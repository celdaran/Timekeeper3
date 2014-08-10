using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Timekeeper
{
    //---------------------------------------------------------------------
    // A structure to hold simple int/string pairings
    //---------------------------------------------------------------------

    public struct IdValuePair
    {
        public int Id;
        public string Description;

        public IdValuePair(int id, string description)
        {
            this.Id = id;
            this.Description = description;
        }

        public override string ToString()
        {
            return this.Description;
        }
    }

    //---------------------------------------------------------------------
    // A structure to hold simple int/object pairings
    //---------------------------------------------------------------------

    public struct IdObjectPair
    {
        public int Id;
        public object Object;

        public IdObjectPair(int id, object o)
        {
            this.Id = id;
            this.Object = o;
        }

        public override string ToString()
        {
            return this.Object.ToString();
        }
    }

    //---------------------------------------------------------------------
    // A structure to hold simple name/object pairings
    //---------------------------------------------------------------------

    public struct NameObjectPair
    {
        public string Name;
        public object Object;

        public NameObjectPair(string s, object o)
        {
            this.Name = s;
            this.Object = o;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }

    //---------------------------------------------------------------------
    // Base Class for File New/Upgrade Options
    //---------------------------------------------------------------------

    public class FileBaseOptions
    {
        private string _LocationName;
        private string _LocationDescription;
        private long _LocationTimeZoneId;
        private TimeZoneInfo _LocationTimeZoneInfo;

        //---------------------------------------------------------------------
        // Accessors
        //---------------------------------------------------------------------

        public string LocationName
        {
            get { return _LocationName; }
            set { _LocationName = value; }
        }

        //---------------------------------------------------------------------

        public string LocationDescription
        {
            get { return _LocationDescription; }
            set { _LocationDescription = value; }
        }

        //---------------------------------------------------------------------

        public long LocationTimeZoneId
        {
            get { return _LocationTimeZoneId; }
            set { _LocationTimeZoneId = value; }
        }

        //---------------------------------------------------------------------

        public TimeZoneInfo LocationTimeZoneInfo
        {
            get { return _LocationTimeZoneInfo; }
            set { _LocationTimeZoneInfo = value; }
        }

    }

    //---------------------------------------------------------------------
    // Structure to hold File Creation Options
    //---------------------------------------------------------------------

    public class FileCreateOptions : FileBaseOptions
    {
        public string FileName { get; set; }
        public bool UseProjects { get; set; }
        public bool UseActivities { get; set; }
        public bool UseLocations { get; set; }
        public bool UseCategories { get; set; }
        public int ItemPreset { get; set; }
    }

    //---------------------------------------------------------------------
    // Structure to hold File Upgrade Options
    //---------------------------------------------------------------------

    public class FileUpgradeOptions : FileBaseOptions
    {
        private int _MemoMergeTypeId;

        //---------------------------------------------------------------------
        // Accessors
        //---------------------------------------------------------------------

        public int MemoMergeTypeId
        {
            get { return _MemoMergeTypeId; }
            set { _MemoMergeTypeId = value; }
        }
    }

    //---------------------------------------------------------------------
    // Next Big Thing
    //---------------------------------------------------------------------

}
