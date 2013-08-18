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
            this.Layout_SortProjectsByDirection = new System.Windows.Forms.ComboBox();
            this.Layout_SortItemsByDirection = new System.Windows.Forms.ComboBox();
            this.Label_SortOther = new System.Windows.Forms.Label();
            this.Layout_SortItemsBy = new System.Windows.Forms.ComboBox();
            this.Label_SortProjects = new System.Windows.Forms.Label();
            this.Layout_SortProjectsBy = new System.Windows.Forms.ComboBox();
            this.PresetGroup = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
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
            this.View_StatusBar_AddLabels = new System.Windows.Forms.CheckBox();
            this.View_StatusBar = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ProjectName = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_FileName = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ActivityName = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedAllToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedSinceStart = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedActivityToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedProjectToday = new System.Windows.Forms.CheckBox();
            this.HiddenGroup = new System.Windows.Forms.GroupBox();
            this.View_HiddenProjects = new System.Windows.Forms.CheckBox();
            this.View_HiddenCategoriesSince = new System.Windows.Forms.ComboBox();
            this.View_HiddenActivities = new System.Windows.Forms.CheckBox();
            this.View_HiddenLocationsSince = new System.Windows.Forms.ComboBox();
            this.View_HiddenLocations = new System.Windows.Forms.CheckBox();
            this.View_HiddenActivitiesSince = new System.Windows.Forms.ComboBox();
            this.View_HiddenCategories = new System.Windows.Forms.CheckBox();
            this.View_HiddenProjectsSince = new System.Windows.Forms.ComboBox();
            this.BehaviorPage = new System.Windows.Forms.TabPage();
            this.AnnoyGroup = new System.Windows.Forms.GroupBox();
            this.Behavior_Annoy_PromptBeforeHiding = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Behavior_Annoy_NoRunningPromptAmount = new System.Windows.Forms.NumericUpDown();
            this.Behavior_Annoy_NoRunningPrompt = new System.Windows.Forms.CheckBox();
            this.Behavior_Annoy_ProjectFollowsActivity = new System.Windows.Forms.CheckBox();
            this.Behavior_Annoy_ActivityFollowsProject = new System.Windows.Forms.CheckBox();
            this.WindowControlGroup = new System.Windows.Forms.GroupBox();
            this.Behavior_Window_MinimizeOnUse = new System.Windows.Forms.CheckBox();
            this.Behavior_Window_MinimizeToTray = new System.Windows.Forms.CheckBox();
            this.Behavior_Window_ShowInTray = new System.Windows.Forms.CheckBox();
            this.TitleBarGroup = new System.Windows.Forms.GroupBox();
            this.Behavior_TitleBar_Template = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.Behavior_TitleBar_ElapsedAllToday = new System.Windows.Forms.RadioButton();
            this.Behavior_TitleBar_ElapsedActivityToday = new System.Windows.Forms.RadioButton();
            this.Behavior_TitleBar_ElapsedProjectToday = new System.Windows.Forms.RadioButton();
            this.Behavior_TitleBar_ElapsedSinceStart = new System.Windows.Forms.RadioButton();
            this.ReportPage = new System.Windows.Forms.TabPage();
            this.ReportGroup = new System.Windows.Forms.GroupBox();
            this.LabelBaseFont = new System.Windows.Forms.Label();
            this.Report_StyleSheet = new System.Windows.Forms.RichTextBox();
            this.Report_FontList = new System.Windows.Forms.ListBox();
            this.LabelStyleSheet = new System.Windows.Forms.Label();
            this.LabelBaseFontSize = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Report_FontSize = new System.Windows.Forms.NumericUpDown();
            this.KeyboardPage = new System.Windows.Forms.TabPage();
            this.ShortcutGroup = new System.Windows.Forms.GroupBox();
            this.AssignKey = new System.Windows.Forms.Button();
            this.wAlt = new System.Windows.Forms.CheckBox();
            this.RemoveKey = new System.Windows.Forms.Button();
            this.wKey = new System.Windows.Forms.ComboBox();
            this.wShift = new System.Windows.Forms.CheckBox();
            this.wCtrl = new System.Windows.Forms.CheckBox();
            this.wFunctionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.AdvancedPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.LoggingGroup = new System.Windows.Forms.GroupBox();
            this.ViewLog = new System.Windows.Forms.Button();
            this.Advanced_Logging_Database = new System.Windows.Forms.ComboBox();
            this.Advanced_Logging_Application = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.HiddenGroupPanelProject = new System.Windows.Forms.Panel();
            this.HiddenGroupPanelActivity = new System.Windows.Forms.Panel();
            this.HiddenGroupPanelLocation = new System.Windows.Forms.Panel();
            this.HiddenGroupPanelCategory = new System.Windows.Forms.Panel();
            this.OptionsPanelCollection.SuspendLayout();
            this.LayoutPage.SuspendLayout();
            this.SortingGroup.SuspendLayout();
            this.PresetGroup.SuspendLayout();
            this.DimensionGroup.SuspendLayout();
            this.ViewPage.SuspendLayout();
            this.StatusBarGroup.SuspendLayout();
            this.HiddenGroup.SuspendLayout();
            this.BehaviorPage.SuspendLayout();
            this.AnnoyGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Behavior_Annoy_NoRunningPromptAmount)).BeginInit();
            this.WindowControlGroup.SuspendLayout();
            this.TitleBarGroup.SuspendLayout();
            this.ReportPage.SuspendLayout();
            this.ReportGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_FontSize)).BeginInit();
            this.KeyboardPage.SuspendLayout();
            this.ShortcutGroup.SuspendLayout();
            this.AdvancedPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.LoggingGroup.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.HiddenGroupPanelProject.SuspendLayout();
            this.HiddenGroupPanelActivity.SuspendLayout();
            this.HiddenGroupPanelLocation.SuspendLayout();
            this.HiddenGroupPanelCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(432, 432);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 1;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(351, 432);
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
            this.OptionsPanelCollection.Size = new System.Drawing.Size(495, 413);
            this.OptionsPanelCollection.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.OptionsPanelCollection.TabIndex = 0;
            // 
            // LayoutPage
            // 
            this.LayoutPage.Controls.Add(this.SortingGroup);
            this.LayoutPage.Controls.Add(this.PresetGroup);
            this.LayoutPage.Controls.Add(this.DimensionGroup);
            this.LayoutPage.Location = new System.Drawing.Point(98, 4);
            this.LayoutPage.Name = "LayoutPage";
            this.LayoutPage.Padding = new System.Windows.Forms.Padding(3);
            this.LayoutPage.Size = new System.Drawing.Size(393, 405);
            this.LayoutPage.TabIndex = 2;
            this.LayoutPage.Text = "Layout";
            this.LayoutPage.UseVisualStyleBackColor = true;
            // 
            // SortingGroup
            // 
            this.SortingGroup.Controls.Add(this.Layout_SortProjectsByDirection);
            this.SortingGroup.Controls.Add(this.Layout_SortItemsByDirection);
            this.SortingGroup.Controls.Add(this.Label_SortOther);
            this.SortingGroup.Controls.Add(this.Layout_SortItemsBy);
            this.SortingGroup.Controls.Add(this.Label_SortProjects);
            this.SortingGroup.Controls.Add(this.Layout_SortProjectsBy);
            this.SortingGroup.Location = new System.Drawing.Point(17, 244);
            this.SortingGroup.Name = "SortingGroup";
            this.SortingGroup.Size = new System.Drawing.Size(363, 81);
            this.SortingGroup.TabIndex = 4;
            this.SortingGroup.TabStop = false;
            this.SortingGroup.Text = "Sorting";
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
            this.Layout_SortProjectsByDirection.Location = new System.Drawing.Point(264, 46);
            this.Layout_SortProjectsByDirection.Name = "Layout_SortProjectsByDirection";
            this.Layout_SortProjectsByDirection.Size = new System.Drawing.Size(88, 21);
            this.Layout_SortProjectsByDirection.TabIndex = 19;
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
            this.Layout_SortItemsByDirection.Location = new System.Drawing.Point(264, 19);
            this.Layout_SortItemsByDirection.Name = "Layout_SortItemsByDirection";
            this.Layout_SortItemsByDirection.Size = new System.Drawing.Size(88, 21);
            this.Layout_SortItemsByDirection.TabIndex = 20;
            // 
            // Label_SortOther
            // 
            this.Label_SortOther.AutoSize = true;
            this.Label_SortOther.Location = new System.Drawing.Point(17, 22);
            this.Label_SortOther.Name = "Label_SortOther";
            this.Label_SortOther.Size = new System.Drawing.Size(57, 13);
            this.Label_SortOther.TabIndex = 18;
            this.Label_SortOther.Text = "Sort Items:";
            // 
            // Layout_SortItemsBy
            // 
            this.Layout_SortItemsBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Layout_SortItemsBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Layout_SortItemsBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layout_SortItemsBy.FormattingEnabled = true;
            this.Layout_SortItemsBy.Location = new System.Drawing.Point(112, 19);
            this.Layout_SortItemsBy.Name = "Layout_SortItemsBy";
            this.Layout_SortItemsBy.Size = new System.Drawing.Size(146, 21);
            this.Layout_SortItemsBy.TabIndex = 18;
            // 
            // Label_SortProjects
            // 
            this.Label_SortProjects.AutoSize = true;
            this.Label_SortProjects.Location = new System.Drawing.Point(17, 49);
            this.Label_SortProjects.Name = "Label_SortProjects";
            this.Label_SortProjects.Size = new System.Drawing.Size(70, 13);
            this.Label_SortProjects.TabIndex = 17;
            this.Label_SortProjects.Text = "Sort Projects:";
            // 
            // Layout_SortProjectsBy
            // 
            this.Layout_SortProjectsBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Layout_SortProjectsBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Layout_SortProjectsBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layout_SortProjectsBy.FormattingEnabled = true;
            this.Layout_SortProjectsBy.Location = new System.Drawing.Point(112, 46);
            this.Layout_SortProjectsBy.Name = "Layout_SortProjectsBy";
            this.Layout_SortProjectsBy.Size = new System.Drawing.Size(146, 21);
            this.Layout_SortProjectsBy.TabIndex = 16;
            // 
            // PresetGroup
            // 
            this.PresetGroup.Controls.Add(this.label11);
            this.PresetGroup.Controls.Add(this.Layout_Preset_TheWorks);
            this.PresetGroup.Controls.Add(this.Layout_Preset_Typical);
            this.PresetGroup.Controls.Add(this.Layout_Preset_Simple);
            this.PresetGroup.Location = new System.Drawing.Point(17, 16);
            this.PresetGroup.Name = "PresetGroup";
            this.PresetGroup.Size = new System.Drawing.Size(363, 100);
            this.PresetGroup.TabIndex = 3;
            this.PresetGroup.TabStop = false;
            this.PresetGroup.Text = "Interface Presets";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(122, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(230, 65);
            this.label11.TabIndex = 3;
            this.label11.Text = resources.GetString("label11.Text");
            // 
            // Layout_Preset_TheWorks
            // 
            this.Layout_Preset_TheWorks.AutoSize = true;
            this.Layout_Preset_TheWorks.Location = new System.Drawing.Point(17, 65);
            this.Layout_Preset_TheWorks.Name = "Layout_Preset_TheWorks";
            this.Layout_Preset_TheWorks.Size = new System.Drawing.Size(78, 17);
            this.Layout_Preset_TheWorks.TabIndex = 2;
            this.Layout_Preset_TheWorks.Text = "The Works";
            this.Layout_Preset_TheWorks.UseVisualStyleBackColor = true;
            // 
            // Layout_Preset_Typical
            // 
            this.Layout_Preset_Typical.AutoSize = true;
            this.Layout_Preset_Typical.Location = new System.Drawing.Point(17, 42);
            this.Layout_Preset_Typical.Name = "Layout_Preset_Typical";
            this.Layout_Preset_Typical.Size = new System.Drawing.Size(59, 17);
            this.Layout_Preset_Typical.TabIndex = 1;
            this.Layout_Preset_Typical.Text = "Typical";
            this.Layout_Preset_Typical.UseVisualStyleBackColor = true;
            // 
            // Layout_Preset_Simple
            // 
            this.Layout_Preset_Simple.AutoSize = true;
            this.Layout_Preset_Simple.Checked = true;
            this.Layout_Preset_Simple.Location = new System.Drawing.Point(17, 19);
            this.Layout_Preset_Simple.Name = "Layout_Preset_Simple";
            this.Layout_Preset_Simple.Size = new System.Drawing.Size(56, 17);
            this.Layout_Preset_Simple.TabIndex = 0;
            this.Layout_Preset_Simple.TabStop = true;
            this.Layout_Preset_Simple.Text = "Simple";
            this.Layout_Preset_Simple.UseVisualStyleBackColor = true;
            // 
            // DimensionGroup
            // 
            this.DimensionGroup.Controls.Add(this.Layout_UseCategories);
            this.DimensionGroup.Controls.Add(this.Layout_UseLocations);
            this.DimensionGroup.Controls.Add(this.Layout_UseActivities);
            this.DimensionGroup.Controls.Add(this.Layout_UseProjects);
            this.DimensionGroup.Location = new System.Drawing.Point(17, 122);
            this.DimensionGroup.Name = "DimensionGroup";
            this.DimensionGroup.Size = new System.Drawing.Size(363, 116);
            this.DimensionGroup.TabIndex = 0;
            this.DimensionGroup.TabStop = false;
            this.DimensionGroup.Text = "Timetracking Dimensions";
            // 
            // Layout_UseCategories
            // 
            this.Layout_UseCategories.AutoSize = true;
            this.Layout_UseCategories.Location = new System.Drawing.Point(17, 88);
            this.Layout_UseCategories.Name = "Layout_UseCategories";
            this.Layout_UseCategories.Size = new System.Drawing.Size(98, 17);
            this.Layout_UseCategories.TabIndex = 9;
            this.Layout_UseCategories.Text = "Use Categories";
            this.Layout_UseCategories.UseVisualStyleBackColor = true;
            this.Layout_UseCategories.CheckedChanged += new System.EventHandler(this.Layout_UseCategories_CheckedChanged);
            // 
            // Layout_UseLocations
            // 
            this.Layout_UseLocations.AutoSize = true;
            this.Layout_UseLocations.Location = new System.Drawing.Point(17, 65);
            this.Layout_UseLocations.Name = "Layout_UseLocations";
            this.Layout_UseLocations.Size = new System.Drawing.Size(94, 17);
            this.Layout_UseLocations.TabIndex = 8;
            this.Layout_UseLocations.Text = "Use Locations";
            this.Layout_UseLocations.UseVisualStyleBackColor = true;
            this.Layout_UseLocations.CheckedChanged += new System.EventHandler(this.Layout_UseLocations_CheckedChanged);
            // 
            // Layout_UseActivities
            // 
            this.Layout_UseActivities.AutoSize = true;
            this.Layout_UseActivities.Location = new System.Drawing.Point(17, 42);
            this.Layout_UseActivities.Name = "Layout_UseActivities";
            this.Layout_UseActivities.Size = new System.Drawing.Size(90, 17);
            this.Layout_UseActivities.TabIndex = 7;
            this.Layout_UseActivities.Text = "Use Activities";
            this.Layout_UseActivities.UseVisualStyleBackColor = true;
            this.Layout_UseActivities.CheckedChanged += new System.EventHandler(this.Layout_UseActivities_CheckedChanged);
            // 
            // Layout_UseProjects
            // 
            this.Layout_UseProjects.AutoSize = true;
            this.Layout_UseProjects.Location = new System.Drawing.Point(17, 19);
            this.Layout_UseProjects.Name = "Layout_UseProjects";
            this.Layout_UseProjects.Size = new System.Drawing.Size(86, 17);
            this.Layout_UseProjects.TabIndex = 6;
            this.Layout_UseProjects.Text = "Use Projects";
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
            this.ViewPage.Size = new System.Drawing.Size(393, 405);
            this.ViewPage.TabIndex = 0;
            this.ViewPage.Text = "View";
            this.ViewPage.UseVisualStyleBackColor = true;
            // 
            // StatusBarGroup
            // 
            this.StatusBarGroup.Controls.Add(this.View_StatusBar_AddLabels);
            this.StatusBarGroup.Controls.Add(this.View_StatusBar);
            this.StatusBarGroup.Controls.Add(this.View_StatusBar_ProjectName);
            this.StatusBarGroup.Controls.Add(this.View_StatusBar_FileName);
            this.StatusBarGroup.Controls.Add(this.View_StatusBar_ActivityName);
            this.StatusBarGroup.Controls.Add(this.View_StatusBar_ElapsedAllToday);
            this.StatusBarGroup.Controls.Add(this.View_StatusBar_ElapsedSinceStart);
            this.StatusBarGroup.Controls.Add(this.View_StatusBar_ElapsedActivityToday);
            this.StatusBarGroup.Controls.Add(this.View_StatusBar_ElapsedProjectToday);
            this.StatusBarGroup.Location = new System.Drawing.Point(17, 16);
            this.StatusBarGroup.Name = "StatusBarGroup";
            this.StatusBarGroup.Size = new System.Drawing.Size(363, 215);
            this.StatusBarGroup.TabIndex = 20;
            this.StatusBarGroup.TabStop = false;
            this.StatusBarGroup.Text = "Status Bar";
            // 
            // View_StatusBar_AddLabels
            // 
            this.View_StatusBar_AddLabels.AutoSize = true;
            this.View_StatusBar_AddLabels.Enabled = false;
            this.View_StatusBar_AddLabels.Location = new System.Drawing.Point(224, 19);
            this.View_StatusBar_AddLabels.Name = "View_StatusBar_AddLabels";
            this.View_StatusBar_AddLabels.Size = new System.Drawing.Size(79, 17);
            this.View_StatusBar_AddLabels.TabIndex = 11;
            this.View_StatusBar_AddLabels.Text = "Add Labels";
            this.View_StatusBar_AddLabels.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar
            // 
            this.View_StatusBar.AutoSize = true;
            this.View_StatusBar.Location = new System.Drawing.Point(17, 19);
            this.View_StatusBar.Name = "View_StatusBar";
            this.View_StatusBar.Size = new System.Drawing.Size(75, 17);
            this.View_StatusBar.TabIndex = 0;
            this.View_StatusBar.Text = "Status Bar";
            this.View_StatusBar.UseVisualStyleBackColor = true;
            this.View_StatusBar.CheckedChanged += new System.EventHandler(this.View_StatusBar_CheckedChanged);
            // 
            // View_StatusBar_ProjectName
            // 
            this.View_StatusBar_ProjectName.AutoSize = true;
            this.View_StatusBar_ProjectName.Enabled = false;
            this.View_StatusBar_ProjectName.Location = new System.Drawing.Point(37, 42);
            this.View_StatusBar_ProjectName.Name = "View_StatusBar_ProjectName";
            this.View_StatusBar_ProjectName.Size = new System.Drawing.Size(125, 17);
            this.View_StatusBar_ProjectName.TabIndex = 1;
            this.View_StatusBar_ProjectName.Text = "Current Project name";
            this.View_StatusBar_ProjectName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_FileName
            // 
            this.View_StatusBar_FileName.AutoSize = true;
            this.View_StatusBar_FileName.Enabled = false;
            this.View_StatusBar_FileName.Location = new System.Drawing.Point(37, 180);
            this.View_StatusBar_FileName.Name = "View_StatusBar_FileName";
            this.View_StatusBar_FileName.Size = new System.Drawing.Size(115, 17);
            this.View_StatusBar_FileName.TabIndex = 10;
            this.View_StatusBar_FileName.Text = "Current opened file";
            this.View_StatusBar_FileName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ActivityName
            // 
            this.View_StatusBar_ActivityName.AutoSize = true;
            this.View_StatusBar_ActivityName.Enabled = false;
            this.View_StatusBar_ActivityName.Location = new System.Drawing.Point(37, 65);
            this.View_StatusBar_ActivityName.Name = "View_StatusBar_ActivityName";
            this.View_StatusBar_ActivityName.Size = new System.Drawing.Size(126, 17);
            this.View_StatusBar_ActivityName.TabIndex = 2;
            this.View_StatusBar_ActivityName.Text = "Current Activity name";
            this.View_StatusBar_ActivityName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedAllToday
            // 
            this.View_StatusBar_ElapsedAllToday.AutoSize = true;
            this.View_StatusBar_ElapsedAllToday.Enabled = false;
            this.View_StatusBar_ElapsedAllToday.Location = new System.Drawing.Point(37, 157);
            this.View_StatusBar_ElapsedAllToday.Name = "View_StatusBar_ElapsedAllToday";
            this.View_StatusBar_ElapsedAllToday.Size = new System.Drawing.Size(141, 17);
            this.View_StatusBar_ElapsedAllToday.TabIndex = 6;
            this.View_StatusBar_ElapsedAllToday.Text = "Total elapsed time today";
            this.View_StatusBar_ElapsedAllToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedSinceStart
            // 
            this.View_StatusBar_ElapsedSinceStart.AutoSize = true;
            this.View_StatusBar_ElapsedSinceStart.Enabled = false;
            this.View_StatusBar_ElapsedSinceStart.Location = new System.Drawing.Point(37, 88);
            this.View_StatusBar_ElapsedSinceStart.Name = "View_StatusBar_ElapsedSinceStart";
            this.View_StatusBar_ElapsedSinceStart.Size = new System.Drawing.Size(152, 17);
            this.View_StatusBar_ElapsedSinceStart.TabIndex = 3;
            this.View_StatusBar_ElapsedSinceStart.Text = "Elapsed since timer started";
            this.View_StatusBar_ElapsedSinceStart.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedActivityToday
            // 
            this.View_StatusBar_ElapsedActivityToday.AutoSize = true;
            this.View_StatusBar_ElapsedActivityToday.Enabled = false;
            this.View_StatusBar_ElapsedActivityToday.Location = new System.Drawing.Point(37, 134);
            this.View_StatusBar_ElapsedActivityToday.Name = "View_StatusBar_ElapsedActivityToday";
            this.View_StatusBar_ElapsedActivityToday.Size = new System.Drawing.Size(181, 17);
            this.View_StatusBar_ElapsedActivityToday.TabIndex = 5;
            this.View_StatusBar_ElapsedActivityToday.Text = "Elapsed today for current Activity";
            this.View_StatusBar_ElapsedActivityToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedProjectToday
            // 
            this.View_StatusBar_ElapsedProjectToday.AutoSize = true;
            this.View_StatusBar_ElapsedProjectToday.Enabled = false;
            this.View_StatusBar_ElapsedProjectToday.Location = new System.Drawing.Point(37, 111);
            this.View_StatusBar_ElapsedProjectToday.Name = "View_StatusBar_ElapsedProjectToday";
            this.View_StatusBar_ElapsedProjectToday.Size = new System.Drawing.Size(180, 17);
            this.View_StatusBar_ElapsedProjectToday.TabIndex = 4;
            this.View_StatusBar_ElapsedProjectToday.Text = "Elapsed today for current Project";
            this.View_StatusBar_ElapsedProjectToday.UseVisualStyleBackColor = true;
            // 
            // HiddenGroup
            // 
            this.HiddenGroup.Controls.Add(this.HiddenGroupPanelCategory);
            this.HiddenGroup.Controls.Add(this.HiddenGroupPanelLocation);
            this.HiddenGroup.Controls.Add(this.HiddenGroupPanelActivity);
            this.HiddenGroup.Controls.Add(this.HiddenGroupPanelProject);
            this.HiddenGroup.Location = new System.Drawing.Point(17, 237);
            this.HiddenGroup.Name = "HiddenGroup";
            this.HiddenGroup.Size = new System.Drawing.Size(363, 131);
            this.HiddenGroup.TabIndex = 19;
            this.HiddenGroup.TabStop = false;
            this.HiddenGroup.Text = "Hidden Items";
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
            this.BehaviorPage.Controls.Add(this.AnnoyGroup);
            this.BehaviorPage.Controls.Add(this.WindowControlGroup);
            this.BehaviorPage.Controls.Add(this.TitleBarGroup);
            this.BehaviorPage.Location = new System.Drawing.Point(98, 4);
            this.BehaviorPage.Name = "BehaviorPage";
            this.BehaviorPage.Padding = new System.Windows.Forms.Padding(3);
            this.BehaviorPage.Size = new System.Drawing.Size(393, 405);
            this.BehaviorPage.TabIndex = 3;
            this.BehaviorPage.Text = "Behavior";
            this.BehaviorPage.UseVisualStyleBackColor = true;
            // 
            // AnnoyGroup
            // 
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_PromptBeforeHiding);
            this.AnnoyGroup.Controls.Add(this.label10);
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_NoRunningPromptAmount);
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_ProjectFollowsActivity);
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_ActivityFollowsProject);
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_NoRunningPrompt);
            this.AnnoyGroup.Location = new System.Drawing.Point(17, 275);
            this.AnnoyGroup.Name = "AnnoyGroup";
            this.AnnoyGroup.Size = new System.Drawing.Size(363, 116);
            this.AnnoyGroup.TabIndex = 2;
            this.AnnoyGroup.TabStop = false;
            this.AnnoyGroup.Text = "Annoyances";
            // 
            // Behavior_Annoy_PromptBeforeHiding
            // 
            this.Behavior_Annoy_PromptBeforeHiding.AutoSize = true;
            this.Behavior_Annoy_PromptBeforeHiding.Location = new System.Drawing.Point(17, 19);
            this.Behavior_Annoy_PromptBeforeHiding.Name = "Behavior_Annoy_PromptBeforeHiding";
            this.Behavior_Annoy_PromptBeforeHiding.Size = new System.Drawing.Size(150, 17);
            this.Behavior_Annoy_PromptBeforeHiding.TabIndex = 8;
            this.Behavior_Annoy_PromptBeforeHiding.Text = "Prompt before hiding items";
            this.Behavior_Annoy_PromptBeforeHiding.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "minutes";
            // 
            // Behavior_Annoy_NoRunningPromptAmount
            // 
            this.Behavior_Annoy_NoRunningPromptAmount.Location = new System.Drawing.Point(192, 41);
            this.Behavior_Annoy_NoRunningPromptAmount.Name = "Behavior_Annoy_NoRunningPromptAmount";
            this.Behavior_Annoy_NoRunningPromptAmount.Size = new System.Drawing.Size(53, 20);
            this.Behavior_Annoy_NoRunningPromptAmount.TabIndex = 6;
            // 
            // Behavior_Annoy_NoRunningPrompt
            // 
            this.Behavior_Annoy_NoRunningPrompt.AutoSize = true;
            this.Behavior_Annoy_NoRunningPrompt.Location = new System.Drawing.Point(17, 42);
            this.Behavior_Annoy_NoRunningPrompt.Name = "Behavior_Annoy_NoRunningPrompt";
            this.Behavior_Annoy_NoRunningPrompt.Size = new System.Drawing.Size(169, 17);
            this.Behavior_Annoy_NoRunningPrompt.TabIndex = 5;
            this.Behavior_Annoy_NoRunningPrompt.Text = "Prompt if no timer running after";
            this.Behavior_Annoy_NoRunningPrompt.UseVisualStyleBackColor = true;
            // 
            // Behavior_Annoy_ProjectFollowsActivity
            // 
            this.Behavior_Annoy_ProjectFollowsActivity.AutoSize = true;
            this.Behavior_Annoy_ProjectFollowsActivity.Location = new System.Drawing.Point(16, 90);
            this.Behavior_Annoy_ProjectFollowsActivity.Name = "Behavior_Annoy_ProjectFollowsActivity";
            this.Behavior_Annoy_ProjectFollowsActivity.Size = new System.Drawing.Size(174, 17);
            this.Behavior_Annoy_ProjectFollowsActivity.TabIndex = 4;
            this.Behavior_Annoy_ProjectFollowsActivity.Text = "Project follows selected Activity";
            this.Behavior_Annoy_ProjectFollowsActivity.UseVisualStyleBackColor = true;
            // 
            // Behavior_Annoy_ActivityFollowsProject
            // 
            this.Behavior_Annoy_ActivityFollowsProject.AutoSize = true;
            this.Behavior_Annoy_ActivityFollowsProject.Location = new System.Drawing.Point(17, 67);
            this.Behavior_Annoy_ActivityFollowsProject.Name = "Behavior_Annoy_ActivityFollowsProject";
            this.Behavior_Annoy_ActivityFollowsProject.Size = new System.Drawing.Size(174, 17);
            this.Behavior_Annoy_ActivityFollowsProject.TabIndex = 3;
            this.Behavior_Annoy_ActivityFollowsProject.Text = "Activity follows selected Project";
            this.Behavior_Annoy_ActivityFollowsProject.UseVisualStyleBackColor = true;
            // 
            // WindowControlGroup
            // 
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_MinimizeOnUse);
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_MinimizeToTray);
            this.WindowControlGroup.Controls.Add(this.Behavior_Window_ShowInTray);
            this.WindowControlGroup.Location = new System.Drawing.Point(17, 169);
            this.WindowControlGroup.Name = "WindowControlGroup";
            this.WindowControlGroup.Size = new System.Drawing.Size(363, 100);
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
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_Template);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_ElapsedAllToday);
            this.TitleBarGroup.Controls.Add(this.label9);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_ElapsedActivityToday);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_ElapsedProjectToday);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_ElapsedSinceStart);
            this.TitleBarGroup.Location = new System.Drawing.Point(17, 16);
            this.TitleBarGroup.Name = "TitleBarGroup";
            this.TitleBarGroup.Size = new System.Drawing.Size(363, 147);
            this.TitleBarGroup.TabIndex = 0;
            this.TitleBarGroup.TabStop = false;
            this.TitleBarGroup.Text = "Title Bar";
            // 
            // Behavior_TitleBar_Template
            // 
            this.Behavior_TitleBar_Template.Location = new System.Drawing.Point(74, 22);
            this.Behavior_TitleBar_Template.Name = "Behavior_TitleBar_Template";
            this.Behavior_TitleBar_Template.Size = new System.Drawing.Size(171, 20);
            this.Behavior_TitleBar_Template.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Template:";
            // 
            // Behavior_TitleBar_ElapsedAllToday
            // 
            this.Behavior_TitleBar_ElapsedAllToday.AutoSize = true;
            this.Behavior_TitleBar_ElapsedAllToday.Location = new System.Drawing.Point(18, 117);
            this.Behavior_TitleBar_ElapsedAllToday.Name = "Behavior_TitleBar_ElapsedAllToday";
            this.Behavior_TitleBar_ElapsedAllToday.Size = new System.Drawing.Size(173, 17);
            this.Behavior_TitleBar_ElapsedAllToday.TabIndex = 3;
            this.Behavior_TitleBar_ElapsedAllToday.TabStop = true;
            this.Behavior_TitleBar_ElapsedAllToday.Tag = "3";
            this.Behavior_TitleBar_ElapsedAllToday.Text = "Display total elapsed time today";
            this.Behavior_TitleBar_ElapsedAllToday.UseVisualStyleBackColor = true;
            // 
            // Behavior_TitleBar_ElapsedActivityToday
            // 
            this.Behavior_TitleBar_ElapsedActivityToday.AutoSize = true;
            this.Behavior_TitleBar_ElapsedActivityToday.Location = new System.Drawing.Point(17, 94);
            this.Behavior_TitleBar_ElapsedActivityToday.Name = "Behavior_TitleBar_ElapsedActivityToday";
            this.Behavior_TitleBar_ElapsedActivityToday.Size = new System.Drawing.Size(237, 17);
            this.Behavior_TitleBar_ElapsedActivityToday.TabIndex = 2;
            this.Behavior_TitleBar_ElapsedActivityToday.TabStop = true;
            this.Behavior_TitleBar_ElapsedActivityToday.Tag = "2";
            this.Behavior_TitleBar_ElapsedActivityToday.Text = "Display elapsed time today for current activity";
            this.Behavior_TitleBar_ElapsedActivityToday.UseVisualStyleBackColor = true;
            // 
            // Behavior_TitleBar_ElapsedProjectToday
            // 
            this.Behavior_TitleBar_ElapsedProjectToday.AutoSize = true;
            this.Behavior_TitleBar_ElapsedProjectToday.Location = new System.Drawing.Point(17, 71);
            this.Behavior_TitleBar_ElapsedProjectToday.Name = "Behavior_TitleBar_ElapsedProjectToday";
            this.Behavior_TitleBar_ElapsedProjectToday.Size = new System.Drawing.Size(236, 17);
            this.Behavior_TitleBar_ElapsedProjectToday.TabIndex = 1;
            this.Behavior_TitleBar_ElapsedProjectToday.TabStop = true;
            this.Behavior_TitleBar_ElapsedProjectToday.Tag = "1";
            this.Behavior_TitleBar_ElapsedProjectToday.Text = "Display elapsed time today for current project";
            this.Behavior_TitleBar_ElapsedProjectToday.UseVisualStyleBackColor = true;
            // 
            // Behavior_TitleBar_ElapsedSinceStart
            // 
            this.Behavior_TitleBar_ElapsedSinceStart.AutoSize = true;
            this.Behavior_TitleBar_ElapsedSinceStart.Location = new System.Drawing.Point(17, 48);
            this.Behavior_TitleBar_ElapsedSinceStart.Name = "Behavior_TitleBar_ElapsedSinceStart";
            this.Behavior_TitleBar_ElapsedSinceStart.Size = new System.Drawing.Size(228, 17);
            this.Behavior_TitleBar_ElapsedSinceStart.TabIndex = 0;
            this.Behavior_TitleBar_ElapsedSinceStart.TabStop = true;
            this.Behavior_TitleBar_ElapsedSinceStart.Tag = "0";
            this.Behavior_TitleBar_ElapsedSinceStart.Text = "Display elapsed time since timer last started";
            this.Behavior_TitleBar_ElapsedSinceStart.UseVisualStyleBackColor = true;
            // 
            // ReportPage
            // 
            this.ReportPage.Controls.Add(this.ReportGroup);
            this.ReportPage.Location = new System.Drawing.Point(98, 4);
            this.ReportPage.Name = "ReportPage";
            this.ReportPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReportPage.Size = new System.Drawing.Size(393, 405);
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
            this.ReportGroup.Controls.Add(this.label7);
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
            this.LabelBaseFont.Location = new System.Drawing.Point(19, 30);
            this.LabelBaseFont.Name = "LabelBaseFont";
            this.LabelBaseFont.Size = new System.Drawing.Size(58, 13);
            this.LabelBaseFont.TabIndex = 0;
            this.LabelBaseFont.Text = "Base Font:";
            // 
            // Report_StyleSheet
            // 
            this.Report_StyleSheet.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Report_StyleSheet.Location = new System.Drawing.Point(106, 175);
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
            this.Report_FontList.Location = new System.Drawing.Point(106, 30);
            this.Report_FontList.Name = "Report_FontList";
            this.Report_FontList.Size = new System.Drawing.Size(238, 95);
            this.Report_FontList.TabIndex = 1;
            // 
            // LabelStyleSheet
            // 
            this.LabelStyleSheet.AutoSize = true;
            this.LabelStyleSheet.Location = new System.Drawing.Point(19, 175);
            this.LabelStyleSheet.Name = "LabelStyleSheet";
            this.LabelStyleSheet.Size = new System.Drawing.Size(61, 13);
            this.LabelStyleSheet.TabIndex = 5;
            this.LabelStyleSheet.Text = "Style Sheet";
            // 
            // LabelBaseFontSize
            // 
            this.LabelBaseFontSize.AutoSize = true;
            this.LabelBaseFontSize.Location = new System.Drawing.Point(19, 141);
            this.LabelBaseFontSize.Name = "LabelBaseFontSize";
            this.LabelBaseFontSize.Size = new System.Drawing.Size(81, 13);
            this.LabelBaseFontSize.TabIndex = 2;
            this.LabelBaseFontSize.Text = "Base Font Size:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 141);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Points";
            // 
            // Report_FontSize
            // 
            this.Report_FontSize.Location = new System.Drawing.Point(106, 139);
            this.Report_FontSize.Name = "Report_FontSize";
            this.Report_FontSize.Size = new System.Drawing.Size(69, 20);
            this.Report_FontSize.TabIndex = 3;
            // 
            // KeyboardPage
            // 
            this.KeyboardPage.Controls.Add(this.ShortcutGroup);
            this.KeyboardPage.Controls.Add(this.wFunctionList);
            this.KeyboardPage.Location = new System.Drawing.Point(98, 4);
            this.KeyboardPage.Name = "KeyboardPage";
            this.KeyboardPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeyboardPage.Size = new System.Drawing.Size(393, 405);
            this.KeyboardPage.TabIndex = 4;
            this.KeyboardPage.Text = "Keyboard";
            this.KeyboardPage.UseVisualStyleBackColor = true;
            // 
            // ShortcutGroup
            // 
            this.ShortcutGroup.Controls.Add(this.AssignKey);
            this.ShortcutGroup.Controls.Add(this.wAlt);
            this.ShortcutGroup.Controls.Add(this.RemoveKey);
            this.ShortcutGroup.Controls.Add(this.wKey);
            this.ShortcutGroup.Controls.Add(this.wShift);
            this.ShortcutGroup.Controls.Add(this.wCtrl);
            this.ShortcutGroup.Location = new System.Drawing.Point(15, 309);
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
            // wAlt
            // 
            this.wAlt.AutoSize = true;
            this.wAlt.Location = new System.Drawing.Point(65, 36);
            this.wAlt.Name = "wAlt";
            this.wAlt.Size = new System.Drawing.Size(38, 17);
            this.wAlt.TabIndex = 11;
            this.wAlt.Text = "Alt";
            this.wAlt.UseVisualStyleBackColor = true;
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
            this.wKey.Location = new System.Drawing.Point(162, 34);
            this.wKey.Name = "wKey";
            this.wKey.Size = new System.Drawing.Size(75, 21);
            this.wKey.TabIndex = 9;
            // 
            // wShift
            // 
            this.wShift.AutoSize = true;
            this.wShift.Location = new System.Drawing.Point(109, 36);
            this.wShift.Name = "wShift";
            this.wShift.Size = new System.Drawing.Size(47, 17);
            this.wShift.TabIndex = 8;
            this.wShift.Text = "Shift";
            this.wShift.UseVisualStyleBackColor = true;
            // 
            // wCtrl
            // 
            this.wCtrl.AutoSize = true;
            this.wCtrl.Location = new System.Drawing.Point(18, 36);
            this.wCtrl.Name = "wCtrl";
            this.wCtrl.Size = new System.Drawing.Size(41, 17);
            this.wCtrl.TabIndex = 7;
            this.wCtrl.Text = "Ctrl";
            this.wCtrl.UseVisualStyleBackColor = true;
            // 
            // wFunctionList
            // 
            this.wFunctionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.wFunctionList.FullRowSelect = true;
            this.wFunctionList.HideSelection = false;
            this.wFunctionList.Location = new System.Drawing.Point(15, 16);
            this.wFunctionList.MultiSelect = false;
            this.wFunctionList.Name = "wFunctionList";
            this.wFunctionList.Size = new System.Drawing.Size(365, 287);
            this.wFunctionList.SmallImageList = this.imageList1;
            this.wFunctionList.TabIndex = 8;
            this.wFunctionList.UseCompatibleStateImageBehavior = false;
            this.wFunctionList.View = System.Windows.Forms.View.Details;
            this.wFunctionList.SelectedIndexChanged += new System.EventHandler(this.wFunctionList_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Function";
            this.columnHeader1.Width = 280;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "ImageIconMenu");
            this.imageList1.Images.SetKeyName(1, "ImageIconToolbar");
            // 
            // AdvancedPage
            // 
            this.AdvancedPage.Controls.Add(this.groupBox2);
            this.AdvancedPage.Controls.Add(this.groupBox1);
            this.AdvancedPage.Controls.Add(this.LoggingGroup);
            this.AdvancedPage.Location = new System.Drawing.Point(98, 4);
            this.AdvancedPage.Name = "AdvancedPage";
            this.AdvancedPage.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedPage.Size = new System.Drawing.Size(393, 405);
            this.AdvancedPage.TabIndex = 5;
            this.AdvancedPage.Text = "Advanced";
            this.AdvancedPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(17, 117);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(51, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(252, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "CUSTOM DATE/TIME FORMAT GOES HERE";
            // 
            // LoggingGroup
            // 
            this.LoggingGroup.Controls.Add(this.ViewLog);
            this.LoggingGroup.Controls.Add(this.Advanced_Logging_Database);
            this.LoggingGroup.Controls.Add(this.Advanced_Logging_Application);
            this.LoggingGroup.Controls.Add(this.label1);
            this.LoggingGroup.Controls.Add(this.label2);
            this.LoggingGroup.Location = new System.Drawing.Point(17, 16);
            this.LoggingGroup.Name = "LoggingGroup";
            this.LoggingGroup.Size = new System.Drawing.Size(363, 95);
            this.LoggingGroup.TabIndex = 2;
            this.LoggingGroup.TabStop = false;
            this.LoggingGroup.Text = "Logging";
            // 
            // ViewLog
            // 
            this.ViewLog.Location = new System.Drawing.Point(271, 42);
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
            this.Advanced_Logging_Database.Location = new System.Drawing.Point(122, 56);
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
            this.Advanced_Logging_Application.Location = new System.Drawing.Point(122, 29);
            this.Advanced_Logging_Application.Name = "Advanced_Logging_Application";
            this.Advanced_Logging_Application.Size = new System.Drawing.Size(121, 21);
            this.Advanced_Logging_Application.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Database:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel3);
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Location = new System.Drawing.Point(17, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 163);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 24);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.checkBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 40);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(357, 24);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.checkBox3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(3, 64);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(357, 24);
            this.panel3.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(22, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(22, 3);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(22, 3);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(80, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // HiddenGroupPanelProject
            // 
            this.HiddenGroupPanelProject.Controls.Add(this.View_HiddenProjects);
            this.HiddenGroupPanelProject.Controls.Add(this.View_HiddenProjectsSince);
            this.HiddenGroupPanelProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroupPanelProject.Location = new System.Drawing.Point(3, 16);
            this.HiddenGroupPanelProject.Name = "HiddenGroupPanelProject";
            this.HiddenGroupPanelProject.Size = new System.Drawing.Size(357, 27);
            this.HiddenGroupPanelProject.TabIndex = 19;
            // 
            // HiddenGroupPanelActivity
            // 
            this.HiddenGroupPanelActivity.Controls.Add(this.View_HiddenActivities);
            this.HiddenGroupPanelActivity.Controls.Add(this.View_HiddenActivitiesSince);
            this.HiddenGroupPanelActivity.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroupPanelActivity.Location = new System.Drawing.Point(3, 43);
            this.HiddenGroupPanelActivity.Name = "HiddenGroupPanelActivity";
            this.HiddenGroupPanelActivity.Size = new System.Drawing.Size(357, 27);
            this.HiddenGroupPanelActivity.TabIndex = 20;
            // 
            // HiddenGroupPanelLocation
            // 
            this.HiddenGroupPanelLocation.Controls.Add(this.View_HiddenLocations);
            this.HiddenGroupPanelLocation.Controls.Add(this.View_HiddenLocationsSince);
            this.HiddenGroupPanelLocation.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroupPanelLocation.Location = new System.Drawing.Point(3, 70);
            this.HiddenGroupPanelLocation.Name = "HiddenGroupPanelLocation";
            this.HiddenGroupPanelLocation.Size = new System.Drawing.Size(357, 27);
            this.HiddenGroupPanelLocation.TabIndex = 21;
            // 
            // HiddenGroupPanelCategory
            // 
            this.HiddenGroupPanelCategory.Controls.Add(this.View_HiddenCategories);
            this.HiddenGroupPanelCategory.Controls.Add(this.View_HiddenCategoriesSince);
            this.HiddenGroupPanelCategory.Dock = System.Windows.Forms.DockStyle.Top;
            this.HiddenGroupPanelCategory.Location = new System.Drawing.Point(3, 97);
            this.HiddenGroupPanelCategory.Name = "HiddenGroupPanelCategory";
            this.HiddenGroupPanelCategory.Size = new System.Drawing.Size(357, 27);
            this.HiddenGroupPanelCategory.TabIndex = 22;
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
            this.SortingGroup.PerformLayout();
            this.PresetGroup.ResumeLayout(false);
            this.PresetGroup.PerformLayout();
            this.DimensionGroup.ResumeLayout(false);
            this.DimensionGroup.PerformLayout();
            this.ViewPage.ResumeLayout(false);
            this.StatusBarGroup.ResumeLayout(false);
            this.StatusBarGroup.PerformLayout();
            this.HiddenGroup.ResumeLayout(false);
            this.BehaviorPage.ResumeLayout(false);
            this.AnnoyGroup.ResumeLayout(false);
            this.AnnoyGroup.PerformLayout();
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.LoggingGroup.ResumeLayout(false);
            this.LoggingGroup.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.HiddenGroupPanelProject.ResumeLayout(false);
            this.HiddenGroupPanelProject.PerformLayout();
            this.HiddenGroupPanelActivity.ResumeLayout(false);
            this.HiddenGroupPanelActivity.PerformLayout();
            this.HiddenGroupPanelLocation.ResumeLayout(false);
            this.HiddenGroupPanelLocation.PerformLayout();
            this.HiddenGroupPanelCategory.ResumeLayout(false);
            this.HiddenGroupPanelCategory.PerformLayout();
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
        private System.Windows.Forms.Label Label_SortOther;
        private System.Windows.Forms.ComboBox Layout_SortItemsBy;
        private System.Windows.Forms.Label Label_SortProjects;
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
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton Behavior_TitleBar_ElapsedAllToday;
        private System.Windows.Forms.RadioButton Behavior_TitleBar_ElapsedActivityToday;
        private System.Windows.Forms.RadioButton Behavior_TitleBar_ElapsedProjectToday;
        private System.Windows.Forms.RadioButton Behavior_TitleBar_ElapsedSinceStart;
        private System.Windows.Forms.RichTextBox Report_StyleSheet;
        private System.Windows.Forms.Label LabelStyleSheet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown Report_FontSize;
        private System.Windows.Forms.Label LabelBaseFontSize;
        private System.Windows.Forms.ListBox Report_FontList;
        private System.Windows.Forms.Label LabelBaseFont;
        private System.Windows.Forms.GroupBox AnnoyGroup;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown Behavior_Annoy_NoRunningPromptAmount;
        private System.Windows.Forms.CheckBox Behavior_Annoy_NoRunningPrompt;
        private System.Windows.Forms.CheckBox Behavior_Annoy_ProjectFollowsActivity;
        private System.Windows.Forms.CheckBox Behavior_Annoy_ActivityFollowsProject;
        private System.Windows.Forms.TabPage KeyboardPage;
        public System.Windows.Forms.ListView wFunctionList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.GroupBox ShortcutGroup;
        private System.Windows.Forms.Button RemoveKey;
        private System.Windows.Forms.ComboBox wKey;
        private System.Windows.Forms.CheckBox wShift;
        private System.Windows.Forms.CheckBox wCtrl;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox Layout_SortProjectsByDirection;
        private System.Windows.Forms.ComboBox Layout_SortItemsByDirection;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox wAlt;
        private System.Windows.Forms.Button AssignKey;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox Behavior_Annoy_PromptBeforeHiding;
        private System.Windows.Forms.TabPage AdvancedPage;
        private System.Windows.Forms.GroupBox LoggingGroup;
        private System.Windows.Forms.Button ViewLog;
        private System.Windows.Forms.ComboBox Advanced_Logging_Database;
        private System.Windows.Forms.ComboBox Advanced_Logging_Application;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox StatusBarGroup;
        private System.Windows.Forms.CheckBox View_StatusBar_AddLabels;
        private System.Windows.Forms.GroupBox HiddenGroup;
        private System.Windows.Forms.GroupBox ReportGroup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel HiddenGroupPanelCategory;
        private System.Windows.Forms.Panel HiddenGroupPanelLocation;
        private System.Windows.Forms.Panel HiddenGroupPanelActivity;
        private System.Windows.Forms.Panel HiddenGroupPanelProject;

    }
}