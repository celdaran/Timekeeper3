namespace Timekeeper
{
    partial class About
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.wTicks = new System.Windows.Forms.ListBox();
            this.wElapsed = new System.Windows.Forms.TextBox();
            this.FileStats = new System.Windows.Forms.DataGridView();
            this.attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.db_createdate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.btnOK = new System.Windows.Forms.Button();
            this.FileStatsPanel = new System.Windows.Forms.Panel();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileStats)).BeginInit();
            this.BottomPanel.SuspendLayout();
            this.FileStatsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.SystemColors.Control;
            this.HeaderPanel.Controls.Add(this.label3);
            this.HeaderPanel.Controls.Add(this.label2);
            this.HeaderPanel.Controls.Add(this.label1);
            this.HeaderPanel.Controls.Add(this.pictureBox1);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(407, 64);
            this.HeaderPanel.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Copyright © 1999-2013 by Charlie Hills";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Unreleased Development Version (3.0.0.1)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(66, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Timekeeper 3.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Timekeeper.Properties.Resources.ImageIconMedium;
            this.pictureBox1.Location = new System.Drawing.Point(12, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // wTicks
            // 
            this.wTicks.FormattingEnabled = true;
            this.wTicks.Location = new System.Drawing.Point(222, 310);
            this.wTicks.Name = "wTicks";
            this.wTicks.Size = new System.Drawing.Size(230, 160);
            this.wTicks.TabIndex = 12;
            this.wTicks.Visible = false;
            // 
            // wElapsed
            // 
            this.wElapsed.Location = new System.Drawing.Point(270, 284);
            this.wElapsed.Name = "wElapsed";
            this.wElapsed.Size = new System.Drawing.Size(74, 20);
            this.wElapsed.TabIndex = 14;
            this.wElapsed.Visible = false;
            // 
            // FileStats
            // 
            this.FileStats.AllowUserToAddRows = false;
            this.FileStats.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.FileStats.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.FileStats.BackgroundColor = System.Drawing.SystemColors.Control;
            this.FileStats.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FileStats.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FileStats.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.FileStats.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FileStats.ColumnHeadersVisible = false;
            this.FileStats.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.attribute,
            this.db_createdate});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.FileStats.DefaultCellStyle = dataGridViewCellStyle3;
            this.FileStats.Location = new System.Drawing.Point(13, 6);
            this.FileStats.Name = "FileStats";
            this.FileStats.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FileStats.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.FileStats.RowHeadersVisible = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.FileStats.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.FileStats.RowTemplate.Height = 18;
            this.FileStats.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FileStats.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FileStats.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.FileStats.Size = new System.Drawing.Size(382, 112);
            this.FileStats.TabIndex = 15;
            this.FileStats.TabStop = false;
            // 
            // attribute
            // 
            this.attribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.attribute.HeaderText = "Attribute";
            this.attribute.Name = "attribute";
            this.attribute.ReadOnly = true;
            this.attribute.Width = 5;
            // 
            // db_createdate
            // 
            this.db_createdate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.db_createdate.HeaderText = "Value";
            this.db_createdate.Name = "db_createdate";
            this.db_createdate.Width = 5;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.btnOK);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 188);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(407, 34);
            this.BottomPanel.TabIndex = 16;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(319, 3);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FileStatsPanel
            // 
            this.FileStatsPanel.Controls.Add(this.FileStats);
            this.FileStatsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FileStatsPanel.Location = new System.Drawing.Point(0, 64);
            this.FileStatsPanel.Name = "FileStatsPanel";
            this.FileStatsPanel.Size = new System.Drawing.Size(407, 124);
            this.FileStatsPanel.TabIndex = 17;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(407, 222);
            this.Controls.Add(this.FileStatsPanel);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.wElapsed);
            this.Controls.Add(this.wTicks);
            this.Controls.Add(this.HeaderPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.HeaderPanel.ResumeLayout(false);
            this.HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FileStats)).EndInit();
            this.BottomPanel.ResumeLayout(false);
            this.FileStatsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.ListBox wTicks;
        private System.Windows.Forms.TextBox wElapsed;
        private System.Windows.Forms.DataGridView FileStats;
        private System.Windows.Forms.DataGridViewTextBoxColumn attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn db_createdate;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel FileStatsPanel;
    }
}