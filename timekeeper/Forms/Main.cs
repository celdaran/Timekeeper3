using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Technitivity.Toolbox;

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
        private Entries Entries;
        private Classes.Meta Meta;
        private Classes.Options Options;
        private Classes.Widgets Widgets;

        // current objects
        private Entry currentEntry;
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
        // Enumerated types
        //---------------------------------------------------------------------

        //private enum FileMode { FileOpened, FileClosed, TimerStarted, TimerStopped };
        private enum DatabaseCheckAction { NoAction, CreateIfMissing };

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
            Action_LoadFile(menuItem.Text);
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

        // Tasks | New Task
        private void menuTasksNewTask_Click(object sender, EventArgs e)
        {
            Activity task = new Activity(Database);
            Dialog_NewItem(wTasks, "New Task", false, (Item)task, Timekeeper.IMG_TASK);
        }

        // Tasks | New Task Folder
        private void menuTasksNewTaskFolder_Click(object sender, EventArgs e)
        {
            Activity task = new Activity(Database);
            Dialog_NewItem(wTasks, "New Task Folder", true, (Item)task, Timekeeper.IMG_TASK);
        }

        // Tasks | Edit Task
        private void menuTasksEdit_Click(object sender, EventArgs e)
        {
            if (wTasks.SelectedNode != null) {
                Activity task = new Activity(Database, wTasks.SelectedNode.Text);
                Dialog_EditItem(wTasks, "Edit Task", (Item)task);
            }
        }

        // Tasks | Hide Task
        private void menuTasksHideTask_Click(object sender, EventArgs e)
        {
            if (wTasks.SelectedNode != null) {
                Dialog_HideItem(wTasks, options.wViewHiddenTasks.Checked);
                MenuBar_ShowHideActivity(false);
            }
        }

        // Tasks | Unhide Task
        private void menuTasksUnhideTask_Click(object sender, EventArgs e)
        {
            if (wTasks.SelectedNode != null) {
                Action_UnhideItem(wTasks);
                MenuBar_ShowHideActivity(true);
            }
        }

        // Task | Delete Task
        private void menuTasksDeleteTask_Click(object sender, EventArgs e)
        {
            if (wTasks.SelectedNode != null) {
                Action_DeleteItem(wTasks);
            }
        }

        // Task | New Project
        private void menuTasksNewProject_Click(object sender, EventArgs e)
        {
            Project project = new Project(Database);
            Dialog_NewItem(wProjects, "New Project", false, (Item)project, Timekeeper.IMG_PROJECT);
        }

        // Task | New Project Folder
        private void menuTasksNewProjectFolder_Click(object sender, EventArgs e)
        {
            Project project = new Project(Database);
            Dialog_NewItem(wProjects, "New Project Folder", true, (Item)project, Timekeeper.IMG_PROJECT);
        }

        // Task | Edit Project
        private void menuTasksEditProject_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                Project project;
                project = new Project(Database, wProjects.SelectedNode.Text);
                Dialog_EditItem(wProjects, "Edit Project", (Item)project);
            }
        }

        // Tasks | Hide Project
        private void menuTasksHideProject_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                Dialog_HideItem(wProjects, options.wViewHiddenProjects.Checked);
                MenuBar_ShowHideProject(false);
            }
        }

        // Tasks | Unhide Project
        private void menuTasksUnhideProject_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                Action_UnhideItem(wProjects);
                MenuBar_ShowHideProject(true);
            }
        }

        // Tasks | Delete Project
        private void menuTasksDeleteProject_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                Action_DeleteItem(wProjects);
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
                Action_UpdateDiary(dlg.wEntry.Text, dlg.wEntryDate.Value, dlg.wJumpBox.SelectedIndex == -1);
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
            if (wTasks.SelectedNode != null) {
                wTasks.SelectedNode.BeginEdit();
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
            if (wTasks.SelectedNode != null) {
                Activity item = (Activity)wTasks.SelectedNode.Tag;
                Dialog_Properties((Item)item);
            }
        }

        // Popup Project | Rename
        private void pmenuProjectsRename_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                wProjects.SelectedNode.BeginEdit();
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
            if (wProjects.SelectedNode != null) {
                Project item = (Project)wProjects.SelectedNode.Tag;
                Dialog_Properties((Item)item);
            }
        }

        //---------------------------------------------------------------------
        // Keyboard events
        //---------------------------------------------------------------------

        // Task window keys
        private void wTasks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                wTasks.SelectedNode.BeginEdit();
            }
            else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(wTasks);
            }
            else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                pmenuTasksProperties_Click(sender, e);
            }
        }

        // Project window keys
        private void wProjects_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                wProjects.SelectedNode.BeginEdit();
            }
            else if (e.KeyCode == Keys.Delete) {
                Action_DeleteItem(wProjects);
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
        private void wTasks_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                wTasks.SelectedNode = wTasks.GetNodeAt(e.X, e.Y);
            }
        }

        // Ditto for tasks
        private void wProjects_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                wProjects.SelectedNode = wProjects.GetNodeAt(e.X, e.Y);
            }
        }

        // Mouse shortcut
        private void wTasks_DoubleClick(object sender, EventArgs e)
        {
            Action_StartTimer();
        }

        private void wProjects_DoubleClick(object sender, EventArgs e)
        {
            Action_StartTimer();
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

        private void wTasks_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = wTasks.SelectedNode;
            Item item = (Item)node.Tag;
            e.CancelEdit = !Action_RenameItem(node, item, e.Label);
        }

        //---------------------------------------------------------------------
        private void wProjects_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = wProjects.SelectedNode;
            Item item = (Item)node.Tag;
            e.CancelEdit = !Action_RenameItem(node, item, e.Label);
        }

        //---------------------------------------------------------------------
        // On Task Change
        //---------------------------------------------------------------------

        private void wTasks_AfterSelect(object sender, TreeViewEventArgs e)
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
            pmenuTasksSep3.Visible = hide;
            pmenuTasksShowProjects.Visible = hide;

            MenuActionSep2.Visible = show;
            menuTasksNewProject.Visible = show;
            menuTasksNewProjectFolder.Visible = show;
            menuTasksEditProject.Visible = show;
            menuTasksHideProject.Visible = show;
            menuTasksDeleteProject.Visible = show;
        }

        private void reloadTasks()
        {
            wTasks.Nodes.Clear();
            Widgets.BuildActivityTree(wTasks.Nodes, null, 0);
            wTasks.ExpandAll();
        }

        private void reloadProjects()
        {
            wProjects.Nodes.Clear();
            Widgets.BuildProjectTree(wProjects.Nodes, null, 0);
            wProjects.ExpandAll();
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

        //---------------------------------------------------------------------

    }
}