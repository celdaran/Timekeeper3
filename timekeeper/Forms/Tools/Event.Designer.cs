namespace Timekeeper.Forms.Tools
{
    partial class Event
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("One Time", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Recurring", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Christmas",
            "Don\'t forget to start your shopping on Black Friday!",
            "2013-12-25",
            "One Time",
            "via Email"}, 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Exercise",
            "Get off your butt now and then",
            "2013-10-04 08:30",
            "Hourly",
            "System Tray"}, 1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Halloween",
            "It\'s going to be scary this year!",
            "2013-10-31",
            "One Time",
            "via Email"}, 0);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Trip to Denton",
            "See Sawah!",
            "2013-10-18",
            "One Time",
            "None"}, 0);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Event));
            this.TodoList = new System.Windows.Forms.ListView();
            this.NewEventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TargetTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventPeriod = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RemindSomething = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupMenuReminder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupMenuTodoAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoHide = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuTodoView = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoViewSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuTodoViewShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupBy = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByStatus = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByStartDate = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByDueDate = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeImages = new System.Windows.Forms.ImageList(this.components);
            this.SmallImages = new System.Windows.Forms.ImageList(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarItemCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.TodoToolbar = new System.Windows.Forms.ToolStrip();
            this.MenuTodoAction = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuTodoActionAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoActionEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoActionHide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoActionUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoActionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoShow = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuTodoShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTodoShowCompletedItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuTodoViewLargeIcons = new System.Windows.Forms.ToolStripButton();
            this.MenuTodoViewSmallIcons = new System.Windows.Forms.ToolStripButton();
            this.MenuTodoViewTiles = new System.Windows.Forms.ToolStripButton();
            this.MenuTodoViewList = new System.Windows.Forms.ToolStripButton();
            this.MenuTodoViewDetails = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SendEmailButton = new System.Windows.Forms.ToolStripButton();
            this.QuartzTestButton = new System.Windows.Forms.ToolStripButton();
            this.PopupMenuReminder.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.TodoToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TodoList
            // 
            this.TodoList.AllowColumnReorder = true;
            this.TodoList.AllowDrop = true;
            this.TodoList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NewEventName,
            this.EventDescription,
            this.TargetTime,
            this.EventPeriod,
            this.RemindSomething,
            this.columnHeader1});
            this.TodoList.ContextMenuStrip = this.PopupMenuReminder;
            this.TodoList.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "One Time";
            listViewGroup1.Name = "OneTime";
            listViewGroup2.Header = "Recurring";
            listViewGroup2.Name = "Recurring";
            this.TodoList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.TodoList.HideSelection = false;
            listViewItem1.Group = listViewGroup1;
            listViewItem2.Group = listViewGroup2;
            listViewItem3.Group = listViewGroup1;
            listViewItem4.Group = listViewGroup1;
            this.TodoList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.TodoList.LargeImageList = this.LargeImages;
            this.TodoList.Location = new System.Drawing.Point(0, 25);
            this.TodoList.Name = "TodoList";
            this.TodoList.ShowItemToolTips = true;
            this.TodoList.Size = new System.Drawing.Size(680, 315);
            this.TodoList.SmallImageList = this.SmallImages;
            this.TodoList.TabIndex = 6;
            this.TodoList.UseCompatibleStateImageBehavior = false;
            this.TodoList.View = System.Windows.Forms.View.Details;
            // 
            // NewEventName
            // 
            this.NewEventName.Text = "Event";
            this.NewEventName.Width = 120;
            // 
            // EventDescription
            // 
            this.EventDescription.Text = "Description";
            this.EventDescription.Width = 150;
            // 
            // TargetTime
            // 
            this.TargetTime.Text = "Next Occurrence";
            this.TargetTime.Width = 120;
            // 
            // EventPeriod
            // 
            this.EventPeriod.Text = "Period";
            this.EventPeriod.Width = 80;
            // 
            // RemindSomething
            // 
            this.RemindSomething.Text = "Remind Via";
            this.RemindSomething.Width = 80;
            // 
            // PopupMenuReminder
            // 
            this.PopupMenuReminder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuTodoAdd,
            this.PopupMenuTodoEdit,
            this.PopupMenuTodoHide,
            this.PopupMenuTodoUnhide,
            this.PopupMenuTodoDelete,
            this.PopupMenuTodoSep1,
            this.PopupMenuTodoView,
            this.PopupMenuTodoGroupBy});
            this.PopupMenuReminder.Name = "contextMenuStrip1";
            this.PopupMenuReminder.Size = new System.Drawing.Size(119, 164);
            // 
            // PopupMenuTodoAdd
            // 
            this.PopupMenuTodoAdd.Name = "PopupMenuTodoAdd";
            this.PopupMenuTodoAdd.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoAdd.Text = "Add...";
            // 
            // PopupMenuTodoEdit
            // 
            this.PopupMenuTodoEdit.Name = "PopupMenuTodoEdit";
            this.PopupMenuTodoEdit.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoEdit.Text = "Edit...";
            // 
            // PopupMenuTodoHide
            // 
            this.PopupMenuTodoHide.Name = "PopupMenuTodoHide";
            this.PopupMenuTodoHide.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoHide.Text = "Hide";
            // 
            // PopupMenuTodoUnhide
            // 
            this.PopupMenuTodoUnhide.Name = "PopupMenuTodoUnhide";
            this.PopupMenuTodoUnhide.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoUnhide.Text = "Unhide";
            this.PopupMenuTodoUnhide.Visible = false;
            // 
            // PopupMenuTodoDelete
            // 
            this.PopupMenuTodoDelete.Name = "PopupMenuTodoDelete";
            this.PopupMenuTodoDelete.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoDelete.Text = "Delete";
            // 
            // PopupMenuTodoSep1
            // 
            this.PopupMenuTodoSep1.Name = "PopupMenuTodoSep1";
            this.PopupMenuTodoSep1.Size = new System.Drawing.Size(115, 6);
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
            this.PopupMenuTodoViewShowGroups});
            this.PopupMenuTodoView.Name = "PopupMenuTodoView";
            this.PopupMenuTodoView.Size = new System.Drawing.Size(118, 22);
            this.PopupMenuTodoView.Text = "View";
            // 
            // PopupMenuTodoViewLargeIcons
            // 
            this.PopupMenuTodoViewLargeIcons.Name = "PopupMenuTodoViewLargeIcons";
            this.PopupMenuTodoViewLargeIcons.Size = new System.Drawing.Size(137, 22);
            this.PopupMenuTodoViewLargeIcons.Text = "Large Icons";
            // 
            // PopupMenuTodoViewSmallIcons
            // 
            this.PopupMenuTodoViewSmallIcons.Name = "PopupMenuTodoViewSmallIcons";
            this.PopupMenuTodoViewSmallIcons.Size = new System.Drawing.Size(137, 22);
            this.PopupMenuTodoViewSmallIcons.Text = "Small Icons";
            // 
            // PopupMenuTodoViewTiles
            // 
            this.PopupMenuTodoViewTiles.Name = "PopupMenuTodoViewTiles";
            this.PopupMenuTodoViewTiles.Size = new System.Drawing.Size(137, 22);
            this.PopupMenuTodoViewTiles.Text = "Tiles";
            // 
            // PopupMenuTodoViewList
            // 
            this.PopupMenuTodoViewList.Name = "PopupMenuTodoViewList";
            this.PopupMenuTodoViewList.Size = new System.Drawing.Size(137, 22);
            this.PopupMenuTodoViewList.Text = "List";
            // 
            // PopupMenuTodoViewDetails
            // 
            this.PopupMenuTodoViewDetails.Checked = true;
            this.PopupMenuTodoViewDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuTodoViewDetails.Name = "PopupMenuTodoViewDetails";
            this.PopupMenuTodoViewDetails.Size = new System.Drawing.Size(137, 22);
            this.PopupMenuTodoViewDetails.Text = "Details";
            // 
            // PopupMenuTodoViewSep1
            // 
            this.PopupMenuTodoViewSep1.Name = "PopupMenuTodoViewSep1";
            this.PopupMenuTodoViewSep1.Size = new System.Drawing.Size(134, 6);
            // 
            // PopupMenuTodoViewShowGroups
            // 
            this.PopupMenuTodoViewShowGroups.Checked = true;
            this.PopupMenuTodoViewShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuTodoViewShowGroups.Name = "PopupMenuTodoViewShowGroups";
            this.PopupMenuTodoViewShowGroups.Size = new System.Drawing.Size(137, 22);
            this.PopupMenuTodoViewShowGroups.Text = "Show Groups";
            // 
            // PopupMenuTodoGroupBy
            // 
            this.PopupMenuTodoGroupBy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuTodoGroupByStatus,
            this.PopupMenuTodoGroupByStartDate,
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
            this.PopupMenuTodoGroupByStatus.Size = new System.Drawing.Size(124, 22);
            this.PopupMenuTodoGroupByStatus.Text = "Status";
            // 
            // PopupMenuTodoGroupByStartDate
            // 
            this.PopupMenuTodoGroupByStartDate.Enabled = false;
            this.PopupMenuTodoGroupByStartDate.Name = "PopupMenuTodoGroupByStartDate";
            this.PopupMenuTodoGroupByStartDate.Size = new System.Drawing.Size(124, 22);
            this.PopupMenuTodoGroupByStartDate.Text = "Start Date";
            // 
            // PopupMenuTodoGroupByDueDate
            // 
            this.PopupMenuTodoGroupByDueDate.Enabled = false;
            this.PopupMenuTodoGroupByDueDate.Name = "PopupMenuTodoGroupByDueDate";
            this.PopupMenuTodoGroupByDueDate.Size = new System.Drawing.Size(124, 22);
            this.PopupMenuTodoGroupByDueDate.Text = "Due Date";
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
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarItemCount});
            this.StatusBar.Location = new System.Drawing.Point(0, 340);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(680, 22);
            this.StatusBar.TabIndex = 8;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusBarItemCount
            // 
            this.StatusBarItemCount.Name = "StatusBarItemCount";
            this.StatusBarItemCount.Size = new System.Drawing.Size(13, 17);
            this.StatusBarItemCount.Text = "0";
            // 
            // TodoToolbar
            // 
            this.TodoToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TodoToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTodoAction,
            this.MenuTodoShow,
            this.toolStripSeparator1,
            this.MenuTodoViewLargeIcons,
            this.MenuTodoViewSmallIcons,
            this.MenuTodoViewTiles,
            this.MenuTodoViewList,
            this.MenuTodoViewDetails,
            this.toolStripSeparator2,
            this.SendEmailButton,
            this.QuartzTestButton});
            this.TodoToolbar.Location = new System.Drawing.Point(0, 0);
            this.TodoToolbar.Name = "TodoToolbar";
            this.TodoToolbar.Size = new System.Drawing.Size(680, 25);
            this.TodoToolbar.TabIndex = 9;
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
            // 
            // MenuTodoActionAdd
            // 
            this.MenuTodoActionAdd.Name = "MenuTodoActionAdd";
            this.MenuTodoActionAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.MenuTodoActionAdd.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionAdd.Text = "Add...";
            this.MenuTodoActionAdd.Click += new System.EventHandler(this.MenuTodoActionAdd_Click);
            // 
            // MenuTodoActionEdit
            // 
            this.MenuTodoActionEdit.Name = "MenuTodoActionEdit";
            this.MenuTodoActionEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.MenuTodoActionEdit.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionEdit.Text = "Edit...";
            // 
            // MenuTodoActionHide
            // 
            this.MenuTodoActionHide.Name = "MenuTodoActionHide";
            this.MenuTodoActionHide.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionHide.Text = "Hide...";
            // 
            // MenuTodoActionUnhide
            // 
            this.MenuTodoActionUnhide.Name = "MenuTodoActionUnhide";
            this.MenuTodoActionUnhide.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionUnhide.Text = "Unhide...";
            this.MenuTodoActionUnhide.Visible = false;
            // 
            // MenuTodoActionDelete
            // 
            this.MenuTodoActionDelete.Name = "MenuTodoActionDelete";
            this.MenuTodoActionDelete.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.MenuTodoActionDelete.Size = new System.Drawing.Size(164, 22);
            this.MenuTodoActionDelete.Text = "Delete...";
            // 
            // MenuTodoShow
            // 
            this.MenuTodoShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuTodoShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuTodoShowGroups,
            this.MenuTodoShowCompletedItems});
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
            this.MenuTodoShowGroups.Size = new System.Drawing.Size(155, 22);
            this.MenuTodoShowGroups.Text = "Groups";
            // 
            // MenuTodoShowCompletedItems
            // 
            this.MenuTodoShowCompletedItems.Name = "MenuTodoShowCompletedItems";
            this.MenuTodoShowCompletedItems.Size = new System.Drawing.Size(155, 22);
            this.MenuTodoShowCompletedItems.Text = "Completed Items";
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SendEmailButton
            // 
            this.SendEmailButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SendEmailButton.Image = ((System.Drawing.Image)(resources.GetObject("SendEmailButton.Image")));
            this.SendEmailButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SendEmailButton.Name = "SendEmailButton";
            this.SendEmailButton.Size = new System.Drawing.Size(59, 22);
            this.SendEmailButton.Text = "Email Test";
            this.SendEmailButton.Click += new System.EventHandler(this.SendEmailButton_Click);
            // 
            // QuartzTestButton
            // 
            this.QuartzTestButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.QuartzTestButton.Image = ((System.Drawing.Image)(resources.GetObject("QuartzTestButton.Image")));
            this.QuartzTestButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.QuartzTestButton.Name = "QuartzTestButton";
            this.QuartzTestButton.Size = new System.Drawing.Size(68, 22);
            this.QuartzTestButton.Text = "Quartz Test";
            this.QuartzTestButton.Click += new System.EventHandler(this.QuartzTestButton_Click);
            // 
            // Reminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 362);
            this.Controls.Add(this.TodoList);
            this.Controls.Add(this.TodoToolbar);
            this.Controls.Add(this.StatusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Reminder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reminders";
            this.PopupMenuReminder.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.TodoToolbar.ResumeLayout(false);
            this.TodoToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView TodoList;
        private System.Windows.Forms.ColumnHeader NewEventName;
        private System.Windows.Forms.ColumnHeader EventDescription;
        private System.Windows.Forms.ColumnHeader TargetTime;
        private System.Windows.Forms.ColumnHeader EventPeriod;
        private System.Windows.Forms.ColumnHeader RemindSomething;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStrip TodoToolbar;
        private System.Windows.Forms.ToolStripDropDownButton MenuTodoAction;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionHide;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionUnhide;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoActionDelete;
        private System.Windows.Forms.ToolStripDropDownButton MenuTodoShow;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoShowGroups;
        private System.Windows.Forms.ToolStripMenuItem MenuTodoShowCompletedItems;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton MenuTodoViewLargeIcons;
        private System.Windows.Forms.ToolStripButton MenuTodoViewSmallIcons;
        private System.Windows.Forms.ToolStripButton MenuTodoViewTiles;
        private System.Windows.Forms.ToolStripButton MenuTodoViewList;
        private System.Windows.Forms.ToolStripButton MenuTodoViewDetails;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarItemCount;
        private System.Windows.Forms.ContextMenuStrip PopupMenuReminder;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoAdd;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoEdit;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoHide;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoUnhide;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoDelete;
        private System.Windows.Forms.ToolStripSeparator PopupMenuTodoSep1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoView;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewTiles;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewList;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewDetails;
        private System.Windows.Forms.ToolStripSeparator PopupMenuTodoViewSep1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoViewShowGroups;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupBy;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByStatus;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByStartDate;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByDueDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton SendEmailButton;
        private System.Windows.Forms.ImageList SmallImages;
        private System.Windows.Forms.ImageList LargeImages;
        private System.Windows.Forms.ToolStripButton QuartzTestButton;


    }
}