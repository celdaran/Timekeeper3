namespace Timekeeper
{
    partial class fToolReminders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.eventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.reminderActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.reminderType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventName,
            this.eventDateTime,
            this.eventType,
            this.reminderActive,
            this.reminderType});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(388, 134);
            this.dataGridView1.TabIndex = 3;
            // 
            // eventName
            // 
            this.eventName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.eventName.HeaderText = "Event";
            this.eventName.Name = "eventName";
            this.eventName.Width = 60;
            // 
            // eventDateTime
            // 
            this.eventDateTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.eventDateTime.HeaderText = "Date/Time";
            this.eventDateTime.Name = "eventDateTime";
            this.eventDateTime.Width = 83;
            // 
            // eventType
            // 
            this.eventType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.eventType.HeaderText = "Type";
            this.eventType.Items.AddRange(new object[] {
            "One-Time",
            "Recurring"});
            this.eventType.Name = "eventType";
            this.eventType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.eventType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.eventType.Width = 56;
            // 
            // reminderActive
            // 
            this.reminderActive.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.reminderActive.HeaderText = "Active?";
            this.reminderActive.Name = "reminderActive";
            this.reminderActive.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.reminderActive.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.reminderActive.Width = 68;
            // 
            // reminderType
            // 
            this.reminderType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.reminderType.HeaderText = "Remind";
            this.reminderType.Items.AddRange(new object[] {
            "Audio",
            "Message Box",
            "Email"});
            this.reminderType.Name = "reminderType";
            this.reminderType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.reminderType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.reminderType.Width = 68;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(325, 152);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // fToolReminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 186);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fToolReminders";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Reminders";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDateTime;
        private System.Windows.Forms.DataGridViewComboBoxColumn eventType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn reminderActive;
        private System.Windows.Forms.DataGridViewComboBoxColumn reminderType;
        private System.Windows.Forms.Button btnClose;

    }
}