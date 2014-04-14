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

        public DateTime MostRecentModification()
        {
            this.Database.BeginWork();

            try {
                string Query = String.Format(@"SELECT max(ModifyTime) as EventModifyTime FROM Event WHERE IsDeleted = 0");
                Row Row = this.Database.SelectRow(Query);
                DateTime EventModifyTime = DateTime.Parse(Row["EventModifyTime"]);

                Query = String.Format(@"SELECT max(ModifyTime) as ReminderModifyTime FROM Reminder");
                Row = this.Database.SelectRow(Query);
                DateTime ReminderModifyTime = DateTime.Parse(Row["ReminderModifyTime"]);

                Query = String.Format(@"SELECT max(ModifyTime) as ScheduleModifyTime FROM Schedule");
                Row = this.Database.SelectRow(Query);
                DateTime ScheduleModifyTime = DateTime.Parse(Row["ScheduleModifyTime"]);

                this.Database.EndWork();

                if (EventModifyTime.CompareTo(ReminderModifyTime) > 0) {
                    if (EventModifyTime.CompareTo(ScheduleModifyTime) > 0) {
                        return EventModifyTime;
                    } else {
                        return ScheduleModifyTime;
                    }
                } else {
                    if (ReminderModifyTime.CompareTo(ScheduleModifyTime) > 0) {
                        return ReminderModifyTime;
                    } else {
                        return ScheduleModifyTime;
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                // Just in case (safe to call twice)
                this.Database.EndWork();
                return DateTime.Now;
            }
        }

        //----------------------------------------------------------------------
    }
}
