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

using Timekeeper.Classes.Toolbox;
using Timekeeper.Classes;

namespace Timekeeper.Forms
{
    public partial class Audit : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private Classes.Widgets Widgets;

        private Classes.AuditView AuditView;

        public delegate void BrowserCallback(long entryId);

        private BrowserCallback Browser_GotoEntry;

        private string sortOrder = "j.StartTime ASC";

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Audit(BrowserCallback f)
        {
            InitializeComponent();

            this.AuditView = new Classes.AuditView();
            this.Widgets = new Classes.Widgets();

            this.Browser_GotoEntry = f;

            this.AuditDate.Text = AuditView.GetDateAfterMostRecentlyReconciledEntry();
            RunFind(AuditDate.Text, this.sortOrder);

            JournalResultsGrid.Dock = DockStyle.Fill;
        }

        //---------------------------------------------------------------------
        // Events
        //---------------------------------------------------------------------

        private void Find_Load(object sender, EventArgs e)
        {
            try {
                // Restore window metrics
                // Note: setting window metrics for Audit is currently not implemented.
                // Refer to Find.cs in the future as a reference for how to implement this.
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void Find_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save window metrics
            // Note: saving window metrics for Audit is currently not implemented.
        }

        //----------------------------------------------------------------------
        // Toolbar Commands
        //----------------------------------------------------------------------

        private void GoToPrevDayButton_Click(object sender, EventArgs e)
        {
            string prevDay = AuditView.GetPrevDateFromJournal(AuditDate.Text);
            AuditDate.Text = prevDay;
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void AuditDate_Leave(object sender, EventArgs e)
        {
            if (AuditView.IsDateValid(AuditDate.Text)) {
                RunFind(AuditDate.Text, this.sortOrder);
            } else
            {
                Common.Warn("Invalid date format. Please enter a valid date in the format: YYYY-MM-DD");
            }
        }

        private void GoToNextDayButton_Click(object sender, EventArgs e)
        {
            string nextDay = AuditView.GetNextDateFromJournal(AuditDate.Text);
            AuditDate.Text = nextDay;
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void ReconcileAllButton_Click(object sender, EventArgs e)
        {
            if (!AuditView.IsDateValid(AuditDate.Text))
            {
                Common.Warn("Invalid date format. Please enter a valid date in the format: YYYY-MM-DD");
                return;
            }

            if (Common.Prompt("This will mark all entries for date " + AuditDate.Text + " as reconciled. Continue?") == DialogResult.Yes)
            {
                var rowsUpdated = AuditView.ReconcileAll(AuditDate.Text);
                Common.Info("Updated " + rowsUpdated + " entries.");
                RunFind(AuditDate.Text, this.sortOrder);
            }
            else
            {
                Common.Info("No action taken");
            }
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void SortByStartTimeButton_Click(object sender, EventArgs e)
        {
            this.sortOrder = "j.StartTime ASC";
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void SortByProjectButton_Click(object sender, EventArgs e)
        {
            this.sortOrder = "p.Name ASC, a.Name ASC, j.StartTime ASC";
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void SortByActivityButton_Click(object sender, EventArgs e)
        {
            this.sortOrder = "a.Name ASC, p.Name ASC, j.StartTime ASC";
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void SortByLocationButton_Click(object sender, EventArgs e)
        {
            this.sortOrder = "l.Name ASC, j.StartTime ASC";
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void SortByCategoryButton_Click(object sender, EventArgs e)
        {
            this.sortOrder = "c.Name ASC, p.Name ASC, a.Name ASC, j.StartTime ASC";
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void SortByDurationButton_Click(object sender, EventArgs e)
        {
            this.sortOrder = "Duration ASC";
            RunFind(AuditDate.Text, this.sortOrder);
        }

        private void SortByModifiedTimeButton_Click(object sender, EventArgs e)
        {
            this.sortOrder = "j.ModifyTime ASC, p.Name ASC, a.Name ASC";
            RunFind(AuditDate.Text, this.sortOrder);
        }

        //----------------------------------------------------------------------
        // Other events
        //----------------------------------------------------------------------

        // TODO: These are copy/pasted from Find

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

        private void JournalResultsGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // This forces the checkbox change to 'commit' to the underlying 
            // cell value immediately, which in turn triggers CellValueChanged.
            if (JournalResultsGrid.CurrentCell is DataGridViewCheckBoxCell)
            {
                if (JournalResultsGrid.IsCurrentCellDirty)
                {
                    JournalResultsGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
                }
            }
        }

        //----------------------------------------------------------------------

        private void JournalResultsGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && _isPopulating == false)
            {
                if (JournalResultsGrid.Columns[e.ColumnIndex].Name == "IsReconciled")
                {
                    DataGridViewRow Row = JournalResultsGrid.Rows[e.RowIndex];
                    bool isChecked = Convert.ToBoolean(Row.Cells["IsReconciled"].Value);
                    long JournalId = Convert.ToInt64(Row.Cells["JournalId"].Value);
                    var JournalEntry = new JournalEntry();
                    JournalEntry.Load(JournalId);
                    if (isChecked)
                    {
                        JournalEntry.Reconcile();
                    }
                    else
                    {
                        JournalEntry.Unreconcile();
                    }
                }
            }
        }

        //----------------------------------------------------------------------
        // Internal Helpers
        //----------------------------------------------------------------------

        private void RunFind(string auditDate, string whereClause)
        {
            int Count = 0;

            Count = RunJournalFind(auditDate, whereClause);

            string StatusBarText = String.Format("{0} found.",
                Timekeeper.Pluralize(Count, "entry", "entries"));

            ResultCount.Text = StatusBarText;
        }

        //---------------------------------------------------------------------

        private bool _isPopulating;

        private int RunJournalFind(string auditDate, string whereClause)
        {
            //----------------------------------------------
            // Populate Table
            //----------------------------------------------

            Table FindResults = AuditView.JournalResults(auditDate, whereClause);

            JournalResultsGrid.Rows.Clear();

            _isPopulating = true;

            foreach (Row JournalEntry in FindResults) {

                JournalResultsGrid.Rows.Add(
                    JournalEntry["JournalId"],
                    JournalEntry["IsReconciled"],
                    Timekeeper.DateForDisplay(JournalEntry["ReconcileTime"]),
                    JournalEntry["ShortStartTime"],
                    JournalEntry["ShortStopTime"],
                    JournalEntry["Duration"],
                    JournalEntry["Gap"],
                    JournalEntry["RunningTotal"],
                    JournalEntry["ProjectId"],
                    JournalEntry["ProjectName"],
                    JournalEntry["ActivityId"],
                    JournalEntry["ActivityName"],
                    JournalEntry["LocationId"],
                    JournalEntry["LocationName"],
                    JournalEntry["CategoryId"],
                    JournalEntry["CategoryName"],
                    JournalEntry["MemoExcerpt"],
                    Timekeeper.DateForDisplay(JournalEntry["CreateTime"]),
                    Timekeeper.DateForDisplay(JournalEntry["ModifyTime"])
                    );
            }

            _isPopulating = false;

            return FindResults.Count;
        }


        //---------------------------------------------------------------------

    }
}
