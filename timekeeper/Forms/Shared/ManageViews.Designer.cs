namespace Timekeeper.Forms.Shared
{
    partial class ManageViews
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
            this.SavedViewList = new System.Windows.Forms.ListBox();
            this.CloseDialogButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.RenameButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SavedViewList
            // 
            this.SavedViewList.FormattingEnabled = true;
            this.SavedViewList.Location = new System.Drawing.Point(12, 12);
            this.SavedViewList.Name = "SavedViewList";
            this.SavedViewList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.SavedViewList.Size = new System.Drawing.Size(270, 134);
            this.SavedViewList.TabIndex = 1;
            this.SavedViewList.SelectedIndexChanged += new System.EventHandler(this.SavedViewList_SelectedIndexChanged);
            this.SavedViewList.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // CloseDialogButton
            // 
            this.CloseDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseDialogButton.Location = new System.Drawing.Point(207, 159);
            this.CloseDialogButton.Name = "CloseDialogButton";
            this.CloseDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CloseDialogButton.TabIndex = 4;
            this.CloseDialogButton.Text = "Close";
            this.CloseDialogButton.UseVisualStyleBackColor = true;
            this.CloseDialogButton.Click += new System.EventHandler(this.CloseDialogButton_Click);
            this.CloseDialogButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(93, 159);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "&Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            this.DeleteButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MoveDownButton.Font = new System.Drawing.Font("Wingdings 3", 8F);
            this.MoveDownButton.ImageKey = "(none)";
            this.MoveDownButton.Location = new System.Drawing.Point(288, 31);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(23, 19);
            this.MoveDownButton.TabIndex = 6;
            this.MoveDownButton.Text = "q";
            this.MoveDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            this.MoveDownButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MoveUpButton.Font = new System.Drawing.Font("Wingdings 3", 8F);
            this.MoveUpButton.ImageKey = "(none)";
            this.MoveUpButton.Location = new System.Drawing.Point(288, 12);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(23, 19);
            this.MoveUpButton.TabIndex = 5;
            this.MoveUpButton.Text = "p";
            this.MoveUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            this.MoveUpButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // RenameButton
            // 
            this.RenameButton.Location = new System.Drawing.Point(12, 159);
            this.RenameButton.Name = "RenameButton";
            this.RenameButton.Size = new System.Drawing.Size(75, 23);
            this.RenameButton.TabIndex = 2;
            this.RenameButton.Text = "&Rename";
            this.RenameButton.UseVisualStyleBackColor = true;
            this.RenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            this.RenameButton.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // ManageViews
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseDialogButton;
            this.ClientSize = new System.Drawing.Size(317, 190);
            this.Controls.Add(this.RenameButton);
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CloseDialogButton);
            this.Controls.Add(this.SavedViewList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageViews";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Items";
            this.Load += new System.EventHandler(this.ManageViews_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox SavedViewList;
        private System.Windows.Forms.Button CloseDialogButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button RenameButton;
    }
}