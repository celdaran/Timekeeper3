using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Categories
    {
        private DBI Database;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Categories()
        {
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Public Methods
        //---------------------------------------------------------------------

        public List<IdObjectPair> Fetch()
        {
            List<IdObjectPair> Values = new List<IdObjectPair>();

            try {
                string Query = String.Format(@"SELECT * FROM Category ORDER BY SortOrderNo, Name");
                Table Rows = Database.Select(Query);

                foreach (Row Row in Rows) {
                    Category Category= new Category(Row["CategoryId"]);
                    IdObjectPair Pair = new IdObjectPair((int)Row["CategoryId"], Category);
                    //IdObjectPair Pair = new IdObjectPair((int)Row["CategoryId"], Row["CategoryName"]);
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
