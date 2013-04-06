using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class fMain
    {
        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        private void Dialog_EditItem(TreeView tree, string title, Item item)
        {
            string TableName = (string)tree.Tag;
            fItem Dialog = new fItem(Database, TableName);

            Dialog.Text = title;
            if (tree.SelectedNode == null) {
                Dialog.wParent.SelectedIndex = 0;
            } else if (tree.SelectedNode.Parent == null) {
                Dialog.wParent.SelectedIndex = 0;
            } else {
                int i = Dialog.wParent.FindString(tree.SelectedNode.Parent.Text);
                if (i < 0) { i = 0; }
                Dialog.wParent.SelectedIndex = i;
            }

            Dialog.wNodeName.Text = tree.SelectedNode.Text;
            Dialog.wNodeDescription.Text = tree.SelectedNode.ToolTipText;

            if (Dialog.ShowDialog(this) == DialogResult.OK) {

                Action_RenameItem(tree.SelectedNode, item, Dialog.wNodeName.Text);
                Action_RedescribeItem(tree.SelectedNode, item, Dialog.wNodeDescription.Text);
                Action_ReparentItem(tree, item, Dialog.wParent.Text);

            }
        }

        //---------------------------------------------------------------------

        private void Dialog_HideItem(TreeView tree, bool viewingHiddenItems)
        {
            if (options.wPromptHide.Checked)
            {
                fPrompt Dialog = new fPrompt();
                Dialog.wInstructions.Text = "Hide this item?\n\nTo display hidden items, go to Tools | Options and check the appropriate boxes on the View tab. Hidden items are always available on reports.";

                if (Dialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                } else {
                    if (Dialog.wDontShowAgain.Checked) {
                        options.wPromptHide.Checked = false;
                    }
                }
            }

            Action_HideItem(tree, viewingHiddenItems);
        }

        //---------------------------------------------------------------------

        private void Dialog_NewFile()
        {
            if (NewFileDialog.ShowDialog(this) == DialogResult.OK) {
                Action_LoadFile(NewFileDialog.FileName, DatabaseCheckAction.CreateIfMissing);
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_NewItem(TreeView tree, string title, bool isFolder, Item item, int imageIndex)
        {
            string TableName = (string)tree.Tag;
            fItem Dialog = new fItem(Database, TableName);

            Dialog.Text = title;
            if (tree.SelectedNode == null) {
                Dialog.wParent.SelectedIndex = 0;
            } else {
                int i = Dialog.wParent.FindString(tree.SelectedNode.Text);
                if (i < 0) { i = 0; }
                Dialog.wParent.SelectedIndex = i;
            }

            if (Dialog.ShowDialog(this) == DialogResult.OK) {
                item.Name = Dialog.wNodeName.Text;
                item.Description = Dialog.wNodeDescription.Text;
                item.IsFolder = isFolder;
                int CreateResult = Trees_CreateItem(tree.Nodes, item, Dialog.wParent.Text, imageIndex);
                switch (CreateResult) {
                    case TREES_ITEM_CREATED:
                        //Common.Info("Item created");
                        break;
                    case TREES_ERROR_CREATING_ITEM:
                        Common.Warn("There was an error creating the item.");
                        break;
                    case TREES_DUPLICATE_ITEM:
                        Common.Warn("An item with that name already exists.");
                        break;
                    default:
                        Common.Warn("An unexpected error occurred creating item.");
                        break;
                }
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_OpenFile()
        {
            if (OpenFileDialog.ShowDialog(this) == DialogResult.OK) {
                Action_LoadFile(OpenFileDialog.FileName);
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_Options()
        {
            bool prevViewHiddenTasks = options.wViewHiddenTasks.Checked;
            bool prevViewHiddenProjects = options.wViewHiddenProjects.Checked;

            options.ShowDialog(this);
            if (options.saved) {
                try {
                    // view or hide projects pane
                    _toggleProjects();

                    StatusBar_SetVisibility();

                    // window metrics
                    switch (options.wProfile.Text) {
                        case "Basic":
                            Width = 248;
                            Height = 73;
                            break;
                        case "Normal":
                            Width = 365;
                            Height = 127;
                            break;
                        case "Advanced":
                            // Resize only if currently "too small"
                            if (Width < 365) {
                                Width = 365;
                            }
                            if (Height < 127) {
                                Height = 127;
                            }
                            //splitContainer1.SplitterDistance = 450;
                            break;
                        default:
                            break;
                    }

                    // system try icon?
                    if (options.wShowInTray.Checked) {
                        wNotifyIcon.Visible = true;
                    } else {
                        wNotifyIcon.Visible = false;
                    }

                    // Reorder requested?
                    if (options.reordered) {
                        if (timerRunning) {
                            Common.Info("Cannot reorder items while the timer is running. Items will be reordered when Timekeeper restarts.");
                        } else {
                            options.reordered = false;
                            reloadTasks();
                            reloadProjects();
                        }
                    }

                    // Reload tasks and projects, if hidden options changed
                    if (prevViewHiddenTasks != options.wViewHiddenTasks.Checked) {
                        reloadTasks();
                    }
                    if (prevViewHiddenProjects != options.wViewHiddenProjects.Checked) {
                        reloadProjects();
                    }

                    // Keyboard customizations
                    foreach (ListViewItem function in options.wFunctionList.Items) {
                        foreach (ToolStripMenuItem item in MenuMain.Items.Find(function.Text, true)) {
                            item.ShortcutKeys = (Keys)function.ImageIndex;
                        }
                    }
                }
                catch (Exception x) {
                    Common.Warn("There was a problem applying options.");
                    Timekeeper.Exception(x);
                }
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_Properties(Item item)
        {
            string From = DateTime.Now.ToString(Common.DATE_FORMAT + " 00:00:00");
            string To = DateTime.Now.ToString(Common.DATE_FORMAT + " 23:59:59");

            properties.Text = "Properties for " + item.Name;

            properties.wID.Text = item.ItemId.ToString();
            properties.wType.Text = item.IsFolder ? "Folder" : "Item"; ;
            properties.wDescription.Text = item.Description.Length > 0 ? item.Description : "(none)";
            properties.wTotalTime.Text = Timekeeper.FormatSeconds(item.RecursiveSecondsElapsed(item.ItemId, "1900-01-01", "2999-01-01"));
            properties.wTimeToday.Text = Timekeeper.FormatSeconds(item.RecursiveSecondsElapsed(item.ItemId, From, To));
            properties.wCreated.Text = item.CreateTime.ToString();

            properties.ShowDialog(this);
        }

        //---------------------------------------------------------------------

        private void Dialog_SaveAsFile()
        {
            if (SaveAsDialog.ShowDialog(this) == DialogResult.OK) {
                Action_SaveAs(SaveAsDialog.FilterIndex);
            }
        }

        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
    }
}
