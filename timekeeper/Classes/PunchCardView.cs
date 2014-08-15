using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class PunchCardView : BaseView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string ViewTableName = "PunchCardView";

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public PunchCardView()
            : base(ViewTableName)
        {
            this.FilterOptions.FilterOptionsType = Classes.FilterOptions.OptionsType.PunchCard;
        }

        //---------------------------------------------------------------------

        public PunchCardView(long calendarViewId)
            : base(ViewTableName, calendarViewId)
        {
            this.FilterOptions.FilterOptionsType = Classes.FilterOptions.OptionsType.PunchCard;
        }

        //---------------------------------------------------------------------

        public PunchCardView(string calendarViewName)
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
                SELECT
                    strftime('%Y/%m/%d', j.StartTime) as Day,
                    min(j.StartTime) as PunchIn, max(j.StopTime) as PunchOut
                FROM Journal j
                WHERE {0}
                GROUP BY Day
                ORDER BY Day",
                this.FilterOptions.WhereClause);

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

    }
}
