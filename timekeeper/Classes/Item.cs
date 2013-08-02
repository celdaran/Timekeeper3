using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Item
    {
        //---------------------------------------------------------------------
        // Public Properties
        //---------------------------------------------------------------------

        private long _ItemId;
        private DateTime _CreateTime;
        private DateTime _ModifyTime;
        private string _ItemGuid;

        private string _Name;
        private string _Description;
        private long _ParentId;
        private long _SortOrderNo;
        private long _FollowedItemId;
        private bool _IsFolder;
        private bool _IsFolderOpened;
        private bool _IsHidden;
        private bool _IsDeleted;
        private DateTime _HiddenTime;
        private DateTime _DeletedTime;

        private string _ExternalProjectNo;

        private ItemType _Type;

        // In-memory only
        public DateTime StartTime;

        //---------------------------------------------------------------------
        // Protected Properties
        //---------------------------------------------------------------------

        protected DBI Data;
        protected string TableName;
        protected string IdColumnName;

        //---------------------------------------------------------------------
        // Private Properties
        //---------------------------------------------------------------------

        private string OtherTableName;
        private long SecondsElapsedToday = 0;

        public enum ItemType { Project, Activity };

        //---------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------

        public Item(DBI data, string tableName, string idColumnName)
        {
            this.Data = data;
            this.TableName = tableName;
            this.IdColumnName = idColumnName;
            this.OtherTableName = this.TableName == "Project" ? "Activity" : "Project";

            if (tableName == "Activity") {
                this.Type = ItemType.Activity;
            } else {
                this.Type = ItemType.Project;
            }
        }

        //---------------------------------------------------------------------

        public Item(DBI data, long itemId, string tableName, string idColumnName)
            : this(data, tableName, idColumnName)
        {
            Load(itemId);
        }

        //---------------------------------------------------------------------

        public Item(DBI data, string itemName, string tableName, string idColumnName)
            : this(data, tableName, idColumnName)
        {
            // fetch row from db
            itemName = itemName.Replace("'", "''");

            string query = String.Format(@"
                select {0}
                from {1}
                where Name = '{2}'",
                this.IdColumnName,
                this.TableName,
                itemName);

            Row row = data.SelectRow(query);
            long itemId = row[this.IdColumnName] == null ? 0 : row[this.IdColumnName];

            /*
            Row Row = Timekeeper.DB.SelectRow(query);
            Row Row = App.DB.Insert("table", Row);
            Row Row = TK.DB.SelectRow(query);
            Row Row = Global.DB.Update(query);

            Database.SelectRow(Query);
            Database.Insert("Table", Row);
            Database.Update("Tabble", Row, "Id = Id");
            Database.Begin();
            Database.Commit();
            Database.Rollback();
            Database.TableExists("TableName");
            Database.TablesExist();
            
            */

            Load(itemId);
        }

        //---------------------------------------------------------------------
        // Accessors
        //---------------------------------------------------------------------

        public long     ItemId { get { return _ItemId; } private set { _ItemId = value; } }
        public DateTime CreateTime { get { return _CreateTime; } private set { _CreateTime = value; } }
        public DateTime ModifyTime { get { return _ModifyTime; } private set { _ModifyTime = value; } }
        public string   ItemGuid { get { return _ItemGuid; } private set { _ItemGuid = value; } }

        public string   Name { get { return _Name; } set { _Name = value; } }
        public string   Description { get { return _Description; } set { _Description = value; } }
        public long     ParentId { get { return _ParentId; } set { _ParentId = value; } }
        public long     SortOrderNo { get { return _SortOrderNo; } set { _SortOrderNo = value; } }
        public long     FollowedItemId { get { return _FollowedItemId; } set { _FollowedItemId = value; } }
        public bool     IsFolder { get { return _IsFolder; } set { _IsFolder = value; } }
        public bool     IsFolderOpened { get { return _IsFolderOpened; } set { _IsFolderOpened = value; } }
        public bool     IsHidden { get { return _IsHidden; } set { _IsHidden = value; } }
        public bool     IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }
        public DateTime HiddenTime { get { return _HiddenTime; } set { _HiddenTime = value; } }
        public DateTime DeletedTime { get { return _DeletedTime; } set { _DeletedTime = value; } }

        public string   ExternalProjectNo { get { return _ExternalProjectNo; } set { _ExternalProjectNo = value; } }

        public ItemType Type { get { return _Type; } set { _Type = value; } }

        //---------------------------------------------------------------------
        // Property-Like Methods
        //---------------------------------------------------------------------

        public DateTime DateLastUsed()
        {
            string Query = String.Format(@"
                select max(StopTime) as DateLastUsed
                from Journal
                where {0} = {1}",
                this.IdColumnName, this.ItemId);
            Row Row = Data.SelectRow(Query);
            if (Row["DateLastUsed"] != null) {
                return DateTime.Parse(Row["DateLastUsed"]);
            } else {
                return DateTime.Now;
            }
        }

        //---------------------------------------------------------------------

        public int NumberOfDaysUsed()
        {
            Table Rows = FetchDatesUsed();
            return Rows.Count;
        }

        //---------------------------------------------------------------------

        public List<DateTime> DaysUsed()
        {
            Table Rows = FetchDatesUsed();

            List<DateTime> Days = new List<DateTime>();
            foreach (Row Row in Rows) {
                Days.Add(DateTime.Parse(Row["StartDate"]));
            }

            return Days;
        }

        //---------------------------------------------------------------------

        public bool IsDescendentOf(long itemId)
        {
            string Query = String.Format(@"
                select ParentId from {0} where {1} = '{2}'",
                this.TableName, this.IdColumnName, itemId);
            Row row = Data.SelectRow(Query);

            if (row["ParentId"] == 0) {
                return false;
            } else {
                long ParentId = row["ParentId"];
                if (this.ItemId == ParentId) {
                    return true;
                } else {
                    return IsDescendentOf(ParentId);
                }
            }
        }

        //---------------------------------------------------------------------

        public long RecursiveSecondsElapsed(long itemId, string fromDate, string toDate)
        {
            // get self
            string Query = String.Format(@"
                select sum(Seconds) as Seconds
                from Journal
                where StartTime >= '{0}'
                  and StopTime < '{1}'
                  and {2} = {3}",
                fromDate, toDate, this.IdColumnName, itemId);
            Row Row = this.Data.SelectRow(Query);

            long Seconds = Row["Seconds"] == null ? 0 : Row["Seconds"];

            // get child(ren)
            Query = String.Format(@"
                select {0}
                from {1}
                where ParentId = {2}",
                this.IdColumnName, this.TableName, itemId);
            Table Rows = this.Data.Select(Query);

            foreach (Row Child in Rows) {
                Seconds += RecursiveSecondsElapsed(Child[this.IdColumnName], fromDate, toDate);
            }

            return Seconds;
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        public void Copy(Item source)
        {
            this.ItemId = 0;
            this.Name = source.Name;
            this.Description = source.Description;
            this.ParentId = source.ParentId;
            this.SortOrderNo = source.SortOrderNo;
            this.FollowedItemId = source.FollowedItemId;
            this.IsFolder = source.IsFolder;
            this.IsFolderOpened = source.IsFolderOpened;
            this.IsHidden = source.IsHidden;
            this.HiddenTime = source.HiddenTime;
            this.IsDeleted = source.IsDeleted;
            this.DeletedTime = source.DeletedTime;
            this.ExternalProjectNo = source.ExternalProjectNo;
        }

        //---------------------------------------------------------------------

        public long Create()
        {
            if (Exists(this.Name) == true) {
                return -1;
            }

            Row Row = new Row();

            Row["CreateTime"] = Common.Now();
            Row["ModifyTime"] = Common.Now();
            Row[this.TableName + "Guid"] = UUID.Get();

            Row["Name"] = this.Name;
            Row["Description"] = this.Description;
            Row["ParentId"] = this.ParentId;
            Row["SortOrderNo"] = this.SortOrderNo;
            Row["Last" + OtherTableName + "Id"] = this.FollowedItemId;
            Row["IsFolder"] = this.IsFolder ? 1 : 0;
            Row["IsFolderOpened"] = this.IsFolder ? 1 : 0;
            Row["IsHidden"] = 0;
            Row["IsDeleted"] = 0;
            Row["HiddenTime"] = null;
            Row["DeletedTime"] = null;

            if (this.TableName == "Project") {
                Row["ExternalProjectNo"] = this.ExternalProjectNo ?? UUID.Get();
            }

            this.ItemId = this.Data.Insert(this.TableName, Row);

            if (this.ItemId > 0) {
                // Load the newly-created row
                this.Load(this.ItemId);
            }

            return this.ItemId;
        }

        //---------------------------------------------------------------------

        public long Delete()
        {
            this.IsDeleted = true;
            return SetStatus("Deleted", this.IsDeleted);
        }

        //---------------------------------------------------------------------

        public TimeSpan Elapsed()
        {
            DateTime Now = DateTime.Now;
            return new TimeSpan(Now.Ticks - StartTime.Ticks);
        }

        //---------------------------------------------------------------------

        public TimeSpan ElapsedToday()
        {
            DateTime Now = DateTime.Now;
            Now = Now.AddSeconds(this.SecondsElapsedToday);
            return new TimeSpan(Now.Ticks - StartTime.Ticks);
        }

        //---------------------------------------------------------------------

        public string ElapsedTodayFormatted()
        {
            DateTime midnight = DateTime.Parse("00:00:00");
            midnight = midnight.AddSeconds(this.SecondsElapsedToday);
            TimeSpan ts = new TimeSpan(midnight.Ticks - 0);
            return Timekeeper.FormatTimeSpan(ts);
        }

        //---------------------------------------------------------------------

        public bool Exists()
        {
            return this.Name != "";
        }

        //---------------------------------------------------------------------

        public bool Exists(string name)
        {
            // FIME: You do this everywhere. I'm still not happy with DBI
            // or the fact that I can't parameterize my queries.
            name = name.Replace('\'', '"');

            // see if the name is free
            string Query = String.Format(@"
                select count(*) as Count
                from {0}
                where name = '{1}'", this.TableName, name);

            Row Row = this.Data.SelectRow(Query);
            long Count = Row["Count"];

            if (Count > 0) {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------

        public long Hide()
        {
            this.IsHidden = true;
            return SetStatus("Hidden", this.IsHidden);
        }

        //---------------------------------------------------------------------

        protected void Load(long itemId)
        {
            if (itemId == 0) {
                // Invalid item id
                return;
            }

            // fetch row from db
            string Query = String.Format(@"
                select * from {0}
                where {1} = {2}", this.TableName, this.IdColumnName, itemId);

            Row row = Data.SelectRow(Query);

            this.ItemId = itemId;
            this.CreateTime = row["CreateTime"];
            this.ModifyTime = row["ModifyTime"];
            this.ItemGuid = row[this.TableName + "Guid"];

            this.Name = row["Name"];
            this.Description = row["Description"];
            this.ParentId = row["ParentId"];
            this.SortOrderNo = row["SortOrderNo"];
            this.FollowedItemId = row["Last" + this.OtherTableName + "Id"];
            this.IsFolder = row["IsFolder"];
            this.IsHidden = row["IsHidden"];
            this.IsDeleted = row["IsDeleted"];

            if (row["HiddenTime"] != null)
                this.HiddenTime = row["HiddenTime"];
            if (row["DeletedTime"] != null)
                this.DeletedTime = row["DeletedTime"];

            if (this.TableName == "Project") {
                this.ExternalProjectNo = row["ExternalProjectNo"];
            }

            // Initialize times
            this.SetSecondsElapsedToday();
        }

        //---------------------------------------------------------------------

        public int Redescribe(string newDescription)
        {
            Row Row = new Row();
            Row["Description"] = newDescription;
            Row["ModifyTime"] = Common.Now();
            long Count = Data.Update(this.TableName, Row, this.IdColumnName, this.ItemId);

            if (Count == 1) {
                this.Description = newDescription;
                return Timekeeper.SUCCESS;
            } else {
                return Timekeeper.FAILURE;
            }
        }

        //---------------------------------------------------------------------

        // false = 0 = unsuccessful
        // true = 1 = successful
        // below 0 = unsucessful, but with reason

        public const int ERR_RENAME_EXISTS = -1;
        public const int ERR_RENAME_NULL = -2;
        public const int ERR_RENAME_BLANK = -3;

        public int Rename(string newName)
        {
            // Validation
            if (newName == null) {
                return ERR_RENAME_NULL;
            }

            if (newName.Length == 0) {
                return ERR_RENAME_BLANK;
            }

            if (Exists(newName)) {
                return ERR_RENAME_EXISTS;
            }

            Row Row = new Row();
            Row["Name"] = newName;
            Row["ModifyTime"] = Common.Now();
            long Count = Data.Update(this.TableName, Row, this.IdColumnName, this.ItemId);

            if (Count == 1) {
                this.Name = newName;
                return Timekeeper.SUCCESS;
            } else {
                return Timekeeper.FAILURE;
            }
        }

        //---------------------------------------------------------------------

        public int Reparent(long itemId)
        {
            // Update database
            Row Row = new Row();
            Row["ParentId"] = itemId;
            Row["ModifyTime"] = Common.Now();
            long Count = Data.Update(this.TableName, Row, this.IdColumnName, this.ItemId);

            if (Count == 1) {
                // Update instance
                this.ParentId = itemId;
                return Timekeeper.SUCCESS;
            } else {
                // Otherwise, failure
                return Timekeeper.FAILURE;
            }
        }

        //---------------------------------------------------------------------

        public int Reparent(Item node)
        {
            return this.Reparent(node.ItemId);
        }

        //---------------------------------------------------------------------

        public void StartTiming(DateTime setStartTime)
        {
            // Simply record the time we start
            this.StartTime = setStartTime;

            // Update (in memory) elapsed seconds for today
            this.SetSecondsElapsedToday();
        }

        //---------------------------------------------------------------------

        public int StopTiming(DateTime setStopTime)
        {
            /*
            DateTime StartTime = OldRow["timestamp_s"];
            DateTime StopTime = OldRow["timestamp_e"];
            TimeSpan Delta = StopTime.Subtract(StartTime);
            int DeltaSeconds = Convert.ToInt32(Delta.TotalSeconds);
            */
             
            // Calculate elapsed seconds
            TimeSpan Delta = setStopTime.Subtract(this.StartTime);
            int ElapsedSeconds = Convert.ToInt32(Delta.TotalSeconds);

            // Update (in memory) elapsed seconds for today
            this.SetSecondsElapsedToday(ElapsedSeconds);

            // Return the elapsed time
            return ElapsedSeconds;
        }

        //---------------------------------------------------------------------

        public long Unhide()
        {
            this.IsHidden = false;
            return SetStatus("Hidden", this.IsHidden);
        }

        //---------------------------------------------------------------------
        // Protected Helpers
        //---------------------------------------------------------------------

        protected void SetSecondsElapsedToday()
        {
            SetSecondsElapsedToday(0);
        }

        //---------------------------------------------------------------------

        protected void SetSecondsElapsedToday(long offset)
        {
            try {
                if (!this.Data.TableExists("Journal")) {
                    // If no Journal table exists, don't bother to
                    // fetch any time data. Note: the only place
                    // where this is an issue is during database
                    // creation, because Projects and Activities
                    // can be populated and loaded before the
                    // Journal table has been created.
                    return;
                }

                // fetch seconds from the db for this node
                string today = DateTime.Today.ToString(Common.DATE_FORMAT);
                string midnight = "00:00:00";

                string query = String.Format(@"
                    select sum(Seconds) as Seconds
                    from Journal
                    where StartTime > '{0} {1}'
                      and {2} = {3}",
                    today, midnight, this.IdColumnName, this.ItemId);
                Row row = this.Data.SelectRow(query);

                if (row["Seconds"] > 0) {
                    this.SecondsElapsedToday = row["Seconds"] + offset;
                }
            }
            catch {
                this.SecondsElapsedToday = 0;
            }
        }

        //---------------------------------------------------------------------

        public override string ToString() {
            return this.Name + " (" + this.ItemId.ToString() + ")";
        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        private Table FetchDatesUsed()
        {
            string Query = String.Format(@"
                select 
                    strftime('%Y-%m-%d', StartTime) as StartDate, 
                    count(*) as Count
                from Journal
                where {0} = {1}
                group by StartDate",
                this.IdColumnName, this.ItemId);
            return Data.Select(Query);
        }

        //---------------------------------------------------------------------

        private long SetStatus(string status, bool isSet)
        {
            string BooleanColumnName = "Is" + status;
            string TimeColumnName = status + "Time";

            Row Row = new Row();
            Row[BooleanColumnName] = isSet ? 1 : 0;
            if (isSet) {
                Row[TimeColumnName] = Common.Now();
            } else {
                Row[TimeColumnName] = null;
            }

            return Data.Update(this.TableName, Row, this.IdColumnName, this.ItemId);
        }

        //---------------------------------------------------------------------

    }
}
