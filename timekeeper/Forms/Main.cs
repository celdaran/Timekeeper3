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

        // TreeView Panel Visibility
        private bool ProjectsVisible = false;
        private bool ActivitiesVisible = false;

        // Misc
        private bool StartTimeManuallySet = false;

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
        private Project currentProject;
        private Activity currentActivity;
        private TreeNode currentProjectNode;
        private TreeNode currentActivityNode;

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

        // Action | New Project
        private void MenuActionNewProject_Click(object sender, EventArgs e)
        {
            Project project = new Project(Database);
            Dialog_NewItem(ProjectTree, "New Project", false, (Item)project, Timekeeper.IMG_PROJECT);
        }

        // Action | New Project Folder
        private void MenuActionNewProjectFolder_Click(object sender, EventArgs e)
        {
            Project project = new Project(Database);
            Dialog_NewItem(ProjectTree, "New Project Folder", true, (Item)project, Timekeeper.IMG_PROJECT);
        }

        // Action | Edit Project
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

        // Action | New Activity
        private void MenuActionNewActivity_Click(object sender, EventArgs e)
        {
            Activity Activity = new Activity(Database);
            Dialog_NewItem(ActivityTree, "New Activity", false, (Item)Activity, Timekeeper.IMG_ACTIVITY);
        }

        // Action | New Activity Folder
        private void MenuActionNewActivityFolder_Click(object sender, EventArgs e)
        {
            Activity Activity = new Activity(Database);
            Dialog_NewItem(ActivityTree, "New Activity Folder", true, (Item)Activity, Timekeeper.IMG_ACTIVITY);
        }

        // Action | Edit Activity
        private void MenuActionEdit_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Activity Activity = new Activity(Database, ActivityTree.SelectedNode.Text);
                Dialog_EditItem(ActivityTree, "Edit Activity", (Item)Activity);
            }
        }

        // Action | Hide Activity
        private void MenuActionHideActivity_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Dialog_HideItem(ActivityTree, options.wViewHiddenTasks.Checked);
                MenuBar_ShowHideActivity(false);
            }
        }

        // Action | Unhide Activity
        private void MenuActionUnhideActivity_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Action_UnhideItem(ActivityTree);
                MenuBar_ShowHideActivity(true);
            }
        }

        // Action | Delete Activity
        private void MenuActionDeleteActivity_Click(object sender, EventArgs e)
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

        // Popup Project | Rename
        private void PopupMenuProjectRename_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                ProjectTree.SelectedNode.BeginEdit();
            }
        }

        // Popup Projects | Properties
        private void PopupMenuProjectProperties_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Project item = (Project)ProjectTree.SelectedNode.Tag;
                Dialog_Properties((Item)item);
            }
        }

        // Popup Activity | Rename
        private void PopupMenuActivityRename_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                ActivityTree.SelectedNode.BeginEdit();
            }
        }

        // Poup Activity | Properties
        private void PopupMenuActivityProperties_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Activity item = (Activity)ActivityTree.SelectedNode.Tag;
                Dialog_Properties((Item)item);
            }
        }

        //---------------------------------------------------------------------
        // Keyboard events
        //---------------------------------------------------------------------

        // Project window keys
        private void ProjectTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                ProjectTree.SelectedNode.BeginEdit();
            }
            else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(ProjectTree);
            }
            else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                PopupMenuProjectProperties_Click(sender, e);
            }
        }

        // Action window keys
        private void ActivityTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                ActivityTree.SelectedNode.BeginEdit();
            }
            else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(ActivityTree);
            }
            else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                PopupMenuActivityProperties_Click(sender, e);
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

        // Allow right-click selection in ProjectTree window
        private void ProjectTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                ProjectTree.SelectedNode = ProjectTree.GetNodeAt(e.X, e.Y);
            }
        }

        // Allow right-click selection in ActivityTree window
        private void ActivityTree_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                ActivityTree.SelectedNode = ActivityTree.GetNodeAt(e.X, e.Y);
            }
        }

        //---------------------------------------------------------------------

        // Drag and Drop: Initiate drag sequence
        private void ProjectTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void ActivityTree_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        // Drag and Drop: Set drag entry effect
        private void Tree_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Drag and Drop: Node selection on DragOver (Projects)
        private void ProjectTree_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = ProjectTree.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            ProjectTree.SelectedNode = ProjectTree.GetNodeAt(targetPoint);
        }

        // Drag and Drop: Node selection on DragOver (Activities)
        private void ActivityTree_DragOver(object sender, DragEventArgs e)
        {
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = ActivityTree.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            ActivityTree.SelectedNode = ActivityTree.GetNodeAt(targetPoint);
        }

        // Drag and Drop: Wrapper around the core drop logic
        private void ProjectTree_DragDrop(object sender, DragEventArgs e)
        {
            Action_TreeView_DragDrop(ProjectTree, sender, e);
        }

        private void ActivityTree_DragDrop(object sender, DragEventArgs e)
        {
            Action_TreeView_DragDrop(ActivityTree, sender, e);
        }

        //---------------------------------------------------------------------

        // Mouse shortcut
        private void ProjectTree_DoubleClick(object sender, EventArgs e)
        {
            Action_StartTimer();
        }

        // Mouse shortcut
        private void ActivityTree_DoubleClick(object sender, EventArgs e)
        {
            Action_StartTimer();
        }

        //---------------------------------------------------------------------

        // Center the splitter when double-clicked
        private void splitTrees_DoubleClick(object sender, EventArgs e)
        {
            Action_CenterSplitter(splitTrees);
        }

        private void splitMain_DoubleClick(object sender, EventArgs e)
        {
            Action_CenterSplitter(splitMain);
        }

        //---------------------------------------------------------------------
        // Timer Events
        //---------------------------------------------------------------------

        private void ShortTimer_Tick(object sender, EventArgs e)
        {
            Action_ShortTick();
        }

        //---------------------------------------------------------------------
        private void LongTimer_Tick(object sender, EventArgs e)
        {
            Action_LongTick();
        }

        //---------------------------------------------------------------------
        // Editing events
        //---------------------------------------------------------------------

        private void wStartTime_Leave(object sender, EventArgs e)
        {
            // FIXME: move this into Action
            StartTimeManuallySet = (wStartTime.Value != priorLoadedBrowserEntry.StartTime);
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

        private void ProjectTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = ProjectTree.SelectedNode;
            Item item = (Item)node.Tag;
            e.CancelEdit = !Action_RenameItem(node, item, e.Label);
        }

        //---------------------------------------------------------------------

        private void ActivityTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = ActivityTree.SelectedNode;
            Item item = (Item)node.Tag;
            e.CancelEdit = !Action_RenameItem(node, item, e.Label);
        }

        //---------------------------------------------------------------------
        // On Item Change
        //---------------------------------------------------------------------

        private void ProjectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Action_ChangedProject();
        }

        //---------------------------------------------------------------------

        private void ActivityTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Action_ChangedActivity();
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

        private void Main_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState) {
                if (TrayIcon.Visible && (options.wMinimizeToTray.Checked)) {
                    Hide();
                }
            }
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        //---------------------------------------------------------------------
        // Form Events
        //---------------------------------------------------------------------

        private void Main_Load(object sender, EventArgs e)
        {
            Action_FormLoad();
        }

        //---------------------------------------------------------------------

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Action_FormClose();
        }

        //---------------------------------------------------------------------
        // Disable close if timer running
        private void Main_FormClosing(object sender, FormClosingEventArgs e)
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

        private void reloadProjects()
        {
            ProjectTree.Nodes.Clear();
            Widgets.BuildProjectTree(ProjectTree.Nodes);
        }

        private void reloadActivities()
        {
            ActivityTree.Nodes.Clear();
            Widgets.BuildActivityTree(ActivityTree.Nodes);
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

        private void ProjectTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Project Project = (Project)SelectedNode.Tag;
                if (!Project.IsFolderOpened) {
                    Project.OpenFolder();
                }
            }
        }

        private void ProjectTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Project Project = (Project)SelectedNode.Tag;
                if (Project.IsFolderOpened) {
                    Project.CloseFolder();
                }
            }
        }

        private void ActivityTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Activity Activity = (Activity)SelectedNode.Tag;
                if (!Activity.IsFolderOpened) {
                    Activity.OpenFolder();
                }
            }
        }

        private void ActivityTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Activity Activity = (Activity)SelectedNode.Tag;
                if (Activity.IsFolderOpened) {
                    Activity.CloseFolder();
                }
            }
        }

        private void PopupMenuActivitySwapPanes_Click(object sender, EventArgs e)
        {
            Action_SwapPanes();
        }

        private void PopupMenuProjectSwapPanes_Click(object sender, EventArgs e)
        {
            Action_SwapPanes();
        }

        // MENU ITEM A: Projects | Use Projects
        private void PopupMenuProjectShowProjects_Click(object sender, EventArgs e)
        {
            Action_UseProjects(!PopupMenuProjectShowProjects.Checked);
        }

        // MENU ITEM B: Project | Use Activities
        private void PopupMenuProjectShowActivities_Click(object sender, EventArgs e)
        {
            Action_UseActivities(!PopupMenuProjectShowActivities.Checked);
        }

        // MENU ITEM D: Activities | Use Projects
        private void PopupMenuActivityShowProjects_Click(object sender, EventArgs e)
        {
            Action_UseProjects(!PopupMenuActivityShowProjects.Checked);
        }

        // MENU ITEM E: Activities | Use Activities
        private void PopupMenuActivityShowActivities_Click(object sender, EventArgs e)
        {
            Action_UseActivities(!PopupMenuActivityShowActivities.Checked);
        }

        private void wStartTime_Enter(object sender, EventArgs e)
        {
            // This is in anticipation that the value will change
            StartTimeManuallySet = true;
        }

        //---------------------------------------------------------------------
        // Experimental Area
        //---------------------------------------------------------------------

        // Nothing today!

        //---------------------------------------------------------------------

    }
}