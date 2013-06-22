using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    public partial class Upgrade : Form
    {
        private Datafile Datafile;
        private bool UpgradeSucceeded;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Upgrade()
        {
            InitializeComponent();

            this.Datafile = new Datafile();
            this.UpgradeSucceeded = false;
        }

        //---------------------------------------------------------------------

        private void StartButton_Click(object sender, EventArgs e)
        {
            // Change button state
            StartButton.Enabled = false;
            LaterButton.Enabled = false;

            bool ExceptionCaught = false;
            bool Upgraded = false;

            try {
                // Back up file
                File.Copy(Datafile.Database.DataFile, BackUpFileLabel.Text);

                // Upgrade file (this needs to happen in its own thread)
                Upgraded = Datafile.Upgrade(StepLabel, UpgradeProgress);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                ExceptionCaught = true;
            }

            if (ExceptionCaught || !Upgraded) {
                Common.Warn("There was an error encountered upgrading the database. Please check the Timekeeper log file for details. You will need to restore your backup and try again after correcting the problem.");
                StepLabel.Text = "Upgrade Failed";
            } else {
                StepLabel.Text = "Upgrade Complete";
                UpgradeSucceeded = true;
            }

            // All done
            OkayButton.Visible = true;
            StartButton.Visible = false;
        }

        //---------------------------------------------------------------------

        private void OkayButton_Click(object sender, EventArgs e)
        {
            if (UpgradeSucceeded) {
                DialogResult = DialogResult.OK;
            } else {
                DialogResult = DialogResult.Abort;
            }
        }

        //---------------------------------------------------------------------

    }
}
