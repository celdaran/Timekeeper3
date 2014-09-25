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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.wGroupProperties = new System.Windows.Forms.GroupBox();
            this.wExternalProjectNo = new System.Windows.Forms.TextBox();
            this.wGUID = new System.Windows.Forms.TextBox();
            this.wID = new System.Windows.Forms.TextBox();
            this.wType = new System.Windows.Forms.TextBox();
            this.wDescription = new System.Windows.Forms.TextBox();
            this.wName = new System.Windows.Forms.TextBox();
            this.wExternalProjectNoLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelDialog = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.wIsHidden = new System.Windows.Forms.CheckBox();
            this.wIsDeleted = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.wTimeToday = new System.Windows.Forms.TextBox();
            this.wTotalTime = new System.Windows.Forms.TextBox();
            this.wModified = new System.Windows.Forms.TextBox();
            this.wCreated = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.wDeletedTime = new System.Windows.Forms.TextBox();
            this.wHiddenTime = new System.Windows.Forms.TextBox();
            this.wGroupProperties.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Total Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Created:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Internal ID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 10;
            this.label8.Text = "Type:";
            // 
            // wGroupProperties
            // 
            this.wGroupProperties.Controls.Add(this.wExternalProjectNo);
            this.wGroupProperties.Controls.Add(this.wGUID);
            this.wGroupProperties.Controls.Add(this.wID);
            this.wGroupProperties.Controls.Add(this.wType);
            this.wGroupProperties.Controls.Add(this.wDescription);
            this.wGroupProperties.Controls.Add(this.wName);
            this.wGroupProperties.Controls.Add(this.wExternalProjectNoLabel);
            this.wGroupProperties.Controls.Add(this.label9);
            this.wGroupProperties.Controls.Add(this.NameLabel);
            this.wGroupProperties.Controls.Add(this.label3);
            this.wGroupProperties.Controls.Add(this.label4);
            this.wGroupProperties.Controls.Add(this.label8);
            this.wGroupProperties.Location = new System.Drawing.Point(12, 8);
            this.wGroupProperties.Name = "wGroupProperties";
            this.wGroupProperties.Size = new System.Drawing.Size(330, 223);
            this.wGroupProperties.TabIndex = 12;
            this.wGroupProperties.TabStop = false;
            // 
            // wExternalProjectNo
            // 
            this.wExternalProjectNo.BackColor = System.Drawing.SystemColors.Control;
            this.wExternalProjectNo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wExternalProjectNo.Location = new System.Drawing.Point(97, 198);
            this.wExternalProjectNo.Name = "wExternalProjectNo";
            this.wExternalProjectNo.ReadOnly = true;
            this.wExternalProjectNo.Size = new System.Drawing.Size(227, 13);
            this.wExternalProjectNo.TabIndex = 34;
            this.wExternalProjectNo.TabStop = false;
            // 
            // wGUID
            // 
            this.wGUID.BackColor = System.Drawing.SystemColors.Control;
            this.wGUID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wGUID.Location = new System.Drawing.Point(97, 172);
            this.wGUID.Name = "wGUID";
            this.wGUID.ReadOnly = true;
            this.wGUID.Size = new System.Drawing.Size(227, 13);
            this.wGUID.TabIndex = 28;
            this.wGUID.TabStop = false;
            // 
            // wID
            // 
            this.wID.BackColor = System.Drawing.SystemColors.Control;
            this.wID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wID.Location = new System.Drawing.Point(97, 146);
            this.wID.Name = "wID";
            this.wID.ReadOnly = true;
            this.wID.Size = new System.Drawing.Size(227, 13);
            this.wID.TabIndex = 27;
            this.wID.TabStop = false;
            // 
            // wType
            // 
            this.wType.BackColor = System.Drawing.SystemColors.Control;
            this.wType.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wType.Location = new System.Drawing.Point(97, 120);
            this.wType.Name = "wType";
            this.wType.ReadOnly = true;
            this.wType.Size = new System.Drawing.Size(227, 13);
            this.wType.TabIndex = 26;
            this.wType.TabStop = false;
            // 
            // wDescription
            // 
            this.wDescription.AcceptsReturn = true;
            this.wDescription.BackColor = System.Drawing.SystemColors.Control;
            this.wDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wDescription.Location = new System.Drawing.Point(97, 42);
            this.wDescription.Multiline = true;
            this.wDescription.Name = "wDescription";
            this.wDescription.ReadOnly = true;
            this.wDescription.Size = new System.Drawing.Size(227, 64);
            this.wDescription.TabIndex = 25;
            this.wDescription.TabStop = false;
            // 
            // wName
            // 
            this.wName.BackColor = System.Drawing.SystemColors.Control;
            this.wName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wName.Location = new System.Drawing.Point(97, 16);
            this.wName.Name = "wName";
            this.wName.ReadOnly = true;
            this.wName.Size = new System.Drawing.Size(227, 13);
            this.wName.TabIndex = 24;
            this.wName.TabStop = false;
            // 
            // wExternalProjectNoLabel
            // 
            this.wExternalProjectNoLabel.AutoSize = true;
            this.wExternalProjectNoLabel.Location = new System.Drawing.Point(13, 198);
            this.wExternalProjectNoLabel.Name = "wExternalProjectNoLabel";
            this.wExternalProjectNoLabel.Size = new System.Drawing.Size(84, 13);
            this.wExternalProjectNoLabel.TabIndex = 22;
            this.wExternalProjectNoLabel.Text = "External Project:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 172);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "GUID:";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Location = new System.Drawing.Point(12, 16);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(38, 13);
            this.NameLabel.TabIndex = 14;
            this.NameLabel.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Time Today:";
            // 
            // CancelDialog
            // 
            this.CancelDialog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialog.Location = new System.Drawing.Point(267, 435);
            this.CancelDialog.Name = "CancelDialog";
            this.CancelDialog.Size = new System.Drawing.Size(75, 23);
            this.CancelDialog.TabIndex = 13;
            this.CancelDialog.Text = "&Close";
            this.CancelDialog.UseVisualStyleBackColor = true;
            this.CancelDialog.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Attributes:";
            // 
            // wIsHidden
            // 
            this.wIsHidden.AutoCheck = false;
            this.wIsHidden.AutoSize = true;
            this.wIsHidden.Location = new System.Drawing.Point(97, 15);
            this.wIsHidden.Name = "wIsHidden";
            this.wIsHidden.Size = new System.Drawing.Size(60, 17);
            this.wIsHidden.TabIndex = 17;
            this.wIsHidden.TabStop = false;
            this.wIsHidden.Text = "Hidden";
            this.wIsHidden.UseVisualStyleBackColor = true;
            // 
            // wIsDeleted
            // 
            this.wIsDeleted.AutoCheck = false;
            this.wIsDeleted.AutoSize = true;
            this.wIsDeleted.Location = new System.Drawing.Point(97, 38);
            this.wIsDeleted.Name = "wIsDeleted";
            this.wIsDeleted.Size = new System.Drawing.Size(63, 17);
            this.wIsDeleted.TabIndex = 18;
            this.wIsDeleted.TabStop = false;
            this.wIsDeleted.Text = "Deleted";
            this.wIsDeleted.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Modified:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.wTimeToday);
            this.groupBox1.Controls.Add(this.wTotalTime);
            this.groupBox1.Controls.Add(this.wModified);
            this.groupBox1.Controls.Add(this.wCreated);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 237);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(330, 120);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // wTimeToday
            // 
            this.wTimeToday.BackColor = System.Drawing.SystemColors.Control;
            this.wTimeToday.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wTimeToday.Location = new System.Drawing.Point(97, 94);
            this.wTimeToday.Name = "wTimeToday";
            this.wTimeToday.ReadOnly = true;
            this.wTimeToday.Size = new System.Drawing.Size(227, 13);
            this.wTimeToday.TabIndex = 31;
            this.wTimeToday.TabStop = false;
            // 
            // wTotalTime
            // 
            this.wTotalTime.BackColor = System.Drawing.SystemColors.Control;
            this.wTotalTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wTotalTime.Location = new System.Drawing.Point(97, 68);
            this.wTotalTime.Name = "wTotalTime";
            this.wTotalTime.ReadOnly = true;
            this.wTotalTime.Size = new System.Drawing.Size(227, 13);
            this.wTotalTime.TabIndex = 31;
            this.wTotalTime.TabStop = false;
            // 
            // wModified
            // 
            this.wModified.BackColor = System.Drawing.SystemColors.Control;
            this.wModified.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wModified.Location = new System.Drawing.Point(97, 42);
            this.wModified.Name = "wModified";
            this.wModified.ReadOnly = true;
            this.wModified.Size = new System.Drawing.Size(227, 13);
            this.wModified.TabIndex = 30;
            this.wModified.TabStop = false;
            // 
            // wCreated
            // 
            this.wCreated.BackColor = System.Drawing.SystemColors.Control;
            this.wCreated.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wCreated.Location = new System.Drawing.Point(97, 16);
            this.wCreated.Name = "wCreated";
            this.wCreated.ReadOnly = true;
            this.wCreated.Size = new System.Drawing.Size(227, 13);
            this.wCreated.TabIndex = 29;
            this.wCreated.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.wDeletedTime);
            this.groupBox2.Controls.Add(this.wHiddenTime);
            this.groupBox2.Controls.Add(this.wIsHidden);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.wIsDeleted);
            this.groupBox2.Location = new System.Drawing.Point(12, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 66);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            // 
            // wDeletedTime
            // 
            this.wDeletedTime.BackColor = System.Drawing.SystemColors.Control;
            this.wDeletedTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wDeletedTime.Location = new System.Drawing.Point(190, 39);
            this.wDeletedTime.Name = "wDeletedTime";
            this.wDeletedTime.ReadOnly = true;
            this.wDeletedTime.Size = new System.Drawing.Size(123, 13);
            this.wDeletedTime.TabIndex = 33;
            this.wDeletedTime.TabStop = false;
            // 
            // wHiddenTime
            // 
            this.wHiddenTime.BackColor = System.Drawing.SystemColors.Control;
            this.wHiddenTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wHiddenTime.Location = new System.Drawing.Point(190, 16);
            this.wHiddenTime.Name = "wHiddenTime";
            this.wHiddenTime.ReadOnly = true;
            this.wHiddenTime.Size = new System.Drawing.Size(123, 13);
            this.wHiddenTime.TabIndex = 32;
            this.wHiddenTime.TabStop = false;
            // 
            // Properties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CancelButton = this.CancelDialog;
            this.ClientSize = new System.Drawing.Size(354, 468);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CancelDialog);
            this.Controls.Add(this.wGroupProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Properties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Properties";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Properties_FormClosing);
            this.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            this.wGroupProperties.ResumeLayout(false);
            this.wGroupProperties.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox wGroupProperties;
        private System.Windows.Forms.Button CancelDialog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.TextBox wName;
        internal System.Windows.Forms.TextBox wDescription;
        internal System.Windows.Forms.TextBox wGUID;
        internal System.Windows.Forms.TextBox wID;
        internal System.Windows.Forms.TextBox wType;
        internal System.Windows.Forms.CheckBox wIsDeleted;
        internal System.Windows.Forms.CheckBox wIsHidden;
        internal System.Windows.Forms.TextBox wTimeToday;
        internal System.Windows.Forms.TextBox wTotalTime;
        internal System.Windows.Forms.TextBox wModified;
        internal System.Windows.Forms.TextBox wCreated;
        internal System.Windows.Forms.TextBox wHiddenTime;
        internal System.Windows.Forms.TextBox wDeletedTime;
        internal System.Windows.Forms.TextBox wExternalProjectNo;
        internal System.Windows.Forms.Label wExternalProjectNoLabel;
    }
}