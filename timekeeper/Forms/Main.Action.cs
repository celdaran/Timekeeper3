using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Diagnostics;

using Technitivity.Toolbox;

//FIXME: wrong place for this
using Quartz;
using Quartz.Impl;
using Quartz.Simpl;
//Move(d) to Classes.Schedule (?)

namespace Timekeeper.Forms
{
    partial class Main
    {
        // These prevent potentially infinite following
        private bool DontChangeProject = false;
        private bool DontChangeActivity = false;

        // Deferred keyboard shortcut setting
        private bool DeferShortcutAssignment = false;

        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        private void Action_ChangedProject()
        {
            // Get current project
            Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
            Options.State_LastProjectId = Project.ItemId;

            // Update status bar
            if (timerRunning == false) {
                Classes.Activity Activity;
                if (ActivityTree.SelectedNode != null) {
                    Activity = (Classes.Activity)ActivityTree.SelectedNode.Tag;
                } else {
                    Activity = new Classes.Activity();
                }
                StatusBar_Update(Project, Activity);
            }

            // Auto-follow
            if (!isBrowsing) {
                if (Options.Behavior_Annoy_ActivityFollowsProject) {
                    if (Project.FollowedItemId > 0) {
                        TreeNode node = Widgets.FindTreeNode(ActivityTree.Nodes, Project.FollowedItemId);
                        if ((node != null) && (!DontChangeProject)) {
                            DontChangeActivity = true;
                            ActivityTree.SelectedNode = node;
                            DontChangeActivity = false;
                        }
                    }
                }
            }

            // TODO: Implement auto-follow the other direction
            // Set hide mode based on projects's IsHidden property
            MenuBar_ShowHideProject(!Project.IsHidden);

            // Update calendar to reflect change
            Action_UpdateCalendar(ProjectTree);

            // Set our dirty bit
            if ((isBrowsing) && (Project.ItemId != browserEntry.ProjectId)) {
                toolControlRevert.Enabled = true;
            }
        }

        //---------------------------------------------------------------------

        private void Action_ChangedActivity()
        {
            // Get current items
            Classes.Activity Activity = (Classes.Activity)ActivityTree.SelectedNode.Tag;
            Options.State_LastActivityId = Activity.ItemId;

            // Update status bar
            if (timerRunning == false) {
                Classes.Project Project;
                if (ProjectTree.SelectedNode != null) {
                    Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
                } else {
                    Project = new Classes.Project();
                }
                StatusBar_Update(Project, Activity);
            }

            if (!isBrowsing) {
                if (Options.Behavior_Annoy_ProjectFollowsActivity) {
                    if (Activity.FollowedItemId > 0) {
                        TreeNode node = Widgets.FindTreeNode(ProjectTree.Nodes, Activity.FollowedItemId);
                        if ((node != null) && (!DontChangeActivity)) {
                            DontChangeProject = true;
                            ProjectTree.SelectedNode = node;
                            DontChangeProject = false;
                        }
                    }
                }
            }

            // Set hide mode based on Activity's IsHidden property
            MenuBar_ShowHideActivity(!Activity.IsHidden);

            // Update calendar to reflect change
            Action_UpdateCalendar(ActivityTree);

            // Set our dirty bit
            if ((isBrowsing) && (Activity.ItemId != browserEntry.ActivityId)) {
                toolControlRevert.Enabled = true;
            }
        }

        //---------------------------------------------------------------------

        private void Action_ChangedLocation()
        {
            // First make sure an item has been selected
            if (Action_ItemSelected(wLocation)) {
                IdObjectPair CurrentItem = Dialog_LocationManager();
                Action_SelectItem(wLocation, CurrentItem);
            }
        }

        //---------------------------------------------------------------------

        private void Action_ChangedCategory()
        {
            // First make sure an item has been selected
            if (Action_ItemSelected(wCategory)) {

                // Display the Category Manager dialog box
                Forms.CategoryManager Dialog = new Forms.CategoryManager();
                Dialog.ShowDialog(this);

                // Rebuild the list
                wCategory.Items.Clear();
                Widgets.PopulateCategoryComboBox(wCategory);

                // Select whatever item was selected on the dialog box
                Action_SelectItem(wCategory, Dialog.CurrentItem);

                // All done
                Dialog.Dispose();
            }
        }

        //----------------------------------------------------------------------

        public bool Action_CheckRecentFile(ToolStripMenuItem menuItem)
        {
            if (System.IO.File.Exists(menuItem.Text)) {
                return true;
            } else {
                string Message = String.Format(
                    "File {0}  does not exist. Would you like to remove it from the Recent Files list?",
                    menuItem.Text);
                if (Common.WarnPrompt(Message) == DialogResult.Yes) {
                    MenuFileRecent.DropDownItems.Remove(menuItem);
                }
                return false;
            }
        }

        //---------------------------------------------------------------------
        // Next two are helpers for the change list attribute methods above
        //---------------------------------------------------------------------

        private bool Action_ItemSelected(ComboBox box)
        {
            if (box.SelectedIndex > -1) {
                IdObjectPair Item = (IdObjectPair)box.SelectedItem;
                Classes.ListAttribute ListAttribute = (Classes.ListAttribute)Item.Object;

                if (ListAttribute.Id == -1) {
                    return true;
                } else {
                    return false;
                }
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------

        private void Action_SelectItem(ComboBox box, object currentItem)
        {
            // Select an appropriate value
            if (currentItem == null) {
                box.SelectedIndex = 0;
            } else {
                // Select a new item based on whatever was last selected in the Dialog box
                Classes.ListAttribute ListAttribute = (Classes.ListAttribute)((IdObjectPair)currentItem).Object;
                int Index = box.FindString(ListAttribute.Name);
                box.SelectedIndex = Index;
            }
        }

        //---------------------------------------------------------------------

        private void Action_CopyFilenameToClipboard(string text)
        {
            // Strip instructions
            string subText = text.Substring(0, text.IndexOf("\n"));
            // Put remainder on clipboard
            Clipboard.SetData(DataFormats.StringFormat, subText);
            // Notify user (TODO: candidate for annoyance option?)
            Common.Info("File name copied to the clipboard.");
        }

        //---------------------------------------------------------------------

        private bool Action_CheckDatabase()
        {
            try {
                int LogLevel = Timekeeper.GetLogLevel(Options.Advanced_Logging_Database);

                Timekeeper.Info("Opening Database: " + DatabaseFileName);
                Timekeeper.OpenDatabase(DatabaseFileName, LogLevel);

                if (!Timekeeper.Database.FileExists) {
                    Timekeeper.DoubleWarn("File " + DatabaseFileName + " not found");
                    return false;
                }

                File File = new File();

                switch (File.Check()) {
                    case File.ERROR_UNEXPECTED:
                        Timekeeper.DoubleWarn("An error occurred during the database check. Cannot open file.");
                        return false;

                    case File.ERROR_NEWER_VERSION_DETECTED:
                        Timekeeper.DoubleWarn("This database is from a newer version of Timekeeper. Cannot open file.");
                        return false;

                    case File.ERROR_NOT_TKDB:
                        Timekeeper.DoubleWarn("This is not a Timekeeper database. File not opened.");
                        return false;

                    case File.ERROR_EMPTY_DB:
                        Timekeeper.DoubleWarn("This is not a Timekeeper database. File not opened.");
                        return false;

                    case File.ERROR_REQUIRES_UPGRADE:
                        if (Action_ConvertPriorVersion()) {
                            return true;
                        } else {
                            return false;
                        }
                }

                // Instantiate Meta class. This is used here
                // and globally throughout the Main object realm.
                Meta = new Classes.Meta();

                if (Meta.ProcessId > 0) {

                    string Message;
                    string ProcessName = "Unknown";

                    try {
                        Process OpenProcess = Process.GetProcessById(Meta.ProcessId);
                        ProcessName = OpenProcess.ProcessName;
                    }
                    catch {
                        // Safe to ignore
                    }

                    Message = String.Format(
                            "This database appears to be in use by another program (Name=\"{0}\", PID={1}). Continue opening?",
                            ProcessName, Meta.ProcessId);

                    if (Common.WarnPrompt(Message) == DialogResult.Yes) {
                        Meta.MarkFree();
                    } else {
                        return false;
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //---------------------------------------------------------------------

        private bool Action_CreateFile(string fileName, FileCreateOptions createOptions)
        {
            Timekeeper.Info("Creating Database: " + fileName);

            bool FileCreated = false;

            int LogLevel = Timekeeper.GetLogLevel(Options.Advanced_Logging_Database);
            Timekeeper.OpenDatabase(fileName, LogLevel);

            File File = new File();
            Version Version = new Version(File.SCHEMA_VERSION);

            File.CreateOptions = createOptions;
            FileCreated = File.Create(Version);

            Timekeeper.CloseDatabase();

            return FileCreated;
        }

        //---------------------------------------------------------------------

        private void Action_CloseFile()
        {
            if (Timekeeper.Database != null) {

                ProjectTree.Nodes.Clear();
                ActivityTree.Nodes.Clear();

                StatusBar_FileClosed();
                MenuBar_FileClosed();
                Browser_Disable();

                Options.SaveLocal();

                if (Meta != null) {
                    if (Process.GetCurrentProcess().Id == Meta.ProcessId) {
                        // Free up the file if this is the current process
                        // attempting to do the freeing.
                        Meta.MarkFree();
                    }
                }

                Timekeeper.Info("Closing Database: " + DatabaseFileName);
                Timekeeper.CloseDatabase();

                foreach (Form Form in OpenForms) {
                    Form.Close();
                }
            }
        }

        //---------------------------------------------------------------------

        public void Action_DeleteItem(TreeView tree)
        {
            // Confirm
            if (Common.Prompt("Delete this item?") != DialogResult.Yes) {
                return;
            }

            // Instantiate item
            Classes.TreeAttribute SourceItem = (Classes.TreeAttribute)tree.SelectedNode.Tag;

            // See if it's in use
            Classes.JournalEntryCollection.Dimension Dim;
            if (SourceItem.Type == Classes.TreeAttribute.ItemType.Project) {
                Dim = Classes.JournalEntryCollection.Dimension.Project;
            } else {
                Dim = Classes.JournalEntryCollection.Dimension.Project;
            }
            var JournalEntries = new Classes.JournalEntryCollection();
            int Count = JournalEntries.Count(Dim, SourceItem.ItemId);

            if (Count > 0) {
                string Prompt = String.Format(
                    "You have {0} journal entries logged against this item. Would you like to merge them with another item?",
                    Count);
                if (Common.Prompt(Prompt) == DialogResult.Yes) {
                    if (!Action_MergeItem(SourceItem)) {
                        return;
                    }
                }
            }

            // Remove item from the database
            long result = SourceItem.Delete();
            if (result == 0) {
                Common.Warn("There was a problem deleting the item.");
                return;
            }

            // Now remove from the UI
            tree.SelectedNode.Remove();

            // Display root lines?
            Action_TreeView_ShowRootLines();

            //tree.ShowRootLines = Activities.HasParents();
        }

        //---------------------------------------------------------------------

        private void Action_EnableRevert(string currentText, string previousText)
        {
//            if ((isBrowsing) || (!isBrowsing && timerRunning)) {
            if (isBrowsing) {
                if (currentText != previousText) {
                    Browser_EnableRevert(true);
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_FormClose()
        {
            Browser_SaveRow(false);

            Action_GetMetrics();
            Action_SaveOptions();
            Action_CloseFile();

            Options = Timekeeper.CloseOptions();
            Timekeeper.CloseScheduler();

            // Logging (TODO: should this be an option?)
            Timekeeper.Info("Timekeeper Closed");
        }

        //---------------------------------------------------------------------

        private bool Action_FormLoad()
        {
            try {
                // Load options from the Registry & TKDB
                Action_LoadOptions();

                // Next, instantiate any run-time only controls
                this.MemoEditor = new Forms.Shared.MemoEditor();
                this.MemoEditor.Parent = splitMain.Panel2;
                this.MemoEditor.BringToFront();
                this.MemoEditor.Dock = DockStyle.Fill;
                this.MemoEditor.MemoEntry.TextChanged += new System.EventHandler(this.wMemo_TextChanged);
                this.MemoEditor.MemoEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wMemo_KeyDown);

                // Instantiate persistent dialog boxes
                properties = new Forms.Properties();

                // Initialize timer
                timerLastRun = DateTime.Now;

                // Any system-wide (i.e., not file-based) UI options
                Action_InitializeUI();

                // If DatabaseFileName not already set (via command line) then
                // get it from the MRU list.
                if (DatabaseFileName == null) {
                    if (MenuFileRecent.DropDownItems.Count > 0) {
                        DatabaseFileName = MenuFileRecent.DropDownItems[0].Text;
                    }
                }

                if (DatabaseFileName != null) {
                    Action_LoadFile();
                }

                // Initialize drag drop operations
                this.ProjectTree.ItemDrag += new ItemDragEventHandler(ProjectTree_ItemDrag);
                this.ActivityTree.ItemDrag += new ItemDragEventHandler(ActivityTree_ItemDrag);

                // Schedule events and reminders
                Action_Schedule();

                // SHORTCUTS
                /*
                Forms.Shared.Schedule DialogBox = new Forms.Shared.Schedule();
                DialogBox.ShowDialog(this);
                Application.Exit();
                */

                /*
                Forms.Tools.Event DialogBox = new Forms.Tools.Event();
                DialogBox.Show(this);
                //Application.Exit();
                */

                /*
                Forms.Shared.Schedule ScheduleDialog = new Forms.Shared.Schedule(9, DateTime.Now);
                ScheduleDialog.ShowDialog(this);
                Application.Exit();
                */

                /*
                Forms.Tools.EventDetail EventDetail = new Forms.Tools.EventDetail();
                EventDetail.ShowDialog(this);
                if (EventDetail.DialogResult == DialogResult.OK) {
                    Common.Info("Creating a new event");
                } else {
                    Common.Info("Not OK");
                }
                Application.Exit();
                */

                /*
                Forms.Tools.Event EventWindow = new Forms.Tools.Event();
                EventWindow.ShowDialog(this);
                Application.Exit();
                */

                /*
                Forms.Tools.Notebook NotebookWindow = new Forms.Tools.Notebook();
                NotebookWindow.ShowDialog(this);
                Application.Exit();
                */

                //Forms.Find FindDialog = new Forms.Find(Browser_GotoEntry, Find.FindDataSources.Journal);
                /*
                var DatabaseCheckWindow = new Reports.DatabaseCheck(Browser_GotoEntry);
                DatabaseCheckWindow.ShowDialog(this);
                Application.Exit();
                */
            }
            catch (Exception x) {
                Common.Warn("There was an error loading the application. Depending on the error, additional information may exist in the application's log file.");
                Common.Warn(x.Message);
                return false;
            }

            return true;
        }

        //---------------------------------------------------------------------

        private void Action_GetMetrics()
        {
            Options.Main_Height = Height;
            Options.Main_Width = Width;
            Options.Main_Top = Top;
            Options.Main_Left = Left;
            Options.Main_MainSplitterDistance = splitMain.SplitterDistance;
            Options.Main_TreeSplitterDistance = splitTrees.SplitterDistance;
        }

        //---------------------------------------------------------------------

        private void Action_InitializeUI()
        {
            // NOTE/TODO: Some of my "Actions" are user-initiated and
            // some are system-initiated. Consider splitting these
            // into two parts so that Action always implies a user-
            // initiated action and that "XYZ" is the other. I don't
            // have a name for it yet, obviously.

            // Set Main window metrics
            Left = Options.Main_Left;
            Top = Options.Main_Top;
            Width = Options.Main_Width;
            Height = Options.Main_Height;
            splitTrees.SplitterDistance = Options.Main_TreeSplitterDistance;
            splitMain.SplitterDistance = Options.Main_MainSplitterDistance;

            // Hide browser panel until file is opened
            splitMain.Panel2Collapsed = true;

            // Until a file is opened, treat it as closed
            MenuBar_FileClosed();
            StatusBar_FileClosed();
            StatusBar_SetVisibility();

            // Using Projects and/or Activities?
            Action_UseProjects(Options.Layout_UseProjects);
            Action_UseActivities(Options.Layout_UseActivities);

            // Populate MRU List
            foreach (string FileName in Options.MRU_List) {
                ToolStripMenuItem Item = new ToolStripMenuItem();
                Item.Click += new EventHandler(MenuFileRecentFile_Click);
                Item.Text = FileName;
                MenuFileRecent.DropDownItems.Add(Item);
            }

            MenuFileRecent.Enabled = (MenuFileRecent.DropDownItems.Count > 0);

            // Load keyboard shortcuts
            Action_SetShortcuts();

            // FIXME/TODO: restore "hide projects", etc.,
            // FIXME/TODO: sort order not yet supported
            // FIXME/TODO: actually, many options aren't even used yet

            // Create tray icon if requested
            if (Options.Behavior_Window_ShowInTray) {
                TrayIcon.Visible = true;
            } else {
                TrayIcon.Visible = false;
            }

            // Set date/time formats
            wStartTime.CustomFormat = Options.Advanced_DateTimeFormat;
            wStopTime.CustomFormat = Options.Advanced_DateTimeFormat;

            // Adjust Start/Stop time widths and LocationAndCategoryPanel location
            wStartTime.Value = DateTime.Parse("1970-01-01T00:00:00.00-00:00");
            Size DateSize = TextRenderer.MeasureText(wStartTime.Text, wStartTime.Font);
            int DateTimeWidth = DateSize.Width;
            int DropDownButtonWidth = 33;

            StatusBarDebug1.Text = "Width: " + DateTimeWidth.ToString();

            wStartTime.Width = DateTimeWidth + DropDownButtonWidth;
            wStopTime.Width = DateTimeWidth + DropDownButtonWidth;

            CloseStartGapButton.Left = Math.Max(wStartTime.Width + 73, 142);
            CloseStopGapButton.Left = Math.Max(wStartTime.Width + 73, 142);

            LocationAndCategoryPanel.Left = CloseStartGapButton.Left + DropDownButtonWidth;
        }

        //---------------------------------------------------------------------

        private void Action_LoadOptions()
        {
            // Instantiate Options
            Options = Timekeeper.OpenOptions();

            // Load up primary Options
            Options.LoadOptions();
            Options.LoadMetrics();
            Options.LoadMRU();

            // TODO: should this itself be an option?
            Timekeeper.Info("Timekeeper Version " + Timekeeper.VERSION + " Started");
        }

        //---------------------------------------------------------------------

        private bool Action_MergeItem(Classes.TreeAttribute item)
        {
            Forms.Shared.Merge DialogBox = new Forms.Shared.Merge(item);
            if (DialogBox.ShowDialog(this) == DialogResult.Cancel) {
                return false;
            } else {
                Classes.TreeAttribute TargetItem = DialogBox.TargetItem;
                string Message = String.Format("You just merged all of the entries for {0} into {1}", item.Name, TargetItem.Name);
                Common.Info(Message);
                return true;
            }
        }

        //---------------------------------------------------------------------

        private void Action_OpenFile(string fileName)
        {
            Action_CloseFile();
            DatabaseFileName = fileName;
            Action_LoadFile();
        }

        //---------------------------------------------------------------------

        private void Action_HideItem(TreeView tree, bool viewingHiddenItems)
        {
            // Hide in the database
            Classes.TreeAttribute Item = (Classes.TreeAttribute)tree.SelectedNode.Tag;

            if (Item.Hide() == 0) {
                Common.Warn("There was a problem hiding the item.");
                return;
            }

            // Now handle the UI
            if (viewingHiddenItems) {
                tree.SelectedNode.ForeColor = Color.Gray;
                if (Item.IsFolder) {
                    tree.SelectedNode.ImageIndex = Timekeeper.IMG_FOLDER_HIDDEN;
                    tree.SelectedNode.SelectedImageIndex = Timekeeper.IMG_FOLDER_HIDDEN;
                } else {
                    tree.SelectedNode.ImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                    tree.SelectedNode.SelectedImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                }
            } else {
                tree.SelectedNode.Remove();
            }

            Action_TreeView_ShowRootLines();
        }

        //----------------------------------------------------------------------

        private void Action_UnhideItem(TreeView tree)
        {
            // Unhide in the database
            Classes.TreeAttribute item = (Classes.TreeAttribute)tree.SelectedNode.Tag;
            long result = item.Unhide();

            if (result == 0) {
                Common.Warn("There was a problem unhiding the item.");
                return;
            }

            // Update the UI
            tree.SelectedNode.ForeColor = Color.Black;
            if (item.IsFolder) {
                tree.SelectedNode.ImageIndex = Timekeeper.IMG_FOLDER_CLOSED;
                tree.SelectedNode.SelectedImageIndex = Timekeeper.IMG_FOLDER_CLOSED;
            } else {
                int Icon = Timekeeper.IMG_PROJECT;
                if (item.Type == Classes.TreeAttribute.ItemType.Activity) {
                    Icon = Timekeeper.IMG_ACTIVITY;
                }
                tree.SelectedNode.ImageIndex = Icon;
                tree.SelectedNode.SelectedImageIndex = Icon;
            }

            Action_TreeView_ShowRootLines();
        }

        //----------------------------------------------------------------------

        private bool Action_LoadFile()
        {
            try {
                //------------------------------------------
                // Perform database sanity check
                //------------------------------------------

                if (Action_CheckDatabase()) {
                    OpenFileDialog.FileName = DatabaseFileName;
                } else {
                    return false;
                }

                //------------------------------------------
                // Load Database-based options
                //------------------------------------------

                Options.LoadLocal();

                //------------------------------------------
                // Instatiate Classes
                //------------------------------------------

                Entries = new Classes.JournalEntryCollection();
                TimedEntry = new Classes.JournalEntry();

                //------------------------------------------
                // Prepare UI elements
                //------------------------------------------

                Widgets = new Classes.Widgets();
                Widgets.BuildProjectTree(ProjectTree.Nodes);
                Widgets.BuildActivityTree(ActivityTree.Nodes);
                Widgets.PopulateLocationComboBox(wLocation);
                Widgets.PopulateCategoryComboBox(wCategory);

                Action_TreeView_ShowRootLines();

                MenuBar_FileOpened();
                StatusBar_FileOpened();
                StatusBar_SetVisibility();

                Action_UseProjects(Options.Layout_UseProjects);
                Action_UseActivities(Options.Layout_UseActivities);

                //------------------------------------------
                // Prepare Browser
                //------------------------------------------

                Browser_Load();
                Browser_SetupForStarting();
                Browser_Enable();
                Browser_Show(Options.Main_BrowserOpen);

                //------------------------------------------
                // Restore Prior State
                //------------------------------------------

                // Re-select last selected project
                TreeNode LastNode = Widgets.FindTreeNode(ProjectTree.Nodes, Options.State_LastProjectId);
                if (LastNode != null) {
                    ProjectTree.SelectedNode = LastNode;
                    ProjectTree.SelectedNode.Expand();
                }

                // Re-select last selected activity
                LastNode = Widgets.FindTreeNode(ActivityTree.Nodes, Options.State_LastActivityId);
                if (LastNode != null) {
                    ActivityTree.SelectedNode = LastNode;
                    ActivityTree.SelectedNode.Expand();
                }

                //------------------------------------------
                // Mark Database in Use
                //------------------------------------------

                Meta.MarkInUse();

                return true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }
        }

        //----------------------------------------------------------------------

        private void Action_Reindex()
        {
            try {
                Classes.JournalEntryCollection Entries = new Classes.JournalEntryCollection();
                Entries.Reindex();
                Common.Info("Journal entries have been successfully reindexed.");
            }
            catch (Exception x) {
                Common.Warn(x.Message);
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void Action_Schedule()
        {
            try
            {
                // Open a scheduler
                Timekeeper.OpenScheduler();

                // Instantiate a collection of Scheduled Events
                Classes.ScheduledEventCollection ScheduledEvents = new Classes.ScheduledEventCollection();

                // Then loop through them
                foreach (Classes.ScheduledEvent ScheduledEvent in ScheduledEvents.Fetch()) {
                    // And schedule
                    Timekeeper.Schedule(ScheduledEvent, this);
                }

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void Action_SetMenuAvailability(ToolStripMenuItem menu, bool enabled)
        {
            //------------------------------------
            // Used to recursively disable all 
            // menu items and child items for
            // a given ToolStripMenuItem.
            //------------------------------------

            menu.Enabled = enabled;

            foreach (ToolStripItem Item in menu.DropDownItems) {
                if (Item.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem") {
                    ToolStripMenuItem MenuItem = (ToolStripMenuItem)Item;
                    Action_SetMenuAvailability(MenuItem, enabled);
                }
            }
        }

        //----------------------------------------------------------------------

        private void Action_UseProjects(bool show)
        {
            // Hide or Show the Project Pane
            if (splitTrees.Panel1.Contains(this.ProjectTree)) {
                splitTrees.Panel1Collapsed = !show;
            } else {
                splitTrees.Panel2Collapsed = !show;
            }
            Options.Layout_UseProjects = show;

            // Update the action menu accordingly
            MenuActionSep1.Visible = show;
            MenuActionNewProject.Visible = show;
            MenuActionNewProjectFolder.Visible = show;
            MenuActionEditProject.Visible = show;
            MenuActionHideProject.Visible = show;
            MenuActionDeleteProject.Visible = show;

            // Update the popup menu state accordingly
            PopupMenuProjectUseProjects.Checked = show;
            PopupMenuProjectUseActivities.Enabled = show;

            // Mirror update the other popup menu accordingly
            PopupMenuActivityUseProjects.Checked = show;
            PopupMenuActivityUseActivities.Enabled = show;

            // Swap menu handling is a bit different
            PopupMenuProjectSwapPanes.Enabled = Options.Layout_UseProjects && Options.Layout_UseActivities;
            PopupMenuActivitySwapPanes.Enabled = Options.Layout_UseProjects && Options.Layout_UseActivities;
        }

        //----------------------------------------------------------------------

        private void Action_UseActivities(bool show)
        {
            // Hide or Show the Activity Pane
            if (splitTrees.Panel1.Contains(this.ActivityTree)) {
                splitTrees.Panel1Collapsed = !show;
            } else {
                splitTrees.Panel2Collapsed = !show;
            }
            Options.Layout_UseActivities = show;

            // Update the action menu accordingly
            MenuActionSep2.Visible = show;
            MenuActionNewActivity.Visible = show;
            MenuActionNewActivityFolder.Visible = show;
            MenuActionEditActivity.Visible = show;
            MenuActionHideActivity.Visible = show;
            MenuActionDeleteActivity.Visible = show;

            // Update the popup menu state accordingly
            PopupMenuActivityUseActivities.Checked = show;
            PopupMenuActivityUseProjects.Enabled = show;

            // Mirror update the other popup menu accordingly
            PopupMenuProjectUseActivities.Checked = show;
            PopupMenuProjectUseProjects.Enabled = show;

            // Swap menu handling is a bit different
            PopupMenuProjectSwapPanes.Enabled = Options.Layout_UseProjects && Options.Layout_UseActivities;
            PopupMenuActivitySwapPanes.Enabled = Options.Layout_UseProjects && Options.Layout_UseActivities;
        }

        //---------------------------------------------------------------------

        private bool Action_ConvertPriorVersion()
        {
            bool status = false;

            try {
                Timekeeper.Info("Database Upgrade Started");

                // Get backup file name
                string NewDataFile = GetBackupFileName();

                // Open dialog box
                Forms.Wizards.UpgradeDatabase Dialog = new Forms.Wizards.UpgradeDatabase();
                Dialog.BackUpFileLabel.Text = NewDataFile;
                //Dialog.StepLabel.Text = "Click the Start button to begin the database upgrade...";
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    status = true;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
            finally {
                Timekeeper.Info("Database Upgrade Completed");
            }

            return status;
        }

        private string GetBackupFileName()
        {
            return GetBackupFileName(1);
        }

        private string GetBackupFileName(int fileno)
        {
            File File = new File();
            FileInfo FileInfo = new FileInfo(File.FullPath);

            string BackupFileName;

            if (fileno == 1) {
                BackupFileName = String.Format("{0}\\{1} - Backup{2}",
                    FileInfo.Directory.FullName,
                    Path.GetFileNameWithoutExtension(FileInfo.Name),
                    FileInfo.Extension);
            } else {
                BackupFileName = String.Format("{0}\\{1} - Backup ({3}){2}",
                    FileInfo.Directory.FullName,
                    Path.GetFileNameWithoutExtension(FileInfo.Name),
                    FileInfo.Extension, fileno);
            }

            if (System.IO.File.Exists(BackupFileName)) {
                BackupFileName = GetBackupFileName(fileno + 1);
            }

            return BackupFileName;
        }

        //---------------------------------------------------------------------

        private void Action_RedescribeItem(TreeNode node, Classes.TreeAttribute item, string newDescription)
        {
            int result = item.Redescribe(newDescription);
            if (result == Timekeeper.SUCCESS) {
                node.ToolTipText = item.Description;
            } else {
                Common.Warn("Error updating item description.");
                return;
            }
        }

        //---------------------------------------------------------------------

        private bool Action_RenameItem(TreeNode node, Classes.TreeAttribute item, string newName)
        {
            int result = item.Rename(newName);
            if (result == Timekeeper.SUCCESS) {
                return true;
            } else if (result == Classes.TreeAttribute.ERR_RENAME_EXISTS) {
                Common.Warn("An item with that name already exists.");
                return false;
            } else if (result == Timekeeper.FAILURE) {
                Common.Warn("Error renaming item.");
                return false;
            } else {
                // Don't care
                return false;
            }
        }

        //---------------------------------------------------------------------

        private void Action_ReparentItem(TreeView tree, Classes.TreeAttribute item, long parentId)
        {
            TreeNode ParentNode = Widgets.FindTreeNode(tree.Nodes, parentId);

            if (ParentNode == null) {
                item.Reparent(0);
            } else {
                Classes.TreeAttribute parentItem = (Classes.TreeAttribute)ParentNode.Tag;
                if (item.IsDescendentOf(parentItem.ItemId)) {
                    Common.Warn("Item renamed, but not reparented. Cannot reparent to a descendent.");
                    return;
                }
                item.Reparent((Classes.TreeAttribute)ParentNode.Tag);
            }

            // and reload
            // FIXME! BEGIN WTF: this sucks...
            tree.Nodes.Clear();
            // FIXME: bit of a hack, here (okay, more than a bit)
            if (tree.Name == "ProjectTree") {
                Widgets.BuildProjectTree(ProjectTree.Nodes);
            } else {
                Widgets.BuildActivityTree(ActivityTree.Nodes);
            }
            // END WTF

            // display root lines?
            Action_TreeView_ShowRootLines();
        }

        //---------------------------------------------------------------------

        private void Action_RepointItem(TreeNode node, Classes.Project project, string newExternalProjectNo)
        {
            int result = project.Repoint(newExternalProjectNo);

            if (result == 0) {
                Common.Warn("Error updating External Project Number.");
            }
        }

        //---------------------------------------------------------------------

        private void Action_CenterSplitter(SplitContainer split)
        {
            int FullSize = (split.Orientation == Orientation.Horizontal) ? split.Height : split.Width;
            split.SplitterDistance = FullSize / 2;
        }

        //---------------------------------------------------------------------

        private void Action_SaveAs(int fileType)
        {
            DBI NewDatabase = new DBI(SaveAsDialog.FileName);
            File CurrentFile = new File();
            File NewFile = new File(NewDatabase);

            CurrentFile.SaveAs22(NewFile);

            //Common.Info("You selected Save As Type: " + fileType.ToString());
        }

        //---------------------------------------------------------------------

        private void Action_SaveOptions()
        {
            Options.SaveOptions();
            Options.SaveMetrics();
            Options.SaveMRU(MenuFileRecent.DropDownItems);
        }

        //---------------------------------------------------------------------

        private void Action_SetShortcuts()
        {
            try {
                foreach (NameObjectPair Pair in Options.Keyboard_FunctionList) {
                    ToolStripItem[] Items = MenuMain.Items.Find(Pair.Name, true);
                    if (Items.Length > 0) {
                        ToolStripMenuItem Item = (ToolStripMenuItem)Items[0];
                        Item.ShortcutKeys = (Keys)Pair.Object;
                    } else {
                        Timekeeper.Info("Menu Not Found: " + Pair.Name + ", " + Pair.Object.ToString());
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Action_ShortTick()
        {
            //---------------------------------------------------------
            // Short tick is once per second: it controls the animated
            // timer on the activity tree node as well as updating the 
            // status bar and form window text.
            //---------------------------------------------------------

            // Calculate status and window bar display values
            if ((TimedActivity != null) && (timerRunning == true)) {

                // Simple increment for the one-second timer
                ElapsedSinceStart++;
                ElapsedProjectToday++;
                ElapsedActivityToday++;
                ElapsedAllToday++;

                StatusBar_Update();

                if (!isBrowsing) {
                    wDuration.Text = StatusBarElapsedSinceStart.Text;
                    wStopTime.Value = DateTime.Now;
                }

                // FIXME: More Options Overhaul
                string timeToShow = "";
                switch (Options.Behavior_TitleBar_Time) {
                    case 0: timeToShow = StatusBarElapsedSinceStart.Text; break;
                    case 1: timeToShow = StatusBarElapsedProjectToday.Text; break;
                    case 2: timeToShow = StatusBarElapsedActivityToday.Text; break;
                    case 3: timeToShow = StatusBarElapsedAllToday.Text; break;
                }

                // FIXME: add this to Widgets?
                // FIXME: I liked this updating-in-real-time feature (when it was directly accessing: options.wTitleBarTemplate.Text)
                string tmp = Options.Behavior_TitleBar_Template;
                tmp = tmp.Replace("%activity", "{0}");
                tmp = tmp.Replace("%project", "{1}");
                tmp = tmp.Replace("%time", "{2}");
                Text = String.Format(tmp, currentActivityNode.Text, currentProjectNode.Text, timeToShow);
                //wNotifyIcon.Text = Text;
                TrayIcon.Text = Common.Abbreviate(Text, 63);
            }

            // Animate the selected item icons
            if (timerRunning == true) {
                int currentIndex = currentActivityNode.SelectedImageIndex;
                if (currentIndex > Timekeeper.IMG_TIMER_END - 1) {
                    currentActivityNode.ImageIndex = Timekeeper.IMG_TIMER_START;
                    currentActivityNode.SelectedImageIndex = Timekeeper.IMG_TIMER_START;
                } else {
                    currentActivityNode.ImageIndex++;
                    currentActivityNode.SelectedImageIndex++;
                }
                currentProjectNode.ImageIndex = currentActivityNode.ImageIndex;
                currentProjectNode.SelectedImageIndex = currentActivityNode.SelectedImageIndex;
            }

            if (timerRunning == false) {
                if (!isBrowsing && (browserEntry != null)) {
                    if (!StartTimeManuallySet) {
                        wStartTime.Value = DateTime.Now;
                        wStopTime.Value = DateTime.Now;
                    } else {
                        wStopTime.Value = DateTime.Now;
                    }
                    wDuration.Text = Browser_CalculateDuration();
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_LongTick()
        {
            if (timerRunning) {
                // Refresh actual time values from database to correct for drift
                ElapsedSinceStart = Convert.ToInt32(TimedActivity.Elapsed().TotalSeconds); // FIXME: CURRENT ACTIVITY?
                ElapsedProjectToday = Convert.ToInt32(TimedProject.ElapsedToday().TotalSeconds);
                ElapsedActivityToday = Convert.ToInt32(TimedActivity.ElapsedToday().TotalSeconds);
                ElapsedAllToday = Convert.ToInt32(Entries.ElapsedToday());
            }

            // Annoyance support: if so desired, bug the user that the timer isn't running
            DateTime now = DateTime.Now;
            TimeSpan ts = new TimeSpan(now.Ticks - timerLastRun.Ticks);
            if (Options.Behavior_Annoy_NoRunningPrompt) {
                if (ts.TotalMinutes > (double)Options.Behavior_Annoy_NoRunningPromptAmount) {
                    if (timerRunning == false) {
                        if (TrayIcon.Visible) {
                            TrayIcon.ShowBalloonTip(30000,
                                Timekeeper.TITLE,
                                "No timer is currently running.\n\nYou can change the frequency of this notification (or disable it completely) in the Options dialog box.",
                                ToolTipIcon.Info);
                        }
                    }
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_StartTimer()
        {
            // Cannot start timer while browsing
            if (isBrowsing) {
                // Should be unreachable code due to the start function being
                // disabled in the UI itself. Setting this here for safety
                // purposes anyway.
                Common.Warn("You cannot start the timer while browsing entries.");
                return;
            }

            // Find the currently selected project
            if (ProjectTree.SelectedNode == null) {
                if (ProjectTree.Nodes.Count == 1) {
                    ProjectTree.SelectedNode = ProjectTree.Nodes[0];
                } else {
                    if (Options.Layout_UseProjects) {
                        Common.Warn("No Project selected.");
                        return;
                    } else {
                        ProjectTree.SelectedNode = GetFirstNonFolder(ProjectTree.Nodes);
                    }
                }
            }

            // Check for a currently selected activity
            if (ActivityTree.SelectedNode == null) {
                if (ActivityTree.Nodes.Count == 1) {
                    // If there's only one, just select it. If it turns
                    // out this is a folder, then the user can fix this
                    // manually. But it's highly likely we're here 
                    // because they're not using Activities and only
                    // the default activity is present.
                    ActivityTree.SelectedNode = ActivityTree.Nodes[0];
                } else {
                    if (Options.Layout_UseActivities) {
                        // If there's more than one, and we're supposed
                        // to be using activities at this point, then 
                        // this is an error. Make them select one.
                        Common.Warn("No Activity selected.");
                        return;
                    } else {
                        // If activities aren't in use, just find the
                        // first activity that isn't a folder and
                        // select it.
                        ActivityTree.SelectedNode = GetFirstNonFolder(ActivityTree.Nodes);
                    }
                }
            }

            // Grab instances of currently selected objects
            currentProjectNode = ProjectTree.SelectedNode;
            currentActivityNode = ActivityTree.SelectedNode;
            TimedProject = (Classes.Project)currentProjectNode.Tag;
            TimedActivity = (Classes.Activity)currentActivityNode.Tag;

            if (wLocation.SelectedItem != null)
                TimedLocation = (Classes.Location)((IdObjectPair)wLocation.SelectedItem).Object;
            if (wCategory.SelectedItem != null)
                TimedCategory = (Classes.Category)((IdObjectPair)wCategory.SelectedItem).Object;

            if ((TimedProject.IsFolder == true) || (TimedActivity.IsFolder)) {
                Common.Warn("Folders cannot be timed. Please select an item before starting the timer.");
                return;
            }

            // Now start timing
            DateTime StartTime = IsBrowserOpen() ? wStartTime.Value : DateTime.Now;
            TimedActivity.StartTiming(StartTime);
            TimedActivity.FollowedItemId = TimedProject.ItemId;

            TimedProject.StartTiming(StartTime);
            TimedProject.FollowedItemId = TimedActivity.ItemId;

            TimedEntry = new Classes.JournalEntry(); // reinstantiate this entry upon timer start
            TimedEntry.ProjectId = TimedProject.ItemId;
            TimedEntry.ActivityId = TimedActivity.ItemId;
            TimedEntry.StartTime = StartTime;
            TimedEntry.StopTime = StartTime;
            TimedEntry.Seconds = 0; // default to zero
            //Entry.Memo = wMemo.Text;
            TimedEntry.Memo = MemoEditor.Text;
            TimedEntry.IsLocked = true;
            TimedEntry.LocationId = TimedLocation == null ? 0 : TimedLocation.Id; // FIXME: Location should be not null.
            TimedEntry.CategoryId = TimedCategory == null ? 0 : TimedCategory.Id;
            if (!TimedEntry.Create()) {
                Common.Warn("There was an error starting the timer.");
                return;
            }

            //ShortTimer.Enabled = true; // Are this line and the next line the same thing?
            timerRunning = true;
            timerLastRun = DateTime.Now;

            // Grab times (this is a database hit)
            ElapsedSinceStart = (long)TimedActivity.Elapsed().TotalSeconds;
            ElapsedProjectToday = (long)TimedProject.ElapsedToday().TotalSeconds;
            ElapsedActivityToday = (long)TimedActivity.ElapsedToday().TotalSeconds;
            ElapsedAllToday = (long)Entries.ElapsedToday() + ElapsedSinceStart;

            // Make any UI changes based on the timer starting
            MenuActionStartTimer.Visible = false;
            //menuActionStartAdvanced.Visible = false;
            MenuActionStopTimer.Visible = true;
            //menuActionStopAdvanced.Visible = true;
            //Browser_EnableRevert(false);

            // swap start/stop keystrokes
            // FIXME: this is a mess
            Keys saveKeys = new Keys();
            //Keys saveKeysAdvanced = new Keys();
            saveKeys = MenuActionStartTimer.ShortcutKeys;
            //saveKeysAdvanced = MenuActionOpenBrowser.ShortcutKeys;
            MenuActionStartTimer.ShortcutKeys = Keys.None;
            //MenuActionOpenBrowser.ShortcutKeys = Keys.None;
            MenuActionStopTimer.ShortcutKeys = saveKeys;
            //MenuActionCloseBrowser.ShortcutKeys = saveKeysAdvanced;
            Browser_SetShortcuts();

            /*
            saveKeys = menuToolControlStart.ShortcutKeys;
            menuToolControlStart.ShortcutKeys = Keys.None;
            menuToolControlStop.ShortcutKeys = saveKeys;
            */

            StatusBar_TimerStarted(currentProjectNode.Text, currentActivityNode.Text);

            Text = TimedActivity.Name;

            TrayIcon.Text = Common.Abbreviate(Text, 63);

            Action_SetMenuAvailability(MenuFile, false);

            if (Options.Behavior_Window_MinimizeOnUse) {
                if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                    // Shift key temporarily overrides the minimize-on-use option
                } else {
                    WindowState = FormWindowState.Minimized;
                }
            }

            // Don't display while the timer is running (FIXME: make this an option)
            //CloseBrowser();

            // As soon as the timer has started, we have to paint "stop" mode.
            Browser_SetupForStopping();
        }

        private TreeNode GetFirstNonFolder(TreeNodeCollection nodes)
        {
            TreeNode ReturnValue = null;

            foreach (TreeNode Node in nodes) {
                Classes.TreeAttribute Temp = (Classes.TreeAttribute)Node.Tag;
                if (Temp.IsFolder) {
                    ReturnValue = GetFirstNonFolder(Node.Nodes);
                    break;
                } else {
                    ReturnValue = Node;
                    break;
                }
            }

            return ReturnValue;
        }

        //---------------------------------------------------------------------

        private void Action_StopTimer()
        {
            // Close off the timer for both objects
            long Seconds = TimedActivity.StopTiming(wStopTime.Value);
                           TimedProject.StopTiming(wStopTime.Value);

            // Close off timer
            TimedEntry.ProjectId = TimedProject.ItemId;
            TimedEntry.ActivityId = TimedActivity.ItemId;
            TimedEntry.StartTime = wStartTime.Value;
            TimedEntry.StopTime = IsBrowserOpen() ? wStopTime.Value : DateTime.Now;
            TimedEntry.Seconds = Seconds;
            //Entry.Memo = wMemo.Text;
            TimedEntry.Memo = MemoEditor.Text;
            TimedEntry.IsLocked = false;
//            Entry.LocationId = currentLocation.Id;
//            Entry.CategoryId = currentCategory.Id;
            TimedEntry.Save();
            timerRunning = false;
            //ShortTimer.Enabled = false;
            //timerLastRunNotified = false;

            // Clear instances of current object
            TimedProject = null;
            TimedActivity = null;
            //currentEntry = null;

            // Make any UI changes 
            Text = Timekeeper.TITLE;

            MenuActionStartTimer.Visible = true;
            //menuActionStartAdvanced.Visible = true;
            MenuActionStopTimer.Visible = false;
            //menuActionStopAdvanced.Visible = false;

            StatusBar_TimerStopped();

            // swap start/stop keystrokes
            // FIXME: this is a mess
            Keys saveKeys = new Keys();
            Keys saveKeysAdvanced = new Keys();
            saveKeys = MenuActionStopTimer.ShortcutKeys;
            saveKeysAdvanced = MenuActionCloseBrowser.ShortcutKeys;
            MenuActionStopTimer.ShortcutKeys = Keys.None;
            MenuActionCloseBrowser.ShortcutKeys = Keys.None;
            MenuActionStartTimer.ShortcutKeys = saveKeys;
            MenuActionOpenBrowser.ShortcutKeys = saveKeysAdvanced;
            /*
            saveKeys = menuToolControlStop.ShortcutKeys;
            menuToolControlStop.ShortcutKeys = Keys.None;
            menuToolControlStart.ShortcutKeys = saveKeys;
            */
            currentProjectNode.ImageIndex = Timekeeper.IMG_PROJECT;
            currentProjectNode.SelectedImageIndex = Timekeeper.IMG_PROJECT;
            currentActivityNode.ImageIndex = Timekeeper.IMG_ACTIVITY;
            currentActivityNode.SelectedImageIndex = Timekeeper.IMG_ACTIVITY;

            Action_SetMenuAvailability(MenuFile, true);

            // As soon as the timer has stopped, we have to paint "start" mode.
            newBrowserEntry = null;

            // FIXME: stopping the timer != opening the browser
            Browser_SetupForStarting();
            browserEntry.SetNextIndex();

            // In case any keyboard shortcuts were set while the timer
            // was running, take care of those now.
            if (DeferShortcutAssignment) {
                Action_SetShortcuts();
                Browser_SetShortcuts();
                DeferShortcutAssignment = false;
            }

        }

        //----------------------------------------------------------------------

        private void Action_SplitEntry(int parts)
        {
            try {
                // Determine the duration of each split
                long ChunkSize = (browserEntry.StopTime.Ticks - browserEntry.StartTime.Ticks) / parts;
                long ChunkSizeInSeconds = (long)TimeSpan.FromTicks(ChunkSize).TotalSeconds;

                // FIXME: this is an Advanced Option
                if (ChunkSizeInSeconds <= 600) {
                    long Minutes = ChunkSizeInSeconds / 60;
                    long Seconds = ChunkSizeInSeconds % 60;
                    string Message = String.Format(
                        "Split entries will only be {0} minutes and {1} seconds long each. Are you sure you want to split this entry?",
                        Minutes.ToString(), Seconds.ToString());
                    if (Common.WarnPrompt(Message) == DialogResult.No) {
                        return;
                    }
                }

                // Next, adjust the current entry
                browserEntry.StopTime = browserEntry.StartTime.AddTicks(ChunkSize);
                browserEntry.Seconds = ChunkSizeInSeconds;
                browserEntry.Save(); // FIXME: rethink a global "save" and support specific updates
                DateTimeOffset LastChunkTime = browserEntry.StopTime;

                // Clone the current entry
                Classes.JournalEntry SplitEntry = new Classes.JournalEntry();
                SplitEntry = browserEntry.Copy();
                SplitEntry.Seconds = ChunkSizeInSeconds;
                SplitEntry.Memo = "Entry automatically split from Journal Entry Id: " + browserEntry.JournalId.ToString();

                // Create the extra entries based on the clone
                for (int i = 1; i < parts; i++) {

                    SplitEntry.StartTime = LastChunkTime;
                    SplitEntry.StopTime = SplitEntry.StartTime.AddTicks(ChunkSize);

                    if (SplitEntry.Create()) {
                        LastChunkTime = SplitEntry.StopTime;
                    } else {
                        throw new Exception("Failed to create split entry: Journal.Id = " + browserEntry.JournalId);
                    }
                }

                // Reindex the Journal table
                Entries.Reindex(browserEntry.StartTime);

                // Copy the last-created split entry back to the browser
                browserEntry = SplitEntry.Copy();
                browserEntry.ResetIndex();
                Browser_EntryToForm(browserEntry);
            }
            catch (Exception x) {
                Common.Warn("There was a problem splitting the entry");
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void Action_SwapPanes()
        {
            if (splitTrees.Panel1.Contains(this.ActivityTree)) {
                splitTrees.Panel1.Controls.Remove(this.ActivityTree);
                splitTrees.Panel2.Controls.Remove(this.ProjectTree);

                splitTrees.Panel1.Controls.Add(this.ProjectTree);
                splitTrees.Panel2.Controls.Add(this.ActivityTree);
            } else {
                splitTrees.Panel1.Controls.Remove(this.ProjectTree);
                splitTrees.Panel2.Controls.Remove(this.ActivityTree);

                splitTrees.Panel1.Controls.Add(this.ActivityTree);
                splitTrees.Panel2.Controls.Add(this.ProjectTree);
            }
        }

        //---------------------------------------------------------------------

        private void Action_TreeView_DragDrop(TreeView tree, object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = tree.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = tree.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Get the Timekeeper Item of the node that was dragged.
            Classes.TreeAttribute draggedItem = (Classes.TreeAttribute)draggedNode.Tag;

            // Cross-tree dragging warning
            bool CrossDragAccepted = false;
            if (tree.Name != draggedNode.TreeView.Name) {
                // TODO: Allow conversion via drag and drop. This means that once confirmed
                string ToItem = (string)tree.Tag;
                string FromItem = (ToItem == "Project") ? "Activity" : "Project";
                string Message;
                if (draggedItem.IsFolder) {
                    Message = String.Format("You cannot drag this {0} folder to the {1} tree.", FromItem, ToItem);
                    Common.Warn(Message);
                    return;
                } else {
                    Message = "You are dragging an item to a different tree. ";
                    Message += String.Format("Do you wish to convert this {0} to a {1}?", FromItem, ToItem);
                    if (draggedItem.GetType() == typeof(Classes.Project)) {
                        Message += Environment.NewLine + Environment.NewLine + 
                            "Note that any External Project Number associated with this Project will be lost. This action cannot be undone.";
                    }
                    if (Common.WarnPrompt(Message) == DialogResult.Yes) {
                        CrossDragAccepted = true;
                    } else {
                        return;
                    }
                }
            }

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            // Also confirm that a folder isn't being dropped on top
            // of an item: items can only go into folders.
            bool DropAllowed = false;

            if (targetNode == null) {
                DropAllowed = true;
            } else {
                Classes.TreeAttribute targetItem = (Classes.TreeAttribute)targetNode.Tag;
                if (targetItem.IsFolder) {
                    DropAllowed = true;
                }
            }

            if (!draggedNode.Equals(targetNode) && !Action_TreeView_ContainsNode(draggedNode, targetNode) && (DropAllowed)) {
                if (e.Effect == DragDropEffects.Move) {
                    draggedNode.Remove();
                    if (targetNode == null) {
                        // Move to the root
                        tree.Nodes.Add(draggedNode);
                        // Update the database
                        draggedItem.Reparent(0);
                    } else {
                        // Otherwise, drop it on the target
                        targetNode.Nodes.Add(draggedNode);

                        // Update the database
                        Classes.TreeAttribute targetItem = (Classes.TreeAttribute)targetNode.Tag;
                        draggedItem.Reparent(targetItem.ItemId);

                        // Expand the node at the location 
                        // to show the dropped node.
                        targetNode.Expand();
                    }
                }
            }
            else if (!draggedNode.Equals(targetNode) && Action_TreeView_IsSibling(draggedNode, targetNode)) {

                int OldIndex = targetNode.Index;
                TreeNode Parent = targetNode.Parent;

                draggedNode.Remove();
                targetNode.Parent.Nodes.Insert(targetNode.Index + 1, draggedNode);
                targetNode.Remove();
                Parent.Nodes.Insert(OldIndex + 1, targetNode);

                long Index = 1;
                foreach (TreeNode node in Parent.Nodes) {
                    Classes.TreeAttribute Item = (Classes.TreeAttribute)node.Tag;
                    Item.Reorder(Index);
                    Index++;
                }

            }

            if (CrossDragAccepted) {

                // Conversion
                if (draggedItem.GetType() == typeof(Classes.Project)) {

                    // Create an Activity in the database
                    Classes.Activity Activity = new Classes.Activity();
                    Activity.Copy(draggedItem);
                    Activity.Create();

                    draggedNode.Tag = (Classes.TreeAttribute)Activity;

                    // Update the UI
                    if (Activity.IsHidden) {
                        draggedNode.ImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                        draggedNode.SelectedImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                    } else {
                        draggedNode.ImageIndex = Timekeeper.IMG_ACTIVITY;
                        draggedNode.SelectedImageIndex = Timekeeper.IMG_ACTIVITY;
                    }
                } else {
                    // Create a Project in the database
                    Classes.Project Project = new Classes.Project();
                    Project.Copy(draggedItem);
                    Project.Create();

                    draggedNode.Tag = (Classes.TreeAttribute)Project;

                    // Update the UI
                    if (Project.IsHidden) {
                        draggedNode.ImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                        draggedNode.SelectedImageIndex = Timekeeper.IMG_ITEM_HIDDEN;
                    } else {
                        draggedNode.ImageIndex = Timekeeper.IMG_PROJECT;
                        draggedNode.SelectedImageIndex = Timekeeper.IMG_PROJECT;
                    }
                }

                // Removal
                draggedItem.Delete();
                //draggedItem.Rename(draggedItem.ItemGuid);
            }
        }

        //---------------------------------------------------------------------

        private bool Action_TreeView_ContainsNode(TreeNode node1, TreeNode node2)
        {
            // A TreeView Drag-and-Drop Helper method
            if (node2 == null) {
                // We're moving it to the top level
                return false;
            } else {
                // Check the parent node of the second node.
                if (node2.Parent == null) return false;
                if (node2.Parent.Equals(node1)) return true;

                // If the parent node is not null or equal to the first node, 
                // call the ContainsNode method recursively using the parent of 
                // the second node.
                return Action_TreeView_ContainsNode(node1, node2.Parent);
            }
        }

        //---------------------------------------------------------------------

        private bool Action_TreeView_IsSibling(TreeNode node1, TreeNode node2)
        {
            // A TreeView Drag-and-Drop Helper method
            if (node2 == null) {
                return false;
            } else {
                Classes.TreeAttribute draggedItem = (Classes.TreeAttribute)node1.Tag;
                Classes.TreeAttribute targetItem = (Classes.TreeAttribute)node2.Tag;
                if (draggedItem.ParentId == targetItem.ParentId) {
                    return true;
                } else {
                    return false;
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_TreeView_ShowRootLines()
        {
            Classes.ProjectCollection Projects = new Classes.ProjectCollection();
            ProjectTree.ShowRootLines = Projects.HasParents();

            Classes.ActivityCollection Activities = new Classes.ActivityCollection();
            ActivityTree.ShowRootLines = Activities.HasParents();
        }

        //---------------------------------------------------------------------

        private void Action_UpdateCalendar(TreeView tree)
        {
            // unified
            if (calendar != null) {
                Classes.TreeAttribute CurrentItem = (Classes.TreeAttribute)tree.SelectedNode.Tag;
                DateTime LastUsed = CurrentItem.DateLastUsed();

                calendar.wCalendar.TodayDate = LastUsed;

                // Bold all dates where item has been used
                int Count = CurrentItem.NumberOfDaysUsed();
                DateTime[] Array = new DateTime[Count];

                List<DateTime> DaysUsed = CurrentItem.DaysUsed();
                Array = DaysUsed.ToArray();

                calendar.wCalendar.BoldedDates = Array;
            }
        }

        //---------------------------------------------------------------------

        private void Action_UpdateDuration(DateTimeOffset currentTime, DateTimeOffset previousTime)
        {
            if (isBrowsing) {
                if (currentTime != previousTime) {
                    wDuration.Text = Browser_CalculateDuration();
                    Browser_EnableRevert(true);
                }
            }
        }

        //---------------------------------------------------------------------

    }
}
