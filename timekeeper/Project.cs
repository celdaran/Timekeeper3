using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Project : Item
    {
        // constructor, no lookup
        public Project(DBI data)
        {
            this.data = data;
            this.table = "projects";
            this.id_column = "project_id";
        }

        // constructor, by id
        public Project(DBI data, int project_id)
        {
            this.data = data;
            this.table = "projects";
            this.id_column = "project_id";

            _load(project_id);
        }

        // constructor, by name
        public Project(DBI data, string projectName)
        {
            this.data = data;
            this.table = "projects";
            this.id_column = "project_id";

            // fetch row from db
            projectName = projectName.Replace("'", "''");

            string query = String.Format(@"
                select id from projects
                where name = '{0}'", projectName);

            Row row = data.SelectRow(query);
            int project_id = Convert.ToInt32(row["id"]);

            _load(project_id);
        }

    }
} 
