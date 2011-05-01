namespace Timekeeper
{
    partial class fReport
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
            this.panelButtonBar = new System.Windows.Forms.Panel();
            this.wGroupPrint = new System.Windows.Forms.GroupBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPrintSetup = new System.Windows.Forms.Button();
            this.btnPrintPreview = new System.Windows.Forms.Button();
            this.wGroupDates = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wPreset = new System.Windows.Forms.ComboBox();
            this.wEndDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.wStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.wReport = new System.Windows.Forms.WebBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelButtonBar.SuspendLayout();
            this.wGroupPrint.SuspendLayout();
            this.wGroupDates.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelButtonBar
            // 
            this.panelButtonBar.Controls.Add(this.wGroupPrint);
            this.panelButtonBar.Controls.Add(this.wGroupDates);
            this.panelButtonBar.Controls.Add(this.btnClose);
            this.panelButtonBar.Controls.Add(this.btnGo);
            this.panelButtonBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtonBar.Location = new System.Drawing.Point(0, 213);
            this.panelButtonBar.Name = "panelButtonBar";
            this.panelButtonBar.Size = new System.Drawing.Size(572, 140);
            this.panelButtonBar.TabIndex = 5;
            // 
            // wGroupPrint
            // 
            this.wGroupPrint.Controls.Add(this.btnPrint);
            this.wGroupPrint.Controls.Add(this.btnPrintSetup);
            this.wGroupPrint.Controls.Add(this.btnPrintPreview);
            this.wGroupPrint.Location = new System.Drawing.Point(240, 10);
            this.wGroupPrint.Name = "wGroupPrint";
            this.wGroupPrint.Size = new System.Drawing.Size(216, 119);
            this.wGroupPrint.TabIndex = 5;
            this.wGroupPrint.TabStop = false;
            this.wGroupPrint.Text = "Print";
            this.wGroupPrint.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(42, 21);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 23);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrintSetup
            // 
            this.btnPrintSetup.Location = new System.Drawing.Point(42, 49);
            this.btnPrintSetup.Name = "btnPrintSetup";
            this.btnPrintSetup.Size = new System.Drawing.Size(86, 23);
            this.btnPrintSetup.TabIndex = 7;
            this.btnPrintSetup.Text = "Print &Setup...";
            this.btnPrintSetup.UseVisualStyleBackColor = true;
            this.btnPrintSetup.Click += new System.EventHandler(this.btnPrintSetup_Click);
            // 
            // btnPrintPreview
            // 
            this.btnPrintPreview.Location = new System.Drawing.Point(42, 78);
            this.btnPrintPreview.Name = "btnPrintPreview";
            this.btnPrintPreview.Size = new System.Drawing.Size(86, 23);
            this.btnPrintPreview.TabIndex = 8;
            this.btnPrintPreview.Text = "Print Pre&view...";
            this.btnPrintPreview.UseVisualStyleBackColor = true;
            this.btnPrintPreview.Click += new System.EventHandler(this.btnPrintPreview_Click);
            // 
            // wGroupDates
            // 
            this.wGroupDates.Controls.Add(this.label3);
            this.wGroupDates.Controls.Add(this.wPreset);
            this.wGroupDates.Controls.Add(this.wEndDate);
            this.wGroupDates.Controls.Add(this.label1);
            this.wGroupDates.Controls.Add(this.wStartDate);
            this.wGroupDates.Controls.Add(this.label2);
            this.wGroupDates.Location = new System.Drawing.Point(10, 10);
            this.wGroupDates.Name = "wGroupDates";
            this.wGroupDates.Size = new System.Drawing.Size(220, 120);
            this.wGroupDates.TabIndex = 1;
            this.wGroupDates.TabStop = false;
            this.wGroupDates.Text = "Date Range";
            this.wGroupDates.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
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
            // wPreset
            // 
            this.wPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wPreset.FormattingEnabled = true;
            this.wPreset.Items.AddRange(new object[] {
            "Today",
            "Previous Day",
            "Past Five Days"});
            this.wPreset.Location = new System.Drawing.Point(77, 20);
            this.wPreset.Name = "wPreset";
            this.wPreset.Size = new System.Drawing.Size(125, 21);
            this.wPreset.TabIndex = 2;
            this.wPreset.SelectedIndexChanged += new System.EventHandler(this.wPreset_SelectedIndexChanged);
            // 
            // wEndDate
            // 
            this.wEndDate.CustomFormat = "yyyy-MM-dd";
            this.wEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.wEndDate.Location = new System.Drawing.Point(77, 74);
            this.wEndDate.Name = "wEndDate";
            this.wEndDate.Size = new System.Drawing.Size(125, 20);
            this.wEndDate.TabIndex = 4;
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
            this.wStartDate.TabIndex = 3;
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
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(485, 105);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            this.btnClose.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(485, 76);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 9;
            this.btnGo.Text = "&Refresh";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            this.btnGo.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wReport
            // 
            this.wReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wReport.Location = new System.Drawing.Point(0, 0);
            this.wReport.MinimumSize = new System.Drawing.Size(20, 20);
            this.wReport.Name = "wReport";
            this.wReport.Size = new System.Drawing.Size(572, 213);
            this.wReport.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.wReport);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(572, 213);
            this.panel2.TabIndex = 1;
            // 
            // fReport
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(572, 353);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelButtonBar);
            this.MinimizeBox = false;
            this.Name = "fReport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Report";
            this.Load += new System.EventHandler(this.fReport_Load);
            this.panelButtonBar.ResumeLayout(false);
            this.wGroupPrint.ResumeLayout(false);
            this.wGroupDates.ResumeLayout(false);
            this.wGroupDates.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelButtonBar;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox wPreset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrintSetup;
        private System.Windows.Forms.DateTimePicker wEndDate;
        private System.Windows.Forms.DateTimePicker wStartDate;
        private System.Windows.Forms.Button btnPrintPreview;
        private System.Windows.Forms.GroupBox wGroupDates;
        private System.Windows.Forms.GroupBox wGroupPrint;
        private System.Windows.Forms.WebBrowser wReport;
        private System.Windows.Forms.Panel panel2;
    }
}