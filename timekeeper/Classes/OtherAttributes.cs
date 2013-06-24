using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class OtherAttributes
    {
        private DBI Database;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public OtherAttributes()
        {
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Public Methods
        //---------------------------------------------------------------------

        public List<IdValuePair> Locations()
        {
            return Fetch("Location");
        }

        //---------------------------------------------------------------------

        public List<IdValuePair> Categories()
        {
            return Fetch("Categories");
        }

        //---------------------------------------------------------------------

        private List<IdValuePair> Fetch(string tableName)
        {
            List<IdValuePair> Values = new List<IdValuePair>();

            try {
                string Query = String.Format(@"SELECT * FROM {0} ORDER BY SortOrderNo, {1}",
                    tableName, tableName + "Id");
                Table Rows = Database.Select(Query);

                foreach (Row Row in Rows) {
                    IdValuePair Pair = new IdValuePair((int)Row[tableName + "Id"], (string)Row["Name"]);
                    Values.Add(Pair);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Values;
        }

        //---------------------------------------------------------------------
    }
}
