using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class ActivityCollection : Classes.TreeAttributeCollection
    {
        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public ActivityCollection(DBI data, string orderByClause)
            : base(data, "Activity", orderByClause)
        {}

        public ActivityCollection(DBI data)
            : this (data, "CreateTime")
        {}

        //---------------------------------------------------------------------
        // Public Methods
        //---------------------------------------------------------------------

        public List<Classes.Activity> Fetch(long parentId, bool showHidden)
        {
            Table Rows = base.GetItems(parentId, showHidden);

            List<Classes.Activity> Activities = new List<Classes.Activity>();

            foreach (Row Row in Rows) {
                var Activity = new Classes.Activity(Data, Row["ActivityId"]);
                Activities.Add(Activity);
            }

            return Activities;
        }

        //---------------------------------------------------------------------

    }
}
