using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Diary
    {
        private DBI data;

        // constructor, no lookup
        public Diary(DBI data)
        {
            this.data = data;
        }

        public int count()
        {
            string query = "select count(*) from Diary";
            Row row = data.SelectRow(query);
            return (int)row["count(*)"];
        }
    }
}
