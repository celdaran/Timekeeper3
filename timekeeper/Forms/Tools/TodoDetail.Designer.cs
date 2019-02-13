namespace Timekeeper.Forms.Tools
{
    partial class TodoDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TodoDetail));
            this.StartTime = new System.Windows.Forms.DateTimePicker();
            this.DueTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.RefTodoStatus = new System.Windows.Forms.ComboBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.RightButtonPanel = new System.Windows.Forms.Panel();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.FixedDetailPanel = new System.Windows.Forms.Panel();
            this.EstimateBox = new System.Windows.Forms.TextBox();
            this.EstimateLabel = new System.Windows.Forms.Label();
            this.UseDueDate = new System.Windows.Forms.CheckBox();
            this.UseStartDate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProjectTreeDropdown = new ComboTreeBox();
            this.PopupMenuDimension = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupMenuDimensionNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuDimensionManageItems = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuDimensionSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuDimensionProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.MemoPanel = new System.Windows.Forms.Panel();
            this.ButtonPanel.SuspendLayout();
            this.RightButtonPanel.SuspendLayout();
            this.FixedDetailPanel.SuspendLayout();
            this.PopupMenuDimension.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartTime
            // 
            resources.ApplyResources(this.StartTime, "StartTime");
            this.StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartTime.Name = "StartTime";
            // 
            // DueTime
            // 
            resources.ApplyResources(this.DueTime, "DueTime");
            this.DueTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DueTime.Name = "DueTime";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // RefTodoStatus
            // 
            this.RefTodoStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RefTodoStatus.FormattingEnabled = true;
            this.RefTodoStatus.Items.AddRange(new object[] {
            resources.GetString("RefTodoStatus.Items"),
            resources.GetString("RefTodoStatus.Items1"),
            resources.GetString("RefTodoStatus.Items2"),
            resources.GetString("RefTodoStatus.Items3"),
            resources.GetString("RefTodoStatus.Items4")});
            resources.ApplyResources(this.RefTodoStatus, "RefTodoStatus");
            this.RefTodoStatus.Name = "RefTodoStatus";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.RightButtonPanel);
            resources.ApplyResources(this.ButtonPanel, "ButtonPanel");
            this.ButtonPanel.Name = "ButtonPanel";
            // 
            // RightButtonPanel
            // 
            this.RightButtonPanel.Controls.Add(this.CancelDialogButton);
            this.RightButtonPanel.Controls.Add(this.AcceptDialogButton);
            resources.ApplyResources(this.RightButtonPanel, "RightButtonPanel");
            this.RightButtonPanel.Name = "RightButtonPanel";
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.CancelDialogButton, "CancelDialogButton");
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // AcceptDialogButton
            // 
            resources.ApplyResources(this.AcceptDialogButton, "AcceptDialogButton");
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // FixedDetailPanel
            // 
            this.FixedDetailPanel.Controls.Add(this.EstimateBox);
            this.FixedDetailPanel.Controls.Add(this.EstimateLabel);
            this.FixedDetailPanel.Controls.Add(this.UseDueDate);
            this.FixedDetailPanel.Controls.Add(this.DueTime);
            this.FixedDetailPanel.Controls.Add(this.UseStartDate);
            this.FixedDetailPanel.Controls.Add(this.label1);
            this.FixedDetailPanel.Controls.Add(this.StartTime);
            this.FixedDetailPanel.Controls.Add(this.ProjectTreeDropdown);
            this.FixedDetailPanel.Controls.Add(this.label3);
            this.FixedDetailPanel.Controls.Add(this.RefTodoStatus);
            resources.ApplyResources(this.FixedDetailPanel, "FixedDetailPanel");
            this.FixedDetailPanel.Name = "FixedDetailPanel";
            // 
            // EstimateBox
            // 
            resources.ApplyResources(this.EstimateBox, "EstimateBox");
            this.EstimateBox.Name = "EstimateBox";
            this.EstimateBox.Leave += new System.EventHandler(this.EstimateBox_Leave);
            // 
            // EstimateLabel
            // 
            resources.ApplyResources(this.EstimateLabel, "EstimateLabel");
            this.EstimateLabel.Name = "EstimateLabel";
            // 
            // UseDueDate
            // 
            resources.ApplyResources(this.UseDueDate, "UseDueDate");
            this.UseDueDate.Name = "UseDueDate";
            this.UseDueDate.UseVisualStyleBackColor = true;
            this.UseDueDate.CheckedChanged += new System.EventHandler(this.UseDueDate_CheckedChanged);
            // 
            // UseStartDate
            // 
            resources.ApplyResources(this.UseStartDate, "UseStartDate");
            this.UseStartDate.Name = "UseStartDate";
            this.UseStartDate.UseVisualStyleBackColor = true;
            this.UseStartDate.CheckedChanged += new System.EventHandler(this.UseStartDate_CheckedChanged);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // ProjectTreeDropdown
            // 
            this.ProjectTreeDropdown.ContextMenuStrip = this.PopupMenuDimension;
            this.ProjectTreeDropdown.DrawWithVisualStyles = false;
            this.ProjectTreeDropdown.DroppedDown = false;
            this.ProjectTreeDropdown.Images = this.TreeImageList;
            resources.ApplyResources(this.ProjectTreeDropdown, "ProjectTreeDropdown");
            this.ProjectTreeDropdown.Name = "ProjectTreeDropdown";
            this.ProjectTreeDropdown.SelectedNode = null;
            this.ProjectTreeDropdown.Tag = "0";
            this.ProjectTreeDropdown.SelectedNodeChanged += new System.EventHandler(this.ProjectTreeDropdown_SelectedNodeChanged);
            this.ProjectTreeDropdown.DropDownClosed += new System.EventHandler(this.ProjectTreeDropdown_DropDownClosed);
            this.ProjectTreeDropdown.Enter += new System.EventHandler(this.ProjectTreeDropdown_Enter);
            this.ProjectTreeDropdown.Leave += new System.EventHandler(this.ProjectTreeDropdown_Leave);
            // 
            // PopupMenuDimension
            // 
            this.PopupMenuDimension.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuDimensionNewItem,
            this.PopupMenuDimensionManageItems,
            this.PopupMenuDimensionSep1,
            this.PopupMenuDimensionProperties});
            this.PopupMenuDimension.Name = "menuTask";
            resources.ApplyResources(this.PopupMenuDimension, "PopupMenuDimension");
            // 
            // PopupMenuDimensionNewItem
            // 
            resources.ApplyResources(this.PopupMenuDimensionNewItem, "PopupMenuDimensionNewItem");
            this.PopupMenuDimensionNewItem.Name = "PopupMenuDimensionNewItem";
            this.PopupMenuDimensionNewItem.Click += new System.EventHandler(this.PopupMenuDimensionNewItem_Click);
            // 
            // PopupMenuDimensionManageItems
            // 
            this.PopupMenuDimensionManageItems.Name = "PopupMenuDimensionManageItems";
            resources.ApplyResources(this.PopupMenuDimensionManageItems, "PopupMenuDimensionManageItems");
            this.PopupMenuDimensionManageItems.Click += new System.EventHandler(this.PopupMenuDimensionManageItems_Click);
            // 
            // PopupMenuDimensionSep1
            // 
            this.PopupMenuDimensionSep1.Name = "PopupMenuDimensionSep1";
            resources.ApplyResources(this.PopupMenuDimensionSep1, "PopupMenuDimensionSep1");
            // 
            // PopupMenuDimensionProperties
            // 
            this.PopupMenuDimensionProperties.Name = "PopupMenuDimensionProperties";
            resources.ApplyResources(this.PopupMenuDimensionProperties, "PopupMenuDimensionProperties");
            // 
            // TreeImageList
            // 
            this.TreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImageList.ImageStream")));
            this.TreeImageList.TransparentColor = System.Drawing.Color.White;
            this.TreeImageList.Images.SetKeyName(0, "Folder");
            this.TreeImageList.Images.SetKeyName(1, "Project");
            this.TreeImageList.Images.SetKeyName(2, "Activity");
            this.TreeImageList.Images.SetKeyName(3, "Location");
            this.TreeImageList.Images.SetKeyName(4, "Category");
            this.TreeImageList.Images.SetKeyName(5, "HiddenItem");
            this.TreeImageList.Images.SetKeyName(6, "HiddenFolder");
            // 
            // MemoPanel
            // 
            resources.ApplyResources(this.MemoPanel, "MemoPanel");
            this.MemoPanel.Name = "MemoPanel";
            // 
            // TodoDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.Controls.Add(this.MemoPanel);
            this.Controls.Add(this.FixedDetailPanel);
            this.Controls.Add(this.ButtonPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TodoDetail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TodoItem_FormClosing);
            this.Load += new System.EventHandler(this.TodoItem_Load);
            this.ButtonPanel.ResumeLayout(false);
            this.RightButtonPanel.ResumeLayout(false);
            this.FixedDetailPanel.ResumeLayout(false);
            this.FixedDetailPanel.PerformLayout();
            this.PopupMenuDimension.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartTime;
        private System.Windows.Forms.DateTimePicker DueTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RefTodoStatus;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.Panel RightButtonPanel;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Panel FixedDetailPanel;
        private System.Windows.Forms.CheckBox UseDueDate;
        private System.Windows.Forms.CheckBox UseStartDate;
        private ComboTreeBox ProjectTreeDropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MemoPanel;
        public System.Windows.Forms.ImageList TreeImageList;
        private System.Windows.Forms.ContextMenuStrip PopupMenuDimension;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuDimensionNewItem;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuDimensionManageItems;
        private System.Windows.Forms.ToolStripSeparator PopupMenuDimensionSep1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuDimensionProperties;
        private System.Windows.Forms.TextBox EstimateBox;
        private System.Windows.Forms.Label EstimateLabel;
    }
}