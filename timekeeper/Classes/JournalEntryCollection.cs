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

        public int Count(Timekeeper.Dimension dimension, long id)
        {
            string ColumnName = dimension.ToString() + "Id";
            /*
            switch (dimension) {
                case Timekeeper.Dimension.Project:
                    ColumnName = "ProjectId";
                    break;
                case Timekeeper.Dimension.Activity:
                    ColumnName = "ActivityId";
                    break;
                case Timekeeper.Dimension.Location:
                    ColumnName = "LocationId";
                    break;
                case Timekeeper.Dimension.Category:
                    ColumnName = "CategoryId";
                    break;
            }
            */
            string Query = String.Format("SELECT count(*) AS Count FROM Journal WHERE {0} = {1}",
                ColumnName, id);
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
            DateTimeOffset Midnight = DateTimeOffset.Parse("00:00:00");
            Midnight = Midnight.AddSeconds(this.TodaySeconds());
            TimeSpan TimeSpan = new TimeSpan(Midnight.Ticks - 0);
            return Timekeeper.FormatTimeSpan(TimeSpan);
        }

        //---------------------------------------------------------------------

        public bool Exists(DateTimeOffset dateTime)
        {
            string query = String.Format(@"
                select count(*) as Count
                from Journal
                where datetime(StartTime, 'utc') = datetime('{0}', 'utc')",
            dateTime.DateTime.ToString(Common.UTC_DATETIME_FORMAT));
            Row Row = this.Database.SelectRow(query);
            return Row["Count"] > 0;
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
            long UpdateCount = Database.Update("Journal j", Row, whereClause);
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
