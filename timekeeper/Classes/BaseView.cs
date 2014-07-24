using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class BaseView : Classes.SortableItem
    {
        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long FilterOptionsId { get; private set; }
        public Classes.FilterOptions FilterOptions { get; set; }

        public bool Saved { get; set; }
        public bool Changed { get; set; }
        public bool IsAutoSaved { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public BaseView(string tableName) : base(tableName)
        {
            this.FilterOptions = new Classes.FilterOptions();

            this.Saved = false;
            this.Changed = true;
            this.IsAutoSaved = false;
        }

        //----------------------------------------------------------------------

        public BaseView(string tableName, long id) : this(tableName)
        {
            this.Load(id);
        }

        //----------------------------------------------------------------------

        public BaseView(string tableName, string viewName) : this(tableName)
        {
            long id = this.NameToId(viewName);
            this.Load(id);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        new public Row Load(long id)
        {
            Row View = base.Load(id);

            if (View[this.TableName + "Id"] != null) {
                this.FilterOptionsId = View["FilterOptionsId"];
                this.FilterOptions = new Classes.FilterOptions(FilterOptionsId);
                this.Changed = false;
                this.IsAutoSaved = (this.Name == "Unsaved View");
            }

            return View;
        }

        //----------------------------------------------------------------------

        public bool Save(bool filterOptionsChanged, long filterOptionsId)
        {
            bool Saved = false;
            Row ExtraColumns = new Row();
            ExtraColumns["FilterOptionsId"] = filterOptionsId;

            if (filterOptionsChanged) {
                Saved = base.Save(ExtraColumns);
            } else {
                if (filterOptionsId == this.FilterOptions.FilterOptionsId) {
                    Saved = base.Save(ExtraColumns);
                } else {
                    Saved = base.Add(ExtraColumns);
                }
            }

            try {
                if (Saved) {
                    // If the base saved, now handle View-specific columns
                    Row View = new Row();

                    // Default value: may get overridden
                    View["FilterOptionsId"] = this.FilterOptions.FilterOptionsId;

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
                            Timekeeper.Debug("Just updated FilterOptionsId: " + filterOptionsId.ToString());
                        } else {
                            // Otherwise, create a new row
                            this.FilterOptions.Create();
                            Timekeeper.Debug("Just created FilterOptionsId: " + this.FilterOptions.FilterOptionsId.ToString());
                        }

                        if (this.FilterOptions.FilterOptionsId < 1) {
                            throw new Exception("Error upserting FilterOptions row");
                        } else {
                            View["FilterOptionsId"] = this.FilterOptions.FilterOptionsId;
                        }
                    }

                    View["ModifyTime"] = Timekeeper.DateForDatabase();
                    Timekeeper.Debug("About to update " + this.TableName + "Id: " + this.Id.ToString());
                    if (this.Database.Update(this.TableName, View, this.TableName + "Id", this.Id) == 1) {
                        ModifyTime = Convert.ToDateTime(View["ModifyTime"]);
                        FilterOptionsId = View["FilterOptionsId"];
                    } else {
                        throw new Exception("Error updating " + this.TableName);
                    }

                    this.Saved = true;
                    this.Changed = false;
                    this.IsAutoSaved = (this.Name == "Unsaved View");

                }

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                this.Saved = false;
            }

            return this.Saved;
        }

        //----------------------------------------------------------------------

    }
}
