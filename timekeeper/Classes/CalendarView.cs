using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    class CalendarView : BaseView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string ViewTableName = "CalendarView";

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public CalendarView() : base(ViewTableName)
        {
            this.FilterOptions.FilterOptionsType = Classes.FilterOptions.OptionsType.Calendar;
        }

        //---------------------------------------------------------------------

        public CalendarView(long calendarViewId)
            : base(ViewTableName, calendarViewId)
        {
            this.FilterOptions.FilterOptionsType = Classes.FilterOptions.OptionsType.Calendar;
        }

        //---------------------------------------------------------------------

        public CalendarView(string calendarViewName)
            : base(ViewTableName, calendarViewName)
        {
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public bool Save(bool filterOptionsChanged)
        {
            return Save(filterOptionsChanged, 0);
        }

        //---------------------------------------------------------------------

        public Table FilterResults()
        {
            string Query = String.Format(@"
                select
                    j.JournalId, j.CreateTime, j.ModifyTime,
                    j.ProjectId, p.Name as ProjectName,
                    j.ActivityId, a.Name as ActivityName,
                    j.LocationId, l.Name as LocationName,
                    j.CategoryId, c.Name as CategoryName,
                    j.StartTime, j.StopTime, j.Seconds,
                    j.Memo, j.IsLocked
                from Journal j
                join Activity a on a.ActivityId = j.ActivityId
                join Project p on p.ProjectId = j.ProjectId
                join Location l on l.LocationId = j.LocationId
                join Category c on c.CategoryId = j.CategoryId
                where {0}
                order by {1}",
                this.FilterOptions.WhereClause, "j.JournalId");

            Table FindResults = Timekeeper.Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

    }
}
