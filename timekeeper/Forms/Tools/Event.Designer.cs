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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Default", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("One Time", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("Recurring", System.Windows.Forms.HorizontalAlignment.Left);
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
            this.EventList = new System.Windows.Forms.ListView();
            this.NewEventName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EventDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TargetTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TriggerCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReminderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ScheduleId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PopupMenuEvents = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupMenuEventsAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventHide = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuEventManageGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuEventView = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventViewLargeIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventViewSmallIcons = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventViewTiles = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventViewList = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventViewDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventViewSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuEventViewShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventViewShowPastEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuEventViewShowHiddenEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupBy = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByEventGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByEventDate = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupByReminder = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuTodoGroupBySchedule = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeImages = new System.Windows.Forms.ImageList(this.components);
            this.SmallImages = new System.Windows.Forms.ImageList(this.components);
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarItemCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.TodoToolbar = new System.Windows.Forms.ToolStrip();
            this.MenuEventsAction = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuEventsActionAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsActionEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsActionHide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsActionUnhide = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsActionDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuEventsActionRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsActionSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuEventsActionManageGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsShow = new System.Windows.Forms.ToolStripDropDownButton();
            this.MenuEventsShowGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsShowPastEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsShowHiddenEvents = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuEventsSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuEventsViewLargeIcons = new System.Windows.Forms.ToolStripButton();
            this.MenuEventsViewSmallIcons = new System.Windows.Forms.ToolStripButton();
            this.MenuEventsViewTiles = new System.Windows.Forms.ToolStripButton();
            this.MenuEventsViewList = new System.Windows.Forms.ToolStripButton();
            this.MenuEventsViewDetails = new System.Windows.Forms.ToolStripButton();
            this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.PopupMenuEvents.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.TodoToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // EventList
            // 
            this.EventList.AllowColumnReorder = true;
            this.EventList.AllowDrop = true;
            this.EventList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NewEventName,
            this.EventDescription,
            this.TargetTime,
            this.TriggerCount,
            this.ReminderId,
            this.ScheduleId});
            this.EventList.ContextMenuStrip = this.PopupMenuEvents;
            this.EventList.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "Default";
            listViewGroup1.Name = "Default";
            listViewGroup2.Header = "One Time";
            listViewGroup2.Name = "OneTime";
            listViewGroup3.Header = "Recurring";
            listViewGroup3.Name = "Recurring";
            this.EventList.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3});
            this.EventList.HideSelection = false;
            listViewItem1.Group = listViewGroup2;
            listViewItem2.Group = listViewGroup3;
            listViewItem3.Group = listViewGroup2;
            listViewItem4.Group = listViewGroup2;
            this.EventList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4});
            this.EventList.LargeImageList = this.LargeImages;
            this.EventList.Location = new System.Drawing.Point(0, 25);
            this.EventList.MultiSelect = false;
            this.EventList.Name = "EventList";
            this.EventList.ShowItemToolTips = true;
            this.EventList.Size = new System.Drawing.Size(802, 436);
            this.EventList.SmallImageList = this.SmallImages;
            this.EventList.TabIndex = 6;
            this.EventList.UseCompatibleStateImageBehavior = false;
            this.EventList.View = System.Windows.Forms.View.Details;
            this.EventList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.EventList_ColumnClick);
            this.EventList.SelectedIndexChanged += new System.EventHandler(this.EventList_SelectedIndexChanged);
            this.EventList.DoubleClick += new System.EventHandler(this.EventList_DoubleClick);
            // 
            // NewEventName
            // 
            this.NewEventName.Text = "Event";
            this.NewEventName.Width = 200;
            // 
            // EventDescription
            // 
            this.EventDescription.Text = "Description";
            this.EventDescription.Width = 200;
            // 
            // TargetTime
            // 
            this.TargetTime.Text = "Next Occurrence";
            this.TargetTime.Width = 100;
            // 
            // TriggerCount
            // 
            this.TriggerCount.Text = "Fire Count";
            this.TriggerCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // ReminderId
            // 
            this.ReminderId.Text = "Reminder";
            this.ReminderId.Width = 100;
            // 
            // ScheduleId
            // 
            this.ScheduleId.Text = "Schedule";
            this.ScheduleId.Width = 100;
            // 
            // PopupMenuEvents
            // 
            this.PopupMenuEvents.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuEventsAdd,
            this.PopupMenuEventEdit,
            this.PopupMenuEventHide,
            this.PopupMenuEventUnhide,
            this.PopupMenuEventDelete,
            this.PopupMenuEventSep1,
            this.PopupMenuEventManageGroups,
            this.PopupMenuEventSep2,
            this.PopupMenuEventView,
            this.PopupMenuTodoGroupBy});
            this.PopupMenuEvents.Name = "contextMenuStrip1";
            this.PopupMenuEvents.Size = new System.Drawing.Size(162, 192);
            this.PopupMenuEvents.Opening += new System.ComponentModel.CancelEventHandler(this.PopupMenuEvents_Opening);
            // 
            // PopupMenuEventsAdd
            // 
            this.PopupMenuEventsAdd.Name = "PopupMenuEventsAdd";
            this.PopupMenuEventsAdd.Size = new System.Drawing.Size(161, 22);
            this.PopupMenuEventsAdd.Text = "Add...";
            this.PopupMenuEventsAdd.Click += new System.EventHandler(this.MenuEventsActionAdd_Click);
            // 
            // PopupMenuEventEdit
            // 
            this.PopupMenuEventEdit.Name = "PopupMenuEventEdit";
            this.PopupMenuEventEdit.Size = new System.Drawing.Size(161, 22);
            this.PopupMenuEventEdit.Text = "Edit...";
            this.PopupMenuEventEdit.Click += new System.EventHandler(this.MenuEventsActionEdit_Click);
            // 
            // PopupMenuEventHide
            // 
            this.PopupMenuEventHide.Name = "PopupMenuEventHide";
            this.PopupMenuEventHide.Size = new System.Drawing.Size(161, 22);
            this.PopupMenuEventHide.Text = "Hide";
            this.PopupMenuEventHide.Click += new System.EventHandler(this.MenuEventsActionHide_Click);
            // 
            // PopupMenuEventUnhide
            // 
            this.PopupMenuEventUnhide.Name = "PopupMenuEventUnhide";
            this.PopupMenuEventUnhide.Size = new System.Drawing.Size(161, 22);
            this.PopupMenuEventUnhide.Text = "Unhide";
            this.PopupMenuEventUnhide.Visible = false;
            this.PopupMenuEventUnhide.Click += new System.EventHandler(this.MenuEventsActionUnhide_Click);
            // 
            // PopupMenuEventDelete
            // 
            this.PopupMenuEventDelete.Name = "PopupMenuEventDelete";
            this.PopupMenuEventDelete.Size = new System.Drawing.Size(161, 22);
            this.PopupMenuEventDelete.Text = "Delete";
            this.PopupMenuEventDelete.Click += new System.EventHandler(this.MenuEventsActionDelete_Click);
            // 
            // PopupMenuEventSep1
            // 
            this.PopupMenuEventSep1.Name = "PopupMenuEventSep1";
            this.PopupMenuEventSep1.Size = new System.Drawing.Size(158, 6);
            // 
            // PopupMenuEventManageGroups
            // 
            this.PopupMenuEventManageGroups.Name = "PopupMenuEventManageGroups";
            this.PopupMenuEventManageGroups.Size = new System.Drawing.Size(161, 22);
            this.PopupMenuEventManageGroups.Text = "Manage Groups...";
            this.PopupMenuEventManageGroups.Click += new System.EventHandler(this.MenuEventsActionManageGroups_Click);
            // 
            // PopupMenuEventSep2
            // 
            this.PopupMenuEventSep2.Name = "PopupMenuEventSep2";
            this.PopupMenuEventSep2.Size = new System.Drawing.Size(158, 6);
            // 
            // PopupMenuEventView
            // 
            this.PopupMenuEventView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuEventViewLargeIcons,
            this.PopupMenuEventViewSmallIcons,
            this.PopupMenuEventViewTiles,
            this.PopupMenuEventViewList,
            this.PopupMenuEventViewDetails,
            this.PopupMenuEventViewSep1,
            this.PopupMenuEventViewShowGroups,
            this.PopupMenuEventViewShowPastEvents,
            this.PopupMenuEventViewShowHiddenEvents});
            this.PopupMenuEventView.Name = "PopupMenuEventView";
            this.PopupMenuEventView.Size = new System.Drawing.Size(161, 22);
            this.PopupMenuEventView.Text = "View";
            // 
            // PopupMenuEventViewLargeIcons
            // 
            this.PopupMenuEventViewLargeIcons.Name = "PopupMenuEventViewLargeIcons";
            this.PopupMenuEventViewLargeIcons.Size = new System.Drawing.Size(172, 22);
            this.PopupMenuEventViewLargeIcons.Text = "Large Icons";
            this.PopupMenuEventViewLargeIcons.Click += new System.EventHandler(this.MenuEventViewLargeIcons_Click);
            // 
            // PopupMenuEventViewSmallIcons
            // 
            this.PopupMenuEventViewSmallIcons.Name = "PopupMenuEventViewSmallIcons";
            this.PopupMenuEventViewSmallIcons.Size = new System.Drawing.Size(172, 22);
            this.PopupMenuEventViewSmallIcons.Text = "Small Icons";
            this.PopupMenuEventViewSmallIcons.Click += new System.EventHandler(this.MenuEventViewSmallIcons_Click);
            // 
            // PopupMenuEventViewTiles
            // 
            this.PopupMenuEventViewTiles.Name = "PopupMenuEventViewTiles";
            this.PopupMenuEventViewTiles.Size = new System.Drawing.Size(172, 22);
            this.PopupMenuEventViewTiles.Text = "Tiles";
            this.PopupMenuEventViewTiles.Click += new System.EventHandler(this.MenuEventViewTiles_Click);
            // 
            // PopupMenuEventViewList
            // 
            this.PopupMenuEventViewList.Name = "PopupMenuEventViewList";
            this.PopupMenuEventViewList.Size = new System.Drawing.Size(172, 22);
            this.PopupMenuEventViewList.Text = "List";
            this.PopupMenuEventViewList.Click += new System.EventHandler(this.MenuEventViewList_Click);
            // 
            // PopupMenuEventViewDetails
            // 
            this.PopupMenuEventViewDetails.Checked = true;
            this.PopupMenuEventViewDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuEventViewDetails.Name = "PopupMenuEventViewDetails";
            this.PopupMenuEventViewDetails.Size = new System.Drawing.Size(172, 22);
            this.PopupMenuEventViewDetails.Text = "Details";
            this.PopupMenuEventViewDetails.Click += new System.EventHandler(this.MenuEventViewDetails_Click);
            // 
            // PopupMenuEventViewSep1
            // 
            this.PopupMenuEventViewSep1.Name = "PopupMenuEventViewSep1";
            this.PopupMenuEventViewSep1.Size = new System.Drawing.Size(169, 6);
            // 
            // PopupMenuEventViewShowGroups
            // 
            this.PopupMenuEventViewShowGroups.Checked = true;
            this.PopupMenuEventViewShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuEventViewShowGroups.Name = "PopupMenuEventViewShowGroups";
            this.PopupMenuEventViewShowGroups.Size = new System.Drawing.Size(172, 22);
            this.PopupMenuEventViewShowGroups.Text = "Show Groups";
            this.PopupMenuEventViewShowGroups.Click += new System.EventHandler(this.MenuEventsShowGroups_Click);
            // 
            // PopupMenuEventViewShowPastEvents
            // 
            this.PopupMenuEventViewShowPastEvents.Checked = true;
            this.PopupMenuEventViewShowPastEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuEventViewShowPastEvents.Name = "PopupMenuEventViewShowPastEvents";
            this.PopupMenuEventViewShowPastEvents.Size = new System.Drawing.Size(172, 22);
            this.PopupMenuEventViewShowPastEvents.Text = "Show Past Events";
            this.PopupMenuEventViewShowPastEvents.Click += new System.EventHandler(this.MenuEventsShowPastEvents_Click);
            // 
            // PopupMenuEventViewShowHiddenEvents
            // 
            this.PopupMenuEventViewShowHiddenEvents.Name = "PopupMenuEventViewShowHiddenEvents";
            this.PopupMenuEventViewShowHiddenEvents.Size = new System.Drawing.Size(172, 22);
            this.PopupMenuEventViewShowHiddenEvents.Text = "Show Hidden Events";
            this.PopupMenuEventViewShowHiddenEvents.Click += new System.EventHandler(this.MenuEventsShowHiddenEvents_Click);
            // 
            // PopupMenuTodoGroupBy
            // 
            this.PopupMenuTodoGroupBy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuTodoGroupByEventGroup,
            this.PopupMenuTodoGroupByEventDate,
            this.PopupMenuTodoGroupByReminder,
            this.PopupMenuTodoGroupBySchedule});
            this.PopupMenuTodoGroupBy.Name = "PopupMenuTodoGroupBy";
            this.PopupMenuTodoGroupBy.Size = new System.Drawing.Size(161, 22);
            this.PopupMenuTodoGroupBy.Text = "Group By";
            // 
            // PopupMenuTodoGroupByEventGroup
            // 
            this.PopupMenuTodoGroupByEventGroup.Checked = true;
            this.PopupMenuTodoGroupByEventGroup.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PopupMenuTodoGroupByEventGroup.Name = "PopupMenuTodoGroupByEventGroup";
            this.PopupMenuTodoGroupByEventGroup.Size = new System.Drawing.Size(134, 22);
            this.PopupMenuTodoGroupByEventGroup.Text = "Event Group";
            // 
            // PopupMenuTodoGroupByEventDate
            // 
            this.PopupMenuTodoGroupByEventDate.Enabled = false;
            this.PopupMenuTodoGroupByEventDate.Name = "PopupMenuTodoGroupByEventDate";
            this.PopupMenuTodoGroupByEventDate.Size = new System.Drawing.Size(134, 22);
            this.PopupMenuTodoGroupByEventDate.Text = "Event Date";
            // 
            // PopupMenuTodoGroupByReminder
            // 
            this.PopupMenuTodoGroupByReminder.Enabled = false;
            this.PopupMenuTodoGroupByReminder.Name = "PopupMenuTodoGroupByReminder";
            this.PopupMenuTodoGroupByReminder.Size = new System.Drawing.Size(134, 22);
            this.PopupMenuTodoGroupByReminder.Text = "Reminder";
            // 
            // PopupMenuTodoGroupBySchedule
            // 
            this.PopupMenuTodoGroupBySchedule.Enabled = false;
            this.PopupMenuTodoGroupBySchedule.Name = "PopupMenuTodoGroupBySchedule";
            this.PopupMenuTodoGroupBySchedule.Size = new System.Drawing.Size(134, 22);
            this.PopupMenuTodoGroupBySchedule.Text = "Schedule";
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
            this.StatusBar.Location = new System.Drawing.Point(0, 461);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(802, 22);
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
            this.MenuEventsAction,
            this.MenuEventsShow,
            this.MenuEventsSep1,
            this.MenuEventsViewLargeIcons,
            this.MenuEventsViewSmallIcons,
            this.MenuEventsViewTiles,
            this.MenuEventsViewList,
            this.MenuEventsViewDetails});
            this.TodoToolbar.Location = new System.Drawing.Point(0, 0);
            this.TodoToolbar.Name = "TodoToolbar";
            this.TodoToolbar.Size = new System.Drawing.Size(802, 25);
            this.TodoToolbar.TabIndex = 9;
            this.TodoToolbar.Text = "toolStrip1";
            // 
            // MenuEventsAction
            // 
            this.MenuEventsAction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuEventsAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEventsActionAdd,
            this.MenuEventsActionEdit,
            this.MenuEventsActionHide,
            this.MenuEventsActionUnhide,
            this.MenuEventsActionDelete,
            this.toolStripMenuItem1,
            this.MenuEventsActionRefresh,
            this.MenuEventsActionSep2,
            this.MenuEventsActionManageGroups});
            this.MenuEventsAction.Image = ((System.Drawing.Image)(resources.GetObject("MenuEventsAction.Image")));
            this.MenuEventsAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEventsAction.Name = "MenuEventsAction";
            this.MenuEventsAction.Size = new System.Drawing.Size(50, 22);
            this.MenuEventsAction.Text = "Action";
            // 
            // MenuEventsActionAdd
            // 
            this.MenuEventsActionAdd.Name = "MenuEventsActionAdd";
            this.MenuEventsActionAdd.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Insert)));
            this.MenuEventsActionAdd.Size = new System.Drawing.Size(161, 22);
            this.MenuEventsActionAdd.Text = "Add...";
            this.MenuEventsActionAdd.Click += new System.EventHandler(this.MenuEventsActionAdd_Click);
            // 
            // MenuEventsActionEdit
            // 
            this.MenuEventsActionEdit.Name = "MenuEventsActionEdit";
            this.MenuEventsActionEdit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.MenuEventsActionEdit.Size = new System.Drawing.Size(161, 22);
            this.MenuEventsActionEdit.Text = "Edit...";
            this.MenuEventsActionEdit.Click += new System.EventHandler(this.MenuEventsActionEdit_Click);
            // 
            // MenuEventsActionHide
            // 
            this.MenuEventsActionHide.Name = "MenuEventsActionHide";
            this.MenuEventsActionHide.Size = new System.Drawing.Size(161, 22);
            this.MenuEventsActionHide.Text = "Hide...";
            this.MenuEventsActionHide.Click += new System.EventHandler(this.MenuEventsActionHide_Click);
            // 
            // MenuEventsActionUnhide
            // 
            this.MenuEventsActionUnhide.Name = "MenuEventsActionUnhide";
            this.MenuEventsActionUnhide.Size = new System.Drawing.Size(161, 22);
            this.MenuEventsActionUnhide.Text = "Unhide...";
            this.MenuEventsActionUnhide.Visible = false;
            this.MenuEventsActionUnhide.Click += new System.EventHandler(this.MenuEventsActionUnhide_Click);
            // 
            // MenuEventsActionDelete
            // 
            this.MenuEventsActionDelete.Name = "MenuEventsActionDelete";
            this.MenuEventsActionDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.MenuEventsActionDelete.Size = new System.Drawing.Size(161, 22);
            this.MenuEventsActionDelete.Text = "Delete...";
            this.MenuEventsActionDelete.Click += new System.EventHandler(this.MenuEventsActionDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // MenuEventsActionRefresh
            // 
            this.MenuEventsActionRefresh.Name = "MenuEventsActionRefresh";
            this.MenuEventsActionRefresh.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MenuEventsActionRefresh.Size = new System.Drawing.Size(161, 22);
            this.MenuEventsActionRefresh.Text = "Refresh";
            this.MenuEventsActionRefresh.Click += new System.EventHandler(this.MenuEventsActionRefresh_Click);
            // 
            // MenuEventsActionSep2
            // 
            this.MenuEventsActionSep2.Name = "MenuEventsActionSep2";
            this.MenuEventsActionSep2.Size = new System.Drawing.Size(158, 6);
            // 
            // MenuEventsActionManageGroups
            // 
            this.MenuEventsActionManageGroups.Name = "MenuEventsActionManageGroups";
            this.MenuEventsActionManageGroups.Size = new System.Drawing.Size(161, 22);
            this.MenuEventsActionManageGroups.Text = "Manage Groups...";
            this.MenuEventsActionManageGroups.Click += new System.EventHandler(this.MenuEventsActionManageGroups_Click);
            // 
            // MenuEventsShow
            // 
            this.MenuEventsShow.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.MenuEventsShow.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuEventsShowGroups,
            this.MenuEventsShowPastEvents,
            this.MenuEventsShowHiddenEvents});
            this.MenuEventsShow.Image = ((System.Drawing.Image)(resources.GetObject("MenuEventsShow.Image")));
            this.MenuEventsShow.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEventsShow.Name = "MenuEventsShow";
            this.MenuEventsShow.Size = new System.Drawing.Size(46, 22);
            this.MenuEventsShow.Text = "Show";
            // 
            // MenuEventsShowGroups
            // 
            this.MenuEventsShowGroups.Checked = true;
            this.MenuEventsShowGroups.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuEventsShowGroups.Name = "MenuEventsShowGroups";
            this.MenuEventsShowGroups.Size = new System.Drawing.Size(143, 22);
            this.MenuEventsShowGroups.Text = "Groups";
            this.MenuEventsShowGroups.Click += new System.EventHandler(this.MenuEventsShowGroups_Click);
            // 
            // MenuEventsShowPastEvents
            // 
            this.MenuEventsShowPastEvents.Checked = true;
            this.MenuEventsShowPastEvents.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuEventsShowPastEvents.Name = "MenuEventsShowPastEvents";
            this.MenuEventsShowPastEvents.Size = new System.Drawing.Size(143, 22);
            this.MenuEventsShowPastEvents.Text = "Past Events";
            this.MenuEventsShowPastEvents.Click += new System.EventHandler(this.MenuEventsShowPastEvents_Click);
            // 
            // MenuEventsShowHiddenEvents
            // 
            this.MenuEventsShowHiddenEvents.Name = "MenuEventsShowHiddenEvents";
            this.MenuEventsShowHiddenEvents.Size = new System.Drawing.Size(143, 22);
            this.MenuEventsShowHiddenEvents.Text = "Hidden Events";
            this.MenuEventsShowHiddenEvents.Click += new System.EventHandler(this.MenuEventsShowHiddenEvents_Click);
            // 
            // MenuEventsSep1
            // 
            this.MenuEventsSep1.Name = "MenuEventsSep1";
            this.MenuEventsSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // MenuEventsViewLargeIcons
            // 
            this.MenuEventsViewLargeIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuEventsViewLargeIcons.Image = global::Timekeeper.Properties.Resources.ImageButtonViewLarge;
            this.MenuEventsViewLargeIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEventsViewLargeIcons.Name = "MenuEventsViewLargeIcons";
            this.MenuEventsViewLargeIcons.Size = new System.Drawing.Size(23, 22);
            this.MenuEventsViewLargeIcons.Text = "View Large Icons";
            this.MenuEventsViewLargeIcons.Click += new System.EventHandler(this.MenuEventViewLargeIcons_Click);
            // 
            // MenuEventsViewSmallIcons
            // 
            this.MenuEventsViewSmallIcons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuEventsViewSmallIcons.Image = global::Timekeeper.Properties.Resources.ImageButtonViewSmall;
            this.MenuEventsViewSmallIcons.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEventsViewSmallIcons.Name = "MenuEventsViewSmallIcons";
            this.MenuEventsViewSmallIcons.Size = new System.Drawing.Size(23, 22);
            this.MenuEventsViewSmallIcons.Text = "View Small Icons";
            this.MenuEventsViewSmallIcons.Click += new System.EventHandler(this.MenuEventViewSmallIcons_Click);
            // 
            // MenuEventsViewTiles
            // 
            this.MenuEventsViewTiles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuEventsViewTiles.Image = global::Timekeeper.Properties.Resources.ImageButtonViewTiles;
            this.MenuEventsViewTiles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEventsViewTiles.Name = "MenuEventsViewTiles";
            this.MenuEventsViewTiles.Size = new System.Drawing.Size(23, 22);
            this.MenuEventsViewTiles.Text = "View Tiles";
            this.MenuEventsViewTiles.Click += new System.EventHandler(this.MenuEventViewTiles_Click);
            // 
            // MenuEventsViewList
            // 
            this.MenuEventsViewList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuEventsViewList.Image = global::Timekeeper.Properties.Resources.ImageButtonViewList;
            this.MenuEventsViewList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEventsViewList.Name = "MenuEventsViewList";
            this.MenuEventsViewList.Size = new System.Drawing.Size(23, 22);
            this.MenuEventsViewList.Text = "View List";
            this.MenuEventsViewList.Click += new System.EventHandler(this.MenuEventViewList_Click);
            // 
            // MenuEventsViewDetails
            // 
            this.MenuEventsViewDetails.Checked = true;
            this.MenuEventsViewDetails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuEventsViewDetails.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MenuEventsViewDetails.Image = global::Timekeeper.Properties.Resources.ImageButtonViewDetails;
            this.MenuEventsViewDetails.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MenuEventsViewDetails.Name = "MenuEventsViewDetails";
            this.MenuEventsViewDetails.Size = new System.Drawing.Size(23, 22);
            this.MenuEventsViewDetails.Text = "View Details";
            this.MenuEventsViewDetails.Click += new System.EventHandler(this.MenuEventViewDetails_Click);
            // 
            // RefreshTimer
            // 
            this.RefreshTimer.Enabled = true;
            this.RefreshTimer.Interval = 5000;
            this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
            // 
            // Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 483);
            this.Controls.Add(this.EventList);
            this.Controls.Add(this.TodoToolbar);
            this.Controls.Add(this.StatusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Event";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Events";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Event_FormClosing);
            this.Load += new System.EventHandler(this.Event_Load);
            this.PopupMenuEvents.ResumeLayout(false);
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.TodoToolbar.ResumeLayout(false);
            this.TodoToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView EventList;
        private System.Windows.Forms.ColumnHeader NewEventName;
        private System.Windows.Forms.ColumnHeader EventDescription;
        private System.Windows.Forms.ColumnHeader TargetTime;
        private System.Windows.Forms.ColumnHeader ReminderId;
        private System.Windows.Forms.ColumnHeader ScheduleId;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStrip TodoToolbar;
        private System.Windows.Forms.ToolStripDropDownButton MenuEventsAction;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsActionAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsActionEdit;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsActionHide;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsActionUnhide;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsActionDelete;
        private System.Windows.Forms.ToolStripDropDownButton MenuEventsShow;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsShowGroups;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsShowHiddenEvents;
        private System.Windows.Forms.ToolStripSeparator MenuEventsSep1;
        private System.Windows.Forms.ToolStripButton MenuEventsViewLargeIcons;
        private System.Windows.Forms.ToolStripButton MenuEventsViewSmallIcons;
        private System.Windows.Forms.ToolStripButton MenuEventsViewTiles;
        private System.Windows.Forms.ToolStripButton MenuEventsViewList;
        private System.Windows.Forms.ToolStripButton MenuEventsViewDetails;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarItemCount;
        private System.Windows.Forms.ContextMenuStrip PopupMenuEvents;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventsAdd;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventEdit;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventHide;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventUnhide;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventDelete;
        private System.Windows.Forms.ToolStripSeparator PopupMenuEventSep2;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventView;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventViewLargeIcons;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventViewSmallIcons;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventViewTiles;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventViewList;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventViewDetails;
        private System.Windows.Forms.ToolStripSeparator PopupMenuEventViewSep1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventViewShowGroups;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupBy;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByEventGroup;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByEventDate;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupByReminder;
        private System.Windows.Forms.ImageList SmallImages;
        private System.Windows.Forms.ImageList LargeImages;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventViewShowHiddenEvents;
        private System.Windows.Forms.ToolStripSeparator PopupMenuEventSep1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventManageGroups;
        private System.Windows.Forms.ToolStripSeparator MenuEventsActionSep2;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsActionManageGroups;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuTodoGroupBySchedule;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsActionRefresh;
        private System.Windows.Forms.Timer RefreshTimer;
        private System.Windows.Forms.ColumnHeader TriggerCount;
        private System.Windows.Forms.ToolStripMenuItem MenuEventsShowPastEvents;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuEventViewShowPastEvents;


    }
}