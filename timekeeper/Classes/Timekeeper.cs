using System;
using System.IO;
using System.Diagnostics;

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
        public const string IDENTIFIER = "AA9FFC4E-5CEB-4E3F-83FE-7EC5D1A33300";

        public const int SUCCESS = 1;
        public const int FAILURE = 0;

        public const int IMG_FOLDER_OPEN = 0;
        public const int IMG_FOLDER_CLOSED = 1;
        public const int IMG_PROJECT = 2;
        public const int IMG_TASK = 3;
        public const int IMG_TASK_TIMER_START = 4;
        public const int IMG_TASK_TIMER_END = 7;
        public const int IMG_TASK_HIDDEN = 8; // UNUSED (why?)

        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        public static DBI Database;
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
            return IDENTIFIER.Replace("-", "_");
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
    }

    //---------------------------------------------------------------------
    // Custom datatypes
    //---------------------------------------------------------------------

    public struct IdValuePair
    {
        public int Id;
        public string Description;

        public IdValuePair(int id, string description) {
            this.Id = id;
            this.Description = description;
        }

        public override string ToString() {
            return this.Description;
        }
    }

    //---------------------------------------------------------------------

    public struct IdObjectPair
    {
        public int Id;
        public object Object;

        public IdObjectPair(int id, object o)
        {
            this.Id = id;
            this.Object = o;
        }

        public override string ToString()
        {
            return this.Object.ToString();
        }
    }

    //---------------------------------------------------------------------

}
