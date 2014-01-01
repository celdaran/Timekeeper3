using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class EventCollection
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public EventCollection()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------
        // Fetch
        //----------------------------------------------------------------------

        /*
        public bool Exists(long projectId)
        {
            string Query = String.Format(@"SELECT COUNT(*) AS Count FROM Todo WHERE ProjectId = {0} AND IsDeleted = 0", projectId);
            Row TodoRow = this.Database.SelectRow(Query);
            return (TodoRow["Count"] > 0);
        }
        */

        //----------------------------------------------------------------------

        public List<Classes.Event> Fetch()
        {
            List<Classes.Event> ReturnList = new List<Classes.Event>();

            string Query = String.Format(@"SELECT EventId FROM Event WHERE IsDeleted = 0 ORDER BY SortOrderNo, EventId");
            Table EventRows = this.Database.Select(Query);

            foreach (Row EventRow in EventRows) {
                Classes.Event Event = new Classes.Event(EventRow["EventId"]);
                ReturnList.Add(Event);
            }

            return ReturnList;
        }

        //----------------------------------------------------------------------
    }
}
