namespace Timekeeper.Forms.Wizards
{
    partial class NewDatabase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDatabase));
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.FinishButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.LaterButton = new System.Windows.Forms.Button();
            this.WizardPicture = new System.Windows.Forms.PictureBox();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.Tab6 = new System.Windows.Forms.Panel();
            this.WizardReview = new System.Windows.Forms.TextBox();
            this.WizardReviewInstructions = new System.Windows.Forms.Label();
            this.Tab5 = new System.Windows.Forms.Panel();
            this.LocationTimeZone = new System.Windows.Forms.ComboBox();
            this.LocationInstructions = new System.Windows.Forms.Label();
            this.LocationTimeZoneLabel = new System.Windows.Forms.Label();
            this.LocationDescriptionLabel = new System.Windows.Forms.Label();
            this.LocationDescription = new System.Windows.Forms.TextBox();
            this.LocationName = new System.Windows.Forms.TextBox();
            this.LocationNameLabel = new System.Windows.Forms.Label();
            this.Tab4 = new System.Windows.Forms.Panel();
            this.ItemPreset = new System.Windows.Forms.ComboBox();
            this.ItemPresetInstructions = new System.Windows.Forms.Label();
            this.Tab3 = new System.Windows.Forms.Panel();
            this.UseActivities = new System.Windows.Forms.CheckBox();
            this.DimensionInstructions = new System.Windows.Forms.Label();
            this.UseProjects = new System.Windows.Forms.CheckBox();
            this.Tab2 = new System.Windows.Forms.Panel();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.NewDatabaseInstructions = new System.Windows.Forms.Label();
            this.NewDatabaseFileName = new System.Windows.Forms.TextBox();
            this.Tab1 = new System.Windows.Forms.Panel();
            this.IntroductionInstructions = new System.Windows.Forms.Label();
            this.NewFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).BeginInit();
            this.TopPanel.SuspendLayout();
            this.Tab6.SuspendLayout();
            this.Tab5.SuspendLayout();
            this.Tab4.SuspendLayout();
            this.Tab3.SuspendLayout();
            this.Tab2.SuspendLayout();
            this.Tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.FinishButton);
            this.ButtonPanel.Controls.Add(this.BackButton);
            this.ButtonPanel.Controls.Add(this.NextButton);
            this.ButtonPanel.Controls.Add(this.LaterButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 282);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(2394, 41);
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
            this.WizardPicture.Size = new System.Drawing.Size(163, 282);
            this.WizardPicture.TabIndex = 13;
            this.WizardPicture.TabStop = false;
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.Tab6);
            this.TopPanel.Controls.Add(this.Tab5);
            this.TopPanel.Controls.Add(this.Tab4);
            this.TopPanel.Controls.Add(this.Tab3);
            this.TopPanel.Controls.Add(this.Tab2);
            this.TopPanel.Controls.Add(this.Tab1);
            this.TopPanel.Controls.Add(this.WizardPicture);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(2394, 282);
            this.TopPanel.TabIndex = 17;
            // 
            // Tab6
            // 
            this.Tab6.BackColor = System.Drawing.SystemColors.Window;
            this.Tab6.Controls.Add(this.WizardReview);
            this.Tab6.Controls.Add(this.WizardReviewInstructions);
            this.Tab6.Location = new System.Drawing.Point(1964, 0);
            this.Tab6.Name = "Tab6";
            this.Tab6.Size = new System.Drawing.Size(354, 283);
            this.Tab6.TabIndex = 20;
            // 
            // WizardReview
            // 
            this.WizardReview.Location = new System.Drawing.Point(6, 60);
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
            this.WizardReviewInstructions.Location = new System.Drawing.Point(3, 9);
            this.WizardReviewInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.WizardReviewInstructions.Name = "WizardReviewInstructions";
            this.WizardReviewInstructions.Size = new System.Drawing.Size(331, 39);
            this.WizardReviewInstructions.TabIndex = 24;
            this.WizardReviewInstructions.Text = "Please review your upgrade options and click Finish to upgrade your database. Not" +
    "e, depending on the size of your database, this operation could take several min" +
    "utes.";
            // 
            // Tab5
            // 
            this.Tab5.BackColor = System.Drawing.SystemColors.Window;
            this.Tab5.Controls.Add(this.LocationTimeZone);
            this.Tab5.Controls.Add(this.LocationInstructions);
            this.Tab5.Controls.Add(this.LocationTimeZoneLabel);
            this.Tab5.Controls.Add(this.LocationDescriptionLabel);
            this.Tab5.Controls.Add(this.LocationDescription);
            this.Tab5.Controls.Add(this.LocationName);
            this.Tab5.Controls.Add(this.LocationNameLabel);
            this.Tab5.Location = new System.Drawing.Point(1604, 0);
            this.Tab5.Name = "Tab5";
            this.Tab5.Size = new System.Drawing.Size(354, 283);
            this.Tab5.TabIndex = 19;
            // 
            // LocationTimeZone
            // 
            this.LocationTimeZone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LocationTimeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LocationTimeZone.FormattingEnabled = true;
            this.LocationTimeZone.Location = new System.Drawing.Point(77, 190);
            this.LocationTimeZone.Name = "LocationTimeZone";
            this.LocationTimeZone.Size = new System.Drawing.Size(260, 21);
            this.LocationTimeZone.TabIndex = 28;
            // 
            // LocationInstructions
            // 
            this.LocationInstructions.AutoSize = true;
            this.LocationInstructions.Location = new System.Drawing.Point(3, 9);
            this.LocationInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.LocationInstructions.Name = "LocationInstructions";
            this.LocationInstructions.Size = new System.Drawing.Size(330, 91);
            this.LocationInstructions.TabIndex = 22;
            this.LocationInstructions.Text = resources.GetString("LocationInstructions.Text");
            // 
            // LocationTimeZoneLabel
            // 
            this.LocationTimeZoneLabel.AutoSize = true;
            this.LocationTimeZoneLabel.Location = new System.Drawing.Point(3, 193);
            this.LocationTimeZoneLabel.Name = "LocationTimeZoneLabel";
            this.LocationTimeZoneLabel.Size = new System.Drawing.Size(64, 13);
            this.LocationTimeZoneLabel.TabIndex = 25;
            this.LocationTimeZoneLabel.Text = "Time Zone: ";
            // 
            // LocationDescriptionLabel
            // 
            this.LocationDescriptionLabel.AutoSize = true;
            this.LocationDescriptionLabel.Location = new System.Drawing.Point(3, 141);
            this.LocationDescriptionLabel.Name = "LocationDescriptionLabel";
            this.LocationDescriptionLabel.Size = new System.Drawing.Size(63, 13);
            this.LocationDescriptionLabel.TabIndex = 24;
            this.LocationDescriptionLabel.Text = "Description:";
            // 
            // LocationDescription
            // 
            this.LocationDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.LocationDescription.Location = new System.Drawing.Point(77, 138);
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
            this.LocationName.Location = new System.Drawing.Point(77, 112);
            this.LocationName.Name = "LocationName";
            this.LocationName.Size = new System.Drawing.Size(260, 20);
            this.LocationName.TabIndex = 26;
            this.LocationName.Text = "Default Location";
            // 
            // LocationNameLabel
            // 
            this.LocationNameLabel.AutoSize = true;
            this.LocationNameLabel.Location = new System.Drawing.Point(3, 115);
            this.LocationNameLabel.Name = "LocationNameLabel";
            this.LocationNameLabel.Size = new System.Drawing.Size(38, 13);
            this.LocationNameLabel.TabIndex = 23;
            this.LocationNameLabel.Text = "Name:";
            // 
            // Tab4
            // 
            this.Tab4.BackColor = System.Drawing.SystemColors.Window;
            this.Tab4.Controls.Add(this.ItemPreset);
            this.Tab4.Controls.Add(this.ItemPresetInstructions);
            this.Tab4.Location = new System.Drawing.Point(1244, 0);
            this.Tab4.Name = "Tab4";
            this.Tab4.Size = new System.Drawing.Size(354, 283);
            this.Tab4.TabIndex = 18;
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
            this.ItemPreset.Location = new System.Drawing.Point(6, 92);
            this.ItemPreset.Name = "ItemPreset";
            this.ItemPreset.Size = new System.Drawing.Size(328, 21);
            this.ItemPreset.TabIndex = 19;
            // 
            // ItemPresetInstructions
            // 
            this.ItemPresetInstructions.AutoSize = true;
            this.ItemPresetInstructions.Location = new System.Drawing.Point(3, 9);
            this.ItemPresetInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.ItemPresetInstructions.Name = "ItemPresetInstructions";
            this.ItemPresetInstructions.Size = new System.Drawing.Size(331, 65);
            this.ItemPresetInstructions.TabIndex = 18;
            this.ItemPresetInstructions.Text = resources.GetString("ItemPresetInstructions.Text");
            // 
            // Tab3
            // 
            this.Tab3.BackColor = System.Drawing.SystemColors.Window;
            this.Tab3.Controls.Add(this.UseActivities);
            this.Tab3.Controls.Add(this.DimensionInstructions);
            this.Tab3.Controls.Add(this.UseProjects);
            this.Tab3.Location = new System.Drawing.Point(884, 0);
            this.Tab3.Name = "Tab3";
            this.Tab3.Size = new System.Drawing.Size(354, 283);
            this.Tab3.TabIndex = 17;
            // 
            // UseActivities
            // 
            this.UseActivities.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.UseActivities.Checked = true;
            this.UseActivities.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseActivities.Location = new System.Drawing.Point(16, 136);
            this.UseActivities.Name = "UseActivities";
            this.UseActivities.Size = new System.Drawing.Size(319, 44);
            this.UseActivities.TabIndex = 19;
            this.UseActivities.Text = "Activities. An activity is a verb and most closely represents an action to be tra" +
    "cked. Some Activity examples: Developing, Writing, Recording.";
            this.UseActivities.UseVisualStyleBackColor = true;
            // 
            // DimensionInstructions
            // 
            this.DimensionInstructions.AutoSize = true;
            this.DimensionInstructions.Location = new System.Drawing.Point(3, 9);
            this.DimensionInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.DimensionInstructions.Name = "DimensionInstructions";
            this.DimensionInstructions.Size = new System.Drawing.Size(332, 39);
            this.DimensionInstructions.TabIndex = 17;
            this.DimensionInstructions.Text = "Timekeeper supports time tracking in one or two dimensions. Check which ones you\'" +
    "d like to use in your new database. You can change your mind later at any time:";
            // 
            // UseProjects
            // 
            this.UseProjects.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.UseProjects.Checked = true;
            this.UseProjects.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseProjects.Location = new System.Drawing.Point(16, 64);
            this.UseProjects.Name = "UseProjects";
            this.UseProjects.Size = new System.Drawing.Size(319, 57);
            this.UseProjects.TabIndex = 18;
            this.UseProjects.Text = "Projects. A project is a noun and most closely represents a deliverable and/or cu" +
    "stomer. Some Project examples: Software Update 2.0, My Great American Novel, My " +
    "New CD Release.";
            this.UseProjects.UseVisualStyleBackColor = true;
            // 
            // Tab2
            // 
            this.Tab2.BackColor = System.Drawing.SystemColors.Window;
            this.Tab2.Controls.Add(this.SelectFileButton);
            this.Tab2.Controls.Add(this.NewDatabaseInstructions);
            this.Tab2.Controls.Add(this.NewDatabaseFileName);
            this.Tab2.Location = new System.Drawing.Point(524, 0);
            this.Tab2.Name = "Tab2";
            this.Tab2.Size = new System.Drawing.Size(354, 283);
            this.Tab2.TabIndex = 16;
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.SelectFileButton.Location = new System.Drawing.Point(311, 47);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(26, 20);
            this.SelectFileButton.TabIndex = 18;
            this.SelectFileButton.Text = "...";
            this.SelectFileButton.UseVisualStyleBackColor = false;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // NewDatabaseInstructions
            // 
            this.NewDatabaseInstructions.AutoSize = true;
            this.NewDatabaseInstructions.Location = new System.Drawing.Point(3, 9);
            this.NewDatabaseInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.NewDatabaseInstructions.Name = "NewDatabaseInstructions";
            this.NewDatabaseInstructions.Size = new System.Drawing.Size(309, 26);
            this.NewDatabaseInstructions.TabIndex = 16;
            this.NewDatabaseInstructions.Text = "Choose a name for your new Timekeeper database, or click the Browse button to nav" +
    "igate to a location.";
            // 
            // NewDatabaseFileName
            // 
            this.NewDatabaseFileName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.NewDatabaseFileName.ForeColor = System.Drawing.SystemColors.WindowText;
            this.NewDatabaseFileName.Location = new System.Drawing.Point(6, 48);
            this.NewDatabaseFileName.Name = "NewDatabaseFileName";
            this.NewDatabaseFileName.Size = new System.Drawing.Size(299, 20);
            this.NewDatabaseFileName.TabIndex = 17;
            // 
            // Tab1
            // 
            this.Tab1.BackColor = System.Drawing.SystemColors.Window;
            this.Tab1.Controls.Add(this.IntroductionInstructions);
            this.Tab1.Location = new System.Drawing.Point(164, 0);
            this.Tab1.Name = "Tab1";
            this.Tab1.Size = new System.Drawing.Size(354, 283);
            this.Tab1.TabIndex = 15;
            // 
            // IntroductionInstructions
            // 
            this.IntroductionInstructions.AutoSize = true;
            this.IntroductionInstructions.Location = new System.Drawing.Point(3, 9);
            this.IntroductionInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.IntroductionInstructions.Name = "IntroductionInstructions";
            this.IntroductionInstructions.Size = new System.Drawing.Size(332, 195);
            this.IntroductionInstructions.TabIndex = 12;
            this.IntroductionInstructions.Text = resources.GetString("IntroductionInstructions.Text");
            // 
            // NewFileDialog
            // 
            this.NewFileDialog.CheckFileExists = false;
            this.NewFileDialog.DefaultExt = "tkdb";
            // 
            // NewDatabase
            // 
            this.AcceptButton = this.FinishButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.LaterButton;
            this.ClientSize = new System.Drawing.Size(2394, 323);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.ButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewDatabase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Database";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewWizard_FormClosing);
            this.Load += new System.EventHandler(this.NewWizard_Load);
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).EndInit();
            this.TopPanel.ResumeLayout(false);
            this.Tab6.ResumeLayout(false);
            this.Tab6.PerformLayout();
            this.Tab5.ResumeLayout(false);
            this.Tab5.PerformLayout();
            this.Tab4.ResumeLayout(false);
            this.Tab4.PerformLayout();
            this.Tab3.ResumeLayout(false);
            this.Tab3.PerformLayout();
            this.Tab2.ResumeLayout(false);
            this.Tab2.PerformLayout();
            this.Tab1.ResumeLayout(false);
            this.Tab1.PerformLayout();
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
        //private Forms.Controls.TablessControl tablessControl1;
        private System.Windows.Forms.Label IntroductionInstructions;
        private System.Windows.Forms.Button SelectFileButton;
        internal System.Windows.Forms.TextBox NewDatabaseFileName;
        private System.Windows.Forms.Label NewDatabaseInstructions;
        private System.Windows.Forms.CheckBox UseActivities;
        private System.Windows.Forms.CheckBox UseProjects;
        private System.Windows.Forms.Label DimensionInstructions;
        private System.Windows.Forms.ComboBox ItemPreset;
        private System.Windows.Forms.Label ItemPresetInstructions;
        private System.Windows.Forms.TextBox WizardReview;
        private System.Windows.Forms.Label WizardReviewInstructions;
        private System.Windows.Forms.ComboBox LocationTimeZone;
        private System.Windows.Forms.TextBox LocationDescription;
        private System.Windows.Forms.TextBox LocationName;
        private System.Windows.Forms.Label LocationTimeZoneLabel;
        private System.Windows.Forms.Label LocationDescriptionLabel;
        private System.Windows.Forms.Label LocationNameLabel;
        private System.Windows.Forms.Label LocationInstructions;
        private System.Windows.Forms.Panel Tab1;
        private System.Windows.Forms.Panel Tab6;
        private System.Windows.Forms.Panel Tab5;
        private System.Windows.Forms.Panel Tab4;
        private System.Windows.Forms.Panel Tab3;
        private System.Windows.Forms.Panel Tab2;
    }
}