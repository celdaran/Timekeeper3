using System;
using System.Collections.Generic;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    public class TreeAttribute
    {
        //---------------------------------------------------------------------
        // Public Properties
        //---------------------------------------------------------------------

        // Common properties
        public long ItemId { get; set; }
        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public string ItemGuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? ParentId { get; set; }
        public long SortOrderNo { get; set; }
        public bool IsFolder { get; set; }
        public bool IsFolderOpened { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? HiddenTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }

        // Table-specific properties
        public long? LastActivityId { get; set; }        // used by Project
        public long? LastLocationId { get; set; }        // used by Project
        public long? LastCategoryId { get; set; }        // used by Project
        public string ExternalProjectNo { get; set; }    // used by Project
        public DateTimeOffset? StartTime { get; set; }   // used by Project
        public DateTimeOffset? DueTime { get; set; }     // used by Project
        public long? Estimate { get; set; }              // used by Project
        public long? RefTimeZoneId { get; set; }         // used by Location

        public Timekeeper.Dimension Dimension { get; set; }

        // In-memory only
        public DateTimeOffset TimerStartedTime;

        //---------------------------------------------------------------------
        // Protected Properties
        //---------------------------------------------------------------------

        protected DBI Database;
        protected string TableName;
        protected string IdColumnName;

        //---------------------------------------------------------------------
        // Private Properties
        //---------------------------------------------------------------------

        private long SecondsElapsedToday = 0;

        //---------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------

        public TreeAttribute(string tableName, string idColumnName)
        {
            this.Database = Timekeeper.Database;
            this.TableName = tableName;
            this.IdColumnName = idColumnName;

            // Convert the table name into the enumerated dimension
            this.Dimension = (Timekeeper.Dimension)Enum.Parse(typeof(Timekeeper.Dimension), tableName);
        }

        //---------------------------------------------------------------------

        public TreeAttribute(long itemId, string tableName, string idColumnName)
            : this(tableName, idColumnName)
        {
            Load(itemId);
        }

        //---------------------------------------------------------------------

        public TreeAttribute(long? itemId, string tableName, string idColumnName)
            : this(tableName, idColumnName)
        {
            // Convert nulls to 0.
            long ItemId = itemId.HasValue ? itemId.Value : 0;
            Load(ItemId);
        }

        //---------------------------------------------------------------------

        public TreeAttribute(string itemName, string tableName, string idColumnName)
            : this(tableName, idColumnName)
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

            Row row = this.Database.SelectRow(query);
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
        // Property-Like Methods
        //---------------------------------------------------------------------

        public DateTimeOffset DateLastUsed()
        {
            string Query = String.Format(@"
                select max(StopTime) as DateLastUsed
                from Journal
                where {0} = {1}",
                this.IdColumnName, this.ItemId);
            Row Row = Database.SelectRow(Query);
            if (Row["DateLastUsed"] != null) {
                return Timekeeper.StringToDate(Row["DateLastUsed"]);
            } else {
                return Timekeeper.LocalNow;
            }
        }

        //---------------------------------------------------------------------

        public string DisplayName()
        {
            string DisplayName = this.Name;

            // FIXME: Options control whether this happens or not,
            // and if it happens, how it will be formatted. I'm 
            // not sure how to get UI options at this layer of
            // the codebase.  :-/

            if (this.Dimension == Timekeeper.Dimension.Project) {
                if (1 == 1) { // Option check here
                    if (this.ExternalProjectNo != null) {
                        DisplayName = this.ExternalProjectNo + " - " + this.Name;
                    }
                }
            }

            return DisplayName;
        }

        //---------------------------------------------------------------------

        public int NumberOfDaysUsed()
        {
            Table Rows = FetchDatesUsed();
            return Rows.Count;
        }

        //---------------------------------------------------------------------

        public List<DateTimeOffset> DaysUsed()
        {
            Table Rows = FetchDatesUsed();

            List<DateTimeOffset> Days = new List<DateTimeOffset>();
            foreach (Row Row in Rows) {
                Days.Add(DateTimeOffset.Parse(Row["StartDate"]));
            }

            return Days;
        }

        //---------------------------------------------------------------------

        public bool IsDescendentOf(long itemId)
        {
            string Query = String.Format(@"
                select ParentId from {0} where {1} = '{2}'",
                this.TableName, this.IdColumnName, itemId);
            Row row = Database.SelectRow(Query);

            if (row["ParentId"] == null) {
                return false;
            } else {
                long ParentId = row["ParentId"].Value;
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
                where StartTime >= datetime('{0}', '{4} hours')
                  and StartTime < datetime('{1}', '{4} hours')
                  and {2} = {3}",
                fromDate, toDate, this.IdColumnName, itemId,
                Timekeeper.Options.Advanced_Other_MidnightOffset);
            Row Row = this.Database.SelectRow(Query);

            long Seconds = Row["Seconds"] == null ? 0 : Row["Seconds"];

            // get child(ren)
            Query = String.Format(@"
                select {0}
                from {1}
                where ParentId = {2}",
                this.IdColumnName, this.TableName, itemId);
            Table Rows = this.Database.Select(Query);

            foreach (Row Child in Rows) {
                Seconds += RecursiveSecondsElapsed(Child[this.IdColumnName], fromDate, toDate);
            }

            return Seconds;
        }

        //----------------------------------------------------------------------

        public Classes.TreeAttribute Parent
        {
            get {
                return new Classes.TreeAttribute(this.ParentId, this.TableName, this.IdColumnName);
            }
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        public void CloseFolder()
        {
            ChangeFolderOpenState(false);
        }

        //---------------------------------------------------------------------

        public void Copy(TreeAttribute source)
        {
            this.ItemId = 0;
            this.Name = source.Name;
            this.Description = source.Description;
            this.ParentId = source.ParentId;
            this.SortOrderNo = source.SortOrderNo;
            this.IsFolder = source.IsFolder;
            this.IsFolderOpened = source.IsFolderOpened;
            this.IsHidden = source.IsHidden;
            this.HiddenTime = source.HiddenTime;
            this.IsDeleted = source.IsDeleted;
            this.DeletedTime = source.DeletedTime;

            this.LastActivityId = source.LastActivityId;
            this.LastLocationId = source.LastLocationId;
            this.LastCategoryId = source.LastCategoryId;
            this.ExternalProjectNo = source.ExternalProjectNo;
            this.StartTime = source.StartTime;
            this.DueTime = source.DueTime;
            this.Estimate = source.Estimate;
            this.RefTimeZoneId = source.RefTimeZoneId;
        }

        //---------------------------------------------------------------------

        // convert a null to 0 in a nullable value
        private long? FixMe(long? value)
        {
            if (value.HasValue)
                if (value.Value != 0)
                    return value.Value;
                else
                    return null;
            else
                return null;
        }

        public long Create()
        {
            if (Exists(this.Name) == true) {
                return -1;
            }

            Row Row = new Row();

            Row["CreateTime"] = Timekeeper.DateForDatabase();
            Row["ModifyTime"] = Timekeeper.DateForDatabase();
            Row[this.TableName + "Guid"] = UUID.Get();

            Row["Name"] = this.Name;
            Row["Description"] = this.Description;
            Row["ParentId"] = FixMe(this.ParentId);
            Row["SortOrderNo"] = Timekeeper.GetNextSortOrderNo(this.TableName, this.ParentId);
            Row["IsFolder"] = this.IsFolder ? 1 : 0;
            Row["IsFolderOpened"] = this.IsFolder ? 1 : 0;
            Row["IsHidden"] = 0;
            Row["IsDeleted"] = 0;
            Row["HiddenTime"] = null;
            Row["DeletedTime"] = null;

            if (this.Dimension == Timekeeper.Dimension.Project) {
                Row["LastActivityId"] = this.LastActivityId;
                Row["LastLocationId"] = this.LastLocationId;
                Row["LastCategoryId"] = this.LastCategoryId;
                Row["ExternalProjectNo"] = this.ExternalProjectNo;
                Row["StartTime"] = this.StartTime;
                Row["DueTime"] = this.DueTime;
                Row["Estimate"] = this.Estimate;
            }

            if (this.Dimension == Timekeeper.Dimension.Activity) {
                // None at the moment
            }

            if (this.Dimension == Timekeeper.Dimension.Location) {
                Row["RefTimeZoneId"] = this.RefTimeZoneId;
            }

            this.ItemId = this.Database.Insert(this.TableName, Row);

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
            DateTimeOffset Now = Timekeeper.LocalNow;
            TimeSpan ts = new TimeSpan(Now.Ticks - TimerStartedTime.Ticks);
            // Trying to track down Issue #1395
            Timekeeper.Debug("Now.............: " + Now);
            Timekeeper.Debug("TimerStartedTime: " + TimerStartedTime);
            if (ts.TotalSeconds > (60 * 60 * 24 * 7)) {
                string Message = String.Format("Elapsed time is greater than a week. Something's not right. Now is {0}, TimerStartedTime is {1}.",
                    Timekeeper.DateForDatabase(Now),
                    Timekeeper.DateForDatabase(TimerStartedTime));
                Timekeeper.Warn(Message);
            }
            return ts;
        }

        //---------------------------------------------------------------------

        public TimeSpan ElapsedToday()
        {
            DateTimeOffset Now = Timekeeper.LocalNow;
            Now = Now.AddSeconds(this.SecondsElapsedToday);
            return new TimeSpan(Now.Ticks - TimerStartedTime.Ticks);
        }

        //---------------------------------------------------------------------

        public string ElapsedTodayFormatted()
        {
            /*
            DateTimeOffset midnight = DateTimeOffset.Parse("00:00:00"); // FIXME: MIDNIGHT ISSUE AGAIN
            midnight = midnight.AddSeconds(this.SecondsElapsedToday);
            TimeSpan ts = new TimeSpan(midnight.Ticks - 0);
            return Timekeeper.FormatTimeSpan(ts);
            */
            return Timekeeper.FormatSeconds(this.SecondsElapsedToday);
        }

        //---------------------------------------------------------------------

        public bool Exists()
        {
            if (this.Name == null)
                return false;
            if (this.Name == "")
                return false;
            return true;
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

            Row Row = this.Database.SelectRow(Query);
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

            Row row = Database.SelectRow(Query);

            if (row[this.IdColumnName] == null) {
                Timekeeper.Warn("Attempted to look up non-existent attribute.");
                return;
            }

            this.ItemId = itemId;
            this.CreateTime = row["CreateTime"];
            this.ModifyTime = row["ModifyTime"];
            this.ItemGuid = row[this.TableName + "Guid"];

            this.Name = row["Name"];
            this.Description = row["Description"];
            this.ParentId = row["ParentId"];
            this.SortOrderNo = row["SortOrderNo"];
            this.IsFolder = row["IsFolder"];
            this.IsFolderOpened = row["IsFolderOpened"];
            this.IsHidden = row["IsHidden"];
            this.IsDeleted = row["IsDeleted"];
            this.HiddenTime = row["HiddenTime"];
            this.DeletedTime = row["DeletedTime"];

            if (this.Dimension == Timekeeper.Dimension.Project) {
                this.LastActivityId = row["LastActivityId"];
                this.LastLocationId = row["LastLocationId"];
                this.LastCategoryId = row["LastCategoryId"];
                this.ExternalProjectNo = row["ExternalProjectNo"];
                this.StartTime = row["StartTime"];
                this.DueTime = row["DueTime"];
                this.Estimate = row["Estimate"];
            }

            if (this.Dimension == Timekeeper.Dimension.Activity) {
                // None at the moment
            }

            if (this.Dimension == Timekeeper.Dimension.Location) {
                this.RefTimeZoneId = row["RefTimeZoneId"];
            }

            // Initialize times
            this.SetSecondsElapsedToday();
        }

        //---------------------------------------------------------------------

        public void OpenFolder()
        {
            ChangeFolderOpenState(true);
        }

        //---------------------------------------------------------------------

        public int Redescribe(string newDescription)
        {
            Row Row = new Row();
            Row["Description"] = newDescription;
            Row["ModifyTime"] = Timekeeper.DateForDatabase();
            long Count = Database.Update(this.TableName, Row, this.IdColumnName, this.ItemId);

            if (Count == 1) {
                this.Description = newDescription;
                // FIXME: maintaining the symmetry between the object and 
                // what's currently in the database for this object is
                // more than bothering me. This is likely a Timekeeper 4.0
                // type project, but I'd really like to figure out a better
                // ORM for Timekeeper. This method is fraught with issues.
                this.ModifyTime = Timekeeper.StringToDate(Row["ModifyTime"]);
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
            Row["ModifyTime"] = Timekeeper.DateForDatabase();
            long Count = Database.Update(this.TableName, Row, this.IdColumnName, this.ItemId);

            if (Count == 1) {
                this.Name = newName;
                this.ModifyTime = Timekeeper.StringToDate(Row["ModifyTime"]);
                return Timekeeper.SUCCESS;
            } else {
                return Timekeeper.FAILURE;
            }
        }

        //---------------------------------------------------------------------

        public int Reorder(long sortOrderNo)
        {
            // Update database
            Row Row = new Row();
            Row["SortOrderNo"] = sortOrderNo;
            Row["ModifyTime"] = Timekeeper.DateForDatabase();
            long Count = Database.Update(this.TableName, Row, this.IdColumnName, this.ItemId);

            if (Count == 1) {
                // Update instance
                this.SortOrderNo = sortOrderNo;
                this.ModifyTime = Timekeeper.StringToDate(Row["ModifyTime"]);
                return Timekeeper.SUCCESS;
            } else {
                // Otherwise, failure
                return Timekeeper.FAILURE;
            }
        }

        //---------------------------------------------------------------------

        public int Reparent(long itemId)
        {
            // Update database
            Row Row = new Row();
            if (itemId == 0)
                Row["ParentId"] = null;
            else
                Row["ParentId"] = itemId;
            Row["ModifyTime"] = Timekeeper.DateForDatabase();
            Row["SortOrderNo"] = Timekeeper.GetNextSortOrderNo(this.TableName, itemId);
            long Count = Database.Update(this.TableName, Row, this.IdColumnName, this.ItemId);

            if (Count == 1) {
                // Update instance
                this.ParentId = itemId;
                this.ModifyTime = Timekeeper.StringToDate(Row["ModifyTime"]);
                this.SortOrderNo = Row["SortOrderNo"];
                return Timekeeper.SUCCESS;
            } else {
                // Otherwise, failure
                return Timekeeper.FAILURE;
            }
        }

        //---------------------------------------------------------------------

        public int Reparent(TreeAttribute node)
        {
            return this.Reparent(node.ItemId);
        }

        //---------------------------------------------------------------------

        public void StartTiming(DateTimeOffset setStartTime)
        {
            // Simply record the time we start
            Timekeeper.Debug("TimerStartedTime in StartTiming(): " + TimerStartedTime);
            this.TimerStartedTime = setStartTime;

            /* so this happened:
            2021-02-13T00:13:04-06:00 [DEBUG]: TimerStartedTime in StartTiming(): 0001-01-01 00:00:00 +00:00 (ThreadId: 1)
            2021-02-13T00:13:04-06:00 [DEBUG]: TimerStartedTime in StartTiming(): 0001-01-01 00:00:00 +00:00 (ThreadId: 1)
            2021-02-13T00:13:04-06:00 [DEBUG]: TimerStartedTime in StartTiming(): 2021-02-12 16:58:16 -06:00 (ThreadId: 1)
            2021-02-13T00:13:04-06:00 [DEBUG]: TimerStartedTime in StartTiming(): 2021-02-12 16:58:16 -06:00 (ThreadId: 1)
            */

            // Update (in memory) elapsed seconds for today
            this.SetSecondsElapsedToday();
        }

        //---------------------------------------------------------------------

        public int StopTiming(DateTimeOffset setStopTime)
        {
            /*
            DateTime StartTime = OldRow["timestamp_s"];
            DateTime StopTime = OldRow["timestamp_e"];
            TimeSpan Delta = StopTime.Subtract(StartTime);
            int DeltaSeconds = Convert.ToInt32(Delta.TotalSeconds);
            */

            // Calculate elapsed seconds
            int ElapsedSeconds = 0;
            try
            {
                TimeSpan Delta = setStopTime.Subtract(this.TimerStartedTime);
                ElapsedSeconds = Convert.ToInt32(Delta.TotalSeconds);
            }
            catch (Exception e)
            {
                string msg = "There was an error calculating Elapsed Seconds. Double check the entry and check logs for additional details";
                Timekeeper.Error(msg);
                Timekeeper.Error(e.Message);
                Common.Warn(msg);
            }

            // Update (in memory) elapsed seconds for today
            this.SetSecondsElapsedToday(ElapsedSeconds);

            // Return the elapsed time
            return ElapsedSeconds;
        }

        //---------------------------------------------------------------------

        public void ChangedTime()
        {
            this.SetSecondsElapsedToday();
        }

        //---------------------------------------------------------------------

        public long Unhide()
        {
            this.IsHidden = false;
            return SetStatus("Hidden", this.IsHidden);
        }

        //---------------------------------------------------------------------

        public int SaveTask()
        {
            Row Project = new Row();
            Project["StartTime"] = Timekeeper.NullableDateForDatabase(this.StartTime);
            Project["DueTime"] = Timekeeper.NullableDateForDatabase(this.DueTime);
            Project["Estimate"] = this.Estimate;
            return (int)this.Database.Update("Project", Project, "ProjectId", this.ItemId);
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
                if (!this.Database.TableExists("Journal")) {
                    // If no Journal table exists, don't bother to
                    // fetch any time data. Note: the only place
                    // where this is an issue is during database
                    // creation, because Projects and Activities
                    // can be populated and loaded before the
                    // Journal table has been created.
                    return;
                }

                // fetch seconds from the db for this node
                DateTime Today = Timekeeper.AdjustedToday;

                string query = String.Format(@"
                    select sum(Seconds) as Seconds
                    from Journal
                    where StartTime >= datetime('{0}', '{3} hours')
                      and StartTime < datetime('{0}', '{4} hours')
                      and {1} = {2}",
                    Today.ToString(Timekeeper.LOCAL_DATETIME_FORMAT), 
                    this.IdColumnName, this.ItemId,
                    Timekeeper.Options.Advanced_Other_MidnightOffset,
                    (24 - Timekeeper.Options.Advanced_Other_MidnightOffset));
                Row row = this.Database.SelectRow(query);

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

        private void ChangeFolderOpenState(bool opened)
        {
            if (this.IsFolder) {
                Row Row = new Row();
                Row["IsFolderOpened"] = opened ? 1 : 0;
                Row["ModifyTime"] = Timekeeper.DateForDatabase();
                long Count = Database.Update(this.TableName, Row, this.IdColumnName, this.ItemId);

                if (Count == 1) {
                    this.IsFolderOpened = opened;
                     this.ModifyTime = Timekeeper.StringToDate(Row["ModifyTime"]);
                }
            }
        }

        //---------------------------------------------------------------------

        /*
        private long GetNextSortOrderNo(long parentId)
        {
            string Query = String.Format(@"
                select max(SortOrderNo) as HighestSortOrderNo
                from {0}
                where ParentId = {1}
                order by SortOrderNo",
                this.TableName, parentId);
            Row Row = Data.SelectRow(Query);
            if (Row["HighestSortOrderNo"] != null) {
                return Row["HighestSortOrderNo"] + 1;
            } else {
                return 1;
            }
        }
        */

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
            return Database.Select(Query);
        }

        //---------------------------------------------------------------------

        private long SetStatus(string status, bool isSet)
        {
            string BooleanColumnName = "Is" + status;
            string TimeColumnName = status + "Time";

            Row Row = new Row();
            Row[BooleanColumnName] = isSet ? 1 : 0;
            if (isSet) {
                Row[TimeColumnName] = Timekeeper.DateForDatabase();
            } else {
                Row[TimeColumnName] = null;
            }

            if (status == "Deleted") {
                // Frees up name for reuse
                Row["Name"] = this.Name + "\t{" + this.ItemGuid + "}";
            }

            return Database.Update(this.TableName, Row, this.IdColumnName, this.ItemId);
        }

        //---------------------------------------------------------------------

    }
}
