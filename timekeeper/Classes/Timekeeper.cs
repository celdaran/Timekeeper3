using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Collections.ObjectModel;

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

        public static readonly string VERSION = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        public static readonly string SHORT_VERSION = VERSION.Substring(0, 3);

        public const int SUCCESS = 1;
        public const int FAILURE = 0;

        public const int IMG_FOLDER_OPEN = 0;
        public const int IMG_FOLDER_CLOSED = 1;
        public const int IMG_PROJECT = 2;
        public const int IMG_ACTIVITY = 3;
        public const int IMG_TIMER_START = 4;
        public const int IMG_TIMER_END = 7;
        public const int IMG_ITEM_HIDDEN = 8;
        public const int IMG_FOLDER_HIDDEN = 9;

        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        public static DBI Database;
        public static Classes.Options Options;
        public static IScheduler Scheduler;
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
                Timekeeper.Warn("Could not close a null Scheduler");
            } else {
                Scheduler.Shutdown();
            }
        }

        //---------------------------------------------------------------------

        public static void OpenScheduler()
        {
            ISchedulerFactory ScheduleFactory = new StdSchedulerFactory();
            Scheduler = ScheduleFactory.GetScheduler();
            Scheduler.Start();
        }

        //---------------------------------------------------------------------

        public static void Schedule(Classes.ScheduledEvent ScheduledEvent, Forms.Main mainForm)
        {
            if (ScheduledEvent.Schedule == null) {
                Timekeeper.Debug("Attempting to schedule an undefined schedule");
                return;
            }

            // Create job
            IJobDetail Job = JobBuilder.Create<Classes.ReminderJob>()
                .WithIdentity(ScheduledEvent.Event.Id.ToString(), "Timekeeper")
                .Build();
            Job.JobDataMap.Add("MainForm", mainForm);

            // Determine reminder time
            DateTime ReminderTime = ScheduledEvent.Schedule.ReminderTime(
                ScheduledEvent.Event.NextOccurrenceTime.LocalDateTime,
                (int)ScheduledEvent.Reminder.TimeUnit,
                (int)ScheduledEvent.Reminder.TimeAmount);

            string Debug =
                "Created Job \"" + Job.Key.ToString() + "\"" +
                " for Event \"" + ScheduledEvent.Event.Name + "\"" + 
                " to be Reminded at \"" + ReminderTime.ToString(Common.LOCAL_DATETIME_FORMAT) + "\"";
            Timekeeper.Debug(Debug);

            // Create trigger
            switch (ScheduledEvent.Schedule.RefScheduleTypeId) {
                case 1: // one time
                    ITrigger SimpleTrigger = ScheduledEvent.Schedule.OneTimeTrigger(
                        ScheduledEvent.Event.Name, 
                        ReminderTime);
                    Timekeeper.Scheduler.ScheduleJob(Job, SimpleTrigger);
                    break;

                case 2: // fixed period
                    ITrigger FixedTrigger = ScheduledEvent.Schedule.FixedTrigger(
                        ScheduledEvent.Event.Name, 
                        ReminderTime,
                        (int)ScheduledEvent.Schedule.OnceUnit,
                        (int)ScheduledEvent.Schedule.OnceAmount);
                    Timekeeper.Scheduler.ScheduleJob(Job, FixedTrigger);
                    break;

                case 3: // daily
                    ITrigger DailyTrigger = ScheduledEvent.Schedule.DailyTrigger(
                        ScheduledEvent.Event.Name,
                        ReminderTime,
                        (int)ScheduledEvent.Schedule.DailyTypeId,
                        (int)ScheduledEvent.Schedule.DailyIntervalCount);
                    Timekeeper.Scheduler.ScheduleJob(Job, DailyTrigger);
                    break;

                case 4: // weekly
                    ITrigger WeeklyTrigger = ScheduledEvent.Schedule.WeeklyTrigger(
                        ScheduledEvent.Event.Name,
                        ReminderTime);
                    Timekeeper.Scheduler.ScheduleJob(Job, WeeklyTrigger);
                    Debug += WeeklyTrigger.Key.ToString();
                    break;

                case 5: // monthly
                    ITrigger MonthlyTrigger = ScheduledEvent.Schedule.MonthlyTrigger(
                        ScheduledEvent.Event.Name,
                        ReminderTime);
                    Timekeeper.Scheduler.ScheduleJob(Job, MonthlyTrigger);
                    break;

                case 6: // yearly
                    ITrigger YearlyTrigger = ScheduledEvent.Schedule.YearlyTrigger(
                        ScheduledEvent.Event.Name,
                        ReminderTime);
                    Timekeeper.Scheduler.ScheduleJob(Job, YearlyTrigger);
                    break;

                case 7: // cronly
                    ITrigger CronTrigger = ScheduledEvent.Schedule.CronTrigger(
                        ScheduledEvent.Event.Name,
                        ReminderTime,
                        ScheduledEvent.Schedule.CrontabExpression,
                        "Cronly");
                    Timekeeper.Scheduler.ScheduleJob(Job, CronTrigger);
                    break;
            }
        }

        //---------------------------------------------------------------------
        // Standard Exception Handling
        //---------------------------------------------------------------------

        public static void Exception(Exception x)
        {
            Log = GetLog();
            string msg = Common.Exception(x, 2);
            Log.Warn(msg);
        }

        //---------------------------------------------------------------------

        public static string MetaTableName()
        {
            return "[" + IDENTIFIER + "]";
        }

        //---------------------------------------------------------------------
        // Format Helpers
        //---------------------------------------------------------------------

        public static string FormatSeconds(long seconds)
        {
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
        // Private helpers
        //---------------------------------------------------------------------

        private static Log GetLog()
        {
            if (Log == null) {
                Log = new Technitivity.Toolbox.Log(GetLogPath());
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

        public static long GetNextSortOrderNo(string tableName)
        {
            return GetNextSortOrderNo(tableName, -1);
        }

        //----------------------------------------------------------------------

        public static long GetNextSortOrderNo(string tableName, long parentId)
        {
            string WhereClause = parentId > -1 ? "WHERE ParentId = " + parentId : "";

            string Query = String.Format(@"
                SELECT max(SortOrderNo) as HighestSortOrderNo
                FROM {0}
                {1}
                ORDER BY SortOrderNo",
                tableName, WhereClause);
            Row Row = Database.SelectRow(Query);

            if (Row["HighestSortOrderNo"] != null) {
                return Row["HighestSortOrderNo"] + 1;
            } else {
                return 1;
            }
        }

        //----------------------------------------------------------------------

    }

}
