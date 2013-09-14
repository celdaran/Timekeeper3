using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class BaseOptionsCollection
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

        public BaseOptionsCollection(string tableName)
        {
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
            this.TableName = tableName;
        }

        //----------------------------------------------------------------------

        public bool ViewExists(string optionName)
        {
            string QuotedName = optionName.Replace("'", "''");
            string Query = String.Format(@"SELECT Count(*) AS Count FROM {0} WHERE Name = '{1}'", 
                this.TableName, QuotedName);
            Row Results = this.Database.SelectRow(Query);
            return (Results["Count"] == 0);
        }

        //----------------------------------------------------------------------

        public Table Fetch()
        {
            string Query = String.Format(@"SELECT * FROM {0} ORDER BY SortOrderNo, Name", this.TableName);
            return this.Database.Select(Query);
        }

        //----------------------------------------------------------------------

        public List<Classes.BaseOptions> FetchObjects()
        {
            List<Classes.BaseOptions> ReturnValue = new List<Classes.BaseOptions>();

            try {
                Table Options = this.Fetch();
                foreach (Row OptionRow in Options) {
                    Classes.BaseOptions BaseOptions = new Classes.BaseOptions(this.TableName, OptionRow[this.TableName + "Id"]);
                    ReturnValue.Add(BaseOptions);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return ReturnValue;
        }

        //----------------------------------------------------------------------

    }
}
