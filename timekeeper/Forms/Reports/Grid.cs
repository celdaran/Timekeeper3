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
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;

        private Classes.GridView GridView;
        private Classes.GridView AutoSavedGridView;

        public delegate void BrowserCallback(long entryId);

        private List<ToolStripMenuItem> GroupByButtons;

        public long lastGridViewId;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Grid()
        {
            InitializeComponent();

            // TODO: I'd like some sort of basic framework for
            // loading up and closing a form: where things like Database
            // and Options are auto-set, form metrics are loaded and saved,
            // and so on. Feels like a lot of the same things are needed
            // (and repeated) across multiple forms.
            // e.g., what if Width, Height, Left, Top are a single Rect 
            // struct (Point, Size) that gets assigned . . .

            this.Options = Timekeeper.Options;
            this.GridView = new Classes.GridView();
            this.AutoSavedGridView = new Classes.GridView();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Grid_Load(object sender, EventArgs e)
        {
            // Some interface defaults

            /*
            WAIT: SHOULD THESE BE HANDLED ELSEWHERE???
            */
            GroupByComboBox.SelectedItem = "Month";
            DimensionComboBox.SelectedIndex = 0;
            TimeDisplayComboBox.SelectedIndex = 0;

            // ABOVE CAME FROM Constructor

            // Create array of GroupBy buttons
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

            // Populate the list of Saved Views
            PopulateLoadMenu();

            // Then go!
            LoadAndRunGrid(Options.State_LastGridViewId);
        }

        //----------------------------------------------------------------------

        private void Grid_Activated(object sender, EventArgs e)
        {
            EnableToolbar();
        }

        //----------------------------------------------------------------------

        private void Grid_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.Grid_Height = Height;
            Options.Grid_Width = Width;
            Options.Grid_Top = Top;
            Options.Grid_Left = Left;
        }

        //----------------------------------------------------------------------
        // Toolbar Commands
        //----------------------------------------------------------------------

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.Filtering FilterDialog = new Forms.Shared.Filtering(GridView.FilterOptions);

            if (FilterDialog.ShowDialog(this) == DialogResult.OK) {
                GridView.FilterOptions = FilterDialog.FilterOptions;
                Timekeeper.Info("FIXME");
                RunGrid();
            }
        }

        //----------------------------------------------------------------------

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            Forms.Reports.GridOptions DialogBox = new GridOptions();

            // FIXME: You're cheating now . . .
            DialogBox.GroupDataBy.SelectedIndex = GroupByComboBox.SelectedIndex;
            DialogBox.Dimension.SelectedIndex = DimensionComboBox.SelectedIndex;
            DialogBox.TimeDisplay.SelectedIndex = TimeDisplayComboBox.SelectedIndex;

            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                GroupByComboBox.SelectedIndex = DialogBox.GroupDataBy.SelectedIndex;
                DimensionComboBox.SelectedIndex = DialogBox.Dimension.SelectedIndex;
                TimeDisplayComboBox.SelectedIndex = DialogBox.TimeDisplay.SelectedIndex;
                GroupBySelect(GroupByComboBox.SelectedIndex);
            }
        }

        //----------------------------------------------------------------------

        private void GroupByDayButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(0);
        }

        //----------------------------------------------------------------------

        private void GroupByWeekButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(1);
        }

        //----------------------------------------------------------------------

        private void GroupByMonthButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(2);
        }

        //----------------------------------------------------------------------

        private void GroupByYearButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(3);
        }

        //----------------------------------------------------------------------

        private void GroupByNoneButton_Click(object sender, EventArgs e)
        {
            GroupBySelect(4);
        }

        //----------------------------------------------------------------------

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            Timekeeper.Debug("This may need work. I'm thinking about handling date presets...");
            RunGrid();
        }

        //----------------------------------------------------------------------

        private void LoadViewButton_Click(object sender, EventArgs e)
        {
            // NOTE: This isn't actually attached to a Toolbar button at
            // design-time. It's assigned at run-time to the dynamic list
            // of saved views when the form populates.

            ToolStripItem Item = (ToolStripItem)sender;
            Classes.BaseView View = (Classes.BaseView)Item.Tag;
            LoadAndRunGrid(View.Id);
        }

        //----------------------------------------------------------------------

        private void SaveViewButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.SaveView DialogBox = new Forms.Shared.SaveView();
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                GridView.Name = DialogBox.wName.Text;
                GridView.Description = DialogBox.wDescription.Text;
                GridView.Save();
                PopulateLoadMenu();
                SetTitleBar();
            }
        }

        //----------------------------------------------------------------------

        private void ManageViewsButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.ManageViews DialogBox = new Forms.Shared.ManageViews("GridView");
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                // Brute force: just in case anything changed.
                PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------

        private void PrintButton_Click(object sender, EventArgs e)
        {
        }

        //----------------------------------------------------------------------

        private void PrintSetupButton_Click(object sender, EventArgs e)
        {
        }

        //----------------------------------------------------------------------

        private void PrintPreviewButton_Click(object sender, EventArgs e)
        {
        }

        //----------------------------------------------------------------------
        // Internal Helpers
        //----------------------------------------------------------------------

        private void AutoSaveView()
        {
            AutoSavedGridView = new Classes.GridView("Last View");

            bool NewView = false;

            if (AutoSavedGridView.Id == 0) {
                // This is the first time; so seed the new view
                AutoSavedGridView.Name = "Last View";
                AutoSavedGridView.Description = "Automatically saved view";
                NewView = true;
            }

            // Overwrite FilterOptions with current FilterOptions
            AutoSavedGridView.FilterOptions = GridView.FilterOptions;

            // Overwrite Grid-specific settings with current UI values
            AutoSavedGridView.RefGroupById = GroupByComboBox.SelectedIndex + 1;
            AutoSavedGridView.RefDimensionId = DimensionComboBox.SelectedIndex + 1;
            AutoSavedGridView.RefTimeDisplayId = TimeDisplayComboBox.SelectedIndex + 1;

            // Now attempt to save (this is an upsert)
            if (AutoSavedGridView.Save()) {
                // Make sure the Last Saved ID is the current value
                Options.State_LastGridViewId = AutoSavedGridView.Id;

                // Tell me about it
                Timekeeper.Debug("Just saved GridViewId = " + AutoSavedGridView.Id.ToString());

                // And copy it back into the current grid options
                GridView = AutoSavedGridView;

                // Update title bar
                SetTitleBar();
            } else {
                Timekeeper.Debug("Options not saved in AutoSaveView()");
            }

            if (NewView) {
                PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------

        private void EnableToolbar()
        {
            Classes.JournalEntryCollection JournalEntries = new Classes.JournalEntryCollection();

            bool HasEntries = (JournalEntries.Count() > 0);

            FilterButton.Enabled = HasEntries;
            OptionsButton.Enabled = HasEntries;
            GroupByMenuButton.Enabled = HasEntries;
            RefreshButton.Enabled = HasEntries;
            LoadMenuButton.Enabled = HasEntries;
            SaveViewButton.Enabled = HasEntries;
            ManageViewsButton.Enabled = HasEntries;
            PrintMenuButton.Enabled = HasEntries;
        }

        //----------------------------------------------------------------------

        private void GroupBySelect(int buttonIndex)
        {
            GroupBySelect(buttonIndex, true);
        }

        //----------------------------------------------------------------------

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
            GroupByComboBox.SelectedIndex = buttonIndex;
            RunGrid(autoSaveView);
        }

        //----------------------------------------------------------------------

        private void PopulateLoadMenu()
        {
            // Reset UI
            LoadMenuButton.DropDownItems.Clear();
            LoadMenuButton.Enabled = false;
            ManageViewsButton.Enabled = false;

            // Now grab new entries
            List<Classes.BaseView> BaseViews = new Classes.BaseViewCollection("GridView").Fetch();
            foreach (Classes.BaseView BaseView in BaseViews) {
                ToolStripItem Item = LoadMenuButton.DropDownItems.Add(BaseView.Name);
                Item.Tag = BaseView;
                Item.Click += new System.EventHandler(this.LoadViewButton_Click);
                Item.ToolTipText = BaseView.Description;
            }

            // Update UI
            if (BaseViews.Count > 0) {
                LoadMenuButton.Enabled = true;
                ManageViewsButton.Enabled = true;
            }
        }

        //----------------------------------------------------------------------

        private void SetTitleBar()
        {
            this.Text = String.Format("Timekeeper Grid ({0})", GridView.Name);
        }

        //----------------------------------------------------------------------
        // Core Grid-generation methods
        //----------------------------------------------------------------------

        private void RunGrid()
        {
            RunGrid(true);
        }

        //----------------------------------------------------------------------

        private void RunGrid(bool autoSaveView)
        {
            string Message = String.Format("Refreshing Grid. ID = {0}, Name = {1}, AutoSave = {2}",
                GridView.Id, GridView.Name, autoSaveView.ToString());
            Timekeeper.Debug(Message);

            try {
                //-----------------------------------
                // Initialization
                //-----------------------------------

                // Start with a blank grid
                GridControl.Columns.Clear();
                //GridControl.Columns[0].HeaderText = "Wait, whut?";

                //-----------------------------------
                // Query setup
                //-----------------------------------

                // Handle grouping
                string GroupBy = "";
                switch (GroupByComboBox.Text) {
                    case "Day": GroupBy = "%Y/%m/%d"; break;
                    case "Week": GroupBy = "%Y, %W"; break;
                    case "Month": GroupBy = "%Y/%m"; break;
                    case "Year": GroupBy = "%Y"; break;
                }

                // Get table name
                string TableName;
                switch (DimensionComboBox.SelectedIndex) {
                    case 0 :
                        TableName = "Project";
                        break;
                    case 1 :
                        TableName = "Activity";
                        break;
                    default :
                        TableName = "Project";
                        break;
                }

                // Get data
                Table table = GridView.Results(GroupBy, TableName);

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
                CreateNewColumn("item",
                    DimensionComboBox.Text.Substring(0, DimensionComboBox.Text.Length - 1),
                    DataGridViewContentAlignment.MiddleLeft,
                    true);

                var bucketList = buckets.Keys.ToList();
                if (GroupBy != "") {
                    // Add one column for each bucket
                    bucketList.Sort();
                    foreach (string key in bucketList) {
                        int id = GridControl.Columns.Add(key, key);
                        GridControl.Columns[id].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        GridControl.Columns[id].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        GridControl.Columns[id].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }

                // Add one column for the row totals
                CreateNewColumn("total", "Total", DataGridViewContentAlignment.MiddleRight, false);

                // Add one row for each item
                var itemList = items.Keys.ToList();
                itemList.Sort();
                foreach (string key in itemList) {
                    GridControl.Rows.Add(key);
                }

                // Add one row for column totals
                int totalRow = GridControl.Rows.Add("Total");
                GridControl.Rows[totalRow].DefaultCellStyle.BackColor = Color.AliceBlue;

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
                            string c = FormatCell(TimeDisplayComboBox.SelectedIndex, seconds);
                            GridControl.Rows[y].Cells[x + 1].Value = c;
                            GridControl.Rows[y].Cells[x + 1].Tag = seconds;
                            rowTotal += seconds;
                        }
                        x++;
                    }
                    int offset = GroupBy == "" ? 0 : 1;
                    GridControl.Rows[y].Cells[x + offset].Value = FormatCell(TimeDisplayComboBox.SelectedIndex, rowTotal);
                    GridControl.Rows[y].Cells[x + offset].Tag = rowTotal;
                    y++;
                }

                //-----------------------------------
                // Lastly, add column totals
                //-----------------------------------

                long colTotal = 0;
                int colNo = 0;
                foreach (DataGridViewColumn col in GridControl.Columns) {
                    if (colNo > 0) {
                        colTotal = 0;
                        foreach (DataGridViewRow row in GridControl.Rows) {
                            if (row.Cells[col.Name].Tag != null)
                                colTotal += (long)row.Cells[col.Name].Tag;
                        }
                        GridControl.Rows[GridControl.Rows.Count - 1].Cells[colNo].Value = FormatCell(TimeDisplayComboBox.SelectedIndex, colTotal);
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

        //----------------------------------------------------------------------

        private void CreateNewColumn(string colName, string colHeading, DataGridViewContentAlignment align, bool frozen)
        {
            int col = GridControl.Columns.Add(colName, colHeading);
            GridControl.Columns[col].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            GridControl.Columns[col].HeaderCell.Style.Alignment = align;
            GridControl.Columns[col].DefaultCellStyle.Alignment = align;
            GridControl.Columns[col].DefaultCellStyle.BackColor = Color.AliceBlue;
            GridControl.Columns[col].Frozen = frozen;
            GridControl.Columns[col].ReadOnly = true;
        }

        //----------------------------------------------------------------------

        private string FormatCell(int format, long seconds)
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

        private void LoadAndRunGrid(long gridViewId)
        {
            if (gridViewId > 0) {
                // Load Last Saved Options
                GridView.Load(gridViewId);

                // Reflect loaded grid in Title Bar
                SetTitleBar();

                // Set this as the last run ID
                Options.State_LastGridViewId = gridViewId;

                // Restore UI based on Saved Options
                // FIXME: Stolen (more or less) from the Options button
                GroupByComboBox.SelectedIndex = (int)GridView.RefGroupById - 1;
                DimensionComboBox.SelectedIndex = (int)GridView.RefDimensionId - 1; // dimension
                TimeDisplayComboBox.SelectedIndex = (int)GridView.RefTimeDisplayId - 1;

                // Set the value (which triggers RunGrid() itself)
                GroupBySelect(GroupByComboBox.SelectedIndex, false);
            } else {
                // Enable/disable toolbar
                EnableToolbar();

                // Default to "By Day" (and trigger RunGrid())
                GroupBySelect(0, false);

                // "Hide" our only column if there's no view to load
                /*
                GridControl.Columns[0].HeaderText = "No Data Found";
                GridControl.Columns[0].Width = 200;
                */
            }
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

        //----------------------------------------------------------------------

    }
}