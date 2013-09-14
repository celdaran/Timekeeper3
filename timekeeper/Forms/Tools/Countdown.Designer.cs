namespace Timekeeper.Forms.Tools
{
    partial class Countdown
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.wGroupTimer = new System.Windows.Forms.GroupBox();
            this.wGroupEvent = new System.Windows.Forms.GroupBox();
            this.wHours = new System.Windows.Forms.NumericUpDown();
            this.wMinutes = new System.Windows.Forms.NumericUpDown();
            this.wSeconds = new System.Windows.Forms.NumericUpDown();
            this.btnGo = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.eventName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eventCountdown = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wGroupTimer.SuspendLayout();
            this.wGroupEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSeconds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // wGroupTimer
            // 
            this.wGroupTimer.Controls.Add(this.textBox1);
            this.wGroupTimer.Controls.Add(this.btnGo);
            this.wGroupTimer.Controls.Add(this.wSeconds);
            this.wGroupTimer.Controls.Add(this.wMinutes);
            this.wGroupTimer.Controls.Add(this.wHours);
            this.wGroupTimer.Location = new System.Drawing.Point(12, 12);
            this.wGroupTimer.Name = "wGroupTimer";
            this.wGroupTimer.Size = new System.Drawing.Size(239, 165);
            this.wGroupTimer.TabIndex = 0;
            this.wGroupTimer.TabStop = false;
            this.wGroupTimer.Text = "Timer";
            // 
            // wGroupEvent
            // 
            this.wGroupEvent.Controls.Add(this.dataGridView1);
            this.wGroupEvent.Location = new System.Drawing.Point(257, 12);
            this.wGroupEvent.Name = "wGroupEvent";
            this.wGroupEvent.Size = new System.Drawing.Size(454, 165);
            this.wGroupEvent.TabIndex = 1;
            this.wGroupEvent.TabStop = false;
            this.wGroupEvent.Text = "Event";
            // 
            // wHours
            // 
            this.wHours.Location = new System.Drawing.Point(16, 23);
            this.wHours.Maximum = new decimal(new int[] {
            168,
            0,
            0,
            0});
            this.wHours.Name = "wHours";
            this.wHours.Size = new System.Drawing.Size(40, 20);
            this.wHours.TabIndex = 1;
            // 
            // wMinutes
            // 
            this.wMinutes.Location = new System.Drawing.Point(62, 23);
            this.wMinutes.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.wMinutes.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.wMinutes.Name = "wMinutes";
            this.wMinutes.Size = new System.Drawing.Size(41, 20);
            this.wMinutes.TabIndex = 2;
            this.wMinutes.ValueChanged += new System.EventHandler(this.wMinutes_ValueChanged);
            // 
            // wSeconds
            // 
            this.wSeconds.Location = new System.Drawing.Point(109, 23);
            this.wSeconds.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.wSeconds.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.wSeconds.Name = "wSeconds";
            this.wSeconds.Size = new System.Drawing.Size(41, 20);
            this.wSeconds.TabIndex = 3;
            this.wSeconds.ValueChanged += new System.EventHandler(this.wSeconds_ValueChanged);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(156, 23);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(66, 23);
            this.btnGo.TabIndex = 4;
            this.btnGo.Text = "&Go";
            this.btnGo.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(16, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(206, 62);
            this.textBox1.TabIndex = 5;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(618, 182);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Summer Vacation 2010",
            "Harry Potter and the Deathly Hallows",
            "Christmas in Kilarny"});
            this.comboBox1.Location = new System.Drawing.Point(240, 185);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 192);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(197, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "3 days 2 hours 5 minutes and 8 seconds";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.eventName,
            this.eventDateTime,
            this.eventCountdown});
            this.dataGridView1.Location = new System.Drawing.Point(19, 19);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 20;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.Size = new System.Drawing.Size(417, 134);
            this.dataGridView1.TabIndex = 2;
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
            // eventCountdown
            // 
            this.eventCountdown.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            this.eventCountdown.DefaultCellStyle = dataGridViewCellStyle1;
            this.eventCountdown.HeaderText = "Remaining";
            this.eventCountdown.Name = "eventCountdown";
            this.eventCountdown.ReadOnly = true;
            this.eventCountdown.Width = 82;
            // 
            // fToolCountdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 214);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.wGroupEvent);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.wGroupTimer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fToolCountdown";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Countdown";
            this.wGroupTimer.ResumeLayout(false);
            this.wGroupTimer.PerformLayout();
            this.wGroupEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wSeconds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox wGroupTimer;
        private System.Windows.Forms.GroupBox wGroupEvent;
        private System.Windows.Forms.NumericUpDown wSeconds;
        private System.Windows.Forms.NumericUpDown wMinutes;
        private System.Windows.Forms.NumericUpDown wHours;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventName;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn eventCountdown;
    }
}