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
        public long ReminderId { get; set; }
        public long ScheduleId { get; set; }

        public Classes.EventGroup Group { get; set; }
        public Classes.Reminder Reminder { get; set; }
        public Classes.Schedule Schedule { get; set; }

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
                    this.ReminderId = (long)Timekeeper.GetValue(Event["ReminderId"], 0);
                    this.ScheduleId = (long)Timekeeper.GetValue(Event["ScheduleId"], 0);

                    this.Group = this.EventGroupId > 0 ? new Classes.EventGroup(this.EventGroupId) : null;
                    this.Reminder = this.ReminderId > 0 ? new Classes.Reminder(this.ReminderId) : null;
                    this.Schedule = this.ScheduleId > 0 ? new Classes.Schedule(this.ScheduleId) : null;

                    this.IsHidden = (bool)Timekeeper.GetValue(Event["IsHidden"], false);
                    this.IsDeleted = (bool)Timekeeper.GetValue(Event["IsDeleted"], false);
                    this.HiddenTime = (DateTime)Timekeeper.GetValue(Event["HiddenTime"], DateTime.MaxValue);
                    this.DeletedTime = (DateTime)Timekeeper.GetValue(Event["DeletedTime"], DateTime.MaxValue);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Event;
        }

        //----------------------------------------------------------------------

        new public bool Save()
        {
            bool Saved = false;

            try {
                Saved = base.Save();

                if (Saved) {
                    Row Event = new Row();

                    // Make sure everything's always localtime
                    // TODO: Something's not quite right here, I need to figure
                    // out where things are going wrong. This is nothing more
                    // than a band-aid. (See Journal Entry class)
                    this.NextOccurrenceTime = DateTime.SpecifyKind(this.NextOccurrenceTime, DateTimeKind.Local);

                    Event["EventGroupId"] = this.EventGroupId;
                    Event["NextOccurrenceTime"] = this.NextOccurrenceTime.ToString(Common.DATETIME_FORMAT);
                    Event["ReminderId"] = this.ReminderId;
                    Event["ScheduleId"] = this.ScheduleId;
                    Event["IsHidden"] = 0;
                    Event["IsDeleted"] = 0;

                    if (this.Database.Update("Event", Event, "EventId", this.Id) == 1) {
                        Saved = true;
                    } else {
                        Saved = false;
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Saved;
        }

        //----------------------------------------------------------------------

    }
}
