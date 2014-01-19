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

        public long ReminderId { get; private set; }
        public DateTime CreateTime { get; private set; }
        public DateTime ModifyTime { get; private set; }

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

        public bool Save()
        {
            bool Saved = false;
            string DbTimeStamp = Common.Now();

            try {
                Row Reminder = new Row();

                Reminder["ModifyTime"] = DbTimeStamp;

                Reminder["TimeAmount"] = this.TimeAmount;
                Reminder["TimeUnit"] = this.TimeUnit;

                Reminder["NotifyViaTray"] = this.NotifyViaTray ? 1 : 0;
                Reminder["NotifyViaAudio"] = this.NotifyViaAudio ? 1 : 0;
                Reminder["NotifyViaEmail"] = this.NotifyViaEmail ? 1 : 0;
                Reminder["NotifyViaText"] = this.NotifyViaText ? 1 : 0;

                Reminder["NotifyTrayMessage"] = this.NotifyTrayMessage;
                Reminder["NotifyAudioFile"] = this.NotifyAudioFile;
                Reminder["NotifyEmailAddress"] = this.NotifyEmailAddress;
                Reminder["NotifyPhoneNumber"] = this.NotifyPhoneNumber;
                Reminder["NotifyCarrierListId"] = this.NotifyCarrierListId;

                if (this.ReminderId == 0) {
                    // new row
                    Reminder["CreateTime"] = DbTimeStamp;

                    this.ReminderId = this.Database.Insert("Reminder", Reminder);
                    if (this.ReminderId > 0) {
                        Saved = true;
                        this.CreateTime = DateTime.Parse(DbTimeStamp);
                        this.ModifyTime = this.CreateTime;
                    }
                } else {
                    // existing row
                    if (this.Database.Update("Reminder", Reminder, "ReminderId", this.ReminderId) == 1) {
                        Saved = true;
                        this.ModifyTime = DateTime.Parse(DbTimeStamp);
                    }
                }

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return Saved;
        }

        //----------------------------------------------------------------------

    }
}
