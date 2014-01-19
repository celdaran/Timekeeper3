using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms.Tools
{
    public partial class ManageEventGroups : Form
    {
        //
        // NOTES: Sorry, some heavy copy/paste here from Forms.Shared.ManageViews
        //

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ManageEventGroups()
        {
            InitializeComponent();
            LoadList();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void ManageEventGroups_Load(object sender, EventArgs e)
        {

        }

        //----------------------------------------------------------------------


        private void EventGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = EventGroupList.SelectedIndex;
            MoveUpButton.Enabled = (Index != 0);
            MoveDownButton.Enabled = (Index != EventGroupList.Items.Count - 1);
        }

        //----------------------------------------------------------------------

        private void AddButton_Click(object sender, EventArgs e)
        {
            Forms.Tools.EditEventGroup DialogBox = new Forms.Tools.EditEventGroup();
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                LoadList();
            }
        }

        //----------------------------------------------------------------------

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (EventGroupList.SelectedItem == null) {
                return;
            }

            IdObjectPair CurrentItem = (IdObjectPair)EventGroupList.SelectedItem;

            Forms.Tools.EditEventGroup DialogBox = new Forms.Tools.EditEventGroup(CurrentItem.Id);
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                LoadList();
            }
        }

        //----------------------------------------------------------------------

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (EventGroupList.SelectedItem == null) {
                return;
            }

            try {
                // Get Items
                IdObjectPair CurrentItem = (IdObjectPair)EventGroupList.SelectedItem;
                int Index = EventGroupList.Items.IndexOf(CurrentItem);
                IdObjectPair PreviousItem = (IdObjectPair)EventGroupList.Items[Index - 1];
                Classes.SortableItem CurrentGroup = (Classes.SortableItem)CurrentItem.Object;
                Classes.SortableItem PreviousGroup = (Classes.SortableItem)PreviousItem.Object;

                // Swap them
                SwapItems(CurrentGroup, PreviousGroup);

                // Repaint list
                LoadList();

                // Reselect previously selected item
                EventGroupList.SelectedIndex = Index - 1;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (EventGroupList.SelectedItem == null) {
                return;
            }

            try {
                // Get Items
                IdObjectPair CurrentItem = (IdObjectPair)EventGroupList.SelectedItem;
                int Index = EventGroupList.Items.IndexOf(CurrentItem);
                IdObjectPair NextItem = (IdObjectPair)EventGroupList.Items[Index + 1];
                Classes.SortableItem CurrentGroup = (Classes.SortableItem)CurrentItem.Object;
                Classes.SortableItem NextGroup = (Classes.SortableItem)NextItem.Object;

                // Swap them
                SwapItems(CurrentGroup, NextGroup);

                // Repaint list
                LoadList();

                // Reselect previously selected item
                EventGroupList.SelectedIndex = Index + 1;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // Private Helpers
        //----------------------------------------------------------------------

        private void LoadList()
        {
            EventGroupList.Items.Clear();

            List<Classes.SortableItem> Groups = new Classes.SortableItemCollection("EventGroup").Fetch();

            foreach (Classes.SortableItem Group in Groups) {
                IdObjectPair Pair = new IdObjectPair((int)Group.Id, Group);
                EventGroupList.Items.Add(Pair);
            }
        }

        //----------------------------------------------------------------------

        private void SwapItems(Classes.SortableItem firstGroup, Classes.SortableItem secondGroup)
        {
            // FIXME: Man, this didn't change a BIT from the ManageViews version. :-/

            try {
                int SavedFirstSortOrderNo = firstGroup.SortOrderNo;

                firstGroup.SortOrderNo = secondGroup.SortOrderNo;
                // FIXME: Consider SaveRow() without args calls SaveRow(false, 0)
                firstGroup.Save();

                secondGroup.SortOrderNo = SavedFirstSortOrderNo;
                secondGroup.Save();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

    }
}
