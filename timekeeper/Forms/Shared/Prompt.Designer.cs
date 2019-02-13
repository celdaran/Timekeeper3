namespace Timekeeper.Forms.Shared
{
    partial class Prompt
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
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
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
            // btnYes
            // 
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnYes.Location = new System.Drawing.Point(164, 102);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "&Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnNo.Location = new System.Drawing.Point(245, 102);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.TabIndex = 4;
            this.btnNo.Text = "&No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.wInstructions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 96);
            this.panel1.TabIndex = 5;
            // 
            // wInstructions
            // 
            this.wInstructions.BackColor = System.Drawing.SystemColors.Window;
            this.wInstructions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wInstructions.Cursor = System.Windows.Forms.Cursors.Default;
            this.wInstructions.Location = new System.Drawing.Point(12, 12);
            this.wInstructions.Multiline = true;
            this.wInstructions.Name = "wInstructions";
            this.wInstructions.ReadOnly = true;
            this.wInstructions.Size = new System.Drawing.Size(308, 84);
            this.wInstructions.TabIndex = 4;
            this.wInstructions.TabStop = false;
            // 
            // Prompt
            // 
            this.AcceptButton = this.btnYes;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnNo;
            this.ClientSize = new System.Drawing.Size(332, 131);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.wDontShowAgain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Prompt";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Confirm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYes;
        public System.Windows.Forms.CheckBox wDontShowAgain;
        private System.Windows.Forms.Button btnNo;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox wInstructions;
    }
}