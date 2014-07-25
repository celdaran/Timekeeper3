namespace Timekeeper.Forms.Tools
{
    partial class EditEventGroup
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
            this.NameLabel = new System.Windows.Forms.Label();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.EventGroupDescription = new System.Windows.Forms.RichTextBox();
            this.EventGroupName = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 15);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(120, 116);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 2;
            this.AcceptDialogButton.Text = "&OK";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(201, 116);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 3;
            this.CancelDialogButton.Text = "&Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // EventGroupDescription
            // 
            this.EventGroupDescription.AcceptsTab = true;
            this.EventGroupDescription.Location = new System.Drawing.Point(83, 38);
            this.EventGroupDescription.Name = "EventGroupDescription";
            this.EventGroupDescription.Size = new System.Drawing.Size(191, 64);
            this.EventGroupDescription.TabIndex = 6;
            this.EventGroupDescription.Text = "";
            // 
            // EventGroupName
            // 
            this.EventGroupName.Location = new System.Drawing.Point(83, 12);
            this.EventGroupName.Name = "EventGroupName";
            this.EventGroupName.Size = new System.Drawing.Size(191, 20);
            this.EventGroupName.TabIndex = 5;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 41);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 7;
            this.DescriptionLabel.Text = "Description:";
            // 
            // EditEventGroup
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(288, 151);
            this.Controls.Add(this.EventGroupDescription);
            this.Controls.Add(this.EventGroupName);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.AcceptDialogButton);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditEventGroup";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Event Group";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        internal System.Windows.Forms.RichTextBox EventGroupDescription;
        internal System.Windows.Forms.TextBox EventGroupName;
        private System.Windows.Forms.Label DescriptionLabel;
    }
}