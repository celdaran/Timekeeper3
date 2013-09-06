using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class ReferenceData
    {
        private DBI Database;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public ReferenceData()
        {
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Date Presets
        //---------------------------------------------------------------------

        public List<IdValuePair> DatePreset()
        {
            return Lookup("RefDatePreset");
        }

        //---------------------------------------------------------------------
        // Group By Values
        //---------------------------------------------------------------------

        public List<IdValuePair> GridGroupBy()
        {
            return Lookup("RefGroupBy");
        }

        //---------------------------------------------------------------------
        // Item Types
        //---------------------------------------------------------------------

        public List<IdValuePair> ItemType()
        {
            return Lookup("RefItemType");
        }

        //---------------------------------------------------------------------
        // Time Display Formats
        //---------------------------------------------------------------------

        public List<IdValuePair> TimeDisplay()
        {
            return Lookup("RefTimeDisplay");
        }

        //---------------------------------------------------------------------
        // Todo Status Values
        //---------------------------------------------------------------------

        public List<IdValuePair> TodoStatus()
        {
            return Lookup("RefTodoStatus");
        }

        //---------------------------------------------------------------------
        // Private Common Lookup
        //---------------------------------------------------------------------

        private List<IdValuePair> Lookup(string tableName)
        {
            List<IdValuePair> Pairs = new List<IdValuePair>();

            try {
                string Query = String.Format(@"select {0}, Name from {1} order by {0}",
                    tableName + "Id", tableName);
                Table Rows = Database.Select(Query);
                foreach (Row Row in Rows) {
                    IdValuePair Pair = new IdValuePair((int)Row[tableName + "Id"], (string)Row["Name"]);
                    Pairs.Add(Pair);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Pairs;
        }

    }
}
