using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

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

        private long _Id;

        private DateTime _CreateTime;
        private DateTime _ModifyTime;
        private string _Guid;

        private string _Name;
        private string _Description;

        private long _RefTimeZoneId;
        private long _SortOrderNo;
        private bool _IsHidden;
        private bool _IsDeleted;
        private DateTime _HiddenTime;
        private DateTime _DeletedTime;

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
        // Accessors
        //----------------------------------------------------------------------

        public long Id { get { return _Id; } set { _Id = value; } }

        public DateTime CreateTime { get { return _CreateTime;} set { _CreateTime = value;} }
        public DateTime ModifyTime { get { return _ModifyTime;} set { _ModifyTime = value;} }
        public string Guid { get { return _Guid;} set { _Guid = value;} }

        public string Name { get { return _Name;} set { _Name = value;} }
        public string Description { get { return _Description;} set { _Description = value;} }

        public long RefTimeZoneId { get { return _RefTimeZoneId;} set { _RefTimeZoneId = value;} }
        public long SortOrderNo { get { return _SortOrderNo;} set { _SortOrderNo = value;} }
        public bool IsHidden { get { return _IsHidden;} set { _IsHidden = value;} }
        public bool IsDeleted { get { return _IsDeleted;} private set { _IsDeleted = value;} }
        public DateTime HiddenTime { get { return _HiddenTime;} private set { _HiddenTime = value;} }
        public DateTime DeletedTime { get { return _DeletedTime;} private set { _DeletedTime = value;} }

        //----------------------------------------------------------------------

        public bool Create()
        {
            return Upsert(Mode.Insert);
        }

        //----------------------------------------------------------------------

        public bool Delete()
        {
            Row ListAttribute = new Row();

            string Now = Common.Now();

            ListAttribute["ModifyTime"] = Now;
            ListAttribute["DeletedTime"] = Now;
            ListAttribute["IsDeleted"] = 1;

            if (Database.Update(this.TableName, ListAttribute, this.IdColumnName, this.Id) > 0) {

                this.ModifyTime = Convert.ToDateTime(Now);
                this.DeletedTime = Convert.ToDateTime(Now);
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

                if (ListAttribute["HiddenTime"] != null)
                    this.HiddenTime = ListAttribute["HiddenTime"];
                if (ListAttribute["DeletedTime"] != null)
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

                string Now = Common.Now();

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
                    this.CreateTime = Convert.ToDateTime(ListAttribute["CreateTime"]);
                    this.Guid = ListAttribute[this.TableName + "Guid"];

                } else {
                    long Count = Database.Update(this.TableName, ListAttribute, this.IdColumnName, this.Id);

                    if (Count < 1) {
                        return false;
                    }
                }

                // More backfilling
                this.ModifyTime = Convert.ToDateTime(ListAttribute["ModifyTime"]);

                if (ListAttribute["HiddenTime"] != null)
                    this.HiddenTime = Convert.ToDateTime(ListAttribute["HiddenTime"]);
                if (ListAttribute["DeletedTime"] != null)
                    this.DeletedTime = Convert.ToDateTime(ListAttribute["DeletedTime"]);

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
