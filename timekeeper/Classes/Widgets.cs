using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    partial class Widgets
    {
        //----------------------------------------------------------------------
        // UI Helper Class
        //----------------------------------------------------------------------

        private DBI Database;
        private Classes.Options Options;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Widgets() {
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
        }

        //----------------------------------------------------------------------
        // Drop Down Populators
        //----------------------------------------------------------------------

        public void PopulateLocationComboBox(ComboBox box)
        {
            try {
                //----------------------------------------
                // Add items from database
                //----------------------------------------

                LocationCollection Locations = new LocationCollection();
                List<IdObjectPair> Items = Locations.Fetch();

                PopulateGenericComboBox(box, Items);

                //----------------------------------------
                // Add special item
                //----------------------------------------

                Location Location = new Location();
                Location.Id = -1;
                Location.Name = "(Manage Entries...)";

                IdObjectPair NewEntry = new IdObjectPair(-1, Location);
                box.Items.Add(NewEntry);

                box.SelectedIndex = -1;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void PopulateCategoryComboBox(ComboBox box)
        {
            try {
                //----------------------------------------
                // Add items from database
                //----------------------------------------

                CategoryCollection Categories = new CategoryCollection();
                List<IdObjectPair> Items = Categories.Fetch();

                PopulateGenericComboBox(box, Items);

                //----------------------------------------
                // Add special item
                //----------------------------------------

                Category Category = new Category();
                Category.Id = -1;
                Category.Name = "(Manage Entries...)";

                IdObjectPair NewEntry = new IdObjectPair(-1, Category);
                box.Items.Add(NewEntry);

                box.SelectedIndex = -1;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void PopulateGenericComboBox(ComboBox box, List<IdObjectPair> items)
        {
            foreach (IdObjectPair Pair in items) {
                box.Items.Add(Pair);
            }
        }

        //----------------------------------------------------------------------
        // Experimental

        public void PopulateGenericComboBox(ComboBox box, Table table)
        {
            try {
                foreach (Row Row in table) {
                    IdObjectPair Pair = new IdObjectPair((int)Row["Id"], Row["Name"]);
                    box.Items.Add(Pair);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void PopulateTimeZoneComboBox(ComboBox box)
        {
            try {
                ReadOnlyCollection<TimeZoneInfo> TimeZones = TimeZoneInfo.GetSystemTimeZones();

                TimeZone CurrentTimeZone = TimeZone.CurrentTimeZone;
                int CurrentIndex = 0;

                foreach (TimeZoneInfo timeZone in TimeZones) {

                    IdObjectPair Pair = new IdObjectPair(CurrentIndex + 1, timeZone);

                    box.Items.Add(Pair);
                    if (CurrentTimeZone.StandardName == timeZone.StandardName) {
                        box.SelectedIndex = CurrentIndex;
                    }
                    CurrentIndex++;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void SelectCurrentTimeZone(ComboBox box)
        {
            TimeZone CurrentTimeZone = TimeZone.CurrentTimeZone;
            TimeZoneInfo CurrentTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(CurrentTimeZone.StandardName);
            int Index = box.FindString(CurrentTimeZoneInfo.DisplayName);
            box.SelectedIndex = Index;
        }

        //----------------------------------------------------------------------

    }
}
