using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class EventGroup
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public EventGroup()
        {
        }

        public EventGroup(long eventGroupId)
        {
            String Query = String.Format("SELECT * FROM EventGroup WHERE EventGroupId = {0}", eventGroupId);

            Row EventGroup = Timekeeper.Database.SelectRow(Query);

            this.Name = EventGroup["Name"];
            this.Description = EventGroup["Description"];
        }

        public Table Table()
        {
            return Timekeeper.Database.Select("select EventGroupId as Id, * from EventGroup");
        }

        /*
        public List<IdObjectPair> Table()
        {
            List<IdObjectPair> ReturnValue = new List<IdObjectPair>();

            Table Table = Timekeeper.Database.Select("select * from EventGroup");
            foreach (Row EventGroup in Table) {
                IdObjectPair Pair = new IdObjectPair(EventGroup["EventGroupId"], EventGroup);
                ReturnValue.Add(Pair);
            }

            return ReturnValue;
        }
        */
    }
}
