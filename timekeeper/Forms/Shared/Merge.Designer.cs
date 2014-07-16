namespace Timekeeper.Forms.Shared
{
    partial class Merge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Merge));
            this.ItemTree = new System.Windows.Forms.TreeView();
            this.TreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.CloseButton = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MergeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FilterButton = new System.Windows.Forms.ToolStripButton();
            this.BottomPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemTree
            // 
            this.ItemTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemTree.HideSelection = false;
            this.ItemTree.ImageIndex = 0;
            this.ItemTree.ImageList = this.TreeImageList;
            this.ItemTree.Location = new System.Drawing.Point(0, 25);
            this.ItemTree.Name = "ItemTree";
            this.ItemTree.SelectedImageIndex = 0;
            this.ItemTree.Size = new System.Drawing.Size(510, 200);
            this.ItemTree.TabIndex = 1;
            this.ItemTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.ItemTree_BeforeSelect);
            this.ItemTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.ItemTree_AfterSelect);
            this.ItemTree.DoubleClick += new System.EventHandler(this.ItemTree_DoubleClick);
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
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(84, 6);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.panel1);
            this.BottomPanel.Controls.Add(this.label1);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 225);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(510, 36);
            this.BottomPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.MergeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(345, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 36);
            this.panel1.TabIndex = 4;
            // 
            // MergeButton
            // 
            this.MergeButton.Location = new System.Drawing.Point(3, 6);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(75, 23);
            this.MergeButton.TabIndex = 3;
            this.MergeButton.Text = "Merge...";
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select an item as the merge target.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(510, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // FilterButton
            // 
            this.FilterButton.Image = global::Timekeeper.Properties.Resources.ImageButtonFilter;
            this.FilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(51, 22);
            this.FilterButton.Text = "Filter";
            this.FilterButton.ToolTipText = "Use a filter to limit the number of Journal Entries merged.";
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // Merge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(510, 261);
            this.Controls.Add(this.ItemTree);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.BottomPanel);
            this.Name = "Merge";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Merge";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Merge_FormClosing);
            this.Load += new System.EventHandler(this.Merge_Load);
            this.BottomPanel.ResumeLayout(false);
            this.BottomPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ItemTree;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton FilterButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ImageList TreeImageList;
    }
}