using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Media;

namespace Timekeeper.Forms.Tools
{
    public partial class Event : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Event()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Event_Load(object sender, EventArgs e)
        {
            Classes.ReferenceData Ref = new Classes.ReferenceData();
            Classes.Widgets Widgets = new Classes.Widgets();
            Widgets.PopulateGenericComboBox(EventGroup, Ref.Table("DatePreset"));
            EventTabControl.TabPages.RemoveByKey("HiddenTab");
            EnableRangeTab(false);
            ThenLabel.Visible = false;
            TargetPanel.Visible = false;

            // FIXME: move to widgets | experimental right now

            // Directory relative to exe
            DirectoryInfo di = new DirectoryInfo("Sounds");
            foreach (FileInfo f in di.GetFiles("*.wav")) {
                SoundList.Items.Add(f.Name);
            }
        }

        //----------------------------------------------------------------------
        // Radio Events
        //----------------------------------------------------------------------

        private void RecurNoneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurNoneRadioButton.Checked) {
                HideAllPanels();
                EnableRangeTab(false);
                ThenLabel.Visible = false;
                TargetPanel.Visible = false;
            }
        }

        private void RecurFixedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurFixedRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurFixedPanel);
            }
        }

        private void RecurDailyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurDailyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurDailyPanel);
            }
        }

        private void RecurWeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurWeeklyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurWeeklyPanel);
            }
        }

        private void RecurMonthlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurMonthlyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurMonthlyPanel);
            }
        }

        private void RecurYearlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurYearlyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurYearlyPanel);
            }
        }

        private void EnableRangeTab(bool enabled)
        {
            foreach (Control ctl in EventTabControl.TabPages["RangeTab"].Controls) {
                ctl.Enabled = enabled;
            }
        }

        private void RelocatePanel(Panel panel)
        {
            panel.Top = TargetPanel.Top + 6;
            panel.Left = TargetPanel.Left + 6;
            panel.Parent = PatternGroupBox;
            panel.BringToFront();
            EnableRangeTab(true);
            ThenLabel.Visible = true;
            TargetPanel.Visible = true;
        }

        private void HideAllPanels()
        {
            RecurFixedPanel.Parent = PanelCorral;
            RecurDailyPanel.Parent = PanelCorral;
            RecurWeeklyPanel.Parent = PanelCorral;
            RecurMonthlyPanel.Parent = PanelCorral;
            RecurYearlyPanel.Parent = PanelCorral;
        }

        private void SoundList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try {
                SoundPlayer simpleSound = new SoundPlayer(@"Sounds/" + SoundList.SelectedItem.ToString());
                simpleSound.Play();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
    }
}
