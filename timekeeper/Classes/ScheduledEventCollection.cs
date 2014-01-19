using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class ScheduledEventCollection
    {
        private DBI Database;

        //----------------------------------------------------------------------

        public ScheduledEventCollection()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------

        public List<Classes.ScheduledEvent> Fetch()
        {
            List<Classes.ScheduledEvent> ReturnList = new List<ScheduledEvent>();

            string Query = String.Format(@"
                SELECT e.EventId
                FROM Event e
                JOIN Reminder r on r.ReminderId = e.ReminderId
                JOIN Schedule s on s.ScheduleId = e.ScheduleId
                WHERE e.IsDeleted = 0
                  AND datetime(e.NextOccurrenceTime, 'localtime') > datetime('now', 'localtime')");

            Table Rows = this.Database.Select(Query);

            foreach (Row Row in Rows) {
                Classes.ScheduledEvent ScheduledEvent = new Classes.ScheduledEvent(Row["EventId"]);
                ReturnList.Add(ScheduledEvent);
            }

            return ReturnList;
        }

        //----------------------------------------------------------------------
    }
}
