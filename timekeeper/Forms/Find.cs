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

        public long lastFindViewId;

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

                // Populate the list of Saved Views
                PopulateLoadMenu();

                // Then go!
                FindView.Load(Options.State_LastFindViewId);
                RunFind(false);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        private void Find_Activated(object sender, EventArgs e)
        {
            EnableToolbar();
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
            Forms.Shared.Filtering FilterDialog = new Forms.Shared.Filtering(FindView.FilterOptions);

            if (FilterDialog.ShowDialog(this) == DialogResult.OK) {
                FindView.FilterOptions = FilterDialog.FilterOptions;
                // FIXME: with double visibility
                Timekeeper.Info("FIXME");
                RunFind();
            }
        }

        //---------------------------------------------------------------------

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunFind(false);
        }

        //---------------------------------------------------------------------

        private void LoadViewButton_Click(object sender, EventArgs e)
        {
            ToolStripItem Item = (ToolStripItem)sender;
            Classes.BaseView View = (Classes.BaseView)Item.Tag;
            FindView.Load(View.Id);
            RunFind(false);
        }

        //----------------------------------------------------------------------

        private void SaveViewButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.SaveView DialogBox = new Forms.Shared.SaveView("FindView");
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                FindView.Name = DialogBox.ViewName.Text;
                FindView.Description = DialogBox.ViewDescription.Text;
                FindView.Save();
                PopulateLoadMenu();
                this.Widgets.SetViewTitleBar(this, "Find", FindView.Name);
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
        // Internal Helpers
        //----------------------------------------------------------------------

        private void AutoSaveView()
        {
            AutoSavedFindView = new Classes.FindView("Last View");

            bool NewView = false;

            if (AutoSavedFindView.Id == 0) {
                // This is the first time; so seed the new view
                AutoSavedFindView.Name = "Last View";
                AutoSavedFindView.Description = "Automatically saved view";
                NewView = true;
            }

            // Overwrite FilterOptions with current FilterOptions
            AutoSavedFindView.FilterOptions = FindView.FilterOptions;

            // Overwrite Find-specific settings with current UI values
            // NONE YET: Below is from Grid.cs for reference
            /*
            AutoSavedFindView.RefGroupById = GroupByComboBox.SelectedIndex + 1;
            AutoSavedFindView.RefDimensionId = DimensionComboBox.SelectedIndex + 1;
            AutoSavedFindView.RefTimeDisplayId = TimeDisplayComboBox.SelectedIndex + 1;
            */

            // Now attempt to save (this is an upsert)
            if (AutoSavedFindView.Save()) {
                // Make sure the Last Saved ID is the current value
                Options.State_LastFindViewId = AutoSavedFindView.Id;

                // Tell me about it
                Timekeeper.Debug("Just saved FindViewId = " + AutoSavedFindView.Id.ToString());

                // And copy it back into the current find options
                FindView = AutoSavedFindView;

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

        private void EnableToolbar()
        {
            Classes.JournalEntryCollection JournalEntries = new Classes.JournalEntryCollection();

            bool HasEntries = (JournalEntries.Count() > 0);

            FilterButton.Enabled = HasEntries;
            /*
            OptionsButton.Enabled = HasEntries;
            GroupByMenuButton.Enabled = HasEntries;
            */
            RefreshButton.Enabled = HasEntries;
            LoadViewMenuButton.Enabled = HasEntries;
            SaveViewButton.Enabled = HasEntries;
            ManageViewsButton.Enabled = HasEntries;

            /*
            PrintMenuButton.Enabled = HasEntries;
            */

            // FIXME: wrong spot for this

            // Hide Columns based on Options
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
            // Setup
            //----------------------------------------------

            // Reflect loaded grid in Title Bar
            this.Widgets.SetViewTitleBar(this, "Find", FindView.Name);

            Options.State_LastFindViewId = FindView.Id;

            //----------------------------------------------
            // Run
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

            ResultCount.Text = FindResultsGrid.Rows.Count.ToString() + " entries found.";

            //----------------------------------------------
            // Save
            //----------------------------------------------

            if (autoSaveView) {
                AutoSaveView();
            }

        }

        //---------------------------------------------------------------------

        private void FindResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow Row = FindResultsGrid.Rows[e.RowIndex];
                long JournalIndex = Convert.ToInt64(Row.Cells["JournalIndex"].Value);
                this.Browser_GotoEntry(JournalIndex);
            }
        }

        //---------------------------------------------------------------------

    }
}
