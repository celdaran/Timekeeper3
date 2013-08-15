using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public partial class Options
    {
        //-----------------------------------------------------------------------
        // Load Options
        //-----------------------------------------------------------------------

        private void LoadFromDatabase()
        {
            try {
                Row Option;
                string Query;

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastProjectId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    this._Database_LastProjectId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastActivityId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    this._Database_LastActivityId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastGridViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    this._Database_LastGridViewId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastReportViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    this._Database_LastReportViewId = Convert.ToInt64(Option["Value"]);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // Accessors
        //----------------------------------------------------------------------

        // FIXME/TODO: I'm not sure about the "auto save to database upon assignment" nature of this.
        // Come back to this later after the whole Options overhaul develops, and model it more after
        // the Registry-based settings.

        public long LastProjectId
        {
            get { return _Database_LastProjectId; }

            set
            {
                _Database_LastProjectId = value;
                _SaveToDatabase("LastProjectId", value.ToString());
            }
        }

        //----------------------------------------------------------------------

        public long LastActivityId
        {
            get { return _Database_LastActivityId; }

            set
            {
                _Database_LastActivityId = value;
                _SaveToDatabase("LastActivityId", value.ToString());
            }
        }

        //----------------------------------------------------------------------

        public long LastGridViewId
        {
            get { return _Database_LastGridViewId; }

            set
            {
                _Database_LastGridViewId = value;
                _SaveToDatabase("LastGridViewId", value.ToString());
            }
        }

        //----------------------------------------------------------------------

        public long LastReportViewId
        {
            get { return _Database_LastReportViewId; }

            set
            {
                _Database_LastReportViewId = value;
                _SaveToDatabase("LastReportViewId", value.ToString());
            }
        }

        //----------------------------------------------------------------------
        // Private helpers
        //----------------------------------------------------------------------

        private void _SaveToDatabase(string columnName, string columnValue)
        {
            try {
                Row Options = new Row();

                Options["Value"] = columnValue;
                Options["ModifyTime"] = Common.Now();

                this.Database.Update("Options", Options, "Key", columnName);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

    }
}
