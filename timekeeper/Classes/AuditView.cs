using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    public class AuditView : BaseView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string ViewTableName = "AuditView";

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public AuditView() : base(ViewTableName)
        {
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public Table JournalResults()
        {
            string Query = String.Format(@"
                select
                    j.JournalId, j.CreateTime, j.ModifyTime,
                    j.ProjectId, p.Name as ProjectName,
                    j.ActivityId, a.Name as ActivityName,
                    j.LocationId, l.Name as LocationName,
                    j.CategoryId, c.Name as CategoryName,
                    j.StartTime, j.StopTime, j.Seconds,
                    j.Memo, j.IsReconciled, j.IsIgnored, j.IsLocked
                from Journal j
                join Project p on p.ProjectId = j.ProjectId
                join Activity a on a.ActivityId = j.ActivityId
                join Location l on l.LocationId = j.LocationId
                join Category c on c.CategoryId = j.CategoryId
                where {0}
                order by {1}",
                this.FilterOptions.WhereClause, "j.JournalId");

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

    }
}
