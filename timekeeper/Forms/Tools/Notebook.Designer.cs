namespace Timekeeper.Forms.Tools
{
    partial class Notebook
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
            this.wGroupEntry = new System.Windows.Forms.GroupBox();
            this.wJumpBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.wEntryDate = new System.Windows.Forms.DateTimePicker();
            this.wEntry = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.wGroupEntry.SuspendLayout();
            this.SuspendLayout();
            // 
            // wGroupEntry
            // 
            this.wGroupEntry.Controls.Add(this.wJumpBox);
            this.wGroupEntry.Controls.Add(this.label3);
            this.wGroupEntry.Controls.Add(this.wEntryDate);
            this.wGroupEntry.Controls.Add(this.wEntry);
            this.wGroupEntry.Controls.Add(this.label2);
            this.wGroupEntry.Controls.Add(this.label1);
            this.wGroupEntry.Location = new System.Drawing.Point(12, 12);
            this.wGroupEntry.Name = "wGroupEntry";
            this.wGroupEntry.Size = new System.Drawing.Size(399, 202);
            this.wGroupEntry.TabIndex = 0;
            this.wGroupEntry.TabStop = false;
            this.wGroupEntry.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wJumpBox
            // 
            this.wJumpBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wJumpBox.FormattingEnabled = true;
            this.wJumpBox.Location = new System.Drawing.Point(236, 18);
            this.wJumpBox.Name = "wJumpBox";
            this.wJumpBox.Size = new System.Drawing.Size(157, 21);
            this.wJumpBox.TabIndex = 4;
            this.wJumpBox.SelectedIndexChanged += new System.EventHandler(this.wJumpBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Jump to Entry";
            // 
            // wEntryDate
            // 
            this.wEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.wEntryDate.Location = new System.Drawing.Point(43, 19);
            this.wEntryDate.Name = "wEntryDate";
            this.wEntryDate.Size = new System.Drawing.Size(101, 20);
            this.wEntryDate.TabIndex = 1;
            // 
            // wEntry
            // 
            this.wEntry.Location = new System.Drawing.Point(43, 48);
            this.wEntry.Name = "wEntry";
            this.wEntry.Size = new System.Drawing.Size(350, 141);
            this.wEntry.TabIndex = 2;
            this.wEntry.Text = "";
            this.wEntry.TextChanged += new System.EventHandler(this.wEntry_TextChanged);
            this.wEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.wEntry_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Entry";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Date";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(255, 227);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(336, 227);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // fToolJournal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(423, 262);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.wGroupEntry);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fToolJournal";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Journal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fToolsJournal_FormClosing);
            this.Load += new System.EventHandler(this.fToolJournal_Load);
            this.wGroupEntry.ResumeLayout(false);
            this.wGroupEntry.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox wGroupEntry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.RichTextBox wEntry;
        internal System.Windows.Forms.DateTimePicker wEntryDate;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.ComboBox wJumpBox;
    }
}