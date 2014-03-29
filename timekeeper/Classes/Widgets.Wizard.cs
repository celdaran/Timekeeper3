using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    partial class Widgets
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private List<Panel> WizardPanels = new List<Panel>();
        private int WizardCurrentTab;

        public int WizardWidth { get; set; }
        public Button NextButton { get; set; }
        public Button BackButton { get; set; }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        public void AddTab(Panel tab)
        {
            WizardPanels.Add(tab);
        }

        //----------------------------------------------------------------------

        public bool AtEnd()
        {
            return (WizardCurrentTab == WizardPanels.Count);
        }

        //----------------------------------------------------------------------

        public int CurrentTab()
        {
            return WizardCurrentTab;
        }

        //----------------------------------------------------------------------

        public Panel CurrentTabControl()
        {
            return WizardPanels[WizardCurrentTab];
        }

        //----------------------------------------------------------------------

        public int TabCount()
        {
            return WizardPanels.Count;
        }

        //----------------------------------------------------------------------
        // Wizard Navigation
        //----------------------------------------------------------------------

        public void GoToFirstTab()
        {
            GoToTab(1);
        }

        //----------------------------------------------------------------------

        public void GoToLastTab()
        {
            GoToTab(WizardPanels.Count);
        }

        //----------------------------------------------------------------------

        public void GoBack()
        {
            GoToTab(WizardCurrentTab - 1);
        }

        //----------------------------------------------------------------------

        public void GoForward()
        {
            GoToTab(WizardCurrentTab + 1);
        }

        //----------------------------------------------------------------------

        private void GoToTab(int tabNo)
        {
            // Display requested tab
            if ((tabNo > 0) && (tabNo <= WizardPanels.Count)) {
                WizardCurrentTab = tabNo;

                Panel Tab = WizardPanels[tabNo - 1];
                Tab.Visible = true;
                // FIXME: hardcoded value!
                Tab.Left = 164;

                int Index = 0;
                foreach (Panel OtherTab in WizardPanels) {
                    if (Index != (tabNo - 1)) {
                        OtherTab.Visible = false;
                        OtherTab.Left = WizardWidth - 1;
                    }
                    Index++;
                }
            }

            // Update buttons accordingly

            BackButton.Enabled = true;
            NextButton.Enabled = true;

            BackButton.Visible = true;
            NextButton.Visible = true;

            if (WizardCurrentTab == 1) {
                BackButton.Enabled = false;
            }

            if (AtEnd()) {
                NextButton.Enabled = false;
            }
        }

    }
}
