using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class fMain
    {
        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        public const int TREES_ITEM_CREATED = 0;
        public const int TREES_ERROR_CREATING_ITEM = -1;
        public const int TREES_DUPLICATE_ITEM = -2;

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        private void Trees_BuildActivityTree(TreeNodeCollection tree, TreeNode parentNode, long parentId)
        {
            // Instantiate Activities object
            this.tasks = new Activities(Database, Trees_GetOrderBy());

            // Iterate over Activities
            foreach (Activity Activity in tasks.Fetch(parentId, options.wViewHiddenTasks.Checked)) {
                // Create the new node
                TreeNode Node = Trees_InsertItem(tree, parentNode, Activity, IMG_TASK);

                // Then recurse
                if (Activity.ItemId != parentId) {
                    Trees_BuildActivityTree(tree, Node, Activity.ItemId);
                }
            }
        }

        //---------------------------------------------------------------------

        private void Trees_BuildProjectTree(TreeNodeCollection tree, TreeNode parentNode, long parentId)
        {
            // Instantiate Projects object
            this.projects = new Projects(Database, Trees_GetOrderBy());

            // Iterate over Projects
            foreach (Project Project in projects.Fetch(parentId, options.wViewHiddenTasks.Checked)) {
                // Create the new node
                TreeNode Node = Trees_InsertItem(tree, parentNode, Project, IMG_PROJECT);

                // Then recurse
                if (Project.ItemId != parentId) {
                    Trees_BuildProjectTree(tree, Node, Project.ItemId);
                }
            }
        }

        //---------------------------------------------------------------------

        private void Trees_DestroyActivityTree()
        {
            wTasks.Nodes.Clear();
        }

        //---------------------------------------------------------------------

        private void Trees_DestroyProjectTree()
        {
            wProjects.Nodes.Clear();
        }

        //---------------------------------------------------------------------

        private int Trees_CreateItem(TreeNodeCollection tree, Item item, string parentName, int imageIndex)
        {
            TreeNode ParentNode = null;
            item.ParentId = 0;

            if (parentName != "(Top Level)") {
                ParentNode = Trees_FindNode(tree, parentName);
                if (ParentNode != null) {
                    Item parentItem = (Item)ParentNode.Tag;
                    item.ParentId = parentItem.ItemId;
                } else {
                    //Common.Warn("There was an error creating the item.");
                    return TREES_ERROR_CREATING_ITEM;
                }
            }

            int Result = TREES_ITEM_CREATED;

            int CreateStatus = item.Create();
            switch (CreateStatus) {
                case 1:
                    TreeNode foo = Trees_InsertItem(tree, ParentNode, item, imageIndex);
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

        public TreeNode Trees_FindNode(TreeNodeCollection nodes, string name)
        {
            TreeNode Node = null;

            foreach (TreeNode n in nodes) {
                if (n.Text == name) {
                    Node = n;
                } else {
                    Node = Trees_FindNode(n.Nodes, name);
                }
                if (Node != null) {
                    break;
                }
            }

            return Node;
        }

        //---------------------------------------------------------------------

        public TreeNode Trees_FindNode(TreeNodeCollection nodes, long itemId)
        {
            TreeNode result = null;

            foreach (TreeNode n in nodes) {
                Item item = (Item)n.Tag;

                if (item.ItemId == itemId) {
                    result = n;
                } else {
                    result = Trees_FindNode(n.Nodes, itemId);
                }
                if (result != null) {
                    break;
                }
            }

            return result;
        }

        //---------------------------------------------------------------------

        private string Trees_GetOrderBy()
        {
            string OrderBy;

            switch (options.wOrderBy.SelectedIndex) {
                case 0: OrderBy = "Name asc"; break;
                case 1: OrderBy = "Name desc"; break;
                case 2: OrderBy = "CreateTime asc"; break;
                case 3: OrderBy = "CreateTime desc"; break;
                case 4: OrderBy = "ModifyTime asc"; break;
                case 5: OrderBy = "ModifyTime desc"; break;
                case 6: OrderBy = "SortOrderNo"; break;
                default: OrderBy = "CreateTime asc"; break;
            }

            return OrderBy;
        }

        //---------------------------------------------------------------------

        private TreeNode Trees_InsertItem(TreeNodeCollection tree, TreeNode parentNode, Item item, int imageIndex)
        {
            TreeNode Node = new TreeNode();
            Node.Tag = item;
            Node.Text = item.Name;
            Node.ToolTipText = item.Description;
            if (item.IsHidden) {
                Node.ForeColor = Color.Gray;
            }

            if (item.IsFolder) {
                Node.ImageIndex = IMG_FOLDER_CLOSED;
                Node.SelectedImageIndex = IMG_FOLDER_OPEN;
            } else {
                Node.ImageIndex = imageIndex;
                Node.SelectedImageIndex = imageIndex;
            }

            if (parentNode == null) {
                tree.Add(Node);
            } else {
                parentNode.Nodes.Add(Node);
            }

            Trees_ShowRootLines();

            return Node;
        }

        //---------------------------------------------------------------------

        private void Trees_ShowRootLines()
        {
            Activities Activities = new Activities(Database);
            wTasks.ShowRootLines = Activities.HasParents();

            Projects Projects = new Projects(Database);
            wProjects.ShowRootLines = Projects.HasParents();
        }

        //---------------------------------------------------------------------

    }
}
