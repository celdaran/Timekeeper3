using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class LocationCollection
    {
        private DBI Database;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public LocationCollection()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------------

        public List<IdObjectPair> Fetch()
        {
            return Fetch(false);
        }

        //----------------------------------------------------------------------

        public List<IdObjectPair> Fetch(bool includeHidden)
        {
            List<IdObjectPair> Values = new List<IdObjectPair>();

            try {
                string Where = "IsDeleted <> 1";
                       Where += includeHidden ? "" : " AND IsHidden <> 1";
                string Query = String.Format(@"SELECT LocationId FROM Location WHERE {0} ORDER BY SortOrderNo, Name", Where);
                Table Rows = Database.Select(Query);

                foreach (Row Row in Rows) {
                    Location Location = new Location(Row["LocationId"]);
                    IdObjectPair Pair = new IdObjectPair((int)Row["LocationId"], Location);
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
