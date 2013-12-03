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

namespace Timekeeper.Forms.Shared
{
    public partial class Reminder : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;
        private Classes.Widgets Widgets;
        private Classes.Reminder CurrentReminder;

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

        private void Reminder_Load(object sender, EventArgs e)
        {
            this.Widgets = new Classes.Widgets();
            this.Options = Timekeeper.Options;
            this.CurrentReminder = new Classes.Reminder(2);

            PopulateForm(sender, e);
        }

        //----------------------------------------------------------------------

        private void Reminder_FormClosing(object sender, FormClosingEventArgs e)
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
                // FIXME: move to widgets | experimental right now

                // Directory relative to exe
                DirectoryInfo di = new DirectoryInfo("Sounds");
                foreach (FileInfo f in di.GetFiles("*.wav")) {
                    NotifyAudioFileList.Items.Add(f.Name);
                }

                // Now the normal population
                TimeUnitList.SelectedIndex = (int)CurrentReminder.TimeUnit;

                NotifyViaTrayCheckbox.Checked = CurrentReminder.NotifyViaTray;
                NotifyViaAudioCheckbox.Checked = CurrentReminder.NotifyViaAudio;
                NotifyViaEmailCheckbox.Checked = CurrentReminder.NotifyViaEmail;
                NotifyViaTextCheckbox.Checked = CurrentReminder.NotifyViaText;

                NotifyTrayMessageInput.Text = CurrentReminder.NotifyTrayMessage;
                NotifyEmailAddressInput.Text = CurrentReminder.NotifyEmailAddress;
                NotifyPhoneNumberInput.Text = CurrentReminder.NotifyPhoneNumber;
                NotifyCarrierList.SelectedIndex = (int)CurrentReminder.NotifyCarrierListId;

                if (CurrentReminder.TimeAmount == 0) {
                    DontRemindMeRadioButton.Checked = true;
                    DontRemindMeButton_CheckedChanged(sender, e);
                } else {
                    RemindMeRadioButton.Checked = true;
                    TimeAmountInput.Value = CurrentReminder.TimeAmount;
                    RemindMeButton_CheckedChanged(sender, e);
                }

                // Do this last unless you want it to play every time the dialog box opens
                NotifyAudioFileList.SelectedIndex = NotifyAudioFileList.FindString(CurrentReminder.NotifyAudioFile);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // Radio Events
        //----------------------------------------------------------------------

        private void DontRemindMeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DontRemindMeRadioButton.Checked) {
                EnableReminderTab(false);
            }
        }

        private void RemindMeButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RemindMeRadioButton.Checked) {
                EnableReminderTab(true);
            }
        }

        //----------------------------------------------------------------------
        // Radio Event Helpers
        //----------------------------------------------------------------------

        private void EnableReminderTab(bool enabled)
        {
            TimeAmountInput.Enabled = enabled;
            TimeUnitList.Enabled = enabled;
            NotifyViaTrayCheckbox.Enabled = enabled;
            NotifyViaAudioCheckbox.Enabled = enabled;
            NotifyViaEmailCheckbox.Enabled = enabled;
            NotifyViaTextCheckbox.Enabled = enabled;

            NotifyTrayMessageInput.Enabled = NotifyViaTrayCheckbox.Checked && NotifyViaTrayCheckbox.Enabled;
            NotifyAudioFileList.Enabled = NotifyViaAudioCheckbox.Checked && NotifyViaAudioCheckbox.Enabled;
            NotifyEmailAddressInput.Enabled = NotifyViaEmailCheckbox.Checked && NotifyViaEmailCheckbox.Enabled;
            NotifyPhoneNumberInput.Enabled = NotifyViaTextCheckbox.Checked && NotifyViaTextCheckbox.Enabled;
            NotifyCarrierList.Enabled = NotifyViaTextCheckbox.Checked && NotifyViaTextCheckbox.Enabled;
        }

        //----------------------------------------------------------------------
        // Other Event handlers
        //----------------------------------------------------------------------

        private void NotifyViaTrayCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            NotifyTrayMessageInput.Enabled = NotifyViaTrayCheckbox.Checked;
        }

        //----------------------------------------------------------------------

        private void NotifyViaAudioCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            NotifyAudioFileList.Enabled = NotifyViaAudioCheckbox.Checked;
        }

        //----------------------------------------------------------------------

        private void NotifyViaEmailCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            NotifyEmailAddressInput.Enabled = NotifyViaEmailCheckbox.Checked;
        }

        //----------------------------------------------------------------------

        private void NotifyViaTextCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            NotifyPhoneNumberInput.Enabled = NotifyViaTextCheckbox.Checked;
            NotifyCarrierList.Enabled = NotifyViaTextCheckbox.Checked;
        }

        //----------------------------------------------------------------------

        private void Reminder_NotifyAudioFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                if (NotifyViaAudioCheckbox.Checked && NotifyViaAudioCheckbox.Enabled) {
                    SoundPlayer simpleSound =
                        new SoundPlayer(@"Sounds/" + NotifyAudioFileList.SelectedItem.ToString());
                    simpleSound.Play();
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // TEMPORARY AND/OR EXPERIMENTAL
        //----------------------------------------------------------------------

    }
}
