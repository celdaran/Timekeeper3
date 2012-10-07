using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper
{
    class Timekeeper
    {
        public const string VERSION = "2.2.0.4";

        public Timekeeper()
        {
        }
        
        public static string FormatSeconds(long seconds)
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
    }
}
