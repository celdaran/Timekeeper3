using System;
using System.Collections.Generic;
using System.Text;

using System.Diagnostics;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Entry
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Data;
        private Log Log;
        
        private string Query;
        private string Message;
        
        private long LastEntryId;
        private DateTime CurrentStartTime;

        // Public Entry attributes
        public long EntryId;
        public long TaskId;
        public long ProjectId;
        public DateTime StartTime;    // about to rename timestamp_s
        public DateTime StopTime;     // about to rename timestamp_e
        public long Seconds;
        public string PreLog;
        public string PostLog;
        public string Text;         // NEW --> replaces pre_log and post_log
        public bool IsLocked;
        public string TaskName;
        public string ProjectName;

        //---------------------------------------------------------------------
        // Constructors
        //---------------------------------------------------------------------

        public Entry(DBI Data)
        {
            this.Data = Data;
            this.Log = new Log(Data.DataFile + ".log");
            this.Text = "FIXME";
            this.CurrentStartTime = DateTime.Now;
        }

        //---------------------------------------------------------------------

        public Entry(DBI Data, long logId) : this(Data)
        {
            this.Load(logId);
        }

        //---------------------------------------------------------------------
        // Primary Entry Management Methods
        //---------------------------------------------------------------------

        public void Create()
        {
            try {
                // Create the row based on current object attributes
                EntryId = Data.Insert("timekeeper", GetAttributes());
                LastEntryId = EntryId;

                // Update the tasks table to track the last project
                Row row = new Row();
                row["project_id__last"] = this.ProjectId;
                Data.Update("tasks", row, "id", this.TaskId);
            }
            catch {
                Log.Warn("could not create");
            }
        }

        //---------------------------------------------------------------------

        public void Save(long entryId)
        {
            try {
                // Update on the last created entry id (LastEntryId) instead
                // of EntryId, since EntryId may change based on user navigation
                // in the inline log browser.
                Data.Update("timekeeper", GetAttributes(), "id", entryId);
            }
            catch {
                Log.Warn("could not close");
            }
        }

        //---------------------------------------------------------------------

        public void Save()
        {
            Save(LastEntryId);
        }

        //---------------------------------------------------------------------
        // Browsing Methods
        //---------------------------------------------------------------------

        public void Load(long logId)
        {
            try {
                Query = @"
                    select
                        log.id,
                        log.task_id, t.name as task_name,
                        log.project_id, p.name as project_name,
                        log.timestamp_s, log.timestamp_e, 
                        log.seconds, log.pre_log, log.post_log,
                        log.is_locked
                    from timekeeper log
                    join tasks t on t.id = log.task_id
                    join projects p on p.id = log.project_id
                    where log.id = " + logId;
                SetAttributes(Data.SelectRow(Query));
            } catch (Exception e) {
                Message = string.Format("Could not set attributes in Entry.Load(), Query = {0}, Error = {1}",
                    Query, e.ToString());
                Log.Warn(Message);
            }
        }

        public void Load()
        {
            Load(this.EntryId);
        }

        public bool Empty()
        {
            return (this.EntryId == 0);
        }

        public void Reset()
        {
            this.CurrentStartTime = DateTime.Now;
            //this.SetPrevId();
        }

        //---------------------------------------------------------------------

        public void SetLastId()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper 
                order by timestamp_s desc 
                limit 1");
            SetId(query);
        }

        //---------------------------------------------------------------------

        public void SetFirstId()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper 
                order by timestamp_s asc 
                limit 1");
            SetId(query);
        }

        //---------------------------------------------------------------------

        public void SetPrevId()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper
                where timestamp_s < '{0}'
                order by timestamp_s desc
                limit 1", this.CurrentStartTime.ToString(Common.DATETIME_FORMAT));
            SetId(query);
        }

        //---------------------------------------------------------------------

        public void SetNextId()
        {
            if (this.CurrentStartTime == DateTime.MinValue)
                return;
            string query = String.Format(@"
                select id, timestamp_s from timekeeper
                where timestamp_s > '{0}'
                order by timestamp_s asc
                limit 1", this.CurrentStartTime.ToString(Common.DATETIME_FORMAT));
            SetId(query);
        }

        //---------------------------------------------------------------------
        // Helper "Properties"
        //---------------------------------------------------------------------

        public int Count()
        {
            string query = "select count(*) as count from timekeeper";
            Row row = Data.SelectRow(query);
            return (int)row["count"];
        }

        //---------------------------------------------------------------------

        public int TotalSeconds()
        {
            string query = "select sum(seconds) as seconds from timekeeper";
            Row row = Data.SelectRow(query);
            return row["seconds"] == null ? 0 : (int)row["seconds"];
        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        private Row GetAttributes()
        {
            var row = new Row();
            //row["id"] = EntryId;
            row["task_id"] = TaskId;
            row["project_id"] = ProjectId;
            row["timestamp_s"] = StartTime.ToString(Technitivity.Toolbox.Common.DATETIME_FORMAT);
            row["timestamp_e"] = StopTime.ToString(Technitivity.Toolbox.Common.DATETIME_FORMAT);
            row["seconds"] = Seconds;
            row["pre_log"] = PreLog;
            row["post_log"] = PostLog;
            row["is_locked"] = IsLocked ? 1 : 0;
            //row["task_name"] = TaskName;
            //row["project_name"] = ProjectName;
            return row;
        }

        //---------------------------------------------------------------------

        private void SetAttributes(Row row)
        {
            EntryId = row["id"];
            TaskId = row["task_id"];
            ProjectId = row["project_id"];
            StartTime = row["timestamp_s"];
            StopTime = row["timestamp_e"];
            Seconds = row["seconds"];
            PreLog = row["pre_log"];
            PostLog = row["post_log"];
            IsLocked = row["is_locked"];
            TaskName = row["task_name"];
            ProjectName = row["project_name"];
        }

        //---------------------------------------------------------------------
        // Row location testers
        //---------------------------------------------------------------------

        public bool AtEnd()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper 
                order by timestamp_s desc 
                limit 1");
            Row row = Data.SelectRow(query);
            if ((row["id"] != null) && (row["id"] == this.EntryId)) {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------

        public bool AtBeginning()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper 
                order by timestamp_s asc 
                limit 1");
            Row row = Data.SelectRow(query);
            if ((row["id"] != null) && (row["id"] == this.EntryId)) {
                return true;
            } else {
                return false;
            }
        }


        //---------------------------------------------------------------------

        private void SetId(string query)
        {
            //-----------------------------------------------------------------
            // A Note on EntryId Values
            // Remember that the id does not imply chronology. Backfills, Data 
            // migrations, and other Data changes can create "out of order" id 
            // values. The value of timestamp_s is authoritative.
            //-----------------------------------------------------------------

            var s = new Stopwatch();
            s.Start();

            try {
                Row row = Data.SelectRow(query);
                this.EntryId = row["id"];
                this.CurrentStartTime = row["timestamp_s"];
            }
            catch {
                this.EntryId = 0;
                this.CurrentStartTime = DateTime.MinValue;
            }

            s.Stop();
            // Helpful debugging step
            // this.Text = "Elapsed time " + s.ElapsedMilliseconds.ToString();
        }

        //---------------------------------------------------------------------

    }
}
