namespace Timekeeper.Forms.Shared
{
    partial class SaveView
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
            if (disposing && (components != null))
            {
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
            this.ViewName = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.ViewDescription = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ViewName
            // 
            this.ViewName.Location = new System.Drawing.Point(83, 12);
            this.ViewName.Name = "ViewName";
            this.ViewName.Size = new System.Drawing.Size(191, 20);
            this.ViewName.TabIndex = 1;
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(12, 41);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.DescriptionLabel.TabIndex = 3;
            this.DescriptionLabel.Text = "Description:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 15);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Name:";
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(120, 116);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 4;
            this.AcceptDialogButton.Text = "&OK";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            this.AcceptDialogButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(201, 116);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 5;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            this.CancelDialogButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // ViewDescription
            // 
            this.ViewDescription.AcceptsTab = true;
            this.ViewDescription.Location = new System.Drawing.Point(83, 38);
            this.ViewDescription.Name = "ViewDescription";
            this.ViewDescription.Size = new System.Drawing.Size(191, 64);
            this.ViewDescription.TabIndex = 2;
            this.ViewDescription.Text = "";
            // 
            // SaveView
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(288, 151);
            this.Controls.Add(this.ViewDescription);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.AcceptDialogButton);
            this.Controls.Add(this.ViewName);
            this.Controls.Add(this.DescriptionLabel);
            this.Controls.Add(this.NameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save View";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SaveView_FormClosing);
            this.Click += new System.EventHandler(this.CancelDialogButton_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        internal System.Windows.Forms.TextBox ViewName;
        internal System.Windows.Forms.RichTextBox ViewDescription;
    }
}