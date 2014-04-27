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
            this.CloseButton = new System.Windows.Forms.Button();
            this.TreeImageList = new System.Windows.Forms.ImageList(this.components);
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.OkayButton = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.FilterButton = new System.Windows.Forms.ToolStripButton();
            this.BottomPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemTree
            // 
            this.ItemTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ItemTree.ImageIndex = 0;
            this.ItemTree.ImageList = this.TreeImageList;
            this.ItemTree.Location = new System.Drawing.Point(0, 25);
            this.ItemTree.Name = "ItemTree";
            this.ItemTree.SelectedImageIndex = 0;
            this.ItemTree.Size = new System.Drawing.Size(510, 200);
            this.ItemTree.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(87, 6);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TreeImageList
            // 
            this.TreeImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeImageList.ImageStream")));
            this.TreeImageList.TransparentColor = System.Drawing.Color.Magenta;
            this.TreeImageList.Images.SetKeyName(0, "OpenFolder");
            this.TreeImageList.Images.SetKeyName(1, "ClosedFolder");
            this.TreeImageList.Images.SetKeyName(2, "Project");
            this.TreeImageList.Images.SetKeyName(3, "Activity");
            this.TreeImageList.Images.SetKeyName(4, "task-clock1.bmp");
            this.TreeImageList.Images.SetKeyName(5, "task-clock2.bmp");
            this.TreeImageList.Images.SetKeyName(6, "task-clock3.bmp");
            this.TreeImageList.Images.SetKeyName(7, "task-clock4.bmp");
            this.TreeImageList.Images.SetKeyName(8, "HiddenItem");
            this.TreeImageList.Images.SetKeyName(9, "HiddenFolder");
            // 
            // BottomPanel
            // 
            this.BottomPanel.Controls.Add(this.OkayButton);
            this.BottomPanel.Controls.Add(this.CloseButton);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 225);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(510, 36);
            this.BottomPanel.TabIndex = 4;
            // 
            // OkayButton
            // 
            this.OkayButton.Location = new System.Drawing.Point(6, 6);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(75, 23);
            this.OkayButton.TabIndex = 3;
            this.OkayButton.Text = "OK";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
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
            this.Text = "Merge";
            this.Load += new System.EventHandler(this.Merge_Load);
            this.BottomPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView ItemTree;
        private System.Windows.Forms.Button CloseButton;
        public System.Windows.Forms.ImageList TreeImageList;
        private System.Windows.Forms.Panel BottomPanel;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton FilterButton;
    }
}