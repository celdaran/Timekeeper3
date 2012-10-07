using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Task : Item
    {
        // constructor, no lookup
        public Task(DBI data)
        {
            this.data = data;
            this.table = "tasks";
            this.id_column = "task_id";
        }

        // constructor, by id
        public Task(DBI data, long task_id)
        {
            this.data = data;
            this.table = "tasks";
            this.id_column = "task_id";

            _load(task_id);
        }

        // constructor, by name
        public Task(DBI data, string taskName)
        {
            this.data = data;
            this.table = "tasks";
            this.id_column = "task_id";

            // fetch row from db
            taskName = taskName.Replace("'", "''");

            string query = String.Format(@"
                select id from tasks
                where name = '{0}'", taskName);

            Row row = data.SelectRow(query);
            long task_id = row["id"];

            _load(task_id);
        }
    }
} 
