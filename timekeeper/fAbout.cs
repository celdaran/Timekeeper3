using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper
{
    public partial class fAbout : Form
    {
        public fAbout(Row info)
        {
            InitializeComponent();

            wStats.Rows.Add("Opened File", info["filename"]);
            wStats.Rows.Add("File Created", info["created"]);
            wStats.Rows.Add("File Version", info["version"]);
            wStats.Rows.Add("File Identifier", info["id"]);
            wStats.Rows.Add("File Size", info["filesize"]);
            wStats.Rows.Add("Number of Tasks", info["taskcount"]);
            wStats.Rows.Add("Number of Projects", info["projectcount"]);
            wStats.Rows.Add("Number of Log Entries", info["logcount"]);
            wStats.Rows.Add("Total Time Logged", info["totalseconds"]);
            wStats.Rows.Add("Number of Journal Entries", info["journalcount"]);
        }

        private void btnUUID_Click(object sender, EventArgs e)
        {
            wUUID.Text = UUID.Get();
            string cb = "";

            DateTime startTime = DateTime.Now;

            for (int i = 0; i < 65535; i++) {
                string uuid = UUID.Get(); // getUnique(); // getHighSpeed();
                //wUUIDs.Items.Add(uuid);
                //cb += uuid + "\r\n";

                /*
                long t = DateTime.Now.Ticks;
                wTicks.Items.Add(t);
                cb += t.ToString() + "\n";
                */
            }

            cb = "Suppressed for benchmarking";

            DateTime endTime = DateTime.Now;
            TimeSpan elapsed = new TimeSpan(endTime.Ticks - startTime.Ticks);

            Clipboard.SetText(cb);
            wElapsed.Text = elapsed.TotalMilliseconds.ToString();
        }


    }
}