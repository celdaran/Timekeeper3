using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Runtime.InteropServices;
using Technitivity.Toolbox;

namespace Timekeeper.Forms.Wizards
{
    public partial class Import : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Widgets Widgets;
        private enum ImportTypes { Timekeeper1x, CSV };
        private ImportTypes ImportType;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Import()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void ImportWizard_Load(object sender, EventArgs e)
        {
            Widgets = new Classes.Widgets();

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

            ImportDataTypeList.SelectedIndex = 0;
        }

        //----------------------------------------------------------------------

        private void NextButton_Click(object sender, EventArgs e)
        {
            if (Widgets.CurrentTab() == 1) {

                if (ImportDataTypeList.Text == "") {
                    Common.Warn("You must select a file type");
                    return;

                } else if (ImportDataTypeList.Text == "Timekeeper 1.x") {
                    this.ImportType = Import.ImportTypes.Timekeeper1x;
                    this.OpenFile.Filter = "Timekeeper 1.x files|*.adl|All files|*.*";
                    ImportProjects.Enabled = true;
                    ImportProjects.Checked = true;
                    ImportEntries.Enabled = true;
                    ImportEntries.Checked = true;

                } else if (ImportDataTypeList.Text == "Comma Separated Values") {
                    this.ImportType = Import.ImportTypes.CSV;
                    this.OpenFile.Filter = "CSV files|*.csv|All files|*.*";
                    ImportProjects.Enabled = false;
                    ImportProjects.Checked = true;
                    ImportEntries.Enabled = false;
                    ImportEntries.Checked = true;
                }
            }

            Widgets.GoForward();

            UpdateReviewText();

            if (Widgets.AtEnd()) {
                ImportButton.Left = NextButton.Left;
                NextButton.Visible = false;
                ImportButton.Visible = true;
            }
        }

        //----------------------------------------------------------------------

        private void BackButton_Click(object sender, EventArgs e)
        {
            Widgets.GoBack();

            if (!Widgets.AtEnd()) {
                //NextButton.Left = ImportButton.Left;
                NextButton.Visible = true;
                ImportButton.Visible = false;
            }
        }

        //----------------------------------------------------------------------

        private void UpdateReviewText()
        {
            string FileName = Path.GetFileName(ImportFileName.Text);
            string FileFolder = Path.GetDirectoryName(ImportFileName.Text);

            WizardReview.Text = "";

            AddReviewLine("Import File Type", ImportDataTypeList.Text);
            AddReviewLine("Import File", FileName);
            AddReviewLine("Import File Folder", FileFolder);

            AddReviewLine("Import Entries", ImportEntries.Checked ? "Yes" : "No");
            AddReviewLine("Import Projects", ImportProjects.Enabled ? "N/A" : ImportProjects.Checked ? "Yes" : "No");
        }

        //----------------------------------------------------------------------

        private void AddReviewLine(string prompt, string value)
        {
            WizardReview.Text += String.Format("{1}:{0}  {2}{0}{0}",
                Environment.NewLine, prompt, value);
        }

        //----------------------------------------------------------------------

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Widgets.GoToLastTab();
            ImportButton.Enabled = false;
            BackButton.Enabled = false;
            NextButton.Visible = false; // FIXME: why is this still showing?

            EndLabel.Text = "Importing...";

            // Clear pending events before importing
            Application.DoEvents();

            Classes.Import Importer = new Classes.Import(ImportFileName.Text);
            Importer.Console = Console;
            Importer.ImportProgress = ImportProgress;

            switch (this.ImportType) {
                case ImportTypes.Timekeeper1x:
                    Importer.Timekeeper1x(ImportProjects.Checked, ImportEntries.Checked);
                    break;
                case Import.ImportTypes.CSV:
                    Importer.CommaSeparatedValues();
                    break;
            }

            ImportButton.Visible = false;
            BackButton.Visible = false;
            CancelDialogButton.Visible = false;

            CloseButton.Visible = true;
            CloseButton.Left = CancelDialogButton.Left;

            EndLabel.Text = "Import complete.";
        }

        //----------------------------------------------------------------------

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog(this) == DialogResult.OK) {
                ImportFileName.Text = OpenFile.FileName;
                ImportFileName.Select(ImportFileName.Text.Length, 0);
            }
        }

        //----------------------------------------------------------------------

    }
}
