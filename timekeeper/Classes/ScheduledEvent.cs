using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    public class ScheduledEvent
    {
        //----------------------------------------------------------------------
        // The construct of a "Scheduled Event" is an amalgam of three
        // tables: Event, Reminder, and Schedule. The precise interrelationship
        // of these objects results in a "Scheduled Event".
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;

        public Classes.Event Event { get; set; }
        public Classes.Reminder Reminder { get; set; }
        public Classes.Schedule Schedule { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ScheduledEvent(long eventId)
        {
            this.Database = Timekeeper.Database;

            string Query = String.Format(@"
                SELECT 
                    e.EventId, e.ReminderId, e.ScheduleId
                FROM Event e
                JOIN Reminder r on r.ReminderId = e.ReminderId
                LEFT OUTER JOIN Schedule s on s.ScheduleId = e.ScheduleId
                WHERE e.IsDeleted = 0
                  AND e.EventId = {0}", eventId);

            Row Row = this.Database.SelectRow(Query);

            if ((Row.Count > 0) && (Row["EventId"] != null))
            {
                this.Event = new Classes.Event(eventId);

                if (Row["ReminderId"] != null) {
                    this.Reminder = new Classes.Reminder(Row["ReminderId"]);
                }

                if (Row["ScheduleId"] != null) {
                    this.Schedule = new Classes.Schedule(Row["ScheduleId"]);
                } else {
                    this.Schedule = new Classes.Schedule(0);
                }
            }
        }

        //----------------------------------------------------------------------

    }
}
