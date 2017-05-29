using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    public class TodoItem
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;

        public long TodoId { get; private set; }
        public DateTimeOffset CreateTime { get; private set; }
        public DateTimeOffset ModifyTime { get; private set; }
        public string Memo { get; set; }
        public long ProjectId { get; set; }
        public long RefTodoStatusId { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? HiddenTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }

        public string ProjectName { get; private set; }
        public string StatusName { get; private set; }
        public string StatusDescription { get; private set; }
        public string ProjectFolderName { get; private set; }

        // These attributes are persisted with the Project, but 
        // exposed as properties here for convenience. The methods
        // sort out the underlying table implementation.
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? DueTime { get; set; }
        public long? Estimate { get; set; }

        //----------------------------------------------------------------------

        public TodoItem()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------

        public TodoItem(long todoId) : this()
        {
            this.Load(todoId);
        }

        //----------------------------------------------------------------------

        public void Load(long todoId)
        {
            // TODO: add hidden/deleted columns

            string Query = String.Format(@"
                SELECT
                    t.TodoId, t.CreateTime, t.ModifyTime,
                    t.Memo,
                    p.ProjectId, p.Name as ProjectName,
                    p.StartTime, p.DueTime, 
                    p.Estimate,
                    r.RefTodoStatusId, r.Name as StatusName , r.Description as StatusDescription,
                    t.IsHidden, t.HiddenTime,
                    t.IsDeleted, t.DeletedTime
                FROM Todo t
                JOIN RefTodoStatus r on r.RefTodoStatusId = t.RefTodoStatusId
                JOIN Project p on p.ProjectId = t.ProjectId
                WHERE t.TodoId = {0}
                  AND t.IsDeleted = 0", todoId);
            Row TodoItem = Database.SelectRow(Query);

            if (TodoItem["TodoId"] != null)
            {
                this.TodoId = TodoItem["TodoId"];

                this.CreateTime = TodoItem["CreateTime"];
                this.ModifyTime = TodoItem["ModifyTime"];

                this.Memo = TodoItem["Memo"];
                this.ProjectId = TodoItem["ProjectId"];
                this.ProjectName = TodoItem["ProjectName"];
                this.RefTodoStatusId = TodoItem["RefTodoStatusId"];
                this.StatusName = TodoItem["StatusName"];
                this.StatusDescription = TodoItem["StatusDescription"];
                this.StartTime = TodoItem["StartTime"];
                this.DueTime = TodoItem["DueTime"];
                this.Estimate = TodoItem["Estimate"];

                this.IsHidden = TodoItem["IsHidden"];
                this.IsDeleted = TodoItem["IsDeleted"];
                this.HiddenTime = TodoItem["HiddenTime"];
                this.DeletedTime = TodoItem["DeletedTime"];

                Classes.Project Project = new Classes.Project(this.ProjectId);
                this.ProjectFolderName = Project.Parent.Name;
            }
        }

        //----------------------------------------------------------------------

        public bool Create()
        {
            try {
                // Update Todo table

                Row TodoItem = new Row();

                string Now = Timekeeper.DateForDatabase();

                TodoItem["CreateTime"] = Now;
                TodoItem["ModifyTime"] = Now;

                TodoItem["Memo"] = this.Memo;
                TodoItem["ProjectId"] = this.ProjectId;
                TodoItem["RefTodoStatusId"] = this.RefTodoStatusId;
                TodoItem["IsHidden"] = 0;
                TodoItem["IsDeleted"] = 0;

                this.TodoId = Database.Insert("Todo", TodoItem);

                if (this.TodoId == 0) {
                    throw new Exception("Could not create Todo item.");
                }

                // Update Project
                Classes.Project RelatedProject = new Classes.Project(this.ProjectId);
                RelatedProject.StartTime = this.StartTime;
                RelatedProject.DueTime = this.DueTime;
                RelatedProject.Estimate = this.Estimate;
                RelatedProject.SaveTask();

                // Backfill instance with system-generated values
                this.CreateTime = Timekeeper.StringToDate(TodoItem["CreateTime"]);
                this.ModifyTime = Timekeeper.StringToDate(TodoItem["ModifyTime"]);

                // And with foreign table information
                this.ProjectName = (new Classes.Project(this.ProjectId)).DisplayName();
                string Query = @"SELECT Name, Description FROM RefTodoStatus WHERE RefTodoStatusId = " + this.RefTodoStatusId;
                Row RefTodoStatus = Database.SelectRow(Query);
                this.StatusName = RefTodoStatus["Name"];
                this.StatusDescription = RefTodoStatus["Description"];
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            try {
                Row TodoItem = new Row();

                TodoItem["ModifyTime"] = Timekeeper.DateForDatabase();

                TodoItem["Memo"] = this.Memo;
                TodoItem["ProjectId"] = this.ProjectId;
                TodoItem["RefTodoStatusId"] = this.RefTodoStatusId;

                if (Database.Update("Todo", TodoItem, "TodoId", this.TodoId) != 1) {
                    throw new Exception("Could not save Todo item.");
                }

                // Update Project
                Classes.Project RelatedProject = new Classes.Project(this.ProjectId);
                RelatedProject.StartTime = this.StartTime;
                RelatedProject.DueTime = this.DueTime;
                RelatedProject.Estimate = this.Estimate;
                RelatedProject.SaveTask();

                // Backfill instance with system-generated values
                this.ModifyTime = Timekeeper.StringToDate(TodoItem["ModifyTime"]);

                // And with foreign table information
                this.ProjectName = (new Classes.Project(this.ProjectId)).DisplayName();
                string Query = @"SELECT Name, Description FROM RefTodoStatus WHERE RefTodoStatusId = " + this.RefTodoStatusId;
                Row RefTodoStatus = Database.SelectRow(Query);
                this.StatusName = RefTodoStatus["Name"];
                this.StatusDescription = RefTodoStatus["Description"];
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //----------------------------------------------------------------------

        public void Delete()
        {
            DateTimeOffset Now = Timekeeper.LocalNow;
            Update("IsDeleted", 1);
            Update("DeletedTime", Now);
            this.IsDeleted = true;
            this.DeletedTime = Now;
        }

        //----------------------------------------------------------------------

        public void Hide()
        {
            DateTimeOffset Now = Timekeeper.LocalNow;
            Update("IsHidden", 1);
            Update("HiddenTime", Now);
            this.IsHidden = true;
            this.HiddenTime = Now;
        }

        //----------------------------------------------------------------------

        public void Unhide()
        {
            Update("IsHidden", 0);
            Update("HiddenTime", null);
            this.IsHidden = false;
            this.HiddenTime = null;
        }

        //----------------------------------------------------------------------

        public void MarkComplete()
        {
            // TODO: Come up with a constant
            // AND/OR DEPRECATE THIS METHOD
            UpdateStatus(5);
        }

        //----------------------------------------------------------------------

        public void UpdateStatus(long refTodoStatusId)
        {
            Update("RefTodoStatusId", refTodoStatusId);
            this.RefTodoStatusId = refTodoStatusId;

            // TODO: clean this up, please.
            string Query = @"SELECT Name, Description FROM RefTodoStatus WHERE RefTodoStatusId = " + this.RefTodoStatusId;
            Row RefTodoStatus = Database.SelectRow(Query);
            this.StatusName = RefTodoStatus["Name"];
            this.StatusDescription = RefTodoStatus["Description"];
        }

        //----------------------------------------------------------------------
        // Private Helpers
        //----------------------------------------------------------------------

        private bool Update(string columnName, object columnValue)
        {
            try {
                Row TodoItem = new Row();

                TodoItem["ModifyTime"] = Timekeeper.DateForDatabase();

                TodoItem[columnName] = columnValue;

                if (Database.Update("Todo", TodoItem, "TodoId", this.TodoId) != 1) {
                    throw new Exception("Could not update Todo column " + columnName);
                }

                this.ModifyTime = Timekeeper.StringToDate(TodoItem["ModifyTime"]);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //----------------------------------------------------------------------

    }
}
