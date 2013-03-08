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
    public partial class fGridFilter : Form
    {
        DBI data;
        bool loaded;

        public fGridFilter(DBI data)
        {
            InitializeComponent();
            this.data = data;
            this.loaded = false;
        }

        private void fGridFilter_Load(object sender, EventArgs e)
        {
            data.Begin();

            if (!loaded)
            {
                _load("tasks", wTaskList);
                _load("projects", wProjectList);
            }

            data.Commit();
        }

        internal void _load(string table, CheckedListBox list)
        {
            string query = String.Format(@"select * from {0} where is_folder = 0 and is_deleted = 0", table);
            Table rows = data.Select(query);

            foreach (Row row in rows)
            {
                Pair item = new Pair();
                item.Key = (int)row["id"];
                item.Value = row["name"];
                list.Items.Add(item);
            }

            this.loaded = true;
        }

        internal void _set_checks(CheckedListBox list, string values)
        {
            if (values == null) {
                return;
            }

            string[] ids = values.Split(new Char [] {','});

            // ids = {'234ADF', '234EDF', 'CA04FF'}

            for (int i = 0; i < list.Items.Count; i++) {
                Pair pair = (Pair)list.Items[i];
                int index = Array.IndexOf(ids, pair.Key.ToString());
                //Common.Info("index of " + pair.Key.ToString() + " in array is " + index);
                if (index >= 0) {
                    list.SetItemChecked(i, true);
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < wTaskList.Items.Count; i++) {
                wTaskList.SetItemChecked(i, false);
            }

            for (int i = 0; i < wProjectList.Items.Count; i++) {
                wProjectList.SetItemChecked(i, false);
            }
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fGridFilter\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

    }


}
