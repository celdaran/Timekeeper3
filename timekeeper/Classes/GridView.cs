using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

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
            Row View = new Row();

            View["RefDimensionId"] = this.RefDimensionId;
            View["RefGroupById"] = this.RefGroupById;
            View["RefTimeDisplayId"] = this.RefTimeDisplayId;

            return base.Save(filterOptionsChanged, filterOptionsId, View);
        }

        //----------------------------------------------------------------------

        public Table Results(string sGroupBy, string tableName)
        {
            string Offset = "";
            if (this.Options.Advanced_Other_MidnightOffset != 0) {
                Offset = String.Format(", '-{0} hours'", this.Options.Advanced_Other_MidnightOffset);
            }

            /*

            WITH RECURSIVE ProjectPath(ProjectId, FullPath) AS (
            -- 1. Anchor Member: Start with Top-Level Projects (where ParentId is NULL)
            SELECT 
                ProjectId, 
                Name 
            FROM Project 
            WHERE ParentId IS NULL

            UNION ALL

            -- 2. Recursive Member: Join children to their parents and append names
            SELECT 
                p.ProjectId, 
                pp.FullPath || '::' || p.Name
            FROM Project p
            JOIN ProjectPath pp ON p.ParentId = pp.ProjectId
            )
            -- 3. Final Select: Join the results with your Journal table
            SELECT 
                pp.FullPath AS Name, 
                SUM(j.Seconds) AS Seconds
            FROM Journal j
            JOIN ProjectPath pp ON j.ProjectId = pp.ProjectId
            GROUP BY pp.FullPath
            ORDER BY pp.FullPath;
             * 
             */

            string Query = String.Format(@"
                WITH RECURSIVE {1}Path({1}Id, FullPath) AS (
                -- 1. Anchor Member: Start with Top-Level Dimensions (where ParentId is NULL)
                SELECT 
                    {1}Id, 
                    Name 
                FROM {1} 
                WHERE ParentId IS NULL

                UNION ALL

                -- 2. Recursive Member: Join children to their parents and append names
                SELECT 
                    i.{1}Id, 
                    ii.FullPath || '::' || i.Name
                FROM {1} i
                JOIN {1}Path ii ON i.ParentId = ii.{1}Id
                )

                -- 3. Final Select: Join the results with your Journal table
                SELECT 
                    ii.FullPath AS Name, 
                    strftime('{0}', j.StartTime{3}) as Grouping, 
                    SUM(j.Seconds) AS Seconds
                FROM Journal j
                JOIN {1}Path ii ON j.{1}Id = ii.{1}Id
                GROUP BY ii.FullPath, Grouping
                ORDER BY ii.FullPath, Grouping",
                sGroupBy, tableName, this.FilterOptions.WhereClause, Offset);

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

    }
}
