using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Forms.Shared
{
    public partial class SaveView : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private string TableName;
        private Classes.Widgets Widgets;
        private bool IsDirty;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public SaveView(string tableName, bool isDirty)
        {
            InitializeComponent();
            this.TableName = tableName;
            this.IsDirty = isDirty;
            this.Widgets = new Classes.Widgets();
        }

        //----------------------------------------------------------------------
        // Form events
        //----------------------------------------------------------------------

        private void SaveView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) {
                if (this.Widgets.ViewExists(this.TableName, this.ViewName.Text, this.IsDirty)) {
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

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fGridSave\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

        //---------------------------------------------------------------------
    }
}
