using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper
{
    class Log
    {
        private DBI data;
        private int log_id;

        public Log(DBI data)
        {
            this.data = data;
        }

        public void start(string entry, int task_id, int project_id)
        {
            Row row = new Row();

            row["task_id"] = task_id.ToString();
            row["project_id"] = project_id.ToString();
            row["timestamp_s"] = Common.Now();
            row["seconds"] = "0";
            row["pre_log"] = entry;
            row["is_locked"] = "1";

            log_id = data.insert("timekeeper", row);

            // record last project id

            row = new Row();
            row["project_id__last"] = project_id.ToString();
            data.update("tasks", row, "id", task_id.ToString());
        }

        public void end(string entry, string pre_entry, int seconds)
        {
            Row row = new Row();

            row["timestamp_e"] = Common.Now();
            row["seconds"] = seconds.ToString();
            row["pre_log"] = pre_entry;
            row["post_log"] = entry;
            row["is_locked"] = "0";

            data.update("timekeeper", row, "id", log_id.ToString());
        }

        public int count()
        {
            string query = "select count(*) as count from timekeeper";
            Row row = data.selectRow(query);
            if (row["count"] == "") {
                return 0;
            } else {
                return Convert.ToInt32(row["count"]);
            }
        }

        public int seconds()
        {
            string query = "select sum(seconds) as seconds from timekeeper";
            Row row = data.selectRow(query);
            if (row["seconds"] == "") {
                return 0;
            } else {
                return Convert.ToInt32(row["seconds"]);
            }
        }

    }
}
