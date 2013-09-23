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

        public long Id { get; private set; }

        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrderNo { get; set; }
        public long FilterOptionsId { get; private set; }

        public Classes.FilterOptions FilterOptions { get; set; }

        public bool Saved { get; set; }
        public bool Changed { get; set; }
        public bool IsAutoSaved { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public BaseView(string tableName)
        {
            this.Id = 0;

            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
            this.TableName = tableName;
            this.FilterOptions = new Classes.FilterOptions();

            this.Saved = false;
            this.Changed = true;
            this.IsAutoSaved = false;
        }

        //----------------------------------------------------------------------

        public BaseView(string tableName, long id) : this(tableName)
        {
            this.LoadRow(id);
        }

        //----------------------------------------------------------------------

        public BaseView(string tableName, string viewName) : this(tableName)
        {
            long id = this.NameToId(viewName);
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
                    this.FilterOptions = new Classes.FilterOptions(FilterOptionsId);
                    this.Changed = false;
                    this.IsAutoSaved = (this.Name == "Unsaved View");
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return View;
        }

        //----------------------------------------------------------------------

        public bool SaveRow(bool filterOptionsChanged, long filterOptionsId)
        {
            try {
                Row View = new Row();

                View["Name"] = Name;
                View["Description"] = Description;
                View["SortOrderNo"] = SortOrderNo;

                // Default value: may get overridden
                View["FilterOptionsId"] = this.FilterOptions.FilterOptionsId;

                // TODO: TBX/DBI needs a RowExists and/or Upsert statement

                // TODO ALSO: Your entire "ORM" is way too much copy/paste.
                // This is also something many others have already solved,
                // so look into better ways to do this.

                // TODO AGAIN: I've said it before and I'll say it again: this
                // Replace() method call is a sign that You're Doing it Wrong.


                // FilterOptions are not saved/created with the view itself.
                // e.g., the "Last Saved" view may be updated with a brand-new
                // set of FilterOptions. The management thereof now becomes
                // tricky, because the code below doesn't work the way I'd hoped.
                if (filterOptionsChanged) {
                    if (filterOptionsId > 0) {
                        // If we passed in an id, update the existing id.
                        // This should only be used for AutoSaved values
                        // to prevent hundreds of rows from being created
                        // while simply hitting "OK" on the Filtering dialog
                        // box (before explicitly saving the view).
                        this.FilterOptions.Save();
                        Common.Info("Just updated FilterOptionsId: " + filterOptionsId.ToString());
                    } else {
                        // Otherwise, create a new row
                        this.FilterOptions.Create();
                        Common.Info("Just created FilterOptionsId: " + this.FilterOptions.FilterOptionsId.ToString());
                    }

                    if (this.FilterOptions.FilterOptionsId < 1) {
                        throw new Exception("Error upserting FilterOptions row");
                    } else {
                        View["FilterOptionsId"] = this.FilterOptions.FilterOptionsId;
                    }
                }

                string QuotedName = Name.Replace("'", "''");
                string Query = String.Format(@"
                    SELECT count(*) as Count 
                    FROM {0}
                    WHERE Name = '{1}'",
                    this.TableName, QuotedName);
                Row Count = this.Database.SelectRow(Query);

                if (Count["Count"] == 0) {
                    //this.FilterOptions.Create();

                    View["CreateTime"] = Common.Now();
                    View["ModifyTime"] = Common.Now();

                    // On insert, override any previously set SortOrderNo
                    View["SortOrderNo"] = Timekeeper.GetNextSortOrderNo(this.TableName);

                    this.Id = this.Database.Insert(this.TableName, View);
                    Common.Info("Just inserted " + this.TableName + "Id: " + this.Id.ToString());
                    if (this.Id > 0) {
                        CreateTime = Convert.ToDateTime(View["CreateTime"]);
                        ModifyTime = Convert.ToDateTime(View["ModifyTime"]);
                        FilterOptionsId = View["FilterOptionsId"];
                        SortOrderNo = (int)View["SortOrderNo"];
                    } else {
                        throw new Exception("Error inserting into " + this.TableName);
                    }
                } else {
                    //this.FilterOptions.Save();

                    View["ModifyTime"] = Common.Now();
                    Common.Info("About to update " + this.TableName + "Id: " + this.Id.ToString());
                    if (this.Database.Update(this.TableName, View, this.TableName + "Id", this.Id) == 1) {
                        ModifyTime = Convert.ToDateTime(View["ModifyTime"]);
                        FilterOptionsId = View["FilterOptionsId"];
                    } else {
                        throw new Exception("Error updating " + this.TableName);
                    }
                }

                this.Saved = true;
                this.Changed = false;
                this.IsAutoSaved = (this.Name == "Unsaved View");
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                this.Saved = false;
            }

            return this.Saved;
        }

        //----------------------------------------------------------------------

        public void Delete()
        {
            Database.Delete("FilterOptions", "FilterOptionsId", this.FilterOptionsId);
            Database.Delete(this.TableName, this.TableName + "Id", this.Id);

            this.Id = 0;
            this.CreateTime = DateTime.MinValue;
            this.ModifyTime = DateTime.MinValue;
            this.Name = null;
            this.Description = null;
            this.SortOrderNo = 0;
            this.FilterOptionsId = 0;

            this.Saved = false;
            this.Changed = true;
            this.IsAutoSaved = false;
        }

        //----------------------------------------------------------------------

        public override string ToString()
        {
            return this.Name;
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private long NameToId(string viewName)
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
