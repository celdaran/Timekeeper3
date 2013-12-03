using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public class Reminder
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private DBI Database;

        //----------------------------------------------------------------------
        // Public Properties
        //----------------------------------------------------------------------

        public long ReminderId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime ModifyTime { get; set; }

        public long TimeAmount { get; set; }
        public long TimeUnit { get; set; }

        public bool NotifyViaTray { get; set; }
        public bool NotifyViaAudio { get; set; }
        public bool NotifyViaEmail { get; set; }
        public bool NotifyViaText { get; set; }

        public string NotifyTrayMessage { get; set; }
        public string NotifyAudioFile { get; set; }
        public string NotifyEmailAddress { get; set; }
        public string NotifyPhoneNumber { get; set; }
        public long NotifyCarrierListId { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Reminder()
        {
            this.Database = Timekeeper.Database;
        }

        //----------------------------------------------------------------------

        public Reminder(long id) : this()
        {
            this.Load(id);
        }

        //----------------------------------------------------------------------
        // Persistence
        //----------------------------------------------------------------------

        public Row Load(long id)
        {
            Row Reminder = new Row();

            try {
                string Query = String.Format(@"select ReminderId Id, * from Reminder where ReminderId = {0}", id);
                Reminder = this.Database.SelectRow(Query);

                if (Reminder["ReminderId"] != null) {
                    this.ReminderId = Reminder["ReminderId"];
                    this.CreateTime = Reminder["CreateTime"];
                    this.ModifyTime = Reminder["ModifyTime"];

                    this.TimeAmount = Reminder["TimeAmount"];
                    this.TimeUnit = Reminder["TimeUnit"];

                    this.NotifyViaTray = Reminder["NotifyViaTray"];
                    this.NotifyViaAudio = Reminder["NotifyViaAudio"];
                    this.NotifyViaEmail = Reminder["NotifyViaEmail"];
                    this.NotifyViaText = Reminder["NotifyViaText"];

                    this.NotifyTrayMessage = (string)Timekeeper.GetValue(Reminder["NotifyTrayMessage"], "Here is your reminder");
                    this.NotifyAudioFile = (string)Timekeeper.GetValue(Reminder["NotifyAudioFile"], "");
                    this.NotifyEmailAddress = (string)Timekeeper.GetValue(Reminder["NotifyEmailAddress"], "you@example.com");
                    this.NotifyPhoneNumber = (string)Timekeeper.GetValue(Reminder["NotifyPhoneNumber"], "9995551212");
                    this.NotifyCarrierListId = (long)Timekeeper.GetValue(Reminder["NotifyCarrierListId"], 3);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Reminder;
        }
    }
}
