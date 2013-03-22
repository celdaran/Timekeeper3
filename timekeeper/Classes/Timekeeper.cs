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

        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private static Log Log;

        //---------------------------------------------------------------------
        // Helper Methods (TBX candidates?)
        //---------------------------------------------------------------------

        public static string Abbreviate(string text, int length)
        {
            if (text.Length < length) {
                return text;
            } else {
                return text.Substring(0, length - 3) + "...";
            }
        }

        //---------------------------------------------------------------------

        public static void Exception(Exception x)
        {
            if (Log == null) {
                Log = new Log(GetPath());
            }
            StackTrace StackTrace = new StackTrace();
            StackFrame StackFrame = StackTrace.GetFrame(1);
            string msg = String.Format(@"Exception in {0}.{1}: {2}",
                StackFrame.GetMethod().DeclaringType, StackFrame.GetMethod().Name, x.Message);
            Log.Warn(msg);
        }

        //---------------------------------------------------------------------

        public static void Info(string msg)
        {
            if (Log == null) {
                Log = new Log(GetPath());
            }
            Log.Info(msg);
        }

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

        public static void Warn(string msg)
        {
            if (Log == null) {
                Log = new Log(GetPath());
            }
            Log.Warn(msg);
        }

        //---------------------------------------------------------------------
        // Private helpers
        //---------------------------------------------------------------------

        private static string GetPath()
        {
            // Determine log file path
            string LogPath = Path.Combine(
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

        //---------------------------------------------------------------------

    }
}
