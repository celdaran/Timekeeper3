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
                    this.SetAttributes(Reminder);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Reminder;
        }

        //----------------------------------------------------------------------

        public void SetAttributes(Row row)
        {
            this.ReminderId = row["ReminderId"];
            this.CreateTime = row["CreateTime"];
            this.ModifyTime = row["ModifyTime"];

            this.TimeAmount = row["TimeAmount"];
            this.TimeUnit = row["TimeUnit"];

            this.NotifyViaTray = row["NotifyViaTray"];
            this.NotifyViaAudio = row["NotifyViaAudio"];
            this.NotifyViaEmail = row["NotifyViaEmail"];
            this.NotifyViaText = row["NotifyViaText"];

            this.NotifyTrayMessage = (string)Timekeeper.GetValue(row["NotifyTrayMessage"], "Here is your reminder");
            this.NotifyAudioFile = (string)Timekeeper.GetValue(row["NotifyAudioFile"], "");
            this.NotifyEmailAddress = (string)Timekeeper.GetValue(row["NotifyEmailAddress"], "you@example.com");
            this.NotifyPhoneNumber = (string)Timekeeper.GetValue(row["NotifyPhoneNumber"], "9995551212");
            this.NotifyCarrierListId = (long)Timekeeper.GetValue(row["NotifyCarrierListId"], 3);
        }

        //----------------------------------------------------------------------

    }
}
