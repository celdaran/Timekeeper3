using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class JournalEntry
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Data;

        private long NextJournalIndex;

        private enum Mode { Insert, Update };

        //---------------------------------------------------------------------
        // Journal Attributes
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
        public long JournalIndex; //FIXME! NOT PUBLIC! ONLY FOR TESTING!

        //---------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------

        public JournalEntry(DBI data)
        {
            this.Data = data;
            this.SetAttributes();
        }

        //---------------------------------------------------------------------

        public JournalEntry(DBI data, long journalId) : this(data)
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

        public void AdvanceIndex()
        {
            this.JournalIndex++;
        }

        //---------------------------------------------------------------------

        public bool Create()
        {
            try {
                // Create the Row based on current object attributes
                JournalId = Data.Insert("Journal", GetAttributes(Mode.Insert));

                if (JournalId == 0) {
                    throw new Exception("Could not create journal entry.");
                }

                // Update bidirectional tracking
                Row row = new Row();
                row["LastProjectId"] = this.ProjectId;
                Data.Update("Activity", row, "ActivityId", this.ActivityId);

                row = new Row();
                row["LastActivityId"] = this.ActivityId;
                Data.Update("Project", row, "ProjectId", this.ProjectId);

                // Update JournalIndex and NextJournalIndex
                this.JournalIndex = this.NextJournalIndex;
                this.NextJournalIndex++;

                return true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }
        }

        //---------------------------------------------------------------------

        public JournalEntry Copy()
        {
            JournalEntry copy = new JournalEntry(this.Data);

            // copy internals
            copy.NextJournalIndex = this.NextJournalIndex;

            // copy private properties
            //copy.CurrentStartTime = this.CurrentStartTime;
            copy.CreateTime = this.CreateTime;
            copy.ModifyTime = this.ModifyTime;
            copy.JournalGuid = UUID.Get();
            copy.JournalIndex = this.JournalIndex;

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

        public bool Equals(JournalEntry copy)
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

        public void Load(long journalIndex)
        {
            try {
                if ((journalIndex == 0) || (journalIndex == NextJournalIndex)) {
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
                            j.JournalIndex,
                            j.CreateTime, j.ModifyTime, j.JournalGuid
                        from Journal j
                        join Activity a on a.ActivityId  = j.ActivityId
                        join Project p  on p.ProjectId   = j.ProjectId
                        left outer join Location l on l.LocationId  = j.LocationId
                        left outer join Category c on c.CategoryId = j.CategoryId
                        where j.JournalIndex = " + journalIndex;
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
            Load(this.JournalIndex);
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
            this.JournalIndex = 1;
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadPrevious()
        {
            this.JournalIndex--;
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadNext()
        {
            this.JournalIndex++;
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadLast()
        {
            this.JournalIndex = NextJournalIndex - 1;
            this.Load();
        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        private Row GetAttributes(Mode mode)
        {
            // Make sure everything's always localtime
            // TODO: Something's not quite right here, I need to figure
            // out where things are going wrong. This is nothing more
            // than a band-aid.
            StartTime = DateTime.SpecifyKind(StartTime, DateTimeKind.Local);
            StopTime = DateTime.SpecifyKind(StopTime, DateTimeKind.Local);

            Row Journal = new Row();

            string Now = Common.Now();

            if (mode == Mode.Insert) {
                Journal["CreateTime"] = Now;
                Journal["JournalGuid"] = UUID.Get();
                Journal["JournalIndex"] = NextJournalIndex;
            }
            Journal["ModifyTime"] = Now;

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
            // Get Next JournalIndex value
            Row Journal = Data.SelectRow("select max(JournalIndex) as HighestJournalIndex from Journal");
            if (Journal["HighestJournalIndex"] != null) {
                NextJournalIndex = Journal["HighestJournalIndex"] + 1;
            } else {
                // This is the first journal entry in a new database
                NextJournalIndex = 1;
            }

            // Now set default attributes
            Journal = new Row();

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
            Journal["JournalIndex"] = NextJournalIndex;

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

        private void SetAttributes(Row Journal)
        {
            Type t = Journal["StartTime"].GetType();

            if (t.FullName == "System.String") {
                Journal["StartTime"] = DateTime.Parse(Journal["StartTime"]);
                Journal["StopTime"] = DateTime.Parse(Journal["StopTime"]);
                Journal["StartTime"] = DateTime.SpecifyKind(Journal["StartTime"], DateTimeKind.Local);
                Journal["StopTime"] = DateTime.SpecifyKind(Journal["StopTime"], DateTimeKind.Local);
            }

            JournalId = Journal["JournalId"];
            ActivityId = Journal["ActivityId"];
            ProjectId = Journal["ProjectId"];
            StartTime = Journal["StartTime"];
            StopTime = Journal["StopTime"];
            Seconds = Journal["Seconds"];
            Memo = Journal["Memo"];
            LocationId = Journal["LocationId"] ?? 0;
            CategoryId = Journal["CategoryId"] ?? 0;
            IsLocked = Journal["IsLocked"];
            JournalIndex = Journal["JournalIndex"];

            ActivityName = Journal["ActivityName"];
            ProjectName = Journal["ProjectName"];
            LocationName = Journal["LocationName"] ?? "";
            CategoryName = Journal["CategoryName"] ?? "";

            CreateTime = Journal["CreateTime"];
            ModifyTime = Journal["ModifyTime"];
            JournalGuid = Journal["JournalGuid"];
        }

        //---------------------------------------------------------------------
        // Row location testers
        //---------------------------------------------------------------------

        public bool AtEnd()
        {
            return this.JournalIndex == this.NextJournalIndex - 1;
        }

        //---------------------------------------------------------------------

        public bool AtBeginning()
        {
            return this.JournalIndex == 1;
        }

        //---------------------------------------------------------------------

    }
}