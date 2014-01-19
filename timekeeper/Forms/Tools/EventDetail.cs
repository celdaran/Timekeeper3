using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Media;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Tools
{
    public partial class EventDetail : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;
        private Classes.Widgets Widgets;
        private long EventId;

        private Forms.Shared.Reminder ReminderForm;

        public Classes.Event CurrentEvent { get; set; }

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public EventDetail() : this(0)
        {
        }

        public EventDetail(long eventId)
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;
            this.EventId = eventId;

            // Restore options
            EventNextOccurrence.CustomFormat = Options.Advanced_DateTimeFormat;
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Event_Load(object sender, EventArgs e)
        {
            this.Widgets = new Classes.Widgets();
            this.Options = Timekeeper.Options;
            this.CurrentEvent = new Classes.Event(this.EventId);

            PopulateForm(sender, e);
        }

        //----------------------------------------------------------------------

        private void Event_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel) {
                e.Cancel = false;
            }
            return;
        }

        //----------------------------------------------------------------------

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            CurrentEvent.Name = EventName.Text;
            CurrentEvent.Description = EventDescription.Text;

            CurrentEvent.EventGroupId = EventGroupList.SelectedIndex > -1 ? EventGroupList.SelectedIndex + 1 : 1;
            CurrentEvent.NextOccurrenceTime = EventNextOccurrence.Value;

            /*
            FIXME: only set these if they weren't there before
            CurrentEvent.ReminderId = 0;
            CurrentEvent.ScheduleId = 0;
            */

            CurrentEvent.Group = new Classes.EventGroup(CurrentEvent.EventGroupId);

            /*
            FIXME: ditto from above
            CurrentEvent.Reminder = null; // FIXME
            CurrentEvent.Schedule = null; // FIXME 2
            */

            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------

        private void CancelDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //----------------------------------------------------------------------
        // Form Event Helpers
        //----------------------------------------------------------------------

        private void PopulateForm(object sender, EventArgs e)
        {
            try {
                Classes.EventGroup EventGroup = new Classes.EventGroup();
                Widgets.PopulateGenericComboBox(EventGroupList, EventGroup.Table());

                if (CurrentEvent.Id == 0) {
                    EventGroupList.SelectedIndex = 0;
                    EventNextOccurrence.Value = DateTime.Now;
                } else {
                    EventName.Text = CurrentEvent.Name;
                    EventDescription.Text = CurrentEvent.Description;
                    EventGroupList.SelectedIndex = EventGroupList.FindStringExact(CurrentEvent.Group.Name);
                    EventNextOccurrence.Value = CurrentEvent.NextOccurrenceTime;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        private void ReminderButton_Click(object sender, EventArgs e)
        {
            if (ReminderForm == null) {
              ReminderForm = new Forms.Shared.Reminder(CurrentEvent.ReminderId);
              ReminderForm.PopulateForm();
            }
            ReminderForm.ShowDialog(this);
        }

        private void SchedulerButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.Schedule DialogBox = new Forms.Shared.Schedule(
                CurrentEvent.ScheduleId, CurrentEvent.NextOccurrenceTime);
            DialogBox.ShowDialog(this);
        }

    }
}
