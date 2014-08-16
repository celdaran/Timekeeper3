using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class Audit
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private Classes.Options Options;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Audit()
        {
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
        }

        //----------------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------------

        public void DatabaseChecked(long issueCount)
        {
            string AuditMessage =
                String.Format("Database checked with {0} issue(s) found.",
                    issueCount);
            Log("DatabaseChecked", AuditMessage);
        }

        //----------------------------------------------------------------------

        public void DatabaseCreated(Version version)
        {
            string AuditMessage = String.Format("Database created with schema version {0}",
                version);
            Log("DatabaseCreated", AuditMessage);
        }

        //----------------------------------------------------------------------

        public void DatabaseDowngraded(Version fromVersion, Version toVersion)
        {
            string AuditMessage =
                String.Format("Database downgraded from schema version {0} to {1}",
                    fromVersion, toVersion);
            Log("DatabaseDowngraded", AuditMessage);
        }

        //----------------------------------------------------------------------

        public void DatabaseUpgraded(Version fromVersion, Version toVersion)
        {
            string AuditMessage =
                String.Format("Database upgraded from schema version {0} to {1}",
                    fromVersion, toVersion);
            Log("DatabaseUpgraded", AuditMessage);
        }

        //----------------------------------------------------------------------

        private void Log(string actionText, string eventText)
        {
            Row Audit = new Row();
            Audit["EventTime"] = Timekeeper.DateForDatabase();
            Audit["Action"] = actionText;
            Audit["Memo"] = eventText;
            this.Database.Insert("Audit", Audit);
        }

        //----------------------------------------------------------------------

    }
}
