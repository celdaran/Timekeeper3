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
            Action_SetMenuAvailability(MenuAction, true);
            Action_SetMenuAvailability(MenuReport, true);
            Action_SetMenuAvailability(MenuTool, true);

            /*
            OldPopupMenuProject.Enabled = true;
            PopupMenuActivity.Enabled = true;
            */

            MenuFileSaveAs.Enabled = true;
            MenuFileClose.Enabled = true;

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
            Action_SetMenuAvailability(MenuAction, false);
            Action_SetMenuAvailability(MenuReport, false);
            Action_SetMenuAvailability(MenuTool, false);

            /*
            OldPopupMenuProject.Enabled = false;
            PopupMenuActivity.Enabled = false;
            */

            MenuFileSaveAs.Enabled = false;
            MenuFileClose.Enabled = false;
        }

        //---------------------------------------------------------------------

        private void MenuBar_ShowHideProject(bool visible)
        {
            if (Options.View_HiddenProjects) {
                // set main menu items
                //MenuActionHideProject.Visible = visible;
                //MenuActionUnhideProject.Visible = !visible;

                // mirror popup menu items
                //PopupMenuProjectHide.Visible = visible;
                //PopupMenuProjectUnhide.Visible = !visible;
            }
        }

        //---------------------------------------------------------------------

        private void MenuBar_ShowMergeProject(bool isFolder)
        {
            //MenuActionMergeProject.Enabled = !isFolder;
            //PopupMenuProjectMerge.Enabled = !isFolder;
        }

        //---------------------------------------------------------------------

        private void MenuBar_ShowDeleteProject(bool isDeleted)
        {
            //MenuActionEditProject.Enabled = !isDeleted;
            //MenuActionHideProject.Enabled = !isDeleted;
            //MenuActionDeleteProject.Enabled = !isDeleted;

            //PopupMenuProjectEdit.Enabled = !isDeleted;
            //PopupMenuProjectRename.Enabled = !isDeleted;
            //PopupMenuProjectHide.Enabled = !isDeleted;
            //PopupMenuProjectDelete.Enabled = !isDeleted;
        }

        //---------------------------------------------------------------------

        private void MenuBar_ShowHideActivity(bool visible)
        {
            if (Options.View_HiddenActivities) {
                // Set main menu items
                //MenuActionHideActivity.Visible = visible;
                //MenuActionUnhideActivity.Visible = !visible;

                // Mirror popup menu items
                //PopupMenuActivityHide.Visible = visible;
                //PopupMenuActivityUnhide.Visible = !visible;
            }
        }

    }
}
