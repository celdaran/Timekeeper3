using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Forms.Shared
{
    public partial class ManageViews : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

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

        private void ManageViews_Load(object sender, EventArgs e)
        {
            if (SavedViewList.Items.Count > 0) {
                // Select first item, if we have items.
                SavedViewList.SelectedIndex = 0;
            } else {
                RenameButton.Enabled = false;
                DeleteButton.Enabled = false;
                MoveUpButton.Enabled = false;
                MoveDownButton.Enabled = false;
            }
        }

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
                Classes.SortableItem CurrentView = (Classes.SortableItem)CurrentItem.Object;
                Classes.SortableItem PreviousView = (Classes.SortableItem)PreviousItem.Object;

                // Swap them
                SwapItems(CurrentView, PreviousView);

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
                Classes.SortableItem CurrentView = (Classes.SortableItem)CurrentItem.Object;
                Classes.SortableItem NextView = (Classes.SortableItem)NextItem.Object;

                // Swap them
                SwapItems(CurrentView, NextView);

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
                    Classes.SortableItem View = (Classes.SortableItem)Item.Object;
                    View.Delete();
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
                Classes.SortableItem View = (Classes.SortableItem)CurrentItem.Object;

                RenameView DialogBox = new RenameView(this.TableName);

                string PreviousName = View.Name;
                string PreviousDescription = View.Description;

                DialogBox.wNewName.Text = View.Name;
                DialogBox.wNewDescription.Text = View.Description;

                if (DialogBox.ShowDialog() == DialogResult.OK) {

                    // Nothing changed, no work to do
                    if ((PreviousName == DialogBox.wNewName.Text) && (PreviousDescription == DialogBox.wNewDescription.Text)) {
                        return;
                    }

                    // Only the description changed
                    if ((PreviousName == DialogBox.wNewName.Text) && (PreviousDescription != DialogBox.wNewDescription.Text)) {
                        View.Description = DialogBox.wNewDescription.Text;
                        View.Save();
                        LoadList();
                        return;
                        // TODO or FIXME: Let's have a ubiquitous Id property synonymous with TableNameId
                        // for each object. I'd like to just say GridOptions.GridOptionsId
                    }

                    // From here on out, the name changed but we'll handle name and description together
                    if (PreviousName != DialogBox.wNewName.Text) {

                        // Rename (and Redescribe)
                        View.Name = DialogBox.wNewName.Text;
                        View.Description = DialogBox.wNewDescription.Text;
                        View.Save();  // FIXME: crap! this is an upsert... I CAN'T rename

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

            List<Classes.SortableItem> Views = new Classes.SortableItemCollection(this.TableName).Fetch();

            foreach (Classes.SortableItem View in Views)
            {
                IdObjectPair Pair = new IdObjectPair((int)View.Id, View);
                SavedViewList.Items.Add(Pair);
            }
        }

        //----------------------------------------------------------------------

        private void SwapItems(Classes.SortableItem firstView, Classes.SortableItem secondView)
        {
            try {
                int SavedFirstSortOrderNo = firstView.SortOrderNo;

                firstView.SortOrderNo = secondView.SortOrderNo;
                // FIXME: Consider SaveRow() without args calls SaveRow(false, 0)
                firstView.Save();

                secondView.SortOrderNo = SavedFirstSortOrderNo;
                secondView.Save();
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
