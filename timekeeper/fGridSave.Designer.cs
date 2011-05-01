namespace Timekeeper
{
    partial class fGridSave
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
            this.wGroupName = new System.Windows.Forms.GroupBox();
            this.wEndDateType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wDescription = new System.Windows.Forms.TextBox();
            this.wName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.wGroupName.SuspendLayout();
            this.SuspendLayout();
            // 
            // wGroupName
            // 
            this.wGroupName.Controls.Add(this.wEndDateType);
            this.wGroupName.Controls.Add(this.label3);
            this.wGroupName.Controls.Add(this.wDescription);
            this.wGroupName.Controls.Add(this.wName);
            this.wGroupName.Controls.Add(this.label2);
            this.wGroupName.Controls.Add(this.label1);
            this.wGroupName.Location = new System.Drawing.Point(12, 6);
            this.wGroupName.Name = "wGroupName";
            this.wGroupName.Size = new System.Drawing.Size(275, 101);
            this.wGroupName.TabIndex = 0;
            this.wGroupName.TabStop = false;
            this.wGroupName.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wEndDateType
            // 
            this.wEndDateType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wEndDateType.FormattingEnabled = true;
            this.wEndDateType.Location = new System.Drawing.Point(105, 68);
            this.wEndDateType.Name = "wEndDateType";
            this.wEndDateType.Size = new System.Drawing.Size(143, 21);
            this.wEndDateType.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Save end date as:";
            // 
            // wDescription
            // 
            this.wDescription.Location = new System.Drawing.Point(105, 39);
            this.wDescription.Name = "wDescription";
            this.wDescription.Size = new System.Drawing.Size(143, 20);
            this.wDescription.TabIndex = 4;
            // 
            // wName
            // 
            this.wName.Location = new System.Drawing.Point(105, 13);
            this.wName.Name = "wName";
            this.wName.Size = new System.Drawing.Size(143, 20);
            this.wName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Description:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name of view:";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(128, 113);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(212, 113);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // fGridSave
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(298, 148);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.wGroupName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fGridSave";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Save View";
            this.wGroupName.ResumeLayout(false);
            this.wGroupName.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox wGroupName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.TextBox wDescription;
        internal System.Windows.Forms.TextBox wName;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.ComboBox wEndDateType;
    }
}