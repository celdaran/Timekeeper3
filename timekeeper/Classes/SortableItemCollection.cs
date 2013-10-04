using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class SortableItemCollection
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        protected DBI Database;
        protected Classes.Options Options;
        private string TableName;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public SortableItemCollection(string tableName)
        {
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
            this.TableName = tableName;
        }

        //----------------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------------

        public bool ItemExists(string optionName)
        {
            string QuotedName = optionName.Replace("'", "''");
            string Query = String.Format(@"SELECT Count(*) AS Count FROM {0} WHERE Name = '{1}'",
                this.TableName, QuotedName);
            Row Results = this.Database.SelectRow(Query);
            return (Results["Count"] > 0);
        }

        //----------------------------------------------------------------------

        public List<Classes.SortableItem> Fetch()
        {
            List<Classes.SortableItem> ReturnValue = new List<Classes.SortableItem>();

            try {
                Table Views = this.FetchRows();
                foreach (Row View in Views) {
                    Classes.SortableItem SortableItem = new Classes.SortableItem(this.TableName, View[this.TableName + "Id"]);
                    ReturnValue.Add(SortableItem);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return ReturnValue;
        }

        //----------------------------------------------------------------------
        // Private Helpers
        //----------------------------------------------------------------------

        private Table FetchRows()
        {
            string Query = String.Format(@"SELECT * FROM {0} WHERE Name <> 'Unsaved View' ORDER BY SortOrderNo, Name", this.TableName);
            return this.Database.Select(Query);
        }

        //----------------------------------------------------------------------

    }
}
