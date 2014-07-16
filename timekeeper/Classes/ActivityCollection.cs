using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class ActivityCollection : Classes.TreeAttributeCollection
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ActivityCollection(string orderByClause)
            : base("Activity", orderByClause)
        {}

        public ActivityCollection()
            : this ("CreateTime")
        {}

        //----------------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------------

        new public List<Classes.Activity> Fetch(long parentId, bool showHidden, DateTimeOffset showHiddenSince)
        {
            Table Table = base.GetItems(parentId, showHidden, showHiddenSince);

            List<Classes.Activity> Activities = new List<Classes.Activity>();

            foreach (Row Row in Table) {
                var Activity = new Classes.Activity(Row["ActivityId"]);
                Activities.Add(Activity);
            }

            return Activities;
        }

        //---------------------------------------------------------------------

    }
}
