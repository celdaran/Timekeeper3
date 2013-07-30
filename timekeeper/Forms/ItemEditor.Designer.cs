namespace Timekeeper
{
    partial class ItemEditor
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
            this.AcceptDialog = new System.Windows.Forms.Button();
            this.CancelDialog = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.FunctionalPanel = new System.Windows.Forms.Panel();
            this.ItemExternalProjectNo = new System.Windows.Forms.TextBox();
            this.ExternalProjectNoLabel = new System.Windows.Forms.Label();
            this.ItemParent = new System.Windows.Forms.ListBox();
            this.FolderLabel = new System.Windows.Forms.Label();
            this.ItemDescription = new System.Windows.Forms.TextBox();
            this.ItemName = new System.Windows.Forms.TextBox();
            this.DescriptionLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ButtonPanel.SuspendLayout();
            this.FunctionalPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AcceptDialog
            // 
            this.AcceptDialog.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AcceptDialog.Location = new System.Drawing.Point(234, 6);
            this.AcceptDialog.Name = "AcceptDialog";
            this.AcceptDialog.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialog.TabIndex = 7;
            this.AcceptDialog.Text = "Save";
            this.AcceptDialog.UseVisualStyleBackColor = true;
            this.AcceptDialog.Click += new System.EventHandler(this.AcceptDialog_Click);
            this.AcceptDialog.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // CancelDialog
            // 
            this.CancelDialog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialog.Location = new System.Drawing.Point(315, 6);
            this.CancelDialog.Name = "CancelDialog";
            this.CancelDialog.Size = new System.Drawing.Size(75, 23);
            this.CancelDialog.TabIndex = 8;
            this.CancelDialog.Text = "Cancel";
            this.CancelDialog.UseVisualStyleBackColor = true;
            this.CancelDialog.Click += new System.EventHandler(this.CancelDialog_Click);
            this.CancelDialog.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.AcceptDialog);
            this.ButtonPanel.Controls.Add(this.CancelDialog);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 202);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(406, 39);
            this.ButtonPanel.TabIndex = 6;
            // 
            // FunctionalPanel
            // 
            this.FunctionalPanel.Controls.Add(this.ItemExternalProjectNo);
            this.FunctionalPanel.Controls.Add(this.ExternalProjectNoLabel);
            this.FunctionalPanel.Controls.Add(this.ItemParent);
            this.FunctionalPanel.Controls.Add(this.FolderLabel);
            this.FunctionalPanel.Controls.Add(this.ItemDescription);
            this.FunctionalPanel.Controls.Add(this.ItemName);
            this.FunctionalPanel.Controls.Add(this.DescriptionLabel);
            this.FunctionalPanel.Controls.Add(this.NameLabel);
            this.FunctionalPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FunctionalPanel.Location = new System.Drawing.Point(0, 0);
            this.FunctionalPanel.Name = "FunctionalPanel";
            this.FunctionalPanel.Size = new System.Drawing.Size(406, 202);
            this.FunctionalPanel.TabIndex = 1;
            // 
            // ItemExternalProjectNo
            // 
            this.ItemExternalProjectNo.Location = new System.Drawing.Point(78, 175);
            this.ItemExternalProjectNo.Name = "ItemExternalProjectNo";
            this.ItemExternalProjectNo.Size = new System.Drawing.Size(310, 20);
            this.ItemExternalProjectNo.TabIndex = 5;
            this.ItemExternalProjectNo.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // ExternalProjectNoLabel
            // 
            this.ExternalProjectNoLabel.AutoSize = true;
            this.ExternalProjectNoLabel.Location = new System.Drawing.Point(10, 178);
            this.ExternalProjectNoLabel.Name = "ExternalProjectNoLabel";
            this.ExternalProjectNoLabel.Size = new System.Drawing.Size(57, 13);
            this.ExternalProjectNoLabel.TabIndex = 15;
            this.ExternalProjectNoLabel.Text = "E&xternal Id";
            // 
            // ItemParent
            // 
            this.ItemParent.FormattingEnabled = true;
            this.ItemParent.Location = new System.Drawing.Point(78, 71);
            this.ItemParent.Name = "ItemParent";
            this.ItemParent.Size = new System.Drawing.Size(310, 95);
            this.ItemParent.TabIndex = 4;
            this.ItemParent.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // FolderLabel
            // 
            this.FolderLabel.AutoSize = true;
            this.FolderLabel.Location = new System.Drawing.Point(10, 71);
            this.FolderLabel.Name = "FolderLabel";
            this.FolderLabel.Size = new System.Drawing.Size(48, 13);
            this.FolderLabel.TabIndex = 13;
            this.FolderLabel.Text = "In &Folder";
            // 
            // ItemDescription
            // 
            this.ItemDescription.Location = new System.Drawing.Point(78, 41);
            this.ItemDescription.Name = "ItemDescription";
            this.ItemDescription.Size = new System.Drawing.Size(310, 20);
            this.ItemDescription.TabIndex = 3;
            this.ItemDescription.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // ItemName
            // 
            this.ItemName.Location = new System.Drawing.Point(78, 14);
            this.ItemName.Name = "ItemName";
            this.ItemName.Size = new System.Drawing.Size(310, 20);
            this.ItemName.TabIndex = 2;
            this.ItemName.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // DescriptionLabel
            // 
            this.DescriptionLabel.AutoSize = true;
            this.DescriptionLabel.Location = new System.Drawing.Point(10, 44);
            this.DescriptionLabel.Name = "DescriptionLabel";
            this.DescriptionLabel.Size = new System.Drawing.Size(60, 13);
            this.DescriptionLabel.TabIndex = 11;
            this.DescriptionLabel.Text = "&Description";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(10, 17);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(35, 13);
            this.NameLabel.TabIndex = 9;
            this.NameLabel.Text = "&Name";
            // 
            // ItemEditor
            // 
            this.AcceptButton = this.AcceptDialog;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialog;
            this.ClientSize = new System.Drawing.Size(406, 241);
            this.Controls.Add(this.FunctionalPanel);
            this.Controls.Add(this.ButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemEditor";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ItemEditor_FormClosing);
            this.Load += new System.EventHandler(this.ItemEditor_Load);
            this.ButtonPanel.ResumeLayout(false);
            this.FunctionalPanel.ResumeLayout(false);
            this.FunctionalPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AcceptDialog;
        private System.Windows.Forms.Button CancelDialog;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Panel FunctionalPanel;
        internal System.Windows.Forms.TextBox ItemExternalProjectNo;
        private System.Windows.Forms.Label ExternalProjectNoLabel;
        internal System.Windows.Forms.ListBox ItemParent;
        private System.Windows.Forms.Label FolderLabel;
        internal System.Windows.Forms.TextBox ItemDescription;
        internal System.Windows.Forms.TextBox ItemName;
        private System.Windows.Forms.Label DescriptionLabel;
        private System.Windows.Forms.Label NameLabel;
    }
}