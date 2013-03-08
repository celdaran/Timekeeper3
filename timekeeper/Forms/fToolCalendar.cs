using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper
{
    public partial class fToolCalendar : Form
    {
        public fToolCalendar()
        {
            InitializeComponent();
        }

        private void fCalendar_Load(object sender, EventArgs e)
        {
            //wCalendar.TodayDate = Convert.ToDateTime("January 1");
            wCalendar.SelectionStart = Convert.ToDateTime("January 1");
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
            string topic = String.Format("html\\context\\fCalendar\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

    }
}