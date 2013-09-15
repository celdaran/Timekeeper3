using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class JournalEntryCollection
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        protected DBI Database;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public JournalEntryCollection()
        {
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        public int Count()
        {
            string Query = "SELECT count(*) AS Count FROM Journal WHERE IsLocked = 0";
            Row Row = Database.SelectRow(Query);
            return (int)Row["Count"];
        }

        //---------------------------------------------------------------------

        public long ElapsedToday()
        {
            return this.TodaySeconds();
        }

        //---------------------------------------------------------------------

        public string ElapsedTodayFormatted()
        {
            DateTime Midnight = DateTime.Parse("00:00:00");
            Midnight = Midnight.AddSeconds(this.TodaySeconds());
            TimeSpan TimeSpan = new TimeSpan(Midnight.Ticks - 0);
            return Timekeeper.FormatTimeSpan(TimeSpan);
        }

        //---------------------------------------------------------------------

        private long TodaySeconds()
        {
            string Today = DateTime.Today.ToString(Common.DATE_FORMAT);
            string Midnight = "00:00:00"; // TKT #1255 here?

            string query = String.Format(@"
                select sum(Seconds) as TodaySeconds
                from Journal
                where StartTime > '{0} {1}'",
                Today, Midnight);
            Row Row = this.Database.SelectRow(query);
            return Row["TodaySeconds"] == null ? 0 : Row["TodaySeconds"];
        }

        //---------------------------------------------------------------------

        public int TotalSeconds()
        {
            string Query = "select sum(Seconds) as TotalSeconds from Journal";
            Row Row = Database.SelectRow(Query);
            return Row["TotalSeconds"] == null ? 0 : (int)Row["TotalSeconds"];
        }

        //---------------------------------------------------------------------

        public void Reindex()
        {
            Reindex(new DateTime(1, 0, 0));
        }

        //---------------------------------------------------------------------

        public void Reindex(DateTime since)
        {
            var t = new Stopwatch();

            // FIXME: How about some error handling?
            // FIXME2: This is brute-force and horribly inefficent. Come up with something better.

            // First, get every row we need to update
            Bench(t);
            string Query = String.Format(
                "select JournalId, JournalIndex from Journal where datetime(StartTime) >= datetime('{0}') order by StartTime",
                since.ToString(Common.DATETIME_FORMAT));
            Table Table = Database.Select(Query);
            Bench(t, "[Reindex] Rows fetched");

            // Then get our starting index
            Bench(t);
            Query = String.Format(
                "select JournalIndex from Journal where datetime(StartTime) < datetime('{0}') order by StartTime desc limit 1",
                since.ToString(Common.DATETIME_FORMAT));
            Row LastGoodRow = Database.SelectRow(Query);
            Bench(t, "[Reindex] Starting Index fetched");

            // Drop the current database index
            Bench(t);
            Database.Exec("DROP INDEX idx_Journal_JournalIndex");
            Bench(t, "[Reindex] Dropped database index");

            // Rebuild JournalIndex
            Bench(t);
            long Index = LastGoodRow["JournalIndex"] + 1;
            foreach (Row Row in Table) {
                Row UpdatedRow = new Row();
                UpdatedRow["JournalIndex"] = Index;
                Database.Update("Journal", UpdatedRow, "JournalId", Row["JournalId"]);
                Index++;
            }
            Bench(t, "[Reindex] Updated JournalIndex values");

            // Recreate database index
            Bench(t);
            Database.Exec("CREATE UNIQUE INDEX idx_Journal_JournalIndex ON Journal(JournalIndex);");
            Bench(t, "[Reindex] Re-created database index");
        }

        //---------------------------------------------------------------------

        private void Bench(Stopwatch t)
        {
            t.Start();
        }

        private void Bench(Stopwatch t, string message)
        {
            t.Stop();
            Timekeeper.Info(message + ": " + t.ElapsedMilliseconds.ToString());
            t.Reset();
        }

        //----------------------------------------------------------------------

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

        //----------------------------------------------------------------------

        public DateTime FirstDay()
        {
            DateTime FirstDay;

            string Query = @"
                select min(datetime(StartTime, 'localtime')) as FirstDate 
                from Journal";
            Row Row = Timekeeper.Database.SelectRow(Query);
            if (Row["FirstDate"] == null) {
                FirstDay = DateTime.Now;
            } else {
                FirstDay = DateTime.Parse(Row["FirstDate"]);
            }

            return FirstDay;
        }

        //----------------------------------------------------------------------

        public DateTime LastDay()
        {
            DateTime LastDay;

            string Query = @"
                select max(datetime(StartTime, 'localtime')) as LastDate 
                from Journal";
            Row Row = Timekeeper.Database.SelectRow(Query);
            if (Row["LastDate"] == null) {
                LastDay = DateTime.Now;
            } else {
                LastDay = DateTime.Parse(Row["LastDate"]);
            }

            return LastDay;
        }

        //----------------------------------------------------------------------

    }
}
