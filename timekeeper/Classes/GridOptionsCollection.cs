using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

// FIXME: is this even being used anymore?

namespace Timekeeper.Classes
{
    class GridOptionsCollection : BaseOptionsCollection
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string OptionsTableName = "GridOptions";

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public GridOptionsCollection()
            : base(OptionsTableName)
        {
        }

        //----------------------------------------------------------------------

    }
}
