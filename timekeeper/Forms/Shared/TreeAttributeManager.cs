using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Shared
{
    public partial class TreeAttributeManager : Form
    {
        private Classes.Options Options;
        private Timekeeper.Dimension Dimension;
        private Classes.Widgets Widgets;
        private Classes.Project Project;
        private string EditDialogTitle;
        private ComboTreeNode PreSelectedNode;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public TreeAttributeManager(Timekeeper.Dimension dimension, ComboTreeNode selectedNode)
        {
            InitializeComponent();

            // Important things
            this.Options = Timekeeper.Options;
            this.Widgets = new Classes.Widgets();

            // Restore window metrics
            Height = Options.TreeManager_Height;
            Width = Options.TreeManager_Width;
            Top = Options.TreeManager_Top;
            Left = Options.TreeManager_Left;

            // Set the window flavor
            this.Dimension = dimension;

            switch (this.Dimension) {
                case Timekeeper.Dimension.Project:
                    this.Text = "Manage Projects";
                    this.EditDialogTitle = "Edit Project";
                    this.MenuNew.Text = "New Project";
                    break;
                case Timekeeper.Dimension.Activity:
                    this.Text = "Manage Activities";
                    this.EditDialogTitle = "Edit Activity";
                    this.MenuNew.Text = "New Activity";
                    break;
                case Timekeeper.Dimension.Location:
                    this.Text = "Manage Locations";
                    this.EditDialogTitle = "Edit Location";
                    this.MenuNew.Text = "New Location";
                    break;
                case Timekeeper.Dimension.Category:
                    this.Text = "Manage Categories";
                    this.EditDialogTitle = "Edit Category";
                    this.MenuNew.Text = "New Category";
                    break;
            }

            // Ensure right-clicking a tree item selects it.
            Tree.NodeMouseClick += (sender, args) => Tree.SelectedNode = args.Node;

            // Save for later
            this.PreSelectedNode = selectedNode;
        }

        //----------------------------------------------------------------------
        // Public propertie
        //----------------------------------------------------------------------

        public TreeNode SelectedNode
        {
            get {
                return Tree.SelectedNode;
            }

            set {
                Tree.SelectedNode = value;
            }
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void TreeAttributeManager_Load(object sender, EventArgs e)
        {
            this.Widgets.BuildTree(this.Dimension, Tree);

            try {
                if (this.PreSelectedNode != null) {
                    Classes.TreeAttribute Item = (Classes.TreeAttribute)this.PreSelectedNode.Tag;
                    TreeNode FoundNode = this.Widgets.FindTreeNode(Tree.Nodes, Item.ItemId);
                    Tree.SelectedNode = FoundNode;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void TreeAttributeManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Options.TreeManager_Height = Height;
            Options.TreeManager_Width = Width;
            Options.TreeManager_Top = Top;
            Options.TreeManager_Left = Left;
        }

        //----------------------------------------------------------------------
        // Menu Events
        //----------------------------------------------------------------------

        private void MenuNew_Click(object sender, EventArgs e)
        {
            this.Widgets.CreateTreeItemDialog(Tree, this.Dimension, false);
        }

        //----------------------------------------------------------------------

        private void MenuNewFolder_Click(object sender, EventArgs e)
        {
            this.Widgets.CreateTreeItemDialog(Tree, this.Dimension, true);
        }

        //----------------------------------------------------------------------

        private void MenuEdit_Click(object sender, EventArgs e)
        {
            Classes.TreeAttribute Item = (Classes.TreeAttribute)Tree.SelectedNode.Tag;
            string Title = this.EditDialogTitle;
            if (Item.IsFolder)
                Title += " Folder";
            EditItemDialog(Tree, Title, Item);
        }

        //----------------------------------------------------------------------

        private void MenuRename_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)Tree.SelectedNode.Tag;
                Tree.SelectedNode.Text = Item.Name;
                Tree.SelectedNode.BeginEdit();
            }
        }

        //----------------------------------------------------------------------

        private void MenuHide_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null) {
                Dialog_HideItem(Tree);
                SetHideUnhide();
            }
        }

        //----------------------------------------------------------------------

        private void MenuUnhide_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null) {
                Action_UnhideItem(Tree);
                SetHideUnhide();
            }
        }

        //----------------------------------------------------------------------

        private void MenuMerge_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)Tree.SelectedNode.Tag;
                Action_MergeItem(Item);
            }
        }

        //----------------------------------------------------------------------

        private void MenuDelete_Click(object sender, EventArgs e)
        {
            Action_DeleteItem(Tree);
        }

        //----------------------------------------------------------------------

        private void MenuProperties_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)Tree.SelectedNode.Tag;
                Forms.Properties Dialog = Widgets.GetPropertiesDialog(Item);
                Dialog.ShowDialog(this);
            }
        }

        //----------------------------------------------------------------------
        // Tree events
        //----------------------------------------------------------------------

        private void Tree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)SelectedNode.Tag;
                if (Item.IsFolderOpened) {
                    Item.CloseFolder();
                }
            }
        }

        //----------------------------------------------------------------------

        private void Tree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)SelectedNode.Tag;
                if (!Item.IsFolderOpened) {
                    Item.OpenFolder();
                }
            }
        }

        //----------------------------------------------------------------------

        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SetHideUnhide();
        }

        private void SetHideUnhide()
        {
            TreeNode Node = Tree.SelectedNode;
            Classes.TreeAttribute Item = (Classes.TreeAttribute)Node.Tag;

            MenuHide.Visible = !Item.IsHidden;
            PopupMenuHide.Visible = !Item.IsHidden;
            MenuUnhide.Visible = Item.IsHidden;
            PopupMenuUnhide.Visible = Item.IsHidden;
        }

        //----------------------------------------------------------------------

        private void Tree_DoubleClick(object sender, EventArgs e)
        {
            MenuEdit_Click(sender, e);
        }

        //----------------------------------------------------------------------
        // Keyboard events
        //----------------------------------------------------------------------

        private void Tree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                // Note, this Text replacement is only needed for Projects (which can
                // display the External project no in the TreeView) but it's harmless
                // for the other dimensions, so I'm leaving it here unconditionally.
                // I'm still calling the TreeAttribute "Project" as a reminder of 
                // what it's here for, even though this is used for all dimensions.
                Classes.TreeAttribute Project = (Classes.TreeAttribute)Tree.SelectedNode.Tag;
                Tree.SelectedNode.Text = Project.Name;
                Tree.SelectedNode.BeginEdit();
            } else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(Tree);
            } else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                MenuProperties_Click(sender, e);
            }
        }

        //----------------------------------------------------------------------
        // Label-Editing Events
        //----------------------------------------------------------------------

        private void Tree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode Node = Tree.SelectedNode;
            Classes.TreeAttribute Item = (Classes.TreeAttribute)Node.Tag;

            /* Old, simple approach. (Can't be used when ExternalProjectNo is involved.)
            TreeNode node = Tree.SelectedNode;
            Classes.TreeAttribute item = (Classes.TreeAttribute)node.Tag;
            e.CancelEdit = !Action_RenameItem(node, item, e.Label);
            */

            if (e.Label == null) {
                // This means they hit escape, so just reset the
                // node's text to what it was before this started.
                Node.Text = Item.DisplayName();
            } else {
                if (Action_RenameItem(Node, Item, e.Label)) {
                    Node.Text = Item.DisplayName();
                }
            }

            // Edit's never cancelled: we're manually handling all cases,
            // so don't give control back to the framework.
            e.CancelEdit = true;
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private void EditItemDialog(TreeView tree, string title, Classes.TreeAttribute item)
        {
            // Instantiate Dialog
            ItemEditor Dialog = new ItemEditor(this.Dimension, item.IsFolder);
            Dialog.Text = title;

            // Store the object in the dialog's tag
            Dialog.Tag = item;

            // Create a Project object (needed for External)
            if (this.Dimension == Timekeeper.Dimension.Project) {
                this.Project = new Classes.Project(item.Name);
            }

            // Nickname
            Classes.TreeAttribute ItemParent = item.Parent;

            // Previous values
            string PreviousName = item.Name;
            string PreviousDescription = item.Description;
            string PreviousFolder = ItemParent.Exists() ? ItemParent.Name : "(Top Level)"; //FIXME: some sort of keyword?!
            string PreviousExternalProjectNo = null;

            // Fill in defaults on the dialog box
            Dialog.ItemName.Text = PreviousName;
            Dialog.ItemDescription.Text = PreviousDescription;

            if (tree.SelectedNode == null) {
                Dialog.ItemParent.SelectedIndex = 0;
            } else if (tree.SelectedNode.Parent == null) {
                Dialog.ItemParent.SelectedIndex = 0;
            } else {
                PreviousFolder = tree.SelectedNode.Parent.Text;
                int i = Dialog.ItemParent.FindString(PreviousFolder);
                if (i < 0) i = 0;
                Dialog.ItemParent.SelectedIndex = i;
            }

            if (this.Dimension == Timekeeper.Dimension.Project) {
                PreviousExternalProjectNo = Project.ExternalProjectNo;
                Dialog.ItemExternalProjectNo.Text = PreviousExternalProjectNo;
            }

            // Now display the dialog box and handle the results
            if (Dialog.ShowDialog(this) == DialogResult.OK) {

                if (Dialog.ItemName.Text != PreviousName) {
                    if (Action_RenameItem(tree.SelectedNode, item, Dialog.ItemName.Text)) {
                        tree.SelectedNode.Text = item.DisplayName();
                    } else {
                        return;
                    }
                }

                if (Dialog.ItemDescription.Text != PreviousDescription) {
                    Action_RedescribeItem(tree.SelectedNode, item, Dialog.ItemDescription.Text);
                }

                if ((Dialog.ItemParent.Text != PreviousFolder)) {
                    IdValuePair Pair = (IdValuePair)Dialog.ItemParent.SelectedItem;
                    Action_ReparentItem(tree, item, (long)Pair.Id);
                }

                if ((this.Dimension == Timekeeper.Dimension.Project) && 
                    (Dialog.ItemExternalProjectNo.Text != "") &&
                    (Dialog.ItemExternalProjectNo.Text != PreviousExternalProjectNo))
                {
                    Project.Name = Dialog.ItemName.Text;
                    Action_RepointItem(tree.SelectedNode, Project, Dialog.ItemExternalProjectNo.Text);
                    tree.SelectedNode.Text = Project.DisplayName();
                    item = Project;
                }

                // Not sure about this just yet
                //tree.SelectedNode.Tag = item;
            }
        }

        //----------------------------------------------------------------------
        // gets messy below --- still needs cleanup
        //----------------------------------------------------------------------

        private void Dialog_HideItem(TreeView tree)
        {
            if (Options.Behavior_Annoy_PromptBeforeHiding) {
                Forms.Shared.Prompt Dialog = new Forms.Shared.Prompt();
                Dialog.wInstructions.Text = "Hide this item?\n\nTo display hidden items, go to Tools | Options and check the appropriate boxes on the View tab. Hidden items are always available on reports.";

                if (Dialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                } else {
                    if (Dialog.wDontShowAgain.Checked) {
                        Common.Warn("Debug this. Not sure if this will get saved.");
                        //Options.Behavior_Annoy_PromptBeforeHiding = false;
                    }
                }
            }

            Action_HideItem(tree);
        }


        //----------------------------------------------------------------------
        // Actions
        //----------------------------------------------------------------------

        public void Action_DeleteItem(TreeView tree)
        {
            // Confirm
            if (Common.Prompt("Delete this item?") != DialogResult.Yes) {
                return;
            }

            // Instantiate item
            Classes.TreeAttribute SourceItem = (Classes.TreeAttribute)tree.SelectedNode.Tag;

            // See if it's in use
            var JournalEntries = new Classes.JournalEntryCollection();
            int Count = JournalEntries.Count(SourceItem.Dimension, SourceItem.ItemId);

            if (Count > 0) {
                string Prompt = String.Format(
                    "You have {0} journal entries logged against this item. Would you like to merge them with another item?",
                    Count);
                if (Common.Prompt(Prompt) == DialogResult.Yes) {
                    if (!Action_MergeItem(SourceItem)) {
                        return;
                    }
                }
            }

            // Remove item from the database
            long result = SourceItem.Delete();
            if (result == 0) {
                Common.Warn("There was a problem deleting the item.");
                return;
            }

            // Now remove from the UI
            tree.SelectedNode.Remove();
        }

        //----------------------------------------------------------------------

        private void Action_HideItem(TreeView tree)
        {
            // Hide in the database
            Classes.TreeAttribute Item = (Classes.TreeAttribute)tree.SelectedNode.Tag;

            if (Item.Hide() == 0) {
                Common.Warn("There was a problem hiding the item.");
                return;
            }

            // Now handle the UI
            bool viewingHiddenItems = this.Widgets.GetViewHidden(this.Dimension);
            if (viewingHiddenItems) {
                tree.SelectedNode.ForeColor = Color.Gray;
                if (Item.IsFolder) {
                    tree.SelectedNode.ImageIndex = Timekeeper.IMG_FOLDER_HIDDEN;
                    tree.SelectedNode.SelectedImageIndex = Timekeeper.IMG_FOLDER_HIDDEN;
                } else {
                    tree.SelectedNode.ImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                    tree.SelectedNode.SelectedImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                }
            } else {
                tree.SelectedNode.Remove();
            }
        }

        //----------------------------------------------------------------------

        private void Action_UnhideItem(TreeView tree)
        {
            // Unhide in the database
            Classes.TreeAttribute item = (Classes.TreeAttribute)tree.SelectedNode.Tag;
            long result = item.Unhide();

            if (result == 0) {
                Common.Warn("There was a problem unhiding the item.");
                return;
            }

            // Update the UI
            tree.SelectedNode.ForeColor = Color.Black;
            if (item.IsFolder) {
                tree.SelectedNode.ImageIndex = Timekeeper.IMG_FOLDER;
                tree.SelectedNode.SelectedImageIndex = Timekeeper.IMG_FOLDER;
            } else {
                int Icon = Timekeeper.IMG_PROJECT;
                if (item.Dimension == Timekeeper.Dimension.Activity) {
                    Icon = Timekeeper.IMG_ACTIVITY;
                }
                tree.SelectedNode.ImageIndex = Icon;
                tree.SelectedNode.SelectedImageIndex = Icon;
            }
        }

        //----------------------------------------------------------------------

        private bool Action_MergeItem(Classes.TreeAttribute item)
        {
            Forms.Shared.Merge DialogBox = new Forms.Shared.Merge(item);
            if (DialogBox.ShowDialog(this) == DialogResult.Cancel) {
                return false;
            } else {
                return true;
            }
        }

        //----------------------------------------------------------------------

        private void Action_RedescribeItem(TreeNode node, Classes.TreeAttribute item, string newDescription)
        {
            int result = item.Redescribe(newDescription);
            if (result == Timekeeper.SUCCESS) {
                node.ToolTipText = item.Description;
            } else {
                Common.Warn("Error updating item description.");
                return;
            }
        }

        //----------------------------------------------------------------------

        private bool Action_RenameItem(TreeNode node, Classes.TreeAttribute item, string newName)
        {
            int result = item.Rename(newName);
            if (result == Timekeeper.SUCCESS) {
                return true;
            } else if (result == Classes.TreeAttribute.ERR_RENAME_EXISTS) {
                Common.Warn("An item with that name already exists.");
                return false;
            } else if (result == Timekeeper.FAILURE) {
                Common.Warn("Error renaming item.");
                return false;
            } else {
                // Don't care
                return false;
            }
        }

        //----------------------------------------------------------------------

        private void Action_ReparentItem(TreeView tree, Classes.TreeAttribute item, long parentId)
        {
            // Remove existing item from tree
            TreeNode ItemNode = Widgets.FindTreeNode(tree.Nodes, item.ItemId);
            ItemNode.Remove();

            // Now put it in its new place
            TreeNode ParentNode = Widgets.FindTreeNode(tree.Nodes, parentId);

            if (ParentNode == null) {
                item.Reparent(0);
                tree.Nodes.Add(ItemNode);
            } else {
                Classes.TreeAttribute parentItem = (Classes.TreeAttribute)ParentNode.Tag;
                if (item.IsDescendentOf(parentItem.ItemId)) {
                    Common.Warn("Item renamed, but not reparented. Cannot reparent to a descendent.");
                    return;
                }
                item.Reparent((Classes.TreeAttribute)ParentNode.Tag);
                ParentNode.Nodes.Add(ItemNode);
            }

        }

        //----------------------------------------------------------------------

        private void Action_RepointItem(TreeNode node, Classes.Project project, string newExternalProjectNo)
        {
            int result = project.Repoint(newExternalProjectNo);

            if (result == 0) {
                Common.Warn("Error updating External Project Number.");
            }
        }

        //----------------------------------------------------------------------
        // Drag and Drop Support
        //----------------------------------------------------------------------

        // Drag and Drop: Initiate drag sequence
        private void Tree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        // Drag and Drop: Set drag entry effect
        private void Tree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        //----------------------------------------------------------------------

        // Drag and Drop: Node selection on DragOver
        private void Tree_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = Tree.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            Tree.SelectedNode = Tree.GetNodeAt(targetPoint);
        }

        //----------------------------------------------------------------------

        // Drag and Drop: Wrapper around the core drop logic
        private void Tree_DragDrop(object sender, DragEventArgs e)
        {
            Action_TreeView_DragDrop(Tree, sender, e);
        }

        //----------------------------------------------------------------------

        private void Action_TreeView_DragDrop(TreeView tree, object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = tree.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = tree.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Get the Timekeeper Item of the node that was dragged.
            Classes.TreeAttribute draggedItem = (Classes.TreeAttribute)draggedNode.Tag;

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            // Also confirm that a folder isn't being dropped on top
            // of an item: items can only go into folders.
            bool DropAllowed = false;

            if (targetNode == null) {
                DropAllowed = true;
            } else {
                Classes.TreeAttribute targetItem = (Classes.TreeAttribute)targetNode.Tag;
                if (targetItem.IsFolder) {
                    DropAllowed = true;
                }
            }

            if (!draggedNode.Equals(targetNode) && !Action_TreeView_ContainsNode(draggedNode, targetNode) && (DropAllowed)) {
                if (e.Effect == DragDropEffects.Move) {
                    draggedNode.Remove();
                    if (targetNode == null) {
                        // Move to the root
                        tree.Nodes.Add(draggedNode);
                        // Update the database
                        draggedItem.Reparent(0);
                    } else {
                        // Otherwise, drop it on the target
                        targetNode.Nodes.Add(draggedNode);

                        // Update the database
                        Classes.TreeAttribute targetItem = (Classes.TreeAttribute)targetNode.Tag;
                        draggedItem.Reparent(targetItem.ItemId);

                        // Expand the node at the location 
                        // to show the dropped node.
                        targetNode.Expand();
                    }
                }
            } else if (!draggedNode.Equals(targetNode) && Action_TreeView_IsSibling(draggedNode, targetNode)) {

                int OldIndex = targetNode.Index;
                TreeNode Parent = targetNode.Parent;

                draggedNode.Remove();
                targetNode.Parent.Nodes.Insert(targetNode.Index + 1, draggedNode);
                targetNode.Remove();
                Parent.Nodes.Insert(OldIndex + 1, targetNode);

                long Index = 1;
                foreach (TreeNode node in Parent.Nodes) {
                    Classes.TreeAttribute Item = (Classes.TreeAttribute)node.Tag;
                    Item.Reorder(Index);
                    Index++;
                }
            } else {
                Common.Warn("Cannot drop item here");
            }
        }

        //----------------------------------------------------------------------

        private bool Action_TreeView_ContainsNode(TreeNode node1, TreeNode node2)
        {
            // A TreeView Drag-and-Drop Helper method
            if (node2 == null) {
                // We're moving it to the top level
                return false;
            } else {
                // Check the parent node of the second node.
                if (node2.Parent == null) return false;
                if (node2.Parent.Equals(node1)) return true;

                // If the parent node is not null or equal to the first node, 
                // call the ContainsNode method recursively using the parent of 
                // the second node.
                return Action_TreeView_ContainsNode(node1, node2.Parent);
            }
        }

        //----------------------------------------------------------------------

        private bool Action_TreeView_IsSibling(TreeNode node1, TreeNode node2)
        {
            // A TreeView Drag-and-Drop Helper method
            if (node2 == null) {
                return false;
            } else {
                Classes.TreeAttribute draggedItem = (Classes.TreeAttribute)node1.Tag;
                Classes.TreeAttribute targetItem = (Classes.TreeAttribute)node2.Tag;
                if (draggedItem.ParentId == targetItem.ParentId) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        //----------------------------------------------------------------------
        // CODE ARCHIVE
        //----------------------------------------------------------------------

        /*
        private void PopupMenuProjectAddtoTodoList_Click(object sender, EventArgs e)
        {
            Forms.Tools.TodoDetail DialogBox = new Forms.Tools.TodoDetail();

            Classes.Project Project = (Classes.Project)Tree.SelectedNode.Tag;
            DialogBox.ProjectId = Project.ItemId;

            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                Classes.TodoItem TodoItem = DialogBox.TodoItem;
                TodoItem.Create();

                // If a Todo form is open, add it to its list
                foreach (Form Form in OpenForms) {
                    if (Form.Name == "Todo") {
                        Forms.Tools.Todo Todo = (Forms.Tools.Todo)Form;
                        Todo.AddItem(Project.DisplayName(), TodoItem, Todo.TodoList.Groups[TodoItem.StatusName]);
                    }
                }
            }
        }
        */

        /*
        private void PopupMenuProject_Opening(object sender, CancelEventArgs e)
        {
            // FIXME: too much logic here
            if (Tree.SelectedNode != null) {
                Classes.Project Project = (Classes.Project)Tree.SelectedNode.Tag;

                if (Project.IsFolder) {
                    PopupMenuProjectAddtoTodoList.Enabled = false;
                } else {
                    if (Project.IsDeleted) {
                        PopupMenuProjectAddtoTodoList.Enabled = false;
                    } else {
                        Classes.TodoItemCollection TodoItems = new Classes.TodoItemCollection();
                        PopupMenuProjectAddtoTodoList.Enabled = !TodoItems.Exists(Project.ItemId);
                    }
                }
            } else {
                PopupMenuProjectAddtoTodoList.Enabled = false;
            }
        }
        */

        //----------------------------------------------------------------------


    }
}
