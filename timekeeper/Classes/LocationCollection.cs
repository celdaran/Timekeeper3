using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    class LocationCollection : Classes.TreeAttributeCollection
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public LocationCollection(string orderByClause)
            : base("Location", orderByClause)
        {}

        public LocationCollection() 
            : this ("CreateTime")
        {}

        //----------------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------------

        new public List<Classes.Location> Fetch(long? parentId, bool showHidden, DateTimeOffset showHiddenSince)
        {
            Table Table = base.GetItems(parentId, showHidden, showHiddenSince);

            List<Classes.Location> Locations = new List<Classes.Location>();

            foreach (Row Row in Table) {
                var Location = new Classes.Location(Row["LocationId"]);
                Locations.Add(Location);
            }

            return Locations;
        }

        //---------------------------------------------------------------------

    }
}
