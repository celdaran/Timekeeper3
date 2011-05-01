using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper
{
    public partial class fToolJournal : Form
    {
        public bool is_dirty = false;
        private DBI data;

        public fToolJournal(DBI data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void fToolJournal_Load(object sender, EventArgs e)
        {
            string query = "select id, timestamp_c from journal order by timestamp_c";
            RowSet rows = data.select(query);

            foreach (Row row in rows) {
                DateTime dt;
                dt = Convert.ToDateTime(row["timestamp_c"]);
                wJumpBox.Items.Add(dt.ToString(Common.DATETIME_FORMAT));
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void fToolsJournal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.is_dirty == true) && (DialogResult != DialogResult.OK))
            {
                if (Common.WarnPrompt("Text has changed. Continue closing?") != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void wEntry_TextChanged(object sender, EventArgs e)
        {
            //this.is_dirty = true;
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fToolJournal\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

        private void wJumpBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string timestamp_c = wJumpBox.Items[wJumpBox.SelectedIndex].ToString();

            DateTime dt;
            dt = Convert.ToDateTime(timestamp_c);

            string query = "select * from journal where timestamp_c = '" + dt.ToString(Common.DATETIME_FORMAT) + "'";
            Row row = data.selectRow(query);
            wEntry.Text = row["description"];

            wEntryDate.Value = dt;
        }

        private void wEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.is_dirty = true;
        }


    }
}
