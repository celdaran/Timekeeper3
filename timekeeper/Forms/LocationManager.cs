using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    public partial class LocationManager : Forms.ListAttributeManager
    {
        //----------------------------------------------------------------------
        // Constructor for Subclassed Form
        //----------------------------------------------------------------------

        public LocationManager()
            : base()
        {
            InitializeComponent();

            this.Kind = ListAttributeKind.Location;

            LocationTimeZone.Visible = true;
            LocationTimeZoneLabel.Visible = true;
        }

        //----------------------------------------------------------------------
        // Form Methods
        //----------------------------------------------------------------------

        private void LocationManager_Load(object sender, EventArgs e)
        {
            Classes.Widgets Widgets = new Classes.Widgets();
            Widgets.PopulateTimeZoneComboBox(LocationTimeZone);
            LocationTimeZone.SelectedIndex = -1;
        }

        //----------------------------------------------------------------------
        // "Callbacks"
        //----------------------------------------------------------------------

        protected override List<IdObjectPair> GetItems()
        {
            Classes.LocationCollection Locations = new Classes.LocationCollection();
            List<IdObjectPair> Items = Locations.Fetch(true);
            return Items;
        }

        //----------------------------------------------------------------------

        protected override bool CreateItem(int sortOrderNo)
        {
            Classes.Location Location = new Classes.Location();

            Location.Name = AttributeName.Text;
            Location.Description = AttributeDescription.Text;
            Location.RefTimeZoneId = LocationTimeZone.SelectedIndex;
            Location.SortOrderNo = sortOrderNo;
            Location.IsHidden = AttributeIsHiddenCheckBox.Checked;

            return Location.Create();
        }

        //----------------------------------------------------------------------

        protected override bool UpdateItem()
        {
            Classes.Location Location = (Classes.Location)((IdObjectPair)CurrentItem).Object;

            Location.Name = AttributeName.Text;
            Location.Description = AttributeDescription.Text;
            Location.RefTimeZoneId = LocationTimeZone.SelectedIndex;
            Location.IsHidden = AttributeIsHiddenCheckBox.Checked;

            return Location.Save();
        }

        //----------------------------------------------------------------------

    }
}
