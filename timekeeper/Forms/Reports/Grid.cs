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
        private Classes.Widgets Widgets;

        private Classes.GridView GridView;
        private Classes.GridView AutoSavedGridView;

        private Forms.Shared.Filtering FilterDialog;
        private List<ToolStripMenuItem> GroupByButtons;
        private int ViewCount;

        private bool LoadingExistingGrid;

        //----------------------------------------------------------------------

        public delegate void BrowserCallback(long entryId);

        //public long lastGridViewId;

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
            this.Widgets = new Classes.Widgets();
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

            // Load up saved grid and paint
            LoadAndRunGrid(Options.State_LastGridViewId);

            if (GridView.IsAutoSaved) {
                GridView.Changed = true;
            }

            // Populate the list of Saved Views
            PopulateLoadMenu();

        }

        //----------------------------------------------------------------------

        private void Grid_Activated(object sender, EventArgs e)
        {
            UpdateToolbar();
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
            GridView.FilterOptions = this.Widgets.FilteringDialog(this, 
                FilterDialog, GridView.FilterOptions.FilterOptionsId);

            if (GridView.FilterOptions.Changed) {
                GridView.Changed = true;
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
            RunGrid(false);
        }

        //----------------------------------------------------------------------

        private void ClearViewButton_Click(object sender, EventArgs e)
        {
            if (GridView.Changed) {
                if (Common.WarnPrompt("Current view has not been saved. Continue clearing?") == DialogResult.No) {
                    return;
                }
            }

            GridView = new Classes.GridView();

            GroupByComboBox.SelectedItem = "Month";
            DimensionComboBox.SelectedIndex = 0;
            TimeDisplayComboBox.SelectedIndex = 0;

            this.Widgets.SetViewTitleBar(this, "Grid");
            ClearViewButton.Enabled = false;

            LoadAndRunGrid(0);
        }

        //----------------------------------------------------------------------

        private void LoadViewButton_Click(object sender, EventArgs e)
        {
            ToolStripItem Item = (ToolStripItem)sender;
            Classes.BaseView View = (Classes.BaseView)Item.Tag;
            LoadAndRunGrid(View.Id);
        }

        //----------------------------------------------------------------------

        private void SaveViewButton_Click(object sender, EventArgs e)
        {
            // Set Grid-specific view options
            GridView.RefGroupById = GroupByComboBox.SelectedIndex + 1;
            GridView.RefDimensionId = DimensionComboBox.SelectedIndex + 1;
            GridView.RefTimeDisplayId = TimeDisplayComboBox.SelectedIndex + 1;

            // Save view
            GridView.Save(GridView.FilterOptions.Changed, GridView.FilterOptions.FilterOptionsId);

            // Post-save steps
            GridView.Changed = false;
            this.Widgets.SetViewTitleBar(this, "Grid", GridView.Name);
        }

        //----------------------------------------------------------------------

        private void SaveViewAsButton_Click(object sender, EventArgs e)
        {
            GridView = (Classes.GridView)this.Widgets.SaveViewDialog(this, "Grid", GridView);
            if (GridView.Changed) {
                GridView.Save(GridView.FilterOptions.Changed);
                GridView.Changed = false;
                PopulateLoadMenu();
                UpdateToolbar();
                Options.State_LastGridViewId = GridView.Id;
            }
        }

        //----------------------------------------------------------------------

        private void ManageViewsButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.ManageViews DialogBox = new Forms.Shared.ManageViews("GridView");
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
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

        private void UpdateViewState(bool autoSaveView)
        {
            if ((GridView.Id == 0) || GridView.IsAutoSaved) {
                if (autoSaveView) {
                    AutoSaveView();
                }
            } else {
                if (GridView.Changed) {
                    this.Widgets.SetViewTitleBar(this, "Grid", GridView.Name + "*");
                }
            }
            UpdateToolbar();
        }

        //----------------------------------------------------------------------

        private void AutoSaveView()
        {
            AutoSavedGridView = new Classes.GridView("Unsaved View");

            bool NewView = false;

            if (AutoSavedGridView.Id == 0) {
                // This is the first time; so seed the new view
                AutoSavedGridView.Name = "Unsaved View";
                AutoSavedGridView.Description = "Unnamed, last-applied view";
                NewView = true;
            }

            // Overwrite FilterOptions with current FilterOptions
            long SavedFilterOptionsId = AutoSavedGridView.FilterOptions.FilterOptionsId;
            AutoSavedGridView.FilterOptions = GridView.FilterOptions;
            if (GridView.FilterOptions.FilterOptionsId > 0) {
                AutoSavedGridView.FilterOptions.FilterOptionsId = GridView.FilterOptions.FilterOptionsId;
            } else {
                AutoSavedGridView.FilterOptions.FilterOptionsId = SavedFilterOptionsId;
            }

            // Overwrite Grid-specific settings with current UI values
            AutoSavedGridView.RefGroupById = GroupByComboBox.SelectedIndex + 1;
            AutoSavedGridView.RefDimensionId = DimensionComboBox.SelectedIndex + 1;
            AutoSavedGridView.RefTimeDisplayId = TimeDisplayComboBox.SelectedIndex + 1;

            // Now attempt to save (this is an upsert)
            if (AutoSavedGridView.Save(GridView.FilterOptions.Changed, AutoSavedGridView.FilterOptions.FilterOptionsId)) {
                // Make sure the Last Saved ID is the current value
                Options.State_LastGridViewId = AutoSavedGridView.Id;

                // Tell me about it
                Timekeeper.Debug("Just saved GridViewId = " + AutoSavedGridView.Id.ToString());

                // 
                // And copy it back into the current grid options
                GridView = AutoSavedGridView;

                // Although this has technically been saved to the DB, treat it as though it hasn't
                GridView.Changed = true;

                // Update title bar
                this.Widgets.SetViewTitleBar(this, "Grid", GridView.Name);
            } else {
                Timekeeper.Debug("Options not saved in AutoSaveView()");
            }

            if (NewView) {
                PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------

        private void UpdateToolbar()
        {
            Classes.JournalEntryCollection JournalEntries = new Classes.JournalEntryCollection();

            bool HasEntries = (JournalEntries.Count() > 0);

            FilterButton.Enabled = HasEntries;
            OptionsButton.Enabled = HasEntries;
            GroupByMenuButton.Enabled = HasEntries;

            RefreshButton.Enabled = HasEntries;

            ClearViewButton.Enabled = (GridView.Id > 0);
            LoadViewMenuButton.Enabled = (this.ViewCount > 0);
            SaveViewButton.Enabled = (GridView.Changed && !GridView.IsAutoSaved);
            SaveViewAsButton.Enabled = HasEntries;
            ManageViewsButton.Enabled = (this.ViewCount > 0);

            PrintMenuButton.Enabled = HasEntries;

            // Special handling
            if (GridView.Id == 0) {
                SaveViewButton.Enabled = false;
                SaveViewAsButton.Enabled = false;
            }
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
            if (!LoadingExistingGrid) {
                GridView.Changed = true;
            }
            RunGrid(autoSaveView);
        }

        //----------------------------------------------------------------------

        private void PopulateLoadMenu()
        {
            // Common functions
            this.ViewCount = this.Widgets.PopulateLoadMenu("GridView", ToolStrip);

            // Grid-specific function
            foreach (ToolStripItem Item in LoadViewMenuButton.DropDownItems) {
                Item.Click += new System.EventHandler(this.LoadViewButton_Click);
            }
        }

        //----------------------------------------------------------------------
        // Wrapper for the grid-loading logic, followed by the actual running
        // of the grid (triggered within GroupBySelect).
        //----------------------------------------------------------------------

        private void LoadAndRunGrid(long gridViewId)
        {
            if (gridViewId > 0) {
                // Load Last Saved Options
                LoadingExistingGrid = true;

                GridView.Load(gridViewId);

                // This requires some explanation. It's definitely a hack but something
                // for which I don't currently have the time or energy to handle otherwise.
                // In short, the tree handling logic lies within the Filtering dialog box,
                // including the ImpliedProjects and ImpliedActivities. These structures
                // are the result of looking at the actually-checked values in the treeview
                // controls and returning the  list of ProjectId and ActivityId values that
                // are implied by the checkboxes. This information is required to properly
                // paint a just-loaded grid and it only lives in Forms.Shared.Filtering.
                // If we instantiate this form here, right after loading up a saved grid
                // view, then everything Just Works.
                this.FilterDialog = new Forms.Shared.Filtering(GridView.FilterOptions);

                // Reflect loaded grid in Title Bar
                this.Widgets.SetViewTitleBar(this, "Grid", GridView.Name);

                // Set this as the last run ID
                Options.State_LastGridViewId = gridViewId;

                // Restore UI based on Saved Options
                // FIXME: Stolen (more or less) from the Options button
                GroupByComboBox.SelectedIndex = (int)GridView.RefGroupById - 1;
                DimensionComboBox.SelectedIndex = (int)GridView.RefDimensionId - 1; // dimension
                TimeDisplayComboBox.SelectedIndex = (int)GridView.RefTimeDisplayId - 1;

                // Update Toolbar
                UpdateToolbar();

                // Set the value (which triggers RunGrid() itself)
                GroupBySelect(GroupByComboBox.SelectedIndex, false);

                LoadingExistingGrid = false;
            } else {
                // We still need one
                this.FilterDialog = new Forms.Shared.Filtering();

                // Enable/disable toolbar
                UpdateToolbar();

                // Default to "By Day" (and trigger RunGrid())
                GroupBySelect(0, false);
            }
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
                // Update the view state
                //-----------------------------------

                UpdateViewState(autoSaveView);
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