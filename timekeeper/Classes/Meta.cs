using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

//---------------------------------------------------------------------
// I'd like to use this as a model for how I'd like to approach data
// access going forward: both at the TBX level and the application 
// level. In short: keep it strongly typed.
//---------------------------------------------------------------------

namespace Timekeeper.Classes
{
    class Meta
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Data;

        //---------------------------------------------------------------------

        public DateTime Created;
        public Version Version;
        public string Id;

        private string _LastActivity;
        private string _LastProject;
        private string _LastGridView;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Meta()
        {
            this.Data = Timekeeper.Database;

            try {
                Table Rows = new Table();
                Rows = this.Data.Select("select * from Meta order by MetaId");

                this.Created = Convert.ToDateTime(Rows[0]["Value"]);
                this.Version = new Version(Rows[1]["Value"]);
                this.Id = Rows[2]["Value"];
                this._LastActivity = Rows[3]["Value"];
                this._LastProject = Rows[4]["Value"];
                this._LastGridView = Rows[5]["Value"];
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
        // Private helpers
        //---------------------------------------------------------------------

        private void Save(string columnName, string columnValue)
        {
            try {
                Row Row = new Row();
                Row["Value"] = columnValue;
                Row["ModifyTime"] = Common.Now();
                this.Data.Update("Meta", Row, "Key", columnName);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

    }
}
