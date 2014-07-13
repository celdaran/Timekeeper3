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

        private enum Mode { Insert, Update };
        public enum BrowseByMode { Entry, Day, Week, Month, Year };

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

        public JournalEntry(long journalId) : this()
        {
            this.Load(journalId);
        }

        //---------------------------------------------------------------------
        // Primary Methods
        //---------------------------------------------------------------------

        public bool Create()
        {
            try {
                // Create the Row based on current object attributes
                JournalId = Database.Insert("Journal", GetAttributes(Mode.Insert));

                if (JournalId == 0) {
                    throw new Exception("Could not create journal entry.");
                }

                // Update "last" values

                Row ProjectRow = new Row();
                ProjectRow["LastActivityId"] = this.ActivityId;
                Database.Update("Project", ProjectRow, "ProjectId", this.ProjectId);

                Row ActivityRow = new Row();
                ActivityRow["LastLocationId"] = this.LocationId;
                Database.Update("Activity", ActivityRow, "ActivityId", this.ActivityId);

                Row LocationRow = new Row();
                LocationRow["LastCategoryId"] = this.CategoryId;
                Database.Update("Location", LocationRow, "LocationId", this.LocationId);

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
            Load(this.JournalId);
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
                            datetime(j.StartTime, 'localtime') as StartTime,
                            datetime(j.StopTime, 'localtime') as StopTime,
                            j.Seconds,
                            j.Memo,
                            j.ProjectId, p.Name as ProjectName,
                            j.ActivityId, a.Name as ActivityName,
                            j.LocationId, l.Name as LocationName,
                            j.CategoryId, c.Name as CategoryName,
                            j.IsLocked,
                            j.CreateTime, j.ModifyTime, j.JournalGuid
                        from Journal j
                        join Activity a on a.ActivityId  = j.ActivityId
                        join Project p  on p.ProjectId   = j.ProjectId
                        left outer join Location l on l.LocationId  = j.LocationId
                        left outer join Category c on c.CategoryId = j.CategoryId
                        where j.JournalId = " + journalId;
                    SetAttributes(Database.SelectRow(Query));
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                SetAttributes();
            }
        }

        //---------------------------------------------------------------------

        public void LoadLite(long journalId)
        {
            // FIXME: Experiment. Loading a Journal row without any joins.
            // At the moment, only used by the DatabaseCheck report.
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
                        j.CreateTime, j.ModifyTime, j.JournalGuid
                    from Journal j
                    where j.JournalId = " + journalId;
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
        // Navigational Getters
        //---------------------------------------------------------------------

        private long GetFirstId()
        {
            string Query = String.Format(@"
                SELECT JournalId
                FROM Journal
                ORDER BY StartTime ASC
                LIMIT 1");
            return GetJournalId(Query);
        }

        //---------------------------------------------------------------------

        private long GetLastId()
        {
            string Query = String.Format(@"
                SELECT JournalId
                FROM Journal
                ORDER BY StartTime DESC
                LIMIT 1");
            return GetJournalId(Query);
        }

        //---------------------------------------------------------------------

        private long GetPrevId()
        {
            return GetPrevId(BrowseByMode.Entry);
        }

        //---------------------------------------------------------------------

        private long GetPrevId(BrowseByMode mode)
        {
            // select JournalId from Journal where StartTime < '2015-07-07T08:48:28-05:00' order by StartTime desc limit 1;

            string StartSearchAt = Common.Now();
            switch (mode) {
                case BrowseByMode.Entry:
                    StartSearchAt = this.StartTime.ToString(Common.UTC_DATETIME_FORMAT);
                    break;

                case BrowseByMode.Day:
                    DateTimeOffset Yesterday = this.StartTime.AddDays(-1);
                    // FIXME: need to figure out how to handle time zones
                    StartSearchAt = Yesterday.DateTime.ToString(Common.DATE_FORMAT) + "T23:59:59-05:00";
                    break;

                case BrowseByMode.Week:
                    /*
                    int Delta = DayOfWeek.Monday - this.StartTime.DayOfWeek;
                    Delta = 7 - Math.Abs(Delta);
                    DateTimeOffset LastWeek = this.StartTime.AddDays(-Delta);
                    */
                    DateTimeOffset LastWeek = this.StartTime.AddDays(-7);
                    StartSearchAt = LastWeek.DateTime.ToString(Common.DATE_FORMAT) + "T23:59:59-05:00";
                    break;

                case BrowseByMode.Month:
                    DateTimeOffset LastMonth = this.StartTime.AddMonths(-1);
                    StartSearchAt = LastMonth.DateTime.ToString(Common.DATE_FORMAT) + "T23:59:59-05:00";
                    break;

                case BrowseByMode.Year:
                    DateTimeOffset LastYear = this.StartTime.AddYears(-1);
                    StartSearchAt = LastYear.DateTime.ToString(Common.DATE_FORMAT) + "T23:59:59-05:00";
                    break;
            }

            string Query = String.Format(@"
                    SELECT JournalId
                    FROM Journal
                    WHERE StartTime < '{0}'
                    ORDER BY StartTime DESC
                    LIMIT 1", StartSearchAt);
            long JournalId = GetJournalId(Query);

            if (JournalId == 0) {
                // If we got a zero, we ran past the end of the dataset
                // so let's just fetch the first one.
                JournalId = GetFirstId();
            }

            return JournalId;
        }

        //---------------------------------------------------------------------

        private long GetNextId()
        {
            return GetNextId(BrowseByMode.Entry);
        }

        //---------------------------------------------------------------------

        private long GetNextId(BrowseByMode mode)
        {
            /*

            // select JournalId from Journal where StartTime >  '2014-07-07T08:48:28-05:00' order by StartTime asc limit 1;

            --> browse by week (find the first item after the previous day's last tick: hey, same thing. These *all* start at the first entry of a day, so the only real trick is finding out what the day is supposed to be)
            
            select JournalId from Journal 
            where StartTime > '2015-06-22T23:59:59.99-05:00' 
            order by StartTime asc limit 1;

            // FIXME: This is another area where a user-definable midnight will need to be considered.
            */

            string StartSearchAt = Common.Now();
            switch (mode) {
                case BrowseByMode.Entry:
                    StartSearchAt = this.StartTime.ToString(Common.UTC_DATETIME_FORMAT);
                    break;

                case BrowseByMode.Day:
                    DateTimeOffset Tomorrow = this.StartTime.AddDays(1);
                    // FIXME: need to figure out how to handle time zones
                    //StartSearchAt = tmp.DateTime.ToString(Common.DATE_FORMAT) + "T23:59:53-05:00";
                    StartSearchAt = Tomorrow.DateTime.ToString(Common.DATE_FORMAT) + "T00:00:00-05:00";
                    break;

                case BrowseByMode.Week:
                    /*
                    // This code was intended to jump by Mondays.
                    // Maybe make an option to jump # of days/weeks/months/years
                    // versus jump to the start of the next day/week/month/year
                    int Delta = DayOfWeek.Monday - this.StartTime.DayOfWeek;
                    Delta = 7 - Math.Abs(Delta);
                    DateTimeOffset NextWeek = this.StartTime.AddDays(Delta);
                    */
                    DateTimeOffset NextWeek = this.StartTime.AddDays(7);
                    StartSearchAt = NextWeek.DateTime.ToString(Common.DATE_FORMAT) + "T00:00:00-05:00";
                    break;

                case BrowseByMode.Month:
                    DateTimeOffset NextMonth = this.StartTime.AddMonths(1);
                    //StartSearchAt = NextMonth.DateTime.ToString("yyyy-MM-01") + "T00:00:00-05:00";
                    StartSearchAt = NextMonth.DateTime.ToString(Common.DATE_FORMAT) + "T00:00:00-05:00";
                    break;

                case BrowseByMode.Year:
                    DateTimeOffset NextYear = this.StartTime.AddYears(1);
                    StartSearchAt = NextYear.DateTime.ToString(Common.DATE_FORMAT) + "T00:00:00-05:00";
                    break;
            }

            string Query = String.Format(@"
                SELECT JournalId
                FROM Journal
                WHERE StartTime > '{0}'
                ORDER BY StartTime ASC
                LIMIT 1", StartSearchAt);

            long JournalId = GetJournalId(Query);

            if (JournalId == 0) {
                // If we got a zero, we ran past the end of the dataset
                // so let's just fetch the last one.
                JournalId = GetLastId();
            }

            return JournalId;
        }

        //---------------------------------------------------------------------

        private long GetJournalId(string query)
        {
            long JournalId = 0;

            try {
                Row JournalEntry = Database.SelectRow(query);
                JournalId = Convert.ToInt64(JournalEntry["JournalId"]);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return JournalId;
        }

        //---------------------------------------------------------------------
        // Navigational Setters
        //---------------------------------------------------------------------

        public void SetFirstId()
        {
            this.JournalId = GetFirstId();
        }

        //---------------------------------------------------------------------

        public void SetLastId()
        {
            this.JournalId = GetLastId();
        }

        //---------------------------------------------------------------------

        public void SetPreviousId()
        {
            SetPreviousId(BrowseByMode.Entry);
        }

        //---------------------------------------------------------------------

        public void SetPreviousId(BrowseByMode mode)
        {
            this.JournalId = GetPrevId(mode);
        }

        //---------------------------------------------------------------------

        public void SetNextId()
        {
            SetNextId(BrowseByMode.Entry);
        }

        //---------------------------------------------------------------------

        public void SetNextId(BrowseByMode mode)
        {
            this.JournalId = GetNextId(mode);
        }

        //---------------------------------------------------------------------
        // Loaders
        //---------------------------------------------------------------------

        public void LoadByNewIndex(long journalId)
        {
            this.JournalId = journalId;
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadFirst()
        {
            this.SetFirstId();
            this.Load();
        }

        //---------------------------------------------------------------------

        public void LoadPrevious()
        {
            this.SetPreviousId();
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

            try {
                string Now = Common.Now();

                if (mode == Mode.Insert) {
                    Journal["CreateTime"] = Now;
                    Journal["JournalGuid"] = UUID.Get();
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
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Journal;
        }

        //---------------------------------------------------------------------

        private void SetAttributes()
        {
            Row Journal = new Row();

            try {
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

                Journal["ActivityName"] = "";
                Journal["ProjectName"] = "";
                Journal["LocationName"] = "";
                Journal["CategoryName"] = "";

                Journal["CreateTime"] = DateTimeOffset.Now;
                Journal["ModifyTime"] = DateTimeOffset.Now;
                Journal["JournalGuid"] = UUID.Get();

                SetAttributes(Journal);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

        }

        //---------------------------------------------------------------------

        private void SetAttributes(Row Journal)
        {
            try {
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

                ActivityName = Journal["ActivityName"];
                ProjectName = Journal["ProjectName"];
                LocationName = Journal["LocationName"] ?? "";
                CategoryName = Journal["CategoryName"] ?? "";

                CreateTime = Journal["CreateTime"];
                ModifyTime = Journal["ModifyTime"];
                JournalGuid = Journal["JournalGuid"];
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------
        // Row location testers
        //---------------------------------------------------------------------

        public bool AtEnd()
        {
            return this.JournalId == this.GetLastId();
        }

        //---------------------------------------------------------------------

        public bool AtBeginning()
        {
            return this.JournalId == this.GetFirstId();
        }

        //---------------------------------------------------------------------

    }
}