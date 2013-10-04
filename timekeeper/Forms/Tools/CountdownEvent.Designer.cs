namespace Timekeeper.Forms.Tools
{
    partial class CountdownEvent
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
            this.EventName = new System.Windows.Forms.TextBox();
            this.EventDescription = new System.Windows.Forms.RichTextBox();
            this.EventDateTime = new System.Windows.Forms.DateTimePicker();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButtno = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EventName
            // 
            this.EventName.Location = new System.Drawing.Point(99, 12);
            this.EventName.Name = "EventName";
            this.EventName.Size = new System.Drawing.Size(239, 20);
            this.EventName.TabIndex = 0;
            // 
            // EventDescription
            // 
            this.EventDescription.Location = new System.Drawing.Point(99, 38);
            this.EventDescription.Name = "EventDescription";
            this.EventDescription.Size = new System.Drawing.Size(239, 96);
            this.EventDescription.TabIndex = 1;
            this.EventDescription.Text = "";
            // 
            // EventDateTime
            // 
            this.EventDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EventDateTime.Location = new System.Drawing.Point(99, 140);
            this.EventDateTime.Name = "EventDateTime";
            this.EventDateTime.Size = new System.Drawing.Size(239, 20);
            this.EventDateTime.TabIndex = 2;
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(182, 182);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 3;
            this.AcceptDialogButton.Text = "OK";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // CancelDialogButtno
            // 
            this.CancelDialogButtno.Location = new System.Drawing.Point(263, 182);
            this.CancelDialogButtno.Name = "CancelDialogButtno";
            this.CancelDialogButtno.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButtno.TabIndex = 4;
            this.CancelDialogButtno.Text = "Cancel";
            this.CancelDialogButtno.UseVisualStyleBackColor = true;
            // 
            // CountdownEvent
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButtno;
            this.ClientSize = new System.Drawing.Size(359, 217);
            this.Controls.Add(this.CancelDialogButtno);
            this.Controls.Add(this.AcceptDialogButton);
            this.Controls.Add(this.EventDateTime);
            this.Controls.Add(this.EventDescription);
            this.Controls.Add(this.EventName);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CountdownEvent";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Event";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CountdownEvent_FormClosing);
            this.Load += new System.EventHandler(this.CountdownEvent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox EventName;
        private System.Windows.Forms.RichTextBox EventDescription;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.Button CancelDialogButtno;
        internal System.Windows.Forms.DateTimePicker EventDateTime;

    }
}