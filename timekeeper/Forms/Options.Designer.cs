namespace Timekeeper.Forms
{
    partial class Options
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
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.AcceptDialogButton = new System.Windows.Forms.Button();
            this.PanelSelector = new System.Windows.Forms.ListBox();
            this.SelectorPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.OptionsPanelCollection = new System.Windows.Forms.TabControl();
            this.ViewOptionsPanel = new System.Windows.Forms.TabPage();
            this.View_StatusBar_ActivityName = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ProjectName = new System.Windows.Forms.CheckBox();
            this.View_StatusBar = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ButtonPanel.SuspendLayout();
            this.SelectorPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.OptionsPanelCollection.SuspendLayout();
            this.ViewOptionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.CancelDialogButton);
            this.ButtonPanel.Controls.Add(this.AcceptDialogButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 381);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(514, 39);
            this.ButtonPanel.TabIndex = 1;
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(425, 7);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 1;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // AcceptDialogButton
            // 
            this.AcceptDialogButton.Location = new System.Drawing.Point(344, 7);
            this.AcceptDialogButton.Name = "AcceptDialogButton";
            this.AcceptDialogButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptDialogButton.TabIndex = 0;
            this.AcceptDialogButton.Text = "Save";
            this.AcceptDialogButton.UseVisualStyleBackColor = true;
            this.AcceptDialogButton.Click += new System.EventHandler(this.AcceptDialogButton_Click);
            // 
            // PanelSelector
            // 
            this.PanelSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelSelector.FormattingEnabled = true;
            this.PanelSelector.Items.AddRange(new object[] {
            "View Options",
            "Layout Options",
            "Title Bar",
            "",
            "Window Control",
            "Annoyances",
            "Keyboard Mapping"});
            this.PanelSelector.Location = new System.Drawing.Point(6, 6);
            this.PanelSelector.Name = "PanelSelector";
            this.PanelSelector.Size = new System.Drawing.Size(150, 369);
            this.PanelSelector.TabIndex = 3;
            this.PanelSelector.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // SelectorPanel
            // 
            this.SelectorPanel.Controls.Add(this.PanelSelector);
            this.SelectorPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.SelectorPanel.Location = new System.Drawing.Point(0, 0);
            this.SelectorPanel.Margin = new System.Windows.Forms.Padding(0);
            this.SelectorPanel.Name = "SelectorPanel";
            this.SelectorPanel.Padding = new System.Windows.Forms.Padding(6);
            this.SelectorPanel.Size = new System.Drawing.Size(162, 381);
            this.SelectorPanel.TabIndex = 5;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.OptionsPanelCollection);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(162, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Padding = new System.Windows.Forms.Padding(6);
            this.ContentPanel.Size = new System.Drawing.Size(352, 381);
            this.ContentPanel.TabIndex = 6;
            // 
            // OptionsPanelCollection
            // 
            this.OptionsPanelCollection.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.OptionsPanelCollection.Controls.Add(this.ViewOptionsPanel);
            this.OptionsPanelCollection.Controls.Add(this.tabPage2);
            this.OptionsPanelCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsPanelCollection.Location = new System.Drawing.Point(6, 6);
            this.OptionsPanelCollection.Name = "OptionsPanelCollection";
            this.OptionsPanelCollection.SelectedIndex = 0;
            this.OptionsPanelCollection.Size = new System.Drawing.Size(340, 369);
            this.OptionsPanelCollection.TabIndex = 0;
            // 
            // ViewOptionsPanel
            // 
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar_ActivityName);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar_ProjectName);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar);
            this.ViewOptionsPanel.Location = new System.Drawing.Point(4, 4);
            this.ViewOptionsPanel.Name = "ViewOptionsPanel";
            this.ViewOptionsPanel.Padding = new System.Windows.Forms.Padding(3);
            this.ViewOptionsPanel.Size = new System.Drawing.Size(332, 343);
            this.ViewOptionsPanel.TabIndex = 0;
            this.ViewOptionsPanel.Text = "View";
            this.ViewOptionsPanel.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ActivityName
            // 
            this.View_StatusBar_ActivityName.AutoSize = true;
            this.View_StatusBar_ActivityName.Location = new System.Drawing.Point(53, 105);
            this.View_StatusBar_ActivityName.Name = "View_StatusBar_ActivityName";
            this.View_StatusBar_ActivityName.Size = new System.Drawing.Size(91, 17);
            this.View_StatusBar_ActivityName.TabIndex = 2;
            this.View_StatusBar_ActivityName.Text = "Activity Name";
            this.View_StatusBar_ActivityName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ProjectName
            // 
            this.View_StatusBar_ProjectName.AutoSize = true;
            this.View_StatusBar_ProjectName.Location = new System.Drawing.Point(53, 82);
            this.View_StatusBar_ProjectName.Name = "View_StatusBar_ProjectName";
            this.View_StatusBar_ProjectName.Size = new System.Drawing.Size(90, 17);
            this.View_StatusBar_ProjectName.TabIndex = 1;
            this.View_StatusBar_ProjectName.Text = "Project Name";
            this.View_StatusBar_ProjectName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar
            // 
            this.View_StatusBar.AutoSize = true;
            this.View_StatusBar.Location = new System.Drawing.Point(53, 59);
            this.View_StatusBar.Name = "View_StatusBar";
            this.View_StatusBar.Size = new System.Drawing.Size(75, 17);
            this.View_StatusBar.TabIndex = 0;
            this.View_StatusBar.Text = "Status Bar";
            this.View_StatusBar.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(332, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(514, 420);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.SelectorPanel);
            this.Controls.Add(this.ButtonPanel);
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Options";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.ButtonPanel.ResumeLayout(false);
            this.SelectorPanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.OptionsPanelCollection.ResumeLayout(false);
            this.ViewOptionsPanel.ResumeLayout(false);
            this.ViewOptionsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button AcceptDialogButton;
        private System.Windows.Forms.ListBox PanelSelector;
        //        private Forms.Controls.TablessControl tablessControl1;
        private System.Windows.Forms.Panel SelectorPanel;
        private System.Windows.Forms.Panel ContentPanel;
        private System.Windows.Forms.TabControl OptionsPanelCollection;
        private System.Windows.Forms.TabPage ViewOptionsPanel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox View_StatusBar;
        private System.Windows.Forms.CheckBox View_StatusBar_ActivityName;
        private System.Windows.Forms.CheckBox View_StatusBar_ProjectName;

    }
}