namespace Timekeeper.Forms
{
    partial class Location
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
            this.LocationHiddenCheckBox = new System.Windows.Forms.CheckBox();
            this.LocationModifyTime = new System.Windows.Forms.TextBox();
            this.LocationCreateTime = new System.Windows.Forms.TextBox();
            this.LocationTimeZone = new System.Windows.Forms.ComboBox();
            this.LocationDescription = new System.Windows.Forms.TextBox();
            this.LocationName = new System.Windows.Forms.TextBox();
            this.LocationTimeZoneLabel = new System.Windows.Forms.Label();
            this.LocationDescriptionLabel = new System.Windows.Forms.Label();
            this.LocationNameLabel = new System.Windows.Forms.Label();
            this.ItemList = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.MoveToTopButton = new System.Windows.Forms.ToolStripButton();
            this.MoveUpButton = new System.Windows.Forms.ToolStripButton();
            this.MoveDownButton = new System.Windows.Forms.ToolStripButton();
            this.MoveToBottomButton = new System.Windows.Forms.ToolStripButton();
            this.Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NewItemButton = new System.Windows.Forms.ToolStripButton();
            this.SaveItemButton = new System.Windows.Forms.ToolStripButton();
            this.DeleteItemButton = new System.Windows.Forms.ToolStripButton();
            this.ListPanel = new System.Windows.Forms.Panel();
            this.FormPanel = new System.Windows.Forms.Panel();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LocationHiddenTime = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.ListPanel.SuspendLayout();
            this.FormPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LocationHiddenCheckBox
            // 
            this.LocationHiddenCheckBox.AutoSize = true;
            this.LocationHiddenCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LocationHiddenCheckBox.Enabled = false;
            this.LocationHiddenCheckBox.Location = new System.Drawing.Point(84, 169);
            this.LocationHiddenCheckBox.Name = "LocationHiddenCheckBox";
            this.LocationHiddenCheckBox.Size = new System.Drawing.Size(15, 14);
            this.LocationHiddenCheckBox.TabIndex = 7;
            this.LocationHiddenCheckBox.UseVisualStyleBackColor = true;
            this.LocationHiddenCheckBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LocationHiddenCheckBox_MouseDown);
            // 
            // LocationModifyTime
            // 
            this.LocationModifyTime.Location = new System.Drawing.Point(86, 140);
            this.LocationModifyTime.Name = "LocationModifyTime";
            this.LocationModifyTime.ReadOnly = true;
            this.LocationModifyTime.Size = new System.Drawing.Size(260, 20);
            this.LocationModifyTime.TabIndex = 6;
            // 
            // LocationCreateTime
            // 
            this.LocationCreateTime.Location = new System.Drawing.Point(86, 114);
            this.LocationCreateTime.Name = "LocationCreateTime";
            this.LocationCreateTime.ReadOnly = true;
            this.LocationCreateTime.Size = new System.Drawing.Size(260, 20);
            this.LocationCreateTime.TabIndex = 5;
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
            // LocationDescription
            // 
            this.LocationDescription.BackColor = System.Drawing.SystemColors.Control;
            this.LocationDescription.Enabled = false;
            this.LocationDescription.Location = new System.Drawing.Point(86, 36);
            this.LocationDescription.Multiline = true;
            this.LocationDescription.Name = "LocationDescription";
            this.LocationDescription.ReadOnly = true;
            this.LocationDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LocationDescription.Size = new System.Drawing.Size(260, 46);
            this.LocationDescription.TabIndex = 3;
            this.LocationDescription.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LocationDescription_KeyPress);
            // 
            // LocationName
            // 
            this.LocationName.BackColor = System.Drawing.SystemColors.Control;
            this.LocationName.Enabled = false;
            this.LocationName.Location = new System.Drawing.Point(86, 10);
            this.LocationName.Name = "LocationName";
            this.LocationName.ReadOnly = true;
            this.LocationName.Size = new System.Drawing.Size(260, 20);
            this.LocationName.TabIndex = 2;
            this.LocationName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LocationName_KeyPress);
            this.LocationName.Leave += new System.EventHandler(this.LocationName_Leave);
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
            // LocationDescriptionLabel
            // 
            this.LocationDescriptionLabel.AutoSize = true;
            this.LocationDescriptionLabel.Location = new System.Drawing.Point(12, 39);
            this.LocationDescriptionLabel.Name = "LocationDescriptionLabel";
            this.LocationDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.LocationDescriptionLabel.TabIndex = 30;
            this.LocationDescriptionLabel.Text = "Description:";
            // 
            // LocationNameLabel
            // 
            this.LocationNameLabel.AutoSize = true;
            this.LocationNameLabel.Location = new System.Drawing.Point(12, 13);
            this.LocationNameLabel.Name = "LocationNameLabel";
            this.LocationNameLabel.Size = new System.Drawing.Size(38, 13);
            this.LocationNameLabel.TabIndex = 29;
            this.LocationNameLabel.Text = "Name:";
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
            this.Separator1,
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
            // Separator1
            // 
            this.Separator1.Name = "Separator1";
            this.Separator1.Size = new System.Drawing.Size(6, 25);
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
            this.FormPanel.Controls.Add(this.label4);
            this.FormPanel.Controls.Add(this.label3);
            this.FormPanel.Controls.Add(this.label2);
            this.FormPanel.Controls.Add(this.label1);
            this.FormPanel.Controls.Add(this.LocationHiddenTime);
            this.FormPanel.Controls.Add(this.LocationHiddenCheckBox);
            this.FormPanel.Controls.Add(this.LocationNameLabel);
            this.FormPanel.Controls.Add(this.LocationModifyTime);
            this.FormPanel.Controls.Add(this.LocationTimeZoneLabel);
            this.FormPanel.Controls.Add(this.LocationName);
            this.FormPanel.Controls.Add(this.LocationDescription);
            this.FormPanel.Controls.Add(this.LocationCreateTime);
            this.FormPanel.Controls.Add(this.LocationDescriptionLabel);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(107, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Hidden On:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 41;
            this.label3.Text = "Hidden:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 40;
            this.label2.Text = "Modified On:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Created On:";
            // 
            // LocationHiddenTime
            // 
            this.LocationHiddenTime.Location = new System.Drawing.Point(174, 166);
            this.LocationHiddenTime.Name = "LocationHiddenTime";
            this.LocationHiddenTime.ReadOnly = true;
            this.LocationHiddenTime.Size = new System.Drawing.Size(172, 20);
            this.LocationHiddenTime.TabIndex = 8;
            // 
            // Location
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
            this.Name = "Location";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Locations";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Location_FormClosing);
            this.Load += new System.EventHandler(this.Location_Load);
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
        private System.Windows.Forms.TextBox LocationDescription;
        private System.Windows.Forms.TextBox LocationName;
        private System.Windows.Forms.Label LocationDescriptionLabel;
        private System.Windows.Forms.Label LocationNameLabel;
        private System.Windows.Forms.CheckBox LocationHiddenCheckBox;
        private System.Windows.Forms.TextBox LocationModifyTime;
        private System.Windows.Forms.TextBox LocationCreateTime;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton MoveToTopButton;
        private System.Windows.Forms.ToolStripButton MoveUpButton;
        private System.Windows.Forms.ToolStripButton MoveDownButton;
        private System.Windows.Forms.ToolStripButton MoveToBottomButton;
        private System.Windows.Forms.ToolStripSeparator Separator1;
        private System.Windows.Forms.ToolStripButton NewItemButton;
        private System.Windows.Forms.ToolStripButton DeleteItemButton;
        private System.Windows.Forms.Panel ListPanel;
        private System.Windows.Forms.Panel FormPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox LocationHiddenTime;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.ToolStripButton SaveItemButton;
        protected System.Windows.Forms.ComboBox LocationTimeZone;
        protected System.Windows.Forms.Label LocationTimeZoneLabel;
    }
}