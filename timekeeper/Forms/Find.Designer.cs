namespace Timekeeper.Forms
{
    partial class Find
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Find));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.FilterButton = new System.Windows.Forms.ToolStripButton();
            this.SortButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearViewButton = new System.Windows.Forms.ToolStripButton();
            this.LoadViewMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ActionMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.manageViewsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveViewButton = new System.Windows.Forms.ToolStripButton();
            this.SaveViewAsButton = new System.Windows.Forms.ToolStripButton();
            this.ManageViewsButton = new System.Windows.Forms.ToolStripButton();
            this.JournalResultsGrid = new System.Windows.Forms.DataGridView();
            this.JournalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ResultCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.NotebookResultsGrid = new System.Windows.Forms.DataGridView();
            this.NotebookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotebookEntryTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotebookMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotebookLocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotebookLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotebookCategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NotebookCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalResultsGrid)).BeginInit();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NotebookResultsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterButton,
            this.SortButton,
            this.toolStripSeparator2,
            this.RefreshButton,
            this.ToolStripSeparator1,
            this.ClearViewButton,
            this.LoadViewMenuButton,
            this.ActionMenuButton,
            this.toolStripSeparator3,
            this.SaveViewButton,
            this.SaveViewAsButton,
            this.ManageViewsButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(893, 25);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // FilterButton
            // 
            this.FilterButton.Image = global::Timekeeper.Properties.Resources.ImageButtonFilter;
            this.FilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(77, 22);
            this.FilterButton.Text = "Filtering...";
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // SortButton
            // 
            this.SortButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SortButton.Image = ((System.Drawing.Image)(resources.GetObject("SortButton.Image")));
            this.SortButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(57, 22);
            this.SortButton.Text = "Sorting...";
            this.SortButton.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = global::Timekeeper.Properties.Resources.ImageButtonRefresh;
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.ToolTipText = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ClearViewButton
            // 
            this.ClearViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClearViewButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearViewButton.Image")));
            this.ClearViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearViewButton.Name = "ClearViewButton";
            this.ClearViewButton.Size = new System.Drawing.Size(36, 22);
            this.ClearViewButton.Text = "Clear";
            this.ClearViewButton.ToolTipText = "Clear the current view";
            this.ClearViewButton.Visible = false;
            this.ClearViewButton.Click += new System.EventHandler(this.ClearViewButton_Click);
            // 
            // LoadViewMenuButton
            // 
            this.LoadViewMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadViewMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadViewMenuButton.Image")));
            this.LoadViewMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadViewMenuButton.Name = "LoadViewMenuButton";
            this.LoadViewMenuButton.Size = new System.Drawing.Size(43, 22);
            this.LoadViewMenuButton.Text = "Load";
            this.LoadViewMenuButton.ToolTipText = "Load a saved View";
            // 
            // ActionMenuButton
            // 
            this.ActionMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ActionMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem2,
            this.manageViewsToolStripMenuItem});
            this.ActionMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("ActionMenuButton.Image")));
            this.ActionMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActionMenuButton.Name = "ActionMenuButton";
            this.ActionMenuButton.Size = new System.Drawing.Size(42, 22);
            this.ActionMenuButton.Text = "View";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveViewButton_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.SaveViewAsButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.ClearViewButton_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 6);
            // 
            // manageViewsToolStripMenuItem
            // 
            this.manageViewsToolStripMenuItem.Name = "manageViewsToolStripMenuItem";
            this.manageViewsToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.manageViewsToolStripMenuItem.Text = "Manage Views...";
            this.manageViewsToolStripMenuItem.Click += new System.EventHandler(this.ManageViewsButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Visible = false;
            // 
            // SaveViewButton
            // 
            this.SaveViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewButton.Image")));
            this.SaveViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewButton.Name = "SaveViewButton";
            this.SaveViewButton.Size = new System.Drawing.Size(35, 22);
            this.SaveViewButton.Text = "Save";
            this.SaveViewButton.ToolTipText = "Save Current View";
            this.SaveViewButton.Visible = false;
            this.SaveViewButton.Click += new System.EventHandler(this.SaveViewButton_Click);
            // 
            // SaveViewAsButton
            // 
            this.SaveViewAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewAsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewAsButton.Image")));
            this.SaveViewAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewAsButton.Name = "SaveViewAsButton";
            this.SaveViewAsButton.Size = new System.Drawing.Size(62, 22);
            this.SaveViewAsButton.Text = "Save As...";
            this.SaveViewAsButton.ToolTipText = "Save current view for future use";
            this.SaveViewAsButton.Visible = false;
            this.SaveViewAsButton.Click += new System.EventHandler(this.SaveViewAsButton_Click);
            // 
            // ManageViewsButton
            // 
            this.ManageViewsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageViewsButton.Image = ((System.Drawing.Image)(resources.GetObject("ManageViewsButton.Image")));
            this.ManageViewsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageViewsButton.Name = "ManageViewsButton";
            this.ManageViewsButton.Size = new System.Drawing.Size(61, 22);
            this.ManageViewsButton.Text = "Manage...";
            this.ManageViewsButton.ToolTipText = "Manage your saved Views";
            this.ManageViewsButton.Visible = false;
            this.ManageViewsButton.Click += new System.EventHandler(this.ManageViewsButton_Click);
            // 
            // JournalResultsGrid
            // 
            this.JournalResultsGrid.AllowUserToAddRows = false;
            this.JournalResultsGrid.AllowUserToDeleteRows = false;
            this.JournalResultsGrid.AllowUserToOrderColumns = true;
            this.JournalResultsGrid.AllowUserToResizeRows = false;
            this.JournalResultsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.JournalResultsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.JournalResultsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.JournalResultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.JournalResultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JournalId,
            this.ProjectId,
            this.ProjectName,
            this.ActivityId,
            this.ActivityName,
            this.StartTime,
            this.StopTime,
            this.Seconds,
            this.Memo,
            this.LocationId,
            this.LocationName,
            this.CategoryId,
            this.CategoryName,
            this.IsLocked});
            this.JournalResultsGrid.Location = new System.Drawing.Point(0, 25);
            this.JournalResultsGrid.Name = "JournalResultsGrid";
            this.JournalResultsGrid.RowHeadersVisible = false;
            this.JournalResultsGrid.Size = new System.Drawing.Size(893, 110);
            this.JournalResultsGrid.TabIndex = 1;
            this.JournalResultsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JournalFindResults_CellDoubleClick);
            // 
            // JournalId
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.JournalId.DefaultCellStyle = dataGridViewCellStyle1;
            this.JournalId.HeaderText = "ID";
            this.JournalId.MinimumWidth = 8;
            this.JournalId.Name = "JournalId";
            this.JournalId.ReadOnly = true;
            this.JournalId.ToolTipText = "Internal Journal Entry Identifier";
            this.JournalId.Width = 43;
            // 
            // ProjectId
            // 
            this.ProjectId.HeaderText = "ProjectId";
            this.ProjectId.Name = "ProjectId";
            this.ProjectId.ReadOnly = true;
            this.ProjectId.Visible = false;
            // 
            // ProjectName
            // 
            this.ProjectName.HeaderText = "Project";
            this.ProjectName.Name = "ProjectName";
            this.ProjectName.ReadOnly = true;
            this.ProjectName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ProjectName.Width = 65;
            // 
            // ActivityId
            // 
            this.ActivityId.HeaderText = "ActivityId";
            this.ActivityId.Name = "ActivityId";
            this.ActivityId.ReadOnly = true;
            this.ActivityId.Visible = false;
            // 
            // ActivityName
            // 
            this.ActivityName.HeaderText = "Activity";
            this.ActivityName.Name = "ActivityName";
            this.ActivityName.ReadOnly = true;
            this.ActivityName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ActivityName.Width = 66;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 80;
            // 
            // StopTime
            // 
            this.StopTime.HeaderText = "Stop Time";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            this.StopTime.Width = 80;
            // 
            // Seconds
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Seconds.DefaultCellStyle = dataGridViewCellStyle2;
            this.Seconds.HeaderText = "Duration";
            this.Seconds.Name = "Seconds";
            this.Seconds.ReadOnly = true;
            this.Seconds.Width = 72;
            // 
            // Memo
            // 
            this.Memo.HeaderText = "Memo";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            // 
            // LocationId
            // 
            this.LocationId.HeaderText = "LocationId";
            this.LocationId.Name = "LocationId";
            this.LocationId.ReadOnly = true;
            this.LocationId.Visible = false;
            // 
            // LocationName
            // 
            this.LocationName.HeaderText = "Location";
            this.LocationName.Name = "LocationName";
            this.LocationName.ReadOnly = true;
            this.LocationName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.LocationName.Width = 73;
            // 
            // CategoryId
            // 
            this.CategoryId.HeaderText = "CategoryId";
            this.CategoryId.Name = "CategoryId";
            this.CategoryId.ReadOnly = true;
            this.CategoryId.Visible = false;
            // 
            // CategoryName
            // 
            this.CategoryName.HeaderText = "Category";
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.ReadOnly = true;
            this.CategoryName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CategoryName.Width = 74;
            // 
            // IsLocked
            // 
            this.IsLocked.HeaderText = "Locked";
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.ReadOnly = true;
            this.IsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsLocked.Width = 40;
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResultCount});
            this.StatusBar.Location = new System.Drawing.Point(0, 271);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(893, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // ResultCount
            // 
            this.ResultCount.Name = "ResultCount";
            this.ResultCount.Size = new System.Drawing.Size(0, 17);
            // 
            // NotebookResultsGrid
            // 
            this.NotebookResultsGrid.AllowUserToAddRows = false;
            this.NotebookResultsGrid.AllowUserToDeleteRows = false;
            this.NotebookResultsGrid.AllowUserToOrderColumns = true;
            this.NotebookResultsGrid.AllowUserToResizeRows = false;
            this.NotebookResultsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.NotebookResultsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.NotebookResultsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.NotebookResultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NotebookResultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NotebookId,
            this.NotebookEntryTime,
            this.NotebookMemo,
            this.NotebookLocationId,
            this.NotebookLocation,
            this.NotebookCategoryId,
            this.NotebookCategory});
            this.NotebookResultsGrid.Location = new System.Drawing.Point(0, 141);
            this.NotebookResultsGrid.Name = "NotebookResultsGrid";
            this.NotebookResultsGrid.RowHeadersVisible = false;
            this.NotebookResultsGrid.Size = new System.Drawing.Size(893, 110);
            this.NotebookResultsGrid.TabIndex = 3;
            this.NotebookResultsGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.NotebookFindResults_CellDoubleClick);
            // 
            // NotebookId
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NotebookId.DefaultCellStyle = dataGridViewCellStyle3;
            this.NotebookId.HeaderText = "ID";
            this.NotebookId.MinimumWidth = 8;
            this.NotebookId.Name = "NotebookId";
            this.NotebookId.ReadOnly = true;
            this.NotebookId.ToolTipText = "Internal Journal Entry Identifier";
            this.NotebookId.Width = 43;
            // 
            // NotebookEntryTime
            // 
            this.NotebookEntryTime.HeaderText = "Entry Time";
            this.NotebookEntryTime.Name = "NotebookEntryTime";
            this.NotebookEntryTime.ReadOnly = true;
            this.NotebookEntryTime.Width = 120;
            // 
            // NotebookMemo
            // 
            this.NotebookMemo.HeaderText = "Memo";
            this.NotebookMemo.Name = "NotebookMemo";
            this.NotebookMemo.ReadOnly = true;
            // 
            // NotebookLocationId
            // 
            this.NotebookLocationId.HeaderText = "LocationId";
            this.NotebookLocationId.Name = "NotebookLocationId";
            this.NotebookLocationId.ReadOnly = true;
            this.NotebookLocationId.Visible = false;
            // 
            // NotebookLocation
            // 
            this.NotebookLocation.HeaderText = "Location";
            this.NotebookLocation.Name = "NotebookLocation";
            this.NotebookLocation.ReadOnly = true;
            this.NotebookLocation.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NotebookLocation.Width = 73;
            // 
            // NotebookCategoryId
            // 
            this.NotebookCategoryId.HeaderText = "CategoryId";
            this.NotebookCategoryId.Name = "NotebookCategoryId";
            this.NotebookCategoryId.ReadOnly = true;
            this.NotebookCategoryId.Visible = false;
            // 
            // NotebookCategory
            // 
            this.NotebookCategory.HeaderText = "Category";
            this.NotebookCategory.Name = "NotebookCategory";
            this.NotebookCategory.ReadOnly = true;
            this.NotebookCategory.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NotebookCategory.Width = 74;
            // 
            // Find
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 293);
            this.Controls.Add(this.NotebookResultsGrid);
            this.Controls.Add(this.JournalResultsGrid);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Find";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find";
            this.Activated += new System.EventHandler(this.Find_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Find_FormClosing);
            this.Load += new System.EventHandler(this.Find_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalResultsGrid)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NotebookResultsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton FilterButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton LoadViewMenuButton;
        private System.Windows.Forms.ToolStripButton SaveViewAsButton;
        private System.Windows.Forms.ToolStripButton ManageViewsButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripButton SortButton;
        private System.Windows.Forms.DataGridView JournalResultsGrid;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel ResultCount;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ClearViewButton;
        private System.Windows.Forms.DataGridView NotebookResultsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotebookId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotebookEntryTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotebookMemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotebookLocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotebookLocation;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotebookCategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NotebookCategory;
        private System.Windows.Forms.ToolStripDropDownButton ActionMenuButton;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageViewsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton SaveViewButton;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLocked;
    }
}