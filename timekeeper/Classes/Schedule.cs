using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class Schedule
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private DBI Database;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long ScheduleId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        // Schedule
        public long RefScheduleTypeId { get; set; }

        public long OnceAmount { get; set; }
        public long OnceUnit { get; set; }

        public long DailyTypeId { get; set; }
        public long DailyIntervalCount { get; set; }

        public long WeeklyIntervalCount { get; set; }
        public bool WeeklyMonday { get; set; }
        public bool WeeklyTueday { get; set; }
        public bool WeeklyWednesday { get; set; }
        public bool WeeklyThursday { get; set; }
        public bool WeeklyFriday { get; set; }
        public bool WeeklySaturday { get; set; }
        public bool WeeklySunday { get; set; }

        public long MonthlyTypeId { get; set; }
        public long MonthlyIntervalCount { get; set; }
        public long MonthlyDate { get; set; }
        public long MonthlyOrdinalDay { get; set; }
        public long MonthlyDayOfWeek { get; set; }

        public long YearlyTypeId { get; set; }
        public long YearlyEveryDate { get; set; }
        public long YearlyOrdinalDay { get; set; }
        public long YearlyDayOfWeek { get; set; }
        public long YearlyMonth { get; set; }

        public string CrontabExpression { get; set; }

        public long DurationTypeId { get; set; }
        public long StopAfterCount { get; set; }
        public DateTime StopAfterTime { get; set; }

        // Event Metadata
        public long TriggerCount { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Schedule()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------

        public Schedule(long id) : this()
        {
            this.Load(id);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public Row Load(long id)
        {
            Row Schedule = new Row();

            try {
                string Query = String.Format(@"select ScheduleId Id, * from Schedule where ScheduleId = {0}", id);
                Schedule = this.Database.SelectRow(Query);

                if (Schedule["ScheduleId"] != null) {
                    this.ScheduleId = Schedule["ScheduleId"];
                    this.CreateTime = Schedule["CreateTime"];
                    this.ModifyTime = Schedule["ModifyTime"];

                    this.RefScheduleTypeId = Schedule["RefScheduleTypeId"];

                    this.OnceAmount = (long)Timekeeper.GetValue(Schedule["OnceAmount"], 15);
                    this.OnceUnit = (long)Timekeeper.GetValue(Schedule["OnceUnit"], 3);

                    this.DailyTypeId = (long)Timekeeper.GetValue(Schedule["DailyTypeId"], 1);
                    this.DailyIntervalCount = (long)Timekeeper.GetValue(Schedule["DailyIntervalCount"], 2);

                    this.WeeklyIntervalCount = (long)Timekeeper.GetValue(Schedule["WeeklyIntervalCount"], 1);
                    this.WeeklyMonday = (bool)Timekeeper.GetValue(Schedule["WeeklyMonday"], false);
                    this.WeeklyTueday = (bool)Timekeeper.GetValue(Schedule["WeeklyTueday"], false);
                    this.WeeklyWednesday = (bool)Timekeeper.GetValue(Schedule["WeeklyWednesday"], false);
                    this.WeeklyThursday = (bool)Timekeeper.GetValue(Schedule["WeeklyThursday"], false);
                    this.WeeklyFriday = (bool)Timekeeper.GetValue(Schedule["WeeklyFriday"], false);
                    this.WeeklySaturday = (bool)Timekeeper.GetValue(Schedule["WeeklySaturday"], false);
                    this.WeeklySunday = (bool)Timekeeper.GetValue(Schedule["WeeklySunday"], false);

                    this.MonthlyTypeId = (long)Timekeeper.GetValue(Schedule["MonthlyTypeId"], 1);
                    this.MonthlyIntervalCount = (long)Timekeeper.GetValue(Schedule["MonthlyIntervalCount"], 1);
                    this.MonthlyDate = (long)Timekeeper.GetValue(Schedule["MonthlyDate"], 1);
                    this.MonthlyOrdinalDay = (long)Timekeeper.GetValue(Schedule["MonthlyOrdinalDay"], 1);
                    this.MonthlyDayOfWeek = (long)Timekeeper.GetValue(Schedule["MonthlyDayOfWeek"], 1);

                    this.YearlyTypeId = (long)Timekeeper.GetValue(Schedule["YearlyTypeId"], 1);
                    this.YearlyEveryDate = (long)Timekeeper.GetValue(Schedule["YearlyEveryDate"], 1);
                    this.YearlyOrdinalDay = (long)Timekeeper.GetValue(Schedule["YearlyOrdinalDay"], 1);
                    this.YearlyDayOfWeek = (long)Timekeeper.GetValue(Schedule["YearlyDayOfWeek"], 1);
                    this.YearlyMonth = (long)Timekeeper.GetValue(Schedule["YearlyMonth"], 1);

                    this.CrontabExpression = (string)Timekeeper.GetValue(Schedule["CrontabExpression"], "* * * * * ?");

                    // Duration
                    this.DurationTypeId = Schedule["DurationTypeId"];
                    this.StopAfterCount = (long)Timekeeper.GetValue(Schedule["StopAfterCount"], 10);
                    this.StopAfterTime = (DateTime)Timekeeper.GetValue(Schedule["StopAfterTime"], DateTime.MaxValue);

                    // Event Metadata
                    this.TriggerCount = Schedule["TriggerCount"];
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Schedule;
        }
    }
}
