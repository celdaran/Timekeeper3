using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Category : Classes.ListAttribute
    {
        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public Category()
            : base("Category")
        { }

        //----------------------------------------------------------------------

        public Category(long locationId)
            : base("Category", locationId)
        { }

        //----------------------------------------------------------------------

        public static bool Exists(string name)
        {
            return ListAttribute.Exists("Category", name);
        }

        //----------------------------------------------------------------------

    }
}
