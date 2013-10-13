using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class EventGroup
    {
        public EventGroup()
        {
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
