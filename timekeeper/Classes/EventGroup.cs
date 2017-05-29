using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    public class EventGroup : Classes.SortableItem
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        /*
        public string Name { get; set; }
        public string Description { get; set; }
        */

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public EventGroup()
            : base("EventGroup")
        {
        }

        //----------------------------------------------------------------------

        public EventGroup(long eventGroupId)
            : base("EventGroup", eventGroupId)
        {
        }

        //----------------------------------------------------------------------

        public Table Table()
        {
            // FIXME: This should be in (the currently non-existent) EventGroupCollection class
            return Timekeeper.Database.Select("SELECT EventGroupId AS Id, * FROM EventGroup ORDER BY SortOrderNo");
        }

        //----------------------------------------------------------------------
    }
}
