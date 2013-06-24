using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Options
    {
        private DBI Database;

        private string _LastActivity;
        private string _LastProject;
        private string _LastGridView;
        private string _LastReportView;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Options()
        {
            this.Database = Timekeeper.Database;
            this.Load();
        }

        //---------------------------------------------------------------------

        private void Load()
        {
            try {
                Row Row;
                string Query;

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastActivity");
                Row = this.Database.SelectRow(Query);
                if (Row.Count > 0) {
                    this._LastActivity = Row["Value"];
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastProject");
                Row = this.Database.SelectRow(Query);
                if (Row.Count > 0) {
                    this._LastProject = Row["Value"];
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastGridView");
                Row = this.Database.SelectRow(Query);
                if (Row.Count > 0) {
                    this._LastGridView = Row["Value"];
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastReportView");
                Row = this.Database.SelectRow(Query);
                if (Row.Count > 0) {
                    this._LastReportView = Row["Value"];
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public string LastActivity
        {
            get { return _LastActivity; }

            set {
                _LastActivity = value;
                Save("LastActivity", value);
            }
        }

        //---------------------------------------------------------------------

        public string LastProject
        {
            get { return _LastProject; }

            set {
                _LastProject = value;
                Save("LastProject", value);
            }
        }

        //---------------------------------------------------------------------

        public string LastGridView
        {
            get { return _LastGridView; }

            set
            {
                _LastGridView = value;
                Save("LastGridView", value);
            }
        }

        //---------------------------------------------------------------------

        public string LastReportView
        {
            get { return _LastReportView; }

            set
            {
                _LastReportView = value;
                Save("LastReportView", value);
            }
        }

        //---------------------------------------------------------------------
        // Private helpers
        //---------------------------------------------------------------------

        private void Save(string columnName, string columnValue)
        {
            try {
                Row Row = new Row();
                Row["Value"] = columnValue;
                Row["ModifyTime"] = Common.Now();
                this.Database.Update("Options", Row, "Key", columnName);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------
    }
}
