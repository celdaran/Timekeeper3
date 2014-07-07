namespace Timekeeper.Forms.Reports
{
    partial class DatabaseCheck
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
            this.DatabaseCheckResultsGrid = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StartButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBox = new System.Windows.Forms.ToolStripStatusLabel();
            this.JournalId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Issue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StopTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Memo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseCheckResultsGrid)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DatabaseCheckResultsGrid
            // 
            this.DatabaseCheckResultsGrid.AllowUserToAddRows = false;
            this.DatabaseCheckResultsGrid.AllowUserToDeleteRows = false;
            this.DatabaseCheckResultsGrid.AllowUserToOrderColumns = true;
            this.DatabaseCheckResultsGrid.AllowUserToResizeRows = false;
            this.DatabaseCheckResultsGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DatabaseCheckResultsGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DatabaseCheckResultsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.DatabaseCheckResultsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatabaseCheckResultsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.JournalId,
            this.Issue,
            this.StartTime,
            this.StopTime,
            this.Memo});
            this.DatabaseCheckResultsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DatabaseCheckResultsGrid.Location = new System.Drawing.Point(0, 25);
            this.DatabaseCheckResultsGrid.MultiSelect = false;
            this.DatabaseCheckResultsGrid.Name = "DatabaseCheckResultsGrid";
            this.DatabaseCheckResultsGrid.ReadOnly = true;
            this.DatabaseCheckResultsGrid.RowHeadersVisible = false;
            this.DatabaseCheckResultsGrid.Size = new System.Drawing.Size(774, 245);
            this.DatabaseCheckResultsGrid.TabIndex = 4;
            this.DatabaseCheckResultsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DatabaseCheckResultsGrid_CellDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StartButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(774, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StartButton
            // 
            this.StartButton.Image = global::Timekeeper.Properties.Resources.ImageButtonGo;
            this.StartButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(51, 22);
            this.StartButton.Text = "Start";
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.StatusBox});
            this.statusStrip1.Location = new System.Drawing.Point(0, 270);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            this.ProgressBar.Visible = false;
            // 
            // StatusBox
            // 
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(38, 17);
            this.StatusBox.Text = "Status";
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
            // Issue
            // 
            this.Issue.HeaderText = "Issue";
            this.Issue.Name = "Issue";
            this.Issue.ReadOnly = true;
            this.Issue.Width = 200;
            // 
            // StartTime
            // 
            this.StartTime.HeaderText = "Start Time";
            this.StartTime.Name = "StartTime";
            this.StartTime.ReadOnly = true;
            this.StartTime.Width = 120;
            // 
            // StopTime
            // 
            this.StopTime.HeaderText = "Stop Time";
            this.StopTime.Name = "StopTime";
            this.StopTime.ReadOnly = true;
            this.StopTime.Width = 120;
            // 
            // Memo
            // 
            this.Memo.HeaderText = "Memo";
            this.Memo.Name = "Memo";
            this.Memo.ReadOnly = true;
            // 
            // DatabaseCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 292);
            this.Controls.Add(this.DatabaseCheckResultsGrid);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.HelpButton = true;
            this.Name = "DatabaseCheck";
            this.ShowIcon = false;
            this.Text = "Database Check";
            ((System.ComponentModel.ISupportInitialize)(this.DatabaseCheckResultsGrid)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DatabaseCheckResultsGrid;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton StartButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn JournalId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Issue;
        private System.Windows.Forms.DataGridViewTextBoxColumn StartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn StopTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Memo;
    }
}