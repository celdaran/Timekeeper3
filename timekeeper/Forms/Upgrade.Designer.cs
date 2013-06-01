namespace Timekeeper.Forms
{
    partial class Upgrade
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.BackUpFileLabel = new System.Windows.Forms.Label();
            this.UpgradeProgress = new System.Windows.Forms.ProgressBar();
            this.StepLabel = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.LaterButton = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(430, 41);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.TabStop = false;
            this.richTextBox1.Text = "This database is from a prior version of Timekeeper and needs to be upgraded befo" +
    "re continuing. Before upgrading, the existing file will be backed up to:";
            // 
            // BackUpFileLabel
            // 
            this.BackUpFileLabel.AutoSize = true;
            this.BackUpFileLabel.Location = new System.Drawing.Point(9, 56);
            this.BackUpFileLabel.Name = "BackUpFileLabel";
            this.BackUpFileLabel.Size = new System.Drawing.Size(51, 13);
            this.BackUpFileLabel.TabIndex = 1;
            this.BackUpFileLabel.Text = "FileName";
            // 
            // UpgradeProgress
            // 
            this.UpgradeProgress.Location = new System.Drawing.Point(12, 110);
            this.UpgradeProgress.Name = "UpgradeProgress";
            this.UpgradeProgress.Size = new System.Drawing.Size(430, 23);
            this.UpgradeProgress.TabIndex = 2;
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(12, 94);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(29, 13);
            this.StepLabel.TabIndex = 3;
            this.StepLabel.Text = "Step";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(286, 142);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 23);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LaterButton
            // 
            this.LaterButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LaterButton.Location = new System.Drawing.Point(367, 142);
            this.LaterButton.Name = "LaterButton";
            this.LaterButton.Size = new System.Drawing.Size(75, 23);
            this.LaterButton.TabIndex = 5;
            this.LaterButton.Text = "Not Now";
            this.LaterButton.UseVisualStyleBackColor = true;
            // 
            // OkayButton
            // 
            this.OkayButton.Location = new System.Drawing.Point(286, 142);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 6;
            this.OkayButton.Text = "OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Visible = false;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // Upgrade
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.LaterButton;
            this.ClientSize = new System.Drawing.Size(454, 177);
            this.ControlBox = false;
            this.Controls.Add(this.OkayButton);
            this.Controls.Add(this.LaterButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.StepLabel);
            this.Controls.Add(this.UpgradeProgress);
            this.Controls.Add(this.BackUpFileLabel);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Upgrade";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Upgrade Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Label BackUpFileLabel;
        public System.Windows.Forms.ProgressBar UpgradeProgress;
        public System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button LaterButton;
        private System.Windows.Forms.Button OkayButton;
    }
}