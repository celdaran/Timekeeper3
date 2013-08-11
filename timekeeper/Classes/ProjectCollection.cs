using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class ProjectCollection : Classes.TreeAttributeCollection
    {
        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public ProjectCollection(DBI data, string orderByClause)
            : base(data, "Project", orderByClause)
        {}

        public ProjectCollection(DBI data) 
            : this (data, "CreateTime")
        {}

        //---------------------------------------------------------------------
        // Public Methods
        //---------------------------------------------------------------------

        public List<Classes.Project> Fetch(long parentId, bool showHidden)
        {
            Table Rows = base.GetItems(parentId, showHidden);

            List<Classes.Project> Projects = new List<Classes.Project>();

            foreach (Row Row in Rows) {
                var Project = new Classes.Project(Data, Row["ProjectId"]);
                Projects.Add(Project);
            }

            return Projects;
        }

        //---------------------------------------------------------------------

        public bool ExternalProjectNoExists(string externalProjectNo)
        {
            if (externalProjectNo == "") {
                return false;
            }

            externalProjectNo = externalProjectNo.Replace("'", "''");

            string Query = String.Format("select count(*) as Count from Project where ExternalProjectNo = '{0}'",
                externalProjectNo);
            Row Project = Data.SelectRow(Query);

            if (Project["Count"] > 0) {
                return true;
            } else {
                return false;
            }

        }

        //---------------------------------------------------------------------

    }
}
