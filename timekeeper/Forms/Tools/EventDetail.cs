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
    public partial class Reminder : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;
        private Classes.Widgets Widgets;
        private Classes.Event CurrentEvent;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Reminder()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Event_Load(object sender, EventArgs e)
        {
            this.Widgets = new Classes.Widgets();
            this.Options = Timekeeper.Options;
            this.CurrentEvent = new Classes.Event(2);

            PopulateForm(sender, e);
        }

        //----------------------------------------------------------------------

        private void Event_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            return;
        }

        //----------------------------------------------------------------------

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
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
                // Event Tab
                EventName.Text = CurrentEvent.Name;
                EventDescription.Text = CurrentEvent.Description;

                Classes.EventGroup EventGroup = new Classes.EventGroup();
                Widgets.PopulateGenericComboBox(EventGroupList, EventGroup.Table());

                EventGroupList.SelectedIndex = (int)CurrentEvent.EventGroupId;
                EventNextOccurrence.Value = CurrentEvent.NextOccurrenceTime;
                EventNextOccurrence.CustomFormat = Options.Advanced_DateTimeFormat;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        private void ReminderButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.Reminder DialogBox = new Forms.Shared.Reminder();
            DialogBox.ShowDialog(this);
        }

        private void SchedulerButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.Schedule DialogBox = new Forms.Shared.Schedule();
            DialogBox.ShowDialog(this);
        }

    }
}
