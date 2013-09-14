using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Tools
{
    public partial class Notebook : Form
    {
        public bool is_dirty = false;
        private DBI data;
        private Classes.Notebook NotebookRenameMe;

        public Notebook(DBI data)
        {
            InitializeComponent();
            this.data = data;
        }

        private void fToolJournal_Load(object sender, EventArgs e)
        {
            NotebookRenameMe = new Classes.Notebook();
            Table Entries = NotebookRenameMe.Entries();

            foreach (Row Entry in Entries) {
                wJumpBox.Items.Add(Entry["EntryTime"].ToString(Common.DATETIME_FORMAT));
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
            string CreateTime = wJumpBox.Items[wJumpBox.SelectedIndex].ToString();

            DateTime dt;
            dt = Convert.ToDateTime(CreateTime);

            string query = "select * from Notebook where CreateTime = '" + dt.ToString(Common.DATETIME_FORMAT) + "'";
            Row row = data.SelectRow(query);
            wEntry.Text = row["Memo"];

            wEntryDate.Value = dt;
        }

        private void wEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.is_dirty = true;
        }


    }
}
