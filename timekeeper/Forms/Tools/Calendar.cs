using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Tools
{
    public partial class Calendar : Forms.Shared.BaseView
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private Table CalendarResults;
        private int FilterDateCount;
        private System.Windows.Forms.ToolStripButton ShowEntriesButton;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Calendar(BrowserCallback f)
            : base()
        {
            InitializeComponent();
            InitializeComponentExtensions();

            // Define the things that make this form *this* form
            this.FilterOptionsType = Classes.FilterOptions.OptionsType.Calendar;
            this.ViewName = "Calendar";
            this.TableName = "CalendarView";
            this.Browser_GotoEntry = f;
            this.CurrentView = new Classes.CalendarView();
            this.AutoSavedView = new Classes.CalendarView();
            this.CurrentViewEmpty = new Classes.CalendarView();
            this.AutoSavedViewEmpty = new Classes.CalendarView("Unsaved View");

            this.Browser_GotoEntry = f;

            // Then initialize the base class
            this.Initialize();
        }

        //---------------------------------------------------------------------

        private void InitializeComponentExtensions()
        {
            this.ShowEntriesButton = new System.Windows.Forms.ToolStripButton();

            this.ShowEntriesButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallProject;
            this.ShowEntriesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowEntriesButton.Name = "ShowEntriesButton";
            this.ShowEntriesButton.Size = new System.Drawing.Size(89, 22);
            this.ShowEntriesButton.Text = "Show Entries";
            this.ShowEntriesButton.Click += new System.EventHandler(this.ShowEntriesButton_Click);

            this.ToolStrip.Items.Insert(1, ShowEntriesButton);
        }

        //---------------------------------------------------------------------
        // Form Events
        //---------------------------------------------------------------------

        private void Calendar_Load(object sender, EventArgs e)
        {
            // Restore window metrics
            Height = Options.Calendar_Height;
            Width = Options.Calendar_Width;
            Top = Options.Calendar_Top;
            Left = Options.Calendar_Left;

            // Restore column widths
            FilterResultsGrid.Columns["JournalId"].Width = Options.Calendar_Grid_JournalIdWidth;
            FilterResultsGrid.Columns["ProjectName"].Width = Options.Calendar_Grid_ProjectNameWidth;
            FilterResultsGrid.Columns["ActivityName"].Width = Options.Calendar_Grid_ActivityNameWidth;
            FilterResultsGrid.Columns["StartTime"].Width = Options.Calendar_Grid_StartTimeWidth;
            FilterResultsGrid.Columns["StopTime"].Width = Options.Calendar_Grid_StopTimeWidth;
            FilterResultsGrid.Columns["Seconds"].Width = Options.Calendar_Grid_SecondsWidth;
            FilterResultsGrid.Columns["Memo"].Width = Options.Calendar_Grid_MemoWidth;
            FilterResultsGrid.Columns["LocationName"].Width = Options.Calendar_Grid_LocationNameWidth;
            FilterResultsGrid.Columns["CategoryName"].Width = Options.Calendar_Grid_CategoryNameWidth;
            FilterResultsGrid.Columns["IsLocked"].Width = Options.Calendar_Grid_IsLockedWidth;

            // Show entries?
            CalendarSplitContainer.Panel2Collapsed = Options.Calendar_ShowEntries;
            ShowEntriesButton_Click(sender, e);
        }

        //---------------------------------------------------------------------

        private void Calendar_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save window metrics
            Options.Calendar_Height = Height;
            Options.Calendar_Width = Width;
            Options.Calendar_Top = Top;
            Options.Calendar_Left = Left;

            // Save column widths
            Options.Calendar_Grid_JournalIdWidth = FilterResultsGrid.Columns["JournalId"].Width;
            Options.Calendar_Grid_ProjectNameWidth = FilterResultsGrid.Columns["ProjectName"].Width;
            Options.Calendar_Grid_ActivityNameWidth = FilterResultsGrid.Columns["ActivityName"].Width;
            Options.Calendar_Grid_StartTimeWidth = FilterResultsGrid.Columns["StartTime"].Width;
            Options.Calendar_Grid_StopTimeWidth = FilterResultsGrid.Columns["StopTime"].Width;
            Options.Calendar_Grid_SecondsWidth = FilterResultsGrid.Columns["Seconds"].Width;
            Options.Calendar_Grid_MemoWidth = FilterResultsGrid.Columns["Memo"].Width;
            Options.Calendar_Grid_LocationNameWidth = FilterResultsGrid.Columns["LocationName"].Width;
            Options.Calendar_Grid_CategoryNameWidth = FilterResultsGrid.Columns["CategoryName"].Width;
            Options.Calendar_Grid_IsLockedWidth = FilterResultsGrid.Columns["IsLocked"].Width;

            // Save Show Entries
            Options.Calendar_ShowEntries = !CalendarSplitContainer.Panel2Collapsed;

            // Save last view
            Options.State_LastCalendarViewId = this.LastViewId;
        }

        //---------------------------------------------------------------------

        private void CalendarControl_DateChanged(object sender, DateRangeEventArgs e)
        {
            PopulateResultsGrid();
        }

        //---------------------------------------------------------------------
        // Toolbar events
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
        // Private helpers
        //---------------------------------------------------------------------

        override internal void PopulateData()
        {
            //----------------------------------------------
            // Populate Table
            //----------------------------------------------

            // At this point, this.CurrentView *should* be enough to get us
            // by, but it's not. So we need to instantiate a new, specific,
            // child-class. Then copy the FilterOptions into it.
            Classes.CalendarView CalendarView = new Classes.CalendarView(this.CurrentView.Id);
            CalendarView.FilterOptions.Copy(this.CurrentView.FilterOptions);

            // Now get the results
            this.CalendarResults = CalendarView.FilterResults();

            List<DateTime> DateList = new List<DateTime>();

            foreach (Row JournalEntry in CalendarResults) {

                DateTime EntryStartTime = JournalEntry["StartTime"];

                if (!DateList.Contains(EntryStartTime.Date))
                    DateList.Add(EntryStartTime.Date);
            }

            FilterDateCount = DateList.Count;
            DateTime[] DateArray = new DateTime[FilterDateCount];
            DateArray = DateList.ToArray();

            CalendarControl.BoldedDates = DateArray;

            PopulateResultsGrid();
        }

        //---------------------------------------------------------------------

        private void PopulateResultsGrid()
        {
            FilterResultsGrid.Rows.Clear();

            int EntryCount = 0;

            foreach (Row JournalEntry in CalendarResults) {

                DateTime EntryStartTime = JournalEntry["StartTime"];

                if (EntryStartTime.Date.CompareTo(CalendarControl.SelectionStart.Date) == 0) {

                    EntryCount++;

                    FilterResultsGrid.Rows.Add(
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

            //----------------------------------------------
            // Sort (or re-sort) the table
            //----------------------------------------------

            DataGridViewColumn CurrentlySortedColumn = FilterResultsGrid.SortedColumn;

            if (CurrentlySortedColumn == null) {
                DataGridViewColumn DefaultSortColumn = FilterResultsGrid.Columns["StartTime"];
                FilterResultsGrid.Sort(DefaultSortColumn, ListSortDirection.Ascending);
            } else {
                ListSortDirection CurrentDirection = ListSortDirection.Ascending;
                if (FilterResultsGrid.SortOrder == SortOrder.Descending) {
                    CurrentDirection = ListSortDirection.Descending;
                }
                FilterResultsGrid.Sort(CurrentlySortedColumn, CurrentDirection);
            }

            string StatusBarText = String.Format("{0} filter. {1} found for current date.",
                Timekeeper.Pluralize(FilterDateCount, "date matches", "dates match"),
                Timekeeper.Pluralize(EntryCount, "entry", "entries"));

            ResultCount.Text = StatusBarText;
        }

        private void FilterResultsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow Row = FilterResultsGrid.Rows[e.RowIndex];
                long JournalId = Convert.ToInt64(Row.Cells["JournalId"].Value);
                // Browser_GotoEntry() is a callback. The call you see here is
                // not the same as the call you see below.
                this.Browser_GotoEntry(JournalId);
            }
        }

        //---------------------------------------------------------------------
    }
}
