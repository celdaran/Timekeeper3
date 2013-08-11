using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class ListAttributeCollection
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private string TableName;
        private string IdColumnName;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ListAttributeCollection(string tableName)
        {
            this.Database = Timekeeper.Database;
            this.TableName = tableName;
            this.IdColumnName = tableName + "Id";
        }

        //----------------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------------

        public Table GetItems(bool includeHidden)
        {
            Table Rows;

            try {
                string Where = "IsDeleted <> 1";
                       Where += includeHidden ? "" : " AND IsHidden <> 1";
                string Query = String.Format(@"SELECT {0} FROM {1} WHERE {2} ORDER BY SortOrderNo, Name", 
                    this.IdColumnName, this.TableName, Where);
                Rows = Database.Select(Query);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                Rows = new Table();
            }

            return Rows;
        }

        //----------------------------------------------------------------------
    }
}
