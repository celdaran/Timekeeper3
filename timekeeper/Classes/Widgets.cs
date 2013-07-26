using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using System.Collections.ObjectModel;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Widgets
    {
        //---------------------------------------------------------------------
        // UI Helper Class
        //---------------------------------------------------------------------

        private DBI Database;

        public const int TREES_ITEM_CREATED = 0;
        public const int TREES_ERROR_CREATING_ITEM = -1;
        public const int TREES_DUPLICATE_ITEM = -2;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Widgets() {
            this.Database = Timekeeper.Database;
        }

        //---------------------------------------------------------------------

        public void BuildActivityTree(TreeNodeCollection tree, TreeNode parentNode, long parentId)
        {
            // TODO: pass this in
            bool showHidden = false;

            // Instantiate Activities object
            Activities Activities = new Activities(Database);

            // Iterate over Activities
            foreach (Activity Activity in Activities.Fetch(parentId, showHidden)) {
                // Create the new node
                TreeNode Node = AddItemToTree(tree, parentNode, Activity, Timekeeper.IMG_TASK);

                // Then recurse
                if (Activity.ItemId != parentId) {
                    BuildActivityTree(tree, Node, Activity.ItemId);
                }
            }
        }

        //---------------------------------------------------------------------

        public void BuildProjectTree(TreeNodeCollection tree, TreeNode parentNode, long parentId)
        {
            // TODO: pass this in
            bool showHidden = false;

            // Instantiate Activities object
            Projects Projects = new Projects(Database);

            // Iterate over Activities
            foreach (Project Project in Projects.Fetch(parentId, showHidden)) {
                // Create the new node
                TreeNode Node = AddItemToTree(tree, parentNode, Project, Timekeeper.IMG_PROJECT);

                // Then recurse
                if (Project.ItemId != parentId) {
                    BuildProjectTree(tree, Node, Project.ItemId);
                }
            }
        }

        //---------------------------------------------------------------------

        private TreeNode AddItemToTree(TreeNodeCollection tree, TreeNode parentNode, Item item, int imageIndex)
        {
            TreeNode Node = new TreeNode();
            Node.Tag = item;
            Node.Text = item.Name; // +String.Format(" ({0})", item.ItemId);
            Node.ToolTipText = item.Description;
            if (item.IsHidden) {
                Node.ForeColor = Color.Gray;
            }

            if (item.IsFolder) {
                Node.ImageIndex = Timekeeper.IMG_FOLDER_CLOSED;
                Node.SelectedImageIndex = Timekeeper.IMG_FOLDER_OPEN;
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

        //---------------------------------------------------------------------

        public TreeNode AddHiddenProjectToTree(TreeNodeCollection tree, Project project) //, Project parentProject)
        {
            Project parentProject = new Project(Database, project.ParentId);

            if (parentProject.ItemId == 0) {
                // If we've gone all the way up, add the item itself as a root
                return AddItemToTree(tree, null, project, Timekeeper.IMG_TASK_HIDDEN);
            } else {
                // Otherwise, try to add the item to the found parent

                string parentName = parentProject.Name;

                TreeNode ParentNode = FindTreeNode(tree, parentName);
                if (ParentNode != null) {
                    // If we got one, add it
                    return AddItemToTree(tree, ParentNode, project, Timekeeper.IMG_TASK_HIDDEN);
                } else {
                    // Otherwise, attempt to add the parent, recursively
                    //Project grandparentProject = new Project(Database, parentProject.ParentId);
                    TreeNode NewNode = AddHiddenProjectToTree(tree, parentProject); //, grandparentProject);
                    return AddItemToTree(tree, NewNode, project, Timekeeper.IMG_TASK_HIDDEN);
                }
            }

        }

        //---------------------------------------------------------------------

        public TreeNode AddHiddenActivityToTree(TreeNodeCollection tree, Activity activity)
        {
            // Yes, this is a complete copy/paste of the above.
            // Yes, I tried to genericize this with the Item type.
            // Yes, I ran into problems.
            // Brute forcing it now, just to get on with life.

            Activity parentActivity = new Activity(Database, activity.ParentId);

            if (parentActivity.ItemId == 0) {
                // If we've gone all the way up, add the item itself as a root
                return AddItemToTree(tree, null, activity, Timekeeper.IMG_TASK_HIDDEN);
            } else {
                // Otherwise, try to add the item to the found parent

                string parentName = parentActivity.Name;

                TreeNode ParentNode = FindTreeNode(tree, parentName);
                if (ParentNode != null) {
                    // If we got one, add it
                    return AddItemToTree(tree, ParentNode, activity, Timekeeper.IMG_TASK_HIDDEN);
                } else {
                    // Otherwise, attempt to add the parent, recursively
                    TreeNode NewNode = AddHiddenActivityToTree(tree, parentActivity);
                    return AddItemToTree(tree, NewNode, activity, Timekeeper.IMG_TASK_HIDDEN);
                }
            }
        }

        //---------------------------------------------------------------------

        public int CreateTreeItem(TreeNodeCollection tree, Item item, string parentName, int imageIndex)
        {
            TreeNode ParentNode = null;
            item.ParentId = 0;

            if (parentName != "(Top Level)") {
                ParentNode = FindTreeNode(tree, parentName);
                if (ParentNode != null) {
                    Item parentItem = (Item)ParentNode.Tag;
                    item.ParentId = parentItem.ItemId;
                } else {
                    return TREES_ERROR_CREATING_ITEM;
                }
            }

            int Result = TREES_ITEM_CREATED;

            long CreateStatus = item.Create();
            switch (CreateStatus) {
                case 1:
                    TreeNode foo = AddItemToTree(tree, ParentNode, item, imageIndex);
                    break;
                case 0:
                    Result = TREES_ERROR_CREATING_ITEM;
                    break;
                case -1:
                    Result = TREES_DUPLICATE_ITEM;
                    break;
            }

            return Result;
        }

        //---------------------------------------------------------------------

        public TreeNode FindTreeNode(TreeNodeCollection nodes, string name)
        {
            TreeNode FoundNode = null;

            foreach (TreeNode Node in nodes) {
                if (Node.Text == name) {
                    FoundNode = Node;
                } else {
                    FoundNode = FindTreeNode(Node.Nodes, name);
                }
                if (FoundNode != null) {
                    break;
                }
            }

            return FoundNode;
        }

        //---------------------------------------------------------------------

        public TreeNode FindTreeNode(TreeNodeCollection nodes, long itemId)
        {
            TreeNode FoundNode = null;

            foreach (TreeNode Node in nodes) {
                Item item = (Item)Node.Tag;

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

        //---------------------------------------------------------------------

        private void ShowRootLines(TreeView tree)
        {
            Activities Activities = new Activities(Database);
            tree.ShowRootLines = Activities.HasParents();

            Projects Projects = new Projects(Database);
            tree.ShowRootLines = Projects.HasParents();

            // FIXME: this is very unfinished
        }

        //---------------------------------------------------------------------
        // Populate a TimeZone drop down
        //---------------------------------------------------------------------

        public void PopulateTimeZoneComboBox(ComboBox box)
        {
            try {
                ReadOnlyCollection<TimeZoneInfo> TimeZones = TimeZoneInfo.GetSystemTimeZones();

                TimeZone CurrentTimeZone = TimeZone.CurrentTimeZone;
                int CurrentIndex = 0;

                foreach (TimeZoneInfo timeZone in TimeZones) {

                    IdObjectPair Pair = new IdObjectPair(CurrentIndex + 1, timeZone);

                    box.Items.Add(Pair);
                    if (CurrentTimeZone.StandardName == timeZone.StandardName) {
                        box.SelectedIndex = CurrentIndex;
                    }
                    CurrentIndex++;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

    }

}
