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
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.PanelSelector = new System.Windows.Forms.ListBox();
            this.SelectorPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.OptionsPanelCollection = new System.Windows.Forms.TabControl();
            this.LayoutPage = new System.Windows.Forms.TabPage();
            this.Layout_SortProjectsByDirection = new System.Windows.Forms.ComboBox();
            this.SortingGroup = new System.Windows.Forms.GroupBox();
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
            this.View_HiddenCategoriesSince = new System.Windows.Forms.ComboBox();
            this.View_HiddenLocationsSince = new System.Windows.Forms.ComboBox();
            this.View_HiddenActivitiesSince = new System.Windows.Forms.ComboBox();
            this.View_HiddenProjectsSince = new System.Windows.Forms.ComboBox();
            this.View_HiddenCategories = new System.Windows.Forms.CheckBox();
            this.View_HiddenLocations = new System.Windows.Forms.CheckBox();
            this.View_HiddenActivities = new System.Windows.Forms.CheckBox();
            this.View_HiddenProjects = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_FileName = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.View_StatusBar_ElapsedAllToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedActivityToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedProjectToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedSinceStart = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ActivityName = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ProjectName = new System.Windows.Forms.CheckBox();
            this.View_StatusBar = new System.Windows.Forms.CheckBox();
            this.BehaviorPage = new System.Windows.Forms.TabPage();
            this.AnnoyGroup = new System.Windows.Forms.GroupBox();
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
            this.Report_StyleSheet = new System.Windows.Forms.RichTextBox();
            this.LabelStyleSheet = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Report_FontSize = new System.Windows.Forms.NumericUpDown();
            this.LabelBaseFontSize = new System.Windows.Forms.Label();
            this.Report_FontList = new System.Windows.Forms.ListBox();
            this.LabelBaseFont = new System.Windows.Forms.Label();
            this.KeyboardPage = new System.Windows.Forms.TabPage();
            this.ShortcutGroup = new System.Windows.Forms.GroupBox();
            this.RemoveKey = new System.Windows.Forms.Button();
            this.wKey = new System.Windows.Forms.ComboBox();
            this.wShift = new System.Windows.Forms.CheckBox();
            this.wCtrl = new System.Windows.Forms.CheckBox();
            this.wFunctionList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.wAlt = new System.Windows.Forms.CheckBox();
            this.AssignKey = new System.Windows.Forms.Button();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ButtonPanel.SuspendLayout();
            this.SelectorPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.OptionsPanelCollection.SuspendLayout();
            this.LayoutPage.SuspendLayout();
            this.SortingGroup.SuspendLayout();
            this.PresetGroup.SuspendLayout();
            this.DimensionGroup.SuspendLayout();
            this.ViewPage.SuspendLayout();
            this.BehaviorPage.SuspendLayout();
            this.AnnoyGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Behavior_Annoy_NoRunningPromptAmount)).BeginInit();
            this.WindowControlGroup.SuspendLayout();
            this.TitleBarGroup.SuspendLayout();
            this.ReportPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_FontSize)).BeginInit();
            this.KeyboardPage.SuspendLayout();
            this.ShortcutGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.comboBox1);
            this.ButtonPanel.Controls.Add(this.CancelDialogButton);
            this.ButtonPanel.Controls.Add(this.AcceptDialogButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 428);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(559, 39);
            this.ButtonPanel.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Simple",
            "Normal",
            "The Works"});
            this.comboBox1.Location = new System.Drawing.Point(172, 8);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 2;
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(478, 6);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 1;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(397, 6);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 0;
            this.AcceptDialogButton.Text = "Save";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // PanelSelector
            // 
            this.PanelSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSelector.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelSelector.FormattingEnabled = true;
            this.PanelSelector.ItemHeight = 16;
            this.PanelSelector.Items.AddRange(new object[] {
            "Layout",
            "View",
            "Behavior",
            "Report",
            "Keyboard"});
            this.PanelSelector.Location = new System.Drawing.Point(6, 6);
            this.PanelSelector.Name = "PanelSelector";
            this.PanelSelector.Size = new System.Drawing.Size(150, 416);
            this.PanelSelector.TabIndex = 3;
            this.PanelSelector.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // SelectorPanel
            // 
            this.SelectorPanel.Controls.Add(this.PanelSelector);
            this.SelectorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SelectorPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SelectorPanel.Name = "SelectorPanel";
            this.SelectorPanel.Padding = new System.Windows.Forms.Padding(6);
            this.SelectorPanel.Size = new System.Drawing.Size(162, 428);
            this.SelectorPanel.TabIndex = 5;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.OptionsPanelCollection);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(162, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(6);
            this.ContentPanel.Size = new System.Drawing.Size(397, 428);
            this.ContentPanel.TabIndex = 6;
            // 
            // OptionsPanelCollection
            // 
            this.OptionsPanelCollection.Controls.Add(this.LayoutPage);
            this.OptionsPanelCollection.Controls.Add(this.ViewPage);
            this.OptionsPanelCollection.Controls.Add(this.BehaviorPage);
            this.OptionsPanelCollection.Controls.Add(this.ReportPage);
            this.OptionsPanelCollection.Controls.Add(this.KeyboardPage);
            this.OptionsPanelCollection.ItemSize = new System.Drawing.Size(72, 18);
            this.OptionsPanelCollection.Location = new System.Drawing.Point(6, 6);
            this.OptionsPanelCollection.Name = "OptionsPanelCollection";
            this.OptionsPanelCollection.SelectedIndex = 0;
            this.OptionsPanelCollection.Size = new System.Drawing.Size(383, 413);
            this.OptionsPanelCollection.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.OptionsPanelCollection.TabIndex = 0;
            // 
            // LayoutPage
            // 
            this.LayoutPage.Controls.Add(this.Layout_SortProjectsByDirection);
            this.LayoutPage.Controls.Add(this.SortingGroup);
            this.LayoutPage.Controls.Add(this.PresetGroup);
            this.LayoutPage.Controls.Add(this.DimensionGroup);
            this.LayoutPage.Location = new System.Drawing.Point(4, 22);
            this.LayoutPage.Name = "LayoutPage";
            this.LayoutPage.Padding = new System.Windows.Forms.Padding(3);
            this.LayoutPage.Size = new System.Drawing.Size(375, 387);
            this.LayoutPage.TabIndex = 2;
            this.LayoutPage.Text = "Layout";
            this.LayoutPage.UseVisualStyleBackColor = true;
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
            this.Layout_SortProjectsByDirection.Location = new System.Drawing.Point(270, 272);
            this.Layout_SortProjectsByDirection.Name = "Layout_SortProjectsByDirection";
            this.Layout_SortProjectsByDirection.Size = new System.Drawing.Size(88, 21);
            this.Layout_SortProjectsByDirection.TabIndex = 19;
            // 
            // SortingGroup
            // 
            this.SortingGroup.Controls.Add(this.Layout_SortItemsByDirection);
            this.SortingGroup.Controls.Add(this.Label_SortOther);
            this.SortingGroup.Controls.Add(this.Layout_SortItemsBy);
            this.SortingGroup.Controls.Add(this.Label_SortProjects);
            this.SortingGroup.Controls.Add(this.Layout_SortProjectsBy);
            this.SortingGroup.Location = new System.Drawing.Point(6, 249);
            this.SortingGroup.Name = "SortingGroup";
            this.SortingGroup.Size = new System.Drawing.Size(363, 88);
            this.SortingGroup.TabIndex = 4;
            this.SortingGroup.TabStop = false;
            this.SortingGroup.Text = "Sorting";
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
            this.Layout_SortItemsByDirection.Location = new System.Drawing.Point(264, 50);
            this.Layout_SortItemsByDirection.Name = "Layout_SortItemsByDirection";
            this.Layout_SortItemsByDirection.Size = new System.Drawing.Size(88, 21);
            this.Layout_SortItemsByDirection.TabIndex = 20;
            // 
            // Label_SortOther
            // 
            this.Label_SortOther.AutoSize = true;
            this.Label_SortOther.Location = new System.Drawing.Point(17, 53);
            this.Label_SortOther.Name = "Label_SortOther";
            this.Label_SortOther.Size = new System.Drawing.Size(86, 13);
            this.Label_SortOther.TabIndex = 18;
            this.Label_SortOther.Text = "Sort Other Items:";
            // 
            // Layout_SortItemsBy
            // 
            this.Layout_SortItemsBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.Layout_SortItemsBy.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Layout_SortItemsBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Layout_SortItemsBy.FormattingEnabled = true;
            this.Layout_SortItemsBy.Location = new System.Drawing.Point(125, 50);
            this.Layout_SortItemsBy.Name = "Layout_SortItemsBy";
            this.Layout_SortItemsBy.Size = new System.Drawing.Size(133, 21);
            this.Layout_SortItemsBy.TabIndex = 18;
            // 
            // Label_SortProjects
            // 
            this.Label_SortProjects.AutoSize = true;
            this.Label_SortProjects.Location = new System.Drawing.Point(17, 26);
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
            this.Layout_SortProjectsBy.Location = new System.Drawing.Point(125, 23);
            this.Layout_SortProjectsBy.Name = "Layout_SortProjectsBy";
            this.Layout_SortProjectsBy.Size = new System.Drawing.Size(133, 21);
            this.Layout_SortProjectsBy.TabIndex = 16;
            // 
            // PresetGroup
            // 
            this.PresetGroup.Controls.Add(this.label11);
            this.PresetGroup.Controls.Add(this.Layout_Preset_TheWorks);
            this.PresetGroup.Controls.Add(this.Layout_Preset_Typical);
            this.PresetGroup.Controls.Add(this.Layout_Preset_Simple);
            this.PresetGroup.Location = new System.Drawing.Point(6, 6);
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
            this.DimensionGroup.Location = new System.Drawing.Point(6, 112);
            this.DimensionGroup.Name = "DimensionGroup";
            this.DimensionGroup.Size = new System.Drawing.Size(363, 131);
            this.DimensionGroup.TabIndex = 0;
            this.DimensionGroup.TabStop = false;
            this.DimensionGroup.Text = "Timetracking Dimensions";
            // 
            // Layout_UseCategories
            // 
            this.Layout_UseCategories.AutoSize = true;
            this.Layout_UseCategories.Location = new System.Drawing.Point(17, 98);
            this.Layout_UseCategories.Name = "Layout_UseCategories";
            this.Layout_UseCategories.Size = new System.Drawing.Size(98, 17);
            this.Layout_UseCategories.TabIndex = 9;
            this.Layout_UseCategories.Text = "Use Categories";
            this.Layout_UseCategories.UseVisualStyleBackColor = true;
            // 
            // Layout_UseLocations
            // 
            this.Layout_UseLocations.AutoSize = true;
            this.Layout_UseLocations.Location = new System.Drawing.Point(17, 75);
            this.Layout_UseLocations.Name = "Layout_UseLocations";
            this.Layout_UseLocations.Size = new System.Drawing.Size(94, 17);
            this.Layout_UseLocations.TabIndex = 8;
            this.Layout_UseLocations.Text = "Use Locations";
            this.Layout_UseLocations.UseVisualStyleBackColor = true;
            // 
            // Layout_UseActivities
            // 
            this.Layout_UseActivities.AutoSize = true;
            this.Layout_UseActivities.Location = new System.Drawing.Point(17, 52);
            this.Layout_UseActivities.Name = "Layout_UseActivities";
            this.Layout_UseActivities.Size = new System.Drawing.Size(90, 17);
            this.Layout_UseActivities.TabIndex = 7;
            this.Layout_UseActivities.Text = "Use Activities";
            this.Layout_UseActivities.UseVisualStyleBackColor = true;
            // 
            // Layout_UseProjects
            // 
            this.Layout_UseProjects.AutoSize = true;
            this.Layout_UseProjects.Location = new System.Drawing.Point(17, 28);
            this.Layout_UseProjects.Name = "Layout_UseProjects";
            this.Layout_UseProjects.Size = new System.Drawing.Size(86, 17);
            this.Layout_UseProjects.TabIndex = 6;
            this.Layout_UseProjects.Text = "Use Projects";
            this.Layout_UseProjects.UseVisualStyleBackColor = true;
            // 
            // ViewPage
            // 
            this.ViewPage.Controls.Add(this.View_HiddenCategoriesSince);
            this.ViewPage.Controls.Add(this.View_HiddenLocationsSince);
            this.ViewPage.Controls.Add(this.View_HiddenActivitiesSince);
            this.ViewPage.Controls.Add(this.View_HiddenProjectsSince);
            this.ViewPage.Controls.Add(this.View_HiddenCategories);
            this.ViewPage.Controls.Add(this.View_HiddenLocations);
            this.ViewPage.Controls.Add(this.View_HiddenActivities);
            this.ViewPage.Controls.Add(this.View_HiddenProjects);
            this.ViewPage.Controls.Add(this.View_StatusBar_FileName);
            this.ViewPage.Controls.Add(this.checkedListBox1);
            this.ViewPage.Controls.Add(this.View_StatusBar_ElapsedAllToday);
            this.ViewPage.Controls.Add(this.View_StatusBar_ElapsedActivityToday);
            this.ViewPage.Controls.Add(this.View_StatusBar_ElapsedProjectToday);
            this.ViewPage.Controls.Add(this.View_StatusBar_ElapsedSinceStart);
            this.ViewPage.Controls.Add(this.View_StatusBar_ActivityName);
            this.ViewPage.Controls.Add(this.View_StatusBar_ProjectName);
            this.ViewPage.Controls.Add(this.View_StatusBar);
            this.ViewPage.Location = new System.Drawing.Point(4, 22);
            this.ViewPage.Name = "ViewPage";
            this.ViewPage.Padding = new System.Windows.Forms.Padding(3);
            this.ViewPage.Size = new System.Drawing.Size(375, 387);
            this.ViewPage.TabIndex = 0;
            this.ViewPage.Text = "View";
            this.ViewPage.UseVisualStyleBackColor = true;
            // 
            // View_HiddenCategoriesSince
            // 
            this.View_HiddenCategoriesSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenCategoriesSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenCategoriesSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenCategoriesSince.FormattingEnabled = true;
            this.View_HiddenCategoriesSince.Location = new System.Drawing.Point(149, 293);
            this.View_HiddenCategoriesSince.Name = "View_HiddenCategoriesSince";
            this.View_HiddenCategoriesSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenCategoriesSince.TabIndex = 18;
            // 
            // View_HiddenLocationsSince
            // 
            this.View_HiddenLocationsSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenLocationsSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenLocationsSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenLocationsSince.FormattingEnabled = true;
            this.View_HiddenLocationsSince.Location = new System.Drawing.Point(149, 266);
            this.View_HiddenLocationsSince.Name = "View_HiddenLocationsSince";
            this.View_HiddenLocationsSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenLocationsSince.TabIndex = 17;
            // 
            // View_HiddenActivitiesSince
            // 
            this.View_HiddenActivitiesSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenActivitiesSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenActivitiesSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenActivitiesSince.FormattingEnabled = true;
            this.View_HiddenActivitiesSince.Location = new System.Drawing.Point(149, 239);
            this.View_HiddenActivitiesSince.Name = "View_HiddenActivitiesSince";
            this.View_HiddenActivitiesSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenActivitiesSince.TabIndex = 16;
            // 
            // View_HiddenProjectsSince
            // 
            this.View_HiddenProjectsSince.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.View_HiddenProjectsSince.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.View_HiddenProjectsSince.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.View_HiddenProjectsSince.FormattingEnabled = true;
            this.View_HiddenProjectsSince.Location = new System.Drawing.Point(149, 212);
            this.View_HiddenProjectsSince.Name = "View_HiddenProjectsSince";
            this.View_HiddenProjectsSince.Size = new System.Drawing.Size(121, 21);
            this.View_HiddenProjectsSince.TabIndex = 15;
            // 
            // View_HiddenCategories
            // 
            this.View_HiddenCategories.AutoSize = true;
            this.View_HiddenCategories.Location = new System.Drawing.Point(6, 295);
            this.View_HiddenCategories.Name = "View_HiddenCategories";
            this.View_HiddenCategories.Size = new System.Drawing.Size(141, 17);
            this.View_HiddenCategories.TabIndex = 14;
            this.View_HiddenCategories.Text = "Hidden Categories since";
            this.View_HiddenCategories.UseVisualStyleBackColor = true;
            // 
            // View_HiddenLocations
            // 
            this.View_HiddenLocations.AutoSize = true;
            this.View_HiddenLocations.Location = new System.Drawing.Point(6, 268);
            this.View_HiddenLocations.Name = "View_HiddenLocations";
            this.View_HiddenLocations.Size = new System.Drawing.Size(137, 17);
            this.View_HiddenLocations.TabIndex = 13;
            this.View_HiddenLocations.Text = "Hidden Locations since";
            this.View_HiddenLocations.UseVisualStyleBackColor = true;
            // 
            // View_HiddenActivities
            // 
            this.View_HiddenActivities.AutoSize = true;
            this.View_HiddenActivities.Location = new System.Drawing.Point(6, 241);
            this.View_HiddenActivities.Name = "View_HiddenActivities";
            this.View_HiddenActivities.Size = new System.Drawing.Size(133, 17);
            this.View_HiddenActivities.TabIndex = 12;
            this.View_HiddenActivities.Text = "Hidden Activities since";
            this.View_HiddenActivities.UseVisualStyleBackColor = true;
            // 
            // View_HiddenProjects
            // 
            this.View_HiddenProjects.AutoSize = true;
            this.View_HiddenProjects.Location = new System.Drawing.Point(6, 214);
            this.View_HiddenProjects.Name = "View_HiddenProjects";
            this.View_HiddenProjects.Size = new System.Drawing.Size(129, 17);
            this.View_HiddenProjects.TabIndex = 11;
            this.View_HiddenProjects.Text = "Hidden Projects since";
            this.View_HiddenProjects.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_FileName
            // 
            this.View_StatusBar_FileName.AutoSize = true;
            this.View_StatusBar_FileName.Location = new System.Drawing.Point(6, 167);
            this.View_StatusBar_FileName.Name = "View_StatusBar_FileName";
            this.View_StatusBar_FileName.Size = new System.Drawing.Size(127, 17);
            this.View_StatusBar_FileName.TabIndex = 10;
            this.View_StatusBar_FileName.Text = "Currently Opened File";
            this.View_StatusBar_FileName.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "View_StatusBar",
            "View_StatusBar_ProjectName",
            "View_StatusBar_ActivityName",
            "View_StatusBar_ElapsedSinceStart",
            "View_StatusBar_ElapsedProjectToday",
            "View_StatusBar_ElapsedActivityToday",
            "View_StatusBar_ElapsedAllToday",
            "View_StatusBar_FileName"});
            this.checkedListBox1.Location = new System.Drawing.Point(149, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(220, 124);
            this.checkedListBox1.TabIndex = 7;
            // 
            // View_StatusBar_ElapsedAllToday
            // 
            this.View_StatusBar_ElapsedAllToday.AutoSize = true;
            this.View_StatusBar_ElapsedAllToday.Location = new System.Drawing.Point(6, 144);
            this.View_StatusBar_ElapsedAllToday.Name = "View_StatusBar_ElapsedAllToday";
            this.View_StatusBar_ElapsedAllToday.Size = new System.Drawing.Size(111, 17);
            this.View_StatusBar_ElapsedAllToday.TabIndex = 6;
            this.View_StatusBar_ElapsedAllToday.Text = "Elapsed All Today";
            this.View_StatusBar_ElapsedAllToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedActivityToday
            // 
            this.View_StatusBar_ElapsedActivityToday.AutoSize = true;
            this.View_StatusBar_ElapsedActivityToday.Location = new System.Drawing.Point(6, 121);
            this.View_StatusBar_ElapsedActivityToday.Name = "View_StatusBar_ElapsedActivityToday";
            this.View_StatusBar_ElapsedActivityToday.Size = new System.Drawing.Size(134, 17);
            this.View_StatusBar_ElapsedActivityToday.TabIndex = 5;
            this.View_StatusBar_ElapsedActivityToday.Text = "Elapsed Activity Today";
            this.View_StatusBar_ElapsedActivityToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedProjectToday
            // 
            this.View_StatusBar_ElapsedProjectToday.AutoSize = true;
            this.View_StatusBar_ElapsedProjectToday.Location = new System.Drawing.Point(6, 98);
            this.View_StatusBar_ElapsedProjectToday.Name = "View_StatusBar_ElapsedProjectToday";
            this.View_StatusBar_ElapsedProjectToday.Size = new System.Drawing.Size(133, 17);
            this.View_StatusBar_ElapsedProjectToday.TabIndex = 4;
            this.View_StatusBar_ElapsedProjectToday.Text = "Elapsed Project Today";
            this.View_StatusBar_ElapsedProjectToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedSinceStart
            // 
            this.View_StatusBar_ElapsedSinceStart.AutoSize = true;
            this.View_StatusBar_ElapsedSinceStart.Location = new System.Drawing.Point(6, 75);
            this.View_StatusBar_ElapsedSinceStart.Name = "View_StatusBar_ElapsedSinceStart";
            this.View_StatusBar_ElapsedSinceStart.Size = new System.Drawing.Size(119, 17);
            this.View_StatusBar_ElapsedSinceStart.TabIndex = 3;
            this.View_StatusBar_ElapsedSinceStart.Text = "Elapsed Since Start";
            this.View_StatusBar_ElapsedSinceStart.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ActivityName
            // 
            this.View_StatusBar_ActivityName.AutoSize = true;
            this.View_StatusBar_ActivityName.Location = new System.Drawing.Point(6, 52);
            this.View_StatusBar_ActivityName.Name = "View_StatusBar_ActivityName";
            this.View_StatusBar_ActivityName.Size = new System.Drawing.Size(91, 17);
            this.View_StatusBar_ActivityName.TabIndex = 2;
            this.View_StatusBar_ActivityName.Text = "Activity Name";
            this.View_StatusBar_ActivityName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ProjectName
            // 
            this.View_StatusBar_ProjectName.AutoSize = true;
            this.View_StatusBar_ProjectName.Location = new System.Drawing.Point(6, 29);
            this.View_StatusBar_ProjectName.Name = "View_StatusBar_ProjectName";
            this.View_StatusBar_ProjectName.Size = new System.Drawing.Size(90, 17);
            this.View_StatusBar_ProjectName.TabIndex = 1;
            this.View_StatusBar_ProjectName.Text = "Project Name";
            this.View_StatusBar_ProjectName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar
            // 
            this.View_StatusBar.AutoSize = true;
            this.View_StatusBar.Location = new System.Drawing.Point(6, 6);
            this.View_StatusBar.Name = "View_StatusBar";
            this.View_StatusBar.Size = new System.Drawing.Size(75, 17);
            this.View_StatusBar.TabIndex = 0;
            this.View_StatusBar.Text = "Status Bar";
            this.View_StatusBar.UseVisualStyleBackColor = true;
            // 
            // BehaviorPage
            // 
            this.BehaviorPage.Controls.Add(this.AnnoyGroup);
            this.BehaviorPage.Controls.Add(this.WindowControlGroup);
            this.BehaviorPage.Controls.Add(this.TitleBarGroup);
            this.BehaviorPage.Location = new System.Drawing.Point(4, 22);
            this.BehaviorPage.Name = "BehaviorPage";
            this.BehaviorPage.Padding = new System.Windows.Forms.Padding(3);
            this.BehaviorPage.Size = new System.Drawing.Size(375, 387);
            this.BehaviorPage.TabIndex = 3;
            this.BehaviorPage.Text = "Behavior";
            this.BehaviorPage.UseVisualStyleBackColor = true;
            // 
            // AnnoyGroup
            // 
            this.AnnoyGroup.Controls.Add(this.label10);
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_NoRunningPromptAmount);
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_NoRunningPrompt);
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_ProjectFollowsActivity);
            this.AnnoyGroup.Controls.Add(this.Behavior_Annoy_ActivityFollowsProject);
            this.AnnoyGroup.Location = new System.Drawing.Point(6, 265);
            this.AnnoyGroup.Name = "AnnoyGroup";
            this.AnnoyGroup.Size = new System.Drawing.Size(363, 100);
            this.AnnoyGroup.TabIndex = 2;
            this.AnnoyGroup.TabStop = false;
            this.AnnoyGroup.Text = "Annoyances";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 7;
            this.label10.Text = "minutes";
            // 
            // Behavior_Annoy_NoRunningPromptAmount
            // 
            this.Behavior_Annoy_NoRunningPromptAmount.Location = new System.Drawing.Point(192, 64);
            this.Behavior_Annoy_NoRunningPromptAmount.Name = "Behavior_Annoy_NoRunningPromptAmount";
            this.Behavior_Annoy_NoRunningPromptAmount.Size = new System.Drawing.Size(53, 20);
            this.Behavior_Annoy_NoRunningPromptAmount.TabIndex = 6;
            // 
            // Behavior_Annoy_NoRunningPrompt
            // 
            this.Behavior_Annoy_NoRunningPrompt.AutoSize = true;
            this.Behavior_Annoy_NoRunningPrompt.Location = new System.Drawing.Point(17, 65);
            this.Behavior_Annoy_NoRunningPrompt.Name = "Behavior_Annoy_NoRunningPrompt";
            this.Behavior_Annoy_NoRunningPrompt.Size = new System.Drawing.Size(169, 17);
            this.Behavior_Annoy_NoRunningPrompt.TabIndex = 5;
            this.Behavior_Annoy_NoRunningPrompt.Text = "Prompt if no timer running after";
            this.Behavior_Annoy_NoRunningPrompt.UseVisualStyleBackColor = true;
            // 
            // Behavior_Annoy_ProjectFollowsActivity
            // 
            this.Behavior_Annoy_ProjectFollowsActivity.AutoSize = true;
            this.Behavior_Annoy_ProjectFollowsActivity.Location = new System.Drawing.Point(16, 42);
            this.Behavior_Annoy_ProjectFollowsActivity.Name = "Behavior_Annoy_ProjectFollowsActivity";
            this.Behavior_Annoy_ProjectFollowsActivity.Size = new System.Drawing.Size(174, 17);
            this.Behavior_Annoy_ProjectFollowsActivity.TabIndex = 4;
            this.Behavior_Annoy_ProjectFollowsActivity.Text = "Project follows selected Activity";
            this.Behavior_Annoy_ProjectFollowsActivity.UseVisualStyleBackColor = true;
            // 
            // Behavior_Annoy_ActivityFollowsProject
            // 
            this.Behavior_Annoy_ActivityFollowsProject.AutoSize = true;
            this.Behavior_Annoy_ActivityFollowsProject.Location = new System.Drawing.Point(17, 19);
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
            this.WindowControlGroup.Location = new System.Drawing.Point(6, 159);
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
            // 
            // TitleBarGroup
            // 
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_Template);
            this.TitleBarGroup.Controls.Add(this.label9);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_ElapsedAllToday);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_ElapsedActivityToday);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_ElapsedProjectToday);
            this.TitleBarGroup.Controls.Add(this.Behavior_TitleBar_ElapsedSinceStart);
            this.TitleBarGroup.Location = new System.Drawing.Point(6, 6);
            this.TitleBarGroup.Name = "TitleBarGroup";
            this.TitleBarGroup.Size = new System.Drawing.Size(363, 147);
            this.TitleBarGroup.TabIndex = 0;
            this.TitleBarGroup.TabStop = false;
            this.TitleBarGroup.Text = "Title Bar";
            // 
            // Behavior_TitleBar_Template
            // 
            this.Behavior_TitleBar_Template.Location = new System.Drawing.Point(74, 114);
            this.Behavior_TitleBar_Template.Name = "Behavior_TitleBar_Template";
            this.Behavior_TitleBar_Template.Size = new System.Drawing.Size(171, 20);
            this.Behavior_TitleBar_Template.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Template:";
            // 
            // Behavior_TitleBar_ElapsedAllToday
            // 
            this.Behavior_TitleBar_ElapsedAllToday.AutoSize = true;
            this.Behavior_TitleBar_ElapsedAllToday.Location = new System.Drawing.Point(17, 88);
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
            this.Behavior_TitleBar_ElapsedActivityToday.Location = new System.Drawing.Point(17, 65);
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
            this.Behavior_TitleBar_ElapsedProjectToday.Location = new System.Drawing.Point(17, 42);
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
            this.Behavior_TitleBar_ElapsedSinceStart.Location = new System.Drawing.Point(17, 19);
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
            this.ReportPage.Controls.Add(this.Report_StyleSheet);
            this.ReportPage.Controls.Add(this.LabelStyleSheet);
            this.ReportPage.Controls.Add(this.label7);
            this.ReportPage.Controls.Add(this.Report_FontSize);
            this.ReportPage.Controls.Add(this.LabelBaseFontSize);
            this.ReportPage.Controls.Add(this.Report_FontList);
            this.ReportPage.Controls.Add(this.LabelBaseFont);
            this.ReportPage.Location = new System.Drawing.Point(4, 22);
            this.ReportPage.Name = "ReportPage";
            this.ReportPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReportPage.Size = new System.Drawing.Size(375, 387);
            this.ReportPage.TabIndex = 1;
            this.ReportPage.Text = "Report";
            this.ReportPage.UseVisualStyleBackColor = true;
            // 
            // Report_StyleSheet
            // 
            this.Report_StyleSheet.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.Report_StyleSheet.Location = new System.Drawing.Point(105, 147);
            this.Report_StyleSheet.Name = "Report_StyleSheet";
            this.Report_StyleSheet.ReadOnly = true;
            this.Report_StyleSheet.Size = new System.Drawing.Size(264, 190);
            this.Report_StyleSheet.TabIndex = 6;
            this.Report_StyleSheet.Text = "Paste custom CSS style sheet here for more control over report appearance. See th" +
    "e help file for more details and samples.";
            // 
            // LabelStyleSheet
            // 
            this.LabelStyleSheet.AutoSize = true;
            this.LabelStyleSheet.Location = new System.Drawing.Point(6, 150);
            this.LabelStyleSheet.Name = "LabelStyleSheet";
            this.LabelStyleSheet.Size = new System.Drawing.Size(61, 13);
            this.LabelStyleSheet.TabIndex = 5;
            this.LabelStyleSheet.Text = "Style Sheet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(180, 123);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Points";
            // 
            // Report_FontSize
            // 
            this.Report_FontSize.Location = new System.Drawing.Point(105, 119);
            this.Report_FontSize.Name = "Report_FontSize";
            this.Report_FontSize.Size = new System.Drawing.Size(69, 20);
            this.Report_FontSize.TabIndex = 3;
            // 
            // LabelBaseFontSize
            // 
            this.LabelBaseFontSize.AutoSize = true;
            this.LabelBaseFontSize.Location = new System.Drawing.Point(6, 123);
            this.LabelBaseFontSize.Name = "LabelBaseFontSize";
            this.LabelBaseFontSize.Size = new System.Drawing.Size(81, 13);
            this.LabelBaseFontSize.TabIndex = 2;
            this.LabelBaseFontSize.Text = "Base Font Size:";
            // 
            // Report_FontList
            // 
            this.Report_FontList.FormattingEnabled = true;
            this.Report_FontList.Location = new System.Drawing.Point(105, 15);
            this.Report_FontList.Name = "Report_FontList";
            this.Report_FontList.Size = new System.Drawing.Size(264, 95);
            this.Report_FontList.TabIndex = 1;
            // 
            // LabelBaseFont
            // 
            this.LabelBaseFont.AutoSize = true;
            this.LabelBaseFont.Location = new System.Drawing.Point(6, 15);
            this.LabelBaseFont.Name = "LabelBaseFont";
            this.LabelBaseFont.Size = new System.Drawing.Size(58, 13);
            this.LabelBaseFont.TabIndex = 0;
            this.LabelBaseFont.Text = "Base Font:";
            // 
            // KeyboardPage
            // 
            this.KeyboardPage.Controls.Add(this.ShortcutGroup);
            this.KeyboardPage.Controls.Add(this.wFunctionList);
            this.KeyboardPage.Location = new System.Drawing.Point(4, 22);
            this.KeyboardPage.Name = "KeyboardPage";
            this.KeyboardPage.Padding = new System.Windows.Forms.Padding(3);
            this.KeyboardPage.Size = new System.Drawing.Size(375, 387);
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
            this.ShortcutGroup.Location = new System.Drawing.Point(6, 299);
            this.ShortcutGroup.Name = "ShortcutGroup";
            this.ShortcutGroup.Size = new System.Drawing.Size(365, 82);
            this.ShortcutGroup.TabIndex = 9;
            this.ShortcutGroup.TabStop = false;
            this.ShortcutGroup.Text = "Shortcut";
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
            "Delete",
            "D0",
            "D1",
            "D2",
            "D3",
            "D4",
            "D5",
            "D6",
            "D7",
            "D8",
            "D9",
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
            "F24"});
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
            this.wFunctionList.Location = new System.Drawing.Point(6, 6);
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "SmallFolder.png");
            this.imageList1.Images.SetKeyName(1, "SmallProject.png");
            this.imageList1.Images.SetKeyName(2, "SmallActivity.png");
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
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 0;
            // 
            // Options
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(559, 467);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.SelectorPanel);
            this.Controls.Add(this.ButtonPanel);
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
            this.ButtonPanel.ResumeLayout(false);
            this.SelectorPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.OptionsPanelCollection.ResumeLayout(false);
            this.LayoutPage.ResumeLayout(false);
            this.SortingGroup.ResumeLayout(false);
            this.SortingGroup.PerformLayout();
            this.PresetGroup.ResumeLayout(false);
            this.PresetGroup.PerformLayout();
            this.DimensionGroup.ResumeLayout(false);
            this.DimensionGroup.PerformLayout();
            this.ViewPage.ResumeLayout(false);
            this.ViewPage.PerformLayout();
            this.BehaviorPage.ResumeLayout(false);
            this.AnnoyGroup.ResumeLayout(false);
            this.AnnoyGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Behavior_Annoy_NoRunningPromptAmount)).EndInit();
            this.WindowControlGroup.ResumeLayout(false);
            this.WindowControlGroup.PerformLayout();
            this.TitleBarGroup.ResumeLayout(false);
            this.TitleBarGroup.PerformLayout();
            this.ReportPage.ResumeLayout(false);
            this.ReportPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Report_FontSize)).EndInit();
            this.KeyboardPage.ResumeLayout(false);
            this.ShortcutGroup.ResumeLayout(false);
            this.ShortcutGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.ListBox PanelSelector;
        //        private Forms.Controls.TablessControl tablessControl1;
        private System.Windows.Forms.Panel SelectorPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TabControl OptionsPanelCollection;
        private System.Windows.Forms.TabPage ViewPage;
        private System.Windows.Forms.TabPage ReportPage;
        private System.Windows.Forms.CheckBox View_StatusBar;
        private System.Windows.Forms.CheckBox View_StatusBar_ActivityName;
        private System.Windows.Forms.CheckBox View_StatusBar_ProjectName;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
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
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox wAlt;
        private System.Windows.Forms.Button AssignKey;
        private System.Windows.Forms.ColumnHeader columnHeader3;

    }
}