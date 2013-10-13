using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class Event : Classes.SortableItem
    {
        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long EventGroupId { get; set; }
        public DateTime NextOccurrenceTime { get; set; }

        // Reminder
        public long Reminder_TimeAmount { get; set; }
        public long Reminder_TimeUnit { get; set; }
        public bool Reminder_NotifyViaTray { get; set; }
        public bool Reminder_NotifyViaAudio { get; set; }
        public bool Reminder_NotifyViaEmail { get; set; }
        public bool Reminder_NotifyViaSMS { get; set; }
        public string Reminder_NotifyTrayMessage { get; set; }
        public string Reminder_NotifyAudioFile { get; set; }
        public string Reminder_NotifyEmailAddress { get; set; }
        public string Reminder_NotifyPhoneNumber { get; set; }
        public long Reminder_NotifyCarrierListId { get; set; }

        // Schedule
        public long RefScheduleTypeId { get; set; }

        public long Schedule_OnceAmount { get; set; }
        public long Schedule_OnceUnit { get; set; }

        public long Schedule_DailyTypeId { get; set; }
        public long Schedule_DailyIntervalCount { get; set; }

        public long Schedule_WeeklyIntervalCount { get; set; }
        public bool Schedule_WeeklyMonday { get; set; }
        public bool Schedule_WeeklyTueday { get; set; }
        public bool Schedule_WeeklyWednesday { get; set; }
        public bool Schedule_WeeklyThursday { get; set; }
        public bool Schedule_WeeklyFriday { get; set; }
        public bool Schedule_WeeklySaturday { get; set; }
        public bool Schedule_WeeklySunday { get; set; }

        public long Schedule_MonthlyTypeId { get; set; }
        public long Schedule_MonthlyIntervalCount { get; set; }
        public long Schedule_MonthlyDate { get; set; }
        public long Schedule_MonthlyOrdinalDay { get; set; }
        public long Schedule_MonthlyDayOfWeek { get; set; }

        public long Schedule_YearlyTypeId { get; set; }
        public long Schedule_YearlyEveryDate { get; set; }
        public long Schedule_YearlyOrdinalDay { get; set; }
        public long Schedule_YearlyDayOfWeek { get; set; }
        public long Schedule_YearlyMonth { get; set; }

        public string CrontabExpression { get; set; }

        // Duration
        public long Duration_TypeId { get; set; }
        public long Duration_StopAfterCount { get; set; }
        public DateTime Duration_StopAfterTime { get; set; }

        // Event Metadata
        public long TriggerCount { get; set; }

        // System Metadata
        public bool IsHidden { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime HiddenTime { get; set; }
        public DateTime DeletedTime { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Event() : base("Event")
        {
        }

        //----------------------------------------------------------------------

        public Event(long id) : this()
        {
            this.Load(id);
        }

        //----------------------------------------------------------------------

        public Event(string name) : this()
        {
            long id = this.NameToId(name);
            this.Load(id);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        new public Row Load(long id)
        {
            Row Event = base.Load(id);

            try {
                if (Event["EventId"] != null) {
                    this.EventGroupId = Event["EventGroupId"];
                    this.NextOccurrenceTime = Event["NextOccurrenceTime"];

                    // Reminder
                    this.Reminder_TimeAmount = Event["Reminder_TimeAmount"];
                    this.Reminder_TimeUnit = Event["Reminder_TimeUnit"];
                    this.Reminder_NotifyViaTray = Event["Reminder_NotifyViaTray"];
                    this.Reminder_NotifyViaAudio = Event["Reminder_NotifyViaAudio"];
                    this.Reminder_NotifyViaEmail = Event["Reminder_NotifyViaEmail"];
                    this.Reminder_NotifyViaSMS = Event["Reminder_NotifyViaSMS"];
                    this.Reminder_NotifyTrayMessage = (string)Timekeeper.GetValue(Event["Reminder_NotifyTrayMessage"], "Here is your reminder");
                    this.Reminder_NotifyAudioFile = (string)Timekeeper.GetValue(Event["Reminder_NotifyAudioFile"], "");
                    this.Reminder_NotifyEmailAddress = (string)Timekeeper.GetValue(Event["Reminder_NotifyEmailAddress"], "you@example.com");
                    this.Reminder_NotifyPhoneNumber = (string)Timekeeper.GetValue(Event["Reminder_NotifyPhoneNumber"], "9995551212");
                    this.Reminder_NotifyCarrierListId = (long)Timekeeper.GetValue(Event["Reminder_NotifyCarrierListId"], 3);

                    // Schedule
                    this.RefScheduleTypeId = Event["RefScheduleTypeId"];

                    this.Schedule_OnceAmount = (long)Timekeeper.GetValue(Event["Schedule_OnceAmount"], 15);
                    this.Schedule_OnceUnit = (long)Timekeeper.GetValue(Event["Schedule_OnceUnit"], 3);

                    this.Schedule_DailyTypeId = (long)Timekeeper.GetValue(Event["Schedule_DailyTypeId"], 1);
                    this.Schedule_DailyIntervalCount = (long)Timekeeper.GetValue(Event["Schedule_DailyIntervalCount"], 2);

                    this.Schedule_WeeklyIntervalCount = (long)Timekeeper.GetValue(Event["Schedule_WeeklyIntervalCount"], 1);
                    this.Schedule_WeeklyMonday = (bool)Timekeeper.GetValue(Event["Schedule_WeeklyMonday"], false);
                    this.Schedule_WeeklyTueday = (bool)Timekeeper.GetValue(Event["Schedule_WeeklyTueday"], false);
                    this.Schedule_WeeklyWednesday = (bool)Timekeeper.GetValue(Event["Schedule_WeeklyWednesday"], false);
                    this.Schedule_WeeklyThursday = (bool)Timekeeper.GetValue(Event["Schedule_WeeklyThursday"], false);
                    this.Schedule_WeeklyFriday = (bool)Timekeeper.GetValue(Event["Schedule_WeeklyFriday"], false);
                    this.Schedule_WeeklySaturday = (bool)Timekeeper.GetValue(Event["Schedule_WeeklySaturday"], false);
                    this.Schedule_WeeklySunday = (bool)Timekeeper.GetValue(Event["Schedule_WeeklySunday"], false);

                    this.Schedule_MonthlyTypeId = (long)Timekeeper.GetValue(Event["Schedule_MonthlyTypeId"], 1);
                    this.Schedule_MonthlyIntervalCount = (long)Timekeeper.GetValue(Event["Schedule_MonthlyIntervalCount"], 1);
                    this.Schedule_MonthlyDate = (long)Timekeeper.GetValue(Event["Schedule_MonthlyDate"], 1);
                    this.Schedule_MonthlyOrdinalDay = (long)Timekeeper.GetValue(Event["Schedule_MonthlyOrdinalDay"], 1);
                    this.Schedule_MonthlyDayOfWeek = (long)Timekeeper.GetValue(Event["Schedule_MonthlyDayOfWeek"], 1);

                    this.Schedule_YearlyTypeId = (long)Timekeeper.GetValue(Event["Schedule_YearlyTypeId"], 1);
                    this.Schedule_YearlyEveryDate = (long)Timekeeper.GetValue(Event["Schedule_YearlyEveryDate"], 1);
                    this.Schedule_YearlyOrdinalDay = (long)Timekeeper.GetValue(Event["Schedule_YearlyOrdinalDay"], 1);
                    this.Schedule_YearlyDayOfWeek = (long)Timekeeper.GetValue(Event["Schedule_YearlyDayOfWeek"], 1);
                    this.Schedule_YearlyMonth = (long)Timekeeper.GetValue(Event["Schedule_YearlyMonth"], 1);

                    this.CrontabExpression = (string)Timekeeper.GetValue(Event["CrontabExpression"], "* * * * * ?");

                    // Duration
                    this.Duration_TypeId = Event["Duration_TypeId"];
                    this.Duration_StopAfterCount = (long)Timekeeper.GetValue(Event["Duration_StopAfterCount"], 10);
                    this.Duration_StopAfterTime = (DateTime)Timekeeper.GetValue(Event["Duration_StopAfterTime"], DateTime.MaxValue);

                    // Event Metadata
                    this.TriggerCount = Event["TriggerCount"];

                    // System Metadata
                    this.IsHidden = Event["IsHidden"];
                    this.IsDeleted = Event["IsDeleted"];
                    this.HiddenTime = (DateTime)Timekeeper.GetValue(Event["HiddenTime"], DateTime.MinValue);
                    this.DeletedTime = (DateTime)Timekeeper.GetValue(Event["DeletedTime"], DateTime.MinValue);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Event;
        }

    }
}
