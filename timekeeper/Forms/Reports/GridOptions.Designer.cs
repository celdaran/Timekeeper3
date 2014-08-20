namespace Timekeeper.Forms.Reports
{
    partial class GridOptions
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
            this.DisplayLabel = new System.Windows.Forms.Label();
            this.DimensionLabel = new System.Windows.Forms.Label();
            this.TimeDisplay = new System.Windows.Forms.ComboBox();
            this.Dimension = new System.Windows.Forms.ComboBox();
            this.GroupByLabel = new System.Windows.Forms.Label();
            this.GroupDataBy = new System.Windows.Forms.ComboBox();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DisplayLabel
            // 
            this.DisplayLabel.AutoSize = true;
            this.DisplayLabel.Location = new System.Drawing.Point(12, 63);
            this.DisplayLabel.Name = "DisplayLabel";
            this.DisplayLabel.Size = new System.Drawing.Size(85, 13);
            this.DisplayLabel.TabIndex = 5;
            this.DisplayLabel.Text = "Display Time As:";
            // 
            // DimensionLabel
            // 
            this.DimensionLabel.AutoSize = true;
            this.DimensionLabel.Location = new System.Drawing.Point(12, 36);
            this.DimensionLabel.Name = "DimensionLabel";
            this.DimensionLabel.Size = new System.Drawing.Size(59, 13);
            this.DimensionLabel.TabIndex = 4;
            this.DimensionLabel.Text = "Dimension:";
            // 
            // TimeDisplay
            // 
            this.TimeDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TimeDisplay.FormattingEnabled = true;
            this.TimeDisplay.Items.AddRange(new object[] {
            "hh:mm:ss",
            "Hours",
            "Minutes",
            "Seconds"});
            this.TimeDisplay.Location = new System.Drawing.Point(120, 61);
            this.TimeDisplay.Name = "TimeDisplay";
            this.TimeDisplay.Size = new System.Drawing.Size(156, 21);
            this.TimeDisplay.TabIndex = 3;
            // 
            // Dimension
            // 
            this.Dimension.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Dimension.FormattingEnabled = true;
            this.Dimension.Items.AddRange(new object[] {
            "Project",
            "Activity",
            "Location",
            "Category"});
            this.Dimension.Location = new System.Drawing.Point(120, 33);
            this.Dimension.Name = "Dimension";
            this.Dimension.Size = new System.Drawing.Size(156, 21);
            this.Dimension.TabIndex = 2;
            // 
            // GroupByLabel
            // 
            this.GroupByLabel.AutoSize = true;
            this.GroupByLabel.Location = new System.Drawing.Point(12, 9);
            this.GroupByLabel.Name = "GroupByLabel";
            this.GroupByLabel.Size = new System.Drawing.Size(80, 13);
            this.GroupByLabel.TabIndex = 1;
            this.GroupByLabel.Text = "Group Data By:";
            // 
            // GroupDataBy
            // 
            this.GroupDataBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GroupDataBy.FormattingEnabled = true;
            this.GroupDataBy.Items.AddRange(new object[] {
            "Day",
            "Week",
            "Month",
            "Year",
            "No Grouping"});
            this.GroupDataBy.Location = new System.Drawing.Point(120, 6);
            this.GroupDataBy.Name = "GroupDataBy";
            this.GroupDataBy.Size = new System.Drawing.Size(156, 21);
            this.GroupDataBy.TabIndex = 0;
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(120, 7);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 1;
            this.AcceptDialogButton.Text = "OK";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(201, 7);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 2;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CancelDialogButton);
            this.panel1.Controls.Add(this.AcceptDialogButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 40);
            this.panel1.TabIndex = 6;
            // 
            // GridOptions
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(288, 128);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DisplayLabel);
            this.Controls.Add(this.DimensionLabel);
            this.Controls.Add(this.TimeDisplay);
            this.Controls.Add(this.Dimension);
            this.Controls.Add(this.GroupByLabel);
            this.Controls.Add(this.GroupDataBy);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GridOptions";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Grid Options";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DimensionLabel;
        private System.Windows.Forms.Label GroupByLabel;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Label DisplayLabel;
        internal System.Windows.Forms.ComboBox TimeDisplay;
        internal System.Windows.Forms.ComboBox Dimension;
        internal System.Windows.Forms.ComboBox GroupDataBy;
        private System.Windows.Forms.Panel panel1;
    }
}