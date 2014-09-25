using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Linq;

using Technitivity.Toolbox;
using Quartz;
using Quartz.Impl;

namespace Timekeeper
{
    public static class Timekeeper
    {
        //---------------------------------------------------------------------
        // Constants
        //---------------------------------------------------------------------

        public const string TITLE = "Timekeeper";
        public const string IDENTIFIER = "7EFF6E35-2448-4AA8-BBB0-441536BE592F";

        public static readonly string VERSION = Assembly.GetEntryAssembly().GetName().Version.ToString();
        public static readonly string SHORT_VERSION = VERSION.Substring(0, 3);

        public static readonly string CWD = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public const int SUCCESS = 1;
        public const int FAILURE = 0;

        public const int IMG_FOLDER = 0;
        public const int IMG_PROJECT = 1;
        public const int IMG_ACTIVITY = 2;
        public const int IMG_LOCATION = 3;
        public const int IMG_CATEGORY = 4;
        public const int IMG_ITEM_HIDDEN = 5;
        public const int IMG_FOLDER_HIDDEN = 6;

        public const char CHAR_UNCHECKEDBOX = '\u2610';
        public const char CHAR_CHECKEDBOX = '\u2611';

        public enum Dimension { Project, Activity, Location, Category };

        public const string DATE_FORMAT = "yyyy-MM-dd";
        public const string LOCAL_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string UTC_DATETIME_FORMAT = "yyyy-MM-ddTHH:mm:sszzz";

        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        public static DBI Database;
        public static Classes.Options Options;

        public static IScheduler Scheduler;
        public static Classes.Messages Mailbox = Classes.Messages.Instance;

        public static string Checkedbox { get { return CHAR_CHECKEDBOX.ToString(); } }
        public static string Uncheckedbox { get { return CHAR_UNCHECKEDBOX.ToString(); } }

        private static Log Log;

        //---------------------------------------------------------------------
        // Database I/O
        //---------------------------------------------------------------------

        public static DBI CloseDatabase()
        {
            Database = null;
            return Database;
        }

        //---------------------------------------------------------------------

        public static DBI OpenDatabase(string dataFile, int logLevel)
        {
            if (Database == null) {
                Database = new DBI(dataFile, logLevel, GetLogPath());
            }
            return Database;
        }

        //---------------------------------------------------------------------
        // Options I/O
        //---------------------------------------------------------------------

        public static Classes.Options CloseOptions()
        {
            Options = null;
            return Options;
        }

        //---------------------------------------------------------------------

        public static Classes.Options OpenOptions()
        {
            if (Options == null) {
                Options = new Classes.Options();
            }
            return Options;
        }

        //---------------------------------------------------------------------
        // Scheduler
        //---------------------------------------------------------------------

        public static void CloseScheduler()
        {
            if (Scheduler == null) {
                Timekeeper.Debug("Attempt to close a null Scheduler.");
            } else {
                Scheduler.Shutdown();
            }
        }

        //---------------------------------------------------------------------

        public static void OpenScheduler()
        {
            if (Options.Advanced_Other_EnableScheduler) {
                ISchedulerFactory ScheduleFactory = new StdSchedulerFactory();
                Scheduler = ScheduleFactory.GetScheduler();
                Scheduler.Start();
            } else {
                Scheduler = null;
            }
        }

        //---------------------------------------------------------------------

        public static void Schedule(Classes.ScheduledEvent scheduledEvent, Forms.Main mainForm)
        {
            if (!Options.Advanced_Other_EnableScheduler) {
                return;
            }

            if (scheduledEvent.Schedule == null) {
                Timekeeper.Debug("Attempting to schedule an undefined schedule.");
                return;
            }

            // Create job
            IJobDetail Job = JobBuilder.Create<Classes.ReminderJob>()
                .WithIdentity(scheduledEvent.Event.Id.ToString(), "Timekeeper")
                .Build();
            Job.JobDataMap.Add("MainForm", mainForm);

            // Determine reminder time
            DateTimeOffset ReminderTime = scheduledEvent.Schedule.ReminderTime(
                scheduledEvent.Event.NextOccurrenceTime,
                (int)scheduledEvent.Reminder.TimeUnit,
                (int)scheduledEvent.Reminder.TimeAmount);

            string Debug =
                "Created Job \"" + Job.Key.ToString() + "\"" +
                " for Event \"" + scheduledEvent.Event.Name + "\"" + 
                " to be Reminded at \"" + Timekeeper.DateForDisplay(ReminderTime) + "\"";
            Timekeeper.Debug(Debug);

            // Create trigger
            Timekeeper.CreateTrigger(scheduledEvent, ReminderTime, Job);
        }

        //---------------------------------------------------------------------

        public static ITrigger CreateTrigger(Classes.ScheduledEvent scheduledEvent, DateTimeOffset reminderTime, IJobDetail job)
        {
            if (!Options.Advanced_Other_EnableScheduler) {
                return null;
            }

            switch (scheduledEvent.Schedule.RefScheduleTypeId)
            {
                case 1: // one time
                    ITrigger SimpleTrigger = scheduledEvent.Schedule.OneTimeTrigger(
                        scheduledEvent.Event.Name,
                        reminderTime);
                    if (job != null)
                        Timekeeper.Scheduler.ScheduleJob(job, SimpleTrigger);
                    return SimpleTrigger;

                case 2: // fixed period
                    ITrigger FixedTrigger = scheduledEvent.Schedule.FixedTrigger(
                        scheduledEvent.Event.Name,
                        reminderTime,
                        (int)scheduledEvent.Schedule.OnceUnit,
                        (int)scheduledEvent.Schedule.OnceAmount);
                    if (job != null)
                        Timekeeper.Scheduler.ScheduleJob(job, FixedTrigger);
                    return FixedTrigger;

                case 3: // daily
                    ITrigger DailyTrigger = scheduledEvent.Schedule.DailyTrigger(
                        scheduledEvent.Event.Name,
                        reminderTime,
                        (int)scheduledEvent.Schedule.DailyTypeId,
                        (int)scheduledEvent.Schedule.DailyIntervalCount);
                    if (job != null)
                        Timekeeper.Scheduler.ScheduleJob(job, DailyTrigger);
                    return DailyTrigger;

                case 4: // weekly
                    ITrigger WeeklyTrigger = scheduledEvent.Schedule.WeeklyTrigger(
                        scheduledEvent.Event.Name,
                        reminderTime);
                    if (job != null)
                        Timekeeper.Scheduler.ScheduleJob(job, WeeklyTrigger);
                    return WeeklyTrigger;

                case 5: // monthly
                    ITrigger MonthlyTrigger = scheduledEvent.Schedule.MonthlyTrigger(
                        scheduledEvent.Event.Name,
                        reminderTime);
                    if (job != null)
                        Timekeeper.Scheduler.ScheduleJob(job, MonthlyTrigger);
                    return MonthlyTrigger;

                case 6: // yearly
                    ITrigger YearlyTrigger = scheduledEvent.Schedule.YearlyTrigger(
                        scheduledEvent.Event.Name,
                        reminderTime);
                    if (job != null)
                        Timekeeper.Scheduler.ScheduleJob(job, YearlyTrigger);
                    return YearlyTrigger;

                case 7: // cronly
                    ITrigger CronTrigger = scheduledEvent.Schedule.CronTrigger(
                        scheduledEvent.Event.Name,
                        reminderTime,
                        scheduledEvent.Schedule.CrontabExpression,
                        "Cronly");
                    if (job != null)
                        Timekeeper.Scheduler.ScheduleJob(job, CronTrigger);
                    return CronTrigger;
            }

            return null;
        }

        //---------------------------------------------------------------------
        // DateTime Helpers
        //---------------------------------------------------------------------
        // IMPORTANT NOTE: Timekeeper very purposefully only uses local time
        // values. There are no UTC dates and (more importantly) no unspecified
        // DateTime values. This was not a light decision.
        //---------------------------------------------------------------------
        // I'm officially abandoning TBX's datetime helper methods in favor of
        // what you see below. While these are very thin and simple one-liners,
        // the point is I now have an abstraction layer which: 1) is under 
        // completely control of the Timekeeper database (i.e., no external
        // dependency upon TBX, and 2) can easily be modified later should I
        // choose to convert from LocalTime to UTC in the future.
        //---------------------------------------------------------------------

        public static string DateForDatabase()
        {
            return DatabaseDateTimeString(Timekeeper.LocalNow);
        }

        //---------------------------------------------------------------------

        public static string DateForDatabase(DateTimeOffset datetime)
        {
            return DatabaseDateTimeString(datetime);
        }

        //---------------------------------------------------------------------

        public static string NullableDateForDatabase(DateTimeOffset? datetime)
        {
            return NullableDatabaseDateTimeString(datetime);
        }

        //---------------------------------------------------------------------

        public static string DateForDisplay()
        {
            return UserDateTimeString(Timekeeper.LocalNow);
        }

        //---------------------------------------------------------------------

        public static string DateForDisplay(DateTimeOffset datetime)
        {
            return UserDateTimeString(datetime);
        }

        //---------------------------------------------------------------------

        public static string NullableDateForDisplay(DateTimeOffset? datetime)
        {
            return NullableUserDateTimeString(datetime);
        }

        //---------------------------------------------------------------------

        public static string TimeForDisplay(DateTimeOffset datetime)
        {
            return UserTimeString(datetime);
        }

        //---------------------------------------------------------------------

        private static string DatabaseDateTimeString(DateTimeOffset datetime)
        {
            return datetime.ToLocalTime().ToString(Timekeeper.LOCAL_DATETIME_FORMAT);
        }

        //---------------------------------------------------------------------

        private static string NullableDatabaseDateTimeString(DateTimeOffset? datetime)
        {
            if ((datetime == null) || (datetime == DateTimeOffset.MinValue)) {
                return null;
            } else {
                DateTimeOffset Converted = (DateTimeOffset)datetime;
                return Converted.ToLocalTime().ToString(Timekeeper.LOCAL_DATETIME_FORMAT);
            }
        }

        //---------------------------------------------------------------------

        private static string UserDateTimeString(DateTimeOffset datetime)
        {
            return datetime.ToLocalTime().ToString(Options.Advanced_DateTimeFormat);
        }

        //---------------------------------------------------------------------

        private static string UserTimeString(DateTimeOffset datetime)
        {
            // TODO/FIXME: implement this: Options.Advanced_TimeFormat);
            return datetime.ToLocalTime().ToString("hh:mm:ss"); 
        }

        //---------------------------------------------------------------------

        private static string NullableUserDateTimeString(DateTimeOffset? datetime)
        {
            if ((datetime == null) || (datetime == DateTimeOffset.MinValue)) {
                return "None";
            } else {
                DateTimeOffset Converted = (DateTimeOffset)datetime;
                return Converted.ToLocalTime().ToString(Options.Advanced_DateTimeFormat);
            }
        }

        //---------------------------------------------------------------------

        public static DateTimeOffset StringToDate(string datetime)
        {
            return datetime == null ? DateTimeOffset.MinValue : DateTimeOffset.Parse(datetime).ToLocalTime();
        }

        //---------------------------------------------------------------------

        public static DateTimeOffset? StringToNullableDate(string datetime)
        {
            if (datetime == null)
                return null;
            else
                return DateTimeOffset.Parse(datetime).ToLocalTime();
        }

        //---------------------------------------------------------------------

        public static DateTimeOffset LocalNow
        {
            get {
                return DateTimeOffset.Now;
            }
        }

        //---------------------------------------------------------------------

        public static DateTime AdjustedToday
        {
            get {
                // 2014-07-22 23:29 + (-3) ==> 7/22
                // 2014-07-23 12:29 + (-3) ==> 7/22
                // 2014-07-23 04:29 + (-3) ==> 7/23
                DateTime AdjustedNow = DateTime.Now.AddHours(-Timekeeper.Options.Advanced_Other_MidnightOffset);
                return AdjustedNow.Date;
            }
        }

        //---------------------------------------------------------------------
        // DateTime Converters
        //---------------------------------------------------------------------
        // 2014-07-14 update: I'm officially ditching the UTC internal datetime
        // storage idea. It's too much work for too little benefit. I'll take
        // it on later when this thing goes a bit more global. For now, it's
        // sucking up too much time. I'm leaving these methods below for later
        // because I would like a standard set of DateTime<-->String methods
        // designed just for TK that take Location.TimeZone into account.
        //---------------------------------------------------------------------

        // If you're wondering where these all went, I backedpeddled from my
        // statements, moved the methods above, and made some modifications.

        //---------------------------------------------------------------------
        // Format Helpers
        //---------------------------------------------------------------------

        public static string ReformatSeconds(string time)
        {
            long Seconds = Timekeeper.UnformatSeconds(time);
            return Timekeeper.FormatSeconds(Seconds);
        }

        //---------------------------------------------------------------------

        public static long UnformatSeconds(string time)
        {
            long seconds = 0;
            long h = 0;
            long m = 0;
            long s = 0;
            bool negative = false;
            char[] units = new char[] {'h', 'H', 'm', 'M', 's', 'S'};

            try {
                if (time.Substring(0, 1) == "-") {
                    // user going back in time
                    negative = true;
                    // strip minus sign from text
                    time = time.Substring(1);
                }

                string[] parts = time.Split(':');

                switch (parts.Length) {
                    case 1:
                        // one part => either minutes or a number with a unit
                        char PossibleUnit = parts[0][parts[0].Length - 1];
                        if (units.Contains(PossibleUnit)) {
                            long value = Convert.ToInt64(parts[0].Substring(0, parts[0].Length - 1));
                            switch (PossibleUnit) {
                                case 'h':
                                case 'H':
                                    h = value * 60 * 60;
                                    break;
                                case 'm':
                                case 'M':
                                    m = value * 60;
                                    break;
                                default:
                                    s = value;
                                    break;
                            }
                        } else {
                            bool AppearsNumeric = long.TryParse(PossibleUnit.ToString(), out m);
                            if (AppearsNumeric) {
                                h = 0;
                                m = Convert.ToInt64(parts[0]) * 60;
                                s = 0;
                            } else {
                                throw new System.ApplicationException("invalid time unit specifier");
                            }
                        }
                        break;
                    case 2:
                        // two parts => minutes seconds
                        h = 0;
                        m = Convert.ToInt64(parts[0]) * 60;
                        s = Convert.ToInt64(parts[1]);
                        if ((m < 0) || (m > 3599)) {
                            throw new System.ApplicationException("invalid minutes");
                        }
                        break;
                    case 3:
                        // three parts => hours minutes seconds
                        h = Convert.ToInt64(parts[0]) * 3600;
                        m = Convert.ToInt64(parts[1]) * 60;
                        s = Convert.ToInt64(parts[2]);
                        if ((m < 0) || (m > 3599)) {
                            throw new System.ApplicationException("invalid minutes");
                        }
                        if ((s < 0) || (s > 59)) {
                            throw new System.ApplicationException("invalid seconds");
                        }
                        break;
                    default:
                        // if it's not 1, 2, or three, do nothing
                        break;
                }

                seconds = h + m + s;
            }
            catch {
                // do anything? -- probably not, just ignore it and 
                // return the default value of 0
            }

            return negative ? -seconds : seconds;
        }

        //---------------------------------------------------------------------

        public static string FormatSeconds(long seconds)
        {
            if (seconds > (9999*60*60 + 59*60 + 59)) {
                Common.Info("Duration greater than 10,000 hours detected.");
            }
            TimeSpan t = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    (t.Days * 24) + t.Hours,
                                    t.Minutes,
                                    t.Seconds);
        }

        //---------------------------------------------------------------------

        public static string FormatTimeSpan(TimeSpan t)
        {
            int days = t.Days;
            if (days > 7) {
                // This is a right royal hack because I apparently
                // don't understand something fundamental about TimeSpan.
                // For some reason my Days value is 733915, which seems
                // to be the number of days from year 1. I'll look into
                // this later. For now, if the number is "too big" then
                // it gets reset to zero here. Sorry.
                days = 0;
            }
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    (days * 24) + t.Hours,
                                    t.Minutes,
                                    t.Seconds);
        }

        //---------------------------------------------------------------------
        // Benchmarking
        //---------------------------------------------------------------------

        public static Stopwatch Bench()
        {
            Stopwatch t = new Stopwatch();
            t.Start();
            return t;
        }

        //---------------------------------------------------------------------
        // TODO: Use my own Stopwatch wrapper class instead of Stopwatch 
        // directly. See Classes.Datatypes for more info.
        //---------------------------------------------------------------------

        public static void Bench(Stopwatch t)
        {
            t.Start();
        }

        //---------------------------------------------------------------------

        public static void Bench(Stopwatch t, string message)
        {
            t.Stop();
            Timekeeper.Debug("BENCH: " + message + ": " + t.ElapsedMilliseconds.ToString() + "ms");
            t.Reset();
            t.Start();
        }

        //---------------------------------------------------------------------
        // Standard Exception Handling
        //---------------------------------------------------------------------

        public static void Exception(Exception x)
        {
            // Get exception text
            string Message = Common.Exception(x, 2);

            // Build message
            Message = String.Format("{0} {1}.", Message, x.StackTrace);

            // Sent output to log
            Log = GetLog();
            Log.Warn(Message);

            // Dump full stack trace, if requested
            if (Options.Advanced_Other_EnableStackTracing) {
                string StackTraceOutput = "Stack trace:";
                var StackTrace = new StackTrace(1, true);
                StackFrame[] Frames = StackTrace.GetFrames();
                foreach (StackFrame f in Frames) {
                    string SourceFileName = f.GetFileName();
                    if (SourceFileName != null) {
                        // Only add to the stack trace if we got a file name back.
                        string StackTraceLine = String.Format("\n  at {0} in {1}:line {2}",
                            f.GetMethod().Name, SourceFileName, f.GetFileLineNumber());
                        StackTraceOutput += StackTraceLine;
                    }
                }
                Log.Warn(StackTraceOutput);
            }
        }

        //---------------------------------------------------------------------

        public static string MetaTableName()
        {
            return "[" + IDENTIFIER + "]";
        }

        //---------------------------------------------------------------------
        // Logging helpers
        //---------------------------------------------------------------------

        public static void Debug(string msg)
        {
            Log = GetLog();
            Log.Debug(msg);
        }

        //---------------------------------------------------------------------

        public static void Info(string msg)
        {
            Log = GetLog();
            Log.Info(msg);
        }

        //---------------------------------------------------------------------

        public static void Warn(string msg)
        {
            Log = GetLog();
            Log.Warn(msg);
        }

        //---------------------------------------------------------------------

        public static void DoubleWarn(string msg)
        {
            Log = GetLog();
            Log.Warn(msg);
            Common.Warn(msg);
        }

        //----------------------------------------------------------------------

        public static void Error(string msg)
        {
            Log = GetLog();
            Log.Error(msg);
        }

        //---------------------------------------------------------------------

        public static void FIXME(string msg)
        {
            Log = GetLog();
            Log.Warn("FIXME: " + msg);
        }

        //---------------------------------------------------------------------

        public static void TODO(string msg)
        {
            Log = GetLog();
            Log.Info("TODO: " + msg);
        }

        //----------------------------------------------------------------------

        public static int GetLogLevel(int level)
        {
            int LogLevel = Log.NONE;

            switch (level) {
                case 0: LogLevel = Log.NONE; break;
                case 1: LogLevel = Log.DEBUG; break;
                case 2: LogLevel = Log.INFO; break;
                case 3: LogLevel = Log.WARN; break;
                case 4: LogLevel = Log.ERROR; break;
            }

            return LogLevel;
        }

        //---------------------------------------------------------------------
        // Random Things
        //---------------------------------------------------------------------

        public static Point CenterInParent(Form parentForm, int width, int height)
        {
            // A manual "CenterParent" function, due to the way I'm
            // managing the wizard forms (sans tabs). These forms, in
            // spite of their visible width, are thousands of pixels
            // wide, and that's what .NET uses to "center" it, which 
            // always puts it to the far left of the monitor. This gets
            // a point which represents the Center in the parent after
            // the width has been visually adjusted.
            int x = parentForm.Location.X + ((parentForm.Width - width) / 2);
            int y = parentForm.Location.Y + ((parentForm.Height - height) / 2);
            return new Point(x, y);
        }

        //---------------------------------------------------------------------

        public static long CurrentTimeZoneId()
        {
            ReadOnlyCollection<TimeZoneInfo> TimeZones = TimeZoneInfo.GetSystemTimeZones();

            TimeZone CurrentTimeZone = TimeZone.CurrentTimeZone;
            long CurrentIndex = 0;

            foreach (TimeZoneInfo Enumerated in TimeZones) {

                if (CurrentTimeZone.StandardName == Enumerated.StandardName) {
                    return CurrentIndex;
                } else {
                    CurrentIndex++;
                }
            }

            return 0;
        }

        //----------------------------------------------------------------------

        // TODO: TBX helper?
        public static object GetValue(object value, object defaultValue)
        {
            if (value == null) {
                return defaultValue;
            } else {
                return value;
            }
        }

        //----------------------------------------------------------------------

        public static string GetFilePath(string fileName)
        {
            return Path.IsPathRooted(fileName) ? fileName : Timekeeper.CWD + Path.DirectorySeparatorChar + fileName;
        }

        //----------------------------------------------------------------------

        // TODO: TBX helper?
        public static string Pluralize(int count, string singluar, string plural)
        {
            if (count == 0)
                // TODO: I'm not 100% sold on "0 ==> No"
                // Just trying it on for size at this point.
                return String.Format(@"No {0}", plural);
            else if (count == 1)
                // I could add an "English" mode which would
                // substitute "No" for 0 and "One" for 1...?
                return String.Format(@"{0} {1}", count, singluar);
            else
                return String.Format(@"{0} {1}", count, plural);
        }

        //----------------------------------------------------------------------

        public static long GetNextSortOrderNo(string tableName)
        {
            return GetNextSortOrderNo(tableName, null);
        }

        //----------------------------------------------------------------------

        public static long GetNextSortOrderNo(string tableName, long? parentId)
        {
            string WhereClause = parentId.HasValue ? "WHERE ParentId = " + parentId.Value : "";

            string Query = String.Format(@"
                SELECT max(SortOrderNo) as HighestSortOrderNo
                FROM {0}
                {1}
                ORDER BY SortOrderNo",
                tableName, WhereClause);
            Row Row = Database.SelectRow(Query);

            if (Row.ContainsKey("HighestSortOrderNo")) {
                if (Row["HighestSortOrderNo"] != null) {
                    return Row["HighestSortOrderNo"] + 1;
                } else {
                    return 1;
                }
            } else {
                return 1;
            }
        }

        //---------------------------------------------------------------------
        // Private helpers
        //---------------------------------------------------------------------

        private static Log GetLog()
        {
            if (Log == null) {
                Log = new Technitivity.Toolbox.Log(GetLogPath(), Timekeeper.UTC_DATETIME_FORMAT);
                Log.Level = GetLogLevel(Options.Advanced_Logging_Application);
                Log.Debug("Log File Opened");
            }
            return Log;
        }

        //---------------------------------------------------------------------

        public static string GetLogPath()
        {
            string LogPath = "";

            try {
                // Determine log file path
                LogPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), Timekeeper.TITLE);

                // Create directory if it doesn't exist
                if (!Directory.Exists(LogPath)) {
                    Directory.CreateDirectory(LogPath);
                }

                // Add filename to path
                LogPath += @"\" + Timekeeper.TITLE + @".log";

                // And that's all we need.
                return LogPath;
            }
            catch (Exception x) {
                // FIXME: Is this appropriate at this level? Consider alternatives
                Common.Warn("Could not open or write to log file.\n\n" + LogPath);
                Common.Warn(x.Message);
                return "";
            }
        }

        //----------------------------------------------------------------------

    }

}
