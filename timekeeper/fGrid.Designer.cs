namespace Timekeeper
{
    partial class fGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fGrid));
            this.wGrid = new System.Windows.Forms.DataGridView();
            this.task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.wGroupOptions = new System.Windows.Forms.GroupBox();
            this.wTimeFormat = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.wDataType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.wGroupBy = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.wHideEmptyRows = new System.Windows.Forms.CheckBox();
            this.wGroupDates = new System.Windows.Forms.GroupBox();
            this.wDatePreset = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.wEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.wStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnClose = new System.Windows.Forms.Button();
            this.wToolbar = new System.Windows.Forms.ToolStrip();
            this.btnFilter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnLoadViewDropDown = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnSaveView2 = new System.Windows.Forms.ToolStripButton();
            this.btnManageViews = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.wGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.wGroupOptions.SuspendLayout();
            this.wGroupDates.SuspendLayout();
            this.wToolbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // wGrid
            // 
            this.wGrid.AllowUserToAddRows = false;
            this.wGrid.AllowUserToDeleteRows = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.wGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.task});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.wGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.wGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wGrid.Location = new System.Drawing.Point(0, 25);
            this.wGrid.Name = "wGrid";
            this.wGrid.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.wGrid.RowHeadersVisible = false;
            this.wGrid.Size = new System.Drawing.Size(572, 198);
            this.wGrid.TabIndex = 14;
            this.wGrid.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // task
            // 
            this.task.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.task.DefaultCellStyle = dataGridViewCellStyle6;
            this.task.Frozen = true;
            this.task.HeaderText = "Task";
            this.task.Name = "task";
            this.task.ReadOnly = true;
            this.task.Width = 56;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Controls.Add(this.wGroupOptions);
            this.panel1.Controls.Add(this.wGroupDates);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 223);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 152);
            this.panel1.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(485, 85);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 12;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.btnRefresh.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wGroupOptions
            // 
            this.wGroupOptions.Controls.Add(this.wTimeFormat);
            this.wGroupOptions.Controls.Add(this.label6);
            this.wGroupOptions.Controls.Add(this.wDataType);
            this.wGroupOptions.Controls.Add(this.label5);
            this.wGroupOptions.Controls.Add(this.wGroupBy);
            this.wGroupOptions.Controls.Add(this.label4);
            this.wGroupOptions.Controls.Add(this.wHideEmptyRows);
            this.wGroupOptions.Location = new System.Drawing.Point(240, 10);
            this.wGroupOptions.Name = "wGroupOptions";
            this.wGroupOptions.Size = new System.Drawing.Size(216, 130);
            this.wGroupOptions.TabIndex = 2;
            this.wGroupOptions.TabStop = false;
            this.wGroupOptions.Text = "Grid Options";
            this.wGroupOptions.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wTimeFormat
            // 
            this.wTimeFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wTimeFormat.FormattingEnabled = true;
            this.wTimeFormat.Items.AddRange(new object[] {
            "hh:mm:ss",
            "Minutes",
            "Seconds"});
            this.wTimeFormat.Location = new System.Drawing.Point(106, 75);
            this.wTimeFormat.Name = "wTimeFormat";
            this.wTimeFormat.Size = new System.Drawing.Size(90, 21);
            this.wTimeFormat.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Display time as:";
            // 
            // wDataType
            // 
            this.wDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wDataType.FormattingEnabled = true;
            this.wDataType.Items.AddRange(new object[] {
            "Tasks",
            "Projects"});
            this.wDataType.Location = new System.Drawing.Point(105, 48);
            this.wDataType.Name = "wDataType";
            this.wDataType.Size = new System.Drawing.Size(90, 21);
            this.wDataType.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Grid &data from:";
            // 
            // wGroupBy
            // 
            this.wGroupBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wGroupBy.FormattingEnabled = true;
            this.wGroupBy.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month",
            "Year",
            "No Grouping"});
            this.wGroupBy.Location = new System.Drawing.Point(105, 20);
            this.wGroupBy.Name = "wGroupBy";
            this.wGroupBy.Size = new System.Drawing.Size(90, 21);
            this.wGroupBy.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "&Group data by:";
            // 
            // wHideEmptyRows
            // 
            this.wHideEmptyRows.AutoSize = true;
            this.wHideEmptyRows.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.wHideEmptyRows.Checked = true;
            this.wHideEmptyRows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wHideEmptyRows.Location = new System.Drawing.Point(15, 104);
            this.wHideEmptyRows.Name = "wHideEmptyRows";
            this.wHideEmptyRows.Size = new System.Drawing.Size(104, 17);
            this.wHideEmptyRows.TabIndex = 11;
            this.wHideEmptyRows.Text = "Hide empty rows";
            this.wHideEmptyRows.UseVisualStyleBackColor = true;
            this.wHideEmptyRows.Visible = false;
            this.wHideEmptyRows.Click += new System.EventHandler(this.wHideEmptyRows_Click);
            // 
            // wGroupDates
            // 
            this.wGroupDates.Controls.Add(this.wDatePreset);
            this.wGroupDates.Controls.Add(this.label3);
            this.wGroupDates.Controls.Add(this.label2);
            this.wGroupDates.Controls.Add(this.wEndDate);
            this.wGroupDates.Controls.Add(this.label1);
            this.wGroupDates.Controls.Add(this.wStartDate);
            this.wGroupDates.Location = new System.Drawing.Point(10, 10);
            this.wGroupDates.Name = "wGroupDates";
            this.wGroupDates.Size = new System.Drawing.Size(220, 130);
            this.wGroupDates.TabIndex = 1;
            this.wGroupDates.TabStop = false;
            this.wGroupDates.Text = "Date Range";
            this.wGroupDates.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wDatePreset
            // 
            this.wDatePreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wDatePreset.FormattingEnabled = true;
            this.wDatePreset.Items.AddRange(new object[] {
            "Today",
            "Yesterday",
            "Previous Day",
            "This Week",
            "This Month",
            "Last Month",
            "This Year",
            "Last Year",
            "All",
            "Custom"});
            this.wDatePreset.Location = new System.Drawing.Point(77, 20);
            this.wDatePreset.Name = "wDatePreset";
            this.wDatePreset.Size = new System.Drawing.Size(125, 21);
            this.wDatePreset.TabIndex = 2;
            this.wDatePreset.SelectedIndexChanged += new System.EventHandler(this.wDatePreset_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Prese&t:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "&End date:";
            // 
            // wEndDate
            // 
            this.wEndDate.CustomFormat = "yyyy-MM-dd";
            this.wEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.wEndDate.Location = new System.Drawing.Point(77, 74);
            this.wEndDate.Name = "wEndDate";
            this.wEndDate.Size = new System.Drawing.Size(125, 20);
            this.wEndDate.TabIndex = 6;
            this.wEndDate.Enter += new System.EventHandler(this.wStartDate_Enter);
            this.wEndDate.Leave += new System.EventHandler(this.wStartDate_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "&Start date:";
            // 
            // wStartDate
            // 
            this.wStartDate.CustomFormat = "yyyy-MM-dd";
            this.wStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.wStartDate.Location = new System.Drawing.Point(77, 48);
            this.wStartDate.Name = "wStartDate";
            this.wStartDate.Size = new System.Drawing.Size(125, 20);
            this.wStartDate.TabIndex = 4;
            this.wStartDate.Enter += new System.EventHandler(this.wStartDate_Enter);
            this.wStartDate.Leave += new System.EventHandler(this.wStartDate_Leave);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(485, 114);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wToolbar
            // 
            this.wToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.wToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFilter,
            this.toolStripSeparator1,
            this.btnLoadViewDropDown,
            this.btnSaveView2,
            this.btnManageViews,
            this.toolStripSeparator2});
            this.wToolbar.Location = new System.Drawing.Point(0, 0);
            this.wToolbar.Name = "wToolbar";
            this.wToolbar.Size = new System.Drawing.Size(572, 25);
            this.wToolbar.TabIndex = 15;
            this.wToolbar.Text = "toolStrip1";
            this.wToolbar.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnFilter
            // 
            this.btnFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFilter.Image = ((System.Drawing.Image)(resources.GetObject("btnFilter.Image")));
            this.btnFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(111, 22);
            this.btnFilter.Text = "Additional &Filtering...";
            this.btnFilter.ToolTipText = "Filter data";
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnLoadViewDropDown
            // 
            this.btnLoadViewDropDown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnLoadViewDropDown.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadViewDropDown.Image")));
            this.btnLoadViewDropDown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadViewDropDown.Name = "btnLoadViewDropDown";
            this.btnLoadViewDropDown.Size = new System.Drawing.Size(68, 22);
            this.btnLoadViewDropDown.Text = "&Load View";
            // 
            // btnSaveView2
            // 
            this.btnSaveView2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSaveView2.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveView2.Image")));
            this.btnSaveView2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveView2.Name = "btnSaveView2";
            this.btnSaveView2.Size = new System.Drawing.Size(72, 22);
            this.btnSaveView2.Text = "Save &View...";
            this.btnSaveView2.Click += new System.EventHandler(this.btnSaveView2_Click);
            // 
            // btnManageViews
            // 
            this.btnManageViews.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnManageViews.Image = ((System.Drawing.Image)(resources.GetObject("btnManageViews.Image")));
            this.btnManageViews.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnManageViews.Name = "btnManageViews";
            this.btnManageViews.Size = new System.Drawing.Size(91, 22);
            this.btnManageViews.Text = "&Manage Views...";
            this.btnManageViews.Click += new System.EventHandler(this.btnManageViews_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // fGrid
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(572, 375);
            this.Controls.Add(this.wGrid);
            this.Controls.Add(this.wToolbar);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(8, 245);
            this.Name = "fGrid";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Time Grid";
            this.Load += new System.EventHandler(this.fGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.wGroupOptions.ResumeLayout(false);
            this.wGroupOptions.PerformLayout();
            this.wGroupDates.ResumeLayout(false);
            this.wGroupDates.PerformLayout();
            this.wToolbar.ResumeLayout(false);
            this.wToolbar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView wGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox wGroupDates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker wEndDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker wStartDate;
        private System.Windows.Forms.GroupBox wGroupOptions;
        private System.Windows.Forms.ComboBox wGroupBy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox wHideEmptyRows;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox wDataType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn task;
        private System.Windows.Forms.ToolStrip wToolbar;
        private System.Windows.Forms.ToolStripButton btnFilter;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnSaveView2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton btnLoadViewDropDown;
        private System.Windows.Forms.ToolStripButton btnManageViews;
        internal System.Windows.Forms.ComboBox wDatePreset;
        private System.Windows.Forms.ComboBox wTimeFormat;
        private System.Windows.Forms.Label label6;
    }
}