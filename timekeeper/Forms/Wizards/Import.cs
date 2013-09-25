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

        private List<Panel> WizardPanels = new List<Panel>();
        private int CurrentTab;

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
            Width = 525;

            WizardPanels.Add(Tab1);
            WizardPanels.Add(Tab2);
            WizardPanels.Add(Tab3);
            WizardPanels.Add(Tab4);
            WizardPanels.Add(Tab5);

            GoToTab(1);
        }

        //----------------------------------------------------------------------

        private void NextButton_Click(object sender, EventArgs e)
        {
            GoToTab(CurrentTab + 1);
            if (CurrentTab == 4) {
                ImportButton.Left = NextButton.Left;
                NextButton.Visible = false;
                ImportButton.Visible = true;
            }
        }

        //----------------------------------------------------------------------

        private void BackButton_Click(object sender, EventArgs e)
        {
            GoToTab(CurrentTab - 1);
        }

        //----------------------------------------------------------------------

        private void ImportButton_Click(object sender, EventArgs e)
        {
            GoToTab(5);
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
        // Wizard Navigation
        //----------------------------------------------------------------------

        private void GoToTab(int tabNo)
        {
            if ((tabNo > 0) && (tabNo <= WizardPanels.Count)) {
                CurrentTab = tabNo;

                Panel Tab = WizardPanels[tabNo - 1];
                Tab.Visible = true;
                Tab.Left = 164;

                int Index = 0;
                foreach (Panel OtherTab in WizardPanels) {
                    if (Index != (tabNo - 1)) {
                        OtherTab.Visible = false;
                        OtherTab.Left = 524;
                    }
                    Index++;
                }
            }
        }

        //----------------------------------------------------------------------

    }
}
