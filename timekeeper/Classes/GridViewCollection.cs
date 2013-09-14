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

        private static string OptionsTableName = "GridOptions";

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public GridViewCollection()
            : base(OptionsTableName)
        {
        }

        //----------------------------------------------------------------------

    }
}
