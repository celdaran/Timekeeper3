namespace Timekeeper.Forms.Controls
{
    partial class DateRangePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PresetLabel = new System.Windows.Forms.Label();
            this.FromDateLabel = new System.Windows.Forms.Label();
            this.ToDateLabel = new System.Windows.Forms.Label();
            this.Presets = new System.Windows.Forms.ComboBox();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // PresetLabel
            // 
            this.PresetLabel.AutoSize = true;
            this.PresetLabel.Location = new System.Drawing.Point(4, 6);
            this.PresetLabel.Name = "PresetLabel";
            this.PresetLabel.Size = new System.Drawing.Size(40, 13);
            this.PresetLabel.TabIndex = 1;
            this.PresetLabel.Text = "Preset:";
            // 
            // FromDateLabel
            // 
            this.FromDateLabel.AutoSize = true;
            this.FromDateLabel.Location = new System.Drawing.Point(4, 30);
            this.FromDateLabel.Name = "FromDateLabel";
            this.FromDateLabel.Size = new System.Drawing.Size(59, 13);
            this.FromDateLabel.TabIndex = 2;
            this.FromDateLabel.Text = "From Date:";
            // 
            // ToDateLabel
            // 
            this.ToDateLabel.AutoSize = true;
            this.ToDateLabel.Location = new System.Drawing.Point(4, 56);
            this.ToDateLabel.Name = "ToDateLabel";
            this.ToDateLabel.Size = new System.Drawing.Size(49, 13);
            this.ToDateLabel.TabIndex = 3;
            this.ToDateLabel.Text = "To Date:";
            // 
            // Presets
            // 
            this.Presets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Presets.FormattingEnabled = true;
            this.Presets.Location = new System.Drawing.Point(75, 3);
            this.Presets.Name = "Presets";
            this.Presets.Size = new System.Drawing.Size(121, 21);
            this.Presets.TabIndex = 4;
            this.Presets.SelectedIndexChanged += new System.EventHandler(this.Presets_SelectedIndexChanged);
            // 
            // FromDate
            // 
            this.FromDate.CustomFormat = "yyyy-MM-dd";
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDate.Location = new System.Drawing.Point(75, 30);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(121, 20);
            this.FromDate.TabIndex = 6;
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "yyyy-MM-dd";
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(75, 56);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(121, 20);
            this.ToDate.TabIndex = 5;
            // 
            // DateRangePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Presets);
            this.Controls.Add(this.ToDateLabel);
            this.Controls.Add(this.ToDate);
            this.Controls.Add(this.PresetLabel);
            this.Controls.Add(this.FromDateLabel);
            this.Controls.Add(this.FromDate);
            this.Name = "DateRangePicker";
            this.Size = new System.Drawing.Size(201, 81);
            this.Load += new System.EventHandler(this.DateRangePicker_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PresetLabel;
        private System.Windows.Forms.Label FromDateLabel;
        private System.Windows.Forms.Label ToDateLabel;
        public System.Windows.Forms.ComboBox Presets;
        public System.Windows.Forms.DateTimePicker FromDate;
        public System.Windows.Forms.DateTimePicker ToDate;
    }
}
