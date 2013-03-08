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
    public partial class fItem : Form
    {
        private DBI data;

        public fItem(DBI data, string table)
        {
            InitializeComponent();
            this.data = data;
            string query = String.Format(@"select * from {0} where is_deleted = 0 and is_hidden = 0 and is_folder = 1", table);
            Table rows = data.Select(query);
            wParent.Items.Add("(Top Level)");
            foreach (Row row in rows) {
                wParent.Items.Add(row["name"]);
            }
        }

        private void fNode_Load(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fItem\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

    }
}