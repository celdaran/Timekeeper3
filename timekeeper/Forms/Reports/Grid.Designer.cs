namespace Timekeeper.Forms.Reports
{
    partial class Grid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid));
            this.wGrid = new System.Windows.Forms.DataGridView();
            this.task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.FilterButton = new System.Windows.Forms.ToolStripButton();
            this.GroupByMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.GroupByDayButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByWeekButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByMonthButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByYearButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByNoneButton = new System.Windows.Forms.ToolStripMenuItem();
            this.OptionsButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.lastRunReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveOptionsButton = new System.Windows.Forms.ToolStripButton();
            this.ManageOptionsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.PrintReportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintSetupButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreviewButton = new System.Windows.Forms.ToolStripMenuItem();
            this.wGroupBy = new System.Windows.Forms.ToolStripComboBox();
            this.wDataType = new System.Windows.Forms.ToolStripComboBox();
            this.wTimeFormat = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.wGrid)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // wGrid
            // 
            this.wGrid.AllowUserToAddRows = false;
            this.wGrid.AllowUserToDeleteRows = false;
            this.wGrid.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.wGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.task});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.wGrid.DefaultCellStyle = dataGridViewCellStyle3;
            this.wGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wGrid.Location = new System.Drawing.Point(0, 25);
            this.wGrid.Name = "wGrid";
            this.wGrid.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.wGrid.RowHeadersVisible = false;
            this.wGrid.Size = new System.Drawing.Size(837, 258);
            this.wGrid.TabIndex = 14;
            this.wGrid.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // task
            // 
            this.task.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.task.DefaultCellStyle = dataGridViewCellStyle2;
            this.task.Frozen = true;
            this.task.HeaderText = "Task";
            this.task.Name = "task";
            this.task.ReadOnly = true;
            this.task.Width = 56;
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterButton,
            this.OptionsButton,
            this.GroupByMenuButton,
            this.RefreshButton,
            this.toolStripSeparator3,
            this.LoadMenuButton,
            this.SaveOptionsButton,
            this.ManageOptionsButton,
            this.toolStripSeparator4,
            this.PrintMenuButton,
            this.wGroupBy,
            this.wDataType,
            this.wTimeFormat});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(837, 25);
            this.ToolStrip.TabIndex = 16;
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
            // GroupByMenuButton
            // 
            this.GroupByMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GroupByMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GroupByDayButton,
            this.GroupByWeekButton,
            this.GroupByMonthButton,
            this.GroupByYearButton,
            this.GroupByNoneButton});
            this.GroupByMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("GroupByMenuButton.Image")));
            this.GroupByMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GroupByMenuButton.Name = "GroupByMenuButton";
            this.GroupByMenuButton.Size = new System.Drawing.Size(64, 22);
            this.GroupByMenuButton.Text = "Group By";
            // 
            // GroupByDayButton
            // 
            this.GroupByDayButton.Name = "GroupByDayButton";
            this.GroupByDayButton.Size = new System.Drawing.Size(152, 22);
            this.GroupByDayButton.Text = "Day";
            this.GroupByDayButton.Click += new System.EventHandler(this.GroupByDayButton_Click);
            // 
            // GroupByWeekButton
            // 
            this.GroupByWeekButton.Name = "GroupByWeekButton";
            this.GroupByWeekButton.Size = new System.Drawing.Size(152, 22);
            this.GroupByWeekButton.Text = "Week";
            this.GroupByWeekButton.Click += new System.EventHandler(this.GroupByWeekButton_Click);
            // 
            // GroupByMonthButton
            // 
            this.GroupByMonthButton.Name = "GroupByMonthButton";
            this.GroupByMonthButton.Size = new System.Drawing.Size(152, 22);
            this.GroupByMonthButton.Text = "Month";
            this.GroupByMonthButton.Click += new System.EventHandler(this.GroupByMonthButton_Click);
            // 
            // GroupByYearButton
            // 
            this.GroupByYearButton.Name = "GroupByYearButton";
            this.GroupByYearButton.Size = new System.Drawing.Size(152, 22);
            this.GroupByYearButton.Text = "Year";
            this.GroupByYearButton.Click += new System.EventHandler(this.GroupByYearButton_Click);
            // 
            // GroupByNoneButton
            // 
            this.GroupByNoneButton.Checked = true;
            this.GroupByNoneButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GroupByNoneButton.Name = "GroupByNoneButton";
            this.GroupByNoneButton.Size = new System.Drawing.Size(152, 22);
            this.GroupByNoneButton.Text = "No Grouping";
            this.GroupByNoneButton.Click += new System.EventHandler(this.GroupByNoneButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("OptionsButton.Image")));
            this.OptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(60, 22);
            this.OptionsButton.Text = "Options...";
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
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
            // LoadMenuButton
            // 
            this.LoadMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastRunReportToolStripMenuItem});
            this.LoadMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadMenuButton.Image")));
            this.LoadMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadMenuButton.Name = "LoadMenuButton";
            this.LoadMenuButton.Size = new System.Drawing.Size(43, 22);
            this.LoadMenuButton.Text = "Load";
            // 
            // lastRunReportToolStripMenuItem
            // 
            this.lastRunReportToolStripMenuItem.Name = "lastRunReportToolStripMenuItem";
            this.lastRunReportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lastRunReportToolStripMenuItem.Text = "Last Run Report";
            // 
            // SaveOptionsButton
            // 
            this.SaveOptionsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveOptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveOptionsButton.Image")));
            this.SaveOptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveOptionsButton.Name = "SaveOptionsButton";
            this.SaveOptionsButton.Size = new System.Drawing.Size(47, 22);
            this.SaveOptionsButton.Text = "Save...";
            this.SaveOptionsButton.Click += new System.EventHandler(this.SaveOptionsButton_Click);
            // 
            // ManageOptionsButton
            // 
            this.ManageOptionsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageOptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("ManageOptionsButton.Image")));
            this.ManageOptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageOptionsButton.Name = "ManageOptionsButton";
            this.ManageOptionsButton.Size = new System.Drawing.Size(61, 22);
            this.ManageOptionsButton.Text = "Manage...";
            this.ManageOptionsButton.Click += new System.EventHandler(this.ManageOptionsButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // PrintMenuButton
            // 
            this.PrintMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintReportButton,
            this.PrintSetupButton,
            this.PrintPreviewButton});
            this.PrintMenuButton.Image = global::Timekeeper.Properties.Resources.ImageButtonPrinter;
            this.PrintMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintMenuButton.Name = "PrintMenuButton";
            this.PrintMenuButton.Size = new System.Drawing.Size(58, 22);
            this.PrintMenuButton.Text = "Print";
            // 
            // PrintReportButton
            // 
            this.PrintReportButton.Name = "PrintReportButton";
            this.PrintReportButton.Size = new System.Drawing.Size(152, 22);
            this.PrintReportButton.Text = "Print this Report";
            // 
            // PrintSetupButton
            // 
            this.PrintSetupButton.Name = "PrintSetupButton";
            this.PrintSetupButton.Size = new System.Drawing.Size(152, 22);
            this.PrintSetupButton.Text = "Print Setup...";
            // 
            // PrintPreviewButton
            // 
            this.PrintPreviewButton.Name = "PrintPreviewButton";
            this.PrintPreviewButton.Size = new System.Drawing.Size(152, 22);
            this.PrintPreviewButton.Text = "Print Preview...";
            // 
            // wGroupBy
            // 
            this.wGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wGroupBy.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month",
            "Year",
            "No Grouping"});
            this.wGroupBy.Name = "wGroupBy";
            this.wGroupBy.Size = new System.Drawing.Size(100, 25);
            // 
            // wDataType
            // 
            this.wDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wDataType.Items.AddRange(new object[] {
            "Projects",
            "Activities"});
            this.wDataType.Name = "wDataType";
            this.wDataType.Size = new System.Drawing.Size(80, 25);
            // 
            // wTimeFormat
            // 
            this.wTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wTimeFormat.Items.AddRange(new object[] {
            "hh:mm:ss",
            "Hours",
            "Minutes",
            "Seconds"});
            this.wTimeFormat.Name = "wTimeFormat";
            this.wTimeFormat.Size = new System.Drawing.Size(75, 25);
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 283);
            this.Controls.Add(this.wGrid);
            this.Controls.Add(this.ToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(8, 245);
            this.Name = "Grid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Timekeeper Grid";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Grid_FormClosing);
            this.Load += new System.EventHandler(this.Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wGrid)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView wGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn task;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton FilterButton;
        private System.Windows.Forms.ToolStripButton OptionsButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton LoadMenuButton;
        private System.Windows.Forms.ToolStripMenuItem lastRunReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SaveOptionsButton;
        private System.Windows.Forms.ToolStripButton ManageOptionsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton PrintMenuButton;
        private System.Windows.Forms.ToolStripMenuItem PrintReportButton;
        private System.Windows.Forms.ToolStripMenuItem PrintSetupButton;
        private System.Windows.Forms.ToolStripMenuItem PrintPreviewButton;
        private System.Windows.Forms.ToolStripComboBox wGroupBy;
        private System.Windows.Forms.ToolStripComboBox wDataType;
        private System.Windows.Forms.ToolStripComboBox wTimeFormat;
        private System.Windows.Forms.ToolStripDropDownButton GroupByMenuButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByDayButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByWeekButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByMonthButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByYearButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByNoneButton;
    }
}