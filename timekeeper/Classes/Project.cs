using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Project : Classes.TreeAttribute
    {
        private static string ProjectTableName = "Project";
        private static string ProjectIdColumnName = "ProjectId";

        // constructor, no lookup
        public Project()
            : base(ProjectTableName, ProjectIdColumnName)
        {}

        // constructor, by id
        public Project(long projectId)
            : base(projectId, ProjectTableName, ProjectIdColumnName)
        {}

        // constructor, by name
        public Project(string projectName)
            : base(projectName, ProjectTableName, ProjectIdColumnName)
        {}

        //---------------------------------------------------------------------

        public int Repoint(string externalProjectNo)
            // TODO: Revisit this method, especially this odd return value approach
        {
            ProjectCollection Projects = new ProjectCollection();

            if (Projects.ExternalProjectNoExists(externalProjectNo)) {
                return 0;
            } else {
                Row Project = new Row();
                Project["ExternalProjectNo"] = externalProjectNo;
                Project["ModifyTime"] = Common.Now();
                long Count = Database.Update(this.TableName, Project, this.IdColumnName, this.ItemId);

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
