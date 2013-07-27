using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Technitivity.Toolbox;

using System.Resources;
using System.Xml;

namespace Timekeeper.Forms
{
    public partial class Main : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        // Database
        private DBI Database;
        private string DatabaseFileName;

        // Persistent dialog boxes
        private Forms.Options options;
        private fToolCalendar calendar;
        private Forms.Properties properties;

      // Other Namespace Experiments
      //private Forms.Tools.Calendar Calendar;
      //private Forms.Grid.Main
      //private Forms.Grid.Filter

        // form tracking
        private List<Form> OpenForms = new List<Form>();

        // dialog box attributes
        private int reportHeight;
        private int reportWidth;
        private string lastGridView;

        // objects
        private Classes.JournalEntries Entries;
        private Classes.Meta Meta;
        private Classes.Options Options;
        private Classes.Widgets Widgets;

        // current objects
        private Classes.Journal currentEntry;
        private Activity currentTask;
        private Project currentProject;
        private TreeNode currentTaskNode;
        private TreeNode currentProjectNode;

        // timer properties
        private bool timerRunning = false;
        private DateTime timerLastRun;
        private long elapsed;
        private long elapsedToday;
        private long elapsedTodayAll;

        //---------------------------------------------------------------------
        // Constants
        //---------------------------------------------------------------------

        const string REGKEY = "Software\\Technitivity\\Timekeeper\\3.0\\";

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Main(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0) {
                DatabaseFileName = args[0];
            }
        }

        //---------------------------------------------------------------------
        // Menu Events
        //---------------------------------------------------------------------

        // File | New
        private void MenuFileNew_Click(object sender, EventArgs e)
        {
            Dialog_NewFile();
        }

        // File | Open
        private void MenuFileOpen_Click(object sender, EventArgs e)
        {
            Dialog_OpenFile();
        }

        // File | Save As
        private void MenuFileSaveAs_Click(object sender, EventArgs e)
        {
            Dialog_SaveAsFile();
        }

        // File | Close
        private void MenuFileClose_Click(object sender, EventArgs e)
        {
            Action_CloseFile();
        }

        // File | Recent Files
        private void MenuFileRecentFile_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            Action_OpenFile(menuItem.Text);
        }

        // File | Exit
        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //---------------------------------------------------------------------

        // Action | Start Timer
        private void MenuActionStartTimer_Click(object sender, EventArgs e)
        {
            Action_StartTimer();
        }

        // Action | Stop Timer
        private void MenuActionStopTimer_Click(object sender, EventArgs e)
        {
            Action_StopTimer();
        }

        // Action | Open Browser
        private void MenuActionOpenBrowser_Click(object sender, EventArgs e)
        {
            Browser_Open();
        }

        // Action | Close Browser
        private void MenuActionCloseBrowser_Click(object sender, EventArgs e)
        {
            Browser_Close();
        }

        // Task | New Project
        private void MenuActionNewProject_Click(object sender, EventArgs e)
        {
            Project project = new Project(Database);
            Dialog_NewItem(ProjectTree, "New Project", false, (Item)project, Timekeeper.IMG_PROJECT);
        }

        // Task | New Project Folder
        private void MenuActionNewProjectFolder_Click(object sender, EventArgs e)
        {
            Project project = new Project(Database);
            Dialog_NewItem(ProjectTree, "New Project Folder", true, (Item)project, Timekeeper.IMG_PROJECT);
        }

        // Task | Edit Project
        private void MenuActionEditProject_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Project project;
                project = new Project(Database, ProjectTree.SelectedNode.Text);
                Dialog_EditItem(ProjectTree, "Edit Project", (Item)project);
            }
        }

        // Action | Hide Project
        private void MenuActionHideProject_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Dialog_HideItem(ProjectTree, options.wViewHiddenProjects.Checked);
                MenuBar_ShowHideProject(false);
            }
        }

        // Action | Unhide Project
        private void MenuActionUnhideProject_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Action_UnhideItem(ProjectTree);
                MenuBar_ShowHideProject(true);
            }
        }

        // Action | Delete Project
        private void MenuActionDeleteProject_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Action_DeleteItem(ProjectTree);
            }
        }
        // Action | New Task
        private void MenuActionNewTask_Click(object sender, EventArgs e)
        {
            Activity task = new Activity(Database);
            Dialog_NewItem(ActivityTree, "New Task", false, (Item)task, Timekeeper.IMG_TASK);
        }

        // Action | New Task Folder
        private void MenuActionNewTaskFolder_Click(object sender, EventArgs e)
        {
            Activity task = new Activity(Database);
            Dialog_NewItem(ActivityTree, "New Task Folder", true, (Item)task, Timekeeper.IMG_TASK);
        }

        // Action | Edit Task
        private void MenuActionEdit_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Activity task = new Activity(Database, ActivityTree.SelectedNode.Text);
                Dialog_EditItem(ActivityTree, "Edit Task", (Item)task);
            }
        }

        // Action | Hide Task
        private void MenuActionHideTask_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Dialog_HideItem(ActivityTree, options.wViewHiddenTasks.Checked);
                MenuBar_ShowHideActivity(false);
            }
        }

        // Action | Unhide Task
        private void MenuActionUnhideTask_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Action_UnhideItem(ActivityTree);
                MenuBar_ShowHideActivity(true);
            }
        }

        // Task | Delete Task
        private void MenuActionDeleteTask_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Action_DeleteItem(ActivityTree);
            }
        }

        //---------------------------------------------------------------------

        // Report | Grid
        private void menuReportsGrid_Click(object sender, EventArgs e)
        {
            fGrid grid = new fGrid(Database);
            grid.lastGridView = lastGridView;
            grid.Show(this);
            OpenForms.Add(grid);
            lastGridView = grid.lastGridView;
        }

        // Report | Quick List
        private void menuReportsQuick_Click(object sender, EventArgs e)
        {
            Forms.Report Report = new Forms.Report();
            Report.Show(this);

            /*
            fReport rpt = new fReport(Database, 
                options.wFontList.SelectedItem.ToString(), 
                Convert.ToInt32(options.wFontSize.Value),
                reportHeight, reportWidth);
            rpt.Show(this);
            OpenForms.Add(rpt);
            reportHeight = rpt.Height;
            reportWidth = rpt.Width;
            */
        }

        // Report | Punch Card
        private void menuReportsPunch_Click(object sender, EventArgs e)
        {
            fPunch punch = new fPunch(Database);
            punch.Show(this);
            OpenForms.Add(punch);
        }

        //---------------------------------------------------------------------

        // Tools | Control | First Entry
        private void menuToolControlFirst_Click(object sender, EventArgs e)
        {
            Browser_GotoFirstEntry();
        }

        // Tools | Control | Previous Entry
        private void menuToolControlPrev_Click(object sender, EventArgs e)
        {
            Browser_GotoPreviousEntry();
        }

        // Tools | Control | Next Entry
        private void menuToolControlNext_Click(object sender, EventArgs e)
        {
            Browser_GotoNextEntry();
        }

        // Tools | Control | Last Entry
        private void menuToolControlLast_Click(object sender, EventArgs e)
        {
            Browser_GotoLastEntry();
        }

        private void menuToolControlNew_Click(object sender, EventArgs e)
        {
            Browser_SetupForStarting();
        }

        private void menuToolControlCloseStartGap_Click(object sender, EventArgs e)
        {
            Browser_CloseStartGap();
        }

        private void menuToolControlCloseEndGap_Click(object sender, EventArgs e)
        {
            Browser_CloseStopGap();
        }

        private void menuToolControlRevert_Click(object sender, EventArgs e)
        {
            Browser_RevertEntry();
        }

        private void menuToolControlUnlock_Click(object sender, EventArgs e)
        {
            Browser_UnlockEntry();
        }

        // Tools | Log/Tweak
        private void menuToolsTweak_Click(object sender, EventArgs e)
        {
            var log = new fLog(Database);
            log.isTimerRunning = timerRunning;
            log.ShowDialog(this);
        }

        // Tools | Calendar
        private void menuToolsCalendar_Click(object sender, EventArgs e)
        {
            calendar = new fToolCalendar();
            calendar.Show(this);
            OpenForms.Add(calendar);
        }

        // Tools | Journal
        private void menuToolsJournal_Click(object sender, EventArgs e)
        {
            fToolJournal dlg = new fToolJournal(Database);
            dlg.ActiveControl = dlg.wEntry;
            if (dlg.ShowDialog(this) == DialogResult.OK && dlg.is_dirty) {
                Action_UpdateNotebook(dlg.wEntry.Text, dlg.wEntryDate.Value, dlg.wJumpBox.SelectedIndex == -1);
            }
        }

        // Tools | Stopwatch
        private void menuToolsStopwatch_Click(object sender, EventArgs e)
        {
            // FIXME: proposed namespace for tools

            // var Dialog = new Forms.Tools.Stopwatch();
            // Dialog.Show(this);
            // OpenForms.Add(Dialog);

            fToolStopwatch dlg = new fToolStopwatch();
            dlg.Show(this);
            OpenForms.Add(dlg);
        }

        // Tools | Countdown
        private void menuToolsCountdown_Click(object sender, EventArgs e)
        {
            fToolCountdown dlg = new fToolCountdown();
            dlg.ShowDialog(this);
        }

        // Tools | Date Calculator
        private void menuToolsDatecalc_Click(object sender, EventArgs e)
        {
            fToolDatecalc dlg = new fToolDatecalc();
            dlg.Show(this);
            OpenForms.Add(dlg);
        }

        // Tools | Reminders
        private void menuToolsReminders_Click(object sender, EventArgs e)
        {
            fToolReminders dlg = new fToolReminders();
            dlg.ShowDialog(this);
        }

        // Tools | Options
        private void menuToolsOptions_Click(object sender, EventArgs e)
        {
            Dialog_Options();
        }

        //---------------------------------------------------------------------

        // Help | Contents
        private void menuHelpContents_Click(object sender, EventArgs e)
        {
            Help.ShowHelpIndex(this, "timekeeper.chm");
        }

        // Help | Web Support
        private void menuHelpWeb_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "http://www.technitivity.com/timekeeper/help/?version=" + Timekeeper.VERSION);
        }

        // Help | About
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            File db = new File(Database);
            Row dbinfo = db.Info();
            fAbout dlg = new fAbout(dbinfo);
            dlg.ShowDialog(this);
        }

        //---------------------------------------------------------------------
        // Context Menu Events
        //---------------------------------------------------------------------

        // Popup Task | Rename
        private void pmenuTasksRename_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                ActivityTree.SelectedNode.BeginEdit();
            }
        }

        // Poup Task | Show Projects
        private void pmenuTasksShowProjects_Click(object sender, EventArgs e)
        {
            options.wViewProjectPane.Checked = true;
            _toggleProjects();
        }

        // Poup Task | Properties
        private void pmenuTasksProperties_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Activity item = (Activity)ActivityTree.SelectedNode.Tag;
                Dialog_Properties((Item)item);
            }
        }

        // Popup Project | Rename
        private void pmenuProjectsRename_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                ProjectTree.SelectedNode.BeginEdit();
            }
        }

        // Popup Project | Hide Pane
        private void pmenuProjectsHidePane_Click(object sender, EventArgs e)
        {
            options.wViewProjectPane.Checked = false;
            _toggleProjects();
        }

        // Popup Projects | Properties
        private void pmenuProjectsProperties_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Project item = (Project)ProjectTree.SelectedNode.Tag;
                Dialog_Properties((Item)item);
            }
        }

        //---------------------------------------------------------------------
        // Keyboard events
        //---------------------------------------------------------------------

        // Task window keys
        private void ActivityTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                ActivityTree.SelectedNode.BeginEdit();
            }
            else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(ActivityTree);
            }
            else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                pmenuTasksProperties_Click(sender, e);
            }
        }

        // Project window keys
        private void wProjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                ProjectTree.SelectedNode.BeginEdit();
            }
            else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(ProjectTree);
            }
            else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                pmenuProjectsProperties_Click(sender, e);
            }
        }

        // Memo keys
        private void wMemo_KeyDown(object sender, KeyEventArgs e)
        {
            // No matter what, whether the timer is running or not, Escape
            // is what closes the browser pane. So it's "unconditionally"
            // handled here, rather than through menu item or toolbar 
            // button shortcuts.

            if (e.KeyCode == Keys.Escape) {
                MenuActionCloseBrowser_Click(sender, e);
                //menuToolControlClose_Click(sender, e);
            }
        }

        //---------------------------------------------------------------------
        // Mouse events
        //---------------------------------------------------------------------

        // Allow right-click selection in tasks window
        private void ActivityTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                ActivityTree.SelectedNode = ActivityTree.GetNodeAt(e.X, e.Y);
            }
        }

        // Ditto for tasks
        private void wProjects_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                ProjectTree.SelectedNode = ProjectTree.GetNodeAt(e.X, e.Y);
            }
        }

        // Mouse shortcut
        private void ActivityTree_DoubleClick(object sender, EventArgs e)
        {
            Action_StartTimer();
        }

        private void wProjects_DoubleClick(object sender, EventArgs e)
        {
            Action_StartTimer();
        }

        private void splitTrees_DoubleClick(object sender, EventArgs e)
        {
            Action_ResizeSplitter();
        }

        //---------------------------------------------------------------------
        // Timer Events
        //---------------------------------------------------------------------

        private void timer_Tick(object sender, EventArgs e)
        {
            Action_ShortTick();
        }

        //---------------------------------------------------------------------
        private void timerLong_Tick(object sender, EventArgs e)
        {
            Action_LongTick();
        }

        //---------------------------------------------------------------------
        // Editing events
        //---------------------------------------------------------------------

        private void wStartTime_Leave(object sender, EventArgs e)
        {
            Action_UpdateDuration(wStartTime.Value, priorLoadedBrowserEntry.StartTime);
        }

        //---------------------------------------------------------------------

        private void wStopTime_Leave(object sender, EventArgs e)
        {
            Action_UpdateDuration(wStopTime.Value, priorLoadedBrowserEntry.StopTime);
        }

        //---------------------------------------------------------------------

        private void wDuration_Leave(object sender, EventArgs e)
        {
            Browser_UpdateTimes();
        }

        //---------------------------------------------------------------------

        private void wMemo_TextChanged(object sender, EventArgs e)
        {
            Action_EnableRevert(wMemo.Text, priorLoadedBrowserEntry.Memo);
        }

        //---------------------------------------------------------------------
        // Label-Editing Events
        //---------------------------------------------------------------------

        private void ActivityTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = ActivityTree.SelectedNode;
            Item item = (Item)node.Tag;
            e.CancelEdit = !Action_RenameItem(node, item, e.Label);
        }

        //---------------------------------------------------------------------
        private void wProjects_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = ProjectTree.SelectedNode;
            Item item = (Item)node.Tag;
            e.CancelEdit = !Action_RenameItem(node, item, e.Label);
        }

        //---------------------------------------------------------------------
        // On Task Change
        //---------------------------------------------------------------------

        private void ActivityTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Action_ChangedActivity();
        }

        //---------------------------------------------------------------------
        private void wProjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Action_ChangedProject();
        }

        //---------------------------------------------------------------------
        // Random bits
        //---------------------------------------------------------------------

        private void statusFile_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                Action_CopyFilenameToClipboard(StatusBarFileName.ToolTipText);
            }
        }

        //---------------------------------------------------------------------
        // System Tray Events
        //---------------------------------------------------------------------

        private void fMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState) {
                if (wNotifyIcon.Visible && (options.wMinimizeToTray.Checked)) {
                    Hide();
                }
            }
        }

        private void wNotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        //---------------------------------------------------------------------
        // Form Events
        //---------------------------------------------------------------------

        private void fMain_Load(object sender, EventArgs e)
        {
            Action_FormLoad();
        }

        //---------------------------------------------------------------------

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Action_FormClose();
        }

        //---------------------------------------------------------------------
        // Disable close if timer running
        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerRunning == true) {
                Common.Warn("You must stop the timer before exiting.");
                e.Cancel = true;
            } else {
                // override settings in persistent dialogs
                // TODO: no more "persistent dialog boxes" -- that should have been a red flag.
                e.Cancel = false;
            }
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private void _toggleProjects()
        {
            // TODO: this will be redone with TKT #1267
            bool show = options.wViewProjectPane.Checked;
            bool hide = !show;

            splitTrees.Panel2Collapsed = hide;
            PopupMenuActivitySep2.Visible = hide;
            PopupMenuActivityShowProjects.Visible = hide;

            MenuActionSep2.Visible = show;
            MenuActionNewProject.Visible = show;
            MenuActionNewProjectFolder.Visible = show;
            MenuActionEditProject.Visible = show;
            MenuActionHideProject.Visible = show;
            MenuActionDeleteProject.Visible = show;
        }

        private void reloadTasks()
        {
            ActivityTree.Nodes.Clear();
            Widgets.BuildActivityTree(ActivityTree.Nodes, null, 0);
            ActivityTree.ExpandAll();
        }

        private void reloadProjects()
        {
            ProjectTree.Nodes.Clear();
            Widgets.BuildProjectTree(ProjectTree.Nodes, null, 0);
            ProjectTree.ExpandAll();
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fMain\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

        //---------------------------------------------------------------------
        // Experimental Area
        //---------------------------------------------------------------------

        private void menuToolFind_Click(object sender, EventArgs e)
        {
            /*
            try {
                throw new System.ApplicationException("Doing this on purpose");
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
            */

            Forms.Report Report = new Forms.Report();
            Report.Show(this);
        }

        private void menuToolsXmlTest_Click(object sender, EventArgs e)
        {
            ResourceManager Resources = new ResourceManager("Timekeeper.Properties.Resources", typeof(File).Assembly);

            XmlDocument Presets = new XmlDocument();
            Presets.LoadXml(Resources.GetString("Item_Presets"));

            XmlNodeList PresetDefinitions = Presets.DocumentElement.GetElementsByTagName("preset");

            foreach (XmlNode Preset in PresetDefinitions) {
                XmlAttributeCollection Attributes = Preset.Attributes;
                foreach (XmlAttribute Attribute in Attributes) {
                    //Common.Info(Attribute.Name);
                }
            }

            XmlNode Foo = Presets.SelectSingleNode("/presets/preset[@name='Manager']");

            XmlNodeList Items = Foo.ChildNodes;

            XmlNode Projects = Items[0];
            XmlNode Activities = Items[1];

            foreach (XmlElement Project in Projects.ChildNodes) {

                //Common.Info(Project.Name + " = " + Project.InnerText);

                // This works, but it's positional
                XmlNode ProjectName = Project.ChildNodes.Item(0);
                XmlNode ProjectDescription = Project.ChildNodes.Item(1);
                //Common.Info(ProjectName.InnerText + ": " + ProjectDescription.InnerText);

                // This doesn't work, stupid
                /*
                string XPath = String.Format("/presets/preset/projects/{0}/", Project.Name);
                XmlNode ProjectName = Project.SelectSingleNode(XPath + "/name");
                Common.Info(ProjectName.InnerText);
                */

                // This works, but is cumbersome
                /*
                XmlNodeList ProjectAttributes = Projects.ChildNodes;
                foreach (XmlElement Tag in Project) {
                    //Common.Info(Tag.Name + " = " + Tag.InnerText);
                }
                */

            }

            foreach (XmlNode Project in Projects.ChildNodes) {

                //Common.Info(Project["name"].InnerText + ": " + Project["description"].InnerText);

                Project NewProject = new Project(Database);

                NewProject.Name = Project["name"].InnerText;
                NewProject.Description = Project["description"].InnerText;
                NewProject.IsFolder = Project["isfolder"].InnerText == "true";

                if (Project["parent"].InnerText != "") {
                    Project ParentProject = new Project(Database, Project["parent"].InnerText);
                    if (ParentProject.ItemId == 0) {
                        Timekeeper.Warn("Could not find parent item: '" + Project["parent"].InnerText + "'");
                    } else {
                        NewProject.ParentId = ParentProject.ItemId;
                    }
                }

                NewProject.Create();
            }

            /*
            Project Project = new Project(Database);

            Project.LocationId = 1;
            Project.Name = "First Project";
            Project.Description = "This Project was created in C# by my new PopulateItems() method.";
            Project.ParentId = 0;
            Project.SortOrderNo = 0;
            Project.FollowedItemId = 0;
            Project.IsFolder = false;

            Project.Create();
            */

        }

        //---------------------------------------------------------------------

    }
}