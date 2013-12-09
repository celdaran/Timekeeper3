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
            Widgets.GoForward();
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
        }

        //----------------------------------------------------------------------

        private void ImportButton_Click(object sender, EventArgs e)
        {
            Widgets.GoToLastTab();
            ImportButton.Enabled = false;
            BackButton.Enabled = false;

            Classes.Import Importer = new Classes.Import(ImportFileName.Text);
            Importer.Console = Console;
            Importer.ImportProgress = ImportProgress;
            Importer.Timekeeper1x(ImportProjects.Checked, ImportEntries.Checked);

            ImportButton.Visible = false;
            BackButton.Visible = false;
            CancelDialogButton.Visible = false;

            CloseButton.Visible = true;
            CloseButton.Left = CancelDialogButton.Left;
        }

        //----------------------------------------------------------------------

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------

    }
}
