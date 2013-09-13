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

        private DBI Database;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ManageViews()
        {
            InitializeComponent();
            this.Database = Timekeeper.Database;
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
                Classes.GridOptions CurrentGridOptions = (Classes.GridOptions)CurrentItem.Object;
                Classes.GridOptions PreviousGridOptions = (Classes.GridOptions)PreviousItem.Object;

                // Swap them
                SwapItems(CurrentGridOptions, PreviousGridOptions);

                // Repaint list
                LoadList();

                // And reselect item
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
                Classes.GridOptions CurrentGridOptions = (Classes.GridOptions)CurrentItem.Object;
                Classes.GridOptions NextGridOptions = (Classes.GridOptions)NextItem.Object;

                // Swap them
                SwapItems(NextGridOptions, CurrentGridOptions);

                // Repaint list
                LoadList();

                // And reselect item
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

                // Begin unit of work
                Database.Begin();

                // First delete from db
                foreach (IdObjectPair Item in SavedViewList.SelectedItems) { //SavedViewList.CheckedItems) {
                    RemovedItems.Add(Item);
                    Database.Delete("GridOptions", "GridOptionsId", Item.Id);
                    Count++;
                }

                // Now remove from widget
                foreach (IdObjectPair Item in RemovedItems) {
                    SavedViewList.Items.Remove(Item);
                }

                // Complete unit of work
                Database.Commit();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                Database.Rollback();
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
                Classes.GridOptions GridOptions = (Classes.GridOptions)CurrentItem.Object;

                fGridManageRename DialogBox = new fGridManageRename();

                string PreviousName = GridOptions.Name;
                string PreviousDescription = GridOptions.Description;

                DialogBox.wNewName.Text = GridOptions.Name;
                DialogBox.wNewDescription.Text = GridOptions.Description;

                if (DialogBox.ShowDialog() == DialogResult.OK) {

                    // Nothing changed, no work to do
                    if ((PreviousName == DialogBox.wNewName.Text) && (PreviousDescription == DialogBox.wNewDescription.Text)) {
                        return;
                    }

                    // Only the description changed
                    if ((PreviousName == DialogBox.wNewName.Text) && (PreviousDescription != DialogBox.wNewDescription.Text)) {
                        Row Row = new Row();
                        Row["Description"] = DialogBox.wNewDescription.Text;
                        Database.Update("GridOptions", Row, "GridOptionsId", GridOptions.GridOptionsId);
                        LoadList();
                        return;
                        // TODO or FIXME: Let's have a ubiquitous Id property synonymous with TableNameId
                        // for each object. I'd like to just say GridOptions.Id
                    }

                    // From here on out, the name changed but we'll handle name and description together
                    if (PreviousName != DialogBox.wNewName.Text) {
                        // Begin unit of work
                        Database.Begin();

                        // FIXME: crap, crap, crap. I just remembered (2013-09-08 09:45 CDT) that this
                        // module has to work for ALL options (Grid, Report, Find, etc.) and not just
                        // grid, although I've done a nice job here tying it to GridOptions. This has
                        // implications I'm not ready to deal with right now, but I'll just finish
                        // what I started first, then get back to genericizing it.

                        // Check for uniqueness
                        String QuotedName = DialogBox.wNewName.Text.Replace("'", "''");
                        Row Row = Database.SelectRow(String.Format(@"select count(*) as Count from GridOptions where Name = '{0}'", QuotedName));
                        if (Row["Count"] == 1) {
                            Database.Rollback();
                            Common.Warn("A view with that name already exists.");
                            return;
                        }

                        // now rename
                        Row = new Row();
                        Row["Name"] = DialogBox.wNewName.Text;
                        Row["Description"] = DialogBox.wNewDescription.Text;
                        Database.Update("GridOptions", Row, "GridOptionsId", GridOptions.GridOptionsId);

                        // Now just repaint whole form
                        LoadList();

                        // Complete unit of work
                        Database.Commit();
                    }

                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                Database.Rollback(); // sloppy
            }


        }

        //----------------------------------------------------------------------
        // Private Helpers
        //----------------------------------------------------------------------

        private void LoadList()
        {
            SavedViewList.Items.Clear();

            List<Classes.GridOptions> GridOptionsCollection = new Classes.GridOptionsCollection().FetchObjects();

            foreach (Classes.GridOptions Item in GridOptionsCollection)
            {
                IdObjectPair Pair = new IdObjectPair((int)Item.GridOptionsId, Item);
                SavedViewList.Items.Add(Pair);
            }
        }

        //----------------------------------------------------------------------

        private void SwapItems(Classes.GridOptions firstItem, Classes.GridOptions secondItem)
        {
            try {
                // Begin unit of work
                Database.Begin();

                // Update first row with second row's SortOrderNo
                Row row = new Row();
                row["SortOrderNo"] = (long)firstItem.SortOrderNo;
                Database.Update("GridOptions", row, "GridOptionsId", secondItem.GridOptionsId);

                //Timekeeper.Info("Assigned " + firstItem.SortOrderNo.ToString() + " to " + secondItem.GridOptionsId.ToString());

                // Update second row with first row's SortOrderNo
                row = new Row();
                row["SortOrderNo"] = (long)secondItem.SortOrderNo;
                Database.Update("GridOptions", row, "GridOptionsId", firstItem.GridOptionsId);

                //Timekeeper.Info("Assigned " + secondItem.SortOrderNo.ToString() + " to " + firstItem.GridOptionsId.ToString());

                // Complete unit of work
                Database.Commit();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                Database.Rollback();
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

        private void CloseDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //---------------------------------------------------------------------

    }
}
