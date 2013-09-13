using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class GridOptionsCollection
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private Classes.Options Options;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public GridOptionsCollection()
        {
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
        }

        //----------------------------------------------------------------------

        public Table Fetch()
        {
            string Query = String.Format(@"SELECT * FROM GridOptions ORDER BY SortOrderNo, Name");
            return this.Database.Select(Query);
        }

        //----------------------------------------------------------------------

        public List<Classes.GridOptions> FetchObjects()
        {
            List<Classes.GridOptions> ReturnValue = new List<Classes.GridOptions>();

            Table Options = this.Fetch();
            foreach (Row OptionRow in Options) {
                Classes.GridOptions GridOptions = new Classes.GridOptions(OptionRow["GridOptionsId"]);
                ReturnValue.Add(GridOptions);
            }

            return ReturnValue;
        }

        //----------------------------------------------------------------------

    }
}
