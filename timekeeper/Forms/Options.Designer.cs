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
            this.View_StatusBar_ElapsedSinceStart = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedProjectToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedActivityToday = new System.Windows.Forms.CheckBox();
            this.View_StatusBar_ElapsedAllToday = new System.Windows.Forms.CheckBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Layout_UseProjects = new System.Windows.Forms.RadioButton();
            this.Layout_UseActivities = new System.Windows.Forms.RadioButton();
            this.Layout_UseBoth = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ButtonPanel.SuspendLayout();
            this.SelectorPanel.SuspendLayout();
            this.ContentPanel.SuspendLayout();
            this.OptionsPanelCollection.SuspendLayout();
            this.ViewOptionsPanel.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.CancelDialogButton);
            this.ButtonPanel.Controls.Add(this.AcceptDialogButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 381);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(557, 39);
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
            "Layout Options",
            "View Options",
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
            this.ContentPanel.Size = new System.Drawing.Size(395, 381);
            this.ContentPanel.TabIndex = 6;
            // 
            // OptionsPanelCollection
            // 
            this.OptionsPanelCollection.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.OptionsPanelCollection.Controls.Add(this.tabPage1);
            this.OptionsPanelCollection.Controls.Add(this.ViewOptionsPanel);
            this.OptionsPanelCollection.Controls.Add(this.tabPage2);
            this.OptionsPanelCollection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OptionsPanelCollection.Location = new System.Drawing.Point(6, 6);
            this.OptionsPanelCollection.Name = "OptionsPanelCollection";
            this.OptionsPanelCollection.SelectedIndex = 0;
            this.OptionsPanelCollection.Size = new System.Drawing.Size(383, 369);
            this.OptionsPanelCollection.TabIndex = 0;
            // 
            // ViewOptionsPanel
            // 
            this.ViewOptionsPanel.Controls.Add(this.label2);
            this.ViewOptionsPanel.Controls.Add(this.label1);
            this.ViewOptionsPanel.Controls.Add(this.checkedListBox1);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar_ElapsedAllToday);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar_ElapsedActivityToday);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar_ElapsedProjectToday);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar_ElapsedSinceStart);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar_ActivityName);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar_ProjectName);
            this.ViewOptionsPanel.Controls.Add(this.View_StatusBar);
            this.ViewOptionsPanel.Location = new System.Drawing.Point(4, 4);
            this.ViewOptionsPanel.Name = "ViewOptionsPanel";
            this.ViewOptionsPanel.Padding = new System.Windows.Forms.Padding(3);
            this.ViewOptionsPanel.Size = new System.Drawing.Size(375, 343);
            this.ViewOptionsPanel.TabIndex = 0;
            this.ViewOptionsPanel.Text = "View";
            this.ViewOptionsPanel.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ActivityName
            // 
            this.View_StatusBar_ActivityName.AutoSize = true;
            this.View_StatusBar_ActivityName.Location = new System.Drawing.Point(6, 52);
            this.View_StatusBar_ActivityName.Name = "View_StatusBar_ActivityName";
            this.View_StatusBar_ActivityName.Size = new System.Drawing.Size(91, 17);
            this.View_StatusBar_ActivityName.TabIndex = 2;
            this.View_StatusBar_ActivityName.Text = "Activity Name";
            this.View_StatusBar_ActivityName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ProjectName
            // 
            this.View_StatusBar_ProjectName.AutoSize = true;
            this.View_StatusBar_ProjectName.Location = new System.Drawing.Point(6, 29);
            this.View_StatusBar_ProjectName.Name = "View_StatusBar_ProjectName";
            this.View_StatusBar_ProjectName.Size = new System.Drawing.Size(90, 17);
            this.View_StatusBar_ProjectName.TabIndex = 1;
            this.View_StatusBar_ProjectName.Text = "Project Name";
            this.View_StatusBar_ProjectName.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar
            // 
            this.View_StatusBar.AutoSize = true;
            this.View_StatusBar.Location = new System.Drawing.Point(6, 6);
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
            this.tabPage2.Size = new System.Drawing.Size(375, 343);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedSinceStart
            // 
            this.View_StatusBar_ElapsedSinceStart.AutoSize = true;
            this.View_StatusBar_ElapsedSinceStart.Location = new System.Drawing.Point(6, 75);
            this.View_StatusBar_ElapsedSinceStart.Name = "View_StatusBar_ElapsedSinceStart";
            this.View_StatusBar_ElapsedSinceStart.Size = new System.Drawing.Size(119, 17);
            this.View_StatusBar_ElapsedSinceStart.TabIndex = 3;
            this.View_StatusBar_ElapsedSinceStart.Text = "Elapsed Since Start";
            this.View_StatusBar_ElapsedSinceStart.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedProjectToday
            // 
            this.View_StatusBar_ElapsedProjectToday.AutoSize = true;
            this.View_StatusBar_ElapsedProjectToday.Location = new System.Drawing.Point(6, 98);
            this.View_StatusBar_ElapsedProjectToday.Name = "View_StatusBar_ElapsedProjectToday";
            this.View_StatusBar_ElapsedProjectToday.Size = new System.Drawing.Size(133, 17);
            this.View_StatusBar_ElapsedProjectToday.TabIndex = 4;
            this.View_StatusBar_ElapsedProjectToday.Text = "Elapsed Project Today";
            this.View_StatusBar_ElapsedProjectToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedActivityToday
            // 
            this.View_StatusBar_ElapsedActivityToday.AutoSize = true;
            this.View_StatusBar_ElapsedActivityToday.Location = new System.Drawing.Point(6, 121);
            this.View_StatusBar_ElapsedActivityToday.Name = "View_StatusBar_ElapsedActivityToday";
            this.View_StatusBar_ElapsedActivityToday.Size = new System.Drawing.Size(134, 17);
            this.View_StatusBar_ElapsedActivityToday.TabIndex = 5;
            this.View_StatusBar_ElapsedActivityToday.Text = "Elapsed Activity Today";
            this.View_StatusBar_ElapsedActivityToday.UseVisualStyleBackColor = true;
            // 
            // View_StatusBar_ElapsedAllToday
            // 
            this.View_StatusBar_ElapsedAllToday.AutoSize = true;
            this.View_StatusBar_ElapsedAllToday.Location = new System.Drawing.Point(6, 144);
            this.View_StatusBar_ElapsedAllToday.Name = "View_StatusBar_ElapsedAllToday";
            this.View_StatusBar_ElapsedAllToday.Size = new System.Drawing.Size(111, 17);
            this.View_StatusBar_ElapsedAllToday.TabIndex = 6;
            this.View_StatusBar_ElapsedAllToday.Text = "Elapsed All Today";
            this.View_StatusBar_ElapsedAllToday.UseVisualStyleBackColor = true;
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "View_StatusBar",
            "View_StatusBar_ProjectName",
            "View_StatusBar_ActivityName",
            "View_StatusBar_ElapsedSinceStart",
            "View_StatusBar_ElapsedProjectToday",
            "View_StatusBar_ElapsedActivityToday",
            "View_StatusBar_ElapsedAllToday"});
            this.checkedListBox1.Location = new System.Drawing.Point(149, 6);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(220, 109);
            this.checkedListBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(155, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(209, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Go with this one later, to support reordering";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(375, 343);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Layout";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Layout_UseBoth);
            this.groupBox1.Controls.Add(this.Layout_UseActivities);
            this.groupBox1.Controls.Add(this.Layout_UseProjects);
            this.groupBox1.Location = new System.Drawing.Point(6, 121);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Title";
            // 
            // Layout_UseProjects
            // 
            this.Layout_UseProjects.AutoSize = true;
            this.Layout_UseProjects.Location = new System.Drawing.Point(17, 65);
            this.Layout_UseProjects.Name = "Layout_UseProjects";
            this.Layout_UseProjects.Size = new System.Drawing.Size(85, 17);
            this.Layout_UseProjects.TabIndex = 0;
            this.Layout_UseProjects.Text = "Use Projects";
            this.Layout_UseProjects.UseVisualStyleBackColor = true;
            // 
            // Layout_UseActivities
            // 
            this.Layout_UseActivities.AutoSize = true;
            this.Layout_UseActivities.Location = new System.Drawing.Point(17, 42);
            this.Layout_UseActivities.Name = "Layout_UseActivities";
            this.Layout_UseActivities.Size = new System.Drawing.Size(89, 17);
            this.Layout_UseActivities.TabIndex = 1;
            this.Layout_UseActivities.TabStop = true;
            this.Layout_UseActivities.Text = "Use Activities";
            this.Layout_UseActivities.UseVisualStyleBackColor = true;
            // 
            // Layout_UseBoth
            // 
            this.Layout_UseBoth.AutoSize = true;
            this.Layout_UseBoth.Checked = true;
            this.Layout_UseBoth.Location = new System.Drawing.Point(17, 19);
            this.Layout_UseBoth.Name = "Layout_UseBoth";
            this.Layout_UseBoth.Size = new System.Drawing.Size(151, 17);
            this.Layout_UseBoth.TabIndex = 2;
            this.Layout_UseBoth.TabStop = true;
            this.Layout_UseBoth.Text = "Use Projects and Activities";
            this.Layout_UseBoth.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(266, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "This will also better support hiding Projects or Activities.";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(187, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Interface";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 65);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(78, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.Text = "The Works";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(17, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(59, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Text = "Typical";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(17, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(56, 17);
            this.radioButton3.TabIndex = 0;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Simple";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(7, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 84);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox1.AutoSize = true;
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.checkBox1.Image = global::Timekeeper.Properties.Resources.PictureSetup;
            this.checkBox1.Location = new System.Drawing.Point(199, 11);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(170, 320);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Options
            // 
            this.AcceptButton = this.AcceptDialogButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelDialogButton;
            this.ClientSize = new System.Drawing.Size(557, 420);
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
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedAllToday;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedActivityToday;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedProjectToday;
        private System.Windows.Forms.CheckBox View_StatusBar_ElapsedSinceStart;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Layout_UseBoth;
        private System.Windows.Forms.RadioButton Layout_UseActivities;
        private System.Windows.Forms.RadioButton Layout_UseProjects;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;

    }
}