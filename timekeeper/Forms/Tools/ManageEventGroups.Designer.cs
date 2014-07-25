namespace Timekeeper.Forms.Tools
{
    partial class ManageEventGroups
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
            this.EditButton = new System.Windows.Forms.Button();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CloseDialogButton = new System.Windows.Forms.Button();
            this.EventGroupList = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(156, 155);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(60, 23);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "&Edit";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MoveDownButton.Font = new System.Drawing.Font("Wingdings 3", 8F);
            this.MoveDownButton.ImageKey = "(none)";
            this.MoveDownButton.Location = new System.Drawing.Point(288, 31);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(23, 19);
            this.MoveDownButton.TabIndex = 7;
            this.MoveDownButton.Text = "q";
            this.MoveDownButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.MoveUpButton.Font = new System.Drawing.Font("Wingdings 3", 8F);
            this.MoveUpButton.ImageKey = "(none)";
            this.MoveUpButton.Location = new System.Drawing.Point(288, 12);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(23, 19);
            this.MoveUpButton.TabIndex = 6;
            this.MoveUpButton.Text = "p";
            this.MoveUpButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(222, 155);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(60, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "&Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // CloseDialogButton
            // 
            this.CloseDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseDialogButton.Location = new System.Drawing.Point(12, 155);
            this.CloseDialogButton.Name = "CloseDialogButton";
            this.CloseDialogButton.Size = new System.Drawing.Size(58, 23);
            this.CloseDialogButton.TabIndex = 5;
            this.CloseDialogButton.Text = "Close";
            this.CloseDialogButton.UseVisualStyleBackColor = true;
            this.CloseDialogButton.Visible = false;
            // 
            // EventGroupList
            // 
            this.EventGroupList.FormattingEnabled = true;
            this.EventGroupList.Location = new System.Drawing.Point(12, 12);
            this.EventGroupList.Name = "EventGroupList";
            this.EventGroupList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.EventGroupList.Size = new System.Drawing.Size(270, 134);
            this.EventGroupList.TabIndex = 1;
            this.EventGroupList.SelectedIndexChanged += new System.EventHandler(this.EventGroupList_SelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(90, 155);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(60, 23);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "&Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ManageEventGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 187);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.MoveDownButton);
            this.Controls.Add(this.MoveUpButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.CloseDialogButton);
            this.Controls.Add(this.EventGroupList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageEventGroups";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Event Groups";
            this.Load += new System.EventHandler(this.ManageEventGroups_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CloseDialogButton;
        private System.Windows.Forms.ListBox EventGroupList;
        private System.Windows.Forms.Button AddButton;

    }
}