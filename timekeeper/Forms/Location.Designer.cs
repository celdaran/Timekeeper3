namespace Timekeeper.Forms
{
    partial class ListAttributeManager
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
            this.AttributeIsHiddenCheckBox = new System.Windows.Forms.CheckBox();
            this.AttributeModifyTime = new System.Windows.Forms.TextBox();
            this.AttributeCreateTime = new System.Windows.Forms.TextBox();
            this.LocationTimeZone = new System.Windows.Forms.ComboBox();
            this.AttributeDescription = new System.Windows.Forms.TextBox();
            this.AttributeName = new System.Windows.Forms.TextBox();
            this.LocationTimeZoneLabel = new System.Windows.Forms.Label();
            this.AttributeDescriptionLabel = new System.Windows.Forms.Label();
            this.AttributeNameLabel = new System.Windows.Forms.Label();
            this.ItemList = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MoveToTopButton = new System.Windows.Forms.ToolStripButton();
            this.MoveUpButton = new System.Windows.Forms.ToolStripButton();
            this.MoveDownButton = new System.Windows.Forms.ToolStripButton();
            this.MoveToBottomButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NewItemButton = new System.Windows.Forms.ToolStripButton();
            this.SaveItemButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteItemButton = new System.Windows.Forms.ToolStripButton();
            this.ListPanel = new System.Windows.Forms.Panel();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.AttributeHiddenTimeLabel = new System.Windows.Forms.Label();
            this.AttributeIsHiddenLabel = new System.Windows.Forms.Label();
            this.AttributeModifyTimeLabel = new System.Windows.Forms.Label();
            this.AttributeCreateTimeLabel = new System.Windows.Forms.Label();
            this.AttributeHiddenTime = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.ListPanel.SuspendLayout();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AttributeIsHiddenCheckBox
            // 
            this.AttributeIsHiddenCheckBox.AutoSize = true;
            this.AttributeIsHiddenCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AttributeIsHiddenCheckBox.Enabled = false;
            this.AttributeIsHiddenCheckBox.Location = new System.Drawing.Point(84, 169);
            this.AttributeIsHiddenCheckBox.Name = "AttributeIsHiddenCheckBox";
            this.AttributeIsHiddenCheckBox.Size = new System.Drawing.Size(15, 14);
            this.AttributeIsHiddenCheckBox.TabIndex = 7;
            this.AttributeIsHiddenCheckBox.UseVisualStyleBackColor = true;
            this.AttributeIsHiddenCheckBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AttributeIsHiddenCheckBox_MouseDown);
            // 
            // AttributeModifyTime
            // 
            this.AttributeModifyTime.Location = new System.Drawing.Point(86, 140);
            this.AttributeModifyTime.Name = "AttributeModifyTime";
            this.AttributeModifyTime.ReadOnly = true;
            this.AttributeModifyTime.Size = new System.Drawing.Size(260, 20);
            this.AttributeModifyTime.TabIndex = 6;
            // 
            // AttributeCreateTime
            // 
            this.AttributeCreateTime.Location = new System.Drawing.Point(86, 114);
            this.AttributeCreateTime.Name = "AttributeCreateTime";
            this.AttributeCreateTime.ReadOnly = true;
            this.AttributeCreateTime.Size = new System.Drawing.Size(260, 20);
            this.AttributeCreateTime.TabIndex = 5;
            // 
            // LocationTimeZone
            // 
            this.LocationTimeZone.BackColor = System.Drawing.SystemColors.Control;
            this.LocationTimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationTimeZone.Enabled = false;
            this.LocationTimeZone.FormattingEnabled = true;
            this.LocationTimeZone.Location = new System.Drawing.Point(86, 88);
            this.LocationTimeZone.Name = "LocationTimeZone";
            this.LocationTimeZone.Size = new System.Drawing.Size(260, 21);
            this.LocationTimeZone.TabIndex = 4;
            this.LocationTimeZone.SelectionChangeCommitted += new System.EventHandler(this.LocationTimeZone_SelectionChangeCommitted);
            // 
            // AttributeDescription
            // 
            this.AttributeDescription.BackColor = System.Drawing.SystemColors.Control;
            this.AttributeDescription.Enabled = false;
            this.AttributeDescription.Location = new System.Drawing.Point(86, 36);
            this.AttributeDescription.Multiline = true;
            this.AttributeDescription.Name = "AttributeDescription";
            this.AttributeDescription.ReadOnly = true;
            this.AttributeDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AttributeDescription.Size = new System.Drawing.Size(260, 46);
            this.AttributeDescription.TabIndex = 3;
            this.AttributeDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AttributeDescription_KeyPress);
            // 
            // AttributeName
            // 
            this.AttributeName.BackColor = System.Drawing.SystemColors.Control;
            this.AttributeName.Enabled = false;
            this.AttributeName.Location = new System.Drawing.Point(86, 10);
            this.AttributeName.Name = "AttributeName";
            this.AttributeName.ReadOnly = true;
            this.AttributeName.Size = new System.Drawing.Size(260, 20);
            this.AttributeName.TabIndex = 2;
            this.AttributeName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AttributeName_KeyPress);
            this.AttributeName.Leave += new System.EventHandler(this.AttributeName_Leave);
            // 
            // LocationTimeZoneLabel
            // 
            this.LocationTimeZoneLabel.AutoSize = true;
            this.LocationTimeZoneLabel.Location = new System.Drawing.Point(12, 91);
            this.LocationTimeZoneLabel.Name = "LocationTimeZoneLabel";
            this.LocationTimeZoneLabel.Size = new System.Drawing.Size(64, 13);
            this.LocationTimeZoneLabel.TabIndex = 31;
            this.LocationTimeZoneLabel.Text = "Time Zone: ";
            // 
            // AttributeDescriptionLabel
            // 
            this.AttributeDescriptionLabel.AutoSize = true;
            this.AttributeDescriptionLabel.Location = new System.Drawing.Point(12, 39);
            this.AttributeDescriptionLabel.Name = "AttributeDescriptionLabel";
            this.AttributeDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.AttributeDescriptionLabel.TabIndex = 30;
            this.AttributeDescriptionLabel.Text = "Description:";
            // 
            // AttributeNameLabel
            // 
            this.AttributeNameLabel.AutoSize = true;
            this.AttributeNameLabel.Location = new System.Drawing.Point(12, 13);
            this.AttributeNameLabel.Name = "AttributeNameLabel";
            this.AttributeNameLabel.Size = new System.Drawing.Size(38, 13);
            this.AttributeNameLabel.TabIndex = 29;
            this.AttributeNameLabel.Text = "Name:";
            // 
            // ItemList
            // 
            this.ItemList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemList.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ItemList.FormattingEnabled = true;
            this.ItemList.Location = new System.Drawing.Point(0, 0);
            this.ItemList.Name = "ItemList";
            this.ItemList.Size = new System.Drawing.Size(133, 226);
            this.ItemList.TabIndex = 1;
            this.ItemList.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.ItemList_DrawItem);
            this.ItemList.SelectedIndexChanged += new System.EventHandler(this.ItemList_SelectedIndexChanged);
            this.ItemList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ItemList_KeyDown);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MoveToTopButton,
            this.MoveUpButton,
            this.MoveDownButton,
            this.MoveToBottomButton,
            this.ToolStripSeparator1,
            this.NewItemButton,
            this.SaveItemButton,
            this.DeleteItemButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(492, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // MoveToTopButton
            // 
            this.MoveToTopButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveToTopButton.Enabled = false;
            this.MoveToTopButton.Image = global::Timekeeper.Properties.Resources.ImageButtonTop;
            this.MoveToTopButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveToTopButton.Name = "MoveToTopButton";
            this.MoveToTopButton.Size = new System.Drawing.Size(23, 22);
            this.MoveToTopButton.Text = "MoveToTopButton";
            this.MoveToTopButton.ToolTipText = "Move Item to Top of List";
            this.MoveToTopButton.Click += new System.EventHandler(this.MoveToTopButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveUpButton.Enabled = false;
            this.MoveUpButton.Image = global::Timekeeper.Properties.Resources.ImageButtonUp;
            this.MoveUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(23, 22);
            this.MoveUpButton.Text = "MoveUpButton";
            this.MoveUpButton.ToolTipText = "Move Item Up";
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveDownButton.Enabled = false;
            this.MoveDownButton.Image = global::Timekeeper.Properties.Resources.ImageButtonDown;
            this.MoveDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(23, 22);
            this.MoveDownButton.Text = "MoveDownButton";
            this.MoveDownButton.ToolTipText = "Move Item Down";
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveToBottomButton
            // 
            this.MoveToBottomButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.MoveToBottomButton.Enabled = false;
            this.MoveToBottomButton.Image = global::Timekeeper.Properties.Resources.ImageButtonBottom;
            this.MoveToBottomButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.MoveToBottomButton.Name = "MoveToBottomButton";
            this.MoveToBottomButton.Size = new System.Drawing.Size(23, 22);
            this.MoveToBottomButton.Text = "MoveToBottomButton";
            this.MoveToBottomButton.ToolTipText = "Move Item to Bottom of List";
            this.MoveToBottomButton.Click += new System.EventHandler(this.MoveToBottomButton_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // NewItemButton
            // 
            this.NewItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewItemButton.Image = global::Timekeeper.Properties.Resources.ImageButtonNew;
            this.NewItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewItemButton.Name = "NewItemButton";
            this.NewItemButton.Size = new System.Drawing.Size(23, 22);
            this.NewItemButton.Text = "NewItemButton";
            this.NewItemButton.ToolTipText = "Create a New Item";
            this.NewItemButton.Click += new System.EventHandler(this.NewItemButton_Click);
            // 
            // SaveItemButton
            // 
            this.SaveItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveItemButton.Enabled = false;
            this.SaveItemButton.Image = global::Timekeeper.Properties.Resources.ImageButtonSave;
            this.SaveItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveItemButton.Name = "SaveItemButton";
            this.SaveItemButton.Size = new System.Drawing.Size(23, 22);
            this.SaveItemButton.Text = "SaveItemButton";
            this.SaveItemButton.ToolTipText = "Save Item Edit";
            this.SaveItemButton.Click += new System.EventHandler(this.SaveItemButton_Click);
            // 
            // DeleteItemButton
            // 
            this.DeleteItemButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteItemButton.Enabled = false;
            this.DeleteItemButton.Image = global::Timekeeper.Properties.Resources.ImageButtonCancel;
            this.DeleteItemButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteItemButton.Name = "DeleteItemButton";
            this.DeleteItemButton.Size = new System.Drawing.Size(23, 22);
            this.DeleteItemButton.Text = "DeleteItemButton";
            this.DeleteItemButton.ToolTipText = "Delete Selected Item";
            this.DeleteItemButton.Click += new System.EventHandler(this.DeleteItemButton_Click);
            // 
            // ListPanel
            // 
            this.ListPanel.Controls.Add(this.ItemList);
            this.ListPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListPanel.Location = new System.Drawing.Point(0, 25);
            this.ListPanel.Name = "ListPanel";
            this.ListPanel.Size = new System.Drawing.Size(133, 226);
            this.ListPanel.TabIndex = 10;
            // 
            // FormPanel
            // 
            this.FormPanel.Controls.Add(this.AcceptDialogButton);
            this.FormPanel.Controls.Add(this.AttributeHiddenTimeLabel);
            this.FormPanel.Controls.Add(this.AttributeIsHiddenLabel);
            this.FormPanel.Controls.Add(this.AttributeModifyTimeLabel);
            this.FormPanel.Controls.Add(this.AttributeCreateTimeLabel);
            this.FormPanel.Controls.Add(this.AttributeHiddenTime);
            this.FormPanel.Controls.Add(this.AttributeIsHiddenCheckBox);
            this.FormPanel.Controls.Add(this.AttributeNameLabel);
            this.FormPanel.Controls.Add(this.AttributeModifyTime);
            this.FormPanel.Controls.Add(this.LocationTimeZoneLabel);
            this.FormPanel.Controls.Add(this.AttributeName);
            this.FormPanel.Controls.Add(this.AttributeDescription);
            this.FormPanel.Controls.Add(this.AttributeCreateTime);
            this.FormPanel.Controls.Add(this.AttributeDescriptionLabel);
            this.FormPanel.Controls.Add(this.LocationTimeZone);
            this.FormPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.FormPanel.Location = new System.Drawing.Point(133, 25);
            this.FormPanel.Name = "FormPanel";
            this.FormPanel.Size = new System.Drawing.Size(359, 226);
            this.FormPanel.TabIndex = 11;
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(271, 192);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 37;
            this.AcceptDialogButton.Text = "Close";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // AttributeHiddenTimeLabel
            // 
            this.AttributeHiddenTimeLabel.AutoSize = true;
            this.AttributeHiddenTimeLabel.Location = new System.Drawing.Point(107, 169);
            this.AttributeHiddenTimeLabel.Name = "AttributeHiddenTimeLabel";
            this.AttributeHiddenTimeLabel.Size = new System.Drawing.Size(61, 13);
            this.AttributeHiddenTimeLabel.TabIndex = 42;
            this.AttributeHiddenTimeLabel.Text = "Hidden On:";
            // 
            // AttributeIsHiddenLabel
            // 
            this.AttributeIsHiddenLabel.AutoSize = true;
            this.AttributeIsHiddenLabel.Location = new System.Drawing.Point(12, 169);
            this.AttributeIsHiddenLabel.Name = "AttributeIsHiddenLabel";
            this.AttributeIsHiddenLabel.Size = new System.Drawing.Size(44, 13);
            this.AttributeIsHiddenLabel.TabIndex = 41;
            this.AttributeIsHiddenLabel.Text = "Hidden:";
            // 
            // AttributeModifyTimeLabel
            // 
            this.AttributeModifyTimeLabel.AutoSize = true;
            this.AttributeModifyTimeLabel.Location = new System.Drawing.Point(12, 143);
            this.AttributeModifyTimeLabel.Name = "AttributeModifyTimeLabel";
            this.AttributeModifyTimeLabel.Size = new System.Drawing.Size(67, 13);
            this.AttributeModifyTimeLabel.TabIndex = 40;
            this.AttributeModifyTimeLabel.Text = "Modified On:";
            // 
            // AttributeCreateTimeLabel
            // 
            this.AttributeCreateTimeLabel.AutoSize = true;
            this.AttributeCreateTimeLabel.Location = new System.Drawing.Point(12, 117);
            this.AttributeCreateTimeLabel.Name = "AttributeCreateTimeLabel";
            this.AttributeCreateTimeLabel.Size = new System.Drawing.Size(64, 13);
            this.AttributeCreateTimeLabel.TabIndex = 39;
            this.AttributeCreateTimeLabel.Text = "Created On:";
            // 
            // AttributeHiddenTime
            // 
            this.AttributeHiddenTime.Location = new System.Drawing.Point(174, 166);
            this.AttributeHiddenTime.Name = "AttributeHiddenTime";
            this.AttributeHiddenTime.ReadOnly = true;
            this.AttributeHiddenTime.Size = new System.Drawing.Size(172, 20);
            this.AttributeHiddenTime.TabIndex = 8;
            // 
            // ListAttributeManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 251);
            this.Controls.Add(this.ListPanel);
            this.Controls.Add(this.FormPanel);
            this.Controls.Add(this.toolStrip1);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 278);
            this.Name = "ListAttributeManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Locations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ListAttributeManager_FormClosing);
            this.Load += new System.EventHandler(this.ListAttributeManager_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ListPanel.ResumeLayout(false);
            this.FormPanel.ResumeLayout(false);
            this.FormPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ItemList;
        private System.Windows.Forms.Label AttributeDescriptionLabel;
        private System.Windows.Forms.Label AttributeNameLabel;
        private System.Windows.Forms.TextBox AttributeModifyTime;
        private System.Windows.Forms.TextBox AttributeCreateTime;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton MoveToTopButton;
        private System.Windows.Forms.ToolStripButton MoveUpButton;
        private System.Windows.Forms.ToolStripButton MoveDownButton;
        private System.Windows.Forms.ToolStripButton MoveToBottomButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripButton NewItemButton;
        private System.Windows.Forms.ToolStripButton DeleteItemButton;
        private System.Windows.Forms.Panel ListPanel;
        private System.Windows.Forms.Panel FormPanel;
        private System.Windows.Forms.Label AttributeHiddenTimeLabel;
        private System.Windows.Forms.Label AttributeIsHiddenLabel;
        private System.Windows.Forms.Label AttributeModifyTimeLabel;
        private System.Windows.Forms.Label AttributeCreateTimeLabel;
        private System.Windows.Forms.TextBox AttributeHiddenTime;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.ToolStripButton SaveItemButton;
        protected System.Windows.Forms.ComboBox LocationTimeZone;
        protected System.Windows.Forms.Label LocationTimeZoneLabel;
        protected System.Windows.Forms.TextBox AttributeDescription;
        protected System.Windows.Forms.TextBox AttributeName;
        protected System.Windows.Forms.CheckBox AttributeIsHiddenCheckBox;
    }
}