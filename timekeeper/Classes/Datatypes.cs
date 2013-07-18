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
    // Structure to hold File Creation Options
    //---------------------------------------------------------------------

    public struct FileCreateOptions
    {
        private string _FileName;
        private bool _UseProjects;
        private bool _UseActivities;
        private int _ItemPreset;
        private string _LocationName;
        private string _LocationDescription;
        private int _LocationTimeZoneId;
        private TimeZoneInfo _LocationTimeZoneInfo;

        //---------------------------------------------------------------------
        // Accessors
        //---------------------------------------------------------------------

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        //---------------------------------------------------------------------

        public bool UseProjects
        {
            get { return _UseProjects; }
            set { _UseProjects = value; }
        }

        //---------------------------------------------------------------------

        public bool UseActivities
        {
            get { return _UseActivities; }
            set { _UseActivities = value; }
        }

        //---------------------------------------------------------------------

        public int ItemPreset
        {
            get { return _ItemPreset; }
            set { _ItemPreset = value; }
        }

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

        public int LocationTimeZoneId
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
    // Structure to hold File Upgrade Options
    //---------------------------------------------------------------------

    public struct FileUpgradeOptions
    {
        private string _LocationName;
        private string _LocationDescription;
        private int _LocationTimeZoneId;
        private TimeZoneInfo _LocationTimeZoneInfo;
        private int _MemoMergeTypeId;

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

        public int LocationTimeZoneId
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

        //---------------------------------------------------------------------

        public int MemoMergeTypeId
        {
            get { return _MemoMergeTypeId; }
            set { _MemoMergeTypeId = value; }
        }
    }

    //---------------------------------------------------------------------
    // Structure to hold File Upgrade Options
    //---------------------------------------------------------------------

}
