using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

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

        public bool Save(bool filterOptionsChanged)
        {
            return Save(filterOptionsChanged, 0);
        }

        //----------------------------------------------------------------------

        public Table Results(string orderBy)
        {
            string Offset = "";
            if (this.Options.Advanced_Other_MidnightOffset != 0) {
                Offset = String.Format(", '-{0} hours'", this.Options.Advanced_Other_MidnightOffset);
            }

            string Query = String.Format(@"
                select
                    datetime(j.StartTime{2}) as StartTime,
                    datetime(j.StopTime{2}) as StopTime,
                    j.Seconds, 
                    p.Name as ProjectName, a.Name as ActivityName,
                    l.Name as LocationName, t.Name as CategoryName,
                    j.Memo
                from Journal j
                join Activity a on a.ActivityId = j.ActivityId
                join Project p on p.ProjectId = j.ProjectId
                left join Location l on l.LocationId = j.LocationId
                left join Category t on t.CategoryId = j.CategoryId
                where {0}
                order by {1}",
                this.FilterOptions.WhereClause, orderBy, Offset);

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

    }
}
