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

        private Classes.Options Options;
        private Classes.Widgets Widgets;

        private Classes.AuditView AuditView;

        public delegate void BrowserCallback(long entryId);

        private BrowserCallback Browser_GotoEntry;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Audit(BrowserCallback f)
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;
            this.AuditView = new Classes.AuditView();
            this.Widgets = new Classes.Widgets();

            this.Browser_GotoEntry = f;

            JournalResultsGrid.Visible = true;
            JournalResultsGrid.Dock = DockStyle.Fill;
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
                JournalResultsGrid.Columns["JournalId"].Width = Options.Find_JournalGrid_JournalIdWidth;
                JournalResultsGrid.Columns["ProjectName"].Width = Options.Find_JournalGrid_ProjectNameWidth;
                JournalResultsGrid.Columns["ActivityName"].Width = Options.Find_JournalGrid_ActivityNameWidth;
                JournalResultsGrid.Columns["StartTime"].Width = Options.Find_JournalGrid_StartTimeWidth;
                JournalResultsGrid.Columns["StopTime"].Width = Options.Find_JournalGrid_StopTimeWidth;
                JournalResultsGrid.Columns["Seconds"].Width = Options.Find_JournalGrid_SecondsWidth;
                JournalResultsGrid.Columns["Memo"].Width = Options.Find_JournalGrid_MemoWidth;
                JournalResultsGrid.Columns["LocationName"].Width = Options.Find_JournalGrid_LocationNameWidth;
                JournalResultsGrid.Columns["CategoryName"].Width = Options.Find_JournalGrid_CategoryNameWidth;
                JournalResultsGrid.Columns["IsLocked"].Width = Options.Find_JournalGrid_IsLockedWidth;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
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
            Options.Find_JournalGrid_JournalIdWidth = JournalResultsGrid.Columns["JournalId"].Width;
            Options.Find_JournalGrid_ProjectNameWidth = JournalResultsGrid.Columns["ProjectName"].Width;
            Options.Find_JournalGrid_ActivityNameWidth = JournalResultsGrid.Columns["ActivityName"].Width;
            Options.Find_JournalGrid_StartTimeWidth = JournalResultsGrid.Columns["StartTime"].Width;
            Options.Find_JournalGrid_StopTimeWidth = JournalResultsGrid.Columns["StopTime"].Width;
            Options.Find_JournalGrid_SecondsWidth = JournalResultsGrid.Columns["Seconds"].Width;
            Options.Find_JournalGrid_MemoWidth = JournalResultsGrid.Columns["Memo"].Width;
            Options.Find_JournalGrid_LocationNameWidth = JournalResultsGrid.Columns["LocationName"].Width;
            Options.Find_JournalGrid_CategoryNameWidth = JournalResultsGrid.Columns["CategoryName"].Width;
            Options.Find_JournalGrid_IsLockedWidth = JournalResultsGrid.Columns["IsLocked"].Width;
        }

        //----------------------------------------------------------------------
        // Toolbar Commands
        //----------------------------------------------------------------------

        private void AuditDate_Leave(object sender, EventArgs e)
        {
            RunFind();
        }


        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunFind();
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

        private void RunFind()
        {
            int Count = 0;

            Count = RunJournalFind();

            string StatusBarText = String.Format("{0} found.",
                Timekeeper.Pluralize(Count, "entry", "entries"));

            ResultCount.Text = StatusBarText;
        }

        //---------------------------------------------------------------------

        private bool _isPopulating;

        private int RunJournalFind()
        {
            //----------------------------------------------
            // Populate Table
            //----------------------------------------------

            Table FindResults = AuditView.JournalResults();

            JournalResultsGrid.Rows.Clear();

            _isPopulating = true;

            foreach (Row JournalEntry in FindResults) {

                JournalResultsGrid.Rows.Add(
                    Timekeeper.DateForDisplay(JournalEntry["StartTime"]),
                    Timekeeper.DateForDisplay(JournalEntry["StopTime"]),
                    Timekeeper.FormatSeconds(JournalEntry["Seconds"]),
                    JournalEntry["ProjectId"],
                    JournalEntry["ProjectName"],
                    JournalEntry["ActivityId"],
                    JournalEntry["ActivityName"],
                    JournalEntry["LocationId"],
                    JournalEntry["LocationName"],
                    JournalEntry["CategoryId"],
                    JournalEntry["CategoryName"],
                    JournalEntry["Memo"],
                    JournalEntry["IsReconciled"],
                    JournalEntry["IsIgnored"],
                    JournalEntry["IsLocked"],
                    JournalEntry["JournalId"]
                    );
            }

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

            _isPopulating = false;

            return FindResults.Count;
        }

        //---------------------------------------------------------------------

    }
}
