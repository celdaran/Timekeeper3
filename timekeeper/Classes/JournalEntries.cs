using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Entries
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        protected DBI Data;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Entries(DBI data)
        {
            this.Data = data;
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        public int Count()
        {
            string Query = "select count(*) as Count from Journal";
            Row Row = Data.SelectRow(Query);
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
            Row Row = this.Data.SelectRow(query);
            return Row["TodaySeconds"] == null ? 0 : Row["TodaySeconds"];
        }

        //---------------------------------------------------------------------

        public int TotalSeconds()
        {
            string Query = "select sum(Seconds) as TotalSeconds from Journal";
            Row Row = Data.SelectRow(Query);
            return Row["TotalSeconds"] == null ? 0 : (int)Row["TotalSeconds"];
        }

        //---------------------------------------------------------------------

    }
}
