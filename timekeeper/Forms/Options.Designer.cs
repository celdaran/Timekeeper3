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
            this.SortingGroup = new System.Windows.Forms.GroupBox();
            this.SortingGroup_BottomPanel = new System.Windows.Forms.Panel();
            this.Layout_SortItemsBy = new System.Windows.Forms.ComboBox();
            this.Layout_SortItemsByDirection = new System.Windows.Forms.ComboBox();
            this.SortItemsLabel = new System.Windows.Forms.Label();
            this.SortingGroup_ProjectPanel = new System.Windows.Forms.Panel();
            this.Layout_SortProjectsByDirection = new System.Windows.Forms.ComboBox();
            this.Layout_SortProjectsBy = new System.Windows.Forms.ComboBox();
            this.SortProjectsLabel = new System.Windows.Forms.Label();
            this.PresetGroup = new System.Windows.Forms.GroupBox();
            this.PresetInstructionsLabel = new System.Windows.Forms.Label();
            this.Layout_Preset_TheWorks = new System.Windows.Forms.RadioButton();
            this.Layout_Preset_Typical = new System.Windows.Forms.RadioButton();
            this.Layout_Preset_Simple = new System.Windows.Forms.RadioButton();
            this.DimensionGroup = new System.Windows.Forms.GroupBox();
            this.Layout_UseCategories = new System.Windows.Forms.CheckBox();
            this.Layout_UseLocations = new System.Windows.Forms.CheckBox();
            this.Layout_UseActivities = new System.Windows.Forms.CheckBox();
            this.Layout_UseProjects = new System.Windows.Forms.CheckBox();
            this.ViewPage = new System.Windows.Forms.TabPage();
            this.StatusBarGroup = new System.Windows.Forms.GroupBox();
            this.StatusBarGroup_BottomPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedAllToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_FileName = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ActivityElapsedPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedActivityToday = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ProjectElapsedPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedProjectToday = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ElapsedPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ElapsedSinceStart = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ActivityNamePanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ActivityName = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_ProjectNamePanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_ProjectName = new System.Windows.Forms.CheckBox();
            this.StatusBarGroup_TopPanel = new System.Windows.Forms.Panel();
            this.View_StatusBar_AddLabels = new System.Windows.Forms.CheckBox();
            this.View_StatusBar = new System.Windows.Forms.CheckBox();
            this.HiddenGroup = new System.Windows.Forms.GroupBox();
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
            this.AnnoyGroup_BottomPanel = new System.Windows.Forms.Panel();
            this.Behavior_Annoy_ActivityFollowsProject = new System.Windows.Forms.CheckBox();
            this.Behavior_Annoy_ProjectFollowsActivity = new System.Windows.Forms.CheckBox();
            this.AnnoyGroup_TopPanel = new System.Windows.Forms.Panel();
            this.MinutesLabel = new System.Windows.Forms.Label();
            this.Behavior_Annoy_PromptBeforeHiding = new System.Windows.Forms.CheckBox();
            this.Behavior_Annoy_NoRunningPrompt = new System.Windows.Forms.CheckBox();
            this.Behavior_Annoy_NoRunningPromptAmount = new System.Windows.Forms.NumericUpDown();
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
            this.LabelBaseFont = new System.Windows.Forms.Label();
            this.Report_StyleSheet = new System.Windows.Forms.RichTextBox();
            this.Report_FontList = new System.Windows.Forms.ListBox();
            this.LabelStyleSheet = new System.Windows.Forms.Label();
            this.LabelBaseFontSize = new System.Windows.Forms.Label();
            this.PointSizeLabel = new System.Windows.Forms.Label();
            this.Report_FontSize = new System.Windows.Forms.NumericUpDown();
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
            this.OtherGroup = new System.Windows.Forms.GroupBox();
            this.DateTimeFormatTemplate = new System.Windows.Forms.TextBox();
            this.LoggingGroup = new System.Windows.Forms.GroupBox();
            this.ViewLog = new System.Windows.Forms.Button();
            this.Advanced_Logging_Database = new System.Windows.Forms.ComboBox();
            this.Advanced_Logging_Application = new System.Windows.Forms.ComboBox();
            this.LoggingApplicationLabel = new System.Windows.Forms.Label();
            this.LoggingDatabaseLabel = new System.Windows.Forms.Label();
            this.DimensionsInstructionsLabel = new System.Windows.Forms.Label();
            this.OptionsPanelCollection.SuspendLayout();
            this.LayoutPage.SuspendLayout();
            this.SortingGroup.SuspendLayout();
            this.SortingGroup_BottomPanel.SuspendLayout();
            this.SortingGroup_ProjectPanel.SuspendLayout();
            this.PresetGroup.SuspendLayout();
            this.DimensionGroup.SuspendLayout();
            this.ViewPage.SuspendLayout();
            this.StatusBarGroup.SuspendLayout();
            this.StatusBarGroup_BottomPanel.SuspendLayout();
            this.StatusBarGroup_ActivityElapsedPanel.SuspendLayout();
            this.StatusBarGroup_ProjectElapsedPanel.SuspendLayout();
            this.StatusBarGroup_ElapsedPanel.SuspendLayout();
            this.StatusBarGroup_ActivityNamePanel.SuspendLayout();
            this.StatusBarGroup_ProjectNamePanel.SuspendLayout();
            this.StatusBarGroup_TopPanel.SuspendLayout();
            this.HiddenGroup.SuspendLayout();
            this.HiddenGroup_CategoryPanel.SuspendLayout();
            this.HiddenGroup_LocationPanel.SuspendLayout();
            this.HiddenGroup_ActivityPanel.SuspendLayout();
            this.HiddenGroup_ProjectPanel.SuspendLayout();
            this.BehaviorPage.SuspendLayout();
            this.AnnoyGroup.SuspendLayout();
            this.AnnoyGroup_BottomPanel.SuspendLayout();
            this.AnnoyGroup_TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Behavior_Annoy_NoRunningPromptAmount)).BeginInit();
            this.WindowControlGroup.SuspendLayout();
            this.TitleBarGroup.SuspendLayout();
            this.ReportPage.SuspendLayout();
            this.ReportGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_FontSize)).BeginInit();
            this.KeyboardPage.SuspendLayout();
            this.ShortcutGroup.SuspendLayout();
            this.AdvancedPage.SuspendLayout();
            this.OtherGroup.SuspendLayout();
            this.LoggingGroup.SuspendLayout();
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
            // SortingGroup
            // 
            this.SortingGroup.Controls.Add(this.SortingGroup_BottomPanel);
            this.SortingGroup.Controls.Add(this.SortingGroup_ProjectPanel);
            this.SortingGroup.Location = new System.Drawing.Point(17, 324);
            this.SortingGroup.Name = "SortingGroup";
            this.SortingGroup.Size = new System.Drawing.Size(363, 81);
            this.SortingGroup.TabIndex = 4;
            this.SortingGroup.TabStop = false;
            this.SortingGroup.Text = "Sorting";
            // 
            // SortingGroup_BottomPanel
            // 
            this.SortingGroup_BottomPanel.Controls.Add(this.Layout_SortItemsBy);
            this.SortingGroup_BottomPanel.Controls.Add(this.Layout_SortItemsByDirection);
            this.SortingGroup_BottomPanel.Controls.Add(this.SortItemsLabel);
            this.SortingGroup_BottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SortingGroup_BottomPanel.Location = new System.Drawing.Point(3, 43);
            this.SortingGroup_BottomPanel.Name = "SortingGroup_BottomPanel";
            this.SortingGroup_BottomPanel.Size = new System.Drawing.Size(357, 27);
            this.SortingGroup_BottomPanel.TabIndex = 1;
            // 
            // Layout_SortItemsBy
            // 
            this.Layout_SortItemsBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Layout_SortItemsBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Layout_SortItemsBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layout_SortItemsBy.FormattingEnabled = true;
            this.Layout_SortItemsBy.Location = new System.Drawing.Point(109, 3);
            this.Layout_SortItemsBy.Name = "Layout_SortItemsBy";
            this.Layout_SortItemsBy.Size = new System.Drawing.Size(146, 21);
            this.Layout_SortItemsBy.TabIndex = 18;
            // 
            // Layout_SortItemsByDirection
            // 
            this.Layout_SortItemsByDirection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Layout_SortItemsByDirection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Layout_SortItemsByDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layout_SortItemsByDirection.FormattingEnabled = true;
            this.Layout_SortItemsByDirection.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.Layout_SortItemsByDirection.Location = new System.Drawing.Point(261, 3);
            this.Layout_SortItemsByDirection.Name = "Layout_SortItemsByDirection";
            this.Layout_SortItemsByDirection.Size = new System.Drawing.Size(88, 21);
            this.Layout_SortItemsByDirection.TabIndex = 20;
            // 
            // SortItemsLabel
            // 
            this.SortItemsLabel.AutoSize = true;
            this.SortItemsLabel.Location = new System.Drawing.Point(11, 6);
            this.SortItemsLabel.Name = "SortItemsLabel";
            this.SortItemsLabel.Size = new System.Drawing.Size(57, 13);
            this.SortItemsLabel.TabIndex = 18;
            this.SortItemsLabel.Text = "Sort Items:";
            // 
            // SortingGroup_ProjectPanel
            // 
            this.SortingGroup_ProjectPanel.Controls.Add(this.Layout_SortProjectsByDirection);
            this.SortingGroup_ProjectPanel.Controls.Add(this.Layout_SortProjectsBy);
            this.SortingGroup_ProjectPanel.Controls.Add(this.SortProjectsLabel);
            this.SortingGroup_ProjectPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SortingGroup_ProjectPanel.Location = new System.Drawing.Point(3, 16);
            this.SortingGroup_ProjectPanel.Name = "SortingGroup_ProjectPanel";
            this.SortingGroup_ProjectPanel.Size = new System.Drawing.Size(357, 27);
            this.SortingGroup_ProjectPanel.TabIndex = 0;
            // 
            // Layout_SortProjectsByDirection
            // 
            this.Layout_SortProjectsByDirection.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Layout_SortProjectsByDirection.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Layout_SortProjectsByDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layout_SortProjectsByDirection.FormattingEnabled = true;
            this.Layout_SortProjectsByDirection.Items.AddRange(new object[] {
            "Ascending",
            "Descending"});
            this.Layout_SortProjectsByDirection.Location = new System.Drawing.Point(261, 3);
            this.Layout_SortProjectsByDirection.Name = "Layout_SortProjectsByDirection";
            this.Layout_SortProjectsByDirection.Size = new System.Drawing.Size(88, 21);
            this.Layout_SortProjectsByDirection.TabIndex = 19;
            // 
            // Layout_SortProjectsBy
            // 
            this.Layout_SortProjectsBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Layout_SortProjectsBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Layout_SortProjectsBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layout_SortProjectsBy.FormattingEnabled = true;
            this.Layout_SortProjectsBy.Location = new System.Drawing.Point(109, 3);
            this.Layout_SortProjectsBy.Name = "Layout_SortProjectsBy";
            this.Layout_SortProjectsBy.Size = new System.Drawing.Size(146, 21);
            this.Layout_SortProjectsBy.TabIndex = 16;
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
            // PresetGroup
            // 
            this.PresetGroup.Controls.Add(this.PresetInstructionsLabel);
            this.PresetGroup.Controls.Add(this.Layout_Preset_TheWorks);
            this.PresetGroup.Controls.Add(this.Layout_Preset_Simple);
            this.PresetGroup.Controls.Add(this.Layout_Preset_Typical);
            this.PresetGroup.Location = new System.Drawing.Point(17, 16);
            this.PresetGroup.Name = "PresetGroup";
            this.PresetGroup.Size = new System.Drawing.Size(363, 125);
            this.PresetGroup.TabIndex = 3;
            this.PresetGroup.TabStop = false;
            this.PresetGroup.Text = "Interface Presets";
            // 
            // PresetInstructionsLabel
            // 
            this.PresetInstructionsLabel.AutoSize = true;
            this.PresetInstructionsLabel.Location = new System.Drawing.Point(127, 33);
            this.PresetInstructionsLabel.Name = "PresetInstructionsLabel";
            this.PresetInstructionsLabel.Size = new System.Drawing.Size(230, 65);
            this.PresetInstructionsLabel.TabIndex = 3;
            this.PresetInstructionsLabel.Text = resources.GetString("PresetInstructionsLabel.Text");
            // 
            // Layout_Preset_TheWorks
            // 
            this.Layout_Preset_TheWorks.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_Preset_TheWorks.Location = new System.Drawing.Point(17, 86);
            this.Layout_Preset_TheWorks.Name = "Layout_Preset_TheWorks";
            this.Layout_Preset_TheWorks.Size = new System.Drawing.Size(90, 23);
            this.Layout_Preset_TheWorks.TabIndex = 2;
            this.Layout_Preset_TheWorks.Text = "The Works";
            this.Layout_Preset_TheWorks.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_Preset_TheWorks.UseVisualStyleBackColor = true;
            this.Layout_Preset_TheWorks.Click += new System.EventHandler(this.Layout_Preset_TheWorks_Click);
            // 
            // Layout_Preset_Typical
            // 
            this.Layout_Preset_Typical.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_Preset_Typical.Location = new System.Drawing.Point(17, 57);
            this.Layout_Preset_Typical.Name = "Layout_Preset_Typical";
            this.Layout_Preset_Typical.Size = new System.Drawing.Size(90, 23);
            this.Layout_Preset_Typical.TabIndex = 1;
            this.Layout_Preset_Typical.Text = "Typical";
            this.Layout_Preset_Typical.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_Preset_Typical.UseVisualStyleBackColor = true;
            this.Layout_Preset_Typical.Click += new System.EventHandler(this.Layout_Preset_Typical_Click);
            // 
            // Layout_Preset_Simple
            // 
            this.Layout_Preset_Simple.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_Preset_Simple.Location = new System.Drawing.Point(17, 28);
            this.Layout_Preset_Simple.Name = "Layout_Preset_Simple";
            this.Layout_Preset_Simple.Size = new System.Drawing.Size(90, 23);
            this.Layout_Preset_Simple.TabIndex = 0;
            this.Layout_Preset_Simple.Text = "Simple";
            this.Layout_Preset_Simple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_Preset_Simple.UseVisualStyleBackColor = true;
            this.Layout_Preset_Simple.Click += new System.EventHandler(this.Layout_Preset_Simple_Click);
            // 
            // DimensionGroup
            // 
            this.DimensionGroup.Controls.Add(this.DimensionsInstructionsLabel);
            this.DimensionGroup.Controls.Add(this.Layout_UseCategories);
            this.DimensionGroup.Controls.Add(this.Layout_UseLocations);
            this.DimensionGroup.Controls.Add(this.Layout_UseActivities);
            this.DimensionGroup.Controls.Add(this.Layout_UseProjects);
            this.DimensionGroup.Location = new System.Drawing.Point(17, 159);
            this.DimensionGroup.Name = "DimensionGroup";
            this.DimensionGroup.Size = new System.Drawing.Size(363, 151);
            this.DimensionGroup.TabIndex = 0;
            this.DimensionGroup.TabStop = false;
            this.DimensionGroup.Text = "Timetracking Dimensions";
            // 
            // Layout_UseCategories
            // 
            this.Layout_UseCategories.Appearance = System.Windows.Forms.Appearance.Button;
            this.Layout_UseCategories.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Layout_UseCategories.Location = new System.Drawing.Point(17, 115);
            this.Layout_UseCategories.Name = "Layout_UseCategories";
            this.Layout_UseCategories.Size = new System.Drawing.Size(90, 23);
            this.Layout_UseCategories.TabIndex = 9;
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
            this.Layout_UseLocations.TabIndex = 8;
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
            this.Layout_UseActivities.TabIndex = 7;
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
            this.Layout_UseProjects.TabIndex = 6;
            this.Layout_UseProjects.Text = "Use Projects";
            this.Layout_UseProjects.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Layout_UseProjects.UseVisualStyleBackColor = true;
            this.Layout_UseProjects.CheckedChanged += new System.EventHandler(this.Layout_UseProjects_CheckedChanged);
            // 
            // ViewPage
            // 
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
            // StatusBarGroup
            // 
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_BottomPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ActivityElapsedPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ProjectElapsedPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ElapsedPanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ActivityNamePanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_ProjectNamePanel);
            this.StatusBarGroup.Controls.Add(this.StatusBarGroup_TopPanel);
            this.StatusBarGroup.Location = new System.Drawing.Point(17, 16);
            this.StatusBarGroup.Name = "StatusBarGroup";
            this.StatusBarGroup.Size = new System.Drawing.Size(363, 208);
            this.StatusBarGroup.TabIndex = 20;
            this.StatusBarGroup.TabStop = false;
            this.StatusBarGroup.Text = "Status Bar";
            // 
            // StatusBarGroup_BottomPanel
            // 
            this.StatusBarGroup_BottomPanel.Controls.Add(this.View_StatusBar_ElapsedAllToday);
            this.StatusBarGroup_BottomPanel.Controls.Add(this.View_StatusBar_FileName);
            this.StatusBarGroup_BottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_BottomPanel.Location = new System.Drawing.Point(3, 154);
            this.StatusBarGroup_BottomPanel.Name = "StatusBarGroup_BottomPanel";
            this.StatusBarGroup_BottomPanel.Size = new System.Drawing.Size(357, 46);
            this.StatusBarGroup_BottomPanel.TabIndex = 6;
            // 
            // View_StatusBar_ElapsedAllToday
            // 
            this.View_StatusBar_ElapsedAllToday.AutoSize = true;
            this.View_StatusBar_ElapsedAllToday.Enabled = false;
            this.View_StatusBar_ElapsedAllToday.Location = new System.Drawing.Point(33, 4);
            this.View_StatusBar_ElapsedAllToday.Name = "View_StatusBar_ElapsedAllToday";
            this.View_StatusBar_ElapsedAllToday.Size = new System.Drawing.Size(141, 17);
            this.View_StatusBar_ElapsedAllToday.TabIndex = 6;
            this.View_StatusBar_ElapsedAllToday.Text = "Total elapsed time today";
            this.View_StatusBar_ElapsedAllToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_FileName
            // 
            this.View_StatusBar_FileName.AutoSize = true;
            this.View_StatusBar_FileName.Enabled = false;
            this.View_StatusBar_FileName.Location = new System.Drawing.Point(33, 27);
            this.View_StatusBar_FileName.Name = "View_StatusBar_FileName";
            this.View_StatusBar_FileName.Size = new System.Drawing.Size(115, 17);
            this.View_StatusBar_FileName.TabIndex = 10;
            this.View_StatusBar_FileName.Text = "Current opened file";
            this.View_StatusBar_FileName.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ActivityElapsedPanel
            // 
            this.StatusBarGroup_ActivityElapsedPanel.Controls.Add(this.View_StatusBar_ElapsedActivityToday);
            this.StatusBarGroup_ActivityElapsedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ActivityElapsedPanel.Location = new System.Drawing.Point(3, 131);
            this.StatusBarGroup_ActivityElapsedPanel.Name = "StatusBarGroup_ActivityElapsedPanel";
            this.StatusBarGroup_ActivityElapsedPanel.Size = new System.Drawing.Size(357, 23);
            this.StatusBarGroup_ActivityElapsedPanel.TabIndex = 5;
            // 
            // View_StatusBar_ElapsedActivityToday
            // 
            this.View_StatusBar_ElapsedActivityToday.AutoSize = true;
            this.View_StatusBar_ElapsedActivityToday.Enabled = false;
            this.View_StatusBar_ElapsedActivityToday.Location = new System.Drawing.Point(33, 4);
            this.View_StatusBar_ElapsedActivityToday.Name = "View_StatusBar_ElapsedActivityToday";
            this.View_StatusBar_ElapsedActivityToday.Size = new System.Drawing.Size(181, 17);
            this.View_StatusBar_ElapsedActivityToday.TabIndex = 5;
            this.View_StatusBar_ElapsedActivityToday.Text = "Elapsed today for current Activity";
            this.View_StatusBar_ElapsedActivityToday.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ProjectElapsedPanel
            // 
            this.StatusBarGroup_ProjectElapsedPanel.Controls.Add(this.View_StatusBar_ElapsedProjectToday);
            this.StatusBarGroup_ProjectElapsedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ProjectElapsedPanel.Location = new System.Drawing.Point(3, 108);
            this.StatusBarGroup_ProjectElapsedPanel.Name = "StatusBarGroup_ProjectElapsedPanel";
            this.StatusBarGroup_ProjectElapsedPanel.Size = new System.Drawing.Size(357, 23);
            this.StatusBarGroup_ProjectElapsedPanel.TabIndex = 4;
            // 
            // View_StatusBar_ElapsedProjectToday
            // 
            this.View_StatusBar_ElapsedProjectToday.AutoSize = true;
            this.View_StatusBar_ElapsedProjectToday.Enabled = false;
            this.View_StatusBar_ElapsedProjectToday.Location = new System.Drawing.Point(33, 4);
            this.View_StatusBar_ElapsedProjectToday.Name = "View_StatusBar_ElapsedProjectToday";
            this.View_StatusBar_ElapsedProjectToday.Size = new System.Drawing.Size(180, 17);
            this.View_StatusBar_ElapsedProjectToday.TabIndex = 4;
            this.View_StatusBar_ElapsedProjectToday.Text = "Elapsed today for current Project";
            this.View_StatusBar_ElapsedProjectToday.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ElapsedPanel
            // 
            this.StatusBarGroup_ElapsedPanel.Controls.Add(this.View_StatusBar_ElapsedSinceStart);
            this.StatusBarGroup_ElapsedPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ElapsedPanel.Location = new System.Drawing.Point(3, 85);
            this.StatusBarGroup_ElapsedPanel.Name = "StatusBarGroup_ElapsedPanel";
            this.StatusBarGroup_ElapsedPanel.Size = new System.Drawing.Size(357, 23);
            this.StatusBarGroup_ElapsedPanel.TabIndex = 3;
            // 
            // View_StatusBar_ElapsedSinceStart
            // 
            this.View_StatusBar_ElapsedSinceStart.AutoSize = true;
            this.View_StatusBar_ElapsedSinceStart.Enabled = false;
            this.View_StatusBar_ElapsedSinceStart.Location = new System.Drawing.Point(33, 4);
            this.View_StatusBar_ElapsedSinceStart.Name = "View_StatusBar_ElapsedSinceStart";
            this.View_StatusBar_ElapsedSinceStart.Size = new System.Drawing.Size(152, 17);
            this.View_StatusBar_ElapsedSinceStart.TabIndex = 3;
            this.View_StatusBar_ElapsedSinceStart.Text = "Elapsed since timer started";
            this.View_StatusBar_ElapsedSinceStart.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ActivityNamePanel
            // 
            this.StatusBarGroup_ActivityNamePanel.Controls.Add(this.View_StatusBar_ActivityName);
            this.StatusBarGroup_ActivityNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ActivityNamePanel.Location = new System.Drawing.Point(3, 62);
            this.StatusBarGroup_ActivityNamePanel.Name = "StatusBarGroup_ActivityNamePanel";
            this.StatusBarGroup_ActivityNamePanel.Size = new System.Drawing.Size(357, 23);
            this.StatusBarGroup_ActivityNamePanel.TabIndex = 2;
            // 
            // View_StatusBar_ActivityName
            // 
            this.View_StatusBar_ActivityName.AutoSize = true;
            this.View_StatusBar_ActivityName.Enabled = false;
            this.View_StatusBar_ActivityName.Location = new System.Drawing.Point(33, 4);
            this.View_StatusBar_ActivityName.Name = "View_StatusBar_ActivityName";
            this.View_StatusBar_ActivityName.Size = new System.Drawing.Size(126, 17);
            this.View_StatusBar_ActivityName.TabIndex = 2;
            this.View_StatusBar_ActivityName.Text = "Current Activity name";
            this.View_StatusBar_ActivityName.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_ProjectNamePanel
            // 
            this.StatusBarGroup_ProjectNamePanel.Controls.Add(this.View_StatusBar_ProjectName);
            this.StatusBarGroup_ProjectNamePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_ProjectNamePanel.Location = new System.Drawing.Point(3, 39);
            this.StatusBarGroup_ProjectNamePanel.Name = "StatusBarGroup_ProjectNamePanel";
            this.StatusBarGroup_ProjectNamePanel.Size = new System.Drawing.Size(357, 23);
            this.StatusBarGroup_ProjectNamePanel.TabIndex = 1;
            // 
            // View_StatusBar_ProjectName
            // 
            this.View_StatusBar_ProjectName.AutoSize = true;
            this.View_StatusBar_ProjectName.Enabled = false;
            this.View_StatusBar_ProjectName.Location = new System.Drawing.Point(33, 4);
            this.View_StatusBar_ProjectName.Name = "View_StatusBar_ProjectName";
            this.View_StatusBar_ProjectName.Size = new System.Drawing.Size(125, 17);
            this.View_StatusBar_ProjectName.TabIndex = 1;
            this.View_StatusBar_ProjectName.Text = "Current Project name";
            this.View_StatusBar_ProjectName.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup_TopPanel
            // 
            this.StatusBarGroup_TopPanel.Controls.Add(this.View_StatusBar_AddLabels);
            this.StatusBarGroup_TopPanel.Controls.Add(this.View_StatusBar);
            this.StatusBarGroup_TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.StatusBarGroup_TopPanel.Location = new System.Drawing.Point(3, 16);
            this.StatusBarGroup_TopPanel.Name = "StatusBarGroup_TopPanel";
            this.StatusBarGroup_TopPanel.Size = new System.Drawing.Size(357, 23);
            this.StatusBarGroup_TopPanel.TabIndex = 0;
            // 
            // View_StatusBar_AddLabels
            // 
            this.View_StatusBar_AddLabels.AutoSize = true;
            this.View_StatusBar_AddLabels.Enabled = false;
            this.View_StatusBar_AddLabels.Location = new System.Drawing.Point(221, 4);
            this.View_StatusBar_AddLabels.Name = "View_StatusBar_AddLabels";
            this.View_StatusBar_AddLabels.Size = new System.Drawing.Size(79, 17);
            this.View_StatusBar_AddLabels.TabIndex = 11;
            this.View_StatusBar_AddLabels.Text = "Add Labels";
            this.View_StatusBar_AddLabels.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar
            // 
            this.View_StatusBar.AutoSize = true;
            this.View_StatusBar.Location = new System.Drawing.Point(14, 4);
            this.View_StatusBar.Name = "View_StatusBar";
            this.View_StatusBar.Size = new System.Drawing.Size(75, 17);
            this.View_StatusBar.TabIndex = 0;
            this.View_StatusBar.Text = "Status Bar";
            this.View_StatusBar.UseVisualStyleBackColor = true;
            this.View_StatusBar.CheckedChanged += new System.EventHandler(this.View_StatusBar_CheckedChanged);
            // 
            // HiddenGroup
            // 
            this.HiddenGroup.Controls.Add(this.HiddenGroup_CategoryPanel);
            this.HiddenGroup.Controls.Add(this.HiddenGroup_LocationPanel);
            this.HiddenGroup.Controls.Add(this.HiddenGroup_ActivityPanel);
            this.HiddenGroup.Controls.Add(this.HiddenGroup_ProjectPanel);
            this.HiddenGroup.Location = new System.Drawing.Point(17, 230);
            this.HiddenGroup.Name = "HiddenGroup";
            this.HiddenGroup.Size = new System.Drawing.Size(363, 131);
            this.HiddenGroup.TabIndex = 19;
            this.HiddenGroup.TabStop = false;
            this.HiddenGroup.Text = "Hidden Items";
            // 
            // HiddenGroup_CategoryPanel
            // 
            this.HiddenGroup_CategoryPanel.Controls.Add(this.View_HiddenCategories);
            this.HiddenGroup_CategoryPanel.Controls.Add(this.View_HiddenCategoriesSince);
            this.HiddenGroup_CategoryPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroup_CategoryPanel.Location = new System.Drawing.Point(3, 97);
            this.HiddenGroup_CategoryPanel.Name = "HiddenGroup_CategoryPanel";
            this.HiddenGroup_CategoryPanel.Size = new System.Drawing.Size(357, 27);
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
            this.View_HiddenCategoriesSince.Location = new System.Drawing.Point(221, 2);
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
            this.HiddenGroup_LocationPanel.Size = new System.Drawing.Size(357, 27);
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
            this.View_HiddenLocationsSince.Location = new System.Drawing.Point(221, 2);
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
            this.HiddenGroup_ActivityPanel.Size = new System.Drawing.Size(357, 27);
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
            this.View_HiddenActivitiesSince.Location = new System.Drawing.Point(221, 2);
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
            this.HiddenGroup_ProjectPanel.Size = new System.Drawing.Size(357, 27);
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
            this.View_HiddenProjectsSince.Location = new System.Drawing.Point(221, 2);
            this.View_HiddenProjectsSince.Name = "View_HiddenProjectsSince";
            this.View_HiddenProjectsSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenProjectsSince.TabIndex = 15;
            // 
            // BehaviorPage
            // 
            this.BehaviorPage.Controls.Add(this.SortingGroup);
            this.BehaviorPage.Controls.Add(this.AnnoyGroup);
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
            this.AnnoyGroup.Controls.Add(this.AnnoyGroup_BottomPanel);
            this.AnnoyGroup.Controls.Add(this.AnnoyGroup_TopPanel);
            this.AnnoyGroup.Location = new System.Drawing.Point(17, 201);
            this.AnnoyGroup.Name = "AnnoyGroup";
            this.AnnoyGroup.Size = new System.Drawing.Size(363, 116);
            this.AnnoyGroup.TabIndex = 2;
            this.AnnoyGroup.TabStop = false;
            this.AnnoyGroup.Text = "Annoyances";
            // 
            // AnnoyGroup_BottomPanel
            // 
            this.AnnoyGroup_BottomPanel.Controls.Add(this.Behavior_Annoy_ActivityFollowsProject);
            this.AnnoyGroup_BottomPanel.Controls.Add(this.Behavior_Annoy_ProjectFollowsActivity);
            this.AnnoyGroup_BottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnnoyGroup_BottomPanel.Location = new System.Drawing.Point(3, 63);
            this.AnnoyGroup_BottomPanel.Name = "AnnoyGroup_BottomPanel";
            this.AnnoyGroup_BottomPanel.Size = new System.Drawing.Size(357, 46);
            this.AnnoyGroup_BottomPanel.TabIndex = 1;
            // 
            // Behavior_Annoy_ActivityFollowsProject
            // 
            this.Behavior_Annoy_ActivityFollowsProject.AutoSize = true;
            this.Behavior_Annoy_ActivityFollowsProject.Location = new System.Drawing.Point(14, 4);
            this.Behavior_Annoy_ActivityFollowsProject.Name = "Behavior_Annoy_ActivityFollowsProject";
            this.Behavior_Annoy_ActivityFollowsProject.Size = new System.Drawing.Size(174, 17);
            this.Behavior_Annoy_ActivityFollowsProject.TabIndex = 3;
            this.Behavior_Annoy_ActivityFollowsProject.Text = "Activity follows selected Project";
            this.Behavior_Annoy_ActivityFollowsProject.UseVisualStyleBackColor = true;
            // 
            // Behavior_Annoy_ProjectFollowsActivity
            // 
            this.Behavior_Annoy_ProjectFollowsActivity.AutoSize = true;
            this.Behavior_Annoy_ProjectFollowsActivity.Location = new System.Drawing.Point(14, 27);
            this.Behavior_Annoy_ProjectFollowsActivity.Name = "Behavior_Annoy_ProjectFollowsActivity";
            this.Behavior_Annoy_ProjectFollowsActivity.Size = new System.Drawing.Size(174, 17);
            this.Behavior_Annoy_ProjectFollowsActivity.TabIndex = 4;
            this.Behavior_Annoy_ProjectFollowsActivity.Text = "Project follows selected Activity";
            this.Behavior_Annoy_ProjectFollowsActivity.UseVisualStyleBackColor = true;
            // 
            // AnnoyGroup_TopPanel
            // 
            this.AnnoyGroup_TopPanel.Controls.Add(this.MinutesLabel);
            this.AnnoyGroup_TopPanel.Controls.Add(this.Behavior_Annoy_PromptBeforeHiding);
            this.AnnoyGroup_TopPanel.Controls.Add(this.Behavior_Annoy_NoRunningPrompt);
            this.AnnoyGroup_TopPanel.Controls.Add(this.Behavior_Annoy_NoRunningPromptAmount);
            this.AnnoyGroup_TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AnnoyGroup_TopPanel.Location = new System.Drawing.Point(3, 16);
            this.AnnoyGroup_TopPanel.Name = "AnnoyGroup_TopPanel";
            this.AnnoyGroup_TopPanel.Size = new System.Drawing.Size(357, 47);
            this.AnnoyGroup_TopPanel.TabIndex = 0;
            // 
            // MinutesLabel
            // 
            this.MinutesLabel.AutoSize = true;
            this.MinutesLabel.Location = new System.Drawing.Point(248, 28);
            this.MinutesLabel.Name = "MinutesLabel";
            this.MinutesLabel.Size = new System.Drawing.Size(43, 13);
            this.MinutesLabel.TabIndex = 7;
            this.MinutesLabel.Text = "minutes";
            // 
            // Behavior_Annoy_PromptBeforeHiding
            // 
            this.Behavior_Annoy_PromptBeforeHiding.AutoSize = true;
            this.Behavior_Annoy_PromptBeforeHiding.Location = new System.Drawing.Point(14, 4);
            this.Behavior_Annoy_PromptBeforeHiding.Name = "Behavior_Annoy_PromptBeforeHiding";
            this.Behavior_Annoy_PromptBeforeHiding.Size = new System.Drawing.Size(150, 17);
            this.Behavior_Annoy_PromptBeforeHiding.TabIndex = 8;
            this.Behavior_Annoy_PromptBeforeHiding.Text = "Prompt before hiding items";
            this.Behavior_Annoy_PromptBeforeHiding.UseVisualStyleBackColor = true;
            // 
            // Behavior_Annoy_NoRunningPrompt
            // 
            this.Behavior_Annoy_NoRunningPrompt.AutoSize = true;
            this.Behavior_Annoy_NoRunningPrompt.Location = new System.Drawing.Point(14, 27);
            this.Behavior_Annoy_NoRunningPrompt.Name = "Behavior_Annoy_NoRunningPrompt";
            this.Behavior_Annoy_NoRunningPrompt.Size = new System.Drawing.Size(169, 17);
            this.Behavior_Annoy_NoRunningPrompt.TabIndex = 5;
            this.Behavior_Annoy_NoRunningPrompt.Text = "Prompt if no timer running after";
            this.Behavior_Annoy_NoRunningPrompt.UseVisualStyleBackColor = true;
            this.Behavior_Annoy_NoRunningPrompt.CheckedChanged += new System.EventHandler(this.Behavior_Annoy_NoRunningPrompt_CheckedChanged);
            // 
            // Behavior_Annoy_NoRunningPromptAmount
            // 
            this.Behavior_Annoy_NoRunningPromptAmount.Location = new System.Drawing.Point(189, 26);
            this.Behavior_Annoy_NoRunningPromptAmount.Name = "Behavior_Annoy_NoRunningPromptAmount";
            this.Behavior_Annoy_NoRunningPromptAmount.Size = new System.Drawing.Size(53, 20);
            this.Behavior_Annoy_NoRunningPromptAmount.TabIndex = 6;
            // 
            // WindowControlGroup
            // 
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_MinimizeOnUse);
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_MinimizeToTray);
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_ShowInTray);
            this.WindowControlGroup.Location = new System.Drawing.Point(17, 107);
            this.WindowControlGroup.Name = "WindowControlGroup";
            this.WindowControlGroup.Size = new System.Drawing.Size(363, 88);
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
            this.TitleBarGroup.Size = new System.Drawing.Size(363, 85);
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
            this.Behavior_TitleBar_Time.Size = new System.Drawing.Size(241, 21);
            this.Behavior_TitleBar_Time.TabIndex = 6;
            // 
            // Behavior_TitleBar_Template
            // 
            this.Behavior_TitleBar_Template.Location = new System.Drawing.Point(111, 25);
            this.Behavior_TitleBar_Template.Name = "Behavior_TitleBar_Template";
            this.Behavior_TitleBar_Template.Size = new System.Drawing.Size(240, 20);
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
            this.ReportGroup.Controls.Add(this.LabelBaseFont);
            this.ReportGroup.Controls.Add(this.Report_StyleSheet);
            this.ReportGroup.Controls.Add(this.Report_FontList);
            this.ReportGroup.Controls.Add(this.LabelStyleSheet);
            this.ReportGroup.Controls.Add(this.LabelBaseFontSize);
            this.ReportGroup.Controls.Add(this.PointSizeLabel);
            this.ReportGroup.Controls.Add(this.Report_FontSize);
            this.ReportGroup.Location = new System.Drawing.Point(17, 16);
            this.ReportGroup.Name = "ReportGroup";
            this.ReportGroup.Size = new System.Drawing.Size(363, 374);
            this.ReportGroup.TabIndex = 7;
            this.ReportGroup.TabStop = false;
            this.ReportGroup.Text = "Styling";
            // 
            // LabelBaseFont
            // 
            this.LabelBaseFont.AutoSize = true;
            this.LabelBaseFont.Location = new System.Drawing.Point(14, 28);
            this.LabelBaseFont.Name = "LabelBaseFont";
            this.LabelBaseFont.Size = new System.Drawing.Size(58, 13);
            this.LabelBaseFont.TabIndex = 0;
            this.LabelBaseFont.Text = "Base Font:";
            // 
            // Report_StyleSheet
            // 
            this.Report_StyleSheet.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Report_StyleSheet.Location = new System.Drawing.Point(111, 175);
            this.Report_StyleSheet.Name = "Report_StyleSheet";
            this.Report_StyleSheet.ReadOnly = true;
            this.Report_StyleSheet.Size = new System.Drawing.Size(238, 182);
            this.Report_StyleSheet.TabIndex = 6;
            this.Report_StyleSheet.Text = "Paste custom CSS style sheet here for more control over report appearance. See th" +
    "e help file for more details and samples.";
            // 
            // Report_FontList
            // 
            this.Report_FontList.FormattingEnabled = true;
            this.Report_FontList.Location = new System.Drawing.Point(111, 25);
            this.Report_FontList.Name = "Report_FontList";
            this.Report_FontList.Size = new System.Drawing.Size(238, 95);
            this.Report_FontList.TabIndex = 1;
            // 
            // LabelStyleSheet
            // 
            this.LabelStyleSheet.AutoSize = true;
            this.LabelStyleSheet.Location = new System.Drawing.Point(14, 175);
            this.LabelStyleSheet.Name = "LabelStyleSheet";
            this.LabelStyleSheet.Size = new System.Drawing.Size(61, 13);
            this.LabelStyleSheet.TabIndex = 5;
            this.LabelStyleSheet.Text = "Style Sheet";
            // 
            // LabelBaseFontSize
            // 
            this.LabelBaseFontSize.AutoSize = true;
            this.LabelBaseFontSize.Location = new System.Drawing.Point(14, 139);
            this.LabelBaseFontSize.Name = "LabelBaseFontSize";
            this.LabelBaseFontSize.Size = new System.Drawing.Size(81, 13);
            this.LabelBaseFontSize.TabIndex = 2;
            this.LabelBaseFontSize.Text = "Base Font Size:";
            // 
            // PointSizeLabel
            // 
            this.PointSizeLabel.AutoSize = true;
            this.PointSizeLabel.Location = new System.Drawing.Point(181, 139);
            this.PointSizeLabel.Name = "PointSizeLabel";
            this.PointSizeLabel.Size = new System.Drawing.Size(36, 13);
            this.PointSizeLabel.TabIndex = 4;
            this.PointSizeLabel.Text = "Points";
            // 
            // Report_FontSize
            // 
            this.Report_FontSize.Location = new System.Drawing.Point(111, 137);
            this.Report_FontSize.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.Report_FontSize.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.Report_FontSize.Name = "Report_FontSize";
            this.Report_FontSize.Size = new System.Drawing.Size(69, 20);
            this.Report_FontSize.TabIndex = 3;
            this.Report_FontSize.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
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
            this.AdvancedPage.Controls.Add(this.OtherGroup);
            this.AdvancedPage.Controls.Add(this.LoggingGroup);
            this.AdvancedPage.Location = new System.Drawing.Point(98, 4);
            this.AdvancedPage.Name = "AdvancedPage";
            this.AdvancedPage.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedPage.Size = new System.Drawing.Size(393, 412);
            this.AdvancedPage.TabIndex = 5;
            this.AdvancedPage.Text = "Advanced";
            this.AdvancedPage.UseVisualStyleBackColor = true;
            // 
            // OtherGroup
            // 
            this.OtherGroup.Controls.Add(this.DateTimeFormatTemplate);
            this.OtherGroup.Location = new System.Drawing.Point(17, 117);
            this.OtherGroup.Name = "OtherGroup";
            this.OtherGroup.Size = new System.Drawing.Size(363, 100);
            this.OtherGroup.TabIndex = 3;
            this.OtherGroup.TabStop = false;
            this.OtherGroup.Text = "Other";
            // 
            // DateTimeFormatTemplate
            // 
            this.DateTimeFormatTemplate.Location = new System.Drawing.Point(51, 45);
            this.DateTimeFormatTemplate.Name = "DateTimeFormatTemplate";
            this.DateTimeFormatTemplate.Size = new System.Drawing.Size(252, 20);
            this.DateTimeFormatTemplate.TabIndex = 0;
            this.DateTimeFormatTemplate.Text = "CUSTOM DATE/TIME FORMAT GOES HERE";
            // 
            // LoggingGroup
            // 
            this.LoggingGroup.Controls.Add(this.ViewLog);
            this.LoggingGroup.Controls.Add(this.Advanced_Logging_Database);
            this.LoggingGroup.Controls.Add(this.LoggingDatabaseLabel);
            this.LoggingGroup.Controls.Add(this.Advanced_Logging_Application);
            this.LoggingGroup.Controls.Add(this.LoggingApplicationLabel);
            this.LoggingGroup.Location = new System.Drawing.Point(17, 16);
            this.LoggingGroup.Name = "LoggingGroup";
            this.LoggingGroup.Size = new System.Drawing.Size(363, 87);
            this.LoggingGroup.TabIndex = 2;
            this.LoggingGroup.TabStop = false;
            this.LoggingGroup.Text = "Logging";
            // 
            // ViewLog
            // 
            this.ViewLog.Location = new System.Drawing.Point(260, 36);
            this.ViewLog.Name = "ViewLog";
            this.ViewLog.Size = new System.Drawing.Size(75, 23);
            this.ViewLog.TabIndex = 4;
            this.ViewLog.Text = "View Log";
            this.ViewLog.UseVisualStyleBackColor = true;
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
            // LoggingDatabaseLabel
            // 
            this.LoggingDatabaseLabel.AutoSize = true;
            this.LoggingDatabaseLabel.Location = new System.Drawing.Point(14, 55);
            this.LoggingDatabaseLabel.Name = "LoggingDatabaseLabel";
            this.LoggingDatabaseLabel.Size = new System.Drawing.Size(56, 13);
            this.LoggingDatabaseLabel.TabIndex = 1;
            this.LoggingDatabaseLabel.Text = "Database:";
            // 
            // DimensionsInstructionsLabel
            // 
            this.DimensionsInstructionsLabel.AutoSize = true;
            this.DimensionsInstructionsLabel.Location = new System.Drawing.Point(127, 33);
            this.DimensionsInstructionsLabel.Name = "DimensionsInstructionsLabel";
            this.DimensionsInstructionsLabel.Size = new System.Drawing.Size(230, 65);
            this.DimensionsInstructionsLabel.TabIndex = 4;
            this.DimensionsInstructionsLabel.Text = resources.GetString("DimensionsInstructionsLabel.Text");
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
            this.HelpButton = true;
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
            this.SortingGroup.ResumeLayout(false);
            this.SortingGroup_BottomPanel.ResumeLayout(false);
            this.SortingGroup_BottomPanel.PerformLayout();
            this.SortingGroup_ProjectPanel.ResumeLayout(false);
            this.SortingGroup_ProjectPanel.PerformLayout();
            this.PresetGroup.ResumeLayout(false);
            this.PresetGroup.PerformLayout();
            this.DimensionGroup.ResumeLayout(false);
            this.DimensionGroup.PerformLayout();
            this.ViewPage.ResumeLayout(false);
            this.StatusBarGroup.ResumeLayout(false);
            this.StatusBarGroup_BottomPanel.ResumeLayout(false);
            this.StatusBarGroup_BottomPanel.PerformLayout();
            this.StatusBarGroup_ActivityElapsedPanel.ResumeLayout(false);
            this.StatusBarGroup_ActivityElapsedPanel.PerformLayout();
            this.StatusBarGroup_ProjectElapsedPanel.ResumeLayout(false);
            this.StatusBarGroup_ProjectElapsedPanel.PerformLayout();
            this.StatusBarGroup_ElapsedPanel.ResumeLayout(false);
            this.StatusBarGroup_ElapsedPanel.PerformLayout();
            this.StatusBarGroup_ActivityNamePanel.ResumeLayout(false);
            this.StatusBarGroup_ActivityNamePanel.PerformLayout();
            this.StatusBarGroup_ProjectNamePanel.ResumeLayout(false);
            this.StatusBarGroup_ProjectNamePanel.PerformLayout();
            this.StatusBarGroup_TopPanel.ResumeLayout(false);
            this.StatusBarGroup_TopPanel.PerformLayout();
            this.HiddenGroup.ResumeLayout(false);
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
            this.AnnoyGroup_BottomPanel.ResumeLayout(false);
            this.AnnoyGroup_BottomPanel.PerformLayout();
            this.AnnoyGroup_TopPanel.ResumeLayout(false);
            this.AnnoyGroup_TopPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Behavior_Annoy_NoRunningPromptAmount)).EndInit();
            this.WindowControlGroup.ResumeLayout(false);
            this.WindowControlGroup.PerformLayout();
            this.TitleBarGroup.ResumeLayout(false);
            this.TitleBarGroup.PerformLayout();
            this.ReportPage.ResumeLayout(false);
            this.ReportGroup.ResumeLayout(false);
            this.ReportGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_FontSize)).EndInit();
            this.KeyboardPage.ResumeLayout(false);
            this.ShortcutGroup.ResumeLayout(false);
            this.ShortcutGroup.PerformLayout();
            this.AdvancedPage.ResumeLayout(false);
            this.OtherGroup.ResumeLayout(false);
            this.OtherGroup.PerformLayout();
            this.LoggingGroup.ResumeLayout(false);
            this.LoggingGroup.PerformLayout();
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
        private System.Windows.Forms.Label SortItemsLabel;
        private System.Windows.Forms.ComboBox Layout_SortItemsBy;
        private System.Windows.Forms.Label SortProjectsLabel;
        private System.Windows.Forms.ComboBox Layout_SortProjectsBy;
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
        private System.Windows.Forms.RichTextBox Report_StyleSheet;
        private System.Windows.Forms.Label LabelStyleSheet;
        private System.Windows.Forms.Label PointSizeLabel;
        private System.Windows.Forms.NumericUpDown Report_FontSize;
        private System.Windows.Forms.Label LabelBaseFontSize;
        private System.Windows.Forms.ListBox Report_FontList;
        private System.Windows.Forms.Label LabelBaseFont;
        private System.Windows.Forms.GroupBox AnnoyGroup;
        private System.Windows.Forms.Label MinutesLabel;
        private System.Windows.Forms.NumericUpDown Behavior_Annoy_NoRunningPromptAmount;
        private System.Windows.Forms.CheckBox Behavior_Annoy_NoRunningPrompt;
        private System.Windows.Forms.CheckBox Behavior_Annoy_ProjectFollowsActivity;
        private System.Windows.Forms.CheckBox Behavior_Annoy_ActivityFollowsProject;
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
        private System.Windows.Forms.ComboBox Layout_SortProjectsByDirection;
        private System.Windows.Forms.ComboBox Layout_SortItemsByDirection;
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
        private System.Windows.Forms.GroupBox OtherGroup;
        private System.Windows.Forms.TextBox DateTimeFormatTemplate;
        private System.Windows.Forms.GroupBox StatusBarGroup;
        private System.Windows.Forms.CheckBox View_StatusBar_AddLabels;
        private System.Windows.Forms.GroupBox HiddenGroup;
        private System.Windows.Forms.GroupBox ReportGroup;
        private System.Windows.Forms.Panel HiddenGroup_CategoryPanel;
        private System.Windows.Forms.Panel HiddenGroup_LocationPanel;
        private System.Windows.Forms.Panel HiddenGroup_ActivityPanel;
        private System.Windows.Forms.Panel HiddenGroup_ProjectPanel;
        private System.Windows.Forms.Panel StatusBarGroup_TopPanel;
        private System.Windows.Forms.Panel StatusBarGroup_ElapsedPanel;
        private System.Windows.Forms.Panel StatusBarGroup_ActivityNamePanel;
        private System.Windows.Forms.Panel StatusBarGroup_ProjectNamePanel;
        private System.Windows.Forms.Panel StatusBarGroup_ProjectElapsedPanel;
        private System.Windows.Forms.Panel StatusBarGroup_BottomPanel;
        private System.Windows.Forms.Panel StatusBarGroup_ActivityElapsedPanel;
        private System.Windows.Forms.Panel SortingGroup_BottomPanel;
        private System.Windows.Forms.Panel SortingGroup_ProjectPanel;
        private System.Windows.Forms.Panel AnnoyGroup_BottomPanel;
        private System.Windows.Forms.Panel AnnoyGroup_TopPanel;
        private System.Windows.Forms.Label DisplayLabel;
        private System.Windows.Forms.ComboBox Behavior_TitleBar_Time;
        private System.Windows.Forms.Label DimensionsInstructionsLabel;

    }
}