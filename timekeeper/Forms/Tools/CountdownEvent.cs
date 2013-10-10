using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms.Tools
{
    public partial class CountdownEvent : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;
        private Classes.Widgets Widgets;
        private bool IsDirty;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public CountdownEvent(bool isDirty)
        {
            InitializeComponent();
            this.IsDirty = isDirty;
            this.Options = Timekeeper.Options;
            this.Widgets = new Classes.Widgets();
        }

        //----------------------------------------------------------------------
        // Form events
        //----------------------------------------------------------------------

        private void CountdownEvent_Load(object sender, EventArgs e)
        {
            //EventDateTime.CustomFormat = this.Options.Advanced_DateTimeFormat;
        }

        //----------------------------------------------------------------------

        private void CountdownEvent_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) {
                if (this.Widgets.ViewExists("Event", "FIXME" /*this.EventName.Text*/, this.IsDirty)) {
                    e.Cancel = true;
                }
            }
        }

        //----------------------------------------------------------------------

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------

        private void CancelDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //----------------------------------------------------------------------

    }
}
