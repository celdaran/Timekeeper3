using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class BaseView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        protected DBI Database;
        protected Classes.Options Options;
        private string TableName;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long Id { get; protected set; }

        public DateTime CreateTime { get; protected set; }
        public DateTime ModifyTime { get; protected set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrderNo { get; set; }
        public long FilterOptionsId { get; protected set; }

        public Classes.FilterOptions FilterOptions { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public BaseView(string tableName)
        {
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
            this.TableName = tableName;
        }

        //----------------------------------------------------------------------

        public BaseView(string tableName, long id) : this(tableName)
        {
            this.LoadRow(id);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        protected Row LoadRow(long id)
        {
            Row View = new Row();

            try {
                string Query = String.Format(@"select * from {0} where {0}Id = {1}",
                    this.TableName, id);
                View = this.Database.SelectRow(Query);

                if (View[this.TableName + "Id"] != null) {
                    this.Id = id;
                    this.CreateTime = View["CreateTime"];
                    this.ModifyTime = View["ModifyTime"];
                    this.Name = View["Name"];
                    this.Description = (string)Timekeeper.GetValue(View["Description"], "");
                    this.SortOrderNo = (int)Timekeeper.GetValue(View["SortOrderNo"], 0);
                    this.FilterOptionsId = View["FilterOptionsId"];
                    FilterOptions = new Classes.FilterOptions(FilterOptionsId);
                } else {
                    FilterOptions = new Classes.FilterOptions();
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return View;
        }

        //----------------------------------------------------------------------

        public bool SaveRow()
        {
            try {
                Row View = new Row();

                View["Name"] = Name;
                View["Description"] = Description;
                View["SortOrderNo"] = SortOrderNo;

                // TODO: TBX/DBI needs a RowExists and/or Upsert statement

                // TODO ALSO: Your entire "ORM" is way too much copy/paste.
                // This is also something many others have already solved,
                // so look into better ways to do this.

                // TODO AGAIN: I've said it before and I'll say it again: this
                // Replace() method call is a sign that You're Doing it Wrong.

                string QuotedName = Name.Replace("'", "''");
                string Query = String.Format(@"
                    SELECT count(*) as Count 
                    FROM {0}
                    WHERE Name = '{1}'",
                    this.TableName, QuotedName);
                Row Count = this.Database.SelectRow(Query);

                if (Count["Count"] == 0) {
                    this.FilterOptions.Create();

                    // On insert, override any previously set SortOrderNo
                    View["SortOrderNo"] = Timekeeper.GetNextSortOrderNo(this.TableName);

                    View["CreateTime"] = Common.Now();
                    View["ModifyTime"] = Common.Now();
                    View["FilterOptionsId"] = this.FilterOptions.FilterOptionsId;

                    this.Id = this.Database.Insert(this.TableName, View);
                    if (this.Id > 0) {
                        CreateTime = Convert.ToDateTime(View["CreateTime"]);
                        ModifyTime = Convert.ToDateTime(View["ModifyTime"]);
                        FilterOptionsId = View["FilterOptionsId"];
                    } else {
                        throw new Exception("Error inserting into " + this.TableName);
                    }
                } else {
                    this.FilterOptions.Save();

                    View["ModifyTime"] = Common.Now();
                    if (this.Database.Update(this.TableName, View, this.TableName + "Id", this.Id) == 1) {
                        ModifyTime = Convert.ToDateTime(View["ModifyTime"]);
                    } else {
                        throw new Exception("Error updating " + this.TableName);
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //----------------------------------------------------------------------

        public void Delete()
        {
            Database.Delete(this.TableName, this.TableName + "Id", this.Id);
        }

        //----------------------------------------------------------------------

        public Table Results(string sGroupBy, string tableName)
        {
            string Query = String.Format(@"
                select
                    i.Name as Name, 
                    strftime('{0}', j.StartTime) as Grouping, 
                    sum(j.Seconds) as Seconds
                from Journal j
                join {1} i on i.{1}Id = j.{1}Id
                where {2}
                group by i.Name, Grouping
                order by i.Name, Grouping",
                sGroupBy, tableName, this.FilterOptions.WhereClause);

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

        public override string ToString()
        {
            return this.Name;
        }

        //----------------------------------------------------------------------

    }
}
