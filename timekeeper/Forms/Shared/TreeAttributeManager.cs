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
        private Timekeeper.Dimension Dimension;
        private Classes.Widgets Widgets;
        private Classes.Project Project;
        //private Classes.Activity Activity;
        private Classes.TreeAttribute Item;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public TreeAttributeManager(Timekeeper.Dimension dimension)
        {
            InitializeComponent();
            this.Dimension = dimension;

            switch (this.Dimension) {
                case Timekeeper.Dimension.Project:
                    this.Text = "Manage Projects";
                    break;
                case Timekeeper.Dimension.Activity:
                    this.Text = "Manage Activities";
                    break;
                case Timekeeper.Dimension.Location:
                    this.Text = "Manage Locations";
                    break;
                case Timekeeper.Dimension.Category:
                    this.Text = "Manage Categories";
                    break;
            }

            Tree.NodeMouseClick += (sender, args) => Tree.SelectedNode = args.Node;

            this.Widgets = new Classes.Widgets();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void TreeAttributeManager_Load(object sender, EventArgs e)
        {
            this.BuildTree();
        }

        //----------------------------------------------------------------------
        // Menu Events
        //----------------------------------------------------------------------

        private void MenuNew_Click(object sender, EventArgs e)
        {
            CreateNewItem(false);
        }

        //----------------------------------------------------------------------

        private void MenuNewFolder_Click(object sender, EventArgs e)
        {
            CreateNewItem(true);
        }

        //---------------------------------------------------------------------

        private void MenuEdit_Click(object sender, EventArgs e)
        {
            EditItemDialog(Tree, "FIX ME", (Classes.TreeAttribute)Tree.SelectedNode.Tag);
        }

        //---------------------------------------------------------------------

        private void MenuRename_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)Tree.SelectedNode.Tag;
                Tree.SelectedNode.Text = Item.Name;
                Tree.SelectedNode.BeginEdit();
            }
        }

        //---------------------------------------------------------------------
        // gets messy below --- still needs cleanup
        //---------------------------------------------------------------------

        private void MenuActionHideProject_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null) {
                Dialog_HideItem(Tree, true); // FIXME: NEED SUPPORT FOR THIS STILL: Options.View_HiddenProjects);
                //MenuBar_ShowHideProject(false);
            }
        }

        //---------------------------------------------------------------------

        private void MenuActionUnhideProject_Click(object sender, EventArgs e)
        {
            if (Tree.SelectedNode != null) {
                Action_UnhideItem(Tree);
                //MenuBar_ShowHideProject(true);
            }
        }

        private void PopupMenuProjectProperties_Click(object sender, EventArgs e)
        {
            // FIXME: COPY/PASTE
            if (Tree.SelectedNode != null) {
                Classes.Project item = (Classes.Project)Tree.SelectedNode.Tag;
                PropertiesDialog((Classes.TreeAttribute)item);
            }
        }

        private void PopupMenuActivityProperties_Click(object sender, EventArgs e)
        {
            // FIXME: COPY/PASTE
            if (Tree.SelectedNode != null) {
                Classes.Activity item = (Classes.Activity)Tree.SelectedNode.Tag;
                PropertiesDialog((Classes.TreeAttribute)item);
            }
        }

        //---------------------------------------------------------------------
        // Keyboard events
        //---------------------------------------------------------------------

        private void Tree_KeyDown(object sender, KeyEventArgs e)
        {
            switch (this.Dimension) {
                case Timekeeper.Dimension.Project:
                    ProjectTree_KeyDown(sender, e);
                    break;
                case Timekeeper.Dimension.Activity:
                    ActivityTree_KeyDown(sender, e);
                    break;
            }
        }

        // Project window keys
        private void ProjectTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                Classes.Project Project = (Classes.Project)Tree.SelectedNode.Tag;
                Tree.SelectedNode.Text = Project.Name;
                Tree.SelectedNode.BeginEdit();
            } else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(Tree);
            } else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                PopupMenuProjectProperties_Click(sender, e);
            }
        }

        // Action window keys
        private void ActivityTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                Tree.SelectedNode.BeginEdit();
            } else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(Tree);
            } else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                PopupMenuActivityProperties_Click(sender, e);
            }
        }

        //---------------------------------------------------------------------
        // Label-Editing Events
        //---------------------------------------------------------------------

        private void Tree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            switch (this.Dimension) {
                case Timekeeper.Dimension.Project:
                    ProjectTree_AfterLabelEdit(sender, e);
                    break;
                case Timekeeper.Dimension.Activity:
                    ActivityTree_AfterLabelEdit(sender, e);
                    break;
            }
        }

        //---------------------------------------------------------------------

        private void ProjectTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode Node = Tree.SelectedNode;
            Classes.Project Project = (Classes.Project)Node.Tag;

            if (e.Label == null) {
                // This means they hit escape, so just reset the
                // node's text to what it was before this started.
                Node.Text = Project.DisplayName();
            } else {
                if (Action_RenameItem(Node, Project, e.Label)) {
                    Node.Text = Project.DisplayName();
                }
            }

            // Edit's never cancelled: we're manually handling all cases,
            // so don't give control back to the framework.
            e.CancelEdit = true;
        }

        //---------------------------------------------------------------------

        private void ActivityTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node = Tree.SelectedNode;
            Classes.TreeAttribute item = (Classes.TreeAttribute)node.Tag;
            e.CancelEdit = !Action_RenameItem(node, item, e.Label);
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private void BuildTree()
        {
            switch (this.Dimension) {
                case Timekeeper.Dimension.Project:
                    Widgets.BuildProjectTree(Tree.Nodes);
                    break;
                case Timekeeper.Dimension.Activity:
                    Widgets.BuildActivityTree(Tree.Nodes);
                    break;
            }
        }

        //----------------------------------------------------------------------

        private void CreateNewItem(bool isFolder)
        {
            string DialogTitle = 
                "New " + 
                this.Dimension.ToString() + 
                (isFolder ? " Folder" : "");
            int Icon = 0;

            switch (this.Dimension) {
                case Timekeeper.Dimension.Project:
                    this.Item = new Classes.Project();
                    Icon = Timekeeper.IMG_PROJECT;
                    break;
                case Timekeeper.Dimension.Activity:
                    this.Item = new Classes.Activity();
                    Icon = Timekeeper.IMG_ACTIVITY;
                    break;
            }

            CreateNewItemDialog(Tree, DialogTitle, isFolder, Item, Icon);
        }

        //----------------------------------------------------------------------

        private void CreateNewItemDialog(TreeView tree, string title, bool isFolder, Classes.TreeAttribute item, int imageIndex)
        {
            // Instantiate Dialog
            ItemEditor Dialog = new ItemEditor(this.Dimension);
            Dialog.Text = title;

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

            if (Dialog.ShowDialog(this) == DialogResult.OK) {
                item.Name = Dialog.ItemName.Text;
                item.Description = Dialog.ItemDescription.Text;
                item.IsFolder = isFolder;
                item.ExternalProjectNo = Dialog.ItemExternalProjectNo.Text == "" ? null : Dialog.ItemExternalProjectNo.Text;

                IdValuePair Pair = (IdValuePair)Dialog.ItemParent.SelectedItem;
                int ParentItemId = Pair.Id;

                int CreateResult = Widgets.CreateTreeItem(tree.Nodes, item, ParentItemId, imageIndex);
                switch (CreateResult) {
                    case Classes.Widgets.TREES_ITEM_CREATED:
                        //Action_TreeView_ShowRootLines();
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
        }

        //----------------------------------------------------------------------

        private void EditItemDialog(TreeView tree, string title, Classes.TreeAttribute item)
        {
            // Instantiate Dialog
            ItemEditor Dialog = new ItemEditor(this.Dimension);
            Dialog.Text = title;

            // Store the object in the dialog's tag
            Dialog.Tag = item;

            // Create a Project object (needed for External)
            if (this.Dimension == Timekeeper.Dimension.Project) {
                this.Project = new Classes.Project(item.Name);
            }

            // Previous values
            string PreviousName = item.Name;
            string PreviousDescription = item.Description;
            string PreviousFolder = "";
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
                        tree.SelectedNode.Tag = item;
                    } else {
                        return;
                    }
                }

                if (Dialog.ItemDescription.Text != PreviousDescription) {
                    Action_RedescribeItem(tree.SelectedNode, item, Dialog.ItemDescription.Text);
                }

                if (Dialog.ItemParent.Text != PreviousFolder) {
                    IdValuePair Pair = (IdValuePair)Dialog.ItemParent.SelectedItem;
                    Action_ReparentItem(tree, item, (long)Pair.Id);
                }

                if ((this.Dimension == Timekeeper.Dimension.Project) && 
                    (Dialog.ItemExternalProjectNo.Text != PreviousExternalProjectNo))
                {
                    Project.Name = Dialog.ItemName.Text;
                    Action_RepointItem(tree.SelectedNode, Project, Dialog.ItemExternalProjectNo.Text);
                    tree.SelectedNode.Text = Project.DisplayName();
                }
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_HideItem(TreeView tree, bool viewingHiddenItems)
        {
            //if (Options.Behavior_Annoy_PromptBeforeHiding) {
            if (true) {
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

            Action_HideItem(tree, viewingHiddenItems);
        }

        //---------------------------------------------------------------------

        private void PropertiesDialog(Classes.TreeAttribute item)
        {
            Forms.Properties Dialog = new Forms.Properties();

            // Set date range for time calculations
            string From = DateTime.Now.ToString(Common.DATE_FORMAT + " 00:00:00");
            string To = DateTime.Now.ToString(Common.DATE_FORMAT + " 23:59:59");

            // Determine the item type
            string ItemType = item.Type.ToString();
            if (item.IsFolder) ItemType += " Folder";

            // Set dialog box title
            Dialog.Text = ItemType + " Properties";

            // Set description
            string Description;
            if (item.Description.Length > 0) {
                Description = Common.Abbreviate(item.Description, 42);
                Dialog.wDescription.Enabled = true;
            } else {
                Description = "None";
                Dialog.wDescription.Enabled = false;
            }

            // Now fill in all the values
            Dialog.wName.Text = Common.Abbreviate(item.Name, 42);
            Dialog.wDescription.Text = Description;
            Dialog.wType.Text = ItemType;
            Dialog.wID.Text = item.ItemId.ToString();
            Dialog.wGUID.Text = item.ItemGuid;

            Dialog.wCreated.Text = item.CreateTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            Dialog.wModified.Text = item.ModifyTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            Dialog.wTotalTime.Text = Timekeeper.FormatSeconds(item.RecursiveSecondsElapsed(item.ItemId, "1900-01-01", "2999-01-01"));
            Dialog.wTimeToday.Text = Timekeeper.FormatSeconds(item.RecursiveSecondsElapsed(item.ItemId, From, To));

            Dialog.wIsHidden.Checked = item.IsHidden;
            Dialog.wIsDeleted.Checked = item.IsDeleted;
            if (item.IsHidden)
                Dialog.wHiddenTime.Text = item.HiddenTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            if (item.IsDeleted)
                Dialog.wDeletedTime.Text = item.DeletedTime.ToString(Common.LOCAL_DATETIME_FORMAT);

            if (item.Type == Timekeeper.Dimension.Project) {
                long LastActivityId = item.FollowedItemId;
                if (LastActivityId > 0) {
                    Classes.Activity Activity = new Classes.Activity(LastActivityId);
                    Dialog.wLastItemName.Enabled = true;
                    Dialog.wLastItemName.Text = Activity.Name;
                    Dialog.wLastItemLabel.Text = "Last Activity:";
                } else {
                    Dialog.wLastItemName.Enabled = false;
                    Dialog.wLastItemName.Text = "None";
                }
                Dialog.wExternalProjectNo.Text = item.ExternalProjectNo;
                Dialog.wExternalProjectNoLabel.Visible = true;
                Dialog.wExternalProjectNo.Visible = true;
            } else {
                long LastProjectId = item.FollowedItemId;
                if (LastProjectId > 0) {
                    Classes.Project Project = new Classes.Project(LastProjectId);
                    Dialog.wLastItemLabel.Text = "Last Project:";
                    Dialog.wLastItemName.Enabled = true;
                    Dialog.wLastItemName.Text = Project.Name;
                } else {
                    Dialog.wLastItemName.Enabled = false;
                    Dialog.wLastItemName.Text = "None";
                }
                Dialog.wExternalProjectNoLabel.Visible = false;
                Dialog.wExternalProjectNo.Visible = false;
            }

            Dialog.ShowDialog(this);
        }


        //----------------------------------------------------------------------
        // Actions
        //---------------------------------------------------------------------

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
            int Count = JournalEntries.Count(SourceItem.Type, SourceItem.ItemId);

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

        //---------------------------------------------------------------------

        private void Action_HideItem(TreeView tree, bool viewingHiddenItems)
        {
            // Hide in the database
            Classes.TreeAttribute Item = (Classes.TreeAttribute)tree.SelectedNode.Tag;

            if (Item.Hide() == 0) {
                Common.Warn("There was a problem hiding the item.");
                return;
            }

            // Now handle the UI
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
                tree.SelectedNode.ImageIndex = Timekeeper.IMG_FOLDER_CLOSED;
                tree.SelectedNode.SelectedImageIndex = Timekeeper.IMG_FOLDER_CLOSED;
            } else {
                int Icon = Timekeeper.IMG_PROJECT;
                if (item.Type == Timekeeper.Dimension.Activity) {
                    Icon = Timekeeper.IMG_ACTIVITY;
                }
                tree.SelectedNode.ImageIndex = Icon;
                tree.SelectedNode.SelectedImageIndex = Icon;
            }
        }

        //---------------------------------------------------------------------

        private bool Action_MergeItem(Classes.TreeAttribute item)
        {
            Forms.Shared.Merge DialogBox = new Forms.Shared.Merge(item);
            if (DialogBox.ShowDialog(this) == DialogResult.Cancel) {
                return false;
            } else {
                Classes.TreeAttribute TargetItem = DialogBox.TargetItem;
                string Message = String.Format("You just merged all of the entries for {0} into {1}", item.Name, TargetItem.Name);
                Common.Info(Message);
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
            TreeNode ParentNode = Widgets.FindTreeNode(tree.Nodes, parentId);

            if (ParentNode == null) {
                item.Reparent(0);
            } else {
                Classes.TreeAttribute parentItem = (Classes.TreeAttribute)ParentNode.Tag;
                if (item.IsDescendentOf(parentItem.ItemId)) {
                    Common.Warn("Item renamed, but not reparented. Cannot reparent to a descendent.");
                    return;
                }
                item.Reparent((Classes.TreeAttribute)ParentNode.Tag);
            }

            // FIXME: Find a less brute-force way to do this
            this.BuildTree();
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
        // CODE ARCHIVE
        //----------------------------------------------------------------------

        // Drag and Drop: Node selection on DragOver (Projects)
        /*
        private void ProjectTree_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = ProjectTree.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            ProjectTree.SelectedNode = ProjectTree.GetNodeAt(targetPoint);
        }

        // Drag and Drop: Node selection on DragOver (Activities)
        private void ActivityTree_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = ActivityTree.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            ActivityTree.SelectedNode = ActivityTree.GetNodeAt(targetPoint);
        }

        // Drag and Drop: Wrapper around the core drop logic
        private void ProjectTree_DragDrop(object sender, DragEventArgs e)
        {
            Action_TreeView_DragDrop(ProjectTree, sender, e);
        }

        private void ActivityTree_DragDrop(object sender, DragEventArgs e)
        {
            Action_TreeView_DragDrop(ActivityTree, sender, e);
        }
        */

        //---------------------------------------------------------------------

        // Drag and Drop: Initiate drag sequence
        /*
        private void ProjectTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void ActivityTree_ItemDrag(object sender, ItemDragEventArgs e)
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
        */

        //----------------------------------------------------------------------

        /*
        private void ProjectTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Classes.Project Project = (Classes.Project)SelectedNode.Tag;
                if (Project.IsFolderOpened) {
                    Project.CloseFolder();
                }
            }
        }

        private void ActivityTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Classes.Activity Activity = (Classes.Activity)SelectedNode.Tag;
                if (!Activity.IsFolderOpened) {
                    Activity.OpenFolder();
                }
            }
        }

        private void ActivityTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Classes.Activity Activity = (Classes.Activity)SelectedNode.Tag;
                if (Activity.IsFolderOpened) {
                    Activity.CloseFolder();
                }
            }
        }
        */

        //----------------------------------------------------------------------

        /*
        private void PopupMenuProjectAddtoTodoList_Click(object sender, EventArgs e)
        {
            Forms.Tools.TodoDetail DialogBox = new Forms.Tools.TodoDetail();

            Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
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
            if (ProjectTree.SelectedNode != null) {
                Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;

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

        //---------------------------------------------------------------------

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

            // Cross-tree dragging warning
            bool CrossDragAccepted = false;
            if (tree.Name != draggedNode.TreeView.Name) {
                // TODO: Allow conversion via drag and drop. This means that once confirmed
                string ToItem = (string)tree.Tag;
                string FromItem = (ToItem == "Project") ? "Activity" : "Project";
                string Message;
                if (draggedItem.IsFolder) {
                    Message = String.Format("You cannot drag this {0} folder to the {1} tree.", FromItem, ToItem);
                    Common.Warn(Message);
                    return;
                } else {
                    Message = "You are dragging an item to a different tree. ";
                    Message += String.Format("Do you wish to convert this {0} to a {1}?", FromItem, ToItem);
                    if (draggedItem.GetType() == typeof(Classes.Project)) {
                        Message += Environment.NewLine + Environment.NewLine +
                            "Note that any External Project Number associated with this Project will be lost. This action cannot be undone.";
                    }
                    if (Common.WarnPrompt(Message) == DialogResult.Yes) {
                        CrossDragAccepted = true;
                    } else {
                        return;
                    }
                }
            }

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

            }

            if (CrossDragAccepted) {

                // Conversion
                if (draggedItem.GetType() == typeof(Classes.Project)) {

                    // Create an Activity in the database
                    Classes.Activity Activity = new Classes.Activity();
                    Activity.Copy(draggedItem);
                    Activity.Create();

                    draggedNode.Tag = (Classes.TreeAttribute)Activity;

                    // Update the UI
                    if (Activity.IsHidden) {
                        draggedNode.ImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                        draggedNode.SelectedImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                    } else {
                        draggedNode.ImageIndex = Timekeeper.IMG_ACTIVITY;
                        draggedNode.SelectedImageIndex = Timekeeper.IMG_ACTIVITY;
                    }
                } else {
                    // Create a Project in the database
                    Classes.Project Project = new Classes.Project();
                    Project.Copy(draggedItem);
                    Project.Create();

                    draggedNode.Tag = (Classes.TreeAttribute)Project;

                    // Update the UI
                    if (Project.IsHidden) {
                        draggedNode.ImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                        draggedNode.SelectedImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                    } else {
                        draggedNode.ImageIndex = Timekeeper.IMG_PROJECT;
                        draggedNode.SelectedImageIndex = Timekeeper.IMG_PROJECT;
                    }
                }

                // Removal
                draggedItem.Delete();
                //draggedItem.Rename(draggedItem.ItemGuid);
            }
        }

        //---------------------------------------------------------------------

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

        //---------------------------------------------------------------------

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

        //---------------------------------------------------------------------

    }
}
