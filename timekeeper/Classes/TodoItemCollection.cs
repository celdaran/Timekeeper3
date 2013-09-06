using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class TodoItemCollection
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public TodoItemCollection()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------
        // Fetch
        //----------------------------------------------------------------------

        public bool Exists(long projectId)
        {
            string Query = String.Format(@"SELECT COUNT(*) AS Count FROM Todo WHERE ProjectId = {0} AND IsDeleted = 0", projectId);
            Row TodoRow = this.Database.SelectRow(Query);
            return (TodoRow["Count"] > 0);
        }

        //----------------------------------------------------------------------

        public List<Classes.TodoItem> Fetch(bool hideCompleted)
        {
            List<Classes.TodoItem> ReturnList = new List<TodoItem>();

            string Qualifier = hideCompleted ? " AND RefTodoStatusId <> 5" : "";
            string Query = String.Format(@"SELECT TodoId FROM Todo WHERE IsDeleted = 0 {0} ORDER BY TodoId", Qualifier);
            Table TodoRows = this.Database.Select(Query);

            foreach (Row TodoRow in TodoRows) {
                Classes.TodoItem TodoItem = new Classes.TodoItem(TodoRow["TodoId"]);
                ReturnList.Add(TodoItem);
            }

            return ReturnList;
        }

        //----------------------------------------------------------------------

    }
}
