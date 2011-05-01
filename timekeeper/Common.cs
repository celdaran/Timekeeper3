using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;



namespace Timekeeper
{
    class Common
    {
        public const string VERSION = "2.2.0.0";
        public const string DATE_FORMAT = "yyyy-MM-dd";
        public const string TIME_FORMAT = "HH:mm:ss";
        public const string DATETIME_FORMAT = DATE_FORMAT + " " + TIME_FORMAT;

        public Common()
        {
        }
        
        public static string Today()
        {
            return DateTime.Now.ToString(Common.DATE_FORMAT);
        }

        public static string Now()
        {
            return DateTime.Now.ToString(Common.DATETIME_FORMAT);
        }

        public static string FormatSeconds(int seconds)
        {
            TimeSpan t = TimeSpan.FromSeconds(seconds);
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                                    (t.Days * 24) + t.Hours,
                                    t.Minutes,
                                    t.Seconds);
        }

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

        public static void Info(string msg)
        {
            MessageBox.Show(msg, "Timekeeper", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warn(string msg)
        {
            MessageBox.Show(msg, "Timekeeper", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static DialogResult Prompt(string msg)
        {
            return MessageBox.Show(msg, "Timekeeper", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult WarnPrompt(string msg)
        {
            return MessageBox.Show(msg, "Timekeeper", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

    }
}
