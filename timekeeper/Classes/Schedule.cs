using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//FIXME: wrong place for this
using Quartz;
using Quartz.Impl;

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
        // Constants
        //----------------------------------------------------------------------

        public const int TIME_UNIT_SECONDS = 1;
        public const int TIME_UNIT_MINUTES = 2;
        public const int TIME_UNIT_HOURS = 3;
        public const int TIME_UNIT_DAYS = 4;
        public const int TIME_UNIT_WEEKS = 5;
        public const int TIME_UNIT_MONTHS = 6;
        public const int TIME_UNIT_QUARTERS = 7;
        public const int TIME_UNIT_YEARS = 8;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long ScheduleId { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }

        // Schedule
        public long RefScheduleTypeId { get; set; }

        public long OnceAmount { get; set; }
        public long OnceUnit { get; set; }

        public long DailyTypeId { get; set; }
        public long DailyIntervalCount { get; set; }

        public long WeeklyIntervalCount { get; set; }
        public bool WeeklyMonday { get; set; }
        public bool WeeklyTuesday { get; set; }
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
                    this.SetAttributes(Schedule);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Schedule;
        }

        //----------------------------------------------------------------------

        public void SetAttributes(Row row)
        {
            this.ScheduleId = row["ScheduleId"];
            this.CreateTime = row["CreateTime"];
            this.ModifyTime = row["ModifyTime"];

            this.RefScheduleTypeId = row["RefScheduleTypeId"];

            this.OnceAmount = (long)Timekeeper.GetValue(row["OnceAmount"], 15);
            this.OnceUnit = (long)Timekeeper.GetValue(row["OnceUnit"], 3);

            this.DailyTypeId = (long)Timekeeper.GetValue(row["DailyTypeId"], 1);
            this.DailyIntervalCount = (long)Timekeeper.GetValue(row["DailyIntervalCount"], 2);

            this.WeeklyIntervalCount = (long)Timekeeper.GetValue(row["WeeklyIntervalCount"], 1);
            this.WeeklyMonday = (bool)Timekeeper.GetValue(row["WeeklyMonday"], false);
            this.WeeklyTuesday = (bool)Timekeeper.GetValue(row["WeeklyTueday"], false);
            this.WeeklyWednesday = (bool)Timekeeper.GetValue(row["WeeklyWednesday"], false);
            this.WeeklyThursday = (bool)Timekeeper.GetValue(row["WeeklyThursday"], false);
            this.WeeklyFriday = (bool)Timekeeper.GetValue(row["WeeklyFriday"], false);
            this.WeeklySaturday = (bool)Timekeeper.GetValue(row["WeeklySaturday"], false);
            this.WeeklySunday = (bool)Timekeeper.GetValue(row["WeeklySunday"], false);

            this.MonthlyTypeId = (long)Timekeeper.GetValue(row["MonthlyTypeId"], 1);
            this.MonthlyIntervalCount = (long)Timekeeper.GetValue(row["MonthlyIntervalCount"], 1);
            this.MonthlyDate = (long)Timekeeper.GetValue(row["MonthlyDate"], 1);
            this.MonthlyOrdinalDay = (long)Timekeeper.GetValue(row["MonthlyOrdinalDay"], 1);
            this.MonthlyDayOfWeek = (long)Timekeeper.GetValue(row["MonthlyDayOfWeek"], 1);

            this.YearlyTypeId = (long)Timekeeper.GetValue(row["YearlyTypeId"], 1);
            this.YearlyEveryDate = (long)Timekeeper.GetValue(row["YearlyEveryDate"], 1);
            this.YearlyOrdinalDay = (long)Timekeeper.GetValue(row["YearlyOrdinalDay"], 1);
            this.YearlyDayOfWeek = (long)Timekeeper.GetValue(row["YearlyDayOfWeek"], 1);
            this.YearlyMonth = (long)Timekeeper.GetValue(row["YearlyMonth"], 1);

            this.CrontabExpression = (string)Timekeeper.GetValue(row["CrontabExpression"], "* * * * * ?");

            // Duration
            this.DurationTypeId = row["DurationTypeId"];
            this.StopAfterCount = (long)Timekeeper.GetValue(row["StopAfterCount"], 10);
            this.StopAfterTime = (DateTime)Timekeeper.GetValue(row["StopAfterTime"], DateTime.MaxValue);

            // Event Metadata
            this.TriggerCount = row["TriggerCount"];
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            bool Saved = false;
            string DbTimeStamp = Common.Now();

            try
            {
                Row Schedule = new Row();

                Schedule["ModifyTime"] = DbTimeStamp;

                Schedule["RefScheduleTypeId"] = this.RefScheduleTypeId;

                Schedule["OnceAmount"] = this.OnceAmount;
                Schedule["OnceUnit"] = this.OnceUnit;

                Schedule["DailyTypeId"] = this.DailyTypeId;
                Schedule["DailyIntervalCount"] = this.DailyIntervalCount;

                Schedule["WeeklyIntervalCount"] = this.WeeklyIntervalCount;
                Schedule["WeeklyMonday"] = this.WeeklyMonday ? 1 : 0;
                Schedule["WeeklyTueday"] = this.WeeklyTuesday ? 1 : 0;
                Schedule["WeeklyWednesday"] = this.WeeklyWednesday ? 1 : 0;
                Schedule["WeeklyThursday"] = this.WeeklyThursday ? 1 : 0;
                Schedule["WeeklyFriday"] = this.WeeklyFriday ? 1 : 0;
                Schedule["WeeklySaturday"] = this.WeeklySaturday ? 1 : 0;
                Schedule["WeeklySunday"] = this.WeeklySunday ? 1 : 0;

                Schedule["MonthlyTypeId"] = this.MonthlyTypeId;
                Schedule["MonthlyIntervalCount"] = this.MonthlyIntervalCount;
                Schedule["MonthlyDate"] = this.MonthlyDate;
                Schedule["MonthlyOrdinalDay"] = this.MonthlyOrdinalDay;
                Schedule["MonthlyDayOfWeek"] = this.MonthlyDayOfWeek;

                Schedule["YearlyTypeId"] = this.YearlyTypeId;
                Schedule["YearlyEveryDate"] = this.YearlyEveryDate;
                Schedule["YearlyOrdinalDay"] = this.YearlyOrdinalDay;
                Schedule["YearlyDayOfWeek"] = this.YearlyDayOfWeek;
                Schedule["YearlyMonth"] = this.YearlyMonth;

                Schedule["CrontabExpression"] = this.CrontabExpression;

                // Duration
                Schedule["DurationTypeId"] = this.DurationTypeId;
                Schedule["StopAfterCount"] = this.StopAfterCount;
                Schedule["StopAfterTime"] = this.StopAfterTime.ToString(Common.DATETIME_FORMAT); // TODO: UTC-safe?

                // Event Metadata
                Schedule["TriggerCount"] = this.TriggerCount;

                if (this.ScheduleId == 0) {
                    Schedule["CreateTime"] = DbTimeStamp;

                    this.ScheduleId = this.Database.Insert("Schedule", Schedule);
                    if (this.ScheduleId > 0) {
                        Saved = true;
                        this.CreateTime = DateTime.Parse(DbTimeStamp);
                        this.ModifyTime = this.CreateTime;
                    }
                } else {
                    if (this.Database.Update("Schedule", Schedule, "ScheduleId", this.ScheduleId) == 1) {
                        Saved = true;
                        this.ModifyTime = DateTime.Parse(DbTimeStamp);
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Saved;
        }

        //----------------------------------------------------------------------
        // Trigger Builders
        //----------------------------------------------------------------------

        public DateTime ReminderTime(DateTime nextOccurrence, int unit, int amount)
        {
            DateTime ReminderTime = nextOccurrence;

            switch (unit) {
                case 1: // minutes
                    ReminderTime = ReminderTime.AddMinutes(-(double)amount);
                    break;
                case 2: // hours
                    ReminderTime = ReminderTime.AddHours(-(double)amount);
                    break;
                case 3: // days
                    ReminderTime = ReminderTime.AddDays(-(double)amount);
                    break;
                case 4: // weeks
                    ReminderTime = ReminderTime.AddDays(-(double)amount * 7);
                    break;
                case 5: // months
                    ReminderTime = ReminderTime.AddMonths(-(int)amount);
                    break;
            }

            return ReminderTime;
        }

        //----------------------------------------------------------------------

        public ITrigger OneTimeTrigger(string triggerName, DateTime startAt)
        {
            string Debug = String.Format("Created one time trigger for schedule {0}, starting at {1}",
                this.ScheduleId, startAt.ToString(Common.DATETIME_FORMAT));
            Timekeeper.Debug(Debug);

            ITrigger SimpleTrigger = TriggerBuilder.Create()
                .WithIdentity(triggerName)
                .WithSimpleSchedule()
                .StartAt(startAt)
                .Build();

            return SimpleTrigger;

        }

        //----------------------------------------------------------------------

        public ITrigger FixedTrigger(string triggerName, DateTime startAt, int unit, int amount)
        {
            ITrigger FixedTrigger;
            string Debug;

            // seconds, minutes, hours, days, weeks | months, quarters, years

            if (unit < TIME_UNIT_MONTHS) {
                int Seconds = amount;

                switch (unit) {
                    case TIME_UNIT_MINUTES:
                        Seconds = amount * 60;
                        break;
                    case TIME_UNIT_HOURS:
                        Seconds = amount * 60 * 60;
                        break;
                    case TIME_UNIT_DAYS:
                        Seconds = amount * 60 * 60 * 24;
                        break;
                    case TIME_UNIT_WEEKS:
                        Seconds = amount * 60 * 60 * 24 * 7;
                        break;
                }

                Debug = String.Format("Created fixed trigger for schedule {0}, starting at {1}, interval {2} seconds",
                    this.ScheduleId, startAt.ToString(Common.DATETIME_FORMAT), Seconds);
                Timekeeper.Debug(Debug);

                FixedTrigger = TriggerBuilder.Create()
                    .WithIdentity(triggerName)
                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(Seconds).RepeatForever())
                    .StartAt(startAt)
                    .Build();

            } else {
                int Months = amount;

                switch (unit) {
                    case TIME_UNIT_QUARTERS:
                        Months = amount * 3;
                        break;
                    case TIME_UNIT_YEARS:
                        Months = amount * 12;
                        break;
                }

                Debug = String.Format("Created fixed trigger for schedule {0}, starting at {1}, interval {2} months",
                    this.ScheduleId, startAt.ToString(Common.DATETIME_FORMAT), Months);
                Timekeeper.Debug(Debug);

                FixedTrigger = TriggerBuilder.Create()
                    .WithIdentity(triggerName)
                    .WithCalendarIntervalSchedule(x => x.WithIntervalInMonths(Months))
                    .StartAt(startAt)
                    .Build();
            }

            /* OLD PREVIEW CODE FOR REFERENCE (wait, this is Fixed, not OneTime)

            ITrigger PreviewTrigger = TriggerBuilder.Create()
                .WithIdentity("Preview Trigger")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(count).RepeatForever())
                .StartAt(EventNextOccurrence.Value)
                .Build();
            */

            return FixedTrigger;
        }

        //----------------------------------------------------------------------

        public ITrigger DailyTrigger(string triggerName, DateTime startAt, int dailyTypeId, int interval)
        {
            ITrigger DailyTrigger;

            switch (dailyTypeId) {
                case 2:
                    string CronExpressionString =
                        String.Format("{0} {1} {2} ? * MON,TUE,WED,THU,FRI *", startAt.Second, startAt.Minute, startAt.Hour);
                    DailyTrigger = this.CronTrigger(triggerName, startAt, CronExpressionString);
                    break;

                case 3:
                    DailyTrigger = this.FixedTrigger(triggerName, startAt, TIME_UNIT_DAYS, interval);
                    break;

                default:
                    DailyTrigger = this.FixedTrigger(triggerName, startAt, TIME_UNIT_DAYS, 1);
                    break;
            }

            return DailyTrigger;
        }

        //----------------------------------------------------------------------

        public ITrigger WeeklyTrigger(string triggerName, DateTime startAt)
        {
            List<string> Weekdays = new List<string>();

            if (this.WeeklyMonday)
                Weekdays.Add("MON");
            if (this.WeeklyTuesday)
                Weekdays.Add("TUE");
            if (this.WeeklyWednesday)
                Weekdays.Add("WED");
            if (this.WeeklyThursday)
                Weekdays.Add("THU");
            if (this.WeeklyFriday)
                Weekdays.Add("FRI");
            if (this.WeeklySaturday)
                Weekdays.Add("SAT");
            if (this.WeeklySunday)
                Weekdays.Add("SUN");

            return this.WeeklyTrigger(triggerName, startAt, Weekdays);
        }

        //----------------------------------------------------------------------

        public ITrigger WeeklyTrigger(string triggerName, DateTime startAt, List<string> weekdays)
        {
            ITrigger WeeklyTrigger;

            string CronExpressionString =
                String.Format("{0} {1} {2} ? * {3} *",
                    startAt.Second,
                    startAt.Minute,
                    startAt.Hour,
                    string.Join(",", weekdays.ToArray()));
            WeeklyTrigger = this.CronTrigger(triggerName, startAt, CronExpressionString);

            /*

                // FIXME: Currently no support for WeeklyIntervalCountValue.
                // I think we'll have to just let it fire once a week, but
                // then silently drop triggers according to the interval
                // schedule. That, or we drop support for it completely.
                // Hate to do that though. I like the idea of "every other
                // monday" for recycling, or "every other friday" for paychecks.

            STILL HAVEN'T SOLVED THE INTERVAL PROBLEM . . . seems like it should be easy.  :(

            WeeklyTrigger = TriggerBuilder.Create()
                .WithIdentity(triggerName)
                .WithCalendarIntervalSchedule(x => x.WithIntervalInWeeks(2))
                .StartAt(startAt)
                .Build();

            WeeklyTrigger = TriggerBuilder.Create()
                .WithIdentity(triggerName)
                .WithCalendarIntervalSchedule(x => x.WithInterval(2, IntervalUnit.Week))
                .StartAt(startAt)
                .Build();
            */

            return WeeklyTrigger;
        }

        //----------------------------------------------------------------------

        public ITrigger MonthlyTrigger(string triggerName, DateTime startAt)
        {
            if (this.MonthlyTypeId == 1) {
                return this.MonthlyTrigger(triggerName, startAt,
                    (int)this.MonthlyDate, (int)this.MonthlyIntervalCount);
            } else {
                return this.MonthlyTrigger(triggerName, startAt, 
                    (int)this.MonthlyOrdinalDay, (int)this.MonthlyDayOfWeek, (int)this.MonthlyIntervalCount);
            }
        }

        //----------------------------------------------------------------------

        public ITrigger MonthlyTrigger(string triggerName, DateTime startAt, int dateValue, int interval)
        {
            // 0 0 12 7 1/3 ? *
            string CronExpressionString =
                String.Format("{0} {1} {2} {3} 1/{4} ? *",
                    startAt.Second,
                    startAt.Minute,
                    startAt.Hour,
                    dateValue,
                    interval);

            return this.CronTrigger(triggerName, startAt, CronExpressionString);
        }

        //----------------------------------------------------------------------

        public ITrigger MonthlyTrigger(string triggerName, DateTime startAt, int ordinalDay, int dayOfWeek, int interval)
        {
            // Day of week
            string DayOfWeek = "";
            switch (dayOfWeek) {
                case 1: DayOfWeek = "MON"; break;
                case 2: DayOfWeek = "TUE"; break;
                case 3: DayOfWeek = "WED"; break;
                case 4: DayOfWeek = "THU"; break;
                case 5: DayOfWeek = "FRI"; break;
                case 6: DayOfWeek = "SAT"; break;
                case 7: DayOfWeek = "SUN"; break;
            }

            // Ordinal week
            string WeekOfMonth = "";
            switch (ordinalDay) {
                case 1: WeekOfMonth = "#1"; break;
                case 2: WeekOfMonth = "#2"; break;
                case 3: WeekOfMonth = "#3"; break;
                case 4: WeekOfMonth = "#4"; break;
                case 5: WeekOfMonth = "L"; break;
            }

            // 0 0 12 ? 1/1 TUE#2 *

            string CronExpressionString =
                String.Format("{0} {1} {2} ? 1/{3} {4}{5} *",
                    startAt.Second,
                    startAt.Minute,
                    startAt.Hour,
                    interval,
                    DayOfWeek,
                    WeekOfMonth);

            return this.CronTrigger(triggerName, startAt, CronExpressionString);
        }

        //----------------------------------------------------------------------

        public ITrigger YearlyTrigger(string triggerName, DateTime startAt)
        {
            if (this.YearlyTypeId == 1) {
                return this.YearlyTrigger(triggerName, startAt,
                    (int)this.YearlyEveryDate, (int)this.YearlyMonth);
            } else {
                return this.YearlyTrigger(triggerName, startAt,
                    (int)this.YearlyDayOfWeek, (int)this.YearlyOrdinalDay, (int)this.YearlyMonth);
            }
        }

        //----------------------------------------------------------------------

        public ITrigger YearlyTrigger(string triggerName, DateTime startAt, int dateValue, int monthValue)
        {
            string CronExpressionString =
                String.Format("{0} {1} {2} {3} {4} ? *",
                    startAt.Second,
                    startAt.Minute,
                    startAt.Hour,
                    dateValue,
                    monthValue);

            return this.CronTrigger(triggerName, startAt, CronExpressionString);
        }

        //----------------------------------------------------------------------

        public ITrigger YearlyTrigger(string triggerName, DateTime startAt, int dayOfWeek, int ordinalWeek, int month)
        {
            // FIXME: fix this copy/paste code (see MonthlyTrigger above)
            // TODO:  consider the Calendar scheduler too, instead of turning everything over to cron

            // Day of week
            string DayOfWeek = "";
            switch (dayOfWeek) {
                case 1: DayOfWeek = "MON"; break;
                case 2: DayOfWeek = "TUE"; break;
                case 3: DayOfWeek = "WED"; break;
                case 4: DayOfWeek = "THU"; break;
                case 5: DayOfWeek = "FRI"; break;
                case 6: DayOfWeek = "SAT"; break;
                case 7: DayOfWeek = "SUN"; break;
            }

            // Ordinal week
            string WeekOfMonth = "";
            switch (ordinalWeek) {
                case 1: WeekOfMonth = "#1"; break;
                case 2: WeekOfMonth = "#2"; break;
                case 3: WeekOfMonth = "#3"; break;
                case 4: WeekOfMonth = "#4"; break;
                case 5: WeekOfMonth = "L"; break;
            }

            // 0 0 12 ? 5 WED#2 *

            string CronExpressionString =
                String.Format("{0} {1} {2} ? {3} {4}{5} *",
                    startAt.Second,
                    startAt.Minute,
                    startAt.Hour,
                    month,
                    DayOfWeek,
                    WeekOfMonth);

            return this.CronTrigger(triggerName, startAt, CronExpressionString);
        }

        //----------------------------------------------------------------------

        public ITrigger CronTrigger(string triggerName, DateTime startAt, string cronTabExpression)
        {
            ITrigger CronTrigger;
            string Debug;

            Debug = String.Format("Scheduled cron job for event {0}, starting at {1}",
                this.ScheduleId, startAt.ToString(Common.DATETIME_FORMAT));
            Timekeeper.Debug(Debug);

            // NOTE: It feels like a cron job should run independently of
            // any given start date. That is, if you set up a cron job,
            // then you set it up and it just runs. Ponder this. (Mostly
            // because this logic could really apply to all these things.
            // Don't lose sight of what Events & Reminders are.)

            CronTrigger = TriggerBuilder.Create()
                .WithIdentity(triggerName)
                .WithCronSchedule(cronTabExpression)
                .StartAt(startAt)
                .Build();

            return CronTrigger;
        }

        //----------------------------------------------------------------------

    }
}
