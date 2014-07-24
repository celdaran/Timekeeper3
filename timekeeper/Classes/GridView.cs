using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class GridView : BaseView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string ViewTableName = "GridView";

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long RefDimensionId { get; set; }
        public long RefGroupById { get; set; }
        public long RefTimeDisplayId { get; set; }

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public GridView() : base(ViewTableName)
        {
        }

        //---------------------------------------------------------------------

        public GridView(long gridViewId) : base(ViewTableName, gridViewId)
        {
        }

        //---------------------------------------------------------------------

        public GridView(string gridViewName) : base(ViewTableName, gridViewName)
        {
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        new public void Load(long gridViewId)
        {
            try {
                Row View = base.Load(gridViewId);

                if (View["GridViewId"] != null) {
                    // FIXME: potential off-by-one issue with Ref Id vs SelectedIndex
                    // Another sign of "You're Doing it Wrong".
                    // Need to populate these comboboxes with appropriate objects
                    RefDimensionId = (long)Timekeeper.GetValue(View["RefDimensionId"], 1);       // default: Project
                    RefGroupById = (long)Timekeeper.GetValue(View["RefGroupById"], 1);           // default: By Day
                    RefTimeDisplayId = (long)Timekeeper.GetValue(View["RefTimeDisplayId"], 1);   // default: hh:mm:ss
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public bool Save(bool filterOptionsChanged)
        {
            return Save(filterOptionsChanged, 0);
        }

        //----------------------------------------------------------------------

        new public bool Save(bool filterOptionsChanged, long filterOptionsId)
        {
            bool Saved = false;

            try {
                Saved = base.Save(filterOptionsChanged, filterOptionsId);

                if (Saved) {
                    Row View = new Row();

                    View["RefDimensionId"] = this.RefDimensionId;
                    View["RefGroupById"] = this.RefGroupById;
                    View["RefTimeDisplayId"] = this.RefTimeDisplayId;

                    if (this.Database.Update(ViewTableName, View, ViewTableName + "Id", this.Id) == 1) {
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

        public Table Results(string sGroupBy, string tableName)
        {
            string Offset = "";
            if (this.Options.Advanced_Other_MidnightOffset != 0) {
                Offset = String.Format(", '-{0} hours'", this.Options.Advanced_Other_MidnightOffset);
            }

            string Query = String.Format(@"
                select
                    i.Name as Name, 
                    strftime('{0}', j.StartTime{3}) as Grouping, 
                    sum(j.Seconds) as Seconds
                from Journal j
                join {1} i on i.{1}Id = j.{1}Id
                where {2}
                group by i.Name, Grouping
                order by i.Name, Grouping",
                sGroupBy, tableName, this.FilterOptions.WhereClause, Offset);

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

    }
}
