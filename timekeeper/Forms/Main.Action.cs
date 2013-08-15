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

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    partial class Main
    {
        // These prevent potentially infinite following
        private bool DontChangeProject = false;
        private bool DontChangeActivity = false;

        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        private void Action_ChangedProject()
        {
            // Get current project
            Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;

            // Update status bar
            if (timerRunning == false) {
                Classes.Activity Activity;
                if (ActivityTree.SelectedNode != null) {
                    Activity = (Classes.Activity)ActivityTree.SelectedNode.Tag;
                } else {
                    Activity = new Classes.Activity(this.Database);
                }
                StatusBar_Update(Project, Activity);
            }

            // Auto-follow
            if (!isBrowsing) {
            if (options.wProjectFollow.Checked) {
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

            // Update status bar
            if (timerRunning == false) {
                Classes.Project Project;
                if (ProjectTree.SelectedNode != null) {
                    Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
                } else {
                    Project = new Classes.Project(this.Database);
                }
                StatusBar_Update(Project, Activity);
            }

            // Auto-follow

            // FIXME: Can only be one other the other. This is just a rough simulation of that.
            // TODO: Here's an idea. Have a single "follow" option, but the option is only based
            // on whether that particular treeview has focus. e.g., if Project has focus then
            // Activity follows Project. If Activity has focus, then it's the other way around.

            if (!isBrowsing) {
            if (!options.wProjectFollow.Checked) {
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

                // Display the Location Manager dialog box
                Forms.LocationManager Dialog = new Forms.LocationManager();
                Dialog.ShowDialog(this);

                // Rebuild the list
                wLocation.Items.Clear();
                Classes.Widgets Widgets = new Classes.Widgets();
                Widgets.PopulateLocationComboBox(wLocation);

                // Select whatever item was selected on the dialog box
                Action_SelectItem(wLocation, Dialog.CurrentItem);

                // All done
                Dialog.Dispose();
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
                Classes.Widgets Widgets = new Classes.Widgets();
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
                // FIXME: Options overhaul is going to need two logging
                // levels. Set one for Timekeeper and one for Toolbox.DBI.
                // It might be helpful to have one set at debug and the
                // other at warn, for example.

                options.wSQLtracing.Checked = true;
                int LogLevel = Log.INFO;

                Timekeeper.Info("Opening Database: " + DatabaseFileName);
                Database = Timekeeper.OpenDatabase(DatabaseFileName, LogLevel);

                if (!Database.FileExists) {
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
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //---------------------------------------------------------------------

        private void Action_CreateFile(string fileName, FileCreateOptions createOptions)
        {
            Timekeeper.Info("Creating Database: " + fileName);

            // FIXME: a bit of doubled-up code between here and above
            int LogLevel = Log.INFO;
            Database = Timekeeper.OpenDatabase(fileName, LogLevel);

            File File = new File();
            Version Version = new Version(File.SCHEMA_VERSION);

            File.CreateOptions = createOptions;
            File.Create(Version);

            Database = Timekeeper.CloseDatabase();
        }

        //---------------------------------------------------------------------

        private void Action_CloseFile()
        {
            if (Database != null) {
                ProjectTree.Nodes.Clear();
                ActivityTree.Nodes.Clear();

                StatusBar_FileClosed();
                MenuBar_FileClosed();

                Timekeeper.Info("Closing Database: " + DatabaseFileName);
                Database = Timekeeper.CloseDatabase();

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

            // Remove item from the database
            Classes.TreeAttribute item = (Classes.TreeAttribute)tree.SelectedNode.Tag;
            long result = item.Delete();

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
            options = new Forms.OptionsLegacy(Database);
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
                Action_LoadFile();
            }

            // Initialize drag drop operations
            this.ProjectTree.ItemDrag += new ItemDragEventHandler(ProjectTree_ItemDrag);
            this.ActivityTree.ItemDrag += new ItemDragEventHandler(ActivityTree_ItemDrag);

            //----------------------------------------------
            // Extras to do at app startup, for fun
            //----------------------------------------------
            // EnumerateTimeZones();

            // short cut
            //Forms.Report Report = new Forms.Report();
            //Report.Show(this);

            // another short cut
            //Forms.Filtering FilterDialog = new Forms.Filtering();
            //FilterDialog.Show(this);

            //Common.Info("Testing TBX 3.0.0.7");
        }

        public static void EnumerateTimeZones()
        {
            try {
                string OUTPUTFILENAME = Timekeeper.GetLogPath() + ".timezones";

                DateTimeFormatInfo dateFormats = CultureInfo.CurrentCulture.DateTimeFormat;
                ReadOnlyCollection<TimeZoneInfo> timeZones = TimeZoneInfo.GetSystemTimeZones();
                StreamWriter sw = new StreamWriter(OUTPUTFILENAME, false);

                foreach (TimeZoneInfo timeZone in timeZones) {
                    bool hasDST = timeZone.SupportsDaylightSavingTime;
                    TimeSpan offsetFromUtc = timeZone.BaseUtcOffset;
                    TimeZoneInfo.AdjustmentRule[] adjustRules;
                    string offsetString;

                    sw.WriteLine("ID: {0}", timeZone.Id);
                    sw.WriteLine("   Display Name: {0, 40}", timeZone.DisplayName);
                    sw.WriteLine("   Standard Name: {0, 39}", timeZone.StandardName);
                    sw.Write("   Daylight Name: {0, 39}", timeZone.DaylightName);
                    sw.Write(hasDST ? "   ***Has " : "   ***Does Not Have ");
                    sw.WriteLine("Daylight Saving Time***");
                    offsetString = String.Format("{0} hours, {1} minutes", offsetFromUtc.Hours, offsetFromUtc.Minutes);
                    sw.WriteLine("   Offset from UTC: {0, 40}", offsetString);
                    adjustRules = timeZone.GetAdjustmentRules();
                    sw.WriteLine("   Number of adjustment rules: {0, 26}", adjustRules.Length);
                    if (adjustRules.Length > 0) {
                        sw.WriteLine("   Adjustment Rules:");
                        foreach (TimeZoneInfo.AdjustmentRule rule in adjustRules) {
                            TimeZoneInfo.TransitionTime transTimeStart = rule.DaylightTransitionStart;
                            TimeZoneInfo.TransitionTime transTimeEnd = rule.DaylightTransitionEnd;

                            sw.WriteLine("      From {0} to {1}", rule.DateStart, rule.DateEnd);
                            sw.WriteLine("      Delta: {0}", rule.DaylightDelta);
                            if (!transTimeStart.IsFixedDateRule) {
                                sw.WriteLine("      Begins at {0:t} on {1} of week {2} of {3}", transTimeStart.TimeOfDay,
                                                                                              transTimeStart.DayOfWeek,
                                                                                              transTimeStart.Week,
                                                                                              dateFormats.MonthNames[transTimeStart.Month - 1]);
                                sw.WriteLine("      Ends at {0:t} on {1} of week {2} of {3}", transTimeEnd.TimeOfDay,
                                                                                              transTimeEnd.DayOfWeek,
                                                                                              transTimeEnd.Week,
                                                                                              dateFormats.MonthNames[transTimeEnd.Month - 1]);
                            } else {
                                sw.WriteLine("      Begins at {0:t} on {1} {2}", transTimeStart.TimeOfDay,
                                                                               transTimeStart.Day,
                                                                               dateFormats.MonthNames[transTimeStart.Month - 1]);
                                sw.WriteLine("      Ends at {0:t} on {1} {2}", transTimeEnd.TimeOfDay,
                                                                             transTimeEnd.Day,
                                                                             dateFormats.MonthNames[transTimeEnd.Month - 1]);
                            }
                        }
                    }
                }
                sw.Close();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
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
                TrayIcon.Visible = true;
            } else {
                TrayIcon.Visible = false;
            }
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
            splitTrees.SplitterDistance = (int)key.GetValue("SplitTrees", 300);
            splitMain.SplitterDistance = (int)key.GetValue("SplitMain", 300);
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

            // experimental: swapping Activities/Projects (see TKT #1266)
            //this.splitTrees.Panel1.Controls.Add(this.ActivityTree);

            /*
            splitTrees.Panel1.Controls.Remove(this.ActivityTree);
            splitTrees.Panel1.Controls.Remove(this.ProjectTree);

            splitTrees.Panel1.Controls.Add(this.ProjectTree);
            splitTrees.Panel2.Controls.Add(this.ActivityTree);
            */
        }

        //---------------------------------------------------------------------

        private void Action_OpenFile(string fileName)
        {
            Action_CloseFile();
            DatabaseFileName = fileName;
            Action_LoadFile();
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
            key.SetValue("SplitTrees", splitTrees.SplitterDistance, Microsoft.Win32.RegistryValueKind.DWord);
            key.SetValue("SplitMain", splitMain.SplitterDistance, Microsoft.Win32.RegistryValueKind.DWord);
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
            // FIXME: this leaves stray entries above "i". We should probably
            // clean those up along the way.
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
            if (ProjectTree.SelectedNode != null) {
                Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
                Options.LastProjectId = Project.ItemId;
            }
            if (ActivityTree.SelectedNode != null) {
                Classes.Activity Activity = (Classes.Activity)ActivityTree.SelectedNode.Tag;
                Options.LastActivityId = Activity.ItemId;
            }
            Options.LastGridViewId = lastGridViewId;
            Options.LastReportViewId = lastReportViewId;

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

        //---------------------------------------------------------------------

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

        private bool Action_LoadFile()
        {
            try {
                if (!Action_CheckDatabase()) {
                    return false;
                }

                Widgets = new Classes.Widgets();
                Widgets.BuildProjectTree(ProjectTree.Nodes);
                Widgets.BuildActivityTree(ActivityTree.Nodes);
                Widgets.PopulateLocationComboBox(wLocation);
                Widgets.PopulateCategoryComboBox(wCategory);

                Entries = new Classes.JournalEntries(Database);
                Meta = new Classes.Meta();
                Options = new Classes.Options();

                Entry = new Classes.Journal(Database);

                MenuBar_FileOpened();
                StatusBar_FileOpened();

                Browser_Load();
                Browser_SetupForStarting();
                Browser_Show(true);

                // and save name for next Ctrl+O
                OpenFileDialog.FileName = DatabaseFileName;

                lastGridViewId = Options.LastGridViewId;
                lastReportViewId = Options.LastReportViewId;

                // Re-select last selected project
                TreeNode lastNode = Widgets.FindTreeNode(ProjectTree.Nodes, Options.LastProjectId);
                if (lastNode != null) {
                    ProjectTree.SelectedNode = lastNode;
                    ProjectTree.SelectedNode.Expand();
                }

                // Re-select last selected activity
                lastNode = Widgets.FindTreeNode(ActivityTree.Nodes, Options.LastActivityId);
                if (lastNode != null) {
                    ActivityTree.SelectedNode = lastNode;
                    ActivityTree.SelectedNode.Expand();
                }

                //------------------------------------------------------------
                // END:TODO
                //------------------------------------------------------------

                // View root lines?
                Action_TreeView_ShowRootLines();

                // View or hide the project pane
                bool useProjects = true;
                bool useActivities = true;

                Action_UseProjects(useProjects); // options.wViewProjectPane.Checked);
                Action_UseActivities(useActivities); // FIXME: Need an Option for this

                return true;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }
        }

        //--

        private void Action_UseProjects(bool show)
        {
            // Hide or Show the Project Pane
            if (splitTrees.Panel1.Contains(this.ProjectTree)) {
                splitTrees.Panel1Collapsed = !show;
            } else {
                splitTrees.Panel2Collapsed = !show;
            }
            this.ProjectsVisible = show;

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
            PopupMenuProjectSwapPanes.Enabled = this.ProjectsVisible && this.ActivitiesVisible;
            PopupMenuActivitySwapPanes.Enabled = this.ProjectsVisible && this.ActivitiesVisible;
        }

        //--

        private void Action_UseActivities(bool show)
        {
            // Hide or Show the Activity Pane
            if (splitTrees.Panel1.Contains(this.ActivityTree)) {
                splitTrees.Panel1Collapsed = !show;
            } else {
                splitTrees.Panel2Collapsed = !show;
            }
            this.ActivitiesVisible = show;

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
            PopupMenuProjectSwapPanes.Enabled = this.ProjectsVisible && this.ActivitiesVisible;
            PopupMenuActivitySwapPanes.Enabled = this.ProjectsVisible && this.ActivitiesVisible;
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
                Forms.UpgradeWizard Dialog = new Forms.UpgradeWizard();
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
            split.SplitterDistance = split.Width / 2;
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
            // timer on the activity tree node as well as updating the 
            // status bar and form window text.
            //---------------------------------------------------------

            // Calculate status and window bar display values
            if ((currentActivity != null) && (timerRunning == true)) {

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
                string timeToShow;
                if (options.wShowCurrent.Checked) {
                    timeToShow = StatusBarElapsedSinceStart.Text;
                } else if (options.wShowToday.Checked) {
                    timeToShow = StatusBarElapsedActivityToday.Text;
                } else {
                    timeToShow = StatusBarElapsedAllToday.Text;
                }

                // FIXME: add this to Widgets?
                string tmp = options.wTitleBarTemplate.Text;
                tmp = tmp.Replace("%task", "{0}"); // FIXME: take care of this later
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
                if (!isBrowsing) {
                    if (!StartTimeManuallySet) {
                        wStartTime.Value = DateTime.Now;
                        wStopTime.Value = DateTime.Now;
                    }
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_LongTick()
        {
            if (timerRunning) {
                // Refresh actual time values from database to correct for drift
                ElapsedSinceStart = Convert.ToInt32(currentActivity.Elapsed().TotalSeconds); // FIXME: CURRENT ACTIVITY?
                ElapsedProjectToday = Convert.ToInt32(currentProject.ElapsedToday().TotalSeconds);
                ElapsedActivityToday = Convert.ToInt32(currentActivity.ElapsedToday().TotalSeconds);
                ElapsedAllToday = Convert.ToInt32(Entries.ElapsedToday());
            }

            // Annoyance support: if so desired, bug the user that the timer isn't running
            DateTime now = DateTime.Now;
            TimeSpan ts = new TimeSpan(now.Ticks - timerLastRun.Ticks);
            if (options.wPromptNoTimer.Checked) {
                if (ts.TotalMinutes > (double)options.wPromptInterval.Value) {
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
                    Common.Warn("No Project selected.");
                    return;
                }
            }

            // Check for a currently selected activity
            if (ActivityTree.SelectedNode == null) {
                if (ActivityTree.Nodes.Count == 1) {
                    ActivityTree.SelectedNode = ActivityTree.Nodes[0];
                } else {
                    Common.Warn("No Activity selected.");
                    return;
                }
            }

            // Grab instances of currently selected objects
            currentProjectNode = ProjectTree.SelectedNode;
            currentActivityNode = ActivityTree.SelectedNode;
            currentProject = (Classes.Project)currentProjectNode.Tag;
            currentActivity = (Classes.Activity)currentActivityNode.Tag;

            if (wLocation.SelectedItem != null)
                currentLocation = (Classes.Location)((IdObjectPair)wLocation.SelectedItem).Object;
            if (wCategory.SelectedItem != null)
                currentCategory = (Classes.Category)((IdObjectPair)wCategory.SelectedItem).Object;

            if ((currentProject.IsFolder == true) || (currentActivity.IsFolder)) {
                Common.Warn("Folders cannot be timed. Please select an item before starting the timer.");
                return;
            }

            // Now start timing
            DateTime StartTime = IsBrowserOpen() ? wStartTime.Value : DateTime.Now;
            currentActivity.StartTiming(StartTime);
            currentActivity.FollowedItemId = currentProject.ItemId;

            currentProject.StartTiming(StartTime);
            currentProject.FollowedItemId = currentActivity.ItemId;

            //currentEntry = new Classes.Journal(Database);
            Entry.ProjectId = currentProject.ItemId;
            Entry.ActivityId = currentActivity.ItemId;
            Entry.StartTime = StartTime;
            Entry.StopTime = StartTime;
            Entry.Seconds = 0; // default to zero
            Entry.Memo = wMemo.Text;
            Entry.IsLocked = true;
            Entry.LocationId = currentLocation == null ? 0 : currentLocation.Id; // FIXME: Location should be not null.
            Entry.CategoryId = currentCategory == null ? 0 : currentCategory.Id;
            if (!Entry.Create()) {
                Common.Warn("There was an error starting the timer.");
                return;
            }

            //ShortTimer.Enabled = true; // Are this line and the next line the same thing?
            timerRunning = true;
            timerLastRun = DateTime.Now;

            // Grab times (this is a database hit)
            ElapsedSinceStart = (long)currentActivity.Elapsed().TotalSeconds;
            ElapsedProjectToday = (long)currentProject.ElapsedToday().TotalSeconds;
            ElapsedActivityToday = (long)currentActivity.ElapsedToday().TotalSeconds;
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

            StatusBar_TimerStarted(currentProjectNode.Text, currentActivityNode.Text);

            Text = currentActivity.Name;

            TrayIcon.Text = Common.Abbreviate(Text, 63);

            MenuFile.Enabled = false;
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
            // Close off the timer for both objects
            long Seconds = currentActivity.StopTiming(wStopTime.Value);
                           currentProject.StopTiming(wStopTime.Value);

            // Close off timer
            Entry.ProjectId = currentProject.ItemId;
            Entry.ActivityId = currentActivity.ItemId;
            Entry.StartTime = wStartTime.Value;
            Entry.StopTime = IsBrowserOpen() ? wStopTime.Value : DateTime.Now;
            Entry.Seconds = Seconds;
            Entry.Memo = wMemo.Text;
            Entry.IsLocked = false;
//            Entry.LocationId = currentLocation.Id;
//            Entry.CategoryId = currentCategory.Id;
            Entry.Save();
            timerRunning = false;
            //ShortTimer.Enabled = false;
            //timerLastRunNotified = false;

            // Clear instances of current object
            currentProject = null;
            currentActivity = null;
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

            MenuFile.Enabled = true;
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
            Entry.AdvanceIndex(); // FIXME: EXPERIMENTAL
        }

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
                    Classes.Activity Activity = new Classes.Activity(Database);
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
                    Classes.Project Project = new Classes.Project(Database);
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
            Classes.ProjectCollection Projects = new Classes.ProjectCollection(Database);
            ProjectTree.ShowRootLines = Projects.HasParents();

            Classes.ActivityCollection Activities = new Classes.ActivityCollection(Database);
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

        private void Action_UpdateNotebook(string memo, DateTime entryTime, bool create)
        {
            var Notebook = new Classes.Notebook();

            Notebook.Memo = memo;
            Notebook.EntryTime = entryTime;

            if (create) {
                Notebook.Create();
                Common.Info("Journal entry created.");
            } else {
                // FIXME: what was this? what that value?
                // dlg.wJumpBox.Items[dlg.wJumpBox.SelectedIndex].ToString();
                Notebook.Update();
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
