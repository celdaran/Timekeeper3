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
    public partial class About : Form
    {
        private Row Info;

        public About(Row info)
        {
            InitializeComponent();
            this.Info = info;
        }

        private void About_Load(object sender, EventArgs e)
        {
            if (Info["FileOpened"]) {
                string Upgraded;
                DateTime t = Info["Upgraded"];
                if (t.Year == 1) {
                    Upgraded = "Never";
                } else {
                    Upgraded = t.ToString(Common.LOCAL_DATETIME_FORMAT);
                }

                FileStatsPanel.Visible = true;
                Height = 247;

                FileStats.Rows.Add("Opened File", Info["FileName"]);
                FileStats.Rows.Add("File Created", Info["Created"].ToString(Common.LOCAL_DATETIME_FORMAT));
                FileStats.Rows.Add("File Upgraded", Upgraded);
                FileStats.Rows.Add("File Schema Version", Info["Version"]);
                FileStats.Rows.Add("File Identifier", Info["Id"]);
                FileStats.Rows.Add("File Size", Info["FileSize"]);
                FileStats.Rows.Add("Number of Journal Entries", Info["EntryCount"]);
                FileStats.Rows.Add("Number of Notebook Entries", Info["NotebookCount"]);
                FileStats.Rows.Add("Number of Projects", Info["ProjectCount"]);
                FileStats.Rows.Add("Number of Activities", Info["ActivityCount"]);
                FileStats.Rows.Add("Total Time Logged", Info["TotalTime"]);
            } else {
                FileStatsPanel.Visible = false;
                Height = 247 - FileStatsPanel.Height;
            }
        }
    }
}