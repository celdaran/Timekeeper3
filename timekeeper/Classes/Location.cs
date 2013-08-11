using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Location
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;

        private long _LocationId;

        private DateTime _CreateTime;
        private DateTime _ModifyTime;
        private string _LocationGuid;

        private string _Name;
        private string _Description;

        private long _RefTimeZoneId;
        private long _SortOrderNo;
        private bool _IsHidden;
        private bool _IsDeleted;
        private DateTime _HiddenTime;
        private DateTime _DeletedTime;

        private enum Mode { Insert, Update };

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Location()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------

        public Location(long locationId)
        {
            this.Database = Timekeeper.Database;
            this.Load(locationId);
        }

        //----------------------------------------------------------------------
        // Accessors
        //----------------------------------------------------------------------

        public long LocationId { get { return _LocationId; } set { _LocationId = value; } }

        public DateTime CreateTime { get { return _CreateTime;} set { _CreateTime = value;} }
        public DateTime ModifyTime { get { return _ModifyTime;} set { _ModifyTime = value;} }
        public string LocationGuid { get { return _LocationGuid;} set { _LocationGuid = value;} }

        public string Name { get { return _Name;} set { _Name = value;} }
        public string Description { get { return _Description;} set { _Description = value;} }

        public long RefTimeZoneId { get { return _RefTimeZoneId;} set { _RefTimeZoneId = value;} }
        public long SortOrderNo { get { return _SortOrderNo;} set { _SortOrderNo = value;} }
        public bool IsHidden { get { return _IsHidden;} set { _IsHidden = value;} }
        public bool IsDeleted { get { return _IsDeleted;} private set { _IsDeleted = value;} }
        public DateTime HiddenTime { get { return _HiddenTime;} private set { _HiddenTime = value;} }
        public DateTime DeletedTime { get { return _DeletedTime;} private set { _DeletedTime = value;} }

        //----------------------------------------------------------------------

        public bool Create()
        {
            return Upsert(Mode.Insert);
        }

        //----------------------------------------------------------------------

        public bool Delete()
        {
            Row Location = new Row();

            string Now = Common.Now();

            Location["ModifyTime"] = Now;
            Location["DeletedTime"] = Now;
            Location["IsDeleted"] = 1;

            if (Database.Update("Location", Location, "LocationId", this.LocationId) > 0) {

                this.ModifyTime = Convert.ToDateTime(Now);
                this.DeletedTime = Convert.ToDateTime(Now);
                this.IsDeleted = true;

                return true;
            } else {
                return false;
            }
        }

        //----------------------------------------------------------------------

        public static bool Exists(string name)
        {
            name = name.Replace("'", "''");
            string Query = String.Format(@"SELECT count(*) as Count FROM Location WHERE Name = '{0}'", name);
            Row Row = Timekeeper.Database.SelectRow(Query);

            if (Row["Count"] > 0) {
                return true;
            } else {
                return false;
            }
        }

        //----------------------------------------------------------------------

        public void Load(long locationId)
        {
            string Query = String.Format(@"SELECT * FROM Location WHERE LocationId = {0}", locationId);
            Row Location = Database.SelectRow(Query);

            if (Location["LocationId"] != null) {
                this.LocationId = Location["LocationId"];

                this.CreateTime = Location["CreateTime"];
                this.ModifyTime = Location["ModifyTime"];
                this.LocationGuid = Location["LocationGuid"];

                this.Name = Location["Name"];
                this.Description = Location["Description"];

                this.RefTimeZoneId = Location["RefTimeZoneId"];
                this.SortOrderNo = Location["SortOrderNo"];
                this.IsHidden = Location["IsHidden"];
                this.IsDeleted = Location["IsDeleted"];

                if (Location["HiddenTime"] != null)
                    this.HiddenTime = Location["HiddenTime"];
                if (Location["DeletedTime"] != null)
                    this.DeletedTime = Location["DeletedTime"];
            }
        }

        //----------------------------------------------------------------------

        public long Reposition(int index)
        {
            Row Location = new Row();
            Location["SortOrderNo"] = index;
            return Database.Update("Location", Location, "LocationId", this.LocationId);
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            return Upsert(Mode.Update);
        }

        //----------------------------------------------------------------------

        public override string ToString()
        {
            return this.Name;
        }

        //----------------------------------------------------------------------

        private bool Upsert(Mode mode)
        {
            try {
                Row Location = new Row();

                //--------------------------------
                // System-generated Values
                //--------------------------------

                string Now = Common.Now();

                Location["ModifyTime"] = Now;

                if (mode == Mode.Insert) {
                    Location["CreateTime"] = Now;
                    Location["LocationGuid"] = UUID.Get();
                }

                Location["HiddenTime"] = this.IsHidden ? Now : null;
                Location["DeletedTime"] = this.IsDeleted ? Now : null;

                //--------------------------------
                // User-provided Values
                //--------------------------------

                Location["Name"] = this.Name;
                Location["Description"] = this.Description;

                Location["RefTimeZoneId"] = this.RefTimeZoneId;
                Location["SortOrderNo"] = this.SortOrderNo;
                Location["IsHidden"] = this.IsHidden ? 1 : 0;
                Location["IsDeleted"] = this.IsDeleted ? 1 : 0;

                //--------------------------------
                // Update the database
                //--------------------------------

                if (mode == Mode.Insert) {

                    this.LocationId = Database.Insert("Location", Location);

                    if (this.LocationId == 0) {
                        return false;
                    }

                    // Backfill instance with system-generated values
                    this.CreateTime = Convert.ToDateTime(Location["CreateTime"]);
                    this.LocationGuid = Location["LocationGuid"];

                } else {
                    long Count = Database.Update("Location", Location, "LocationId", this.LocationId);

                    if (Count < 1) {
                        return false;
                    }
                }

                // More backfilling
                this.ModifyTime = Convert.ToDateTime(Location["ModifyTime"]);

                if (Location["HiddenTime"] != null)
                    this.HiddenTime = Convert.ToDateTime(Location["HiddenTime"]);
                if (Location["DeletedTime"] != null)
                    this.DeletedTime = Convert.ToDateTime(Location["DeletedTime"]);

                return true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }
        }

        //----------------------------------------------------------------------

    }
}
