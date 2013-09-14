using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class GridOptions : BaseOptions
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string OptionsTableName = "GridOptions";

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        // FIXME: RefDimension? RefPrimaryDimension?
        public long RefItemTypeId { get; set; }
        public long RefGroupById { get; set; }
        public long RefTimeDisplayId { get; set; }

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public GridOptions()
            : base(OptionsTableName)
        {
        }

        //---------------------------------------------------------------------

        public GridOptions(long gridOptionsId)
            : this()
        {
            this.Load(gridOptionsId);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public void Load(long gridOptionsId)
        {
            try {
                Row Options = base.LoadRow(gridOptionsId);

                if (Options["GridOptionsId"] != null) {
                    // FIXME: potential off-by-one issue with Ref Id vs SelectedIndex
                    // Another sign of "You're Doing it Wrong".
                    // Need to populate these comboboxes with appropriate objects
                    RefItemTypeId = (long)Timekeeper.GetValue(Options["RefItemTypeId"], 1);         // default: Project
                    RefGroupById = (long)Timekeeper.GetValue(Options["RefGroupById"], 1);           // default: By Day
                    RefTimeDisplayId = (long)Timekeeper.GetValue(Options["RefTimeDisplayId"], 1);   // default: hh:mm:ss
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            bool Saved = false;

            try {
                Saved = base.SaveRow();

                if (Saved) {
                    Row Options = new Row();

                    Options["RefItemTypeId"] = this.RefItemTypeId;
                    Options["RefGroupById"] = this.RefGroupById;
                    Options["RefTimeDisplayId"] = this.RefTimeDisplayId;

                    if (this.Database.Update(OptionsTableName, Options, OptionsTableName + "Id", this.Id) == 1) {
                        Saved = true;
                    } else {
                        Saved = false;
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Saved;
        }

        //----------------------------------------------------------------------

    }
}
