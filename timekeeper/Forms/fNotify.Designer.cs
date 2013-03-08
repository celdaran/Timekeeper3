namespace Timekeeper
{
    partial class fNotify
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
            this.wDontShowAgain = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.wInstructions = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // wDontShowAgain
            // 
            this.wDontShowAgain.AutoSize = true;
            this.wDontShowAgain.Location = new System.Drawing.Point(12, 106);
            this.wDontShowAgain.Name = "wDontShowAgain";
            this.wDontShowAgain.Size = new System.Drawing.Size(127, 17);
            this.wDontShowAgain.TabIndex = 1;
            this.wDontShowAgain.Text = "Don\'t show this again";
            this.wDontShowAgain.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(245, 102);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.wInstructions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 96);
            this.panel1.TabIndex = 4;
            // 
            // wInstructions
            // 
            this.wInstructions.BackColor = System.Drawing.SystemColors.Window;
            this.wInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wInstructions.Cursor = System.Windows.Forms.Cursors.Default;
            this.wInstructions.Location = new System.Drawing.Point(12, 9);
            this.wInstructions.Multiline = true;
            this.wInstructions.Name = "wInstructions";
            this.wInstructions.ReadOnly = true;
            this.wInstructions.Size = new System.Drawing.Size(308, 84);
            this.wInstructions.TabIndex = 4;
            this.wInstructions.TabStop = false;
            this.wInstructions.Text = "No timer is running.\r\n\r\nCheck the box below to permanently dismiss this notificat" +
                "ion. This choice can be reset in the Options dialog box (press F6 to access).";
            // 
            // fNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(332, 131);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.wDontShowAgain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fNotify";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Notification";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        public System.Windows.Forms.CheckBox wDontShowAgain;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox wInstructions;
    }
}