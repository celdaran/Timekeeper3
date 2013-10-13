namespace Timekeeper.Forms.Tools
{
    partial class EventDetail
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
            this.EventNextOccurrence = new System.Windows.Forms.DateTimePicker();
            this.EventDescription = new System.Windows.Forms.RichTextBox();
            this.EventName = new System.Windows.Forms.TextBox();
            this.EventTabControl = new System.Windows.Forms.TabControl();
            this.EventTab = new System.Windows.Forms.TabPage();
            this.GroupLabel = new System.Windows.Forms.Label();
            this.EventGroupList = new System.Windows.Forms.ComboBox();
            this.NextOccurrenceLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ReminderTab = new System.Windows.Forms.TabPage();
            this.Reminder_NotificationGroupBox = new System.Windows.Forms.GroupBox();
            this.Reminder_NotifyTrayMessage = new System.Windows.Forms.TextBox();
            this.Reminder_NotifyViaTray = new System.Windows.Forms.CheckBox();
            this.Reminder_NotifyViaAudio = new System.Windows.Forms.CheckBox();
            this.Reminder_NotifyViaEmail = new System.Windows.Forms.CheckBox();
            this.Reminder_NotifyAudioFile = new System.Windows.Forms.ComboBox();
            this.Reminder_NotifyEmailAddress = new System.Windows.Forms.TextBox();
            this.Reminder_NotifyViaSMS = new System.Windows.Forms.CheckBox();
            this.Reminder_NotifyCarrierList = new System.Windows.Forms.ComboBox();
            this.Reminder_NotifyPhoneNumber = new System.Windows.Forms.TextBox();
            this.Reminder_RemindMeButton = new System.Windows.Forms.RadioButton();
            this.Reminder_DontRemindMeButton = new System.Windows.Forms.RadioButton();
            this.Reminder_ReminderLabel = new System.Windows.Forms.Label();
            this.Reminder_TimeUnit = new System.Windows.Forms.ComboBox();
            this.Reminder_TimeAmount = new System.Windows.Forms.NumericUpDown();
            this.ScheduleTab = new System.Windows.Forms.TabPage();
            this.RecurCronRadioButton = new System.Windows.Forms.RadioButton();
            this.ThenLabel = new System.Windows.Forms.Label();
            this.EventNextOccurrenceCopy = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.RecurNoneRadioButton = new System.Windows.Forms.RadioButton();
            this.RecurFixedRadioButton = new System.Windows.Forms.RadioButton();
            this.RecurYearlyRadioButton = new System.Windows.Forms.RadioButton();
            this.RecurDailyRadioButton = new System.Windows.Forms.RadioButton();
            this.RecurWeeklyRadioButton = new System.Windows.Forms.RadioButton();
            this.RecurMonthlyRadioButton = new System.Windows.Forms.RadioButton();
            this.TargetPanel = new System.Windows.Forms.Panel();
            this.HiddenTab = new System.Windows.Forms.TabPage();
            this.PanelCorral = new System.Windows.Forms.GroupBox();
            this.RecurCronPanel = new System.Windows.Forms.Panel();
            this.CrontabExpression = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.CrontabDayOfWeek = new System.Windows.Forms.TextBox();
            this.CrontabMonth = new System.Windows.Forms.TextBox();
            this.CrontabDayOfMonth = new System.Windows.Forms.TextBox();
            this.CrontabHours = new System.Windows.Forms.TextBox();
            this.CrontabMinutes = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.CrontabSeconds = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.RecurYearlyPanel = new System.Windows.Forms.Panel();
            this.Schedule_YearlyMonth = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Schedule_YearlyDayOfWeek = new System.Windows.Forms.ComboBox();
            this.Schedule_YearlyOrdinalDay = new System.Windows.Forms.ComboBox();
            this.Schedule_YearlyDayButton = new System.Windows.Forms.RadioButton();
            this.Schedule_YearlyEveryDate = new System.Windows.Forms.NumericUpDown();
            this.Schedule_YearlyEveryDateButton = new System.Windows.Forms.RadioButton();
            this.RecurMonthlyPanel = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.Schedule_MonthlyIntervalCount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.Schedule_MonthlyDayOfWeek = new System.Windows.Forms.ComboBox();
            this.Schedule_MonthlyOrdinalDay = new System.Windows.Forms.ComboBox();
            this.Schedule_MonthlyDayButton = new System.Windows.Forms.RadioButton();
            this.Schedule_MonthlyDate = new System.Windows.Forms.NumericUpDown();
            this.Schedule_MonthlyDateButton = new System.Windows.Forms.RadioButton();
            this.RecurFixedPanel = new System.Windows.Forms.Panel();
            this.Schedule_OnceLabel = new System.Windows.Forms.Label();
            this.Schedule_OnceUnit = new System.Windows.Forms.ComboBox();
            this.Schedule_OnceAmount = new System.Windows.Forms.NumericUpDown();
            this.RecurWeeklyPanel = new System.Windows.Forms.Panel();
            this.Schedule_WeeklyLabel = new System.Windows.Forms.Label();
            this.Schedule_WeeklySunday = new System.Windows.Forms.CheckBox();
            this.Schedule_WeeklySaturday = new System.Windows.Forms.CheckBox();
            this.Schedule_WeeklyFriday = new System.Windows.Forms.CheckBox();
            this.Schedule_WeeklyThursday = new System.Windows.Forms.CheckBox();
            this.Schedule_WeeklyWednesday = new System.Windows.Forms.CheckBox();
            this.Schedule_WeeklyTuesday = new System.Windows.Forms.CheckBox();
            this.Schedule_WeeklyMonday = new System.Windows.Forms.CheckBox();
            this.Schedule_WeeklyCountLabel = new System.Windows.Forms.Label();
            this.Schedule_WeeklyIntervalCount = new System.Windows.Forms.NumericUpDown();
            this.RecurDailyPanel = new System.Windows.Forms.Panel();
            this.Schedule_DailyEveryWeekday = new System.Windows.Forms.RadioButton();
            this.Schedule_DailyEveryDay = new System.Windows.Forms.RadioButton();
            this.Schedule_DailyInterval = new System.Windows.Forms.RadioButton();
            this.Schedule_DailySkipDaysCountLabel = new System.Windows.Forms.Label();
            this.Schedule_DailyIntervalCount = new System.Windows.Forms.NumericUpDown();
            this.DurationTab = new System.Windows.Forms.TabPage();
            this.Duration_StopAfterTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.Duration_StopAfterCount = new System.Windows.Forms.NumericUpDown();
            this.Duration_StopAfterCountButton = new System.Windows.Forms.RadioButton();
            this.Duration_RunIndefinitelyButton = new System.Windows.Forms.RadioButton();
            this.Duration_StopAfterTimeButton = new System.Windows.Forms.RadioButton();
            this.PreviewTab = new System.Windows.Forms.TabPage();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.EventTabControl.SuspendLayout();
            this.EventTab.SuspendLayout();
            this.ReminderTab.SuspendLayout();
            this.Reminder_NotificationGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reminder_TimeAmount)).BeginInit();
            this.ScheduleTab.SuspendLayout();
            this.HiddenTab.SuspendLayout();
            this.PanelCorral.SuspendLayout();
            this.RecurCronPanel.SuspendLayout();
            this.RecurYearlyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_YearlyEveryDate)).BeginInit();
            this.RecurMonthlyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_MonthlyIntervalCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_MonthlyDate)).BeginInit();
            this.RecurFixedPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_OnceAmount)).BeginInit();
            this.RecurWeeklyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_WeeklyIntervalCount)).BeginInit();
            this.RecurDailyPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_DailyIntervalCount)).BeginInit();
            this.DurationTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Duration_StopAfterCount)).BeginInit();
            this.PreviewTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(352, 262);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 9;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButton_Click);
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(271, 262);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 8;
            this.AcceptDialogButton.Text = "OK";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // EventNextOccurrence
            // 
            this.EventNextOccurrence.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EventNextOccurrence.Location = new System.Drawing.Point(111, 171);
            this.EventNextOccurrence.Name = "EventNextOccurrence";
            this.EventNextOccurrence.Size = new System.Drawing.Size(279, 20);
            this.EventNextOccurrence.TabIndex = 4;
            this.EventNextOccurrence.ValueChanged += new System.EventHandler(this.EventNextOccurrence_ValueChanged);
            // 
            // EventDescription
            // 
            this.EventDescription.Location = new System.Drawing.Point(111, 42);
            this.EventDescription.Name = "EventDescription";
            this.EventDescription.Size = new System.Drawing.Size(279, 96);
            this.EventDescription.TabIndex = 2;
            this.EventDescription.Text = "";
            // 
            // EventName
            // 
            this.EventName.Location = new System.Drawing.Point(111, 16);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(279, 20);
            this.EventName.TabIndex = 1;
            // 
            // EventTabControl
            // 
            this.EventTabControl.Controls.Add(this.EventTab);
            this.EventTabControl.Controls.Add(this.ReminderTab);
            this.EventTabControl.Controls.Add(this.ScheduleTab);
            this.EventTabControl.Controls.Add(this.HiddenTab);
            this.EventTabControl.Controls.Add(this.DurationTab);
            this.EventTabControl.Controls.Add(this.PreviewTab);
            this.EventTabControl.Location = new System.Drawing.Point(12, 12);
            this.EventTabControl.Name = "EventTabControl";
            this.EventTabControl.SelectedIndex = 0;
            this.EventTabControl.Size = new System.Drawing.Size(415, 244);
            this.EventTabControl.TabIndex = 10;
            // 
            // EventTab
            // 
            this.EventTab.Controls.Add(this.GroupLabel);
            this.EventTab.Controls.Add(this.EventGroupList);
            this.EventTab.Controls.Add(this.NextOccurrenceLabel);
            this.EventTab.Controls.Add(this.DescriptionLabel);
            this.EventTab.Controls.Add(this.NameLabel);
            this.EventTab.Controls.Add(this.EventNextOccurrence);
            this.EventTab.Controls.Add(this.EventName);
            this.EventTab.Controls.Add(this.EventDescription);
            this.EventTab.Location = new System.Drawing.Point(4, 22);
            this.EventTab.Name = "EventTab";
            this.EventTab.Padding = new System.Windows.Forms.Padding(3);
            this.EventTab.Size = new System.Drawing.Size(407, 218);
            this.EventTab.TabIndex = 0;
            this.EventTab.Text = "Event";
            this.EventTab.UseVisualStyleBackColor = true;
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Location = new System.Drawing.Point(15, 147);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(39, 13);
            this.GroupLabel.TabIndex = 20;
            this.GroupLabel.Text = "Group:";
            // 
            // EventGroupList
            // 
            this.EventGroupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EventGroupList.FormattingEnabled = true;
            this.EventGroupList.Location = new System.Drawing.Point(111, 144);
            this.EventGroupList.Name = "EventGroupList";
            this.EventGroupList.Size = new System.Drawing.Size(279, 21);
            this.EventGroupList.TabIndex = 3;
            // 
            // NextOccurrenceLabel
            // 
            this.NextOccurrenceLabel.AutoSize = true;
            this.NextOccurrenceLabel.Location = new System.Drawing.Point(15, 174);
            this.NextOccurrenceLabel.Name = "NextOccurrenceLabel";
            this.NextOccurrenceLabel.Size = new System.Drawing.Size(80, 13);
            this.NextOccurrenceLabel.TabIndex = 9;
            this.NextOccurrenceLabel.Text = "Date and Time:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(15, 45);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 8;
            this.DescriptionLabel.Text = "Description:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(15, 19);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "Name:";
            // 
            // ReminderTab
            // 
            this.ReminderTab.Controls.Add(this.Reminder_NotificationGroupBox);
            this.ReminderTab.Controls.Add(this.Reminder_RemindMeButton);
            this.ReminderTab.Controls.Add(this.Reminder_DontRemindMeButton);
            this.ReminderTab.Controls.Add(this.Reminder_ReminderLabel);
            this.ReminderTab.Controls.Add(this.Reminder_TimeUnit);
            this.ReminderTab.Controls.Add(this.Reminder_TimeAmount);
            this.ReminderTab.Location = new System.Drawing.Point(4, 22);
            this.ReminderTab.Name = "ReminderTab";
            this.ReminderTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReminderTab.Size = new System.Drawing.Size(407, 218);
            this.ReminderTab.TabIndex = 5;
            this.ReminderTab.Text = "Reminder";
            this.ReminderTab.UseVisualStyleBackColor = true;
            // 
            // Reminder_NotificationGroupBox
            // 
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyTrayMessage);
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyViaTray);
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyViaAudio);
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyViaEmail);
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyAudioFile);
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyEmailAddress);
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyViaSMS);
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyCarrierList);
            this.Reminder_NotificationGroupBox.Controls.Add(this.Reminder_NotifyPhoneNumber);
            this.Reminder_NotificationGroupBox.Location = new System.Drawing.Point(18, 77);
            this.Reminder_NotificationGroupBox.Name = "Reminder_NotificationGroupBox";
            this.Reminder_NotificationGroupBox.Size = new System.Drawing.Size(371, 122);
            this.Reminder_NotificationGroupBox.TabIndex = 26;
            this.Reminder_NotificationGroupBox.TabStop = false;
            this.Reminder_NotificationGroupBox.Text = "Notify Me Via";
            // 
            // Reminder_NotifyTrayMessage
            // 
            this.Reminder_NotifyTrayMessage.Enabled = false;
            this.Reminder_NotifyTrayMessage.Location = new System.Drawing.Point(115, 17);
            this.Reminder_NotifyTrayMessage.Name = "Reminder_NotifyTrayMessage";
            this.Reminder_NotifyTrayMessage.Size = new System.Drawing.Size(240, 20);
            this.Reminder_NotifyTrayMessage.TabIndex = 6;
            // 
            // Reminder_NotifyViaTray
            // 
            this.Reminder_NotifyViaTray.AutoSize = true;
            this.Reminder_NotifyViaTray.Location = new System.Drawing.Point(12, 19);
            this.Reminder_NotifyViaTray.Name = "Reminder_NotifyViaTray";
            this.Reminder_NotifyViaTray.Size = new System.Drawing.Size(80, 17);
            this.Reminder_NotifyViaTray.TabIndex = 5;
            this.Reminder_NotifyViaTray.Text = "System tray";
            this.Reminder_NotifyViaTray.UseVisualStyleBackColor = true;
            this.Reminder_NotifyViaTray.CheckedChanged += new System.EventHandler(this.Reminder_NotifyViaTray_CheckedChanged);
            // 
            // Reminder_NotifyViaAudio
            // 
            this.Reminder_NotifyViaAudio.AutoSize = true;
            this.Reminder_NotifyViaAudio.Location = new System.Drawing.Point(12, 44);
            this.Reminder_NotifyViaAudio.Name = "Reminder_NotifyViaAudio";
            this.Reminder_NotifyViaAudio.Size = new System.Drawing.Size(87, 17);
            this.Reminder_NotifyViaAudio.TabIndex = 7;
            this.Reminder_NotifyViaAudio.Text = "Play a sound";
            this.Reminder_NotifyViaAudio.UseVisualStyleBackColor = true;
            this.Reminder_NotifyViaAudio.CheckedChanged += new System.EventHandler(this.Reminder_NotifyViaAudio_CheckedChanged);
            // 
            // Reminder_NotifyViaEmail
            // 
            this.Reminder_NotifyViaEmail.AutoSize = true;
            this.Reminder_NotifyViaEmail.Location = new System.Drawing.Point(12, 69);
            this.Reminder_NotifyViaEmail.Name = "Reminder_NotifyViaEmail";
            this.Reminder_NotifyViaEmail.Size = new System.Drawing.Size(90, 17);
            this.Reminder_NotifyViaEmail.TabIndex = 9;
            this.Reminder_NotifyViaEmail.Text = "Send email to";
            this.Reminder_NotifyViaEmail.UseVisualStyleBackColor = true;
            this.Reminder_NotifyViaEmail.CheckedChanged += new System.EventHandler(this.Reminder_NotifyViaEmail_CheckedChanged);
            // 
            // Reminder_NotifyAudioFile
            // 
            this.Reminder_NotifyAudioFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Reminder_NotifyAudioFile.Enabled = false;
            this.Reminder_NotifyAudioFile.FormattingEnabled = true;
            this.Reminder_NotifyAudioFile.Location = new System.Drawing.Point(115, 42);
            this.Reminder_NotifyAudioFile.Name = "Reminder_NotifyAudioFile";
            this.Reminder_NotifyAudioFile.Size = new System.Drawing.Size(240, 21);
            this.Reminder_NotifyAudioFile.TabIndex = 8;
            this.Reminder_NotifyAudioFile.SelectedIndexChanged += new System.EventHandler(this.Reminder_NotifyAudioFile_SelectedIndexChanged);
            // 
            // Reminder_NotifyEmailAddress
            // 
            this.Reminder_NotifyEmailAddress.Enabled = false;
            this.Reminder_NotifyEmailAddress.Location = new System.Drawing.Point(115, 68);
            this.Reminder_NotifyEmailAddress.Name = "Reminder_NotifyEmailAddress";
            this.Reminder_NotifyEmailAddress.Size = new System.Drawing.Size(240, 20);
            this.Reminder_NotifyEmailAddress.TabIndex = 10;
            // 
            // Reminder_NotifyViaSMS
            // 
            this.Reminder_NotifyViaSMS.AutoSize = true;
            this.Reminder_NotifyViaSMS.Location = new System.Drawing.Point(12, 95);
            this.Reminder_NotifyViaSMS.Name = "Reminder_NotifyViaSMS";
            this.Reminder_NotifyViaSMS.Size = new System.Drawing.Size(83, 17);
            this.Reminder_NotifyViaSMS.TabIndex = 11;
            this.Reminder_NotifyViaSMS.Text = "Send text to";
            this.Reminder_NotifyViaSMS.UseVisualStyleBackColor = true;
            this.Reminder_NotifyViaSMS.CheckedChanged += new System.EventHandler(this.Reminder_NotifyViaSMS_CheckedChanged);
            // 
            // Reminder_NotifyCarrierList
            // 
            this.Reminder_NotifyCarrierList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Reminder_NotifyCarrierList.Enabled = false;
            this.Reminder_NotifyCarrierList.FormattingEnabled = true;
            this.Reminder_NotifyCarrierList.Items.AddRange(new object[] {
            "Alltel",
            "AT&T",
            "Boost Mobile",
            "Sprint",
            "T-Mobile",
            "US Cellular",
            "Verizon",
            "Virgin Mobile"});
            this.Reminder_NotifyCarrierList.Location = new System.Drawing.Point(255, 93);
            this.Reminder_NotifyCarrierList.Name = "Reminder_NotifyCarrierList";
            this.Reminder_NotifyCarrierList.Size = new System.Drawing.Size(100, 21);
            this.Reminder_NotifyCarrierList.TabIndex = 13;
            // 
            // Reminder_NotifyPhoneNumber
            // 
            this.Reminder_NotifyPhoneNumber.Enabled = false;
            this.Reminder_NotifyPhoneNumber.Location = new System.Drawing.Point(115, 93);
            this.Reminder_NotifyPhoneNumber.Name = "Reminder_NotifyPhoneNumber";
            this.Reminder_NotifyPhoneNumber.Size = new System.Drawing.Size(134, 20);
            this.Reminder_NotifyPhoneNumber.TabIndex = 12;
            // 
            // Reminder_RemindMeButton
            // 
            this.Reminder_RemindMeButton.AutoSize = true;
            this.Reminder_RemindMeButton.Location = new System.Drawing.Point(18, 41);
            this.Reminder_RemindMeButton.Name = "Reminder_RemindMeButton";
            this.Reminder_RemindMeButton.Size = new System.Drawing.Size(78, 17);
            this.Reminder_RemindMeButton.TabIndex = 2;
            this.Reminder_RemindMeButton.Text = "Remind me";
            this.Reminder_RemindMeButton.UseVisualStyleBackColor = true;
            this.Reminder_RemindMeButton.CheckedChanged += new System.EventHandler(this.Reminder_RemindMeButton_CheckedChanged);
            // 
            // Reminder_DontRemindMeButton
            // 
            this.Reminder_DontRemindMeButton.AutoSize = true;
            this.Reminder_DontRemindMeButton.Checked = true;
            this.Reminder_DontRemindMeButton.Location = new System.Drawing.Point(18, 18);
            this.Reminder_DontRemindMeButton.Name = "Reminder_DontRemindMeButton";
            this.Reminder_DontRemindMeButton.Size = new System.Drawing.Size(101, 17);
            this.Reminder_DontRemindMeButton.TabIndex = 1;
            this.Reminder_DontRemindMeButton.TabStop = true;
            this.Reminder_DontRemindMeButton.Text = "Don\'t remind me";
            this.Reminder_DontRemindMeButton.UseVisualStyleBackColor = true;
            this.Reminder_DontRemindMeButton.CheckedChanged += new System.EventHandler(this.Reminder_DontRemindMeButton_CheckedChanged);
            // 
            // Reminder_ReminderLabel
            // 
            this.Reminder_ReminderLabel.AutoSize = true;
            this.Reminder_ReminderLabel.Location = new System.Drawing.Point(260, 43);
            this.Reminder_ReminderLabel.Name = "Reminder_ReminderLabel";
            this.Reminder_ReminderLabel.Size = new System.Drawing.Size(70, 13);
            this.Reminder_ReminderLabel.TabIndex = 22;
            this.Reminder_ReminderLabel.Text = "before event.";
            // 
            // Reminder_TimeUnit
            // 
            this.Reminder_TimeUnit.FormattingEnabled = true;
            this.Reminder_TimeUnit.Items.AddRange(new object[] {
            "Minutes",
            "Hours",
            "Days",
            "Weeks",
            "Months"});
            this.Reminder_TimeUnit.Location = new System.Drawing.Point(172, 41);
            this.Reminder_TimeUnit.Name = "Reminder_TimeUnit";
            this.Reminder_TimeUnit.Size = new System.Drawing.Size(83, 21);
            this.Reminder_TimeUnit.TabIndex = 4;
            // 
            // Reminder_TimeAmount
            // 
            this.Reminder_TimeAmount.Location = new System.Drawing.Point(102, 41);
            this.Reminder_TimeAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Reminder_TimeAmount.Name = "Reminder_TimeAmount";
            this.Reminder_TimeAmount.Size = new System.Drawing.Size(64, 20);
            this.Reminder_TimeAmount.TabIndex = 3;
            this.Reminder_TimeAmount.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            // 
            // ScheduleTab
            // 
            this.ScheduleTab.Controls.Add(this.RecurCronRadioButton);
            this.ScheduleTab.Controls.Add(this.ThenLabel);
            this.ScheduleTab.Controls.Add(this.EventNextOccurrenceCopy);
            this.ScheduleTab.Controls.Add(this.label2);
            this.ScheduleTab.Controls.Add(this.RecurNoneRadioButton);
            this.ScheduleTab.Controls.Add(this.RecurFixedRadioButton);
            this.ScheduleTab.Controls.Add(this.RecurYearlyRadioButton);
            this.ScheduleTab.Controls.Add(this.RecurDailyRadioButton);
            this.ScheduleTab.Controls.Add(this.RecurWeeklyRadioButton);
            this.ScheduleTab.Controls.Add(this.RecurMonthlyRadioButton);
            this.ScheduleTab.Controls.Add(this.TargetPanel);
            this.ScheduleTab.Location = new System.Drawing.Point(4, 22);
            this.ScheduleTab.Name = "ScheduleTab";
            this.ScheduleTab.Padding = new System.Windows.Forms.Padding(3);
            this.ScheduleTab.Size = new System.Drawing.Size(407, 218);
            this.ScheduleTab.TabIndex = 1;
            this.ScheduleTab.Text = "Schedule";
            this.ScheduleTab.UseVisualStyleBackColor = true;
            // 
            // RecurCronRadioButton
            // 
            this.RecurCronRadioButton.AutoSize = true;
            this.RecurCronRadioButton.Location = new System.Drawing.Point(18, 156);
            this.RecurCronRadioButton.Name = "RecurCronRadioButton";
            this.RecurCronRadioButton.Size = new System.Drawing.Size(74, 17);
            this.RecurCronRadioButton.TabIndex = 41;
            this.RecurCronRadioButton.Text = "Advanced";
            this.RecurCronRadioButton.UseVisualStyleBackColor = true;
            this.RecurCronRadioButton.CheckedChanged += new System.EventHandler(this.RecurCronRadioButton_CheckedChanged);
            // 
            // ThenLabel
            // 
            this.ThenLabel.AutoSize = true;
            this.ThenLabel.Location = new System.Drawing.Point(333, 20);
            this.ThenLabel.Name = "ThenLabel";
            this.ThenLabel.Size = new System.Drawing.Size(31, 13);
            this.ThenLabel.TabIndex = 40;
            this.ThenLabel.Text = "then:";
            // 
            // EventNextOccurrenceCopy
            // 
            this.EventNextOccurrenceCopy.CustomFormat = "";
            this.EventNextOccurrenceCopy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EventNextOccurrenceCopy.Location = new System.Drawing.Point(182, 16);
            this.EventNextOccurrenceCopy.Name = "EventNextOccurrenceCopy";
            this.EventNextOccurrenceCopy.Size = new System.Drawing.Size(145, 20);
            this.EventNextOccurrenceCopy.TabIndex = 39;
            this.EventNextOccurrenceCopy.ValueChanged += new System.EventHandler(this.EventNextOccurrenceCopy_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Starting:";
            // 
            // RecurNoneRadioButton
            // 
            this.RecurNoneRadioButton.AutoSize = true;
            this.RecurNoneRadioButton.Checked = true;
            this.RecurNoneRadioButton.Location = new System.Drawing.Point(18, 18);
            this.RecurNoneRadioButton.Name = "RecurNoneRadioButton";
            this.RecurNoneRadioButton.Size = new System.Drawing.Size(71, 17);
            this.RecurNoneRadioButton.TabIndex = 31;
            this.RecurNoneRadioButton.TabStop = true;
            this.RecurNoneRadioButton.Text = "One Time";
            this.RecurNoneRadioButton.UseVisualStyleBackColor = true;
            this.RecurNoneRadioButton.CheckedChanged += new System.EventHandler(this.RecurNoneRadioButton_CheckedChanged);
            // 
            // RecurFixedRadioButton
            // 
            this.RecurFixedRadioButton.AutoSize = true;
            this.RecurFixedRadioButton.Location = new System.Drawing.Point(18, 41);
            this.RecurFixedRadioButton.Name = "RecurFixedRadioButton";
            this.RecurFixedRadioButton.Size = new System.Drawing.Size(83, 17);
            this.RecurFixedRadioButton.TabIndex = 32;
            this.RecurFixedRadioButton.Text = "Fixed Period";
            this.RecurFixedRadioButton.UseVisualStyleBackColor = true;
            this.RecurFixedRadioButton.CheckedChanged += new System.EventHandler(this.RecurFixedRadioButton_CheckedChanged);
            // 
            // RecurYearlyRadioButton
            // 
            this.RecurYearlyRadioButton.AutoSize = true;
            this.RecurYearlyRadioButton.Location = new System.Drawing.Point(18, 133);
            this.RecurYearlyRadioButton.Name = "RecurYearlyRadioButton";
            this.RecurYearlyRadioButton.Size = new System.Drawing.Size(54, 17);
            this.RecurYearlyRadioButton.TabIndex = 36;
            this.RecurYearlyRadioButton.Text = "Yearly";
            this.RecurYearlyRadioButton.UseVisualStyleBackColor = true;
            this.RecurYearlyRadioButton.CheckedChanged += new System.EventHandler(this.RecurYearlyRadioButton_CheckedChanged);
            // 
            // RecurDailyRadioButton
            // 
            this.RecurDailyRadioButton.AutoSize = true;
            this.RecurDailyRadioButton.Location = new System.Drawing.Point(18, 64);
            this.RecurDailyRadioButton.Name = "RecurDailyRadioButton";
            this.RecurDailyRadioButton.Size = new System.Drawing.Size(48, 17);
            this.RecurDailyRadioButton.TabIndex = 33;
            this.RecurDailyRadioButton.Text = "Daily";
            this.RecurDailyRadioButton.UseVisualStyleBackColor = true;
            this.RecurDailyRadioButton.CheckedChanged += new System.EventHandler(this.RecurDailyRadioButton_CheckedChanged);
            // 
            // RecurWeeklyRadioButton
            // 
            this.RecurWeeklyRadioButton.AutoSize = true;
            this.RecurWeeklyRadioButton.Location = new System.Drawing.Point(18, 87);
            this.RecurWeeklyRadioButton.Name = "RecurWeeklyRadioButton";
            this.RecurWeeklyRadioButton.Size = new System.Drawing.Size(61, 17);
            this.RecurWeeklyRadioButton.TabIndex = 34;
            this.RecurWeeklyRadioButton.Text = "Weekly";
            this.RecurWeeklyRadioButton.UseVisualStyleBackColor = true;
            this.RecurWeeklyRadioButton.CheckedChanged += new System.EventHandler(this.RecurWeeklyRadioButton_CheckedChanged);
            // 
            // RecurMonthlyRadioButton
            // 
            this.RecurMonthlyRadioButton.AutoSize = true;
            this.RecurMonthlyRadioButton.Location = new System.Drawing.Point(17, 110);
            this.RecurMonthlyRadioButton.Name = "RecurMonthlyRadioButton";
            this.RecurMonthlyRadioButton.Size = new System.Drawing.Size(62, 17);
            this.RecurMonthlyRadioButton.TabIndex = 35;
            this.RecurMonthlyRadioButton.Text = "Monthly";
            this.RecurMonthlyRadioButton.UseVisualStyleBackColor = true;
            this.RecurMonthlyRadioButton.CheckedChanged += new System.EventHandler(this.RecurMonthlyRadioButton_CheckedChanged);
            // 
            // TargetPanel
            // 
            this.TargetPanel.Location = new System.Drawing.Point(133, 42);
            this.TargetPanel.Name = "TargetPanel";
            this.TargetPanel.Size = new System.Drawing.Size(268, 170);
            this.TargetPanel.TabIndex = 37;
            // 
            // HiddenTab
            // 
            this.HiddenTab.AutoScroll = true;
            this.HiddenTab.Controls.Add(this.PanelCorral);
            this.HiddenTab.Location = new System.Drawing.Point(4, 22);
            this.HiddenTab.Name = "HiddenTab";
            this.HiddenTab.Padding = new System.Windows.Forms.Padding(3);
            this.HiddenTab.Size = new System.Drawing.Size(407, 218);
            this.HiddenTab.TabIndex = 2;
            this.HiddenTab.Text = "[Schedule Panels]";
            this.HiddenTab.UseVisualStyleBackColor = true;
            // 
            // PanelCorral
            // 
            this.PanelCorral.Controls.Add(this.RecurCronPanel);
            this.PanelCorral.Controls.Add(this.RecurYearlyPanel);
            this.PanelCorral.Controls.Add(this.RecurMonthlyPanel);
            this.PanelCorral.Controls.Add(this.RecurFixedPanel);
            this.PanelCorral.Controls.Add(this.RecurWeeklyPanel);
            this.PanelCorral.Controls.Add(this.RecurDailyPanel);
            this.PanelCorral.Location = new System.Drawing.Point(16, 16);
            this.PanelCorral.Name = "PanelCorral";
            this.PanelCorral.Size = new System.Drawing.Size(351, 702);
            this.PanelCorral.TabIndex = 32;
            this.PanelCorral.TabStop = false;
            // 
            // RecurCronPanel
            // 
            this.RecurCronPanel.BackColor = System.Drawing.SystemColors.Control;
            this.RecurCronPanel.Controls.Add(this.CrontabExpression);
            this.RecurCronPanel.Controls.Add(this.label18);
            this.RecurCronPanel.Controls.Add(this.label17);
            this.RecurCronPanel.Controls.Add(this.label16);
            this.RecurCronPanel.Controls.Add(this.label11);
            this.RecurCronPanel.Controls.Add(this.label15);
            this.RecurCronPanel.Controls.Add(this.label14);
            this.RecurCronPanel.Controls.Add(this.CrontabDayOfWeek);
            this.RecurCronPanel.Controls.Add(this.CrontabMonth);
            this.RecurCronPanel.Controls.Add(this.CrontabDayOfMonth);
            this.RecurCronPanel.Controls.Add(this.CrontabHours);
            this.RecurCronPanel.Controls.Add(this.CrontabMinutes);
            this.RecurCronPanel.Controls.Add(this.label10);
            this.RecurCronPanel.Controls.Add(this.CrontabSeconds);
            this.RecurCronPanel.Controls.Add(this.label13);
            this.RecurCronPanel.Location = new System.Drawing.Point(15, 515);
            this.RecurCronPanel.Name = "RecurCronPanel";
            this.RecurCronPanel.Size = new System.Drawing.Size(268, 165);
            this.RecurCronPanel.TabIndex = 32;
            // 
            // CrontabExpression
            // 
            this.CrontabExpression.Location = new System.Drawing.Point(62, 131);
            this.CrontabExpression.Name = "CrontabExpression";
            this.CrontabExpression.Size = new System.Drawing.Size(190, 20);
            this.CrontabExpression.TabIndex = 15;
            this.CrontabExpression.Text = "*";
            this.CrontabExpression.TextChanged += new System.EventHandler(this.CrontabExpression_TextChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(9, 134);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 13);
            this.label18.TabIndex = 14;
            this.label18.Text = "Full:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(126, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 13);
            this.label17.TabIndex = 13;
            this.label17.Text = "Day of Week";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(126, 66);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(37, 13);
            this.label16.TabIndex = 12;
            this.label16.Text = "Month";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(126, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Day of Month";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 13);
            this.label15.TabIndex = 10;
            this.label15.Text = "Hour:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Minute:";
            // 
            // CrontabDayOfWeek
            // 
            this.CrontabDayOfWeek.Location = new System.Drawing.Point(203, 89);
            this.CrontabDayOfWeek.Name = "CrontabDayOfWeek";
            this.CrontabDayOfWeek.Size = new System.Drawing.Size(49, 20);
            this.CrontabDayOfWeek.TabIndex = 8;
            this.CrontabDayOfWeek.Text = "*";
            // 
            // CrontabMonth
            // 
            this.CrontabMonth.Location = new System.Drawing.Point(203, 63);
            this.CrontabMonth.Name = "CrontabMonth";
            this.CrontabMonth.Size = new System.Drawing.Size(49, 20);
            this.CrontabMonth.TabIndex = 7;
            this.CrontabMonth.Text = "*";
            // 
            // CrontabDayOfMonth
            // 
            this.CrontabDayOfMonth.Location = new System.Drawing.Point(203, 37);
            this.CrontabDayOfMonth.Name = "CrontabDayOfMonth";
            this.CrontabDayOfMonth.Size = new System.Drawing.Size(49, 20);
            this.CrontabDayOfMonth.TabIndex = 6;
            this.CrontabDayOfMonth.Text = "*";
            // 
            // CrontabHours
            // 
            this.CrontabHours.Location = new System.Drawing.Point(62, 92);
            this.CrontabHours.Name = "CrontabHours";
            this.CrontabHours.Size = new System.Drawing.Size(49, 20);
            this.CrontabHours.TabIndex = 5;
            this.CrontabHours.Text = "*";
            // 
            // CrontabMinutes
            // 
            this.CrontabMinutes.Location = new System.Drawing.Point(62, 63);
            this.CrontabMinutes.Name = "CrontabMinutes";
            this.CrontabMinutes.Size = new System.Drawing.Size(49, 20);
            this.CrontabMinutes.TabIndex = 4;
            this.CrontabMinutes.Text = "*";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Second:";
            // 
            // CrontabSeconds
            // 
            this.CrontabSeconds.Location = new System.Drawing.Point(62, 37);
            this.CrontabSeconds.Name = "CrontabSeconds";
            this.CrontabSeconds.Size = new System.Drawing.Size(49, 20);
            this.CrontabSeconds.TabIndex = 1;
            this.CrontabSeconds.Text = "*";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(9, 9);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(140, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Quartz Crontab Expressions:";
            // 
            // RecurYearlyPanel
            // 
            this.RecurYearlyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.RecurYearlyPanel.Controls.Add(this.Schedule_YearlyMonth);
            this.RecurYearlyPanel.Controls.Add(this.label9);
            this.RecurYearlyPanel.Controls.Add(this.Schedule_YearlyDayOfWeek);
            this.RecurYearlyPanel.Controls.Add(this.Schedule_YearlyOrdinalDay);
            this.RecurYearlyPanel.Controls.Add(this.Schedule_YearlyDayButton);
            this.RecurYearlyPanel.Controls.Add(this.Schedule_YearlyEveryDate);
            this.RecurYearlyPanel.Controls.Add(this.Schedule_YearlyEveryDateButton);
            this.RecurYearlyPanel.Location = new System.Drawing.Point(15, 388);
            this.RecurYearlyPanel.Name = "RecurYearlyPanel";
            this.RecurYearlyPanel.Size = new System.Drawing.Size(268, 118);
            this.RecurYearlyPanel.TabIndex = 31;
            // 
            // Schedule_YearlyMonth
            // 
            this.Schedule_YearlyMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Schedule_YearlyMonth.FormattingEnabled = true;
            this.Schedule_YearlyMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.Schedule_YearlyMonth.Location = new System.Drawing.Point(64, 65);
            this.Schedule_YearlyMonth.Name = "Schedule_YearlyMonth";
            this.Schedule_YearlyMonth.Size = new System.Drawing.Size(80, 21);
            this.Schedule_YearlyMonth.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(16, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "of";
            // 
            // Schedule_YearlyDayOfWeek
            // 
            this.Schedule_YearlyDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Schedule_YearlyDayOfWeek.FormattingEnabled = true;
            this.Schedule_YearlyDayOfWeek.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.Schedule_YearlyDayOfWeek.Location = new System.Drawing.Point(150, 29);
            this.Schedule_YearlyDayOfWeek.Name = "Schedule_YearlyDayOfWeek";
            this.Schedule_YearlyDayOfWeek.Size = new System.Drawing.Size(80, 21);
            this.Schedule_YearlyDayOfWeek.TabIndex = 6;
            // 
            // Schedule_YearlyOrdinalDay
            // 
            this.Schedule_YearlyOrdinalDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Schedule_YearlyOrdinalDay.FormattingEnabled = true;
            this.Schedule_YearlyOrdinalDay.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Last"});
            this.Schedule_YearlyOrdinalDay.Location = new System.Drawing.Point(64, 29);
            this.Schedule_YearlyOrdinalDay.Name = "Schedule_YearlyOrdinalDay";
            this.Schedule_YearlyOrdinalDay.Size = new System.Drawing.Size(80, 21);
            this.Schedule_YearlyOrdinalDay.TabIndex = 5;
            // 
            // Schedule_YearlyDayButton
            // 
            this.Schedule_YearlyDayButton.AutoSize = true;
            this.Schedule_YearlyDayButton.Location = new System.Drawing.Point(6, 31);
            this.Schedule_YearlyDayButton.Name = "Schedule_YearlyDayButton";
            this.Schedule_YearlyDayButton.Size = new System.Drawing.Size(44, 17);
            this.Schedule_YearlyDayButton.TabIndex = 4;
            this.Schedule_YearlyDayButton.Text = "The";
            this.Schedule_YearlyDayButton.UseVisualStyleBackColor = true;
            this.Schedule_YearlyDayButton.CheckedChanged += new System.EventHandler(this.Schedule_YearlyDayButton_CheckedChanged);
            // 
            // Schedule_YearlyEveryDate
            // 
            this.Schedule_YearlyEveryDate.Location = new System.Drawing.Point(64, 3);
            this.Schedule_YearlyEveryDate.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.Schedule_YearlyEveryDate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Schedule_YearlyEveryDate.Name = "Schedule_YearlyEveryDate";
            this.Schedule_YearlyEveryDate.Size = new System.Drawing.Size(80, 20);
            this.Schedule_YearlyEveryDate.TabIndex = 3;
            this.Schedule_YearlyEveryDate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Schedule_YearlyEveryDateButton
            // 
            this.Schedule_YearlyEveryDateButton.AutoSize = true;
            this.Schedule_YearlyEveryDateButton.Checked = true;
            this.Schedule_YearlyEveryDateButton.Location = new System.Drawing.Point(6, 3);
            this.Schedule_YearlyEveryDateButton.Name = "Schedule_YearlyEveryDateButton";
            this.Schedule_YearlyEveryDateButton.Size = new System.Drawing.Size(52, 17);
            this.Schedule_YearlyEveryDateButton.TabIndex = 1;
            this.Schedule_YearlyEveryDateButton.TabStop = true;
            this.Schedule_YearlyEveryDateButton.Text = "Every";
            this.Schedule_YearlyEveryDateButton.UseVisualStyleBackColor = true;
            this.Schedule_YearlyEveryDateButton.CheckedChanged += new System.EventHandler(this.Schedule_YearlyEveryDateButton_CheckedChanged);
            // 
            // RecurMonthlyPanel
            // 
            this.RecurMonthlyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.RecurMonthlyPanel.Controls.Add(this.label8);
            this.RecurMonthlyPanel.Controls.Add(this.Schedule_MonthlyIntervalCount);
            this.RecurMonthlyPanel.Controls.Add(this.label7);
            this.RecurMonthlyPanel.Controls.Add(this.Schedule_MonthlyDayOfWeek);
            this.RecurMonthlyPanel.Controls.Add(this.Schedule_MonthlyOrdinalDay);
            this.RecurMonthlyPanel.Controls.Add(this.Schedule_MonthlyDayButton);
            this.RecurMonthlyPanel.Controls.Add(this.Schedule_MonthlyDate);
            this.RecurMonthlyPanel.Controls.Add(this.Schedule_MonthlyDateButton);
            this.RecurMonthlyPanel.Location = new System.Drawing.Point(15, 279);
            this.RecurMonthlyPanel.Name = "RecurMonthlyPanel";
            this.RecurMonthlyPanel.Size = new System.Drawing.Size(268, 103);
            this.RecurMonthlyPanel.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(147, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "months";
            // 
            // Schedule_MonthlyIntervalCount
            // 
            this.Schedule_MonthlyIntervalCount.Location = new System.Drawing.Point(64, 65);
            this.Schedule_MonthlyIntervalCount.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.Schedule_MonthlyIntervalCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Schedule_MonthlyIntervalCount.Name = "Schedule_MonthlyIntervalCount";
            this.Schedule_MonthlyIntervalCount.Size = new System.Drawing.Size(73, 20);
            this.Schedule_MonthlyIntervalCount.TabIndex = 4;
            this.Schedule_MonthlyIntervalCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "of every";
            // 
            // Schedule_MonthlyDayOfWeek
            // 
            this.Schedule_MonthlyDayOfWeek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Schedule_MonthlyDayOfWeek.FormattingEnabled = true;
            this.Schedule_MonthlyDayOfWeek.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.Schedule_MonthlyDayOfWeek.Location = new System.Drawing.Point(143, 29);
            this.Schedule_MonthlyDayOfWeek.Name = "Schedule_MonthlyDayOfWeek";
            this.Schedule_MonthlyDayOfWeek.Size = new System.Drawing.Size(73, 21);
            this.Schedule_MonthlyDayOfWeek.TabIndex = 4;
            // 
            // Schedule_MonthlyOrdinalDay
            // 
            this.Schedule_MonthlyOrdinalDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Schedule_MonthlyOrdinalDay.FormattingEnabled = true;
            this.Schedule_MonthlyOrdinalDay.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth",
            "Last"});
            this.Schedule_MonthlyOrdinalDay.Location = new System.Drawing.Point(64, 29);
            this.Schedule_MonthlyOrdinalDay.Name = "Schedule_MonthlyOrdinalDay";
            this.Schedule_MonthlyOrdinalDay.Size = new System.Drawing.Size(73, 21);
            this.Schedule_MonthlyOrdinalDay.TabIndex = 3;
            // 
            // Schedule_MonthlyDayButton
            // 
            this.Schedule_MonthlyDayButton.AutoSize = true;
            this.Schedule_MonthlyDayButton.Location = new System.Drawing.Point(6, 31);
            this.Schedule_MonthlyDayButton.Name = "Schedule_MonthlyDayButton";
            this.Schedule_MonthlyDayButton.Size = new System.Drawing.Size(44, 17);
            this.Schedule_MonthlyDayButton.TabIndex = 2;
            this.Schedule_MonthlyDayButton.TabStop = true;
            this.Schedule_MonthlyDayButton.Text = "The";
            this.Schedule_MonthlyDayButton.UseVisualStyleBackColor = true;
            this.Schedule_MonthlyDayButton.CheckedChanged += new System.EventHandler(this.Schedule_MonthlyDayButton_CheckedChanged);
            // 
            // Schedule_MonthlyDate
            // 
            this.Schedule_MonthlyDate.Location = new System.Drawing.Point(64, 3);
            this.Schedule_MonthlyDate.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.Schedule_MonthlyDate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Schedule_MonthlyDate.Name = "Schedule_MonthlyDate";
            this.Schedule_MonthlyDate.Size = new System.Drawing.Size(73, 20);
            this.Schedule_MonthlyDate.TabIndex = 1;
            this.Schedule_MonthlyDate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Schedule_MonthlyDateButton
            // 
            this.Schedule_MonthlyDateButton.AutoSize = true;
            this.Schedule_MonthlyDateButton.Checked = true;
            this.Schedule_MonthlyDateButton.Location = new System.Drawing.Point(6, 3);
            this.Schedule_MonthlyDateButton.Name = "Schedule_MonthlyDateButton";
            this.Schedule_MonthlyDateButton.Size = new System.Drawing.Size(44, 17);
            this.Schedule_MonthlyDateButton.TabIndex = 1;
            this.Schedule_MonthlyDateButton.TabStop = true;
            this.Schedule_MonthlyDateButton.Text = "Day";
            this.Schedule_MonthlyDateButton.UseVisualStyleBackColor = true;
            this.Schedule_MonthlyDateButton.CheckedChanged += new System.EventHandler(this.Schedule_MonthlyDateButton_CheckedChanged);
            // 
            // RecurFixedPanel
            // 
            this.RecurFixedPanel.Controls.Add(this.Schedule_OnceLabel);
            this.RecurFixedPanel.Controls.Add(this.Schedule_OnceUnit);
            this.RecurFixedPanel.Controls.Add(this.Schedule_OnceAmount);
            this.RecurFixedPanel.Location = new System.Drawing.Point(15, 19);
            this.RecurFixedPanel.Name = "RecurFixedPanel";
            this.RecurFixedPanel.Size = new System.Drawing.Size(268, 39);
            this.RecurFixedPanel.TabIndex = 27;
            // 
            // Schedule_OnceLabel
            // 
            this.Schedule_OnceLabel.AutoSize = true;
            this.Schedule_OnceLabel.Location = new System.Drawing.Point(3, 9);
            this.Schedule_OnceLabel.Name = "Schedule_OnceLabel";
            this.Schedule_OnceLabel.Size = new System.Drawing.Size(62, 13);
            this.Schedule_OnceLabel.TabIndex = 30;
            this.Schedule_OnceLabel.Text = "Once every";
            // 
            // Schedule_OnceUnit
            // 
            this.Schedule_OnceUnit.FormattingEnabled = true;
            this.Schedule_OnceUnit.Items.AddRange(new object[] {
            "Seconds",
            "Minutes",
            "Hours",
            "Days",
            "Weeks",
            "Months",
            "Quarters",
            "Years"});
            this.Schedule_OnceUnit.Location = new System.Drawing.Point(129, 7);
            this.Schedule_OnceUnit.Name = "Schedule_OnceUnit";
            this.Schedule_OnceUnit.Size = new System.Drawing.Size(83, 21);
            this.Schedule_OnceUnit.TabIndex = 2;
            // 
            // Schedule_OnceAmount
            // 
            this.Schedule_OnceAmount.Location = new System.Drawing.Point(71, 7);
            this.Schedule_OnceAmount.Maximum = new decimal(new int[] {
            366,
            0,
            0,
            0});
            this.Schedule_OnceAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Schedule_OnceAmount.Name = "Schedule_OnceAmount";
            this.Schedule_OnceAmount.Size = new System.Drawing.Size(52, 20);
            this.Schedule_OnceAmount.TabIndex = 1;
            this.Schedule_OnceAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RecurWeeklyPanel
            // 
            this.RecurWeeklyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklyLabel);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklySunday);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklySaturday);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklyFriday);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklyThursday);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklyWednesday);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklyTuesday);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklyMonday);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklyCountLabel);
            this.RecurWeeklyPanel.Controls.Add(this.Schedule_WeeklyIntervalCount);
            this.RecurWeeklyPanel.Location = new System.Drawing.Point(15, 143);
            this.RecurWeeklyPanel.Name = "RecurWeeklyPanel";
            this.RecurWeeklyPanel.Size = new System.Drawing.Size(268, 130);
            this.RecurWeeklyPanel.TabIndex = 29;
            // 
            // Schedule_WeeklyLabel
            // 
            this.Schedule_WeeklyLabel.AutoSize = true;
            this.Schedule_WeeklyLabel.Location = new System.Drawing.Point(5, 5);
            this.Schedule_WeeklyLabel.Name = "Schedule_WeeklyLabel";
            this.Schedule_WeeklyLabel.Size = new System.Drawing.Size(34, 13);
            this.Schedule_WeeklyLabel.TabIndex = 0;
            this.Schedule_WeeklyLabel.Text = "Every";
            // 
            // Schedule_WeeklySunday
            // 
            this.Schedule_WeeklySunday.AutoSize = true;
            this.Schedule_WeeklySunday.Location = new System.Drawing.Point(117, 49);
            this.Schedule_WeeklySunday.Name = "Schedule_WeeklySunday";
            this.Schedule_WeeklySunday.Size = new System.Drawing.Size(62, 17);
            this.Schedule_WeeklySunday.TabIndex = 8;
            this.Schedule_WeeklySunday.Text = "Sunday";
            this.Schedule_WeeklySunday.UseVisualStyleBackColor = true;
            // 
            // Schedule_WeeklySaturday
            // 
            this.Schedule_WeeklySaturday.AutoSize = true;
            this.Schedule_WeeklySaturday.Location = new System.Drawing.Point(117, 29);
            this.Schedule_WeeklySaturday.Name = "Schedule_WeeklySaturday";
            this.Schedule_WeeklySaturday.Size = new System.Drawing.Size(68, 17);
            this.Schedule_WeeklySaturday.TabIndex = 7;
            this.Schedule_WeeklySaturday.Text = "Saturday";
            this.Schedule_WeeklySaturday.UseVisualStyleBackColor = true;
            // 
            // Schedule_WeeklyFriday
            // 
            this.Schedule_WeeklyFriday.AutoSize = true;
            this.Schedule_WeeklyFriday.Location = new System.Drawing.Point(22, 110);
            this.Schedule_WeeklyFriday.Name = "Schedule_WeeklyFriday";
            this.Schedule_WeeklyFriday.Size = new System.Drawing.Size(54, 17);
            this.Schedule_WeeklyFriday.TabIndex = 6;
            this.Schedule_WeeklyFriday.Text = "Friday";
            this.Schedule_WeeklyFriday.UseVisualStyleBackColor = true;
            // 
            // Schedule_WeeklyThursday
            // 
            this.Schedule_WeeklyThursday.AutoSize = true;
            this.Schedule_WeeklyThursday.Location = new System.Drawing.Point(22, 89);
            this.Schedule_WeeklyThursday.Name = "Schedule_WeeklyThursday";
            this.Schedule_WeeklyThursday.Size = new System.Drawing.Size(70, 17);
            this.Schedule_WeeklyThursday.TabIndex = 5;
            this.Schedule_WeeklyThursday.Text = "Thursday";
            this.Schedule_WeeklyThursday.UseVisualStyleBackColor = true;
            // 
            // Schedule_WeeklyWednesday
            // 
            this.Schedule_WeeklyWednesday.AutoSize = true;
            this.Schedule_WeeklyWednesday.Location = new System.Drawing.Point(22, 69);
            this.Schedule_WeeklyWednesday.Name = "Schedule_WeeklyWednesday";
            this.Schedule_WeeklyWednesday.Size = new System.Drawing.Size(83, 17);
            this.Schedule_WeeklyWednesday.TabIndex = 4;
            this.Schedule_WeeklyWednesday.Text = "Wednesday";
            this.Schedule_WeeklyWednesday.UseVisualStyleBackColor = true;
            // 
            // Schedule_WeeklyTuesday
            // 
            this.Schedule_WeeklyTuesday.AutoSize = true;
            this.Schedule_WeeklyTuesday.Location = new System.Drawing.Point(22, 49);
            this.Schedule_WeeklyTuesday.Name = "Schedule_WeeklyTuesday";
            this.Schedule_WeeklyTuesday.Size = new System.Drawing.Size(67, 17);
            this.Schedule_WeeklyTuesday.TabIndex = 3;
            this.Schedule_WeeklyTuesday.Text = "Tuesday";
            this.Schedule_WeeklyTuesday.UseVisualStyleBackColor = true;
            // 
            // Schedule_WeeklyMonday
            // 
            this.Schedule_WeeklyMonday.AutoSize = true;
            this.Schedule_WeeklyMonday.Location = new System.Drawing.Point(22, 29);
            this.Schedule_WeeklyMonday.Name = "Schedule_WeeklyMonday";
            this.Schedule_WeeklyMonday.Size = new System.Drawing.Size(64, 17);
            this.Schedule_WeeklyMonday.TabIndex = 2;
            this.Schedule_WeeklyMonday.Text = "Monday";
            this.Schedule_WeeklyMonday.UseVisualStyleBackColor = true;
            // 
            // Schedule_WeeklyCountLabel
            // 
            this.Schedule_WeeklyCountLabel.AutoSize = true;
            this.Schedule_WeeklyCountLabel.Location = new System.Drawing.Point(103, 5);
            this.Schedule_WeeklyCountLabel.Name = "Schedule_WeeklyCountLabel";
            this.Schedule_WeeklyCountLabel.Size = new System.Drawing.Size(59, 13);
            this.Schedule_WeeklyCountLabel.TabIndex = 0;
            this.Schedule_WeeklyCountLabel.Text = "week(s) on";
            // 
            // Schedule_WeeklyIntervalCount
            // 
            this.Schedule_WeeklyIntervalCount.Location = new System.Drawing.Point(45, 2);
            this.Schedule_WeeklyIntervalCount.Maximum = new decimal(new int[] {
            52,
            0,
            0,
            0});
            this.Schedule_WeeklyIntervalCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Schedule_WeeklyIntervalCount.Name = "Schedule_WeeklyIntervalCount";
            this.Schedule_WeeklyIntervalCount.Size = new System.Drawing.Size(52, 20);
            this.Schedule_WeeklyIntervalCount.TabIndex = 1;
            this.Schedule_WeeklyIntervalCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // RecurDailyPanel
            // 
            this.RecurDailyPanel.BackColor = System.Drawing.SystemColors.Control;
            this.RecurDailyPanel.Controls.Add(this.Schedule_DailyEveryWeekday);
            this.RecurDailyPanel.Controls.Add(this.Schedule_DailyEveryDay);
            this.RecurDailyPanel.Controls.Add(this.Schedule_DailyInterval);
            this.RecurDailyPanel.Controls.Add(this.Schedule_DailySkipDaysCountLabel);
            this.RecurDailyPanel.Controls.Add(this.Schedule_DailyIntervalCount);
            this.RecurDailyPanel.Location = new System.Drawing.Point(15, 64);
            this.RecurDailyPanel.Name = "RecurDailyPanel";
            this.RecurDailyPanel.Size = new System.Drawing.Size(268, 73);
            this.RecurDailyPanel.TabIndex = 28;
            // 
            // Schedule_DailyEveryWeekday
            // 
            this.Schedule_DailyEveryWeekday.AutoSize = true;
            this.Schedule_DailyEveryWeekday.Location = new System.Drawing.Point(6, 26);
            this.Schedule_DailyEveryWeekday.Name = "Schedule_DailyEveryWeekday";
            this.Schedule_DailyEveryWeekday.Size = new System.Drawing.Size(96, 17);
            this.Schedule_DailyEveryWeekday.TabIndex = 2;
            this.Schedule_DailyEveryWeekday.Text = "Each weekday";
            this.Schedule_DailyEveryWeekday.UseVisualStyleBackColor = true;
            this.Schedule_DailyEveryWeekday.CheckedChanged += new System.EventHandler(this.Schedule_DailyEveryWeekday_CheckedChanged);
            // 
            // Schedule_DailyEveryDay
            // 
            this.Schedule_DailyEveryDay.AutoSize = true;
            this.Schedule_DailyEveryDay.Checked = true;
            this.Schedule_DailyEveryDay.Location = new System.Drawing.Point(6, 3);
            this.Schedule_DailyEveryDay.Name = "Schedule_DailyEveryDay";
            this.Schedule_DailyEveryDay.Size = new System.Drawing.Size(72, 17);
            this.Schedule_DailyEveryDay.TabIndex = 1;
            this.Schedule_DailyEveryDay.TabStop = true;
            this.Schedule_DailyEveryDay.Text = "Every day";
            this.Schedule_DailyEveryDay.UseVisualStyleBackColor = true;
            this.Schedule_DailyEveryDay.CheckedChanged += new System.EventHandler(this.Schedule_DailyEveryDay_CheckedChanged);
            // 
            // Schedule_DailyInterval
            // 
            this.Schedule_DailyInterval.AutoSize = true;
            this.Schedule_DailyInterval.Location = new System.Drawing.Point(6, 48);
            this.Schedule_DailyInterval.Name = "Schedule_DailyInterval";
            this.Schedule_DailyInterval.Size = new System.Drawing.Size(80, 17);
            this.Schedule_DailyInterval.TabIndex = 3;
            this.Schedule_DailyInterval.Text = "Once every";
            this.Schedule_DailyInterval.UseVisualStyleBackColor = true;
            this.Schedule_DailyInterval.CheckedChanged += new System.EventHandler(this.Schedule_DailySkipDays_CheckedChanged);
            // 
            // Schedule_DailySkipDaysCountLabel
            // 
            this.Schedule_DailySkipDaysCountLabel.AutoSize = true;
            this.Schedule_DailySkipDaysCountLabel.Location = new System.Drawing.Point(150, 52);
            this.Schedule_DailySkipDaysCountLabel.Name = "Schedule_DailySkipDaysCountLabel";
            this.Schedule_DailySkipDaysCountLabel.Size = new System.Drawing.Size(29, 13);
            this.Schedule_DailySkipDaysCountLabel.TabIndex = 32;
            this.Schedule_DailySkipDaysCountLabel.Text = "days";
            // 
            // Schedule_DailyIntervalCount
            // 
            this.Schedule_DailyIntervalCount.Location = new System.Drawing.Point(92, 48);
            this.Schedule_DailyIntervalCount.Maximum = new decimal(new int[] {
            366,
            0,
            0,
            0});
            this.Schedule_DailyIntervalCount.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Schedule_DailyIntervalCount.Name = "Schedule_DailyIntervalCount";
            this.Schedule_DailyIntervalCount.Size = new System.Drawing.Size(52, 20);
            this.Schedule_DailyIntervalCount.TabIndex = 4;
            this.Schedule_DailyIntervalCount.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // DurationTab
            // 
            this.DurationTab.Controls.Add(this.Duration_StopAfterTime);
            this.DurationTab.Controls.Add(this.label4);
            this.DurationTab.Controls.Add(this.Duration_StopAfterCount);
            this.DurationTab.Controls.Add(this.Duration_StopAfterCountButton);
            this.DurationTab.Controls.Add(this.Duration_RunIndefinitelyButton);
            this.DurationTab.Controls.Add(this.Duration_StopAfterTimeButton);
            this.DurationTab.Location = new System.Drawing.Point(4, 22);
            this.DurationTab.Name = "DurationTab";
            this.DurationTab.Padding = new System.Windows.Forms.Padding(3);
            this.DurationTab.Size = new System.Drawing.Size(407, 218);
            this.DurationTab.TabIndex = 3;
            this.DurationTab.Text = "Duration";
            this.DurationTab.UseVisualStyleBackColor = true;
            // 
            // Duration_StopAfterTime
            // 
            this.Duration_StopAfterTime.Enabled = false;
            this.Duration_StopAfterTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Duration_StopAfterTime.Location = new System.Drawing.Point(95, 64);
            this.Duration_StopAfterTime.Name = "Duration_StopAfterTime";
            this.Duration_StopAfterTime.Size = new System.Drawing.Size(133, 20);
            this.Duration_StopAfterTime.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(148, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "occurrences";
            // 
            // Duration_StopAfterCount
            // 
            this.Duration_StopAfterCount.Enabled = false;
            this.Duration_StopAfterCount.Location = new System.Drawing.Point(95, 38);
            this.Duration_StopAfterCount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Duration_StopAfterCount.Name = "Duration_StopAfterCount";
            this.Duration_StopAfterCount.Size = new System.Drawing.Size(47, 20);
            this.Duration_StopAfterCount.TabIndex = 8;
            this.Duration_StopAfterCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Duration_StopAfterCountButton
            // 
            this.Duration_StopAfterCountButton.AutoSize = true;
            this.Duration_StopAfterCountButton.Location = new System.Drawing.Point(18, 41);
            this.Duration_StopAfterCountButton.Name = "Duration_StopAfterCountButton";
            this.Duration_StopAfterCountButton.Size = new System.Drawing.Size(71, 17);
            this.Duration_StopAfterCountButton.TabIndex = 7;
            this.Duration_StopAfterCountButton.Text = "Stop after";
            this.Duration_StopAfterCountButton.UseVisualStyleBackColor = true;
            this.Duration_StopAfterCountButton.CheckedChanged += new System.EventHandler(this.Duration_StopAfterCountButton_CheckedChanged);
            // 
            // Duration_RunIndefinitelyButton
            // 
            this.Duration_RunIndefinitelyButton.AutoSize = true;
            this.Duration_RunIndefinitelyButton.Checked = true;
            this.Duration_RunIndefinitelyButton.Location = new System.Drawing.Point(18, 18);
            this.Duration_RunIndefinitelyButton.Name = "Duration_RunIndefinitelyButton";
            this.Duration_RunIndefinitelyButton.Size = new System.Drawing.Size(98, 17);
            this.Duration_RunIndefinitelyButton.TabIndex = 6;
            this.Duration_RunIndefinitelyButton.TabStop = true;
            this.Duration_RunIndefinitelyButton.Text = "Run Indefinitely";
            this.Duration_RunIndefinitelyButton.UseVisualStyleBackColor = true;
            this.Duration_RunIndefinitelyButton.CheckedChanged += new System.EventHandler(this.Duration_RunIndefinitelyButton_CheckedChanged);
            // 
            // Duration_StopAfterTimeButton
            // 
            this.Duration_StopAfterTimeButton.AutoSize = true;
            this.Duration_StopAfterTimeButton.Location = new System.Drawing.Point(18, 64);
            this.Duration_StopAfterTimeButton.Name = "Duration_StopAfterTimeButton";
            this.Duration_StopAfterTimeButton.Size = new System.Drawing.Size(71, 17);
            this.Duration_StopAfterTimeButton.TabIndex = 9;
            this.Duration_StopAfterTimeButton.Text = "Stop after";
            this.Duration_StopAfterTimeButton.UseVisualStyleBackColor = true;
            this.Duration_StopAfterTimeButton.CheckedChanged += new System.EventHandler(this.Duration_StopAfterTimeButton_CheckedChanged);
            // 
            // PreviewTab
            // 
            this.PreviewTab.Controls.Add(this.richTextBox1);
            this.PreviewTab.Location = new System.Drawing.Point(4, 22);
            this.PreviewTab.Name = "PreviewTab";
            this.PreviewTab.Padding = new System.Windows.Forms.Padding(3);
            this.PreviewTab.Size = new System.Drawing.Size(407, 218);
            this.PreviewTab.TabIndex = 4;
            this.PreviewTab.Text = "Preview";
            this.PreviewTab.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(16, 16);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(376, 192);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // Event
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(440, 293);
            this.Controls.Add(this.EventTabControl);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.AcceptDialogButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Event";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Event Details";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Event_FormClosing);
            this.Load += new System.EventHandler(this.Event_Load);
            this.EventTabControl.ResumeLayout(false);
            this.EventTab.ResumeLayout(false);
            this.EventTab.PerformLayout();
            this.ReminderTab.ResumeLayout(false);
            this.ReminderTab.PerformLayout();
            this.Reminder_NotificationGroupBox.ResumeLayout(false);
            this.Reminder_NotificationGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reminder_TimeAmount)).EndInit();
            this.ScheduleTab.ResumeLayout(false);
            this.ScheduleTab.PerformLayout();
            this.HiddenTab.ResumeLayout(false);
            this.PanelCorral.ResumeLayout(false);
            this.RecurCronPanel.ResumeLayout(false);
            this.RecurCronPanel.PerformLayout();
            this.RecurYearlyPanel.ResumeLayout(false);
            this.RecurYearlyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_YearlyEveryDate)).EndInit();
            this.RecurMonthlyPanel.ResumeLayout(false);
            this.RecurMonthlyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_MonthlyIntervalCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_MonthlyDate)).EndInit();
            this.RecurFixedPanel.ResumeLayout(false);
            this.RecurFixedPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_OnceAmount)).EndInit();
            this.RecurWeeklyPanel.ResumeLayout(false);
            this.RecurWeeklyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_WeeklyIntervalCount)).EndInit();
            this.RecurDailyPanel.ResumeLayout(false);
            this.RecurDailyPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Schedule_DailyIntervalCount)).EndInit();
            this.DurationTab.ResumeLayout(false);
            this.DurationTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Duration_StopAfterCount)).EndInit();
            this.PreviewTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button AcceptDialogButton;
        internal System.Windows.Forms.DateTimePicker EventNextOccurrence;
        private System.Windows.Forms.RichTextBox EventDescription;
        private System.Windows.Forms.TextBox EventName;
        private System.Windows.Forms.TabControl EventTabControl;
        private System.Windows.Forms.TabPage EventTab;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TabPage ScheduleTab;
        private System.Windows.Forms.Label NextOccurrenceLabel;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.ComboBox EventGroupList;
        private System.Windows.Forms.TabPage HiddenTab;
        private System.Windows.Forms.Panel RecurWeeklyPanel;
        private System.Windows.Forms.Panel RecurDailyPanel;
        private System.Windows.Forms.Panel RecurFixedPanel;
        private System.Windows.Forms.ComboBox Schedule_OnceUnit;
        private System.Windows.Forms.NumericUpDown Schedule_OnceAmount;
        private System.Windows.Forms.GroupBox PanelCorral;
        private System.Windows.Forms.TabPage DurationTab;
        private System.Windows.Forms.Panel RecurYearlyPanel;
        private System.Windows.Forms.Panel RecurMonthlyPanel;
        private System.Windows.Forms.Label Schedule_OnceLabel;
        private System.Windows.Forms.RadioButton Schedule_DailyEveryDay;
        private System.Windows.Forms.RadioButton Schedule_DailyInterval;
        private System.Windows.Forms.Label Schedule_DailySkipDaysCountLabel;
        private System.Windows.Forms.NumericUpDown Schedule_DailyIntervalCount;
        private System.Windows.Forms.CheckBox Schedule_WeeklySunday;
        private System.Windows.Forms.CheckBox Schedule_WeeklySaturday;
        private System.Windows.Forms.CheckBox Schedule_WeeklyFriday;
        private System.Windows.Forms.CheckBox Schedule_WeeklyThursday;
        private System.Windows.Forms.CheckBox Schedule_WeeklyWednesday;
        private System.Windows.Forms.CheckBox Schedule_WeeklyTuesday;
        private System.Windows.Forms.CheckBox Schedule_WeeklyMonday;
        private System.Windows.Forms.Label Schedule_WeeklyCountLabel;
        private System.Windows.Forms.NumericUpDown Schedule_WeeklyIntervalCount;
        private System.Windows.Forms.Label Schedule_WeeklyLabel;
        private System.Windows.Forms.ComboBox Schedule_MonthlyDayOfWeek;
        private System.Windows.Forms.ComboBox Schedule_MonthlyOrdinalDay;
        private System.Windows.Forms.RadioButton Schedule_MonthlyDayButton;
        private System.Windows.Forms.NumericUpDown Schedule_MonthlyDate;
        private System.Windows.Forms.RadioButton Schedule_MonthlyDateButton;
        private System.Windows.Forms.ComboBox Schedule_YearlyMonth;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox Schedule_YearlyDayOfWeek;
        private System.Windows.Forms.ComboBox Schedule_YearlyOrdinalDay;
        private System.Windows.Forms.RadioButton Schedule_YearlyDayButton;
        private System.Windows.Forms.NumericUpDown Schedule_YearlyEveryDate;
        private System.Windows.Forms.RadioButton Schedule_YearlyEveryDateButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown Schedule_MonthlyIntervalCount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton Schedule_DailyEveryWeekday;
        private System.Windows.Forms.TabPage PreviewTab;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TabPage ReminderTab;
        private System.Windows.Forms.Label Reminder_ReminderLabel;
        private System.Windows.Forms.ComboBox Reminder_NotifyCarrierList;
        private System.Windows.Forms.TextBox Reminder_NotifyPhoneNumber;
        private System.Windows.Forms.CheckBox Reminder_NotifyViaSMS;
        private System.Windows.Forms.TextBox Reminder_NotifyEmailAddress;
        private System.Windows.Forms.CheckBox Reminder_NotifyViaEmail;
        private System.Windows.Forms.CheckBox Reminder_NotifyViaAudio;
        private System.Windows.Forms.CheckBox Reminder_NotifyViaTray;
        private System.Windows.Forms.ComboBox Reminder_TimeUnit;
        private System.Windows.Forms.NumericUpDown Reminder_TimeAmount;
        private System.Windows.Forms.ComboBox Reminder_NotifyAudioFile;
        private System.Windows.Forms.Panel RecurCronPanel;
        private System.Windows.Forms.TextBox CrontabSeconds;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox Reminder_NotificationGroupBox;
        private System.Windows.Forms.RadioButton Reminder_RemindMeButton;
        private System.Windows.Forms.RadioButton Reminder_DontRemindMeButton;
        private System.Windows.Forms.RadioButton RecurCronRadioButton;
        private System.Windows.Forms.Label ThenLabel;
        private System.Windows.Forms.DateTimePicker EventNextOccurrenceCopy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton RecurNoneRadioButton;
        private System.Windows.Forms.RadioButton RecurFixedRadioButton;
        private System.Windows.Forms.RadioButton RecurYearlyRadioButton;
        private System.Windows.Forms.RadioButton RecurDailyRadioButton;
        private System.Windows.Forms.RadioButton RecurWeeklyRadioButton;
        private System.Windows.Forms.RadioButton RecurMonthlyRadioButton;
        private System.Windows.Forms.Panel TargetPanel;
        private System.Windows.Forms.DateTimePicker Duration_StopAfterTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown Duration_StopAfterCount;
        private System.Windows.Forms.RadioButton Duration_StopAfterCountButton;
        private System.Windows.Forms.RadioButton Duration_RunIndefinitelyButton;
        private System.Windows.Forms.RadioButton Duration_StopAfterTimeButton;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox CrontabDayOfWeek;
        private System.Windows.Forms.TextBox CrontabMonth;
        private System.Windows.Forms.TextBox CrontabDayOfMonth;
        private System.Windows.Forms.TextBox CrontabHours;
        private System.Windows.Forms.TextBox CrontabMinutes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox CrontabExpression;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox Reminder_NotifyTrayMessage;
    }
}