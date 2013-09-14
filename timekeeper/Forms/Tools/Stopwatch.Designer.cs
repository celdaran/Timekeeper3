namespace Timekeeper
{
    partial class fToolStopwatch
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
            this.components = new System.ComponentModel.Container();
            this.wDisplay = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnSplit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.wSplits = new System.Windows.Forms.DataGridView();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            this.split = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.wSplits)).BeginInit();
            this.SuspendLayout();
            // 
            // wDisplay
            // 
            this.wDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.wDisplay.Font = new System.Drawing.Font("Courier New", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wDisplay.Location = new System.Drawing.Point(12, 12);
            this.wDisplay.Name = "wDisplay";
            this.wDisplay.ReadOnly = true;
            this.wDisplay.Size = new System.Drawing.Size(332, 55);
            this.wDisplay.TabIndex = 0;
            this.wDisplay.TabStop = false;
            this.wDisplay.Text = "00:00:00.00";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(264, 73);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnSplit
            // 
            this.btnSplit.Enabled = false;
            this.btnSplit.Location = new System.Drawing.Point(264, 102);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(75, 23);
            this.btnSplit.TabIndex = 2;
            this.btnSplit.Text = "S&plit";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(264, 176);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // wSplits
            // 
            this.wSplits.AllowUserToAddRows = false;
            this.wSplits.AllowUserToDeleteRows = false;
            this.wSplits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wSplits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.split,
            this.clock});
            this.wSplits.Location = new System.Drawing.Point(12, 73);
            this.wSplits.Name = "wSplits";
            this.wSplits.ReadOnly = true;
            this.wSplits.RowHeadersVisible = false;
            this.wSplits.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.wSplits.Size = new System.Drawing.Size(243, 126);
            this.wSplits.TabIndex = 5;
            // 
            // timer
            // 
            this.timer.Interval = 10;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(264, 131);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "&Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // split
            // 
            this.split.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.split.HeaderText = "Split Time";
            this.split.MinimumWidth = 120;
            this.split.Name = "split";
            this.split.ReadOnly = true;
            this.split.Width = 120;
            // 
            // clock
            // 
            this.clock.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.clock.HeaderText = "Wall Clock";
            this.clock.MinimumWidth = 120;
            this.clock.Name = "clock";
            this.clock.ReadOnly = true;
            this.clock.Width = 120;
            // 
            // fToolStopwatch
            // 
            this.AcceptButton = this.btnStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(347, 212);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.wSplits);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSplit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.wDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fToolStopwatch";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Stopwatch";
            ((System.ComponentModel.ISupportInitialize)(this.wSplits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox wDisplay;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView wSplits;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn split;
        private System.Windows.Forms.DataGridViewTextBoxColumn clock;
    }
}