//------------------------------------------------------------------------------
// Timekeeper.Classes.FilterOptions
// Persistence Class for Generalized Timekeeper Filtering
// Copyright © 1999-2014 by Charlie Hills
// Published by Technitivity, a division of Lockshire Media, LLC.
//------------------------------------------------------------------------------
// DESCRIPTION
//
// This class provides a common accessor and persistence interface for Filter
// Options within Timekeeper. It is not meant to be instantiated directly within 
// the project except by other Options classes (specifically BaseOptions).
//
//------------------------------------------------------------------------------
// LICENCE
//
// This file is part of Timekeeper, hereafter known as "the Software."
// The software is maintained by Charlie Hills and Lockshire Media, LLC, 
// hereafter known as "the Licensor."
//
// Timekeeper is freeware (but not free software, though, on a case by case
// basis, the sources may be shared upon request). The Software is provided free
// of charge and you may freely distribute the software. You may not sell the
// Software or directly profit from it in any way.
//
// The Software is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. In no event will the Licensor be liable for any 
// damages, claims or costs whatsoever or any consequential, indirect, 
// incidental damages, or any lost profits or lost savings, even if the Licensor
// has been advised of the possibility of such loss, damages, claims or costs or
// for any claim by any third party.
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class FilterOptions
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private Classes.Options Options;
        private Classes.JournalEntryCollection JournalEntries;

        private string _WhereClause;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long FilterOptionsId { get; set; } // FIXME: set should be private, but I'm experimenting

        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }

        public int DateRangePreset { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string MemoContains { get; set; }
        public List<long> Projects { get; set; }
        public List<long> Activities { get; set; }
        public List<long> Locations { get; set; }
        public List<long> Categories { get; set; }
        public int DurationOperator { get; set; }
        public int DurationAmount { get; set; }
        public int DurationUnit { get; set; }

        public List<long> ImpliedProjects { get; set; }
        public List<long> ImpliedActivities { get; set; }

        public bool Changed { get; set; }

        //----------------------------------------------------------------------

        public enum DurationOperators
        {
            Any, 
            GreaterThan, 
            LessThan, 
            EqualTo
        };

        public const int DATE_PRESET_NONE = 0;
        public const int DATE_PRESET_TODAY = 1;
        public const int DATE_PRESET_YESTERDAY = 2;
        public const int DATE_PRESET_PREVIOUS_DAY = 3;
        public const int DATE_PRESET_THIS_WEEK = 4;
        public const int DATE_PRESET_THIS_MONTH = 5;
        public const int DATE_PRESET_LAST_MONTH = 6;
        public const int DATE_PRESET_THIS_YEAR = 7;
        public const int DATE_PRESET_LAST_YEAR = 8;
        public const int DATE_PRESET_ALL = 9;
        public const int DATE_PRESET_CUSTOM = 10;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public FilterOptions()
        {
            Clear();
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
            this.JournalEntries = new Classes.JournalEntryCollection();
        }

        //---------------------------------------------------------------------

        public FilterOptions(long filterOptionsId) : this()
        {
            FilterOptionsId = filterOptionsId;
            this.Load(filterOptionsId);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public void Load(long filterOptionsId)
        {
            try {
                string Query = @"select * from FilterOptions where FilterOptionsId = " + filterOptionsId;
                Row Options = this.Database.SelectRow(Query);

                DateRangePreset = (int)Timekeeper.GetValue(Options["RefDatePresetId"], DATE_PRESET_ALL);
                FromDate = (DateTime)Timekeeper.GetValue(Options["FromDate"], DateTime.MinValue);
                ToDate = (DateTime)Timekeeper.GetValue(Options["ToDate"], DateTime.MaxValue);
                MemoContains = (string)Timekeeper.GetValue(Options["MemoContains"], "");
                Projects = List((string)Timekeeper.GetValue(Options["ProjectList"], ""));
                Activities = List((string)Timekeeper.GetValue(Options["ActivityList"], ""));
                Locations = List((string)Timekeeper.GetValue(Options["LocationList"], ""));
                Categories = List((string)Timekeeper.GetValue(Options["CategoryList"], ""));
                DurationOperator = (int)Timekeeper.GetValue(Options["DurationOperator"], -1);
                DurationAmount = (int)Timekeeper.GetValue(Options["DurationAmount"], 0);
                DurationUnit = (int)Timekeeper.GetValue(Options["DurationUnit"], 0);

                // Actually, if DateRangePreset is anything but Custom, we should
                // recalculate FromDate and ToDate based on the preset and NOT
                // use whatever From/To date values were stored.
                if (DateRangePreset != DATE_PRESET_CUSTOM) {
                    SetDateRange();
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public void Create()
        {
            Common.Info("Creating a new FilterOptions row");
            this.FilterOptionsId = -1;
            this.Upsert();
        }

        //---------------------------------------------------------------------

        public void Copy(Classes.FilterOptions that)
        {
            this.FilterOptionsId = that.FilterOptionsId;
            this.CreateTime = that.CreateTime;
            this.ModifyTime = that.ModifyTime;

            this.DateRangePreset = that.DateRangePreset;
            this.FromDate = that.FromDate;
            this.ToDate = that.ToDate;
            this.MemoContains = that.MemoContains;
            this.Projects = that.Projects;
            this.Activities = that.Activities;
            this.Locations = that.Locations;
            this.Categories = that.Categories;
            this.DurationOperator = that.DurationOperator;
            this.DurationAmount = that.DurationAmount;
            this.DurationUnit = that.DurationUnit;
            this.ImpliedProjects = that.ImpliedProjects;
            this.ImpliedActivities = that.ImpliedActivities;

            this.Changed = false;
        }

        //---------------------------------------------------------------------

        public bool Equals(Classes.FilterOptions that)
        {
            /*
            Timekeeper.Debug(String.Format("this.DateRangePreset={0}, that.DateRangePreset={1}", this.DateRangePreset, that.DateRangePreset));
            Timekeeper.Debug(String.Format("this.FromDate={0}, that.FromDate={1}", this.FromDate, that.FromDate));
            Timekeeper.Debug(String.Format("this.ToDate={0}, that.ToDate={1}", this.ToDate, that.ToDate));
            Timekeeper.Debug(String.Format("this.MemoContains={0}, that.MemoContains={1}", this.MemoContains, that.MemoContains));
            Timekeeper.Debug(String.Format("this.Projects={0}, that.Projects={1}", String.Join(",", this.Projects), String.Join(",", that.Projects)));
            Timekeeper.Debug(String.Format("this.Activities={0}, that.Activities={1}", String.Join(",", this.Activities), String.Join(",", that.Activities)));
            Timekeeper.Debug(String.Format("this.Locations={0}, that.Locations={1}", String.Join(",", this.Locations), String.Join(",", that.Locations)));
            Timekeeper.Debug(String.Format("this.Categories={0}, that.Categories={1}", String.Join(",", this.Categories), String.Join(",", that.Categories)));
            Timekeeper.Debug(String.Format("this.DurationOperator={0}, that.DurationOperator={1}", this.DurationOperator, that.DurationOperator));
            Timekeeper.Debug(String.Format("this.DurationAmount={0}, that.DurationAmount={1}", this.DurationAmount, that.DurationAmount));
            Timekeeper.Debug(String.Format("this.DurationUnit={0}, that.DurationUnit={1}", this.DurationUnit, that.DurationUnit));
            */

            if (
                (this.DateRangePreset == that.DateRangePreset) &&
                (this.FromDate == that.FromDate) &&
                (this.ToDate == that.ToDate) &&
                (this.MemoContains == that.MemoContains) &&
                (this.SetsEqual(this.Projects, that.Projects)) &&
                (this.SetsEqual(this.Activities, that.Activities)) &&
                (this.SetsEqual(this.Locations, that.Locations)) &&
                (this.SetsEqual(this.Categories, that.Categories)) &&
                (this.DurationOperator == that.DurationOperator) &&
                (this.DurationAmount == that.DurationAmount) &&
                (this.DurationUnit == that.DurationUnit))
            {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------
        // Find a home for this. Just testing for now.
        //---------------------------------------------------------------------

        private bool SetsEqual(List<long> left, List<long> right)
        {
            if (left.Count != right.Count)
                return false;

            Dictionary<long, long> Dictionary = new Dictionary<long, long>();

            foreach (long Member in left) {
                if (Dictionary.ContainsKey(Member) == false)
                    Dictionary[Member] = 1;
                else
                    Dictionary[Member]++;
            }

            foreach (long Member in right) {
                if (Dictionary.ContainsKey(Member) == false)
                    return false;
                else
                    Dictionary[Member]--;
            }

            foreach (KeyValuePair<long, long> Pair in Dictionary) {
                if (Pair.Value != 0)
                    return false;
            }

            return true;
        }

        //---------------------------------------------------------------------

        public void Save()
        {
            this.Upsert();
        }

        //---------------------------------------------------------------------

        private void Upsert()
        {
            try {
                Row Options = new Row();

                Options["RefDatePresetId"] = DateRangePreset;
                Options["FromDate"] = FromDate.ToString(Common.DATETIME_FORMAT);
                Options["ToDate"] = ToDate.ToString(Common.DATETIME_FORMAT);
                Options["MemoContains"] = MemoContains;
                Options["ProjectList"] = List(Projects);
                Options["ActivityList"] = List(Activities);
                Options["LocationList"] = List(Locations);
                Options["CategoryList"] = List(Categories);
                Options["DurationOperator"] = DurationOperator;
                Options["DurationAmount"] = DurationAmount;
                Options["DurationUnit"] = DurationUnit;

                // TODO: TBX/DBI needs a RowExists and/or Upsert statement

                Row Count = this.Database.SelectRow(@"
                    select count(*) as Count 
                    from FilterOptions 
                    where FilterOptionsId = " + FilterOptionsId);

                if (Count["Count"] == 0) {
                    Options["CreateTime"] = Common.Now();
                    Options["ModifyTime"] = Common.Now();

                    FilterOptionsId = this.Database.Insert("FilterOptions", Options);
                    if (FilterOptionsId > 0) {
                        CreateTime = Convert.ToDateTime(Options["CreateTime"]);
                        ModifyTime = Convert.ToDateTime(Options["ModifyTime"]);
                    } else {
                        throw new Exception("Error inserting into FilterOptions");
                    }
                } else {
                    Options["ModifyTime"] = Common.Now();
                    this.Database.Update("FilterOptions", Options, "FilterOptionsId", FilterOptionsId);
                    ModifyTime = Convert.ToDateTime(Options["ModifyTime"]);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        public void Clear()
        {
            FilterOptionsId = -1;
            DateRangePreset = DATE_PRESET_ALL;
            FromDate = DateTime.UtcNow.Date;
            ToDate = DateTime.UtcNow.Date;
            MemoContains = null;
            Projects = null;
            Activities = null;
            Locations = null;
            Categories = null;
            DurationOperator = -1;
            DurationAmount = 0;
            DurationUnit = 0;
            ImpliedProjects = null;
            ImpliedActivities = null;
        }

        //---------------------------------------------------------------------

        public string FromDateToString()
        {
            return FromDate.ToString(Common.DATE_FORMAT) + " 00:00:00";
        }

        //---------------------------------------------------------------------

        public string ToDateToString()
        {
            return ToDate.ToString(Common.DATE_FORMAT) + " 23:59:59";
        }

        //---------------------------------------------------------------------

        public List<long> List(string list)
        {
            // Convert a comma-delimited list of numeric strings 
            // to a List of longs. For example: "2,3,5,7,11" becomes
            // the collection: (2,3,5,7,11).
            List<long> Items = new List<long>();

            if (list.Length > 0) {
                string[] StringItems = list.Split(',');
                foreach (string StringItem in StringItems) {
                    Items.Add(Convert.ToInt64(StringItem));
                }
            }

            return Items;
        }

        //---------------------------------------------------------------------

        public string List(List<long> list)
        {
            // The reverse of the above.
            // TODO: These two could be promoted to
            // either the Timekeeper or Toolbox level.
            return list == null ? "" : String.Join(",", list);
        }

        //---------------------------------------------------------------------

        public int Seconds()
        {
            switch (DurationUnit) {
                // Minutes
                case 0: return DurationAmount * 60;
                // Hours
                case 1: return DurationAmount * 60 * 60;
            }
            return 0;
        }

        //----------------------------------------------------------------------

        public string WhereClause
        {
            get {
                this._WhereClause = GenerateWhereClause();
                return this._WhereClause;
            }
        }

        //----------------------------------------------------------------------

        private string GenerateWhereClause()
        {
            string WhereClause = "";

            WhereClause += String.Format("datetime(j.StartTime, 'localtime') >= datetime('{0}')",
                this.FromDateToString()) + System.Environment.NewLine;

            WhereClause += String.Format("and datetime(j.StopTime, 'localtime') <= datetime('{0}')",
                this.ToDateToString()) + System.Environment.NewLine;

            if ((this.ImpliedProjects != null) && (this.ImpliedProjects.Count > 0)) {
                WhereClause += String.Format("and j.ProjectId in ({0})",
                    this.List(this.ImpliedProjects)) + System.Environment.NewLine;
            }

            if ((this.ImpliedActivities != null) && (this.ImpliedActivities.Count > 0)) {
                WhereClause += String.Format("and j.ActivityId in ({0})",
                    this.List(this.ImpliedActivities)) + System.Environment.NewLine;
            }

            if ((this.MemoContains != null) && (this.MemoContains != "")) {
                WhereClause += String.Format("and j.Memo like '%{0}%'", this.MemoContains) + System.Environment.NewLine;
            }

            if (this.DurationOperator > 0) {
                // Meaning, if anything but "Any" was selected

                WhereClause += "and j.Seconds ";

                switch (this.DurationOperator) {
                    case 1: WhereClause += " > "; break;
                    case 2: WhereClause += " < "; break;
                    case 3: WhereClause += " = "; break;
                }

                WhereClause += this.Seconds().ToString() + System.Environment.NewLine;
            }

            if ((this.Locations != null) && (this.Locations.Count > 0)) {
                WhereClause += String.Format("and j.LocationId in ({0})",
                    this.List(this.Locations)) + System.Environment.NewLine;
            }

            if ((this.Categories != null) && (this.Categories.Count > 0)) {
                WhereClause += String.Format("and j.CategoryId in ({0})",
                    this.List(this.Categories)) + System.Environment.NewLine;
            }

            return WhereClause;
        }

        //----------------------------------------------------------------------

        public void SetDateRange()
        {
            DateTime Today = DateTime.UtcNow.Date;
            Classes.JournalEntryCollection Entries;

            switch (this.DateRangePreset) {
                case DATE_PRESET_TODAY:
                    this.FromDate = Today;
                    this.ToDate = Today;
                    break;

                case DATE_PRESET_YESTERDAY:
                    this.FromDate = Today.Subtract(new TimeSpan(24, 0, 0));
                    this.ToDate = this.FromDate;
                    break;

                case DATE_PRESET_PREVIOUS_DAY:
                    Entries = new Classes.JournalEntryCollection();
                    this.FromDate = Entries.PreviousDay();
                    this.ToDate = this.FromDate;
                    break;

                case DATE_PRESET_THIS_WEEK:
                    // TODO: Make the week start day user-definable (e.g., Monday vs. Sunday)
                    // FIXME: You've defined "THIS WEEK" as "THIS WORK WEEK"
                    int MondayDelta = Today.DayOfWeek - DayOfWeek.Monday;
                    this.FromDate = Today.Subtract(new TimeSpan(MondayDelta * 24, 0, 0));
                    int FridayDelta = DayOfWeek.Friday - Today.DayOfWeek;
                    this.ToDate = Today.Add(new TimeSpan(FridayDelta * 24, 0, 0));
                    break;

                case DATE_PRESET_THIS_MONTH:
                    this.FromDate = DateTime.Parse(Today.Year.ToString() + "/" + Today.Month.ToString() + "/1");
                    this.ToDate = DateTime.Parse(Today.Year.ToString() + "/" + Today.Month.ToString() + "/" + DateTime.DaysInMonth(Today.Year, Today.Month).ToString());
                    break;

                case DATE_PRESET_LAST_MONTH:
                    int year = Today.Year;
                    int month = Today.Month;
                    if (Today.Month == 1) {
                        year--;
                        month = 12;
                    } else {
                        month--;
                    }
                    this.FromDate = DateTime.Parse(year.ToString() + "/" + month.ToString() + "/1");
                    this.ToDate = DateTime.Parse(year.ToString() + "/" + month.ToString() + "/" + DateTime.DaysInMonth(year, month).ToString());
                    break;

                case DATE_PRESET_THIS_YEAR:
                    this.FromDate = DateTime.Parse(Today.Year.ToString() + "/01/01");
                    this.ToDate = DateTime.Parse(Today.Year.ToString() + "/12/31");
                    break;

                case DATE_PRESET_LAST_YEAR:
                    year = Today.Year;
                    year--;
                    this.FromDate = DateTime.Parse(year.ToString() + "/01/01");
                    this.ToDate = DateTime.Parse(year.ToString() + "/12/31");
                    break;

                case DATE_PRESET_ALL:
                    Entries = new Classes.JournalEntryCollection();
                    this.FromDate = Entries.FirstDay().Date;
                    this.ToDate = Entries.LastDay().Date;
                    break;

                default: 
                    // do nothing
                    break;
            }
        }

        //----------------------------------------------------------------------

    }
}
