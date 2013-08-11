using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    public partial class Location : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private object _CurrentItem = null;
        private bool IsNewItem;
        private bool ChangedOrder;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Location()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        // Accessors
        //----------------------------------------------------------------------

        public object CurrentItem { get { return _CurrentItem; } set { _CurrentItem = value; }}

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Location_Load(object sender, EventArgs e)
        {
            PopulateList();

            Classes.Widgets Widgets = new Classes.Widgets();
            Widgets.PopulateTimeZoneComboBox(LocationTimeZone);
            LocationTimeZone.SelectedIndex = -1;
        }

        //----------------------------------------------------------------------

        private void Location_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save new item ordering, unconditionally
            ReorderItems();

            // Ask to save any unsaved work
            if (SavePrompt()) {
                SaveItem();
            }
        }

        //----------------------------------------------------------------------

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------
        // Toolbar Button events
        //----------------------------------------------------------------------

        private void MoveToTopButton_Click(object sender, EventArgs e)
        {
            MoveItem(0);
        }

        //----------------------------------------------------------------------

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            MoveItem(ItemList.SelectedIndex - 1);
        }

        //----------------------------------------------------------------------

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            MoveItem(ItemList.SelectedIndex + 1);
        }

        //----------------------------------------------------------------------

        private void MoveToBottomButton_Click(object sender, EventArgs e)
        {
            MoveItem(ItemList.Items.Count - 1);
        }

        //----------------------------------------------------------------------

        private void NewItemButton_Click(object sender, EventArgs e)
        {
            EnableEditing();
            ClearForm();
            IsNewItem = true;
            NewItemButton.Enabled = !IsNewItem;
        }

        //----------------------------------------------------------------------

        private void SaveItemButton_Click(object sender, EventArgs e)
        {
            SaveItem();
        }

        //----------------------------------------------------------------------

        private void DeleteItemButton_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }
        //----------------------------------------------------------------------
        // Dirty Events
        //----------------------------------------------------------------------

        private void LocationName_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveItemButton.Enabled = true;
        }

        //----------------------------------------------------------------------

        private void LocationDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveItemButton.Enabled = true;
        }

        //----------------------------------------------------------------------

        private void LocationTimeZone_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LocationTimeZone.SelectedIndex != -1) {
                SaveItemButton.Enabled = true;
            }
        }

        //----------------------------------------------------------------------

        private void LocationHiddenCheckBox_MouseDown(object sender, MouseEventArgs e)
        {
            SaveItemButton.Enabled = true;
        }

        //----------------------------------------------------------------------
        // To Be Categorized
        //----------------------------------------------------------------------

        private void ItemList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemList.SelectedItem != null) {

                // If we changed items without saving any previous changes,
                // prompt for that here and then save the item.
                if (SavePrompt()) {
                    SaveItem();
                }

                IsNewItem = false;
                NewItemButton.Enabled = !IsNewItem;

                // Change displayed values
                Classes.Location Location = (Classes.Location)((IdObjectPair)ItemList.SelectedItem).Object;
                PopulateItem(Location);

                // Now make any necessary UI changes

                EnableEditing();

                MoveToTopButton.Enabled = true;
                MoveUpButton.Enabled = true;
                MoveDownButton.Enabled = true;
                MoveToBottomButton.Enabled = true;

                if (ItemList.SelectedIndex == 0) {
                    MoveToTopButton.Enabled = false;
                    MoveUpButton.Enabled = false;
                }
                if (ItemList.SelectedIndex == ItemList.Items.Count - 1) {
                    MoveDownButton.Enabled = false;
                    MoveToBottomButton.Enabled = false;
                }

                DeleteItemButton.Enabled = true;

                // Update CurrentItem
                CurrentItem = ItemList.SelectedItem;
            }
        }

        //----------------------------------------------------------------------
        // Helper Methods
        //----------------------------------------------------------------------

        private void ClearForm()
        {
            LocationName.Text = "";
            LocationDescription.Text = "";

            Classes.Widgets Widgets = new Classes.Widgets();
            Widgets.SelectCurrentTimeZone(LocationTimeZone);

            LocationCreateTime.Text = "";
            LocationModifyTime.Text = "";
            LocationHiddenCheckBox.Checked = false;
            LocationHiddenTime.Text = "";
        }

        //----------------------------------------------------------------------

        private void DeleteItem()
        {
            Classes.Location Location = (Classes.Location)((IdObjectPair)CurrentItem).Object;
            int LastIndex = ItemList.SelectedIndex;

            if (Common.WarnPrompt("Are you sure you want to delete \"" + Location.Name + "\"?") != DialogResult.Yes) {
                return;
            }

            if (Location.Delete()) {
                PopulateList();

                if (ItemList.Items.Count == 0) {
                    DisableEditing();
                    ClearForm();
                    DeleteItemButton.Enabled = false;
                } else {
                    if ((LastIndex > -1) && (LastIndex < ItemList.Items.Count)) {
                        ItemList.SelectedIndex = LastIndex;
                    } else if (LastIndex == ItemList.Items.Count) {
                        ItemList.SelectedIndex = ItemList.Items.Count - 1;
                    } else if (LastIndex > -1) {
                        ItemList.SelectedIndex = 0;
                    } else {
                        // Do nothing: this should be an empty list
                        Common.Info("Empty List detected");
                    }
                }

            } else {
                Common.Warn("There was an error deleting the item.");
            }
        }

        //----------------------------------------------------------------------

        private void DisableEditing()
        {
            SetEditing(false);
        }

        //----------------------------------------------------------------------

        private void EnableEditing()
        {
            SetEditing(true);
        }

        //----------------------------------------------------------------------

        private void SetEditing(bool on)
        {
            Color Color = on ? SystemColors.Window : SystemColors.Control;

            LocationName.BackColor = Color;
            LocationDescription.BackColor = Color;
            LocationTimeZone.BackColor = Color;

            LocationName.Enabled = on;
            LocationDescription.Enabled = on;
            LocationTimeZone.Enabled = on;

            LocationName.ReadOnly = !on;
            LocationDescription.ReadOnly = !on;

            LocationHiddenCheckBox.Enabled = on;
        }

        //----------------------------------------------------------------------

        private void MoveItem(int moveTo)
        {
            if (ItemList.SelectedIndex > -1) {
                IdObjectPair Pair = (IdObjectPair)ItemList.SelectedItem;
                ItemList.Items.RemoveAt(ItemList.SelectedIndex);
                ItemList.Items.Insert(moveTo, Pair);
                ItemList.SelectedIndex = moveTo;
                ChangedOrder = true;
            }
        }

        //----------------------------------------------------------------------

        private void PopulateItem(Classes.Location Location)
        {
            LocationName.Text = Location.Name;
            LocationDescription.Text = Location.Description;
            LocationTimeZone.SelectedIndex = (int)Location.RefTimeZoneId;
            LocationCreateTime.Text = Location.CreateTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            LocationModifyTime.Text = Location.ModifyTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            LocationHiddenCheckBox.Checked = Location.IsHidden;
            if (Location.IsHidden) {
                LocationHiddenTime.Text = Location.HiddenTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            } else {
                LocationHiddenTime.Text = "";
            }
        }

        //----------------------------------------------------------------------

        private void PopulateList()
        {
            // Clear List
            ItemList.Items.Clear();

            // Get Locations
            Classes.Locations Locations = new Classes.Locations();
            List<IdObjectPair> Items = Locations.Fetch(true);

            // Now Populate List
            foreach (IdObjectPair Item in Items) {
                ItemList.Items.Add(Item);
            }

            // Changed Order
            ChangedOrder = false;
        }

        //----------------------------------------------------------------------

        private void SaveItem()
        {
            if (IsNewItem) {
                Classes.Location Location = new Classes.Location();
                int LastIndex = ItemList.SelectedIndex;

                Location.Name = LocationName.Text;
                Location.Description = LocationDescription.Text;
                Location.RefTimeZoneId = LocationTimeZone.SelectedIndex;
                Location.SortOrderNo = ItemList.Items.Count;
                Location.IsHidden = LocationHiddenCheckBox.Checked;

                if (Location.Create()) {
                    SaveItemButton.Enabled = false;
                    PopulateList();
                    ItemList.SelectedIndex = ItemList.Items.Count - 1;
                    IsNewItem = false;
                    NewItemButton.Enabled = !IsNewItem;
                    DeleteItemButton.Enabled = true;
                } else {
                    Common.Warn("There was an error creating the new item.");
                }
            }
            else {
                Classes.Location Location = (Classes.Location)((IdObjectPair)CurrentItem).Object;

                Location.Name = LocationName.Text;
                Location.Description = LocationDescription.Text;
                Location.RefTimeZoneId = LocationTimeZone.SelectedIndex;
                Location.IsHidden = LocationHiddenCheckBox.Checked;

                if (Location.Save()) {
                    SaveItemButton.Enabled = false;
                    PopulateItem(Location);
                    ItemList.Refresh();
                } else {
                    Common.Warn("There was an error saving the item.");
                }
            }
        }

        //----------------------------------------------------------------------

        private bool SavePrompt()
        {
            if (SaveItemButton.Enabled) {
                if (Common.WarnPrompt("Changes to this item have not been saved. Would you like to save them?") == DialogResult.Yes) {
                    return true;
                } else {
                    return false;
                }
            }
            return false;
        }

        //----------------------------------------------------------------------

        private void ReorderItems()
        {
            if (!ChangedOrder) {
                return;
            }

            int Index = 0;
            foreach (object Item in ItemList.Items) {
                IdObjectPair Pair = (IdObjectPair)Item;
                Classes.Location Location = (Classes.Location)Pair.Object;
                Location.Reposition(Index);
                Index++;
            }
        }

        //----------------------------------------------------------------------
        // User Interface Helpers
        //----------------------------------------------------------------------

        private void ItemList_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) {
                return;
            }

            Classes.Location Location = (Classes.Location)((IdObjectPair)ItemList.Items[e.Index]).Object;

            e.DrawBackground();
            Graphics g = e.Graphics;

            Color ItemColor;

            if (Location.IsHidden) {
                ItemColor = Color.Gray;
            } else {
                ItemColor = Color.Black;
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                ItemColor = Color.White;
            }

            g.DrawString(Location.Name, e.Font, new SolidBrush(ItemColor), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        /*
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData) {
                case (Keys.Control | Keys.S):
                    {
                        SaveItem();
                        break;
                    }
                }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        */

        private void ItemList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                DeleteItem();
            }
        }

        private void LocationName_Leave(object sender, EventArgs e)
        {
            string PreviousName;

            if (CurrentItem == null) {
                PreviousName = "";
            } else {
                Classes.Location Location = (Classes.Location)((IdObjectPair)CurrentItem).Object;
                PreviousName = Location.Name;
            }

            if (LocationName.Text != PreviousName) {
                bool Exists = Classes.Location.Exists(LocationName.Text);
                if (Exists) {
                    Common.Warn("This name already exists.");
                    LocationName.Focus();
                }
            }
        }

        private void LocationName_TextChanged(object sender, EventArgs e)
        {

        }

        //----------------------------------------------------------------------

    }
}
