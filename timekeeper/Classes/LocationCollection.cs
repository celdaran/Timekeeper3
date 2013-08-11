using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class LocationCollection : Classes.ListAttributeCollection
    {
        private DBI Database;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public LocationCollection() : base("Location")
        {
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
            Table Locations = base.GetItems(includeHidden);

            List<IdObjectPair> Values = new List<IdObjectPair>();

            foreach (Row Row in Locations) {
                Location Location = new Location(Row["LocationId"]);
                IdObjectPair Pair = new IdObjectPair((int)Row["LocationId"], Location);
                Values.Add(Pair);
            }

            return Values;
        }

        //---------------------------------------------------------------------
    }
}
