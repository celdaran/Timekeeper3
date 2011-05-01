namespace Timekeeper
{
    partial class fLog
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fLog));
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnFirst = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.btnExpand = new System.Windows.Forms.Button();
            this.wGroupMain = new System.Windows.Forms.GroupBox();
            this.btnCloseEndGap = new System.Windows.Forms.Button();
            this.btnCloseStartGap = new System.Windows.Forms.Button();
            this.wProject = new System.Windows.Forms.ComboBox();
            this.wTask = new System.Windows.Forms.ComboBox();
            this.wPostLog = new System.Windows.Forms.RichTextBox();
            this.wPrevLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.wDuration = new System.Windows.Forms.TextBox();
            this.wPrevEnd = new System.Windows.Forms.TextBox();
            this.wPrevStart = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.wID = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.wSplitSearch = new System.Windows.Forms.SplitContainer();
            this.wToDatePicker = new System.Windows.Forms.DateTimePicker();
            this.wFromDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.wSearchText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.wResults = new System.Windows.Forms.DataGridView();
            this.log_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fromDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.task = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.project = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.wGroupMain.SuspendLayout();
            this.wSplitSearch.Panel1.SuspendLayout();
            this.wSplitSearch.Panel2.SuspendLayout();
            this.wSplitSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wResults)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(767, 318);
            this.panel2.TabIndex = 12;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel1.Controls.Add(this.btnUnlock);
            this.splitContainer1.Panel1.Controls.Add(this.btnFirst);
            this.splitContainer1.Panel1.Controls.Add(this.btnLast);
            this.splitContainer1.Panel1.Controls.Add(this.btnExpand);
            this.splitContainer1.Panel1.Controls.Add(this.wGroupMain);
            this.splitContainer1.Panel1.Controls.Add(this.btnOK);
            this.splitContainer1.Panel1.Controls.Add(this.btnPrev);
            this.splitContainer1.Panel1.Controls.Add(this.wID);
            this.splitContainer1.Panel1.Controls.Add(this.btnNext);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.wSplitSearch);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(767, 318);
            this.splitContainer1.SplitterDistance = 488;
            this.splitContainer1.TabIndex = 11;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Location = new System.Drawing.Point(12, 286);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(57, 23);
            this.btnUnlock.TabIndex = 14;
            this.btnUnlock.Text = "Unlock";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Visible = false;
            this.btnUnlock.Click += new System.EventHandler(this.btnUnlock_Click);
            this.btnUnlock.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnFirst
            // 
            this.btnFirst.Location = new System.Drawing.Point(83, 286);
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.Size = new System.Drawing.Size(32, 23);
            this.btnFirst.TabIndex = 9;
            this.btnFirst.Text = "| <";
            this.btnFirst.UseVisualStyleBackColor = true;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            this.btnFirst.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnLast
            // 
            this.btnLast.Location = new System.Drawing.Point(197, 286);
            this.btnLast.Name = "btnLast";
            this.btnLast.Size = new System.Drawing.Size(32, 23);
            this.btnLast.TabIndex = 12;
            this.btnLast.Text = "> &|";
            this.btnLast.UseVisualStyleBackColor = true;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            this.btnLast.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnExpand
            // 
            this.btnExpand.Location = new System.Drawing.Point(415, 286);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(69, 23);
            this.btnExpand.TabIndex = 13;
            this.btnExpand.Text = "Searc&h >>";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            this.btnExpand.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wGroupMain
            // 
            this.wGroupMain.Controls.Add(this.btnCloseEndGap);
            this.wGroupMain.Controls.Add(this.btnCloseStartGap);
            this.wGroupMain.Controls.Add(this.wProject);
            this.wGroupMain.Controls.Add(this.wTask);
            this.wGroupMain.Controls.Add(this.wPostLog);
            this.wGroupMain.Controls.Add(this.wPrevLog);
            this.wGroupMain.Controls.Add(this.label3);
            this.wGroupMain.Controls.Add(this.label4);
            this.wGroupMain.Controls.Add(this.label2);
            this.wGroupMain.Controls.Add(this.label7);
            this.wGroupMain.Controls.Add(this.label6);
            this.wGroupMain.Controls.Add(this.label5);
            this.wGroupMain.Controls.Add(this.wDuration);
            this.wGroupMain.Controls.Add(this.wPrevEnd);
            this.wGroupMain.Controls.Add(this.wPrevStart);
            this.wGroupMain.Controls.Add(this.label1);
            this.wGroupMain.Location = new System.Drawing.Point(12, 3);
            this.wGroupMain.Name = "wGroupMain";
            this.wGroupMain.Size = new System.Drawing.Size(472, 277);
            this.wGroupMain.TabIndex = 1;
            this.wGroupMain.TabStop = false;
            this.wGroupMain.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnCloseEndGap
            // 
            this.btnCloseEndGap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseEndGap.Location = new System.Drawing.Point(200, 40);
            this.btnCloseEndGap.Name = "btnCloseEndGap";
            this.btnCloseEndGap.Size = new System.Drawing.Size(31, 20);
            this.btnCloseEndGap.TabIndex = 15;
            this.btnCloseEndGap.TabStop = false;
            this.btnCloseEndGap.Text = "-->";
            this.btnCloseEndGap.UseVisualStyleBackColor = true;
            this.btnCloseEndGap.Click += new System.EventHandler(this.btnCloseEndGap_Click);
            // 
            // btnCloseStartGap
            // 
            this.btnCloseStartGap.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCloseStartGap.Location = new System.Drawing.Point(200, 14);
            this.btnCloseStartGap.Name = "btnCloseStartGap";
            this.btnCloseStartGap.Size = new System.Drawing.Size(31, 20);
            this.btnCloseStartGap.TabIndex = 14;
            this.btnCloseStartGap.TabStop = false;
            this.btnCloseStartGap.Text = "<--";
            this.btnCloseStartGap.UseVisualStyleBackColor = true;
            this.btnCloseStartGap.Click += new System.EventHandler(this.btnCloseStartGap_Click);
            // 
            // wProject
            // 
            this.wProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wProject.FormattingEnabled = true;
            this.wProject.Location = new System.Drawing.Point(297, 40);
            this.wProject.Name = "wProject";
            this.wProject.Size = new System.Drawing.Size(160, 21);
            this.wProject.TabIndex = 6;
            this.wProject.Enter += new System.EventHandler(this.wEnterControl);
            this.wProject.Leave += new System.EventHandler(this.wLeaveControl);
            // 
            // wTask
            // 
            this.wTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wTask.FormattingEnabled = true;
            this.wTask.Location = new System.Drawing.Point(297, 14);
            this.wTask.Name = "wTask";
            this.wTask.Size = new System.Drawing.Size(160, 21);
            this.wTask.TabIndex = 5;
            this.wTask.Enter += new System.EventHandler(this.wEnterControl);
            this.wTask.Leave += new System.EventHandler(this.wLeaveControl);
            // 
            // wPostLog
            // 
            this.wPostLog.Location = new System.Drawing.Point(297, 92);
            this.wPostLog.Name = "wPostLog";
            this.wPostLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.wPostLog.Size = new System.Drawing.Size(160, 173);
            this.wPostLog.TabIndex = 7;
            this.wPostLog.Text = "";
            this.wPostLog.Enter += new System.EventHandler(this.wEnterControl);
            this.wPostLog.Leave += new System.EventHandler(this.wLeaveControl);
            // 
            // wPrevLog
            // 
            this.wPrevLog.Location = new System.Drawing.Point(71, 92);
            this.wPrevLog.Name = "wPrevLog";
            this.wPrevLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.wPrevLog.Size = new System.Drawing.Size(160, 173);
            this.wPrevLog.TabIndex = 4;
            this.wPrevLog.Text = "";
            this.wPrevLog.Enter += new System.EventHandler(this.wEnterControl);
            this.wPrevLog.Leave += new System.EventHandler(this.wLeaveControl);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pre Log:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Duration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "End:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Post Log:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Project:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(242, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Task:";
            // 
            // wDuration
            // 
            this.wDuration.Location = new System.Drawing.Point(71, 66);
            this.wDuration.Name = "wDuration";
            this.wDuration.Size = new System.Drawing.Size(123, 20);
            this.wDuration.TabIndex = 3;
            this.wDuration.Enter += new System.EventHandler(this.wEnterControl);
            this.wDuration.Leave += new System.EventHandler(this.wDuration_TextChanged);
            // 
            // wPrevEnd
            // 
            this.wPrevEnd.Location = new System.Drawing.Point(71, 40);
            this.wPrevEnd.Name = "wPrevEnd";
            this.wPrevEnd.Size = new System.Drawing.Size(123, 20);
            this.wPrevEnd.TabIndex = 2;
            this.wPrevEnd.Enter += new System.EventHandler(this.wEnterControl);
            this.wPrevEnd.Leave += new System.EventHandler(this.wPrevEnd_TextChanged);
            // 
            // wPrevStart
            // 
            this.wPrevStart.Location = new System.Drawing.Point(71, 14);
            this.wPrevStart.Name = "wPrevStart";
            this.wPrevStart.Size = new System.Drawing.Size(123, 20);
            this.wPrevStart.TabIndex = 1;
            this.wPrevStart.Enter += new System.EventHandler(this.wEnterControl);
            this.wPrevStart.Leave += new System.EventHandler(this.wPrevEnd_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start:";
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnOK.Location = new System.Drawing.Point(309, 286);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(37, 23);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            this.btnOK.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnPrev
            // 
            this.btnPrev.Location = new System.Drawing.Point(121, 286);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(32, 23);
            this.btnPrev.TabIndex = 10;
            this.btnPrev.Text = "&<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            this.btnPrev.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wID
            // 
            this.wID.AutoSize = true;
            this.wID.Location = new System.Drawing.Point(235, 291);
            this.wID.Name = "wID";
            this.wID.Size = new System.Drawing.Size(13, 13);
            this.wID.TabIndex = 9;
            this.wID.Text = "0";
            this.wID.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(159, 286);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(32, 23);
            this.btnNext.TabIndex = 11;
            this.btnNext.Text = ">&>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            this.btnNext.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wSplitSearch
            // 
            this.wSplitSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wSplitSearch.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.wSplitSearch.Location = new System.Drawing.Point(0, 0);
            this.wSplitSearch.Name = "wSplitSearch";
            this.wSplitSearch.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // wSplitSearch.Panel1
            // 
            this.wSplitSearch.Panel1.Controls.Add(this.wToDatePicker);
            this.wSplitSearch.Panel1.Controls.Add(this.wFromDatePicker);
            this.wSplitSearch.Panel1.Controls.Add(this.label8);
            this.wSplitSearch.Panel1.Controls.Add(this.btnGo);
            this.wSplitSearch.Panel1.Controls.Add(this.label10);
            this.wSplitSearch.Panel1.Controls.Add(this.wSearchText);
            this.wSplitSearch.Panel1.Controls.Add(this.label9);
            // 
            // wSplitSearch.Panel2
            // 
            this.wSplitSearch.Panel2.Controls.Add(this.wResults);
            this.wSplitSearch.Size = new System.Drawing.Size(275, 318);
            this.wSplitSearch.SplitterDistance = 136;
            this.wSplitSearch.TabIndex = 15;
            this.wSplitSearch.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wToDatePicker
            // 
            this.wToDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.wToDatePicker.Location = new System.Drawing.Point(51, 39);
            this.wToDatePicker.Name = "wToDatePicker";
            this.wToDatePicker.Size = new System.Drawing.Size(105, 20);
            this.wToDatePicker.TabIndex = 19;
            // 
            // wFromDatePicker
            // 
            this.wFromDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.wFromDatePicker.Location = new System.Drawing.Point(51, 12);
            this.wFromDatePicker.Name = "wFromDatePicker";
            this.wFromDatePicker.Size = new System.Drawing.Size(105, 20);
            this.wFromDatePicker.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "From:";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(51, 93);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 17;
            this.btnGo.Text = "&Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            this.btnGo.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(31, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Text:";
            // 
            // wSearchText
            // 
            this.wSearchText.Location = new System.Drawing.Point(51, 64);
            this.wSearchText.Name = "wSearchText";
            this.wSearchText.Size = new System.Drawing.Size(105, 20);
            this.wSearchText.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "To:";
            // 
            // wResults
            // 
            this.wResults.AllowUserToAddRows = false;
            this.wResults.AllowUserToDeleteRows = false;
            this.wResults.AllowUserToOrderColumns = true;
            this.wResults.AllowUserToResizeRows = false;
            this.wResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.wResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.wResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.log_id,
            this.fromDate,
            this.toDate,
            this.task,
            this.project});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.wResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.wResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wResults.Location = new System.Drawing.Point(0, 0);
            this.wResults.Name = "wResults";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.wResults.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.wResults.RowHeadersVisible = false;
            this.wResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.wResults.Size = new System.Drawing.Size(275, 178);
            this.wResults.TabIndex = 18;
            this.wResults.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            this.wResults.DoubleClick += new System.EventHandler(this.wResults_DoubleClick);
            // 
            // log_id
            // 
            this.log_id.HeaderText = "ID";
            this.log_id.Name = "log_id";
            this.log_id.Visible = false;
            this.log_id.Width = 24;
            // 
            // fromDate
            // 
            this.fromDate.HeaderText = "From";
            this.fromDate.Name = "fromDate";
            this.fromDate.ReadOnly = true;
            this.fromDate.Width = 55;
            // 
            // toDate
            // 
            this.toDate.HeaderText = "To";
            this.toDate.Name = "toDate";
            this.toDate.ReadOnly = true;
            this.toDate.Width = 45;
            // 
            // task
            // 
            this.task.HeaderText = "Task";
            this.task.Name = "task";
            this.task.ReadOnly = true;
            this.task.Width = 56;
            // 
            // project
            // 
            this.project.HeaderText = "Project";
            this.project.Name = "project";
            this.project.ReadOnly = true;
            this.project.Width = 65;
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(275, 351);
            this.panel1.TabIndex = 14;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(353, 286);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // fLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnOK;
            this.ClientSize = new System.Drawing.Size(767, 318);
            this.Controls.Add(this.panel2);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fLog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Log Browser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fLog_FormClosing);
            this.Load += new System.EventHandler(this.fLog_Load);
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.wGroupMain.ResumeLayout(false);
            this.wGroupMain.PerformLayout();
            this.wSplitSearch.Panel1.ResumeLayout(false);
            this.wSplitSearch.Panel1.PerformLayout();
            this.wSplitSearch.Panel2.ResumeLayout(false);
            this.wSplitSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.wResults)).EndInit();
            this.ResumeLayout(false);

}

        #endregion

private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.GroupBox wGroupMain;
        private System.Windows.Forms.ComboBox wProject;
        private System.Windows.Forms.ComboBox wTask;
        private System.Windows.Forms.RichTextBox wPostLog;
        private System.Windows.Forms.RichTextBox wPrevLog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox wDuration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox wPrevEnd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox wPrevStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label wID;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.TextBox wSearchText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView wResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn log_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fromDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn toDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn task;
        private System.Windows.Forms.DataGridViewTextBoxColumn project;
        private System.Windows.Forms.SplitContainer wSplitSearch;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Button btnUnlock;
        private System.Windows.Forms.Button btnCloseStartGap;
        private System.Windows.Forms.Button btnCloseEndGap;
        private System.Windows.Forms.DateTimePicker wFromDatePicker;
        private System.Windows.Forms.DateTimePicker wToDatePicker;
        private System.Windows.Forms.Button btnCancel;

}
}