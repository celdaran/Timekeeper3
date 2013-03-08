namespace Timekeeper
{
    partial class fGridFilter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.wProjectList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wTaskList = new System.Windows.Forms.CheckedListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.wProjectList);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.wTaskList);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(224, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Projects";
            // 
            // wProjectList
            // 
            this.wProjectList.CheckOnClick = true;
            this.wProjectList.FormattingEnabled = true;
            this.wProjectList.Location = new System.Drawing.Point(227, 32);
            this.wProjectList.Name = "wProjectList";
            this.wProjectList.Size = new System.Drawing.Size(200, 94);
            this.wProjectList.TabIndex = 4;
            this.wProjectList.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Tasks";
            // 
            // wTaskList
            // 
            this.wTaskList.CheckOnClick = true;
            this.wTaskList.FormattingEnabled = true;
            this.wTaskList.Location = new System.Drawing.Point(15, 32);
            this.wTaskList.Name = "wTaskList";
            this.wTaskList.Size = new System.Drawing.Size(200, 94);
            this.wTaskList.TabIndex = 2;
            this.wTaskList.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(298, 162);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 6;
            this.btnOK.Tag = "1";
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(379, 162);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 7;
            this.bCancel.Tag = "3.14";
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 162);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            this.btnClear.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // fGridFilter
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(469, 196);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fGridFilter";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Additional Filtering";
            this.Load += new System.EventHandler(this.fGridFilter_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button bCancel;
        internal System.Windows.Forms.CheckedListBox wProjectList;
        internal System.Windows.Forms.CheckedListBox wTaskList;
        private System.Windows.Forms.Button btnClear;

    }
}