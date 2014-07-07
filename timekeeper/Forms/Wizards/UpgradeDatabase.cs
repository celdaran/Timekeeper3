using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Globalization;
using System.Collections.ObjectModel;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Wizards
{
    public partial class UpgradeDatabase : Form
    {
        //-----------------------------------------------------------------------
        // Properties
        //-----------------------------------------------------------------------

        private Classes.Widgets Widgets;
        private File File;
        private bool UpgradeSucceeded;
        private int MemoMergeOptionsId;

        //----------------------------------------------------------------------

        // FIXME: This belongs in the wizard code
        private bool IsDirty = false;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public UpgradeDatabase()
        {
            InitializeComponent();

            this.File = new File();
            this.UpgradeSucceeded = false;
        }

        //----------------------------------------------------------------------

        private void Upgrade_Load(object sender, EventArgs e)
        {
            this.Widgets = new Classes.Widgets();

            Widgets.PopulateTimeZoneComboBox(LocationTimeZone);

            Width = 525;

            this.Location = Timekeeper.CenterInParent(this.Owner, this.Width, this.Height);

            Widgets.WizardWidth = Width;
            Widgets.BackButton = BackButton;
            Widgets.NextButton = NextButton;

            Widgets.AddTab(Tab1);
            Widgets.AddTab(Tab2);
            Widgets.AddTab(Tab3);
            Widgets.AddTab(Tab4);
            Widgets.AddTab(Tab5);

            Widgets.GoToFirstTab();
        }

        //----------------------------------------------------------------------

        private void NextButton_Click(object sender, EventArgs e)
        {
            // FIXME: is this first test needed? And, if so, shouldn't it be part of the 
            // widget object? I'm trying to ponder what this might actually mean...
            // FIXME: Not sure if I mentioned this or not, but this Widget Wizard thing 
            // really should be its own class and not wrapped up in the Widget class.

            if (this.Widgets.CurrentTab() < this.Widgets.TabCount()) {
            //if (tablessControl1.SelectedIndex < tablessControl1.TabCount) {

                if (this.Widgets.CurrentTab() == 1) {
                    // If they've clicked past the first tab, we're dirty
                    IsDirty = true;
                }

                // Move to next tab
                this.Widgets.GoForward();

                // Advance buttons
                if (this.Widgets.AtEnd()) {
                //if (tablessControl1.SelectedIndex == tablessControl1.TabCount - 1) {
                    StartButton.Visible = true;
                    StartButton.Location = NextButton.Location;
                    StartButton.Size = NextButton.Size;
                    StartButton.Focus();
                }

                // Update Review text
                string BackupDir = Path.GetDirectoryName(BackUpFileLabel.Text);
                string BackupFile = Path.GetFileName(BackUpFileLabel.Text);
                UpgradeReview.Text  = "Backup File: " + Environment.NewLine + "  " + BackupFile + Environment.NewLine + Environment.NewLine;
                UpgradeReview.Text += "Backup File Location: " + Environment.NewLine + "  " + BackupDir + Environment.NewLine + Environment.NewLine;
                UpgradeReview.Text += "Location: " + Environment.NewLine + "  " + LocationName.Text + ", " + LocationTimeZone.SelectedItem + Environment.NewLine + Environment.NewLine;
                UpgradeReview.Text += "Memo Handling: " + Environment.NewLine + "  ";

                if (MergeMemoStandard.Checked) {
                    UpgradeReview.Text += MergeMemoStandard.Text;
                    MemoMergeOptionsId = 1;
                } else if (MergeMemoNoSep.Checked) {
                    UpgradeReview.Text += MergeMemoNoSep.Text;
                    MemoMergeOptionsId = 2;
                } else if (MergeMemoNoPre.Checked) {
                    UpgradeReview.Text += MergeMemoNoPre.Text;
                    MemoMergeOptionsId = 3;
                } else if (MergeMemoNoPost.Checked) {
                    UpgradeReview.Text += MergeMemoNoPost.Text;
                    MemoMergeOptionsId = 4;
                } else {
                    UpgradeReview.Text += "No option selected";
                    MemoMergeOptionsId = -1;
                }

                UpgradeReview.Text += Environment.NewLine;
            }
        }

        //----------------------------------------------------------------------

        private void ButtonBack_Click(object sender, EventArgs e)
        {
            this.Widgets.GoBack();
            StartButton.Visible = false;

            /*
            if (tablessControl1.SelectedIndex > 0) {
                tablessControl1.SelectedIndex--;
                NextButton.Visible = true;
                StartButton.Visible = false;
                if (tablessControl1.SelectedIndex == 0) {
                    BackButton.Enabled = false;
                }
            }
            */
        }

        //----------------------------------------------------------------------

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Change button state
            StartButton.Enabled = false;
            LaterButton.Enabled = false;
            BackButton.Enabled = false;

            bool ExceptionCaught = false;
            bool Upgraded = false;

            try {
                // Back up file
                System.IO.File.Copy(File.Database.FileName, BackUpFileLabel.Text);

                // Define Upgrade Options
                FileUpgradeOptions Options = new FileUpgradeOptions();
                IdObjectPair Pair = (IdObjectPair)LocationTimeZone.SelectedItem;
                TimeZoneInfo TimeZone = (TimeZoneInfo)Pair.Object;

                Options.LocationName = LocationName.Text;
                Options.LocationDescription = LocationDescription.Text;
                Options.LocationTimeZoneId = Pair.Id;
                Options.LocationTimeZoneInfo = TimeZone;
                Options.MemoMergeTypeId = MemoMergeOptionsId;

                // Upgrade file (this needs to happen in its own thread)
                Upgraded = File.Upgrade(StepLabel, UpgradeProgress, Options);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                ExceptionCaught = true;
            }

            if (ExceptionCaught || !Upgraded) {
                Common.Warn("There was an error encountered upgrading the database. Please check the Timekeeper log file for details. You will need to restore your backup and try again after correcting the problem.");
                StepLabel.Text = "Upgrade Failed";
            } else {
                StepLabel.Text = "Upgrade Complete";
                UpgradeSucceeded = true;
            }

            // All done
            StartButton.Visible = false;
            NextButton.Visible = false;
            OkayButton.Visible = true;
            OkayButton.Location = NextButton.Location;
            OkayButton.Size = NextButton.Size;
            OkayButton.Focus();
        }

        //----------------------------------------------------------------------

        private void OkayButton_Click(object sender, EventArgs e)
        {
            if (UpgradeSucceeded) {
                DialogResult = DialogResult.OK;
            } else {
                DialogResult = DialogResult.Abort;
            }
        }

        private void SelectFileButton_Click(object sender, EventArgs e)
        {
            FileDialog.FileName = BackUpFileLabel.Text;
            if (FileDialog.ShowDialog() == DialogResult.OK) {
                BackUpFileLabel.Text = FileDialog.FileName;
            }
        }

        private void LaterButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void UpgradeDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDirty && (DialogResult == DialogResult.Cancel)) {
                // Meaning: if there have been changes, and we're not at the end of the process,
                // ask the user if they want to cancel...
                if (UpgradeSucceeded) {
                    // ...UNLESS WE'VE SUCCESSFULLY UPGRADED
                    DialogResult = DialogResult.OK;
                } else {
                    if (Common.Prompt("Are you sure you want to exit the Upgrade Database wizard?") == DialogResult.No) {
                        e.Cancel = true;
                    }
                }
            }
        }

        //----------------------------------------------------------------------

    }
}
