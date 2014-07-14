using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    partial class Widgets
    {
        //----------------------------------------------------------------------
        // Constants
        //----------------------------------------------------------------------

        public const int TREES_ITEM_CREATED = 0;
        public const int TREES_ERROR_CREATING_ITEM = -1;
        public const int TREES_DUPLICATE_ITEM = -2;

        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private Timekeeper.Dimension CurrentDimension;
        private int CurrentIcon;

        //----------------------------------------------------------------------
        // Tree Builder Methods
        //----------------------------------------------------------------------
        // The astute reader will immediately recognize what looks like a high
        // degree of copy and paste throughout this file. I have spent hours
        // and hours trying to eliminate it. But every solution either:
        //   1) ultimately fails or
        //   2) creates a solution far worse than the initial problem.
        // For future reference, the issue is twofold: there are simply two
        // different classes used to represent tree structures (either the
        // original .NET TreeNodeCollection or Bradley Smith's alternative
        // ComboTreeNodeCollection) and (worse) each of these Collections is
        // made up of a different class (TreeNode vs ComboTreeNode). Due to
        // C#'s strong typing (and perhaps my lack of experience with C#), I
        // simply couldn't find an elegant way of eliminating what looks like
        // rampant copy/paste across all these key builder methods. 2014-05-17.
        //----------------------------------------------------------------------

        public void BuildTree(Timekeeper.Dimension dimension, dynamic tree)
        {
            // Helper function when you need to build a tree but you
            // only have the dimension at your disposal. Calls the
            // appropriate underlying Builder.

            tree.Nodes.Clear();

            switch (dimension) {
                case Timekeeper.Dimension.Project:
                    this.BuildProjectTree(tree.Nodes);
                    break;
                case Timekeeper.Dimension.Activity:
                    this.BuildActivityTree(tree.Nodes);
                    break;
                case Timekeeper.Dimension.Location:
                    this.BuildLocationTree(tree.Nodes);
                    break;
                case Timekeeper.Dimension.Category:
                    this.BuildCategoryTree(tree.Nodes);
                    break;
            }
        }

        //----------------------------------------------------------------------

        public void BuildProjectTree(dynamic tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Project;
            this.CurrentIcon = Timekeeper.IMG_PROJECT;
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        public void BuildActivityTree(dynamic tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Activity;
            this.CurrentIcon = Timekeeper.IMG_ACTIVITY;
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        public void BuildLocationTree(dynamic tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Location;
            this.CurrentIcon = Timekeeper.IMG_LOCATION;
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        public void BuildCategoryTree(dynamic tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Category;
            this.CurrentIcon = Timekeeper.IMG_CATEGORY;
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        private void BuildTree(dynamic tree, dynamic parentNode, long parentId)
        {
            bool showHidden = GetViewHidden();
            DateTime showHiddenSince = GetViewHiddenSinceTime();
            string orderByClause = GetOrderBy(Options.Behavior_SortItemsBy, Options.Behavior_SortItemsByDirection);

            // Instantiate Items
            TreeAttributeCollection Items = new TreeAttributeCollection(this.CurrentDimension.ToString(), orderByClause);

            // Iterate over Items
            foreach (TreeAttribute Item in Items.Fetch(parentId, showHidden, showHiddenSince)) {

                // Choose icon
                int Icon = this.CurrentIcon;

                if (Item.IsHidden) {
                    Icon = Timekeeper.IMG_ITEM_HIDDEN;
                }

                // Create the new node
                dynamic Node = AddItemToTree(tree, parentNode, Item, Icon);

                // Then recurse
                if (Item.ItemId != parentId) {
                    BuildTree(tree, Node, Item.ItemId);
                }
            }
        }

        //----------------------------------------------------------------------

        private void ExpandTree(dynamic tree)
        {
            foreach (dynamic Node in tree) {
                TreeAttribute Item = (TreeAttribute)Node.Tag;
                if (Item.IsFolderOpened) {
                    if (!Node.IsExpanded) {
                        Node.Expand();
                    }
                }
                if (Item.IsFolder) {
                    ExpandTree(Node.Nodes);
                }
            }
        }

        //----------------------------------------------------------------------

        private dynamic GetNewNode(dynamic tree)
        {
            dynamic Node = null;

            System.Type TreeType = tree.GetType();

            if (TreeType.Name == "ComboTreeNodeCollection") {
                Node = new ComboTreeNode();
            } else {
                Node = new TreeNode();
            }

            return Node;
        }

        private dynamic AddItemToTree(dynamic tree, dynamic parentNode, TreeAttribute item, int imageIndex)
        {
            dynamic Node = GetNewNode(tree);

            try {
                System.Type TreeType = tree.GetType();

                Node.Tag = item;
                Node.Text = item.DisplayName();
                Node.ToolTipText = item.Description;
                if (item.IsHidden) {
                    Node.ForeColor = Color.Gray;
                }

                if (item.IsFolder) {
                    if (item.IsHidden) {
                        Node.ImageIndex = Timekeeper.IMG_FOLDER_HIDDEN;
                        Node.SelectedImageIndex = Timekeeper.IMG_FOLDER_HIDDEN;
                    } else {
                        Node.ImageIndex = Timekeeper.IMG_FOLDER;
                        Node.SelectedImageIndex = Timekeeper.IMG_FOLDER;
                    }
                } else {
                    Node.ImageIndex = imageIndex;
                    Node.SelectedImageIndex = imageIndex;
                }

                if (parentNode == null) {
                    tree.Add(Node);
                } else {
                    parentNode.Nodes.Add(Node);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Node;
        }

        //----------------------------------------------------------------------

        public dynamic AddHiddenItemToTree(dynamic tree, TreeAttribute item)
        {
            TreeAttribute ParentItem = new TreeAttribute(item.ParentId, 
                this.CurrentDimension.ToString(), 
                this.CurrentDimension.ToString() + "Id");

            if (ParentItem.ItemId == 0) {
                // If we've gone all the way up, add the item itself as a root
                return AddItemToTree(tree, null, item, Timekeeper.IMG_ITEM_HIDDEN);
            } else {
                // Otherwise, try to add the item to the found parent

                long parentId = ParentItem.ItemId;

                dynamic ParentNode = FindTreeNode(tree, parentId);
                if (ParentNode != null) {
                    // If we got one, add it
                    return AddItemToTree(tree, ParentNode, item, Timekeeper.IMG_ITEM_HIDDEN);
                } else {
                    // Otherwise, attempt to add the parent, recursively
                    dynamic NewNode = AddHiddenItemToTree(tree, ParentItem);
                    return AddItemToTree(tree, NewNode, item, Timekeeper.IMG_ITEM_HIDDEN);
                }
            }
        }

        //----------------------------------------------------------------------

        public int CreateTreeItem(dynamic tree, TreeAttribute item, long parentId, int imageIndex)
        {
            dynamic ParentNode = null;
            item.ParentId = 0;

            if (parentId != -1) {
                ParentNode = FindTreeNode(tree, parentId);
                if (ParentNode != null) {
                    item.ParentId = parentId;
                } else {
                    return TREES_ERROR_CREATING_ITEM;
                }
            }

            int Result = TREES_ITEM_CREATED;

            long CreateStatus = item.Create();
            switch (CreateStatus) {
                case 0:
                    Result = TREES_ERROR_CREATING_ITEM;
                    break;
                case -1:
                    Result = TREES_DUPLICATE_ITEM;
                    break;
                default:
                    AddItemToTree(tree, ParentNode, item, imageIndex);
                    break;
            }

            return Result;
        }

        //----------------------------------------------------------------------

        public dynamic FindTreeNode(dynamic nodes, long itemId)
        {
            dynamic FoundNode = null;

            foreach (dynamic Node in nodes) {
                TreeAttribute item = (TreeAttribute)Node.Tag;

                if (item.ItemId == itemId) {
                    FoundNode = Node;
                } else {
                    FoundNode = FindTreeNode(Node.Nodes, itemId);
                }
                if (FoundNode != null) {
                    break;
                }
            }

            return FoundNode;
        }

        //----------------------------------------------------------------------
        // Dialog to Create an Item or a Folder
        //----------------------------------------------------------------------

        public Classes.TreeAttribute CreateTreeItemDialog(dynamic tree, Timekeeper.Dimension dim, bool isFolder)
        {
            string DialogTitle =
                "New " +
                dim.ToString() +
                (isFolder ? " Folder" : "");

            int Icon = 0;
            Classes.TreeAttribute Item = null;

            switch (dim) {
                case Timekeeper.Dimension.Project:
                    Item = new Classes.Project();
                    Icon = Timekeeper.IMG_PROJECT;
                    break;
                case Timekeeper.Dimension.Activity:
                    Item = new Classes.Activity();
                    Icon = Timekeeper.IMG_ACTIVITY;
                    break;
                case Timekeeper.Dimension.Location:
                    Item = new Classes.Location();
                    Icon = Timekeeper.IMG_LOCATION;
                    break;
                case Timekeeper.Dimension.Category:
                    Item = new Classes.Category();
                    Icon = Timekeeper.IMG_CATEGORY;
                    break;
            }

            // Instantiate Dialog
            ItemEditor Dialog = new ItemEditor(dim, isFolder);
            Dialog.Text = DialogTitle;

            // Determine preselected folder
            int ParentIndex = 0;
            if (tree.SelectedNode != null) {

                Classes.TreeAttribute SelectedItem = (Classes.TreeAttribute)tree.SelectedNode.Tag;

                if (SelectedItem.IsFolder) {
                    ParentIndex = Dialog.ItemParent.FindString(SelectedItem.Name);
                } else if (tree.SelectedNode.Parent != null) {
                    ParentIndex = Dialog.ItemParent.FindString(SelectedItem.Parent().Name);
                } else {
                    // Do nothing?
                }
            }
            Dialog.ItemParent.SelectedIndex = ParentIndex;

            if (Dialog.ShowDialog() == DialogResult.OK) {
                Item.Name = Dialog.ItemName.Text;
                Item.Description = Dialog.ItemDescription.Text;
                Item.IsFolder = isFolder;
                Item.ExternalProjectNo = Dialog.ItemExternalProjectNo.Text == "" ? null : Dialog.ItemExternalProjectNo.Text;

                IdValuePair Pair = (IdValuePair)Dialog.ItemParent.SelectedItem;
                int ParentItemId = Pair.Id;

                Dialog.CreatedItem = null;
                int CreateResult = this.CreateTreeItem(tree.Nodes, Item, ParentItemId, Icon);
                switch (CreateResult) {
                    case Classes.Widgets.TREES_ITEM_CREATED:
                        Dialog.CreatedItem = Item;
                        break;
                    case Classes.Widgets.TREES_ERROR_CREATING_ITEM:
                        Common.Warn("There was an error creating the item.");
                        break;
                    case Classes.Widgets.TREES_DUPLICATE_ITEM:
                        Common.Warn("An item with that name already exists.");
                        break;
                    default:
                        Common.Warn("An unexpected error occurred creating item.");
                        break;
                }
            }

            return Dialog.CreatedItem;
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private bool GetViewHidden()
        {
            return GetViewHidden(this.CurrentDimension);
        }

        //----------------------------------------------------------------------

        public bool GetViewHidden(Timekeeper.Dimension dim)
        {
            bool Show = false;

            switch (dim) {
                case Timekeeper.Dimension.Project:
                    Show = Options.View_HiddenProjects;
                    break;
                case Timekeeper.Dimension.Activity:
                    Show = Options.View_HiddenActivities;
                    break;
                case Timekeeper.Dimension.Location:
                    Show = Options.View_HiddenLocations;
                    break;
                case Timekeeper.Dimension.Category:
                    Show = Options.View_HiddenCategories;
                    break;
            }

            return Show;
        }

        //----------------------------------------------------------------------

        private DateTime GetViewHiddenSinceTime()
        {
            DateTime showHiddenSince = DateTime.Now;
            TimeSpan Offset;
            int HiddenSinceSetting = -1;

            switch (this.CurrentDimension) {
                case Timekeeper.Dimension.Project:
                    HiddenSinceSetting = Options.View_HiddenProjectsSince;
                    break;
                case Timekeeper.Dimension.Activity:
                    HiddenSinceSetting = Options.View_HiddenActivitiesSince;
                    break;
                case Timekeeper.Dimension.Location:
                    HiddenSinceSetting = Options.View_HiddenLocationsSince;
                    break;
                case Timekeeper.Dimension.Category:
                    HiddenSinceSetting = Options.View_HiddenCategoriesSince;
                    break;
            }

            switch (HiddenSinceSetting) {
                case 0: Offset = new TimeSpan(-1, 0, 0, 0); break;
                case 1: Offset = new TimeSpan(-7, 0, 0, 0); break;
                case 2: Offset = new TimeSpan(-30, 0, 0, 0); break;
                case 3: Offset = new TimeSpan(-365, 0, 0, 0); break;
                default: Offset = new TimeSpan(-3650, 0, 0, 0); break;
            }

            showHiddenSince = showHiddenSince.Add(Offset);

            return showHiddenSince;
        }

        //----------------------------------------------------------------------

        private string GetOrderBy(int sortBy, int sortDirection)
        {
            string OrderBy;

            switch (sortBy) {
                case 0: OrderBy = "Name"; break;
                case 1: OrderBy = "SortOrderNo"; break;
                case 2: OrderBy = "CreateTime"; break;
                case 3: OrderBy = "ModifyTime"; break;
                // FIXME: the cast below needs to be an option
                // FIXME: also ONLY supported by Projects
                case 4: OrderBy = "cast(ExternalProjectNo as int)"; break;
                default: OrderBy = "SortOrderNo"; break;
            }

            string Direction = sortDirection == 0 ? "asc" : "desc";

            return OrderBy + " " + Direction;
        }

        //----------------------------------------------------------------------

    }
}
