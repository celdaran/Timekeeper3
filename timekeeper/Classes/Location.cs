using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Location : Classes.ListAttribute
    {
        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public Location()
            : base("Location")
        {}

        //----------------------------------------------------------------------

        public Location(long locationId)
            : base("Location", locationId)
        {}

        //----------------------------------------------------------------------

        public static bool Exists(string name)
        {
            return ListAttribute.Exists("Location", name);
        }

        //----------------------------------------------------------------------

    }
}
