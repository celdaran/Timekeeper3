using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Projects : Items
    {
        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Projects(DBI data, string orderByClause)
            : base(data, "Project", orderByClause)
        {}

        public Projects(DBI data) 
            : this (data, "CreateDate")
        {}

        //---------------------------------------------------------------------
        // Public Methods
        //---------------------------------------------------------------------

        public List<Project> Fetch(long parentId, bool showHidden)
        {
            Table Rows = base.GetItems(parentId, showHidden);

            List<Project> Projects = new List<Project>();

            foreach (Row Row in Rows) {
                var Project = new Project(Data, Row["ProjectId"]);
                Projects.Add(Project);
            }

            return Projects;
        }

        //---------------------------------------------------------------------

    }
}
