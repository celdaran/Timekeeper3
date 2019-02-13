using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper
{
    public partial class About : Form
    {
        private Row Info;
        private Classes.Options Options;

        public About(Row info)
        {
            InitializeComponent();
            this.Info = info;
            this.Options = Timekeeper.Options;
        }

        private void About_Load(object sender, EventArgs e)
        {
            try {
                //----------------------------------------------
                // Fill out Application info
                //----------------------------------------------

                ApplicationName.Text = Timekeeper.TITLE + " " + Timekeeper.SHORT_VERSION;
                ApplicationRelease.Text = "Version " + Timekeeper.VERSION + " (Released " + Timekeeper.RELEASE_DATE + ")";
                ApplicationCopyright.Text = Timekeeper.COPYRIGHT;

                //----------------------------------------------
                // View or Hide Statistics
                //----------------------------------------------

                if (Info["FileOpened"]) {
                    string Upgraded;
                    DateTimeOffset UpgradedTime = Info["Upgraded"];
                    DateTimeOffset CreatedTime = Info["Created"];
                    if (CreatedTime.CompareTo(UpgradedTime) == 0) {
                        Upgraded = "Never";
                    } else {
                        Upgraded = UpgradedTime.ToString(Options.Advanced_DateTimeFormat);
                    }

                    FileStatsPanel.Visible = true;
                    Height = 247;

                    FileStats.Rows.Add("Opened File", Info["FileName"]);
                    FileStats.Rows.Add("File Created", Info["Created"].ToString(Options.Advanced_DateTimeFormat));
                    FileStats.Rows.Add("File Upgraded", Upgraded);
                    FileStats.Rows.Add("File Schema Version", Info["Version"]);
                    FileStats.Rows.Add("File Identifier", Info["Id"]);
                    FileStats.Rows.Add("File Size", Info["FileSize"]);
                    FileStats.Rows.Add("Number of Journal Entries", Info["EntryCount"]);
                    FileStats.Rows.Add("Number of Notebook Entries", Info["NotebookCount"]);
                    FileStats.Rows.Add("Number of Projects", Info["ProjectCount"]);
                    FileStats.Rows.Add("Number of Activities", Info["ActivityCount"]);
                    FileStats.Rows.Add("Number of Locations", Info["LocationCount"]);
                    FileStats.Rows.Add("Number of Categories", Info["CategoryCount"]);
                    FileStats.Rows.Add("Total Time Logged", Info["TotalTime"]);
                } else {
                    FileStatsPanel.Visible = false;
                    Height = 247 - FileStatsPanel.Height;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }
    }
}