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
            this.GroupLabel = new System.Windows.Forms.Label();
            this.EventGroupList = new System.Windows.Forms.ComboBox();
            this.NextOccurrenceLabel = new System.Windows.Forms.Label();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ReminderButton = new System.Windows.Forms.Button();
            this.SchedulerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(312, 205);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 9;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.Click += new System.EventHandler(this.CancelDialogButton_Click);
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(231, 205);
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
            this.EventNextOccurrence.Location = new System.Drawing.Point(108, 170);
            this.EventNextOccurrence.Name = "EventNextOccurrence";
            this.EventNextOccurrence.Size = new System.Drawing.Size(279, 20);
            this.EventNextOccurrence.TabIndex = 4;
            // 
            // EventDescription
            // 
            this.EventDescription.Location = new System.Drawing.Point(108, 41);
            this.EventDescription.Name = "EventDescription";
            this.EventDescription.Size = new System.Drawing.Size(279, 96);
            this.EventDescription.TabIndex = 2;
            this.EventDescription.Text = "";
            // 
            // EventName
            // 
            this.EventName.Location = new System.Drawing.Point(108, 15);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(279, 20);
            this.EventName.TabIndex = 1;
            // 
            // GroupLabel
            // 
            this.GroupLabel.AutoSize = true;
            this.GroupLabel.Location = new System.Drawing.Point(12, 146);
            this.GroupLabel.Name = "GroupLabel";
            this.GroupLabel.Size = new System.Drawing.Size(70, 13);
            this.GroupLabel.TabIndex = 20;
            this.GroupLabel.Text = "Event Group:";
            // 
            // EventGroupList
            // 
            this.EventGroupList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EventGroupList.FormattingEnabled = true;
            this.EventGroupList.Location = new System.Drawing.Point(108, 143);
            this.EventGroupList.Name = "EventGroupList";
            this.EventGroupList.Size = new System.Drawing.Size(279, 21);
            this.EventGroupList.TabIndex = 3;
            // 
            // NextOccurrenceLabel
            // 
            this.NextOccurrenceLabel.AutoSize = true;
            this.NextOccurrenceLabel.Location = new System.Drawing.Point(12, 173);
            this.NextOccurrenceLabel.Name = "NextOccurrenceLabel";
            this.NextOccurrenceLabel.Size = new System.Drawing.Size(80, 13);
            this.NextOccurrenceLabel.TabIndex = 9;
            this.NextOccurrenceLabel.Text = "Date and Time:";
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 44);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 8;
            this.DescriptionLabel.Text = "Description:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 18);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "Name:";
            // 
            // ReminderButton
            // 
            this.ReminderButton.Location = new System.Drawing.Point(15, 205);
            this.ReminderButton.Name = "ReminderButton";
            this.ReminderButton.Size = new System.Drawing.Size(75, 23);
            this.ReminderButton.TabIndex = 21;
            this.ReminderButton.Text = "Reminder...";
            this.ReminderButton.UseVisualStyleBackColor = true;
            this.ReminderButton.Click += new System.EventHandler(this.ReminderButton_Click);
            // 
            // SchedulerButton
            // 
            this.SchedulerButton.Location = new System.Drawing.Point(96, 205);
            this.SchedulerButton.Name = "SchedulerButton";
            this.SchedulerButton.Size = new System.Drawing.Size(75, 23);
            this.SchedulerButton.TabIndex = 22;
            this.SchedulerButton.Text = "Schedule...";
            this.SchedulerButton.UseVisualStyleBackColor = true;
            this.SchedulerButton.Click += new System.EventHandler(this.SchedulerButton_Click);
            // 
            // Reminder
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(402, 240);
            this.Controls.Add(this.SchedulerButton);
            this.Controls.Add(this.ReminderButton);
            this.Controls.Add(this.GroupLabel);
            this.Controls.Add(this.EventGroupList);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.NextOccurrenceLabel);
            this.Controls.Add(this.AcceptDialogButton);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.EventName);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.EventDescription);
            this.Controls.Add(this.EventNextOccurrence);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Reminder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Event";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Event_FormClosing);
            this.Load += new System.EventHandler(this.Event_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button AcceptDialogButton;
        internal System.Windows.Forms.DateTimePicker EventNextOccurrence;
        private System.Windows.Forms.RichTextBox EventDescription;
        private System.Windows.Forms.TextBox EventName;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label NextOccurrenceLabel;
        private System.Windows.Forms.Label GroupLabel;
        private System.Windows.Forms.ComboBox EventGroupList;
        private System.Windows.Forms.Button ReminderButton;
        private System.Windows.Forms.Button SchedulerButton;
    }
}