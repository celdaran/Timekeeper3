using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Item
    {
        // public properties
        public long id;
        public string name;
        public string description;
        public long parent_id;
        public bool is_folder;
        public bool is_hidden;
        public bool is_deleted;
        public DateTime timestamp_c;
        public DateTime timestamp_m;
        public long project_id__last;

        public bool isTiming;
        public DateTime startTime;

        // protected properties
        protected DBI data;
        protected string table;
        protected string id_column;
        protected long secondsOne = 0;
        
        protected void _load(long id)
        {
            // fetch row from db
            string query = String.Format(@"
                select * from {0}
                where id = {1}", this.table, id);

            Row row = data.SelectRow(query);

            this.id = id;
            this.name = row["name"];
            this.description = row["descr"];
            this.parent_id = row["parent_id"];
            this.is_folder = row["is_folder"];
            this.is_hidden = row["is_hidden"];
            this.is_deleted = row["is_deleted"];
            if (row["timestamp_c"] != null)
                this.timestamp_c = row["timestamp_c"];
            if (row["timestamp_m"] != null)
                this.timestamp_m = row["timestamp_m"];
            if (row.ContainsKey("project_id__last")) {
                if (row["project_id__last"] > 0) {
                    project_id__last = row["project_id__last"];
                } else {
                    project_id__last = -1;
                }
            } else {
                project_id__last = -1;
            }

            // Initialize times
            this.getSeconds();
        }

        protected void getSeconds()
        {
            getSeconds(0);
        }

        protected void getSeconds(long offset)
        {
            // fetch seconds from the db for this node
            string today = DateTime.Today.ToString(Common.DATE_FORMAT);
            string midnight = "00:00:00";

            string query = String.Format(@"
                select sum(seconds) as seconds
                from timekeeper
                where timestamp_s > '{1} {2}'
                  and {0} = {3}",
                this.id_column, today, midnight, this.id);
            Row row = this.data.SelectRow(query);

            if (row["seconds"] > 0) {
                this.secondsOne = row["seconds"] + offset;
            }

        }

        // is the specified id a descendent of the current node?
        public bool isDescendentOf(long id)
        {
            string query = String.Format(@"
                select parent_id from {0} where id = '{1}'",
                this.table, id);
            Row row = data.SelectRow(query);

            if (row["parent_id"] == 0) {
                return false;
            } else {
                long parent_id = row["parent_id"];
                if (this.id == parent_id) {
                    return true;
                } else {
                    return isDescendentOf(parent_id);
                }
            }
        }

        public long countTreeTime(long id, string fromDate, string toDate)
        {
            // get self
            string query = String.Format(@"
                select sum(seconds) as seconds
                from timekeeper
                where timestamp_s >= '{1}'
                  and timestamp_e < '{2}'
                  and {0} = {3}",
                this.id_column, fromDate, toDate, id);
            Row row = this.data.SelectRow(query);

            long seconds = row["seconds"] == null ? 0 : row["seconds"];

            // get child(ren)
            query = String.Format(@"
                select id from {0}
                where parent_id = {1}", this.table, id);
            Table rows = this.data.Select(query);

            foreach (Row child in rows) {
                seconds += countTreeTime(child["id"], fromDate, toDate);
            }

            return seconds;
        }

        public int create()
        {
            if (exists(this.name) == true) {
                return -1;
            }

            Row row = new Row();

            row["name"] = this.name;
            row["descr"] = this.description;
            row["parent_id"] = this.parent_id;
            row["is_folder"] = this.is_folder ? 1 : 0;
            row["is_hidden"] = 0;
            row["is_deleted"] = 0;
            row["timestamp_c"] = Common.Now();
            row["timestamp_m"] = Common.Now();

            this.id = this.data.Insert(this.table, row);

            if (this.id > 0) {
                return 1;
            } else {
                return 0;
            }
        }

        public bool exists(string newname)
        {
            // poor-man's quote
            string newname_q = newname.Replace('\'', '"');

            // see if the name is free
            string query = String.Format(@"
                select count(*) from {0}
                where name = '{1}'", this.table, newname_q);

            Row row = this.data.SelectRow(query);
            long count = row["count(*)"];

            if (count > 0) {
                return true;
            } else {
                return false;
            }
        }

        public int hide()
        {
            Row row = new Row();
            is_hidden = true;
            row["is_hidden"] = 1;
            return data.Update(this.table, row, "id", this.id);
        }

        public int unhide()
        {
            Row row = new Row();
            is_hidden = false;
            row["is_hidden"] = 0;
            return data.Update(this.table, row, "id", this.id);
        }

        public int delete()
        {
            Row row = new Row();
            is_deleted = true;
            row["is_deleted"] = 1;
            return data.Update(this.table, row, "id", this.id);
        }

        public DateTime dateLastUsed()
        {
            string query = String.Format(@"
                select max(timestamp_e) as dateLastUsed
                from timekeeper
                where {0} = {1}",
                this.id_column, this.id);
            Row row = data.SelectRow(query);
            return row["dateLastUsed"];
            /*
            if (dateLastUsed.Length > 0) {
                return DateTime.Parse(row["dateLastUsed"]);
            } else {
                return DateTime.Now;
            }
            */
        }

        public int countDaysUsed()
        {
            string query = String.Format(@"
                select 
                    strftime('%Y-%m-%d', timestamp_s) as date, 
                    count(*) as count
                from timekeeper 
                where {0} = {1}
                group by date",
                this.id_column, this.id);
            Row row = data.SelectRow(query);
            return (int)row["count"];
        }

        public List<DateTime> daysUsed()
        {
            string query = String.Format(@"
                select 
                    strftime('%Y-%m-%d', timestamp_s) as date, 
                    count(*) as count
                from timekeeper 
                where {0} = {1}
                group by date",
                this.id_column, this.id);
            Table rows = data.Select(query);

            List<DateTime> days = new List<DateTime>();
            foreach (Row row in rows) {
                days.Add(row["date"]);
            }

            return days;
        }

        public int rename(string newname, bool changeDescriptionOnly)
        {
            if (!changeDescriptionOnly && (exists(newname) == true)) {
                return -1;
            } else {
                // now update
                Row row = new Row();
                row["name"] = newname;
                row["descr"] = this.description;
                row["timestamp_m"] = Common.Now();
                int count = data.Update(this.table, row, "id", this.id);

                if (count == 1) {
                    this.name = newname;
                    return 1;
                } else {
                    return 0;
                }
            }
        }

        public int reparent(long id)
        {
            Row row = new Row();
            row["parent_id"] = id;
            row["timestamp_m"] = Common.Now();
            int count = data.Update(this.table, row, "id", this.id);

            return count == 1 ? 1 : 0;
        }

        public int reparent(Item node)
        {
            Row row = new Row();
            row["parent_id"] = node.id;
            row["timestamp_m"] = Common.Now();
            int count = data.Update(this.table, row, "id", this.id);

            return count == 1 ? 1 : 0;
        }

        public void beginTiming()
        {
            isTiming = true;
            startTime = DateTime.Now;
            getSeconds();
        }

        public int endTiming()
        {
            // Get elapsed seconds
            DateTime endTime = DateTime.Now;
            TimeSpan ts = new TimeSpan(endTime.Ticks - startTime.Ticks);
            int elapsedSeconds = Convert.ToInt32(ts.TotalSeconds);

            // subtract one second (correction for rounding problems)
            elapsedSeconds--;

            // update row (and parents recursively)
            // updateTime(this.id, elapsedSeconds);

            // re-load time
            this.getSeconds(elapsedSeconds);

            // return the elapsed time
            return elapsedSeconds;
        }

        public TimeSpan elapsed()
        {
            DateTime currentTime = DateTime.Now;
            return new TimeSpan(currentTime.Ticks - startTime.Ticks);
        }

        public TimeSpan elapsedToday()
        {
            DateTime currentTime = DateTime.Now;
            currentTime = currentTime.AddSeconds(this.secondsOne);
            return new TimeSpan(currentTime.Ticks - startTime.Ticks);
        }

        public TimeSpan elapsedTodayAll(long seconds)
        {
            DateTime currentTime = DateTime.Now;
            currentTime = currentTime.AddSeconds(seconds);
            return new TimeSpan(currentTime.Ticks - startTime.Ticks);
        }

        public string elapsedTodayStatic()
        {
            DateTime midnight = DateTime.Parse("00:00:00");
            midnight = midnight.AddSeconds(this.secondsOne);
            TimeSpan ts = new TimeSpan(midnight.Ticks - 0);
            return Timekeeper.FormatTimeSpan(ts);
        }

        public string elapsedTodayAllStatic(long seconds)
        {
            DateTime midnight = DateTime.Parse("00:00:00");
            midnight = midnight.AddSeconds(seconds);
            TimeSpan ts = new TimeSpan(midnight.Ticks - 0);
            return Timekeeper.FormatTimeSpan(ts);
        }

    }
} 
