using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Category
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;

        private long _CategoryId;

        private DateTime _CreateTime;
        private DateTime _ModifyTime;
        private string _CategoryGuid;

        private string _Name;
        private string _Description;

        private long _SortOrderNo;
        private bool _IsHidden;
        private bool _IsDeleted;
        private DateTime _HiddenTime;
        private DateTime _DeletedTime;

        private bool _Exists;

        private enum Mode { Insert, Update };

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Category()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------

        public Category(long categoryId)
        {
            this.Database = Timekeeper.Database;
            this.Load(categoryId);
        }

        //----------------------------------------------------------------------
        // Accessors
        //----------------------------------------------------------------------

        public long CategoryId { get { return _CategoryId; } set { _CategoryId = value; } }

        public DateTime CreateTime { get { return _CreateTime; } set { _CreateTime = value; } }
        public DateTime ModifyTime { get { return _ModifyTime; } set { _ModifyTime = value; } }
        public string CategoryGuid { get { return _CategoryGuid; } set { _CategoryGuid = value; } }

        public string Name { get { return _Name; } set { _Name = value; } }
        public string Description { get { return _Description; } set { _Description = value; } }

        public long SortOrderNo { get { return _SortOrderNo; } set { _SortOrderNo = value; } }
        public bool IsHidden { get { return _IsHidden; } set { _IsHidden = value; } }
        public bool IsDeleted { get { return _IsDeleted; } set { _IsDeleted = value; } }
        public DateTime HiddenTime { get { return _HiddenTime; } set { _HiddenTime = value; } }
        public DateTime DeletedTime { get { return _DeletedTime; } set { _DeletedTime = value; } }

        public bool Exists { get { return _Exists; } set { _Exists = value; } }

        //----------------------------------------------------------------------

        public bool Create()
        {
            return Upsert(Mode.Insert);
        }

        //----------------------------------------------------------------------

        public void Load(long categoryId)
        {
            string Query = String.Format(@"SELECT * FROM Category WHERE CategoryId = {0}", categoryId);
            Row Category = Database.SelectRow(Query);

            if (Category["CategoryId"] == null) {
                this.Exists = false;
            } else {
                this.Exists = true;

                this.CategoryId = Category["CategoryId"];

                this.CreateTime = Category["CreateTime"];
                this.ModifyTime = Category["ModifyTime"];
                this.CategoryGuid = Category["CategoryGuid"];

                this.Name = Category["Name"];
                this.Description = Category["Description"];

                this.SortOrderNo = Category["SortOrderNo"];
                this.IsHidden = Category["IsHidden"];
                this.IsDeleted = Category["IsDeleted"];

                if (Category["HiddenTime"] != null)
                    this.HiddenTime = Category["HiddenTime"];
                if (Category["DeletedTime"] != null)
                    this.DeletedTime = Category["DeletedTime"];
            }
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
                Row Category = new Row();

                if (mode == Mode.Insert) {
                    Category["CreateTime"] = Common.Now();
                    Category["CategoryGuid"] = UUID.Get();
                }
                Category["ModifyTime"] = Common.Now();

                Category["Name"] = this.Name;
                Category["Description"] = this.Description;

                Category["SortOrderNo"] = this.SortOrderNo;
                Category["IsHidden"] = this.IsHidden;
                Category["IsDeleted"] = this.IsDeleted;
                Category["HiddenTime"] = this.HiddenTime;
                Category["DeletedTime"] = this.DeletedTime;

                if (mode == Mode.Insert) {
                    this.CategoryId = Database.Insert("Category", Category);
                    this.CreateTime = Category["CreateTime"];
                    this.ModifyTime = Category["ModifyTime"];
                    this.CategoryGuid = Category["CategoryGuid"];
                } else {
                    Database.Update("Category", Category, "CategoryId", this.CategoryId);
                }

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
