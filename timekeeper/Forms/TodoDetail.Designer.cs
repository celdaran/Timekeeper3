namespace Timekeeper.Forms
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
            this.ProjectTree = new System.Windows.Forms.TreeView();
            this.TreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.DueDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.RefTodoStatus = new System.Windows.Forms.ComboBox();
            this.Memo = new System.Windows.Forms.RichTextBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.RightButtonPanel = new System.Windows.Forms.Panel();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.DetailPanel = new System.Windows.Forms.Panel();
            this.FixedDetailPanel = new System.Windows.Forms.Panel();
            this.UseStartDate = new System.Windows.Forms.CheckBox();
            this.UseDueDate = new System.Windows.Forms.CheckBox();
            this.ButtonPanel.SuspendLayout();
            this.RightButtonPanel.SuspendLayout();
            this.DetailPanel.SuspendLayout();
            this.FixedDetailPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProjectTree
            // 
            this.ProjectTree.AllowDrop = true;
            resources.ApplyResources(this.ProjectTree, "ProjectTree");
            this.ProjectTree.HideSelection = false;
            this.ProjectTree.ImageList = this.TreeImageList;
            this.ProjectTree.Name = "ProjectTree";
            this.ProjectTree.DragDrop += new System.Windows.Forms.DragEventHandler(this.ProjectTree_DragDrop);
            // 
            // TreeImageList
            // 
            this.TreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImageList.ImageStream")));
            this.TreeImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeImageList.Images.SetKeyName(0, "SmallFolder.png");
            this.TreeImageList.Images.SetKeyName(1, "SmallFolder.png");
            this.TreeImageList.Images.SetKeyName(2, "SmallProject.png");
            this.TreeImageList.Images.SetKeyName(3, "SmallActivity.png");
            this.TreeImageList.Images.SetKeyName(4, "task-clock1.bmp");
            this.TreeImageList.Images.SetKeyName(5, "task-clock2.bmp");
            this.TreeImageList.Images.SetKeyName(6, "task-clock3.bmp");
            this.TreeImageList.Images.SetKeyName(7, "task-clock4.bmp");
            this.TreeImageList.Images.SetKeyName(8, "menu-item-hidden.bmp");
            // 
            // StartDate
            // 
            this.StartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.StartDate, "StartDate");
            this.StartDate.Name = "StartDate";
            // 
            // DueDate
            // 
            this.DueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            resources.ApplyResources(this.DueDate, "DueDate");
            this.DueDate.Name = "DueDate";
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
            // Memo
            // 
            resources.ApplyResources(this.Memo, "Memo");
            this.Memo.HideSelection = false;
            this.Memo.Name = "Memo";
            this.Memo.ShowSelectionMargin = true;
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
            // DetailPanel
            // 
            this.DetailPanel.Controls.Add(this.Memo);
            this.DetailPanel.Controls.Add(this.FixedDetailPanel);
            resources.ApplyResources(this.DetailPanel, "DetailPanel");
            this.DetailPanel.Name = "DetailPanel";
            // 
            // FixedDetailPanel
            // 
            this.FixedDetailPanel.Controls.Add(this.UseDueDate);
            this.FixedDetailPanel.Controls.Add(this.UseStartDate);
            this.FixedDetailPanel.Controls.Add(this.label3);
            this.FixedDetailPanel.Controls.Add(this.StartDate);
            this.FixedDetailPanel.Controls.Add(this.RefTodoStatus);
            this.FixedDetailPanel.Controls.Add(this.DueDate);
            resources.ApplyResources(this.FixedDetailPanel, "FixedDetailPanel");
            this.FixedDetailPanel.Name = "FixedDetailPanel";
            // 
            // UseStartDate
            // 
            resources.ApplyResources(this.UseStartDate, "UseStartDate");
            this.UseStartDate.Name = "UseStartDate";
            this.UseStartDate.UseVisualStyleBackColor = true;
            // 
            // UseDueDate
            // 
            resources.ApplyResources(this.UseDueDate, "UseDueDate");
            this.UseDueDate.Name = "UseDueDate";
            this.UseDueDate.UseVisualStyleBackColor = true;
            // 
            // TodoDetail
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.Controls.Add(this.ProjectTree);
            this.Controls.Add(this.DetailPanel);
            this.Controls.Add(this.ButtonPanel);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TodoDetail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TodoItem_FormClosing);
            this.Load += new System.EventHandler(this.TodoItem_Load);
            this.ButtonPanel.ResumeLayout(false);
            this.RightButtonPanel.ResumeLayout(false);
            this.DetailPanel.ResumeLayout(false);
            this.FixedDetailPanel.ResumeLayout(false);
            this.FixedDetailPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.DateTimePicker DueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RefTodoStatus;
        private System.Windows.Forms.RichTextBox Memo;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.Panel DetailPanel;
        private System.Windows.Forms.ImageList TreeImageList;
        private System.Windows.Forms.Panel RightButtonPanel;
        private System.Windows.Forms.Button CancelDialogButton;
        internal System.Windows.Forms.TreeView ProjectTree;
        private System.Windows.Forms.Panel FixedDetailPanel;
        private System.Windows.Forms.CheckBox UseDueDate;
        private System.Windows.Forms.CheckBox UseStartDate;
    }
}