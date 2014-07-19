namespace Timekeeper.Forms.Tools
{
    partial class Todo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Not Started", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("In Progress", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Blocked", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Todo));
            this.TodoList = new System.Windows.Forms.ListView();
            this.Memo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupMenuTodo = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupMenuTodoAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoHide = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuTodoMarkAs = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoMarkAsNotStarted = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoMarkAsInProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoMarkAsOnHold = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoMarkAsBlocked = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoMarkAsComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuTodoView = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuTodoViewShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewShowCompletedItems = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupBy = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByProject = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByDueDate = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeImages = new System.Windows.Forms.ImageList(this.components);
            this.SmallImages = new System.Windows.Forms.ImageList(this.components);
            this.TodoToolbar = new System.Windows.Forms.ToolStrip();
            this.MenuTodoAction = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuTodoActionAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoActionEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoActionHide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoActionUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoActionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoMarkAs = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuTodoMarkAsNotStarted = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoMarkAsInProgress = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoMarkAsOnHold = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoMarkAsBlocked = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoMarkAsComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoShow = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuTodoShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoShowCompletedItems = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTodoGroupByStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoGroupByProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoGroupByDueDate = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTodoViewLargeIcons = new System.Windows.Forms.ToolStripButton();
            this.MenuTodoViewSmallIcons = new System.Windows.Forms.ToolStripButton();
            this.MenuTodoViewTiles = new System.Windows.Forms.ToolStripButton();
            this.MenuTodoViewList = new System.Windows.Forms.ToolStripButton();
            this.MenuTodoViewDetails = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarItemCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProjectFolderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupMenuTodo.SuspendLayout();
            this.TodoToolbar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TodoList
            // 
            this.TodoList.AllowColumnReorder = true;
            this.TodoList.AllowDrop = true;
            this.TodoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Memo,
            this.ProjectName,
            this.ProjectFolderName,
            this.StartDate,
            this.DueDate,
            this.Status});
            this.TodoList.ContextMenuStrip = this.PopupMenuTodo;
            this.TodoList.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Not Started";
            listViewGroup1.Name = "Not Started";
            listViewGroup2.Header = "In Progress";
            listViewGroup2.Name = "In Progress";
            listViewGroup3.Header = "Blocked";
            listViewGroup3.Name = "Blocked";
            this.TodoList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.TodoList.HideSelection = false;
            this.TodoList.LargeImageList = this.LargeImages;
            this.TodoList.Location = new System.Drawing.Point(0, 25);
            this.TodoList.Name = "TodoList";
            this.TodoList.ShowItemToolTips = true;
            this.TodoList.Size = new System.Drawing.Size(766, 286);
            this.TodoList.SmallImageList = this.SmallImages;
            this.TodoList.TabIndex = 5;
            this.TodoList.UseCompatibleStateImageBehavior = false;
            this.TodoList.View = System.Windows.Forms.View.Details;
            this.TodoList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TodoList_ColumnClick);
            this.TodoList.DoubleClick += new System.EventHandler(this.TodoList_DoubleClick);
            // 
            // Memo
            // 
            this.Memo.Text = "Memo";
            this.Memo.Width = 175;
            // 
            // ProjectName
            // 
            this.ProjectName.Text = "Project";
            this.ProjectName.Width = 100;
            // 
            // StartDate
            // 
            this.StartDate.Text = "Start Date";
            this.StartDate.Width = 120;
            // 
            // DueDate
            // 
            this.DueDate.Text = "Due Date";
            this.DueDate.Width = 120;
            // 
            // Status
            // 
            this.Status.Text = "Status";
            this.Status.Width = 80;
            // 
            // PopupMenuTodo
            // 
            this.PopupMenuTodo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuTodoAdd,
            this.PopupMenuTodoEdit,
            this.PopupMenuTodoHide,
            this.PopupMenuTodoUnhide,
            this.PopupMenuTodoDelete,
            this.PopupMenuTodoSep1,
            this.PopupMenuTodoMarkAs,
            this.PopupMenuTodoSep2,
            this.PopupMenuTodoView,
            this.PopupMenuTodoGroupBy});
            this.PopupMenuTodo.Name = "contextMenuStrip1";
            this.PopupMenuTodo.Size = new System.Drawing.Size(119, 192);
            this.PopupMenuTodo.Opening += new System.ComponentModel.CancelEventHandler(this.PopupMenuTodo_Opening);
            // 
            // PopupMenuTodoAdd
            // 
            this.PopupMenuTodoAdd.Name = "PopupMenuTodoAdd";
            this.PopupMenuTodoAdd.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoAdd.Text = "Add...";
            this.PopupMenuTodoAdd.Click += new System.EventHandler(this.MenuTodoAdd_Click);
            // 
            // PopupMenuTodoEdit
            // 
            this.PopupMenuTodoEdit.Name = "PopupMenuTodoEdit";
            this.PopupMenuTodoEdit.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoEdit.Text = "Edit...";
            this.PopupMenuTodoEdit.Click += new System.EventHandler(this.MenuTodoEdit_Click);
            // 
            // PopupMenuTodoHide
            // 
            this.PopupMenuTodoHide.Name = "PopupMenuTodoHide";
            this.PopupMenuTodoHide.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoHide.Text = "Hide";
            this.PopupMenuTodoHide.Click += new System.EventHandler(this.MenuTodoHide_Click);
            // 
            // PopupMenuTodoUnhide
            // 
            this.PopupMenuTodoUnhide.Name = "PopupMenuTodoUnhide";
            this.PopupMenuTodoUnhide.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoUnhide.Text = "Unhide";
            this.PopupMenuTodoUnhide.Visible = false;
            this.PopupMenuTodoUnhide.Click += new System.EventHandler(this.MenuTodoUnhide_Click);
            // 
            // PopupMenuTodoDelete
            // 
            this.PopupMenuTodoDelete.Name = "PopupMenuTodoDelete";
            this.PopupMenuTodoDelete.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoDelete.Text = "Delete";
            this.PopupMenuTodoDelete.Click += new System.EventHandler(this.MenuTodoDelete_Click);
            // 
            // PopupMenuTodoSep1
            // 
            this.PopupMenuTodoSep1.Name = "PopupMenuTodoSep1";
            this.PopupMenuTodoSep1.Size = new System.Drawing.Size(115, 6);
            // 
            // PopupMenuTodoMarkAs
            // 
            this.PopupMenuTodoMarkAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuTodoMarkAsNotStarted,
            this.PopupMenuTodoMarkAsInProgress,
            this.PopupMenuTodoMarkAsOnHold,
            this.PopupMenuTodoMarkAsBlocked,
            this.PopupMenuTodoMarkAsComplete});
            this.PopupMenuTodoMarkAs.Name = "PopupMenuTodoMarkAs";
            this.PopupMenuTodoMarkAs.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoMarkAs.Text = "Mark As";
            // 
            // PopupMenuTodoMarkAsNotStarted
            // 
            this.PopupMenuTodoMarkAsNotStarted.Name = "PopupMenuTodoMarkAsNotStarted";
            this.PopupMenuTodoMarkAsNotStarted.Size = new System.Drawing.Size(130, 22);
            this.PopupMenuTodoMarkAsNotStarted.Text = "Not Started";
            this.PopupMenuTodoMarkAsNotStarted.Click += new System.EventHandler(this.MenuTodoMarkAsNotStarted_Click);
            // 
            // PopupMenuTodoMarkAsInProgress
            // 
            this.PopupMenuTodoMarkAsInProgress.Name = "PopupMenuTodoMarkAsInProgress";
            this.PopupMenuTodoMarkAsInProgress.Size = new System.Drawing.Size(130, 22);
            this.PopupMenuTodoMarkAsInProgress.Text = "In Progress";
            this.PopupMenuTodoMarkAsInProgress.Click += new System.EventHandler(this.MenuTodoMarkAsInProgress_Click);
            // 
            // PopupMenuTodoMarkAsOnHold
            // 
            this.PopupMenuTodoMarkAsOnHold.Name = "PopupMenuTodoMarkAsOnHold";
            this.PopupMenuTodoMarkAsOnHold.Size = new System.Drawing.Size(130, 22);
            this.PopupMenuTodoMarkAsOnHold.Text = "On Hold";
            this.PopupMenuTodoMarkAsOnHold.Click += new System.EventHandler(this.MenuTodoMarkAsOnHold_Click);
            // 
            // PopupMenuTodoMarkAsBlocked
            // 
            this.PopupMenuTodoMarkAsBlocked.Name = "PopupMenuTodoMarkAsBlocked";
            this.PopupMenuTodoMarkAsBlocked.Size = new System.Drawing.Size(130, 22);
            this.PopupMenuTodoMarkAsBlocked.Text = "Blocked";
            this.PopupMenuTodoMarkAsBlocked.Click += new System.EventHandler(this.MenuTodoMarkAsBlocked_Click);
            // 
            // PopupMenuTodoMarkAsComplete
            // 
            this.PopupMenuTodoMarkAsComplete.Name = "PopupMenuTodoMarkAsComplete";
            this.PopupMenuTodoMarkAsComplete.Size = new System.Drawing.Size(130, 22);
            this.PopupMenuTodoMarkAsComplete.Text = "Completed";
            this.PopupMenuTodoMarkAsComplete.Click += new System.EventHandler(this.MenuTodoMarkAsComplete_Click);
            // 
            // PopupMenuTodoSep2
            // 
            this.PopupMenuTodoSep2.Name = "PopupMenuTodoSep2";
            this.PopupMenuTodoSep2.Size = new System.Drawing.Size(115, 6);
            // 
            // PopupMenuTodoView
            // 
            this.PopupMenuTodoView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuTodoViewLargeIcons,
            this.PopupMenuTodoViewSmallIcons,
            this.PopupMenuTodoViewTiles,
            this.PopupMenuTodoViewList,
            this.PopupMenuTodoViewDetails,
            this.PopupMenuTodoViewSep1,
            this.PopupMenuTodoViewShowGroups,
            this.PopupMenuTodoViewShowCompletedItems});
            this.PopupMenuTodoView.Name = "PopupMenuTodoView";
            this.PopupMenuTodoView.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoView.Text = "View";
            // 
            // PopupMenuTodoViewLargeIcons
            // 
            this.PopupMenuTodoViewLargeIcons.Name = "PopupMenuTodoViewLargeIcons";
            this.PopupMenuTodoViewLargeIcons.Size = new System.Drawing.Size(184, 22);
            this.PopupMenuTodoViewLargeIcons.Text = "Large Icons";
            this.PopupMenuTodoViewLargeIcons.Click += new System.EventHandler(this.MenuTodoViewLargeIcons_Click);
            // 
            // PopupMenuTodoViewSmallIcons
            // 
            this.PopupMenuTodoViewSmallIcons.Name = "PopupMenuTodoViewSmallIcons";
            this.PopupMenuTodoViewSmallIcons.Size = new System.Drawing.Size(184, 22);
            this.PopupMenuTodoViewSmallIcons.Text = "Small Icons";
            this.PopupMenuTodoViewSmallIcons.Click += new System.EventHandler(this.MenuTodoViewSmallIcons_Click);
            // 
            // PopupMenuTodoViewTiles
            // 
            this.PopupMenuTodoViewTiles.Name = "PopupMenuTodoViewTiles";
            this.PopupMenuTodoViewTiles.Size = new System.Drawing.Size(184, 22);
            this.PopupMenuTodoViewTiles.Text = "Tiles";
            this.PopupMenuTodoViewTiles.Click += new System.EventHandler(this.MenuTodoViewTiles_Click);
            // 
            // PopupMenuTodoViewList
            // 
            this.PopupMenuTodoViewList.Name = "PopupMenuTodoViewList";
            this.PopupMenuTodoViewList.Size = new System.Drawing.Size(184, 22);
            this.PopupMenuTodoViewList.Text = "List";
            this.PopupMenuTodoViewList.Click += new System.EventHandler(this.MenuTodoViewList_Click);
            // 
            // PopupMenuTodoViewDetails
            // 
            this.PopupMenuTodoViewDetails.Checked = true;
            this.PopupMenuTodoViewDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuTodoViewDetails.Name = "PopupMenuTodoViewDetails";
            this.PopupMenuTodoViewDetails.Size = new System.Drawing.Size(184, 22);
            this.PopupMenuTodoViewDetails.Text = "Details";
            this.PopupMenuTodoViewDetails.Click += new System.EventHandler(this.MenuTodoViewDetails_Click);
            // 
            // PopupMenuTodoViewSep1
            // 
            this.PopupMenuTodoViewSep1.Name = "PopupMenuTodoViewSep1";
            this.PopupMenuTodoViewSep1.Size = new System.Drawing.Size(181, 6);
            // 
            // PopupMenuTodoViewShowGroups
            // 
            this.PopupMenuTodoViewShowGroups.Checked = true;
            this.PopupMenuTodoViewShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuTodoViewShowGroups.Name = "PopupMenuTodoViewShowGroups";
            this.PopupMenuTodoViewShowGroups.Size = new System.Drawing.Size(184, 22);
            this.PopupMenuTodoViewShowGroups.Text = "Show Groups";
            this.PopupMenuTodoViewShowGroups.Click += new System.EventHandler(this.MenuTodoViewShowGroups_Click);
            // 
            // PopupMenuTodoViewShowCompletedItems
            // 
            this.PopupMenuTodoViewShowCompletedItems.Name = "PopupMenuTodoViewShowCompletedItems";
            this.PopupMenuTodoViewShowCompletedItems.Size = new System.Drawing.Size(184, 22);
            this.PopupMenuTodoViewShowCompletedItems.Text = "Show Completed Items";
            this.PopupMenuTodoViewShowCompletedItems.Click += new System.EventHandler(this.MenuTodoShowCompletedItems_Click);
            // 
            // PopupMenuTodoGroupBy
            // 
            this.PopupMenuTodoGroupBy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuTodoGroupByStatus,
            this.PopupMenuTodoGroupByProject,
            this.PopupMenuTodoGroupByDueDate});
            this.PopupMenuTodoGroupBy.Name = "PopupMenuTodoGroupBy";
            this.PopupMenuTodoGroupBy.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoGroupBy.Text = "Group By";
            // 
            // PopupMenuTodoGroupByStatus
            // 
            this.PopupMenuTodoGroupByStatus.Checked = true;
            this.PopupMenuTodoGroupByStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuTodoGroupByStatus.Name = "PopupMenuTodoGroupByStatus";
            this.PopupMenuTodoGroupByStatus.Size = new System.Drawing.Size(119, 22);
            this.PopupMenuTodoGroupByStatus.Text = "Status";
            this.PopupMenuTodoGroupByStatus.Click += new System.EventHandler(this.MenuTodoGroupByStatus_Click);
            // 
            // PopupMenuTodoGroupByProject
            // 
            this.PopupMenuTodoGroupByProject.Name = "PopupMenuTodoGroupByProject";
            this.PopupMenuTodoGroupByProject.Size = new System.Drawing.Size(119, 22);
            this.PopupMenuTodoGroupByProject.Text = "Project";
            this.PopupMenuTodoGroupByProject.Click += new System.EventHandler(this.MenuTodoGroupByProject_Click);
            // 
            // PopupMenuTodoGroupByDueDate
            // 
            this.PopupMenuTodoGroupByDueDate.Name = "PopupMenuTodoGroupByDueDate";
            this.PopupMenuTodoGroupByDueDate.Size = new System.Drawing.Size(119, 22);
            this.PopupMenuTodoGroupByDueDate.Text = "Due Date";
            this.PopupMenuTodoGroupByDueDate.Click += new System.EventHandler(this.MenuTodoGroupByDueDate_Click);
            // 
            // LargeImages
            // 
            this.LargeImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("LargeImages.ImageStream")));
            this.LargeImages.TransparentColor = System.Drawing.Color.Transparent;
            this.LargeImages.Images.SetKeyName(0, "LargeProject.png");
            // 
            // SmallImages
            // 
            this.SmallImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallImages.ImageStream")));
            this.SmallImages.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallImages.Images.SetKeyName(0, "SmallProject.png");
            this.SmallImages.Images.SetKeyName(1, "menu-item-hidden.bmp");
            // 
            // TodoToolbar
            // 
            this.TodoToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TodoToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTodoAction,
            this.MenuTodoMarkAs,
            this.MenuTodoShow,
            this.MenuTodoRefresh,
            this.toolStripSeparator1,
            this.MenuTodoViewLargeIcons,
            this.MenuTodoViewSmallIcons,
            this.MenuTodoViewTiles,
            this.MenuTodoViewList,
            this.MenuTodoViewDetails});
            this.TodoToolbar.Location = new System.Drawing.Point(0, 0);
            this.TodoToolbar.Name = "TodoToolbar";
            this.TodoToolbar.Size = new System.Drawing.Size(766, 25);
            this.TodoToolbar.TabIndex = 6;
            this.TodoToolbar.Text = "toolStrip1";
            // 
            // MenuTodoAction
            // 
            this.MenuTodoAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuTodoAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTodoActionAdd,
            this.MenuTodoActionEdit,
            this.MenuTodoActionHide,
            this.MenuTodoActionUnhide,
            this.MenuTodoActionDelete});
            this.MenuTodoAction.Image = ((System.Drawing.Image)(resources.GetObject("MenuTodoAction.Image")));
            this.MenuTodoAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoAction.Name = "MenuTodoAction";
            this.MenuTodoAction.Size = new System.Drawing.Size(50, 22);
            this.MenuTodoAction.Text = "Action";
            this.MenuTodoAction.DropDownOpening += new System.EventHandler(this.MenuTodoAction_DropDownOpening);
            // 
            // MenuTodoActionAdd
            // 
            this.MenuTodoActionAdd.Name = "MenuTodoActionAdd";
            this.MenuTodoActionAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.MenuTodoActionAdd.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionAdd.Text = "Add...";
            this.MenuTodoActionAdd.Click += new System.EventHandler(this.MenuTodoAdd_Click);
            // 
            // MenuTodoActionEdit
            // 
            this.MenuTodoActionEdit.Name = "MenuTodoActionEdit";
            this.MenuTodoActionEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.MenuTodoActionEdit.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionEdit.Text = "Edit...";
            this.MenuTodoActionEdit.Click += new System.EventHandler(this.MenuTodoEdit_Click);
            // 
            // MenuTodoActionHide
            // 
            this.MenuTodoActionHide.Name = "MenuTodoActionHide";
            this.MenuTodoActionHide.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionHide.Text = "Hide...";
            this.MenuTodoActionHide.Click += new System.EventHandler(this.MenuTodoHide_Click);
            // 
            // MenuTodoActionUnhide
            // 
            this.MenuTodoActionUnhide.Name = "MenuTodoActionUnhide";
            this.MenuTodoActionUnhide.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionUnhide.Text = "Unhide...";
            this.MenuTodoActionUnhide.Visible = false;
            this.MenuTodoActionUnhide.Click += new System.EventHandler(this.MenuTodoUnhide_Click);
            // 
            // MenuTodoActionDelete
            // 
            this.MenuTodoActionDelete.Name = "MenuTodoActionDelete";
            this.MenuTodoActionDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.MenuTodoActionDelete.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionDelete.Text = "Delete...";
            this.MenuTodoActionDelete.Click += new System.EventHandler(this.MenuTodoDelete_Click);
            // 
            // MenuTodoMarkAs
            // 
            this.MenuTodoMarkAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuTodoMarkAs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTodoMarkAsNotStarted,
            this.MenuTodoMarkAsInProgress,
            this.MenuTodoMarkAsOnHold,
            this.MenuTodoMarkAsBlocked,
            this.MenuTodoMarkAsComplete});
            this.MenuTodoMarkAs.Image = ((System.Drawing.Image)(resources.GetObject("MenuTodoMarkAs.Image")));
            this.MenuTodoMarkAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoMarkAs.Name = "MenuTodoMarkAs";
            this.MenuTodoMarkAs.Size = new System.Drawing.Size(58, 22);
            this.MenuTodoMarkAs.Text = "Mark As";
            // 
            // MenuTodoMarkAsNotStarted
            // 
            this.MenuTodoMarkAsNotStarted.Name = "MenuTodoMarkAsNotStarted";
            this.MenuTodoMarkAsNotStarted.Size = new System.Drawing.Size(130, 22);
            this.MenuTodoMarkAsNotStarted.Text = "Not Started";
            // 
            // MenuTodoMarkAsInProgress
            // 
            this.MenuTodoMarkAsInProgress.Name = "MenuTodoMarkAsInProgress";
            this.MenuTodoMarkAsInProgress.Size = new System.Drawing.Size(130, 22);
            this.MenuTodoMarkAsInProgress.Text = "In Progress";
            // 
            // MenuTodoMarkAsOnHold
            // 
            this.MenuTodoMarkAsOnHold.Name = "MenuTodoMarkAsOnHold";
            this.MenuTodoMarkAsOnHold.Size = new System.Drawing.Size(130, 22);
            this.MenuTodoMarkAsOnHold.Text = "On Hold";
            // 
            // MenuTodoMarkAsBlocked
            // 
            this.MenuTodoMarkAsBlocked.Name = "MenuTodoMarkAsBlocked";
            this.MenuTodoMarkAsBlocked.Size = new System.Drawing.Size(130, 22);
            this.MenuTodoMarkAsBlocked.Text = "Blocked";
            // 
            // MenuTodoMarkAsComplete
            // 
            this.MenuTodoMarkAsComplete.Name = "MenuTodoMarkAsComplete";
            this.MenuTodoMarkAsComplete.Size = new System.Drawing.Size(130, 22);
            this.MenuTodoMarkAsComplete.Text = "Complete";
            // 
            // MenuTodoShow
            // 
            this.MenuTodoShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuTodoShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTodoShowGroups,
            this.MenuTodoShowCompletedItems,
            this.MenuTodoSep1,
            this.MenuTodoGroupByStatus,
            this.MenuTodoGroupByProject,
            this.MenuTodoGroupByDueDate});
            this.MenuTodoShow.Image = ((System.Drawing.Image)(resources.GetObject("MenuTodoShow.Image")));
            this.MenuTodoShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoShow.Name = "MenuTodoShow";
            this.MenuTodoShow.Size = new System.Drawing.Size(46, 22);
            this.MenuTodoShow.Text = "Show";
            // 
            // MenuTodoShowGroups
            // 
            this.MenuTodoShowGroups.Checked = true;
            this.MenuTodoShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuTodoShowGroups.Name = "MenuTodoShowGroups";
            this.MenuTodoShowGroups.Size = new System.Drawing.Size(166, 22);
            this.MenuTodoShowGroups.Text = "Groups";
            this.MenuTodoShowGroups.Click += new System.EventHandler(this.MenuTodoViewShowGroups_Click);
            // 
            // MenuTodoShowCompletedItems
            // 
            this.MenuTodoShowCompletedItems.Name = "MenuTodoShowCompletedItems";
            this.MenuTodoShowCompletedItems.Size = new System.Drawing.Size(166, 22);
            this.MenuTodoShowCompletedItems.Text = "Completed Items";
            this.MenuTodoShowCompletedItems.Click += new System.EventHandler(this.MenuTodoShowCompletedItems_Click);
            // 
            // MenuTodoSep1
            // 
            this.MenuTodoSep1.Name = "MenuTodoSep1";
            this.MenuTodoSep1.Size = new System.Drawing.Size(163, 6);
            // 
            // MenuTodoGroupByStatus
            // 
            this.MenuTodoGroupByStatus.Checked = true;
            this.MenuTodoGroupByStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuTodoGroupByStatus.Name = "MenuTodoGroupByStatus";
            this.MenuTodoGroupByStatus.Size = new System.Drawing.Size(166, 22);
            this.MenuTodoGroupByStatus.Text = "Group by Status";
            this.MenuTodoGroupByStatus.Click += new System.EventHandler(this.MenuTodoGroupByStatus_Click);
            // 
            // MenuTodoGroupByProject
            // 
            this.MenuTodoGroupByProject.Name = "MenuTodoGroupByProject";
            this.MenuTodoGroupByProject.Size = new System.Drawing.Size(166, 22);
            this.MenuTodoGroupByProject.Text = "Group by Project";
            this.MenuTodoGroupByProject.Click += new System.EventHandler(this.MenuTodoGroupByProject_Click);
            // 
            // MenuTodoGroupByDueDate
            // 
            this.MenuTodoGroupByDueDate.Name = "MenuTodoGroupByDueDate";
            this.MenuTodoGroupByDueDate.Size = new System.Drawing.Size(166, 22);
            this.MenuTodoGroupByDueDate.Text = "Group by Due Date";
            this.MenuTodoGroupByDueDate.Click += new System.EventHandler(this.MenuTodoGroupByDueDate_Click);
            // 
            // MenuTodoRefresh
            // 
            this.MenuTodoRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTodoRefresh.Image = global::Timekeeper.Properties.Resources.ImageButtonRefresh;
            this.MenuTodoRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoRefresh.Name = "MenuTodoRefresh";
            this.MenuTodoRefresh.Size = new System.Drawing.Size(23, 22);
            this.MenuTodoRefresh.Text = "Refresh";
            this.MenuTodoRefresh.Click += new System.EventHandler(this.MenuTodoRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // MenuTodoViewLargeIcons
            // 
            this.MenuTodoViewLargeIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTodoViewLargeIcons.Image = global::Timekeeper.Properties.Resources.ImageButtonViewLarge;
            this.MenuTodoViewLargeIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoViewLargeIcons.Name = "MenuTodoViewLargeIcons";
            this.MenuTodoViewLargeIcons.Size = new System.Drawing.Size(23, 22);
            this.MenuTodoViewLargeIcons.Text = "View Large Icons";
            this.MenuTodoViewLargeIcons.Click += new System.EventHandler(this.MenuTodoViewLargeIcons_Click);
            // 
            // MenuTodoViewSmallIcons
            // 
            this.MenuTodoViewSmallIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTodoViewSmallIcons.Image = global::Timekeeper.Properties.Resources.ImageButtonViewSmall;
            this.MenuTodoViewSmallIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoViewSmallIcons.Name = "MenuTodoViewSmallIcons";
            this.MenuTodoViewSmallIcons.Size = new System.Drawing.Size(23, 22);
            this.MenuTodoViewSmallIcons.Text = "View Small Icons";
            this.MenuTodoViewSmallIcons.Click += new System.EventHandler(this.MenuTodoViewSmallIcons_Click);
            // 
            // MenuTodoViewTiles
            // 
            this.MenuTodoViewTiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTodoViewTiles.Image = global::Timekeeper.Properties.Resources.ImageButtonViewTiles;
            this.MenuTodoViewTiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoViewTiles.Name = "MenuTodoViewTiles";
            this.MenuTodoViewTiles.Size = new System.Drawing.Size(23, 22);
            this.MenuTodoViewTiles.Text = "View Tiles";
            this.MenuTodoViewTiles.Click += new System.EventHandler(this.MenuTodoViewTiles_Click);
            // 
            // MenuTodoViewList
            // 
            this.MenuTodoViewList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTodoViewList.Image = global::Timekeeper.Properties.Resources.ImageButtonViewList;
            this.MenuTodoViewList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoViewList.Name = "MenuTodoViewList";
            this.MenuTodoViewList.Size = new System.Drawing.Size(23, 22);
            this.MenuTodoViewList.Text = "View List";
            this.MenuTodoViewList.Click += new System.EventHandler(this.MenuTodoViewList_Click);
            // 
            // MenuTodoViewDetails
            // 
            this.MenuTodoViewDetails.Checked = true;
            this.MenuTodoViewDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuTodoViewDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuTodoViewDetails.Image = global::Timekeeper.Properties.Resources.ImageButtonViewDetails;
            this.MenuTodoViewDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuTodoViewDetails.Name = "MenuTodoViewDetails";
            this.MenuTodoViewDetails.Size = new System.Drawing.Size(23, 22);
            this.MenuTodoViewDetails.Text = "View Details";
            this.MenuTodoViewDetails.Click += new System.EventHandler(this.MenuTodoViewDetails_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarItemCount});
            this.StatusBar.Location = new System.Drawing.Point(0, 311);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(766, 22);
            this.StatusBar.TabIndex = 7;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusBarItemCount
            // 
            this.StatusBarItemCount.Name = "StatusBarItemCount";
            this.StatusBarItemCount.Size = new System.Drawing.Size(13, 17);
            this.StatusBarItemCount.Text = "0";
            // 
            // ProjectFolderName
            // 
            this.ProjectFolderName.Text = "Project Folder";
            this.ProjectFolderName.Width = 100;
            // 
            // Todo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 333);
            this.Controls.Add(this.TodoList);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.TodoToolbar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Todo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Todo List";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Todo_FormClosing);
            this.Load += new System.EventHandler(this.Todo_Load);
            this.PopupMenuTodo.ResumeLayout(false);
            this.TodoToolbar.ResumeLayout(false);
            this.TodoToolbar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColumnHeader ProjectName;
        private System.Windows.Forms.ColumnHeader StartDate;
        private System.Windows.Forms.ColumnHeader DueDate;
        private System.Windows.Forms.ToolStrip TodoToolbar;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ContextMenuStrip PopupMenuTodo;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoAdd;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoEdit;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoDelete;
        private System.Windows.Forms.ToolStripSeparator PopupMenuTodoSep2;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoView;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewTiles;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewList;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewDetails;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupBy;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByStatus;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByProject;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByDueDate;
        private System.Windows.Forms.ToolStripSeparator PopupMenuTodoViewSep1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewShowGroups;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoMarkAs;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoHide;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoUnhide;
        private System.Windows.Forms.ImageList SmallImages;
        private System.Windows.Forms.ImageList LargeImages;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarItemCount;
        private System.Windows.Forms.ToolStripDropDownButton MenuTodoAction;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoMarkAsNotStarted;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoMarkAsInProgress;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoMarkAsComplete;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoMarkAsBlocked;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoMarkAsOnHold;
        private System.Windows.Forms.ToolStripSeparator PopupMenuTodoSep1;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionHide;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionUnhide;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionDelete;
        private System.Windows.Forms.ToolStripDropDownButton MenuTodoMarkAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuTodoViewLargeIcons;
        private System.Windows.Forms.ToolStripButton MenuTodoViewSmallIcons;
        private System.Windows.Forms.ToolStripButton MenuTodoViewTiles;
        private System.Windows.Forms.ToolStripButton MenuTodoViewList;
        private System.Windows.Forms.ToolStripButton MenuTodoViewDetails;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoMarkAsNotStarted;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoMarkAsInProgress;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoMarkAsOnHold;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoMarkAsBlocked;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoMarkAsComplete;
        internal System.Windows.Forms.ListView TodoList;
        private System.Windows.Forms.ToolStripDropDownButton MenuTodoShow;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoShowGroups;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoShowCompletedItems;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewShowCompletedItems;
        private System.Windows.Forms.ColumnHeader Memo;
        private System.Windows.Forms.ToolStripSeparator MenuTodoSep1;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoGroupByStatus;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoGroupByProject;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoGroupByDueDate;
        private System.Windows.Forms.ToolStripButton MenuTodoRefresh;
        private System.Windows.Forms.ColumnHeader ProjectFolderName;
    }
}

