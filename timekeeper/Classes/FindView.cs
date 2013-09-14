using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class FindView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private Classes.Options Options;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long FindOptionsId { get; private set; }

        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int SortOrderNo { get; set; }
        public long FilterOptionsId { get; private set; }

        public Classes.FilterOptions FilterOptions { get; set; }

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public FindView()
        {
            //Clear();
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public void Load(long findOptionsId)
        {
            try {
                string Query = @"select * from FindOptions where FindOptionsId = " + findOptionsId;
                Row Options = this.Database.SelectRow(Query);

                FindOptionsId = findOptionsId;
                CreateTime = Options["CreateTime"];
                ModifyTime = Options["ModifyTime"];
                Name = Options["Name"];
                Description = (string)Timekeeper.GetValue(Options["Description"], "");
                SortOrderNo = (int)Timekeeper.GetValue(Options["SortOrderNo"], 0);
                FilterOptionsId = Options["FilterOptionsId"];

                FilterOptions = new Classes.FilterOptions(FilterOptionsId);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void Save()
        {
            try {
                Row Options = new Row();

                Options["Name"] = Name;
                Options["Description"] = Description;
                Options["SortOrderNo"] = Timekeeper.GetNextSortOrderNo("GridView");

                // TODO: TBX/DBI needs a RowExists and/or Upsert statement
                // TODO ALSO: Your entire ORM is way too much copy/paste.
                // This is also something many others have already solved,
                // so look into better ways to do this.
                // TODO AGAIN: I've said it before and I'll say it again: this
                // Replace() method call is a sign that You're Doing it Wrong.

                string QuotedName = Name.Replace("'", "''");
                Row Count = this.Database.SelectRow(@"
                    select count(*) as Count 
                    from FindOptions 
                    where Name = '" + QuotedName + "'");

                if (Count["Count"] == 0) {
                    this.FilterOptions.Create();

                    Options["CreateTime"] = Common.Now();
                    Options["ModifyTime"] = Common.Now();
                    Options["FilterOptionsId"] = this.FilterOptions.FilterOptionsId;

                    FindOptionsId = this.Database.Insert("FindOptions", Options);
                    if (FindOptionsId > 0) {
                        CreateTime = Convert.ToDateTime(Options["CreateTime"]);
                        ModifyTime = Convert.ToDateTime(Options["ModifyTime"]);
                        FilterOptionsId = Options["FilterOptionsId"];
                    } else {
                        throw new Exception("Error inserting into FindOptions");
                    }
                } else {
                    this.FilterOptions.Save();

                    Options["ModifyTime"] = Common.Now();
                    this.Database.Update("FindOptions", Options, "FindOptionsId", FindOptionsId);
                    ModifyTime = Convert.ToDateTime(Options["ModifyTime"]);
                }

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public Table Fetch()
        {
            string Query = String.Format(@"SELECT * FROM FindOptions ORDER BY SortOrderNo, Name");
            return this.Database.Select(Query);
        }

        //---------------------------------------------------------------------

        public Table Results()
        {
            string Query = String.Format(@"
                select
                    j.JournalId, j.CreateTime, j.ModifyTime,
                    j.ProjectId, p.Name as ProjectName,
                    j.ActivityId, a.Name as ActivityName,
                    j.LocationId, l.Name as LocationName,
                    j.CategoryId, c.Name as CategoryName,
                    j.StartTime, j.StopTime, j.Seconds,
                    j.Memo, j.IsLocked, j.JournalIndex
                from Journal j
                join Activity a on a.ActivityId = j.ActivityId
                join Project p on p.ProjectId = j.ProjectId
                join Location l on l.LocationId = j.LocationId
                join Category c on c.CategoryId = j.CategoryId
                where {0}
                order by {1}",
                this.FilterOptions.WhereClause, "j.JournalId");

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        //----------------------------------------------------------------------

    }
}
