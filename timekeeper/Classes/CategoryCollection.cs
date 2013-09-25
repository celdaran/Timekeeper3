using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class CategoryCollection : Classes.ListAttributeCollection
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public CategoryCollection()
            : base("Category")
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
            Table Categories = base.GetItems(includeHidden);

            List<IdObjectPair> Values = new List<IdObjectPair>();

            foreach (Row Row in Categories) {
                Category Category = new Category(Row["CategoryId"]);
                IdObjectPair Pair = new IdObjectPair((int)Row["CategoryId"], Category);
                Values.Add(Pair);
            }

            return Values;
        }

        //---------------------------------------------------------------------
    }
}
