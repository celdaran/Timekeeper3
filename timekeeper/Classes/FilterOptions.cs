using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class FilterOptions
    {
        public enum DurationOperators {
            Any, 
            GreaterThan, 
            LessThan, 
            EqualTo
        };

        private DBI Database;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public FilterOptions()
        {
            Clear();
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Auto-Implemented Properties
        //---------------------------------------------------------------------

        private int FilterOptionsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SortOrderNo { get; set; }

        /*
        FilterOptionsId             INTEGER PRIMARY KEY AUTOINCREMENT,
        CreateTime                  DATETIME NOT NULL,
        ModifyTime                  DATETIME NOT NULL,
        Name                        TEXT,
        Description                 TEXT,
        SortOrderNo                 INTEGER,
        */

        public int DateRangePreset { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime StopTime { get; set; }
        public List<long> Activities { get; set; }
        public List<long> Projects { get; set; }
        public string Memo { get; set; }
        public int DurationOperator { get; set; }
        public int DurationAmount { get; set; }
        public int DurationUnit { get; set; }
        public List<long> Locations { get; set; }
        public List<long> Categories { get; set; }
        public List<long> ImpliedActivities { get; set; }
        public List<long> ImpliedProjects { get; set; }
        public int SortBy1 { get; set; }
        public int SortBy2 { get; set; }
        public int SortBy3 { get; set; }

        //---------------------------------------------------------------------
        // Persistence
        //---------------------------------------------------------------------

        public void Load(int filterOptionsId)
        {
            try {
                string Query = @"select * from FilterOptions where FilterOptionsId = " + filterOptionsId;
                Row Row = this.Database.SelectRow(Query);

                FilterOptionsId = filterOptionsId;
                Name = Row["Name"];
                Description = Row["Description"];
                SortOrderNo = Row["SortOrderNo"];
                DateRangePreset = Row["SystemDatePresetId"];
                StartTime = Row["FromDate"];
                StopTime = Row["ToDate"];
                Activities = List(Row["ActivityList"]);
                Projects = List(Row["ProjectList"]);
                Memo = Row["Memo"];
                DurationOperator = Row["DurationOperator"];
                DurationAmount = Row["DurationAmount"];
                DurationUnit = Row["DurationUnit"];
                Locations = List(Row["LocationList"]);
                Categories = List(Row["CategoryList"]);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public void Save()
        {
            try {
                Row Row = new Row();

                Row["Name"] = Name;
                Row["Description"] = Description;
                Row["SortOrderNo"] = SortOrderNo;
                Row["SystemDatePresetId"] = DateRangePreset;
                Row["FromDate"] = StartTime;
                Row["ToDate"] = StopTime;
                Row["ActivityList"] = List(Activities);
                Row["ProjectList"] = List(Projects);
                Row["Memo"] = Memo;
                Row["DurationOperator"] = DurationOperator;
                Row["DurationAmount"] = DurationAmount;
                Row["DurationUnit"] = DurationUnit;
                Row["LocationList"] = List(Locations);
                Row["CategoryList"] = List(Categories);

                Row Count = this.Database.SelectRow(@"
                select count(*) as Count 
                from FilterOptions 
                where FilterOptionsId = " + FilterOptionsId);
                if (Count["Count"] == 0) {
                    Row["FilterOptionsId"] = FilterOptionsId;
                    this.Database.Insert("FilterOptions", Row);
                } else {
                    this.Database.Update("FilterOptions", Row, "FilterOptionsId", FilterOptionsId);
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
            DateRangePreset = -1;
            StartTime = DateTime.Now;
            StopTime = DateTime.Now;
            Activities = null;
            Projects = null;
            Memo = null;
            DurationOperator = -1;
            DurationAmount = 0;
            DurationUnit = -1;
            Locations = null;
            Categories = null;
            ImpliedActivities = null;
            ImpliedProjects = null;
            SortBy1 = 0;
            SortBy2 = -1;
            SortBy3 = -1;
        }

        //---------------------------------------------------------------------

        public string StartTimeToString()
        {
            return StartTime.ToString(Common.DATE_FORMAT) + " 00:00:00";
        }

        //---------------------------------------------------------------------

        public string StopTimeToString()
        {
            return StopTime.ToString(Common.DATE_FORMAT) + " 23:59:59";
        }

        //---------------------------------------------------------------------

        public List<long> List(string list)
        {
            // Convert a comma-delimited list of numeric strings 
            // to a List of longs. For example: "2,3,5,7,11" becomes
            // the collection: (2,3,5,7,11).
            string[] StringItems = list.Split(',');
            List<long> Items = new List<long>();
            foreach (string StringItem in StringItems) {
                Items.Add(Convert.ToInt64(StringItem));
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

        //---------------------------------------------------------------------

    }
}
