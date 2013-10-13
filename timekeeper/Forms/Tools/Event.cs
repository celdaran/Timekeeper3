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
    public partial class Event : Form
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

        public Event()
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
            this.CurrentEvent = new Classes.Event(1);

            EventTabControl.TabPages.RemoveByKey("HiddenTab");
            ThenLabel.Visible = false;
            TargetPanel.Visible = false;

            // FIXME: move to widgets | experimental right now
            // Directory relative to exe
            DirectoryInfo di = new DirectoryInfo("Sounds");
            foreach (FileInfo f in di.GetFiles("*.wav")) {
                Reminder_NotifyAudioFile.Items.Add(f.Name);
            }

            PopulateForm(sender, e);
        }

        //----------------------------------------------------------------------

        private void Event_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            return;
            /*
            if (Common.WarnPrompt("Are you sure?") == DialogResult.Yes) {
                e.Cancel = false;
            } else {
                e.Cancel = true;
            }
            */
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


                // Reminder Tab
                if (CurrentEvent.Reminder_TimeAmount == 0) {
                    Reminder_DontRemindMeButton.Checked = true;
                    Reminder_DontRemindMeButton_CheckedChanged(sender, e);
                } else {
                    Reminder_RemindMeButton.Checked = true;
                    Reminder_TimeAmount.Value = CurrentEvent.Reminder_TimeAmount;
                    Reminder_RemindMeButton_CheckedChanged(sender, e);
                }
                Reminder_TimeUnit.SelectedIndex = (int)CurrentEvent.Reminder_TimeUnit;
                Reminder_NotifyViaTray.Checked = CurrentEvent.Reminder_NotifyViaTray;
                Reminder_NotifyViaAudio.Checked = CurrentEvent.Reminder_NotifyViaAudio;
                Reminder_NotifyViaEmail.Checked = CurrentEvent.Reminder_NotifyViaEmail;
                Reminder_NotifyViaSMS.Checked = CurrentEvent.Reminder_NotifyViaSMS;
                Reminder_NotifyTrayMessage.Text = CurrentEvent.Reminder_NotifyTrayMessage;

                // Schedule Tab
                EventNextOccurrenceCopy.CustomFormat = Options.Advanced_DateTimeFormat;
                Schedule_OnceUnit.SelectedIndex = 2;
                Schedule_DailyEveryDay_CheckedChanged(sender, e);
                Schedule_MonthlyDateButton_CheckedChanged(sender, e);
                Schedule_MonthlyOrdinalDay.SelectedIndex = 0;
                Schedule_MonthlyDayOfWeek.SelectedIndex = 0;
                Schedule_YearlyOrdinalDay.SelectedIndex = 0;
                Schedule_YearlyDayOfWeek.SelectedIndex = 0;
                Schedule_YearlyMonth.SelectedIndex = 0;
                Schedule_MonthlyDateButton_CheckedChanged(sender, e);
                Schedule_YearlyEveryDateButton_CheckedChanged(sender, e);

                // Duration Tab
                EnableDurationTab(false);
                Duration_RunIndefinitelyButton.Checked = true;
                Duration_RunIndefinitelyButton_CheckedChanged(sender, e);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //======================================================================
        // REMINDER TAB
        //======================================================================

        //----------------------------------------------------------------------
        // Radio Events
        //----------------------------------------------------------------------

        private void Reminder_DontRemindMeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Reminder_DontRemindMeButton.Checked) {
                EnableReminderTab(false);
            }
        }

        private void Reminder_RemindMeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Reminder_RemindMeButton.Checked) {
                EnableReminderTab(true);
            }
        }

        //----------------------------------------------------------------------
        // Radio Event Helpers
        //----------------------------------------------------------------------

        private void EnableReminderTab(bool enabled)
        {
            Reminder_TimeAmount.Enabled = enabled;
            Reminder_TimeUnit.Enabled = enabled;
            Reminder_NotifyViaTray.Enabled = enabled;
            Reminder_NotifyViaAudio.Enabled = enabled;
            Reminder_NotifyViaEmail.Enabled = enabled;
            Reminder_NotifyViaSMS.Enabled = enabled;

            Reminder_NotifyTrayMessage.Enabled = Reminder_NotifyViaTray.Checked && Reminder_NotifyViaTray.Enabled;
            Reminder_NotifyAudioFile.Enabled = Reminder_NotifyViaAudio.Checked && Reminder_NotifyViaAudio.Enabled;
            Reminder_NotifyEmailAddress.Enabled = Reminder_NotifyViaEmail.Checked && Reminder_NotifyViaEmail.Enabled;
            Reminder_NotifyPhoneNumber.Enabled = Reminder_NotifyViaSMS.Checked && Reminder_NotifyViaSMS.Enabled;
            Reminder_NotifyCarrierList.Enabled = Reminder_NotifyViaSMS.Checked && Reminder_NotifyViaSMS.Enabled;
        }

        //----------------------------------------------------------------------
        // Other Event handlers
        //----------------------------------------------------------------------

        private void Reminder_NotifyViaTray_CheckedChanged(object sender, EventArgs e)
        {
            Reminder_NotifyTrayMessage.Enabled = Reminder_NotifyViaTray.Checked;
        }

        //----------------------------------------------------------------------

        private void Reminder_NotifyViaAudio_CheckedChanged(object sender, EventArgs e)
        {
            Reminder_NotifyAudioFile.Enabled = Reminder_NotifyViaAudio.Checked;
        }

        //----------------------------------------------------------------------

        private void Reminder_NotifyViaEmail_CheckedChanged(object sender, EventArgs e)
        {
            Reminder_NotifyEmailAddress.Enabled = Reminder_NotifyViaEmail.Checked;
        }

        //----------------------------------------------------------------------

        private void Reminder_NotifyViaSMS_CheckedChanged(object sender, EventArgs e)
        {
            Reminder_NotifyPhoneNumber.Enabled = Reminder_NotifyViaSMS.Checked;
            Reminder_NotifyCarrierList.Enabled = Reminder_NotifyViaSMS.Checked;
        }

        //----------------------------------------------------------------------

        private void Reminder_NotifyAudioFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                SoundPlayer simpleSound = 
                    new SoundPlayer(@"Sounds/" + Reminder_NotifyAudioFile.SelectedItem.ToString());
                simpleSound.Play();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //======================================================================
        // RECUR TAB
        //======================================================================

        //----------------------------------------------------------------------
        // Radio Events
        //----------------------------------------------------------------------

        private void RecurNoneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurNoneRadioButton.Checked) {
                HideAllPanels();
                EnableDurationTab(false);
                ThenLabel.Visible = false;
                TargetPanel.Visible = false;
            }
        }

        private void RecurFixedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurFixedRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurFixedPanel);
            }
        }

        private void RecurDailyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurDailyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurDailyPanel);
            }
        }

        private void RecurWeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurWeeklyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurWeeklyPanel);
            }
        }

        private void RecurMonthlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurMonthlyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurMonthlyPanel);
            }
        }

        private void RecurYearlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurYearlyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurYearlyPanel);
            }
        }

        private void RecurCronRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurCronRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurCronPanel);
            }
        }

        //----------------------------------------------------------------------
        // Sub-form Event Handlers
        //----------------------------------------------------------------------

        private void CrontabExpression_TextChanged(object sender, EventArgs e)
        {
            // Clear existing values
            CrontabSeconds.Text = "";
            CrontabMinutes.Text = "";
            CrontabHours.Text = "";
            CrontabDayOfMonth.Text = "";
            CrontabMonth.Text = "";
            CrontabDayOfWeek.Text = "";

            // Repopulate
            string[] Parts = CrontabExpression.Text.Split(' ');
            if (Parts.Length > 0)
                CrontabSeconds.Text = Parts[0];
            if (Parts.Length > 1)
                CrontabMinutes.Text = Parts[1];
            if (Parts.Length > 2)
                CrontabHours.Text = Parts[2];
            if (Parts.Length > 3)
                CrontabDayOfMonth.Text = Parts[3];
            if (Parts.Length > 4)
                CrontabMonth.Text = Parts[4];
            if (Parts.Length > 5)
                CrontabDayOfWeek.Text = Parts[5];
        }

        //----------------------------------------------------------------------
        // Radio Event Helpers
        //----------------------------------------------------------------------

        private void EnableDurationTab(bool enabled)
        {
            Duration_RunIndefinitelyButton.Enabled = enabled;
            Duration_StopAfterCountButton.Enabled = enabled;
            Duration_StopAfterTimeButton.Enabled = enabled;
            Duration_StopAfterCount.Enabled = Duration_StopAfterCountButton.Checked && Duration_StopAfterCountButton.Enabled;
            Duration_StopAfterTime.Enabled = Duration_StopAfterTimeButton.Checked && Duration_StopAfterTimeButton.Enabled;
        }

        //----------------------------------------------------------------------

        private void RelocatePanel(Panel panel)
        {
            panel.Top = TargetPanel.Top; // +6;
            panel.Left = TargetPanel.Left; // +6;
            panel.Parent = ScheduleTab; // PatternGroupBox;
            panel.BringToFront();
            EnableDurationTab(true);
            ThenLabel.Visible = true;
            TargetPanel.Visible = true;
        }

        //----------------------------------------------------------------------

        private void HideAllPanels()
        {
            RecurFixedPanel.Parent = PanelCorral;
            RecurDailyPanel.Parent = PanelCorral;
            RecurWeeklyPanel.Parent = PanelCorral;
            RecurMonthlyPanel.Parent = PanelCorral;
            RecurYearlyPanel.Parent = PanelCorral;
            RecurCronPanel.Parent = PanelCorral;
        }

        //======================================================================
        // REMINDER TAB
        //======================================================================

        //----------------------------------------------------------------------
        // Radio Button Events
        //----------------------------------------------------------------------

        private void Duration_RunIndefinitelyButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Duration_RunIndefinitelyButton.Checked) {
                Duration_StopAfterCount.Enabled = !Duration_RunIndefinitelyButton.Checked;
                Duration_StopAfterTime.Enabled = !Duration_RunIndefinitelyButton.Checked;
            }
        }

        private void Duration_StopAfterCountButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Duration_StopAfterCountButton.Checked) {
                Duration_StopAfterCount.Enabled = !Duration_RunIndefinitelyButton.Checked;
                Duration_StopAfterTime.Enabled = Duration_RunIndefinitelyButton.Checked;
            }
        }

        private void Duration_StopAfterTimeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Duration_StopAfterTimeButton.Checked) {
                Duration_StopAfterCount.Enabled = Duration_RunIndefinitelyButton.Checked;
                Duration_StopAfterTime.Enabled = !Duration_RunIndefinitelyButton.Checked;
            }
        }

        //----------------------------------------------------------------------
        // Other
        //----------------------------------------------------------------------

        private void EventNextOccurrence_ValueChanged(object sender, EventArgs e)
        {
            EventNextOccurrenceCopy.Value = EventNextOccurrence.Value;
        }

        private void EventNextOccurrenceCopy_ValueChanged(object sender, EventArgs e)
        {
            EventNextOccurrence.Value = EventNextOccurrenceCopy.Value;
        }

        //----------------------------------------------------------------------
        // TEMPORARY AND/OR EXPERIMENTAL
        //----------------------------------------------------------------------

        private void Schedule_DailyEveryDay_CheckedChanged(object sender, EventArgs e)
        {
            if (Schedule_DailyEveryDay.Checked) {
                Schedule_DailyIntervalCount.Enabled = false;
            }
        }

        private void Schedule_DailyEveryWeekday_CheckedChanged(object sender, EventArgs e)
        {
            if (Schedule_DailyEveryWeekday.Checked) {
                Schedule_DailyIntervalCount.Enabled = false;
            }
        }

        private void Schedule_DailySkipDays_CheckedChanged(object sender, EventArgs e)
        {
            if (Schedule_DailyInterval.Checked) {
                Schedule_DailyIntervalCount.Enabled = true;
            }
        }

        private void Schedule_MonthlyDateButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Schedule_MonthlyDateButton.Checked) {
                Schedule_MonthlyDate.Enabled = true;
                Schedule_MonthlyOrdinalDay.Enabled = false;
                Schedule_MonthlyDayOfWeek.Enabled = false;
            }
        }

        private void Schedule_MonthlyDayButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Schedule_MonthlyDayButton.Checked) {
                Schedule_MonthlyDate.Enabled = false;
                Schedule_MonthlyOrdinalDay.Enabled = true;
                Schedule_MonthlyDayOfWeek.Enabled = true;
            }
        }

        private void Schedule_YearlyEveryDateButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Schedule_YearlyEveryDateButton.Checked) {
                Schedule_YearlyEveryDate.Enabled = true;
                Schedule_YearlyOrdinalDay.Enabled = false;
                Schedule_YearlyDayOfWeek.Enabled = false;
            }
        }

        private void Schedule_YearlyDayButton_CheckedChanged(object sender, EventArgs e)
        {
            if (Schedule_YearlyDayButton.Checked) {
                Schedule_YearlyEveryDate.Enabled = false;
                Schedule_YearlyOrdinalDay.Enabled = true;
                Schedule_YearlyDayOfWeek.Enabled = true;
            }
        }


    }
}
