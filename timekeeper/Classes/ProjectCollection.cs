using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

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

        new public List<Classes.Project> Fetch(long parentId, bool showHidden, DateTime showHiddenSince)
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
