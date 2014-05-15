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

        public void BuildProjectTree(TreeNodeCollection tree)
        {
            BuildProjectTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        public void BuildActivityTree(TreeNodeCollection tree)
        {
            BuildActivityTree(tree, null, 0);
            ExpandTree(tree);
        }

        //----------------------------------------------------------------------

        public void BuildProjectTree(ComboTreeNodeCollection tree)
        {
            BuildProjectTree(tree, null, 0);
            ExpandTree(tree);
        }

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

        private void BuildProjectTree(TreeNodeCollection tree, TreeNode parentNode, long parentId)
        {

            bool showHidden = Options.View_HiddenProjects;
            DateTime showHiddenSince = GetShowHiddenSinceTime();
            string orderByClause = GetOrderBy(Options.Behavior_SortProjectsBy, Options.Behavior_SortProjectsByDirection);

            // Instantiate Project collection
            ProjectCollection Projects = new ProjectCollection(orderByClause);

            // Iterate over Projects
            foreach (Project Project in Projects.Fetch(parentId, showHidden, showHiddenSince)) {

                // Choose icon
                int Icon = Timekeeper.IMG_PROJECT;

                if (Project.IsHidden) {
                    Icon = Timekeeper.IMG_ITEM_HIDDEN;
                }

                // Create the new node
                TreeNode Node = AddItemToTree(tree, parentNode, Project, Icon);

                // Then recurse
                if (Project.ItemId != parentId) {
                    BuildProjectTree(tree, Node, Project.ItemId);
                }
            }
        }

        //----------------------------------------------------------------------

        private void BuildProjectTree(ComboTreeNodeCollection tree, ComboTreeNode parentNode, long parentId)
        {
            bool showHidden = Options.View_HiddenProjects;
            DateTime showHiddenSince = GetShowHiddenSinceTime();
            string orderByClause = GetOrderBy(Options.Behavior_SortProjectsBy, Options.Behavior_SortProjectsByDirection);

            // Instantiate Activities object
            ProjectCollection Projects = new ProjectCollection(orderByClause);

            // Iterate over Activities
            foreach (Project Project in Projects.Fetch(parentId, showHidden, showHiddenSince)) {

                // Choose icon
                int Icon = Timekeeper.IMG_PROJECT;

                if (Project.IsHidden) {
                    Icon = Timekeeper.IMG_ITEM_HIDDEN;
                }

                // Create the new node
                ComboTreeNode Node = AddItemToTree(tree, parentNode, Project, Icon);

                // Then recurse
                if (Project.ItemId != parentId) {
                    BuildProjectTree(tree, Node, Project.ItemId);
                }
            }
        }

        //----------------------------------------------------------------------

        private void BuildActivityTree(TreeNodeCollection tree, TreeNode parentNode, long parentId)
        {
            bool showHidden = true;
            DateTime showHiddenSince = GetShowHiddenSinceTime();
            string orderByClause = GetOrderBy(Options.Behavior_SortItemsBy, Options.Behavior_SortItemsByDirection);

            // Instantiate Activities object
            ActivityCollection Activities = new ActivityCollection(orderByClause);

            // Iterate over Activities
            foreach (Activity Activity in Activities.Fetch(parentId, showHidden, showHiddenSince)) {

                // Choose icon
                int Icon = Timekeeper.IMG_ACTIVITY;

                if (Activity.IsHidden) {
                    Icon = Timekeeper.IMG_ITEM_HIDDEN;
                }

                // Create the new node
                TreeNode Node = AddItemToTree(tree, parentNode, Activity, Icon);

                // Then recurse
                if (Activity.ItemId != parentId) {
                    BuildActivityTree(tree, Node, Activity.ItemId);
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

        public TreeNode AddHiddenProjectToTree(TreeNodeCollection tree, Project project) //, Project parentProject)
        {
            Project parentProject = new Project(project.ParentId);

            if (parentProject.ItemId == 0) {
                // If we've gone all the way up, add the item itself as a root
                return AddItemToTree(tree, null, project, Timekeeper.IMG_ITEM_HIDDEN);
            } else {
                // Otherwise, try to add the item to the found parent

                long parentId = parentProject.ItemId;

                TreeNode ParentNode = FindTreeNode(tree, parentId);
                if (ParentNode != null) {
                    // If we got one, add it
                    return AddItemToTree(tree, ParentNode, project, Timekeeper.IMG_ITEM_HIDDEN);
                } else {
                    // Otherwise, attempt to add the parent, recursively
                    //Project grandparentProject = new Project(Database, parentProject.ParentId);
                    TreeNode NewNode = AddHiddenProjectToTree(tree, parentProject); //, grandparentProject);
                    return AddItemToTree(tree, NewNode, project, Timekeeper.IMG_ITEM_HIDDEN);
                }
            }
        }

        //----------------------------------------------------------------------

        public TreeNode AddHiddenActivityToTree(TreeNodeCollection tree, Activity activity)
        {
            // Yes, this is a complete copy/paste of the above.
            // Yes, I tried to genericize this with the Item type.
            // Yes, I ran into problems.
            // Brute forcing it now, just to get on with life.

            Activity parentActivity = new Activity(activity.ParentId);

            if (parentActivity.ItemId == 0) {
                // If we've gone all the way up, add the item itself as a root
                return AddItemToTree(tree, null, activity, Timekeeper.IMG_ITEM_HIDDEN);
            } else {
                // Otherwise, try to add the item to the found parent

                long parentId = parentActivity.ItemId;

                TreeNode ParentNode = FindTreeNode(tree, parentId);
                if (ParentNode != null) {
                    // If we got one, add it
                    return AddItemToTree(tree, ParentNode, activity, Timekeeper.IMG_ITEM_HIDDEN);
                } else {
                    // Otherwise, attempt to add the parent, recursively
                    TreeNode NewNode = AddHiddenActivityToTree(tree, parentActivity);
                    return AddItemToTree(tree, NewNode, activity, Timekeeper.IMG_ITEM_HIDDEN);
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
            // FIXME: Look at all the copy/paste. LOOK AT IT.

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

        private void ShowRootLines(TreeView tree)
        {
            ActivityCollection Activities = new ActivityCollection();
            tree.ShowRootLines = Activities.HasParents();

            ProjectCollection Projects = new ProjectCollection();
            tree.ShowRootLines = Projects.HasParents();

            // FIXME: this is very unfinished
        }

        //----------------------------------------------------------------------

    }
}
