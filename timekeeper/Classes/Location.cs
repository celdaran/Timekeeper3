using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Location : Classes.TreeAttribute
    {
        private static string LocationTableName = "Location";
        private static string LocationIdColumnName = "LocationId";

        // constructor, no lookup
        public Location()
            : base(LocationTableName, LocationIdColumnName)
        { }

        // constructor, by id
        public Location(long locationId)
            : base(locationId, LocationTableName, LocationIdColumnName)
        { }

        // constructor, by nullable id
        public Location(long? locationId)
            : base(locationId, LocationTableName, LocationIdColumnName)
        { }

        // constructor, by name
        public Location(string locationName)
            : base(locationName, LocationTableName, LocationIdColumnName)
        { }

    }
}
