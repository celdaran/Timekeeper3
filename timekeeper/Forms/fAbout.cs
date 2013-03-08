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
            wStats.Rows.Add("File Schema Version", info["version"]);
            wStats.Rows.Add("File Identifier", info["id"]);
            wStats.Rows.Add("File Size", info["filesize"]);
            wStats.Rows.Add("Number of Tasks", info["taskcount"]);
            wStats.Rows.Add("Number of Projects", info["projectcount"]);
            wStats.Rows.Add("Number of Journal Entries", info["journalcount"]);
            wStats.Rows.Add("Number of Log Entries", info["logcount"]);
            wStats.Rows.Add("Total Time Logged", info["totalseconds"]);
        }
    }
}