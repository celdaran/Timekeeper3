using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Project : Item
    {
        private static string ProjectTableName = "Project";
        private static string ProjectIdColumnName = "ProjectId";

        // constructor, no lookup
        public Project(DBI data)
            : base(data, ProjectTableName, ProjectIdColumnName)
        {}

        // constructor, by id
        public Project(DBI data, long projectId)
            : base(data, projectId, ProjectTableName, ProjectIdColumnName)
        {}

        // constructor, by name
        public Project(DBI data, string projectName)
            : base(data, projectName, ProjectTableName, ProjectIdColumnName)
        {}

    }
} 
