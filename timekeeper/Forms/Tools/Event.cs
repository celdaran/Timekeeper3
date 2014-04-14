using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;
// FIXME: I shouldn't need these here
using Quartz;
using Quartz.Impl;

namespace Timekeeper.Forms.Tools
{
    public partial class Event : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;
        private ListViewColumnSorter ColumnSorter;

        private DateTime LastAutoRefreshTime;

        private Forms.Main MainForm;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Event(Forms.Main mainForm)
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;
            this.MainForm = mainForm;

            ColumnSorter = new ListViewColumnSorter();
            this.EventList.ListViewItemSorter = ColumnSorter;
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Event_Load(object sender, EventArgs e)
        {
            try {
                RestoreWindowMetrics();
                PopulateEventList();
                ShowGroups(Options.Event_ShowGroups);
                //ShowCompletedItems(Options.Todo_ShowCompletedItems);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void EventList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 0) {
                ListViewItem SelectedItem = (ListViewItem)EventList.SelectedItems[0];
                Classes.Event SelectedEvent = (Classes.Event)SelectedItem.Tag;

                MenuEventsActionHide.Visible = !SelectedEvent.IsHidden;
                MenuEventsActionUnhide.Visible = SelectedEvent.IsHidden;

                PopupMenuEventHide.Visible = MenuEventsActionHide.Visible;
                PopupMenuEventHide.Visible = MenuEventsActionUnhide.Visible;
            }
        }

        //----------------------------------------------------------------------

        private void PopupMenuEvents_Opening(object sender, CancelEventArgs e)
        {
            if (EventList.SelectedItems.Count == 0) {
                PopupMenuEventEdit.Visible = false;
                PopupMenuEventDelete.Visible = false;
                PopupMenuEventHide.Visible = false;
                PopupMenuEventHide.Visible = false;
                PopupMenuEventUnhide.Visible = false;
                return;
            } else {
                PopupMenuEventEdit.Visible = true;
                PopupMenuEventDelete.Visible = true;
            }

            ListViewItem SelectedItem = EventList.SelectedItems[0];
            Classes.Event SelectedEvent = (Classes.Event)SelectedItem.Tag;

            if (SelectedEvent.IsHidden) {
                PopupMenuEventHide.Visible = false;
                PopupMenuEventUnhide.Visible = true;
            } else {
                PopupMenuEventHide.Visible = true;
                PopupMenuEventUnhide.Visible = false;
            }

        }

        //----------------------------------------------------------------------
        // Please To Organize These
        //----------------------------------------------------------------------

        private void RestoreWindowMetrics()
        {
            this.Height = Options.Event_Height;
            this.Width = Options.Event_Width;
            this.Left = Options.Event_Left;
            this.Top = Options.Event_Top;

            MenuEventsShowGroups.Checked = Options.Event_ShowGroups;
            PopupMenuEventViewShowGroups.Checked = Options.Event_ShowGroups;

            MenuEventsShowPastEvents.Checked = Options.Event_ShowPastEvents;
            PopupMenuEventViewShowPastEvents.Checked = Options.Event_ShowPastEvents;

            MenuEventsShowHiddenEvents.Checked = Options.Event_ShowHiddenEvents;
            PopupMenuEventViewShowHiddenEvents.Checked = Options.Event_ShowHiddenEvents;

            switch (Options.Event_IconView) {
                case 1: ViewLargeIcons(); break;
                case 2: ViewSmallIcons(); break;
                case 3: ViewTiles(); break;
                case 4: ViewList(); break;
                default: ViewDetails(); break;
            }

            EventList.Columns[0].Width = Options.Event_NameWidth;
            EventList.Columns[1].Width = Options.Event_DescriptionWidth;
            EventList.Columns[2].Width = Options.Event_NextOccurrenceTimeWidth;
            EventList.Columns[3].Width = Options.Event_TriggerCountWidth;
            EventList.Columns[4].Width = Options.Event_ReminderWidth;
            EventList.Columns[5].Width = Options.Event_ScheduleWidth;

            EventList.Columns[0].DisplayIndex = Options.Event_NameDisplayIndex;
            EventList.Columns[1].DisplayIndex = Options.Event_DescriptionDisplayIndex;
            EventList.Columns[2].DisplayIndex = Options.Event_NextOccurrenceTimeDisplayIndex;
            EventList.Columns[3].DisplayIndex = Options.Event_TriggerCountDisplayIndex;
            EventList.Columns[4].DisplayIndex = Options.Event_ReminderDisplayIndex;
            EventList.Columns[5].DisplayIndex = Options.Event_ScheduleDisplayIndex;
        }

        //----------------------------------------------------------------------

        private void PopulateEventList()
        {
            // Populate Groups
            CreateGroups();

            // Populate items
            EventList.Items.Clear();
            Classes.EventCollection Collection = new Classes.EventCollection();
            List<Classes.Event> Items = Collection.Fetch();

            foreach (Classes.Event Event in Items) {
                this.AddItem(Event, EventList.Groups[Event.Group.Name]);
            }

            StatusBarItemCount.Text = EventList.Items.Count + " item(s)";
        }

        //----------------------------------------------------------------------

        private void RefreshEventList()
        {
            foreach (ListViewItem Item in EventList.Items) {
                RefreshEvent(Item, (Classes.Event)Item.Tag);
            }

            StatusBarItemCount.Text = EventList.Items.Count + " item(s)";
        }

        //----------------------------------------------------------------------

        private void RefreshEvent(ListViewItem item, Classes.Event selectedEvent)
        {
            // Reinstantiate, to pick up any changes in the database
            Classes.Event Event = new Classes.Event(selectedEvent.Id);
            // Update UI with updated Event info
            this.UpdateItem(item, Event, EventList.Groups[Event.Group.Name]);
        }

        //----------------------------------------------------------------------

        private void CreateGroups()
        {
            ListViewGroup Group;
            EventList.Groups.Clear();

            // Get status values

            Classes.EventGroup EventGroup = new Classes.EventGroup();

            // Now create a group for each one
            foreach (Row EventGroupRow in EventGroup.Table()) {
                Group = new ListViewGroup(EventGroupRow["Name"], EventGroupRow["Name"]);
                EventList.Groups.Add(Group);
            }

        }

        //----------------------------------------------------------------------

        private void EventList_DoubleClick(object sender, EventArgs e)
        {
            EditItem();
        }

        //----------------------------------------------------------------------

        public void AddItem(Classes.Event currentEvent, ListViewGroup group)
        {
            try {
                if ((currentEvent.NextOccurrenceTime.CompareTo(DateTime.Now) < 0) && !MenuEventsShowPastEvents.Checked) {
                    // Don't add past items if we're hiding past items
                    return;
                }

                if (currentEvent.IsHidden && !MenuEventsShowHiddenEvents.Checked) {
                    // Don't add hidden items if we're hiding hidden items
                    return;
                }

                ListViewItem NewItem = new ListViewItem(currentEvent.Name, group);

                NewItem.Tag = currentEvent;
                NewItem.ImageIndex = 0;
                NewItem.ToolTipText = currentEvent.Description;

                if (currentEvent.NextOccurrenceTime.CompareTo(DateTime.Now) < 0) {
                    NewItem.ForeColor = Color.Red;
                }

                if (currentEvent.IsHidden) {
                    NewItem.ForeColor = Color.Gray;
                    NewItem.ImageIndex = 1;
                }

                // columns: Event, Description, Next Occurence, etc.

                NewItem.SubItems.Add(currentEvent.Description);
                NewItem.SubItems.Add(currentEvent.NextOccurrenceTime.ToString(Common.LOCAL_DATETIME_FORMAT));

                string TriggerCountText = currentEvent.Schedule == null ? "" : currentEvent.Schedule.TriggerCount.ToString();
                string ReminderText = currentEvent.Reminder == null ? "" : currentEvent.Reminder.ToString();
                string ScheduleText = currentEvent.Schedule == null ? "" : currentEvent.Schedule.ToString();

                NewItem.SubItems.Add(TriggerCountText);
                NewItem.SubItems.Add(ReminderText);
                NewItem.SubItems.Add(ScheduleText);

                EventList.Items.Add(NewItem);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void UpdateItem(ListViewItem item, Classes.Event currentEvent, ListViewGroup group)
        {
            try {
                if ((currentEvent.NextOccurrenceTime.CompareTo(DateTime.Now) < 0) && !MenuEventsShowPastEvents.Checked) {
                    // If we're updating an item, and it's since expired, remove it
                    // as long as the user has also decided to hide past items.
                    EventList.Items.Remove(item);
                    return;
                }

                if (currentEvent.IsHidden && !MenuEventsShowHiddenEvents.Checked) {
                    // If we're updating an item, and it's since become hidden, remove it
                    // as long as the user has also decided to hide hidden items.
                    EventList.Items.Remove(item);
                    return;
                }

                if (currentEvent.IsDeleted) {
                    // Never show deleted items. Remove from list if deleted after list populated
                    EventList.Items.Remove(item);
                    return;
                }

                // Update stuff
                item.Tag = currentEvent;
                item.ImageIndex = 0;
                item.ToolTipText = currentEvent.Description;
                item.Group = group;

                if (currentEvent.NextOccurrenceTime.CompareTo(DateTime.Now) < 0) {
                    item.ForeColor = Color.Red;
                }

                if (currentEvent.IsHidden) {
                    item.ForeColor = Color.Gray;
                    item.ImageIndex = 1;
                }

                // Change column text
                ListViewItem.ListViewSubItem i;
                i = item.SubItems[0]; i.Text = currentEvent.Name;
                i = item.SubItems[1]; i.Text = currentEvent.Description;
                i = item.SubItems[2]; i.Text = currentEvent.NextOccurrenceTime.ToString(Common.LOCAL_DATETIME_FORMAT);

                // yeah, copy/pasted from above
                string TriggerCountText = currentEvent.Schedule == null ? "" : currentEvent.Schedule.TriggerCount.ToString();
                string ReminderText = currentEvent.Reminder == null ? "" : currentEvent.Reminder.ToString();
                string ScheduleText = currentEvent.Schedule == null ? "" : currentEvent.Schedule.ToString();

                i = item.SubItems[3]; i.Text = TriggerCountText;
                i = item.SubItems[4]; i.Text = ReminderText;
                i = item.SubItems[5]; i.Text = ScheduleText;

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // Menu and Toolbar Events
        //----------------------------------------------------------------------

        private void MenuEventsActionAdd_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void MenuEventsActionEdit_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 1) {
                Common.Warn("Cannot edit multiple items");
            } else {
                EditItem();
            }
        }

        private Classes.Event GetCurrentEvent()
        {
            if (EventList.SelectedItems.Count > 0) {
                ListViewItem SelectedItem = (ListViewItem)EventList.SelectedItems[0];
                Classes.Event SelectedEvent = (Classes.Event)SelectedItem.Tag;
                return SelectedEvent;
            } else {
                return null;
            }
        }

        private void MenuEventsActionHide_Click(object sender, EventArgs e)
        {
            Classes.Event SelectedEvent = GetCurrentEvent();
            if (SelectedEvent != null) {
                SelectedEvent.IsHidden = true;
                // TODO: (NOTE TO SELF: Application always deals with Local Time; Database Layer takes care of Local Time -> UTC handling)
                // Just marking that here since that's when it became apparent to me.
                // Also, highly related, things like this should be SelectedEvent.Hide(), and not exposing these weaknesses to the app.
                SelectedEvent.HiddenTime = DateTime.Now;
                SelectedEvent.Save();
                RefreshEvent((ListViewItem)EventList.SelectedItems[0], SelectedEvent);
            }
        }

        private void MenuEventsActionUnhide_Click(object sender, EventArgs e)
        {
            Classes.Event SelectedEvent = GetCurrentEvent();
            if (SelectedEvent != null) {
                SelectedEvent.IsHidden = false;
                SelectedEvent.Save();
                RefreshEvent((ListViewItem)EventList.SelectedItems[0], SelectedEvent);
            }
        }

        private void MenuEventsActionDelete_Click(object sender, EventArgs e)
        {
            Classes.Event SelectedEvent = GetCurrentEvent();
            if (SelectedEvent != null) {
                SelectedEvent.IsDeleted = true;
                SelectedEvent.DeletedTime = DateTime.Now;
                SelectedEvent.Save();
                RefreshEvent((ListViewItem)EventList.SelectedItems[0], SelectedEvent);
            }
        }

        private void MenuEventsActionRefresh_Click(object sender, EventArgs e)
        {
            RefreshEventList();
        }

        private void MenuEventsActionManageGroups_Click(object sender, EventArgs e)
        {
            Forms.Tools.ManageEventGroups DialogBox = new Forms.Tools.ManageEventGroups();
            DialogBox.ShowDialog(this);
            // FIXME: need to do this conditionally
            PopulateEventList();
        }

        private void MenuEventViewLargeIcons_Click(object sender, EventArgs e)
        {
            ViewLargeIcons();
        }

        private void MenuEventViewSmallIcons_Click(object sender, EventArgs e)
        {
            ViewSmallIcons();
        }

        private void MenuEventViewTiles_Click(object sender, EventArgs e)
        {
            ViewTiles();
        }

        private void MenuEventViewList_Click(object sender, EventArgs e)
        {
            ViewList();
        }

        private void MenuEventViewDetails_Click(object sender, EventArgs e)
        {
            ViewDetails();
        }

        private void MenuEventsShowGroups_Click(object sender, EventArgs e)
        {
            ToggleGroups();
        }

        private void MenuEventsShowPastEvents_Click(object sender, EventArgs e)
        {
            MenuEventsShowPastEvents.Checked = !MenuEventsShowPastEvents.Checked;
            PopupMenuEventViewShowPastEvents.Checked = !PopupMenuEventViewShowPastEvents.Checked;
            PopulateEventList();
        }

        private void MenuEventsShowHiddenEvents_Click(object sender, EventArgs e)
        {
            MenuEventsShowHiddenEvents.Checked = !MenuEventsShowHiddenEvents.Checked;
            PopupMenuEventViewShowHiddenEvents.Checked = !PopupMenuEventViewShowHiddenEvents.Checked;
            PopulateEventList();
        }

        private void ToggleGroups()
        {
            ShowGroups(!EventList.ShowGroups);
            Options.Event_ShowGroups = EventList.ShowGroups;
        }

        private void ShowGroups(bool showGroups)
        {
            EventList.ShowGroups = showGroups;
            MenuEventsShowGroups.Checked = EventList.ShowGroups;
            PopupMenuEventViewShowGroups.Checked = EventList.ShowGroups;
        }

        //----------------------------------------------------------------------
        // FIXME: Horrible Amounts of Copy/Paste From Todo
        //----------------------------------------------------------------------

        private void ViewLargeIcons()
        {
            EventList.View = View.LargeIcon;

            PopupMenuEventViewLargeIcons.Checked = true;
            PopupMenuEventViewSmallIcons.Checked = false;
            PopupMenuEventViewTiles.Checked = false;
            PopupMenuEventViewList.Checked = false;
            PopupMenuEventViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewSmallIcons()
        {
            EventList.View = View.SmallIcon;

            PopupMenuEventViewLargeIcons.Checked = false;
            PopupMenuEventViewSmallIcons.Checked = true;
            PopupMenuEventViewTiles.Checked = false;
            PopupMenuEventViewList.Checked = false;
            PopupMenuEventViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewTiles()
        {
            EventList.View = View.Tile;

            PopupMenuEventViewLargeIcons.Checked = false;
            PopupMenuEventViewSmallIcons.Checked = false;
            PopupMenuEventViewTiles.Checked = true;
            PopupMenuEventViewList.Checked = false;
            PopupMenuEventViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewList()
        {
            EventList.View = View.List;

            PopupMenuEventViewLargeIcons.Checked = false;
            PopupMenuEventViewSmallIcons.Checked = false;
            PopupMenuEventViewTiles.Checked = false;
            PopupMenuEventViewList.Checked = true;
            PopupMenuEventViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewDetails()
        {
            EventList.View = View.Details;

            PopupMenuEventViewLargeIcons.Checked = false;
            PopupMenuEventViewSmallIcons.Checked = false;
            PopupMenuEventViewTiles.Checked = false;
            PopupMenuEventViewList.Checked = false;
            PopupMenuEventViewDetails.Checked = true;

            MirrorViewChecks();
        }

        private void MirrorViewChecks()
        {
            MenuEventsViewLargeIcons.Checked = PopupMenuEventViewLargeIcons.Checked;
            MenuEventsViewSmallIcons.Checked = PopupMenuEventViewSmallIcons.Checked;
            MenuEventsViewTiles.Checked = PopupMenuEventViewTiles.Checked;
            MenuEventsViewList.Checked = PopupMenuEventViewList.Checked;
            MenuEventsViewDetails.Checked = PopupMenuEventViewDetails.Checked;
        }

        //----------------------------------------------------------------------
        // Timer Event
        //----------------------------------------------------------------------

        private void RefreshTimer_Tick(object sender, EventArgs e)
        {
            /*
            Common.Info("Here it comes");
            NotifyIcon NotifyIcon = new NotifyIcon();
            NotifyIcon.Visible = true;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            NotifyIcon.ShowBalloonTip(30000,
                Timekeeper.TITLE,
                "Works with a form, don't it!",
                ToolTipIcon.Info);
            */

            // First time through, just seed the value
            if (LastAutoRefreshTime == DateTime.MinValue) {
                LastAutoRefreshTime = DateTime.Now;
                return;
            }

            Classes.ScheduledEventCollection AllEvents = new Classes.ScheduledEventCollection();
            DateTime MostRecentModification = AllEvents.MostRecentModification();

            if (MostRecentModification.CompareTo(LastAutoRefreshTime) > 0) {
                PopulateEventList();
                LastAutoRefreshTime = DateTime.Now;
                StatusBarItemCount.Text = EventList.Items.Count + " item(s), refreshed at " + Common.Now();
            }
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private void AddItem()
        {
            Forms.Tools.EventDetail DialogBox = new Forms.Tools.EventDetail();
            if (DialogBox.ShowDialog(this) == DialogResult.OK)
            {
                Classes.Event Event = DialogBox.CurrentEvent;

                // Save is an upsert function
                if (Event.Save()) {
                    // Add the item to the UI
                    this.AddItem(Event, EventList.Groups[Event.Group.Name]);

                    // Then actually do something about it
                    Classes.ScheduledEvent ScheduledEvent = new Classes.ScheduledEvent(Event.Id);
                    Timekeeper.Schedule(ScheduledEvent, this.MainForm);
                } else {
                    Common.Warn("There was an error creating the event");
                }
            }
        }

        //----------------------------------------------------------------------

        private void EditItem()
        {
            long EventId = GetSelectedId();

            if (EventId == 0) {
                return;
            }

            ListViewItem SelectedItem = EventList.SelectedItems[0];

            Forms.Tools.EventDetail DialogBox = new Forms.Tools.EventDetail(EventId);
            if (DialogBox.ShowDialog(this) == DialogResult.OK)
            {
                Classes.Event Event = DialogBox.CurrentEvent;

                // Save is an upsert function
                if (Event.Save()) {
                    // Update UI
                    this.UpdateItem(SelectedItem, Event, EventList.Groups[Event.Group.Name]);

                    // Unschedule the old job
                    JobKey Key = new JobKey(EventId.ToString(), "Timekeeper");
                    Timekeeper.Scheduler.DeleteJob(Key);

                    string Debug =
                        "Deleted Job \"" + Key.ToString() + "\"";
                    Timekeeper.Debug(Debug);

                    // Reinstantiate a Scheduled Event
                    Classes.ScheduledEvent ScheduledEvent = new Classes.ScheduledEvent(EventId);

                    // Schedule a replacement
                    Timekeeper.Schedule(ScheduledEvent, this.MainForm);
                } else {
                    Common.Warn("There was an error updating the event");
                }
            }
        }

        //----------------------------------------------------------------------

        private long GetSelectedId()
        {
            if (EventList.SelectedItems.Count > 0) {
                Classes.Event Event = (Classes.Event)EventList.SelectedItems[0].Tag;
                return Event.Id;
            } else {
                return 0;
            }
        }

        //----------------------------------------------------------------------
        // Experimental Area
        //----------------------------------------------------------------------

        private void Event_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                Options.Event_Height = Height;
                Options.Event_Width = Width;
                Options.Event_Top = Top;
                Options.Event_Left = Left;

                Options.Event_ShowGroups = EventList.ShowGroups;
                Options.Event_ShowPastEvents = MenuEventsShowPastEvents.Checked;
                Options.Event_ShowHiddenEvents = MenuEventsShowHiddenEvents.Checked;

                Options.Todo_IconView =
                    PopupMenuEventViewLargeIcons.Checked ? 1 :
                    PopupMenuEventViewSmallIcons.Checked ? 2 :
                    PopupMenuEventViewTiles.Checked ? 3 :
                    PopupMenuEventViewList.Checked ? 4 : 5;

                Options.Event_NameWidth = EventList.Columns[0].Width;
                Options.Event_DescriptionWidth = EventList.Columns[1].Width;
                Options.Event_NextOccurrenceTimeWidth = EventList.Columns[2].Width;
                Options.Event_TriggerCountWidth = EventList.Columns[3].Width;
                Options.Event_ReminderWidth = EventList.Columns[4].Width;
                Options.Event_ScheduleWidth = EventList.Columns[5].Width;

                Options.Event_NameDisplayIndex = EventList.Columns[0].DisplayIndex;
                Options.Event_DescriptionDisplayIndex = EventList.Columns[1].DisplayIndex;
                Options.Event_NextOccurrenceTimeDisplayIndex = EventList.Columns[2].DisplayIndex;
                Options.Event_TriggerCountDisplayIndex = EventList.Columns[3].DisplayIndex;
                Options.Event_ReminderDisplayIndex = EventList.Columns[4].DisplayIndex;
                Options.Event_ScheduleDisplayIndex = EventList.Columns[5].DisplayIndex;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        private void EventList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == ColumnSorter.SortColumn) {
                // Reverse the current sort direction for this column.
                if (ColumnSorter.Order == SortOrder.Ascending) {
                    ColumnSorter.Order = SortOrder.Descending;
                } else {
                    ColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                // Set the column number that is to be sorted; default to ascending.
                ColumnSorter.SortColumn = e.Column;
                ColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.EventList.Sort();
        }

        //----------------------------------------------------------------------
        // Next?
        //----------------------------------------------------------------------

    }
}
