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

        private long ReminderId;

        private Classes.Options Options;
        private Classes.Widgets Widgets;

        public Classes.Reminder CurrentReminder { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Reminder(long? reminderId)
        {
            InitializeComponent();
            this.ReminderId = reminderId == null ? 0 : (long)reminderId;
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Reminder_Load(object sender, EventArgs e)
        {
            this.Widgets = new Classes.Widgets();
            this.Options = Timekeeper.Options;
            this.CurrentReminder = new Classes.Reminder(this.ReminderId);

            PopulateForm();
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
            if (DontRemindMeRadioButton.Checked) {
                DialogResult = DialogResult.Ignore;
            }

            if (RemindMeRadioButton.Checked) {
                CurrentReminder.TimeUnit = TimeUnitList.SelectedIndex + 1;
                CurrentReminder.TimeAmount = (long)TimeAmountInput.Value;

                if (NotifyViaTrayCheckbox.Checked) {
                    CurrentReminder.NotifyViaTray = true;
                    CurrentReminder.NotifyTrayMessage = NotifyTrayMessageInput.Text;
                } else {
                    CurrentReminder.NotifyViaTray = false;
                }

                if (NotifyViaAudioCheckbox.Checked) {
                    CurrentReminder.NotifyViaAudio = true;
                    CurrentReminder.NotifyAudioFile = NotifyAudioFileList.Text;
                } else {
                    CurrentReminder.NotifyViaAudio = false;
                }

                if (NotifyViaEmailCheckbox.Checked) {
                    CurrentReminder.NotifyViaEmail = true;
                    CurrentReminder.NotifyEmailAddress = NotifyEmailAddressInput.Text;
                } else {
                    CurrentReminder.NotifyViaEmail = false;
                }

                if (NotifyViaTextCheckbox.Checked) {
                    CurrentReminder.NotifyViaText = true;
                    CurrentReminder.NotifyPhoneNumber = NotifyPhoneNumberInput.Text;
                    CurrentReminder.NotifyCarrierListId = NotifyCarrierList.SelectedIndex + 1;
                } else {
                    CurrentReminder.NotifyViaText = false;
                }

                CurrentReminder.Save();

                // Note, the database update has already happened at this point.
                // There's nothing more to do. If the parent box is Cancelled, then
                // these changes have already happened. Not sure how I want to deal
                // with that in the long run. But for now, that's how it is.

                DialogResult = DialogResult.OK;
            }

        }

        //----------------------------------------------------------------------

        private void CancelDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //----------------------------------------------------------------------
        // Form Event Helpers
        //----------------------------------------------------------------------

        public void PopulateForm()
        {
            try {
                // FIXME: move to widgets | experimental right now

                if (this.ReminderId == 0) {
                    DontRemindMeRadioButton.Checked = true;
                    return;
                } else {
                    RemindMeRadioButton.Checked = true;
                }

                string SoundsDirectoryPath = Timekeeper.CWD + Path.DirectorySeparatorChar + "Sounds";
                DirectoryInfo SoundsDirectory = new DirectoryInfo(SoundsDirectoryPath);
                if (SoundsDirectory.Exists) {
                    foreach (FileInfo SoundFile in SoundsDirectory.GetFiles("*.wav")) {
                        NotifyAudioFileList.Items.Add(Path.GetFileNameWithoutExtension(SoundFile.Name));
                    }
                } else {
                    Timekeeper.DoubleWarn("Could not find Sounds Directory: " + SoundsDirectory.FullName);
                }

                // Now the normal population
                TimeUnitList.SelectedIndex = (int)CurrentReminder.TimeUnit - 1;

                NotifyViaTrayCheckbox.Checked = CurrentReminder.NotifyViaTray;
                NotifyViaAudioCheckbox.Checked = CurrentReminder.NotifyViaAudio;
                NotifyViaEmailCheckbox.Checked = CurrentReminder.NotifyViaEmail;
                NotifyViaTextCheckbox.Checked = CurrentReminder.NotifyViaText;

                NotifyTrayMessageInput.Text = CurrentReminder.NotifyTrayMessage;
                NotifyEmailAddressInput.Text = CurrentReminder.NotifyEmailAddress;
                NotifyPhoneNumberInput.Text = CurrentReminder.NotifyPhoneNumber;
                NotifyCarrierList.SelectedIndex = (int)CurrentReminder.NotifyCarrierListId - 1;

                if (CurrentReminder.TimeAmount == 0) {
                    DontRemindMeRadioButton.Checked = true;
                    DontRemindMe();
                } else {
                    RemindMeRadioButton.Checked = true;
                    TimeAmountInput.Value = CurrentReminder.TimeAmount;
                    RemindMe();
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
            DontRemindMe();
        }

        private void RemindMeButton_CheckedChanged(object sender, EventArgs e)
        {
            RemindMe();
        }

        //----------------------------------------------------------------------
        // TODO: um, not sure where these go atm. Come back to this...

        private void DontRemindMe()
        {
            if (DontRemindMeRadioButton.Checked) {
                EnableReminderTab(false);
            }
        }

        private void RemindMe()
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
            PlayAudioFile.Enabled = NotifyViaAudioCheckbox.Checked && NotifyViaAudioCheckbox.Enabled;
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
            PlayAudioFile.Enabled = NotifyViaAudioCheckbox.Checked;
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
                        new SoundPlayer(@"Sounds/" + NotifyAudioFileList.SelectedItem.ToString() + ".wav");
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
