using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class Main
    {
        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        private void Action_ChangedActivity()
        {
            // Get current activty
            Activity Activity = (Activity)wTasks.SelectedNode.Tag;

            // Update status bar
            if (timerRunning == false) {
                StatusBar_Update(Activity);
            }

            // Auto-follow
            if (options.wProjectFollow.Checked) {
                if (Activity.FollowedItemId > 0) {
                    TreeNode node = Widgets.FindTreeNode(wProjects.Nodes, Activity.FollowedItemId);
                    if (node != null) {
                        wProjects.SelectedNode = node;
                    }
                }
            }

            // Set hide mode based on task's IsHidden property
            MenuBar_ShowHideActivity(!Activity.IsHidden);

            // Update calendar to reflect change
            Action_UpdateCalendar(wTasks);
        }

        //---------------------------------------------------------------------

        private void Action_ChangedProject()
        {
            // Get current project
            Project project = (Project)wProjects.SelectedNode.Tag;

            // Status bar updates?

            // TODO: Implement auto-follow the other direction
            // Set hide mode based on projects's IsHidden property
            MenuBar_ShowHideProject(!project.IsHidden);

            // Update calendar to reflect change
            Action_UpdateCalendar(wProjects);
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

        private bool Action_CheckDatabase(DatabaseCheckAction action)
        {
            try {
                // FIXME: Options overhaul is going to need two logging
                // levels. Set one for Timekeeper and one for Toolbox.DBI.
                // It might be helpful to have one set at debug and the
                // other at warn, for example.

                options.wSQLtracing.Checked = true;
                int LogLevel = Log.INFO;
                Database = Timekeeper.OpenDatabase(DatabaseFileName, LogLevel);

                File File = new File();
                Version Version = new Version(File.SCHEMA_VERSION);

                if (!Database.FileExists) {
                    if (action == DatabaseCheckAction.CreateIfMissing) {
                        File.Create(Version);
                    } else {
                        Common.Warn("File " + DatabaseFileName + " not found");
                    }
                }

                int Status = File.Check();

                switch (Status) {
                    case File.ERROR_UNEXPECTED:
                        Common.Warn("An error occurred during the database check. Cannot open file.");
                        return false;

                    case File.ERROR_NEWER_VERSION_DETECTED:
                        Common.Warn("This database is from a newer version of Timekeeper. Cannot open file.");
                        return false;

                    case File.ERROR_NOT_TKDB:
                        Common.Warn("This is not a Timekeeper database. File not opened.");
                        return false;

                    case File.ERROR_EMPTY_DB:
                        //Common.Warn("This appears to be an empty database. A future version of Timekeeper will allow you to claim it.");
                        if (Common.WarnPrompt("This appears to be an empty database. Would you like Timekeeper to claim it?") == System.Windows.Forms.DialogResult.Yes) {
                            if (File.Create(Version)) {
                                return true;
                            } else {
                                return false;
                            }
                        }
                        return false;

                    case File.ERROR_REQUIRES_UPGRADE:
                        //Common.Warn("This database is from a prior version of Timekeeper and needs to be updated.");
                        if (Action_ConvertPriorVersion()) {
                            return true;
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

        private void Action_CloseFile()
        {
            wTasks.Nodes.Clear();
            wProjects.Nodes.Clear();

            StatusBar_FileClosed();
            MenuBar_FileClosed();

            Database = Timekeeper.CloseDatabase();

            foreach (Form Form in OpenForms) {
                Form.Close();
            }
        }

        //---------------------------------------------------------------------

        public void Action_DeleteItem(TreeView tree)
        {
            // Confirm
            if (Common.Prompt("Delete this item?") != DialogResult.Yes) {
                return;
            }

            // Remove item from the database
            Item item = (Item)tree.SelectedNode.Tag;
            long result = item.Delete();

            if (result == 0) {
                Common.Warn("There was a problem deleting the item.");
                return;
            }

            // Now remove from the UI
            tree.SelectedNode.Remove();

            // Display root lines?
            Trees_ShowRootLines();

            //tree.ShowRootLines = Activities.HasParents();
        }

        //---------------------------------------------------------------------

        private void Action_EnableRevert(string currentText, string previousText)
        {
            if (isBrowsing) {
                if (currentText != previousText) {
                    Browser_EnableRevert(true);
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_FormClose()
        {
            Action_SaveOptions();
            Action_CloseFile();

            // Logging (TODO: should this be an option?)
            Timekeeper.Info("Timekeeper Closed");
        }

        //---------------------------------------------------------------------

        private void Action_FormLoad()
        {
            // Logging (TODO: should this be an option?)
            Timekeeper.Info("Timekeeper Started");

            // Instantiate persistent dialog boxes
            options = new Forms.Options(Database);
            properties = new Forms.Properties();

            // Load options from the Registry & TKDB
            Action_LoadOptions();

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
                // for now, do not open any files upon launch
                //Action_OpenFile();
            }

            Common.Info("Testing TBX 3.0.0.7");
        }

        //---------------------------------------------------------------------

        private void Action_InitializeUI()
        {
            // NOTE/TODO: Some of my "Actions" are user-initiated and
            // some are system-initiated. Consider splitting these
            // into two parts so that Action always implies a user-
            // initiated action and that "XYZ" is the other. I don't
            // have a name for it yet, obviously.

            // Create tray icon if requested
            if (options.wShowInTray.Checked) {
                wNotifyIcon.Visible = true;
            } else {
                wNotifyIcon.Visible = false;
            }
        }

        //---------------------------------------------------------------------

        private void Action_LoadFile(string fileName)
        {
            Action_LoadFile(fileName, DatabaseCheckAction.NoAction);
        }

        //---------------------------------------------------------------------

        private void Action_LoadFile(string fileName, DatabaseCheckAction action)
        {
            Action_CloseFile();
            DatabaseFileName = fileName;
            Action_OpenFile(action);
        }

        //---------------------------------------------------------------------

        private void Action_LoadOptions()
        {
            // TODO: Move all of this to the Options.cs class.
            // I'd like a single class to handle all application options,
            // whether stored in the Registry or in TKDB.Options.

            // Read saved values from registry
            Microsoft.Win32.RegistryKey key;

            // Window metrics
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "WindowMetrics");
            Left = (int)key.GetValue("Left", 10);
            Top = (int)key.GetValue("Top", 10);
            Width = (int)key.GetValue("Width", 426);
            Height = (int)key.GetValue("Height", 376);
            splitTrees.SplitterDistance = (int)key.GetValue("Split", 300);
            int HideProjects = (int)key.GetValue("HideProjects", 1);
            reportHeight = (int)key.GetValue("ReportHeight", 380);
            reportWidth = (int)key.GetValue("ReportWidth", 580);
            key.Close();

            // Initialize options & options dialog
            options.wViewProjectPane.Checked = (HideProjects == 0);

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "Options");
            int ShowInTray = (int)key.GetValue("ShowInTray", 1);
            int MinimizeToTray = (int)key.GetValue("MinimizeToTray", 1);
            int MinimizeOnUse = (int)key.GetValue("MinimizeOnUse", 0);
            int PreLog = (int)key.GetValue("PreLog", 1);
            int PostLog = (int)key.GetValue("PostLog", 1);
            int PromptNoTimer = (int)key.GetValue("PromptNoTimer", 1);
            int PromptHide = (int)key.GetValue("PromptHide", 1);
            int OrderBy = (int)key.GetValue("OrderBy", 0);
            string ReportFontName = (string)key.GetValue("ReportFontName", "Verdana");
            int ReportFontSize = (int)key.GetValue("ReportFontSize", 8);
            int ProjectFollow = (int)key.GetValue("ProjectFollow", 1);
            int ShowHiddenTasks = (int)key.GetValue("ShowHiddenTasks", 0);
            int ShowHiddenProjects = (int)key.GetValue("ShowHiddenProjects", 0);
            string TitleBarTemplate = (string)key.GetValue("TitleBarTemplate", "%task (%project) - %time");
            int SQLtracing = (int)key.GetValue("SQLtracing", 0);
            int TestMode = (int)key.GetValue("TestMode", 0);

            options.wShowInTray.Checked = (ShowInTray == 1);
            options.wMinimizeToTray.Checked = (MinimizeToTray == 1);
            options.wMinimizeOnUse.Checked = (MinimizeOnUse == 1);
            options.wPreLog.Checked = (PreLog == 1);
            options.wPostLog.Checked = (PostLog == 1);
            options.wPromptInterval.Value = (int)key.GetValue("PromptInterval", 10);
            options.wPromptNoTimer.Checked = (PromptNoTimer == 1);
            options.wPromptHide.Checked = (PromptHide == 1);
            options.wOrderBy.SelectedIndex = OrderBy;
            options.wFontList.SelectedIndex = options.wFontList.Items.IndexOf(ReportFontName);
            options.wFontSize.Value = ReportFontSize;
            options.wProjectFollow.Checked = (ProjectFollow == 1);
            options.wViewHiddenTasks.Checked = (ShowHiddenTasks == 1);
            options.wViewHiddenProjects.Checked = (ShowHiddenProjects == 1);
            options.wTitleBarTemplate.Text = TitleBarTemplate;
            options.wSQLtracing.Checked = (SQLtracing == 1);
            options.wTestMode.Checked = (TestMode == 1);
            key.Close();

            // Read MRU list
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "MRU");
            int count = (int)key.GetValue("count", 0);
            for (int i = 0; i < count; i++) {
                string mru = (string)key.GetValue(i.ToString(), "");
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Click += new EventHandler(MenuFileRecentFile_Click);
                item.Text = mru;
                MenuFileRecent.DropDownItems.Add(item);
            }
            key.Close();

            // Load keyboard shortcuts
            try {
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "Keyboard");
                foreach (string name in key.GetValueNames()) {
                    foreach (ToolStripMenuItem item in MenuMain.Items.Find(name, true)) {
                        item.ShortcutKeys = (Keys)key.GetValue(name);
                        options.wFunctionList.Items.Add(name, (int)item.ShortcutKeys);
                    }
                }
                key.Close();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            // NEW:

            // experimental: swapping Tasks/Projects (see TKT #1266)
            //this.splitTrees.Panel1.Controls.Add(this.wTasks);

            /*
            splitTrees.Panel1.Controls.Remove(this.wTasks);
            splitTrees.Panel1.Controls.Remove(this.wProjects);

            splitTrees.Panel1.Controls.Add(this.wProjects);
            splitTrees.Panel2.Controls.Add(this.wTasks);
            */
        }

        //---------------------------------------------------------------------

        private void Action_SaveOptions()
        {
            Microsoft.Win32.RegistryKey key;

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "WindowMetrics");
            key.SetValue("Left", Left, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("Top", Top, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("Width", Width, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("Height", Height, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("Split", splitTrees.SplitterDistance, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("HideProjects", splitTrees.Panel2Collapsed, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("ReportHeight", reportHeight, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("ReportWidth", reportWidth, Microsoft.Win32.RegistryValueKind.DWord);

            key.Close();

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "Options");
            key.SetValue("ShowInTray", options.wShowInTray.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("MinimizeToTray", options.wMinimizeToTray.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("MinimizeOnUse", options.wMinimizeOnUse.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("PreLog", options.wPreLog.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("PostLog", options.wPostLog.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("PromptNoTimer", options.wPromptNoTimer.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("PromptHide", options.wPromptHide.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("PromptInterval", options.wPromptInterval.Value, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("OrderBy", options.wOrderBy.SelectedIndex, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("ReportFontName", options.wFontList.SelectedItem.ToString());
            key.SetValue("ReportFontSize", options.wFontSize.Value, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("ProjectFollow", options.wProjectFollow.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("ShowHiddenTasks", options.wViewHiddenTasks.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("ShowHiddenProjects", options.wViewHiddenProjects.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("TitleBarTemplate", options.wTitleBarTemplate.Text);
            key.SetValue("SQLtracing", options.wSQLtracing.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("TestMode", options.wTestMode.Checked, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();

            // Save MRU list
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "MRU");
            int i = 0;
            foreach (ToolStripMenuItem item in MenuFileRecent.DropDownItems) {
                if (i < 10) { // arbitrary maximum
                    key.SetValue(i.ToString(), item.Text);
                    i++;
                }
            }
            key.SetValue("count", i, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();

            // Save Keyboard customizations
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "Keyboard");
            foreach (ToolStripMenuItem mainItem in MenuMain.Items) {
                foreach (ToolStripItem item in mainItem.DropDownItems) {
                    // Common.Info(item.GetType().ToString());
                    if (item.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem") {
                        ToolStripMenuItem menuItem = (ToolStripMenuItem)item;
                        Keys keys = menuItem.ShortcutKeys;
                        key.SetValue(menuItem.Name, menuItem.ShortcutKeys, Microsoft.Win32.RegistryValueKind.DWord);
                    }
                }
            }
            key.Close();

            // Save DB-specific state
            if (wTasks.SelectedNode != null) {
                Options.LastActivity = wTasks.SelectedNode.Text;
            }
            if (wProjects.SelectedNode != null) {
                Options.LastProject = wProjects.SelectedNode.Text;
            }
            if (lastGridView != null) {
                Options.LastGridView = lastGridView;
            }

        }

        //---------------------------------------------------------------------

        private void Action_HideItem(TreeView tree, bool viewingHiddenItems)
        {
            // Hide in the database
            Item Item = (Item)tree.SelectedNode.Tag;

            if (Item.Hide() == 0) {
                Common.Warn("There was a problem hiding the item.");
                return;
            }

            // Now handle the UI
            if (viewingHiddenItems) {
                tree.SelectedNode.ForeColor = Color.Gray;
            } else {
                tree.SelectedNode.Remove();
            }

            Trees_ShowRootLines();
        }

        //---------------------------------------------------------------------

        private void Action_UnhideItem(TreeView tree)
        {
            // Unhide in the database
            Item item = (Item)tree.SelectedNode.Tag;
            long result = item.Unhide();

            if (result == 0) {
                Common.Warn("There was a problem unhiding the item.");
                return;
            }

            // Update the UI
            tree.SelectedNode.ForeColor = Color.Black;

            Trees_ShowRootLines();
        }

        //---------------------------------------------------------------------

        private bool Action_OpenFile()
        {
            return Action_OpenFile(DatabaseCheckAction.NoAction);
        }

        //---------------------------------------------------------------------

        private bool Action_OpenFile(DatabaseCheckAction action)
        {
            try {
                if (!Action_CheckDatabase(action)) {
                    return false;
                }

                Widgets = new Classes.Widgets();
                Widgets.BuildActivityTree(wTasks.Nodes, null, 0);
                Widgets.BuildProjectTree(wProjects.Nodes, null, 0);

                Entries = new Entries(Database);
                Meta = new Classes.Meta();
                Options = new Classes.Options();

                MenuBar_FileOpened();
                StatusBar_FileOpened();

                Browser_Load();
                Browser_SetupForStarting();
                Browser_Show(true);

                // and save name for next Ctrl+O
                OpenFileDialog.FileName = DatabaseFileName;

                string lastTask = Options.LastActivity;
                string lastProject = Options.LastProject;
                lastGridView = Options.LastGridView ?? "Last View";

                // Re-select last selected task
                TreeNode lastNode = Widgets.FindTreeNode(wTasks.Nodes, lastTask);
                if (lastNode != null) {
                    wTasks.SelectedNode = lastNode;
                    wTasks.SelectedNode.Expand();
                }

                // Re-select last selected project
                lastNode = Widgets.FindTreeNode(wProjects.Nodes, lastProject);
                if (lastNode != null) {
                    wProjects.SelectedNode = lastNode;
                    wProjects.SelectedNode.Expand();
                }

                //------------------------------------------------------------
                // END:TODO
                //------------------------------------------------------------

                // View root lines?
                Trees_ShowRootLines();

                // View or hide the project pane
                _toggleProjects(); // TODO: slated for refactoring

                return true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }
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
                Forms.Upgrade Dialog = new Forms.Upgrade();
                Dialog.BackUpFileLabel.Text = NewDataFile;
                Dialog.StepLabel.Text = "Click the Start button to begin the database upgrade...";
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

        private void Action_RedescribeItem(TreeNode node, Item item, string newDescription)
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

        private bool Action_RenameItem(TreeNode node, Item item, string newName)
        {
            int result = item.Rename(newName);
            if (result == Timekeeper.SUCCESS) {
                node.Text = item.Name;
                return true;
            } else if (result == Item.ERR_RENAME_EXISTS) {
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

        private void Action_ReparentItem(TreeView tree, Item item, string parentText)
        {
            TreeNode ParentNode = Widgets.FindTreeNode(tree.Nodes, parentText);

            if (ParentNode == null) {
                item.Reparent(0);
            } else {
                Item parentItem = (Item)ParentNode.Tag;
                if (item.IsDescendentOf(parentItem.ItemId)) {
                    Common.Warn("Item renamed, but not reparented. Cannot reparent to a descendent.");
                    return;
                }
                item.Reparent((Item)ParentNode.Tag);
            }

            // and reload
            // BEGIN WTF: this sucks...
            tree.Nodes.Clear();
            // FIXME: bit of a hack, here (okay, more than a bit)
            if (tree.Name == "wTasks") {
                Widgets.BuildActivityTree(wTasks.Nodes, null, 0);
            } else {
                Widgets.BuildProjectTree(wProjects.Nodes, null, 0);
            }
            // FIXME: don't always collapse/expand all: do this intelligently
            tree.ExpandAll();
            // END WTF

            // display root lines?
            Trees_ShowRootLines();
        }

        //---------------------------------------------------------------------

        private void Action_SaveAs(int fileType)
        {
            DBI NewDatabase = new DBI(SaveAsDialog.FileName);
            File CurrentFile = new File(Database);
            File NewFile = new File(NewDatabase);

            CurrentFile.SaveAs22(NewFile);

            //Common.Info("You selected Save As Type: " + fileType.ToString());
        }

        //---------------------------------------------------------------------

        private void Action_ShortTick()
        {
            //---------------------------------------------------------
            // Short tick is once per second: it controls the animated
            // timer on the task tree node as well as updating the 
            // status bar and form window text.
            //---------------------------------------------------------

            // Calculate status and window bar display values
            if ((currentTask != null) && (timerRunning == true)) {

                // Simple increment for the one-second timer
                elapsed++;
                elapsedToday++;
                elapsedTodayAll++;

                StatusBar_Update();

                if (!isBrowsing) {
                    wDuration.Text = StatusBarItemTime.Text;
                    wStopTime.Value = DateTime.Now;
                }

                string timeToShow;
                if (options.wShowCurrent.Checked) {
                    timeToShow = StatusBarItemTime.Text;
                } else if (options.wShowToday.Checked) {
                    timeToShow = StatusBarItemTimeToday.Text;
                } else {
                    timeToShow = StatusBarItemsTimeToday.Text;
                }

                // Text = currentTaskNode.Text + " (Timer Running)";
                // Text = currentTaskNode.Text + " (" + currentProjectNode.Text + ") - " + timeToShow;
                string tmp = options.wTitleBarTemplate.Text;
                tmp = tmp.Replace("%task", "{0}");
                tmp = tmp.Replace("%project", "{1}");
                tmp = tmp.Replace("%time", "{2}");
                Text = String.Format(tmp, currentTaskNode.Text, currentProjectNode.Text, timeToShow);
                //wNotifyIcon.Text = Text;
                wNotifyIcon.Text = Common.Abbreviate(Text, 63);
            }

            // Animate the task icon
            if (timerRunning == true) {
                int currentIndex = currentTaskNode.SelectedImageIndex;
                if (currentIndex > Timekeeper.IMG_TASK_TIMER_END - 1) {
                    currentTaskNode.ImageIndex = Timekeeper.IMG_TASK_TIMER_START;
                    currentTaskNode.SelectedImageIndex = Timekeeper.IMG_TASK_TIMER_START;
                } else {
                    currentTaskNode.ImageIndex++;
                    currentTaskNode.SelectedImageIndex++;
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_LongTick()
        {
            if (timerRunning) {
                // Refresh actual time values from database to correct for drift
                elapsed = Convert.ToInt32(currentTask.Elapsed().TotalSeconds);
                elapsedToday = Convert.ToInt32(currentTask.ElapsedToday().TotalSeconds);
                elapsedTodayAll = Convert.ToInt32(Entries.ElapsedToday());
            }

            // Annoyance support: if so desired, bug the user that the timer isn't running
            DateTime now = DateTime.Now;
            TimeSpan ts = new TimeSpan(now.Ticks - timerLastRun.Ticks);
            if (options.wPromptNoTimer.Checked) {
                if (ts.TotalMinutes > (double)options.wPromptInterval.Value) {
                    if (timerRunning == false) {
                        if (wNotifyIcon.Visible) {
                            wNotifyIcon.ShowBalloonTip(30000,
                                Timekeeper.TITLE,
                                "No timer is currently running.\n\nYou can change the frequency of this notification, or disable it completly, in the Options dialog box.",
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
            if (wProjects.SelectedNode == null) {
                if (wProjects.Nodes.Count == 1) {
                    wProjects.SelectedNode = wProjects.Nodes[0];
                } else {
                    Common.Warn("No project selected.");
                    return;
                }
            }

            // Check for a currently selected task
            if (wTasks.SelectedNode == null) {
                Common.Warn("No task selected.");
                return;
            }

            // Grab instances of currently selected objects
            currentTaskNode = wTasks.SelectedNode;
            currentProjectNode = wProjects.SelectedNode;
            currentTask = (Activity)currentTaskNode.Tag;
            currentProject = (Project)currentProjectNode.Tag;

            if ((currentTask.IsFolder == true) || (currentProject.IsFolder)) {
                Common.Warn("Folders cannot be timed. Please select a task before starting the timer.");
                return;
            }

            // Now start timing
            DateTime StartTime = IsBrowserOpen() ? wStartTime.Value : DateTime.Now;
            currentTask.StartTiming(StartTime);
            currentTask.FollowedItemId = currentProject.ItemId; // FIXME: needs to work both ways

            currentEntry = new Entry(Database);
            currentEntry.ActivityId = currentTask.ItemId;
            currentEntry.ProjectId = currentProject.ItemId;
            currentEntry.StartTime = StartTime;
            currentEntry.StopTime = StartTime;
            currentEntry.Seconds = 0; // default to zero
            currentEntry.Memo = wMemo.Text;
            currentEntry.IsLocked = true;
            currentEntry.LocationId = 1;
            currentEntry.CategoryId = 1;
            currentEntry.Create();

            //currentEntry.Begin(wMemo.Text, currentTask.id, currentProject.id);

            timerShort.Enabled = true; // Are this line and the next line the same thing?
            timerRunning = true;
            timerLastRun = DateTime.Now;

            // Grab times (this is a database hit)
            elapsed = (long)currentTask.Elapsed().TotalSeconds;
            elapsedToday = (long)currentTask.ElapsedToday().TotalSeconds;
            elapsedTodayAll = (long)Entries.ElapsedToday();

            // Make any UI changes based on the timer starting
            MenuActionStartTimer.Visible = false;
            //menuActionStartAdvanced.Visible = false;
            MenuActionStopTimer.Visible = true;
            //menuActionStopAdvanced.Visible = true;

            // swap start/stop keystrokes
            // FIXME: this is a mess
            Keys saveKeys = new Keys();
            Keys saveKeysAdvanced = new Keys();
            saveKeys = MenuActionStartTimer.ShortcutKeys;
            saveKeysAdvanced = MenuActionOpenBrowser.ShortcutKeys;
            MenuActionStartTimer.ShortcutKeys = Keys.None;
            MenuActionOpenBrowser.ShortcutKeys = Keys.None;
            MenuActionStopTimer.ShortcutKeys = saveKeys;
            MenuActionCloseBrowser.ShortcutKeys = saveKeysAdvanced;
            /*
            saveKeys = menuToolControlStart.ShortcutKeys;
            menuToolControlStart.ShortcutKeys = Keys.None;
            menuToolControlStop.ShortcutKeys = saveKeys;
            */

            StatusBar_TimerStarted(wTasks.SelectedNode.Text);

            Text = wTasks.SelectedNode.Text;
            menuTasksDeleteTask.Enabled = false;
            pmenuTasksDelete.Enabled = false;
            wNotifyIcon.Text = Common.Abbreviate(Text, 63);

            menuFile.Enabled = false;
            MenuFileNew.Enabled = false;
            MenuFileOpen.Enabled = false;
            MenuFileSaveAs.Enabled = false;
            MenuFileClose.Enabled = false;
            MenuFileRecent.Enabled = false;
            MenuFileUtilities.Enabled = false;
            MenuFileExit.Enabled = false;

            if (options.wMinimizeOnUse.Checked) {
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

        //---------------------------------------------------------------------

        private void Action_StopTimer()
        {
            // Close off timer
            currentEntry.ActivityId = currentTask.ItemId;
            currentEntry.ProjectId = currentProject.ItemId;
            currentEntry.StartTime = wStartTime.Value;
            currentEntry.StopTime = IsBrowserOpen() ? wStopTime.Value : DateTime.Now;
            currentEntry.Seconds = currentTask.StopTiming();
            currentEntry.Memo = wMemo.Text;
            currentEntry.IsLocked = false;
            currentEntry.LocationId = 1;
            currentEntry.CategoryId = 1;
            currentEntry.Save();
            timerRunning = false;
            timerShort.Enabled = false;
            //timerLastRunNotified = false;

            // Clear instances of current object
            currentTask = null;
            currentProject = null;
            currentEntry = null;

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
            currentTaskNode.ImageIndex = Timekeeper.IMG_TASK;
            currentTaskNode.SelectedImageIndex = Timekeeper.IMG_TASK;

            menuTasksDeleteTask.Enabled = true;
            pmenuTasksDelete.Enabled = true;

            menuFile.Enabled = true;
            MenuFileNew.Enabled = true;
            MenuFileOpen.Enabled = true;
            MenuFileSaveAs.Enabled = true;
            MenuFileClose.Enabled = true;
            MenuFileRecent.Enabled = true;
            MenuFileUtilities.Enabled = true;
            MenuFileExit.Enabled = true;

            // As soon as the timer has stopped, we have to paint "start" mode.
            newBrowserEntry = null;

            // FIXME: stopping the timer != opening the browser
            Browser_SetupForStarting();
        }

        //---------------------------------------------------------------------

        private void Action_UpdateCalendar(TreeView tree)
        {
            // unified
            if (calendar != null) {
                Item CurrentItem = (Item)tree.SelectedNode.Tag;
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

        private void Action_UpdateDiary(string memo, DateTime entryTime, bool create)
        {
            var Diary = new Classes.Diary();

            Diary.Memo = memo;
            Diary.EntryTime = entryTime;

            if (create) {
                Diary.Create();
                Common.Info("Journal entry created.");
            } else {
                // FIXME: what was this? what that value?
                // dlg.wJumpBox.Items[dlg.wJumpBox.SelectedIndex].ToString();
                Diary.Update();
                Common.Info("Journal entry updated.");
            }
        }

        //---------------------------------------------------------------------

        private void Action_UpdateDuration(DateTime currentTime, DateTime previousTime)
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
