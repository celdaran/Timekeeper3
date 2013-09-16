using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class FindView : BaseView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string ViewTableName = "FindView";

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public FindView() : base(ViewTableName)
        {
        }

        //---------------------------------------------------------------------

        public FindView(long findViewId) : base(ViewTableName, findViewId)
        {
        }

        //---------------------------------------------------------------------

        public FindView(string findViewName) : base(ViewTableName, findViewName)
        {
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public void Load(long findViewId)
        {
            try {
                Row View = base.LoadRow(findViewId);

                if (View["FindViewId"] != null) {
                    // Extra handling
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            bool Saved = false;

            try {
                Saved = base.SaveRow();

                if (Saved) {
                    // Extra handling
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Saved;
        }

        //---------------------------------------------------------------------

        public Table Results()
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
                this.FilterOptions.WhereClause, "j.JournalId");

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

    }
}
