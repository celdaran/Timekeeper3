using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Items
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        protected DBI Data;
        protected string TableName;
        protected string OrderByClause;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Items(DBI data, string tableName, string orderByClause)
        {
            this.Data = data;
            this.TableName = tableName;
            this.OrderByClause = orderByClause;
        }

        //---------------------------------------------------------------------
        // Public Methods
        //---------------------------------------------------------------------

        public int Count()
        {
            string query = String.Format(@"select count(*) as Count from {0}", this.TableName);
            Row Row = Data.SelectRow(query);
            return (int)Row["Count"];
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
            Row Row = Data.SelectRow(Query);
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

        protected Table GetItems(long parentId, bool showHidden)
        {
            if (OrderByClause == "") {
                OrderByClause = "CreateTime";
            }

            string HiddenQualifier = "";
            if (!showHidden) {
                HiddenQualifier = "and IsHidden = 0";
            }

            string query = String.Format(@"
                select * from {0}
                where IsDeleted = 0
                  {1}
                  and ParentId = {2}
                order by {3}",
                this.TableName, HiddenQualifier, parentId, OrderByClause);

            Table Rows = Data.Select(query);

            return Rows;
        }

        //---------------------------------------------------------------------

    }
}
