using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper.Classes
{
    class Activity : Classes.TreeAttribute
    {
        private static string ActivityTableName = "Activity";
        private static string ActivityIdColumnName = "ActivityId";

        // constructor, no lookup
        public Activity()
            : base(ActivityTableName, ActivityIdColumnName)
        {}

        // constructor, by id
        public Activity(long activityId)
            : base(activityId, ActivityTableName, ActivityIdColumnName)
        {}

        // constructor, by nullable id
        public Activity(long? activityId)
            : base(activityId, ActivityTableName, ActivityIdColumnName)
        { }

        // constructor, by name
        public Activity(string activityName)
            : base(activityName, ActivityTableName, ActivityIdColumnName)
        {}

    }
} 
