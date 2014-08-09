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
    public partial class Calendar : Form
    {
        //---------------------------------------------------------------------

        private Classes.Options Options;
        private Classes.Widgets Widgets;

        private Classes.CalendarView CalendarView;
        private Classes.CalendarView AutoSavedCalendarView;

        private Table CalendarResults;
        private int FilterDateCount;

        //---------------------------------------------------------------------

        public delegate void BrowserCallback(long entryId);
        private BrowserCallback Browser_GotoEntry;

        //---------------------------------------------------------------------

        // Um, hack?
        private Forms.Shared.Filtering FilterDialog;

        //---------------------------------------------------------------------

        public Calendar(BrowserCallback f)
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;
            this.CalendarView = new Classes.CalendarView();
            this.AutoSavedCalendarView = new Classes.CalendarView();
            this.Widgets = new Classes.Widgets();

            this.Browser_GotoEntry = f;
        }

        //---------------------------------------------------------------------

        private void Calendar_Load(object sender, EventArgs e)
        {
            try {
                // Restore window metrics
                Height = Options.Calendar_Height;
                Width = Options.Calendar_Width;
                Top = Options.Calendar_Top;
                Left = Options.Calendar_Left;

                // Restore column widths
                JournalResultsGrid.Columns["JournalId"].Width = Options.Calendar_Grid_JournalIdWidth;
                JournalResultsGrid.Columns["ProjectName"].Width = Options.Calendar_Grid_ProjectNameWidth;
                JournalResultsGrid.Columns["ActivityName"].Width = Options.Calendar_Grid_ActivityNameWidth;
                JournalResultsGrid.Columns["StartTime"].Width = Options.Calendar_Grid_StartTimeWidth;
                JournalResultsGrid.Columns["StopTime"].Width = Options.Calendar_Grid_StopTimeWidth;
                JournalResultsGrid.Columns["Seconds"].Width = Options.Calendar_Grid_SecondsWidth;
                JournalResultsGrid.Columns["Memo"].Width = Options.Calendar_Grid_MemoWidth;
                JournalResultsGrid.Columns["LocationName"].Width = Options.Calendar_Grid_LocationNameWidth;
                JournalResultsGrid.Columns["CategoryName"].Width = Options.Calendar_Grid_CategoryNameWidth;
                JournalResultsGrid.Columns["IsLocked"].Width = Options.Calendar_Grid_IsLockedWidth;

                // Show entries?
                CalendarSplitContainer.Panel2Collapsed = Options.Calendar_ShowEntries;
                ShowEntriesButton_Click(sender, e);

                // Load up saved Calendar and paint
                LoadAndRunCalendar(Options.State_LastCalendarViewId);

                if (CalendarView.IsAutoSaved) {
                    CalendarView.Changed = true;
                }

                // Populate the list of Saved Views
                PopulateLoadMenu();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Calendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CalendarView.Changed) {
                if (Common.WarnPrompt("Calendar view has not been saved. Continue closing?") == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
            }

            // Save window metrics
            Options.Calendar_Height = Height;
            Options.Calendar_Width = Width;
            Options.Calendar_Top = Top;
            Options.Calendar_Left = Left;

            // Save column widths
            Options.Calendar_Grid_JournalIdWidth = JournalResultsGrid.Columns["JournalId"].Width;
            Options.Calendar_Grid_ProjectNameWidth = JournalResultsGrid.Columns["ProjectName"].Width;
            Options.Calendar_Grid_ActivityNameWidth = JournalResultsGrid.Columns["ActivityName"].Width;
            Options.Calendar_Grid_StartTimeWidth = JournalResultsGrid.Columns["StartTime"].Width;
            Options.Calendar_Grid_StopTimeWidth = JournalResultsGrid.Columns["StopTime"].Width;
            Options.Calendar_Grid_SecondsWidth = JournalResultsGrid.Columns["Seconds"].Width;
            Options.Calendar_Grid_MemoWidth = JournalResultsGrid.Columns["Memo"].Width;
            Options.Calendar_Grid_LocationNameWidth = JournalResultsGrid.Columns["LocationName"].Width;
            Options.Calendar_Grid_CategoryNameWidth = JournalResultsGrid.Columns["CategoryName"].Width;
            Options.Calendar_Grid_IsLockedWidth = JournalResultsGrid.Columns["IsLocked"].Width;

            // Save Show Entries
            Options.Calendar_ShowEntries = !CalendarSplitContainer.Panel2Collapsed;
        }

        //---------------------------------------------------------------------
        // Toolbar
        //---------------------------------------------------------------------

        private void FilterButton_Click(object sender, EventArgs e)
        {
            CalendarView.FilterOptions.FilterOptionsType = Classes.FilterOptions.OptionsType.Calendar;
            CalendarView.FilterOptions.FilterMergeType = null;

            // Re-instantiate just before opening. See comment surrounding the
            // only other instantiation of this object
            this.FilterDialog = new Forms.Shared.Filtering(CalendarView.FilterOptions);

            CalendarView.FilterOptions = this.Widgets.FilteringDialog(this,
                FilterDialog, CalendarView.FilterOptions.FilterOptionsId);

            if (CalendarView.FilterOptions.Changed) {
                CalendarView.Changed = true;
                RunCalendar();
            }

            /*
            Common.Info("This is the filter options dialog box.");

            List<DateTime> DaysUsed = new List<DateTime>();
            DaysUsed.Add(DateTime.Now);
            DaysUsed.Add(DateTime.Now.AddDays(1));
            DaysUsed.Add(DateTime.Now.AddDays(2));
            DaysUsed.Add(DateTime.Now.AddDays(6));

            DateTime[] FilterHits = new DateTime[DaysUsed.Count];
            FilterHits = DaysUsed.ToArray();

            wCalendar.BoldedDates = FilterHits;
            */
        }

        //---------------------------------------------------------------------

        private void ShowEntriesButton_Click(object sender, EventArgs e)
        {
            if (CalendarSplitContainer.Panel2Collapsed) {
                CalendarSplitContainer.Panel2Collapsed = false;
                ShowEntriesButton.Text = "Hide Entries";
            } else {
                CalendarSplitContainer.Panel2Collapsed = true;
                ShowEntriesButton.Text = "Show Entries";
            }
        }

        //---------------------------------------------------------------------

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunCalendar(false);
        }

        //----------------------------------------------------------------------

        private void ClearViewButton_Click(object sender, EventArgs e)
        {
            if (this.Widgets.ClearViewCancelled(CalendarView.Changed)) {
                return;
            }

            CalendarView = new Classes.CalendarView();

            this.Widgets.SetViewTitleBar(this, "Calendar");

            LoadAndRunCalendar(0);
        }

        //---------------------------------------------------------------------

        private void LoadViewButton_Click(object sender, EventArgs e)
        {
            ToolStripItem Item = (ToolStripItem)sender;
            Classes.BaseView View = (Classes.BaseView)Item.Tag;
            LoadAndRunCalendar(View.Id);
        }

        //----------------------------------------------------------------------

        private void SaveViewButton_Click(object sender, EventArgs e)
        {
            // Set Calendar-specific view options
            // (none)

            // Save view
            CalendarView.Save(CalendarView.FilterOptions.Changed, CalendarView.FilterOptions.FilterOptionsId);

            // Post-save steps
            CalendarView.Changed = false;
            this.Widgets.SetViewTitleBar(this, "Calendar", CalendarView.Name);
        }

        //----------------------------------------------------------------------

        private void SaveViewAsButton_Click(object sender, EventArgs e)
        {
            CalendarView = (Classes.CalendarView)this.Widgets.SaveViewDialog(this, "Calendar", CalendarView);
            if (CalendarView.Changed) {
                CalendarView.Save(true); // When Saving As, always create a new FilterRow
                CalendarView.Changed = false;
                PopulateLoadMenu();
                UpdateToolbar();
                Options.State_LastCalendarViewId = CalendarView.Id;
            }
        }

        //----------------------------------------------------------------------

        private void ManageViewsButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.ManageViews DialogBox = new Forms.Shared.ManageViews("CalendarView");
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------
        // Other events
        //----------------------------------------------------------------------

        private void wCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            PopulateResultsGrid();
        }

        private void JournalFindResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow Row = JournalResultsGrid.Rows[e.RowIndex];
                long JournalId = Convert.ToInt64(Row.Cells["JournalId"].Value);
                // Browser_GotoEntry() is a callback. The call you see here is
                // not the same as the call you see below.
                this.Browser_GotoEntry(JournalId);
            }
        }

        //----------------------------------------------------------------------
        // Internal Helpers
        //----------------------------------------------------------------------

        private void UpdateViewState(bool autoSaveView)
        {
            if ((CalendarView.Id == 0) || CalendarView.IsAutoSaved) {
                if (autoSaveView) {
                    AutoSaveView();
                }
            } else {
                if (CalendarView.Changed) {
                    this.Widgets.SetViewTitleBar(this, "Calendar", CalendarView.Name + "*");
                }
            }
            UpdateToolbar();
        }

        //----------------------------------------------------------------------

        private void AutoSaveView()
        {
            /*
                Yes, there's a high degree of copy/paste between Grid's AutoSaveView and
                Find's AutoSaveView and here. I'm leaving that for a rainy day project. 
                [CH, 2013-09-24 and then again on 2014-08-06.]
            */
            AutoSavedCalendarView = new Classes.CalendarView("Unsaved View");

            bool NewView = false;

            if (AutoSavedCalendarView.Id == 0) {
                // This is the first time; so seed the new view
                AutoSavedCalendarView.Name = "Unsaved View";
                AutoSavedCalendarView.Description = "Unnamed, last-applied view";
                NewView = true;
            }

            // Overwrite FilterOptions with current FilterOptions
            long SavedFilterOptionsId = AutoSavedCalendarView.FilterOptions.FilterOptionsId;
            AutoSavedCalendarView.FilterOptions = CalendarView.FilterOptions;
            if (CalendarView.FilterOptions.FilterOptionsId > 0) {
                AutoSavedCalendarView.FilterOptions.FilterOptionsId = CalendarView.FilterOptions.FilterOptionsId;
            } else {
                AutoSavedCalendarView.FilterOptions.FilterOptionsId = SavedFilterOptionsId;
            }

            // Overwrite Find-specific settings with current UI values
            // (none (yet))

            // Now attempt to save (this is an upsert)
            if (AutoSavedCalendarView.Save(CalendarView.FilterOptions.Changed, AutoSavedCalendarView.FilterOptions.FilterOptionsId)) {
                // Make sure the Last Saved ID is the current value
                Options.State_LastCalendarViewId = AutoSavedCalendarView.Id;

                // And copy it back into the current grid options
                CalendarView = AutoSavedCalendarView;

                // Although this has technically been saved to the DB, treat it as though it hasn't
                CalendarView.Changed = true;

                // Update title bar
                this.Widgets.SetViewTitleBar(this, "Calendar", CalendarView.Name);
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
            bool HasEntries = this.Widgets.UpdateToolbar(ToolStrip, (Classes.BaseView)CalendarView);

            // Hide Columns based on Options
            // FIXME: Wrong spot for this
            try {
                JournalResultsGrid.Columns["ProjectName"].Visible = Options.Layout_UseProjects;
                JournalResultsGrid.Columns["ActivityName"].Visible = Options.Layout_UseActivities;
                JournalResultsGrid.Columns["LocationName"].Visible = Options.Layout_UseLocations;
                JournalResultsGrid.Columns["CategoryName"].Visible = Options.Layout_UseCategories;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void PopulateLoadMenu()
        {
            // Common functions
            this.Widgets.PopulateLoadMenu("CalendarView", ToolStrip);

            // Calendar-specific function
            foreach (ToolStripItem Item in LoadViewMenuButton.DropDownItems) {
                Item.Click += new System.EventHandler(this.LoadViewButton_Click);
            }
        }

        //----------------------------------------------------------------------
        // Wrapper for the gridfind loading logic, followed by the actual 
        // running of the Find code.
        //----------------------------------------------------------------------

        private void LoadAndRunCalendar(long calenderViewId)
        {
            if (calenderViewId > 0) {
                // Load Last Saved Options
                CalendarView.Load(calenderViewId);

                CalendarView.FilterOptions.FilterMergeType = null;

                // This requires some explanation. It's definitely a hack but something
                // for which I don't currently have the time or energy to handle otherwise.
                // In short, the tree handling logic lies within the Filtering dialog box,
                // including the ImpliedProjects and ImpliedActivities. These structures
                // are the result of looking at the actually-checked values in the treeview
                // controls and returning the list of ProjectId and ActivityId values that
                // are implied by the checkboxes. This information is required to properly
                // paint a just-loaded grid and it only lives in Forms.Shared.Filtering.
                // If we instantiate this form here, right after loading up a saved grid
                // view, then everything Just Works.

                this.FilterDialog = new Forms.Shared.Filtering(CalendarView.FilterOptions);

                // Reflect loaded view in Title Bar
                this.Widgets.SetViewTitleBar(this, "Calendar", CalendarView.Name);

                // Set this as the last run ID
                Options.State_LastCalendarViewId = calenderViewId;

                RunCalendar(false);
            } else {
                UpdateToolbar();
                RunCalendar(false);
            }
        }

        //----------------------------------------------------------------------

        private void RunCalendar()
        {
            RunCalendar(true);
        }

        //---------------------------------------------------------------------

        private void RunCalendar(bool autoSaveView)
        {
            RunJournalCalendar();
            UpdateViewState(autoSaveView);
        }

        //---------------------------------------------------------------------

        private void RunJournalCalendar()
        {
            //----------------------------------------------
            // Populate Table
            //----------------------------------------------

            this.CalendarResults = CalendarView.JournalResults();

            List<DateTime> DateList = new List<DateTime>();

            foreach (Row JournalEntry in CalendarResults) {

                DateTime EntryStartTime = JournalEntry["StartTime"];

                if (!DateList.Contains(EntryStartTime.Date))
                    DateList.Add(EntryStartTime.Date);
            }

            FilterDateCount = DateList.Count;
            DateTime[] DateArray = new DateTime[FilterDateCount];
            DateArray = DateList.ToArray();

            wCalendar.BoldedDates = DateArray;

            PopulateResultsGrid();
        }

        //---------------------------------------------------------------------
        // Private helpers
        //---------------------------------------------------------------------

        private void PopulateResultsGrid()
        {
            JournalResultsGrid.Rows.Clear();

            int EntryCount = 0;

            foreach (Row JournalEntry in CalendarResults) {

                DateTime EntryStartTime = JournalEntry["StartTime"];

                if (EntryStartTime.Date.CompareTo(wCalendar.SelectionStart.Date) == 0) {

                    EntryCount++;

                    JournalResultsGrid.Rows.Add(
                        Timekeeper.TimeForDisplay(JournalEntry["StartTime"]),
                        Timekeeper.TimeForDisplay(JournalEntry["StopTime"]),
                        Timekeeper.FormatSeconds(JournalEntry["Seconds"]),
                        JournalEntry["Memo"],
                        JournalEntry["ProjectId"],
                        JournalEntry["ProjectName"],
                        JournalEntry["ActivityId"],
                        JournalEntry["ActivityName"],
                        JournalEntry["LocationId"],
                        JournalEntry["LocationName"],
                        JournalEntry["CategoryId"],
                        JournalEntry["CategoryName"],
                        JournalEntry["IsLocked"],
                        JournalEntry["JournalId"]
                        );

                }
            }

            // DateTime SelectedDate = wCalendar.SelectionStart;

            //----------------------------------------------
            // Sort (or re-sort) the table
            //----------------------------------------------

            DataGridViewColumn CurrentlySortedColumn = JournalResultsGrid.SortedColumn;

            if (CurrentlySortedColumn == null) {
                DataGridViewColumn DefaultSortColumn = JournalResultsGrid.Columns["StartTime"];
                JournalResultsGrid.Sort(DefaultSortColumn, ListSortDirection.Ascending);
            } else {
                ListSortDirection CurrentDirection = ListSortDirection.Ascending;
                if (JournalResultsGrid.SortOrder == SortOrder.Descending) {
                    CurrentDirection = ListSortDirection.Descending;
                }
                JournalResultsGrid.Sort(CurrentlySortedColumn, CurrentDirection);
            }

            string StatusBarText = String.Format("{0} filter. {1} found for current date.",
                Timekeeper.Pluralize(FilterDateCount, "date matches", "dates match"),
                Timekeeper.Pluralize(EntryCount, "entry", "entries"));

            ResultCount.Text = StatusBarText;
        }

        //---------------------------------------------------------------------

    }
}