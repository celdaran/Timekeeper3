using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class GridOptions
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private Classes.Options Options;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long GridOptionsId { get; private set; }

        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrderNo { get; set; }
        public long FilterOptionsId { get; private set; }

        // FIXME: RefDimension? RefPrimaryDimension?
        public long RefItemTypeId { get; set; }
        public long RefGroupById { get; set; }
        public long RefTimeDisplayId { get; set; }

        public Classes.FilterOptions FilterOptions { get; set; }

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public GridOptions()
        {
            //Clear();
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
        }

        //---------------------------------------------------------------------

        public GridOptions(long gridOptionsId) : this()
        {
            this.Load(gridOptionsId);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public void Load(long gridOptionsId)
        {
            try {
                string Query = @"select * from GridOptions where GridOptionsId = " + gridOptionsId;
                Row Options = this.Database.SelectRow(Query);

                if (Options["GridOptionsId"] != null) {
                    GridOptionsId = gridOptionsId;
                    CreateTime = Options["CreateTime"];
                    ModifyTime = Options["ModifyTime"];
                    Name = Options["Name"];
                    Description = (string)Timekeeper.GetValue(Options["Description"], "");
                    SortOrderNo = (int)Timekeeper.GetValue(Options["SortOrderNo"], 0);
                    FilterOptionsId = Options["FilterOptionsId"];

                    // FIXME: potential off-by-one issue with Ref Id vs SelectedIndex
                    // Another sign of "You're Doing it Wrong".
                    // Need to populate these comboboxes with appropriate objects

                    RefItemTypeId = (long)Timekeeper.GetValue(Options["RefItemTypeId"], 1);         // default Project
                    RefGroupById = (long)Timekeeper.GetValue(Options["RefGroupById"], 1);           // default By Day
                    RefTimeDisplayId = (long)Timekeeper.GetValue(Options["RefTimeDisplayId"], 1);   // default hh:mm:ss

                    FilterOptions = new Classes.FilterOptions(FilterOptionsId);
                } else {
                    FilterOptions = new Classes.FilterOptions();
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public bool Save()
        {
            try {
                Row Options = new Row();

                Options["Name"] = Name;
                Options["Description"] = Description;

                // TODO: TBX/DBI needs a RowExists and/or Upsert statement
                // TODO ALSO: Your entire ORM is way too much copy/paste.
                // This is also something many others have already solved,
                // so look into better ways to do this.
                // TODO AGAIN: I've said it before and I'll say it again: this
                // Replace() method call is a sign that You're Doing it Wrong.

                string QuotedName = Name.Replace("'", "''");
                Row Count = this.Database.SelectRow(@"
                    select count(*) as Count 
                    from GridOptions 
                    where Name = '" + QuotedName + "'");

                if (Count["Count"] == 0) {
                    this.FilterOptions.Create();

                    Options["SortOrderNo"] = Timekeeper.GetNextSortOrderNo("GridOptions");

                    Options["CreateTime"] = Common.Now();
                    Options["ModifyTime"] = Common.Now();
                    Options["FilterOptionsId"] = this.FilterOptions.FilterOptionsId;

                    GridOptionsId = this.Database.Insert("GridOptions", Options);
                    if (GridOptionsId > 0) {
                        CreateTime = Convert.ToDateTime(Options["CreateTime"]);
                        ModifyTime = Convert.ToDateTime(Options["ModifyTime"]);
                        FilterOptionsId = Options["FilterOptionsId"];
                    } else {
                        throw new Exception("Error inserting into GridOptions");
                    }
                } else {
                    this.FilterOptions.Save();

                    Options["ModifyTime"] = Common.Now();
                    if (this.Database.Update("GridOptions", Options, "GridOptionsId", GridOptionsId) == 1) {
                        ModifyTime = Convert.ToDateTime(Options["ModifyTime"]);
                    } else {
                        throw new Exception("Error updating GridOptions");
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //---------------------------------------------------------------------

        public Table Results(string sGroupBy, string tableName)
        {
            string Query = String.Format(@"
                select
                    i.Name as Name, 
                    strftime('{0}', j.StartTime) as Grouping, 
                    sum(j.Seconds) as Seconds
                from Journal j
                join {1} i on i.{1}Id = j.{1}Id
                where {2}
                group by i.Name, Grouping
                order by i.Name, Grouping",
                sGroupBy, tableName, this.FilterOptions.WhereClause);

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

        public override string ToString()
        {
            return this.Name;
        }

        //----------------------------------------------------------------------

    }
}
