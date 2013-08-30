namespace Timekeeper.Forms
{
    partial class Filtering
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Filtering));
            this.ToDateLabel = new System.Windows.Forms.Label();
            this.Presets = new System.Windows.Forms.ComboBox();
            this.FromDateLabel = new System.Windows.Forms.Label();
            this.PresetLabel = new System.Windows.Forms.Label();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.LocationFilter = new System.Windows.Forms.CheckedListBox();
            this.CheckedListBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CheckedListBoxMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedListBoxMenuSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedListBoxMenuInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedListBoxMenuShowHidden = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.ActivityTree = new System.Windows.Forms.TreeView();
            this.TreeViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TreeViewMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewMenuSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewMenuInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewMenuShowHiddenItems = new System.Windows.Forms.ToolStripMenuItem();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.ProjectTree = new System.Windows.Forms.TreeView();
            this.FilterOptionsTabControl = new System.Windows.Forms.TabControl();
            this.CommonTab = new System.Windows.Forms.TabPage();
            this.MemoGroup = new System.Windows.Forms.GroupBox();
            this.MemoLabel = new System.Windows.Forms.Label();
            this.MemoFilter = new System.Windows.Forms.TextBox();
            this.DateRangeGroup = new System.Windows.Forms.GroupBox();
            this.ProjectTab = new System.Windows.Forms.TabPage();
            this.ActivityTab = new System.Windows.Forms.TabPage();
            this.LocationTab = new System.Windows.Forms.TabPage();
            this.CategoryTab = new System.Windows.Forms.TabPage();
            this.CategoryFilter = new System.Windows.Forms.CheckedListBox();
            this.AdvancedTab = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IsLocked = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.DurationOperator = new System.Windows.Forms.ComboBox();
            this.DurationAmount = new System.Windows.Forms.NumericUpDown();
            this.DurationUnit = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ModifyTimePresets = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CreateTimePresets = new System.Windows.Forms.ComboBox();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.CheckedListBoxMenu.SuspendLayout();
            this.TreeViewMenu.SuspendLayout();
            this.FilterOptionsTabControl.SuspendLayout();
            this.CommonTab.SuspendLayout();
            this.MemoGroup.SuspendLayout();
            this.DateRangeGroup.SuspendLayout();
            this.ProjectTab.SuspendLayout();
            this.ActivityTab.SuspendLayout();
            this.LocationTab.SuspendLayout();
            this.CategoryTab.SuspendLayout();
            this.AdvancedTab.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationAmount)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToDateLabel
            // 
            this.ToDateLabel.AutoSize = true;
            this.ToDateLabel.Location = new System.Drawing.Point(14, 78);
            this.ToDateLabel.Name = "ToDateLabel";
            this.ToDateLabel.Size = new System.Drawing.Size(49, 13);
            this.ToDateLabel.TabIndex = 9;
            this.ToDateLabel.Text = "To Date:";
            // 
            // Presets
            // 
            this.Presets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Presets.FormattingEnabled = true;
            this.Presets.Location = new System.Drawing.Point(84, 25);
            this.Presets.Name = "Presets";
            this.Presets.Size = new System.Drawing.Size(121, 21);
            this.Presets.TabIndex = 1;
            this.Presets.SelectedIndexChanged += new System.EventHandler(this.Presets_SelectedIndexChanged);
            // 
            // FromDateLabel
            // 
            this.FromDateLabel.AutoSize = true;
            this.FromDateLabel.Location = new System.Drawing.Point(14, 52);
            this.FromDateLabel.Name = "FromDateLabel";
            this.FromDateLabel.Size = new System.Drawing.Size(59, 13);
            this.FromDateLabel.TabIndex = 8;
            this.FromDateLabel.Text = "From Date:";
            // 
            // PresetLabel
            // 
            this.PresetLabel.AutoSize = true;
            this.PresetLabel.Location = new System.Drawing.Point(14, 25);
            this.PresetLabel.Name = "PresetLabel";
            this.PresetLabel.Size = new System.Drawing.Size(40, 13);
            this.PresetLabel.TabIndex = 7;
            this.PresetLabel.Text = "Preset:";
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "yyyy-MM-dd";
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(84, 78);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(121, 20);
            this.ToDate.TabIndex = 3;
            this.ToDate.Enter += new System.EventHandler(this.ToDate_Enter);
            this.ToDate.Leave += new System.EventHandler(this.ToDate_Leave);
            // 
            // FromDate
            // 
            this.FromDate.CustomFormat = "yyyy-MM-dd";
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDate.Location = new System.Drawing.Point(84, 52);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(121, 20);
            this.FromDate.TabIndex = 2;
            this.FromDate.Enter += new System.EventHandler(this.FromDate_Enter);
            this.FromDate.Leave += new System.EventHandler(this.FromDate_Leave);
            // 
            // LocationFilter
            // 
            this.LocationFilter.ContextMenuStrip = this.CheckedListBoxMenu;
            this.LocationFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocationFilter.FormattingEnabled = true;
            this.LocationFilter.Location = new System.Drawing.Point(3, 3);
            this.LocationFilter.Name = "LocationFilter";
            this.LocationFilter.Size = new System.Drawing.Size(387, 246);
            this.LocationFilter.TabIndex = 5;
            // 
            // CheckedListBoxMenu
            // 
            this.CheckedListBoxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckedListBoxMenuSelectAll,
            this.CheckedListBoxMenuSelectNone,
            this.CheckedListBoxMenuInvertSelection,
            this.CheckedListBoxMenuShowHidden});
            this.CheckedListBoxMenu.Name = "CheckedListBoxMenu";
            this.CheckedListBoxMenu.Size = new System.Drawing.Size(151, 92);
            // 
            // CheckedListBoxMenuSelectAll
            // 
            this.CheckedListBoxMenuSelectAll.Name = "CheckedListBoxMenuSelectAll";
            this.CheckedListBoxMenuSelectAll.Size = new System.Drawing.Size(150, 22);
            this.CheckedListBoxMenuSelectAll.Text = "Select All";
            this.CheckedListBoxMenuSelectAll.Click += new System.EventHandler(this.CheckedListBoxMenuSelectAll_Click);
            // 
            // CheckedListBoxMenuSelectNone
            // 
            this.CheckedListBoxMenuSelectNone.Name = "CheckedListBoxMenuSelectNone";
            this.CheckedListBoxMenuSelectNone.Size = new System.Drawing.Size(150, 22);
            this.CheckedListBoxMenuSelectNone.Text = "Select None";
            this.CheckedListBoxMenuSelectNone.Click += new System.EventHandler(this.CheckedListBoxMenuSelectNone_Click);
            // 
            // CheckedListBoxMenuInvertSelection
            // 
            this.CheckedListBoxMenuInvertSelection.Name = "CheckedListBoxMenuInvertSelection";
            this.CheckedListBoxMenuInvertSelection.Size = new System.Drawing.Size(150, 22);
            this.CheckedListBoxMenuInvertSelection.Text = "Invert Selection";
            this.CheckedListBoxMenuInvertSelection.Click += new System.EventHandler(this.CheckedListBoxMenuInvertSelection_Click);
            // 
            // CheckedListBoxMenuShowHidden
            // 
            this.CheckedListBoxMenuShowHidden.Name = "CheckedListBoxMenuShowHidden";
            this.CheckedListBoxMenuShowHidden.Size = new System.Drawing.Size(150, 22);
            this.CheckedListBoxMenuShowHidden.Text = "Show Hidden";
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(84, 6);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 99;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // OkayButton
            // 
            this.OkayButton.Location = new System.Drawing.Point(3, 6);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 98;
            this.OkayButton.Text = "OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // ActivityTree
            // 
            this.ActivityTree.CheckBoxes = true;
            this.ActivityTree.ContextMenuStrip = this.TreeViewMenu;
            this.ActivityTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActivityTree.ImageIndex = 0;
            this.ActivityTree.ImageList = this.imgSmall;
            this.ActivityTree.Location = new System.Drawing.Point(3, 3);
            this.ActivityTree.Name = "ActivityTree";
            this.ActivityTree.SelectedImageIndex = 0;
            this.ActivityTree.ShowLines = false;
            this.ActivityTree.Size = new System.Drawing.Size(387, 246);
            this.ActivityTree.TabIndex = 0;
            // 
            // TreeViewMenu
            // 
            this.TreeViewMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TreeViewMenuSelectAll,
            this.TreeViewMenuSelectNone,
            this.TreeViewMenuInvertSelection,
            this.TreeViewMenuShowHiddenItems});
            this.TreeViewMenu.Name = "TreeMenu";
            this.TreeViewMenu.Size = new System.Drawing.Size(167, 92);
            // 
            // TreeViewMenuSelectAll
            // 
            this.TreeViewMenuSelectAll.Name = "TreeViewMenuSelectAll";
            this.TreeViewMenuSelectAll.Size = new System.Drawing.Size(166, 22);
            this.TreeViewMenuSelectAll.Text = "Select All";
            this.TreeViewMenuSelectAll.Click += new System.EventHandler(this.MenuSelectAll_Click);
            // 
            // TreeViewMenuSelectNone
            // 
            this.TreeViewMenuSelectNone.Name = "TreeViewMenuSelectNone";
            this.TreeViewMenuSelectNone.Size = new System.Drawing.Size(166, 22);
            this.TreeViewMenuSelectNone.Text = "Select None";
            this.TreeViewMenuSelectNone.Click += new System.EventHandler(this.MenuSelectNone_Click);
            // 
            // TreeViewMenuInvertSelection
            // 
            this.TreeViewMenuInvertSelection.Name = "TreeViewMenuInvertSelection";
            this.TreeViewMenuInvertSelection.Size = new System.Drawing.Size(166, 22);
            this.TreeViewMenuInvertSelection.Text = "Invert Selection";
            this.TreeViewMenuInvertSelection.Click += new System.EventHandler(this.MenuInvertSelection_Click);
            // 
            // TreeViewMenuShowHiddenItems
            // 
            this.TreeViewMenuShowHiddenItems.Name = "TreeViewMenuShowHiddenItems";
            this.TreeViewMenuShowHiddenItems.Size = new System.Drawing.Size(166, 22);
            this.TreeViewMenuShowHiddenItems.Text = "Show Hidden Items";
            // 
            // imgSmall
            // 
            this.imgSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgSmall.ImageStream")));
            this.imgSmall.TransparentColor = System.Drawing.Color.Magenta;
            this.imgSmall.Images.SetKeyName(0, "OpenFolder");
            this.imgSmall.Images.SetKeyName(1, "ClosedFolder");
            this.imgSmall.Images.SetKeyName(2, "Project");
            this.imgSmall.Images.SetKeyName(3, "Activity");
            this.imgSmall.Images.SetKeyName(4, "task-clock1.bmp");
            this.imgSmall.Images.SetKeyName(5, "task-clock2.bmp");
            this.imgSmall.Images.SetKeyName(6, "task-clock3.bmp");
            this.imgSmall.Images.SetKeyName(7, "task-clock4.bmp");
            this.imgSmall.Images.SetKeyName(8, "HiddenItem");
            // 
            // ProjectTree
            // 
            this.ProjectTree.CheckBoxes = true;
            this.ProjectTree.ContextMenuStrip = this.TreeViewMenu;
            this.ProjectTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectTree.ImageIndex = 0;
            this.ProjectTree.ImageList = this.imgSmall;
            this.ProjectTree.Location = new System.Drawing.Point(3, 3);
            this.ProjectTree.Name = "ProjectTree";
            this.ProjectTree.SelectedImageIndex = 0;
            this.ProjectTree.Size = new System.Drawing.Size(387, 246);
            this.ProjectTree.TabIndex = 0;
            // 
            // FilterOptionsTabControl
            // 
            this.FilterOptionsTabControl.Controls.Add(this.CommonTab);
            this.FilterOptionsTabControl.Controls.Add(this.ProjectTab);
            this.FilterOptionsTabControl.Controls.Add(this.ActivityTab);
            this.FilterOptionsTabControl.Controls.Add(this.LocationTab);
            this.FilterOptionsTabControl.Controls.Add(this.CategoryTab);
            this.FilterOptionsTabControl.Controls.Add(this.AdvancedTab);
            this.FilterOptionsTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FilterOptionsTabControl.Location = new System.Drawing.Point(0, 0);
            this.FilterOptionsTabControl.Name = "FilterOptionsTabControl";
            this.FilterOptionsTabControl.SelectedIndex = 0;
            this.FilterOptionsTabControl.Size = new System.Drawing.Size(401, 278);
            this.FilterOptionsTabControl.TabIndex = 0;
            this.FilterOptionsTabControl.Selected += new System.Windows.Forms.TabControlEventHandler(this.FilterOptionsTabControl_Selected);
            // 
            // CommonTab
            // 
            this.CommonTab.Controls.Add(this.MemoGroup);
            this.CommonTab.Controls.Add(this.DateRangeGroup);
            this.CommonTab.Location = new System.Drawing.Point(4, 22);
            this.CommonTab.Name = "CommonTab";
            this.CommonTab.Padding = new System.Windows.Forms.Padding(3);
            this.CommonTab.Size = new System.Drawing.Size(393, 252);
            this.CommonTab.TabIndex = 0;
            this.CommonTab.Text = "Common";
            this.CommonTab.UseVisualStyleBackColor = true;
            // 
            // MemoGroup
            // 
            this.MemoGroup.Controls.Add(this.MemoLabel);
            this.MemoGroup.Controls.Add(this.MemoFilter);
            this.MemoGroup.Location = new System.Drawing.Point(6, 130);
            this.MemoGroup.Name = "MemoGroup";
            this.MemoGroup.Size = new System.Drawing.Size(376, 100);
            this.MemoGroup.TabIndex = 16;
            this.MemoGroup.TabStop = false;
            this.MemoGroup.Text = "Memo";
            // 
            // MemoLabel
            // 
            this.MemoLabel.AutoSize = true;
            this.MemoLabel.Location = new System.Drawing.Point(14, 25);
            this.MemoLabel.Name = "MemoLabel";
            this.MemoLabel.Size = new System.Drawing.Size(51, 13);
            this.MemoLabel.TabIndex = 15;
            this.MemoLabel.Text = "Contains:";
            // 
            // MemoFilter
            // 
            this.MemoFilter.Location = new System.Drawing.Point(84, 22);
            this.MemoFilter.Name = "MemoFilter";
            this.MemoFilter.Size = new System.Drawing.Size(278, 20);
            this.MemoFilter.TabIndex = 4;
            // 
            // DateRangeGroup
            // 
            this.DateRangeGroup.Controls.Add(this.PresetLabel);
            this.DateRangeGroup.Controls.Add(this.ToDateLabel);
            this.DateRangeGroup.Controls.Add(this.Presets);
            this.DateRangeGroup.Controls.Add(this.FromDateLabel);
            this.DateRangeGroup.Controls.Add(this.FromDate);
            this.DateRangeGroup.Controls.Add(this.ToDate);
            this.DateRangeGroup.Location = new System.Drawing.Point(6, 6);
            this.DateRangeGroup.Name = "DateRangeGroup";
            this.DateRangeGroup.Size = new System.Drawing.Size(376, 118);
            this.DateRangeGroup.TabIndex = 13;
            this.DateRangeGroup.TabStop = false;
            this.DateRangeGroup.Text = "Date Range";
            // 
            // ProjectTab
            // 
            this.ProjectTab.Controls.Add(this.ProjectTree);
            this.ProjectTab.Location = new System.Drawing.Point(4, 22);
            this.ProjectTab.Name = "ProjectTab";
            this.ProjectTab.Padding = new System.Windows.Forms.Padding(3);
            this.ProjectTab.Size = new System.Drawing.Size(393, 252);
            this.ProjectTab.TabIndex = 3;
            this.ProjectTab.Text = "Projects";
            this.ProjectTab.UseVisualStyleBackColor = true;
            // 
            // ActivityTab
            // 
            this.ActivityTab.Controls.Add(this.ActivityTree);
            this.ActivityTab.Location = new System.Drawing.Point(4, 22);
            this.ActivityTab.Name = "ActivityTab";
            this.ActivityTab.Padding = new System.Windows.Forms.Padding(3);
            this.ActivityTab.Size = new System.Drawing.Size(393, 252);
            this.ActivityTab.TabIndex = 4;
            this.ActivityTab.Text = "Activities";
            this.ActivityTab.UseVisualStyleBackColor = true;
            // 
            // LocationTab
            // 
            this.LocationTab.Controls.Add(this.LocationFilter);
            this.LocationTab.Location = new System.Drawing.Point(4, 22);
            this.LocationTab.Name = "LocationTab";
            this.LocationTab.Padding = new System.Windows.Forms.Padding(3);
            this.LocationTab.Size = new System.Drawing.Size(393, 252);
            this.LocationTab.TabIndex = 1;
            this.LocationTab.Text = "Locations";
            this.LocationTab.UseVisualStyleBackColor = true;
            // 
            // CategoryTab
            // 
            this.CategoryTab.Controls.Add(this.CategoryFilter);
            this.CategoryTab.Location = new System.Drawing.Point(4, 22);
            this.CategoryTab.Name = "CategoryTab";
            this.CategoryTab.Padding = new System.Windows.Forms.Padding(3);
            this.CategoryTab.Size = new System.Drawing.Size(393, 252);
            this.CategoryTab.TabIndex = 5;
            this.CategoryTab.Text = "Categories";
            this.CategoryTab.UseVisualStyleBackColor = true;
            // 
            // CategoryFilter
            // 
            this.CategoryFilter.ContextMenuStrip = this.CheckedListBoxMenu;
            this.CategoryFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CategoryFilter.FormattingEnabled = true;
            this.CategoryFilter.Location = new System.Drawing.Point(3, 3);
            this.CategoryFilter.Name = "CategoryFilter";
            this.CategoryFilter.Size = new System.Drawing.Size(387, 246);
            this.CategoryFilter.TabIndex = 7;
            // 
            // AdvancedTab
            // 
            this.AdvancedTab.Controls.Add(this.groupBox3);
            this.AdvancedTab.Controls.Add(this.groupBox2);
            this.AdvancedTab.Controls.Add(this.groupBox1);
            this.AdvancedTab.Location = new System.Drawing.Point(4, 22);
            this.AdvancedTab.Name = "AdvancedTab";
            this.AdvancedTab.Padding = new System.Windows.Forms.Padding(3);
            this.AdvancedTab.Size = new System.Drawing.Size(393, 252);
            this.AdvancedTab.TabIndex = 2;
            this.AdvancedTab.Text = "Advanced";
            this.AdvancedTab.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.IsLocked);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Location = new System.Drawing.Point(6, 171);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(379, 68);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Special Needs";
            // 
            // IsLocked
            // 
            this.IsLocked.AutoSize = true;
            this.IsLocked.Location = new System.Drawing.Point(20, 19);
            this.IsLocked.Name = "IsLocked";
            this.IsLocked.Size = new System.Drawing.Size(120, 17);
            this.IsLocked.TabIndex = 6;
            this.IsLocked.Text = "Find Locked Entries";
            this.IsLocked.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(20, 42);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(141, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Find Overlapping Entries";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DurationLabel);
            this.groupBox2.Controls.Add(this.DurationOperator);
            this.groupBox2.Controls.Add(this.DurationAmount);
            this.groupBox2.Controls.Add(this.DurationUnit);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 66);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Duration";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(12, 32);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(61, 13);
            this.DurationLabel.TabIndex = 5;
            this.DurationLabel.Text = "Duration Is:";
            // 
            // DurationOperator
            // 
            this.DurationOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DurationOperator.FormattingEnabled = true;
            this.DurationOperator.Items.AddRange(new object[] {
            "Any",
            "Greater Than",
            "Less Than",
            "Equal To"});
            this.DurationOperator.Location = new System.Drawing.Point(79, 29);
            this.DurationOperator.Name = "DurationOperator";
            this.DurationOperator.Size = new System.Drawing.Size(121, 21);
            this.DurationOperator.TabIndex = 1;
            this.DurationOperator.SelectedIndexChanged += new System.EventHandler(this.DurationOperator_SelectedIndexChanged);
            // 
            // DurationAmount
            // 
            this.DurationAmount.Enabled = false;
            this.DurationAmount.Location = new System.Drawing.Point(206, 30);
            this.DurationAmount.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.DurationAmount.Name = "DurationAmount";
            this.DurationAmount.Size = new System.Drawing.Size(45, 20);
            this.DurationAmount.TabIndex = 2;
            // 
            // DurationUnit
            // 
            this.DurationUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DurationUnit.Enabled = false;
            this.DurationUnit.FormattingEnabled = true;
            this.DurationUnit.Items.AddRange(new object[] {
            "Minutes",
            "Hours"});
            this.DurationUnit.Location = new System.Drawing.Point(257, 29);
            this.DurationUnit.Name = "DurationUnit";
            this.DurationUnit.Size = new System.Drawing.Size(81, 21);
            this.DurationUnit.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ModifyTimePresets);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.CreateTimePresets);
            this.groupBox1.Location = new System.Drawing.Point(6, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(379, 87);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entry Meta Data";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Where entry last modified";
            // 
            // ModifyTimePresets
            // 
            this.ModifyTimePresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ModifyTimePresets.FormattingEnabled = true;
            this.ModifyTimePresets.Location = new System.Drawing.Point(146, 51);
            this.ModifyTimePresets.Name = "ModifyTimePresets";
            this.ModifyTimePresets.Size = new System.Drawing.Size(121, 21);
            this.ModifyTimePresets.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Where entry created";
            // 
            // CreateTimePresets
            // 
            this.CreateTimePresets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CreateTimePresets.FormattingEnabled = true;
            this.CreateTimePresets.Location = new System.Drawing.Point(146, 24);
            this.CreateTimePresets.Name = "CreateTimePresets";
            this.CreateTimePresets.Size = new System.Drawing.Size(121, 21);
            this.CreateTimePresets.TabIndex = 4;
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.ButtonPanel);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 278);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(401, 34);
            this.BottomPanel.TabIndex = 17;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.OkayButton);
            this.ButtonPanel.Controls.Add(this.CloseButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.ButtonPanel.Location = new System.Drawing.Point(237, 0);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(164, 34);
            this.ButtonPanel.TabIndex = 0;
            // 
            // Filtering
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(401, 312);
            this.Controls.Add(this.FilterOptionsTabControl);
            this.Controls.Add(this.BottomPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filtering";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Filtering";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Filtering_FormClosing);
            this.Load += new System.EventHandler(this.Filtering_Load);
            this.CheckedListBoxMenu.ResumeLayout(false);
            this.TreeViewMenu.ResumeLayout(false);
            this.FilterOptionsTabControl.ResumeLayout(false);
            this.CommonTab.ResumeLayout(false);
            this.MemoGroup.ResumeLayout(false);
            this.MemoGroup.PerformLayout();
            this.DateRangeGroup.ResumeLayout(false);
            this.DateRangeGroup.PerformLayout();
            this.ProjectTab.ResumeLayout(false);
            this.ActivityTab.ResumeLayout(false);
            this.LocationTab.ResumeLayout(false);
            this.CategoryTab.ResumeLayout(false);
            this.AdvancedTab.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationAmount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox LocationFilter;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TreeView ActivityTree;
        private System.Windows.Forms.TreeView ProjectTree;
        private System.Windows.Forms.ImageList imgSmall;
        private System.Windows.Forms.ContextMenuStrip TreeViewMenu;
        private System.Windows.Forms.ToolStripMenuItem TreeViewMenuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem TreeViewMenuSelectNone;
        private System.Windows.Forms.ToolStripMenuItem TreeViewMenuInvertSelection;
        private System.Windows.Forms.ToolStripMenuItem TreeViewMenuShowHiddenItems;
        private System.Windows.Forms.ContextMenuStrip CheckedListBoxMenu;
        private System.Windows.Forms.ToolStripMenuItem CheckedListBoxMenuSelectAll;
        private System.Windows.Forms.ToolStripMenuItem CheckedListBoxMenuSelectNone;
        private System.Windows.Forms.ToolStripMenuItem CheckedListBoxMenuInvertSelection;
        private System.Windows.Forms.ToolStripMenuItem CheckedListBoxMenuShowHidden;
        private System.Windows.Forms.Label ToDateLabel;
        public System.Windows.Forms.ComboBox Presets;
        private System.Windows.Forms.Label FromDateLabel;
        private System.Windows.Forms.Label PresetLabel;
        public System.Windows.Forms.DateTimePicker ToDate;
        public System.Windows.Forms.DateTimePicker FromDate;
        private System.Windows.Forms.TabControl FilterOptionsTabControl;
        private System.Windows.Forms.TabPage CommonTab;
        private System.Windows.Forms.TabPage LocationTab;
        private System.Windows.Forms.TabPage AdvancedTab;
        private System.Windows.Forms.GroupBox DateRangeGroup;
        private System.Windows.Forms.TabPage ProjectTab;
        private System.Windows.Forms.TabPage ActivityTab;
        private System.Windows.Forms.GroupBox MemoGroup;
        private System.Windows.Forms.Label MemoLabel;
        private System.Windows.Forms.TextBox MemoFilter;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.ComboBox DurationOperator;
        private System.Windows.Forms.ComboBox DurationUnit;
        private System.Windows.Forms.NumericUpDown DurationAmount;
        private System.Windows.Forms.TabPage CategoryTab;
        private System.Windows.Forms.CheckedListBox CategoryFilter;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox ModifyTimePresets;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox CreateTimePresets;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox IsLocked;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}