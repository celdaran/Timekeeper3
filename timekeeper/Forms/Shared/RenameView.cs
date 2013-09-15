using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms.Shared
{
    public partial class RenameView : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private string TableName;
        private Classes.Widgets Widgets;
        private string PreviousName;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public RenameView(string tableName)
        {
            InitializeComponent();
            this.TableName = tableName;
            this.Widgets = new Classes.Widgets();
        }

        //----------------------------------------------------------------------
        // Event handlers
        //----------------------------------------------------------------------

        private void RenameView_Load(object sender, EventArgs e)
        {
            PreviousName = this.wNewName.Text;
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

        private void RenameView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) {
                if (PreviousName != this.wNewName.Text) {
                    if (this.Widgets.ViewExists(this.TableName, this.wNewName.Text)) {
                        e.Cancel = true;
                    }
                }
            }
        }

        //----------------------------------------------------------------------

    }
}
