using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;
using Quartz;
using Quartz.Impl;

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

            bool SchedulerDisabled = true;
            if (SchedulerDisabled) {
                return ReturnList;
            }

            string Query = String.Format(@"
                SELECT e.EventId
                FROM Event e
                JOIN Reminder r on r.ReminderId = e.ReminderId
                JOIN Schedule s on s.ScheduleId = e.ScheduleId
                WHERE e.IsDeleted = 0
                ORDER BY e.NextOccurrenceTime");
                  // No longer use events in the past as a criteria. Grab all of them because
                  // we need to determine if past events are still nonetheless active.
                  //AND datetime(e.NextOccurrenceTime, 'localtime') > datetime('now', 'localtime')");
            Table Rows = this.Database.Select(Query);

            foreach (Row Row in Rows) {
                // What are we dealing with?
                Timekeeper.Debug("Checking scheduled event " + Row["EventId"]);

                // Instantiate the ScheduledEvent Object
                Classes.ScheduledEvent ScheduledEvent = new Classes.ScheduledEvent(Row["EventId"]);

                // Determine when the NextOccurenceTime should be. (For example, if the date
                // is in the past, but it's on an indefinite schedule, we have to find out 
                // what the next NextOccurenceTime is, and update accordingly.
                SetNextOccurrenceTime(ScheduledEvent);

                // With that, if it's in the future, then it's okay to add it to the
                // list of fetched ScheduledEvents for further processing
                if (ScheduledEvent.Event.NextOccurrenceTime.CompareTo(DateTimeOffset.Now) > 0) {
                    ReturnList.Add(ScheduledEvent);
                }
            }

            return ReturnList;
        }

        //----------------------------------------------------------------------

        private void SetNextOccurrenceTime(Classes.ScheduledEvent scheduledEvent)
        {
            bool SchedulerDisabled = true;
            if (SchedulerDisabled) {
                return;
            }

            try {
                //return; // FOR NOW

                // Need to see if we missed one or more firings and catch us up with
                // reality. e.g., an event that fires every two hours indefinitely
                // has to pick things back up after the laptop was off for a weekend.

                if (scheduledEvent.Event.NextOccurrenceTime.CompareTo(DateTimeOffset.Now) > 0) {
                    // Already in the future, do nothing
                    return;
                }

                // Create trigger (but do not schedule a job)
                ITrigger Trigger = Timekeeper.CreateTrigger(
                    scheduledEvent,
                    scheduledEvent.Event.NextOccurrenceTime.LocalDateTime,
                    null);

                // Set up some helper variables
                bool Continue = true;
                long TriggerCount = scheduledEvent.Schedule.TriggerCount;
                DateTimeOffset? CurrentEventTime = scheduledEvent.Event.NextOccurrenceTime;

                // Now loop until we find our next schedule date
                while (Continue) {

                    DateTimeOffset? NextEventTime = Trigger.GetFireTimeAfter(CurrentEventTime);
                    TriggerCount++;

                    switch (scheduledEvent.Schedule.DurationTypeId) {
                        case 1: // indefinitely: don't do anything
                            if (NextEventTime == null) {
                                // This event is done
                                Timekeeper.Debug("This event has no next time!");
                                Continue = false;
                            } else {
                                if (NextEventTime.Value.LocalDateTime.CompareTo(DateTime.Now) > 0) {
                                    Timekeeper.Debug("Found the next time!");
                                    Continue = false;
                                }
                            }
                            break;

                        case 2: // stop after count
                            if (TriggerCount > scheduledEvent.Schedule.StopAfterCount) {
                                Timekeeper.Debug("Schedule count exceeded");
                                Continue = false;
                            }
                            break;

                        case 3: // stop after time
                            if (NextEventTime.Value.LocalDateTime.CompareTo(scheduledEvent.Schedule.StopAfterTime) > 0) {
                                Timekeeper.Debug("Schedule date exceeded");
                                Continue = false;
                            }
                            break;
                    }

                    CurrentEventTime = NextEventTime;

                    // Safety feature (haven't hit this yet, but you never know)
                    if (TriggerCount > 99999) {
                        Timekeeper.Warn("Trigger count exceeded 99999.");
                        Continue = false;
                        NextEventTime = null;
                    }

                }

                if (CurrentEventTime != null) {
                    scheduledEvent.Event.NextOccurrenceTime = CurrentEventTime.Value;
                    scheduledEvent.Event.Save();
                    scheduledEvent.Schedule.TriggerCount = TriggerCount;
                    scheduledEvent.Schedule.Save();
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
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
