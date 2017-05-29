using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Forms.Tools
{
    public partial class Stopwatch : Form
    {
        DateTime startTime;
        DateTime endTime;
        DateTime now;
        TimeSpan accumulated;
        TimeSpan ts;

        public Stopwatch()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (timer.Enabled) {
                endTime = Timekeeper.LocalNow.DateTime;
                accumulated += endTime.Subtract(startTime);
                btnStart.Text = "&Start";
                timer.Enabled = false;
                btnReset.Enabled = true;
                btnSplit.Enabled = false;
            }
            else
            {
                startTime = Timekeeper.LocalNow.DateTime;
                btnStart.Text = "&Stop";
                timer.Enabled = true;
                btnReset.Enabled = false;
                btnSplit.Enabled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            accumulated = new TimeSpan();
            wDisplay.Text = "00:00:00.00";
            wSplits.Rows.Clear();
        }


        private void btnSplit_Click(object sender, EventArgs e)
        {
            string[] row = {wDisplay.Text, Timekeeper.DateForDisplay()};
            wSplits.Rows.Add(row);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            now = Timekeeper.LocalNow.DateTime;
            ts = now.Subtract(startTime);
            ts = ts.Add(accumulated);
            wDisplay.Text = string.Format(
                "{0:D2}:{1:D2}:{2:D2}.{3:D2}",
                ts.Hours, ts.Minutes, ts.Seconds, (ts.Milliseconds / 10));

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fToolStopwatch\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

    }
}
