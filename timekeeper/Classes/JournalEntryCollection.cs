using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Timekeeper.Classes.Toolbox;

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

        public int Count(Timekeeper.Dimension dimension, long id)
        {
            string ColumnName = dimension.ToString() + "Id";
            string Query = String.Format("SELECT count(*) AS Count FROM Journal WHERE {0} = {1}",
                ColumnName, id);
            Row Row = Database.SelectRow(Query);
            return (int)Row["Count"];
        }

        //---------------------------------------------------------------------

        public int Count(string whereClause)
        {
            string Query = "SELECT count(*) AS Count FROM Journal J WHERE " + whereClause;
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
            /*
            DateTimeOffset Midnight = DateTimeOffset.Parse("00:00:00");
            Midnight = Midnight.AddSeconds(this.TodaySeconds());
            TimeSpan TimeSpan = new TimeSpan(Midnight.Ticks - 0);
            return Timekeeper.FormatTimeSpan(TimeSpan);
            */
            return Timekeeper.FormatSeconds(this.TodaySeconds());
        }

        //---------------------------------------------------------------------

        public bool Exists(DateTimeOffset dateTime)
        {
            string query = String.Format(@"
                select count(*) as Count
                from Journal
                where StartTime = '{0}'", Timekeeper.DateForDatabase(dateTime));
            Row Row = this.Database.SelectRow(query);
            return Row["Count"] > 0;
        }

        //---------------------------------------------------------------------

        private long TodaySeconds()
        {
            DateTime Today = Timekeeper.AdjustedToday;

            string query = String.Format(@"
                select sum(Seconds) as TodaySeconds
                from Journal
                where StartTime >= datetime('{0}', '{1} hours')
                  and StartTime < datetime('{0}', '{2} hours')",
                Today.ToString(Timekeeper.LOCAL_DATETIME_FORMAT),
                Timekeeper.Options.Advanced_Other_MidnightOffset,
                (24 - Timekeeper.Options.Advanced_Other_MidnightOffset));

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

        public Table FetchRaw()
        {
            string Query = "SELECT * FROM Journal ORDER BY StartTime";
            Table Table = Database.Select(Query);
            return Table;
        }

        //---------------------------------------------------------------------

        public bool Merge(string whereClause, string columnName, long columnValue)
        {
            Row Row = new Row();
            Row[columnName] = columnValue;
            long UpdateCount = Database.Update("Journal", Row, whereClause);
            return (UpdateCount > 0);
        }

        //---------------------------------------------------------------------

        private void Bench(Stopwatch t)
        {
            t.Start();
        }

        private void Bench(Stopwatch t, string message)
        {
            t.Stop();
            Timekeeper.Info(message + ": " + t.ElapsedMilliseconds.ToString() + "ms");
            t.Reset();
        }

        //----------------------------------------------------------------------

        public DateTimeOffset PreviousDay()
        {
            DateTimeOffset PreviousDay;
            DateTimeOffset Today = DateTimeOffset.Now;
            string Midnight = "";

            // TODO: if this logic is fairly common, how about 
            // putting it in class Timekeeper?
            if (Timekeeper.Options.Advanced_Other_MidnightOffset != 0) {
                Midnight = String.Format(@"datetime('{0} 00:00:00', '{1} hours')",
                    Today.Date.ToString(Timekeeper.DATE_FORMAT),
                    Timekeeper.Options.Advanced_Other_MidnightOffset);
            } else {
                Midnight = String.Format(@"'{0} 00:00:00'",
                    Today.Date.ToString(Timekeeper.DATE_FORMAT));
            }

            string Query = String.Format(@"
                select distinct strftime('%Y-%m-%d', StartTime) as Date 
                from Journal 
                where StartTime < {0}
                order by Date desc
                limit 1", Midnight);
            Table Rows = Timekeeper.Database.Select(Query);

            if (Rows.Count > 0) {
                PreviousDay = DateTimeOffset.Parse(Rows[0]["Date"]);
            } else {
                PreviousDay = Timekeeper.LocalNow;
            }

            return PreviousDay;
        }

        //----------------------------------------------------------------------

        public DateTimeOffset FirstDay()
        {
            DateTimeOffset FirstDay;

            string Query = @"
                select min(StartTime) as FirstDate 
                from Journal";
            Row Row = Timekeeper.Database.SelectRow(Query);
            if (Row["FirstDate"] == null) {
                FirstDay = Timekeeper.LocalNow;
            } else {
                FirstDay = DateTimeOffset.Parse(Row["FirstDate"]);
            }

            return FirstDay;
        }

        //----------------------------------------------------------------------

        public DateTimeOffset LastDay()
        {
            DateTimeOffset LastDay;

            string Query = @"
                select max(StartTime) as LastDate 
                from Journal";
            Row Row = Timekeeper.Database.SelectRow(Query);
            if (Row["LastDate"] == null) {
                LastDay = Timekeeper.LocalNow;
            } else {
                LastDay = DateTimeOffset.Parse(Row["LastDate"]);
            }

            return LastDay;
        }

        //----------------------------------------------------------------------

    }
}
