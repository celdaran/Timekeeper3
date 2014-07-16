using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class TreeAttributeCollection
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        protected DBI Database;
        protected string TableName;
        protected string OrderByClause;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public TreeAttributeCollection(string tableName, string orderByClause)
        {
            this.Database = Timekeeper.Database;
            this.TableName = tableName;
            this.OrderByClause = orderByClause;
        }

        //---------------------------------------------------------------------

        public List<Classes.TreeAttribute> Fetch(long parentId, bool showHidden, DateTimeOffset showHiddenSince)
        {
            Table Table = this.GetItems(parentId, showHidden, showHiddenSince);

            List<Classes.TreeAttribute> TreeAttributes = new List<Classes.TreeAttribute>();

            foreach (Row Row in Table) {
                var KeyColumnName = this.TableName + "Id";
                var TreeAttribute = new Classes.TreeAttribute(Row[KeyColumnName], this.TableName, KeyColumnName);
                TreeAttributes.Add(TreeAttribute);
            }

            return TreeAttributes;
        }

        //---------------------------------------------------------------------
        // Public Methods
        //---------------------------------------------------------------------

        public int Count()
        {
            string query = String.Format(@"select count(*) as Count from {0}", this.TableName);
            Row Row = Database.SelectRow(query);
            return (int)Row["Count"];
        }

        //---------------------------------------------------------------------

        public Table GetFolders()
        {
            // FIXME: This Order By clause should honor the Timekeeper.Options global "order" setting
            string Query = String.Format(
                @"select {0} as Id, Name from {1} where IsDeleted = 0 and IsHidden = 0 and IsFolder = 1 order by CreateTime",
                this.TableName + "Id", this.TableName);
            return Database.Select(Query);
        }

        //---------------------------------------------------------------------

        public bool HasParents()
        {
            string Query = String.Format(@"
                select count(*) as Count 
                from {0} 
                where IsDeleted = 0
                  and IsHidden = 0 
                  and ParentId > 0",
                this.TableName);
            Row Row = Database.SelectRow(Query);
            long count = Row["Count"];

            if (count > 0) {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------
        // Protected Methods
        //---------------------------------------------------------------------

        protected Table GetItems(long parentId, bool showHidden, DateTimeOffset showHiddenSince)
        {
            if (OrderByClause == "") {
                OrderByClause = "CreateTime";
            }

            string HiddenQualifier = "";
            if (showHidden) {
                string HiddenSince = showHiddenSince.ToString(Common.UTC_DATETIME_FORMAT);
                HiddenQualifier = "and ((IsHidden = 0) or (IsHidden = 1 and HiddenTime > '" + HiddenSince + "'))";
            } else {
                HiddenQualifier = "and IsHidden = 0";
            }

            string Query = String.Format(@"
                select * from {0}
                where IsDeleted = 0
                  {1}
                  and ParentId = {2}
                order by {3}",
                this.TableName, HiddenQualifier, parentId, OrderByClause);

            Table Rows = Database.Select(Query);

            return Rows;
        }

        //---------------------------------------------------------------------

    }
}
