namespace Timekeeper.Forms.Tools
{
    partial class Countdown
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Countdown));
            this.Display = new System.Windows.Forms.TextBox();
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.DisplayMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.SmallSizeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumSizeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeSizeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.DynamicSizeButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.AlwaysOnTopButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.CreateEventButton = new System.Windows.Forms.ToolStripButton();
            this.LoadEventMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.ManageCountdowns = new System.Windows.Forms.ToolStripButton();
            this.SecondTimer = new System.Windows.Forms.Timer(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.BackColor = System.Drawing.SystemColors.Control;
            this.Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Display.Location = new System.Drawing.Point(0, 25);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(407, 31);
            this.Display.TabIndex = 0;
            this.Display.TabStop = false;
            this.Display.Text = "00:00:00";
            this.Display.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Display.Enter += new System.EventHandler(this.Display_Enter);
            this.Display.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Display_KeyDown);
            // 
            // ToolStrip
            // 
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DisplayMenuButton,
            this.toolStripSeparator2,
            this.CreateEventButton,
            this.LoadEventMenu,
            this.ManageCountdowns});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(407, 25);
            this.ToolStrip.TabIndex = 7;
            this.ToolStrip.Text = "toolStrip1";
            // 
            // DisplayMenuButton
            // 
            this.DisplayMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.DisplayMenuButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SmallSizeButton,
            this.MediumSizeButton,
            this.LargeSizeButton,
            this.DynamicSizeButton,
            this.toolStripMenuItem1,
            this.AlwaysOnTopButton});
            this.DisplayMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("DisplayMenuButton.Image")));
            this.DisplayMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DisplayMenuButton.Name = "DisplayMenuButton";
            this.DisplayMenuButton.Size = new System.Drawing.Size(54, 22);
            this.DisplayMenuButton.Text = "Display";
            this.DisplayMenuButton.ToolTipText = "Change various display settings";
            // 
            // SmallSizeButton
            // 
            this.SmallSizeButton.Checked = true;
            this.SmallSizeButton.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SmallSizeButton.Name = "SmallSizeButton";
            this.SmallSizeButton.Size = new System.Drawing.Size(152, 22);
            this.SmallSizeButton.Text = "Small";
            this.SmallSizeButton.Click += new System.EventHandler(this.SmallSizeButton_Click);
            // 
            // MediumSizeButton
            // 
            this.MediumSizeButton.Name = "MediumSizeButton";
            this.MediumSizeButton.Size = new System.Drawing.Size(152, 22);
            this.MediumSizeButton.Text = "Medium";
            this.MediumSizeButton.Click += new System.EventHandler(this.MediumSizeButton_Click);
            // 
            // LargeSizeButton
            // 
            this.LargeSizeButton.Name = "LargeSizeButton";
            this.LargeSizeButton.Size = new System.Drawing.Size(152, 22);
            this.LargeSizeButton.Text = "Large";
            this.LargeSizeButton.Click += new System.EventHandler(this.LargeSizeButton_Click);
            // 
            // DynamicSizeButton
            // 
            this.DynamicSizeButton.Name = "DynamicSizeButton";
            this.DynamicSizeButton.Size = new System.Drawing.Size(152, 22);
            this.DynamicSizeButton.Text = "Dynamic";
            this.DynamicSizeButton.Click += new System.EventHandler(this.DynamicSizeButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // AlwaysOnTopButton
            // 
            this.AlwaysOnTopButton.Name = "AlwaysOnTopButton";
            this.AlwaysOnTopButton.Size = new System.Drawing.Size(152, 22);
            this.AlwaysOnTopButton.Text = "Always on Top";
            this.AlwaysOnTopButton.Click += new System.EventHandler(this.AlwaysOnTopButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // CreateEventButton
            // 
            this.CreateEventButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.CreateEventButton.Image = ((System.Drawing.Image)(resources.GetObject("CreateEventButton.Image")));
            this.CreateEventButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.CreateEventButton.Name = "CreateEventButton";
            this.CreateEventButton.Size = new System.Drawing.Size(87, 22);
            this.CreateEventButton.Text = "Create Event...";
            this.CreateEventButton.Click += new System.EventHandler(this.CreateEventButton_Click);
            // 
            // LoadEventMenu
            // 
            this.LoadEventMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.LoadEventMenu.Image = ((System.Drawing.Image)(resources.GetObject("LoadEventMenu.Image")));
            this.LoadEventMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadEventMenu.Name = "LoadEventMenu";
            this.LoadEventMenu.Size = new System.Drawing.Size(43, 22);
            this.LoadEventMenu.Text = "Load";
            // 
            // ManageCountdowns
            // 
            this.ManageCountdowns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.ManageCountdowns.Image = ((System.Drawing.Image)(resources.GetObject("ManageCountdowns.Image")));
            this.ManageCountdowns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ManageCountdowns.Name = "ManageCountdowns";
            this.ManageCountdowns.Size = new System.Drawing.Size(61, 22);
            this.ManageCountdowns.Text = "Manage...";
            this.ManageCountdowns.Click += new System.EventHandler(this.ManageCountdowns_Click);
            // 
            // SecondTimer
            // 
            this.SecondTimer.Interval = 1000;
            this.SecondTimer.Tick += new System.EventHandler(this.SecondTimer_Tick);
            // 
            // TrayIcon
            // 
            this.TrayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.TrayIcon.BalloonTipTitle = "Timekeeper";
            this.TrayIcon.Text = "notifyIcon1";
            this.TrayIcon.Visible = true;
            // 
            // Countdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 64);
            this.Controls.Add(this.Display);
            this.Controls.Add(this.ToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Countdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Countdown";
            this.ResizeEnd += new System.EventHandler(this.Countdown_ResizeEnd);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Display;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton ManageCountdowns;
        private System.Windows.Forms.ToolStripButton CreateEventButton;
        private System.Windows.Forms.ToolStripDropDownButton LoadEventMenu;
        private System.Windows.Forms.Timer SecondTimer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton DisplayMenuButton;
        private System.Windows.Forms.ToolStripMenuItem SmallSizeButton;
        private System.Windows.Forms.ToolStripMenuItem MediumSizeButton;
        private System.Windows.Forms.ToolStripMenuItem LargeSizeButton;
        private System.Windows.Forms.ToolStripMenuItem DynamicSizeButton;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem AlwaysOnTopButton;
    }
}