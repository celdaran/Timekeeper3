using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    // TODO: Rename file from Notebook.cs to NotebookEntry.cs

    class NotebookEntry
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Database;

        //---------------------------------------------------------------------

        public long NotebookId = 0;
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }
        public string NotebookGuid { get; set; }

        public DateTime EntryTime { get; set; }
        public string Memo { get; set; }
        public int LocationId { get; set; }
        public int CategoryId { get; set; }

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public NotebookEntry()
        {
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        public int Count()
        {
            string Query = "SELECT COUNT(*) AS Count FROM Notebook";
            Row Row = Database.SelectRow(Query);
            return (int)Row["Count"];
        }

        //---------------------------------------------------------------------

        public void Load()
        {
            try {
                Row Row = new Row();
                Row = this.Database.SelectRow("SELECT MAX(NotebookId) AS MaxNotebookId FROM Notebook");
                if (Row["MaxNotebookId"] != null) {
                    int MaxNotebookId = Convert.ToInt32(Row["MaxNotebookId"]);
                    this.Load(MaxNotebookId);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public void Load(int notebookId)
        {
            NotebookId = notebookId;

            try {
                Row Row = new Row();
                Row = this.Database.SelectRow("select * from Notebook where NotebookId = " + notebookId);

                this.CreateTime = Row["CreateTime"];
                this.ModifyTime = Row["ModifyTime"];
                this.NotebookGuid = Row["NotebookGuid"];

                this.EntryTime = Row["EntryTime"];
                this.Memo = Row["Memo"];
                this.LocationId = Row["LocationId"];
                this.CategoryId = Row["CategoryId"];
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------
        // Persistence
        //---------------------------------------------------------------------

        public bool Save()
        {
            Row Row = new Row();

            try {
                if (this.NotebookId == 0) {
                    // Create
                    Row["CreateTime"] = Common.Now();
                    Row["NotebookGuid"] = UUID.Get();
                } else {
                    // Update
                }
                Row["ModifyTime"] = Common.Now();

                Row["EntryTime"] = this.EntryTime.ToString(Common.DATETIME_FORMAT);
                Row["Memo"] = this.Memo;
                Row["LocationId"] = this.LocationId;
                Row["CategoryId"] = this.CategoryId;

                if (this.NotebookId == 0) {
                    this.NotebookId = Database.Insert("Notebook", Row);
                    if (this.NotebookId > 0) {
                        this.CreateTime = DateTime.Parse(Row["CreateTime"]);
                        this.ModifyTime = DateTime.Parse(Row["ModifyTime"]);
                        this.NotebookGuid = Row["NotebookGuid"];
                    } else {
                        throw new Exception("Could not create Notebook entry");
                    }
                } else {
                    if (Database.Update("Notebook", Row, "NotebookId", this.NotebookId) > 0) {
                        this.ModifyTime = DateTime.Parse(Row["ModifyTime"]);
                    } else {
                        throw new Exception("Could not update Notebook entry: " + this.NotebookId.ToString());
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;

        }

        //---------------------------------------------------------------------

    }
}
