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
            this.RefreshButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadOptionsButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.lastRunReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveOptionsButton = new System.Windows.Forms.ToolStripButton();
            this.ManageOptionsButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.PrintMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.PrintReportButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintSetupButton = new System.Windows.Forms.ToolStripMenuItem();
            this.PrintPreviewButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CloseButton = new System.Windows.Forms.ToolStripButton();
            this.SortButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ReportWindow
            // 
            this.ReportWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportWindow.Location = new System.Drawing.Point(0, 25);
            this.ReportWindow.MinimumSize = new System.Drawing.Size(20, 20);
            this.ReportWindow.Name = "ReportWindow";
            this.ReportWindow.Size = new System.Drawing.Size(517, 362);
            this.ReportWindow.TabIndex = 3;
            // 
            // TimerHack
            // 
            this.TimerHack.Interval = 500;
            this.TimerHack.Tick += new System.EventHandler(this.TimerHack_Tick);
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilterButton,
            this.SortButton,
            this.RefreshButton,
            this.ToolStripSeparator1,
            this.LoadOptionsButton,
            this.SaveOptionsButton,
            this.ManageOptionsButton,
            this.ToolStripSeparator2,
            this.PrintMenuButton,
            this.ToolStripSeparator3,
            this.CloseButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(517, 25);
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
            // LoadOptionsButton
            // 
            this.LoadOptionsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadOptionsButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastRunReportToolStripMenuItem});
            this.LoadOptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("LoadOptionsButton.Image")));
            this.LoadOptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadOptionsButton.Name = "LoadOptionsButton";
            this.LoadOptionsButton.Size = new System.Drawing.Size(43, 22);
            this.LoadOptionsButton.Text = "Load";
            // 
            // lastRunReportToolStripMenuItem
            // 
            this.lastRunReportToolStripMenuItem.Name = "lastRunReportToolStripMenuItem";
            this.lastRunReportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lastRunReportToolStripMenuItem.Text = "Last Run Report";
            // 
            // SaveOptionsButton
            // 
            this.SaveOptionsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SaveOptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveOptionsButton.Image")));
            this.SaveOptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveOptionsButton.Name = "SaveOptionsButton";
            this.SaveOptionsButton.Size = new System.Drawing.Size(47, 22);
            this.SaveOptionsButton.Text = "Save...";
            // 
            // ManageOptionsButton
            // 
            this.ManageOptionsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageOptionsButton.Image = ((System.Drawing.Image)(resources.GetObject("ManageOptionsButton.Image")));
            this.ManageOptionsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageOptionsButton.Name = "ManageOptionsButton";
            this.ManageOptionsButton.Size = new System.Drawing.Size(61, 22);
            this.ManageOptionsButton.Text = "Manage...";
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
            // CloseButton
            // 
            this.CloseButton.Image = ((System.Drawing.Image)(resources.GetObject("CloseButton.Image")));
            this.CloseButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(53, 22);
            this.CloseButton.Text = "Close";
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
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
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 387);
            this.Controls.Add(this.ReportWindow);
            this.Controls.Add(this.ToolStrip);
            this.HelpButton = true;
            this.Name = "Report";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Report";
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
        private System.Windows.Forms.ToolStripDropDownButton LoadOptionsButton;
        private System.Windows.Forms.ToolStripMenuItem lastRunReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton SaveOptionsButton;
        private System.Windows.Forms.ToolStripButton ManageOptionsButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton PrintMenuButton;
        private System.Windows.Forms.ToolStripMenuItem PrintReportButton;
        private System.Windows.Forms.ToolStripMenuItem PrintSetupButton;
        private System.Windows.Forms.ToolStripMenuItem PrintPreviewButton;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator3;
        private System.Windows.Forms.ToolStripButton CloseButton;
        private System.Windows.Forms.ToolStripButton RefreshButton;
        private System.Windows.Forms.ToolStripButton SortButton;
    }
}