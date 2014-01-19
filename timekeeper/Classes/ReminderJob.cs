using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;
using Quartz;
using Quartz.Impl;

namespace Timekeeper.Classes
{
    class ReminderJob : Quartz.IJob
    {
        //----------------------------------------------------------------------

        public void Execute(IJobExecutionContext context)
        {
            try {
                long EventId = Convert.ToInt64(context.JobDetail.Key.Name);

                Common.Warn("Event " + context.JobDetail.Key.Name + " just fired");

                Classes.ScheduledEvent ScheduledEvent = new Classes.ScheduledEvent(EventId);

                if (ScheduledEvent.Reminder.NotifyViaTray) {
                    Common.Warn("Tray: "  + ScheduledEvent.Reminder.NotifyTrayMessage);
                }

                if (ScheduledEvent.Reminder.NotifyViaAudio) {
                    Common.Warn("Audio: " + ScheduledEvent.Reminder.NotifyAudioFile);
                }

                if (ScheduledEvent.Reminder.NotifyViaEmail) {
                    Common.Warn("Email: " + ScheduledEvent.Reminder.NotifyEmailAddress);
                }

                if (ScheduledEvent.Reminder.NotifyViaText) {
                    Common.Warn("Text: " + ScheduledEvent.Reminder.NotifyPhoneNumber);
                }

                // Update Count
                ScheduledEvent.Schedule.TriggerCount++;
                ScheduledEvent.Schedule.Save();

                // Unschedule job?
                if (ScheduledEvent.Schedule.DurationTypeId == 2) {
                    if (ScheduledEvent.Schedule.TriggerCount >= ScheduledEvent.Schedule.StopAfterCount) {
                        Timekeeper.Scheduler.UnscheduleJob(context.Trigger.Key);
                        Timekeeper.Debug("TriggerCount exceeded. Job " + ScheduledEvent.Event.Id.ToString() + " cancelled.");
                    }
                }

                if (ScheduledEvent.Schedule.DurationTypeId == 3) {
                    if (DateTime.Now >= ScheduledEvent.Schedule.StopAfterTime) {
                        Timekeeper.Scheduler.UnscheduleJob(context.Trigger.Key);
                        Timekeeper.Debug("End date/time passed. Job " + ScheduledEvent.Event.Id.ToString() + " cancelled.");
                    }
                }

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

    }

}
