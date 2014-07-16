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

        public DateTimeOffset CreateTime { get; protected set; }
        public DateTimeOffset ModifyTime { get; protected set; }

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

        public bool Add()
        {
            bool Added = false;

            try {
                this.Insert();
                Added = true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Added;
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            bool Saved = false;

            try {
                string Query = String.Format(@"
                    SELECT count(*) as Count 
                    FROM {0}
                    WHERE {0}Id = '{1}'",
                    this.TableName, this.Id);
                Row Count = this.Database.SelectRow(Query);

                if (Count["Count"] == 0) {
                    this.Insert();
                } else {
                    this.Update();
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
            this.CreateTime = DateTimeOffset.MinValue;
            this.ModifyTime = DateTimeOffset.MinValue;
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
        // [2014-04-27: I'm about at the end of my wits with this half-baked
        // database layer. If I do anything with Timekeeper 4.0 it's to figure
        // this out. For now, I just apologize. That's all I got.]
        //----------------------------------------------------------------------

        private Row InitRow()
        {
            Row item = new Row();

            item["Name"] = Name;
            item["Description"] = Description;
            item["SortOrderNo"] = SortOrderNo;

            return item;
        }

        //----------------------------------------------------------------------

        private void Insert()
        {
            Row item = this.InitRow();

            item["CreateTime"] = Timekeeper.DateForDatabase();
            item["ModifyTime"] = Timekeeper.DateForDatabase();

            // On insert, override any previously set SortOrderNo
            item["SortOrderNo"] = Timekeeper.GetNextSortOrderNo(this.TableName);

            this.Id = this.Database.Insert(this.TableName, item);
            if (this.Id > 0) {
                Timekeeper.Debug("Just inserted " + this.TableName + "Id: " + this.Id.ToString());
                CreateTime = Timekeeper.StringToDate(item["CreateTime"]);
                ModifyTime = Timekeeper.StringToDate(item["ModifyTime"]);
                SortOrderNo = (int)item["SortOrderNo"];
            } else {
                throw new Exception("Error inserting into " + this.TableName);
            }
        }

        //----------------------------------------------------------------------

        private void Update()
        {
            Row item = this.InitRow();

            item["ModifyTime"] = Timekeeper.DateForDatabase();

            if (this.Database.Update(this.TableName, item, this.TableName + "Id", this.Id) == 1) {
                Timekeeper.Debug("Just updated " + this.TableName + "Id: " + this.Id.ToString());
                ModifyTime = Timekeeper.StringToDate(item["ModifyTime"]);
            } else {
                throw new Exception("Error updating " + this.TableName);
            }
        }

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
