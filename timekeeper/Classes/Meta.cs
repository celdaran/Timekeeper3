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

        private DBI Database;

        //---------------------------------------------------------------------

        public DateTime Created;
        public DateTime Upgraded;
        public Version Version;
        public string Id;

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

                this.Created = Convert.ToDateTime(Rows[0]["Value"]);
                this.Upgraded = Convert.ToDateTime(Rows[1]["Value"]);
                this.Version = new Version(Rows[2]["Value"]);
                this.Id = Rows[3]["Value"];
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

    }
}
