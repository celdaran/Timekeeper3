namespace Timekeeper.Forms
{
    partial class UpgradeWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpgradeWizard));
            this.StartButton = new System.Windows.Forms.Button();
            this.LaterButton = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.WizardPicture = new System.Windows.Forms.PictureBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tablessControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.IntroductionInstructions = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.BackUpFileLabel = new System.Windows.Forms.TextBox();
            this.DatabaseBackupInstructions = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.LocationTimeZone = new System.Windows.Forms.ComboBox();
            this.LocationDescription = new System.Windows.Forms.TextBox();
            this.LocationName = new System.Windows.Forms.TextBox();
            this.LocationTimeZoneLabel = new System.Windows.Forms.Label();
            this.LocationDescriptionLabel = new System.Windows.Forms.Label();
            this.LocationNameLabel = new System.Windows.Forms.Label();
            this.LocationInstructions = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.MemoOption = new System.Windows.Forms.GroupBox();
            this.MergeMemoStandard = new System.Windows.Forms.RadioButton();
            this.MemoMergeInstructions2 = new System.Windows.Forms.Label();
            this.MergeMemoNoSep = new System.Windows.Forms.RadioButton();
            this.MergeMemoNoPost = new System.Windows.Forms.RadioButton();
            this.MergeMemoNoPre = new System.Windows.Forms.RadioButton();
            this.MemoMergeInstructions = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.UpgradeReview = new System.Windows.Forms.TextBox();
            this.FinalizeInstructions = new System.Windows.Forms.Label();
            this.UpgradeProgress = new System.Windows.Forms.ProgressBar();
            this.StepLabel = new System.Windows.Forms.Label();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.tablessControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.MemoOption.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(12, 9);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(43, 23);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Fi&nish";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Visible = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // LaterButton
            // 
            this.LaterButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.LaterButton.Location = new System.Drawing.Point(431, 9);
            this.LaterButton.Name = "LaterButton";
            this.LaterButton.Size = new System.Drawing.Size(75, 23);
            this.LaterButton.TabIndex = 4;
            this.LaterButton.Text = "Cancel";
            this.LaterButton.UseVisualStyleBackColor = true;
            // 
            // OkayButton
            // 
            this.OkayButton.Location = new System.Drawing.Point(61, 9);
            this.OkayButton.Name = "OkayButton";
            this.OkayButton.Size = new System.Drawing.Size(43, 23);
            this.OkayButton.TabIndex = 3;
            this.OkayButton.Text = "Close";
            this.OkayButton.UseVisualStyleBackColor = true;
            this.OkayButton.Visible = false;
            this.OkayButton.Click += new System.EventHandler(this.OkayButton_Click);
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.StartButton);
            this.ButtonPanel.Controls.Add(this.BackButton);
            this.ButtonPanel.Controls.Add(this.NextButton);
            this.ButtonPanel.Controls.Add(this.LaterButton);
            this.ButtonPanel.Controls.Add(this.OkayButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 273);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(518, 41);
            this.ButtonPanel.TabIndex = 14;
            // 
            // BackButton
            // 
            this.BackButton.Enabled = false;
            this.BackButton.Location = new System.Drawing.Point(269, 9);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 5;
            this.BackButton.Text = "< &Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.ButtonBack_Click);
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(344, 9);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "&Next >";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // WizardPicture
            // 
            this.WizardPicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.WizardPicture.Image = global::Timekeeper.Properties.Resources.PictureSetup;
            this.WizardPicture.Location = new System.Drawing.Point(0, 0);
            this.WizardPicture.Name = "WizardPicture";
            this.WizardPicture.Size = new System.Drawing.Size(163, 273);
            this.WizardPicture.TabIndex = 13;
            this.WizardPicture.TabStop = false;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.tablessControl1);
            this.TopPanel.Controls.Add(this.WizardPicture);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(518, 273);
            this.TopPanel.TabIndex = 15;
            // 
            // FileDialog
            // 
            this.FileDialog.CheckFileExists = false;
            this.FileDialog.DefaultExt = "tkdb";
            this.FileDialog.FileName = "openFileDialog1";
            // 
            // tablessControl1
            // 
            this.tablessControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tablessControl1.Controls.Add(this.tabPage1);
            this.tablessControl1.Controls.Add(this.tabPage2);
            this.tablessControl1.Controls.Add(this.tabPage3);
            this.tablessControl1.Controls.Add(this.tabPage4);
            this.tablessControl1.Controls.Add(this.tabPage5);
            this.tablessControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablessControl1.Location = new System.Drawing.Point(163, 0);
            this.tablessControl1.Name = "tablessControl1";
            this.tablessControl1.SelectedIndex = 0;
            this.tablessControl1.Size = new System.Drawing.Size(355, 273);
            this.tablessControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Controls.Add(this.IntroductionInstructions);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(347, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // IntroductionInstructions
            // 
            this.IntroductionInstructions.AutoSize = true;
            this.IntroductionInstructions.Location = new System.Drawing.Point(5, 16);
            this.IntroductionInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.IntroductionInstructions.Name = "IntroductionInstructions";
            this.IntroductionInstructions.Size = new System.Drawing.Size(333, 143);
            this.IntroductionInstructions.TabIndex = 11;
            this.IntroductionInstructions.Text = resources.GetString("IntroductionInstructions.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage2.Controls.Add(this.SelectFileButton);
            this.tabPage2.Controls.Add(this.BackUpFileLabel);
            this.tabPage2.Controls.Add(this.DatabaseBackupInstructions);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(347, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectFileButton.Location = new System.Drawing.Point(313, 54);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(26, 20);
            this.SelectFileButton.TabIndex = 15;
            this.SelectFileButton.Text = "...";
            this.SelectFileButton.UseVisualStyleBackColor = false;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // BackUpFileLabel
            // 
            this.BackUpFileLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackUpFileLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.BackUpFileLabel.Location = new System.Drawing.Point(8, 55);
            this.BackUpFileLabel.Name = "BackUpFileLabel";
            this.BackUpFileLabel.Size = new System.Drawing.Size(299, 20);
            this.BackUpFileLabel.TabIndex = 14;
            // 
            // DatabaseBackupInstructions
            // 
            this.DatabaseBackupInstructions.AutoSize = true;
            this.DatabaseBackupInstructions.Location = new System.Drawing.Point(5, 16);
            this.DatabaseBackupInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.DatabaseBackupInstructions.Name = "DatabaseBackupInstructions";
            this.DatabaseBackupInstructions.Size = new System.Drawing.Size(326, 26);
            this.DatabaseBackupInstructions.TabIndex = 13;
            this.DatabaseBackupInstructions.Text = "Your database will be backed up to the following location. You may accept the pro" +
    "vided name or select your own:";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage3.Controls.Add(this.LocationTimeZone);
            this.tabPage3.Controls.Add(this.LocationDescription);
            this.tabPage3.Controls.Add(this.LocationName);
            this.tabPage3.Controls.Add(this.LocationTimeZoneLabel);
            this.tabPage3.Controls.Add(this.LocationDescriptionLabel);
            this.tabPage3.Controls.Add(this.LocationNameLabel);
            this.tabPage3.Controls.Add(this.LocationInstructions);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(347, 247);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // LocationTimeZone
            // 
            this.LocationTimeZone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LocationTimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationTimeZone.FormattingEnabled = true;
            this.LocationTimeZone.Location = new System.Drawing.Point(79, 197);
            this.LocationTimeZone.Name = "LocationTimeZone";
            this.LocationTimeZone.Size = new System.Drawing.Size(262, 21);
            this.LocationTimeZone.TabIndex = 21;
            // 
            // LocationDescription
            // 
            this.LocationDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LocationDescription.Location = new System.Drawing.Point(79, 145);
            this.LocationDescription.Multiline = true;
            this.LocationDescription.Name = "LocationDescription";
            this.LocationDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LocationDescription.Size = new System.Drawing.Size(260, 46);
            this.LocationDescription.TabIndex = 19;
            // 
            // LocationName
            // 
            this.LocationName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LocationName.Location = new System.Drawing.Point(79, 119);
            this.LocationName.Name = "LocationName";
            this.LocationName.Size = new System.Drawing.Size(260, 20);
            this.LocationName.TabIndex = 18;
            this.LocationName.Text = "Default";
            // 
            // LocationTimeZoneLabel
            // 
            this.LocationTimeZoneLabel.AutoSize = true;
            this.LocationTimeZoneLabel.Location = new System.Drawing.Point(5, 200);
            this.LocationTimeZoneLabel.Name = "LocationTimeZoneLabel";
            this.LocationTimeZoneLabel.Size = new System.Drawing.Size(64, 13);
            this.LocationTimeZoneLabel.TabIndex = 17;
            this.LocationTimeZoneLabel.Text = "Time Zone: ";
            // 
            // LocationDescriptionLabel
            // 
            this.LocationDescriptionLabel.AutoSize = true;
            this.LocationDescriptionLabel.Location = new System.Drawing.Point(5, 148);
            this.LocationDescriptionLabel.Name = "LocationDescriptionLabel";
            this.LocationDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.LocationDescriptionLabel.TabIndex = 16;
            this.LocationDescriptionLabel.Text = "Description:";
            // 
            // LocationNameLabel
            // 
            this.LocationNameLabel.AutoSize = true;
            this.LocationNameLabel.Location = new System.Drawing.Point(5, 122);
            this.LocationNameLabel.Name = "LocationNameLabel";
            this.LocationNameLabel.Size = new System.Drawing.Size(38, 13);
            this.LocationNameLabel.TabIndex = 15;
            this.LocationNameLabel.Text = "Name:";
            // 
            // LocationInstructions
            // 
            this.LocationInstructions.AutoSize = true;
            this.LocationInstructions.Location = new System.Drawing.Point(5, 16);
            this.LocationInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.LocationInstructions.Name = "LocationInstructions";
            this.LocationInstructions.Size = new System.Drawing.Size(335, 91);
            this.LocationInstructions.TabIndex = 14;
            this.LocationInstructions.Text = resources.GetString("LocationInstructions.Text");
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage4.Controls.Add(this.MemoOption);
            this.tabPage4.Controls.Add(this.MemoMergeInstructions);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(347, 247);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // MemoOption
            // 
            this.MemoOption.Controls.Add(this.MergeMemoStandard);
            this.MemoOption.Controls.Add(this.MemoMergeInstructions2);
            this.MemoOption.Controls.Add(this.MergeMemoNoSep);
            this.MemoOption.Controls.Add(this.MergeMemoNoPost);
            this.MemoOption.Controls.Add(this.MergeMemoNoPre);
            this.MemoOption.Location = new System.Drawing.Point(8, 58);
            this.MemoOption.Name = "MemoOption";
            this.MemoOption.Size = new System.Drawing.Size(329, 170);
            this.MemoOption.TabIndex = 21;
            this.MemoOption.TabStop = false;
            // 
            // MergeMemoStandard
            // 
            this.MergeMemoStandard.AutoSize = true;
            this.MergeMemoStandard.Checked = true;
            this.MergeMemoStandard.Location = new System.Drawing.Point(9, 19);
            this.MergeMemoStandard.Name = "MergeMemoStandard";
            this.MergeMemoStandard.Size = new System.Drawing.Size(296, 17);
            this.MergeMemoStandard.TabIndex = 16;
            this.MergeMemoStandard.TabStop = true;
            this.MergeMemoStandard.Text = "Merge using the standard separator text. (Recommended)";
            this.MergeMemoStandard.UseVisualStyleBackColor = true;
            // 
            // MemoMergeInstructions2
            // 
            this.MemoMergeInstructions2.AutoSize = true;
            this.MemoMergeInstructions2.Location = new System.Drawing.Point(6, 53);
            this.MemoMergeInstructions2.MaximumSize = new System.Drawing.Size(336, 0);
            this.MemoMergeInstructions2.Name = "MemoMergeInstructions2";
            this.MemoMergeInstructions2.Size = new System.Drawing.Size(183, 13);
            this.MemoMergeInstructions2.TabIndex = 20;
            this.MemoMergeInstructions2.Text = "The following options are destructive:";
            // 
            // MergeMemoNoSep
            // 
            this.MergeMemoNoSep.AutoSize = true;
            this.MergeMemoNoSep.Location = new System.Drawing.Point(9, 82);
            this.MergeMemoNoSep.Name = "MergeMemoNoSep";
            this.MergeMemoNoSep.Size = new System.Drawing.Size(258, 17);
            this.MergeMemoNoSep.TabIndex = 17;
            this.MergeMemoNoSep.Text = "Merge but do not use the standard separator text.";
            this.MergeMemoNoSep.UseVisualStyleBackColor = true;
            // 
            // MergeMemoNoPost
            // 
            this.MergeMemoNoPost.AutoSize = true;
            this.MergeMemoNoPost.Location = new System.Drawing.Point(9, 128);
            this.MergeMemoNoPost.Name = "MergeMemoNoPost";
            this.MergeMemoNoPost.Size = new System.Drawing.Size(271, 17);
            this.MergeMemoNoPost.TabIndex = 19;
            this.MergeMemoNoPost.Text = "Copy only post annotations, discard pre annotations.";
            this.MergeMemoNoPost.UseVisualStyleBackColor = true;
            // 
            // MergeMemoNoPre
            // 
            this.MergeMemoNoPre.AutoSize = true;
            this.MergeMemoNoPre.Location = new System.Drawing.Point(9, 105);
            this.MergeMemoNoPre.Name = "MergeMemoNoPre";
            this.MergeMemoNoPre.Size = new System.Drawing.Size(271, 17);
            this.MergeMemoNoPre.TabIndex = 18;
            this.MergeMemoNoPre.Text = "Copy only pre annotations, discard post annotations.";
            this.MergeMemoNoPre.UseVisualStyleBackColor = true;
            // 
            // MemoMergeInstructions
            // 
            this.MemoMergeInstructions.AutoSize = true;
            this.MemoMergeInstructions.Location = new System.Drawing.Point(5, 16);
            this.MemoMergeInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.MemoMergeInstructions.Name = "MemoMergeInstructions";
            this.MemoMergeInstructions.Size = new System.Drawing.Size(332, 39);
            this.MemoMergeInstructions.TabIndex = 15;
            this.MemoMergeInstructions.Text = "Timekeeper now stores all journal entry annotations in a single memo value. The p" +
    "revious \"pre\" and \"post\" annotations will be merged together. How do you want to" +
    " handle this conversion?";
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage5.Controls.Add(this.UpgradeReview);
            this.tabPage5.Controls.Add(this.FinalizeInstructions);
            this.tabPage5.Controls.Add(this.UpgradeProgress);
            this.tabPage5.Controls.Add(this.StepLabel);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(347, 247);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            // 
            // UpgradeReview
            // 
            this.UpgradeReview.Location = new System.Drawing.Point(8, 67);
            this.UpgradeReview.Multiline = true;
            this.UpgradeReview.Name = "UpgradeReview";
            this.UpgradeReview.ReadOnly = true;
            this.UpgradeReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.UpgradeReview.Size = new System.Drawing.Size(328, 119);
            this.UpgradeReview.TabIndex = 23;
            // 
            // FinalizeInstructions
            // 
            this.FinalizeInstructions.AutoSize = true;
            this.FinalizeInstructions.Location = new System.Drawing.Point(5, 16);
            this.FinalizeInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.FinalizeInstructions.Name = "FinalizeInstructions";
            this.FinalizeInstructions.Size = new System.Drawing.Size(331, 39);
            this.FinalizeInstructions.TabIndex = 21;
            this.FinalizeInstructions.Text = "Please review your upgrade options and click Finish to upgrade your database. Not" +
    "e, depending on the size of your database, this operation could take several min" +
    "utes.";
            // 
            // UpgradeProgress
            // 
            this.UpgradeProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.UpgradeProgress.Location = new System.Drawing.Point(6, 228);
            this.UpgradeProgress.Name = "UpgradeProgress";
            this.UpgradeProgress.Size = new System.Drawing.Size(328, 23);
            this.UpgradeProgress.TabIndex = 19;
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(5, 212);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(51, 13);
            this.StepLabel.TabIndex = 20;
            this.StepLabel.Text = "Progress:";
            // 
            // UpgradeWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.LaterButton;
            this.ClientSize = new System.Drawing.Size(518, 314);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.ButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpgradeWizard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upgrade Database";
            this.Load += new System.EventHandler(this.Upgrade_Load);
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.tablessControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.MemoOption.ResumeLayout(false);
            this.MemoOption.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button LaterButton;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.TabControl tablessControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.PictureBox WizardPicture;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label IntroductionInstructions;
        private System.Windows.Forms.Button SelectFileButton;
        private System.Windows.Forms.Label DatabaseBackupInstructions;
        internal System.Windows.Forms.TextBox BackUpFileLabel;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.ComboBox LocationTimeZone;
        private System.Windows.Forms.TextBox LocationDescription;
        private System.Windows.Forms.TextBox LocationName;
        private System.Windows.Forms.Label LocationTimeZoneLabel;
        private System.Windows.Forms.Label LocationDescriptionLabel;
        private System.Windows.Forms.Label LocationNameLabel;
        private System.Windows.Forms.Label LocationInstructions;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.RadioButton MergeMemoNoPost;
        private System.Windows.Forms.RadioButton MergeMemoNoPre;
        private System.Windows.Forms.RadioButton MergeMemoNoSep;
        private System.Windows.Forms.RadioButton MergeMemoStandard;
        private System.Windows.Forms.Label MemoMergeInstructions;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.ProgressBar UpgradeProgress;
        public System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.Label FinalizeInstructions;
        private System.Windows.Forms.Label MemoMergeInstructions2;
        private System.Windows.Forms.TextBox UpgradeReview;
        private System.Windows.Forms.GroupBox MemoOption;
    }
}