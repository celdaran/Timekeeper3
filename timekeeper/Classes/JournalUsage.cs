using System;
using System.Collections.Generic;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    public class JournalUsage
	{
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Database;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public JournalUsage()
        {
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Primary Methods
        //---------------------------------------------------------------------

        public bool Update()
        {
            var dimensions = new Dictionary<int, string> {
                { 1, "Project" },
                { 2, "Activity" },
                { 3, "Location" },
                { 4, "Category" }
            };

            try
            {
                Database.Begin();

                foreach (var dim in dimensions)
                {
                    int dimId = dim.Key;
                    string tableName = dim.Value;

                    // 1. Scrub orphaned rows for this dimension
                    Database.Exec($@"
                        DELETE FROM JournalUsage 
                        WHERE RefDimensionId = {dimId} 
                          AND DimensionId NOT IN (SELECT {tableName}Id FROM {tableName})");

                    // 2. Refresh/Upsert the latest stats
                    string sql = $@"
                        INSERT OR REPLACE INTO JournalUsage (
                            RefDimensionId, 
                            DimensionId, 
                            TotalCount, 
                            TotalSeconds,
                            LastMonthCount, 
                            LastMonthSeconds
                        )
                        SELECT 
                            {dimId}, 
                            src.{tableName}Id,
                            COUNT(j.{tableName}Id),
                            SUM(IFNULL(j.Seconds, 0)),
                            COUNT(CASE WHEN j.StartTime >= date('now', '-1 month') THEN 1 END),
                            SUM(CASE WHEN j.StartTime >= date('now', '-1 month') THEN IFNULL(j.Seconds, 0) ELSE 0 END)
                        FROM {tableName} src
                        LEFT JOIN Journal j ON src.{tableName}Id = j.{tableName}Id
                        GROUP BY src.{tableName}Id";

                    this.Database.Exec(sql);
                }

                this.Database.Commit();

                return true;
            }
            catch (Exception x)
            {
                this.Database.Rollback();
                Timekeeper.Exception(x);
                return false;
            }
        }
    }

}
