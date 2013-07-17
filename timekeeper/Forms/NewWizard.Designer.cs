namespace Timekeeper.Forms
{
    partial class NewWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewWizard));
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.FinishButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.LaterButton = new System.Windows.Forms.Button();
            this.WizardPicture = new System.Windows.Forms.PictureBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.tablessControl1 = new Forms.Controls.TablessControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.IntroductionInstructions = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.NewDatabaseFileName = new System.Windows.Forms.TextBox();
            this.NewDatabaseInstructions = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.UseActivities = new System.Windows.Forms.CheckBox();
            this.UseProjects = new System.Windows.Forms.CheckBox();
            this.DimensionInstructions = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.ItemPreset = new System.Windows.Forms.ComboBox();
            this.ItemPresetInstructions = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.LocationTimeZone = new System.Windows.Forms.ComboBox();
            this.LocationDescription = new System.Windows.Forms.TextBox();
            this.LocationName = new System.Windows.Forms.TextBox();
            this.LocationTimeZoneLabel = new System.Windows.Forms.Label();
            this.LocationDescriptionLabel = new System.Windows.Forms.Label();
            this.LocationNameLabel = new System.Windows.Forms.Label();
            this.LocationInstructions = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.WizardReview = new System.Windows.Forms.TextBox();
            this.WizardReviewInstructions = new System.Windows.Forms.Label();
            this.NewFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.tablessControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.FinishButton);
            this.ButtonPanel.Controls.Add(this.BackButton);
            this.ButtonPanel.Controls.Add(this.NextButton);
            this.ButtonPanel.Controls.Add(this.LaterButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 273);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(518, 41);
            this.ButtonPanel.TabIndex = 16;
            // 
            // FinishButton
            // 
            this.FinishButton.Location = new System.Drawing.Point(12, 9);
            this.FinishButton.Name = "FinishButton";
            this.FinishButton.Size = new System.Drawing.Size(43, 23);
            this.FinishButton.TabIndex = 2;
            this.FinishButton.Text = "Fi&nish";
            this.FinishButton.UseVisualStyleBackColor = true;
            this.FinishButton.Visible = false;
            this.FinishButton.Click += new System.EventHandler(this.FinishButton_Click);
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
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
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
            this.TopPanel.TabIndex = 17;
            // 
            // tablessControl1
            // 
            this.tablessControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tablessControl1.Controls.Add(this.tabPage1);
            this.tablessControl1.Controls.Add(this.tabPage2);
            this.tablessControl1.Controls.Add(this.tabPage3);
            this.tablessControl1.Controls.Add(this.tabPage4);
            this.tablessControl1.Controls.Add(this.tabPage5);
            this.tablessControl1.Controls.Add(this.tabPage6);
            this.tablessControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablessControl1.Location = new System.Drawing.Point(163, 0);
            this.tablessControl1.Name = "tablessControl1";
            this.tablessControl1.SelectedIndex = 0;
            this.tablessControl1.Size = new System.Drawing.Size(355, 273);
            this.tablessControl1.TabIndex = 14;
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
            this.IntroductionInstructions.Size = new System.Drawing.Size(332, 195);
            this.IntroductionInstructions.TabIndex = 12;
            this.IntroductionInstructions.Text = resources.GetString("IntroductionInstructions.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage2.Controls.Add(this.SelectFileButton);
            this.tabPage2.Controls.Add(this.NewDatabaseFileName);
            this.tabPage2.Controls.Add(this.NewDatabaseInstructions);
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
            this.SelectFileButton.TabIndex = 18;
            this.SelectFileButton.Text = "...";
            this.SelectFileButton.UseVisualStyleBackColor = false;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // NewDatabaseFileName
            // 
            this.NewDatabaseFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NewDatabaseFileName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NewDatabaseFileName.Location = new System.Drawing.Point(8, 55);
            this.NewDatabaseFileName.Name = "NewDatabaseFileName";
            this.NewDatabaseFileName.Size = new System.Drawing.Size(299, 20);
            this.NewDatabaseFileName.TabIndex = 17;
            // 
            // NewDatabaseInstructions
            // 
            this.NewDatabaseInstructions.AutoSize = true;
            this.NewDatabaseInstructions.Location = new System.Drawing.Point(5, 16);
            this.NewDatabaseInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.NewDatabaseInstructions.Name = "NewDatabaseInstructions";
            this.NewDatabaseInstructions.Size = new System.Drawing.Size(309, 26);
            this.NewDatabaseInstructions.TabIndex = 16;
            this.NewDatabaseInstructions.Text = "Choose a name for your new Timekeeper database, or click the Browse button to nav" +
    "igate to a location.";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage3.Controls.Add(this.UseActivities);
            this.tabPage3.Controls.Add(this.UseProjects);
            this.tabPage3.Controls.Add(this.DimensionInstructions);
            this.tabPage3.Location = new System.Drawing.Point(4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(347, 247);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tabPage3";
            // 
            // UseActivities
            // 
            this.UseActivities.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.UseActivities.Checked = true;
            this.UseActivities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseActivities.Location = new System.Drawing.Point(18, 143);
            this.UseActivities.Name = "UseActivities";
            this.UseActivities.Size = new System.Drawing.Size(319, 44);
            this.UseActivities.TabIndex = 19;
            this.UseActivities.Text = "Activities. An activity is a verb and most closely represents an action to be tra" +
    "cked. Some Activity examples: Developing, Writing, Recording.";
            this.UseActivities.UseVisualStyleBackColor = true;
            // 
            // UseProjects
            // 
            this.UseProjects.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.UseProjects.Checked = true;
            this.UseProjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseProjects.Location = new System.Drawing.Point(18, 71);
            this.UseProjects.Name = "UseProjects";
            this.UseProjects.Size = new System.Drawing.Size(319, 57);
            this.UseProjects.TabIndex = 18;
            this.UseProjects.Text = "Projects. A project is a noun and most closely represents a deliverable and/or cu" +
    "stomer. Some Project examples: Software Update 2.0, My Great American Novel, My " +
    "New CD Release.";
            this.UseProjects.UseVisualStyleBackColor = true;
            // 
            // DimensionInstructions
            // 
            this.DimensionInstructions.AutoSize = true;
            this.DimensionInstructions.Location = new System.Drawing.Point(5, 16);
            this.DimensionInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.DimensionInstructions.Name = "DimensionInstructions";
            this.DimensionInstructions.Size = new System.Drawing.Size(332, 39);
            this.DimensionInstructions.TabIndex = 17;
            this.DimensionInstructions.Text = "Timekeeper supports time tracking in one or two dimensions. Check which ones you\'" +
    "d like to use in your new database. You can change your mind later at any time:";
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage4.Controls.Add(this.ItemPreset);
            this.tabPage4.Controls.Add(this.ItemPresetInstructions);
            this.tabPage4.Location = new System.Drawing.Point(4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(347, 247);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tabPage4";
            // 
            // ItemPreset
            // 
            this.ItemPreset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ItemPreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ItemPreset.FormattingEnabled = true;
            this.ItemPreset.Items.AddRange(new object[] {
            "No thanks, I\'ll create my own",
            "Generic",
            "Manager or Team Lead",
            "Musician",
            "Quality Assurance Tester",
            "Software Developer",
            "Teacher",
            "Tradesman",
            "Transponster",
            "Writer"});
            this.ItemPreset.Location = new System.Drawing.Point(8, 99);
            this.ItemPreset.Name = "ItemPreset";
            this.ItemPreset.Size = new System.Drawing.Size(328, 21);
            this.ItemPreset.TabIndex = 19;
            // 
            // ItemPresetInstructions
            // 
            this.ItemPresetInstructions.AutoSize = true;
            this.ItemPresetInstructions.Location = new System.Drawing.Point(5, 16);
            this.ItemPresetInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.ItemPresetInstructions.Name = "ItemPresetInstructions";
            this.ItemPresetInstructions.Size = new System.Drawing.Size(331, 65);
            this.ItemPresetInstructions.TabIndex = 18;
            this.ItemPresetInstructions.Text = resources.GetString("ItemPresetInstructions.Text");
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage5.Controls.Add(this.LocationTimeZone);
            this.tabPage5.Controls.Add(this.LocationDescription);
            this.tabPage5.Controls.Add(this.LocationName);
            this.tabPage5.Controls.Add(this.LocationTimeZoneLabel);
            this.tabPage5.Controls.Add(this.LocationDescriptionLabel);
            this.tabPage5.Controls.Add(this.LocationNameLabel);
            this.tabPage5.Controls.Add(this.LocationInstructions);
            this.tabPage5.Location = new System.Drawing.Point(4, 4);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(347, 247);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "tabPage5";
            // 
            // LocationTimeZone
            // 
            this.LocationTimeZone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LocationTimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationTimeZone.FormattingEnabled = true;
            this.LocationTimeZone.Location = new System.Drawing.Point(79, 197);
            this.LocationTimeZone.Name = "LocationTimeZone";
            this.LocationTimeZone.Size = new System.Drawing.Size(260, 21);
            this.LocationTimeZone.TabIndex = 28;
            // 
            // LocationDescription
            // 
            this.LocationDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LocationDescription.Location = new System.Drawing.Point(79, 145);
            this.LocationDescription.Multiline = true;
            this.LocationDescription.Name = "LocationDescription";
            this.LocationDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.LocationDescription.Size = new System.Drawing.Size(260, 46);
            this.LocationDescription.TabIndex = 27;
            this.LocationDescription.Text = "My default location.";
            // 
            // LocationName
            // 
            this.LocationName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LocationName.Location = new System.Drawing.Point(79, 119);
            this.LocationName.Name = "LocationName";
            this.LocationName.Size = new System.Drawing.Size(260, 20);
            this.LocationName.TabIndex = 26;
            this.LocationName.Text = "Default";
            // 
            // LocationTimeZoneLabel
            // 
            this.LocationTimeZoneLabel.AutoSize = true;
            this.LocationTimeZoneLabel.Location = new System.Drawing.Point(5, 200);
            this.LocationTimeZoneLabel.Name = "LocationTimeZoneLabel";
            this.LocationTimeZoneLabel.Size = new System.Drawing.Size(64, 13);
            this.LocationTimeZoneLabel.TabIndex = 25;
            this.LocationTimeZoneLabel.Text = "Time Zone: ";
            // 
            // LocationDescriptionLabel
            // 
            this.LocationDescriptionLabel.AutoSize = true;
            this.LocationDescriptionLabel.Location = new System.Drawing.Point(5, 148);
            this.LocationDescriptionLabel.Name = "LocationDescriptionLabel";
            this.LocationDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.LocationDescriptionLabel.TabIndex = 24;
            this.LocationDescriptionLabel.Text = "Description:";
            // 
            // LocationNameLabel
            // 
            this.LocationNameLabel.AutoSize = true;
            this.LocationNameLabel.Location = new System.Drawing.Point(5, 122);
            this.LocationNameLabel.Name = "LocationNameLabel";
            this.LocationNameLabel.Size = new System.Drawing.Size(38, 13);
            this.LocationNameLabel.TabIndex = 23;
            this.LocationNameLabel.Text = "Name:";
            // 
            // LocationInstructions
            // 
            this.LocationInstructions.AutoSize = true;
            this.LocationInstructions.Location = new System.Drawing.Point(5, 16);
            this.LocationInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.LocationInstructions.Name = "LocationInstructions";
            this.LocationInstructions.Size = new System.Drawing.Size(330, 91);
            this.LocationInstructions.TabIndex = 22;
            this.LocationInstructions.Text = resources.GetString("LocationInstructions.Text");
            // 
            // tabPage6
            // 
            this.tabPage6.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage6.Controls.Add(this.WizardReview);
            this.tabPage6.Controls.Add(this.WizardReviewInstructions);
            this.tabPage6.Location = new System.Drawing.Point(4, 4);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(347, 247);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "tabPage6";
            // 
            // WizardReview
            // 
            this.WizardReview.Location = new System.Drawing.Point(8, 67);
            this.WizardReview.Multiline = true;
            this.WizardReview.Name = "WizardReview";
            this.WizardReview.ReadOnly = true;
            this.WizardReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WizardReview.Size = new System.Drawing.Size(328, 196);
            this.WizardReview.TabIndex = 25;
            // 
            // WizardReviewInstructions
            // 
            this.WizardReviewInstructions.AutoSize = true;
            this.WizardReviewInstructions.Location = new System.Drawing.Point(5, 16);
            this.WizardReviewInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.WizardReviewInstructions.Name = "WizardReviewInstructions";
            this.WizardReviewInstructions.Size = new System.Drawing.Size(331, 39);
            this.WizardReviewInstructions.TabIndex = 24;
            this.WizardReviewInstructions.Text = "Please review your upgrade options and click Finish to upgrade your database. Not" +
    "e, depending on the size of your database, this operation could take several min" +
    "utes.";
            // 
            // NewFileDialog
            // 
            this.NewFileDialog.CheckFileExists = false;
            this.NewFileDialog.DefaultExt = "tkdb";
            // 
            // NewWizard
            // 
            this.AcceptButton = this.FinishButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.LaterButton;
            this.ClientSize = new System.Drawing.Size(518, 314);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.ButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewWizard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewWizard_FormClosing);
            this.Load += new System.EventHandler(this.NewWizard_Load);
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
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button FinishButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button LaterButton;
        private System.Windows.Forms.PictureBox WizardPicture;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.OpenFileDialog NewFileDialog;
        private Controls.TablessControl tablessControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label IntroductionInstructions;
        private System.Windows.Forms.Button SelectFileButton;
        internal System.Windows.Forms.TextBox NewDatabaseFileName;
        private System.Windows.Forms.Label NewDatabaseInstructions;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox UseActivities;
        private System.Windows.Forms.CheckBox UseProjects;
        private System.Windows.Forms.Label DimensionInstructions;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox ItemPreset;
        private System.Windows.Forms.Label ItemPresetInstructions;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.TextBox WizardReview;
        private System.Windows.Forms.Label WizardReviewInstructions;
        private System.Windows.Forms.ComboBox LocationTimeZone;
        private System.Windows.Forms.TextBox LocationDescription;
        private System.Windows.Forms.TextBox LocationName;
        private System.Windows.Forms.Label LocationTimeZoneLabel;
        private System.Windows.Forms.Label LocationDescriptionLabel;
        private System.Windows.Forms.Label LocationNameLabel;
        private System.Windows.Forms.Label LocationInstructions;
    }
}