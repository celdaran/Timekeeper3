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
        public Event()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        // Menu and Toolbar Events
        //----------------------------------------------------------------------

        private void MenuTodoViewLargeIcons_Click(object sender, EventArgs e)
        {
            ViewLargeIcons();
        }

        private void MenuTodoViewSmallIcons_Click(object sender, EventArgs e)
        {
            ViewSmallIcons();
        }

        private void MenuTodoViewTiles_Click(object sender, EventArgs e)
        {
            ViewTiles();
        }

        private void MenuTodoViewList_Click(object sender, EventArgs e)
        {
            ViewList();
        }

        private void MenuTodoViewDetails_Click(object sender, EventArgs e)
        {
            ViewDetails();
        }

        //----------------------------------------------------------------------
        // Horrible Amounts of Copy/Paste From Todo
        //----------------------------------------------------------------------

        private void ViewLargeIcons()
        {
            TodoList.View = View.LargeIcon;

            PopupMenuTodoViewLargeIcons.Checked = true;
            PopupMenuTodoViewSmallIcons.Checked = false;
            PopupMenuTodoViewTiles.Checked = false;
            PopupMenuTodoViewList.Checked = false;
            PopupMenuTodoViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewSmallIcons()
        {
            TodoList.View = View.SmallIcon;

            PopupMenuTodoViewLargeIcons.Checked = false;
            PopupMenuTodoViewSmallIcons.Checked = true;
            PopupMenuTodoViewTiles.Checked = false;
            PopupMenuTodoViewList.Checked = false;
            PopupMenuTodoViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewTiles()
        {
            TodoList.View = View.Tile;

            PopupMenuTodoViewLargeIcons.Checked = false;
            PopupMenuTodoViewSmallIcons.Checked = false;
            PopupMenuTodoViewTiles.Checked = true;
            PopupMenuTodoViewList.Checked = false;
            PopupMenuTodoViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewList()
        {
            TodoList.View = View.List;

            PopupMenuTodoViewLargeIcons.Checked = false;
            PopupMenuTodoViewSmallIcons.Checked = false;
            PopupMenuTodoViewTiles.Checked = false;
            PopupMenuTodoViewList.Checked = true;
            PopupMenuTodoViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewDetails()
        {
            TodoList.View = View.Details;

            PopupMenuTodoViewLargeIcons.Checked = false;
            PopupMenuTodoViewSmallIcons.Checked = false;
            PopupMenuTodoViewTiles.Checked = false;
            PopupMenuTodoViewList.Checked = false;
            PopupMenuTodoViewDetails.Checked = true;

            MirrorViewChecks();
        }

        private void MirrorViewChecks()
        {
            MenuTodoViewLargeIcons.Checked = PopupMenuTodoViewLargeIcons.Checked;
            MenuTodoViewSmallIcons.Checked = PopupMenuTodoViewSmallIcons.Checked;
            MenuTodoViewTiles.Checked = PopupMenuTodoViewTiles.Checked;
            MenuTodoViewList.Checked = PopupMenuTodoViewList.Checked;
            MenuTodoViewDetails.Checked = PopupMenuTodoViewDetails.Checked;
        }

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

        private void MenuTodoActionAdd_Click(object sender, EventArgs e)
        {
            Forms.Tools.EventDetail DialogBox = new Forms.Tools.EventDetail();
            DialogBox.ShowDialog(this);
        }

        private void QuartzTestButton_Click(object sender, EventArgs e)
        {
            //------------------------------------
            // Schedule Job One
            //------------------------------------

            IJobDetail Job1 = JobBuilder.Create<HelloJob>()
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

            IJobDetail Job2 = JobBuilder.Create<HelloJob>()
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

            IJobDetail Job3 = JobBuilder.Create<HelloJob>()
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

    class HelloJob : Quartz.IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            //throw new NotImplementedException();
            Common.Warn(context.JobDetail.Key.Name + " just fired");
        }
    }
}
