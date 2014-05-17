using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

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

        private int CurrentIcon;
        private Timekeeper.Dimension CurrentDimension;

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

        public void BuildProjectTree(TreeNodeCollection tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Project;
            this.CurrentIcon = Timekeeper.IMG_PROJECT;
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        public void BuildProjectTree(ComboTreeNodeCollection tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Project;
            this.CurrentIcon = Timekeeper.IMG_PROJECT;
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        public void BuildActivityTree(TreeNodeCollection tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Activity;
            this.CurrentIcon = Timekeeper.IMG_ACTIVITY;
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        public void BuildActivityTree(ComboTreeNodeCollection tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Activity;
            this.CurrentIcon = Timekeeper.IMG_ACTIVITY;
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        public void BuildLocationTree(TreeNodeCollection tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Location;
            this.CurrentIcon = Timekeeper.IMG_ACTIVITY; // FIXME
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        public void BuildLocationTree(ComboTreeNodeCollection tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Location;
            this.CurrentIcon = Timekeeper.IMG_ACTIVITY; // FIXME
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        public void BuildCategoryTree(TreeNodeCollection tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Category;
            this.CurrentIcon = Timekeeper.IMG_ACTIVITY; // FIXME
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        public void BuildCategoryTree(ComboTreeNodeCollection tree)
        {
            this.CurrentDimension = Timekeeper.Dimension.Category;
            this.CurrentIcon = Timekeeper.IMG_ACTIVITY; // FIXME
            BuildTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        private void BuildTree(TreeNodeCollection tree, TreeNode parentNode, long parentId)
        {
            bool showHidden = true; // FIXME: should not be hardcoded
            DateTime showHiddenSince = GetShowHiddenSinceTime();
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
                TreeNode Node = AddItemToTree(tree, parentNode, Item, Icon);

                // Then recurse
                if (Item.ItemId != parentId) {
                    BuildTree(tree, Node, Item.ItemId);
                }
            }
        }

        //----------------------------------------------------------------------

        private void BuildTree(ComboTreeNodeCollection tree, ComboTreeNode parentNode, long parentId)
        {
            bool showHidden = true; // FIXME: should not be hardcoded
            DateTime showHiddenSince = GetShowHiddenSinceTime();
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
                ComboTreeNode Node = AddItemToTree(tree, parentNode, Item, Icon);

                // Then recurse
                if (Item.ItemId != parentId) {
                    BuildTree(tree, Node, Item.ItemId);
                }
            }
        }

        //----------------------------------------------------------------------

        private void ExpandTree(TreeNodeCollection tree)
        {
            foreach (TreeNode Node in tree) {
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

        private void ExpandTree(ComboTreeNodeCollection tree)
        {
            foreach (ComboTreeNode Node in tree) {
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

        private TreeNode AddItemToTree(TreeNodeCollection tree, TreeNode parentNode, TreeAttribute item, int imageIndex)
        {
            TreeNode Node = new TreeNode();
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
                    Node.ImageIndex = Timekeeper.IMG_FOLDER_CLOSED;
                    Node.SelectedImageIndex = Timekeeper.IMG_FOLDER_OPEN;
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

            return Node;
        }

        //----------------------------------------------------------------------

        private ComboTreeNode AddItemToTree(ComboTreeNodeCollection tree, ComboTreeNode parentNode, TreeAttribute item, int imageIndex)
        {
            ComboTreeNode Node = new ComboTreeNode();
            Node.Tag = item;
            Node.Text = item.DisplayName();
            if (item.IsHidden) {
                Node.ForeColor = Color.Gray;
            }

            if (item.IsFolder) {
                if (item.IsHidden) {
                    Node.ImageIndex = Timekeeper.IMG_FOLDER_HIDDEN;
                } else {
                    Node.ImageIndex = Timekeeper.IMG_FOLDER_CLOSED;
                }
            } else {
                Node.ImageIndex = imageIndex;
            }

            if (parentNode == null) {
                tree.Add(Node);
            } else {
                parentNode.Nodes.Add(Node);
            }

            return Node;
        }

        //----------------------------------------------------------------------

        public TreeNode AddHiddenItemToTree(TreeNodeCollection tree, TreeAttribute item)
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

                TreeNode ParentNode = FindTreeNode(tree, parentId);
                if (ParentNode != null) {
                    // If we got one, add it
                    return AddItemToTree(tree, ParentNode, item, Timekeeper.IMG_ITEM_HIDDEN);
                } else {
                    // Otherwise, attempt to add the parent, recursively
                    TreeNode NewNode = AddHiddenItemToTree(tree, ParentItem);
                    return AddItemToTree(tree, NewNode, item, Timekeeper.IMG_ITEM_HIDDEN);
                }
            }
        }

        //----------------------------------------------------------------------

        public ComboTreeNode AddHiddenItemToTree(ComboTreeNodeCollection tree, TreeAttribute item)
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

                ComboTreeNode ParentNode = FindTreeNode(tree, parentId);
                if (ParentNode != null) {
                    // If we got one, add it
                    return AddItemToTree(tree, ParentNode, item, Timekeeper.IMG_ITEM_HIDDEN);
                } else {
                    // Otherwise, attempt to add the parent, recursively
                    ComboTreeNode NewNode = AddHiddenItemToTree(tree, ParentItem);
                    return AddItemToTree(tree, NewNode, item, Timekeeper.IMG_ITEM_HIDDEN);
                }
            }
        }

        //----------------------------------------------------------------------

        public int CreateTreeItem(TreeNodeCollection tree, TreeAttribute item, long parentId, int imageIndex)
        {
            TreeNode ParentNode = null;
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
                    TreeNode foo = AddItemToTree(tree, ParentNode, item, imageIndex);
                    break;
            }

            return Result;
        }

        //----------------------------------------------------------------------

        public TreeNode FindTreeNode(TreeNodeCollection nodes, long itemId)
        {
            TreeNode FoundNode = null;

            foreach (TreeNode Node in nodes) {
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

        public ComboTreeNode FindTreeNode(ComboTreeNodeCollection nodes, long itemId)
        {
            ComboTreeNode FoundNode = null;

            foreach (ComboTreeNode Node in nodes) {
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
        // Helpers
        //----------------------------------------------------------------------

        private DateTime GetShowHiddenSinceTime()
        {
            DateTime showHiddenSince = DateTime.Now;
            TimeSpan Offset;

            switch (Options.View_HiddenProjectsSince) {
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
            /*
            string[] Entries = new string[5] { 
                "Alphabetically",
                "as Placed",
                "by Created Date",
                "by Modified Date",
                "by External Project Number" };
            AddItems(Behavior_SortProjectsBy, Entries);
             */

            string OrderBy;

            switch (sortBy) {
                case 0: OrderBy = "Name"; break;
                case 1: OrderBy = "SortOrderNo"; break;
                case 2: OrderBy = "CreateTime"; break;
                case 3: OrderBy = "ModifyTime"; break;
                // FIXME: the cast below needs to be an option
                case 4: OrderBy = "cast(ExternalProjectNo as int)"; break;
                default: OrderBy = "SortOrderNo"; break;
            }

            //cast(some_integer_column as text)

            string Direction = sortDirection == 0 ? "asc" : "desc";

            return OrderBy + " " + Direction;
        }

        //----------------------------------------------------------------------

    }
}
