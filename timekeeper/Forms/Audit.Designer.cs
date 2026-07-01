namespace Timekeeper.Forms
{
    partial class Audit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Audit));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.SelectDateLabel = new System.Windows.Forms.ToolStripLabel();
            this.AuditDate = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ReconcileAllButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SortByLabel = new System.Windows.Forms.ToolStripLabel();
            this.SortByStartTimeButton = new System.Windows.Forms.ToolStripButton();
            this.SortByProjectButton = new System.Windows.Forms.ToolStripButton();
            this.SortByActivityButton = new System.Windows.Forms.ToolStripButton();
            this.SortByLocationButton = new System.Windows.Forms.ToolStripButton();
            this.SortByCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.SortByDurationButton = new System.Windows.Forms.ToolStripButton();
            this.SortByModifiedTimeButton = new System.Windows.Forms.ToolStripButton();
            this.JournalResultsGrid = new System.Windows.Forms.DataGridView();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ResultCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.JournalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsReconciled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ReconcileTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gap = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RunningTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MemoExcerpt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifyTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoToNextDayButton = new System.Windows.Forms.ToolStripButton();
            this.GoToPrevDayButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalResultsGrid)).BeginInit();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectDateLabel,
            this.GoToPrevDayButton,
            this.AuditDate,
            this.GoToNextDayButton,
            this.toolStripSeparator1,
            this.ReconcileAllButton,
            this.RefreshButton,
            this.toolStripSeparator3,
            this.toolStripSeparator2,
            this.SortByLabel,
            this.SortByStartTimeButton,
            this.SortByProjectButton,
            this.SortByActivityButton,
            this.SortByLocationButton,
            this.SortByCategoryButton,
            this.SortByDurationButton,
            this.SortByModifiedTimeButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(1312, 25);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // SelectDateLabel
            // 
            this.SelectDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDateLabel.Name = "SelectDateLabel";
            this.SelectDateLabel.Size = new System.Drawing.Size(75, 22);
            this.SelectDateLabel.Text = "Select Date:";
            // 
            // AuditDate
            // 
            this.AuditDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AuditDate.Name = "AuditDate";
            this.AuditDate.Size = new System.Drawing.Size(100, 25);
            this.AuditDate.Text = "YYYY-MM-DD";
            this.AuditDate.ToolTipText = "Enter date to audit and reconcile in YYYY-MM-DD format";
            this.AuditDate.Leave += new System.EventHandler(this.AuditDate_Leave);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ReconcileAllButton
            // 
            this.ReconcileAllButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ReconcileAllButton.Image = global::Timekeeper.Properties.Resources.ImageButtonBallotBoxList;
            this.ReconcileAllButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ReconcileAllButton.Name = "ReconcileAllButton";
            this.ReconcileAllButton.Size = new System.Drawing.Size(23, 22);
            this.ReconcileAllButton.Text = "Reconcile";
            this.ReconcileAllButton.ToolTipText = "Mark all entries for date as reconciled";
            this.ReconcileAllButton.Click += new System.EventHandler(this.ReconcileAllButton_Click);
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
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // SortByLabel
            // 
            this.SortByLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortByLabel.Name = "SortByLabel";
            this.SortByLabel.Size = new System.Drawing.Size(51, 22);
            this.SortByLabel.Text = "Sort By:";
            // 
            // SortByStartTimeButton
            // 
            this.SortByStartTimeButton.Image = global::Timekeeper.Properties.Resources.ImageIconMedium;
            this.SortByStartTimeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByStartTimeButton.Name = "SortByStartTimeButton";
            this.SortByStartTimeButton.Size = new System.Drawing.Size(80, 22);
            this.SortByStartTimeButton.Text = "Start Time";
            this.SortByStartTimeButton.ToolTipText = "Sort by Journal Start Time";
            this.SortByStartTimeButton.Click += new System.EventHandler(this.SortByStartTimeButton_Click);
            // 
            // SortByProjectButton
            // 
            this.SortByProjectButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallProject;
            this.SortByProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByProjectButton.Name = "SortByProjectButton";
            this.SortByProjectButton.Size = new System.Drawing.Size(64, 22);
            this.SortByProjectButton.Text = "Project";
            this.SortByProjectButton.ToolTipText = "Sort by Project, by Activity";
            this.SortByProjectButton.Click += new System.EventHandler(this.SortByProjectButton_Click);
            // 
            // SortByActivityButton
            // 
            this.SortByActivityButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallActivity;
            this.SortByActivityButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByActivityButton.Name = "SortByActivityButton";
            this.SortByActivityButton.Size = new System.Drawing.Size(67, 22);
            this.SortByActivityButton.Text = "Activity";
            this.SortByActivityButton.ToolTipText = "Sort by Activity, by Project";
            this.SortByActivityButton.Click += new System.EventHandler(this.SortByActivityButton_Click);
            // 
            // SortByLocationButton
            // 
            this.SortByLocationButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallLocation;
            this.SortByLocationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByLocationButton.Name = "SortByLocationButton";
            this.SortByLocationButton.Size = new System.Drawing.Size(73, 22);
            this.SortByLocationButton.Text = "Location";
            this.SortByLocationButton.ToolTipText = "Sort by Location, by Start Time";
            this.SortByLocationButton.Click += new System.EventHandler(this.SortByLocationButton_Click);
            // 
            // SortByCategoryButton
            // 
            this.SortByCategoryButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallCategory;
            this.SortByCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByCategoryButton.Name = "SortByCategoryButton";
            this.SortByCategoryButton.Size = new System.Drawing.Size(75, 22);
            this.SortByCategoryButton.Text = "Category";
            this.SortByCategoryButton.ToolTipText = "Sort by Category, by Project, by Activity";
            this.SortByCategoryButton.Click += new System.EventHandler(this.SortByCategoryButton_Click);
            // 
            // SortByDurationButton
            // 
            this.SortByDurationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SortByDurationButton.Image = ((System.Drawing.Image)(resources.GetObject("SortByDurationButton.Image")));
            this.SortByDurationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByDurationButton.Name = "SortByDurationButton";
            this.SortByDurationButton.Size = new System.Drawing.Size(57, 22);
            this.SortByDurationButton.Text = "Duration";
            this.SortByDurationButton.ToolTipText = "Sort by Journal Entry Duration";
            this.SortByDurationButton.Click += new System.EventHandler(this.SortByDurationButton_Click);
            // 
            // SortByModifiedTimeButton
            // 
            this.SortByModifiedTimeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SortByModifiedTimeButton.Image = ((System.Drawing.Image)(resources.GetObject("SortByModifiedTimeButton.Image")));
            this.SortByModifiedTimeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByModifiedTimeButton.Name = "SortByModifiedTimeButton";
            this.SortByModifiedTimeButton.Size = new System.Drawing.Size(88, 22);
            this.SortByModifiedTimeButton.Text = "Modified Time";
            this.SortByModifiedTimeButton.ToolTipText = "Sort by Journal Entry Modified Time";
            this.SortByModifiedTimeButton.Click += new System.EventHandler(this.SortByModifiedTimeButton_Click);
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
            this.IsReconciled,
            this.ReconcileTime,
            this.StartTime,
            this.StopTime,
            this.Seconds,
            this.Gap,
            this.RunningTotal,
            this.ProjectId,
            this.ProjectName,
            this.ActivityId,
            this.ActivityName,
            this.LocationId,
            this.LocationName,
            this.CategoryId,
            this.CategoryName,
            this.MemoExcerpt,
            this.CreateTime,
            this.ModifyTime});
            this.JournalResultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.JournalResultsGrid.Location = new System.Drawing.Point(0, 25);
            this.JournalResultsGrid.Name = "JournalResultsGrid";
            this.JournalResultsGrid.RowHeadersVisible = false;
            this.JournalResultsGrid.ShowCellToolTips = false;
            this.JournalResultsGrid.Size = new System.Drawing.Size(1312, 246);
            this.JournalResultsGrid.TabIndex = 1;
            this.JournalResultsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JournalFindResults_CellDoubleClick);
            this.JournalResultsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.JournalResultsGrid_CellValueChanged);
            this.JournalResultsGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.JournalResultsGrid_CurrentCellDirtyStateChanged);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResultCount});
            this.StatusBar.Location = new System.Drawing.Point(0, 271);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1312, 22);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "statusStrip1";
            // 
            // ResultCount
            // 
            this.ResultCount.Name = "ResultCount";
            this.ResultCount.Size = new System.Drawing.Size(0, 17);
            // 
            // JournalId
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.JournalId.DefaultCellStyle = dataGridViewCellStyle5;
            this.JournalId.HeaderText = "ID";
            this.JournalId.MinimumWidth = 8;
            this.JournalId.Name = "JournalId";
            this.JournalId.ReadOnly = true;
            this.JournalId.ToolTipText = "Internal Journal Entry Identifier";
            this.JournalId.Width = 43;
            // 
            // IsReconciled
            // 
            this.IsReconciled.HeaderText = "Reconciled?";
            this.IsReconciled.Name = "IsReconciled";
            this.IsReconciled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsReconciled.Width = 75;
            // 
            // ReconcileTime
            // 
            this.ReconcileTime.HeaderText = "Reconciled On";
            this.ReconcileTime.Name = "ReconcileTime";
            this.ReconcileTime.ReadOnly = true;
            this.ReconcileTime.Width = 125;
            // 
            // StartTime
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StartTime.DefaultCellStyle = dataGridViewCellStyle6;
            this.StartTime.HeaderText = "Start";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 60;
            // 
            // StopTime
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StopTime.DefaultCellStyle = dataGridViewCellStyle7;
            this.StopTime.HeaderText = "Stop";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            this.StopTime.Width = 60;
            // 
            // Seconds
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Seconds.DefaultCellStyle = dataGridViewCellStyle8;
            this.Seconds.HeaderText = "Duration";
            this.Seconds.Name = "Seconds";
            this.Seconds.ReadOnly = true;
            this.Seconds.Width = 60;
            // 
            // Gap
            // 
            this.Gap.HeaderText = "Gap";
            this.Gap.Name = "Gap";
            this.Gap.ReadOnly = true;
            this.Gap.Width = 60;
            // 
            // RunningTotal
            // 
            this.RunningTotal.HeaderText = "RunningTotal";
            this.RunningTotal.Name = "RunningTotal";
            this.RunningTotal.ReadOnly = true;
            this.RunningTotal.Width = 80;
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
            // 
            // MemoExcerpt
            // 
            this.MemoExcerpt.HeaderText = "Memo Excerpt";
            this.MemoExcerpt.Name = "MemoExcerpt";
            this.MemoExcerpt.ReadOnly = true;
            // 
            // CreateTime
            // 
            this.CreateTime.HeaderText = "Created On";
            this.CreateTime.Name = "CreateTime";
            this.CreateTime.ReadOnly = true;
            this.CreateTime.Width = 125;
            // 
            // ModifyTime
            // 
            this.ModifyTime.HeaderText = "Modified On";
            this.ModifyTime.Name = "ModifyTime";
            this.ModifyTime.ReadOnly = true;
            this.ModifyTime.Width = 125;
            // 
            // GoToNextDayButton
            // 
            this.GoToNextDayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GoToNextDayButton.Image = global::Timekeeper.Properties.Resources.ImageButtonNext;
            this.GoToNextDayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GoToNextDayButton.Name = "GoToNextDayButton";
            this.GoToNextDayButton.Size = new System.Drawing.Size(23, 22);
            this.GoToNextDayButton.Text = "Next Day";
            this.GoToNextDayButton.Click += new System.EventHandler(this.GoToNextDayButton_Click);
            // 
            // GoToPrevDayButton
            // 
            this.GoToPrevDayButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.GoToPrevDayButton.Image = global::Timekeeper.Properties.Resources.ImageButtonPrev;
            this.GoToPrevDayButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GoToPrevDayButton.Name = "GoToPrevDayButton";
            this.GoToPrevDayButton.Size = new System.Drawing.Size(23, 22);
            this.GoToPrevDayButton.Text = "Prev Day";
            this.GoToPrevDayButton.Click += new System.EventHandler(this.GoToPrevDayButton_Click);
            // 
            // Audit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 293);
            this.Controls.Add(this.JournalResultsGrid);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ToolStrip);
            this.Name = "Audit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Audit";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Find_FormClosing);
            this.Load += new System.EventHandler(this.Find_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.JournalResultsGrid)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.DataGridView JournalResultsGrid;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel ResultCount;
        private System.Windows.Forms.ToolStripTextBox AuditDate;
        private System.Windows.Forms.ToolStripLabel SortByLabel;
        private System.Windows.Forms.ToolStripButton SortByStartTimeButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ReconcileAllButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton SortByProjectButton;
        private System.Windows.Forms.ToolStripButton SortByActivityButton;
        private System.Windows.Forms.ToolStripButton SortByLocationButton;
        private System.Windows.Forms.ToolStripButton SortByCategoryButton;
        private System.Windows.Forms.ToolStripButton SortByDurationButton;
        private System.Windows.Forms.ToolStripButton SortByModifiedTimeButton;
        private System.Windows.Forms.ToolStripLabel SelectDateLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsReconciled;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReconcileTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gap;
        private System.Windows.Forms.DataGridViewTextBoxColumn RunningTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MemoExcerpt;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifyTime;
        private System.Windows.Forms.ToolStripButton GoToPrevDayButton;
        private System.Windows.Forms.ToolStripButton GoToNextDayButton;
    }
}