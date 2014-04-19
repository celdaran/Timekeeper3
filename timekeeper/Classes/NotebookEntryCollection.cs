using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class NotebookEntryCollection
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Database;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public NotebookEntryCollection()
        {
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Public Methods
        //---------------------------------------------------------------------

        public long Count()
        {
            // FIXME: WHAT ABOUT DELETING ITEMS? This would need IsDeleted = 0
            string Query = "SELECT COUNT(*) AS Count FROM Notebook"; // WHERE datetime(CreateTime) > datetime('2014-04-18T07:55:00-05:00')";
            Row Row = Database.SelectRow(Query);
            return (long)Row["Count"];
        }

        //---------------------------------------------------------------------

        public Row FirstEntry()
        {
            string SubQuery = "SELECT MIN(EntryTime) FROM Notebook";
            return FetchEntry(SubQuery);
        }

        //---------------------------------------------------------------------

        public Row PreviousEntry(Classes.NotebookEntry entry)
        {
            /*
            DateTime Subject = entry.CreateTime.UtcDateTime;

            string Format1 = Subject.ToString();
            string Format2 = Subject.ToString(Common.LOCAL_DATETIME_FORMAT);
            string Format3 = Subject.ToString(Common.DATETIME_FORMAT);
            string Format4 = Subject.ToString("o");

            string Debug = String.Format("Entry={4}\n\nFormat1={0}\nFormat2={1}\nFormat3={2}\nFormat4={3}\n",
                Format1, Format2, Format3, Format4, entry.NotebookId);
            Common.Info(Debug);
            */
            if (entry.EntryTime.DateTime == DateTime.MinValue) {
                return this.LastEntry();
            } else {
                string SubQuery = String.Format(
                    "SELECT MAX(EntryTime) FROM Notebook WHERE datetime(EntryTime) < datetime('{0}')",
                    entry.EntryTime.ToString(Common.DATETIME_FORMAT));
                return FetchEntry(SubQuery);
            }
        }

        //---------------------------------------------------------------------

        public Row NextEntry(Classes.NotebookEntry entry)
        {
            string SubQuery = String.Format(
                "SELECT MIN(EntryTime) FROM Notebook WHERE datetime(EntryTime) > datetime('{0}')",
                entry.EntryTime.ToString(Common.DATETIME_FORMAT));
            return FetchEntry(SubQuery);
        }

        //---------------------------------------------------------------------

        public Row LastEntry()
        {
            string SubQuery = "SELECT MAX(EntryTime) FROM Notebook";
            return FetchEntry(SubQuery);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private Row FetchEntry(string query)
        {
            string Query = String.Format("SELECT * FROM Notebook WHERE EntryTime = ({0})", query);
            Row Row = Database.SelectRow(Query);
            return Row;
        }

        //---------------------------------------------------------------------

    }
}
