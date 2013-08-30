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

        private DBI Database;
        private Classes.Options Options;

        private Classes.FindOptions FindOptions;

        public delegate void BrowserCallback(long entryId);

        private BrowserCallback Browser_GotoEntry;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Find(Classes.FindOptions findOptions, BrowserCallback f)
        {
            InitializeComponent();
            this.FindOptions = findOptions;
            this.Browser_GotoEntry = f;
        }

        //---------------------------------------------------------------------
        // Events
        //---------------------------------------------------------------------

        private void Find_Load(object sender, EventArgs e)
        {
            // Globals
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;

            // Restore window metrics
            Height = Options.Find_Height;
            Width = Options.Find_Width;
            Top = Options.Find_Top;
            Left = Options.Find_Left;

            FindResultsGrid.Columns["JournalId"].Width = Options.Find_Grid_JournalIdWidth;

            // Load Last Saved Options
            FindOptions.Load(Options.State_LastFindOptionsId);
            RunFind();

            //////////////////////////////////////
            // And populate saved view dropdown //
            //////////////////////////////////////

            // clear any previous entries
            LoadOptionsButton.DropDownItems.Clear();

            // now grab new entries
            Table SavedViews = FindOptions.Fetch();

            if (SavedViews.Count > 0) {
                foreach (Row View in SavedViews) {
                    ToolStripItem Item = LoadOptionsButton.DropDownItems.Add(View["Name"]);
                    Item.Click += new System.EventHandler(this._load_view);
                    Item.ToolTipText = View["Description"];
                    Item.Tag = View["FindOptionsId"];
                }
                LoadOptionsButton.Enabled = true;
                ManageOptionsButton.Enabled = true;
            } else {
                LoadOptionsButton.Enabled = false;
                ManageOptionsButton.Enabled = false;
            }
        }

        //---------------------------------------------------------------------

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Forms.Filtering FilterDialog = new Forms.Filtering(FindOptions.FilterOptions);

            if (FilterDialog.ShowDialog(this) == DialogResult.OK) {
                FindOptions.FilterOptions = FilterDialog.FilterOptions;
                RunFind();
            }

            //FilterDialog.Dispose();
        }

        //---------------------------------------------------------------------

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunFind();
        }

        //---------------------------------------------------------------------

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //---------------------------------------------------------------------

        private void TimerHack_Tick(object sender, EventArgs e)
        {
            Common.Warn("TimerHack still going off");
        }

        //---------------------------------------------------------------------
        // Main Find Results Generator
        //---------------------------------------------------------------------

        // TODO: I need this.
        private void RunFind()
        {
            string Query = String.Format(@"
                select
                    j.JournalId, j.CreateTime, j.ModifyTime,
                    j.ProjectId, p.Name as ProjectName,
                    j.ActivityId, a.Name as ActivityName,
                    j.LocationId, l.Name as LocationName,
                    j.CategoryId, c.Name as CategoryName,
                    j.StartTime, j.StopTime, j.Seconds,
                    j.Memo, j.IsLocked, j.JournalIndex
                from Journal j
                join Activity a on a.ActivityId = j.ActivityId
                join Project p on p.ProjectId = j.ProjectId
                join Location l on l.LocationId = j.LocationId
                join Category c on c.CategoryId = j.CategoryId
                where {0}
                order by {1}",
                FindOptions.FilterOptions.WhereClause, "j.JournalId");

            Table FindResults = Database.Select(Query);

            FindResultsGrid.Rows.Clear();

            foreach (Row JournalEntry in FindResults) {

                /*
                DataGridViewRow Row = new DataGridViewRow();
                Row.Cells["ProjectId"].Value = JournalEntry["ProjectId"];
                Row.Cells["ProjectName"].Value = JournalEntry["ProjectName"];
                Row.Cells["Seconds"].Value = JournalEntry["Seconds"];
                Row.Cells["Memo"].Value = JournalEntry["Memo"];

            this.JournalId,
            this.ProjectId,
            this.ProjectName,
            this.ActivityId,
            this.ActivityName,
            this.StartTime,
            this.StopTime,
            this.Seconds,
            this.Memo,
            this.LocationId,
            this.LocationName,
            this.CategoryId,
            this.CategoryName,
            this.IsLocked});

                */

                FindResultsGrid.Rows.Add(
                    JournalEntry["JournalId"],
                    JournalEntry["JournalIndex"],
                    JournalEntry["ProjectId"],
                    JournalEntry["ProjectName"],
                    JournalEntry["ActivityId"],
                    JournalEntry["ActivityName"],
                    JournalEntry["StartTime"].ToString(Options.Advanced_DateTimeFormat),
                    JournalEntry["StopTime"].ToString(Options.Advanced_DateTimeFormat),
                    JournalEntry["Seconds"],
                    JournalEntry["Memo"],
                    JournalEntry["LocationId"],
                    JournalEntry["LocationName"],
                    JournalEntry["CategoryId"],
                    JournalEntry["CategoryName"],
                    JournalEntry["IsLocked"]
                    );

            }

            ResultCount.Text = FindResultsGrid.Rows.Count.ToString() + " entries found.";

            // Common.Info("You ran a filter!");
        }

        //---------------------------------------------------------------------
        // Private Helpers --- FIXME: uh, why isn't this an attribute of Filtering?
        //---------------------------------------------------------------------

        private string GetWhereClause()
        {
            Timekeeper.Warn("YOU SHOULDN'T BE USING THIS VERSION OF GETWHERECLAUSE");

            string WhereClause = "";

            WhereClause += String.Format("log.StartTime >= '{0}'",
                FindOptions.FilterOptions.FromDateToString()) + System.Environment.NewLine;

            WhereClause += String.Format("and log.StopTime <= '{0}'",
                FindOptions.FilterOptions.ToDateToString()) + System.Environment.NewLine;

            if ((FindOptions.FilterOptions.ImpliedActivities != null) && (FindOptions.FilterOptions.ImpliedActivities.Count > 0)) {
                WhereClause += String.Format("and log.ActivityId in ({0})",
                    FindOptions.FilterOptions.List(FindOptions.FilterOptions.ImpliedActivities)) + System.Environment.NewLine;
            }
            if ((FindOptions.FilterOptions.ImpliedProjects != null) && (FindOptions.FilterOptions.ImpliedProjects.Count > 0)) {
                WhereClause += String.Format("and log.ProjectId in ({0})",
                    FindOptions.FilterOptions.List(FindOptions.FilterOptions.ImpliedProjects)) + System.Environment.NewLine;
            }
            if ((FindOptions.FilterOptions.MemoContains != null) && (FindOptions.FilterOptions.MemoContains != "")) {
                WhereClause += String.Format("and log.Memo like '%{0}%'", FindOptions.FilterOptions.MemoContains) + System.Environment.NewLine;
            }

            if (FindOptions.FilterOptions.DurationOperator > 0) {
                // Meaning, if anything but "Any" was selected

                WhereClause += "and log.Seconds ";

                switch (FindOptions.FilterOptions.DurationOperator) {
                    case 1: WhereClause += " > "; break;
                    case 2: WhereClause += " < "; break;
                    case 3: WhereClause += " = "; break;
                }

                WhereClause += FindOptions.FilterOptions.Seconds().ToString() + System.Environment.NewLine;
            }

            if ((FindOptions.FilterOptions.Locations != null) && (FindOptions.FilterOptions.Locations.Count > 0)) {
                WhereClause += String.Format("and log.LocationId in ({0})",
                    FindOptions.FilterOptions.List(FindOptions.FilterOptions.Locations)) + System.Environment.NewLine;
            }

            if ((FindOptions.FilterOptions.Categories != null) && (FindOptions.FilterOptions.Categories.Count > 0)) {
                WhereClause += String.Format("and log.CategoryId in ({0})",
                    FindOptions.FilterOptions.List(FindOptions.FilterOptions.Categories)) + System.Environment.NewLine;
            }

            return WhereClause;
        }

        //---------------------------------------------------------------------

        /*

        private string GetOrderBy()
        {
            string OrderBy = GetOrderByInternal(FilterOptions.SortBy1);

            if (FilterOptions.SortBy2 > -1)
                OrderBy += ", " + GetOrderByInternal(FilterOptions.SortBy2);

            if (FilterOptions.SortBy3 > -1)
                OrderBy += ", " + GetOrderByInternal(FilterOptions.SortBy3);

            return OrderBy;
        }

        //---------------------------------------------------------------------

        private string GetOrderByInternal(int selection)
        {
            string OrderBy = "";

            if (selection <= 1) {
                // If option isn't checked, or it's (none) or it's Date/Time
                // Yes, even "(none)" gets you a sort order . . .
                OrderBy = "log.StartTime";
            } else {
                // Otherwise, set the value accordingly
                switch (selection) {
                    case 2: OrderBy = "a.Name"; break;
                    case 3: OrderBy = "p.Name"; break;
                    case 4: OrderBy = "log.Seconds"; break;
                    case 5: OrderBy = "l.Name"; break;
                    case 6: OrderBy = "t.Name"; break;
                    case 7: OrderBy = "p.ExternalProjectNo"; break;
                    case 8: OrderBy = "log.JournalId"; break;
                }
            }

            return OrderBy;
        }

        */

        private void FindResults_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            /* NOPE NOPE NOPE NOPE

            Classes.JournalEntry Entry = new Classes.JournalEntry(Database);

            DataGridViewRow Row = e.Row;

            Entry.ProjectId = 1;
            Entry.ActivityId = 1;
            Entry.StartTime = Row.Cells["StartTime"].Value.ToString();
            Entry.StopTime = StartTime;
            Entry.Seconds = 0; // default to zero
            Entry.Memo = wMemo.Text;
            Entry.IsLocked = true;
            Entry.LocationId = currentLocation == null ? 0 : currentLocation.Id; // FIXME: Location should be not null.
            Entry.CategoryId = currentCategory == null ? 0 : currentCategory.Id;
            if (!Entry.Create()) {
                Common.Warn("There was an error starting the timer.");
                return;
            }

             * */
        }

        private void FindResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) {
                DataGridViewRow Row = FindResultsGrid.Rows[e.RowIndex];
                long JournalIndex = Convert.ToInt64(Row.Cells["JournalIndex"].Value);
                this.Browser_GotoEntry(JournalIndex);
            }
        }

        private void Find_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save window metrics
            Options.Find_Height = Height;
            Options.Find_Width = Width;
            Options.Find_Top = Top;
            Options.Find_Left = Left;

            Options.Find_Grid_JournalIdWidth = FindResultsGrid.Columns["JournalId"].Width;
        }

        // EXPERIMENTAL AT THIS POINT

        private void lastFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FindOptions.Load(1);
            RunFind();
        }

        private void _load_view(object sender, EventArgs e)
        {
            long FindOptionsId = (long)((ToolStripItem)sender).Tag;
            FindOptions.Load(FindOptionsId);
            Options.State_LastFindOptionsId = FindOptionsId;
            RunFind();
        }

        private void testFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void SaveOptionsButton_Click(object sender, EventArgs e)
        {
            Forms.SaveView DialogBox = new Forms.SaveView();
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                FindOptions.Name = DialogBox.ViewName.Text;
                FindOptions.Description = DialogBox.ViewDescription.Text;
                FindOptions.Save();
            }
        }

        //---------------------------------------------------------------------

    }
}
