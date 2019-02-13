namespace Timekeeper.Forms.Shared
{
    partial class BaseView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseView));
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.FilterButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadViewMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.ActionMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SaveViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveViewAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearViewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ManageViewsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveViewButton = new System.Windows.Forms.ToolStripButton();
            this.SaveViewAsButton = new System.Windows.Forms.ToolStripButton();
            this.ClearViewButton = new System.Windows.Forms.ToolStripButton();
            this.ManageViewsButton = new System.Windows.Forms.ToolStripButton();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ResultCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolStrip.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterButton,
            this.RefreshButton,
            this.ToolStripSeparator1,
            this.LoadViewMenuButton,
            this.ActionMenuButton,
            this.ToolStripSeparator2,
            this.SaveViewButton,
            this.SaveViewAsButton,
            this.ClearViewButton,
            this.ManageViewsButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(740, 25);
            this.ToolStrip.TabIndex = 2;
            this.ToolStrip.Text = "ToolStrip";
            // 
            // FilterButton
            // 
            this.FilterButton.Image = global::Timekeeper.Properties.Resources.ImageButtonFilter;
            this.FilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FilterButton.Name = "FilterButton";
            this.FilterButton.Size = new System.Drawing.Size(77, 22);
            this.FilterButton.Text = "Filtering...";
            this.FilterButton.Click += new System.EventHandler(this.FilterButton_Click);
            // 
            // RefreshButton
            // 
            this.RefreshButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RefreshButton.Image = global::Timekeeper.Properties.Resources.ImageButtonRefresh;
            this.RefreshButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(23, 22);
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.ToolTipText = "Refresh";
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // LoadViewMenuButton
            // 
            this.LoadViewMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadViewMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadViewMenuButton.Image")));
            this.LoadViewMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadViewMenuButton.Name = "LoadViewMenuButton";
            this.LoadViewMenuButton.Size = new System.Drawing.Size(43, 22);
            this.LoadViewMenuButton.Text = "Load";
            // 
            // ActionMenuButton
            // 
            this.ActionMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ActionMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveViewMenuItem,
            this.SaveViewAsMenuItem,
            this.toolStripMenuItem1,
            this.ClearViewMenuItem,
            this.toolStripMenuItem2,
            this.ManageViewsMenuItem});
            this.ActionMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("ActionMenuButton.Image")));
            this.ActionMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActionMenuButton.Name = "ActionMenuButton";
            this.ActionMenuButton.Size = new System.Drawing.Size(42, 22);
            this.ActionMenuButton.Text = "View";
            // 
            // SaveViewMenuItem
            // 
            this.SaveViewMenuItem.Name = "SaveViewMenuItem";
            this.SaveViewMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.SaveViewMenuItem.Size = new System.Drawing.Size(154, 22);
            this.SaveViewMenuItem.Text = "Save";
            this.SaveViewMenuItem.Click += new System.EventHandler(this.SaveViewButton_Click);
            // 
            // SaveViewAsMenuItem
            // 
            this.SaveViewAsMenuItem.Name = "SaveViewAsMenuItem";
            this.SaveViewAsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.SaveViewAsMenuItem.Text = "Save As...";
            this.SaveViewAsMenuItem.Click += new System.EventHandler(this.SaveViewAsButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // ClearViewMenuItem
            // 
            this.ClearViewMenuItem.Name = "ClearViewMenuItem";
            this.ClearViewMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ClearViewMenuItem.Text = "Clear";
            this.ClearViewMenuItem.Click += new System.EventHandler(this.ClearViewButton_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(151, 6);
            // 
            // ManageViewsMenuItem
            // 
            this.ManageViewsMenuItem.Name = "ManageViewsMenuItem";
            this.ManageViewsMenuItem.Size = new System.Drawing.Size(154, 22);
            this.ManageViewsMenuItem.Text = "Manage Views...";
            this.ManageViewsMenuItem.Click += new System.EventHandler(this.ManageViewsButton_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            this.ToolStripSeparator2.Visible = false;
            // 
            // SaveViewButton
            // 
            this.SaveViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewButton.Image")));
            this.SaveViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewButton.Name = "SaveViewButton";
            this.SaveViewButton.Size = new System.Drawing.Size(89, 22);
            this.SaveViewButton.Text = "SaveViewButton";
            this.SaveViewButton.Visible = false;
            this.SaveViewButton.Click += new System.EventHandler(this.SaveViewButton_Click);
            // 
            // SaveViewAsButton
            // 
            this.SaveViewAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewAsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewAsButton.Image")));
            this.SaveViewAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewAsButton.Name = "SaveViewAsButton";
            this.SaveViewAsButton.Size = new System.Drawing.Size(101, 22);
            this.SaveViewAsButton.Text = "SaveViewAsButton";
            this.SaveViewAsButton.ToolTipText = "SaveViewAsButton";
            this.SaveViewAsButton.Visible = false;
            this.SaveViewAsButton.Click += new System.EventHandler(this.SaveViewAsButton_Click);
            // 
            // ClearViewButton
            // 
            this.ClearViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClearViewButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearViewButton.Image")));
            this.ClearViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearViewButton.Name = "ClearViewButton";
            this.ClearViewButton.Size = new System.Drawing.Size(90, 22);
            this.ClearViewButton.Text = "ClearViewButton";
            this.ClearViewButton.ToolTipText = "ClearViewButton";
            this.ClearViewButton.Visible = false;
            this.ClearViewButton.Click += new System.EventHandler(this.ClearViewButton_Click);
            // 
            // ManageViewsButton
            // 
            this.ManageViewsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageViewsButton.Image = ((System.Drawing.Image)(resources.GetObject("ManageViewsButton.Image")));
            this.ManageViewsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageViewsButton.Name = "ManageViewsButton";
            this.ManageViewsButton.Size = new System.Drawing.Size(108, 22);
            this.ManageViewsButton.Text = "ManageViewsButton";
            this.ManageViewsButton.ToolTipText = "ManageViewsButton";
            this.ManageViewsButton.Visible = false;
            this.ManageViewsButton.Click += new System.EventHandler(this.ManageViewsButton_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResultCount});
            this.StatusBar.Location = new System.Drawing.Point(0, 249);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(740, 22);
            this.StatusBar.TabIndex = 4;
            this.StatusBar.Text = "statusStrip1";
            // 
            // ResultCount
            // 
            this.ResultCount.Name = "ResultCount";
            this.ResultCount.Size = new System.Drawing.Size(0, 17);
            // 
            // BaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 271);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BaseView";
            this.Text = "BaseView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaseView_FormClosing);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripButton FilterButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton LoadViewMenuButton;
        private System.Windows.Forms.ToolStripDropDownButton ActionMenuButton;
        private System.Windows.Forms.ToolStripMenuItem SaveViewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveViewAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ClearViewMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ManageViewsMenuItem;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripButton SaveViewButton;
        private System.Windows.Forms.ToolStripButton SaveViewAsButton;
        private System.Windows.Forms.ToolStripButton ClearViewButton;
        private System.Windows.Forms.ToolStripButton ManageViewsButton;
        internal System.Windows.Forms.StatusStrip StatusBar;
        internal System.Windows.Forms.ToolStripStatusLabel ResultCount;
        internal System.Windows.Forms.ToolStrip ToolStrip;
    }
}