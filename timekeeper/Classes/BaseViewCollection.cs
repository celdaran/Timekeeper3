using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class BaseViewCollection
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

        public BaseViewCollection(string tableName)
        {
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
            this.TableName = tableName;
        }

        //----------------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------------

        public bool ViewExists(string optionName)
        {
            string QuotedName = optionName.Replace("'", "''");
            string Query = String.Format(@"SELECT Count(*) AS Count FROM {0} WHERE Name = '{1}'", 
                this.TableName, QuotedName);
            Row Results = this.Database.SelectRow(Query);
            return (Results["Count"] > 0);
        }

        //----------------------------------------------------------------------

        public List<Classes.BaseView> Fetch()
        {
            List<Classes.BaseView> ReturnValue = new List<Classes.BaseView>();

            try {
                Table Views = this.FetchRows();
                foreach (Row View in Views) {
                    Classes.BaseView BaseView = new Classes.BaseView(this.TableName, View[this.TableName + "Id"]);
                    ReturnValue.Add(BaseView);
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
