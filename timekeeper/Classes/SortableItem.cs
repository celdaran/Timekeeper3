using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class SortableItem
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        protected DBI Database;
        protected Classes.Options Options;
        protected string TableName;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long Id { get; protected set; }

        public DateTime CreateTime { get; protected set; }
        public DateTime ModifyTime { get; protected set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrderNo { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public SortableItem(string tableName)
        {
            this.Id = 0;

            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
            this.TableName = tableName;
        }

        //----------------------------------------------------------------------

        public SortableItem(string tableName, long id) : this(tableName)
        {
            this.Load(id);
        }

        //----------------------------------------------------------------------

        public SortableItem(string tableName, string viewName) : this(tableName)
        {
            long id = this.NameToId(viewName);
            this.Load(id);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        protected Row Load(long id)
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
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return View;
        }

        //----------------------------------------------------------------------
        // Some old notes...
        //
        // TODO: TBX/DBI needs a RowExists and/or Upsert statement
        //
        // TODO ALSO: Your entire "ORM" is way too much copy/paste.
        // This is also something many others have already solved,
        // so look into better ways to do this.
        //
        // TODO AGAIN: I've said it before and I'll say it again: this
        // Replace() method call is a sign that You're Doing it Wrong.
        //----------------------------------------------------------------------

        public bool Save()
        {
            bool Saved = false;

            try {
                Row View = new Row();

                View["Name"] = Name;
                View["Description"] = Description;
                View["SortOrderNo"] = SortOrderNo;

                string QuotedName = Name.Replace("'", "''");
                string Query = String.Format(@"
                    SELECT count(*) as Count 
                    FROM {0}
                    WHERE Name = '{1}'",
                    this.TableName, QuotedName);
                Row Count = this.Database.SelectRow(Query);

                if (Count["Count"] == 0) {

                    View["CreateTime"] = Common.Now();
                    View["ModifyTime"] = Common.Now();

                    // On insert, override any previously set SortOrderNo
                    View["SortOrderNo"] = Timekeeper.GetNextSortOrderNo(this.TableName);

                    this.Id = this.Database.Insert(this.TableName, View);
                    Common.Info("Just inserted " + this.TableName + "Id: " + this.Id.ToString());
                    if (this.Id > 0) {
                        CreateTime = Convert.ToDateTime(View["CreateTime"]);
                        ModifyTime = Convert.ToDateTime(View["ModifyTime"]);
                        SortOrderNo = (int)View["SortOrderNo"];
                    } else {
                        throw new Exception("Error inserting into " + this.TableName);
                    }
                } else {

                    View["ModifyTime"] = Common.Now();
                    Common.Info("About to update " + this.TableName + "Id: " + this.Id.ToString());
                    if (this.Database.Update(this.TableName, View, this.TableName + "Id", this.Id) == 1) {
                        ModifyTime = Convert.ToDateTime(View["ModifyTime"]);
                    } else {
                        throw new Exception("Error updating " + this.TableName);
                    }
                }

                Saved = true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Saved;
        }

        //----------------------------------------------------------------------

        public void Delete()
        {
            Database.Delete(this.TableName, this.TableName + "Id", this.Id);

            this.Id = 0;
            this.CreateTime = DateTime.MinValue;
            this.ModifyTime = DateTime.MinValue;
            this.Name = null;
            this.Description = null;
            this.SortOrderNo = 0;
        }

        //----------------------------------------------------------------------

        public override string ToString()
        {
            return this.Name;
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        protected long NameToId(string viewName)
        {
            string QuotedName = viewName.Replace("'", "''");
            string Query = String.Format(@"SELECT {0}Id AS Id FROM {0} WHERE Name = '{1}'",
                this.TableName, QuotedName);
            Row Row = Database.SelectRow(Query);
            if (Row["Id"] != null) {
                return Row["Id"];
            } else {
                return 0;
            }
        }

        //----------------------------------------------------------------------

    }
}
