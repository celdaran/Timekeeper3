using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Category : Classes.TreeAttribute
    {
        private static string CategoryTableName = "Category";
        private static string CategoryIdColumnName = "CategoryId";

        // constructor, no lookup
        public Category()
            : base(CategoryTableName, CategoryIdColumnName)
        { }

        // constructor, by id
        public Category(long categoryId)
            : base(categoryId, CategoryTableName, CategoryIdColumnName)
        { }

        // constructor, by nullable id
        public Category(long? categoryId)
            : base(categoryId, CategoryTableName, CategoryIdColumnName)
        { }

        // constructor, by name
        public Category(string categoryName)
            : base(categoryName, CategoryTableName, CategoryIdColumnName)
        { }

    }
}
