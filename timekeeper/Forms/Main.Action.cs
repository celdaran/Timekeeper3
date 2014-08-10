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
        // Deferred keyboard shortcut setting
        private bool DeferShortcutAssignment = false;
        private bool IgnoreDimensionChanges = false;

        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        private void AutoFollow(long? lastId, ComboTreeBox dropdown, bool allowed)
        {
            if (allowed) {
                if (!isBrowsing) {
                    if ((lastId != null) && (lastId.Value > 0)) {
                        ComboTreeNode Node = Widgets.FindTreeNode(dropdown.Nodes, lastId.Value);
                        if (Node != null) {
                            dropdown.SelectedNode = Node;
                        }
                    }
                }
            }
        }

        private void EnsureSelections()
        {
            this.Widgets.SetDefaultNode(ProjectTreeDropdown);
            this.Widgets.SetDefaultNode(ActivityTreeDropdown);
            this.Widgets.SetDefaultNode(LocationTreeDropdown);
            this.Widgets.SetDefaultNode(CategoryTreeDropdown);
        }

        private void UpdateStatusBar()
        {
            if (timerRunning == false) {
                Classes.TreeAttribute Project = (Classes.TreeAttribute)ProjectTreeDropdown.SelectedNode.Tag;
                Classes.TreeAttribute Activity = (Classes.TreeAttribute)ActivityTreeDropdown.SelectedNode.Tag;
                Classes.TreeAttribute Location = (Classes.TreeAttribute)LocationTreeDropdown.SelectedNode.Tag;
                Classes.TreeAttribute Category = (Classes.TreeAttribute)CategoryTreeDropdown.SelectedNode.Tag;
                StatusBar_Update(Project, Activity, Location, Category);
            }
        }

        private void SetDirtyBit(Classes.TreeAttribute item, long browserItemId)
        {
            if ((isBrowsing) && (item.ItemId != browserItemId)) {
                Browser_EnableRevert(true);
            }
        }

        private void Action_ChangedProject()
        {
            if (IgnoreDimensionChanges)
                return;

            EnsureSelections();

            Classes.TreeAttribute Project = (Classes.TreeAttribute)ProjectTreeDropdown.SelectedNode.Tag;
            AutoFollow(Project.LastActivityId, ActivityTreeDropdown, Options.Behavior_Annoy_ActivityFollowsProject);

            Classes.TreeAttribute Activity = (Classes.TreeAttribute)ActivityTreeDropdown.SelectedNode.Tag;
            AutoFollow(Project.LastLocationId, LocationTreeDropdown, Options.Behavior_Annoy_LocationFollowsProject);

            Classes.TreeAttribute Location = (Classes.TreeAttribute)LocationTreeDropdown.SelectedNode.Tag;
            AutoFollow(Project.LastCategoryId, CategoryTreeDropdown, Options.Behavior_Annoy_CategoryFollowsProject);

            UpdateStatusBar();

            MenuBar_ShowHideProject(!Project.IsHidden);
            MenuBar_ShowMergeProject(Project.IsFolder);
            MenuBar_ShowDeleteProject(Project.IsDeleted);

            SetDirtyBit(Project, browserEntry.ProjectId);
        }

        //---------------------------------------------------------------------

        private void Action_ChangedActivity()
        {
            if (IgnoreDimensionChanges)
                return;

            EnsureSelections();

            Classes.TreeAttribute Activity = (Classes.TreeAttribute)ActivityTreeDropdown.SelectedNode.Tag;

            UpdateStatusBar();

            MenuBar_ShowHideActivity(!Activity.IsHidden);
            // FIXME: Activity equiv? What about our other two dimensions?
            // FIXME: Update 2014-07-23 something's definitely incomplete here...
            // It appears (at first glance) that only Projects can be merged or deleted or something.
            // Look into this.
            /*
            MenuBar_ShowMergeProject(Project.IsFolder);
            MenuBar_ShowDeleteProject(Project.IsDeleted);
            */

            SetDirtyBit(Activity, browserEntry.ActivityId);
        }

        //---------------------------------------------------------------------

        private void Action_ChangedLocation()
        {
            if (IgnoreDimensionChanges)
                return;

            EnsureSelections();

            Classes.TreeAttribute Location = (Classes.TreeAttribute)LocationTreeDropdown.SelectedNode.Tag;

            UpdateStatusBar();

            SetDirtyBit(Location, browserEntry.LocationId);
        }

        //---------------------------------------------------------------------

        private void Action_ChangedCategory()
        {
            if (IgnoreDimensionChanges)
                return;

            EnsureSelections();

            Classes.TreeAttribute Category = (Classes.TreeAttribute)CategoryTreeDropdown.SelectedNode.Tag;

            UpdateStatusBar();

            SetDirtyBit(Category, browserEntry.CategoryId);
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
                int FileCheckResult = File.Check();
                bool FileUpgraded = false;

                switch (FileCheckResult) {
                    case File.ERROR_UNEXPECTED:
                        Timekeeper.DoubleWarn("An error occurred during the database check. Cannot open file.");
                        break;

                    case File.ERROR_NEWER_VERSION_DETECTED:
                        Timekeeper.DoubleWarn("This database is from a newer version of Timekeeper. Cannot open file.");
                        break;

                    case File.ERROR_NOT_TKDB:
                        Timekeeper.DoubleWarn("This is not a Timekeeper database. File not opened.");
                        break;

                    case File.ERROR_EMPTY_DB:
                        Timekeeper.DoubleWarn("This is not a Timekeeper database. File not opened.");
                        break;

                    case File.ERROR_REQUIRES_UPGRADE:
                        if (Action_ConvertPriorVersion(File)) {
                            FileUpgraded = true;
                            Options.Layout_UseProjects = true;
                            Options.Layout_UseActivities = true;
                        }
                        break;
                }

                // Instantiate Meta data, if we're reasonably sure the meta table exists
                if ((FileCheckResult == 0) || ((FileCheckResult == File.ERROR_REQUIRES_UPGRADE) && FileUpgraded))
                    Meta = new Classes.Meta();

                // And bail if anything went wrong.
                if (FileCheckResult != 0) {
                    if (FileUpgraded) {
                        return true;
                    } else {
                        return false;
                    }
                }

                // Check for database already opened
                if ((Meta.ProcessId > 0) && (Options.Advanced_Other_WarnOpeningLockedDatabase)) {

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
                            "This database appears to be in use by another program (PID={1}, Name=\"{0}\"). Continue opening?",
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
            this.MemoEditor.Text = "";
            this.MemoEditor.Enabled = false;
            this.PanelControls.Enabled = false;
            this.BrowserToolbar.Enabled = false;

            if (Timekeeper.Database != null) {

                this.IgnoreDimensionChanges = true;

                Timekeeper.Database.BeginWork();

                Stopwatch OverallTimer = new Stopwatch();
                Timekeeper.Bench(OverallTimer);

                Stopwatch StepTimer = new Stopwatch();

                Timekeeper.Bench(StepTimer);
                ProjectTreeDropdown.Nodes.Clear();
                Timekeeper.Bench(StepTimer, "ProjectTreeDropdown.Nodes.Clear()");

                Timekeeper.Bench(StepTimer);
                ActivityTreeDropdown.Nodes.Clear();
                Timekeeper.Bench(StepTimer, "ActivityTreeDropdown.Nodes.Clear()");

                Timekeeper.Bench(StepTimer);
                LocationTreeDropdown.Nodes.Clear();
                Timekeeper.Bench(StepTimer, "LocationTreeDropdown.Nodes.Clear()");

                Timekeeper.Bench(StepTimer);
                CategoryTreeDropdown.Nodes.Clear();
                Timekeeper.Bench(StepTimer, "CategoryTreeDropdown.Nodes.Clear()");


                Timekeeper.Bench(StepTimer);
                StatusBar_FileClosed();
                Timekeeper.Bench(StepTimer, "StatusBar_FileClosed()");

                Timekeeper.Bench(StepTimer);
                MenuBar_FileClosed();
                Timekeeper.Bench(StepTimer, "MenuBar_FileClosed()");

                Timekeeper.Bench(StepTimer);
                Browser_Disable();
                Timekeeper.Bench(StepTimer, "Browser_Disable()");

                Timekeeper.Bench(StepTimer);
                Options.SaveLocal();
                Timekeeper.Bench(StepTimer, "Options.SaveLocal()");

                if (Meta != null) {
                    if (Process.GetCurrentProcess().Id == Meta.ProcessId) {
                        // Free up the file if this is the current process
                        // attempting to do the freeing.
                        Timekeeper.Bench(StepTimer);
                        Meta.MarkFree();
                        Timekeeper.Bench(StepTimer, "Meta.MarkFree()");
                    }
                }

                Timekeeper.Info("Closing Database: " + DatabaseFileName);
                Timekeeper.Bench(StepTimer);
                Timekeeper.Database.EndWork();
                Timekeeper.CloseDatabase();
                Timekeeper.Bench(StepTimer, "CloseDatabase");

                foreach (Form Form in OpenForms) {
                    Timekeeper.Bench(StepTimer);
                    Form.Close();
                    Timekeeper.Bench(StepTimer, "Form.Close() [Form Name: " + Form.Name + "]");
                }

                Timekeeper.Bench(OverallTimer, "Close Complete");

                this.IgnoreDimensionChanges = false;
            }
        }

        //---------------------------------------------------------------------

        private void Action_EnableRevert(string currentText, string previousText)
        {
            if (isBrowsing) {
                if (currentText != previousText) {
                    Browser_EnableRevert(true);
                }
            } else if (timerRunning) {
                if (currentText != previousText) {
                    // Issue #1369 starts here
                    // But it gets complicated. Passing on this until later...
                    //Browser_EnableSave(true);
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_FormClose()
        {
            this.IgnoreDimensionChanges = true;

            Browser_SaveRow();

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

                // Initialize timer
                timerLastRun = Timekeeper.LocalNow;

                // Any system-wide (i.e., not file-based) UI options
                Action_InitializeUI();

                // If DatabaseFileName not already set (via command line) then
                // get it from the MRU list.
                if (DatabaseFileName == null) {
                    if (MenuFileRecent.DropDownItems.Count > 0) {
                        DatabaseFileName = MenuFileRecent.DropDownItems[0].Text;
                    }
                }

                // Now load a file
                if (DatabaseFileName != null) {
                    Action_LoadFile();
                }

                // Set browser options
                Action_SetBrowserOptions();

                // Initialize drag drop operations
                /*
                this.ProjectTree.ItemDrag += new ItemDragEventHandler(ProjectTree_ItemDrag);
                this.ActivityTree.ItemDrag += new ItemDragEventHandler(ActivityTree_ItemDrag);
                */

                // Is the scheduler subsystem enabled?
                if (Options.Advanced_Other_DisableScheduler) {
                    // Remove from UI
                    MenuToolEvents.Visible = false;
                } else {
                    // Schedule events and reminders
                    Action_Schedule();
                    MenuToolEvents.Visible = true;
                }

                // Not until TK 3.1. Sorry...
                //Action_LoadPlugins();

                // Will this work here?
                MemoEditor.Focus();

                // Subscribe to the message event. This will allow the form to be notified whenever there's a new message.
                Timekeeper.Mailbox.HandleMessage += new EventHandler(OnHandleMessage);

                // SHORTCUTS

                /*
                Forms.Tools.Todo DialogBox = new Forms.Tools.Todo();
                DialogBox.ShowDialog(this);
                Application.Exit();
                */

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
                Forms.Shared.Schedule ScheduleDialog = new Forms.Shared.Schedule(9, Timekeeper.LocalNow);
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
        }

        //---------------------------------------------------------------------

        private void Action_AdjustControlPanel()
        {
            int Count = 0;

            if (Options.Layout_UseProjects) Count++;
            if (Options.Layout_UseActivities) Count++;
            if (Options.Layout_UseLocations) Count++;
            if (Options.Layout_UseCategories) Count++;

            if (Count < 4)
                PanelControls.Height = 122 - 27;
            else
                PanelControls.Height = 122;
        }

        private void Action_InitializeUI()
        {
            Widgets = new Classes.Widgets();

            // NOTE/TODO: Some of my "Actions" are user-initiated and
            // some are system-initiated. Consider splitting these
            // into two parts so that Action always implies a user-
            // initiated action and that "XYZ" is the other. I don't
            // have a name for it yet, obviously.

            // Instantiate any run-time only controls
            // FIXME (OR TODO): Move this (or most of this) to Classes.Widgets
            this.MemoEditor = new Forms.Shared.MemoEditor();
            this.MemoEditor.Parent = MainPanel;
            this.MemoEditor.BringToFront();
            this.MemoEditor.Dock = DockStyle.Fill;
            this.MemoEditor.MemoEntry.TextChanged += new System.EventHandler(this.wMemo_TextChanged);
            this.MemoEditor.TabIndex = 2; // grasping at straws here
            this.MemoEditor.Enabled = false;

            // Set viewability of primary components
            // FIXME: this code is repeated twice. See Main.Dialog.cs
            BrowserToolbar.Visible = Options.View_BrowserToolbar;
            PanelControls.Visible = Options.View_ControlPanel;
            MemoEditor.Visible = Options.View_MemoEditor;
            if (!MemoEditor.Visible)
                PanelControls.Dock = DockStyle.Fill;
            else
                PanelControls.Dock = DockStyle.Bottom;
            StatusBar_SetVisibility();

            // Set Main window metrics
            Left = Options.Main_Left;
            Top = Options.Main_Top;
            Width = Options.Main_Width;
            Height = Options.Main_Height;

            // Set dimension widget width
            DimensionPanel.Width = Options.Advanced_Other_DimensionWidth + 60;
            ProjectTreeDropdown.Width = Options.Advanced_Other_DimensionWidth;
            ActivityTreeDropdown.Width = Options.Advanced_Other_DimensionWidth;
            LocationTreeDropdown.Width = Options.Advanced_Other_DimensionWidth;
            CategoryTreeDropdown.Width = Options.Advanced_Other_DimensionWidth;

            // Until a file is opened, treat it as closed
            MenuBar_FileClosed();
            StatusBar_FileClosed();

            // Using Projects and/or Activities?
            Action_UseProjects(Options.Layout_UseProjects);
            Action_UseActivities(Options.Layout_UseActivities);
            Action_UseLocations(Options.Layout_UseLocations);
            Action_UseCategories(Options.Layout_UseCategories);
            Action_AdjustControlPanel();

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
            this.Widgets.SetTimeInputWidths(this);
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

            Timekeeper.Info("Timekeeper Version " + Timekeeper.VERSION + " Started");
        }

        //---------------------------------------------------------------------

        /*
        private bool Action_ManageTree(Timekeeper.Dimension dimension)
        {
            Forms.Shared.TreeAttributeManager Form = new Shared.TreeAttributeManager(dimension);
            Form.StartPosition = FormStartPosition.CenterParent;
            Form.ShowDialog(this);
            return true; // FIXME: can we make this conditional?
        }
        */

        //---------------------------------------------------------------------

        private void Action_ManageTree(Timekeeper.Dimension dimension, ComboTreeBox tree)
        {
            IgnoreDimensionChanges = true;
            this.Widgets.ManageTreeDialog(dimension, tree, this);
            IgnoreDimensionChanges = false;
        }

        //---------------------------------------------------------------------

        private bool Action_OpenFile(string fileName)
        {
            Action_CloseFile();
            DatabaseFileName = fileName;
            return Action_LoadFile();
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

                Widgets.BuildProjectTree(ProjectTreeDropdown.Nodes);
                Widgets.BuildActivityTree(ActivityTreeDropdown.Nodes);
                Widgets.BuildLocationTree(LocationTreeDropdown.Nodes);
                Widgets.BuildCategoryTree(CategoryTreeDropdown.Nodes);

                MenuBar_FileOpened();
                StatusBar_FileOpened();
                StatusBar_SetVisibility();

                Action_UseProjects(Options.Layout_UseProjects);
                Action_UseActivities(Options.Layout_UseActivities);
                Action_UseLocations(Options.Layout_UseLocations);
                Action_UseCategories(Options.Layout_UseCategories);
                Action_AdjustControlPanel();

                //------------------------------------------
                // Enable UI elements
                //------------------------------------------

                this.MemoEditor.Enabled = true;
                this.PanelControls.Enabled = true;
                this.BrowserToolbar.Enabled = true;

                //------------------------------------------
                // Prepare Browser
                //------------------------------------------

                Browser_Load();
                Browser_SetupForStarting(false);
                Browser_Enable();

                //------------------------------------------
                // Restore Prior State
                //------------------------------------------

                // Re-select last used project
                ComboTreeNode LastComboTreeNode = (ComboTreeNode)Widgets.FindTreeNode(ProjectTreeDropdown.Nodes, Options.State_LastProjectId);
                if (LastComboTreeNode != null) {
                    ProjectTreeDropdown.SelectedNode = LastComboTreeNode;
                }

                // Re-select last used activity
                LastComboTreeNode = (ComboTreeNode)Widgets.FindTreeNode(ActivityTreeDropdown.Nodes, Options.State_LastActivityId);
                if (LastComboTreeNode != null) {
                    ActivityTreeDropdown.SelectedNode = LastComboTreeNode;
                }

                // Re-select last used location
                LastComboTreeNode = (ComboTreeNode)Widgets.FindTreeNode(LocationTreeDropdown.Nodes, Options.State_LastLocationId);
                if (LastComboTreeNode != null) {
                    LocationTreeDropdown.SelectedNode = LastComboTreeNode;
                }

                // Re-select last used category
                LastComboTreeNode = (ComboTreeNode)Widgets.FindTreeNode(CategoryTreeDropdown.Nodes, Options.State_LastCategoryId);
                if (LastComboTreeNode != null) {
                    CategoryTreeDropdown.SelectedNode = LastComboTreeNode;
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

        private List<string> PluginList = new List<string>();

        private void DirSearch(string DirectoryName)
        {
            foreach (string d in Directory.GetDirectories(DirectoryName)) {
                foreach (string f in Directory.GetFiles(d)) {
                    string Extension = Path.GetExtension(f);
                    if (String.Equals(Extension, ".tkplugin", StringComparison.OrdinalIgnoreCase))
                        PluginList.Add(f);
                }
                DirSearch(d);
            }
        }

        private void Action_LoadPlugins()
        {
            // EXPERIMENTAL - NOT FOR TK 3.0 - EXPERIMENTAL

            DirectoryInfo PluginDirectory = new DirectoryInfo("Plugins");

            if (PluginDirectory.Exists)
            {
                DirSearch(PluginDirectory.FullName);

                foreach (string PluginFileName in PluginList) 
                {
                    try {
                        // Load the plugin assembly
                        Assembly PluginAssembly = Assembly.LoadFrom(PluginFileName);
                        string PluginName = Path.GetFileNameWithoutExtension(PluginFileName);
                        Type PluginType = PluginAssembly.GetType("Timekeeper.Plugins." + PluginName);
                        if (PluginType == null)
                            throw new Exception("Could not load " + PluginName);

                        // Create an instance of the plugin and add to the internal list
                        object Plugin = Activator.CreateInstance(PluginType, "en-US");
                        LoadedPlugins.Add(PluginType, Plugin);

                        // Get the user-visible (and possibly localized) plugin name
                        PropertyInfo Property = PluginType.GetProperty("Name");
                        MethodInfo NameMethod = Property.GetGetMethod();
                        string PluginUserVisibleName = (string)NameMethod.Invoke(Plugin, null);

                        // Now add to the menu
                        ToolStripMenuItem PluginMenuItem = new ToolStripMenuItem(PluginUserVisibleName);
                        PluginMenuItem.Click += new EventHandler(PluginMenuItem_Click);
                        PluginMenuItem.Tag = PluginType;
                        MenuTool.DropDownItems.Add(PluginMenuItem);

                        // All done!
                        Timekeeper.Info("Plugin " + PluginName + " loaded");
                    }
                    catch (Exception x) {
                        // Just log it and move on.
                        // Failure to load a plugin should not prevent TK from launching.
                        Timekeeper.Exception(x);
                    }
                }
            }
            else
            {
                Timekeeper.Warn("Could not find Plugin Directory: " + PluginDirectory.FullName);
            }
        }

        //----------------------------------------------------------------------

        void PluginMenuItem_Click(object sender, EventArgs e)
        {
            try {
                ToolStripMenuItem PluginMenuItem = (ToolStripMenuItem)sender;
                Type PluginType = (Type)PluginMenuItem.Tag;
                MethodInfo RunMethod = PluginType.GetMethod("Run");
                RunMethod.Invoke(LoadedPlugins[PluginType], null);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

        }

        //----------------------------------------------------------------------

        private void Action_SetBrowserOptions()
        {
            switch (Options.Behavior_BrowsePrevBy) {
                case 0: Browser_SetBrowseModePrev(ToolbarPrevEntryBrowseByEntry); break;
                case 1: Browser_SetBrowseModePrev(ToolbarPrevEntryBrowseByDay); break;
                case 2: Browser_SetBrowseModePrev(ToolbarPrevEntryBrowseByWeek); break;
                case 3: Browser_SetBrowseModePrev(ToolbarPrevEntryBrowseByMonth); break;
                case 4: Browser_SetBrowseModePrev(ToolbarPrevEntryBrowseByYear); break;
            }

            switch (Options.Behavior_BrowseNextBy) {
                case 0: Browser_SetBrowseModeNext(ToolbarNextEntryBrowseByEntry); break;
                case 1: Browser_SetBrowseModeNext(ToolbarNextEntryBrowseByDay); break;
                case 2: Browser_SetBrowseModeNext(ToolbarNextEntryBrowseByWeek); break;
                case 3: Browser_SetBrowseModeNext(ToolbarNextEntryBrowseByMonth); break;
                case 4: Browser_SetBrowseModeNext(ToolbarNextEntryBrowseByYear); break;
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
            Options.Layout_UseProjects = show;
            ProjectPanel.Visible = show;
            ProjectTreeDropdown.Enabled = show;
            MenuActionManageProjects.Visible = show;
            StatusBar_SetVisibility();
        }

        //----------------------------------------------------------------------

        private void Action_UseActivities(bool show)
        {
            Options.Layout_UseActivities = show;
            ActivityPanel.Visible = show;
            ActivityTreeDropdown.Enabled = show;
            MenuActionManageActivities.Visible = show;
            StatusBar_SetVisibility();
        }

        //----------------------------------------------------------------------

        private void Action_UseLocations(bool show)
        {
            Options.Layout_UseLocations = show;
            LocationPanel.Visible = show;
            LocationTreeDropdown.Enabled = show;
            MenuActionManageLocations.Visible = show;
            StatusBar_SetVisibility();
        }

        //----------------------------------------------------------------------

        private void Action_UseCategories(bool show)
        {
            Options.Layout_UseCategories = show;
            CategoryPanel.Visible = show;
            CategoryTreeDropdown.Enabled = show;
            MenuActionManageCategories.Visible = show;
            StatusBar_SetVisibility();
        }

        //---------------------------------------------------------------------

        private bool Action_ConvertPriorVersion(File file)
        {
            bool status = false;

            try {
                Timekeeper.Info("Database Upgrade Started");

                // Get backup file name
                string NewDataFile = GetBackupFileName();

                // Open dialog box
                Forms.Wizards.UpgradeDatabase Dialog = new Forms.Wizards.UpgradeDatabase();
                Dialog.BackUpFileLabel.Text = NewDataFile;
                Dialog.FileToUpgrade = file;
                //Dialog.StepLabel.Text = "Click the Start button to begin the database upgrade...";
                if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                    status = true;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
            finally {
                Timekeeper.Info("Database Upgrade Completed (Status: " + status.ToString() + ")");
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

            Cursor.Current = Cursors.WaitCursor;

            //Common.Info("You selected Save As Type: " + fileType.ToString());
            switch (fileType) {
                case 1: 
                    // Save as Version 3.0
                    CurrentFile.SaveAs30(NewFile);
                    break;
                case 2:
                    // Save as Version 2.3
                    CurrentFile.SaveAs23(NewFile);
                    break;
                case 3:
                    // Save as Version 2.2
                    CurrentFile.SaveAs22(NewFile);
                    break;
                case 4:
                    // Save as Version 2.1
                    CurrentFile.SaveAs21(NewFile);
                    break;
                case 5:
                    // Save as Version 2.0
                    CurrentFile.SaveAs20(NewFile);
                    break;
            }

            Cursor.Current = Cursors.Default;
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
                ElapsedLocationToday++;
                ElapsedCategoryToday++;
                ElapsedAllToday++;

                StatusBar_Update();

                if (!isBrowsing) {
                    DurationBox.Text = StatusBarElapsedSinceStart.Text;
                    StopTimeSelector.Value = Timekeeper.LocalNow.DateTime;
                }

                // FIXME: More Options Overhaul
                string timeToShow = "";
                switch (Options.Behavior_TitleBar_Time) {
                    case 0: timeToShow = StatusBarElapsedSinceStart.Text; break;
                    case 1: timeToShow = StatusBarElapsedProjectToday.Text; break;
                    case 2: timeToShow = StatusBarElapsedActivityToday.Text; break;
                    case 3: timeToShow = StatusBarElapsedLocationToday.Text; break;
                    case 4: timeToShow = StatusBarElapsedCategoryToday.Text; break;
                    case 5: timeToShow = StatusBarElapsedAllToday.Text; break;
                }

                // FIXME: add this to Widgets?
                // FIXME: I liked this updating-in-real-time feature (when it was directly accessing: options.wTitleBarTemplate.Text)
                string tmp = Options.Behavior_TitleBar_Template;
                tmp = tmp.Replace("%project", "{0}");
                tmp = tmp.Replace("%activity", "{1}");
                tmp = tmp.Replace("%location", "{2}");
                tmp = tmp.Replace("%category", "{3}");
                tmp = tmp.Replace("%time", "{4}");
                Text = String.Format(tmp, TimedProject.Name, TimedActivity.Name, TimedLocation.Name, TimedCategory.Name, timeToShow);
                TrayIcon.Text = Common.Abbreviate(Text, 63);
            }

            // Animate the selected item icons
            /*
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
            */

            if (timerRunning == false) {
                if (!isBrowsing && (browserEntry != null)) {
                    if (!StartTimeManuallySet) {
                        StartTimeSelector.Value = Timekeeper.LocalNow.DateTime;
                        StopTimeSelector.Value = Timekeeper.LocalNow.DateTime;
                    } else {
                        StopTimeSelector.Value = Timekeeper.LocalNow.DateTime;
                    }
                    DurationBox.Text = Browser_CalculateDuration();
                }
            }
        }

        //---------------------------------------------------------------------

        private void Action_LongTick()
        {
            try {
                // Refresh actual time values from database to correct for drift
                if (timerRunning) {
                    ElapsedSinceStart = Convert.ToInt32(TimedProject.Elapsed().TotalSeconds);
                    ElapsedProjectToday = Convert.ToInt32(TimedProject.ElapsedToday().TotalSeconds);
                    ElapsedActivityToday = Convert.ToInt32(TimedActivity.ElapsedToday().TotalSeconds);
                    ElapsedLocationToday = Convert.ToInt32(TimedLocation.ElapsedToday().TotalSeconds);
                    ElapsedCategoryToday = Convert.ToInt32(TimedCategory.ElapsedToday().TotalSeconds);
                    ElapsedAllToday = Convert.ToInt32(Entries.ElapsedToday());
                }

                // Annoyance support: if so desired, bug the user that the timer isn't running
                DateTimeOffset now = Timekeeper.LocalNow;
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
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void GetDimensions()
            // experimental helper
        {
            // Ensure we have items selected
            EnsureSelections();

            // Grab instances of currently selected objects
            TimedProject = (Classes.TreeAttribute)ProjectTreeDropdown.SelectedNode.Tag;
            TimedActivity = (Classes.TreeAttribute)ActivityTreeDropdown.SelectedNode.Tag;
            TimedLocation = (Classes.TreeAttribute)LocationTreeDropdown.SelectedNode.Tag;
            TimedCategory = (Classes.TreeAttribute)CategoryTreeDropdown.SelectedNode.Tag;

            // Set the "Last" versions of each
            Options.State_LastProjectId = TimedProject.ItemId;
            Options.State_LastActivityId = TimedActivity.ItemId;
            Options.State_LastLocationId = TimedLocation.ItemId;
            Options.State_LastCategoryId = TimedCategory.ItemId;
        }

        //---------------------------------------------------------------------

        private void ReleaseDimensions()
        {
            if (timerRunning)
                return;

            TimedProject = null;
            TimedActivity = null;
            TimedLocation = null;
            TimedCategory = null;
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

            // Get current dimension selections
            GetDimensions();

            // Now start timing
            DateTime StartTime = StartTimeSelector.Value;

            TimedProject.StartTiming(StartTime);
            TimedActivity.StartTiming(StartTime);
            TimedLocation.StartTiming(StartTime);
            TimedCategory.StartTiming(StartTime);

            TimedEntry = new Classes.JournalEntry(); // reinstantiate this entry upon timer start
            TimedEntry.StartTime = StartTime;
            TimedEntry.StopTime = StartTime;
            TimedEntry.Seconds = 0;
            TimedEntry.Memo = MemoEditor.Text;
            TimedEntry.ProjectId = TimedProject.ItemId;
            TimedEntry.ActivityId = TimedActivity.ItemId;
            TimedEntry.LocationId = TimedLocation.ItemId;
            TimedEntry.CategoryId = TimedCategory.ItemId;
            TimedEntry.IsLocked = true;
            if (TimedEntry.Create()) {
                browserEntry.JournalId = TimedEntry.JournalId;
            } else {
                Common.Warn("There was an error starting the timer.");
                return;
            }

            timerRunning = true;
            timerLastRun = Timekeeper.LocalNow;

            // Grab times (this is a database hit)
            ElapsedSinceStart = (long)TimedActivity.Elapsed().TotalSeconds; // WTF? FIXME: TimedActivity???
            ElapsedProjectToday = (long)TimedProject.ElapsedToday().TotalSeconds;
            ElapsedActivityToday = (long)TimedActivity.ElapsedToday().TotalSeconds;
            ElapsedLocationToday = (long)TimedLocation.ElapsedToday().TotalSeconds;
            ElapsedCategoryToday = (long)TimedCategory.ElapsedToday().TotalSeconds;
            ElapsedAllToday = (long)Entries.ElapsedToday() + ElapsedSinceStart;

            // Make any UI changes based on the timer starting
            MenuActionStartTimer.Visible = false;
            MenuActionStopTimer.Visible = true;

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

            StatusBar_TimerStarted(
                TimedProject.Name, TimedActivity.Name,
                TimedLocation.Name, TimedCategory.Name);

            Action_SetMenuAvailability(MenuFile, false);

            if (Options.Behavior_Window_MinimizeOnUse) {
                if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                    // Shift key temporarily overrides the minimize-on-use option
                } else {
                    WindowState = FormWindowState.Minimized;
                }
            }

            // As soon as the timer has started, we have to paint "stop" mode.
            Browser_SetupForStopping();
        }

        //---------------------------------------------------------------------

        private void Action_StopTimer()
        {
            // Close off the timer for both objects
            DateTime StartTime = StartTimeSelector.Value;
            DateTime StopTime = StopTimeSelector.Value;

            long Seconds =
                TimedProject.StopTiming(StopTime);
                TimedActivity.StopTiming(StopTime);
                TimedLocation.StopTiming(StopTime);
                TimedCategory.StopTiming(StopTime);

            // Get current dimension selections
            // Note: they may have changed while the timer was running,
            // that's why we're getting them again
            GetDimensions();

            // Close off timer
            TimedEntry.StartTime = StartTime;
            TimedEntry.StopTime = StopTime;
            TimedEntry.Seconds = Seconds;
            TimedEntry.Memo = MemoEditor.Text;
            TimedEntry.ProjectId = TimedProject.ItemId;
            TimedEntry.ActivityId = TimedActivity.ItemId;
            TimedEntry.LocationId = TimedLocation.ItemId;
            TimedEntry.CategoryId = TimedCategory.ItemId;
            TimedEntry.IsLocked = false;
            TimedEntry.Save();

            timerRunning = false;

            // Clear instances of current object
            ReleaseDimensions();

            // Make any UI changes 
            Text = Timekeeper.TITLE;

            MenuActionStartTimer.Visible = true;
            MenuActionStopTimer.Visible = false;

            StatusBar_TimerStopped();

            // swap start/stop keystrokes
            // FIXME: this is a mess
            Keys saveKeys = new Keys();
            saveKeys = MenuActionStopTimer.ShortcutKeys;
            MenuActionStopTimer.ShortcutKeys = Keys.None;
            MenuActionStartTimer.ShortcutKeys = saveKeys;

            Action_SetMenuAvailability(MenuFile, true);

            // As soon as the timer has stopped, we have to paint "start" mode.
            newBrowserEntry = null;

            // FIXME: stopping the timer != opening the browser
            Browser_SetupForStarting(false);

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
                Browser_FormToEntry(ref browserEntry, browserEntry.JournalId);
                browserEntry.StopTime = browserEntry.StartTime.AddTicks(ChunkSize);
                browserEntry.Seconds = ChunkSizeInSeconds;
                browserEntry.Save();
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

                // Copy the last-created split entry back to the browser
                browserEntry = SplitEntry.Copy();
                Browser_EntryToForm(browserEntry);
            }
            catch (Exception x) {
                Common.Warn("There was a problem splitting the entry");
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Action_UpdateDuration(DateTimeOffset currentTime, DateTimeOffset previousTime)
        {
            if (isBrowsing) {
                if ((currentTime != previousTime) || (ToolbarRevert.Enabled)) {
                    Browser_UpdateDurationBox();
                    Browser_EnableRevert(true);
                    Browser_DetermineStartGapState();
                    Browser_DetermineStopGapState();
                }
            }
        }

        //---------------------------------------------------------------------

    }
}
