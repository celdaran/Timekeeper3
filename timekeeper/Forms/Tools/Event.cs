using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

using Technitivity.Toolbox;
using Quartz;
using Quartz.Impl;

namespace Timekeeper.Forms.Tools
{
    public partial class Event : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        /*
        private Classes.Options Options;
        private ListViewColumnSorter ColumnSorter;
        */

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------
        
        public Event()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Event_Load(object sender, EventArgs e)
        {
            try {
                PopulateEventList();
                //RestoreWindowMetrics();
                //ShowGroups(Options.Todo_ShowGroups);
                //ShowCompletedItems(Options.Todo_ShowCompletedItems);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
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
                if (currentEvent.IsHidden) { // FIXME: && !Options.View_HiddenProjects) {
                    // Don't add hidden items if we're hiding hidden items
                    return;
                }

                ListViewItem NewItem = new ListViewItem(currentEvent.Name, group);
                EventList.Items.Add(NewItem);

                NewItem.Tag = currentEvent;
                NewItem.ImageIndex = 0;
                NewItem.ToolTipText = currentEvent.Description;

                if (currentEvent.IsHidden) {
                    NewItem.ForeColor = Color.Gray;
                    NewItem.ImageIndex = 1;
                }

                // columns: Event, Description, Next Occurence, Period, Remind Via

                NewItem.SubItems.Add(currentEvent.Description);
                NewItem.SubItems.Add(currentEvent.NextOccurrenceTime.ToString(Common.LOCAL_DATETIME_FORMAT));

                string ReminderText = currentEvent.Reminder == null ? "None" : currentEvent.Reminder.ReminderId.ToString();
                string ScheduleText = currentEvent.Schedule == null ? "None" : currentEvent.Schedule.ScheduleId.ToString();

                NewItem.SubItems.Add(ReminderText);
                NewItem.SubItems.Add(ScheduleText);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void UpdateItem(ListViewItem item, Classes.Event currentEvent, ListViewGroup group)
        {
            try {
                // Update stuff
                item.Tag = currentEvent;
                item.ImageIndex = 0;
                item.ToolTipText = currentEvent.Description;
                item.Group = group;

                // Change column text
                ListViewItem.ListViewSubItem i;
                i = item.SubItems[0]; i.Text = currentEvent.Name;
                i = item.SubItems[1]; i.Text = currentEvent.Description;
                i = item.SubItems[2]; i.Text = currentEvent.NextOccurrenceTime.ToString(Common.LOCAL_DATETIME_FORMAT);

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
            Forms.Tools.EventDetail DialogBox = new Forms.Tools.EventDetail();
            DialogBox.ShowDialog(this);
            if (DialogBox.DialogResult == DialogResult.OK) {
                Classes.Event Event = DialogBox.CurrentEvent;
                if (Event.Save()) { // Save is an upsert function
                    this.AddItem(Event, EventList.Groups[Event.Group.Name]);
                } else {
                    Common.Warn("There was an error creating the event");
                }
            }
        }

        private void MenuEventsActionEdit_Click(object sender, EventArgs e)
        {
            if (EventList.SelectedItems.Count > 1) {
                Common.Warn("Cannot edit multiple items");
            } else {
                EditItem();
            }
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

        private void MenuEventViewShowGroups_Click(object sender, EventArgs e)
        {
            ToggleGroups();
        }

        private void ToggleGroups()
        {
            ShowGroups(!EventList.ShowGroups);
            //Options.Todo_ShowGroups = EventList.ShowGroups;
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
        // Helpers
        //----------------------------------------------------------------------

        private void EditItem()
        {
            long EventId = GetSelectedId();

            if (EventId == 0) {
                return;
            }

            ListViewItem SelectedItem = EventList.SelectedItems[0];

            Forms.Tools.EventDetail DialogBox = new Forms.Tools.EventDetail(EventId);
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                // Update DB
                Classes.Event Event = DialogBox.CurrentEvent;
                Event.Save();
                // Update UI
                Common.Info(Event.Group.Name);
                this.UpdateItem(SelectedItem, Event, EventList.Groups[Event.Group.Name]);
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

        private void SendEmailButton_Click(object sender, EventArgs e)
        {
            try {
                // TODO: Update Settings to use Options
                // TODO: Update Options to handle mail settings

                SmtpClient Client = new SmtpClient("mail.lockshire.net", 26);
                //SmtpClient Client = new SmtpClient("smtp.gmail.com", 587);
                //Client.EnableSsl = true;
                Client.Timeout = 10000;
                Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                Client.UseDefaultCredentials = false;
                //Client.Credentials = new System.Net.NetworkCredential("hillsc@phizzy.com", "e44@&7740E5@C52$");
                Client.Credentials = new System.Net.NetworkCredential("celdaran", "mvdajtwkyqcvuqvi");

                MailAddress FromAddress = new MailAddress("public@lockshire.net", "Timekeeper Notification");
                MailAddress ToAddress = new MailAddress("public@lockshire.net", "Charlie Hills"); // Configured on a per-event basis
                MailMessage Message = new System.Net.Mail.MailMessage(FromAddress, ToAddress);

                Message.Subject = "Timekeeper Reminder";
                Message.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                Message.Body = String.Format("This message connected to {0} and sent from {1} to {2}",
                    Client.Host + ":" + Client.Port.ToString(),
                    FromAddress.DisplayName + " <" + FromAddress.Address + ">",
                    ToAddress.DisplayName + " <" + ToAddress.Address + ">");
                Message.BodyEncoding = System.Text.Encoding.UTF8;
                Message.IsBodyHtml = false;

                Client.Send(Message);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                Technitivity.Toolbox.Common.Warn("Error sending email\n\n" + x.ToString());
            }
        }

        //----------------------------------------------------------------------

        private void QuartzTestButton_Click(object sender, EventArgs e)
        {
            //------------------------------------
            // Schedule Job One
            //------------------------------------

            IJobDetail Job1 = JobBuilder.Create<Classes.ReminderJob>()
                .WithIdentity("Job One: Simple Schedule", "My Group")
                .Build();

            ITrigger Trigger1 = TriggerBuilder.Create()
                .WithIdentity("Trigger One")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(60).RepeatForever())
                .StartAt(DateBuilder.FutureDate(0, IntervalUnit.Second))
                .Build();

            Timekeeper.Scheduler.ScheduleJob(Job1, Trigger1);

            //------------------------------------
            // Schedule Job Two
            //------------------------------------

            IJobDetail Job2 = JobBuilder.Create<Classes.ReminderJob>()
                .WithIdentity("Job Two: With Time Interval", "My Group")
                .Build();

            ITrigger Trigger2 = TriggerBuilder.Create()
                .WithIdentity("Trigger Two")
                .WithDailyTimeIntervalSchedule(x => x.WithIntervalInHours(24).OnEveryDay().StartingDailyAt(new TimeOfDay(6,40)))
                .StartAt(DateBuilder.FutureDate(0, IntervalUnit.Second))
                .Build();

            Timekeeper.Scheduler.ScheduleJob(Job2, Trigger2);

            //------------------------------------
            // Schedule Job Three
            //------------------------------------

            /*
                1. Seconds
                2. Minutes
                3. Hours
                4. Day-of-Month
                5. Month
                6. Day-of-Week
                7. Year (optional field)
            */

            IJobDetail Job3 = JobBuilder.Create<Classes.ReminderJob>()
                .WithIdentity("Job Three: Cron Job", "My Group")
                .Build();
                
            ITrigger Trigger3 = TriggerBuilder.Create()
                .WithIdentity("Trigger Three")
                .WithCronSchedule("0 * * * * ?")
                .StartAt(DateBuilder.FutureDate(0, IntervalUnit.Second))
                .EndAt(DateBuilder.FutureDate(5, IntervalUnit.Minute))
                .Build();

            Timekeeper.Scheduler.ScheduleJob(Job3, Trigger3);
        }

        //----------------------------------------------------------------------
        // Next?
        //----------------------------------------------------------------------

    }

    /*
    class HelloJob : Quartz.IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //throw new NotImplementedException();
            Common.Warn(context.JobDetail.Key.Name + " just fired");
        }
    }
    */

}
