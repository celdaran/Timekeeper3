using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

// FIXME: is this even being used anymore?

namespace Timekeeper.Classes
{
    class GridViewCollection : BaseViewCollection
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string ViewTableName = "GridView";

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public GridViewCollection()
            : base(ViewTableName)
        {
        }

        //----------------------------------------------------------------------

    }
}
