using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Activity : Classes.TreeAttribute
    {
        private static string ActivityTableName = "Activity";
        private static string ActivityIdColumnName = "ActivityId";

        // constructor, no lookup
        public Activity(DBI data)
            : base(data, ActivityTableName, ActivityIdColumnName)
        {}

        // constructor, by id
        public Activity(DBI data, long activityId)
            : base(data, activityId, ActivityTableName, ActivityIdColumnName)
        {}

        // constructor, by name
        public Activity(DBI data, string activityName)
            : base(data, activityName, ActivityTableName, ActivityIdColumnName)
        {}

    }
} 
