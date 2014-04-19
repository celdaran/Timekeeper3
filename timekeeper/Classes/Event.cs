using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class Event
    {
        //----------------------------------------------------------------------
        // An Important Note
        //----------------------------------------------------------------------
        // This began as a subclass of SortableItem, except that Events are not
        // "sortable items." This kicked off a great deal of soul-searching, as
        // I tried to figure out what the best, generalized ORM solution would
        // be for this project. However, we're now 470 hours into this TK3
        // project, and I *really* just need this done, on multiple levels.
        // Therefore, I'm going brute force this. You'll see a lot of ugly and
        // unmaintainable copy and paste, but, as I said, I have to fast-track
        // this to finish and create a better, more-generalized ORM solution
        // for some future version of Timekeeper.
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        protected DBI Database;
        protected Classes.Options Options;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long Id { get; protected set; }

        public DateTimeOffset CreateTime { get; protected set; }
        public DateTimeOffset ModifyTime { get; protected set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public long EventGroupId { get; set; }
        public DateTimeOffset NextOccurrenceTime { get; set; }
        public long ReminderId { get; set; }
        public long ScheduleId { get; set; }

        public Classes.EventGroup Group { get; set; }
        public Classes.Reminder Reminder { get; set; }
        public Classes.Schedule Schedule { get; set; }

        public bool IsHidden { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset HiddenTime { get; set; }
        public DateTimeOffset DeletedTime { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Event()
        {
            this.Id = 0;

            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
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

        public Row Load(long id)
        {
            Row Event = new Row();

            try {
                string Query = String.Format(@"select * from Event where EventId = {0}", id);
                Event = this.Database.SelectRow(Query);

                if (Event["EventId"] != null) {
                    this.Id = id;
                    this.CreateTime = Event["CreateTime"];
                    this.ModifyTime = Event["ModifyTime"];
                    this.Name = Event["Name"];
                    this.Description = (string)Timekeeper.GetValue(Event["Description"], "");

                    this.EventGroupId = Event["EventGroupId"];
                    this.NextOccurrenceTime = Event["NextOccurrenceTime"];
                    this.ReminderId = (long)Timekeeper.GetValue(Event["ReminderId"], 0);
                    this.ScheduleId = (long)Timekeeper.GetValue(Event["ScheduleId"], 0);

                    this.Group = this.EventGroupId > 0 ? new Classes.EventGroup(this.EventGroupId) : null;
                    this.Reminder = this.ReminderId > 0 ? new Classes.Reminder(this.ReminderId) : null;
                    this.Schedule = this.ScheduleId > 0 ? new Classes.Schedule(this.ScheduleId) : null;

                    this.IsHidden = (bool)Timekeeper.GetValue(Event["IsHidden"], false);
                    this.IsDeleted = (bool)Timekeeper.GetValue(Event["IsDeleted"], false);
                    this.HiddenTime = (DateTimeOffset)Timekeeper.GetValue(Event["HiddenTime"], DateTimeOffset.MaxValue);
                    this.DeletedTime = (DateTimeOffset)Timekeeper.GetValue(Event["DeletedTime"], DateTimeOffset.MaxValue);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Event;
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            bool Saved = false;

            try {
                Row Event = new Row();

                Event["Name"] = Name;
                Event["Description"] = Description;

                // Make sure everything's always localtime
                // TODO: Something's not quite right here, I need to figure
                // out where things are going wrong. This is nothing more
                // than a band-aid. (See Journal Entry class)
                // FIXME (GENERAL FIXME): Sweep all date/time instances for UTC vs LocalTime issues  :^(

                /*
                Commenting out during the Ticket #1310 / DateTimeOffset sweep
                this.NextOccurrenceTime = DateTime.SpecifyKind(this.NextOccurrenceTime, DateTimeKind.Local);
                this.HiddenTime = DateTime.SpecifyKind(this.HiddenTime, DateTimeKind.Local);
                this.DeletedTime = DateTime.SpecifyKind(this.DeletedTime, DateTimeKind.Local);
                */

                Event["EventGroupId"] = this.EventGroupId;
                Event["NextOccurrenceTime"] = this.NextOccurrenceTime.ToString(Common.UTC_DATETIME_FORMAT);
                Event["ReminderId"] = this.ReminderId;
                Event["ScheduleId"] = this.ScheduleId;
                Event["IsHidden"] = this.IsHidden ? 1 : 0;
                Event["IsDeleted"] = this.IsDeleted ? 1 : 0;

                if (this.IsHidden)
                    Event["HiddenTime"] = this.HiddenTime.ToString(Common.UTC_DATETIME_FORMAT);
                if (this.IsDeleted)
                    Event["DeletedTime"] = this.DeletedTime.ToString(Common.UTC_DATETIME_FORMAT);

                string Query = String.Format(@"
                    SELECT count(*) as Count 
                    FROM Event
                    WHERE EventId = '{0}'", this.Id);
                Row Count = this.Database.SelectRow(Query);

                if (Count["Count"] == 0) {

                    Event["CreateTime"] = Common.Now();
                    Event["ModifyTime"] = Common.Now();

                    this.Id = this.Database.Insert("Event", Event);
                    if (this.Id > 0) {
                        //Common.Info("Just inserted EventId: " + this.Id.ToString());
                        CreateTime = Convert.ToDateTime(Event["CreateTime"]);
                        ModifyTime = Convert.ToDateTime(Event["ModifyTime"]);
                    } else {
                        throw new Exception("Error inserting into Event");
                    }
                } else {

                    Event["ModifyTime"] = Common.Now();

                    //Common.Info("About to update EventId: " + this.Id.ToString());
                    if (this.Database.Update("Event", Event, "EventId", this.Id) == 1) {
                        ModifyTime = Convert.ToDateTime(Event["ModifyTime"]);
                    } else {
                        throw new Exception("Error updating Event");
                    }
                }

                Saved = true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Saved;
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        protected long NameToId(string eventName)
        {
            string QuotedName = eventName.Replace("'", "''");
            string Query = String.Format(@"SELECT EventId AS Id FROM Event WHERE Name = '{1}'",
                QuotedName);
            Row Row = Database.SelectRow(Query);
            if (Row["Id"] != null) {
                return Row["Id"];
            } else {
                return 0;
            }
        }

        //----------------------------------------------------------------------
    }
}
