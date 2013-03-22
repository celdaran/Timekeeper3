using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Entry
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
        public long EntryId;
        public long ActivityId;
        public long ProjectId;
        public DateTime StartTime;
        public DateTime StopTime;
        public long Seconds;
        public string Memo;
        public long LocationId;
        public long TagId;
        public bool IsLocked;

        public string ActivityName;
        public string ProjectName;
        public string LocationName;
        public string TagName;

        // Private
        private DateTime CreateTime;
        private DateTime ModifyTime;
        private string JournalEntryGuid;

        //---------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------

        public Entry(DBI data)
        {
            this.Data = data;
            this.SetAttributes();
        }

        //---------------------------------------------------------------------

        public Entry(DBI data, long entryId) : this(data)
        {
            this.Load(entryId);
        }

        //---------------------------------------------------------------------
        // Primary Methods
        //---------------------------------------------------------------------

        public void Create()
        {
            try {
                // Create the Row based on current object attributes
                EntryId = Data.Insert("Journal", GetAttributes(Mode.Insert));

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

        public Entry Copy()
        {
            Entry copy = new Entry(this.Data);

            // copy private properties
            copy.CurrentStartTime = this.CurrentStartTime;
            copy.CreateTime = this.CreateTime;
            copy.ModifyTime = this.ModifyTime;
            copy.JournalEntryGuid = UUID.Get();

            // copy public properties
            copy.EntryId = this.EntryId;
            copy.ActivityId = this.ActivityId;
            copy.ProjectId = this.ProjectId;
            copy.StartTime = this.StartTime;
            copy.StopTime = this.StopTime;
            copy.Seconds = this.Seconds;
            copy.Memo = this.Memo;
            copy.LocationId = this.LocationId;
            copy.TagId = this.TagId;
            copy.IsLocked = this.IsLocked;
            copy.ActivityName = this.ActivityName;
            copy.ProjectName = this.ProjectName;
            copy.LocationName = this.LocationName;
            copy.TagName = this.TagName;

            return copy;
        }

        //---------------------------------------------------------------------

        public bool Equals(Entry copy)
        {
            if (copy == null) {
                return false;
            }

            if (
                // Only compare public, non-PK, non-foreign members
                (copy.ActivityId == this.ActivityId) &&
                (copy.ProjectId == this.ProjectId) &&
                (copy.StartTime == this.StartTime) &&
                (copy.StopTime == this.StopTime) &&
                (copy.Seconds == this.Seconds) &&
                (copy.Memo == this.Memo) &&
                (copy.LocationId == this.LocationId) &&
                (copy.TagId == this.TagId) &&
                (copy.IsLocked == this.IsLocked)
               ) {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------

        public void Load(long entryId)
        {
            try {
                if (entryId == 0) {
                    SetAttributes();
                } else {
                    string Query = @"
                        select
                            j.JournalEntryId,
                            j.ActivityId, a.Name as ActivityName,
                            j.ProjectId, p.Name as ProjectName,
                            j.StartTime,
                            j.StopTime,
                            j.Seconds,
                            j.Memo,
                            j.LocationId, l.Name as LocationName,
                            j.TagId, t.Name as TagName,
                            j.IsLocked,
                            j.CreateTime, j.ModifyTime, j.JournalEntryGuid
                        from Journal j
                        join Activity a on a.ActivityId  = j.ActivityId
                        join Project p  on p.ProjectId   = j.ProjectId
                        join Location l on l.LocationId  = j.LocationId
                        join Tag t      on t.TagId       = j.TagId
                        where j.JournalEntryId = " + entryId;
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
            Load(this.EntryId);
        }

        //---------------------------------------------------------------------

        public void Save()
        {
            try {
                Data.Update("Journal", GetAttributes(Mode.Update), "JournalEntryId", EntryId);
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
                Data.Update("Journal", row, "JournalEntryId", EntryId);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
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
            Row Row = new Row();

            if (mode == Mode.Insert) {
                Row["CreateTime"] = Common.Now();
            }
            Row["ModifyTime"] = Common.Now();
            Row["JournalEntryGuid"] = UUID.Get();

            Row["ActivityId"] = ActivityId;
            Row["ProjectId"] = ProjectId;
            Row["StartTime"] = StartTime.ToString(Common.DATETIME_FORMAT);
            Row["StopTime"] = StopTime.ToString(Common.DATETIME_FORMAT);
            Row["Seconds"] = Seconds;
            Row["Memo"] = Memo;
            Row["LocationId"] = LocationId;
            Row["TagId"] = TagId;

            Row["IsLocked"] = IsLocked ? 1 : 0;

            return Row;
        }

        //---------------------------------------------------------------------

        private void SetAttributes()
        {
            Row row = new Row();

            row["StartTime"] = DateTime.Now;

            row["JournalEntryId"] = 0;
            row["ActivityId"] = 0;
            row["ProjectId"] = 0;
            row["StartTime"] = DateTime.Now;
            row["StopTime"] = DateTime.Now;
            row["Seconds"] = 0;
            row["Memo"] = "";
            row["LocationId"] = 0;
            row["TagId"] = 0;
            row["IsLocked"] = false;

            row["ActivityName"] = "";
            row["ProjectName"] = "";
            row["LocationName"] = "";
            row["TagName"] = "";

            row["CreateTime"] = DateTime.Now;
            row["ModifyTime"] = DateTime.Now;
            row["JournalEntryGuid"] = UUID.Get();

            SetAttributes(row);
        }

        //---------------------------------------------------------------------

        private void SetAttributes(Row row)
        {
            CurrentStartTime = row["StartTime"];

            EntryId = row["JournalEntryId"];
            ActivityId = row["ActivityId"];
            ProjectId = row["ProjectId"];
            StartTime = row["StartTime"];
            StopTime = row["StopTime"];
            Seconds = row["Seconds"];
            Memo = row["Memo"];
            LocationId = row["LocationId"];
            TagId = row["TagId"];
            IsLocked = row["IsLocked"];

            ActivityName = row["ActivityName"];
            ProjectName = row["ProjectName"];
            LocationName = row["LocationName"];
            TagName = row["TagName"];

            CreateTime = row["CreateTime"];
            ModifyTime = row["ModifyTime"];
            JournalEntryGuid = row["JournalEntryGuid"];
        }

        //---------------------------------------------------------------------
        // Row location testers
        //---------------------------------------------------------------------

        public bool AtEnd()
        {
            string Query = String.Format(@"
                select JournalEntryId from Journal 
                order by StartTime desc 
                limit 1");
            return EdgeTest(Query);
        }

        //---------------------------------------------------------------------

        public bool AtBeginning()
        {
            string Query = String.Format(@"
                select JournalEntryId from Journal 
                order by StartTime asc
                limit 1");
            return EdgeTest(Query);
        }

        //---------------------------------------------------------------------
        // Location Helpers
        //---------------------------------------------------------------------

        private bool EdgeTest(string query)
        {
            Row Row = Data.SelectRow(query);
            if ((Row["JournalEntryId"] != null) && (Row["JournalEntryId"] == this.EntryId)) {
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
                select JournalEntryId, StartTime from Journal 
                order by StartTime asc
                limit 1");
            SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetPrevId()
        {
            string query = String.Format(@"
                select JournalEntryId, StartTime from Journal 
                where StartTime < '{0}'
                order by StartTime desc
                limit 1", this.CurrentStartTime.ToString(Common.DATETIME_FORMAT));
            SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetNextId()
        {
            if (this.CurrentStartTime == DateTime.MinValue)
                return;
            string query = String.Format(@"
                select JournalEntryId, StartTime from Journal 
                where StartTime > '{0}'
                order by StartTime asc
                limit 1", this.CurrentStartTime.ToString(Common.DATETIME_FORMAT));
            SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetLastId()
        {
            string query = String.Format(@"
                select JournalEntryId, StartTime from Journal 
                order by StartTime desc 
                limit 1");
            SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetId(string query)
        {
            //-----------------------------------------------------------------
            // A Note on EntryId Values
            // Remember that the id does not imply chronology. Backfills, Data 
            // migrations, and other Data changes can create "out of order" id 
            // values. The value of StartTime is authoritative.
            //-----------------------------------------------------------------

            try {
                Row row = Data.SelectRow(query);
                this.EntryId = row["JournalEntryId"];
                this.CurrentStartTime = row["StartTime"];
            }
            catch {
                this.EntryId = 0;
                this.CurrentStartTime = DateTime.MinValue;
            }
        }

        //---------------------------------------------------------------------

    }
}