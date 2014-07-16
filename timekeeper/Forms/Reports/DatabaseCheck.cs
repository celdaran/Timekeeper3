using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Reports
{
    public partial class DatabaseCheck : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;
        private int IssueCounter = 0;

        public delegate void BrowserCallback(long entryId);
        private BrowserCallback Browser_GotoEntry;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public DatabaseCheck(BrowserCallback f)
        {
            InitializeComponent();
            this.Browser_GotoEntry = f;
            this.Options = Timekeeper.Options;
        }

        //----------------------------------------------------------------------
        // Form events
        //----------------------------------------------------------------------

        private void DatabaseCheckResultsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow Row = DatabaseCheckResultsGrid.Rows[e.RowIndex];
                long JournalId = Convert.ToInt64(Row.Cells["JournalId"].Value);
                if (JournalId > 0) {
                    this.Browser_GotoEntry(JournalId);
                }
            }
        }

        //----------------------------------------------------------------------
        // Toolbar events
        //----------------------------------------------------------------------

        private void StartButton_Click(object sender, EventArgs e)
        {
            try {
                Classes.JournalEntryCollection JournalEntryCollection = new Classes.JournalEntryCollection();

                Table EntryRows = JournalEntryCollection.FetchRaw();
                int EntryCount = EntryRows.Count;

                int Counter = 0;
                ProgressBar.Minimum = 1;
                ProgressBar.Maximum = EntryCount;
                ProgressBar.Visible = true;

                Classes.JournalEntry PriorEntry = new Classes.JournalEntry();
                PriorEntry.StartTime = DateTime.MinValue;
                PriorEntry.StopTime = DateTime.MinValue;

                IssueCounter = 0;
                DatabaseCheckResultsGrid.Rows.Clear();

                foreach (Row EntryRow in EntryRows)
                {
                    Classes.JournalEntry CurrentEntry = new Classes.JournalEntry(EntryRow["JournalId"]);

                    // If JournalId is 0, we couldn't instantiate a JournalEntry
                    // based on the known-good JournalId value. This means a
                    // lookup failed (perhaps a failed join) and we'll make a last-
                    // ditched attempt to look up *only* the JournalEntry row,
                    // without any joins.

                    if (CurrentEntry.JournalId == 0) {
                        CurrentEntry.LoadLite(EntryRow["JournalId"]);
                    }

                    // Integrity checks
                    CheckExistence(CurrentEntry);

                    if (CurrentEntry.JournalId > 0) {
                        // Only do these if we actually have one
                        CheckTimestamps(CurrentEntry);
                        CheckForOverlaps(CurrentEntry, PriorEntry);
                        CheckDuration(CurrentEntry);
                        CheckDimensions(CurrentEntry);
                        CheckForLocks(CurrentEntry);
                    }

                    // Set Prior Entry
                    PriorEntry = CurrentEntry.Copy();

                    // Lastly, update progress
                    Counter++;
                    ProgressBar.Value = Counter;
                }

                ProgressBar.Visible = false;
                StatusBox.Text = IssueCounter == 0 ? "No issues found." :
                    IssueCounter == 1 ? "1 issue found." :
                    IssueCounter.ToString() + " issues found.";
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // Rule checks
        //----------------------------------------------------------------------

        private void CheckExistence(Classes.JournalEntry currentEntry)
        {
            if (currentEntry.JournalId == 0) {
                this.IssueCounter++;
                AddToGrid(currentEntry, "Journal entry is malformed.");
            }
        }

        //----------------------------------------------------------------------

        private void CheckTimestamps(Classes.JournalEntry currentEntry)
        {
            if (currentEntry.ModifyTime.CompareTo(currentEntry.CreateTime) < 0) {
                this.IssueCounter++;
                AddToGrid(currentEntry, "Entry modification time is before creation time.");
            }
        }

        //----------------------------------------------------------------------

        private void CheckForOverlaps(Classes.JournalEntry currentEntry, Classes.JournalEntry priorEntry)
        {
            if (currentEntry.StartTime.CompareTo(priorEntry.StopTime) < 0) {
                this.IssueCounter++;
                AddToGrid(currentEntry, "Start time is prior to previous row's stop time.");
            }
        }

        //----------------------------------------------------------------------

        private void CheckDuration(Classes.JournalEntry currentEntry)
        {
            TimeSpan Delta = currentEntry.StopTime.Subtract(currentEntry.StartTime);
            long ActualSeconds = (long)Math.Abs(Delta.TotalSeconds);
            // FIXME: out of curiosity, why is JournalEntry.Seconds a 64-bit integer?
            if (ActualSeconds != currentEntry.Seconds) {
                this.IssueCounter++;
                string Error = String.Format("Duration ({0}) is not equal to stop time minus start time ({1}).",
                    Timekeeper.FormatSeconds(currentEntry.Seconds),
                    Timekeeper.FormatSeconds(ActualSeconds));
                AddToGrid(currentEntry, Error);
            }
        }

        //----------------------------------------------------------------------

        private void CheckDimensions(Classes.JournalEntry currentEntry)
        {
            Classes.Project Project = new Classes.Project(currentEntry.ProjectId);
            if (!Project.Exists()) {
                this.IssueCounter++;
                AddToGrid(currentEntry, "Project does not exist.");
            }

            Classes.Activity Activity = new Classes.Activity(currentEntry.ActivityId);
            if (!Activity.Exists()) {
                this.IssueCounter++;
                AddToGrid(currentEntry, "Activity does not exist.");
            }

            Classes.Location Location = new Classes.Location(currentEntry.LocationId);
            if (!Location.Exists()) {
                this.IssueCounter++;
                AddToGrid(currentEntry, "Location does not exist.");
            }

            Classes.Category Category = new Classes.Category(currentEntry.CategoryId);
            if (!Category.Exists()) {
                this.IssueCounter++;
                AddToGrid(currentEntry, "Category does not exist.");
            }
        }

        //----------------------------------------------------------------------

        private void CheckForLocks(Classes.JournalEntry currentEntry)
        {
            if (currentEntry.IsLocked) {
                this.IssueCounter++;
                AddToGrid(currentEntry, "Entry is locked.");
            }
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private void AddToGrid(Classes.JournalEntry entry, string issueText)
        {
            DatabaseCheckResultsGrid.Rows.Add(
                entry.JournalId,
                issueText,
                entry.StartTime.ToString(Options.Advanced_DateTimeFormat),
                entry.StopTime.ToString(Options.Advanced_DateTimeFormat),
                entry.Memo
                );
        }

        //----------------------------------------------------------------------

    }
}
