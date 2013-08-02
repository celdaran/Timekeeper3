using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms
{
    public partial class Properties : Form
    {
        public Properties()
        {
            InitializeComponent();
        }

        private void Properties_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string Topic = String.Format("html\\context\\fProperties\\{0}.html", c.Name);
            Timekeeper.Info("Calling help topic: " + Topic);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, Topic);
        }

    }
}