using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    class CategoryCollection : Classes.TreeAttributeCollection
    {
        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public CategoryCollection(string orderByClause)
            : base("Category", orderByClause)
        {}

        public CategoryCollection() 
            : this ("CreateTime")
        {}

        //----------------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------------

        new public List<Classes.Category> Fetch(long? parentId, bool showHidden, DateTimeOffset showHiddenSince)
        {
            Table Table = base.GetItems(parentId, showHidden, showHiddenSince);

            List<Classes.Category> Categories = new List<Classes.Category>();

            foreach (Row Row in Table) {
                var Category = new Classes.Category(Row["CategoryId"]);
                Categories.Add(Category);
            }

            return Categories;
        }

        //---------------------------------------------------------------------

    }
}
