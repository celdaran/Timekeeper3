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

namespace Timekeeper.Forms.Reports
{
    public partial class Grid : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Database;
        private Classes.Options Options;

        private Classes.GridOptions GridOptions;
        private Classes.GridOptions AutoSavedGridOptions;

        public delegate void BrowserCallback(long entryId);

        //private BrowserCallback Browser_GotoEntry;

        private List<ToolStripMenuItem> GroupByButtons;

        //---------------------------------------------------------------------

        /*
        private string task_list;
        private string project_list;
        private string sLoadedViewName;
        private string sLoadedViewDescription;

        private string sBeforeDate;
        private int loopCount;

        private fGridFilter dlgGridFilter;
        */

        public long lastGridViewId;


        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Grid() //Classes.GridOptions gridOptions)
        {
            InitializeComponent();

            // TODO: is this too much stuff in the Constructor?

            // TODO #2: Actually, I'd like some sort of basic framework for
            // loading up and closing a form: where things like Database
            // and Options are auto-set, form metrics are loaded and saved,
            // and so on. Feels like a lot of the same things are needed
            // (and repeated) across multiple forms.

            // e.g., what if Width, Height, Left, Top are a single Rect 
            // struct (Point, Size) that gets assigned . . .

            // Globals
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;

            this.GridOptions = new Classes.GridOptions();

            // Some interface defaults
            wGroupBy.SelectedItem = "Month";
            wDataType.SelectedIndex = 0;
            wTimeFormat.SelectedIndex = 0;

            // Begin unit of work
            //this.Database.Begin();

            // Populate the LoadView menu
            //_populate_loadview();

            // Instantiate the filter here (FIXME: this is a bit ugly)
            /*
            dlgGridFilter = new fGridFilter(this.Database);
            dlgGridFilter._load("tasks", dlgGridFilter.wTaskList);
            dlgGridFilter._load("projects", dlgGridFilter.wProjectList);
            */

            // Complete unit of work
            //this.Database.Commit();

            // Set focus to first control
            //ActiveControl = wDatePreset;
        }

        //---------------------------------------------------------------------
        // Form Events
        //---------------------------------------------------------------------

        private void Grid_Load(object sender, EventArgs e)
        {
            GroupByButtons = new List<ToolStripMenuItem>();
            GroupByButtons.Add(GroupByDayButton);
            GroupByButtons.Add(GroupByWeekButton);
            GroupByButtons.Add(GroupByMonthButton);
            GroupByButtons.Add(GroupByYearButton);
            GroupByButtons.Add(GroupByNoneButton);

            // Restore window metrics
            Height = Options.Grid_Height;
            Width = Options.Grid_Width;
            Top = Options.Grid_Top;
            Left = Options.Grid_Left;

            //_set_start_date();
            //_load_view_by_name(this.lastGridViewId);
            //_load_grid(sender, e);

            //RunGrid();

            // Why?
            // _saveLastView(true);

            // Populate the list of Saved Views
            PopulateLoadMenu();

            // Then go!
            ReallyRunGrid(Options.State_LastGridOptionsId);
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            // Automatically save the last view with every refresh
            //_saveLastView(false);

            // Populate the dropdown
            //_populate_loadview();

            // Then load it
            //_load_grid(sender, e);

            Timekeeper.Debug("This may need work. I'm thinking about handling date presets...");
            RunGrid();
        }

        //-------------------------------
        // Internal helpers
        //-------------------------------

        private void RunGrid()
        {
            RunGrid(true);
        }

        private void RunGrid(bool autoSaveView)
        {
            string Message = String.Format("Refreshing Grid. ID = {0}, Name = {1}, AutoSave = {2}",
                GridOptions.GridOptionsId, GridOptions.Name, autoSaveView.ToString());
            Timekeeper.Debug(Message);

            try {
                //-----------------------------------
                // Initialization
                //-----------------------------------

                // Start with a blank grid
                wGrid.Columns.Clear();

                //-----------------------------------
                // Query setup
                //-----------------------------------

                // Handle grouping
                string sGroupBy = "";
                switch (wGroupBy.Text) {
                    case "Day": sGroupBy = "%Y/%m/%d"; break;
                    case "Week": sGroupBy = "%Y, %W"; break;
                    case "Month": sGroupBy = "%Y/%m"; break;
                    case "Year": sGroupBy = "%Y"; break;
                }

                // Get table name from Data Type dropdown
                // FIXME: REALLY?
                //string tableName = "Project"; //wDataType.Text.Substring(0, wDataType.Text.Length - 1);
                string tableName = wDataType.Text.Substring(0, 1) == "P" ? "Project" : "Activity";

                // Get data
                Table table = GridOptions.Results(sGroupBy, tableName);

                //-----------------------------------
                // Build up grid in memory
                //-----------------------------------

                // Three structures: unique row values, unique column values, and a grid
                var items = new Row();
                var buckets = new Row();
                var grid = new Dictionary<string, Dictionary<string, long>>();

                // Build up from query results
                foreach (Row r in table) {
                    if (items.ContainsKey(r["Name"])) {
                        items[r["Name"]]++;
                    } else {
                        items[r["Name"]] = 1;
                    }

                    if (buckets.ContainsKey(r["Grouping"])) {
                        buckets[r["Grouping"]]++;
                    } else {
                        buckets[r["Grouping"]] = 1;
                    }

                    if (grid.ContainsKey(r["Name"])) {
                        grid[r["Name"]].Add(r["Grouping"], r["Seconds"]);
                    } else {
                        var cell = new Dictionary<string, long>();
                        cell[r["Grouping"]] = r["Seconds"];
                        grid.Add(r["Name"], cell);
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
                //loopCount = 0;
                int x = 0; int y = 0;
                long rowTotal;
                long seconds;
                foreach (string item in itemList) {
                    x = 0;
                    rowTotal = 0;
                    foreach (string bucket in bucketList) {
                        if (grid[item].ContainsKey(bucket)) {
                            seconds = grid[item][bucket];
                            string c = _format_cell2(wTimeFormat.SelectedIndex, seconds);
                            wGrid.Rows[y].Cells[x + 1].Value = c;
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
                // Save This
                //-----------------------------------

                if (autoSaveView) {
                    AutoSaveView();
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
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

        //----------------------------------------------------------------------

        private void AutoSaveView()
        {
            AutoSavedGridOptions = new Classes.GridOptions(1); // 1 == Last Grid View
            // TODO: Consider a load by name option

            /*
            THESE SHOULD ALREADY BE SET

            AutoSavedGridOptions.Name = "Last Grid View";
            AutoSavedGridOptions.Description = "Automatically-saved settings from last grid display"; // TODO: improve this wording.
            AutoSavedGridOptions.SortOrderNo = 0;
            */

            // Overwrite FilterOptions with current FilterOptions
            AutoSavedGridOptions.FilterOptions = GridOptions.FilterOptions;

            // Overwrite Grid-specific settings with current UI values
            AutoSavedGridOptions.RefGroupById = wGroupBy.SelectedIndex + 1;
            AutoSavedGridOptions.RefItemTypeId = wDataType.SelectedIndex + 1;
            AutoSavedGridOptions.RefTimeDisplayId = wTimeFormat.SelectedIndex + 1;

            // Now attempt to save
            if (AutoSavedGridOptions.Save()) {
                // Make sure the Last Saved ID is the current value
                Options.State_LastGridOptionsId = AutoSavedGridOptions.GridOptionsId;

                // Tell me about it
                Common.Info("Just saved GridOptionsId = " + AutoSavedGridOptions.GridOptionsId.ToString());

                // And copy it back into the current grid options
                GridOptions = AutoSavedGridOptions;

                // Update title bar
                // FIXME: you're doing this twice.
                // TODO: I can't shake the feeling that this Grid stuff is still a royal mess
                this.Text = String.Format("Timekeeper Grid ({0})", GridOptions.Name);
            } else {
                Timekeeper.Debug("There was an error saving options");
            }
        }

        //----------------------------------------------------------------------

        private void PopulateLoadMenu()
        {
            // Reset UI
            LoadMenuButton.DropDownItems.Clear();
            LoadMenuButton.Enabled = false;
            ManageOptionsButton.Enabled = false;

            // Now grab new entries
            List<Classes.GridOptions> GridOptionsCollection = new Classes.GridOptionsCollection().FetchObjects();
            foreach (Classes.GridOptions GridOptions in GridOptionsCollection)
            {
                ToolStripItem Item = LoadMenuButton.DropDownItems.Add(GridOptions.Name);
                Item.Tag = GridOptions;
                Item.Click += new System.EventHandler(this._load_view);
                Item.ToolTipText = GridOptions.Description;
            }

            if (GridOptionsCollection.Count > 0) {
                LoadMenuButton.Enabled = true;
                ManageOptionsButton.Enabled = true;
            }
        }

        //----------------------------------------------------------------------

        private void _load_view(object sender, EventArgs e)        {
            ToolStripItem Item = (ToolStripItem)sender;
            Classes.GridOptions GridOptions = (Classes.GridOptions)Item.Tag;

            ReallyRunGrid(GridOptions.GridOptionsId);
        }

        //----------------------------------------------------------------------

        private void ReallyRunGrid(long gridOptionsId)
        {
            // Load Last Saved Options
            GridOptions.Load(gridOptionsId);
            this.Text = String.Format("Timekeeper Grid ({0})", GridOptions.Name);

            // Set this as the last run ID
            Options.State_LastGridOptionsId = gridOptionsId;

            // Restore UI based on Saved Options
            // FIXME: Stolen (more or less) from the Options button
            wGroupBy.SelectedIndex = (int)GridOptions.RefGroupById - 1;
            wDataType.SelectedIndex = (int)GridOptions.RefItemTypeId - 1; // dimension
            wTimeFormat.SelectedIndex = (int)GridOptions.RefTimeDisplayId - 1;

            // Set the value, which also triggers RunGrid
            GroupBySelect(wGroupBy.SelectedIndex, false);
        }

        //----------------------------------------------------------------------
        // Context-sensitive help
        //----------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fGrid\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

        private void Grid_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.Grid_Height = Height;
            Options.Grid_Width = Width;
            Options.Grid_Top = Top;
            Options.Grid_Left = Left;
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Forms.Filtering FilterDialog = new Forms.Filtering(GridOptions.FilterOptions);

            if (FilterDialog.ShowDialog(this) == DialogResult.OK) {
                GridOptions.FilterOptions = FilterDialog.FilterOptions;
                Timekeeper.Info("FIXME");
                RunGrid();
            }
        }

        private void GroupBySelect(int buttonIndex)
        {
            GroupBySelect(buttonIndex, true);
        }

        private void GroupBySelect(int buttonIndex, bool autoSaveView)
        {
            int Index = 0;
            foreach (ToolStripMenuItem Item in GroupByButtons) {
                if (Index == buttonIndex) {
                    Item.Checked = true;
                } else {
                    Item.Checked = false;
                }
                Index++;
            }
            wGroupBy.SelectedIndex = buttonIndex;
            RunGrid(autoSaveView);
        }

        private void GroupByDayButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(0);
        }

        private void GroupByWeekButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(1);
        }

        private void GroupByMonthButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(2);
        }

        private void GroupByYearButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(3);
        }

        private void GroupByNoneButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(4);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            Forms.Reports.GridOptions DialogBox = new GridOptions();

            // FIXME: You're cheating now . . .
            DialogBox.GroupDataBy.SelectedIndex = wGroupBy.SelectedIndex;
            DialogBox.Dimension.SelectedIndex = wDataType.SelectedIndex;
            DialogBox.TimeDisplay.SelectedIndex = wTimeFormat.SelectedIndex;

            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                wGroupBy.SelectedIndex = DialogBox.GroupDataBy.SelectedIndex;
                wDataType.SelectedIndex = DialogBox.Dimension.SelectedIndex;
                wTimeFormat.SelectedIndex = DialogBox.TimeDisplay.SelectedIndex;
                GroupBySelect(wGroupBy.SelectedIndex);
            }
        }

        private void SaveOptionsButton_Click(object sender, EventArgs e)
        {
            fGridSave DialogBox = new fGridSave();
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                GridOptions.Name = DialogBox.wName.Text;
                GridOptions.Description = DialogBox.wDescription.Text;
                GridOptions.Save();
                //Common.Info("Hey ho, I'm saving your thing. Yay me.");
            }
        }

        private void ManageOptionsButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.ManageViews DialogBox = new Forms.Shared.ManageViews();
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                // Brute force: just in case anything changed.
                PopulateLoadMenu();
            }
        }

    }
}