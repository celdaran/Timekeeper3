namespace Timekeeper.Forms
{
    partial class ImportWizard
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
            this.ImportFileName = new System.Windows.Forms.TextBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.Console = new System.Windows.Forms.RichTextBox();
            this.ImportProgress = new System.Windows.Forms.ProgressBar();
            this.ImportProjects = new System.Windows.Forms.CheckBox();
            this.ImportEntries = new System.Windows.Forms.CheckBox();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.CancelDialogButton = new System.Windows.Forms.Button();
            this.NextButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.WizardPicture = new System.Windows.Forms.PictureBox();
            this.Tab1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.Introduction = new System.Windows.Forms.Label();
            this.Tab2 = new System.Windows.Forms.Panel();
            this.OpenFileInstructions = new System.Windows.Forms.Label();
            this.OpenFileButton = new System.Windows.Forms.Button();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Tab3 = new System.Windows.Forms.Panel();
            this.ImportTK1Instructions = new System.Windows.Forms.Label();
            this.Tab5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Tab4 = new System.Windows.Forms.Panel();
            this.WizardReview = new System.Windows.Forms.TextBox();
            this.WizardReviewInstructions = new System.Windows.Forms.Label();
            this.ButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).BeginInit();
            this.Tab1.SuspendLayout();
            this.Tab2.SuspendLayout();
            this.Tab3.SuspendLayout();
            this.Tab5.SuspendLayout();
            this.Tab4.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImportFileName
            // 
            this.ImportFileName.Location = new System.Drawing.Point(18, 45);
            this.ImportFileName.Name = "ImportFileName";
            this.ImportFileName.Size = new System.Drawing.Size(282, 20);
            this.ImportFileName.TabIndex = 1;
            this.ImportFileName.Text = "C:\\Users\\hillsc\\Projects\\timekeeper\\testing\\3.0\\timekeeper";
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(12, 9);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(75, 23);
            this.ImportButton.TabIndex = 2;
            this.ImportButton.Text = "Import Now";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Visible = false;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.SystemColors.WindowText;
            this.Console.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Console.ForeColor = System.Drawing.Color.Lime;
            this.Console.Location = new System.Drawing.Point(18, 71);
            this.Console.Name = "Console";
            this.Console.Size = new System.Drawing.Size(315, 118);
            this.Console.TabIndex = 3;
            this.Console.Text = "";
            // 
            // ImportProgress
            // 
            this.ImportProgress.Location = new System.Drawing.Point(18, 42);
            this.ImportProgress.Name = "ImportProgress";
            this.ImportProgress.Size = new System.Drawing.Size(315, 23);
            this.ImportProgress.TabIndex = 4;
            // 
            // ImportProjects
            // 
            this.ImportProjects.AutoSize = true;
            this.ImportProjects.Location = new System.Drawing.Point(30, 43);
            this.ImportProjects.Name = "ImportProjects";
            this.ImportProjects.Size = new System.Drawing.Size(96, 17);
            this.ImportProjects.TabIndex = 5;
            this.ImportProjects.Text = "Import Projects";
            this.ImportProjects.UseVisualStyleBackColor = true;
            // 
            // ImportEntries
            // 
            this.ImportEntries.AutoSize = true;
            this.ImportEntries.Location = new System.Drawing.Point(30, 66);
            this.ImportEntries.Name = "ImportEntries";
            this.ImportEntries.Size = new System.Drawing.Size(90, 17);
            this.ImportEntries.TabIndex = 6;
            this.ImportEntries.Text = "Import Entries";
            this.ImportEntries.UseVisualStyleBackColor = true;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.CloseButton);
            this.ButtonPanel.Controls.Add(this.ImportButton);
            this.ButtonPanel.Controls.Add(this.CancelDialogButton);
            this.ButtonPanel.Controls.Add(this.NextButton);
            this.ButtonPanel.Controls.Add(this.BackButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 283);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(2001, 40);
            this.ButtonPanel.TabIndex = 7;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(93, 9);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 4;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CancelDialogButton
            // 
            this.CancelDialogButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelDialogButton.Location = new System.Drawing.Point(433, 9);
            this.CancelDialogButton.Name = "CancelDialogButton";
            this.CancelDialogButton.Size = new System.Drawing.Size(75, 23);
            this.CancelDialogButton.TabIndex = 2;
            this.CancelDialogButton.Text = "Cancel";
            this.CancelDialogButton.UseVisualStyleBackColor = true;
            // 
            // NextButton
            // 
            this.NextButton.Location = new System.Drawing.Point(340, 9);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 1;
            this.NextButton.Text = "Next >";
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(259, 9);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(75, 23);
            this.BackButton.TabIndex = 0;
            this.BackButton.Text = "< Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // WizardPicture
            // 
            this.WizardPicture.Dock = System.Windows.Forms.DockStyle.Left;
            this.WizardPicture.Image = global::Timekeeper.Properties.Resources.PictureSetup;
            this.WizardPicture.Location = new System.Drawing.Point(0, 0);
            this.WizardPicture.Name = "WizardPicture";
            this.WizardPicture.Size = new System.Drawing.Size(163, 283);
            this.WizardPicture.TabIndex = 15;
            this.WizardPicture.TabStop = false;
            // 
            // Tab1
            // 
            this.Tab1.BackColor = System.Drawing.SystemColors.Window;
            this.Tab1.Controls.Add(this.comboBox1);
            this.Tab1.Controls.Add(this.Introduction);
            this.Tab1.Location = new System.Drawing.Point(164, 0);
            this.Tab1.Name = "Tab1";
            this.Tab1.Size = new System.Drawing.Size(354, 283);
            this.Tab1.TabIndex = 16;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Timekeeper 1.x / Watchman 0.x",
            "Comma Separated Values",
            "XML File"});
            this.comboBox1.Location = new System.Drawing.Point(18, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(321, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // Introduction
            // 
            this.Introduction.AutoSize = true;
            this.Introduction.Location = new System.Drawing.Point(15, 13);
            this.Introduction.Name = "Introduction";
            this.Introduction.Size = new System.Drawing.Size(324, 52);
            this.Introduction.TabIndex = 0;
            this.Introduction.Text = "The Timekeeper Import Wizard allows you to introduce external\r\ndata of various so" +
    "rts into the currently-opened Timekeeper data file.\r\n\r\nSelect the type of data t" +
    "o import and click Next.";
            // 
            // Tab2
            // 
            this.Tab2.BackColor = System.Drawing.SystemColors.Window;
            this.Tab2.Controls.Add(this.OpenFileButton);
            this.Tab2.Controls.Add(this.OpenFileInstructions);
            this.Tab2.Controls.Add(this.ImportFileName);
            this.Tab2.Location = new System.Drawing.Point(524, 0);
            this.Tab2.Name = "Tab2";
            this.Tab2.Size = new System.Drawing.Size(354, 283);
            this.Tab2.TabIndex = 17;
            // 
            // OpenFileInstructions
            // 
            this.OpenFileInstructions.AutoSize = true;
            this.OpenFileInstructions.Location = new System.Drawing.Point(15, 13);
            this.OpenFileInstructions.Name = "OpenFileInstructions";
            this.OpenFileInstructions.Size = new System.Drawing.Size(260, 13);
            this.OpenFileInstructions.TabIndex = 2;
            this.OpenFileInstructions.Text = "Specify the file containing the data you wish to import.";
            // 
            // OpenFileButton
            // 
            this.OpenFileButton.BackColor = System.Drawing.SystemColors.Control;
            this.OpenFileButton.Location = new System.Drawing.Point(306, 43);
            this.OpenFileButton.Name = "OpenFileButton";
            this.OpenFileButton.Size = new System.Drawing.Size(33, 23);
            this.OpenFileButton.TabIndex = 3;
            this.OpenFileButton.Text = "...";
            this.OpenFileButton.UseVisualStyleBackColor = false;
            // 
            // OpenFile
            // 
            this.OpenFile.ShowHelp = true;
            this.OpenFile.SupportMultiDottedExtensions = true;
            // 
            // Tab3
            // 
            this.Tab3.BackColor = System.Drawing.SystemColors.Window;
            this.Tab3.Controls.Add(this.ImportTK1Instructions);
            this.Tab3.Controls.Add(this.ImportProjects);
            this.Tab3.Controls.Add(this.ImportEntries);
            this.Tab3.Location = new System.Drawing.Point(884, 0);
            this.Tab3.Name = "Tab3";
            this.Tab3.Size = new System.Drawing.Size(354, 283);
            this.Tab3.TabIndex = 18;
            // 
            // ImportTK1Instructions
            // 
            this.ImportTK1Instructions.AutoSize = true;
            this.ImportTK1Instructions.Location = new System.Drawing.Point(15, 13);
            this.ImportTK1Instructions.Name = "ImportTK1Instructions";
            this.ImportTK1Instructions.Size = new System.Drawing.Size(168, 13);
            this.ImportTK1Instructions.TabIndex = 3;
            this.ImportTK1Instructions.Text = "What items do you wish to import?";
            // 
            // Tab5
            // 
            this.Tab5.BackColor = System.Drawing.SystemColors.Window;
            this.Tab5.Controls.Add(this.label1);
            this.Tab5.Controls.Add(this.Console);
            this.Tab5.Controls.Add(this.ImportProgress);
            this.Tab5.Location = new System.Drawing.Point(1604, 0);
            this.Tab5.Name = "Tab5";
            this.Tab5.Size = new System.Drawing.Size(354, 283);
            this.Tab5.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "What data do you wish to import?";
            // 
            // Tab4
            // 
            this.Tab4.BackColor = System.Drawing.SystemColors.Window;
            this.Tab4.Controls.Add(this.WizardReviewInstructions);
            this.Tab4.Controls.Add(this.WizardReview);
            this.Tab4.Location = new System.Drawing.Point(1244, 0);
            this.Tab4.Name = "Tab4";
            this.Tab4.Size = new System.Drawing.Size(354, 283);
            this.Tab4.TabIndex = 20;
            // 
            // WizardReview
            // 
            this.WizardReview.Location = new System.Drawing.Point(18, 64);
            this.WizardReview.Multiline = true;
            this.WizardReview.Name = "WizardReview";
            this.WizardReview.ReadOnly = true;
            this.WizardReview.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WizardReview.Size = new System.Drawing.Size(319, 196);
            this.WizardReview.TabIndex = 26;
            // 
            // WizardReviewInstructions
            // 
            this.WizardReviewInstructions.AutoSize = true;
            this.WizardReviewInstructions.Location = new System.Drawing.Point(15, 13);
            this.WizardReviewInstructions.MaximumSize = new System.Drawing.Size(336, 0);
            this.WizardReviewInstructions.Name = "WizardReviewInstructions";
            this.WizardReviewInstructions.Size = new System.Drawing.Size(324, 39);
            this.WizardReviewInstructions.TabIndex = 27;
            this.WizardReviewInstructions.Text = "Please review your upgrade options and click Import Now to import your data. Note" +
    ", depending on the size of your database, this operation could take several minu" +
    "tes.";
            // 
            // ImportWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2001, 323);
            this.Controls.Add(this.Tab4);
            this.Controls.Add(this.Tab5);
            this.Controls.Add(this.Tab3);
            this.Controls.Add(this.Tab2);
            this.Controls.Add(this.Tab1);
            this.Controls.Add(this.WizardPicture);
            this.Controls.Add(this.ButtonPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImportWizard";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Import Wizard";
            this.Load += new System.EventHandler(this.ImportWizard_Load);
            this.ButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WizardPicture)).EndInit();
            this.Tab1.ResumeLayout(false);
            this.Tab1.PerformLayout();
            this.Tab2.ResumeLayout(false);
            this.Tab2.PerformLayout();
            this.Tab3.ResumeLayout(false);
            this.Tab3.PerformLayout();
            this.Tab5.ResumeLayout(false);
            this.Tab5.PerformLayout();
            this.Tab4.ResumeLayout(false);
            this.Tab4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox ImportFileName;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.RichTextBox Console;
        private System.Windows.Forms.ProgressBar ImportProgress;
        private System.Windows.Forms.CheckBox ImportProjects;
        private System.Windows.Forms.CheckBox ImportEntries;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button CancelDialogButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.PictureBox WizardPicture;
        private System.Windows.Forms.Panel Tab1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label Introduction;
        private System.Windows.Forms.Panel Tab2;
        private System.Windows.Forms.Button OpenFileButton;
        private System.Windows.Forms.Label OpenFileInstructions;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.Panel Tab3;
        private System.Windows.Forms.Label ImportTK1Instructions;
        private System.Windows.Forms.Panel Tab5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Tab4;
        private System.Windows.Forms.TextBox WizardReview;
        private System.Windows.Forms.Label WizardReviewInstructions;
    }
}