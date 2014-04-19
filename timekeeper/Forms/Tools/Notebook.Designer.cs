namespace Timekeeper.Forms.Tools
{
    partial class Notebook
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notebook));
            this.EntryDateTime = new System.Windows.Forms.DateTimePicker();
            this.DateLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolbarFirstEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarPreviousEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarNextEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarLastEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarNewEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarNotebookEntryId = new System.Windows.Forms.ToolStripLabel();
            this.ToolbarSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolbarFind = new System.Windows.Forms.ToolStripButton();
            this.ToolbarSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolbarSave = new System.Windows.Forms.ToolStripButton();
            this.ToolbarRevert = new System.Windows.Forms.ToolStripButton();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.LocationAndCategoryPanel = new System.Windows.Forms.Panel();
            this.CategoryPanel = new System.Windows.Forms.Panel();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.wCategory = new System.Windows.Forms.ComboBox();
            this.LocationPanel = new System.Windows.Forms.Panel();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.wLocation = new System.Windows.Forms.ComboBox();
            this.EditPanel = new System.Windows.Forms.Panel();
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.MenuToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolbarSave = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuFormatBold = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolbarRevert = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.LocationAndCategoryPanel.SuspendLayout();
            this.CategoryPanel.SuspendLayout();
            this.LocationPanel.SuspendLayout();
            this.MenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // EntryDateTime
            // 
            this.EntryDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EntryDateTime.Location = new System.Drawing.Point(41, 6);
            this.EntryDateTime.Name = "EntryDateTime";
            this.EntryDateTime.Size = new System.Drawing.Size(148, 20);
            this.EntryDateTime.TabIndex = 2;
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(5, 8);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(33, 13);
            this.DateLabel.TabIndex = 0;
            this.DateLabel.Text = "Date:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolbarFirstEntry,
            this.ToolbarPreviousEntry,
            this.ToolbarNextEntry,
            this.ToolbarLastEntry,
            this.ToolbarNewEntry,
            this.ToolbarNotebookEntryId,
            this.ToolbarSep1,
            this.ToolbarFind,
            this.ToolbarSep2,
            this.ToolbarSave,
            this.ToolbarRevert});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(423, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Notebook";
            // 
            // ToolbarFirstEntry
            // 
            this.ToolbarFirstEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarFirstEntry.Enabled = false;
            this.ToolbarFirstEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonFirst;
            this.ToolbarFirstEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarFirstEntry.Name = "ToolbarFirstEntry";
            this.ToolbarFirstEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarFirstEntry.Text = "|<";
            this.ToolbarFirstEntry.ToolTipText = "Go to First Entry";
            this.ToolbarFirstEntry.Click += new System.EventHandler(this.ToolbarFirstEntry_Click);
            // 
            // ToolbarPreviousEntry
            // 
            this.ToolbarPreviousEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarPreviousEntry.Enabled = false;
            this.ToolbarPreviousEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonPrev;
            this.ToolbarPreviousEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarPreviousEntry.Name = "ToolbarPreviousEntry";
            this.ToolbarPreviousEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarPreviousEntry.Text = "<<";
            this.ToolbarPreviousEntry.ToolTipText = "Go to Previous Entry";
            this.ToolbarPreviousEntry.Click += new System.EventHandler(this.ToolbarPreviousEntry_Click);
            // 
            // ToolbarNextEntry
            // 
            this.ToolbarNextEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarNextEntry.Enabled = false;
            this.ToolbarNextEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonNext;
            this.ToolbarNextEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarNextEntry.Name = "ToolbarNextEntry";
            this.ToolbarNextEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarNextEntry.Text = ">>";
            this.ToolbarNextEntry.ToolTipText = "Go to Next Entry";
            this.ToolbarNextEntry.Click += new System.EventHandler(this.ToolbarNextEntry_Click);
            // 
            // ToolbarLastEntry
            // 
            this.ToolbarLastEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarLastEntry.Enabled = false;
            this.ToolbarLastEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonLast;
            this.ToolbarLastEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarLastEntry.Name = "ToolbarLastEntry";
            this.ToolbarLastEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarLastEntry.Text = ">|";
            this.ToolbarLastEntry.ToolTipText = "Go to Last Entry";
            this.ToolbarLastEntry.Click += new System.EventHandler(this.ToolbarLastEntry_Click);
            // 
            // ToolbarNewEntry
            // 
            this.ToolbarNewEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarNewEntry.Enabled = false;
            this.ToolbarNewEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonNew;
            this.ToolbarNewEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarNewEntry.Name = "ToolbarNewEntry";
            this.ToolbarNewEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarNewEntry.Text = "New Entry";
            this.ToolbarNewEntry.ToolTipText = "Go to New Entry";
            this.ToolbarNewEntry.Click += new System.EventHandler(this.ToolbarNewEntry_Click);
            // 
            // ToolbarNotebookEntryId
            // 
            this.ToolbarNotebookEntryId.Enabled = false;
            this.ToolbarNotebookEntryId.Name = "ToolbarNotebookEntryId";
            this.ToolbarNotebookEntryId.Size = new System.Drawing.Size(37, 22);
            this.ToolbarNotebookEntryId.Text = "12345";
            // 
            // ToolbarSep1
            // 
            this.ToolbarSep1.Name = "ToolbarSep1";
            this.ToolbarSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolbarFind
            // 
            this.ToolbarFind.Enabled = false;
            this.ToolbarFind.Image = global::Timekeeper.Properties.Resources.ImageButtonFilter;
            this.ToolbarFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarFind.Name = "ToolbarFind";
            this.ToolbarFind.Size = new System.Drawing.Size(47, 22);
            this.ToolbarFind.Text = "Find";
            this.ToolbarFind.ToolTipText = "Find Entries";
            // 
            // ToolbarSep2
            // 
            this.ToolbarSep2.Name = "ToolbarSep2";
            this.ToolbarSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolbarSave
            // 
            this.ToolbarSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarSave.Enabled = false;
            this.ToolbarSave.Image = global::Timekeeper.Properties.Resources.ImageButtonSave;
            this.ToolbarSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarSave.Name = "ToolbarSave";
            this.ToolbarSave.Size = new System.Drawing.Size(23, 22);
            this.ToolbarSave.Text = "Save";
            this.ToolbarSave.Click += new System.EventHandler(this.MenuToolbarSave_Click);
            // 
            // ToolbarRevert
            // 
            this.ToolbarRevert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarRevert.Enabled = false;
            this.ToolbarRevert.Image = global::Timekeeper.Properties.Resources.ImageButtonRevert;
            this.ToolbarRevert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarRevert.Name = "ToolbarRevert";
            this.ToolbarRevert.Size = new System.Drawing.Size(23, 22);
            this.ToolbarRevert.Text = "Revert";
            this.ToolbarRevert.Click += new System.EventHandler(this.ToolbarRevert_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.Controls.Add(this.LocationAndCategoryPanel);
            this.ControlPanel.Controls.Add(this.EntryDateTime);
            this.ControlPanel.Controls.Add(this.DateLabel);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ControlPanel.Location = new System.Drawing.Point(0, 25);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(423, 64);
            this.ControlPanel.TabIndex = 7;
            // 
            // LocationAndCategoryPanel
            // 
            this.LocationAndCategoryPanel.Controls.Add(this.CategoryPanel);
            this.LocationAndCategoryPanel.Controls.Add(this.LocationPanel);
            this.LocationAndCategoryPanel.Location = new System.Drawing.Point(195, 3);
            this.LocationAndCategoryPanel.Name = "LocationAndCategoryPanel";
            this.LocationAndCategoryPanel.Size = new System.Drawing.Size(216, 61);
            this.LocationAndCategoryPanel.TabIndex = 17;
            // 
            // CategoryPanel
            // 
            this.CategoryPanel.Controls.Add(this.CategoryLabel);
            this.CategoryPanel.Controls.Add(this.wCategory);
            this.CategoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CategoryPanel.Location = new System.Drawing.Point(0, 27);
            this.CategoryPanel.Name = "CategoryPanel";
            this.CategoryPanel.Size = new System.Drawing.Size(216, 27);
            this.CategoryPanel.TabIndex = 1;
            // 
            // CategoryLabel
            // 
            this.CategoryLabel.Location = new System.Drawing.Point(3, 4);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(52, 13);
            this.CategoryLabel.TabIndex = 15;
            this.CategoryLabel.Text = "Category:";
            // 
            // wCategory
            // 
            this.wCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wCategory.FormattingEnabled = true;
            this.wCategory.Location = new System.Drawing.Point(58, 1);
            this.wCategory.Name = "wCategory";
            this.wCategory.Size = new System.Drawing.Size(151, 21);
            this.wCategory.TabIndex = 4;
            // 
            // LocationPanel
            // 
            this.LocationPanel.Controls.Add(this.LocationLabel);
            this.LocationPanel.Controls.Add(this.wLocation);
            this.LocationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.LocationPanel.Location = new System.Drawing.Point(0, 0);
            this.LocationPanel.Name = "LocationPanel";
            this.LocationPanel.Size = new System.Drawing.Size(216, 27);
            this.LocationPanel.TabIndex = 0;
            // 
            // LocationLabel
            // 
            this.LocationLabel.Location = new System.Drawing.Point(3, 5);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(52, 13);
            this.LocationLabel.TabIndex = 13;
            this.LocationLabel.Text = "&Location:";
            // 
            // wLocation
            // 
            this.wLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wLocation.FormattingEnabled = true;
            this.wLocation.Location = new System.Drawing.Point(58, 2);
            this.wLocation.Name = "wLocation";
            this.wLocation.Size = new System.Drawing.Size(151, 21);
            this.wLocation.TabIndex = 3;
            // 
            // EditPanel
            // 
            this.EditPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EditPanel.Location = new System.Drawing.Point(0, 89);
            this.EditPanel.Name = "EditPanel";
            this.EditPanel.Size = new System.Drawing.Size(423, 227);
            this.EditPanel.TabIndex = 8;
            // 
            // MenuMain
            // 
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolbar,
            this.MenuFormat});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(423, 24);
            this.MenuMain.TabIndex = 9;
            this.MenuMain.Text = "menuStrip1";
            this.MenuMain.Visible = false;
            // 
            // MenuToolbar
            // 
            this.MenuToolbar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuToolbarSave,
            this.MenuToolbarRevert});
            this.MenuToolbar.Name = "MenuToolbar";
            this.MenuToolbar.Size = new System.Drawing.Size(55, 20);
            this.MenuToolbar.Text = "Toolbar";
            // 
            // MenuToolbarSave
            // 
            this.MenuToolbarSave.Name = "MenuToolbarSave";
            this.MenuToolbarSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.MenuToolbarSave.Size = new System.Drawing.Size(175, 22);
            this.MenuToolbarSave.Text = "Save";
            this.MenuToolbarSave.Click += new System.EventHandler(this.MenuToolbarSave_Click);
            // 
            // MenuFormat
            // 
            this.MenuFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFormatBold});
            this.MenuFormat.Name = "MenuFormat";
            this.MenuFormat.Size = new System.Drawing.Size(53, 20);
            this.MenuFormat.Text = "Format";
            // 
            // MenuFormatBold
            // 
            this.MenuFormatBold.Name = "MenuFormatBold";
            this.MenuFormatBold.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.B)));
            this.MenuFormatBold.Size = new System.Drawing.Size(152, 22);
            this.MenuFormatBold.Text = "Bold";
            this.MenuFormatBold.Click += new System.EventHandler(this.MenuFormatBold_Click);
            // 
            // MenuToolbarRevert
            // 
            this.MenuToolbarRevert.Name = "MenuToolbarRevert";
            this.MenuToolbarRevert.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.MenuToolbarRevert.Size = new System.Drawing.Size(175, 22);
            this.MenuToolbarRevert.Text = "Revert";
            // 
            // Notebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 316);
            this.Controls.Add(this.EditPanel);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.MenuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuMain;
            this.Name = "Notebook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notebook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notebook_FormClosing);
            this.Load += new System.EventHandler(this.Notebook_Load);
            this.Shown += new System.EventHandler(this.Notebook_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.LocationAndCategoryPanel.ResumeLayout(false);
            this.CategoryPanel.ResumeLayout(false);
            this.LocationPanel.ResumeLayout(false);
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DateLabel;
        internal System.Windows.Forms.DateTimePicker EntryDateTime;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolbarFirstEntry;
        private System.Windows.Forms.ToolStripButton ToolbarPreviousEntry;
        private System.Windows.Forms.ToolStripButton ToolbarNextEntry;
        private System.Windows.Forms.ToolStripButton ToolbarLastEntry;
        private System.Windows.Forms.ToolStripButton ToolbarNewEntry;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Panel EditPanel;
        private System.Windows.Forms.ToolStripSeparator ToolbarSep2;
        private System.Windows.Forms.Panel LocationAndCategoryPanel;
        private System.Windows.Forms.Panel CategoryPanel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.ComboBox wCategory;
        private System.Windows.Forms.Panel LocationPanel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.ComboBox wLocation;
        private System.Windows.Forms.ToolStripButton ToolbarSave;
        private System.Windows.Forms.ToolStripButton ToolbarRevert;
        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem MenuToolbar;
        private System.Windows.Forms.ToolStripMenuItem MenuToolbarSave;
        private System.Windows.Forms.ToolStripMenuItem MenuFormat;
        private System.Windows.Forms.ToolStripMenuItem MenuFormatBold;
        private System.Windows.Forms.ToolStripSeparator ToolbarSep1;
        private System.Windows.Forms.ToolStripButton ToolbarFind;
        private System.Windows.Forms.ToolStripLabel ToolbarNotebookEntryId;
        private System.Windows.Forms.ToolStripMenuItem MenuToolbarRevert;
    }
}