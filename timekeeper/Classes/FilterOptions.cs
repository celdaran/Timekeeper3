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

        private string _WhereClause = "";

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long FilterOptionsId { get; set; } // FIXME: set should be private, but I'm experimenting

        public DateTimeOffset CreateTime { get; private set; }
        public DateTimeOffset ModifyTime { get; private set; }

        public OptionsType FilterOptionsType { get; set; }

        public int DateRangePreset { get; set; }
        public DateTimeOffset? FromTime { get; set; }
        public DateTimeOffset? ToTime { get; set; }
        public int MemoOperator { get; set; }
        public string MemoValue { get; set; }
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
        public Timekeeper.Dimension? FilterMergeType { get; set; }
        public bool SuppressTableAlias { get; set; }

        //----------------------------------------------------------------------

        public enum DurationOperators
        {
            Any, 
            GreaterThan, 
            LessThan, 
            EqualTo
        };

        public enum OptionsType
        {
            Journal,
            Notebook,
            Merge,
            Calendar,
            PunchCard,
        };

        public const int DATE_PRESET_NONE = 0;
        public const int DATE_PRESET_TODAY = 1;
        public const int DATE_PRESET_YESTERDAY = 2;
        public const int DATE_PRESET_PREVIOUS_DAY = 3;
        public const int DATE_PRESET_THIS_WEEK = 4;
        public const int DATE_PRESET_LAST_WEEK = 5;
        public const int DATE_PRESET_THIS_MONTH = 6;
        public const int DATE_PRESET_LAST_MONTH = 7;
        public const int DATE_PRESET_THIS_YEAR = 8;
        public const int DATE_PRESET_LAST_YEAR = 9;
        public const int DATE_PRESET_ALL = 10;
        public const int DATE_PRESET_CUSTOM = 11;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public FilterOptions()
        {
            Clear();
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
            this.SuppressTableAlias = false;
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

                if (Options["FilterOptionsId"] == null) {
                    // If requested id not found, clear out everything and bail
                    Clear();
                    return;
                }

                int DbFilterOptionsType = (int)Timekeeper.GetValue(Options["FilterOptionsType"], 1);
                switch (DbFilterOptionsType) {
                    case 1: FilterOptionsType = OptionsType.Journal; break;
                    case 2: FilterOptionsType = OptionsType.Notebook; break;
                    case 3: FilterOptionsType = OptionsType.Merge; break;
                    case 4: FilterOptionsType = OptionsType.Calendar; break;
                }

                DateRangePreset = (int)Timekeeper.GetValue(Options["RefDatePresetId"], DATE_PRESET_ALL);
                FromTime = (DateTimeOffset)Timekeeper.GetValue(Options["FromTime"], null);
                ToTime = (DateTimeOffset)Timekeeper.GetValue(Options["ToTime"], null);
                MemoOperator = (int)Timekeeper.GetValue(Options["MemoOperator"], 0);
                MemoValue = (string)Timekeeper.GetValue(Options["MemoValue"], "");
                Projects = List((string)Timekeeper.GetValue(Options["ProjectList"], ""));
                Activities = List((string)Timekeeper.GetValue(Options["ActivityList"], ""));
                Locations = List((string)Timekeeper.GetValue(Options["LocationList"], ""));
                Categories = List((string)Timekeeper.GetValue(Options["CategoryList"], ""));
                DurationOperator = (int)Timekeeper.GetValue(Options["DurationOperator"], -1);
                DurationAmount = (int)Timekeeper.GetValue(Options["DurationAmount"], 0);
                DurationUnit = (int)Timekeeper.GetValue(Options["DurationUnit"], 0);

                // Actually, if DateRangePreset is anything but Custom, we should
                // recalculate FromTime and ToTime based on the preset and NOT
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
            Timekeeper.Debug("Creating a new FilterOptions row");
            this.FilterOptionsId = -1;
            this.Upsert();
        }

        //---------------------------------------------------------------------

        public void Copy(Classes.FilterOptions that)
        {
            this.FilterOptionsId = that.FilterOptionsId;
            this.CreateTime = that.CreateTime;
            this.ModifyTime = that.ModifyTime;

            this.FilterOptionsType = that.FilterOptionsType;

            this.DateRangePreset = that.DateRangePreset;
            this.FromTime = that.FromTime;
            this.ToTime = that.ToTime;
            this.MemoOperator = that.MemoOperator;
            this.MemoValue = that.MemoValue;
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
            Timekeeper.Debug(String.Format("this.FilterOptionsType={0}, that.FilterOptionsType={1})", this.FilterOptionsType, that.FilterOptionsType));
            Timekeeper.Debug(String.Format("this.DateRangePreset={0}, that.DateRangePreset={1}", this.DateRangePreset, that.DateRangePreset));
            Timekeeper.Debug(String.Format("this.FromTime={0}, that.FromTime={1}", this.FromTime, that.FromTime));
            Timekeeper.Debug(String.Format("this.ToTime={0}, that.ToTime={1}", this.ToTime, that.ToTime));
            Timekeeper.Debug(String.Format("this.MemoOperator={0}, that.MemoOperator={1}", this.MemoOperator, that.MemoOperator));
            Timekeeper.Debug(String.Format("this.MemoValue={0}, that.MemoValue={1}", this.MemoValue, that.MemoValue));
            Timekeeper.Debug(String.Format("this.Projects={0}, that.Projects={1}", String.Join(",", this.Projects), String.Join(",", that.Projects)));
            Timekeeper.Debug(String.Format("this.Activities={0}, that.Activities={1}", String.Join(",", this.Activities), String.Join(",", that.Activities)));
            Timekeeper.Debug(String.Format("this.Locations={0}, that.Locations={1}", String.Join(",", this.Locations), String.Join(",", that.Locations)));
            Timekeeper.Debug(String.Format("this.Categories={0}, that.Categories={1}", String.Join(",", this.Categories), String.Join(",", that.Categories)));
            Timekeeper.Debug(String.Format("this.DurationOperator={0}, that.DurationOperator={1}", this.DurationOperator, that.DurationOperator));
            Timekeeper.Debug(String.Format("this.DurationAmount={0}, that.DurationAmount={1}", this.DurationAmount, that.DurationAmount));
            Timekeeper.Debug(String.Format("this.DurationUnit={0}, that.DurationUnit={1}", this.DurationUnit, that.DurationUnit));
            */

            if (
                    (this.FilterOptionsType == that.FilterOptionsType) &&
                    (this.DateRangePreset == that.DateRangePreset) &&
                    (this.NullableDateTimesEqual(this.FromTime, that.FromTime)) &&
                    (this.NullableDateTimesEqual(this.ToTime, that.ToTime)) &&
                    (this.MemoOperator == that.MemoOperator) &&
                    (this.MemoValue == that.MemoValue) &&
                    (this.SetsEqual(this.Projects, that.Projects)) &&
                    (this.SetsEqual(this.Activities, that.Activities)) &&
                    (this.SetsEqual(this.Locations, that.Locations)) &&
                    (this.SetsEqual(this.Categories, that.Categories)) &&
                    (this.DurationOperator == that.DurationOperator) &&
                    (this.DurationAmount == that.DurationAmount) &&
                    (this.DurationUnit == that.DurationUnit)
                )
                return true;
            else
                return false;
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

        private bool NullableDateTimesEqual(DateTimeOffset? left, DateTimeOffset? right)
        {
            if ((left == null) && (right == null)) {
                return true;
            } else if ((left == null) && (right != null)) {
                return false;
            } else if ((left != null) && (right == null)) {
                return false;
            } else {
                DateTimeOffset ConvertedLeft = (DateTimeOffset)left;
                DateTimeOffset ConvertedRight = (DateTimeOffset)right;
                return (ConvertedLeft.CompareTo(ConvertedRight) == 0);
            }
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

                int DbFilterOptionsType = 0;
                switch (FilterOptionsType) {
                    case OptionsType.Journal: DbFilterOptionsType = 1; break;
                    case OptionsType.Notebook: DbFilterOptionsType = 2; break;
                    case OptionsType.Merge: DbFilterOptionsType = 3; break;
                    case OptionsType.Calendar: DbFilterOptionsType = 4; break;
                }

                Options["FilterOptionsType"] = DbFilterOptionsType;
                Options["RefDatePresetId"] = DateRangePreset;
                Options["FromTime"] = Timekeeper.NullableDateForDatabase(FromTime);
                Options["ToTime"] = Timekeeper.NullableDateForDatabase(ToTime);
                Options["MemoOperator"] = MemoOperator;
                Options["MemoValue"] = MemoValue;
                Options["ProjectList"] = List(Projects);
                Options["ActivityList"] = List(Activities);
                Options["LocationList"] = List(Locations);
                Options["CategoryList"] = List(Categories);
                Options["DurationOperator"] = DurationOperator;
                Options["DurationAmount"] = DurationAmount;
                Options["DurationUnit"] = DurationUnit;

                // TODO: TBX/DBI needs a RowExists and/or Upsert statement
                // MAJOR TODO: I need a real ORM. I hate this stuff.

                Row Count = this.Database.SelectRow(@"
                    select count(*) as Count 
                    from FilterOptions 
                    where FilterOptionsId = " + FilterOptionsId);

                if (Count["Count"] == 0) {
                    Options["CreateTime"] = Timekeeper.DateForDatabase();
                    Options["ModifyTime"] = Timekeeper.DateForDatabase();

                    FilterOptionsId = this.Database.Insert("FilterOptions", Options);
                    if (FilterOptionsId > 0) {
                        CreateTime = Timekeeper.StringToDate(Options["CreateTime"]);
                        ModifyTime = Timekeeper.StringToDate(Options["ModifyTime"]);
                    } else {
                        throw new Exception("Error inserting into FilterOptions");
                    }
                } else {
                    Options["ModifyTime"] = Timekeeper.DateForDatabase();
                    this.Database.Update("FilterOptions", Options, "FilterOptionsId", FilterOptionsId);
                    ModifyTime = Timekeeper.StringToDate(Options["ModifyTime"]);
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
            switch (this.FilterOptionsType) {
                case OptionsType.Journal:
                    Classes.JournalEntryCollection JournalEntries = new JournalEntryCollection();
                    FromTime = JournalEntries.FirstDay();
                    ToTime = JournalEntries.LastDay();
                    break;
                case OptionsType.Notebook:
                    Classes.NotebookEntryCollection NotebookEntries = new NotebookEntryCollection();
                    FromTime = NotebookEntries.FirstDay();
                    ToTime = NotebookEntries.LastDay();
                    break;
            }

            FilterOptionsId = -1;
            FilterOptionsType = 0;
            DateRangePreset = DATE_PRESET_ALL;
            MemoOperator = -1;
            MemoValue = "";
            Projects = new List<long>();
            Activities = new List<long>();
            Locations = new List<long>();
            Categories = new List<long>();
            DurationOperator = -1;
            DurationAmount = 0;
            DurationUnit = 0;
            ImpliedProjects = new List<long>();
            ImpliedActivities = new List<long>();
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

            //Timekeeper.Warn("Filtering still needs some date/time love...");

            string TableAlias = this.SuppressTableAlias ? "" : "j.";

            if ((this.FilterOptionsType == Classes.FilterOptions.OptionsType.Journal) ||
                (this.FilterOptionsType == Classes.FilterOptions.OptionsType.Merge) ||
                (this.FilterOptionsType == Classes.FilterOptions.OptionsType.Calendar) ||
                (this.FilterOptionsType == Classes.FilterOptions.OptionsType.PunchCard))
            {
                WhereClause += String.Format("{0}StartTime >= {1}",
                    TableAlias, this.FormatFromTime()) + System.Environment.NewLine;

                WhereClause += String.Format("and {0}StartTime <= {1}",
                    TableAlias, this.FormatToTime()) + System.Environment.NewLine;
            }

            if (this.FilterOptionsType == Classes.FilterOptions.OptionsType.Notebook) {
                WhereClause += String.Format("{0}EntryTime >= {1}",
                    TableAlias, this.FormatFromTime()) + System.Environment.NewLine;

                WhereClause += String.Format("and {0}EntryTime <= {1}",
                    TableAlias, this.FormatToTime()) + System.Environment.NewLine;
            }

            if (this.FilterOptionsType != Classes.FilterOptions.OptionsType.Notebook)
            {
                if ((this.ImpliedProjects != null) && (this.ImpliedProjects.Count > 0)) {
                    WhereClause += String.Format("and {0}ProjectId in ({1})",
                        TableAlias, this.List(this.ImpliedProjects)) + System.Environment.NewLine;
                }

                if ((this.ImpliedActivities != null) && (this.ImpliedActivities.Count > 0)) {
                    WhereClause += String.Format("and {0}ActivityId in ({1})",
                        TableAlias, this.List(this.ImpliedActivities)) + System.Environment.NewLine;
                }
            }

            if (this.MemoOperator > -1) {

                WhereClause += String.Format("and {0}Memo ", TableAlias);

                switch (this.MemoOperator) {
                    case 0: // Any Value
                        // leave memo value out of this
                        break;
                    case 1: // Contains
                        WhereClause += String.Format("like '%{0}%'", this.MemoValue);
                        break;
                    case 2: // Does Not Contain
                        WhereClause += String.Format("not like '%{0}%'", this.MemoValue);
                        break;
                    case 3: // Begins With
                        WhereClause += String.Format("like '{0}%'", this.MemoValue);
                        break;
                    case 4: // Ends With
                        WhereClause += String.Format("like '%{0}'", this.MemoValue);
                        break;
                    case 5: // Is Empty
                        WhereClause += String.Format("= ''");
                        break;
                    case 6: // Is Not Empty
                        WhereClause += String.Format("<> ''");
                        break;
                }

                WhereClause += System.Environment.NewLine;
            } 

            if (this.DurationOperator > 0) {
                // Meaning, if anything but "Any" was selected

                WhereClause += String.Format("and {0}Seconds ", TableAlias);

                switch (this.DurationOperator) {
                    case 1: WhereClause += " > "; break;
                    case 2: WhereClause += " < "; break;
                    case 3: WhereClause += " = "; break;
                }

                WhereClause += this.Seconds().ToString() + System.Environment.NewLine;
            }

            if ((this.Locations != null) && (this.Locations.Count > 0)) {
                WhereClause += String.Format("and {0}LocationId in ({1})",
                    TableAlias, this.List(this.Locations)) + System.Environment.NewLine;
            }

            if ((this.Categories != null) && (this.Categories.Count > 0)) {
                WhereClause += String.Format("and {0}CategoryId in ({1})",
                    TableAlias, this.List(this.Categories)) + System.Environment.NewLine;
            }

            return WhereClause;
        }

        //----------------------------------------------------------------------

        private string FormatFromTime()
        {
            return FormatTimeRange(this.FromTime, "00:00:00");
        }

        //----------------------------------------------------------------------

        private string FormatToTime()
        {
            return FormatTimeRange(this.ToTime, "23:59:59");
        }

        //----------------------------------------------------------------------

        private string FormatTimeRange(DateTimeOffset? date, string time)
        {
            string FormattedTime;
            if (this.Options.Advanced_Other_MidnightOffset != 0) {
                FormattedTime = String.Format(@"datetime('{0} {1}', '{2} hours')",
                    date.Value.Date.ToString(Timekeeper.DATE_FORMAT),
                    time,
                    this.Options.Advanced_Other_MidnightOffset);
            } else {
                FormattedTime = String.Format(@"'{0} {1}'",
                    date.Value.Date.ToString(Timekeeper.DATE_FORMAT),
                    time);
            }
            return FormattedTime;
        }

        //----------------------------------------------------------------------

        public void SetDateRange()
        {
            DateTimeOffset Today = Timekeeper.LocalNow.Date;
            Classes.JournalEntryCollection Entries;

            switch (this.DateRangePreset) {
                case DATE_PRESET_TODAY:
                    this.FromTime = Today;
                    this.ToTime = Today;
                    break;

                case DATE_PRESET_YESTERDAY:
                    this.FromTime = Today.Subtract(new TimeSpan(24, 0, 0));
                    this.ToTime = this.FromTime;
                    break;

                case DATE_PRESET_PREVIOUS_DAY:
                    Entries = new Classes.JournalEntryCollection();
                    this.FromTime = Entries.PreviousDay();
                    this.ToTime = this.FromTime;
                    break;

                case DATE_PRESET_THIS_WEEK:
                    // TODO: Make the week start day user-definable (e.g., Monday vs. Sunday)
                    // TODO: Make the week length user-definable (e.g., 5 vs. 7)
                    int MondayDelta = Today.DayOfWeek - DayOfWeek.Monday;
                    this.FromTime = Today.Subtract(new TimeSpan(MondayDelta * 24, 0, 0));
                    this.ToTime = FromTime.Value.Add(new TimeSpan(6 * 24, 0, 0));
                    break;

                case DATE_PRESET_LAST_WEEK:
                    int LastMondayDelta = Today.DayOfWeek - DayOfWeek.Monday;
                    this.FromTime = Today.Subtract(new TimeSpan(LastMondayDelta * 24, 0, 0));
                    this.FromTime = FromTime.Value.Subtract(new TimeSpan(7 * 24, 0, 0));
                    this.ToTime = FromTime.Value.Add(new TimeSpan(6 * 24, 0, 0));
                    break;

                case DATE_PRESET_THIS_MONTH:
                    this.FromTime = Timekeeper.StringToDate(Today.Year.ToString() + "/" + Today.Month.ToString() + "/1");
                    this.ToTime = Timekeeper.StringToDate(Today.Year.ToString() + "/" + Today.Month.ToString() + "/" + DateTime.DaysInMonth(Today.Year, Today.Month).ToString());
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
                    this.FromTime = Timekeeper.StringToDate(year.ToString() + "/" + month.ToString() + "/1");
                    this.ToTime = Timekeeper.StringToDate(year.ToString() + "/" + month.ToString() + "/" + DateTime.DaysInMonth(year, month).ToString());
                    break;

                case DATE_PRESET_THIS_YEAR:
                    this.FromTime = Timekeeper.StringToDate(Today.Year.ToString() + "/01/01");
                    this.ToTime = Timekeeper.StringToDate(Today.Year.ToString() + "/12/31");
                    break;

                case DATE_PRESET_LAST_YEAR:
                    year = Today.Year;
                    year--;
                    this.FromTime = Timekeeper.StringToDate(year.ToString() + "/01/01");
                    this.ToTime = Timekeeper.StringToDate(year.ToString() + "/12/31");
                    break;

                case DATE_PRESET_ALL:
                    Entries = new Classes.JournalEntryCollection();
                    this.FromTime = Entries.FirstDay().Date;
                    this.ToTime = Entries.LastDay().Date;
                    break;

                default: 
                    // do nothing
                    break;
            }
        }

        //----------------------------------------------------------------------

    }
}
