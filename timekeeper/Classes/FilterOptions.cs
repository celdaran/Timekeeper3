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

        private string _WhereClause;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long FilterOptionsId { get; private set; }

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

        public List<long> ImpliedActivities { get; set; }
        public List<long> ImpliedProjects { get; set; }

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

                DateRangePreset = (int)Timekeeper.GetValue(Options["RefDatePresetId"], DATE_PRESET_NONE);
                FromDate = (DateTime)Timekeeper.GetValue(Options["FromDate"], DateTime.MinValue);
                ToDate = (DateTime)Timekeeper.GetValue(Options["ToDate"], DateTime.MaxValue);
                MemoContains = (string)Timekeeper.GetValue(Options["Memo"], "");  // TODO: SCHEMA 3.0.0.4 CHANGE MEMO TO MEMOCONTAINS
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
            this.FilterOptionsId = -1;
            this.Upsert();
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
                Options["FromDate"] = FromDate;
                Options["ToDate"] = ToDate;
                Options["Memo"] = MemoContains;  // FIXME: Should be Row["MemoContains"]
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
            DateRangePreset = DATE_PRESET_NONE;
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            MemoContains = null;
            Projects = null;
            Activities = null;
            Locations = null;
            Categories = null;
            DurationOperator = -1;
            DurationAmount = 0;
            DurationUnit = -1;
            ImpliedActivities = null;
            ImpliedProjects = null;
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
            return String.Join(",", list);
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

            WhereClause += String.Format("j.StartTime >= '{0}'",
                this.FromDateToString()) + System.Environment.NewLine;

            WhereClause += String.Format("and j.StopTime <= '{0}'",
                this.ToDateToString()) + System.Environment.NewLine;

            if ((this.ImpliedActivities != null) && (this.ImpliedActivities.Count > 0)) {
                WhereClause += String.Format("and j.ActivityId in ({0})",
                    this.List(this.ImpliedActivities)) + System.Environment.NewLine;
            }
            if ((this.ImpliedProjects != null) && (this.ImpliedProjects.Count > 0)) {
                WhereClause += String.Format("and j.ProjectId in ({0})",
                    this.List(this.ImpliedProjects)) + System.Environment.NewLine;
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
            DateTime Now = DateTime.Now;
            Classes.JournalEntryCollection Entries;

            switch (this.DateRangePreset) {
                case DATE_PRESET_TODAY:
                    this.FromDate = Now;
                    this.ToDate = Now;
                    break;

                case DATE_PRESET_YESTERDAY:
                    this.FromDate = Now.Subtract(new TimeSpan(24, 0, 0));
                    this.ToDate = FromDate;
                    break;

                case DATE_PRESET_PREVIOUS_DAY:
                    Entries = new Classes.JournalEntryCollection(Timekeeper.Database);
                    this.FromDate = Entries.PreviousDay();
                    this.ToDate = this.FromDate;
                    break;

                case DATE_PRESET_THIS_WEEK:
                    int diff = Now.DayOfWeek - DayOfWeek.Monday;
                    this.FromDate = Now.Subtract(new TimeSpan(diff * 24, 0, 0));
                    this.ToDate = Now;
                    break;

                case DATE_PRESET_THIS_MONTH:
                    this.FromDate = DateTime.Parse(Now.Year.ToString() + "/" + Now.Month.ToString() + "/1");
                    this.ToDate = Now;
                    break;

                case DATE_PRESET_LAST_MONTH:
                    int year = Now.Year;
                    int month = Now.Month;
                    if (Now.Month == 1) {
                        year--;
                        month = 12;
                    } else {
                        month--;
                    }
                    this.FromDate = DateTime.Parse(year.ToString() + "/" + month.ToString() + "/1");
                    this.ToDate = DateTime.Parse(year.ToString() + "/" + month.ToString() + "/" + DateTime.DaysInMonth(year, month).ToString());
                    break;

                case DATE_PRESET_THIS_YEAR:
                    this.FromDate = DateTime.Parse(Now.Year.ToString() + "/01/01");
                    this.ToDate = Now;
                    break;

                case DATE_PRESET_LAST_YEAR:
                    year = Now.Year;
                    year--;
                    this.FromDate = DateTime.Parse(year.ToString() + "/01/01");
                    this.ToDate = DateTime.Parse(year.ToString() + "/12/31");
                    break;

                case DATE_PRESET_ALL:
                    Entries = new Classes.JournalEntryCollection(Timekeeper.Database);
                    this.FromDate = Entries.FirstDay();
                    this.ToDate = Entries.LastDay();
                    break;

                default: 
                    // do nothing
                    break;
            }
        }

        //----------------------------------------------------------------------

    }
}
