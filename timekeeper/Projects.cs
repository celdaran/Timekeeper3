using System;
using System.Collections.Generic;
using System.Text;

namespace Timekeeper
{
    class Projects : Items
    {
        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------
        public Projects(DBI data, string sOrderBy)
        {
            this.data = data;
            this.sOrderBy = sOrderBy;
        }

        //---------------------------------------------------------------------
        // Get 
        //---------------------------------------------------------------------
        public List<Project> get(int parent_id, bool bShowHidden)
        {
            if (sOrderBy == "") {
                sOrderBy = "timestamp_c";
            }

            string sShowHidden = "";
            if (!bShowHidden) {
                sShowHidden = "and is_hidden = 0";
            } 
            
            string query = String.Format(@"
                select id from projects
                where is_deleted = 0
                  {0}
                  and parent_id = {1}
                order by {2}", sShowHidden, parent_id, sOrderBy);

            RowSet rows = data.select(query);

            List<Project> projects = new List<Project>();

            foreach (Row row in rows) {
                int project_id = Convert.ToInt32(row["id"]);
                Project project = new Project(data, project_id);
                projects.Add(project);
            }

            return projects;
        }

        public int count()
        {
            // FIXME: move to parent class, set table and call 'super'
            string query = "select count(*) as count from projects";
            Row row = data.selectRow(query);
            if (row["count"] == "") {
                return 0;
            } else {
                return Convert.ToInt32(row["count"]);
            }
        }

    }
}
