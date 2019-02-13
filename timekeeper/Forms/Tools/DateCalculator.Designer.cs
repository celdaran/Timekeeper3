namespace Timekeeper.Forms.Tools
{
    partial class DateCalculator
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
            if (disposing && (components != null))
            {
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCalcDifference = new System.Windows.Forms.Button();
            this.wResultDiff2 = new System.Windows.Forms.TextBox();
            this.wResultDiff1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wEndDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.wStartDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(463, 210);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.btnCalcDifference);
            this.tabPage1.Controls.Add(this.wResultDiff2);
            this.tabPage1.Controls.Add(this.wResultDiff1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.wEndDate);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.wStartDate);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(455, 184);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Date Difference";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(211, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "label4";
            // 
            // btnCalcDifference
            // 
            this.btnCalcDifference.Location = new System.Drawing.Point(117, 79);
            this.btnCalcDifference.Name = "btnCalcDifference";
            this.btnCalcDifference.Size = new System.Drawing.Size(75, 23);
            this.btnCalcDifference.TabIndex = 7;
            this.btnCalcDifference.Text = "Calculate";
            this.btnCalcDifference.UseVisualStyleBackColor = true;
            // 
            // wResultDiff2
            // 
            this.wResultDiff2.Location = new System.Drawing.Point(262, 52);
            this.wResultDiff2.Name = "wResultDiff2";
            this.wResultDiff2.ReadOnly = true;
            this.wResultDiff2.Size = new System.Drawing.Size(175, 20);
            this.wResultDiff2.TabIndex = 6;
            // 
            // wResultDiff1
            // 
            this.wResultDiff1.Location = new System.Drawing.Point(262, 20);
            this.wResultDiff1.Name = "wResultDiff1";
            this.wResultDiff1.ReadOnly = true;
            this.wResultDiff1.Size = new System.Drawing.Size(175, 20);
            this.wResultDiff1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(211, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // wEndDate
            // 
            this.wEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.wEndDate.Location = new System.Drawing.Point(95, 49);
            this.wEndDate.Name = "wEndDate";
            this.wEndDate.Size = new System.Drawing.Size(97, 20);
            this.wEndDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Second date:";
            // 
            // wStartDate
            // 
            this.wStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.wStartDate.Location = new System.Drawing.Point(95, 17);
            this.wStartDate.Name = "wStartDate";
            this.wStartDate.Size = new System.Drawing.Size(97, 20);
            this.wStartDate.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First date:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(455, 184);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Add or Subtract Days";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(455, 184);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Calendar Conversion";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(455, 184);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Milestones";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(396, 228);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // DateCalculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 262);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateCalculator";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Date Calculator";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCalcDifference;
        private System.Windows.Forms.TextBox wResultDiff2;
        private System.Windows.Forms.TextBox wResultDiff1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker wEndDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker wStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnClose;
    }
}