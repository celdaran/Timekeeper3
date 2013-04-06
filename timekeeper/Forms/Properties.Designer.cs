namespace Timekeeper.Forms
{
    partial class Properties
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
            this.wDescription = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.wTotalTime = new System.Windows.Forms.Label();
            this.wCreated = new System.Windows.Forms.Label();
            this.wID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wType = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.wGroupProperties = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wTimeToday = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.wGroupProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // wDescription
            // 
            this.wDescription.AutoEllipsis = true;
            this.wDescription.AutoSize = true;
            this.wDescription.Location = new System.Drawing.Point(76, 16);
            this.wDescription.Name = "wDescription";
            this.wDescription.Size = new System.Drawing.Size(19, 13);
            this.wDescription.TabIndex = 3;
            this.wDescription.Text = "00";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Created:";
            // 
            // wTotalTime
            // 
            this.wTotalTime.AutoSize = true;
            this.wTotalTime.Location = new System.Drawing.Point(76, 93);
            this.wTotalTime.Name = "wTotalTime";
            this.wTotalTime.Size = new System.Drawing.Size(19, 13);
            this.wTotalTime.TabIndex = 6;
            this.wTotalTime.Text = "00";
            // 
            // wCreated
            // 
            this.wCreated.AutoSize = true;
            this.wCreated.Location = new System.Drawing.Point(76, 67);
            this.wCreated.Name = "wCreated";
            this.wCreated.Size = new System.Drawing.Size(19, 13);
            this.wCreated.TabIndex = 7;
            this.wCreated.Text = "00";
            // 
            // wID
            // 
            this.wID.AutoSize = true;
            this.wID.Location = new System.Drawing.Point(76, 54);
            this.wID.Name = "wID";
            this.wID.Size = new System.Drawing.Size(19, 13);
            this.wID.TabIndex = 9;
            this.wID.Text = "00";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Item ID:";
            // 
            // wType
            // 
            this.wType.AutoSize = true;
            this.wType.Location = new System.Drawing.Point(76, 41);
            this.wType.Name = "wType";
            this.wType.Size = new System.Drawing.Size(19, 13);
            this.wType.TabIndex = 11;
            this.wType.Text = "00";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Type:";
            // 
            // wGroupProperties
            // 
            this.wGroupProperties.Controls.Add(this.label1);
            this.wGroupProperties.Controls.Add(this.wTimeToday);
            this.wGroupProperties.Controls.Add(this.label3);
            this.wGroupProperties.Controls.Add(this.wType);
            this.wGroupProperties.Controls.Add(this.label4);
            this.wGroupProperties.Controls.Add(this.label8);
            this.wGroupProperties.Controls.Add(this.wDescription);
            this.wGroupProperties.Controls.Add(this.wID);
            this.wGroupProperties.Controls.Add(this.label5);
            this.wGroupProperties.Controls.Add(this.label6);
            this.wGroupProperties.Controls.Add(this.wCreated);
            this.wGroupProperties.Controls.Add(this.wTotalTime);
            this.wGroupProperties.Location = new System.Drawing.Point(12, 12);
            this.wGroupProperties.Name = "wGroupProperties";
            this.wGroupProperties.Size = new System.Drawing.Size(316, 134);
            this.wGroupProperties.TabIndex = 12;
            this.wGroupProperties.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Time Today:";
            // 
            // wTimeToday
            // 
            this.wTimeToday.AutoSize = true;
            this.wTimeToday.Location = new System.Drawing.Point(76, 106);
            this.wTimeToday.Name = "wTimeToday";
            this.wTimeToday.Size = new System.Drawing.Size(19, 13);
            this.wTimeToday.TabIndex = 13;
            this.wTimeToday.Text = "00";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(133, 152);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // fProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(340, 182);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.wGroupProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fProperties_FormClosing);
            this.Click += new System.EventHandler(this.fProperties_Click);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fProperties_KeyDown);
            this.wGroupProperties.ResumeLayout(false);
            this.wGroupProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label wTotalTime;
        internal System.Windows.Forms.Label wCreated;
        internal System.Windows.Forms.Label wDescription;
        internal System.Windows.Forms.Label wID;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label wType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox wGroupProperties;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label wTimeToday;
    }
}