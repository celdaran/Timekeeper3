using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Shared
{
    public partial class ManageViews : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        // FIXME: red flag! Any class under Timekeeper.Forms that has a DBI
        // connection is wrong. Everything here should be using the application
        // object layer, not talking to the database directly.

        // NOTE: Already fixed here, but leaving this as a reminder to make a
        // pass through all other forms / dialog boxes.

        //private DBI Database;

        private string TableName;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ManageViews(string tableName)
        {
            InitializeComponent();
            this.TableName = tableName;
            LoadList();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void SavedViewList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = SavedViewList.SelectedIndex;
            MoveUpButton.Enabled = (Index != 0);
            MoveDownButton.Enabled = (Index != SavedViewList.Items.Count - 1);
        }

        //----------------------------------------------------------------------

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            if (SavedViewList.SelectedItem == null) {
                return;
            }

            try {
                // Get Items
                IdObjectPair CurrentItem = (IdObjectPair)SavedViewList.SelectedItem;
                int Index = SavedViewList.Items.IndexOf(CurrentItem);
                IdObjectPair PreviousItem = (IdObjectPair)SavedViewList.Items[Index - 1];
                Classes.BaseOptions CurrentBaseOptions = (Classes.BaseOptions)CurrentItem.Object;
                Classes.BaseOptions PreviousBaseOptions = (Classes.BaseOptions)PreviousItem.Object;

                // Swap them
                SwapItems(CurrentBaseOptions, PreviousBaseOptions);

                // Repaint list
                LoadList();

                // Reselect previously selected item
                SavedViewList.SelectedIndex = Index - 1;
            }
            catch (Exception x)
            {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            if (SavedViewList.SelectedItem == null) {
                return;
            }

            try {
                // Get Items
                IdObjectPair CurrentItem = (IdObjectPair)SavedViewList.SelectedItem;
                int Index = SavedViewList.Items.IndexOf(CurrentItem);
                IdObjectPair NextItem = (IdObjectPair)SavedViewList.Items[Index + 1];
                Classes.BaseOptions CurrentBaseOptions = (Classes.BaseOptions)CurrentItem.Object;
                Classes.BaseOptions NextBaseOptions = (Classes.BaseOptions)NextItem.Object;

                // Swap them
                SwapItems(CurrentBaseOptions, NextBaseOptions);

                // Repaint list
                LoadList();

                // Reselect previously selected item
                SavedViewList.SelectedIndex = Index + 1;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int Count = SavedViewList.SelectedItems.Count;
            if (Common.WarnPrompt("Are you sure you want to delete these " + Count.ToString() + " item(s)?") == DialogResult.No) {
                return;
            }

            Count = 0;

            try {
                List<IdObjectPair> RemovedItems = new List<IdObjectPair>();

                // First delete from db
                foreach (IdObjectPair Item in SavedViewList.SelectedItems) { //SavedViewList.CheckedItems) {
                    RemovedItems.Add(Item);
                    Classes.BaseOptions BaseOptions = (Classes.BaseOptions)Item.Object;
                    BaseOptions.Delete();
                    Count++;
                }

                // Now remove from widget
                foreach (IdObjectPair Item in RemovedItems) {
                    SavedViewList.Items.Remove(Item);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            // User feedback
            Common.Info(Count + " item(s) were deleted.");
        }

        //----------------------------------------------------------------------

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (SavedViewList.SelectedItem == null) {
                return;
            }

            try {
                IdObjectPair CurrentItem = (IdObjectPair)SavedViewList.SelectedItem;
                Classes.BaseOptions BaseOptions = (Classes.BaseOptions)CurrentItem.Object;

                fGridManageRename DialogBox = new fGridManageRename();

                string PreviousName = BaseOptions.Name;
                string PreviousDescription = BaseOptions.Description;

                DialogBox.wNewName.Text = BaseOptions.Name;
                DialogBox.wNewDescription.Text = BaseOptions.Description;

                if (DialogBox.ShowDialog() == DialogResult.OK) {

                    // Nothing changed, no work to do
                    if ((PreviousName == DialogBox.wNewName.Text) && (PreviousDescription == DialogBox.wNewDescription.Text)) {
                        return;
                    }

                    // Only the description changed
                    if ((PreviousName == DialogBox.wNewName.Text) && (PreviousDescription != DialogBox.wNewDescription.Text)) {
                        BaseOptions.Description = DialogBox.wNewDescription.Text;
                        BaseOptions.SaveRow();
                        LoadList();
                        return;
                        // TODO or FIXME: Let's have a ubiquitous Id property synonymous with TableNameId
                        // for each object. I'd like to just say GridOptions.GridOptionsId
                    }

                    // From here on out, the name changed but we'll handle name and description together
                    if (PreviousName != DialogBox.wNewName.Text) {

                        // Check for uniqueness
                        Classes.BaseOptionsCollection BaseViewCollection = new Classes.BaseOptionsCollection(this.TableName);

                        if (BaseViewCollection.ViewExists(DialogBox.wNewName.Text)) {
                            Common.Warn("A view with that name already exists.");
                            return;
                        }

                        // Rename (and Redescribe)
                        BaseOptions.Name = DialogBox.wNewName.Text;
                        BaseOptions.Description = DialogBox.wNewDescription.Text;
                        BaseOptions.SaveRow();

                        // Repaint List
                        LoadList();
                    }

                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void CloseDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------
        // Private Helpers
        //----------------------------------------------------------------------

        private void LoadList()
        {
            SavedViewList.Items.Clear();

            List<Classes.BaseOptions> BaseOptionsCollection = new Classes.BaseOptionsCollection(this.TableName).FetchObjects();

            foreach (Classes.BaseOptions Item in BaseOptionsCollection)
            {
                IdObjectPair Pair = new IdObjectPair((int)Item.Id, Item);
                SavedViewList.Items.Add(Pair);
            }
        }

        //----------------------------------------------------------------------

        private void SwapItems(Classes.BaseOptions firstItem, Classes.BaseOptions secondItem)
        {
            try {
                int SavedFirstSortOrderNo = firstItem.SortOrderNo;

                firstItem.SortOrderNo = secondItem.SortOrderNo;
                firstItem.SaveRow();

                secondItem.SortOrderNo = SavedFirstSortOrderNo;
                secondItem.SaveRow();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fGridManage\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

        //---------------------------------------------------------------------

    }
}
