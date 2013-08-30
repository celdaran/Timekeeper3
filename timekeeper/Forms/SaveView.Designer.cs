namespace Timekeeper.Forms
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
            this.ViewName = new System.Windows.Forms.TextBox();
            this.ViewDescription = new System.Windows.Forms.TextBox();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewName
            // 
            this.ViewName.Location = new System.Drawing.Point(81, 12);
            this.ViewName.Name = "ViewName";
            this.ViewName.Size = new System.Drawing.Size(270, 20);
            this.ViewName.TabIndex = 0;
            // 
            // ViewDescription
            // 
            this.ViewDescription.Location = new System.Drawing.Point(81, 38);
            this.ViewDescription.Multiline = true;
            this.ViewDescription.Name = "ViewDescription";
            this.ViewDescription.Size = new System.Drawing.Size(270, 61);
            this.ViewDescription.TabIndex = 1;
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(159, 140);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 2;
            this.AcceptDialogButton.Text = "button1";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(306, 139);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 3;
            this.CancelDialogButton.Text = "button1";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // SaveView
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(461, 217);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.AcceptDialogButton);
            this.Controls.Add(this.ViewDescription);
            this.Controls.Add(this.ViewName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SaveView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Save View";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        internal System.Windows.Forms.TextBox ViewName;
        internal System.Windows.Forms.TextBox ViewDescription;
    }
}