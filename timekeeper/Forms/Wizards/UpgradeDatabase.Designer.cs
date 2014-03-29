namespace Timekeeper.Forms.Wizards
{
    partial class UpgradeDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpgradeDatabase));
            this.StartButton = new System.Windows.Forms.Button();
            this.LaterButton = new System.Windows.Forms.Button();
            this.OkayButton = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.WizardPicture = new System.Windows.Forms.PictureBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Tab5 = new System.Windows.Forms.Panel();
            this.UpgradeReview = new System.Windows.Forms.TextBox();
            this.FinalizeInstructions = new System.Windows.Forms.Label();
            this.StepLabel = new System.Windows.Forms.Label();
            this.UpgradeProgress = new System.Windows.Forms.ProgressBar();
            this.Tab4 = new System.Windows.Forms.Panel();
            this.MemoOption = new System.Windows.Forms.GroupBox();
            this.MergeMemoStandard = new System.Windows.Forms.RadioButton();
            this.MemoMergeInstructions2 = new System.Windows.Forms.Label();
            this.MergeMemoNoSep = new System.Windows.Forms.RadioButton();
            this.MergeMemoNoPost = new System.Windows.Forms.RadioButton();
            this.MergeMemoNoPre = new System.Windows.Forms.RadioButton();
            this.MemoMergeInstructions = new System.Windows.Forms.Label();
            this.Tab3 = new System.Windows.Forms.Panel();
            this.LocationTimeZone = new System.Windows.Forms.ComboBox();
            this.LocationInstructions = new System.Windows.Forms.Label();
            this.LocationNameLabel = new System.Windows.Forms.Label();
            this.LocationDescription = new System.Windows.Forms.TextBox();
            this.LocationDescriptionLabel = new System.Windows.Forms.Label();
            this.LocationTimeZoneLabel = new System.Windows.Forms.Label();
            this.LocationName = new System.Windows.Forms.TextBox();
            this.Tab2 = new System.Windows.Forms.Panel();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.DatabaseBackupInstructions = new System.Windows.Forms.Label();
            this.BackUpFileLabel = new System.Windows.Forms.TextBox();
            this.Tab1 = new System.Windows.Forms.Panel();
            this.IntroductionInstructions = new System.Windows.Forms.Label();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.Tab5.SuspendLayout();
            this.Tab4.SuspendLayout();
            this.MemoOption.SuspendLayout();
            this.Tab3.SuspendLayout();
            this.Tab2.SuspendLayout();
            this.Tab1.SuspendLayout();
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
            this.LaterButton.Click += new System.EventHandler(this.LaterButton_Click);
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
            this.ButtonPanel.Location = new System.Drawing.Point(0, 282);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(2018, 41);
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
            this.WizardPicture.Size = new System.Drawing.Size(163, 282);
            this.WizardPicture.TabIndex = 13;
            this.WizardPicture.TabStop = false;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.Tab5);
            this.TopPanel.Controls.Add(this.Tab4);
            this.TopPanel.Controls.Add(this.Tab3);
            this.TopPanel.Controls.Add(this.Tab2);
            this.TopPanel.Controls.Add(this.Tab1);
            this.TopPanel.Controls.Add(this.WizardPicture);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(2018, 282);
            this.TopPanel.TabIndex = 15;
            // 
            // Tab5
            // 
            this.Tab5.BackColor = System.Drawing.SystemColors.Window;
            this.Tab5.Controls.Add(this.UpgradeReview);
            this.Tab5.Controls.Add(this.FinalizeInstructions);
            this.Tab5.Controls.Add(this.StepLabel);
            this.Tab5.Controls.Add(this.UpgradeProgress);
            this.Tab5.Location = new System.Drawing.Point(1604, 0);
            this.Tab5.Name = "Tab5";
            this.Tab5.Size = new System.Drawing.Size(354, 283);
            this.Tab5.TabIndex = 21;
            // 
            // UpgradeReview
            // 
            this.UpgradeReview.Location = new System.Drawing.Point(6, 60);
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
            this.FinalizeInstructions.Location = new System.Drawing.Point(3, 9);
            this.FinalizeInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.FinalizeInstructions.Name = "FinalizeInstructions";
            this.FinalizeInstructions.Size = new System.Drawing.Size(336, 39);
            this.FinalizeInstructions.TabIndex = 21;
            this.FinalizeInstructions.Text = "Please review your options and click Finish to upgrade your database. Note, depen" +
    "ding on the size of your database, this operation could take several minutes.";
            // 
            // StepLabel
            // 
            this.StepLabel.AutoSize = true;
            this.StepLabel.Location = new System.Drawing.Point(3, 205);
            this.StepLabel.Name = "StepLabel";
            this.StepLabel.Size = new System.Drawing.Size(51, 13);
            this.StepLabel.TabIndex = 20;
            this.StepLabel.Text = "Progress:";
            // 
            // UpgradeProgress
            // 
            this.UpgradeProgress.BackColor = System.Drawing.SystemColors.Control;
            this.UpgradeProgress.Location = new System.Drawing.Point(4, 221);
            this.UpgradeProgress.Name = "UpgradeProgress";
            this.UpgradeProgress.Size = new System.Drawing.Size(328, 23);
            this.UpgradeProgress.TabIndex = 19;
            // 
            // Tab4
            // 
            this.Tab4.BackColor = System.Drawing.SystemColors.Window;
            this.Tab4.Controls.Add(this.MemoOption);
            this.Tab4.Controls.Add(this.MemoMergeInstructions);
            this.Tab4.Location = new System.Drawing.Point(1244, 0);
            this.Tab4.Name = "Tab4";
            this.Tab4.Size = new System.Drawing.Size(354, 283);
            this.Tab4.TabIndex = 20;
            // 
            // MemoOption
            // 
            this.MemoOption.Controls.Add(this.MergeMemoStandard);
            this.MemoOption.Controls.Add(this.MemoMergeInstructions2);
            this.MemoOption.Controls.Add(this.MergeMemoNoSep);
            this.MemoOption.Controls.Add(this.MergeMemoNoPost);
            this.MemoOption.Controls.Add(this.MergeMemoNoPre);
            this.MemoOption.Location = new System.Drawing.Point(6, 51);
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
            this.MemoMergeInstructions.Location = new System.Drawing.Point(3, 9);
            this.MemoMergeInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.MemoMergeInstructions.Name = "MemoMergeInstructions";
            this.MemoMergeInstructions.Size = new System.Drawing.Size(327, 39);
            this.MemoMergeInstructions.TabIndex = 15;
            this.MemoMergeInstructions.Text = "Timekeeper 3.0 stores all journal entry annotations in a single memo value. The p" +
    "revious \"pre\" and \"post\" annotations will be merged together. How do you want to" +
    " handle this conversion?";
            // 
            // Tab3
            // 
            this.Tab3.BackColor = System.Drawing.SystemColors.Window;
            this.Tab3.Controls.Add(this.LocationTimeZone);
            this.Tab3.Controls.Add(this.LocationInstructions);
            this.Tab3.Controls.Add(this.LocationNameLabel);
            this.Tab3.Controls.Add(this.LocationDescription);
            this.Tab3.Controls.Add(this.LocationDescriptionLabel);
            this.Tab3.Controls.Add(this.LocationTimeZoneLabel);
            this.Tab3.Controls.Add(this.LocationName);
            this.Tab3.Location = new System.Drawing.Point(884, 0);
            this.Tab3.Name = "Tab3";
            this.Tab3.Size = new System.Drawing.Size(354, 283);
            this.Tab3.TabIndex = 19;
            // 
            // LocationTimeZone
            // 
            this.LocationTimeZone.BackColor = System.Drawing.SystemColors.Window;
            this.LocationTimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationTimeZone.FormattingEnabled = true;
            this.LocationTimeZone.Location = new System.Drawing.Point(77, 190);
            this.LocationTimeZone.Name = "LocationTimeZone";
            this.LocationTimeZone.Size = new System.Drawing.Size(262, 21);
            this.LocationTimeZone.TabIndex = 21;
            // 
            // LocationInstructions
            // 
            this.LocationInstructions.AutoSize = true;
            this.LocationInstructions.Location = new System.Drawing.Point(3, 9);
            this.LocationInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.LocationInstructions.Name = "LocationInstructions";
            this.LocationInstructions.Size = new System.Drawing.Size(335, 91);
            this.LocationInstructions.TabIndex = 14;
            this.LocationInstructions.Text = resources.GetString("LocationInstructions.Text");
            // 
            // LocationNameLabel
            // 
            this.LocationNameLabel.AutoSize = true;
            this.LocationNameLabel.Location = new System.Drawing.Point(3, 115);
            this.LocationNameLabel.Name = "LocationNameLabel";
            this.LocationNameLabel.Size = new System.Drawing.Size(38, 13);
            this.LocationNameLabel.TabIndex = 15;
            this.LocationNameLabel.Text = "Name:";
            // 
            // LocationDescription
            // 
            this.LocationDescription.BackColor = System.Drawing.SystemColors.Window;
            this.LocationDescription.Location = new System.Drawing.Point(77, 138);
            this.LocationDescription.Multiline = true;
            this.LocationDescription.Name = "LocationDescription";
            this.LocationDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LocationDescription.Size = new System.Drawing.Size(260, 46);
            this.LocationDescription.TabIndex = 19;
            // 
            // LocationDescriptionLabel
            // 
            this.LocationDescriptionLabel.AutoSize = true;
            this.LocationDescriptionLabel.Location = new System.Drawing.Point(3, 141);
            this.LocationDescriptionLabel.Name = "LocationDescriptionLabel";
            this.LocationDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.LocationDescriptionLabel.TabIndex = 16;
            this.LocationDescriptionLabel.Text = "Description:";
            // 
            // LocationTimeZoneLabel
            // 
            this.LocationTimeZoneLabel.AutoSize = true;
            this.LocationTimeZoneLabel.Location = new System.Drawing.Point(3, 193);
            this.LocationTimeZoneLabel.Name = "LocationTimeZoneLabel";
            this.LocationTimeZoneLabel.Size = new System.Drawing.Size(64, 13);
            this.LocationTimeZoneLabel.TabIndex = 17;
            this.LocationTimeZoneLabel.Text = "Time Zone: ";
            // 
            // LocationName
            // 
            this.LocationName.BackColor = System.Drawing.SystemColors.Window;
            this.LocationName.Location = new System.Drawing.Point(77, 112);
            this.LocationName.Name = "LocationName";
            this.LocationName.Size = new System.Drawing.Size(260, 20);
            this.LocationName.TabIndex = 18;
            this.LocationName.Text = "Default";
            // 
            // Tab2
            // 
            this.Tab2.BackColor = System.Drawing.SystemColors.Window;
            this.Tab2.Controls.Add(this.SelectFileButton);
            this.Tab2.Controls.Add(this.DatabaseBackupInstructions);
            this.Tab2.Controls.Add(this.BackUpFileLabel);
            this.Tab2.Location = new System.Drawing.Point(524, 0);
            this.Tab2.Name = "Tab2";
            this.Tab2.Size = new System.Drawing.Size(354, 283);
            this.Tab2.TabIndex = 18;
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectFileButton.Location = new System.Drawing.Point(311, 47);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(26, 20);
            this.SelectFileButton.TabIndex = 15;
            this.SelectFileButton.Text = "...";
            this.SelectFileButton.UseVisualStyleBackColor = false;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // DatabaseBackupInstructions
            // 
            this.DatabaseBackupInstructions.AutoSize = true;
            this.DatabaseBackupInstructions.Location = new System.Drawing.Point(3, 9);
            this.DatabaseBackupInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.DatabaseBackupInstructions.Name = "DatabaseBackupInstructions";
            this.DatabaseBackupInstructions.Size = new System.Drawing.Size(326, 26);
            this.DatabaseBackupInstructions.TabIndex = 13;
            this.DatabaseBackupInstructions.Text = "Your database will be backed up to the following location. You may accept the pro" +
    "vided name or select your own:";
            // 
            // BackUpFileLabel
            // 
            this.BackUpFileLabel.BackColor = System.Drawing.SystemColors.Window;
            this.BackUpFileLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.BackUpFileLabel.Location = new System.Drawing.Point(6, 48);
            this.BackUpFileLabel.Name = "BackUpFileLabel";
            this.BackUpFileLabel.Size = new System.Drawing.Size(299, 20);
            this.BackUpFileLabel.TabIndex = 14;
            // 
            // Tab1
            // 
            this.Tab1.BackColor = System.Drawing.SystemColors.Window;
            this.Tab1.Controls.Add(this.IntroductionInstructions);
            this.Tab1.Location = new System.Drawing.Point(164, 0);
            this.Tab1.Name = "Tab1";
            this.Tab1.Size = new System.Drawing.Size(354, 283);
            this.Tab1.TabIndex = 17;
            // 
            // IntroductionInstructions
            // 
            this.IntroductionInstructions.AutoSize = true;
            this.IntroductionInstructions.Location = new System.Drawing.Point(3, 9);
            this.IntroductionInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.IntroductionInstructions.Name = "IntroductionInstructions";
            this.IntroductionInstructions.Size = new System.Drawing.Size(333, 143);
            this.IntroductionInstructions.TabIndex = 11;
            this.IntroductionInstructions.Text = resources.GetString("IntroductionInstructions.Text");
            // 
            // FileDialog
            // 
            this.FileDialog.CheckFileExists = false;
            this.FileDialog.DefaultExt = "tkdb";
            this.FileDialog.FileName = "openFileDialog1";
            // 
            // UpgradeDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.LaterButton;
            this.ClientSize = new System.Drawing.Size(2018, 323);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.ButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpgradeDatabase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Upgrade Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpgradeDatabase_FormClosing);
            this.Load += new System.EventHandler(this.Upgrade_Load);
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.Tab5.ResumeLayout(false);
            this.Tab5.PerformLayout();
            this.Tab4.ResumeLayout(false);
            this.Tab4.PerformLayout();
            this.MemoOption.ResumeLayout(false);
            this.MemoOption.PerformLayout();
            this.Tab3.ResumeLayout(false);
            this.Tab3.PerformLayout();
            this.Tab2.ResumeLayout(false);
            this.Tab2.PerformLayout();
            this.Tab1.ResumeLayout(false);
            this.Tab1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button LaterButton;
        private System.Windows.Forms.Button OkayButton;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.PictureBox WizardPicture;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
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
        private System.Windows.Forms.RadioButton MergeMemoNoPost;
        private System.Windows.Forms.RadioButton MergeMemoNoPre;
        private System.Windows.Forms.RadioButton MergeMemoNoSep;
        private System.Windows.Forms.RadioButton MergeMemoStandard;
        private System.Windows.Forms.Label MemoMergeInstructions;
        public System.Windows.Forms.ProgressBar UpgradeProgress;
        public System.Windows.Forms.Label StepLabel;
        private System.Windows.Forms.Label FinalizeInstructions;
        private System.Windows.Forms.Label MemoMergeInstructions2;
        private System.Windows.Forms.TextBox UpgradeReview;
        private System.Windows.Forms.GroupBox MemoOption;
        private System.Windows.Forms.Panel Tab1;
        private System.Windows.Forms.Panel Tab5;
        private System.Windows.Forms.Panel Tab4;
        private System.Windows.Forms.Panel Tab3;
        private System.Windows.Forms.Panel Tab2;
    }
}