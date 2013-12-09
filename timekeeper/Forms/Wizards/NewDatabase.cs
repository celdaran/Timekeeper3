using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Wizards
{
    public partial class NewDatabase : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Widgets Widgets;
        private FileCreateOptions _CreateOptions;

        //----------------------------------------------------------------------

        private bool IsDirty = false;

        //----------------------------------------------------------------------
        // Constructor and Form Events
        //----------------------------------------------------------------------

        public NewDatabase()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------

        private void NewWizard_Load(object sender, EventArgs e)
        {
            this.Widgets = new Classes.Widgets();

            Widgets.PopulateTimeZoneComboBox(LocationTimeZone);
            ItemPreset.SelectedIndex = 0;

            Width = 525;
            Widgets.WizardWidth = Width;
            Widgets.BackButton = BackButton;
            Widgets.NextButton = NextButton;

            Widgets.AddTab(Tab1);
            Widgets.AddTab(Tab2);
            Widgets.AddTab(Tab3);
            Widgets.AddTab(Tab4);
            Widgets.AddTab(Tab5);
            Widgets.AddTab(Tab6);

            Widgets.GoToFirstTab();
        }

        //----------------------------------------------------------------------

        private void NewWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDirty && (DialogResult == DialogResult.Cancel)) {
                // Meaning: if there have been changes, and we're not at the end of the process,
                // ask the user if they want to cancel
                if (Common.Prompt("Are you sure you want to exit the New Database wizard?") == DialogResult.No) {
                    e.Cancel = true;
                }
            }
        }

        //----------------------------------------------------------------------
        // Accessors for Public Properties
        //----------------------------------------------------------------------

        /*
        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }
        */

        //----------------------------------------------------------------------

        public FileCreateOptions CreateOptions
        {
            get { return _CreateOptions; }
            set { _CreateOptions = value; }
        }

        //----------------------------------------------------------------------
        // Wizard Button Events
        //----------------------------------------------------------------------

        private void NextButton_Click(object sender, EventArgs e)
        {
            // TODO: Break this up into smaller pieces

            if (this.Widgets.CurrentTab() < this.Widgets.TabCount()) {
            //if (tablessControl1.SelectedIndex < tablessControl1.TabCount) {

                // Tab Validation
                if (this.Widgets.CurrentTab() == 2) {
                //if (tablessControl1.SelectedIndex == 1) {
                    /*
                     * At this point we have one of three situations:
                     * 
                     * 1. The user has selected the file with the NewFileDialog box.
                     * 2. The user has manually typed in a file name with an extension.
                     * 3. The user has manually typed in a file name without an extension.
                     * 
                     * I'd like the dialog box to remain both updated and authoritative.
                     */

                    // Immediately bail if no file name exists at all
                    if (NewDatabaseFileName.Text == "") {
                        Common.Warn("You must select a file name");
                        return;
                    }

                    // Before doing anything else, make sure the user-visible filename
                    // is fully qualified. It should contain a directory, filename and
                    // proper extension. This is a prerequesite for further processing.
                    string NewFolder = Path.GetDirectoryName(NewDatabaseFileName.Text);
                    string NewExtension = Path.GetExtension(NewDatabaseFileName.Text);
                    if (NewFolder == "") {
                        NewFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                        NewDatabaseFileName.Text = NewFolder + Path.DirectorySeparatorChar + NewDatabaseFileName.Text;
                    }
                    if (NewExtension == "") {
                        NewDatabaseFileName.Text += ".tkdb";
                    }

                    // Does the file exist? That should be a problem.
                    if (System.IO.File.Exists(NewDatabaseFileName.Text)) {
                        Common.Warn("File already exists. Choose a new file name.");
                        return;
                    }

                    // If the user-visible filename is different from the dialog
                    // box filename (for whatever reason), whomp the dialog box
                    // filename in favor of what the user can see
                    if (NewDatabaseFileName.Text != NewFileDialog.FileName) {
                        NewFileDialog.FileName = NewDatabaseFileName.Text;
                    }

                    // Lastly, sync everything up
                    //this.FileName = NewDatabaseFileName.Text;
                    IsDirty = true;
                }

                // Item Type validation
                if (this.Widgets.CurrentTab() == 3) {
                //if (tablessControl1.SelectedIndex == 2) {
                    if (UseProjects.Checked == false && UseActivities.Checked == false) {
                        Common.Warn("You must track at least one dimension: Projects or Activities");
                        return;
                    }
                }

                // Location validation
                if (this.Widgets.CurrentTab() == 5) {
                //if (tablessControl1.SelectedIndex == 4) {
                    if (LocationName.Text == "") {
                        Common.Warn("You must specify a Location Name");
                        return;
                    }
                }

                // Move to next tab
                this.Widgets.GoForward();
                //tablessControl1.SelectedIndex++;
                //BackButton.Enabled = true;

                // End of Wizard state change
                if (this.Widgets.AtEnd()) {
                //if (tablessControl1.SelectedIndex == tablessControl1.TabCount - 1) {
                    UpdateReviewText();
                    NextButton.Visible = false;
                    FinishButton.Visible = true;
                    FinishButton.Location = NextButton.Location;
                    FinishButton.Size = NextButton.Size;
                    FinishButton.Focus();

                    IdObjectPair Pair = (IdObjectPair)LocationTimeZone.SelectedItem;

                    FileCreateOptions Options = new FileCreateOptions();
                    Options.FileName = NewDatabaseFileName.Text;
                    Options.UseProjects = UseProjects.Checked;
                    Options.UseActivities = UseActivities.Checked;
                    Options.ItemPreset = ItemPreset.SelectedIndex;
                    Options.LocationName = LocationName.Text;
                    Options.LocationDescription = LocationDescription.Text;
                    Options.LocationTimeZoneId = Pair.Id;
                    Options.LocationTimeZoneInfo = (TimeZoneInfo)Pair.Object;
                    this.CreateOptions = Options;
                }

            }
        }

        //----------------------------------------------------------------------

        private void UpdateReviewText()
        {
            string NewFileName = Path.GetFileName(NewDatabaseFileName.Text);
            string NewFolder = Path.GetDirectoryName(NewDatabaseFileName.Text);

            WizardReview.Text = "New File: " + Environment.NewLine + "  " + NewFileName + Environment.NewLine + Environment.NewLine;
            WizardReview.Text += "New File Folder: " + Environment.NewLine + "  " + NewFolder + Environment.NewLine + Environment.NewLine;

            WizardReview.Text += "Use Projects:" + Environment.NewLine + "  ";
            WizardReview.Text += UseProjects.Checked ? "Yes" : "No";
            WizardReview.Text += Environment.NewLine + Environment.NewLine;

            WizardReview.Text += "Use Activities:" + Environment.NewLine + "  ";
            WizardReview.Text += UseActivities.Checked ? "Yes" : "No";
            WizardReview.Text += Environment.NewLine + Environment.NewLine;

            WizardReview.Text += "Preset Job Template:" + Environment.NewLine + "  ";
            WizardReview.Text += ItemPreset.SelectedIndex == 0 ? "None" : ItemPreset.SelectedItem;
            WizardReview.Text += Environment.NewLine + Environment.NewLine;

            WizardReview.Text += "Location: " + Environment.NewLine + "  ";
            WizardReview.Text += LocationName.Text + Environment.NewLine + "  ";
            WizardReview.Text += LocationDescription.Text + Environment.NewLine + "  ";
            WizardReview.Text += LocationTimeZone.SelectedItem;
            WizardReview.Text += Environment.NewLine + Environment.NewLine;
        }

        //----------------------------------------------------------------------

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Widgets.GoBack();

            //NextButton.Visible = true;
            FinishButton.Visible = false;

            /*
            if (tablessControl1.SelectedIndex > 0) {
                tablessControl1.SelectedIndex--;
                NextButton.Visible = true;
                FinishButton.Visible = false;
                if (tablessControl1.SelectedIndex == 0) {
                    BackButton.Enabled = false;
                }
            }
            */
        }

        //----------------------------------------------------------------------

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            if (NewFileDialog.FileName == "") {
                NewFileDialog.FileName = (Environment.UserName ?? "Timekeeper") + ".tkdb";
            }

            if (NewFileDialog.ShowDialog(this) == DialogResult.OK) {
                NewDatabaseFileName.Text = NewFileDialog.FileName;
            }
        }

        //----------------------------------------------------------------------

        private void LaterButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //----------------------------------------------------------------------

        private void FinishButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------

    }
}
