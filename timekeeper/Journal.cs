using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Journal
    {
        private DBI data;

        // constructor, no lookup
        public Journal(DBI data)
        {
            this.data = data;
        }

        public int count()
        {
            string query = "select count(*) from journal";
            Row row = data.SelectRow(query);
            return (int)row["count(*)"];
        }
    }
}
