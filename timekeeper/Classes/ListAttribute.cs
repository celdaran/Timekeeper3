using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    class ListAttribute
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private string TableName;
        private string IdColumnName;

        public long Id { get; set; }

        public DateTimeOffset CreateTime { get; set; }
        public DateTimeOffset ModifyTime { get; set; }
        public string Guid { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public long RefTimeZoneId { get; set; }
        public long SortOrderNo { get; set; }
        public bool IsHidden { get; set; }
        public bool IsDeleted { get; set; }
        public DateTimeOffset? HiddenTime { get; set; }
        public DateTimeOffset? DeletedTime { get; set; }

        private enum Mode { Insert, Update };

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ListAttribute(string tableName)
        {
            this.Database = Timekeeper.Database;
            this.TableName = tableName;
            this.IdColumnName = tableName + "Id";
        }

        //----------------------------------------------------------------------

        public ListAttribute(string tableName, long id) : this(tableName)
        {
            this.Load(id);
        }

        //----------------------------------------------------------------------

        public bool Create()
        {
            return Upsert(Mode.Insert);
        }

        //----------------------------------------------------------------------

        public bool Delete()
        {
            Row ListAttribute = new Row();

            string Now = Timekeeper.DateForDatabase();

            ListAttribute["ModifyTime"] = Now;
            ListAttribute["DeletedTime"] = Now;
            ListAttribute["IsDeleted"] = 1;

            if (Database.Update(this.TableName, ListAttribute, this.IdColumnName, this.Id) > 0) {

                this.ModifyTime = Timekeeper.StringToDate(Now);
                this.DeletedTime = Timekeeper.StringToDate(Now);
                this.IsDeleted = true;

                return true;
            } else {
                return false;
            }
        }

        //----------------------------------------------------------------------

        public static bool Exists(string tableName, string name)
        {
            name = name.Replace("'", "''");
            string Query = String.Format(@"SELECT count(*) as Count FROM {0} WHERE Name = '{1}'", 
                tableName, name);
            Row Row = Timekeeper.Database.SelectRow(Query);

            if (Row["Count"] > 0) {
                return true;
            } else {
                return false;
            }
        }

        //----------------------------------------------------------------------

        public void Load(long id)
        {
            string Query = String.Format(@"SELECT * FROM {0} WHERE {1} = {2}", this.TableName, this.IdColumnName, id);
            Row ListAttribute = Database.SelectRow(Query);

            if (ListAttribute[this.IdColumnName] != null) {
                this.Id = ListAttribute[this.IdColumnName];

                this.CreateTime = ListAttribute["CreateTime"];
                this.ModifyTime = ListAttribute["ModifyTime"];
                this.Guid = ListAttribute[this.TableName + "Guid"];

                this.Name = ListAttribute["Name"];
                this.Description = ListAttribute["Description"];

                if (this.TableName == "Location") // FIXME: HACK
                    this.RefTimeZoneId = ListAttribute["RefTimeZoneId"];
                this.SortOrderNo = ListAttribute["SortOrderNo"];
                this.IsHidden = ListAttribute["IsHidden"];
                this.IsDeleted = ListAttribute["IsDeleted"];
                this.HiddenTime = ListAttribute["HiddenTime"];
                this.DeletedTime = ListAttribute["DeletedTime"];
            }
        }

        //----------------------------------------------------------------------

        public long Reposition(int index)
        {
            Row ListAttribute = new Row();
            ListAttribute["SortOrderNo"] = index;
            return Database.Update(this.TableName, ListAttribute, this.IdColumnName, this.Id);
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            return Upsert(Mode.Update);
        }

        //----------------------------------------------------------------------

        public override string ToString()
        {
            return this.Name;
        }

        //----------------------------------------------------------------------

        private bool Upsert(Mode mode)
        {
            try {
                Row ListAttribute = new Row();

                //--------------------------------
                // System-generated Values
                //--------------------------------

                string Now = Timekeeper.DateForDatabase();

                ListAttribute["ModifyTime"] = Now;

                if (mode == Mode.Insert) {
                    ListAttribute["CreateTime"] = Now;
                    ListAttribute[this.TableName + "Guid"] = UUID.Get();
                }

                ListAttribute["HiddenTime"] = this.IsHidden ? Now : null;
                ListAttribute["DeletedTime"] = this.IsDeleted ? Now : null;

                //--------------------------------
                // User-provided Values
                //--------------------------------

                ListAttribute["Name"] = this.Name;
                ListAttribute["Description"] = this.Description;

                if (this.TableName == "Location") // FIXME: HACK
                    ListAttribute["RefTimeZoneId"] = this.RefTimeZoneId;
                ListAttribute["SortOrderNo"] = this.SortOrderNo;
                ListAttribute["IsHidden"] = this.IsHidden ? 1 : 0;
                ListAttribute["IsDeleted"] = this.IsDeleted ? 1 : 0;

                //--------------------------------
                // Update the database
                //--------------------------------

                if (mode == Mode.Insert) {

                    this.Id = Database.Insert(this.TableName, ListAttribute);

                    if (this.Id == 0) {
                        return false;
                    }

                    // Backfill instance with system-generated values
                    this.CreateTime = Timekeeper.StringToDate(ListAttribute["CreateTime"]);
                    this.Guid = ListAttribute[this.TableName + "Guid"];

                } else {
                    long Count = Database.Update(this.TableName, ListAttribute, this.IdColumnName, this.Id);

                    if (Count < 1) {
                        return false;
                    }
                }

                // More backfilling
                this.ModifyTime = Timekeeper.StringToDate(ListAttribute["ModifyTime"]);
                this.HiddenTime = Timekeeper.StringToNullableDate(ListAttribute["HiddenTime"]);
                this.DeletedTime = Timekeeper.StringToNullableDate(ListAttribute["DeletedTime"]);

                return true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }
        }

        //----------------------------------------------------------------------

    }
}
