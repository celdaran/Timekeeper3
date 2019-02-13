using System;
using System.Collections.Generic;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    // TODO: Rename file from Notebook.cs to NotebookEntry.cs

    class NotebookEntry
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Database;

        private NotebookEntryCollection AllEntries;

        //---------------------------------------------------------------------

        public long NotebookId = 0;
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public string NotebookGuid { get; set; }

        public DateTimeOffset EntryTime { get; set; }
        public string Memo { get; set; }
        public long? ProjectId { get; set; }
        public long? ActivityId { get; set; }
        public long? LocationId { get; set; }
        public long? CategoryId { get; set; }

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public NotebookEntry()
        {
            this.Database = Timekeeper.Database;
            this.AllEntries = new NotebookEntryCollection();
        }

        //---------------------------------------------------------------------

        public NotebookEntry(long notebookId) : this()
        {
            this.Load(notebookId);
        }

        //---------------------------------------------------------------------
        // Persistence
        //---------------------------------------------------------------------

        public void Load()
        {
            try {
                Row Row = new Row();
                Row = this.Database.SelectRow("SELECT MAX(NotebookId) AS MaxNotebookId FROM Notebook");
                if (Row["MaxNotebookId"] != null) {
                    long MaxNotebookId = Convert.ToInt64(Row["MaxNotebookId"]);
                    this.Load(MaxNotebookId);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public void Load(long notebookId)
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

        public bool Save()
        {
            Row Row = new Row();

            try {
                if (this.NotebookId == 0) {
                    // Create
                    Row["CreateTime"] = Timekeeper.DateForDatabase();
                    Row["NotebookGuid"] = UUID.Get();
                } else {
                    // Update
                }
                Row["ModifyTime"] = Timekeeper.DateForDatabase();

                // FIXME: sweep the codebase for this stuff
                // Seems to be any time we take a string, but
                // I'd really like to figure out how to solve
                // this in a less hacky, less one-off fashion.
                // Could it be part of the constructor itself?
                // Let's try that next! (Did that, commenting this out)
                //this.EntryTime = DateTime.SpecifyKind(this.EntryTime, DateTimeKind.Local);

                // EPIPHANY: I should have been using DateTimeOffset as the datatype for
                // all my date/times and NOT just DateTime, which is ambiguous with 
                // respect to the timezone. Crap. That's pretty fundamental, when it 
                // comes down to an application that pretends to store and manipulate
                // everything in UTC. Still experimenting, but it feels like this is
                // the direction things are heading...

                // FOLLOWUP EPIPHANY: It's 2014-07-14 and I'm ditching UTC and changing
                // everything back to DateTime *BUT* with a standard set of handling,
                // formatting, and conversion routines built into Timekeeper.cs.

                Row["EntryTime"] = Timekeeper.DateForDatabase(this.EntryTime);
                Row["Memo"] = this.Memo;
                Row["ProjectId"] = this.ProjectId;
                Row["ActivityId"] = this.ActivityId;
                Row["LocationId"] = this.LocationId;
                Row["CategoryId"] = this.CategoryId;

                if (this.NotebookId == 0) {
                    this.NotebookId = Database.Insert("Notebook", Row);
                    if (this.NotebookId > 0) {
                        this.CreateTime = Timekeeper.StringToDate(Row["CreateTime"]);
                        this.ModifyTime = Timekeeper.StringToDate(Row["ModifyTime"]);
                        this.NotebookGuid = Row["NotebookGuid"];
                    } else {
                        throw new Exception("Could not create Notebook entry");
                    }
                } else {
                    if (Database.Update("Notebook", Row, "NotebookId", this.NotebookId) > 0) {
                        this.ModifyTime = Timekeeper.StringToDate(Row["ModifyTime"]);
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
        // Helpers
        //---------------------------------------------------------------------

        public void Copy(Classes.NotebookEntry that)
        {
            this.NotebookId = that.NotebookId;
            this.CreateTime = that.CreateTime;
            this.ModifyTime = that.ModifyTime;
            this.NotebookGuid = that.NotebookGuid;
            this.EntryTime = that.EntryTime;
            this.Memo = that.Memo;
            this.ProjectId = that.ProjectId;
            this.ActivityId = that.ActivityId;
            this.LocationId = that.LocationId;
            this.CategoryId = that.CategoryId;
        }

        //---------------------------------------------------------------------
        // Navigation Help
        //---------------------------------------------------------------------

        public bool AtBeginning()
        {
            DateTimeOffset FirstEntry = this.AllEntries.FirstEntry()["EntryTime"];
            return this.EntryTime == FirstEntry;
        }

        //---------------------------------------------------------------------

        public bool AtEnd()
        {
            DateTimeOffset LastEntry = this.AllEntries.LastEntry()["EntryTime"];
            return this.EntryTime == LastEntry;
        }

        //---------------------------------------------------------------------

    }
}
