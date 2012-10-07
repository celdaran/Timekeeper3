using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Tasks : Items
    {
        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public Tasks(DBI data, string sOrderBy)
        {
            this.data = data;
            this.sOrderBy = sOrderBy;
        }

        //---------------------------------------------------------------------
        // Get 
        //---------------------------------------------------------------------
        public List<Task> get(int parent_id, bool bShowHidden)
        {
            if (sOrderBy == "") {
                sOrderBy = "timestamp_c";
            }

            string sShowHidden = "";
            if (!bShowHidden) {
                sShowHidden = "and is_hidden = 0";
            }

            string query = String.Format(@"
                select id from tasks
                where is_deleted = 0
                  {0}
                  and parent_id = {1}
                order by {2}",
                sShowHidden, parent_id, sOrderBy);

            Table rows = data.Select(query);

            List<Task> tasks = new List<Task>();

            foreach (Row row in rows) {
                int task_id = Convert.ToInt32(row["id"]);
                Task task = new Task(data, task_id);
                tasks.Add(task);
            }

            return tasks;
        }

        public int count()
        {
            string query = "select count(*) as count from tasks";
            Row row = data.SelectRow(query);
            if (row["count"] == "") {
                return 0;
            } else {
                return Convert.ToInt32(row["count"]);
            }
        }


    }
}
