using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    public partial class Options : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        public Classes.Options Values { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Options(Classes.Options optionValues)
        {
            InitializeComponent();
            Values = optionValues;
        }

        //----------------------------------------------------------------------
        // Event Handlers
        //----------------------------------------------------------------------

        private void Options_Load(object sender, EventArgs e)
        {
            OptionsToForm();
        }

        //----------------------------------------------------------------------

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) {
                FormToOptions();
            } else {
                if (Common.WarnPrompt("Are you sure?") != DialogResult.Yes) {
                    e.Cancel = true;
                }
            }
        }

        //----------------------------------------------------------------------
        // Options Setter/Getters
        //----------------------------------------------------------------------

        private void OptionsToForm()
        {
            View_StatusBar.Checked = Values.View_StatusBar;
            View_StatusBar_ProjectName.Checked = Values.View_StatusBar_ProjectName;
            View_StatusBar_ActivityName.Checked = Values.View_StatusBar_ActivityName;
        }

        //----------------------------------------------------------------------

        private void FormToOptions()
        {
            Values.View_StatusBar = View_StatusBar.Checked;
            Values.View_StatusBar_ProjectName = View_StatusBar_ProjectName.Checked;
            Values.View_StatusBar_ActivityName = View_StatusBar_ActivityName.Checked;
        }

        //----------------------------------------------------------------------

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------
        // Testing
        //----------------------------------------------------------------------

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OptionsPanelCollection.SelectedIndex = PanelSelector.SelectedIndex;
        }

        //----------------------------------------------------------------------

    }
}
