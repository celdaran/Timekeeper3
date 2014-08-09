namespace Timekeeper.Forms.Tools
{
    partial class Calendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Calendar));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.wCalendar = new System.Windows.Forms.MonthCalendar();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.FilterButton = new System.Windows.Forms.ToolStripButton();
            this.ShowEntriesButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadViewMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ActionMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SaveViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveViewAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ManageViewsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveViewButton = new System.Windows.Forms.ToolStripButton();
            this.SaveViewAsButton = new System.Windows.Forms.ToolStripButton();
            this.ClearViewButton = new System.Windows.Forms.ToolStripButton();
            this.ManageViewsButton = new System.Windows.Forms.ToolStripButton();
            this.CalendarSplitContainer = new System.Windows.Forms.SplitContainer();
            this.JournalResultsGrid = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ResultCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.JournalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarSplitContainer)).BeginInit();
            this.CalendarSplitContainer.Panel1.SuspendLayout();
            this.CalendarSplitContainer.Panel2.SuspendLayout();
            this.CalendarSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalResultsGrid)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wCalendar
            // 
            this.wCalendar.BackColor = System.Drawing.Color.White;
            this.wCalendar.CalendarDimensions = new System.Drawing.Size(3, 1);
            this.wCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wCalendar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wCalendar.ForeColor = System.Drawing.Color.Black;
            this.wCalendar.Location = new System.Drawing.Point(0, 0);
            this.wCalendar.MaxSelectionCount = 1;
            this.wCalendar.Name = "wCalendar";
            this.wCalendar.ScrollChange = 1;
            this.wCalendar.ShowTodayCircle = false;
            this.wCalendar.ShowWeekNumbers = true;
            this.wCalendar.TabIndex = 1;
            this.wCalendar.TrailingForeColor = System.Drawing.Color.Silver;
            this.wCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.wCalendar_DateSelected);
            this.wCalendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.wCalendar_DateSelected);
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterButton,
            this.ShowEntriesButton,
            this.RefreshButton,
            this.ToolStripSeparator1,
            this.LoadViewMenuButton,
            this.ActionMenuButton,
            this.ToolStripSeparator2,
            this.SaveViewButton,
            this.SaveViewAsButton,
            this.ClearViewButton,
            this.ManageViewsButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(711, 25);
            this.ToolStrip.TabIndex = 1;
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
            // ShowEntriesButton
            // 
            this.ShowEntriesButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallProject;
            this.ShowEntriesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShowEntriesButton.Name = "ShowEntriesButton";
            this.ShowEntriesButton.Size = new System.Drawing.Size(89, 22);
            this.ShowEntriesButton.Text = "Show Entries";
            this.ShowEntriesButton.Click += new System.EventHandler(this.ShowEntriesButton_Click);
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
            // LoadViewMenuButton
            // 
            this.LoadViewMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadViewMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadViewMenuButton.Image")));
            this.LoadViewMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadViewMenuButton.Name = "LoadViewMenuButton";
            this.LoadViewMenuButton.Size = new System.Drawing.Size(43, 22);
            this.LoadViewMenuButton.Text = "Load";
            // 
            // ActionMenuButton
            // 
            this.ActionMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ActionMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveViewMenuItem,
            this.SaveViewAsMenuItem,
            this.toolStripMenuItem1,
            this.ClearViewMenuItem,
            this.toolStripMenuItem2,
            this.ManageViewsMenuItem});
            this.ActionMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("ActionMenuButton.Image")));
            this.ActionMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActionMenuButton.Name = "ActionMenuButton";
            this.ActionMenuButton.Size = new System.Drawing.Size(42, 22);
            this.ActionMenuButton.Text = "View";
            // 
            // SaveViewMenuItem
            // 
            this.SaveViewMenuItem.Name = "SaveViewMenuItem";
            this.SaveViewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveViewMenuItem.Size = new System.Drawing.Size(154, 22);
            this.SaveViewMenuItem.Text = "Save";
            this.SaveViewMenuItem.Click += new System.EventHandler(this.SaveViewButton_Click);
            // 
            // SaveViewAsMenuItem
            // 
            this.SaveViewAsMenuItem.Name = "SaveViewAsMenuItem";
            this.SaveViewAsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.SaveViewAsMenuItem.Text = "Save As...";
            this.SaveViewAsMenuItem.Click += new System.EventHandler(this.SaveViewAsButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // ClearViewMenuItem
            // 
            this.ClearViewMenuItem.Name = "ClearViewMenuItem";
            this.ClearViewMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ClearViewMenuItem.Text = "Clear";
            this.ClearViewMenuItem.Click += new System.EventHandler(this.ClearViewButton_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 6);
            // 
            // ManageViewsMenuItem
            // 
            this.ManageViewsMenuItem.Name = "ManageViewsMenuItem";
            this.ManageViewsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ManageViewsMenuItem.Text = "Manage Views...";
            this.ManageViewsMenuItem.Click += new System.EventHandler(this.ManageViewsButton_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.ToolStripSeparator2.Visible = false;
            // 
            // SaveViewButton
            // 
            this.SaveViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewButton.Image")));
            this.SaveViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewButton.Name = "SaveViewButton";
            this.SaveViewButton.Size = new System.Drawing.Size(89, 22);
            this.SaveViewButton.Text = "SaveViewButton";
            this.SaveViewButton.Visible = false;
            // 
            // SaveViewAsButton
            // 
            this.SaveViewAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewAsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewAsButton.Image")));
            this.SaveViewAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewAsButton.Name = "SaveViewAsButton";
            this.SaveViewAsButton.Size = new System.Drawing.Size(101, 22);
            this.SaveViewAsButton.Text = "SaveViewAsButton";
            this.SaveViewAsButton.ToolTipText = "SaveViewAsButton";
            this.SaveViewAsButton.Visible = false;
            // 
            // ClearViewButton
            // 
            this.ClearViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClearViewButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearViewButton.Image")));
            this.ClearViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearViewButton.Name = "ClearViewButton";
            this.ClearViewButton.Size = new System.Drawing.Size(90, 22);
            this.ClearViewButton.Text = "ClearViewButton";
            this.ClearViewButton.ToolTipText = "ClearViewButton";
            this.ClearViewButton.Visible = false;
            // 
            // ManageViewsButton
            // 
            this.ManageViewsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageViewsButton.Image = ((System.Drawing.Image)(resources.GetObject("ManageViewsButton.Image")));
            this.ManageViewsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageViewsButton.Name = "ManageViewsButton";
            this.ManageViewsButton.Size = new System.Drawing.Size(108, 22);
            this.ManageViewsButton.Text = "ManageViewsButton";
            this.ManageViewsButton.ToolTipText = "ManageViewsButton";
            this.ManageViewsButton.Visible = false;
            // 
            // CalendarSplitContainer
            // 
            this.CalendarSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalendarSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.CalendarSplitContainer.Location = new System.Drawing.Point(0, 25);
            this.CalendarSplitContainer.Name = "CalendarSplitContainer";
            // 
            // CalendarSplitContainer.Panel1
            // 
            this.CalendarSplitContainer.Panel1.BackColor = System.Drawing.SystemColors.Window;
            this.CalendarSplitContainer.Panel1.Controls.Add(this.wCalendar);
            // 
            // CalendarSplitContainer.Panel2
            // 
            this.CalendarSplitContainer.Panel2.Controls.Add(this.JournalResultsGrid);
            this.CalendarSplitContainer.Panel2Collapsed = true;
            this.CalendarSplitContainer.Size = new System.Drawing.Size(711, 161);
            this.CalendarSplitContainer.SplitterDistance = 239;
            this.CalendarSplitContainer.TabIndex = 2;
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
            this.StartTime,
            this.StopTime,
            this.Seconds,
            this.Memo,
            this.ProjectId,
            this.ProjectName,
            this.ActivityId,
            this.ActivityName,
            this.LocationId,
            this.LocationName,
            this.CategoryId,
            this.CategoryName,
            this.IsLocked,
            this.JournalId});
            this.JournalResultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JournalResultsGrid.Location = new System.Drawing.Point(0, 0);
            this.JournalResultsGrid.Name = "JournalResultsGrid";
            this.JournalResultsGrid.RowHeadersVisible = false;
            this.JournalResultsGrid.Size = new System.Drawing.Size(468, 161);
            this.JournalResultsGrid.TabIndex = 2;
            this.JournalResultsGrid.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JournalFindResults_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResultCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 186);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(711, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ResultCount
            // 
            this.ResultCount.Name = "ResultCount";
            this.ResultCount.Size = new System.Drawing.Size(0, 17);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Seconds.DefaultCellStyle = dataGridViewCellStyle3;
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
            this.ActivityName.Width = 65;
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
            this.LocationName.Width = 65;
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
            this.CategoryName.Width = 65;
            // 
            // IsLocked
            // 
            this.IsLocked.HeaderText = "Locked";
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.ReadOnly = true;
            this.IsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsLocked.Width = 50;
            // 
            // JournalId
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.JournalId.DefaultCellStyle = dataGridViewCellStyle4;
            this.JournalId.HeaderText = "ID";
            this.JournalId.MinimumWidth = 8;
            this.JournalId.Name = "JournalId";
            this.JournalId.ReadOnly = true;
            this.JournalId.ToolTipText = "Internal Journal Entry Identifier";
            this.JournalId.Width = 50;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(711, 208);
            this.Controls.Add(this.CalendarSplitContainer);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Calendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calendar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calendar_FormClosing);
            this.Load += new System.EventHandler(this.Calendar_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.CalendarSplitContainer.Panel1.ResumeLayout(false);
            this.CalendarSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CalendarSplitContainer)).EndInit();
            this.CalendarSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.JournalResultsGrid)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton FilterButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton LoadViewMenuButton;
        private System.Windows.Forms.ToolStripDropDownButton ActionMenuButton;
        private System.Windows.Forms.ToolStripMenuItem SaveViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveViewAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ClearViewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ManageViewsMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.SplitContainer CalendarSplitContainer;
        private System.Windows.Forms.MonthCalendar wCalendar;
        private System.Windows.Forms.DataGridView JournalResultsGrid;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ResultCount;
        private System.Windows.Forms.ToolStripButton ShowEntriesButton;
        private System.Windows.Forms.ToolStripButton SaveViewButton;
        private System.Windows.Forms.ToolStripButton SaveViewAsButton;
        private System.Windows.Forms.ToolStripButton ClearViewButton;
        private System.Windows.Forms.ToolStripButton ManageViewsButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalId;


    }
}