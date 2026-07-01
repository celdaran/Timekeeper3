using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    public class AuditView : BaseView
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private static string ViewTableName = "AuditView";

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public AuditView() : base(ViewTableName)
        {
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public Table JournalResults(string auditDate, string whereClause)
        {
            var offset = this.Options.Advanced_Other_MidnightOffset;
            string offsetString = $"{offset:D2}:00";

            string Query = String.Format(@"
                WITH vars AS (
                    SELECT '{0}' AS base_date
                )
                SELECT
                    j.JournalId,
                    j.IsReconciled,
                    j.ReconcileTime,
                    time(j.StartTime) as `ShortStartTime`,
                    time(j.StopTime) as `ShortStopTime`,
                    time(j.Seconds, 'unixepoch') as `Duration`,

                    -- Find gaps between entries with a correlated subquery
                    ROUND((julianday(j.StartTime) - julianday((
                        SELECT prev.StopTime 
                        FROM Journal prev 
                        WHERE prev.StartTime < j.StartTime
                        ORDER BY prev.StartTime DESC 
                        LIMIT 1
                    ))) * 1440, 2) as `Gap`,

                    -- Corrected Windowless Running Total with isolated math execution blocks
                        PRINTF('%02d', (
                            SELECT SUM(rt.Seconds) 
                            FROM Journal rt 
                            WHERE rt.StartTime >= datetime(vars.base_date || ' {1}')
                              AND rt.StartTime <= j.StartTime
                        ) / 3600) || ':' ||
                        PRINTF('%02d', ((
                            SELECT SUM(rt.Seconds) 
                            FROM Journal rt 
                            WHERE rt.StartTime >= datetime(vars.base_date || ' {1}')
                              AND rt.StartTime <= j.StartTime
                        ) % 3600) / 60) || ':' ||
                        PRINTF('%02d', (
                            SELECT SUM(rt.Seconds) 
                            FROM Journal rt 
                            WHERE rt.StartTime >= datetime(vars.base_date || ' {1}')
                              AND rt.StartTime <= j.StartTime
                        ) % 60) as `RunningTotal`,

                    p.ProjectId, p.Name as `ProjectName`,
                    a.ActivityId, a.Name as `ActivityName`,
                    l.LocationId, l.Name as `LocationName`,
                    c.CategoryId, c.Name as `CategoryName`,
                    substr(replace(j.Memo, char(10), ' '), 1, 32) as `MemoExcerpt`,
                    j.CreateTime,
                    j.ModifyTime
                FROM Journal j
                CROSS JOIN vars    
                JOIN Project p on p.ProjectId = j.ProjectId
                JOIN Activity a on a.ActivityId = j.ActivityId
                JOIN Location l on l.LocationId = j.LocationId
                JOIN Category c on c.CategoryId = j.CategoryId
                WHERE j.StartTime >= datetime(vars.base_date || ' {1}')
                  AND j.StartTime <  datetime(vars.base_date || ' {1}', '+1 day')
                ORDER BY {2};",
                auditDate, offsetString, whereClause);

            Table FindResults = Database.Select(Query);

            return FindResults;
        }

        public long ReconcileAll(string auditDate)
        {
            var offset = this.Options.Advanced_Other_MidnightOffset;
            string offsetString = $"{offset:D2}:00";

            string Query = String.Format(@"
                Journal
                SET IsReconciled = 1,
                    ReconcileTime = datetime('now')
                WHERE StartTime >= datetime('{0} {1}')
                    AND StartTime <  datetime('{0} {1}', '+1 day')
                    AND IsReconciled = 0",
                auditDate, offsetString);
            return Database.Update(Query);
        }

        public Boolean IsDateValid(string auditDate)
        {
            return DateTime.TryParseExact(auditDate, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out _);
        }

        public string GetDateAfterMostRecentlyReconciledEntry()
        {
            var offset = 24 - this.Options.Advanced_Other_MidnightOffset;

            string Query = String.Format(@"
                SELECT DATE(MAX(StartTime), '{0} hours') AS LastReconciledDate
                FROM Journal
                WHERE IsReconciled = 1", offset);
            Table FindResults = Database.Select(Query);
            if (FindResults.Count > 0)
            {
                if (FindResults[0]["LastReconciledDate"] == null)
                {
                    // If there's no reconciled entry, start over
                    return GetFirstDayToReconcile();
                }
                return FindResults[0]["LastReconciledDate"];
            }
            else
            {
                // If the query failed for whatever reason, start over
                return GetFirstDayToReconcile();
            }
        }

        public string GetFirstDayToReconcile()
        {
            return GetPrevDateFromJournal(DateTime.Today.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture));
        }

        public string GetPrevDateFromJournal(string auditDate)
        {
            var offset = this.Options.Advanced_Other_MidnightOffset;

            string Query = String.Format(@"
                SELECT DATE(MAX(StartTime), '-{1} hours') AS PrevDate
                FROM Journal
                WHERE StartTime < DATETIME('{0}', '+{1} hours')
                  AND IsReconciled = 0
                ORDER BY StartTime DESC
                LIMIT 1", auditDate, offset);
            Table FindResults = Database.Select(Query);
            if (FindResults.Count > 0)
            {
                if (FindResults[0]["PrevDate"] == null)
                {
                    // If there's no previous date, start over
                    return GetFirstDayToReconcile();
                }
                return FindResults[0]["PrevDate"];
            }
            else
            {
                // If there was a problem with the query, start over
                return GetFirstDayToReconcile();
            }
        }

        public string GetNextDateFromJournal(string auditDate)
        {
            var offset = this.Options.Advanced_Other_MidnightOffset;
            var offset2 = offset + 24;

            string Query = String.Format(@"
                SELECT DATE(MIN(StartTime), '-{1} hours') as NextDate
                FROM Journal
                WHERE StartTime >= DATETIME('{0}', '+{2} hours')
                  AND IsReconciled = 0
                ORDER BY StartTime ASC
                LIMIT 1", auditDate, offset, offset2);

            Table FindResults = Database.Select(Query);
            if (FindResults.Count > 0)
            {
                if (FindResults[0]["NextDate"] == null)
                {
                    // If there's no next date, wrap around to oldest to-be-reconciled entry
                    return GetDateAfterMostRecentlyReconciledEntry();
                } else
                {
                    return FindResults[0]["NextDate"];
                }
            }
            else
            {
                // If the query failed for whatever reason, start over
                return GetFirstDayToReconcile();
            }
        }

    }
}
