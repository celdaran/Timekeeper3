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
            this.LoadEventMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.EventsButton = new System.Windows.Forms.ToolStripButton();
            this.SecondTimer = new System.Windows.Forms.Timer(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.TodoButton = new System.Windows.Forms.ToolStripButton();
            this.ToolStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Display
            // 
            this.Display.BackColor = System.Drawing.SystemColors.Control;
            this.Display.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Display.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Display.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Display.Location = new System.Drawing.Point(0, 0);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(288, 31);
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
            this.LoadEventMenu,
            this.EventsButton,
            this.TodoButton});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(292, 25);
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
            this.SmallSizeButton.Size = new System.Drawing.Size(144, 22);
            this.SmallSizeButton.Text = "Small";
            this.SmallSizeButton.Click += new System.EventHandler(this.SmallSizeButton_Click);
            // 
            // MediumSizeButton
            // 
            this.MediumSizeButton.Name = "MediumSizeButton";
            this.MediumSizeButton.Size = new System.Drawing.Size(144, 22);
            this.MediumSizeButton.Text = "Medium";
            this.MediumSizeButton.Click += new System.EventHandler(this.MediumSizeButton_Click);
            // 
            // LargeSizeButton
            // 
            this.LargeSizeButton.Name = "LargeSizeButton";
            this.LargeSizeButton.Size = new System.Drawing.Size(144, 22);
            this.LargeSizeButton.Text = "Large";
            this.LargeSizeButton.Click += new System.EventHandler(this.LargeSizeButton_Click);
            // 
            // DynamicSizeButton
            // 
            this.DynamicSizeButton.Name = "DynamicSizeButton";
            this.DynamicSizeButton.Size = new System.Drawing.Size(144, 22);
            this.DynamicSizeButton.Text = "Dynamic";
            this.DynamicSizeButton.Click += new System.EventHandler(this.DynamicSizeButton_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(141, 6);
            // 
            // AlwaysOnTopButton
            // 
            this.AlwaysOnTopButton.Name = "AlwaysOnTopButton";
            this.AlwaysOnTopButton.Size = new System.Drawing.Size(144, 22);
            this.AlwaysOnTopButton.Text = "Always on Top";
            this.AlwaysOnTopButton.Click += new System.EventHandler(this.AlwaysOnTopButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // EventsButton
            // 
            this.EventsButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EventsButton.Image = ((System.Drawing.Image)(resources.GetObject("EventsButton.Image")));
            this.EventsButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EventsButton.Name = "EventsButton";
            this.EventsButton.Size = new System.Drawing.Size(56, 22);
            this.EventsButton.Text = "Events...";
            this.EventsButton.Click += new System.EventHandler(this.EventsButton_Click);
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
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.Display);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(292, 33);
            this.panel1.TabIndex = 8;
            // 
            // TodoButton
            // 
            this.TodoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.TodoButton.Image = ((System.Drawing.Image)(resources.GetObject("TodoButton.Image")));
            this.TodoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TodoButton.Name = "TodoButton";
            this.TodoButton.Size = new System.Drawing.Size(47, 22);
            this.TodoButton.Text = "Todo...";
            this.TodoButton.Click += new System.EventHandler(this.TodoButton_Click);
            // 
            // Countdown
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 58);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ToolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Countdown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Countdown";
            this.Activated += new System.EventHandler(this.Countdown_Activated);
            this.Load += new System.EventHandler(this.Countdown_Load);
            this.ResizeEnd += new System.EventHandler(this.Countdown_ResizeEnd);
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Display;
        private System.Windows.Forms.ToolStrip ToolStrip;
        private System.Windows.Forms.ToolStripButton EventsButton;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton TodoButton;
    }
}