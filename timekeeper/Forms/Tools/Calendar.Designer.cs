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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CalendarSplitContainer = new System.Windows.Forms.SplitContainer();
            this.CalendarControl = new System.Windows.Forms.MonthCalendar();
            this.FilterResultsGrid = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.CalendarSplitContainer)).BeginInit();
            this.CalendarSplitContainer.Panel1.SuspendLayout();
            this.CalendarSplitContainer.Panel2.SuspendLayout();
            this.CalendarSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FilterResultsGrid)).BeginInit();
            this.SuspendLayout();
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
            this.CalendarSplitContainer.Panel1.Controls.Add(this.CalendarControl);
            // 
            // CalendarSplitContainer.Panel2
            // 
            this.CalendarSplitContainer.Panel2.Controls.Add(this.FilterResultsGrid);
            this.CalendarSplitContainer.Size = new System.Drawing.Size(740, 224);
            this.CalendarSplitContainer.SplitterDistance = 239;
            this.CalendarSplitContainer.TabIndex = 5;
            // 
            // CalendarControl
            // 
            this.CalendarControl.BackColor = System.Drawing.Color.White;
            this.CalendarControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalendarControl.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendarControl.ForeColor = System.Drawing.Color.Black;
            this.CalendarControl.Location = new System.Drawing.Point(0, 0);
            this.CalendarControl.MaxSelectionCount = 1;
            this.CalendarControl.Name = "CalendarControl";
            this.CalendarControl.ScrollChange = 1;
            this.CalendarControl.ShowTodayCircle = false;
            this.CalendarControl.ShowWeekNumbers = true;
            this.CalendarControl.TabIndex = 1;
            this.CalendarControl.TrailingForeColor = System.Drawing.Color.Silver;
            this.CalendarControl.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.CalendarControl_DateChanged);
            // 
            // FilterResultsGrid
            // 
            this.FilterResultsGrid.AllowUserToAddRows = false;
            this.FilterResultsGrid.AllowUserToDeleteRows = false;
            this.FilterResultsGrid.AllowUserToOrderColumns = true;
            this.FilterResultsGrid.AllowUserToResizeRows = false;
            this.FilterResultsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.FilterResultsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FilterResultsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.FilterResultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilterResultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
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
            this.FilterResultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterResultsGrid.Location = new System.Drawing.Point(0, 0);
            this.FilterResultsGrid.Name = "FilterResultsGrid";
            this.FilterResultsGrid.RowHeadersVisible = false;
            this.FilterResultsGrid.Size = new System.Drawing.Size(497, 224);
            this.FilterResultsGrid.TabIndex = 2;
            this.FilterResultsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilterResultsGrid_CellDoubleClick);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Seconds.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.JournalId.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.ClientSize = new System.Drawing.Size(740, 271);
            this.Controls.Add(this.CalendarSplitContainer);
            this.Name = "Calendar";
            this.Text = "Calendar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Calendar_FormClosing);
            this.Load += new System.EventHandler(this.Calendar_Load);
            this.Controls.SetChildIndex(this.CalendarSplitContainer, 0);
            this.CalendarSplitContainer.Panel1.ResumeLayout(false);
            this.CalendarSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CalendarSplitContainer)).EndInit();
            this.CalendarSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FilterResultsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer CalendarSplitContainer;
        private System.Windows.Forms.MonthCalendar CalendarControl;
        private System.Windows.Forms.DataGridView FilterResultsGrid;
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