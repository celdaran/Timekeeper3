using System;
using System.IO;
using System.Diagnostics;

using System.Collections.ObjectModel;

using Technitivity.Toolbox;

namespace Timekeeper
{
    public static class Timekeeper
    {
        //---------------------------------------------------------------------
        // Constants
        //---------------------------------------------------------------------

        public const string TITLE = "Timekeeper";
        public const string VERSION = "3.0.0.0";
        public const string IDENTIFIER = "7EFF6E35-2448-4AA8-BBB0-441536BE592F";

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

        //---------------------------------------------------------------------

        public static void Error(string msg)
        {
            Log = GetLog();
            Log.Error(msg);
        }

        //---------------------------------------------------------------------
        // Private helpers
        //---------------------------------------------------------------------

        private static Log GetLog()
        {
            if (Log == null) {
                Log = new Technitivity.Toolbox.Log(GetLogPath());
                // Figure out how to set this globally and/or
                // have this area access Timekeeper's options.
                Log.Level = Technitivity.Toolbox.Log.INFO;
                Log.Debug("log file opened");
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

    }

}
