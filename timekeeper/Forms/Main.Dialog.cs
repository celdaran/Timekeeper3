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

        private void Dialog_EditItem(TreeView tree, string title, Classes.TreeAttribute item)
        {
            string TableName = (string)tree.Tag;
            ItemEditor Dialog = new ItemEditor(TableName);

            // Store the object in the dialog's tag
            Dialog.Tag = item;

            // Set the title
            Dialog.Text = title;

            // Create a Project object (needed for External)
            Classes.Project Project = null;
            if (TableName == "Project") {
                Project = new Classes.Project(item.Name);
            }

            // Previous values
            string PreviousName = item.Name;
            string PreviousDescription = item.Description;
            string PreviousFolder = "";
            string PreviousExternalProjectNo = null;

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
                    if (Action_RenameItem(tree.SelectedNode, item, Dialog.ItemName.Text)) {
                        tree.SelectedNode.Text = item.DisplayName();
                        tree.SelectedNode.Tag = item;
                    } else {
                        return;
                    }
                }

                if (Dialog.ItemDescription.Text != PreviousDescription) {
                    Action_RedescribeItem(tree.SelectedNode, item, Dialog.ItemDescription.Text);
                }

                if (Dialog.ItemParent.Text != PreviousFolder) {
                    IdValuePair Pair = (IdValuePair)Dialog.ItemParent.SelectedItem;
                    Action_ReparentItem(tree, item, (long)Pair.Id);
                }

                if ((TableName == "Project") && (Dialog.ItemExternalProjectNo.Text != PreviousExternalProjectNo)) {
                    Project.Name = Dialog.ItemName.Text;
                    Action_RepointItem(tree.SelectedNode, Project, Dialog.ItemExternalProjectNo.Text);
                    tree.SelectedNode.Text = Project.DisplayName();
                }

            }
        }

        //---------------------------------------------------------------------

        private void Dialog_HideItem(TreeView tree, bool viewingHiddenItems)
        {
            if (Options.Behavior_Annoy_PromptBeforeHiding)
            {
                Forms.Shared.Prompt Dialog = new Forms.Shared.Prompt();
                Dialog.wInstructions.Text = "Hide this item?\n\nTo display hidden items, go to Tools | Options and check the appropriate boxes on the View tab. Hidden items are always available on reports.";

                if (Dialog.ShowDialog(this) != DialogResult.OK) {
                    return;
                } else {
                    if (Dialog.wDontShowAgain.Checked) {
                        Common.Warn("Debug this. Not sure if this will get saved.");
                        Options.Behavior_Annoy_PromptBeforeHiding = false;
                    }
                }
            }

            Action_HideItem(tree, viewingHiddenItems);
        }

        //---------------------------------------------------------------------

        private IdObjectPair Dialog_LocationManager()
        {
            // Display the Location Manager dialog box
            Forms.LocationManager DialogBox = new Forms.LocationManager();
            DialogBox.ShowDialog(this);

            // Rebuild the list
            wLocation.Items.Clear();
            Widgets.PopulateLocationComboBox(wLocation);

            // Set the return value
            IdObjectPair CurrentItem;
            if (DialogBox.CurrentItem != null) {
                CurrentItem = (IdObjectPair)DialogBox.CurrentItem;
            } else {
                CurrentItem = new IdObjectPair();
            }

            // Dispose of the dialog
            DialogBox.Dispose();

            // Return the selection
            return CurrentItem;
        }

        //---------------------------------------------------------------------

        private void Dialog_NewFile()
        {
            string FileName;
            FileCreateOptions CreateOptions;

            if (Options.Behavior_Annoy_UseNewDatabaseWizard) {
                Forms.Wizards.NewDatabase NewWizardDialog = new Forms.Wizards.NewDatabase();
                if (NewWizardDialog.ShowDialog(this) == DialogResult.OK) {
                    FileName = NewWizardDialog.CreateOptions.FileName;
                    CreateOptions = NewWizardDialog.CreateOptions;
                    if (NewWizardDialog.CreateOptions.UseActivities && NewWizardDialog.CreateOptions.UseProjects) {
                        Options.Behavior_TitleBar_Template = "%time - %activity for %project";
                    } else if (NewWizardDialog.CreateOptions.UseActivities) {
                        Options.Behavior_TitleBar_Template = "%time - %activity";
                    } else if (NewWizardDialog.CreateOptions.UseProjects) {
                        Options.Behavior_TitleBar_Template = "%time - %project";
                    }
                } else {
                    return;
                }
            } else {
                if (NewFileDialog.ShowDialog(this) == DialogResult.OK) {
                    FileName = NewFileDialog.FileName;
                    CreateOptions = new FileCreateOptions();
                    CreateOptions.UseProjects = true;
                    CreateOptions.UseActivities = false;
                    CreateOptions.ItemPreset = 0;
                    CreateOptions.LocationName = "Default";
                    CreateOptions.LocationDescription = "Default Location";
                    CreateOptions.LocationTimeZoneId = Timekeeper.CurrentTimeZoneId();
                    Options.Behavior_TitleBar_Template = "%time - %project";
                } else {
                    return;
                }
            }

            Application.DoEvents();

            Cursor.Current = Cursors.WaitCursor;

            Action_CloseFile();
            if (Action_CreateFile(FileName, CreateOptions)) {
                Action_OpenFile(FileName);

                // Override any earlier registry-based options
                // Fixes Ticket #1291 but see also Ticket #1301
                Options.Layout_UseProjects = CreateOptions.UseProjects;
                Options.Layout_UseActivities = CreateOptions.UseActivities;

                Action_UseProjects(Options.Layout_UseProjects);
                Action_UseActivities(Options.Layout_UseActivities);
            } else {
                Common.Warn("An error occurred creating the database");
            }

            Cursor.Current = Cursors.Default;
        }

        //---------------------------------------------------------------------

        private void Dialog_NewItem(TreeView tree, string title, bool isFolder, Classes.TreeAttribute item, int imageIndex)
        {
            string TableName = (string)tree.Tag;
            ItemEditor Dialog = new ItemEditor(TableName);

            // Set the title
            Dialog.Text = title;

            // Determine preselected folder
            int ParentIndex = 0;
            if (tree.SelectedNode != null) {

                Classes.TreeAttribute SelectedItem = (Classes.TreeAttribute)tree.SelectedNode.Tag;

                if (SelectedItem.IsFolder) {
                    ParentIndex = Dialog.ItemParent.FindString(SelectedItem.Name);
                } else if (tree.SelectedNode.Parent != null) {
                    ParentIndex = Dialog.ItemParent.FindString(SelectedItem.Parent().Name);
                } else {
                    // Do nothing?
                }
            }
            Dialog.ItemParent.SelectedIndex = ParentIndex;

            if (Dialog.ShowDialog(this) == DialogResult.OK) {
                item.Name = Dialog.ItemName.Text;
                item.Description = Dialog.ItemDescription.Text;
                item.IsFolder = isFolder;
                item.ExternalProjectNo = Dialog.ItemExternalProjectNo.Text == "" ? null : Dialog.ItemExternalProjectNo.Text;

                IdValuePair Pair = (IdValuePair)Dialog.ItemParent.SelectedItem;
                int ParentItemId = Pair.Id;

                int CreateResult = Widgets.CreateTreeItem(tree.Nodes, item, ParentItemId, imageIndex);
                switch (CreateResult) {
                    case Classes.Widgets.TREES_ITEM_CREATED:
                        Action_TreeView_ShowRootLines();
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
            // Pass the instantiated options to the dialog box
            Forms.Options DialogBox = new Forms.Options(this.Options, this.MenuMain);

            // If the user clicked 'Save' . . .
            if (DialogBox.ShowDialog(this) == DialogResult.OK)
            {
                // Retrieve any options changes made on the dialog box
                this.Options = DialogBox.Values;

                // And save them back to the persistent store
                this.Options.SaveOptions();

                this.Dialog_ApplyOptions(DialogBox.InterfaceChanged);
            }
            else {
                // JUST FOR NOW
                //Application.Exit();
            }
        }

        private void Dialog_ApplyOptions(bool interfaceChanged)
        {
            StatusBar_SetVisibility();
            Browser_ViewOtherAttributes();

            if (timerRunning) {
                DeferShortcutAssignment = true;
            } else {
                Action_SetShortcuts();
                Browser_SetShortcuts();
            }

            Action_UseProjects(Options.Layout_UseProjects);
            Action_UseActivities(Options.Layout_UseActivities);

            TrayIcon.Visible = Options.Behavior_Window_ShowInTray;

            MemoEditor.ToolbarVisible(Options.View_Other_MemoEditorToolbar);
            MemoEditor.SwitchMarkdown(Options.Advanced_Other_MarkupLanguage);

            if (interfaceChanged) {
                switch (Options.InterfacePreset) {
                    case 0:
                        Height = 200;
                        Width = 364;
                        Browser_Close();
                        Browser_Size(false);
                        break;
                    case 1:
                        Height = 460;
                        Width = 572;
                        splitMain.SplitterDistance = 180;
                        splitTrees.SplitterDistance = Width / 2;
                        Browser_Open();
                        Browser_Size(true);
                        break;
                    case 2:
                        Height = 460;
                        Width = 572;
                        splitMain.SplitterDistance = 180;
                        splitTrees.SplitterDistance = Width / 2;
                        Browser_Open();
                        Browser_Size(true);
                        break;
                }
            }
        }

        //---------------------------------------------------------------------

        private void Dialog_Options_Legacy()
        {
            /*
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
            */
        }

        //---------------------------------------------------------------------

        private void Dialog_Properties(Classes.TreeAttribute item)
        {
            // Set date range for time calculations
            string From = DateTime.Now.ToString(Common.DATE_FORMAT + " 00:00:00");
            string To = DateTime.Now.ToString(Common.DATE_FORMAT + " 23:59:59");

            // Determine the item type
            string ItemType = item.Type == Classes.TreeAttribute.ItemType.Project ? "Project" : "Activity";
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

            if (item.Type == Classes.TreeAttribute.ItemType.Project) {
                long LastActivityId = item.FollowedItemId;
                if (LastActivityId > 0) {
                    Classes.Activity Activity = new Classes.Activity(LastActivityId);
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
                    Classes.Project Project = new Classes.Project(LastProjectId);
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
