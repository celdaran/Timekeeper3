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
    public partial class ListAttributeManager : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private object _CurrentItem = null;
        private bool IsNewItem;
        private bool ChangedOrder;

        protected enum ListAttributeKind { Location, Category };
        protected ListAttributeKind Kind;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ListAttributeManager()
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

        private void ListAttributeManager_Load(object sender, EventArgs e)
        {
            PopulateList();
        }

        //----------------------------------------------------------------------

        private void ListAttributeManager_FormClosing(object sender, FormClosingEventArgs e)
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

        private void AttributeName_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveItemButton.Enabled = true;
        }

        //----------------------------------------------------------------------

        private void AttributeDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            SaveItemButton.Enabled = true;
        }

        //----------------------------------------------------------------------

        protected void LocationTimeZone_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (LocationTimeZone.SelectedIndex != -1) {
                SaveItemButton.Enabled = true;
            }
        }

        //----------------------------------------------------------------------

        private void AttributeIsHiddenCheckBox_MouseDown(object sender, MouseEventArgs e)
        {
            SaveItemButton.Enabled = true;
        }

        //----------------------------------------------------------------------
        // Keyboard Events
        //----------------------------------------------------------------------

        private void ItemList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete) {
                DeleteItem();
            }
        }

        //----------------------------------------------------------------------
        // Unique Name Validator
        //----------------------------------------------------------------------

        private void AttributeName_Leave(object sender, EventArgs e)
        {
            string PreviousName;

            if (CurrentItem == null) {
                PreviousName = "";
            } else {
                Classes.ListAttribute ListAttribute = (Classes.ListAttribute)((IdObjectPair)CurrentItem).Object;
                PreviousName = ListAttribute.Name;
            }

            if (AttributeName.Text != PreviousName) {

                bool Exists = this.Kind == ListAttributeKind.Location ? 
                    Classes.Location.Exists(AttributeName.Text) : 
                    Classes.Category.Exists(AttributeName.Text);

                if (Exists) {
                    Common.Warn("This name already exists.");
                    AttributeName.Focus();
                }
            }
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
                Classes.ListAttribute ListAttribute = (Classes.ListAttribute)((IdObjectPair)ItemList.SelectedItem).Object;
                PopulateItem(ListAttribute);

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
            AttributeName.Text = "";
            AttributeDescription.Text = "";

            if (this.Kind == ListAttributeKind.Location) {
                Classes.Widgets Widgets = new Classes.Widgets();
                Widgets.SelectCurrentTimeZone(LocationTimeZone);
            }

            AttributeCreateTime.Text = "";
            AttributeModifyTime.Text = "";
            AttributeIsHiddenCheckBox.Checked = false;
            AttributeHiddenTime.Text = "";
        }

        //----------------------------------------------------------------------

        private void DeleteItem()
        {
            Classes.ListAttribute ListAttribute = (Classes.ListAttribute)((IdObjectPair)CurrentItem).Object;
            int LastIndex = ItemList.SelectedIndex;

            if (Common.WarnPrompt("Are you sure you want to delete \"" + ListAttribute.Name + "\"?") != DialogResult.Yes) {
                return;
            }

            if (ListAttribute.Delete()) {
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

            AttributeName.BackColor = Color;
            AttributeDescription.BackColor = Color;
            LocationTimeZone.BackColor = Color;

            AttributeName.Enabled = on;
            AttributeDescription.Enabled = on;
            LocationTimeZone.Enabled = on;

            AttributeName.ReadOnly = !on;
            AttributeDescription.ReadOnly = !on;

            AttributeIsHiddenCheckBox.Enabled = on;
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

        private void PopulateItem(Classes.ListAttribute ListAttribute)
        {
            AttributeName.Text = ListAttribute.Name;
            AttributeDescription.Text = ListAttribute.Description;

            if (this.Kind == ListAttributeKind.Location) {
                LocationTimeZone.SelectedIndex = (int)ListAttribute.RefTimeZoneId;
            }

            AttributeCreateTime.Text = ListAttribute.CreateTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            AttributeModifyTime.Text = ListAttribute.ModifyTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            AttributeIsHiddenCheckBox.Checked = ListAttribute.IsHidden;
            if (ListAttribute.IsHidden) {
                AttributeHiddenTime.Text = ListAttribute.HiddenTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            } else {
                AttributeHiddenTime.Text = "";
            }
        }

        //----------------------------------------------------------------------

        private void PopulateList()
        {
            // Clear List
            ItemList.Items.Clear();

            // Get Items
            List<IdObjectPair> Items = GetItems();

            // Now Populate List
            foreach (IdObjectPair Item in Items) {
                ItemList.Items.Add(Item);
            }

            // Changed Order
            ChangedOrder = false;
        }

        //----------------------------------------------------------------------

        protected virtual List<IdObjectPair> GetItems()
        {
            // This method must be overridden by the child forms.
            // While that sounds like the perfect time to use an
            // abstract method, that runs into all sorts of issues,
            // so we'll just leave it at this.
            List<IdObjectPair> Items = new List<IdObjectPair>();
            return Items;
        }

        //----------------------------------------------------------------------

        private void SaveItem()
        {
            if (IsNewItem) {
                if (CreateItem(ItemList.Items.Count)) {
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

                Location.Name = AttributeName.Text;
                Location.Description = AttributeDescription.Text;
                Location.RefTimeZoneId = LocationTimeZone.SelectedIndex;
                Location.IsHidden = AttributeIsHiddenCheckBox.Checked;

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

        protected virtual bool CreateItem(int sortOrderNo) { return false; }

        //----------------------------------------------------------------------

        protected virtual bool UpdateItem() { return false; }

        //----------------------------------------------------------------------

        private bool SavePrompt()
        {
            if (SaveItemButton.Enabled) {
                if (Common.WarnPrompt("Changes have not been saved. Would you like to save your changes now?") == DialogResult.Yes) {
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
                Classes.ListAttribute ListAttribute = (Classes.ListAttribute)Pair.Object;
                ListAttribute.Reposition(Index);
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

            Classes.ListAttribute ListAttribute = (Classes.ListAttribute)((IdObjectPair)ItemList.Items[e.Index]).Object;

            e.DrawBackground();
            Graphics g = e.Graphics;

            Color ItemColor;

            if (ListAttribute.IsHidden) {
                ItemColor = Color.Gray;
            } else {
                ItemColor = Color.Black;
            }

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected) {
                ItemColor = Color.White;
            }

            g.DrawString(ListAttribute.Name, e.Font, new SolidBrush(ItemColor), new PointF(e.Bounds.X, e.Bounds.Y));

            e.DrawFocusRectangle();
        }

        //----------------------------------------------------------------------

    }
}
