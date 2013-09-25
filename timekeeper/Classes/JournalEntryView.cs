using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class JournalEntryView : BaseView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        // FIXME: Rename this table. This isn't the only "report"
        private static string ViewTableName = "ReportView";

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        // None for now.

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public JournalEntryView()
            : base(ViewTableName)
        {
        }

        //---------------------------------------------------------------------

        public JournalEntryView(long journalEntryViewId)
            : base(ViewTableName, journalEntryViewId)
        {
        }

        //---------------------------------------------------------------------

        public JournalEntryView(string journalEntryViewName)
            : base(ViewTableName, journalEntryViewName)
        {
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public void Load(long journalEntryViewId)
        {
            try {
                Row View = base.LoadRow(journalEntryViewId);

                if (View["JournalEntryViewId"] != null) {
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public bool Save(bool filterOptionsChanged)
        {
            return Save(filterOptionsChanged, 0);
        }

        //----------------------------------------------------------------------

        public bool Save(bool filterOptionsChanged, long filterOptionsId)
        {
            bool Saved = false;

            try {
                Saved = base.SaveRow(filterOptionsChanged, filterOptionsId);

                if (Saved) {
                    // Extra handling
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Saved;
        }

        //----------------------------------------------------------------------

        public Table Results(string orderBy)
        {
            string Query = String.Format(@"
                select
                    j.StartTime, j.StopTime, j.Seconds, 
                    p.Name as ProjectName, a.Name as ActivityName,
                    j.Memo
                from Journal j
                join Activity a on a.ActivityId = j.ActivityId
                join Project p on p.ProjectId = j.ProjectId
                left join Location l on l.LocationId = j.LocationId
                left join Category t on t.CategoryId = j.CategoryId
                where {0}
                order by {1}",
                this.FilterOptions.WhereClause, orderBy);

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

    }
}
