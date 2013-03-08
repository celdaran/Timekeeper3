namespace Timekeeper
{
    partial class fAnnotate
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
            this.components = new System.ComponentModel.Container();
            this.panelBottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panelTop = new System.Windows.Forms.Panel();
            this.wPreLog = new System.Windows.Forms.TextBox();
            this.wElapsedTime = new System.Windows.Forms.TextBox();
            this.wStartTime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wLog = new System.Windows.Forms.RichTextBox();
            this.ttStartTime = new System.Windows.Forms.ToolTip(this.components);
            this.panelBottom.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.btnCancel);
            this.panelBottom.Controls.Add(this.btnOK);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 198);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(352, 46);
            this.panelBottom.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(94, 11);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(12, 11);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.wPreLog);
            this.panelTop.Controls.Add(this.wElapsedTime);
            this.panelTop.Controls.Add(this.wStartTime);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(352, 63);
            this.panelTop.TabIndex = 3;
            // 
            // wPreLog
            // 
            this.wPreLog.Location = new System.Drawing.Point(143, 8);
            this.wPreLog.Multiline = true;
            this.wPreLog.Name = "wPreLog";
            this.wPreLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wPreLog.Size = new System.Drawing.Size(197, 45);
            this.wPreLog.TabIndex = 3;
            this.wPreLog.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wElapsedTime
            // 
            this.wElapsedTime.Location = new System.Drawing.Point(82, 33);
            this.wElapsedTime.Name = "wElapsedTime";
            this.wElapsedTime.ReadOnly = true;
            this.wElapsedTime.Size = new System.Drawing.Size(55, 20);
            this.wElapsedTime.TabIndex = 2;
            this.wElapsedTime.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wStartTime
            // 
            this.wStartTime.Location = new System.Drawing.Point(82, 8);
            this.wStartTime.Name = "wStartTime";
            this.wStartTime.ReadOnly = true;
            this.wStartTime.Size = new System.Drawing.Size(55, 20);
            this.wStartTime.TabIndex = 1;
            this.wStartTime.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Elapsed Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Timer Started:";
            // 
            // wLog
            // 
            this.wLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wLog.Location = new System.Drawing.Point(0, 63);
            this.wLog.Name = "wLog";
            this.wLog.Size = new System.Drawing.Size(352, 135);
            this.wLog.TabIndex = 4;
            this.wLog.Text = "";
            this.wLog.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // fAnnotate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(352, 244);
            this.Controls.Add(this.wLog);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fAnnotate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Annotate";
            this.panelBottom.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox wPreLog;
        internal System.Windows.Forms.TextBox wElapsedTime;
        internal System.Windows.Forms.TextBox wStartTime;
        internal System.Windows.Forms.Panel panelTop;
        internal System.Windows.Forms.RichTextBox wLog;
        internal System.Windows.Forms.Button btnOK;
        internal System.Windows.Forms.ToolTip ttStartTime;
    }
}