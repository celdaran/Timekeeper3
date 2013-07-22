using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Journal
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Data;

        private DateTime CurrentStartTime;

        private enum Mode { Insert, Update };

        //---------------------------------------------------------------------
        // Entry Attributes
        //---------------------------------------------------------------------

        // Public
        private long _JournalId;
        private long _ProjectId;
        private long _ActivityId;
        private DateTime _StartTime;
        private DateTime _StopTime;
        private long _Seconds;
        private string _Memo;
        private long _LocationId;
        private long _CategoryId;
        private bool _IsLocked;

        private string _ProjectName;
        private string _ActivityName;
        private string _LocationName;
        private string _CategoryName;

        // Private
        private DateTime CreateTime;
        private DateTime ModifyTime;
        private string JournalGuid;

        //---------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------

        public Journal(DBI data)
        {
            this.Data = data;
            this.SetAttributes();
        }

        //---------------------------------------------------------------------

        public Journal(DBI data, long journalId) : this(data)
        {
            this.Load(journalId);
        }

        //---------------------------------------------------------------------
        // Accessors
        //---------------------------------------------------------------------

        public long JournalId { get { return _JournalId; } set { _JournalId = value; } }
        public long ActivityId { get { return _ActivityId; } set { _ActivityId = value; } }
        public long ProjectId { get { return _ProjectId; } set { _ProjectId = value; } }
        public DateTime StartTime { get { return _StartTime; } set { _StartTime = value; } }
        public DateTime StopTime { get { return _StopTime; } set { _StopTime = value; } }
        public long Seconds { get { return _Seconds; } set { _Seconds = value; } }
        public string Memo { get { return _Memo; } set { _Memo = value; } }
        public long LocationId { get { return _LocationId; } set { _LocationId = value; } }
        public long CategoryId { get { return _CategoryId; } set { _CategoryId = value; } }
        public bool IsLocked { get { return _IsLocked; } set { _IsLocked = value; } }

        public string ActivityName { get { return _ActivityName; } set { _ActivityName = value; } }
        public string ProjectName { get { return _ProjectName; } set { _ProjectName = value; } }
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        public string CategoryName { get { return _CategoryName; } set { _CategoryName = value; } }

        //---------------------------------------------------------------------
        // Primary Methods
        //---------------------------------------------------------------------

        public void Create()
        {
            try {
                // Create the Row based on current object attributes
                JournalId = Data.Insert("Journal", GetAttributes(Mode.Insert));

                // Update bidirectional tracking
                Row row = new Row();
                row["LastProjectId"] = this.ProjectId;
                Data.Update("Activity", row, "ActivityId", this.ActivityId);

                row = new Row();
                row["LastActivityId"] = this.ActivityId;
                Data.Update("Project", row, "ProjectId", this.ProjectId);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public Journal Copy()
        {
            Journal copy = new Journal(this.Data);

            // copy private properties
            copy.CurrentStartTime = this.CurrentStartTime;
            copy.CreateTime = this.CreateTime;
            copy.ModifyTime = this.ModifyTime;
            copy.JournalGuid = UUID.Get();

            // copy public properties
            copy.JournalId = this.JournalId;
            copy.ProjectId = this.ProjectId;
            copy.ActivityId = this.ActivityId;
            copy.StartTime = this.StartTime;
            copy.StopTime = this.StopTime;
            copy.Seconds = this.Seconds;
            copy.Memo = this.Memo;
            copy.LocationId = this.LocationId;
            copy.CategoryId = this.CategoryId;
            copy.IsLocked = this.IsLocked;
            copy.ActivityName = this.ActivityName;
            copy.ProjectName = this.ProjectName;
            copy.LocationName = this.LocationName;
            copy.CategoryName = this.CategoryName;

            return copy;
        }

        //---------------------------------------------------------------------

        public bool Equals(Journal copy)
        {
            if (copy == null) {
                return false;
            }

            if (
                // Only compare public, non-PK, non-foreign members
                (copy.ProjectId == this.ProjectId) &&
                (copy.ActivityId == this.ActivityId) &&
                (copy.StartTime == this.StartTime) &&
                (copy.StopTime == this.StopTime) &&
                (copy.Seconds == this.Seconds) &&
                (copy.Memo == this.Memo) &&
                (copy.LocationId == this.LocationId) &&
                (copy.CategoryId == this.CategoryId) &&
                (copy.IsLocked == this.IsLocked)
               ) {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------

        public void Load(long journalId)
        {
            try {
                if (journalId == 0) {
                    SetAttributes();
                } else {
                    string Query = @"
                        select
                            j.JournalId,
                            j.ProjectId, p.Name as ProjectName,
                            j.ActivityId, a.Name as ActivityName,
                            datetime(j.StartTime, 'localtime') as StartTime,
                            datetime(j.StopTime, 'localtime') as StopTime,
                            j.Seconds,
                            j.Memo,
                            j.LocationId, l.Name as LocationName,
                            j.CategoryId, c.Name as CategoryName,
                            j.IsLocked,
                            j.CreateTime, j.ModifyTime, j.JournalGuid
                        from Journal j
                        join Activity a on a.ActivityId  = j.ActivityId
                        join Project p  on p.ProjectId   = j.ProjectId
                        left outer join Location l on l.LocationId  = j.LocationId
                        left outer join Category c      on c.CategoryId       = c.CategoryId
                        where j.JournalId = " + journalId;
                    SetAttributes(Data.SelectRow(Query));
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public void Load()
        {
            Load(this.JournalId);
        }

        //---------------------------------------------------------------------

        public void Save()
        {
            try {
                Data.Update("Journal", GetAttributes(Mode.Update), "JournalId", JournalId);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public void Unlock()
        {
            try {
                Row row = new Row();
                row["IsLocked"] = 0;
                Data.Update("Journal", row, "JournalId", JournalId);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public DateTime PreviousDay()
        {
            DateTime PreviousDay;

            string Query = @"
                select distinct strftime('%Y-%m-%d', datetime(StartTime, 'localtime')) as Date 
                from Journal 
                order by Date desc";
            Table Rows = Timekeeper.Database.Select(Query);

            if (Rows.Count > 1) {
                PreviousDay = DateTime.Parse(Rows[1]["Date"]);
            } else {
                PreviousDay = DateTime.Now;
            }

            return PreviousDay;
        }

        //---------------------------------------------------------------------

        public DateTime FirstDay()
        {
            DateTime FirstDay;

            string Query = @"
                select min(datetime(StartTime, 'localtime')) as FirstDate 
                from Journal";
            Row Row = Timekeeper.Database.SelectRow(Query);
            FirstDay = DateTime.Parse(Row["FirstDate"]);

            return FirstDay;
        }

        //---------------------------------------------------------------------

        public DateTime LastDay()
        {
            DateTime LastDay;

            string Query = @"
                select max(datetime(StartTime, 'localtime')) as LastDate 
                from Journal";
            Row Row = Timekeeper.Database.SelectRow(Query);
            LastDay = DateTime.Parse(Row["LastDate"]);

            return LastDay;
        }

        //---------------------------------------------------------------------
        // Browsing Helper Methods
        //---------------------------------------------------------------------

        public void LoadFirst()
        {
            this.SetFirstId();
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadPrevious()
        {
            this.SetPrevId();
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadNext()
        {
            this.SetNextId();
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadLast()
        {
            this.SetLastId();
            this.Load();
        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        private Row GetAttributes(Mode mode)
        {
            Row Journal = new Row();

            if (mode == Mode.Insert) {
                Journal["CreateTime"] = Common.Now();
            }
            Journal["ModifyTime"] = Common.Now();
            Journal["JournalGuid"] = UUID.Get();

            Journal["ProjectId"] = ProjectId;
            Journal["ActivityId"] = ActivityId;
            Journal["StartTime"] = StartTime.ToString(Common.DATETIME_FORMAT);
            Journal["StopTime"] = StopTime.ToString(Common.DATETIME_FORMAT);
            Journal["Seconds"] = Seconds;
            Journal["Memo"] = Memo;
            Journal["LocationId"] = LocationId;
            Journal["CategoryId"] = CategoryId;

            Journal["IsLocked"] = IsLocked ? 1 : 0;

            return Journal;
        }

        //---------------------------------------------------------------------

        private void SetAttributes()
        {
            Row Journal = new Row();

            Journal["StartTime"] = DateTime.Now;

            Journal["JournalId"] = 0;
            Journal["ProjectId"] = 0;
            Journal["ActivityId"] = 0;
            Journal["StartTime"] = DateTime.Now;
            Journal["StopTime"] = DateTime.Now;
            Journal["Seconds"] = 0;
            Journal["Memo"] = "";
            Journal["LocationId"] = 0;
            Journal["CategoryId"] = 0;
            Journal["IsLocked"] = false;

            Journal["ActivityName"] = "";
            Journal["ProjectName"] = "";
            Journal["LocationName"] = "";
            Journal["CategoryName"] = "";

            Journal["CreateTime"] = DateTime.Now;
            Journal["ModifyTime"] = DateTime.Now;
            Journal["JournalGuid"] = UUID.Get();

            SetAttributes(Journal);
        }

        //---------------------------------------------------------------------

        private void SetAttributes(Row row)
        {
            Type t = row["StartTime"].GetType();

            if (t.FullName == "System.String") {
                row["StartTime"] = DateTime.Parse(row["StartTime"]);
                row["StopTime"] = DateTime.Parse(row["StopTime"]);
                row["StartTime"] = DateTime.SpecifyKind(row["StartTime"], DateTimeKind.Local);
                row["StopTime"] = DateTime.SpecifyKind(row["StopTime"], DateTimeKind.Local);
            }

            CurrentStartTime = row["StartTime"];

            JournalId = row["JournalId"];
            ActivityId = row["ActivityId"];
            ProjectId = row["ProjectId"];
            StartTime = row["StartTime"];
            StopTime = row["StopTime"];
            Seconds = row["Seconds"];
            Memo = row["Memo"];
            LocationId = row["LocationId"] ?? 0;
            CategoryId = row["CategoryId"] ?? 0;
            IsLocked = row["IsLocked"];

            ActivityName = row["ActivityName"];
            ProjectName = row["ProjectName"];
            LocationName = row["LocationName"] ?? "";
            CategoryName = row["CategoryName"] ?? "";

            CreateTime = row["CreateTime"];
            ModifyTime = row["ModifyTime"];
            JournalGuid = row["JournalGuid"];
        }

        //---------------------------------------------------------------------
        // Row location testers
        //---------------------------------------------------------------------

        public bool AtEnd()
        {
            string Query = String.Format(@"
                select JournalId from Journal 
                order by datetime(StartTime, 'localtime') desc 
                limit 1");
            return EdgeTest(Query);
        }

        //---------------------------------------------------------------------

        public bool AtBeginning()
        {
            string Query = String.Format(@"
                select JournalId from Journal 
                order by datetime(StartTime, 'localtime') asc
                limit 1");
            return EdgeTest(Query);
        }

        //---------------------------------------------------------------------
        // Location Helpers
        //---------------------------------------------------------------------

        private bool EdgeTest(string query)
        {
            Row Row = Data.SelectRow(query);
            if ((Row["JournalId"] != null) && (Row["JournalId"] == this.JournalId)) {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------
        // Navigation Helpers
        //---------------------------------------------------------------------

        private void SetFirstId()
        {
            string query = String.Format(@"
                select JournalId, datetime(StartTime, 'localtime') as StartTime
                from Journal 
                order by datetime(StartTime, 'localtime') asc
                limit 1");
            SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetPrevId()
        {
            string query = String.Format(@"
                select JournalId, datetime(StartTime, 'localtime') as StartTime
                from Journal 
                where datetime(StartTime, 'localtime') < datetime('{0}', 'localtime')
                order by datetime(StartTime, 'localtime') desc
                limit 1", this.CurrentStartTime.ToString(Common.DATETIME_FORMAT));
            SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetNextId()
        {
            if (this.CurrentStartTime == DateTime.MinValue)
                return;
            string query = String.Format(@"
                select JournalId, datetime(StartTime, 'localtime') as StartTime
                from Journal 
                where datetime(StartTime, 'localtime') > datetime('{0}', 'localtime')
                order by datetime(StartTime, 'localtime') asc
                limit 1", this.CurrentStartTime.ToString(Common.DATETIME_FORMAT));
            SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetLastId()
        {
            string query = String.Format(@"
                select JournalId, datetime(StartTime, 'localtime') as StartTime
                from Journal 
                order by datetime(StartTime, 'localtime') desc 
                limit 1");
            SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetId(string query)
        {
            //-----------------------------------------------------------------
            // A Note on JournalId Values
            // Remember that the id does not imply chronology. Backfills, Data 
            // migrations, and other Data changes can create "out of order" id 
            // values. The value of StartTime (stored in UTC) is authoritative.
            //-----------------------------------------------------------------

            try {
                Row row = Data.SelectRow(query);
                this.JournalId = row["JournalId"];
                this.CurrentStartTime = DateTime.Parse(row["StartTime"]);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                this.JournalId = 0;
                this.CurrentStartTime = DateTime.MinValue;
            }
        }

        //---------------------------------------------------------------------

    }
}