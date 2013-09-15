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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grid));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.GridControl = new System.Windows.Forms.DataGridView();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.FilterButton = new System.Windows.Forms.ToolStripButton();
            this.OptionsButton = new System.Windows.Forms.ToolStripButton();
            this.GroupByMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.GroupByDayButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByWeekButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByMonthButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByYearButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByNoneButton = new System.Windows.Forms.ToolStripMenuItem();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SaveViewButton = new System.Windows.Forms.ToolStripButton();
            this.ManageViewsButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.PrintButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintSetupButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreviewButton = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupByComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.DimensionComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.TimeDisplayComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Dimension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // GridControl
            // 
            this.GridControl.AllowUserToAddRows = false;
            this.GridControl.AllowUserToDeleteRows = false;
            this.GridControl.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridControl.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.GridControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dimension});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.GridControl.DefaultCellStyle = dataGridViewCellStyle3;
            this.GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridControl.Location = new System.Drawing.Point(0, 25);
            this.GridControl.Name = "GridControl";
            this.GridControl.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.GridControl.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.GridControl.RowHeadersVisible = false;
            this.GridControl.Size = new System.Drawing.Size(837, 258);
            this.GridControl.TabIndex = 14;
            this.GridControl.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterButton,
            this.OptionsButton,
            this.GroupByMenuButton,
            this.toolStripSeparator1,
            this.RefreshButton,
            this.toolStripSeparator3,
            this.LoadMenuButton,
            this.SaveViewButton,
            this.ManageViewsButton,
            this.toolStripSeparator4,
            this.PrintMenuButton,
            this.GroupByComboBox,
            this.DimensionComboBox,
            this.TimeDisplayComboBox});
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
            this.FilterButton.ToolTipText = "Specify criteria to filter results";
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // OptionsButton
            // 
            this.OptionsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.OptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("OptionsButton.Image")));
            this.OptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OptionsButton.Name = "OptionsButton";
            this.OptionsButton.Size = new System.Drawing.Size(60, 22);
            this.OptionsButton.Text = "Options...";
            this.OptionsButton.ToolTipText = "Additional Grid options";
            this.OptionsButton.Click += new System.EventHandler(this.OptionsButton_Click);
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
            this.GroupByMenuButton.ToolTipText = "Specify data grouping";
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
            this.LoadMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadMenuButton.Image")));
            this.LoadMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadMenuButton.Name = "LoadMenuButton";
            this.LoadMenuButton.Size = new System.Drawing.Size(43, 22);
            this.LoadMenuButton.Text = "Load";
            this.LoadMenuButton.ToolTipText = "Load a saved View";
            // 
            // SaveViewButton
            // 
            this.SaveViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewButton.Image")));
            this.SaveViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewButton.Name = "SaveViewButton";
            this.SaveViewButton.Size = new System.Drawing.Size(47, 22);
            this.SaveViewButton.Text = "Save...";
            this.SaveViewButton.ToolTipText = "Save current view for future use";
            this.SaveViewButton.Click += new System.EventHandler(this.SaveViewButton_Click);
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
            this.ManageViewsButton.Click += new System.EventHandler(this.ManageViewsButton_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // PrintMenuButton
            // 
            this.PrintMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintButton,
            this.PrintSetupButton,
            this.PrintPreviewButton});
            this.PrintMenuButton.Image = global::Timekeeper.Properties.Resources.ImageButtonPrinter;
            this.PrintMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintMenuButton.Name = "PrintMenuButton";
            this.PrintMenuButton.Size = new System.Drawing.Size(58, 22);
            this.PrintMenuButton.Text = "Print";
            this.PrintMenuButton.ToolTipText = "Printing commands";
            // 
            // PrintButton
            // 
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(152, 22);
            this.PrintButton.Text = "Print this Report";
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
            // GroupByComboBox
            // 
            this.GroupByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupByComboBox.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month",
            "Year",
            "No Grouping"});
            this.GroupByComboBox.Name = "GroupByComboBox";
            this.GroupByComboBox.Size = new System.Drawing.Size(100, 25);
            this.GroupByComboBox.Visible = false;
            // 
            // DimensionComboBox
            // 
            this.DimensionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DimensionComboBox.Items.AddRange(new object[] {
            "Projects",
            "Activities"});
            this.DimensionComboBox.Name = "DimensionComboBox";
            this.DimensionComboBox.Size = new System.Drawing.Size(80, 25);
            this.DimensionComboBox.Visible = false;
            // 
            // TimeDisplayComboBox
            // 
            this.TimeDisplayComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeDisplayComboBox.Items.AddRange(new object[] {
            "hh:mm:ss",
            "Hours",
            "Minutes",
            "Seconds"});
            this.TimeDisplayComboBox.Name = "TimeDisplayComboBox";
            this.TimeDisplayComboBox.Size = new System.Drawing.Size(75, 25);
            this.TimeDisplayComboBox.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // Dimension
            // 
            this.Dimension.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Dimension.DefaultCellStyle = dataGridViewCellStyle2;
            this.Dimension.Frozen = true;
            this.Dimension.HeaderText = "No Data";
            this.Dimension.Name = "Dimension";
            this.Dimension.ReadOnly = true;
            this.Dimension.Width = 72;
            // 
            // Grid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 283);
            this.Controls.Add(this.GridControl);
            this.Controls.Add(this.ToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(8, 245);
            this.Name = "Grid";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Timekeeper Grid";
            this.Activated += new System.EventHandler(this.Grid_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Grid_FormClosing);
            this.Load += new System.EventHandler(this.Grid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GridControl)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GridControl;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton FilterButton;
        private System.Windows.Forms.ToolStripButton OptionsButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripDropDownButton LoadMenuButton;
        private System.Windows.Forms.ToolStripButton SaveViewButton;
        private System.Windows.Forms.ToolStripButton ManageViewsButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton PrintMenuButton;
        private System.Windows.Forms.ToolStripMenuItem PrintButton;
        private System.Windows.Forms.ToolStripMenuItem PrintSetupButton;
        private System.Windows.Forms.ToolStripMenuItem PrintPreviewButton;
        private System.Windows.Forms.ToolStripComboBox GroupByComboBox;
        private System.Windows.Forms.ToolStripComboBox DimensionComboBox;
        private System.Windows.Forms.ToolStripComboBox TimeDisplayComboBox;
        private System.Windows.Forms.ToolStripDropDownButton GroupByMenuButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByDayButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByWeekButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByMonthButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByYearButton;
        private System.Windows.Forms.ToolStripMenuItem GroupByNoneButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dimension;
    }
}