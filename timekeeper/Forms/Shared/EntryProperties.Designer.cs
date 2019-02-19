namespace Timekeeper.Forms.Shared
{
    partial class EntryProperties
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.wID = new System.Windows.Forms.TextBox();
            this.wStartTime = new System.Windows.Forms.TextBox();
            this.wStopTime = new System.Windows.Forms.TextBox();
            this.wCreatedOn = new System.Windows.Forms.TextBox();
            this.wModifiedOn = new System.Windows.Forms.TextBox();
            this.wGUID = new System.Windows.Forms.TextBox();
            this.wLockedFlag = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Start Time:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stop Time:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Row Created On:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Row Modified On:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 147);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "GUID:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Locked:";
            // 
            // wID
            // 
            this.wID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wID.Location = new System.Drawing.Point(98, 16);
            this.wID.Name = "wID";
            this.wID.ReadOnly = true;
            this.wID.Size = new System.Drawing.Size(321, 13);
            this.wID.TabIndex = 7;
            this.wID.TabStop = false;
            // 
            // wStartTime
            // 
            this.wStartTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wStartTime.Location = new System.Drawing.Point(98, 43);
            this.wStartTime.Name = "wStartTime";
            this.wStartTime.ReadOnly = true;
            this.wStartTime.Size = new System.Drawing.Size(321, 13);
            this.wStartTime.TabIndex = 8;
            this.wStartTime.TabStop = false;
            // 
            // wStopTime
            // 
            this.wStopTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wStopTime.Location = new System.Drawing.Point(98, 69);
            this.wStopTime.Name = "wStopTime";
            this.wStopTime.ReadOnly = true;
            this.wStopTime.Size = new System.Drawing.Size(321, 13);
            this.wStopTime.TabIndex = 9;
            this.wStopTime.TabStop = false;
            // 
            // wCreatedOn
            // 
            this.wCreatedOn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wCreatedOn.Location = new System.Drawing.Point(98, 95);
            this.wCreatedOn.Name = "wCreatedOn";
            this.wCreatedOn.ReadOnly = true;
            this.wCreatedOn.Size = new System.Drawing.Size(321, 13);
            this.wCreatedOn.TabIndex = 10;
            this.wCreatedOn.TabStop = false;
            // 
            // wModifiedOn
            // 
            this.wModifiedOn.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wModifiedOn.Location = new System.Drawing.Point(98, 121);
            this.wModifiedOn.Name = "wModifiedOn";
            this.wModifiedOn.ReadOnly = true;
            this.wModifiedOn.Size = new System.Drawing.Size(321, 13);
            this.wModifiedOn.TabIndex = 11;
            this.wModifiedOn.TabStop = false;
            // 
            // wGUID
            // 
            this.wGUID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wGUID.Location = new System.Drawing.Point(98, 147);
            this.wGUID.Name = "wGUID";
            this.wGUID.ReadOnly = true;
            this.wGUID.Size = new System.Drawing.Size(321, 13);
            this.wGUID.TabIndex = 12;
            this.wGUID.TabStop = false;
            // 
            // wLockedFlag
            // 
            this.wLockedFlag.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wLockedFlag.Location = new System.Drawing.Point(98, 174);
            this.wLockedFlag.Name = "wLockedFlag";
            this.wLockedFlag.ReadOnly = true;
            this.wLockedFlag.Size = new System.Drawing.Size(321, 13);
            this.wLockedFlag.TabIndex = 13;
            this.wLockedFlag.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(382, 229);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.wLockedFlag);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.wGUID);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.wModifiedOn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.wCreatedOn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.wStopTime);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.wStartTime);
            this.groupBox1.Controls.Add(this.wID);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(445, 211);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // EntryProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(469, 263);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EntryProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Entry Properties";
            this.Load += new System.EventHandler(this.EntryProperties_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox wID;
        private System.Windows.Forms.TextBox wStartTime;
        private System.Windows.Forms.TextBox wStopTime;
        private System.Windows.Forms.TextBox wCreatedOn;
        private System.Windows.Forms.TextBox wModifiedOn;
        private System.Windows.Forms.TextBox wGUID;
        private System.Windows.Forms.TextBox wLockedFlag;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}