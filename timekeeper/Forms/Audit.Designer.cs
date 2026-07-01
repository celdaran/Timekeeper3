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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Audit));
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.JournalResultsGrid = new System.Windows.Forms.DataGridView();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Seconds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ActivityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsReconciled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsIgnored = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsLocked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.JournalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ResultCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.AuditDate = new System.Windows.Forms.ToolStripTextBox();
            this.SortByStartTimeButton = new System.Windows.Forms.ToolStripButton();
            this.SortByLabel = new System.Windows.Forms.ToolStripLabel();
            this.SortByCategoryButton = new System.Windows.Forms.ToolStripButton();
            this.SortByProjectButton = new System.Windows.Forms.ToolStripButton();
            this.SortByActivityButton = new System.Windows.Forms.ToolStripButton();
            this.SortByLocationButton = new System.Windows.Forms.ToolStripButton();
            this.SortByDurationButton = new System.Windows.Forms.ToolStripButton();
            this.SortByModifiedTimeButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ReconcileAllButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectDateLabel = new System.Windows.Forms.ToolStripLabel();
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
            this.AuditDate,
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
            this.ToolStrip.Size = new System.Drawing.Size(893, 25);
            this.ToolStrip.TabIndex = 0;
            this.ToolStrip.Text = "ToolStrip";
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
            this.ProjectId,
            this.ProjectName,
            this.ActivityId,
            this.ActivityName,
            this.LocationId,
            this.LocationName,
            this.CategoryId,
            this.CategoryName,
            this.Memo,
            this.IsReconciled,
            this.IsIgnored,
            this.IsLocked,
            this.JournalId});
            this.JournalResultsGrid.Location = new System.Drawing.Point(0, 25);
            this.JournalResultsGrid.Name = "JournalResultsGrid";
            this.JournalResultsGrid.RowHeadersVisible = false;
            this.JournalResultsGrid.ShowCellToolTips = false;
            this.JournalResultsGrid.Size = new System.Drawing.Size(893, 110);
            this.JournalResultsGrid.TabIndex = 1;
            this.JournalResultsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.JournalFindResults_CellDoubleClick);
            this.JournalResultsGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.JournalResultsGrid_CellValueChanged);
            this.JournalResultsGrid.CurrentCellDirtyStateChanged += new System.EventHandler(this.JournalResultsGrid_CurrentCellDirtyStateChanged);
            // 
            // StartTime
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StartTime.DefaultCellStyle = dataGridViewCellStyle9;
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 80;
            // 
            // StopTime
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.StopTime.DefaultCellStyle = dataGridViewCellStyle10;
            this.StopTime.HeaderText = "Stop Time";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            this.StopTime.Width = 80;
            // 
            // Seconds
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Seconds.DefaultCellStyle = dataGridViewCellStyle11;
            this.Seconds.HeaderText = "Duration";
            this.Seconds.Name = "Seconds";
            this.Seconds.ReadOnly = true;
            this.Seconds.Width = 72;
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
            // Memo
            // 
            this.Memo.HeaderText = "Memo";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            // 
            // IsReconciled
            // 
            this.IsReconciled.HeaderText = "Reconciled?";
            this.IsReconciled.Name = "IsReconciled";
            this.IsReconciled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsIgnored
            // 
            this.IsIgnored.HeaderText = "Ignored?";
            this.IsIgnored.Name = "IsIgnored";
            this.IsIgnored.ReadOnly = true;
            this.IsIgnored.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsLocked
            // 
            this.IsLocked.HeaderText = "Locked";
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.ReadOnly = true;
            this.IsLocked.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsLocked.Width = 40;
            // 
            // JournalId
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.JournalId.DefaultCellStyle = dataGridViewCellStyle12;
            this.JournalId.HeaderText = "ID";
            this.JournalId.MinimumWidth = 8;
            this.JournalId.Name = "JournalId";
            this.JournalId.ReadOnly = true;
            this.JournalId.ToolTipText = "Internal Journal Entry Identifier";
            this.JournalId.Width = 43;
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
            // AuditDate
            // 
            this.AuditDate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.AuditDate.Name = "AuditDate";
            this.AuditDate.Size = new System.Drawing.Size(100, 25);
            this.AuditDate.Text = "2026-07-01";
            this.AuditDate.ToolTipText = "Enter date to audit and reconcile in YYYY-MM-DD format";
            this.AuditDate.Leave += new System.EventHandler(this.AuditDate_Leave);
            // 
            // SortByStartTimeButton
            // 
            this.SortByStartTimeButton.Image = global::Timekeeper.Properties.Resources.ImageIconMedium;
            this.SortByStartTimeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByStartTimeButton.Name = "SortByStartTimeButton";
            this.SortByStartTimeButton.Size = new System.Drawing.Size(80, 22);
            this.SortByStartTimeButton.Text = "Start Time";
            this.SortByStartTimeButton.ToolTipText = "Sort by Journal Start Time";
            // 
            // SortByLabel
            // 
            this.SortByLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SortByLabel.Name = "SortByLabel";
            this.SortByLabel.Size = new System.Drawing.Size(51, 22);
            this.SortByLabel.Text = "Sort By:";
            // 
            // SortByCategoryButton
            // 
            this.SortByCategoryButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallCategory;
            this.SortByCategoryButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByCategoryButton.Name = "SortByCategoryButton";
            this.SortByCategoryButton.Size = new System.Drawing.Size(75, 22);
            this.SortByCategoryButton.Text = "Category";
            this.SortByCategoryButton.ToolTipText = "Sort by Category, by Project, by Activity";
            // 
            // SortByProjectButton
            // 
            this.SortByProjectButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallProject;
            this.SortByProjectButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByProjectButton.Name = "SortByProjectButton";
            this.SortByProjectButton.Size = new System.Drawing.Size(64, 22);
            this.SortByProjectButton.Text = "Project";
            this.SortByProjectButton.ToolTipText = "Sort by Project, by Activity";
            // 
            // SortByActivityButton
            // 
            this.SortByActivityButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallActivity;
            this.SortByActivityButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByActivityButton.Name = "SortByActivityButton";
            this.SortByActivityButton.Size = new System.Drawing.Size(67, 22);
            this.SortByActivityButton.Text = "Activity";
            this.SortByActivityButton.ToolTipText = "Sort by Activity, by Project";
            // 
            // SortByLocationButton
            // 
            this.SortByLocationButton.Image = global::Timekeeper.Properties.Resources.ImageIconSmallLocation;
            this.SortByLocationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortByLocationButton.Name = "SortByLocationButton";
            this.SortByLocationButton.Size = new System.Drawing.Size(73, 22);
            this.SortByLocationButton.Text = "Location";
            this.SortByLocationButton.ToolTipText = "Sort by Location, by Start Time";
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
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // SelectDateLabel
            // 
            this.SelectDateLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelectDateLabel.Name = "SelectDateLabel";
            this.SelectDateLabel.Size = new System.Drawing.Size(75, 22);
            this.SelectDateLabel.Text = "Select Date:";
            // 
            // Audit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 293);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Seconds;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ActivityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoryName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsReconciled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsIgnored;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLocked;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalId;
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
    }
}