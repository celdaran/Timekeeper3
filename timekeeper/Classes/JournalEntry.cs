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

        private DBI Database;

        private long NextJournalIndex;

        private enum Mode { Insert, Update };

        //---------------------------------------------------------------------
        // Attributes
        //---------------------------------------------------------------------

        public long JournalId { get; set; }

        public DateTimeOffset CreateTime { get; private set; }
        public DateTimeOffset ModifyTime { get; private set; }
        public string JournalGuid { get; private set; }

        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset StopTime { get; set; }
        public long Seconds { get; set; }
        public string Memo { get; set; }
        public long ProjectId { get; set; }
        public long ActivityId { get; set; }
        public long LocationId { get; set; }
        public long CategoryId { get; set; }
        public bool IsLocked { get; set; }

        public long JournalIndex { get; private set; }

        public string ProjectName { get; set; }
        public string ActivityName { get; set; }
        public string LocationName { get; set; }
        public string CategoryName { get; set; }

        //---------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------

        public JournalEntry()
        {
            this.Database = Timekeeper.Database;
            this.SetAttributes();
        }

        //---------------------------------------------------------------------

        public JournalEntry(long journalIndex) : this()
        {
            this.Load(journalIndex);
        }

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
                JournalId = Database.Insert("Journal", GetAttributes(Mode.Insert));

                if (JournalId == 0) {
                    throw new Exception("Could not create journal entry.");
                }

                // Update bidirectional tracking
                Row row = new Row();
                row["LastProjectId"] = this.ProjectId;
                Database.Update("Activity", row, "ActivityId", this.ActivityId);

                row = new Row();
                row["LastActivityId"] = this.ActivityId;
                Database.Update("Project", row, "ProjectId", this.ProjectId);

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
            JournalEntry copy = new JournalEntry();

            // copy properties
            copy.NextJournalIndex = this.NextJournalIndex;

            // copy attributes
            copy.JournalId = this.JournalId;
            copy.CreateTime = this.CreateTime;
            copy.ModifyTime = this.ModifyTime;
            copy.JournalGuid = UUID.Get();

            // copy public properties
            copy.StartTime = this.StartTime;
            copy.StopTime = this.StopTime;
            copy.Seconds = this.Seconds;
            copy.Memo = this.Memo;
            copy.ProjectId = this.ProjectId;
            copy.ActivityId = this.ActivityId;
            copy.LocationId = this.LocationId;
            copy.CategoryId = this.CategoryId;
            copy.IsLocked = this.IsLocked;

            copy.JournalIndex = this.JournalIndex;

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
                (copy.StartTime == this.StartTime) &&
                (copy.StopTime == this.StopTime) &&
                (copy.Seconds == this.Seconds) &&
                (copy.Memo == this.Memo) &&
                (copy.ProjectId == this.ProjectId) &&
                (copy.ActivityId == this.ActivityId) &&
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

        public void Load()
        {
            Load(this.JournalIndex);
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
                            datetime(j.StartTime, 'localtime') as StartTime,
                            datetime(j.StopTime, 'localtime') as StopTime,
                            j.Seconds,
                            j.Memo,
                            j.ProjectId, p.Name as ProjectName,
                            j.ActivityId, a.Name as ActivityName,
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
                    SetAttributes(Database.SelectRow(Query));
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                SetAttributes();
            }
        }

        //---------------------------------------------------------------------

        public void LoadLite(long journalIndex)
        {
            // FIXME: Experiment
            try {
                string Query = @"
                    select
                        j.JournalId,
                        datetime(j.StartTime, 'localtime') as StartTime,
                        datetime(j.StopTime, 'localtime') as StopTime,
                        j.Seconds,
                        j.Memo,
                        j.ProjectId, 'No Project' as ProjectName,
                        j.ActivityId, 'No Activity' as ActivityName,
                        j.LocationId, 'No Locaiton' as LocationName,
                        j.CategoryId, 'No Category' as CategoryName,
                        j.IsLocked,
                        j.JournalIndex,
                        j.CreateTime, j.ModifyTime, j.JournalGuid
                    from Journal j
                    where j.JournalIndex = " + journalIndex;
                SetAttributes(Database.SelectRow(Query));
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                SetAttributes();
            }
        }

        //---------------------------------------------------------------------

        public void Save()
        {
            try {
                Database.Update("Journal", GetAttributes(Mode.Update), "JournalId", JournalId);
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
                Database.Update("Journal", row, "JournalId", JournalId);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------
        // Browsing Helper Methods
        //---------------------------------------------------------------------

        public void SetFirstIndex()
        {
            this.JournalIndex = 1;
        }

        //---------------------------------------------------------------------

        public void SetPreviousIndex()
        {
            this.JournalIndex--;
        }

        //---------------------------------------------------------------------

        public void SetNextIndex()
        {
            this.JournalIndex++;
        }

        //---------------------------------------------------------------------

        public void SetLastIndex()
        {
            this.JournalIndex = NextJournalIndex - 1;
        }

        //---------------------------------------------------------------------

        public void LoadByNewIndex(long journalIndex)
        {
            this.JournalIndex = journalIndex;
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadFirst()
        {
            this.SetFirstIndex();
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadPrevious()
        {
            this.SetPreviousIndex();
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadNext()
        {
            this.SetNextIndex();
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadLast()
        {
            this.SetLastIndex();
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
            // Ticket #1310 -- Figured this out on 2014-04-19
            /*
            StartTime = DateTime.SpecifyKind(StartTime, DateTimeKind.Local);
            StopTime = DateTime.SpecifyKind(StopTime, DateTimeKind.Local);
            */

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
            Journal["StartTime"] = StartTime.ToString(Common.UTC_DATETIME_FORMAT);
            Journal["StopTime"] = StopTime.ToString(Common.UTC_DATETIME_FORMAT);
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
            Row Journal = Database.SelectRow("select max(JournalIndex) as HighestJournalIndex from Journal");
            if (Journal["HighestJournalIndex"] != null) {
                NextJournalIndex = Journal["HighestJournalIndex"] + 1;
            } else {
                // This is the first journal entry in a new database
                NextJournalIndex = 1;
            }

            // Now set default attributes
            Journal = new Row();

            Journal["JournalId"] = 0;
            Journal["ProjectId"] = 0;
            Journal["ActivityId"] = 0;
            Journal["StartTime"] = DateTimeOffset.Now;
            Journal["StopTime"] = DateTimeOffset.Now;
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

            Journal["CreateTime"] = DateTimeOffset.Now;
            Journal["ModifyTime"] = DateTimeOffset.Now;
            Journal["JournalGuid"] = UUID.Get();

            SetAttributes(Journal);
        }

        //---------------------------------------------------------------------

        private void SetAttributes(Row Journal)
        {
            Type t = Journal["StartTime"].GetType();

            if (t.FullName == "System.String") {
                Journal["StartTime"] = DateTimeOffset.Parse(Journal["StartTime"]);
                Journal["StopTime"] = DateTimeOffset.Parse(Journal["StopTime"]);
                /*
                Journal["StartTime"] = DateTimeOffset.SpecifyKind(Journal["StartTime"], DateTimeKind.Local);
                Journal["StopTime"] = DateTimeOffset.SpecifyKind(Journal["StopTime"], DateTimeKind.Local);
                */
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