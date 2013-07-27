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

            string Upgraded;
            DateTime t = info["Upgraded"];
            if (t.Year == 1) {
                Upgraded = "Never";
            } else {
                Upgraded = t.ToString(Common.LOCAL_DATETIME_FORMAT);
            }

            wStats.Rows.Add("Opened File", info["FileName"]);
            wStats.Rows.Add("File Created", info["Created"].ToString(Common.LOCAL_DATETIME_FORMAT));
            wStats.Rows.Add("File Upgraded", Upgraded);
            wStats.Rows.Add("File Schema Version", info["Version"]);
            wStats.Rows.Add("File Identifier", info["Id"]);
            wStats.Rows.Add("File Size", info["FileSize"]);
            wStats.Rows.Add("Number of Journal Entries", info["EntryCount"]);
            wStats.Rows.Add("Number of Notebook Entries", info["NotebookCount"]);
            wStats.Rows.Add("Number of Projects", info["ProjectCount"]);
            wStats.Rows.Add("Number of Activities", info["ActivityCount"]);
            wStats.Rows.Add("Total Time Logged", info["TotalTime"]);
        }
    }
}