using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    public partial class Find : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private Classes.Options Options;
        private Classes.Widgets Widgets;

        private Classes.FindView FindView;
        private Classes.FindView AutoSavedFindView;

        public delegate void BrowserCallback(long entryId);

        private BrowserCallback Browser_GotoEntry;

        // Um, hack?

        private Forms.Shared.Filtering FilterDialog;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Find(BrowserCallback f)
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;
            this.FindView = new Classes.FindView();
            this.AutoSavedFindView = new Classes.FindView();
            this.Widgets = new Classes.Widgets();

            this.Browser_GotoEntry = f;
        }

        //---------------------------------------------------------------------
        // Events
        //---------------------------------------------------------------------

        private void Find_Load(object sender, EventArgs e)
        {
            try {
                // Restore window metrics
                Height = Options.Find_Height;
                Width = Options.Find_Width;
                Top = Options.Find_Top;
                Left = Options.Find_Left;

                // Restore column widths
                FindResultsGrid.Columns["JournalId"].Width = Options.Find_Grid_JournalIdWidth;
                FindResultsGrid.Columns["ProjectName"].Width = Options.Find_Grid_ProjectNameWidth;
                FindResultsGrid.Columns["ActivityName"].Width = Options.Find_Grid_ActivityNameWidth;
                FindResultsGrid.Columns["StartTime"].Width = Options.Find_Grid_StartTimeWidth;
                FindResultsGrid.Columns["StopTime"].Width = Options.Find_Grid_StopTimeWidth;
                FindResultsGrid.Columns["Seconds"].Width = Options.Find_Grid_SecondsWidth;
                FindResultsGrid.Columns["Memo"].Width = Options.Find_Grid_MemoWidth;
                FindResultsGrid.Columns["LocationName"].Width = Options.Find_Grid_LocationNameWidth;
                FindResultsGrid.Columns["CategoryName"].Width = Options.Find_Grid_CategoryNameWidth;
                FindResultsGrid.Columns["IsLocked"].Width = Options.Find_Grid_IsLockedWidth;

                // Load up saved Find and paint
                LoadAndRunFind(Options.State_LastFindViewId);

                if (FindView.IsAutoSaved) {
                    FindView.Changed = true;
                }

                // Populate the list of Saved Views
                PopulateLoadMenu();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void Find_Activated(object sender, EventArgs e)
        {
            UpdateToolbar();
        }

        //----------------------------------------------------------------------

        private void Find_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save window metrics
            Options.Find_Height = Height;
            Options.Find_Width = Width;
            Options.Find_Top = Top;
            Options.Find_Left = Left;

            // Save column widths
            Options.Find_Grid_JournalIdWidth = FindResultsGrid.Columns["JournalId"].Width;
            Options.Find_Grid_ProjectNameWidth = FindResultsGrid.Columns["ProjectName"].Width;
            Options.Find_Grid_ActivityNameWidth = FindResultsGrid.Columns["ActivityName"].Width;
            Options.Find_Grid_StartTimeWidth = FindResultsGrid.Columns["StartTime"].Width;
            Options.Find_Grid_StopTimeWidth = FindResultsGrid.Columns["StopTime"].Width;
            Options.Find_Grid_SecondsWidth = FindResultsGrid.Columns["Seconds"].Width;
            Options.Find_Grid_MemoWidth = FindResultsGrid.Columns["Memo"].Width;
            Options.Find_Grid_LocationNameWidth = FindResultsGrid.Columns["LocationName"].Width;
            Options.Find_Grid_CategoryNameWidth = FindResultsGrid.Columns["CategoryName"].Width;
            Options.Find_Grid_IsLockedWidth = FindResultsGrid.Columns["IsLocked"].Width;
        }

        //----------------------------------------------------------------------
        // Toolbar Commands
        //----------------------------------------------------------------------

        private void FilterButton_Click(object sender, EventArgs e)
        {
            // Re-instantiate just before opening. See comment surrounding the
            // only other instantiation of this object
            this.FilterDialog = new Forms.Shared.Filtering(FindView.FilterOptions);

            FindView.FilterOptions = this.Widgets.FilteringDialog(this,
                FilterDialog, FindView.FilterOptions.FilterOptionsId);

            if (FindView.FilterOptions.Changed) {
                FindView.Changed = true;
                RunFind();
            }
        }

        //---------------------------------------------------------------------

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunFind(false);
        }

        //----------------------------------------------------------------------

        private void ClearViewButton_Click(object sender, EventArgs e)
        {
            if (this.Widgets.ClearViewCancelled(FindView.Changed)) {
                return;
            }

            FindView = new Classes.FindView();

            this.Widgets.SetViewTitleBar(this, "Find");
            ClearViewButton.Enabled = false;

            LoadAndRunFind(0);
        }

        //---------------------------------------------------------------------

        private void LoadViewButton_Click(object sender, EventArgs e)
        {
            ToolStripItem Item = (ToolStripItem)sender;
            Classes.BaseView View = (Classes.BaseView)Item.Tag;
            LoadAndRunFind(View.Id);
        }

        //----------------------------------------------------------------------

        private void SaveViewButton_Click(object sender, EventArgs e)
        {
            // Set Find-specific view options
            // (none)

            // Save view
            FindView.Save(FindView.FilterOptions.Changed, FindView.FilterOptions.FilterOptionsId);

            // Post-save steps
            FindView.Changed = false;
            this.Widgets.SetViewTitleBar(this, "Find", FindView.Name);
        }

        //----------------------------------------------------------------------

        private void SaveViewAsButton_Click(object sender, EventArgs e)
        {
            FindView = (Classes.FindView)this.Widgets.SaveViewDialog(this, "Find", FindView);
            if (FindView.Changed) {
                FindView.Save(true); // When Saving As, always create a new FilterRow
                FindView.Changed = false;
                PopulateLoadMenu();
                UpdateToolbar();
                Options.State_LastFindViewId = FindView.Id;
            }
        }

        //----------------------------------------------------------------------

        private void ManageViewsButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.ManageViews DialogBox = new Forms.Shared.ManageViews("FindView");
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------
        // Other events
        //----------------------------------------------------------------------

        private void FindResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow Row = FindResultsGrid.Rows[e.RowIndex];
                long JournalIndex = Convert.ToInt64(Row.Cells["JournalIndex"].Value);
                this.Browser_GotoEntry(JournalIndex);
            }
        }

        //----------------------------------------------------------------------
        // Internal Helpers
        //----------------------------------------------------------------------

        private void UpdateViewState(bool autoSaveView)
        {
            if ((FindView.Id == 0) || FindView.IsAutoSaved) {
                if (autoSaveView) {
                    AutoSaveView();
                }
            } else {
                if (FindView.Changed) {
                    this.Widgets.SetViewTitleBar(this, "Find", FindView.Name + "*");
                }
            }
            UpdateToolbar();
        }

        //----------------------------------------------------------------------

        private void AutoSaveView()
        {
            /*
                Yes, there's a high degree of copy/paste between Grid's AutoSaveView and
                here. I'm leaving that for a rainy day project. [CH, 2013-09-24]
            */
            AutoSavedFindView = new Classes.FindView("Unsaved View");

            bool NewView = false;

            if (AutoSavedFindView.Id == 0) {
                // This is the first time; so seed the new view
                AutoSavedFindView.Name = "Unsaved View";
                AutoSavedFindView.Description = "Unnamed, last-applied view";
                NewView = true;
            }

            // Overwrite FilterOptions with current FilterOptions
            long SavedFilterOptionsId = AutoSavedFindView.FilterOptions.FilterOptionsId;
            AutoSavedFindView.FilterOptions = FindView.FilterOptions;
            if (FindView.FilterOptions.FilterOptionsId > 0) {
                AutoSavedFindView.FilterOptions.FilterOptionsId = FindView.FilterOptions.FilterOptionsId;
            } else {
                AutoSavedFindView.FilterOptions.FilterOptionsId = SavedFilterOptionsId;
            }

            // Overwrite Find-specific settings with current UI values
            // (none (yet))

            // Now attempt to save (this is an upsert)
            if (AutoSavedFindView.Save(FindView.FilterOptions.Changed, AutoSavedFindView.FilterOptions.FilterOptionsId)) {
                // Make sure the Last Saved ID is the current value
                Options.State_LastFindViewId = AutoSavedFindView.Id;

                // And copy it back into the current grid options
                FindView = AutoSavedFindView;

                // Although this has technically been saved to the DB, treat it as though it hasn't
                FindView.Changed = true;

                // Update title bar
                this.Widgets.SetViewTitleBar(this, "Find", FindView.Name);
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
            bool HasEntries = this.Widgets.UpdateToolbar(ToolStrip, (Classes.BaseView)FindView);

            // Hide Columns based on Options
            // FIXME: Wrong spot for this
            try {
                FindResultsGrid.Columns["ProjectName"].Visible = Options.Layout_UseProjects;
                FindResultsGrid.Columns["ActivityName"].Visible = Options.Layout_UseActivities;
                FindResultsGrid.Columns["LocationName"].Visible = Options.Layout_UseLocations;
                FindResultsGrid.Columns["CategoryName"].Visible = Options.Layout_UseCategories;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void PopulateLoadMenu()
        {
            // Common functions
            this.Widgets.PopulateLoadMenu("FindView", ToolStrip);

            // Find-specific function
            foreach (ToolStripItem Item in LoadViewMenuButton.DropDownItems) {
                Item.Click += new System.EventHandler(this.LoadViewButton_Click);
            }
        }

        //----------------------------------------------------------------------
        // Wrapper for the gridfind loading logic, followed by the actual 
        // running of the Find code.
        //----------------------------------------------------------------------

        private void LoadAndRunFind(long findViewId)
        {
            if (findViewId > 0) {
                // Load Last Saved Options
                FindView.Load(findViewId);

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

                this.FilterDialog = new Forms.Shared.Filtering(FindView.FilterOptions);

                // Reflect loaded view in Title Bar
                this.Widgets.SetViewTitleBar(this, "Find", FindView.Name);

                // Set this as the last run ID
                Options.State_LastFindViewId = findViewId;

                RunFind(false);
            } else {
                UpdateToolbar();
                RunFind(false);
            }
        }

        //---------------------------------------------------------------------
        // Main Find Results Generator
        //---------------------------------------------------------------------

        private void RunFind()
        {
            RunFind(true);
        }

        //---------------------------------------------------------------------

        private void RunFind(bool autoSaveView)
        {
            //----------------------------------------------
            // Populate Table
            //----------------------------------------------

            Table FindResults = FindView.Results();

            FindResultsGrid.Rows.Clear();

            foreach (Row JournalEntry in FindResults) {

                FindResultsGrid.Rows.Add(
                    JournalEntry["JournalId"],
                    JournalEntry["JournalIndex"],
                    JournalEntry["ProjectId"],
                    JournalEntry["ProjectName"],
                    JournalEntry["ActivityId"],
                    JournalEntry["ActivityName"],
                    JournalEntry["StartTime"].ToString(Options.Advanced_DateTimeFormat),
                    JournalEntry["StopTime"].ToString(Options.Advanced_DateTimeFormat),
                    Timekeeper.FormatSeconds(JournalEntry["Seconds"]),
                    JournalEntry["Memo"],
                    JournalEntry["LocationId"],
                    JournalEntry["LocationName"],
                    JournalEntry["CategoryId"],
                    JournalEntry["CategoryName"],
                    JournalEntry["IsLocked"]
                    );
            }

            //----------------------------------------------
            // Sort (or re-sort) the table
            //----------------------------------------------

            DataGridViewColumn CurrentlySortedColumn = FindResultsGrid.SortedColumn;

            if (CurrentlySortedColumn == null) {
                DataGridViewColumn DefaultSortColumn = FindResultsGrid.Columns["StartTime"];
                FindResultsGrid.Sort(DefaultSortColumn, ListSortDirection.Ascending);
            } else {
                ListSortDirection CurrentDirection = ListSortDirection.Ascending;
                if (FindResultsGrid.SortOrder == SortOrder.Descending) {
                    CurrentDirection = ListSortDirection.Descending;
                }
                FindResultsGrid.Sort(CurrentlySortedColumn, CurrentDirection);
            }

            //----------------------------------------------
            // UI Updates
            //----------------------------------------------

            ResultCount.Text = FindResultsGrid.Rows.Count.ToString() + " entries found.";
            UpdateViewState(autoSaveView);

        }

        //---------------------------------------------------------------------

    }
}
