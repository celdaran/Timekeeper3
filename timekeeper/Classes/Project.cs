using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
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

        //---------------------------------------------------------------------

        public int Repoint(string externalProjectNo)
            // TODO: Revisit this method, especially this odd return value approach
        {
            Projects Projects = new Projects(Data);

            if (Projects.ExternalProjectNoExists(externalProjectNo)) {
                return 0;
            } else {
                Row Project = new Row();
                Project["ExternalProjectNo"] = externalProjectNo;
                Project["ModifyTime"] = Common.Now();
                long Count = Data.Update(this.TableName, Project, this.IdColumnName, this.ItemId);

                if (Count == 1) {
                    this.ExternalProjectNo = externalProjectNo;
                    return Timekeeper.SUCCESS;
                } else {
                    return Timekeeper.FAILURE;
                }
            }
        }

        //---------------------------------------------------------------------

    }
} 
