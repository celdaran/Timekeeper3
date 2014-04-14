using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using Technitivity.Toolbox;
using Quartz;
using Quartz.Impl;

using System.Net.Mail;
using System.Media;

namespace Timekeeper.Classes
{
    class ReminderJob : Quartz.IJob
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private Forms.Main MainForm;

        //----------------------------------------------------------------------
        // Job Execution
        //----------------------------------------------------------------------

        public void Execute(IJobExecutionContext context)
        {
            try {
                Timekeeper.Debug("Event " + context.JobDetail.Key.Name + " just fired");

                long EventId = Convert.ToInt64(context.JobDetail.Key.Name);
                Classes.ScheduledEvent ScheduledEvent = new Classes.ScheduledEvent(EventId);
                this.MainForm = (Forms.Main)context.JobDetail.JobDataMap.Get("MainForm");

                if (ScheduledEvent.Reminder.NotifyViaTray)
                    TrayNotification(ScheduledEvent);

                if (ScheduledEvent.Reminder.NotifyViaAudio)
                    AudioNotification(ScheduledEvent);

                if (ScheduledEvent.Reminder.NotifyViaEmail)
                    EmailNotification(ScheduledEvent);

                if (ScheduledEvent.Reminder.NotifyViaText)
                    SmsNotification(ScheduledEvent);

                UpdateSchedule(ScheduledEvent, context);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void TrayNotification(Classes.ScheduledEvent scheduledEvent)
        {
            Timekeeper.Debug("  Tray: " + scheduledEvent.Reminder.NotifyTrayMessage);

            if (this.MainForm.TrayIcon.Visible) {
                this.MainForm.TrayIcon.ShowBalloonTip(30000,
                    Timekeeper.TITLE,
                    scheduledEvent.Reminder.NotifyTrayMessage,
                    ToolTipIcon.Info);
            }
        }

        //----------------------------------------------------------------------

        private void AudioNotification(Classes.ScheduledEvent scheduledEvent)
        {
            Timekeeper.Debug("  Audio: " + scheduledEvent.Reminder.NotifyAudioFile);
            SoundPlayer simpleSound =
                new SoundPlayer(@"Sounds/" + scheduledEvent.Reminder.NotifyAudioFile);
            simpleSound.Play();
        }

        //----------------------------------------------------------------------

        private void EmailNotification(Classes.ScheduledEvent scheduledEvent)
        {
            Timekeeper.Debug("  Email: " + scheduledEvent.Reminder.NotifyEmailAddress);
            Classes.Mail Mail = new Classes.Mail();
            Mail.Send(scheduledEvent.Reminder.NotifyEmailAddress, "Actually, what SHOULD I mail?");
        }

        //----------------------------------------------------------------------

        private void SmsNotification(Classes.ScheduledEvent scheduledEvent)
        {
            Timekeeper.Debug("  Text: " + scheduledEvent.Reminder.NotifyPhoneNumber);
            Classes.Mail Mail = new Classes.Mail();
            string EmailDomain = null;

            // FIXME: DON'T COMPILE THIS INTO THE EXECUTABLE, STUPID
            // Come up with some mapping that allows for dynamic changes.
            // i.e., don't store a meaningless id number: make it user-
            // readable, user-definable, and extensible

            switch (scheduledEvent.Reminder.NotifyCarrierListId) {
                // Alltel
                case 1: EmailDomain = "message.alltel.com"; break;
                // AT&T
                case 2: EmailDomain = "txt.att.net"; break;
                // Boost Mobile
                case 3: EmailDomain = "myboostmobile.com"; break;
                // Sprint
                case 4: EmailDomain = "messaging.sprintpcs.com"; break;
                // T-Mobile
                case 5: EmailDomain = "tmomail.net"; break;
                // US Cellular
                case 6: EmailDomain = "email.uscc.net"; break;
                // Verizon
                case 7: EmailDomain = "vtext.com"; break;
                // Virgin Mobile
                case 8: EmailDomain = "vmobl.com"; break;
            }

            if (EmailDomain != null) {
                string NotifyEmailAddress = scheduledEvent.Reminder.NotifyPhoneNumber + "@" + EmailDomain;
                Mail.Send(NotifyEmailAddress, "Actually, what SHOULD I text?");
            } else {
                Timekeeper.Warn("Domain could not be found.");
            }
        }

        //----------------------------------------------------------------------
        //
        //----------------------------------------------------------------------

        private void UpdateSchedule(Classes.ScheduledEvent scheduledEvent, IJobExecutionContext context)
        {
            //------------------------------------
            // Update Count
            //------------------------------------

            scheduledEvent.Schedule.TriggerCount++;
            scheduledEvent.Schedule.Save();

            //------------------------------------
            // Update Next Occurrence, if any
            //------------------------------------

            if (context.NextFireTimeUtc != null) {
                DateTimeOffset? NextFire = context.NextFireTimeUtc;

                scheduledEvent.Event.NextOccurrenceTime = scheduledEvent.Schedule.ReminderTime(
                    NextFire.Value.DateTime,
                    (int)scheduledEvent.Reminder.TimeUnit,
                   -(int)scheduledEvent.Reminder.TimeAmount);
                scheduledEvent.Event.Save();

                Timekeeper.Debug("context.NextFireItemUtc: " + NextFire.Value.DateTime.ToString(Common.DATETIME_FORMAT));
            }

            //------------------------------------
            // Unschedule job?
            //------------------------------------

            if (scheduledEvent.Schedule.DurationTypeId == 2) {
                if (scheduledEvent.Schedule.TriggerCount >= scheduledEvent.Schedule.StopAfterCount) {
                    Timekeeper.Scheduler.UnscheduleJob(context.Trigger.Key);
                    Timekeeper.Debug("TriggerCount exceeded. Job " + scheduledEvent.Event.Id.ToString() + " cancelled.");
                }
            }

            if (scheduledEvent.Schedule.DurationTypeId == 3) {
                if (DateTime.Now >= scheduledEvent.Schedule.StopAfterTime) {
                    Timekeeper.Scheduler.UnscheduleJob(context.Trigger.Key);
                    Timekeeper.Debug("End date/time passed. Job " + scheduledEvent.Event.Id.ToString() + " cancelled.");
                }
            }

            //------------------------------------

        }

    }

}
