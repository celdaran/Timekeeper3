namespace Timekeeper.Forms
{
    partial class Options
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.OptionsPanelCollection = new System.Windows.Forms.TabControl();
            this.LayoutPage = new System.Windows.Forms.TabPage();
            this.PresetGroup = new System.Windows.Forms.GroupBox();
            this.Layout_Preset_Minimal = new System.Windows.Forms.RadioButton();
            this.PresetInstructionsLabel = new System.Windows.Forms.Label();
            this.Layout_Preset_TheWorks = new System.Windows.Forms.RadioButton();
            this.Layout_Preset_Simple = new System.Windows.Forms.RadioButton();
            this.Layout_Preset_Typical = new System.Windows.Forms.RadioButton();
            this.DimensionGroup = new System.Windows.Forms.GroupBox();
            this.DimensionsInstructionsLabel = new System.Windows.Forms.Label();
            this.Layout_UseCategories = new System.Windows.Forms.CheckBox();
            this.Layout_UseLocations = new System.Windows.Forms.CheckBox();
            this.Layout_UseActivities = new System.Windows.Forms.CheckBox();
            this.Layout_UseProjects = new System.Windows.Forms.CheckBox();
            this.ViewPage = new System.Windows.Forms.TabPage();
            this.MainViewGroup = new System.Windows.Forms.GroupBox();
            this.View_MemoEditor = new System.Windows.Forms.CheckBox();
            this.View_StatusBar = new System.Windows.Forms.CheckBox();
            this.View_ControlPanel = new System.Windows.Forms.CheckBox();
            this.View_BrowserToolbar = new System.Windows.Forms.CheckBox();
            this.ViewSpacerBox = new System.Windows.Forms.PictureBox();
            this.MemoEditorGroup = new System.Windows.Forms.GroupBox();
            this.View_MemoEditor_ShowRuler = new System.Windows.Forms.CheckBox();
            this.View_MemoEditor_Font = new System.Windows.Forms.TextBox();
            this.View_MemoEditor_FontButton = new System.Windows.Forms.Button();
            this.View_MemoEditor_ShowGutter = new System.Windows.Forms.CheckBox();
            this.View_MemoEditor_ShowToolbar = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup = new System.Windows.Forms.GroupBox();
            this.StatusBarGroup_BottomPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedAllToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_FileName = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_CategoryElapsedPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedCategoryToday = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_LocationElapsedPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedLocationToday = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ActivityElapsedPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedActivityToday = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ProjectElapsedPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedProjectToday = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ElapsedPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedSinceStart = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_CategoryNamePanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_CategoryName = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_LocationNamePanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_LocationName = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ActivityNamePanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ActivityName = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ProjectNamePanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ProjectName = new System.Windows.Forms.CheckBox();
            this.HiddenGroup = new System.Windows.Forms.GroupBox();
            this.HiddenGroup_EventPanel = new System.Windows.Forms.Panel();
            this.View_HiddenEvents = new System.Windows.Forms.CheckBox();
            this.View_HiddenEventsSince = new System.Windows.Forms.ComboBox();
            this.HiddenGroup_TodoPanel = new System.Windows.Forms.Panel();
            this.View_HiddenTodoItems = new System.Windows.Forms.CheckBox();
            this.View_HiddenTodoItemsSince = new System.Windows.Forms.ComboBox();
            this.HiddenGroup_CategoryPanel = new System.Windows.Forms.Panel();
            this.View_HiddenCategories = new System.Windows.Forms.CheckBox();
            this.View_HiddenCategoriesSince = new System.Windows.Forms.ComboBox();
            this.HiddenGroup_LocationPanel = new System.Windows.Forms.Panel();
            this.View_HiddenLocations = new System.Windows.Forms.CheckBox();
            this.View_HiddenLocationsSince = new System.Windows.Forms.ComboBox();
            this.HiddenGroup_ActivityPanel = new System.Windows.Forms.Panel();
            this.View_HiddenActivities = new System.Windows.Forms.CheckBox();
            this.View_HiddenActivitiesSince = new System.Windows.Forms.ComboBox();
            this.HiddenGroup_ProjectPanel = new System.Windows.Forms.Panel();
            this.View_HiddenProjects = new System.Windows.Forms.CheckBox();
            this.View_HiddenProjectsSince = new System.Windows.Forms.ComboBox();
            this.BehaviorPage = new System.Windows.Forms.TabPage();
            this.AnnoyGroup = new System.Windows.Forms.GroupBox();
            this.AnnoyGroup_CategoryFollowPanel = new System.Windows.Forms.Panel();
            this.Behavior_Annoy_CategoryFollowsProject = new System.Windows.Forms.CheckBox();
            this.AnnoyGroup_LocationFollowPanel = new System.Windows.Forms.Panel();
            this.Behavior_Annoy_LocationFollowsProject = new System.Windows.Forms.CheckBox();
            this.AnnoyGroup_ActivityFollowPanel = new System.Windows.Forms.Panel();
            this.Behavior_Annoy_ActivityFollowsProject = new System.Windows.Forms.CheckBox();
            this.AnnoyGroup_TopPanel = new System.Windows.Forms.Panel();
            this.Behavior_Annoy_PromptBeforeHiding = new System.Windows.Forms.CheckBox();
            this.Behavior_Annoy_UseNewDatabaseWizard = new System.Windows.Forms.CheckBox();
            this.Behavior_Annoy_NoRunningPrompt = new System.Windows.Forms.CheckBox();
            this.Behavior_Annoy_NoRunningPromptAmount = new System.Windows.Forms.NumericUpDown();
            this.MinutesLabel = new System.Windows.Forms.Label();
            this.BehaviorSpacingBox = new System.Windows.Forms.PictureBox();
            this.BrowsingGroup = new System.Windows.Forms.GroupBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.Behavior_BrowseNextBy = new System.Windows.Forms.ComboBox();
            this.Behavior_BrowsePrevBy = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.SortingGroup = new System.Windows.Forms.GroupBox();
            this.SortingGroup_BottomPanel = new System.Windows.Forms.Panel();
            this.Behavior_SortItemsBy = new System.Windows.Forms.ComboBox();
            this.Behavior_SortItemsByDirection = new System.Windows.Forms.ComboBox();
            this.SortItemsLabel = new System.Windows.Forms.Label();
            this.SortingGroup_ProjectPanel = new System.Windows.Forms.Panel();
            this.Behavior_SortProjectsThenByDirection = new System.Windows.Forms.ComboBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Behavior_SortProjectsThenBy = new System.Windows.Forms.ComboBox();
            this.Behavior_SortProjectsByDirection = new System.Windows.Forms.ComboBox();
            this.Behavior_SortProjectsBy = new System.Windows.Forms.ComboBox();
            this.SortProjectsLabel = new System.Windows.Forms.Label();
            this.WindowControlGroup = new System.Windows.Forms.GroupBox();
            this.Behavior_Window_MinimizeOnUse = new System.Windows.Forms.CheckBox();
            this.Behavior_Window_MinimizeToTray = new System.Windows.Forms.CheckBox();
            this.Behavior_Window_ShowInTray = new System.Windows.Forms.CheckBox();
            this.TitleBarGroup = new System.Windows.Forms.GroupBox();
            this.DisplayLabel = new System.Windows.Forms.Label();
            this.Behavior_TitleBar_Time = new System.Windows.Forms.ComboBox();
            this.Behavior_TitleBar_Template = new System.Windows.Forms.TextBox();
            this.TitleBarTemplateLabel = new System.Windows.Forms.Label();
            this.ReportPage = new System.Windows.Forms.TabPage();
            this.ReportGroup = new System.Windows.Forms.GroupBox();
            this.Report_LayoutFileChooser = new System.Windows.Forms.Button();
            this.Report_LayoutFile = new System.Windows.Forms.TextBox();
            this.Report_LayoutFileLabel = new System.Windows.Forms.Label();
            this.Report_StyleSheetFileChooser = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Report_Font = new System.Windows.Forms.TextBox();
            this.Report_FontButton = new System.Windows.Forms.Button();
            this.Report_StyleSheetFile = new System.Windows.Forms.TextBox();
            this.Report_StyleSheetFileLabel = new System.Windows.Forms.Label();
            this.KeyboardPage = new System.Windows.Forms.TabPage();
            this.ShortcutGroup = new System.Windows.Forms.GroupBox();
            this.AssignKey = new System.Windows.Forms.Button();
            this.AltKey = new System.Windows.Forms.CheckBox();
            this.RemoveKey = new System.Windows.Forms.Button();
            this.KeyCode = new System.Windows.Forms.ComboBox();
            this.ShiftKey = new System.Windows.Forms.CheckBox();
            this.ControlKey = new System.Windows.Forms.CheckBox();
            this.FunctionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SmallImages = new System.Windows.Forms.ImageList(this.components);
            this.AdvancedPage = new System.Windows.Forms.TabPage();
            this.AdvancedSpacerBox = new System.Windows.Forms.PictureBox();
            this.AdvancedFormattingGroup = new System.Windows.Forms.GroupBox();
            this.Advanced_DateTimeFormat = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.Advanced_BreakTemplate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Advanced_MarkupLanguage = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.OtherAdvancedGroup = new System.Windows.Forms.GroupBox();
            this.Advanced_Other_MidnightOffset = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Advanced_Other_DimensionWidth = new System.Windows.Forms.NumericUpDown();
            this.Advanced_Other_DimensionWidthLabel = new System.Windows.Forms.Label();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.Advanced_Other_EnableScheduler = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.Advanced_Other_SortExtProjectAsNumber = new System.Windows.Forms.CheckBox();
            this.LoggingGroup = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ViewLog = new System.Windows.Forms.Button();
            this.Advanced_Logging_Database = new System.Windows.Forms.ComboBox();
            this.LoggingDatabaseLabel = new System.Windows.Forms.Label();
            this.Advanced_Logging_Application = new System.Windows.Forms.ComboBox();
            this.LoggingApplicationLabel = new System.Windows.Forms.Label();
            this.MailSettingsPage = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Mail_FromAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Mail_FromDisplayAddress = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Mail_SmtpTimeout = new System.Windows.Forms.NumericUpDown();
            this.Mail_SmtpServerPassword = new System.Windows.Forms.TextBox();
            this.Mail_SmtpServerUsername = new System.Windows.Forms.TextBox();
            this.Mail_SmtpServerRequiresSSL = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Mail_SmtpPort = new System.Windows.Forms.TextBox();
            this.Mail_SmtpServer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FontDialog = new System.Windows.Forms.FontDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.Mail_Subject = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.OptionsPanelCollection.SuspendLayout();
            this.LayoutPage.SuspendLayout();
            this.PresetGroup.SuspendLayout();
            this.DimensionGroup.SuspendLayout();
            this.ViewPage.SuspendLayout();
            this.MainViewGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewSpacerBox)).BeginInit();
            this.MemoEditorGroup.SuspendLayout();
            this.StatusBarGroup.SuspendLayout();
            this.StatusBarGroup_BottomPanel.SuspendLayout();
            this.StatusBarGroup_CategoryElapsedPanel.SuspendLayout();
            this.StatusBarGroup_LocationElapsedPanel.SuspendLayout();
            this.StatusBarGroup_ActivityElapsedPanel.SuspendLayout();
            this.StatusBarGroup_ProjectElapsedPanel.SuspendLayout();
            this.StatusBarGroup_ElapsedPanel.SuspendLayout();
            this.StatusBarGroup_CategoryNamePanel.SuspendLayout();
            this.StatusBarGroup_LocationNamePanel.SuspendLayout();
            this.StatusBarGroup_ActivityNamePanel.SuspendLayout();
            this.StatusBarGroup_ProjectNamePanel.SuspendLayout();
            this.HiddenGroup.SuspendLayout();
            this.HiddenGroup_EventPanel.SuspendLayout();
            this.HiddenGroup_TodoPanel.SuspendLayout();
            this.HiddenGroup_CategoryPanel.SuspendLayout();
            this.HiddenGroup_LocationPanel.SuspendLayout();
            this.HiddenGroup_ActivityPanel.SuspendLayout();
            this.HiddenGroup_ProjectPanel.SuspendLayout();
            this.BehaviorPage.SuspendLayout();
            this.AnnoyGroup.SuspendLayout();
            this.AnnoyGroup_CategoryFollowPanel.SuspendLayout();
            this.AnnoyGroup_LocationFollowPanel.SuspendLayout();
            this.AnnoyGroup_ActivityFollowPanel.SuspendLayout();
            this.AnnoyGroup_TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Behavior_Annoy_NoRunningPromptAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BehaviorSpacingBox)).BeginInit();
            this.BrowsingGroup.SuspendLayout();
            this.SortingGroup.SuspendLayout();
            this.SortingGroup_BottomPanel.SuspendLayout();
            this.SortingGroup_ProjectPanel.SuspendLayout();
            this.WindowControlGroup.SuspendLayout();
            this.TitleBarGroup.SuspendLayout();
            this.ReportPage.SuspendLayout();
            this.ReportGroup.SuspendLayout();
            this.KeyboardPage.SuspendLayout();
            this.ShortcutGroup.SuspendLayout();
            this.AdvancedPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AdvancedSpacerBox)).BeginInit();
            this.AdvancedFormattingGroup.SuspendLayout();
            this.OtherAdvancedGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Advanced_Other_DimensionWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.LoggingGroup.SuspendLayout();
            this.MailSettingsPage.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mail_SmtpTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(432, 435);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 1;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(351, 435);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 0;
            this.AcceptDialogButton.Text = "Save";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // OptionsPanelCollection
            // 
            this.OptionsPanelCollection.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.OptionsPanelCollection.Controls.Add(this.LayoutPage);
            this.OptionsPanelCollection.Controls.Add(this.ViewPage);
            this.OptionsPanelCollection.Controls.Add(this.BehaviorPage);
            this.OptionsPanelCollection.Controls.Add(this.ReportPage);
            this.OptionsPanelCollection.Controls.Add(this.KeyboardPage);
            this.OptionsPanelCollection.Controls.Add(this.AdvancedPage);
            this.OptionsPanelCollection.Controls.Add(this.MailSettingsPage);
            this.OptionsPanelCollection.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.OptionsPanelCollection.ItemSize = new System.Drawing.Size(26, 94);
            this.OptionsPanelCollection.Location = new System.Drawing.Point(12, 9);
            this.OptionsPanelCollection.Multiline = true;
            this.OptionsPanelCollection.Name = "OptionsPanelCollection";
            this.OptionsPanelCollection.SelectedIndex = 0;
            this.OptionsPanelCollection.Size = new System.Drawing.Size(495, 420);
            this.OptionsPanelCollection.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.OptionsPanelCollection.TabIndex = 0;
            // 
            // LayoutPage
            // 
            this.LayoutPage.Controls.Add(this.PresetGroup);
            this.LayoutPage.Controls.Add(this.DimensionGroup);
            this.LayoutPage.Location = new System.Drawing.Point(98, 4);
            this.LayoutPage.Name = "LayoutPage";
            this.LayoutPage.Padding = new System.Windows.Forms.Padding(3);
            this.LayoutPage.Size = new System.Drawing.Size(393, 412);
            this.LayoutPage.TabIndex = 2;
            this.LayoutPage.Text = "Layout";
            this.LayoutPage.UseVisualStyleBackColor = true;
            // 
            // PresetGroup
            // 
            this.PresetGroup.Controls.Add(this.Layout_Preset_Minimal);
            this.PresetGroup.Controls.Add(this.PresetInstructionsLabel);
            this.PresetGroup.Controls.Add(this.Layout_Preset_TheWorks);
            this.PresetGroup.Controls.Add(this.Layout_Preset_Simple);
            this.PresetGroup.Controls.Add(this.Layout_Preset_Typical);
            this.PresetGroup.Location = new System.Drawing.Point(17, 16);
            this.PresetGroup.Name = "PresetGroup";
            this.PresetGroup.Size = new System.Drawing.Size(345, 150);
            this.PresetGroup.TabIndex = 0;
            this.PresetGroup.TabStop = false;
            this.PresetGroup.Text = "Interface Presets";
            // 
            // Layout_Preset_Minimal
            // 
            this.Layout_Preset_Minimal.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_Preset_Minimal.Location = new System.Drawing.Point(17, 24);
            this.Layout_Preset_Minimal.Name = "Layout_Preset_Minimal";
            this.Layout_Preset_Minimal.Size = new System.Drawing.Size(90, 23);
            this.Layout_Preset_Minimal.TabIndex = 1;
            this.Layout_Preset_Minimal.Text = "Minimal";
            this.Layout_Preset_Minimal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_Preset_Minimal.UseVisualStyleBackColor = true;
            this.Layout_Preset_Minimal.Click += new System.EventHandler(this.Layout_Preset_Minimal_Click);
            // 
            // PresetInstructionsLabel
            // 
            this.PresetInstructionsLabel.AutoSize = true;
            this.PresetInstructionsLabel.Location = new System.Drawing.Point(127, 29);
            this.PresetInstructionsLabel.MaximumSize = new System.Drawing.Size(210, 95);
            this.PresetInstructionsLabel.Name = "PresetInstructionsLabel";
            this.PresetInstructionsLabel.Size = new System.Drawing.Size(210, 78);
            this.PresetInstructionsLabel.TabIndex = 3;
            this.PresetInstructionsLabel.Text = resources.GetString("PresetInstructionsLabel.Text");
            // 
            // Layout_Preset_TheWorks
            // 
            this.Layout_Preset_TheWorks.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_Preset_TheWorks.Location = new System.Drawing.Point(17, 111);
            this.Layout_Preset_TheWorks.Name = "Layout_Preset_TheWorks";
            this.Layout_Preset_TheWorks.Size = new System.Drawing.Size(90, 23);
            this.Layout_Preset_TheWorks.TabIndex = 4;
            this.Layout_Preset_TheWorks.Text = "The Works";
            this.Layout_Preset_TheWorks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_Preset_TheWorks.UseVisualStyleBackColor = true;
            this.Layout_Preset_TheWorks.Click += new System.EventHandler(this.Layout_Preset_TheWorks_Click);
            // 
            // Layout_Preset_Simple
            // 
            this.Layout_Preset_Simple.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_Preset_Simple.Location = new System.Drawing.Point(17, 53);
            this.Layout_Preset_Simple.Name = "Layout_Preset_Simple";
            this.Layout_Preset_Simple.Size = new System.Drawing.Size(90, 23);
            this.Layout_Preset_Simple.TabIndex = 2;
            this.Layout_Preset_Simple.Text = "Simple";
            this.Layout_Preset_Simple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_Preset_Simple.UseVisualStyleBackColor = true;
            this.Layout_Preset_Simple.Click += new System.EventHandler(this.Layout_Preset_Simple_Click);
            // 
            // Layout_Preset_Typical
            // 
            this.Layout_Preset_Typical.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_Preset_Typical.Location = new System.Drawing.Point(17, 82);
            this.Layout_Preset_Typical.Name = "Layout_Preset_Typical";
            this.Layout_Preset_Typical.Size = new System.Drawing.Size(90, 23);
            this.Layout_Preset_Typical.TabIndex = 3;
            this.Layout_Preset_Typical.Text = "Typical";
            this.Layout_Preset_Typical.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_Preset_Typical.UseVisualStyleBackColor = true;
            this.Layout_Preset_Typical.Click += new System.EventHandler(this.Layout_Preset_Typical_Click);
            // 
            // DimensionGroup
            // 
            this.DimensionGroup.Controls.Add(this.DimensionsInstructionsLabel);
            this.DimensionGroup.Controls.Add(this.Layout_UseCategories);
            this.DimensionGroup.Controls.Add(this.Layout_UseLocations);
            this.DimensionGroup.Controls.Add(this.Layout_UseActivities);
            this.DimensionGroup.Controls.Add(this.Layout_UseProjects);
            this.DimensionGroup.Location = new System.Drawing.Point(17, 172);
            this.DimensionGroup.Name = "DimensionGroup";
            this.DimensionGroup.Size = new System.Drawing.Size(345, 151);
            this.DimensionGroup.TabIndex = 0;
            this.DimensionGroup.TabStop = false;
            this.DimensionGroup.Text = "Timetracking Dimensions";
            // 
            // DimensionsInstructionsLabel
            // 
            this.DimensionsInstructionsLabel.AutoSize = true;
            this.DimensionsInstructionsLabel.Location = new System.Drawing.Point(127, 33);
            this.DimensionsInstructionsLabel.Name = "DimensionsInstructionsLabel";
            this.DimensionsInstructionsLabel.Size = new System.Drawing.Size(203, 65);
            this.DimensionsInstructionsLabel.TabIndex = 4;
            this.DimensionsInstructionsLabel.Text = resources.GetString("DimensionsInstructionsLabel.Text");
            // 
            // Layout_UseCategories
            // 
            this.Layout_UseCategories.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_UseCategories.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Layout_UseCategories.Location = new System.Drawing.Point(17, 115);
            this.Layout_UseCategories.Name = "Layout_UseCategories";
            this.Layout_UseCategories.Size = new System.Drawing.Size(90, 23);
            this.Layout_UseCategories.TabIndex = 8;
            this.Layout_UseCategories.Text = "Use Categories";
            this.Layout_UseCategories.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_UseCategories.UseVisualStyleBackColor = true;
            this.Layout_UseCategories.CheckedChanged += new System.EventHandler(this.Layout_UseCategories_CheckedChanged);
            // 
            // Layout_UseLocations
            // 
            this.Layout_UseLocations.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_UseLocations.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Layout_UseLocations.Location = new System.Drawing.Point(17, 86);
            this.Layout_UseLocations.Name = "Layout_UseLocations";
            this.Layout_UseLocations.Size = new System.Drawing.Size(90, 23);
            this.Layout_UseLocations.TabIndex = 7;
            this.Layout_UseLocations.Text = "Use Locations";
            this.Layout_UseLocations.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_UseLocations.UseVisualStyleBackColor = true;
            this.Layout_UseLocations.CheckedChanged += new System.EventHandler(this.Layout_UseLocations_CheckedChanged);
            // 
            // Layout_UseActivities
            // 
            this.Layout_UseActivities.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_UseActivities.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Layout_UseActivities.Location = new System.Drawing.Point(17, 57);
            this.Layout_UseActivities.Name = "Layout_UseActivities";
            this.Layout_UseActivities.Size = new System.Drawing.Size(90, 23);
            this.Layout_UseActivities.TabIndex = 6;
            this.Layout_UseActivities.Text = "Use Activities";
            this.Layout_UseActivities.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_UseActivities.UseVisualStyleBackColor = true;
            this.Layout_UseActivities.CheckedChanged += new System.EventHandler(this.Layout_UseActivities_CheckedChanged);
            // 
            // Layout_UseProjects
            // 
            this.Layout_UseProjects.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_UseProjects.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Layout_UseProjects.Location = new System.Drawing.Point(17, 28);
            this.Layout_UseProjects.Name = "Layout_UseProjects";
            this.Layout_UseProjects.Size = new System.Drawing.Size(90, 23);
            this.Layout_UseProjects.TabIndex = 5;
            this.Layout_UseProjects.Text = "Use Projects";
            this.Layout_UseProjects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_UseProjects.UseVisualStyleBackColor = true;
            this.Layout_UseProjects.CheckedChanged += new System.EventHandler(this.Layout_UseProjects_CheckedChanged);
            // 
            // ViewPage
            // 
            this.ViewPage.AutoScroll = true;
            this.ViewPage.Controls.Add(this.MainViewGroup);
            this.ViewPage.Controls.Add(this.ViewSpacerBox);
            this.ViewPage.Controls.Add(this.MemoEditorGroup);
            this.ViewPage.Controls.Add(this.StatusBarGroup);
            this.ViewPage.Controls.Add(this.HiddenGroup);
            this.ViewPage.Location = new System.Drawing.Point(98, 4);
            this.ViewPage.Name = "ViewPage";
            this.ViewPage.Padding = new System.Windows.Forms.Padding(3);
            this.ViewPage.Size = new System.Drawing.Size(393, 412);
            this.ViewPage.TabIndex = 0;
            this.ViewPage.Text = "View";
            this.ViewPage.UseVisualStyleBackColor = true;
            // 
            // MainViewGroup
            // 
            this.MainViewGroup.Controls.Add(this.View_MemoEditor);
            this.MainViewGroup.Controls.Add(this.View_StatusBar);
            this.MainViewGroup.Controls.Add(this.View_ControlPanel);
            this.MainViewGroup.Controls.Add(this.View_BrowserToolbar);
            this.MainViewGroup.Location = new System.Drawing.Point(17, 16);
            this.MainViewGroup.Name = "MainViewGroup";
            this.MainViewGroup.Size = new System.Drawing.Size(345, 67);
            this.MainViewGroup.TabIndex = 23;
            this.MainViewGroup.TabStop = false;
            this.MainViewGroup.Text = "Main Window";
            // 
            // View_MemoEditor
            // 
            this.View_MemoEditor.AutoSize = true;
            this.View_MemoEditor.Checked = true;
            this.View_MemoEditor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.View_MemoEditor.Location = new System.Drawing.Point(17, 42);
            this.View_MemoEditor.Name = "View_MemoEditor";
            this.View_MemoEditor.Size = new System.Drawing.Size(115, 17);
            this.View_MemoEditor.TabIndex = 2;
            this.View_MemoEditor.Text = "Show Memo Editor";
            this.View_MemoEditor.UseVisualStyleBackColor = true;
            this.View_MemoEditor.CheckedChanged += new System.EventHandler(this.View_MemoEditor_CheckedChanged);
            // 
            // View_StatusBar
            // 
            this.View_StatusBar.AutoSize = true;
            this.View_StatusBar.Checked = true;
            this.View_StatusBar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.View_StatusBar.Location = new System.Drawing.Point(186, 42);
            this.View_StatusBar.Name = "View_StatusBar";
            this.View_StatusBar.Size = new System.Drawing.Size(105, 17);
            this.View_StatusBar.TabIndex = 4;
            this.View_StatusBar.Text = "Show Status Bar";
            this.View_StatusBar.UseVisualStyleBackColor = true;
            this.View_StatusBar.CheckedChanged += new System.EventHandler(this.View_StatusBar_CheckedChanged);
            // 
            // View_ControlPanel
            // 
            this.View_ControlPanel.AutoSize = true;
            this.View_ControlPanel.Checked = true;
            this.View_ControlPanel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.View_ControlPanel.Location = new System.Drawing.Point(186, 19);
            this.View_ControlPanel.Name = "View_ControlPanel";
            this.View_ControlPanel.Size = new System.Drawing.Size(145, 17);
            this.View_ControlPanel.TabIndex = 3;
            this.View_ControlPanel.Text = "Show Entry Details Panel";
            this.View_ControlPanel.UseVisualStyleBackColor = true;
            // 
            // View_BrowserToolbar
            // 
            this.View_BrowserToolbar.AutoSize = true;
            this.View_BrowserToolbar.Checked = true;
            this.View_BrowserToolbar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.View_BrowserToolbar.Location = new System.Drawing.Point(17, 19);
            this.View_BrowserToolbar.Name = "View_BrowserToolbar";
            this.View_BrowserToolbar.Size = new System.Drawing.Size(133, 17);
            this.View_BrowserToolbar.TabIndex = 1;
            this.View_BrowserToolbar.Text = "Show Browser Toolbar";
            this.View_BrowserToolbar.UseVisualStyleBackColor = true;
            // 
            // ViewSpacerBox
            // 
            this.ViewSpacerBox.Image = global::Timekeeper.Properties.Resources.ImageIconBlank;
            this.ViewSpacerBox.Location = new System.Drawing.Point(17, 693);
            this.ViewSpacerBox.Name = "ViewSpacerBox";
            this.ViewSpacerBox.Size = new System.Drawing.Size(16, 16);
            this.ViewSpacerBox.TabIndex = 22;
            this.ViewSpacerBox.TabStop = false;
            // 
            // MemoEditorGroup
            // 
            this.MemoEditorGroup.Controls.Add(this.View_MemoEditor_ShowRuler);
            this.MemoEditorGroup.Controls.Add(this.View_MemoEditor_Font);
            this.MemoEditorGroup.Controls.Add(this.View_MemoEditor_FontButton);
            this.MemoEditorGroup.Controls.Add(this.View_MemoEditor_ShowGutter);
            this.MemoEditorGroup.Controls.Add(this.View_MemoEditor_ShowToolbar);
            this.MemoEditorGroup.Location = new System.Drawing.Point(17, 89);
            this.MemoEditorGroup.Name = "MemoEditorGroup";
            this.MemoEditorGroup.Size = new System.Drawing.Size(345, 128);
            this.MemoEditorGroup.TabIndex = 21;
            this.MemoEditorGroup.TabStop = false;
            this.MemoEditorGroup.Text = "Memo Editor";
            // 
            // View_MemoEditor_ShowRuler
            // 
            this.View_MemoEditor_ShowRuler.AutoSize = true;
            this.View_MemoEditor_ShowRuler.Location = new System.Drawing.Point(17, 42);
            this.View_MemoEditor_ShowRuler.Name = "View_MemoEditor_ShowRuler";
            this.View_MemoEditor_ShowRuler.Size = new System.Drawing.Size(76, 17);
            this.View_MemoEditor_ShowRuler.TabIndex = 6;
            this.View_MemoEditor_ShowRuler.Text = "Show ruler";
            this.View_MemoEditor_ShowRuler.UseVisualStyleBackColor = true;
            this.View_MemoEditor_ShowRuler.CheckedChanged += new System.EventHandler(this.View_MemoEditor_ShowRuler_CheckedChanged);
            // 
            // View_MemoEditor_Font
            // 
            this.View_MemoEditor_Font.Location = new System.Drawing.Point(109, 92);
            this.View_MemoEditor_Font.Name = "View_MemoEditor_Font";
            this.View_MemoEditor_Font.ReadOnly = true;
            this.View_MemoEditor_Font.Size = new System.Drawing.Size(220, 20);
            this.View_MemoEditor_Font.TabIndex = 5;
            // 
            // View_MemoEditor_FontButton
            // 
            this.View_MemoEditor_FontButton.Location = new System.Drawing.Point(17, 90);
            this.View_MemoEditor_FontButton.Name = "View_MemoEditor_FontButton";
            this.View_MemoEditor_FontButton.Size = new System.Drawing.Size(86, 23);
            this.View_MemoEditor_FontButton.TabIndex = 4;
            this.View_MemoEditor_FontButton.Text = "Choose Font...";
            this.View_MemoEditor_FontButton.UseVisualStyleBackColor = true;
            this.View_MemoEditor_FontButton.Click += new System.EventHandler(this.View_MemoEditor_FontButton_Click);
            // 
            // View_MemoEditor_ShowGutter
            // 
            this.View_MemoEditor_ShowGutter.AutoSize = true;
            this.View_MemoEditor_ShowGutter.Location = new System.Drawing.Point(17, 65);
            this.View_MemoEditor_ShowGutter.Name = "View_MemoEditor_ShowGutter";
            this.View_MemoEditor_ShowGutter.Size = new System.Drawing.Size(100, 17);
            this.View_MemoEditor_ShowGutter.TabIndex = 2;
            this.View_MemoEditor_ShowGutter.Text = "Show left gutter";
            this.View_MemoEditor_ShowGutter.UseVisualStyleBackColor = true;
            // 
            // View_MemoEditor_ShowToolbar
            // 
            this.View_MemoEditor_ShowToolbar.AutoSize = true;
            this.View_MemoEditor_ShowToolbar.Location = new System.Drawing.Point(17, 19);
            this.View_MemoEditor_ShowToolbar.Name = "View_MemoEditor_ShowToolbar";
            this.View_MemoEditor_ShowToolbar.Size = new System.Drawing.Size(137, 17);
            this.View_MemoEditor_ShowToolbar.TabIndex = 1;
            this.View_MemoEditor_ShowToolbar.Text = "Show formatting toolbar";
            this.View_MemoEditor_ShowToolbar.UseVisualStyleBackColor = true;
            this.View_MemoEditor_ShowToolbar.CheckedChanged += new System.EventHandler(this.View_MemoEditor_ShowToolbar_CheckedChanged);
            // 
            // StatusBarGroup
            // 
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_BottomPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_CategoryElapsedPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_LocationElapsedPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ActivityElapsedPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ProjectElapsedPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ElapsedPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_CategoryNamePanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_LocationNamePanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ActivityNamePanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ProjectNamePanel);
            this.StatusBarGroup.Location = new System.Drawing.Point(17, 223);
            this.StatusBarGroup.Name = "StatusBarGroup";
            this.StatusBarGroup.Size = new System.Drawing.Size(345, 275);
            this.StatusBarGroup.TabIndex = 20;
            this.StatusBarGroup.TabStop = false;
            this.StatusBarGroup.Text = "Status Bar";
            // 
            // StatusBarGroup_BottomPanel
            // 
            this.StatusBarGroup_BottomPanel.Controls.Add(this.View_StatusBar_ElapsedAllToday);
            this.StatusBarGroup_BottomPanel.Controls.Add(this.View_StatusBar_FileName);
            this.StatusBarGroup_BottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_BottomPanel.Location = new System.Drawing.Point(3, 223);
            this.StatusBarGroup_BottomPanel.Name = "StatusBarGroup_BottomPanel";
            this.StatusBarGroup_BottomPanel.Size = new System.Drawing.Size(339, 46);
            this.StatusBarGroup_BottomPanel.TabIndex = 6;
            // 
            // View_StatusBar_ElapsedAllToday
            // 
            this.View_StatusBar_ElapsedAllToday.AutoSize = true;
            this.View_StatusBar_ElapsedAllToday.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_ElapsedAllToday.Name = "View_StatusBar_ElapsedAllToday";
            this.View_StatusBar_ElapsedAllToday.Size = new System.Drawing.Size(141, 17);
            this.View_StatusBar_ElapsedAllToday.TabIndex = 6;
            this.View_StatusBar_ElapsedAllToday.Text = "Total elapsed time today";
            this.View_StatusBar_ElapsedAllToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_FileName
            // 
            this.View_StatusBar_FileName.AutoSize = true;
            this.View_StatusBar_FileName.Location = new System.Drawing.Point(14, 27);
            this.View_StatusBar_FileName.Name = "View_StatusBar_FileName";
            this.View_StatusBar_FileName.Size = new System.Drawing.Size(115, 17);
            this.View_StatusBar_FileName.TabIndex = 10;
            this.View_StatusBar_FileName.Text = "Current opened file";
            this.View_StatusBar_FileName.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_CategoryElapsedPanel
            // 
            this.StatusBarGroup_CategoryElapsedPanel.Controls.Add(this.View_StatusBar_ElapsedCategoryToday);
            this.StatusBarGroup_CategoryElapsedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_CategoryElapsedPanel.Location = new System.Drawing.Point(3, 200);
            this.StatusBarGroup_CategoryElapsedPanel.Name = "StatusBarGroup_CategoryElapsedPanel";
            this.StatusBarGroup_CategoryElapsedPanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_CategoryElapsedPanel.TabIndex = 7;
            // 
            // View_StatusBar_ElapsedCategoryToday
            // 
            this.View_StatusBar_ElapsedCategoryToday.AutoSize = true;
            this.View_StatusBar_ElapsedCategoryToday.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_ElapsedCategoryToday.Name = "View_StatusBar_ElapsedCategoryToday";
            this.View_StatusBar_ElapsedCategoryToday.Size = new System.Drawing.Size(211, 17);
            this.View_StatusBar_ElapsedCategoryToday.TabIndex = 5;
            this.View_StatusBar_ElapsedCategoryToday.Text = "Elapsed time today for current Category";
            this.View_StatusBar_ElapsedCategoryToday.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_LocationElapsedPanel
            // 
            this.StatusBarGroup_LocationElapsedPanel.Controls.Add(this.View_StatusBar_ElapsedLocationToday);
            this.StatusBarGroup_LocationElapsedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_LocationElapsedPanel.Location = new System.Drawing.Point(3, 177);
            this.StatusBarGroup_LocationElapsedPanel.Name = "StatusBarGroup_LocationElapsedPanel";
            this.StatusBarGroup_LocationElapsedPanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_LocationElapsedPanel.TabIndex = 6;
            // 
            // View_StatusBar_ElapsedLocationToday
            // 
            this.View_StatusBar_ElapsedLocationToday.AutoSize = true;
            this.View_StatusBar_ElapsedLocationToday.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_ElapsedLocationToday.Name = "View_StatusBar_ElapsedLocationToday";
            this.View_StatusBar_ElapsedLocationToday.Size = new System.Drawing.Size(210, 17);
            this.View_StatusBar_ElapsedLocationToday.TabIndex = 5;
            this.View_StatusBar_ElapsedLocationToday.Text = "Elapsed time today for current Location";
            this.View_StatusBar_ElapsedLocationToday.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ActivityElapsedPanel
            // 
            this.StatusBarGroup_ActivityElapsedPanel.Controls.Add(this.View_StatusBar_ElapsedActivityToday);
            this.StatusBarGroup_ActivityElapsedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ActivityElapsedPanel.Location = new System.Drawing.Point(3, 154);
            this.StatusBarGroup_ActivityElapsedPanel.Name = "StatusBarGroup_ActivityElapsedPanel";
            this.StatusBarGroup_ActivityElapsedPanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_ActivityElapsedPanel.TabIndex = 5;
            // 
            // View_StatusBar_ElapsedActivityToday
            // 
            this.View_StatusBar_ElapsedActivityToday.AutoSize = true;
            this.View_StatusBar_ElapsedActivityToday.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_ElapsedActivityToday.Name = "View_StatusBar_ElapsedActivityToday";
            this.View_StatusBar_ElapsedActivityToday.Size = new System.Drawing.Size(203, 17);
            this.View_StatusBar_ElapsedActivityToday.TabIndex = 5;
            this.View_StatusBar_ElapsedActivityToday.Text = "Elapsed time today for current Activity";
            this.View_StatusBar_ElapsedActivityToday.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ProjectElapsedPanel
            // 
            this.StatusBarGroup_ProjectElapsedPanel.Controls.Add(this.View_StatusBar_ElapsedProjectToday);
            this.StatusBarGroup_ProjectElapsedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ProjectElapsedPanel.Location = new System.Drawing.Point(3, 131);
            this.StatusBarGroup_ProjectElapsedPanel.Name = "StatusBarGroup_ProjectElapsedPanel";
            this.StatusBarGroup_ProjectElapsedPanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_ProjectElapsedPanel.TabIndex = 4;
            // 
            // View_StatusBar_ElapsedProjectToday
            // 
            this.View_StatusBar_ElapsedProjectToday.AutoSize = true;
            this.View_StatusBar_ElapsedProjectToday.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_ElapsedProjectToday.Name = "View_StatusBar_ElapsedProjectToday";
            this.View_StatusBar_ElapsedProjectToday.Size = new System.Drawing.Size(202, 17);
            this.View_StatusBar_ElapsedProjectToday.TabIndex = 4;
            this.View_StatusBar_ElapsedProjectToday.Text = "Elapsed time today for current Project";
            this.View_StatusBar_ElapsedProjectToday.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ElapsedPanel
            // 
            this.StatusBarGroup_ElapsedPanel.Controls.Add(this.View_StatusBar_ElapsedSinceStart);
            this.StatusBarGroup_ElapsedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ElapsedPanel.Location = new System.Drawing.Point(3, 108);
            this.StatusBarGroup_ElapsedPanel.Name = "StatusBarGroup_ElapsedPanel";
            this.StatusBarGroup_ElapsedPanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_ElapsedPanel.TabIndex = 3;
            // 
            // View_StatusBar_ElapsedSinceStart
            // 
            this.View_StatusBar_ElapsedSinceStart.AutoSize = true;
            this.View_StatusBar_ElapsedSinceStart.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_ElapsedSinceStart.Name = "View_StatusBar_ElapsedSinceStart";
            this.View_StatusBar_ElapsedSinceStart.Size = new System.Drawing.Size(174, 17);
            this.View_StatusBar_ElapsedSinceStart.TabIndex = 3;
            this.View_StatusBar_ElapsedSinceStart.Text = "Elapsed time since timer started";
            this.View_StatusBar_ElapsedSinceStart.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_CategoryNamePanel
            // 
            this.StatusBarGroup_CategoryNamePanel.Controls.Add(this.View_StatusBar_CategoryName);
            this.StatusBarGroup_CategoryNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_CategoryNamePanel.Location = new System.Drawing.Point(3, 85);
            this.StatusBarGroup_CategoryNamePanel.Name = "StatusBarGroup_CategoryNamePanel";
            this.StatusBarGroup_CategoryNamePanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_CategoryNamePanel.TabIndex = 3;
            // 
            // View_StatusBar_CategoryName
            // 
            this.View_StatusBar_CategoryName.AutoSize = true;
            this.View_StatusBar_CategoryName.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_CategoryName.Name = "View_StatusBar_CategoryName";
            this.View_StatusBar_CategoryName.Size = new System.Drawing.Size(147, 17);
            this.View_StatusBar_CategoryName.TabIndex = 1;
            this.View_StatusBar_CategoryName.Text = "Name of current Category";
            this.View_StatusBar_CategoryName.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_LocationNamePanel
            // 
            this.StatusBarGroup_LocationNamePanel.Controls.Add(this.View_StatusBar_LocationName);
            this.StatusBarGroup_LocationNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_LocationNamePanel.Location = new System.Drawing.Point(3, 62);
            this.StatusBarGroup_LocationNamePanel.Name = "StatusBarGroup_LocationNamePanel";
            this.StatusBarGroup_LocationNamePanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_LocationNamePanel.TabIndex = 2;
            // 
            // View_StatusBar_LocationName
            // 
            this.View_StatusBar_LocationName.AutoSize = true;
            this.View_StatusBar_LocationName.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_LocationName.Name = "View_StatusBar_LocationName";
            this.View_StatusBar_LocationName.Size = new System.Drawing.Size(146, 17);
            this.View_StatusBar_LocationName.TabIndex = 1;
            this.View_StatusBar_LocationName.Text = "Name of current Location";
            this.View_StatusBar_LocationName.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ActivityNamePanel
            // 
            this.StatusBarGroup_ActivityNamePanel.Controls.Add(this.View_StatusBar_ActivityName);
            this.StatusBarGroup_ActivityNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ActivityNamePanel.Location = new System.Drawing.Point(3, 39);
            this.StatusBarGroup_ActivityNamePanel.Name = "StatusBarGroup_ActivityNamePanel";
            this.StatusBarGroup_ActivityNamePanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_ActivityNamePanel.TabIndex = 2;
            // 
            // View_StatusBar_ActivityName
            // 
            this.View_StatusBar_ActivityName.AutoSize = true;
            this.View_StatusBar_ActivityName.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_ActivityName.Name = "View_StatusBar_ActivityName";
            this.View_StatusBar_ActivityName.Size = new System.Drawing.Size(139, 17);
            this.View_StatusBar_ActivityName.TabIndex = 2;
            this.View_StatusBar_ActivityName.Text = "Name of current Activity";
            this.View_StatusBar_ActivityName.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ProjectNamePanel
            // 
            this.StatusBarGroup_ProjectNamePanel.Controls.Add(this.View_StatusBar_ProjectName);
            this.StatusBarGroup_ProjectNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ProjectNamePanel.Location = new System.Drawing.Point(3, 16);
            this.StatusBarGroup_ProjectNamePanel.Name = "StatusBarGroup_ProjectNamePanel";
            this.StatusBarGroup_ProjectNamePanel.Size = new System.Drawing.Size(339, 23);
            this.StatusBarGroup_ProjectNamePanel.TabIndex = 1;
            // 
            // View_StatusBar_ProjectName
            // 
            this.View_StatusBar_ProjectName.AutoSize = true;
            this.View_StatusBar_ProjectName.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar_ProjectName.Name = "View_StatusBar_ProjectName";
            this.View_StatusBar_ProjectName.Size = new System.Drawing.Size(138, 17);
            this.View_StatusBar_ProjectName.TabIndex = 1;
            this.View_StatusBar_ProjectName.Text = "Name of current Project";
            this.View_StatusBar_ProjectName.UseVisualStyleBackColor = true;
            // 
            // HiddenGroup
            // 
            this.HiddenGroup.Controls.Add(this.HiddenGroup_EventPanel);
            this.HiddenGroup.Controls.Add(this.HiddenGroup_TodoPanel);
            this.HiddenGroup.Controls.Add(this.HiddenGroup_CategoryPanel);
            this.HiddenGroup.Controls.Add(this.HiddenGroup_LocationPanel);
            this.HiddenGroup.Controls.Add(this.HiddenGroup_ActivityPanel);
            this.HiddenGroup.Controls.Add(this.HiddenGroup_ProjectPanel);
            this.HiddenGroup.Location = new System.Drawing.Point(17, 504);
            this.HiddenGroup.Name = "HiddenGroup";
            this.HiddenGroup.Size = new System.Drawing.Size(345, 183);
            this.HiddenGroup.TabIndex = 19;
            this.HiddenGroup.TabStop = false;
            this.HiddenGroup.Text = "Hidden Items";
            // 
            // HiddenGroup_EventPanel
            // 
            this.HiddenGroup_EventPanel.Controls.Add(this.View_HiddenEvents);
            this.HiddenGroup_EventPanel.Controls.Add(this.View_HiddenEventsSince);
            this.HiddenGroup_EventPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroup_EventPanel.Location = new System.Drawing.Point(3, 151);
            this.HiddenGroup_EventPanel.Name = "HiddenGroup_EventPanel";
            this.HiddenGroup_EventPanel.Size = new System.Drawing.Size(339, 27);
            this.HiddenGroup_EventPanel.TabIndex = 24;
            // 
            // View_HiddenEvents
            // 
            this.View_HiddenEvents.AutoSize = true;
            this.View_HiddenEvents.Location = new System.Drawing.Point(14, 4);
            this.View_HiddenEvents.Name = "View_HiddenEvents";
            this.View_HiddenEvents.Size = new System.Drawing.Size(152, 17);
            this.View_HiddenEvents.TabIndex = 14;
            this.View_HiddenEvents.Text = "Show hidden Events since";
            this.View_HiddenEvents.UseVisualStyleBackColor = true;
            this.View_HiddenEvents.CheckedChanged += new System.EventHandler(this.View_HiddenEvents_CheckedChanged);
            // 
            // View_HiddenEventsSince
            // 
            this.View_HiddenEventsSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenEventsSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenEventsSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenEventsSince.Enabled = false;
            this.View_HiddenEventsSince.FormattingEnabled = true;
            this.View_HiddenEventsSince.Location = new System.Drawing.Point(205, 2);
            this.View_HiddenEventsSince.Name = "View_HiddenEventsSince";
            this.View_HiddenEventsSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenEventsSince.TabIndex = 18;
            // 
            // HiddenGroup_TodoPanel
            // 
            this.HiddenGroup_TodoPanel.Controls.Add(this.View_HiddenTodoItems);
            this.HiddenGroup_TodoPanel.Controls.Add(this.View_HiddenTodoItemsSince);
            this.HiddenGroup_TodoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroup_TodoPanel.Location = new System.Drawing.Point(3, 124);
            this.HiddenGroup_TodoPanel.Name = "HiddenGroup_TodoPanel";
            this.HiddenGroup_TodoPanel.Size = new System.Drawing.Size(339, 27);
            this.HiddenGroup_TodoPanel.TabIndex = 23;
            // 
            // View_HiddenTodoItems
            // 
            this.View_HiddenTodoItems.AutoSize = true;
            this.View_HiddenTodoItems.Location = new System.Drawing.Point(14, 4);
            this.View_HiddenTodoItems.Name = "View_HiddenTodoItems";
            this.View_HiddenTodoItems.Size = new System.Drawing.Size(171, 17);
            this.View_HiddenTodoItems.TabIndex = 14;
            this.View_HiddenTodoItems.Text = "Show hidden Todo items since";
            this.View_HiddenTodoItems.UseVisualStyleBackColor = true;
            this.View_HiddenTodoItems.CheckedChanged += new System.EventHandler(this.View_HiddenTodoItems_CheckedChanged);
            // 
            // View_HiddenTodoItemsSince
            // 
            this.View_HiddenTodoItemsSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenTodoItemsSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenTodoItemsSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenTodoItemsSince.Enabled = false;
            this.View_HiddenTodoItemsSince.FormattingEnabled = true;
            this.View_HiddenTodoItemsSince.Location = new System.Drawing.Point(205, 2);
            this.View_HiddenTodoItemsSince.Name = "View_HiddenTodoItemsSince";
            this.View_HiddenTodoItemsSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenTodoItemsSince.TabIndex = 18;
            // 
            // HiddenGroup_CategoryPanel
            // 
            this.HiddenGroup_CategoryPanel.Controls.Add(this.View_HiddenCategories);
            this.HiddenGroup_CategoryPanel.Controls.Add(this.View_HiddenCategoriesSince);
            this.HiddenGroup_CategoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroup_CategoryPanel.Location = new System.Drawing.Point(3, 97);
            this.HiddenGroup_CategoryPanel.Name = "HiddenGroup_CategoryPanel";
            this.HiddenGroup_CategoryPanel.Size = new System.Drawing.Size(339, 27);
            this.HiddenGroup_CategoryPanel.TabIndex = 22;
            // 
            // View_HiddenCategories
            // 
            this.View_HiddenCategories.AutoSize = true;
            this.View_HiddenCategories.Location = new System.Drawing.Point(14, 4);
            this.View_HiddenCategories.Name = "View_HiddenCategories";
            this.View_HiddenCategories.Size = new System.Drawing.Size(169, 17);
            this.View_HiddenCategories.TabIndex = 14;
            this.View_HiddenCategories.Text = "Show hidden Categories since";
            this.View_HiddenCategories.UseVisualStyleBackColor = true;
            this.View_HiddenCategories.CheckedChanged += new System.EventHandler(this.View_HiddenCategories_CheckedChanged);
            // 
            // View_HiddenCategoriesSince
            // 
            this.View_HiddenCategoriesSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenCategoriesSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenCategoriesSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenCategoriesSince.Enabled = false;
            this.View_HiddenCategoriesSince.FormattingEnabled = true;
            this.View_HiddenCategoriesSince.Location = new System.Drawing.Point(205, 2);
            this.View_HiddenCategoriesSince.Name = "View_HiddenCategoriesSince";
            this.View_HiddenCategoriesSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenCategoriesSince.TabIndex = 18;
            // 
            // HiddenGroup_LocationPanel
            // 
            this.HiddenGroup_LocationPanel.Controls.Add(this.View_HiddenLocations);
            this.HiddenGroup_LocationPanel.Controls.Add(this.View_HiddenLocationsSince);
            this.HiddenGroup_LocationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroup_LocationPanel.Location = new System.Drawing.Point(3, 70);
            this.HiddenGroup_LocationPanel.Name = "HiddenGroup_LocationPanel";
            this.HiddenGroup_LocationPanel.Size = new System.Drawing.Size(339, 27);
            this.HiddenGroup_LocationPanel.TabIndex = 21;
            // 
            // View_HiddenLocations
            // 
            this.View_HiddenLocations.AutoSize = true;
            this.View_HiddenLocations.Location = new System.Drawing.Point(14, 4);
            this.View_HiddenLocations.Name = "View_HiddenLocations";
            this.View_HiddenLocations.Size = new System.Drawing.Size(165, 17);
            this.View_HiddenLocations.TabIndex = 13;
            this.View_HiddenLocations.Text = "Show hidden Locations since";
            this.View_HiddenLocations.UseVisualStyleBackColor = true;
            this.View_HiddenLocations.CheckedChanged += new System.EventHandler(this.View_HiddenLocations_CheckedChanged);
            // 
            // View_HiddenLocationsSince
            // 
            this.View_HiddenLocationsSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenLocationsSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenLocationsSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenLocationsSince.Enabled = false;
            this.View_HiddenLocationsSince.FormattingEnabled = true;
            this.View_HiddenLocationsSince.Location = new System.Drawing.Point(205, 2);
            this.View_HiddenLocationsSince.Name = "View_HiddenLocationsSince";
            this.View_HiddenLocationsSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenLocationsSince.TabIndex = 17;
            // 
            // HiddenGroup_ActivityPanel
            // 
            this.HiddenGroup_ActivityPanel.Controls.Add(this.View_HiddenActivities);
            this.HiddenGroup_ActivityPanel.Controls.Add(this.View_HiddenActivitiesSince);
            this.HiddenGroup_ActivityPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroup_ActivityPanel.Location = new System.Drawing.Point(3, 43);
            this.HiddenGroup_ActivityPanel.Name = "HiddenGroup_ActivityPanel";
            this.HiddenGroup_ActivityPanel.Size = new System.Drawing.Size(339, 27);
            this.HiddenGroup_ActivityPanel.TabIndex = 20;
            // 
            // View_HiddenActivities
            // 
            this.View_HiddenActivities.AutoSize = true;
            this.View_HiddenActivities.Location = new System.Drawing.Point(14, 4);
            this.View_HiddenActivities.Name = "View_HiddenActivities";
            this.View_HiddenActivities.Size = new System.Drawing.Size(161, 17);
            this.View_HiddenActivities.TabIndex = 12;
            this.View_HiddenActivities.Text = "Show hidden Activities since";
            this.View_HiddenActivities.UseVisualStyleBackColor = true;
            this.View_HiddenActivities.CheckedChanged += new System.EventHandler(this.View_HiddenActivities_CheckedChanged);
            // 
            // View_HiddenActivitiesSince
            // 
            this.View_HiddenActivitiesSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenActivitiesSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenActivitiesSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenActivitiesSince.Enabled = false;
            this.View_HiddenActivitiesSince.FormattingEnabled = true;
            this.View_HiddenActivitiesSince.Location = new System.Drawing.Point(205, 2);
            this.View_HiddenActivitiesSince.Name = "View_HiddenActivitiesSince";
            this.View_HiddenActivitiesSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenActivitiesSince.TabIndex = 16;
            // 
            // HiddenGroup_ProjectPanel
            // 
            this.HiddenGroup_ProjectPanel.Controls.Add(this.View_HiddenProjects);
            this.HiddenGroup_ProjectPanel.Controls.Add(this.View_HiddenProjectsSince);
            this.HiddenGroup_ProjectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroup_ProjectPanel.Location = new System.Drawing.Point(3, 16);
            this.HiddenGroup_ProjectPanel.Name = "HiddenGroup_ProjectPanel";
            this.HiddenGroup_ProjectPanel.Size = new System.Drawing.Size(339, 27);
            this.HiddenGroup_ProjectPanel.TabIndex = 19;
            // 
            // View_HiddenProjects
            // 
            this.View_HiddenProjects.AutoSize = true;
            this.View_HiddenProjects.Location = new System.Drawing.Point(14, 4);
            this.View_HiddenProjects.Name = "View_HiddenProjects";
            this.View_HiddenProjects.Size = new System.Drawing.Size(157, 17);
            this.View_HiddenProjects.TabIndex = 11;
            this.View_HiddenProjects.Text = "Show hidden Projects since";
            this.View_HiddenProjects.UseVisualStyleBackColor = true;
            this.View_HiddenProjects.CheckedChanged += new System.EventHandler(this.View_HiddenProjects_CheckedChanged);
            // 
            // View_HiddenProjectsSince
            // 
            this.View_HiddenProjectsSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenProjectsSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenProjectsSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenProjectsSince.Enabled = false;
            this.View_HiddenProjectsSince.FormattingEnabled = true;
            this.View_HiddenProjectsSince.Location = new System.Drawing.Point(205, 2);
            this.View_HiddenProjectsSince.Name = "View_HiddenProjectsSince";
            this.View_HiddenProjectsSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenProjectsSince.TabIndex = 15;
            // 
            // BehaviorPage
            // 
            this.BehaviorPage.AutoScroll = true;
            this.BehaviorPage.Controls.Add(this.AnnoyGroup);
            this.BehaviorPage.Controls.Add(this.BehaviorSpacingBox);
            this.BehaviorPage.Controls.Add(this.BrowsingGroup);
            this.BehaviorPage.Controls.Add(this.SortingGroup);
            this.BehaviorPage.Controls.Add(this.WindowControlGroup);
            this.BehaviorPage.Controls.Add(this.TitleBarGroup);
            this.BehaviorPage.Location = new System.Drawing.Point(98, 4);
            this.BehaviorPage.Name = "BehaviorPage";
            this.BehaviorPage.Padding = new System.Windows.Forms.Padding(3);
            this.BehaviorPage.Size = new System.Drawing.Size(393, 412);
            this.BehaviorPage.TabIndex = 3;
            this.BehaviorPage.Text = "Behavior";
            this.BehaviorPage.UseVisualStyleBackColor = true;
            // 
            // AnnoyGroup
            // 
            this.AnnoyGroup.Controls.Add(this.AnnoyGroup_CategoryFollowPanel);
            this.AnnoyGroup.Controls.Add(this.AnnoyGroup_LocationFollowPanel);
            this.AnnoyGroup.Controls.Add(this.AnnoyGroup_ActivityFollowPanel);
            this.AnnoyGroup.Controls.Add(this.AnnoyGroup_TopPanel);
            this.AnnoyGroup.Location = new System.Drawing.Point(17, 201);
            this.AnnoyGroup.Name = "AnnoyGroup";
            this.AnnoyGroup.Size = new System.Drawing.Size(345, 158);
            this.AnnoyGroup.TabIndex = 2;
            this.AnnoyGroup.TabStop = false;
            this.AnnoyGroup.Text = "Annoyances";
            // 
            // AnnoyGroup_CategoryFollowPanel
            // 
            this.AnnoyGroup_CategoryFollowPanel.Controls.Add(this.Behavior_Annoy_CategoryFollowsProject);
            this.AnnoyGroup_CategoryFollowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnnoyGroup_CategoryFollowPanel.Location = new System.Drawing.Point(3, 128);
            this.AnnoyGroup_CategoryFollowPanel.Name = "AnnoyGroup_CategoryFollowPanel";
            this.AnnoyGroup_CategoryFollowPanel.Size = new System.Drawing.Size(339, 23);
            this.AnnoyGroup_CategoryFollowPanel.TabIndex = 14;
            // 
            // Behavior_Annoy_CategoryFollowsProject
            // 
            this.Behavior_Annoy_CategoryFollowsProject.AutoSize = true;
            this.Behavior_Annoy_CategoryFollowsProject.Location = new System.Drawing.Point(14, 4);
            this.Behavior_Annoy_CategoryFollowsProject.Name = "Behavior_Annoy_CategoryFollowsProject";
            this.Behavior_Annoy_CategoryFollowsProject.Size = new System.Drawing.Size(139, 17);
            this.Behavior_Annoy_CategoryFollowsProject.TabIndex = 10;
            this.Behavior_Annoy_CategoryFollowsProject.Text = "Category follows Project";
            this.Behavior_Annoy_CategoryFollowsProject.UseVisualStyleBackColor = true;
            // 
            // AnnoyGroup_LocationFollowPanel
            // 
            this.AnnoyGroup_LocationFollowPanel.Controls.Add(this.Behavior_Annoy_LocationFollowsProject);
            this.AnnoyGroup_LocationFollowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnnoyGroup_LocationFollowPanel.Location = new System.Drawing.Point(3, 105);
            this.AnnoyGroup_LocationFollowPanel.Name = "AnnoyGroup_LocationFollowPanel";
            this.AnnoyGroup_LocationFollowPanel.Size = new System.Drawing.Size(339, 23);
            this.AnnoyGroup_LocationFollowPanel.TabIndex = 13;
            // 
            // Behavior_Annoy_LocationFollowsProject
            // 
            this.Behavior_Annoy_LocationFollowsProject.AutoSize = true;
            this.Behavior_Annoy_LocationFollowsProject.Location = new System.Drawing.Point(14, 4);
            this.Behavior_Annoy_LocationFollowsProject.Name = "Behavior_Annoy_LocationFollowsProject";
            this.Behavior_Annoy_LocationFollowsProject.Size = new System.Drawing.Size(138, 17);
            this.Behavior_Annoy_LocationFollowsProject.TabIndex = 0;
            this.Behavior_Annoy_LocationFollowsProject.Text = "Location follows Project";
            this.Behavior_Annoy_LocationFollowsProject.UseVisualStyleBackColor = true;
            // 
            // AnnoyGroup_ActivityFollowPanel
            // 
            this.AnnoyGroup_ActivityFollowPanel.Controls.Add(this.Behavior_Annoy_ActivityFollowsProject);
            this.AnnoyGroup_ActivityFollowPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnnoyGroup_ActivityFollowPanel.Location = new System.Drawing.Point(3, 82);
            this.AnnoyGroup_ActivityFollowPanel.Name = "AnnoyGroup_ActivityFollowPanel";
            this.AnnoyGroup_ActivityFollowPanel.Size = new System.Drawing.Size(339, 23);
            this.AnnoyGroup_ActivityFollowPanel.TabIndex = 12;
            // 
            // Behavior_Annoy_ActivityFollowsProject
            // 
            this.Behavior_Annoy_ActivityFollowsProject.AutoSize = true;
            this.Behavior_Annoy_ActivityFollowsProject.Location = new System.Drawing.Point(14, 4);
            this.Behavior_Annoy_ActivityFollowsProject.Name = "Behavior_Annoy_ActivityFollowsProject";
            this.Behavior_Annoy_ActivityFollowsProject.Size = new System.Drawing.Size(131, 17);
            this.Behavior_Annoy_ActivityFollowsProject.TabIndex = 7;
            this.Behavior_Annoy_ActivityFollowsProject.Text = "Activity follows Project";
            this.Behavior_Annoy_ActivityFollowsProject.UseVisualStyleBackColor = true;
            // 
            // AnnoyGroup_TopPanel
            // 
            this.AnnoyGroup_TopPanel.Controls.Add(this.Behavior_Annoy_PromptBeforeHiding);
            this.AnnoyGroup_TopPanel.Controls.Add(this.Behavior_Annoy_UseNewDatabaseWizard);
            this.AnnoyGroup_TopPanel.Controls.Add(this.Behavior_Annoy_NoRunningPrompt);
            this.AnnoyGroup_TopPanel.Controls.Add(this.Behavior_Annoy_NoRunningPromptAmount);
            this.AnnoyGroup_TopPanel.Controls.Add(this.MinutesLabel);
            this.AnnoyGroup_TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnnoyGroup_TopPanel.Location = new System.Drawing.Point(3, 16);
            this.AnnoyGroup_TopPanel.Name = "AnnoyGroup_TopPanel";
            this.AnnoyGroup_TopPanel.Size = new System.Drawing.Size(339, 66);
            this.AnnoyGroup_TopPanel.TabIndex = 11;
            // 
            // Behavior_Annoy_PromptBeforeHiding
            // 
            this.Behavior_Annoy_PromptBeforeHiding.AutoSize = true;
            this.Behavior_Annoy_PromptBeforeHiding.Location = new System.Drawing.Point(14, 3);
            this.Behavior_Annoy_PromptBeforeHiding.Name = "Behavior_Annoy_PromptBeforeHiding";
            this.Behavior_Annoy_PromptBeforeHiding.Size = new System.Drawing.Size(150, 17);
            this.Behavior_Annoy_PromptBeforeHiding.TabIndex = 8;
            this.Behavior_Annoy_PromptBeforeHiding.Text = "Prompt before hiding items";
            this.Behavior_Annoy_PromptBeforeHiding.UseVisualStyleBackColor = true;
            // 
            // Behavior_Annoy_UseNewDatabaseWizard
            // 
            this.Behavior_Annoy_UseNewDatabaseWizard.AutoSize = true;
            this.Behavior_Annoy_UseNewDatabaseWizard.Location = new System.Drawing.Point(14, 49);
            this.Behavior_Annoy_UseNewDatabaseWizard.Name = "Behavior_Annoy_UseNewDatabaseWizard";
            this.Behavior_Annoy_UseNewDatabaseWizard.Size = new System.Drawing.Size(152, 17);
            this.Behavior_Annoy_UseNewDatabaseWizard.TabIndex = 9;
            this.Behavior_Annoy_UseNewDatabaseWizard.Text = "Use New Database wizard";
            this.Behavior_Annoy_UseNewDatabaseWizard.UseVisualStyleBackColor = true;
            // 
            // Behavior_Annoy_NoRunningPrompt
            // 
            this.Behavior_Annoy_NoRunningPrompt.AutoSize = true;
            this.Behavior_Annoy_NoRunningPrompt.Location = new System.Drawing.Point(14, 26);
            this.Behavior_Annoy_NoRunningPrompt.Name = "Behavior_Annoy_NoRunningPrompt";
            this.Behavior_Annoy_NoRunningPrompt.Size = new System.Drawing.Size(169, 17);
            this.Behavior_Annoy_NoRunningPrompt.TabIndex = 5;
            this.Behavior_Annoy_NoRunningPrompt.Text = "Prompt if no timer running after";
            this.Behavior_Annoy_NoRunningPrompt.UseVisualStyleBackColor = true;
            this.Behavior_Annoy_NoRunningPrompt.CheckedChanged += new System.EventHandler(this.Behavior_Annoy_NoRunningPrompt_CheckedChanged);
            // 
            // Behavior_Annoy_NoRunningPromptAmount
            // 
            this.Behavior_Annoy_NoRunningPromptAmount.Location = new System.Drawing.Point(189, 25);
            this.Behavior_Annoy_NoRunningPromptAmount.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.Behavior_Annoy_NoRunningPromptAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Behavior_Annoy_NoRunningPromptAmount.Name = "Behavior_Annoy_NoRunningPromptAmount";
            this.Behavior_Annoy_NoRunningPromptAmount.Size = new System.Drawing.Size(53, 20);
            this.Behavior_Annoy_NoRunningPromptAmount.TabIndex = 6;
            this.Behavior_Annoy_NoRunningPromptAmount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // MinutesLabel
            // 
            this.MinutesLabel.AutoSize = true;
            this.MinutesLabel.Location = new System.Drawing.Point(248, 27);
            this.MinutesLabel.Name = "MinutesLabel";
            this.MinutesLabel.Size = new System.Drawing.Size(43, 13);
            this.MinutesLabel.TabIndex = 7;
            this.MinutesLabel.Text = "minutes";
            // 
            // BehaviorSpacingBox
            // 
            this.BehaviorSpacingBox.Image = global::Timekeeper.Properties.Resources.ImageIconBlank;
            this.BehaviorSpacingBox.Location = new System.Drawing.Point(17, 575);
            this.BehaviorSpacingBox.Name = "BehaviorSpacingBox";
            this.BehaviorSpacingBox.Size = new System.Drawing.Size(16, 16);
            this.BehaviorSpacingBox.TabIndex = 23;
            this.BehaviorSpacingBox.TabStop = false;
            // 
            // BrowsingGroup
            // 
            this.BrowsingGroup.Controls.Add(this.checkBox7);
            this.BrowsingGroup.Controls.Add(this.Behavior_BrowseNextBy);
            this.BrowsingGroup.Controls.Add(this.Behavior_BrowsePrevBy);
            this.BrowsingGroup.Controls.Add(this.label14);
            this.BrowsingGroup.Controls.Add(this.label13);
            this.BrowsingGroup.Location = new System.Drawing.Point(17, 473);
            this.BrowsingGroup.Name = "BrowsingGroup";
            this.BrowsingGroup.Size = new System.Drawing.Size(345, 102);
            this.BrowsingGroup.TabIndex = 5;
            this.BrowsingGroup.TabStop = false;
            this.BrowsingGroup.Text = "Browsing";
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.Enabled = false;
            this.checkBox7.Location = new System.Drawing.Point(17, 79);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(225, 17);
            this.checkBox7.TabIndex = 4;
            this.checkBox7.Text = "Sync Previous and Next browsing options.";
            this.checkBox7.UseVisualStyleBackColor = true;
            // 
            // Behavior_BrowseNextBy
            // 
            this.Behavior_BrowseNextBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_BrowseNextBy.FormattingEnabled = true;
            this.Behavior_BrowseNextBy.Items.AddRange(new object[] {
            "Entry",
            "Day",
            "Week",
            "Month",
            "Year"});
            this.Behavior_BrowseNextBy.Location = new System.Drawing.Point(158, 53);
            this.Behavior_BrowseNextBy.Name = "Behavior_BrowseNextBy";
            this.Behavior_BrowseNextBy.Size = new System.Drawing.Size(121, 21);
            this.Behavior_BrowseNextBy.TabIndex = 3;
            // 
            // Behavior_BrowsePrevBy
            // 
            this.Behavior_BrowsePrevBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_BrowsePrevBy.FormattingEnabled = true;
            this.Behavior_BrowsePrevBy.Items.AddRange(new object[] {
            "Entry",
            "Day",
            "Week",
            "Month",
            "Year"});
            this.Behavior_BrowsePrevBy.Location = new System.Drawing.Point(158, 26);
            this.Behavior_BrowsePrevBy.Name = "Behavior_BrowsePrevBy";
            this.Behavior_BrowsePrevBy.Size = new System.Drawing.Size(121, 21);
            this.Behavior_BrowsePrevBy.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(14, 56);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Browse next entries by:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "Browse previous entries by:";
            // 
            // SortingGroup
            // 
            this.SortingGroup.Controls.Add(this.SortingGroup_BottomPanel);
            this.SortingGroup.Controls.Add(this.SortingGroup_ProjectPanel);
            this.SortingGroup.Location = new System.Drawing.Point(17, 365);
            this.SortingGroup.Name = "SortingGroup";
            this.SortingGroup.Size = new System.Drawing.Size(345, 102);
            this.SortingGroup.TabIndex = 4;
            this.SortingGroup.TabStop = false;
            this.SortingGroup.Text = "Sorting";
            // 
            // SortingGroup_BottomPanel
            // 
            this.SortingGroup_BottomPanel.Controls.Add(this.Behavior_SortItemsBy);
            this.SortingGroup_BottomPanel.Controls.Add(this.Behavior_SortItemsByDirection);
            this.SortingGroup_BottomPanel.Controls.Add(this.SortItemsLabel);
            this.SortingGroup_BottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SortingGroup_BottomPanel.Location = new System.Drawing.Point(3, 73);
            this.SortingGroup_BottomPanel.Name = "SortingGroup_BottomPanel";
            this.SortingGroup_BottomPanel.Size = new System.Drawing.Size(339, 27);
            this.SortingGroup_BottomPanel.TabIndex = 1;
            // 
            // Behavior_SortItemsBy
            // 
            this.Behavior_SortItemsBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Behavior_SortItemsBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Behavior_SortItemsBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_SortItemsBy.FormattingEnabled = true;
            this.Behavior_SortItemsBy.Location = new System.Drawing.Point(87, 3);
            this.Behavior_SortItemsBy.Name = "Behavior_SortItemsBy";
            this.Behavior_SortItemsBy.Size = new System.Drawing.Size(155, 21);
            this.Behavior_SortItemsBy.TabIndex = 18;
            this.Behavior_SortItemsBy.SelectedIndexChanged += new System.EventHandler(this.Behavior_SortItemsBy_SelectedIndexChanged);
            // 
            // Behavior_SortItemsByDirection
            // 
            this.Behavior_SortItemsByDirection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Behavior_SortItemsByDirection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Behavior_SortItemsByDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_SortItemsByDirection.FormattingEnabled = true;
            this.Behavior_SortItemsByDirection.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.Behavior_SortItemsByDirection.Location = new System.Drawing.Point(248, 3);
            this.Behavior_SortItemsByDirection.Name = "Behavior_SortItemsByDirection";
            this.Behavior_SortItemsByDirection.Size = new System.Drawing.Size(88, 21);
            this.Behavior_SortItemsByDirection.TabIndex = 20;
            // 
            // SortItemsLabel
            // 
            this.SortItemsLabel.AutoSize = true;
            this.SortItemsLabel.Location = new System.Drawing.Point(11, 6);
            this.SortItemsLabel.Name = "SortItemsLabel";
            this.SortItemsLabel.Size = new System.Drawing.Size(63, 13);
            this.SortItemsLabel.TabIndex = 18;
            this.SortItemsLabel.Text = "Sort Others:";
            // 
            // SortingGroup_ProjectPanel
            // 
            this.SortingGroup_ProjectPanel.Controls.Add(this.Behavior_SortProjectsThenByDirection);
            this.SortingGroup_ProjectPanel.Controls.Add(this.label20);
            this.SortingGroup_ProjectPanel.Controls.Add(this.Behavior_SortProjectsThenBy);
            this.SortingGroup_ProjectPanel.Controls.Add(this.Behavior_SortProjectsByDirection);
            this.SortingGroup_ProjectPanel.Controls.Add(this.Behavior_SortProjectsBy);
            this.SortingGroup_ProjectPanel.Controls.Add(this.SortProjectsLabel);
            this.SortingGroup_ProjectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SortingGroup_ProjectPanel.Location = new System.Drawing.Point(3, 16);
            this.SortingGroup_ProjectPanel.Name = "SortingGroup_ProjectPanel";
            this.SortingGroup_ProjectPanel.Size = new System.Drawing.Size(339, 57);
            this.SortingGroup_ProjectPanel.TabIndex = 0;
            // 
            // Behavior_SortProjectsThenByDirection
            // 
            this.Behavior_SortProjectsThenByDirection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Behavior_SortProjectsThenByDirection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Behavior_SortProjectsThenByDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_SortProjectsThenByDirection.Enabled = false;
            this.Behavior_SortProjectsThenByDirection.FormattingEnabled = true;
            this.Behavior_SortProjectsThenByDirection.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.Behavior_SortProjectsThenByDirection.Location = new System.Drawing.Point(248, 30);
            this.Behavior_SortProjectsThenByDirection.Name = "Behavior_SortProjectsThenByDirection";
            this.Behavior_SortProjectsThenByDirection.Size = new System.Drawing.Size(88, 21);
            this.Behavior_SortProjectsThenByDirection.TabIndex = 22;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(11, 33);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(50, 13);
            this.label20.TabIndex = 21;
            this.label20.Text = "Then By:";
            // 
            // Behavior_SortProjectsThenBy
            // 
            this.Behavior_SortProjectsThenBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Behavior_SortProjectsThenBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Behavior_SortProjectsThenBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_SortProjectsThenBy.Enabled = false;
            this.Behavior_SortProjectsThenBy.FormattingEnabled = true;
            this.Behavior_SortProjectsThenBy.Location = new System.Drawing.Point(87, 30);
            this.Behavior_SortProjectsThenBy.Name = "Behavior_SortProjectsThenBy";
            this.Behavior_SortProjectsThenBy.Size = new System.Drawing.Size(155, 21);
            this.Behavior_SortProjectsThenBy.TabIndex = 20;
            this.Behavior_SortProjectsThenBy.SelectedIndexChanged += new System.EventHandler(this.Behavior_SortProjectsThenBy_SelectedIndexChanged);
            // 
            // Behavior_SortProjectsByDirection
            // 
            this.Behavior_SortProjectsByDirection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Behavior_SortProjectsByDirection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Behavior_SortProjectsByDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_SortProjectsByDirection.FormattingEnabled = true;
            this.Behavior_SortProjectsByDirection.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.Behavior_SortProjectsByDirection.Location = new System.Drawing.Point(248, 3);
            this.Behavior_SortProjectsByDirection.Name = "Behavior_SortProjectsByDirection";
            this.Behavior_SortProjectsByDirection.Size = new System.Drawing.Size(88, 21);
            this.Behavior_SortProjectsByDirection.TabIndex = 19;
            // 
            // Behavior_SortProjectsBy
            // 
            this.Behavior_SortProjectsBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Behavior_SortProjectsBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Behavior_SortProjectsBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_SortProjectsBy.FormattingEnabled = true;
            this.Behavior_SortProjectsBy.Location = new System.Drawing.Point(87, 3);
            this.Behavior_SortProjectsBy.Name = "Behavior_SortProjectsBy";
            this.Behavior_SortProjectsBy.Size = new System.Drawing.Size(155, 21);
            this.Behavior_SortProjectsBy.TabIndex = 16;
            this.Behavior_SortProjectsBy.SelectedIndexChanged += new System.EventHandler(this.Behavior_SortProjectsBy_SelectedIndexChanged);
            // 
            // SortProjectsLabel
            // 
            this.SortProjectsLabel.AutoSize = true;
            this.SortProjectsLabel.Location = new System.Drawing.Point(11, 6);
            this.SortProjectsLabel.Name = "SortProjectsLabel";
            this.SortProjectsLabel.Size = new System.Drawing.Size(70, 13);
            this.SortProjectsLabel.TabIndex = 17;
            this.SortProjectsLabel.Text = "Sort Projects:";
            // 
            // WindowControlGroup
            // 
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_MinimizeOnUse);
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_MinimizeToTray);
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_ShowInTray);
            this.WindowControlGroup.Location = new System.Drawing.Point(17, 107);
            this.WindowControlGroup.Name = "WindowControlGroup";
            this.WindowControlGroup.Size = new System.Drawing.Size(345, 88);
            this.WindowControlGroup.TabIndex = 1;
            this.WindowControlGroup.TabStop = false;
            this.WindowControlGroup.Text = "Window Control";
            // 
            // Behavior_Window_MinimizeOnUse
            // 
            this.Behavior_Window_MinimizeOnUse.AutoSize = true;
            this.Behavior_Window_MinimizeOnUse.Location = new System.Drawing.Point(17, 65);
            this.Behavior_Window_MinimizeOnUse.Name = "Behavior_Window_MinimizeOnUse";
            this.Behavior_Window_MinimizeOnUse.Size = new System.Drawing.Size(103, 17);
            this.Behavior_Window_MinimizeOnUse.TabIndex = 2;
            this.Behavior_Window_MinimizeOnUse.Text = "Minimize on Use";
            this.Behavior_Window_MinimizeOnUse.UseVisualStyleBackColor = true;
            // 
            // Behavior_Window_MinimizeToTray
            // 
            this.Behavior_Window_MinimizeToTray.AutoSize = true;
            this.Behavior_Window_MinimizeToTray.Enabled = false;
            this.Behavior_Window_MinimizeToTray.Location = new System.Drawing.Point(17, 42);
            this.Behavior_Window_MinimizeToTray.Name = "Behavior_Window_MinimizeToTray";
            this.Behavior_Window_MinimizeToTray.Size = new System.Drawing.Size(102, 17);
            this.Behavior_Window_MinimizeToTray.TabIndex = 1;
            this.Behavior_Window_MinimizeToTray.Text = "Minimize to Tray";
            this.Behavior_Window_MinimizeToTray.UseVisualStyleBackColor = true;
            // 
            // Behavior_Window_ShowInTray
            // 
            this.Behavior_Window_ShowInTray.AutoSize = true;
            this.Behavior_Window_ShowInTray.Location = new System.Drawing.Point(17, 19);
            this.Behavior_Window_ShowInTray.Name = "Behavior_Window_ShowInTray";
            this.Behavior_Window_ShowInTray.Size = new System.Drawing.Size(88, 17);
            this.Behavior_Window_ShowInTray.TabIndex = 0;
            this.Behavior_Window_ShowInTray.Text = "Show in Tray";
            this.Behavior_Window_ShowInTray.UseVisualStyleBackColor = true;
            this.Behavior_Window_ShowInTray.CheckedChanged += new System.EventHandler(this.Behavior_Window_ShowInTray_CheckedChanged);
            // 
            // TitleBarGroup
            // 
            this.TitleBarGroup.Controls.Add(this.DisplayLabel);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_Time);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_Template);
            this.TitleBarGroup.Controls.Add(this.TitleBarTemplateLabel);
            this.TitleBarGroup.Location = new System.Drawing.Point(17, 16);
            this.TitleBarGroup.Name = "TitleBarGroup";
            this.TitleBarGroup.Size = new System.Drawing.Size(345, 85);
            this.TitleBarGroup.TabIndex = 0;
            this.TitleBarGroup.TabStop = false;
            this.TitleBarGroup.Text = "Title Bar";
            // 
            // DisplayLabel
            // 
            this.DisplayLabel.AutoSize = true;
            this.DisplayLabel.Location = new System.Drawing.Point(14, 55);
            this.DisplayLabel.Name = "DisplayLabel";
            this.DisplayLabel.Size = new System.Drawing.Size(85, 13);
            this.DisplayLabel.TabIndex = 7;
            this.DisplayLabel.Text = "Display Time As:";
            // 
            // Behavior_TitleBar_Time
            // 
            this.Behavior_TitleBar_Time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Behavior_TitleBar_Time.FormattingEnabled = true;
            this.Behavior_TitleBar_Time.Location = new System.Drawing.Point(111, 51);
            this.Behavior_TitleBar_Time.Name = "Behavior_TitleBar_Time";
            this.Behavior_TitleBar_Time.Size = new System.Drawing.Size(215, 21);
            this.Behavior_TitleBar_Time.TabIndex = 6;
            // 
            // Behavior_TitleBar_Template
            // 
            this.Behavior_TitleBar_Template.Location = new System.Drawing.Point(111, 25);
            this.Behavior_TitleBar_Template.Name = "Behavior_TitleBar_Template";
            this.Behavior_TitleBar_Template.Size = new System.Drawing.Size(215, 20);
            this.Behavior_TitleBar_Template.TabIndex = 5;
            // 
            // TitleBarTemplateLabel
            // 
            this.TitleBarTemplateLabel.AutoSize = true;
            this.TitleBarTemplateLabel.Location = new System.Drawing.Point(14, 28);
            this.TitleBarTemplateLabel.Name = "TitleBarTemplateLabel";
            this.TitleBarTemplateLabel.Size = new System.Drawing.Size(54, 13);
            this.TitleBarTemplateLabel.TabIndex = 4;
            this.TitleBarTemplateLabel.Text = "Template:";
            // 
            // ReportPage
            // 
            this.ReportPage.Controls.Add(this.ReportGroup);
            this.ReportPage.Location = new System.Drawing.Point(98, 4);
            this.ReportPage.Name = "ReportPage";
            this.ReportPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReportPage.Size = new System.Drawing.Size(393, 412);
            this.ReportPage.TabIndex = 1;
            this.ReportPage.Text = "Report";
            this.ReportPage.UseVisualStyleBackColor = true;
            // 
            // ReportGroup
            // 
            this.ReportGroup.Controls.Add(this.Report_LayoutFileChooser);
            this.ReportGroup.Controls.Add(this.Report_LayoutFile);
            this.ReportGroup.Controls.Add(this.Report_LayoutFileLabel);
            this.ReportGroup.Controls.Add(this.Report_StyleSheetFileChooser);
            this.ReportGroup.Controls.Add(this.label19);
            this.ReportGroup.Controls.Add(this.label18);
            this.ReportGroup.Controls.Add(this.Report_Font);
            this.ReportGroup.Controls.Add(this.Report_FontButton);
            this.ReportGroup.Controls.Add(this.Report_StyleSheetFile);
            this.ReportGroup.Controls.Add(this.Report_StyleSheetFileLabel);
            this.ReportGroup.Location = new System.Drawing.Point(17, 16);
            this.ReportGroup.Name = "ReportGroup";
            this.ReportGroup.Size = new System.Drawing.Size(363, 374);
            this.ReportGroup.TabIndex = 7;
            this.ReportGroup.TabStop = false;
            this.ReportGroup.Text = "Styling";
            // 
            // Report_LayoutFileChooser
            // 
            this.Report_LayoutFileChooser.Location = new System.Drawing.Point(323, 233);
            this.Report_LayoutFileChooser.Name = "Report_LayoutFileChooser";
            this.Report_LayoutFileChooser.Size = new System.Drawing.Size(27, 20);
            this.Report_LayoutFileChooser.TabIndex = 6;
            this.Report_LayoutFileChooser.Text = "···";
            this.Report_LayoutFileChooser.UseVisualStyleBackColor = true;
            this.Report_LayoutFileChooser.Click += new System.EventHandler(this.Report_LayoutFileChooser_Click);
            // 
            // Report_LayoutFile
            // 
            this.Report_LayoutFile.Location = new System.Drawing.Point(111, 233);
            this.Report_LayoutFile.Name = "Report_LayoutFile";
            this.Report_LayoutFile.Size = new System.Drawing.Size(204, 20);
            this.Report_LayoutFile.TabIndex = 5;
            this.Report_LayoutFile.Text = "Files\\JournalEntryReport.html";
            // 
            // Report_LayoutFileLabel
            // 
            this.Report_LayoutFileLabel.AutoSize = true;
            this.Report_LayoutFileLabel.Location = new System.Drawing.Point(17, 236);
            this.Report_LayoutFileLabel.Name = "Report_LayoutFileLabel";
            this.Report_LayoutFileLabel.Size = new System.Drawing.Size(77, 13);
            this.Report_LayoutFileLabel.TabIndex = 15;
            this.Report_LayoutFileLabel.Text = "Report Layout:";
            // 
            // Report_StyleSheetFileChooser
            // 
            this.Report_StyleSheetFileChooser.Location = new System.Drawing.Point(323, 207);
            this.Report_StyleSheetFileChooser.Name = "Report_StyleSheetFileChooser";
            this.Report_StyleSheetFileChooser.Size = new System.Drawing.Size(27, 20);
            this.Report_StyleSheetFileChooser.TabIndex = 4;
            this.Report_StyleSheetFileChooser.Text = "···";
            this.Report_StyleSheetFileChooser.UseVisualStyleBackColor = true;
            this.Report_StyleSheetFileChooser.Click += new System.EventHandler(this.Report_StyleSheetFileChooser_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 142);
            this.label19.MaximumSize = new System.Drawing.Size(340, 95);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(338, 52);
            this.label19.TabIndex = 13;
            this.label19.Text = "Advanced. For complete control over the report layout, you can create your own st" +
    "yle sheet or replace the document wrapper HTML.\r\n\r\nPaths here are relative to th" +
    "e Timekeeper executable.";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(17, 27);
            this.label18.MaximumSize = new System.Drawing.Size(340, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(333, 39);
            this.label18.TabIndex = 12;
            this.label18.Text = "If you\'re comfortable with the basic report layout but would simply like to use a" +
    " different font, click the Choose Font button to select a new font to be applied" +
    " to reports.";
            // 
            // Report_Font
            // 
            this.Report_Font.Location = new System.Drawing.Point(111, 95);
            this.Report_Font.Name = "Report_Font";
            this.Report_Font.ReadOnly = true;
            this.Report_Font.Size = new System.Drawing.Size(236, 20);
            this.Report_Font.TabIndex = 2;
            // 
            // Report_FontButton
            // 
            this.Report_FontButton.Location = new System.Drawing.Point(17, 93);
            this.Report_FontButton.Name = "Report_FontButton";
            this.Report_FontButton.Size = new System.Drawing.Size(86, 23);
            this.Report_FontButton.TabIndex = 1;
            this.Report_FontButton.Text = "Choose Font...";
            this.Report_FontButton.UseVisualStyleBackColor = true;
            this.Report_FontButton.Click += new System.EventHandler(this.Report_FontButton_Click);
            // 
            // Report_StyleSheetFile
            // 
            this.Report_StyleSheetFile.Location = new System.Drawing.Point(111, 207);
            this.Report_StyleSheetFile.Name = "Report_StyleSheetFile";
            this.Report_StyleSheetFile.Size = new System.Drawing.Size(204, 20);
            this.Report_StyleSheetFile.TabIndex = 3;
            this.Report_StyleSheetFile.Text = "Files\\JournalEntryReport.css";
            // 
            // Report_StyleSheetFileLabel
            // 
            this.Report_StyleSheetFileLabel.AutoSize = true;
            this.Report_StyleSheetFileLabel.Location = new System.Drawing.Point(17, 210);
            this.Report_StyleSheetFileLabel.Name = "Report_StyleSheetFileLabel";
            this.Report_StyleSheetFileLabel.Size = new System.Drawing.Size(64, 13);
            this.Report_StyleSheetFileLabel.TabIndex = 5;
            this.Report_StyleSheetFileLabel.Text = "Style Sheet:";
            // 
            // KeyboardPage
            // 
            this.KeyboardPage.Controls.Add(this.ShortcutGroup);
            this.KeyboardPage.Controls.Add(this.FunctionList);
            this.KeyboardPage.Location = new System.Drawing.Point(98, 4);
            this.KeyboardPage.Name = "KeyboardPage";
            this.KeyboardPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeyboardPage.Size = new System.Drawing.Size(393, 412);
            this.KeyboardPage.TabIndex = 4;
            this.KeyboardPage.Text = "Keyboard";
            this.KeyboardPage.UseVisualStyleBackColor = true;
            // 
            // ShortcutGroup
            // 
            this.ShortcutGroup.Controls.Add(this.AssignKey);
            this.ShortcutGroup.Controls.Add(this.AltKey);
            this.ShortcutGroup.Controls.Add(this.RemoveKey);
            this.ShortcutGroup.Controls.Add(this.KeyCode);
            this.ShortcutGroup.Controls.Add(this.ShiftKey);
            this.ShortcutGroup.Controls.Add(this.ControlKey);
            this.ShortcutGroup.Location = new System.Drawing.Point(15, 324);
            this.ShortcutGroup.Name = "ShortcutGroup";
            this.ShortcutGroup.Size = new System.Drawing.Size(365, 82);
            this.ShortcutGroup.TabIndex = 9;
            this.ShortcutGroup.TabStop = false;
            this.ShortcutGroup.Text = "Shortcut";
            // 
            // AssignKey
            // 
            this.AssignKey.Location = new System.Drawing.Point(274, 19);
            this.AssignKey.Name = "AssignKey";
            this.AssignKey.Size = new System.Drawing.Size(75, 23);
            this.AssignKey.TabIndex = 12;
            this.AssignKey.Text = "&Assign";
            this.AssignKey.UseVisualStyleBackColor = true;
            this.AssignKey.Click += new System.EventHandler(this.AssignKey_Click);
            // 
            // AltKey
            // 
            this.AltKey.AutoSize = true;
            this.AltKey.Location = new System.Drawing.Point(65, 36);
            this.AltKey.Name = "AltKey";
            this.AltKey.Size = new System.Drawing.Size(38, 17);
            this.AltKey.TabIndex = 11;
            this.AltKey.Text = "Alt";
            this.AltKey.UseVisualStyleBackColor = true;
            // 
            // RemoveKey
            // 
            this.RemoveKey.Location = new System.Drawing.Point(274, 48);
            this.RemoveKey.Name = "RemoveKey";
            this.RemoveKey.Size = new System.Drawing.Size(75, 23);
            this.RemoveKey.TabIndex = 10;
            this.RemoveKey.Text = "&Remove";
            this.RemoveKey.UseVisualStyleBackColor = true;
            this.RemoveKey.Click += new System.EventHandler(this.RemoveKey_Click);
            // 
            // KeyCode
            // 
            this.KeyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyCode.FormattingEnabled = true;
            this.KeyCode.Items.AddRange(new object[] {
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
            "LWin",
            "RWin",
            "NumPad0",
            "NumPad1",
            "NumPad2",
            "NumPad3",
            "NumPad4",
            "NumPad5",
            "NumPad6",
            "NumPad7",
            "NumPad8",
            "NumPad9",
            "Multiply",
            "Add",
            "Separator",
            "Subtract",
            "Decimal",
            "Divide",
            "F1",
            "F2",
            "F3",
            "F4",
            "F5",
            "F6",
            "F7",
            "F8",
            "F9",
            "F10",
            "F11",
            "F12",
            "F13",
            "F14",
            "F15",
            "F16",
            "F17",
            "F18",
            "F19",
            "F20",
            "F21",
            "F22",
            "F23",
            "F24",
            "Space",
            "PageUp",
            "PageDown",
            "End",
            "Home",
            "Left",
            "Up",
            "Right",
            "Down",
            "Insert",
            "Delete"});
            this.KeyCode.Location = new System.Drawing.Point(162, 34);
            this.KeyCode.Name = "KeyCode";
            this.KeyCode.Size = new System.Drawing.Size(75, 21);
            this.KeyCode.TabIndex = 9;
            // 
            // ShiftKey
            // 
            this.ShiftKey.AutoSize = true;
            this.ShiftKey.Location = new System.Drawing.Point(109, 36);
            this.ShiftKey.Name = "ShiftKey";
            this.ShiftKey.Size = new System.Drawing.Size(47, 17);
            this.ShiftKey.TabIndex = 8;
            this.ShiftKey.Text = "Shift";
            this.ShiftKey.UseVisualStyleBackColor = true;
            // 
            // ControlKey
            // 
            this.ControlKey.AutoSize = true;
            this.ControlKey.Location = new System.Drawing.Point(18, 36);
            this.ControlKey.Name = "ControlKey";
            this.ControlKey.Size = new System.Drawing.Size(41, 17);
            this.ControlKey.TabIndex = 7;
            this.ControlKey.Text = "Ctrl";
            this.ControlKey.UseVisualStyleBackColor = true;
            // 
            // FunctionList
            // 
            this.FunctionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.FunctionList.FullRowSelect = true;
            this.FunctionList.HideSelection = false;
            this.FunctionList.Location = new System.Drawing.Point(15, 16);
            this.FunctionList.MultiSelect = false;
            this.FunctionList.Name = "FunctionList";
            this.FunctionList.Size = new System.Drawing.Size(365, 302);
            this.FunctionList.SmallImageList = this.SmallImages;
            this.FunctionList.TabIndex = 8;
            this.FunctionList.UseCompatibleStateImageBehavior = false;
            this.FunctionList.View = System.Windows.Forms.View.Details;
            this.FunctionList.SelectedIndexChanged += new System.EventHandler(this.wFunctionList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Function";
            this.columnHeader1.Width = 265;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Shortcut";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 0;
            // 
            // SmallImages
            // 
            this.SmallImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("SmallImages.ImageStream")));
            this.SmallImages.TransparentColor = System.Drawing.Color.Transparent;
            this.SmallImages.Images.SetKeyName(0, "ImageIconMenu");
            this.SmallImages.Images.SetKeyName(1, "ImageIconToolbar");
            // 
            // AdvancedPage
            // 
            this.AdvancedPage.AutoScroll = true;
            this.AdvancedPage.Controls.Add(this.AdvancedSpacerBox);
            this.AdvancedPage.Controls.Add(this.AdvancedFormattingGroup);
            this.AdvancedPage.Controls.Add(this.OtherAdvancedGroup);
            this.AdvancedPage.Controls.Add(this.LoggingGroup);
            this.AdvancedPage.Location = new System.Drawing.Point(98, 4);
            this.AdvancedPage.Name = "AdvancedPage";
            this.AdvancedPage.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedPage.Size = new System.Drawing.Size(393, 412);
            this.AdvancedPage.TabIndex = 5;
            this.AdvancedPage.Text = "Advanced";
            this.AdvancedPage.UseVisualStyleBackColor = true;
            // 
            // AdvancedSpacerBox
            // 
            this.AdvancedSpacerBox.Image = global::Timekeeper.Properties.Resources.ImageIconBlank;
            this.AdvancedSpacerBox.Location = new System.Drawing.Point(17, 427);
            this.AdvancedSpacerBox.Name = "AdvancedSpacerBox";
            this.AdvancedSpacerBox.Size = new System.Drawing.Size(16, 16);
            this.AdvancedSpacerBox.TabIndex = 23;
            this.AdvancedSpacerBox.TabStop = false;
            // 
            // AdvancedFormattingGroup
            // 
            this.AdvancedFormattingGroup.Controls.Add(this.Advanced_DateTimeFormat);
            this.AdvancedFormattingGroup.Controls.Add(this.label16);
            this.AdvancedFormattingGroup.Controls.Add(this.Advanced_BreakTemplate);
            this.AdvancedFormattingGroup.Controls.Add(this.label1);
            this.AdvancedFormattingGroup.Controls.Add(this.Advanced_MarkupLanguage);
            this.AdvancedFormattingGroup.Controls.Add(this.label12);
            this.AdvancedFormattingGroup.Location = new System.Drawing.Point(17, 137);
            this.AdvancedFormattingGroup.Name = "AdvancedFormattingGroup";
            this.AdvancedFormattingGroup.Size = new System.Drawing.Size(345, 115);
            this.AdvancedFormattingGroup.TabIndex = 4;
            this.AdvancedFormattingGroup.TabStop = false;
            this.AdvancedFormattingGroup.Text = "Formatting";
            // 
            // Advanced_DateTimeFormat
            // 
            this.Advanced_DateTimeFormat.FormattingEnabled = true;
            this.Advanced_DateTimeFormat.Items.AddRange(new object[] {
            "yyyy-MM-dd HH:mm:ss",
            "M/d/yy h:mm:ss tt",
            "d/M/yyyy hh:mm:ss",
            "MMMM d, yyyy hh:mm:ss"});
            this.Advanced_DateTimeFormat.Location = new System.Drawing.Point(127, 26);
            this.Advanced_DateTimeFormat.Name = "Advanced_DateTimeFormat";
            this.Advanced_DateTimeFormat.Size = new System.Drawing.Size(202, 21);
            this.Advanced_DateTimeFormat.TabIndex = 17;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(16, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(106, 13);
            this.label16.TabIndex = 22;
            this.label16.Text = "Memo <hr> template:";
            // 
            // Advanced_BreakTemplate
            // 
            this.Advanced_BreakTemplate.Location = new System.Drawing.Point(127, 53);
            this.Advanced_BreakTemplate.Name = "Advanced_BreakTemplate";
            this.Advanced_BreakTemplate.Size = new System.Drawing.Size(202, 20);
            this.Advanced_BreakTemplate.TabIndex = 21;
            this.Advanced_BreakTemplate.Text = "\\n<hr data-timestamp=\\\"%timestamp\\\" class=\\\"memo-split\\\" />\\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 20;
            this.label1.Text = "Date format:";
            // 
            // Advanced_MarkupLanguage
            // 
            this.Advanced_MarkupLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Advanced_MarkupLanguage.FormattingEnabled = true;
            this.Advanced_MarkupLanguage.Items.AddRange(new object[] {
            "HTML",
            "Markdown"});
            this.Advanced_MarkupLanguage.Location = new System.Drawing.Point(127, 79);
            this.Advanced_MarkupLanguage.Name = "Advanced_MarkupLanguage";
            this.Advanced_MarkupLanguage.Size = new System.Drawing.Size(202, 21);
            this.Advanced_MarkupLanguage.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 13);
            this.label12.TabIndex = 8;
            this.label12.Text = "Memo markup:";
            // 
            // OtherAdvancedGroup
            // 
            this.OtherAdvancedGroup.Controls.Add(this.Advanced_Other_MidnightOffset);
            this.OtherAdvancedGroup.Controls.Add(this.label15);
            this.OtherAdvancedGroup.Controls.Add(this.Advanced_Other_DimensionWidth);
            this.OtherAdvancedGroup.Controls.Add(this.Advanced_Other_DimensionWidthLabel);
            this.OtherAdvancedGroup.Controls.Add(this.checkBox5);
            this.OtherAdvancedGroup.Controls.Add(this.Advanced_Other_EnableScheduler);
            this.OtherAdvancedGroup.Controls.Add(this.label3);
            this.OtherAdvancedGroup.Controls.Add(this.numericUpDown1);
            this.OtherAdvancedGroup.Controls.Add(this.label2);
            this.OtherAdvancedGroup.Controls.Add(this.Advanced_Other_SortExtProjectAsNumber);
            this.OtherAdvancedGroup.Location = new System.Drawing.Point(17, 258);
            this.OtherAdvancedGroup.Name = "OtherAdvancedGroup";
            this.OtherAdvancedGroup.Size = new System.Drawing.Size(345, 163);
            this.OtherAdvancedGroup.TabIndex = 3;
            this.OtherAdvancedGroup.TabStop = false;
            this.OtherAdvancedGroup.Text = "Other";
            // 
            // Advanced_Other_MidnightOffset
            // 
            this.Advanced_Other_MidnightOffset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Advanced_Other_MidnightOffset.FormattingEnabled = true;
            this.Advanced_Other_MidnightOffset.Items.AddRange(new object[] {
            "Noon",
            "01:00 PM",
            "02:00 PM",
            "03:00 PM",
            "04:00 PM",
            "05:00 PM",
            "06:00 PM",
            "07:00 PM",
            "08:00 PM",
            "09:00 PM",
            "10:00 PM",
            "11:00 PM",
            "Midnight",
            "01:00 AM",
            "02:00 AM",
            "03:00 AM",
            "04:00 AM",
            "05:00 AM",
            "06:00 AM",
            "07:00 AM",
            "08:00 AM",
            "09:00 AM",
            "10:00 AM",
            "11:00 AM"});
            this.Advanced_Other_MidnightOffset.Location = new System.Drawing.Point(198, 129);
            this.Advanced_Other_MidnightOffset.Name = "Advanced_Other_MidnightOffset";
            this.Advanced_Other_MidnightOffset.Size = new System.Drawing.Size(121, 21);
            this.Advanced_Other_MidnightOffset.TabIndex = 16;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(33, 132);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(94, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "Work day ends at:";
            // 
            // Advanced_Other_DimensionWidth
            // 
            this.Advanced_Other_DimensionWidth.Location = new System.Drawing.Point(198, 103);
            this.Advanced_Other_DimensionWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.Advanced_Other_DimensionWidth.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.Advanced_Other_DimensionWidth.Name = "Advanced_Other_DimensionWidth";
            this.Advanced_Other_DimensionWidth.Size = new System.Drawing.Size(53, 20);
            this.Advanced_Other_DimensionWidth.TabIndex = 14;
            this.Advanced_Other_DimensionWidth.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // Advanced_Other_DimensionWidthLabel
            // 
            this.Advanced_Other_DimensionWidthLabel.AutoSize = true;
            this.Advanced_Other_DimensionWidthLabel.Location = new System.Drawing.Point(33, 105);
            this.Advanced_Other_DimensionWidthLabel.Name = "Advanced_Other_DimensionWidthLabel";
            this.Advanced_Other_DimensionWidthLabel.Size = new System.Drawing.Size(121, 13);
            this.Advanced_Other_DimensionWidthLabel.TabIndex = 13;
            this.Advanced_Other_DimensionWidthLabel.Text = "Dimension widget width:";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Enabled = false;
            this.checkBox5.Location = new System.Drawing.Point(260, 27);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(78, 17);
            this.checkBox5.TabIndex = 11;
            this.checkBox5.Text = "Stacktrace";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.Visible = false;
            // 
            // Advanced_Other_EnableScheduler
            // 
            this.Advanced_Other_EnableScheduler.AutoSize = true;
            this.Advanced_Other_EnableScheduler.Location = new System.Drawing.Point(17, 50);
            this.Advanced_Other_EnableScheduler.Name = "Advanced_Other_EnableScheduler";
            this.Advanced_Other_EnableScheduler.Size = new System.Drawing.Size(187, 17);
            this.Advanced_Other_EnableScheduler.TabIndex = 10;
            this.Advanced_Other_EnableScheduler.Text = "Enable Event && Scheduler System";
            this.Advanced_Other_EnableScheduler.UseVisualStyleBackColor = true;
            this.Advanced_Other_EnableScheduler.CheckedChanged += new System.EventHandler(this.Advanced_Other_EnableScheduler_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(257, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "minutes";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(198, 77);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(53, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Warn if splitting an entry less than";
            // 
            // Advanced_Other_SortExtProjectAsNumber
            // 
            this.Advanced_Other_SortExtProjectAsNumber.AutoSize = true;
            this.Advanced_Other_SortExtProjectAsNumber.Location = new System.Drawing.Point(17, 27);
            this.Advanced_Other_SortExtProjectAsNumber.Name = "Advanced_Other_SortExtProjectAsNumber";
            this.Advanced_Other_SortExtProjectAsNumber.Size = new System.Drawing.Size(229, 17);
            this.Advanced_Other_SortExtProjectAsNumber.TabIndex = 2;
            this.Advanced_Other_SortExtProjectAsNumber.Text = "Treat External Project Number as a number";
            this.Advanced_Other_SortExtProjectAsNumber.UseVisualStyleBackColor = true;
            // 
            // LoggingGroup
            // 
            this.LoggingGroup.Controls.Add(this.label17);
            this.LoggingGroup.Controls.Add(this.ViewLog);
            this.LoggingGroup.Controls.Add(this.Advanced_Logging_Database);
            this.LoggingGroup.Controls.Add(this.LoggingDatabaseLabel);
            this.LoggingGroup.Controls.Add(this.Advanced_Logging_Application);
            this.LoggingGroup.Controls.Add(this.LoggingApplicationLabel);
            this.LoggingGroup.Location = new System.Drawing.Point(17, 16);
            this.LoggingGroup.Name = "LoggingGroup";
            this.LoggingGroup.Size = new System.Drawing.Size(345, 115);
            this.LoggingGroup.TabIndex = 2;
            this.LoggingGroup.TabStop = false;
            this.LoggingGroup.Text = "Logging";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(14, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(304, 13);
            this.label17.TabIndex = 5;
            this.label17.Text = "Note: Changing the logging level requires a Timekeeper restart.";
            // 
            // ViewLog
            // 
            this.ViewLog.Location = new System.Drawing.Point(252, 36);
            this.ViewLog.Name = "ViewLog";
            this.ViewLog.Size = new System.Drawing.Size(75, 23);
            this.ViewLog.TabIndex = 4;
            this.ViewLog.Text = "View Log...";
            this.ViewLog.UseVisualStyleBackColor = true;
            this.ViewLog.Click += new System.EventHandler(this.ViewLog_Click);
            // 
            // Advanced_Logging_Database
            // 
            this.Advanced_Logging_Database.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Advanced_Logging_Database.FormattingEnabled = true;
            this.Advanced_Logging_Database.Items.AddRange(new object[] {
            "None",
            "Debug",
            "Info",
            "Warn",
            "Error"});
            this.Advanced_Logging_Database.Location = new System.Drawing.Point(111, 52);
            this.Advanced_Logging_Database.Name = "Advanced_Logging_Database";
            this.Advanced_Logging_Database.Size = new System.Drawing.Size(121, 21);
            this.Advanced_Logging_Database.TabIndex = 3;
            // 
            // LoggingDatabaseLabel
            // 
            this.LoggingDatabaseLabel.AutoSize = true;
            this.LoggingDatabaseLabel.Location = new System.Drawing.Point(14, 55);
            this.LoggingDatabaseLabel.Name = "LoggingDatabaseLabel";
            this.LoggingDatabaseLabel.Size = new System.Drawing.Size(56, 13);
            this.LoggingDatabaseLabel.TabIndex = 1;
            this.LoggingDatabaseLabel.Text = "Database:";
            // 
            // Advanced_Logging_Application
            // 
            this.Advanced_Logging_Application.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Advanced_Logging_Application.FormattingEnabled = true;
            this.Advanced_Logging_Application.Items.AddRange(new object[] {
            "None",
            "Debug",
            "Info",
            "Warn",
            "Error"});
            this.Advanced_Logging_Application.Location = new System.Drawing.Point(111, 25);
            this.Advanced_Logging_Application.Name = "Advanced_Logging_Application";
            this.Advanced_Logging_Application.Size = new System.Drawing.Size(121, 21);
            this.Advanced_Logging_Application.TabIndex = 2;
            // 
            // LoggingApplicationLabel
            // 
            this.LoggingApplicationLabel.AutoSize = true;
            this.LoggingApplicationLabel.Location = new System.Drawing.Point(14, 28);
            this.LoggingApplicationLabel.Name = "LoggingApplicationLabel";
            this.LoggingApplicationLabel.Size = new System.Drawing.Size(62, 13);
            this.LoggingApplicationLabel.TabIndex = 0;
            this.LoggingApplicationLabel.Text = "Application:";
            // 
            // MailSettingsPage
            // 
            this.MailSettingsPage.Controls.Add(this.groupBox2);
            this.MailSettingsPage.Controls.Add(this.groupBox1);
            this.MailSettingsPage.Location = new System.Drawing.Point(98, 4);
            this.MailSettingsPage.Name = "MailSettingsPage";
            this.MailSettingsPage.Padding = new System.Windows.Forms.Padding(3);
            this.MailSettingsPage.Size = new System.Drawing.Size(393, 412);
            this.MailSettingsPage.TabIndex = 6;
            this.MailSettingsPage.Text = "Mail Settings";
            this.MailSettingsPage.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.Mail_Subject);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.Mail_FromAddress);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.Mail_FromDisplayAddress);
            this.groupBox2.Location = new System.Drawing.Point(17, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(345, 115);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mail && SMS Message";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(14, 54);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "From Display:";
            // 
            // Mail_FromAddress
            // 
            this.Mail_FromAddress.Location = new System.Drawing.Point(111, 25);
            this.Mail_FromAddress.Name = "Mail_FromAddress";
            this.Mail_FromAddress.Size = new System.Drawing.Size(215, 20);
            this.Mail_FromAddress.TabIndex = 1;
            this.Mail_FromAddress.Text = "from@example.com";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 28);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "From Address:";
            // 
            // Mail_FromDisplayAddress
            // 
            this.Mail_FromDisplayAddress.Location = new System.Drawing.Point(111, 51);
            this.Mail_FromDisplayAddress.Name = "Mail_FromDisplayAddress";
            this.Mail_FromDisplayAddress.Size = new System.Drawing.Size(215, 20);
            this.Mail_FromDisplayAddress.TabIndex = 2;
            this.Mail_FromDisplayAddress.Text = "Timekeeper Notification";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.Mail_SmtpTimeout);
            this.groupBox1.Controls.Add(this.Mail_SmtpServerPassword);
            this.groupBox1.Controls.Add(this.Mail_SmtpServerUsername);
            this.groupBox1.Controls.Add(this.Mail_SmtpServerRequiresSSL);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Mail_SmtpPort);
            this.groupBox1.Controls.Add(this.Mail_SmtpServer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(17, 137);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(345, 179);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Server Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(161, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Seconds";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 146);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Password:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "SMTP Timeout:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 120);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Username:";
            // 
            // Mail_SmtpTimeout
            // 
            this.Mail_SmtpTimeout.Location = new System.Drawing.Point(111, 77);
            this.Mail_SmtpTimeout.Name = "Mail_SmtpTimeout";
            this.Mail_SmtpTimeout.Size = new System.Drawing.Size(47, 20);
            this.Mail_SmtpTimeout.TabIndex = 7;
            this.Mail_SmtpTimeout.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // Mail_SmtpServerPassword
            // 
            this.Mail_SmtpServerPassword.Location = new System.Drawing.Point(111, 143);
            this.Mail_SmtpServerPassword.Name = "Mail_SmtpServerPassword";
            this.Mail_SmtpServerPassword.Size = new System.Drawing.Size(215, 20);
            this.Mail_SmtpServerPassword.TabIndex = 9;
            this.Mail_SmtpServerPassword.Text = "password";
            this.Mail_SmtpServerPassword.UseSystemPasswordChar = true;
            // 
            // Mail_SmtpServerUsername
            // 
            this.Mail_SmtpServerUsername.Location = new System.Drawing.Point(111, 117);
            this.Mail_SmtpServerUsername.Name = "Mail_SmtpServerUsername";
            this.Mail_SmtpServerUsername.Size = new System.Drawing.Size(215, 20);
            this.Mail_SmtpServerUsername.TabIndex = 8;
            this.Mail_SmtpServerUsername.Text = "username";
            // 
            // Mail_SmtpServerRequiresSSL
            // 
            this.Mail_SmtpServerRequiresSSL.AutoSize = true;
            this.Mail_SmtpServerRequiresSSL.Location = new System.Drawing.Point(164, 54);
            this.Mail_SmtpServerRequiresSSL.Name = "Mail_SmtpServerRequiresSSL";
            this.Mail_SmtpServerRequiresSSL.Size = new System.Drawing.Size(91, 17);
            this.Mail_SmtpServerRequiresSSL.TabIndex = 6;
            this.Mail_SmtpServerRequiresSSL.Text = "Requires SSL";
            this.Mail_SmtpServerRequiresSSL.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "SMTP Port:";
            // 
            // Mail_SmtpPort
            // 
            this.Mail_SmtpPort.Location = new System.Drawing.Point(111, 51);
            this.Mail_SmtpPort.Name = "Mail_SmtpPort";
            this.Mail_SmtpPort.Size = new System.Drawing.Size(47, 20);
            this.Mail_SmtpPort.TabIndex = 5;
            this.Mail_SmtpPort.Text = "25";
            // 
            // Mail_SmtpServer
            // 
            this.Mail_SmtpServer.Location = new System.Drawing.Point(111, 25);
            this.Mail_SmtpServer.Name = "Mail_SmtpServer";
            this.Mail_SmtpServer.Size = new System.Drawing.Size(215, 20);
            this.Mail_SmtpServer.TabIndex = 4;
            this.Mail_SmtpServer.Text = "smtp.example.com";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "SMTP Server:";
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "SET AT RUN TIME";
            // 
            // Mail_Subject
            // 
            this.Mail_Subject.Location = new System.Drawing.Point(111, 77);
            this.Mail_Subject.Name = "Mail_Subject";
            this.Mail_Subject.Size = new System.Drawing.Size(215, 20);
            this.Mail_Subject.TabIndex = 3;
            this.Mail_Subject.Text = "Reminder";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(14, 80);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 13);
            this.label21.TabIndex = 22;
            this.label21.Text = "Subject Line:";
            // 
            // Options
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(519, 467);
            this.Controls.Add(this.AcceptDialogButton);
            this.Controls.Add(this.CancelDialogButton);
            this.Controls.Add(this.OptionsPanelCollection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.OptionsPanelCollection.ResumeLayout(false);
            this.LayoutPage.ResumeLayout(false);
            this.PresetGroup.ResumeLayout(false);
            this.PresetGroup.PerformLayout();
            this.DimensionGroup.ResumeLayout(false);
            this.DimensionGroup.PerformLayout();
            this.ViewPage.ResumeLayout(false);
            this.MainViewGroup.ResumeLayout(false);
            this.MainViewGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ViewSpacerBox)).EndInit();
            this.MemoEditorGroup.ResumeLayout(false);
            this.MemoEditorGroup.PerformLayout();
            this.StatusBarGroup.ResumeLayout(false);
            this.StatusBarGroup_BottomPanel.ResumeLayout(false);
            this.StatusBarGroup_BottomPanel.PerformLayout();
            this.StatusBarGroup_CategoryElapsedPanel.ResumeLayout(false);
            this.StatusBarGroup_CategoryElapsedPanel.PerformLayout();
            this.StatusBarGroup_LocationElapsedPanel.ResumeLayout(false);
            this.StatusBarGroup_LocationElapsedPanel.PerformLayout();
            this.StatusBarGroup_ActivityElapsedPanel.ResumeLayout(false);
            this.StatusBarGroup_ActivityElapsedPanel.PerformLayout();
            this.StatusBarGroup_ProjectElapsedPanel.ResumeLayout(false);
            this.StatusBarGroup_ProjectElapsedPanel.PerformLayout();
            this.StatusBarGroup_ElapsedPanel.ResumeLayout(false);
            this.StatusBarGroup_ElapsedPanel.PerformLayout();
            this.StatusBarGroup_CategoryNamePanel.ResumeLayout(false);
            this.StatusBarGroup_CategoryNamePanel.PerformLayout();
            this.StatusBarGroup_LocationNamePanel.ResumeLayout(false);
            this.StatusBarGroup_LocationNamePanel.PerformLayout();
            this.StatusBarGroup_ActivityNamePanel.ResumeLayout(false);
            this.StatusBarGroup_ActivityNamePanel.PerformLayout();
            this.StatusBarGroup_ProjectNamePanel.ResumeLayout(false);
            this.StatusBarGroup_ProjectNamePanel.PerformLayout();
            this.HiddenGroup.ResumeLayout(false);
            this.HiddenGroup_EventPanel.ResumeLayout(false);
            this.HiddenGroup_EventPanel.PerformLayout();
            this.HiddenGroup_TodoPanel.ResumeLayout(false);
            this.HiddenGroup_TodoPanel.PerformLayout();
            this.HiddenGroup_CategoryPanel.ResumeLayout(false);
            this.HiddenGroup_CategoryPanel.PerformLayout();
            this.HiddenGroup_LocationPanel.ResumeLayout(false);
            this.HiddenGroup_LocationPanel.PerformLayout();
            this.HiddenGroup_ActivityPanel.ResumeLayout(false);
            this.HiddenGroup_ActivityPanel.PerformLayout();
            this.HiddenGroup_ProjectPanel.ResumeLayout(false);
            this.HiddenGroup_ProjectPanel.PerformLayout();
            this.BehaviorPage.ResumeLayout(false);
            this.AnnoyGroup.ResumeLayout(false);
            this.AnnoyGroup_CategoryFollowPanel.ResumeLayout(false);
            this.AnnoyGroup_CategoryFollowPanel.PerformLayout();
            this.AnnoyGroup_LocationFollowPanel.ResumeLayout(false);
            this.AnnoyGroup_LocationFollowPanel.PerformLayout();
            this.AnnoyGroup_ActivityFollowPanel.ResumeLayout(false);
            this.AnnoyGroup_ActivityFollowPanel.PerformLayout();
            this.AnnoyGroup_TopPanel.ResumeLayout(false);
            this.AnnoyGroup_TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Behavior_Annoy_NoRunningPromptAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BehaviorSpacingBox)).EndInit();
            this.BrowsingGroup.ResumeLayout(false);
            this.BrowsingGroup.PerformLayout();
            this.SortingGroup.ResumeLayout(false);
            this.SortingGroup_BottomPanel.ResumeLayout(false);
            this.SortingGroup_BottomPanel.PerformLayout();
            this.SortingGroup_ProjectPanel.ResumeLayout(false);
            this.SortingGroup_ProjectPanel.PerformLayout();
            this.WindowControlGroup.ResumeLayout(false);
            this.WindowControlGroup.PerformLayout();
            this.TitleBarGroup.ResumeLayout(false);
            this.TitleBarGroup.PerformLayout();
            this.ReportPage.ResumeLayout(false);
            this.ReportGroup.ResumeLayout(false);
            this.ReportGroup.PerformLayout();
            this.KeyboardPage.ResumeLayout(false);
            this.ShortcutGroup.ResumeLayout(false);
            this.ShortcutGroup.PerformLayout();
            this.AdvancedPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AdvancedSpacerBox)).EndInit();
            this.AdvancedFormattingGroup.ResumeLayout(false);
            this.AdvancedFormattingGroup.PerformLayout();
            this.OtherAdvancedGroup.ResumeLayout(false);
            this.OtherAdvancedGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Advanced_Other_DimensionWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.LoggingGroup.ResumeLayout(false);
            this.LoggingGroup.PerformLayout();
            this.MailSettingsPage.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Mail_SmtpTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button AcceptDialogButton;
        //        private Forms.Controls.TablessControl tablessControl1;
        private System.Windows.Forms.TabControl OptionsPanelCollection;
        private System.Windows.Forms.TabPage ViewPage;
        private System.Windows.Forms.TabPage ReportPage;
        private System.Windows.Forms.CheckBox View_StatusBar;
        private System.Windows.Forms.CheckBox View_StatusBar_ActivityName;
        private System.Windows.Forms.CheckBox View_StatusBar_ProjectName;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedAllToday;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedActivityToday;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedProjectToday;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedSinceStart;
        private System.Windows.Forms.TabPage LayoutPage;
        private System.Windows.Forms.GroupBox DimensionGroup;
        private System.Windows.Forms.GroupBox PresetGroup;
        private System.Windows.Forms.RadioButton Layout_Preset_TheWorks;
        private System.Windows.Forms.RadioButton Layout_Preset_Typical;
        private System.Windows.Forms.RadioButton Layout_Preset_Simple;
        private System.Windows.Forms.CheckBox View_StatusBar_FileName;
        private System.Windows.Forms.CheckBox Layout_UseCategories;
        private System.Windows.Forms.CheckBox Layout_UseLocations;
        private System.Windows.Forms.CheckBox Layout_UseActivities;
        private System.Windows.Forms.CheckBox Layout_UseProjects;
        private System.Windows.Forms.ComboBox View_HiddenProjectsSince;
        private System.Windows.Forms.CheckBox View_HiddenCategories;
        private System.Windows.Forms.CheckBox View_HiddenLocations;
        private System.Windows.Forms.CheckBox View_HiddenActivities;
        private System.Windows.Forms.CheckBox View_HiddenProjects;
        private System.Windows.Forms.GroupBox SortingGroup;
        private System.Windows.Forms.Label SortProjectsLabel;
        private System.Windows.Forms.ComboBox Behavior_SortProjectsBy;
        private System.Windows.Forms.ComboBox View_HiddenCategoriesSince;
        private System.Windows.Forms.ComboBox View_HiddenLocationsSince;
        private System.Windows.Forms.ComboBox View_HiddenActivitiesSince;
        private System.Windows.Forms.TabPage BehaviorPage;
        private System.Windows.Forms.GroupBox WindowControlGroup;
        private System.Windows.Forms.CheckBox Behavior_Window_MinimizeOnUse;
        private System.Windows.Forms.CheckBox Behavior_Window_MinimizeToTray;
        private System.Windows.Forms.CheckBox Behavior_Window_ShowInTray;
        private System.Windows.Forms.GroupBox TitleBarGroup;
        private System.Windows.Forms.TextBox Behavior_TitleBar_Template;
        private System.Windows.Forms.Label TitleBarTemplateLabel;
        private System.Windows.Forms.Label Report_StyleSheetFileLabel;
        private System.Windows.Forms.GroupBox AnnoyGroup;
        private System.Windows.Forms.Label MinutesLabel;
        private System.Windows.Forms.NumericUpDown Behavior_Annoy_NoRunningPromptAmount;
        private System.Windows.Forms.CheckBox Behavior_Annoy_NoRunningPrompt;
        private System.Windows.Forms.TabPage KeyboardPage;
        public System.Windows.Forms.ListView FunctionList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox ShortcutGroup;
        private System.Windows.Forms.Button RemoveKey;
        private System.Windows.Forms.ComboBox KeyCode;
        private System.Windows.Forms.CheckBox ShiftKey;
        private System.Windows.Forms.CheckBox ControlKey;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label PresetInstructionsLabel;
        private System.Windows.Forms.ComboBox Behavior_SortProjectsByDirection;
        private System.Windows.Forms.ImageList SmallImages;
        private System.Windows.Forms.CheckBox AltKey;
        private System.Windows.Forms.Button AssignKey;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox Behavior_Annoy_PromptBeforeHiding;
        private System.Windows.Forms.TabPage AdvancedPage;
        private System.Windows.Forms.GroupBox LoggingGroup;
        private System.Windows.Forms.Button ViewLog;
        private System.Windows.Forms.ComboBox Advanced_Logging_Database;
        private System.Windows.Forms.ComboBox Advanced_Logging_Application;
        private System.Windows.Forms.Label LoggingApplicationLabel;
        private System.Windows.Forms.Label LoggingDatabaseLabel;
        private System.Windows.Forms.GroupBox OtherAdvancedGroup;
        private System.Windows.Forms.GroupBox StatusBarGroup;
        private System.Windows.Forms.GroupBox HiddenGroup;
        private System.Windows.Forms.GroupBox ReportGroup;
        private System.Windows.Forms.Panel HiddenGroup_CategoryPanel;
        private System.Windows.Forms.Panel HiddenGroup_LocationPanel;
        private System.Windows.Forms.Panel HiddenGroup_ActivityPanel;
        private System.Windows.Forms.Panel HiddenGroup_ProjectPanel;
        private System.Windows.Forms.Panel StatusBarGroup_ElapsedPanel;
        private System.Windows.Forms.Panel StatusBarGroup_ActivityNamePanel;
        private System.Windows.Forms.Panel StatusBarGroup_ProjectNamePanel;
        private System.Windows.Forms.Panel StatusBarGroup_ProjectElapsedPanel;
        private System.Windows.Forms.Panel StatusBarGroup_BottomPanel;
        private System.Windows.Forms.Panel StatusBarGroup_ActivityElapsedPanel;
        private System.Windows.Forms.Panel SortingGroup_ProjectPanel;
        private System.Windows.Forms.Label DisplayLabel;
        private System.Windows.Forms.ComboBox Behavior_TitleBar_Time;
        private System.Windows.Forms.Label DimensionsInstructionsLabel;
        private System.Windows.Forms.CheckBox Advanced_Other_SortExtProjectAsNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox Behavior_Annoy_UseNewDatabaseWizard;
        private System.Windows.Forms.TabPage MailSettingsPage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox Mail_SmtpServerRequiresSSL;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Mail_SmtpPort;
        private System.Windows.Forms.TextBox Mail_SmtpServer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Mail_FromAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Mail_FromDisplayAddress;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Mail_SmtpServerPassword;
        private System.Windows.Forms.TextBox Mail_SmtpServerUsername;
        private System.Windows.Forms.GroupBox MemoEditorGroup;
        private System.Windows.Forms.CheckBox View_MemoEditor_ShowToolbar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown Mail_SmtpTimeout;
        private System.Windows.Forms.ComboBox Advanced_MarkupLanguage;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox Advanced_Other_EnableScheduler;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.GroupBox BrowsingGroup;
        private System.Windows.Forms.ComboBox Behavior_BrowseNextBy;
        private System.Windows.Forms.ComboBox Behavior_BrowsePrevBy;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox View_MemoEditor_ShowGutter;
        private System.Windows.Forms.Button View_MemoEditor_FontButton;
        private System.Windows.Forms.FontDialog FontDialog;
        private System.Windows.Forms.PictureBox ViewSpacerBox;
        private System.Windows.Forms.TextBox View_MemoEditor_Font;
        private System.Windows.Forms.PictureBox BehaviorSpacingBox;
        private System.Windows.Forms.GroupBox MainViewGroup;
        private System.Windows.Forms.CheckBox View_ControlPanel;
        private System.Windows.Forms.CheckBox View_BrowserToolbar;
        private System.Windows.Forms.CheckBox View_MemoEditor;
        private System.Windows.Forms.CheckBox Behavior_Annoy_CategoryFollowsProject;
        private System.Windows.Forms.CheckBox Behavior_Annoy_LocationFollowsProject;
        private System.Windows.Forms.CheckBox Behavior_Annoy_ActivityFollowsProject;
        private System.Windows.Forms.Panel AnnoyGroup_TopPanel;
        private System.Windows.Forms.NumericUpDown Advanced_Other_DimensionWidth;
        private System.Windows.Forms.Label Advanced_Other_DimensionWidthLabel;
        private System.Windows.Forms.Panel AnnoyGroup_CategoryFollowPanel;
        private System.Windows.Forms.Panel AnnoyGroup_LocationFollowPanel;
        private System.Windows.Forms.Panel AnnoyGroup_ActivityFollowPanel;
        private System.Windows.Forms.TextBox Report_StyleSheetFile;
        private System.Windows.Forms.Panel StatusBarGroup_CategoryElapsedPanel;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedCategoryToday;
        private System.Windows.Forms.Panel StatusBarGroup_LocationElapsedPanel;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedLocationToday;
        private System.Windows.Forms.Panel StatusBarGroup_CategoryNamePanel;
        private System.Windows.Forms.CheckBox View_StatusBar_CategoryName;
        private System.Windows.Forms.Panel StatusBarGroup_LocationNamePanel;
        private System.Windows.Forms.CheckBox View_StatusBar_LocationName;
        private System.Windows.Forms.ComboBox Advanced_Other_MidnightOffset;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel HiddenGroup_EventPanel;
        private System.Windows.Forms.CheckBox View_HiddenEvents;
        private System.Windows.Forms.ComboBox View_HiddenEventsSince;
        private System.Windows.Forms.Panel HiddenGroup_TodoPanel;
        private System.Windows.Forms.CheckBox View_HiddenTodoItems;
        private System.Windows.Forms.ComboBox View_HiddenTodoItemsSince;
        private System.Windows.Forms.PictureBox AdvancedSpacerBox;
        private System.Windows.Forms.GroupBox AdvancedFormattingGroup;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox Advanced_BreakTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox Report_Font;
        private System.Windows.Forms.Button Report_FontButton;
        private System.Windows.Forms.Button Report_StyleSheetFileChooser;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Button Report_LayoutFileChooser;
        private System.Windows.Forms.TextBox Report_LayoutFile;
        private System.Windows.Forms.Label Report_LayoutFileLabel;
        private System.Windows.Forms.ComboBox Behavior_SortProjectsThenByDirection;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox Behavior_SortProjectsThenBy;
        private System.Windows.Forms.Panel SortingGroup_BottomPanel;
        private System.Windows.Forms.ComboBox Behavior_SortItemsBy;
        private System.Windows.Forms.ComboBox Behavior_SortItemsByDirection;
        private System.Windows.Forms.Label SortItemsLabel;
        private System.Windows.Forms.CheckBox View_MemoEditor_ShowRuler;
        private System.Windows.Forms.ComboBox Advanced_DateTimeFormat;
        private System.Windows.Forms.RadioButton Layout_Preset_Minimal;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox Mail_Subject;

    }
}