using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper
{
    public partial class fOptions : Form
    {
        public bool saved = false;
        public bool reordered = false;
        private DBI data;

        const int CTRL = (int)Keys.Control;
        const int SHIFT = (int)Keys.Shift;

        public fOptions(DBI data)
        {
            InitializeComponent();
            this.data = data;

            // Populate font box
            InstalledFontCollection fonts = new InstalledFontCollection();
            FontFamily[] fontFamilies = fonts.Families;

            foreach (FontFamily font in fonts.Families) {
                wFontList.Items.Add(font.Name);
            }

            // Populate function list
        }

        private void wViewStatusBar_CheckedChanged(object sender, EventArgs e)
        {
            bool enabled = (wViewStatusBar.Checked == true);
            wViewCurrentTask.Enabled = enabled;
            wViewElapsedCurrent.Enabled = enabled;
            wViewElapsedOne.Enabled = enabled;
            wViewElapsedAll.Enabled = enabled;
            wViewOpenedFile.Enabled = enabled;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saved = true;
            Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            saved = false;
            Hide();
        }

        private void wProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (wProfile.Text) {
                case "Basic":
                    wViewStatusBar.Checked = false;
                    wViewProjectPane.Checked = false;
                    break;

                case "Normal":
                    wViewStatusBar.Checked = true;
                    wViewOpenedFile.Checked = false;
                    wViewProjectPane.Checked = false;
                    break;

                case "Advanced":
                    wViewStatusBar.Checked = true;
                    wViewOpenedFile.Checked = true;
                    wViewProjectPane.Checked = true;
                    break;

                default:
                    break;
            }
        }

        private void fOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void wShowInTray_CheckedChanged(object sender, EventArgs e)
        {
            wMinimizeToTray.Enabled = wShowInTray.Checked;
            wMinimizeToTray.Checked = wShowInTray.Checked;
        }

        private void wMinimizeOnUse_CheckedChanged(object sender, EventArgs e)
        {
            //wMinimizeToTray.Enabled = wMinimizeOnUse.Checked;
        }

        private void wPromptNoTimer_CheckedChanged(object sender, EventArgs e)
        {
            labelMinutes.Enabled = wPromptNoTimer.Checked;
            wPromptInterval.Enabled = wPromptNoTimer.Checked;
        }

        private void wOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void wOrderBy_SelectionChangeCommitted(object sender, EventArgs e)
        {
            reordered = true;
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fOptions\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

        private void wFunctionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = wFunctionList.SelectedItems;
            foreach (ListViewItem item in items)
            {
                int nShortcut = item.ImageIndex;
                if (nShortcut == 0) {
                    wCtrl.Checked = false;
                    wShift.Checked = false;
                    wKey.SelectedIndex = 26;
                    continue;
                }

                wCtrl.Checked = ((nShortcut & CTRL) == CTRL);
                wShift.Checked = ((nShortcut & SHIFT) == SHIFT);
                int nKey = nShortcut;
                if (wCtrl.Checked) {
                    nKey -= CTRL;
                }
                if (wShift.Checked) {
                    nKey -= SHIFT;
                }
                
                if (nKey - (int)'A' < 26) {
                    wKey.SelectedIndex = nKey - (int)'A';
                } else {
                    wKey.SelectedIndex = 26;
                }
            }
        }

        private void wCtrl_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection items = wFunctionList.SelectedItems;
            foreach (ListViewItem item in items)
            {
                if (wKey.SelectedIndex < 26) {
                    if (wCtrl.Checked) {
                        item.ImageIndex += CTRL;
                    } else {
                        item.ImageIndex -= CTRL;
                    }
                }
            }
        }

        private void wShift_MouseClick(object sender, MouseEventArgs e)
        {
            ListView.SelectedListViewItemCollection items = wFunctionList.SelectedItems;
            foreach (ListViewItem item in items)
            {
                if (wKey.SelectedIndex < 26) {
                    if (wShift.Checked) {
                        item.ImageIndex += SHIFT;
                    } else {
                        item.ImageIndex -= SHIFT;
                    }
                }
            }
        }

        private void wKey_SelectedIndexChanged(object sender, EventArgs e)
        {
            int newValue = 0;

            ListView.SelectedListViewItemCollection items = wFunctionList.SelectedItems;
            foreach (ListViewItem item in items)
            {
                if (wKey.SelectedIndex == 26) {
                    item.ImageIndex = 0;
                }
                else
                {
                    if (wShift.Checked) {
                        newValue += SHIFT;
                    }

                    if (wCtrl.Checked) {
                        newValue += CTRL;
                    }

                    newValue += wKey.SelectedIndex + (int)'A';
                    if (item.ImageIndex != newValue) {
                        item.ImageIndex = newValue;
                    }
                }
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection items = wFunctionList.SelectedItems;
            foreach (ListViewItem item in items) {
                item.ImageIndex = 0;
                wCtrl.Checked = false;
                wShift.Checked = false;
                wKey.SelectedIndex = 26;
            }
        }

        // next one goes here
    }
}