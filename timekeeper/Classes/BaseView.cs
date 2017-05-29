using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

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
            Row ExtraColumns = new Row();
            return this.Save(filterOptionsChanged, filterOptionsId, ExtraColumns);
        }

        //----------------------------------------------------------------------

        public bool Save(bool filterOptionsChanged, long filterOptionsId, Row extraColumns)
        {
            // 2014-07-25 update: now that I'm enforcing FK constraints, I can
            // no longer save the base row first and *then* the FilterOptions.
            // The FOID is required to save the base view, so it's time to
            // switch things around quite a bit here.

            try {
                //--------------------------------------------------------------
                // Save filter options first (due to FK constraints)
                //--------------------------------------------------------------

                if (SaveFilterOptions(filterOptionsChanged, filterOptionsId))
                {
                    //--------------------------------------------------------------
                    // Then upsert the base view
                    //--------------------------------------------------------------

                    extraColumns["Name"] = this.Name;
                    extraColumns["FilterOptionsId"] = this.FilterOptions.FilterOptionsId;

                    if (filterOptionsId == this.FilterOptions.FilterOptionsId) {
                        this.Saved = base.Save(extraColumns);
                    } else {
                        this.Saved = base.Add(extraColumns);
                    }

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

        private bool SaveFilterOptions(bool filterOptionsChanged, long filterOptionsId)
        {
            try {
                // FilterOptions are not saved/created with the view itself.
                // e.g., the "Last Saved" view may be updated with a brand-new
                // set of FilterOptions.
                if (filterOptionsChanged) {
                    if (filterOptionsId > 0) {
                        // If we passed in an id, update the existing id.
                        // This should only be used for AutoSaved values
                        // to prevent hundreds of rows from being created
                        // while simply hitting "OK" on the Filtering dialog
                        // box (before explicitly saving the view).

                        this.FilterOptions.Save();
                        Timekeeper.Debug("Just updated FilterOptionsId: " + filterOptionsId.ToString());
                        // TO-CHECK: make sure FilterOptions.FilterOptionsId 
                        // has the right value after coming out of Save()
                    } else {
                        // Otherwise, create a new row
                        this.FilterOptions.Create();
                        Timekeeper.Debug("Just created FilterOptionsId: " + this.FilterOptions.FilterOptionsId.ToString());
                    }

                    if (this.FilterOptions.FilterOptionsId < 1) {
                        throw new Exception("Error upserting FilterOptions row");
                    }
                } else {
                    // will we have to set/pass through filterOptionsId somehow?
                    // come back to this
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

    }
}
