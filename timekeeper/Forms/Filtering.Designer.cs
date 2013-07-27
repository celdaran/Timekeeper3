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
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.SortGroupBox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SortBy3 = new System.Windows.Forms.ComboBox();
            this.SortBy2 = new System.Windows.Forms.ComboBox();
            this.SortBy1 = new System.Windows.Forms.ComboBox();
            this.DateGroupBox = new System.Windows.Forms.GroupBox();
            this.FilterGroupBox = new System.Windows.Forms.GroupBox();
            this.DurationLabel = new System.Windows.Forms.Label();
            this.MemoLabel = new System.Windows.Forms.Label();
            this.DurationOperator = new System.Windows.Forms.ComboBox();
            this.MemoFilter = new System.Windows.Forms.TextBox();
            this.DurationAmount = new System.Windows.Forms.NumericUpDown();
            this.DurationUnit = new System.Windows.Forms.ComboBox();
            this.LocationFilter = new System.Windows.Forms.CheckedListBox();
            this.CheckedListBoxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CheckedListBoxMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedListBoxMenuSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedListBoxMenuInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.CheckedListBoxMenuShowHidden = new System.Windows.Forms.ToolStripMenuItem();
            this.CategoryLabel = new System.Windows.Forms.Label();
            this.CategoryFilter = new System.Windows.Forms.CheckedListBox();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Splitter = new System.Windows.Forms.SplitContainer();
            this.ActivityTree = new System.Windows.Forms.TreeView();
            this.TreeViewMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TreeViewMenuSelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewMenuSelectNone = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewMenuInvertSelection = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewMenuShowHiddenItems = new System.Windows.Forms.ToolStripMenuItem();
            this.imgSmall = new System.Windows.Forms.ImageList(this.components);
            this.ProjectTree = new System.Windows.Forms.TreeView();
            this.BottomPanel.SuspendLayout();
            this.SortGroupBox.SuspendLayout();
            this.FilterGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationAmount)).BeginInit();
            this.CheckedListBoxMenu.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).BeginInit();
            this.Splitter.Panel1.SuspendLayout();
            this.Splitter.Panel2.SuspendLayout();
            this.Splitter.SuspendLayout();
            this.TreeViewMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.SortGroupBox);
            this.BottomPanel.Controls.Add(this.DateGroupBox);
            this.BottomPanel.Controls.Add(this.FilterGroupBox);
            this.BottomPanel.Controls.Add(this.CloseButton);
            this.BottomPanel.Controls.Add(this.OkayButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 120);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(612, 272);
            this.BottomPanel.TabIndex = 17;
            // 
            // SortGroupBox
            // 
            this.SortGroupBox.Controls.Add(this.label3);
            this.SortGroupBox.Controls.Add(this.label2);
            this.SortGroupBox.Controls.Add(this.label1);
            this.SortGroupBox.Controls.Add(this.SortBy3);
            this.SortGroupBox.Controls.Add(this.SortBy2);
            this.SortGroupBox.Controls.Add(this.SortBy1);
            this.SortGroupBox.Location = new System.Drawing.Point(12, 132);
            this.SortGroupBox.Name = "SortGroupBox";
            this.SortGroupBox.Size = new System.Drawing.Size(235, 104);
            this.SortGroupBox.TabIndex = 18;
            this.SortGroupBox.TabStop = false;
            this.SortGroupBox.Text = "Sorting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "And Then By:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Then By:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sort By:";
            // 
            // SortBy3
            // 
            this.SortBy3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortBy3.Enabled = false;
            this.SortBy3.FormattingEnabled = true;
            this.SortBy3.Items.AddRange(new object[] {
            "(none)",
            "Date/Time",
            "Activity",
            "Project",
            "Duration",
            "Location",
            "Category",
            "External Id",
            "Internal Id"});
            this.SortBy3.Location = new System.Drawing.Point(93, 73);
            this.SortBy3.Name = "SortBy3";
            this.SortBy3.Size = new System.Drawing.Size(121, 21);
            this.SortBy3.TabIndex = 2;
            // 
            // SortBy2
            // 
            this.SortBy2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortBy2.Enabled = false;
            this.SortBy2.FormattingEnabled = true;
            this.SortBy2.Items.AddRange(new object[] {
            "(none)",
            "Date/Time",
            "Activity",
            "Project",
            "Duration",
            "Location",
            "Category",
            "External Id",
            "Internal Id"});
            this.SortBy2.Location = new System.Drawing.Point(93, 46);
            this.SortBy2.Name = "SortBy2";
            this.SortBy2.Size = new System.Drawing.Size(121, 21);
            this.SortBy2.TabIndex = 1;
            this.SortBy2.SelectedIndexChanged += new System.EventHandler(this.SortBy2_SelectedIndexChanged);
            // 
            // SortBy1
            // 
            this.SortBy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortBy1.FormattingEnabled = true;
            this.SortBy1.Items.AddRange(new object[] {
            "(none)",
            "Date/Time",
            "Activity",
            "Project",
            "Duration",
            "Location",
            "Category",
            "External Id",
            "Internal Id"});
            this.SortBy1.Location = new System.Drawing.Point(93, 19);
            this.SortBy1.Name = "SortBy1";
            this.SortBy1.Size = new System.Drawing.Size(121, 21);
            this.SortBy1.TabIndex = 0;
            this.SortBy1.SelectedIndexChanged += new System.EventHandler(this.SortBy1_SelectedIndexChanged);
            // 
            // DateGroupBox
            // 
            this.DateGroupBox.Location = new System.Drawing.Point(12, 12);
            this.DateGroupBox.Name = "DateGroupBox";
            this.DateGroupBox.Size = new System.Drawing.Size(235, 113);
            this.DateGroupBox.TabIndex = 17;
            this.DateGroupBox.TabStop = false;
            this.DateGroupBox.Text = "Date Range";
            // 
            // FilterGroupBox
            // 
            this.FilterGroupBox.Controls.Add(this.DurationLabel);
            this.FilterGroupBox.Controls.Add(this.MemoLabel);
            this.FilterGroupBox.Controls.Add(this.DurationOperator);
            this.FilterGroupBox.Controls.Add(this.MemoFilter);
            this.FilterGroupBox.Controls.Add(this.DurationAmount);
            this.FilterGroupBox.Controls.Add(this.DurationUnit);
            this.FilterGroupBox.Controls.Add(this.LocationFilter);
            this.FilterGroupBox.Controls.Add(this.CategoryLabel);
            this.FilterGroupBox.Controls.Add(this.CategoryFilter);
            this.FilterGroupBox.Controls.Add(this.LocationLabel);
            this.FilterGroupBox.Location = new System.Drawing.Point(253, 12);
            this.FilterGroupBox.Name = "FilterGroupBox";
            this.FilterGroupBox.Size = new System.Drawing.Size(347, 224);
            this.FilterGroupBox.TabIndex = 14;
            this.FilterGroupBox.TabStop = false;
            this.FilterGroupBox.Text = "Additional Filtering";
            // 
            // DurationLabel
            // 
            this.DurationLabel.AutoSize = true;
            this.DurationLabel.Location = new System.Drawing.Point(20, 53);
            this.DurationLabel.Name = "DurationLabel";
            this.DurationLabel.Size = new System.Drawing.Size(61, 13);
            this.DurationLabel.TabIndex = 1;
            this.DurationLabel.Text = "Duration Is:";
            // 
            // MemoLabel
            // 
            this.MemoLabel.AutoSize = true;
            this.MemoLabel.Location = new System.Drawing.Point(20, 26);
            this.MemoLabel.Name = "MemoLabel";
            this.MemoLabel.Size = new System.Drawing.Size(83, 13);
            this.MemoLabel.TabIndex = 13;
            this.MemoLabel.Text = "Memo Contains:";
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
            this.DurationOperator.Location = new System.Drawing.Point(106, 49);
            this.DurationOperator.Name = "DurationOperator";
            this.DurationOperator.Size = new System.Drawing.Size(95, 21);
            this.DurationOperator.TabIndex = 2;
            this.DurationOperator.SelectedIndexChanged += new System.EventHandler(this.DurationOperator_SelectedIndexChanged);
            // 
            // MemoFilter
            // 
            this.MemoFilter.Location = new System.Drawing.Point(106, 23);
            this.MemoFilter.Name = "MemoFilter";
            this.MemoFilter.Size = new System.Drawing.Size(226, 20);
            this.MemoFilter.TabIndex = 12;
            // 
            // DurationAmount
            // 
            this.DurationAmount.Enabled = false;
            this.DurationAmount.Location = new System.Drawing.Point(207, 50);
            this.DurationAmount.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.DurationAmount.Name = "DurationAmount";
            this.DurationAmount.Size = new System.Drawing.Size(45, 20);
            this.DurationAmount.TabIndex = 3;
            // 
            // DurationUnit
            // 
            this.DurationUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DurationUnit.Enabled = false;
            this.DurationUnit.FormattingEnabled = true;
            this.DurationUnit.Items.AddRange(new object[] {
            "Minutes",
            "Hours"});
            this.DurationUnit.Location = new System.Drawing.Point(258, 50);
            this.DurationUnit.Name = "DurationUnit";
            this.DurationUnit.Size = new System.Drawing.Size(74, 21);
            this.DurationUnit.TabIndex = 4;
            // 
            // LocationFilter
            // 
            this.LocationFilter.ContextMenuStrip = this.CheckedListBoxMenu;
            this.LocationFilter.FormattingEnabled = true;
            this.LocationFilter.Location = new System.Drawing.Point(106, 76);
            this.LocationFilter.Name = "LocationFilter";
            this.LocationFilter.Size = new System.Drawing.Size(226, 64);
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
            // CategoryLabel
            // 
            this.CategoryLabel.AutoSize = true;
            this.CategoryLabel.Location = new System.Drawing.Point(20, 150);
            this.CategoryLabel.Name = "CategoryLabel";
            this.CategoryLabel.Size = new System.Drawing.Size(60, 13);
            this.CategoryLabel.TabIndex = 8;
            this.CategoryLabel.Text = "Categories:";
            // 
            // CategoryFilter
            // 
            this.CategoryFilter.ContextMenuStrip = this.CheckedListBoxMenu;
            this.CategoryFilter.FormattingEnabled = true;
            this.CategoryFilter.Location = new System.Drawing.Point(106, 150);
            this.CategoryFilter.Name = "CategoryFilter";
            this.CategoryFilter.Size = new System.Drawing.Size(226, 64);
            this.CategoryFilter.TabIndex = 6;
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Location = new System.Drawing.Point(20, 76);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(56, 13);
            this.LocationLabel.TabIndex = 7;
            this.LocationLabel.Text = "Locations:";
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(525, 242);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 16;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // OkayButton
            // 
            this.OkayButton.Location = new System.Drawing.Point(444, 242);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 15;
            this.OkayButton.Text = "OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.Splitter);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(612, 120);
            this.TopPanel.TabIndex = 0;
            // 
            // Splitter
            // 
            this.Splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Splitter.Location = new System.Drawing.Point(0, 0);
            this.Splitter.Name = "Splitter";
            // 
            // Splitter.Panel1
            // 
            this.Splitter.Panel1.Controls.Add(this.ActivityTree);
            // 
            // Splitter.Panel2
            // 
            this.Splitter.Panel2.Controls.Add(this.ProjectTree);
            this.Splitter.Size = new System.Drawing.Size(612, 120);
            this.Splitter.SplitterDistance = 306;
            this.Splitter.TabIndex = 0;
            this.Splitter.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Splitter_MouseDoubleClick);
            // 
            // ActivityTree
            // 
            this.ActivityTree.CheckBoxes = true;
            this.ActivityTree.ContextMenuStrip = this.TreeViewMenu;
            this.ActivityTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ActivityTree.ImageIndex = 0;
            this.ActivityTree.ImageList = this.imgSmall;
            this.ActivityTree.Location = new System.Drawing.Point(0, 0);
            this.ActivityTree.Name = "ActivityTree";
            this.ActivityTree.SelectedImageIndex = 0;
            this.ActivityTree.ShowLines = false;
            this.ActivityTree.Size = new System.Drawing.Size(306, 120);
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
            this.ProjectTree.Location = new System.Drawing.Point(0, 0);
            this.ProjectTree.Name = "ProjectTree";
            this.ProjectTree.SelectedImageIndex = 0;
            this.ProjectTree.ShowRootLines = false;
            this.ProjectTree.Size = new System.Drawing.Size(302, 120);
            this.ProjectTree.TabIndex = 0;
            // 
            // Filtering
            // 
            this.AcceptButton = this.OkayButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(612, 392);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.BottomPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Filtering";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Filtering";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Filtering_FormClosing);
            this.Load += new System.EventHandler(this.Filtering_Load);
            this.BottomPanel.ResumeLayout(false);
            this.SortGroupBox.ResumeLayout(false);
            this.SortGroupBox.PerformLayout();
            this.FilterGroupBox.ResumeLayout(false);
            this.FilterGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DurationAmount)).EndInit();
            this.CheckedListBoxMenu.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.Splitter.Panel1.ResumeLayout(false);
            this.Splitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Splitter)).EndInit();
            this.Splitter.ResumeLayout(false);
            this.TreeViewMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.GroupBox FilterGroupBox;
        private System.Windows.Forms.Label DurationLabel;
        private System.Windows.Forms.ComboBox DurationOperator;
        private System.Windows.Forms.NumericUpDown DurationAmount;
        private System.Windows.Forms.ComboBox DurationUnit;
        private System.Windows.Forms.CheckedListBox LocationFilter;
        private System.Windows.Forms.CheckedListBox CategoryFilter;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.Label CategoryLabel;
        private System.Windows.Forms.TextBox MemoFilter;
        private System.Windows.Forms.Label MemoLabel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.SplitContainer Splitter;
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
        private System.Windows.Forms.GroupBox DateGroupBox;
        private System.Windows.Forms.GroupBox SortGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox SortBy3;
        private System.Windows.Forms.ComboBox SortBy2;
        private System.Windows.Forms.ComboBox SortBy1;
    }
}