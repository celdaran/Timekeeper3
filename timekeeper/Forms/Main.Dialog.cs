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

        private void Dialog_EditItem(TreeView tree, string title, Item item)
        {
            string TableName = (string)tree.Tag;
            ItemEditor Dialog = new ItemEditor(Database, TableName);

            // Set the title
            Dialog.Text = title;

            // Create an Item object
            Project Project = null;
            if (TableName == "Project") {
                Project = new Project(Database, tree.SelectedNode.Text);
            }

            // Previous values
            string PreviousName = tree.SelectedNode.Text;
            string PreviousDescription = tree.SelectedNode.ToolTipText;
            string PreviousFolder = "";
            string PreviousExternalProjectNo = "";

            // Fill in defaults on the dialog box
            Dialog.ItemName.Text = PreviousName;
            Dialog.ItemDescription.Text = PreviousDescription;

            if (tree.SelectedNode == null) {
                Dialog.ItemParent.SelectedIndex = 0;
            } else if (tree.SelectedNode.Parent == null) {
                Dialog.ItemParent.SelectedIndex = 0;
            } else {
                PreviousFolder = tree.SelectedNode.Parent.Text;
                int i = Dialog.ItemParent.FindString(PreviousFolder);
                if (i < 0) i = 0;
                Dialog.ItemParent.SelectedIndex = i;
            }

            if (TableName == "Project") {
                PreviousExternalProjectNo = Project.ExternalProjectNo;
                Dialog.ItemExternalProjectNo.Text = PreviousExternalProjectNo;
            }

            // Now display the dialog box and handle the results
            if (Dialog.ShowDialog(this) == DialogResult.OK) {

                if (Dialog.ItemName.Text != PreviousName) {
                    if (!Action_RenameItem(tree.SelectedNode, item, Dialog.ItemName.Text))
                        return;
                }

                if (Dialog.ItemDescription.Text != PreviousDescription) {
                    Action_RedescribeItem(tree.SelectedNode, item, Dialog.ItemDescription.Text);
                }

                // FIXME: I dislike the way I'm using this constant
                if (Dialog.ItemParent.Text != PreviousFolder) {
                    //if (Dialog.ItemParent.Text != "(Top Level)") {
                        Action_ReparentItem(tree, item, Dialog.ItemParent.Text);
                    //} else {
                    //}
                }

                if ((TableName == "Project") && (Dialog.ItemExternalProjectNo.Text != PreviousExternalProjectNo)) {
                    Action_RepointItem(tree.SelectedNode, Project, Dialog.ItemExternalProjectNo.Text);
                }
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
            bool ShowNewDatabaseWizard = false; // FIXME: this will be an option

            string FileName;
            FileCreateOptions CreateOptions;

            if (ShowNewDatabaseWizard) {
                NewWizard NewWizardDialog = new NewWizard();
                if (NewWizardDialog.ShowDialog(this) == DialogResult.OK) {
                    FileName = NewWizardDialog.CreateOptions.FileName;
                    CreateOptions = NewWizardDialog.CreateOptions;
                } else {
                    return;
                }
            } else {
                if (NewFileDialog.ShowDialog(this) == DialogResult.OK) {
                    FileName = NewFileDialog.FileName;
                    CreateOptions = new FileCreateOptions();
                    CreateOptions.UseProjects = true;
                    CreateOptions.UseActivities = true;
                    CreateOptions.ItemPreset = 1;
                    CreateOptions.LocationName = "Default";
                    CreateOptions.LocationDescription = "Default Location";
                    CreateOptions.LocationTimeZoneId = Timekeeper.CurrentTimeZoneId();
                } else {
                    return;
                }
            }

            Application.DoEvents();

            Cursor.Current = Cursors.WaitCursor;

            Action_CloseFile();
            Action_CreateFile(FileName, CreateOptions);
            Action_OpenFile(FileName);

            Cursor.Current = Cursors.Default;
        }

        //---------------------------------------------------------------------

        private void Dialog_NewItem(TreeView tree, string title, bool isFolder, Item item, int imageIndex)
        {
            string TableName = (string)tree.Tag;
            ItemEditor Dialog = new ItemEditor(Database, TableName);

            // Set the title
            Dialog.Text = title;

            // Determine preselected folder
            int ParentIndex = 0;
            if (tree.SelectedNode != null) {

                Item SelectedItem = (Item)tree.SelectedNode.Tag;

                if (SelectedItem.IsFolder) {
                    ParentIndex = Dialog.ItemParent.FindString(tree.SelectedNode.Text);
                } else if (tree.SelectedNode.Parent != null) {
                    ParentIndex = Dialog.ItemParent.FindString(tree.SelectedNode.Parent.Text);
                } else {
                    // Do nothing?
                }
            }
            Dialog.ItemParent.SelectedIndex = ParentIndex;

            if (Dialog.ShowDialog(this) == DialogResult.OK) {
                item.Name = Dialog.ItemName.Text;
                item.Description = Dialog.ItemDescription.Text;
                item.IsFolder = isFolder;
                item.ExternalProjectNo = Dialog.ItemExternalProjectNo.Text;

                int CreateResult = Widgets.CreateTreeItem(tree.Nodes, item, Dialog.ItemParent.Text, imageIndex);
                switch (CreateResult) {
                    case Classes.Widgets.TREES_ITEM_CREATED:
                        //Common.Info("Item created");
                        break;
                    case Classes.Widgets.TREES_ERROR_CREATING_ITEM:
                        Common.Warn("There was an error creating the item.");
                        break;
                    case Classes.Widgets.TREES_DUPLICATE_ITEM:
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
                Action_OpenFile(OpenFileDialog.FileName);
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_Options()
        {
            bool prevViewHiddenProjects = options.wViewHiddenProjects.Checked;
            bool prevViewHiddenTasks = options.wViewHiddenTasks.Checked;

            options.ShowDialog(this);
            if (options.saved) {
                try {
                    // view or hide projects pane
                    // _toggleProjects();

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
                        TrayIcon.Visible = true;
                    } else {
                        TrayIcon.Visible = false;
                    }

                    // Reorder requested?
                    if (options.reordered) {
                        if (timerRunning) {
                            Common.Info("Cannot reorder items while the timer is running. Items will be reordered when Timekeeper restarts.");
                        } else {
                            options.reordered = false;
                            reloadProjects();
                            reloadActivities();
                        }
                    }

                    // Reload Projects and Activities, if hidden options changed
                    if (prevViewHiddenProjects != options.wViewHiddenProjects.Checked) {
                        reloadProjects();
                    }
                    if (prevViewHiddenTasks != options.wViewHiddenTasks.Checked) {
                        reloadActivities();
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
            // Set date range for time calculations
            string From = DateTime.Now.ToString(Common.DATE_FORMAT + " 00:00:00");
            string To = DateTime.Now.ToString(Common.DATE_FORMAT + " 23:59:59");

            // Determine the item type
            string ItemType = item.Type == Item.ItemType.Project ? "Project" : "Activity";
            if (item.IsFolder) ItemType += " Folder";

            // Set dialog box title
            properties.Text = ItemType + " Properties";

            // Set description
            string Description;
            if (item.Description.Length > 0) {
                Description = Common.Abbreviate(item.Description, 42);
                properties.wDescription.Enabled = true;
            } else {
                Description = "None";
                properties.wDescription.Enabled = false;
            }

            // Now fill in all the values
            properties.wName.Text = Common.Abbreviate(item.Name, 42);
            properties.wDescription.Text = Description;
            properties.wType.Text = ItemType;
            properties.wID.Text = item.ItemId.ToString();
            properties.wGUID.Text = item.ItemGuid;

            properties.wCreated.Text = item.CreateTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            properties.wModified.Text = item.ModifyTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            properties.wTotalTime.Text = Timekeeper.FormatSeconds(item.RecursiveSecondsElapsed(item.ItemId, "1900-01-01", "2999-01-01"));
            properties.wTimeToday.Text = Timekeeper.FormatSeconds(item.RecursiveSecondsElapsed(item.ItemId, From, To));

            properties.wIsHidden.Checked = item.IsHidden;
            properties.wIsDeleted.Checked = item.IsDeleted;
            if (item.IsHidden)
                properties.wHiddenTime.Text = item.HiddenTime.ToString(Common.LOCAL_DATETIME_FORMAT);
            if (item.IsDeleted)
                properties.wDeletedTime.Text = item.DeletedTime.ToString(Common.LOCAL_DATETIME_FORMAT);

            if (item.Type == Item.ItemType.Project) {
                long LastActivityId = item.FollowedItemId;
                if (LastActivityId > 0) {
                    Activity Activity = new Activity(Database, LastActivityId);
                    properties.wLastItemName.Enabled = true;
                    properties.wLastItemName.Text = Activity.Name;
                    properties.wLastItemLabel.Text = "Last Activity:";
                } else {
                    properties.wLastItemName.Enabled = false;
                    properties.wLastItemName.Text = "None";
                }
                properties.wExternalProjectNo.Text = item.ExternalProjectNo;
                properties.wExternalProjectNoLabel.Visible = true;
                properties.wExternalProjectNo.Visible = true;
            } else {
                long LastProjectId = item.FollowedItemId;
                if (LastProjectId > 0) {
                    Project Project = new Project(Database, LastProjectId);
                    properties.wLastItemLabel.Text = "Last Project:";
                    properties.wLastItemName.Enabled = true;
                    properties.wLastItemName.Text = Project.Name;
                } else {
                    properties.wLastItemName.Enabled = false;
                    properties.wLastItemName.Text = "None";
                }
                properties.wExternalProjectNoLabel.Visible = false;
                properties.wExternalProjectNo.Visible = false;
            }

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

    }
}
