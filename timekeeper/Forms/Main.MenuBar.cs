using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    partial class Main
    {
        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        private void MenuBar_FileOpened()
        {
            // Enabled Settings
            MenuAction.Enabled = true;
            menuReport.Enabled = true;
            menuTool.Enabled = true;
            PopupMenuProject.Enabled = true;
            PopupMenuActivity.Enabled = true;

            // MRU handling

            // See if current file is already on the list
            int i = 0;
            int Position = -1;
            foreach (ToolStripMenuItem item in MenuFileRecent.DropDownItems) {
                if (item.Text == DatabaseFileName) {
                    Position = i;
                    break;
                }
                i++;
            }

            // If found, remove from current position
            if (Position > -1) {
                MenuFileRecent.DropDownItems.RemoveAt(Position);
            }

            // Now insert (either the new one or reinserting the one we just deleted, at the top)
            ToolStripMenuItem NewItem = new ToolStripMenuItem();
            NewItem.Click += new EventHandler(MenuFileRecentFile_Click);
            NewItem.Text = DatabaseFileName;
            MenuFileRecent.DropDownItems.Insert(0, NewItem);
        }

        //---------------------------------------------------------------------

        private void MenuBar_FileClosed()
        {
            MenuAction.Enabled = false;
            menuReport.Enabled = false;
            menuTool.Enabled = false;
            PopupMenuProject.Enabled = false;
            PopupMenuActivity.Enabled = false;
        }

        //---------------------------------------------------------------------

        private void MenuBar_ShowHideProject(bool visible)
        {
            if (options.wViewHiddenProjects.Checked) {
                // set main menu items
                MenuActionHideProject.Visible = visible;
                MenuActionUnhideProject.Visible = !visible;

                // mirror popup menu items
                PopupMenuProjectHide.Visible = visible;
                PopupMenuProjectUnhide.Visible = !visible;
            }
        }

        //---------------------------------------------------------------------

        private void MenuBar_ShowHideActivity(bool visible)
        {
            if (options.wViewHiddenTasks.Checked) {
                // Set main menu items
                MenuActionHideActivity.Visible = visible;
                MenuActionUnhideActivity.Visible = !visible;

                // Mirror popup menu items
                PopupMenuActivityHide.Visible = visible;
                PopupMenuActivityUnhide.Visible = !visible;
            }
        }

    }
}
