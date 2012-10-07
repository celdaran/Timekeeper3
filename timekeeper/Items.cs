using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Items
    {
        //---------------------------------------------------------------------
        // This is the base class for accessing groups of nodes. A node is the
        // base class for the application's two node classes: Task and Project.
        //---------------------------------------------------------------------

        // protected properties
        protected DBI data;
        protected string sOrderBy;

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------
        public long getSeconds()
        {
            // fetch seconds from the db for this task
            string today = DateTime.Today.ToString(Common.DATE_FORMAT);
            string midnight = "00:00:00";

            string query = String.Format(@"
                select sum(seconds) as seconds
                from timekeeper
                where timestamp_s > '{0} {1}'",
                today, midnight);
            Row row = this.data.SelectRow(query);
            return row["seconds"] == null ? 0 : row["seconds"];

            /*
            if (row["seconds"].Length > 0) {
                return Convert.ToInt32(row["seconds"]);
            } else {
                return 0;
            }
            */
        }
   
    }
}
