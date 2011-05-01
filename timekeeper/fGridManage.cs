using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper
{
    public partial class fGridManage : Form
    {
        DBI data;

        public fGridManage(DBI data)
        {
            InitializeComponent();
            this.data = data;
            _load_list();
        }

        private void _load_list()
        {
            wViewList.Items.Clear();

            data.begin();

            String query = String.Format(@"select * from grid_views order by sort_index");
            RowSet rows = data.select(query);

            foreach (Row row in rows)
            {
                Pair pair = new Pair(row["name"], row["sort_index"]);
                wViewList.Items.Add(pair);
            }

            data.commit();
        }

        private void btnMoveUp_Click(object sender, EventArgs e)
        {
            Pair curr = (Pair)wViewList.SelectedItem;
            if (curr == null) {
                return;
            }
            int i = wViewList.Items.IndexOf(curr);
            Pair prev = (Pair)wViewList.Items[i - 1];

            // Begin unit of work
            data.begin();

            // Update current row with previous row's sort_index
            Row row = new Row();
            row["sort_index"] = prev.value.ToString();
            data.update("grid_views", row, "name", curr.name);

            // Update previous row with current row's sort_index
            row = new Row();
            row["sort_index"] = curr.value.ToString();
            data.update("grid_views", row, "name", prev.name);

            // Now just repaint whole form
            _load_list();

            // Complete unit of work
            data.commit();

            // And reselect item
            wViewList.SelectedIndex = i - 1;
        }

        private void btnMoveDown_Click(object sender, EventArgs e)
        {
            Pair curr = (Pair)wViewList.SelectedItem;
            if (curr == null) {
                return;
            }
            int i = wViewList.Items.IndexOf(curr);
            Pair next = (Pair)wViewList.Items[i + 1];

            // Begin unit of work
            data.begin();

            // Update current row with next row's sort_index
            Row row = new Row();
            row["sort_index"] = next.value.ToString();
            data.update("grid_views", row, "name", curr.name);

            // Update next row with current row's sort_index
            row = new Row();
            row["sort_index"] = curr.value.ToString();
            data.update("grid_views", row, "name", next.name);

            // Now just repaint whole form
            _load_list();

            // Complete unit of work
            data.commit();

            // And reselect item
            wViewList.SelectedIndex = i + 1;
        }

        private void wViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = wViewList.SelectedIndex;
            btnMoveUp.Enabled = (i != 0);
            btnMoveDown.Enabled = (i != wViewList.Items.Count - 1);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = 0;
            List<Pair> removed = new List<Pair>();

            // Begin unit of work
            data.begin();

            // First delete from db
            foreach (Pair row in wViewList.CheckedItems)
            {
                int i = wViewList.Items.IndexOf(row);
                removed.Add(row);
                data.delete("grid_views", "name", row.name);
                count++;
            }

            // Now remove from widget
            foreach (Pair p in removed)
            {
                wViewList.Items.Remove(p);
            }

            // Complete unit of work
            data.commit();

            // User feedback
            Common.Info(count + " item(s) were deleted.");
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            Pair curr = (Pair)wViewList.SelectedItem;
            if (curr == null) {
                return;
            }

            fGridManageRename dlg = new fGridManageRename();
            dlg.wNewName.Text = curr.name;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Begin unit of work
                data.begin();

                // check for uniqueness
                Row row = data.selectRow(String.Format(@"select count(*) as count from grid_views where name = '{0}'", dlg.wNewName.Text.Replace("'", "''")));
                if (row["count"] == "1") {
                    data.rollback();
                    Common.Warn("A view with that name already exists.");
                    return;
                }

                // now rename
                row = new Row();
                row["name"] = dlg.wNewName.Text;
                data.update("grid_views", row, "name", curr.name);

                // Now just repaint whole form
                _load_list();

                // Complete unit of work
                data.commit();
            }
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fGridManage\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

    }
}
