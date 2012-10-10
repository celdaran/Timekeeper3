using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

using System.Diagnostics;

using Technitivity.Toolbox;

namespace Timekeeper
{
    public partial class fGrid : Form
    {
        private DBI data;

        private string task_list;
        private string project_list;
        private string sLoadedViewName;
        private string sLoadedViewDescription;

        private string sBeforeDate;

        private fGridFilter dlgGridFilter;

        public string lastGridView;

        private int loopCount;

        public fGrid(DBI data)
        {
            InitializeComponent();
            this.data = data;

            // Some interface defaults
            wDatePreset.SelectedItem = "This Month";
            wGroupBy.SelectedItem = "Month";
            wDataType.SelectedIndex = 0;
            wTimeFormat.SelectedIndex = 0;

            // Begin unit of work
            this.data.Begin();

            // Populate the LoadView menu
            _populate_loadview();

            // Instantiate the filter here (FIXME: this is a bit ugly)
            dlgGridFilter = new fGridFilter(data);
            dlgGridFilter._load("tasks", dlgGridFilter.wTaskList);
            dlgGridFilter._load("projects", dlgGridFilter.wProjectList);

            // Complete unit of work
            this.data.Commit();

            // Set focus to first control
            ActiveControl = wDatePreset;
        }

        private void fGrid_Load(object sender, EventArgs e)
        {
            _set_start_date();
            _load_view_by_name(this.lastGridView);
            //_load_grid(sender, e);
            _load_grid2();
            _saveLastView(true);
        }

        private void wDatePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            _set_start_date();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (wStartDate.Text.CompareTo(wEndDate.Text) > 0) {
                Common.Info("Start date is set past end date.");
                return;
            }

            // Automatically save the last view with every refresh
            _saveLastView(false);

            // Populate the dropdown
            _populate_loadview();

            // Then load it
            //_load_grid(sender, e);
            _load_grid2();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Application.Exit(); // for quick testing
            Hide();
        }

        private void wHideEmptyRows_Click(object sender, EventArgs e)
        {
            _toggle_empty_rows();
        }

        //-------------------------------
        // Internal helpers
        //-------------------------------

        private void _load_grid2()
        {
            /*
            _load_grid(null, null);
            return;
            */

            //-----------------------------------
            // Initialization
            //-----------------------------------

            var t = new Stopwatch();
            t.Start();

            // Start with a blank grid
            wGrid.Columns.Clear();

            //-----------------------------------
            // Query setup
            //-----------------------------------

            // Handle date ranges
            string sStartDate = wStartDate.Text + " 00:00:00";
            string sEndDate = wEndDate.Text + " 23:59:59";

            // Handle grouping
            string sGroupBy = "";
            switch (wGroupBy.Text) {
                case "Day": sGroupBy = "%Y/%m/%d"; break;
                case "Week": sGroupBy = "%Y, %W"; break;
                case "Month": sGroupBy = "%Y/%m"; break;
                case "Year": sGroupBy = "%Y"; break;
            }

            // Handle filtering
            string sTaskList;
            string sProjectList;

            if (task_list != null) {
                sTaskList = " and task_id in (" + task_list + ")";
            } else {
                sTaskList = "";
            }

            if (project_list != null) {
                sProjectList = " and project_id in (" + project_list + ")";
            } else {
                sProjectList = "";
            }

            // Get table name from Data Type dropdown
            string tableName = wDataType.Text.Substring(0, wDataType.Text.Length - 1).ToLower();

            // Get data
            var query = String.Format(@"
                select
                    i.name as name, 
                    strftime('{0}', tk.timestamp_s) as grouping, 
                    sum(tk.seconds) as seconds
                from timekeeper tk
                join {1}s i on i.id = tk.{1}_id
                where timestamp_s >= '{2}'
                  and timestamp_s <= '{3}'
                  {4} {5}
                group by i.name, grouping
                order by i.name, grouping",
                sGroupBy, tableName, sStartDate, sEndDate, sTaskList, sProjectList);

            Table table = data.Select(query);

            //-----------------------------------
            // Build up grid in memory
            //-----------------------------------

            // Three structures: unique row values, unique column values, and a grid
            var items = new Row();
            var buckets = new Row();
            var grid = new Dictionary<string, Dictionary<string, long>>();

            // Build up from query results
            foreach (Row r in table) {
                if (items.ContainsKey(r["name"])) {
                    items[r["name"]]++;
                } else {
                    items[r["name"]] = 1;
                }

                if (buckets.ContainsKey(r["grouping"])) {
                    buckets[r["grouping"]]++;
                } else {
                    buckets[r["grouping"]] = 1;
                }

                if (grid.ContainsKey(r["name"])) {
                    grid[r["name"]].Add(r["grouping"], r["seconds"]);
                } else {
                    var cell = new Dictionary<string, long>();
                    cell[r["grouping"]] = r["seconds"];
                    grid.Add(r["name"], cell);
                }
            }

            //-----------------------------------
            // Populate grid from memory
            //-----------------------------------

            // Add one column for the item
            _create_new_column("item",
                wDataType.Text.Substring(0, wDataType.Text.Length - 1),
                DataGridViewContentAlignment.MiddleLeft,
                true);

            // Add one column for each bucket
            var bucketList = buckets.Keys.ToList();
            bucketList.Sort();
            foreach (string key in bucketList) {
                int id = wGrid.Columns.Add(key, key);
                wGrid.Columns[id].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                wGrid.Columns[id].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                wGrid.Columns[id].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            // Add one column for the row totals
            _create_new_column("total", "Total", DataGridViewContentAlignment.MiddleRight, false);

            // Add one row for each item
            var itemList = items.Keys.ToList();
            itemList.Sort();
            foreach (string key in itemList) {
                wGrid.Rows.Add(key);
            }

            // Add one row for column totals
            int totalRow = wGrid.Rows.Add("Total");
            wGrid.Rows[totalRow].DefaultCellStyle.BackColor = Color.AliceBlue;

            // Now fill in the middle
            loopCount = 0;
            int x = 0; int y = 0;
            long rowTotal;
            long seconds;
            foreach (string item in itemList) {
                x = 0;
                rowTotal = 0;
                foreach (string bucket in bucketList) {
                    //wGrid.Rows[y].Cells[x + 1].Value = String.Format("({0},{1})", bucket, item);
                    //wGrid.Rows[y].Cells[x + 1].Value = _seconds(table, bucket, item);
                    if (grid[item].ContainsKey(bucket)) {
                        seconds = grid[item][bucket];
                        string c = _format_cell2(wTimeFormat.SelectedIndex, seconds);
                        wGrid.Rows[y].Cells[x + 1].Value = c; // grid[item][bucket];
                        wGrid.Rows[y].Cells[x + 1].Tag = seconds;
                        rowTotal += seconds;
                    }
                    x++;
                }
                wGrid.Rows[y].Cells[x + 1].Value = _format_cell2(wTimeFormat.SelectedIndex, rowTotal);
                wGrid.Rows[y].Cells[x + 1].Tag = rowTotal;
                y++;
            }

            //-----------------------------------
            // Lastly, add column totals
            //-----------------------------------

            long colTotal = 0;
            int colNo = 0;
            foreach (DataGridViewColumn col in wGrid.Columns) {
                if (colNo > 0) {
                    colTotal = 0;
                    foreach (DataGridViewRow row in wGrid.Rows) {
                        if (row.Cells[col.Name].Tag != null)
                            colTotal += (long)row.Cells[col.Name].Tag;
                    }
                    wGrid.Rows[wGrid.Rows.Count - 1].Cells[colNo].Value = _format_cell2(wTimeFormat.SelectedIndex, colTotal);
                    //wGrid.Rows[wGrid.Rows.Count - 1].Cells[colNo].
                }
                colNo++;
            }

            //-----------------------------------
            // Cleanup
            //-----------------------------------

            t.Stop();
            //Common.Info("Elapsed time: " + t.ElapsedMilliseconds.ToString());
        }

        private string _seconds(Table table, string bucket, string item)
        {
            foreach (Row r in table) {
                if ((r["name"] == item) && (r["grouping"] == bucket)) {
                    return r["seconds"].ToString();
                }
                loopCount++;
            }
            return "";
        }

        private void _load_grid(object sender, EventArgs e)
        {
            // Begin unit of work
            data.Begin();

            var t = new Stopwatch();
            t.Start();

            // Start with a blank grid
            wGrid.Columns.Clear();

            // Add task/project column
            _create_new_column("item", 
                wDataType.Text.Substring(0, wDataType.Text.Length - 1), 
                DataGridViewContentAlignment.MiddleLeft,
                true);

            // First, populate leftmost column with list of tasks/projects
            // FIXME: dangerous query building; please come back and clean up
            String query = String.Format(@"select * from {0} where is_folder = 0 and is_deleted = 0", wDataType.Text);
            Table rows = data.Select(query);

            // This is the expensive section
            if (rows.Count > 0)
            {
                if (rows.Count > 1000) {
                    if (Common.Prompt("Your criteria may take a while to display. Continue?") != DialogResult.Yes) {
                        return;
                    }
                }

                // Stub in one row for each task/project found
                foreach (Row row in rows) {
                    wGrid.Rows.Add(row["name"]);
                }

                // Handle date ranges
                string sStartDate = wStartDate.Text + " 00:00:00";
                string sEndDate = wEndDate.Text + " 23:59:59";

                // Handle grouping
                string sGroupBy;
                switch (wGroupBy.Text) {
                    case "Day": sGroupBy = "%Y/%m/%d"; break;
                    case "Week": sGroupBy = "%Y, %W"; break;
                    case "Month": sGroupBy = "%Y/%m"; break;
                    case "Year": sGroupBy = "%Y"; break;
                    default: sGroupBy = ""; break;
                }

                // Handle filtering
                string sTaskList;
                string sProjectList;

                if (task_list != null) {
                    sTaskList = " and task_id in (" + task_list + ")";
                } else { 
                    sTaskList = "";
                }

                if (project_list != null) {
                    sProjectList = " and project_id in (" + project_list + ")";
                } else {
                    sProjectList = "";
                }


                // Stub in one column for each time grouping found (if any)
                if (sGroupBy != "")
                {
                    query = String.Format(@"
                        select strftime('{0}', timestamp_s) AS grouping, sum(seconds) as seconds
                        from timekeeper
                        where timestamp_s >= '{1}'
                          and timestamp_s <= '{2}'
                          {3} {4}
                        group by grouping
                        order by grouping", sGroupBy, sStartDate, sEndDate, sTaskList, sProjectList);

                    Table columns = data.Select(query);
                    foreach (Row column in columns)
                    {
                        int id = wGrid.Columns.Add(column["grouping"], column["grouping"]);
                        wGrid.Columns[id].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        wGrid.Columns[id].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        wGrid.Columns[id].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                // Add a total column
                _create_new_column("total", "Total", DataGridViewContentAlignment.MiddleRight, false);

                // Now fill in empty grid
                // FIXME: Consider simplifying. Make this the only routine to loop through the data,
                // created rows and columns as necessary, and leaving out the previous exercises.
                // The only thing we lose in this process is the ability to show blank rows, but since
                // hiding blank rows is the default, that might not be a great loss. The upside is
                // a greatly-simplified grid-filling procedure.

                int row_id = 0;

                foreach (Row row in rows)
                {
                    int rowTotal = 0;
                    string itemCol = wDataType.Text.Substring(0, wDataType.Text.Length - 1) + "_id";

                    if (sGroupBy != "")
                    {
                        query = String.Format(@"
                            select strftime('{0}', timestamp_s) AS grouping, sum(seconds) as seconds
                            from timekeeper 
                            where timestamp_s >= '{1}'
                              and timestamp_s <= '{2}'
                              and {4} = {3}
                              {5} {6}
                            group by grouping
                            order by grouping", sGroupBy, sStartDate, sEndDate, row["id"], itemCol, sTaskList, sProjectList);

                        Table cells = data.Select(query);

                        foreach (Row cell in cells)
                        {
                            string cellValue = "";
                            string cellToolTip = "";
                            cellValue = _format_cell(wTimeFormat.SelectedIndex, Convert.ToInt32(cell["seconds"]), out cellToolTip);
                            wGrid.Rows[row_id].Cells[cell["grouping"]].Value = cellValue;
                            wGrid.Rows[row_id].Cells[cell["grouping"]].ToolTipText = cellToolTip;
                            wGrid.Rows[row_id].Cells[cell["grouping"]].Tag = cell["seconds"];
                            rowTotal += (int)cell["seconds"];
                        }
                    }
                    else
                    {
                        query = String.Format(@"
                            select sum(seconds) as seconds
                            from timekeeper 
                            where timestamp_s >= '{1}'
                              and timestamp_s <= '{2}'
                              and {3} = {0}
                              {4} {5}",
                            row["id"], sStartDate, sEndDate, itemCol, sTaskList, sProjectList);
                        Row cell = data.SelectRow(query);
                        if (cell["seconds"] != null) {
                            rowTotal = (int)cell["seconds"];
                        }
                    }

                    // update Total column
                    if (rowTotal > 0)
                    {
                        string cellValue = "";
                        string cellToolTip = "";
                        cellValue = _format_cell(wTimeFormat.SelectedIndex, rowTotal, out cellToolTip);
                        wGrid.Rows[row_id].Cells["total"].Value = cellValue;
                        wGrid.Rows[row_id].Cells["total"].ToolTipText = cellToolTip;
                        wGrid.Rows[row_id].Cells["total"].Tag = rowTotal;
                    }

                    // Advance to next row
                    row_id++;
                }

                //Common.Info("Elapsed time: " + t.ElapsedMilliseconds.ToString());

                // create the bottom total row
                wGrid.Rows.Add("Total");
                for (int j = 1; j < wGrid.Columns.Count; j++) 
                {
                    int colTotal = 0;

                    for (int i = 0; i < wGrid.Rows.Count; i++) {
                        colTotal += Convert.ToInt32(wGrid[j, i].Tag);
                    }

                    string cellValue = "";
                    string cellToolTip = "";
                    cellValue = _format_cell(wTimeFormat.SelectedIndex, colTotal, out cellToolTip);

                    wGrid[j, row_id].Value = cellValue;
                    wGrid[j, row_id].ToolTipText = cellToolTip;
                }

                // and lastly hide/show empty rows
                _toggle_empty_rows();

            }
            else
            {
                Common.Info("No time data found.");
            }

            // End unit of work
            data.Commit();

            t.Stop();
            //Common.Info("Elapsed time: " + t.ElapsedMilliseconds.ToString());
        }

        private void _create_new_column(string colName, string colHeading, DataGridViewContentAlignment align, bool frozen)
        {
            int col = wGrid.Columns.Add(colName, colHeading);
            wGrid.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            wGrid.Columns[col].HeaderCell.Style.Alignment = align;
            wGrid.Columns[col].DefaultCellStyle.Alignment = align;
            wGrid.Columns[col].DefaultCellStyle.BackColor = Color.AliceBlue;
            wGrid.Columns[col].Frozen = frozen;
            wGrid.Columns[col].ReadOnly = true;
        }

        private void _set_start_date()
        {
            DateTime now = DateTime.Now;
            String query;

            switch (wDatePreset.Text)
            {
                case "Today":
                    wStartDate.Value = now;
                    wEndDate.Value = now;
                    break;

                case "Yesterday": 
                    wStartDate.Value = now.Subtract(new TimeSpan(24, 0, 0));
                    wEndDate.Value = wStartDate.Value;
                    break;

                case "Previous Day":
                    query = @"select distinct strftime('%Y-%m-%d', timestamp_s) as date from timekeeper order by date desc";
                    Table rows = data.Select(query);
                    if (rows.Count > 1) {
                        wStartDate.Value = DateTime.Parse(rows[1]["date"]);
                        wEndDate.Value = wStartDate.Value;
                    } else {
                        wStartDate.Value = now;
                        wEndDate.Value = now;
                    }
                    break;

                case "This Week":
                    int diff = now.DayOfWeek - DayOfWeek.Monday;
                    wStartDate.Value = now.Subtract(new TimeSpan(diff * 7, 0, 0)); 
                    wEndDate.Value = now;
                    break;

                case "This Month": 
                    wStartDate.Value = DateTime.Parse(now.Year.ToString() + "/" + now.Month.ToString() + "/1"); 
                    wEndDate.Value = now;
                    break;

                case "Last Month":
                    int year = now.Year;
                    int month = now.Month;
                    if (now.Month == 1) {
                        year--;
                        month = 12;
                    } else {
                        month--;
                    }
                    wStartDate.Value = DateTime.Parse(year.ToString() + "/" + month.ToString() + "/1");
                    wEndDate.Value =   DateTime.Parse(year.ToString() + "/" + month.ToString() + "/" + DateTime.DaysInMonth(year, month).ToString());
                    break;

                case "This Year":
                    wStartDate.Value = DateTime.Parse(now.Year.ToString() + "/01/01");
                    wEndDate.Value = now;
                    break;

                case "Last Year":
                    year = now.Year;
                    year--;
                    wStartDate.Value = DateTime.Parse(year.ToString() + "/01/01");
                    wEndDate.Value = DateTime.Parse(year.ToString() + "/12/31");
                    break;

                case "All":
                    query = @"select min(timestamp_s) as min from timekeeper";
                    Row row = data.SelectRow(query);
                    wStartDate.Value = DateTime.Parse(row["min"]);
                    break;

                case "Custom":
                    // do nothing
                    break;
            }
        }

        private void _toggle_empty_rows()
        {
            for (int i = 0; i < wGrid.Rows.Count; i++)
            {
                int blankCount = 0;
                
                // ignore column 0, since it will never be empty
                for (int j = 1; j < wGrid.Columns.Count; j++)
                {
                    if (Convert.ToString(wGrid.Rows[i].Cells[j].Value) == "") {
                        blankCount++;
                    }
                }

                if (blankCount == (wGrid.Columns.Count - 1)) {
                    wGrid.Rows[i].Visible = !wHideEmptyRows.Checked;
                }
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (dlgGridFilter.ShowDialog(this) == DialogResult.OK)
            {
                this.task_list = _join_items(dlgGridFilter.wTaskList);
                this.project_list = _join_items(dlgGridFilter.wProjectList);
                //_load_grid(sender, e);
                _load_grid2();
            }
        }

        private void btnSaveView2_Click(object sender, EventArgs e)
        {
            fGridSave dlg = new fGridSave();
            
            dlg.wName.Text = sLoadedViewName;
            dlg.wDescription.Text = sLoadedViewDescription;
            dlg.wEndDateType.Enabled = ((string)wDatePreset.SelectedItem == "Custom");
            if (dlg.wEndDateType.Enabled) {
                // literal
                Pair dateEntered = new Pair();
                dateEntered.Key = 1;
                dateEntered.Value = "Entered Date: " + wEndDate.Text;
                
                // literal
                Pair dateToday = new Pair();
                dateToday.Key = 2;
                dateToday.Value = "Today's Date: " + Common.Today();
                
                // variable
                Pair dateTodayFn = new Pair();
                dateTodayFn.Key = 3;
                dateTodayFn.Value = "Variable Date: Today()";

                dlg.wEndDateType.Items.Add(dateEntered);
                if (wEndDate.Text.CompareTo(Common.Today()) != 0) {
                    dlg.wEndDateType.Items.Add(dateToday);
                }
                dlg.wEndDateType.Items.Add(dateTodayFn);
            }

            bool overWrite = false;

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // Any name entered?
                if (dlg.wName.Text == "") {
                    Common.Warn("No view name specified.");
                    return;
                }

                // Begin unit of work
                data.Begin();

                // check for duplicates
                string query = String.Format(@"select name from grid_views where name = '{0}'", dlg.wName.Text.Replace("'", "''"));
                Row tmp = data.SelectRow(query);
                if (tmp["name"] != null) {
                    if (Common.Prompt("A saved view with this name already exists. Do you want to overwrite it?") != DialogResult.Yes)  {
                        return;
                    } else {
                        overWrite = true;
                    }
                }

                string endDateType = null;
                if (dlg.wEndDateType.SelectedItem != null) {
                    Pair p = (Pair)dlg.wEndDateType.SelectedItem;
                    // FIXME: this can be a native int here and below in the row[] defintion
                    endDateType = p.Key.ToString();
                }

                Row row = new Row();
                row["description"] = dlg.wDescription.Text;
                row["task_list"] = this.task_list;
                row["project_list"] = this.project_list;
                row["date_preset"] = this.wDatePreset.SelectedIndex.ToString();
                row["start_date"] = this.wStartDate.Text;
                row["end_date"] = this.wEndDate.Text;
                row["end_date_type"] = endDateType;
                row["group_by"] = this.wGroupBy.SelectedIndex.ToString();
                row["data_from"] = this.wDataType.SelectedIndex.ToString();
                row["hide_empty_rows"] = this.wHideEmptyRows.Checked ? 1 : 0;
                row["timestamp_c"] = Common.Now();
                row["timestamp_m"] = Common.Now();

                if ((dlg.wName.Text == sLoadedViewName) || overWrite)
                {
                    data.Update("grid_views", row, "name", dlg.wName.Text);
                    Common.Info("Grid view updated.");
                }
                else
                {
                    query = String.Format(@"select max(sort_index) as max_sort_index from grid_views");
                    tmp = data.SelectRow(query);
                    long max_sort_index = tmp["max_sort_index"] == null ? 0 : tmp["max_sort_index"];

                    row["name"] = dlg.wName.Text;
                    row["sort_index"] = max_sort_index + 1;
                    data.Insert("grid_views", row);
                    Common.Info("New grid view saved.");
                }

                _populate_loadview();

                // Complete unit of work
                data.Commit();
            }
        }

        private void btnManageViews_Click(object sender, EventArgs e)
        {
            fGridManage dlg = new fGridManage(data);
            dlg.ShowDialog(this);
            _populate_loadview();
        }

        private void _populate_loadview()
        {
            // Begin unit of work
            data.Begin();

            // clear any previous entries
            btnLoadViewDropDown.DropDownItems.Clear();

            // now grab new entries
            string query = String.Format(@"select * from grid_views order by sort_index");
            Table rows = this.data.Select(query);

            if (rows.Count > 0)
            {
                foreach (Row row in rows)
                {
                    ToolStripItem item = btnLoadViewDropDown.DropDownItems.Add(row["name"]);
                    item.Click += new System.EventHandler(this._load_view);
                    item.ToolTipText = row["description"];
                }
                btnLoadViewDropDown.Enabled = true;
                btnManageViews.Enabled = true;
            }
            else
            {
                btnLoadViewDropDown.Enabled = false;
                btnManageViews.Enabled = false;
            }

            // Complete unit of work
            data.Commit();
        }

        private void _load_view(object sender, EventArgs e)
        {
            string name = sender.ToString().Replace("'", "''");
            lastGridView = name;
            _load_view_by_name(name);
            //_load_grid(sender, e);
            _load_grid2();
        }

        private void _load_view_by_name(string name)
        {
            // Begin unit of work
            data.Begin();

            try {
                string query = String.Format(@"select * from grid_views where name = '{0}'", name);
                Row row = this.data.SelectRow(query);

                if (row["id"] != null) {
                    this.sLoadedViewName = row["name"];
                    this.sLoadedViewDescription = row["description"];
                    this.task_list = row["task_list"];
                    this.project_list = row["project_list"];

                    // FIXME: no magic numbers, please (7 = Custom)
                    if (row["date_preset"] == 7)
                    {
                        wDatePreset.SelectedItem = "Custom";
                        wStartDate.Text = row["start_date"];
                        if (row["end_date_type"] == 3) {
                            wEndDate.Text = Common.Today();
                        } else {
                            wEndDate.Text = row["end_date"];
                        }
                    }
                    else
                    {
                        wDatePreset.SelectedIndex = row["date_preset"];
                        _set_start_date();
                    }
                    wGroupBy.SelectedIndex = row["group_by"];
                    wDataType.SelectedIndex = row["data_from"];
                    wHideEmptyRows.Checked = row["hide_empty_rows"] == 1; // FIXME: this column should be boolean // FIXME: actually, this column should be deleted
                    dlgGridFilter._set_checks(dlgGridFilter.wTaskList, this.task_list);
                    dlgGridFilter._set_checks(dlgGridFilter.wProjectList, this.project_list);
                }
            } catch (Exception e) {
                Common.Warn(e.ToString());
            }
            finally {
                // Complete unit of work
                data.Commit();
            }

        }

        private string _join_items(CheckedListBox list)
        {
            string join = null;

            foreach (Pair item in list.CheckedItems)
            {
                join += item.Key.ToString() + ",";
            }
            if (join != null)
            {
                join = join.Substring(0, join.Length - 1);
            }

            return join;
        }

        private void btnFilter2_Click(object sender, EventArgs e)
        {
            if (dlgGridFilter.ShowDialog(this) == DialogResult.OK)
            {
                this.task_list = _join_items(dlgGridFilter.wTaskList);
                this.project_list = _join_items(dlgGridFilter.wProjectList);
            }
        }

        private void wStartDate_Enter(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            sBeforeDate = picker.Text;
        }

        private void wStartDate_Leave(object sender, EventArgs e)
        {
            DateTimePicker picker = (DateTimePicker)sender;
            if (sBeforeDate != picker.Text) {
                wDatePreset.SelectedItem = "Custom";
            }

        }

        private string _format_cell2(int format, long seconds)
        {
            string value;
            switch (format) {
                case 0:
                    value = Timekeeper.FormatSeconds(seconds);
                    break;
                case 1:
                    value = Math.Round(Convert.ToDecimal((float)seconds / 60 / 60), 2).ToString();
                    break;
                case 2:
                    value = Math.Round(Convert.ToDecimal(seconds / 60)).ToString();
                    break;
                case 3:
                    value = seconds.ToString();
                    break;
                default:
                    value = "ERR";
                    break;
            }
            return value;
        }

        private string _format_cell(int format, int seconds, out string toolTip)
        {
            string value;
            switch (format)
            {
                case 0:
                    value = Timekeeper.FormatSeconds(seconds);
                    toolTip = "Hours:Minutes:Seconds";
                    break;
                case 1:
                    value = Math.Round(Convert.ToDecimal(seconds / 60)).ToString();
                    toolTip = "Minutes";
                    break;
                case 2:
                    value = seconds.ToString();
                    toolTip = "Seconds";
                    break;
                default:
                    value = "n/a";
                    toolTip = "Unknown Format Specified";
                    break;
            }
            return value;
        }

        private void _saveLastView(bool onlyIfEmpty)
        {
            // Automatically save "Last View"
            // HUGE FIXME: this whole section is (nearly) duplicated in two spots. Create an "upsertView" method.)

            if (onlyIfEmpty) {
                // bail if there are any rows already in the table
                // this preserves prior Last View values upon load
                // yeah --- it's a bit of a hack (FIXME?)
                string sql = "select count(*) as row_count from grid_views";
                Row tmp = data.SelectRow(sql);
                if (tmp["row_count"] != 0) {
                    return;
                }
            }

            Row row = new Row();
            row["description"] = "Automatically saved last view";
            row["task_list"] = this.task_list;
            row["project_list"] = this.project_list;
            row["date_preset"] = this.wDatePreset.SelectedIndex.ToString();
            row["start_date"] = this.wStartDate.Text;
            row["end_date"] = this.wEndDate.Text;
            row["end_date_type"] = null;
            row["group_by"] = this.wGroupBy.SelectedIndex.ToString();
            row["data_from"] = this.wDataType.SelectedIndex.ToString();
            row["hide_empty_rows"] = this.wHideEmptyRows.Checked ? 1 : 0;
            row["timestamp_c"] = Common.Now();
            row["timestamp_m"] = Common.Now();

            try
            {
                int count = data.Update("grid_views", row, "name", "Last View");

                if (count == 0)
                {
                    string query = String.Format(@"select max(sort_index) as max_sort_index from grid_views");
                    Row tmp = data.SelectRow(query);
                    int max_sort_index = tmp["max_sort_index"] == null ? 0 : tmp["max_sort_index"];

                    row["name"] = "Last View";
                    row["sort_index"] = max_sort_index + 1;
                    data.Insert("grid_views", row);
                }
            }
            catch
            {
            }
        }
        
        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fGrid\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

    }
}