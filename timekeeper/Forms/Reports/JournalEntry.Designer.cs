namespace Timekeeper.Forms.Reports
{
    partial class JournalEntry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JournalEntry));
            this.ReportWindow = new System.Windows.Forms.WebBrowser();
            this.TimerHack = new System.Windows.Forms.Timer(this.components);
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.FilterButton = new System.Windows.Forms.ToolStripButton();
            this.SortButton = new System.Windows.Forms.ToolStripButton();
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ClearViewButton = new System.Windows.Forms.ToolStripButton();
            this.SaveViewButton = new System.Windows.Forms.ToolStripButton();
            this.LoadViewMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SaveViewAsButton = new System.Windows.Forms.ToolStripButton();
            this.ManageViewsButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.PrintReportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintSetupButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreviewButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportWindow
            // 
            this.ReportWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportWindow.Location = new System.Drawing.Point(0, 25);
            this.ReportWindow.MinimumSize = new System.Drawing.Size(20, 20);
            this.ReportWindow.Name = "ReportWindow";
            this.ReportWindow.Size = new System.Drawing.Size(705, 362);
            this.ReportWindow.TabIndex = 3;
            // 
            // TimerHack
            // 
            this.TimerHack.Interval = 500;
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterButton,
            this.SortButton,
            this.RefreshButton,
            this.ToolStripSeparator1,
            this.ClearViewButton,
            this.SaveViewButton,
            this.LoadViewMenuButton,
            this.SaveViewAsButton,
            this.ManageViewsButton,
            this.ToolStripSeparator2,
            this.PrintMenuButton,
            this.ToolStripSeparator3});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(705, 25);
            this.ToolStrip.TabIndex = 0;
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
            // SortButton
            // 
            this.SortButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SortButton.Image = ((System.Drawing.Image)(resources.GetObject("SortButton.Image")));
            this.SortButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SortButton.Name = "SortButton";
            this.SortButton.Size = new System.Drawing.Size(57, 22);
            this.SortButton.Text = "Sorting...";
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
            // ClearViewButton
            // 
            this.ClearViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ClearViewButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearViewButton.Image")));
            this.ClearViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ClearViewButton.Name = "ClearViewButton";
            this.ClearViewButton.Size = new System.Drawing.Size(36, 22);
            this.ClearViewButton.Text = "Clear";
            this.ClearViewButton.ToolTipText = "Clear the current view";
            this.ClearViewButton.Click += new System.EventHandler(this.ClearViewButton_Click);
            // 
            // SaveViewButton
            // 
            this.SaveViewButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewButton.Image")));
            this.SaveViewButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewButton.Name = "SaveViewButton";
            this.SaveViewButton.Size = new System.Drawing.Size(35, 22);
            this.SaveViewButton.Text = "Save";
            this.SaveViewButton.ToolTipText = "Save Current View";
            this.SaveViewButton.Click += new System.EventHandler(this.SaveViewButton_Click);
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
            // SaveViewAsButton
            // 
            this.SaveViewAsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveViewAsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveViewAsButton.Image")));
            this.SaveViewAsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveViewAsButton.Name = "SaveViewAsButton";
            this.SaveViewAsButton.Size = new System.Drawing.Size(62, 22);
            this.SaveViewAsButton.Text = "Save As...";
            this.SaveViewAsButton.Click += new System.EventHandler(this.SaveViewAsButton_Click);
            // 
            // ManageViewsButton
            // 
            this.ManageViewsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageViewsButton.Image = ((System.Drawing.Image)(resources.GetObject("ManageViewsButton.Image")));
            this.ManageViewsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageViewsButton.Name = "ManageViewsButton";
            this.ManageViewsButton.Size = new System.Drawing.Size(61, 22);
            this.ManageViewsButton.Text = "Manage...";
            this.ManageViewsButton.Click += new System.EventHandler(this.ManageViewsButton_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // PrintMenuButton
            // 
            this.PrintMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PrintReportButton,
            this.PrintSetupButton,
            this.PrintPreviewButton});
            this.PrintMenuButton.Image = global::Timekeeper.Properties.Resources.ImageButtonPrinter;
            this.PrintMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PrintMenuButton.Name = "PrintMenuButton";
            this.PrintMenuButton.Size = new System.Drawing.Size(58, 22);
            this.PrintMenuButton.Text = "Print";
            // 
            // PrintReportButton
            // 
            this.PrintReportButton.Name = "PrintReportButton";
            this.PrintReportButton.Size = new System.Drawing.Size(152, 22);
            this.PrintReportButton.Text = "Print this Report";
            this.PrintReportButton.Click += new System.EventHandler(this.PrintReportButton_Click);
            // 
            // PrintSetupButton
            // 
            this.PrintSetupButton.Name = "PrintSetupButton";
            this.PrintSetupButton.Size = new System.Drawing.Size(152, 22);
            this.PrintSetupButton.Text = "Print Setup...";
            this.PrintSetupButton.Click += new System.EventHandler(this.PrintSetupButton_Click);
            // 
            // PrintPreviewButton
            // 
            this.PrintPreviewButton.Name = "PrintPreviewButton";
            this.PrintPreviewButton.Size = new System.Drawing.Size(152, 22);
            this.PrintPreviewButton.Text = "Print Preview...";
            this.PrintPreviewButton.Click += new System.EventHandler(this.PrintPreviewButton_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // JournalEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 387);
            this.Controls.Add(this.ReportWindow);
            this.Controls.Add(this.ToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "JournalEntry";
            this.Text = "Timekeeper Report";
            this.Activated += new System.EventHandler(this.Report_Activated);
            this.Load += new System.EventHandler(this.Report_Load);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser ReportWindow;
        private System.Windows.Forms.Timer TimerHack;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton FilterButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton LoadViewMenuButton;
        private System.Windows.Forms.ToolStripButton SaveViewAsButton;
        private System.Windows.Forms.ToolStripButton ManageViewsButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton PrintMenuButton;
        private System.Windows.Forms.ToolStripMenuItem PrintReportButton;
        private System.Windows.Forms.ToolStripMenuItem PrintSetupButton;
        private System.Windows.Forms.ToolStripMenuItem PrintPreviewButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripButton SortButton;
        private System.Windows.Forms.ToolStripButton ClearViewButton;
        private System.Windows.Forms.ToolStripButton SaveViewButton;
    }
}