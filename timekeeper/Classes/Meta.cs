using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

using Timekeeper.Classes.Toolbox;

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

        private DBI Database;

        //---------------------------------------------------------------------

        public DateTimeOffset Created;
        public DateTimeOffset Upgraded;
        public Version Version;
        public string Id;
        public int ProcessId;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Meta()
        {
            this.Database = Timekeeper.Database;

            try {
                Table Rows = new Table();
                string Query = String.Format(@"select * from {0} order by MetaId", Timekeeper.MetaTableName());
                Rows = this.Database.Select(Query);

                this.Created = Timekeeper.StringToDate(Rows[0]["Value"]);
                this.Upgraded = Timekeeper.StringToDate(Rows[1]["Value"]);
                this.Version = new Version(Rows[2]["Value"]);
                this.Id = Rows[3]["Value"];
                this.ProcessId = Convert.ToInt32(Rows[4]["Value"]);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public bool MarkInUse()
        {
            this.ProcessId = Process.GetCurrentProcess().Id;
            return Save("ProcessId", this.ProcessId.ToString());
        }

        //---------------------------------------------------------------------

        public bool MarkFree()
        {
            return Save("ProcessId", "0");
        }

        //---------------------------------------------------------------------

        private bool Save(string key, string value)
        {
            try {
                Row Meta = new Row();
                Meta["Value"] = value;

                if (this.Database.Update(Timekeeper.MetaTableName(), Meta, "Key", key) > 0) {
                    return true;
                } else {
                    throw new Exception("Error marking file in use.");
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }
        }

        //---------------------------------------------------------------------

    }
}
