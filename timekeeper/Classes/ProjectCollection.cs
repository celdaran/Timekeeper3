using System;
using System.Collections.Generic;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    class ProjectCollection : Classes.TreeAttributeCollection
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ProjectCollection(string orderByClause)
            : base("Project", orderByClause)
        {}

        public ProjectCollection() 
            : this ("CreateTime")
        {}

        //----------------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------------

        new public List<Classes.Project> Fetch(long? parentId, bool showHidden, DateTimeOffset showHiddenSince)
        {
            Table Table = base.GetItems(parentId, showHidden, showHiddenSince);

            List<Classes.Project> Projects = new List<Classes.Project>();

            foreach (Row Row in Table) {
                var Project = new Classes.Project(Row["ProjectId"]);
                Projects.Add(Project);
            }

            return Projects;
        }

        //----------------------------------------------------------------------

        public List<Classes.Project> FetchAll()
        {
            string Query = String.Format(@"SELECT ProjectId FROM Project WHERE IsFolder = 0 AND IsHidden = 0 AND IsDeleted = 0");
            Table Table = this.Database.Select(Query);

            List<Classes.Project> Projects = new List<Classes.Project>();

            foreach (Row Row in Table) {
                var Project = new Classes.Project(Row["ProjectId"]);
                Projects.Add(Project);
            }

            return Projects;
        }

        //----------------------------------------------------------------------

        public bool ExternalProjectNoExists(string externalProjectNo)
        {
            if (externalProjectNo == "") {
                return false;
            }

            externalProjectNo = externalProjectNo.Replace("'", "''");

            string Query = String.Format("select count(*) as Count from Project where ExternalProjectNo = '{0}'",
                externalProjectNo);
            Row Project = Database.SelectRow(Query);

            if (Project["Count"] > 0) {
                return true;
            } else {
                return false;
            }

        }

        //----------------------------------------------------------------------

    }
}
