using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper
{
    public partial class fNew : Form
    {
        public fNew()
        {
            InitializeComponent();
            wFilename.Text = "project1";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.ShowDialog();
            wFilename.Text = dlg.SelectedPath + "\\" + wFilename.Text;
        }
    }
}