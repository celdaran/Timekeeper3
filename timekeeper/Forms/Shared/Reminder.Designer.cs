namespace Timekeeper.Forms.Shared
{
    partial class Reminder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.NotificationGroupBox = new System.Windows.Forms.GroupBox();
            this.NotifyTrayMessageInput = new System.Windows.Forms.TextBox();
            this.NotifyViaTrayCheckbox = new System.Windows.Forms.CheckBox();
            this.NotifyViaAudioCheckbox = new System.Windows.Forms.CheckBox();
            this.NotifyViaEmailCheckbox = new System.Windows.Forms.CheckBox();
            this.NotifyAudioFileList = new System.Windows.Forms.ComboBox();
            this.NotifyEmailAddressInput = new System.Windows.Forms.TextBox();
            this.NotifyViaTextCheckbox = new System.Windows.Forms.CheckBox();
            this.NotifyCarrierList = new System.Windows.Forms.ComboBox();
            this.NotifyPhoneNumberInput = new System.Windows.Forms.TextBox();
            this.RemindMeRadioButton = new System.Windows.Forms.RadioButton();
            this.DontRemindMeRadioButton = new System.Windows.Forms.RadioButton();
            this.Reminder_ReminderLabel = new System.Windows.Forms.Label();
            this.TimeUnitList = new System.Windows.Forms.ComboBox();
            this.TimeAmountInput = new System.Windows.Forms.NumericUpDown();
            this.NotificationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(308, 199);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 9;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButton_Click);
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(227, 199);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 8;
            this.AcceptDialogButton.Text = "OK";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // NotificationGroupBox
            // 
            this.NotificationGroupBox.Controls.Add(this.NotifyTrayMessageInput);
            this.NotificationGroupBox.Controls.Add(this.NotifyViaTrayCheckbox);
            this.NotificationGroupBox.Controls.Add(this.NotifyViaAudioCheckbox);
            this.NotificationGroupBox.Controls.Add(this.NotifyViaEmailCheckbox);
            this.NotificationGroupBox.Controls.Add(this.NotifyAudioFileList);
            this.NotificationGroupBox.Controls.Add(this.NotifyEmailAddressInput);
            this.NotificationGroupBox.Controls.Add(this.NotifyViaTextCheckbox);
            this.NotificationGroupBox.Controls.Add(this.NotifyCarrierList);
            this.NotificationGroupBox.Controls.Add(this.NotifyPhoneNumberInput);
            this.NotificationGroupBox.Location = new System.Drawing.Point(12, 71);
            this.NotificationGroupBox.Name = "NotificationGroupBox";
            this.NotificationGroupBox.Size = new System.Drawing.Size(371, 122);
            this.NotificationGroupBox.TabIndex = 26;
            this.NotificationGroupBox.TabStop = false;
            this.NotificationGroupBox.Text = "Notify Me Via";
            // 
            // NotifyTrayMessageInput
            // 
            this.NotifyTrayMessageInput.Enabled = false;
            this.NotifyTrayMessageInput.Location = new System.Drawing.Point(115, 17);
            this.NotifyTrayMessageInput.Name = "NotifyTrayMessageInput";
            this.NotifyTrayMessageInput.Size = new System.Drawing.Size(240, 20);
            this.NotifyTrayMessageInput.TabIndex = 6;
            // 
            // NotifyViaTrayCheckbox
            // 
            this.NotifyViaTrayCheckbox.AutoSize = true;
            this.NotifyViaTrayCheckbox.Location = new System.Drawing.Point(12, 19);
            this.NotifyViaTrayCheckbox.Name = "NotifyViaTrayCheckbox";
            this.NotifyViaTrayCheckbox.Size = new System.Drawing.Size(80, 17);
            this.NotifyViaTrayCheckbox.TabIndex = 5;
            this.NotifyViaTrayCheckbox.Text = "System tray";
            this.NotifyViaTrayCheckbox.UseVisualStyleBackColor = true;
            this.NotifyViaTrayCheckbox.CheckedChanged += new System.EventHandler(this.NotifyViaTrayCheckbox_CheckedChanged);
            // 
            // NotifyViaAudioCheckbox
            // 
            this.NotifyViaAudioCheckbox.AutoSize = true;
            this.NotifyViaAudioCheckbox.Location = new System.Drawing.Point(12, 44);
            this.NotifyViaAudioCheckbox.Name = "NotifyViaAudioCheckbox";
            this.NotifyViaAudioCheckbox.Size = new System.Drawing.Size(87, 17);
            this.NotifyViaAudioCheckbox.TabIndex = 7;
            this.NotifyViaAudioCheckbox.Text = "Play a sound";
            this.NotifyViaAudioCheckbox.UseVisualStyleBackColor = true;
            this.NotifyViaAudioCheckbox.CheckedChanged += new System.EventHandler(this.NotifyViaAudioCheckbox_CheckedChanged);
            // 
            // NotifyViaEmailCheckbox
            // 
            this.NotifyViaEmailCheckbox.AutoSize = true;
            this.NotifyViaEmailCheckbox.Location = new System.Drawing.Point(12, 69);
            this.NotifyViaEmailCheckbox.Name = "NotifyViaEmailCheckbox";
            this.NotifyViaEmailCheckbox.Size = new System.Drawing.Size(90, 17);
            this.NotifyViaEmailCheckbox.TabIndex = 9;
            this.NotifyViaEmailCheckbox.Text = "Send email to";
            this.NotifyViaEmailCheckbox.UseVisualStyleBackColor = true;
            this.NotifyViaEmailCheckbox.CheckedChanged += new System.EventHandler(this.NotifyViaEmailCheckbox_CheckedChanged);
            // 
            // NotifyAudioFileList
            // 
            this.NotifyAudioFileList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NotifyAudioFileList.Enabled = false;
            this.NotifyAudioFileList.FormattingEnabled = true;
            this.NotifyAudioFileList.Location = new System.Drawing.Point(115, 42);
            this.NotifyAudioFileList.Name = "NotifyAudioFileList";
            this.NotifyAudioFileList.Size = new System.Drawing.Size(240, 21);
            this.NotifyAudioFileList.TabIndex = 8;
            this.NotifyAudioFileList.SelectedIndexChanged += new System.EventHandler(this.Reminder_NotifyAudioFile_SelectedIndexChanged);
            // 
            // NotifyEmailAddressInput
            // 
            this.NotifyEmailAddressInput.Enabled = false;
            this.NotifyEmailAddressInput.Location = new System.Drawing.Point(115, 68);
            this.NotifyEmailAddressInput.Name = "NotifyEmailAddressInput";
            this.NotifyEmailAddressInput.Size = new System.Drawing.Size(240, 20);
            this.NotifyEmailAddressInput.TabIndex = 10;
            // 
            // NotifyViaTextCheckbox
            // 
            this.NotifyViaTextCheckbox.AutoSize = true;
            this.NotifyViaTextCheckbox.Location = new System.Drawing.Point(12, 95);
            this.NotifyViaTextCheckbox.Name = "NotifyViaTextCheckbox";
            this.NotifyViaTextCheckbox.Size = new System.Drawing.Size(83, 17);
            this.NotifyViaTextCheckbox.TabIndex = 11;
            this.NotifyViaTextCheckbox.Text = "Send text to";
            this.NotifyViaTextCheckbox.UseVisualStyleBackColor = true;
            this.NotifyViaTextCheckbox.CheckedChanged += new System.EventHandler(this.NotifyViaTextCheckbox_CheckedChanged);
            // 
            // NotifyCarrierList
            // 
            this.NotifyCarrierList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NotifyCarrierList.Enabled = false;
            this.NotifyCarrierList.FormattingEnabled = true;
            this.NotifyCarrierList.Items.AddRange(new object[] {
            "Alltel",
            "AT&T",
            "Boost Mobile",
            "Sprint",
            "T-Mobile",
            "US Cellular",
            "Verizon",
            "Virgin Mobile"});
            this.NotifyCarrierList.Location = new System.Drawing.Point(255, 93);
            this.NotifyCarrierList.Name = "NotifyCarrierList";
            this.NotifyCarrierList.Size = new System.Drawing.Size(100, 21);
            this.NotifyCarrierList.TabIndex = 13;
            // 
            // NotifyPhoneNumberInput
            // 
            this.NotifyPhoneNumberInput.Enabled = false;
            this.NotifyPhoneNumberInput.Location = new System.Drawing.Point(115, 93);
            this.NotifyPhoneNumberInput.Name = "NotifyPhoneNumberInput";
            this.NotifyPhoneNumberInput.Size = new System.Drawing.Size(134, 20);
            this.NotifyPhoneNumberInput.TabIndex = 12;
            // 
            // RemindMeRadioButton
            // 
            this.RemindMeRadioButton.AutoSize = true;
            this.RemindMeRadioButton.Location = new System.Drawing.Point(12, 35);
            this.RemindMeRadioButton.Name = "RemindMeRadioButton";
            this.RemindMeRadioButton.Size = new System.Drawing.Size(78, 17);
            this.RemindMeRadioButton.TabIndex = 2;
            this.RemindMeRadioButton.Text = "Remind me";
            this.RemindMeRadioButton.UseVisualStyleBackColor = true;
            this.RemindMeRadioButton.CheckedChanged += new System.EventHandler(this.RemindMeButton_CheckedChanged);
            // 
            // DontRemindMeRadioButton
            // 
            this.DontRemindMeRadioButton.AutoSize = true;
            this.DontRemindMeRadioButton.Checked = true;
            this.DontRemindMeRadioButton.Location = new System.Drawing.Point(12, 12);
            this.DontRemindMeRadioButton.Name = "DontRemindMeRadioButton";
            this.DontRemindMeRadioButton.Size = new System.Drawing.Size(101, 17);
            this.DontRemindMeRadioButton.TabIndex = 1;
            this.DontRemindMeRadioButton.TabStop = true;
            this.DontRemindMeRadioButton.Text = "Don\'t remind me";
            this.DontRemindMeRadioButton.UseVisualStyleBackColor = true;
            this.DontRemindMeRadioButton.CheckedChanged += new System.EventHandler(this.DontRemindMeButton_CheckedChanged);
            // 
            // Reminder_ReminderLabel
            // 
            this.Reminder_ReminderLabel.AutoSize = true;
            this.Reminder_ReminderLabel.Location = new System.Drawing.Point(254, 37);
            this.Reminder_ReminderLabel.Name = "Reminder_ReminderLabel";
            this.Reminder_ReminderLabel.Size = new System.Drawing.Size(70, 13);
            this.Reminder_ReminderLabel.TabIndex = 22;
            this.Reminder_ReminderLabel.Text = "before event.";
            // 
            // TimeUnitList
            // 
            this.TimeUnitList.FormattingEnabled = true;
            this.TimeUnitList.Items.AddRange(new object[] {
            "Minutes",
            "Hours",
            "Days",
            "Weeks",
            "Months"});
            this.TimeUnitList.Location = new System.Drawing.Point(166, 35);
            this.TimeUnitList.Name = "TimeUnitList";
            this.TimeUnitList.Size = new System.Drawing.Size(83, 21);
            this.TimeUnitList.TabIndex = 4;
            // 
            // TimeAmountInput
            // 
            this.TimeAmountInput.Location = new System.Drawing.Point(96, 35);
            this.TimeAmountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimeAmountInput.Name = "TimeAmountInput";
            this.TimeAmountInput.Size = new System.Drawing.Size(64, 20);
            this.TimeAmountInput.TabIndex = 3;
            this.TimeAmountInput.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // Reminder
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(397, 236);
            this.Controls.Add(this.NotificationGroupBox);
            this.Controls.Add(this.RemindMeRadioButton);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.DontRemindMeRadioButton);
            this.Controls.Add(this.Reminder_ReminderLabel);
            this.Controls.Add(this.AcceptDialogButton);
            this.Controls.Add(this.TimeUnitList);
            this.Controls.Add(this.TimeAmountInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reminder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reminder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Reminder_FormClosing);
            this.Load += new System.EventHandler(this.Reminder_Load);
            this.NotificationGroupBox.ResumeLayout(false);
            this.NotificationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TimeAmountInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.Label Reminder_ReminderLabel;
        private System.Windows.Forms.ComboBox NotifyCarrierList;
        private System.Windows.Forms.TextBox NotifyPhoneNumberInput;
        private System.Windows.Forms.CheckBox NotifyViaTextCheckbox;
        private System.Windows.Forms.TextBox NotifyEmailAddressInput;
        private System.Windows.Forms.CheckBox NotifyViaEmailCheckbox;
        private System.Windows.Forms.CheckBox NotifyViaAudioCheckbox;
        private System.Windows.Forms.CheckBox NotifyViaTrayCheckbox;
        private System.Windows.Forms.ComboBox TimeUnitList;
        private System.Windows.Forms.NumericUpDown TimeAmountInput;
        private System.Windows.Forms.ComboBox NotifyAudioFileList;
        private System.Windows.Forms.GroupBox NotificationGroupBox;
        private System.Windows.Forms.RadioButton RemindMeRadioButton;
        private System.Windows.Forms.RadioButton DontRemindMeRadioButton;
        private System.Windows.Forms.TextBox NotifyTrayMessageInput;
    }
}