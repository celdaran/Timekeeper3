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
            View_StatusBar_ElapsedSinceStart.Checked = Values.View_StatusBar_ElapsedSinceStart;
            View_StatusBar_ElapsedProjectToday.Checked = Values.View_StatusBar_ElapsedProjectToday;
            View_StatusBar_ElapsedActivityToday.Checked = Values.View_StatusBar_ElapsedActivityToday;
            View_StatusBar_ElapsedAllToday.Checked = Values.View_StatusBar_ElapsedAllToday;
        }

        //----------------------------------------------------------------------

        private void FormToOptions()
        {
            Values.View_StatusBar = View_StatusBar.Checked;
            Values.View_StatusBar_ProjectName = View_StatusBar_ProjectName.Checked;
            Values.View_StatusBar_ActivityName = View_StatusBar_ActivityName.Checked;
            Values.View_StatusBar_ElapsedSinceStart = View_StatusBar_ElapsedSinceStart.Checked;
            Values.View_StatusBar_ElapsedProjectToday = View_StatusBar_ElapsedProjectToday.Checked;
            Values.View_StatusBar_ElapsedActivityToday = View_StatusBar_ElapsedActivityToday.Checked;
            Values.View_StatusBar_ElapsedAllToday = View_StatusBar_ElapsedAllToday.Checked;
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

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Timekeeper.Info("Called OnPaintBackground");
            if (TabRenderer.IsSupported && Application.RenderWithVisualStyles) {
                TabRenderer.DrawTabPage(e.Graphics, this.ClientRectangle);
            } else {
                base.OnPaintBackground(e);
                ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Raised);
            }
        }

        //----------------------------------------------------------------------

    }
}
