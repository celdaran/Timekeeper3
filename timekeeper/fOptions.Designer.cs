namespace Timekeeper
{
    partial class fOptions
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
            this.wViewProjectPane = new System.Windows.Forms.CheckBox();
            this.wMinimizeOnUse = new System.Windows.Forms.CheckBox();
            this.wShowInTray = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.wPreLog = new System.Windows.Forms.CheckBox();
            this.wPostLog = new System.Windows.Forms.CheckBox();
            this.wTabs = new System.Windows.Forms.TabControl();
            this.tabInterface = new System.Windows.Forms.TabPage();
            this.wGroupLayout = new System.Windows.Forms.GroupBox();
            this.wFontSize = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.wFontList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.wOrderBy = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.wProfile = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wGroupView = new System.Windows.Forms.GroupBox();
            this.wViewHiddenProjects = new System.Windows.Forms.CheckBox();
            this.wViewHiddenTasks = new System.Windows.Forms.CheckBox();
            this.wViewOpenedFile = new System.Windows.Forms.CheckBox();
            this.wViewStatusBar = new System.Windows.Forms.CheckBox();
            this.wViewElapsedAll = new System.Windows.Forms.CheckBox();
            this.wViewCurrentTask = new System.Windows.Forms.CheckBox();
            this.wViewElapsedOne = new System.Windows.Forms.CheckBox();
            this.wViewElapsedCurrent = new System.Windows.Forms.CheckBox();
            this.tabBehavior = new System.Windows.Forms.TabPage();
            this.wGroupTimer = new System.Windows.Forms.GroupBox();
            this.wShowCurrent = new System.Windows.Forms.RadioButton();
            this.wShowTodayAll = new System.Windows.Forms.RadioButton();
            this.wShowToday = new System.Windows.Forms.RadioButton();
            this.wGroupOther = new System.Windows.Forms.GroupBox();
            this.wPromptHide = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelMinutes = new System.Windows.Forms.Label();
            this.wPromptInterval = new System.Windows.Forms.NumericUpDown();
            this.wPromptNoTimer = new System.Windows.Forms.CheckBox();
            this.wProjectFollow = new System.Windows.Forms.CheckBox();
            this.wGroupAnnotations = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.wGroupWindow = new System.Windows.Forms.GroupBox();
            this.wMinimizeToTray = new System.Windows.Forms.CheckBox();
            this.tabKeyboard = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.wKey = new System.Windows.Forms.ComboBox();
            this.wShift = new System.Windows.Forms.CheckBox();
            this.wCtrl = new System.Windows.Forms.CheckBox();
            this.wFunctionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.wSQLtracing = new System.Windows.Forms.CheckBox();
            this.wTestMode = new System.Windows.Forms.CheckBox();
            this.wTabs.SuspendLayout();
            this.tabInterface.SuspendLayout();
            this.wGroupLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wFontSize)).BeginInit();
            this.wGroupView.SuspendLayout();
            this.tabBehavior.SuspendLayout();
            this.wGroupTimer.SuspendLayout();
            this.wGroupOther.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wPromptInterval)).BeginInit();
            this.wGroupAnnotations.SuspendLayout();
            this.wGroupWindow.SuspendLayout();
            this.tabKeyboard.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // wViewProjectPane
            // 
            this.wViewProjectPane.AutoSize = true;
            this.wViewProjectPane.Checked = true;
            this.wViewProjectPane.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wViewProjectPane.Location = new System.Drawing.Point(25, 163);
            this.wViewProjectPane.Name = "wViewProjectPane";
            this.wViewProjectPane.Size = new System.Drawing.Size(87, 17);
            this.wViewProjectPane.TabIndex = 9;
            this.wViewProjectPane.Text = "Project Pane";
            this.wViewProjectPane.UseVisualStyleBackColor = true;
            // 
            // wMinimizeOnUse
            // 
            this.wMinimizeOnUse.AutoSize = true;
            this.wMinimizeOnUse.Checked = true;
            this.wMinimizeOnUse.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wMinimizeOnUse.Location = new System.Drawing.Point(25, 68);
            this.wMinimizeOnUse.Name = "wMinimizeOnUse";
            this.wMinimizeOnUse.Size = new System.Drawing.Size(103, 17);
            this.wMinimizeOnUse.TabIndex = 13;
            this.wMinimizeOnUse.Text = "Minimize on Use";
            this.wMinimizeOnUse.UseVisualStyleBackColor = true;
            this.wMinimizeOnUse.CheckedChanged += new System.EventHandler(this.wMinimizeOnUse_CheckedChanged);
            // 
            // wShowInTray
            // 
            this.wShowInTray.AutoSize = true;
            this.wShowInTray.Checked = true;
            this.wShowInTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wShowInTray.Location = new System.Drawing.Point(25, 22);
            this.wShowInTray.Name = "wShowInTray";
            this.wShowInTray.Size = new System.Drawing.Size(88, 17);
            this.wShowInTray.TabIndex = 11;
            this.wShowInTray.Text = "Show in Tray";
            this.wShowInTray.UseVisualStyleBackColor = true;
            this.wShowInTray.CheckedChanged += new System.EventHandler(this.wShowInTray_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Location = new System.Drawing.Point(402, 297);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(483, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            this.btnCancel.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wPreLog
            // 
            this.wPreLog.AutoSize = true;
            this.wPreLog.Checked = true;
            this.wPreLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wPreLog.Location = new System.Drawing.Point(25, 19);
            this.wPreLog.Name = "wPreLog";
            this.wPreLog.Size = new System.Drawing.Size(154, 17);
            this.wPreLog.TabIndex = 6;
            this.wPreLog.Text = "Prompt before starting timer";
            this.wPreLog.UseVisualStyleBackColor = true;
            // 
            // wPostLog
            // 
            this.wPostLog.AutoSize = true;
            this.wPostLog.Checked = true;
            this.wPostLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wPostLog.Location = new System.Drawing.Point(25, 42);
            this.wPostLog.Name = "wPostLog";
            this.wPostLog.Size = new System.Drawing.Size(136, 17);
            this.wPostLog.TabIndex = 7;
            this.wPostLog.Text = "Prompt after timer stops";
            this.wPostLog.UseVisualStyleBackColor = true;
            // 
            // wTabs
            // 
            this.wTabs.Controls.Add(this.tabInterface);
            this.wTabs.Controls.Add(this.tabBehavior);
            this.wTabs.Controls.Add(this.tabKeyboard);
            this.wTabs.Location = new System.Drawing.Point(12, 12);
            this.wTabs.Name = "wTabs";
            this.wTabs.SelectedIndex = 0;
            this.wTabs.Size = new System.Drawing.Size(550, 279);
            this.wTabs.TabIndex = 11;
            // 
            // tabInterface
            // 
            this.tabInterface.Controls.Add(this.wGroupLayout);
            this.tabInterface.Controls.Add(this.wGroupView);
            this.tabInterface.Location = new System.Drawing.Point(4, 22);
            this.tabInterface.Name = "tabInterface";
            this.tabInterface.Padding = new System.Windows.Forms.Padding(3);
            this.tabInterface.Size = new System.Drawing.Size(542, 253);
            this.tabInterface.TabIndex = 1;
            this.tabInterface.Text = "Interface";
            this.tabInterface.UseVisualStyleBackColor = true;
            // 
            // wGroupLayout
            // 
            this.wGroupLayout.Controls.Add(this.wFontSize);
            this.wGroupLayout.Controls.Add(this.label8);
            this.wGroupLayout.Controls.Add(this.wFontList);
            this.wGroupLayout.Controls.Add(this.label7);
            this.wGroupLayout.Controls.Add(this.wOrderBy);
            this.wGroupLayout.Controls.Add(this.label6);
            this.wGroupLayout.Controls.Add(this.wProfile);
            this.wGroupLayout.Controls.Add(this.label1);
            this.wGroupLayout.Location = new System.Drawing.Point(257, 6);
            this.wGroupLayout.Name = "wGroupLayout";
            this.wGroupLayout.Size = new System.Drawing.Size(279, 241);
            this.wGroupLayout.TabIndex = 10;
            this.wGroupLayout.TabStop = false;
            this.wGroupLayout.Text = "Layout Options";
            this.wGroupLayout.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wFontSize
            // 
            this.wFontSize.Location = new System.Drawing.Point(90, 165);
            this.wFontSize.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.wFontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.wFontSize.Name = "wFontSize";
            this.wFontSize.Size = new System.Drawing.Size(51, 20);
            this.wFontSize.TabIndex = 18;
            this.wFontSize.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 165);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Font si&ze:";
            // 
            // wFontList
            // 
            this.wFontList.FormattingEnabled = true;
            this.wFontList.Location = new System.Drawing.Point(91, 84);
            this.wFontList.Name = "wFontList";
            this.wFontList.Size = new System.Drawing.Size(155, 69);
            this.wFontList.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Report &font:";
            // 
            // wOrderBy
            // 
            this.wOrderBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.wOrderBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.wOrderBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wOrderBy.FormattingEnabled = true;
            this.wOrderBy.Items.AddRange(new object[] {
            "Alphabetically",
            "Reverse Alphabetically",
            "Create Date",
            "Create Date Descending",
            "Modified Date",
            "Modified Date Descending"});
            this.wOrderBy.Location = new System.Drawing.Point(91, 52);
            this.wOrderBy.Name = "wOrderBy";
            this.wOrderBy.Size = new System.Drawing.Size(155, 21);
            this.wOrderBy.TabIndex = 14;
            this.wOrderBy.SelectedIndexChanged += new System.EventHandler(this.wOrderBy_SelectedIndexChanged);
            this.wOrderBy.SelectionChangeCommitted += new System.EventHandler(this.wOrderBy_SelectionChangeCommitted);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "&Sort items by:";
            // 
            // wProfile
            // 
            this.wProfile.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.wProfile.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.wProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wProfile.FormattingEnabled = true;
            this.wProfile.Items.AddRange(new object[] {
            "Basic",
            "Normal",
            "Advanced"});
            this.wProfile.Location = new System.Drawing.Point(91, 25);
            this.wProfile.Name = "wProfile";
            this.wProfile.Size = new System.Drawing.Size(155, 21);
            this.wProfile.TabIndex = 12;
            this.wProfile.SelectedIndexChanged += new System.EventHandler(this.wProfile_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Basic &profile:";
            // 
            // wGroupView
            // 
            this.wGroupView.Controls.Add(this.wViewHiddenProjects);
            this.wGroupView.Controls.Add(this.wViewHiddenTasks);
            this.wGroupView.Controls.Add(this.wViewProjectPane);
            this.wGroupView.Controls.Add(this.wViewOpenedFile);
            this.wGroupView.Controls.Add(this.wViewStatusBar);
            this.wGroupView.Controls.Add(this.wViewElapsedAll);
            this.wGroupView.Controls.Add(this.wViewCurrentTask);
            this.wGroupView.Controls.Add(this.wViewElapsedOne);
            this.wGroupView.Controls.Add(this.wViewElapsedCurrent);
            this.wGroupView.Location = new System.Drawing.Point(6, 6);
            this.wGroupView.Name = "wGroupView";
            this.wGroupView.Size = new System.Drawing.Size(245, 241);
            this.wGroupView.TabIndex = 1;
            this.wGroupView.TabStop = false;
            this.wGroupView.Text = "View Options";
            this.wGroupView.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wViewHiddenProjects
            // 
            this.wViewHiddenProjects.AutoSize = true;
            this.wViewHiddenProjects.Location = new System.Drawing.Point(25, 209);
            this.wViewHiddenProjects.Name = "wViewHiddenProjects";
            this.wViewHiddenProjects.Size = new System.Drawing.Size(101, 17);
            this.wViewHiddenProjects.TabIndex = 11;
            this.wViewHiddenProjects.Text = "Hidden Projects";
            this.wViewHiddenProjects.UseVisualStyleBackColor = true;
            // 
            // wViewHiddenTasks
            // 
            this.wViewHiddenTasks.AutoSize = true;
            this.wViewHiddenTasks.Location = new System.Drawing.Point(25, 186);
            this.wViewHiddenTasks.Name = "wViewHiddenTasks";
            this.wViewHiddenTasks.Size = new System.Drawing.Size(92, 17);
            this.wViewHiddenTasks.TabIndex = 10;
            this.wViewHiddenTasks.Text = "Hidden Tasks";
            this.wViewHiddenTasks.UseVisualStyleBackColor = true;
            // 
            // wViewOpenedFile
            // 
            this.wViewOpenedFile.AutoSize = true;
            this.wViewOpenedFile.Checked = true;
            this.wViewOpenedFile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wViewOpenedFile.Location = new System.Drawing.Point(45, 140);
            this.wViewOpenedFile.Name = "wViewOpenedFile";
            this.wViewOpenedFile.Size = new System.Drawing.Size(127, 17);
            this.wViewOpenedFile.TabIndex = 8;
            this.wViewOpenedFile.Text = "Currently Opened File";
            this.wViewOpenedFile.UseVisualStyleBackColor = true;
            // 
            // wViewStatusBar
            // 
            this.wViewStatusBar.AutoSize = true;
            this.wViewStatusBar.Checked = true;
            this.wViewStatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wViewStatusBar.Location = new System.Drawing.Point(25, 22);
            this.wViewStatusBar.Name = "wViewStatusBar";
            this.wViewStatusBar.Size = new System.Drawing.Size(75, 17);
            this.wViewStatusBar.TabIndex = 3;
            this.wViewStatusBar.Text = "Status Bar";
            this.wViewStatusBar.UseVisualStyleBackColor = true;
            this.wViewStatusBar.CheckedChanged += new System.EventHandler(this.wViewStatusBar_CheckedChanged);
            // 
            // wViewElapsedAll
            // 
            this.wViewElapsedAll.AutoSize = true;
            this.wViewElapsedAll.Checked = true;
            this.wViewElapsedAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wViewElapsedAll.Location = new System.Drawing.Point(45, 116);
            this.wViewElapsedAll.Name = "wViewElapsedAll";
            this.wViewElapsedAll.Size = new System.Drawing.Size(175, 17);
            this.wViewElapsedAll.TabIndex = 7;
            this.wViewElapsedAll.Text = "Elapsed Time Today (All Tasks)";
            this.wViewElapsedAll.UseVisualStyleBackColor = true;
            // 
            // wViewCurrentTask
            // 
            this.wViewCurrentTask.AutoSize = true;
            this.wViewCurrentTask.Checked = true;
            this.wViewCurrentTask.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wViewCurrentTask.Location = new System.Drawing.Point(45, 45);
            this.wViewCurrentTask.Name = "wViewCurrentTask";
            this.wViewCurrentTask.Size = new System.Drawing.Size(87, 17);
            this.wViewCurrentTask.TabIndex = 4;
            this.wViewCurrentTask.Text = "Current Task";
            this.wViewCurrentTask.UseVisualStyleBackColor = true;
            // 
            // wViewElapsedOne
            // 
            this.wViewElapsedOne.AutoSize = true;
            this.wViewElapsedOne.Checked = true;
            this.wViewElapsedOne.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wViewElapsedOne.Location = new System.Drawing.Point(45, 92);
            this.wViewElapsedOne.Name = "wViewElapsedOne";
            this.wViewElapsedOne.Size = new System.Drawing.Size(193, 17);
            this.wViewElapsedOne.TabIndex = 6;
            this.wViewElapsedOne.Text = "Elapsed Time Today (Current Task)";
            this.wViewElapsedOne.UseVisualStyleBackColor = true;
            // 
            // wViewElapsedCurrent
            // 
            this.wViewElapsedCurrent.AutoSize = true;
            this.wViewElapsedCurrent.Checked = true;
            this.wViewElapsedCurrent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wViewElapsedCurrent.Location = new System.Drawing.Point(45, 68);
            this.wViewElapsedCurrent.Name = "wViewElapsedCurrent";
            this.wViewElapsedCurrent.Size = new System.Drawing.Size(157, 17);
            this.wViewElapsedCurrent.TabIndex = 5;
            this.wViewElapsedCurrent.Text = "Elapsed Time Since Started";
            this.wViewElapsedCurrent.UseVisualStyleBackColor = true;
            // 
            // tabBehavior
            // 
            this.tabBehavior.Controls.Add(this.wGroupTimer);
            this.tabBehavior.Controls.Add(this.wGroupOther);
            this.tabBehavior.Controls.Add(this.wGroupAnnotations);
            this.tabBehavior.Controls.Add(this.wGroupWindow);
            this.tabBehavior.Location = new System.Drawing.Point(4, 22);
            this.tabBehavior.Name = "tabBehavior";
            this.tabBehavior.Padding = new System.Windows.Forms.Padding(3);
            this.tabBehavior.Size = new System.Drawing.Size(542, 253);
            this.tabBehavior.TabIndex = 0;
            this.tabBehavior.Text = "Behavior";
            this.tabBehavior.UseVisualStyleBackColor = true;
            // 
            // wGroupTimer
            // 
            this.wGroupTimer.Controls.Add(this.wShowCurrent);
            this.wGroupTimer.Controls.Add(this.wShowTodayAll);
            this.wGroupTimer.Controls.Add(this.wShowToday);
            this.wGroupTimer.Location = new System.Drawing.Point(6, 6);
            this.wGroupTimer.Name = "wGroupTimer";
            this.wGroupTimer.Size = new System.Drawing.Size(336, 102);
            this.wGroupTimer.TabIndex = 1;
            this.wGroupTimer.TabStop = false;
            this.wGroupTimer.Text = "Title Bar Display";
            // 
            // wShowCurrent
            // 
            this.wShowCurrent.AutoSize = true;
            this.wShowCurrent.Checked = true;
            this.wShowCurrent.Location = new System.Drawing.Point(25, 22);
            this.wShowCurrent.Name = "wShowCurrent";
            this.wShowCurrent.Size = new System.Drawing.Size(155, 17);
            this.wShowCurrent.TabIndex = 2;
            this.wShowCurrent.TabStop = true;
            this.wShowCurrent.Text = "Time since timer last started";
            this.wShowCurrent.UseVisualStyleBackColor = true;
            // 
            // wShowTodayAll
            // 
            this.wShowTodayAll.AutoSize = true;
            this.wShowTodayAll.Location = new System.Drawing.Point(25, 68);
            this.wShowTodayAll.Name = "wShowTodayAll";
            this.wShowTodayAll.Size = new System.Drawing.Size(170, 17);
            this.wShowTodayAll.TabIndex = 4;
            this.wShowTodayAll.Text = "Elapsed time today for all tasks";
            this.wShowTodayAll.UseVisualStyleBackColor = true;
            // 
            // wShowToday
            // 
            this.wShowToday.AutoSize = true;
            this.wShowToday.Location = new System.Drawing.Point(25, 45);
            this.wShowToday.Name = "wShowToday";
            this.wShowToday.Size = new System.Drawing.Size(152, 17);
            this.wShowToday.TabIndex = 3;
            this.wShowToday.Text = "Elapsed time today for task";
            this.wShowToday.UseVisualStyleBackColor = true;
            // 
            // wGroupOther
            // 
            this.wGroupOther.Controls.Add(this.wPromptHide);
            this.wGroupOther.Controls.Add(this.label2);
            this.wGroupOther.Controls.Add(this.labelMinutes);
            this.wGroupOther.Controls.Add(this.wPromptInterval);
            this.wGroupOther.Controls.Add(this.wPromptNoTimer);
            this.wGroupOther.Controls.Add(this.wProjectFollow);
            this.wGroupOther.Location = new System.Drawing.Point(348, 111);
            this.wGroupOther.Name = "wGroupOther";
            this.wGroupOther.Size = new System.Drawing.Size(188, 136);
            this.wGroupOther.TabIndex = 14;
            this.wGroupOther.TabStop = false;
            this.wGroupOther.Text = "Annoyances";
            this.wGroupOther.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wPromptHide
            // 
            this.wPromptHide.AutoSize = true;
            this.wPromptHide.Checked = true;
            this.wPromptHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wPromptHide.Location = new System.Drawing.Point(25, 42);
            this.wPromptHide.Name = "wPromptHide";
            this.wPromptHide.Size = new System.Drawing.Size(150, 17);
            this.wPromptHide.TabIndex = 16;
            this.wPromptHide.Text = "Prompt before hiding items";
            this.wPromptHide.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "minutes.";
            // 
            // labelMinutes
            // 
            this.labelMinutes.AutoSize = true;
            this.labelMinutes.Location = new System.Drawing.Point(51, 87);
            this.labelMinutes.Name = "labelMinutes";
            this.labelMinutes.Size = new System.Drawing.Size(28, 13);
            this.labelMinutes.TabIndex = 14;
            this.labelMinutes.Text = "after";
            // 
            // wPromptInterval
            // 
            this.wPromptInterval.Location = new System.Drawing.Point(82, 85);
            this.wPromptInterval.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.wPromptInterval.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.wPromptInterval.Name = "wPromptInterval";
            this.wPromptInterval.Size = new System.Drawing.Size(47, 20);
            this.wPromptInterval.TabIndex = 18;
            this.wPromptInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // wPromptNoTimer
            // 
            this.wPromptNoTimer.AutoSize = true;
            this.wPromptNoTimer.Checked = true;
            this.wPromptNoTimer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wPromptNoTimer.Location = new System.Drawing.Point(25, 65);
            this.wPromptNoTimer.Name = "wPromptNoTimer";
            this.wPromptNoTimer.Size = new System.Drawing.Size(145, 17);
            this.wPromptNoTimer.TabIndex = 17;
            this.wPromptNoTimer.Text = "Prompt if no timer running";
            this.wPromptNoTimer.UseVisualStyleBackColor = true;
            // 
            // wProjectFollow
            // 
            this.wProjectFollow.AutoSize = true;
            this.wProjectFollow.Location = new System.Drawing.Point(25, 19);
            this.wProjectFollow.Name = "wProjectFollow";
            this.wProjectFollow.Size = new System.Drawing.Size(160, 17);
            this.wProjectFollow.TabIndex = 15;
            this.wProjectFollow.Text = "Project follows selected task";
            this.wProjectFollow.UseVisualStyleBackColor = true;
            // 
            // wGroupAnnotations
            // 
            this.wGroupAnnotations.Controls.Add(this.comboBox2);
            this.wGroupAnnotations.Controls.Add(this.comboBox1);
            this.wGroupAnnotations.Controls.Add(this.label4);
            this.wGroupAnnotations.Controls.Add(this.label3);
            this.wGroupAnnotations.Controls.Add(this.wPostLog);
            this.wGroupAnnotations.Controls.Add(this.wPreLog);
            this.wGroupAnnotations.Location = new System.Drawing.Point(6, 111);
            this.wGroupAnnotations.Name = "wGroupAnnotations";
            this.wGroupAnnotations.Size = new System.Drawing.Size(336, 136);
            this.wGroupAnnotations.TabIndex = 5;
            this.wGroupAnnotations.TabStop = false;
            this.wGroupAnnotations.Text = "Annotations";
            this.wGroupAnnotations.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // comboBox2
            // 
            this.comboBox2.Enabled = false;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Creates a new line",
            "Closes the dialog box"});
            this.comboBox2.Location = new System.Drawing.Point(176, 87);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(145, 21);
            this.comboBox2.TabIndex = 9;
            this.comboBox2.Text = "Creates a new line";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Creates a new line",
            "Closes the dialog box"});
            this.comboBox1.Location = new System.Drawing.Point(176, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(145, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.Text = "Closes the dialog box";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Using Enter key after timer:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Using Enter key before timer:";
            // 
            // wGroupWindow
            // 
            this.wGroupWindow.Controls.Add(this.wShowInTray);
            this.wGroupWindow.Controls.Add(this.wMinimizeToTray);
            this.wGroupWindow.Controls.Add(this.wMinimizeOnUse);
            this.wGroupWindow.Location = new System.Drawing.Point(348, 6);
            this.wGroupWindow.Name = "wGroupWindow";
            this.wGroupWindow.Size = new System.Drawing.Size(188, 102);
            this.wGroupWindow.TabIndex = 10;
            this.wGroupWindow.TabStop = false;
            this.wGroupWindow.Text = "Window Control";
            this.wGroupWindow.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.widget_HelpRequested);
            // 
            // wMinimizeToTray
            // 
            this.wMinimizeToTray.AutoSize = true;
            this.wMinimizeToTray.Checked = true;
            this.wMinimizeToTray.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wMinimizeToTray.Location = new System.Drawing.Point(25, 45);
            this.wMinimizeToTray.Name = "wMinimizeToTray";
            this.wMinimizeToTray.Size = new System.Drawing.Size(102, 17);
            this.wMinimizeToTray.TabIndex = 12;
            this.wMinimizeToTray.Text = "Minimize to Tray";
            this.wMinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // tabKeyboard
            // 
            this.tabKeyboard.Controls.Add(this.groupBox1);
            this.tabKeyboard.Location = new System.Drawing.Point(4, 22);
            this.tabKeyboard.Name = "tabKeyboard";
            this.tabKeyboard.Padding = new System.Windows.Forms.Padding(3);
            this.tabKeyboard.Size = new System.Drawing.Size(542, 253);
            this.tabKeyboard.TabIndex = 3;
            this.tabKeyboard.Text = "Keyboard";
            this.tabKeyboard.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.wFunctionList);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 241);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemove);
            this.groupBox2.Controls.Add(this.wKey);
            this.groupBox2.Controls.Add(this.wShift);
            this.groupBox2.Controls.Add(this.wCtrl);
            this.groupBox2.Location = new System.Drawing.Point(227, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 114);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Shortcut";
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(86, 76);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 10;
            this.btnRemove.Text = "&Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // wKey
            // 
            this.wKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.wKey.FormattingEnabled = true;
            this.wKey.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D",
            "E",
            "F",
            "G",
            "H",
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
            "-"});
            this.wKey.Location = new System.Drawing.Point(118, 26);
            this.wKey.Name = "wKey";
            this.wKey.Size = new System.Drawing.Size(43, 21);
            this.wKey.TabIndex = 9;
            this.wKey.SelectedIndexChanged += new System.EventHandler(this.wKey_SelectedIndexChanged);
            // 
            // wShift
            // 
            this.wShift.AutoSize = true;
            this.wShift.Location = new System.Drawing.Point(65, 28);
            this.wShift.Name = "wShift";
            this.wShift.Size = new System.Drawing.Size(47, 17);
            this.wShift.TabIndex = 8;
            this.wShift.Text = "Shift";
            this.wShift.UseVisualStyleBackColor = true;
            this.wShift.MouseClick += new System.Windows.Forms.MouseEventHandler(this.wShift_MouseClick);
            // 
            // wCtrl
            // 
            this.wCtrl.AutoSize = true;
            this.wCtrl.Location = new System.Drawing.Point(18, 28);
            this.wCtrl.Name = "wCtrl";
            this.wCtrl.Size = new System.Drawing.Size(41, 17);
            this.wCtrl.TabIndex = 7;
            this.wCtrl.Text = "Ctrl";
            this.wCtrl.UseVisualStyleBackColor = true;
            this.wCtrl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.wCtrl_MouseClick);
            // 
            // wFunctionList
            // 
            this.wFunctionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.wFunctionList.FullRowSelect = true;
            this.wFunctionList.Location = new System.Drawing.Point(18, 19);
            this.wFunctionList.MultiSelect = false;
            this.wFunctionList.Name = "wFunctionList";
            this.wFunctionList.Size = new System.Drawing.Size(192, 216);
            this.wFunctionList.TabIndex = 7;
            this.wFunctionList.UseCompatibleStateImageBehavior = false;
            this.wFunctionList.View = System.Windows.Forms.View.Details;
            this.wFunctionList.SelectedIndexChanged += new System.EventHandler(this.wFunctionList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Function";
            this.columnHeader1.Width = 171;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(155, 17);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Time since timer last started";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(8, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(170, 17);
            this.radioButton3.TabIndex = 24;
            this.radioButton3.Text = "Elapsed time today for all tasks";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(152, 17);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.Text = "Elapsed time today for task";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // wSQLtracing
            // 
            this.wSQLtracing.AutoSize = true;
            this.wSQLtracing.Checked = true;
            this.wSQLtracing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.wSQLtracing.Location = new System.Drawing.Point(13, 301);
            this.wSQLtracing.Name = "wSQLtracing";
            this.wSQLtracing.Size = new System.Drawing.Size(136, 17);
            this.wSQLtracing.TabIndex = 19;
            this.wSQLtracing.Text = "Debug SQL statements";
            this.wSQLtracing.UseVisualStyleBackColor = true;
            this.wSQLtracing.Visible = false;
            // 
            // wTestMode
            // 
            this.wTestMode.AutoSize = true;
            this.wTestMode.Location = new System.Drawing.Point(155, 301);
            this.wTestMode.Name = "wTestMode";
            this.wTestMode.Size = new System.Drawing.Size(77, 17);
            this.wTestMode.TabIndex = 20;
            this.wTestMode.Text = "Test Mode";
            this.wTestMode.UseVisualStyleBackColor = true;
            this.wTestMode.Visible = false;
            // 
            // fOptions
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(574, 332);
            this.Controls.Add(this.wTestMode);
            this.Controls.Add(this.wSQLtracing);
            this.Controls.Add(this.wTabs);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fOptions_FormClosing);
            this.wTabs.ResumeLayout(false);
            this.tabInterface.ResumeLayout(false);
            this.wGroupLayout.ResumeLayout(false);
            this.wGroupLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wFontSize)).EndInit();
            this.wGroupView.ResumeLayout(false);
            this.wGroupView.PerformLayout();
            this.tabBehavior.ResumeLayout(false);
            this.wGroupTimer.ResumeLayout(false);
            this.wGroupTimer.PerformLayout();
            this.wGroupOther.ResumeLayout(false);
            this.wGroupOther.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wPromptInterval)).EndInit();
            this.wGroupAnnotations.ResumeLayout(false);
            this.wGroupAnnotations.PerformLayout();
            this.wGroupWindow.ResumeLayout(false);
            this.wGroupWindow.PerformLayout();
            this.tabKeyboard.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl wTabs;
        private System.Windows.Forms.TabPage tabBehavior;
        private System.Windows.Forms.TabPage tabInterface;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.CheckBox wViewProjectPane;
        internal System.Windows.Forms.CheckBox wMinimizeOnUse;
        internal System.Windows.Forms.CheckBox wShowInTray;
        internal System.Windows.Forms.CheckBox wPreLog;
        internal System.Windows.Forms.CheckBox wPostLog;
        internal System.Windows.Forms.CheckBox wViewElapsedAll;
        internal System.Windows.Forms.CheckBox wViewElapsedOne;
        internal System.Windows.Forms.CheckBox wViewElapsedCurrent;
        internal System.Windows.Forms.CheckBox wViewCurrentTask;
        internal System.Windows.Forms.CheckBox wViewStatusBar;
        internal System.Windows.Forms.ComboBox wProfile;
        internal System.Windows.Forms.CheckBox wViewOpenedFile;
        internal System.Windows.Forms.CheckBox wMinimizeToTray;
        private System.Windows.Forms.GroupBox wGroupView;
        private System.Windows.Forms.GroupBox wGroupWindow;
        private System.Windows.Forms.GroupBox wGroupAnnotations;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TabPage tabKeyboard;
        private System.Windows.Forms.GroupBox wGroupLayout;
        internal System.Windows.Forms.ComboBox wOrderBy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox wGroupOther;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.ListBox wFontList;
        internal System.Windows.Forms.NumericUpDown wFontSize;
        internal System.Windows.Forms.CheckBox wProjectFollow;
        internal System.Windows.Forms.CheckBox wSQLtracing;
        internal System.Windows.Forms.CheckBox wTestMode;
        internal System.Windows.Forms.CheckBox wViewHiddenProjects;
        internal System.Windows.Forms.CheckBox wViewHiddenTasks;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListView wFunctionList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox wKey;
        private System.Windows.Forms.CheckBox wShift;
        private System.Windows.Forms.CheckBox wCtrl;
        private System.Windows.Forms.Button btnRemove;
        internal System.Windows.Forms.GroupBox wGroupTimer;
        internal System.Windows.Forms.RadioButton wShowCurrent;
        internal System.Windows.Forms.RadioButton wShowTodayAll;
        internal System.Windows.Forms.RadioButton wShowToday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelMinutes;
        internal System.Windows.Forms.NumericUpDown wPromptInterval;
        internal System.Windows.Forms.CheckBox wPromptNoTimer;
        internal System.Windows.Forms.CheckBox wPromptHide;
    }
}