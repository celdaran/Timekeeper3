using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

using Technitivity.Toolbox;

namespace Timekeeper
{
    public partial class fMain : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        // data properties
        private DBI data;
        private string dataFile;

        // persistent dialog boxes
        private fOptions options;
        private fToolCalendar calendar;
        private fProperties properties;

        // form tracking
        private List<Form> openForms = new List<Form>();

        // dialog box attributes
        private int reportHeight;
        private int reportWidth;
        private string lastGridView;

        // objects
        private Tasks tasks;
        private Projects projects;

        // current objects
        private Entry currentEntry;
        private Task currentTask;
        private Project currentProject;
        private TreeNode currentTaskNode;
        private TreeNode currentProjectNode;
        private TreeNode draggingNode;

        // Browser Objects
        private Entry browserEntry;
        private Entry priorLoadedBrowserEntry;
        private Entry newBrowserEntry;
        private bool isBrowsing = false;

        // timer properties
        private bool timerRunning = false;
        private DateTime timerLastRun;
        private long elapsed;
        private long elapsedToday;
        private long elapsedTodayAll;

        // dev-only helper settings
        private bool suppressAnnotationDialogs = true;

        // miscellaneous internals
        private DateTime annotateStartTime;
        //private bool suppressBrowserDisplay = false;

        //---------------------------------------------------------------------
        // Constants
        //---------------------------------------------------------------------

        const string REGKEY = "Software\\Technitivity\\Timekeeper\\3.0\\";

        const int IMG_FOLDER_OPEN = 0;
        const int IMG_FOLDER_CLOSED = 1;
        const int IMG_PROJECT = 2;
        const int IMG_TASK = 3;
        const int IMG_TASK_TIMER_START = 4;
        const int IMG_TASK_TIMER_END = 7;
        const int IMG_TASK_HIDDEN = 8; // UNUSED

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public fMain(string[] args)
        {
            InitializeComponent();
            if (args.Length > 0) {
                dataFile = args[0];
            }
        }

        //---------------------------------------------------------------------
        // Menu Events
        //---------------------------------------------------------------------

        // File | New
        private void menuFileNew_Click(object sender, EventArgs e)
        {
            if (dlgNew.ShowDialog(this) == DialogResult.OK) {
                closeFile();
                dataFile = dlgNew.FileName;
                loadFile(true);
            }
        }

        // File | Open
        private void menuFileOpen_Click(object sender, EventArgs e)
        {
            if (dlgOpen.ShowDialog(this) == DialogResult.OK) {
                closeFile();
                dataFile = dlgOpen.FileName;
                loadFile(false);
            }
        }

        // File | Close
        private void menuFileClose_Click(object sender, EventArgs e)
        {
            closeFile();
        }

        // File | Recent Files
        private void menuFileRecentFile_Click(object sender, EventArgs e)
        {
            closeFile();
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            dataFile = menuItem.Text;
            loadFile(false);
        }

        // File | Exit
        private void menuFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        //---------------------------------------------------------------------

        // Action | Start Timer
        private void menuActionStart_Click(object sender, EventArgs e)
        {
            //suppressBrowserDisplay = true;
            StartTimer();
        }

        // Action | Stop Timer
        private void menuActionStop_Click(object sender, EventArgs e)
        {
            StopTimer();
            //suppressBrowserDisplay = false;
        }

        // Action | Annotate and Start Timer
        // FIXME: rename these "advanced" things . . . not what they are any more (just simple open/close browser)
        private void menuActionStartAdvanced_Click(object sender, EventArgs e)
        {
            // Menu Mucking
            /* this should be handled in the ResetBrowserForX() methods
            menuActionStartAdvanced.Visible = false;
            menuActionStopAdvanced.Visible = true;
            */

            ShowBrowser(true);

            if (timerRunning) {
                ResetBrowserForStopping(true);
            } else {
                //ResetBrowserForStarting(true);
            }
        }

        // Action | Annotate and Stop Timer
        private void menuActionStopAdvanced_Click(object sender, EventArgs e)
        {
            CloseBrowser();

            // NO MORE: this is simple open/close, not advanced start/stop
            //ResetBrowserForStopping(true); 

            // This can be used for quick & annotated, but once annotated,
            // we disable quick mode by no longer suppressing the browser.
            //suppressBrowserDisplay = false; 
        }

        // Tasks | New Task
        private void menuTasksNewTask_Click(object sender, EventArgs e)
        {
            Task task = new Task(data);
            dlgItemNew(wTasks, "New Task", false, (Item)task, IMG_TASK);
        }

	    // Tasks | New Task Folder
        private void menuTasksNewTaskFolder_Click(object sender, EventArgs e)
        {
            Task task = new Task(data);
            dlgItemNew(wTasks, "New Task Folder", true, (Item)task, IMG_TASK);
        }

        // Tasks | Edit Task
        private void menuTasksEdit_Click(object sender, EventArgs e)
        {
            if (wTasks.SelectedNode != null) {
                Task task;
                task = new Task(data, wTasks.SelectedNode.Text);
                dlgItemEdit(wTasks, "Edit Task", (Item)task);
            }
        }

        // Tasks | Hide Task
        private void menuTasksHideTask_Click(object sender, EventArgs e)
        {
            if (wTasks.SelectedNode != null) {
                hideItem(wTasks, options.wViewHiddenTasks.Checked);
                _setHideTaskMenuVisibility(false);
            }
        }

        // Tasks | Unhide Task
        private void menuTasksUnhideTask_Click(object sender, EventArgs e)
        {
            if (wTasks.SelectedNode != null) {
                unhideItem(wTasks);
                _setHideTaskMenuVisibility(true);
            }
        }

        // Task | Delete Task
        private void menuTasksDeleteTask_Click(object sender, EventArgs e)
        {
            if (wTasks.SelectedNode != null) {
                deleteItem(wTasks);
            }
        }

        // Task | New Project
        private void menuTasksNewProject_Click(object sender, EventArgs e)
        {
            Project project = new Project(data);
            dlgItemNew(wProjects, "New Project", false, (Item)project, IMG_PROJECT);
        }

        // Task | New Project Folder
        private void menuTasksNewProjectFolder_Click(object sender, EventArgs e)
        {
            Project project = new Project(data);
            dlgItemNew(wProjects, "New Project Folder", true, (Item)project, IMG_PROJECT);
        }

        // Task | Edit Project
        private void menuTasksEditProject_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                Project project;
                project = new Project(data, wProjects.SelectedNode.Text);
                dlgItemEdit(wProjects, "Edit Project", (Item)project);
            }
        }

        // Tasks | Hide Project
        private void menuTasksHideProject_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                hideItem(wProjects, options.wViewHiddenProjects.Checked);
                _setHideProjectMenuVisibility(false);
            }
        }

        // Tasks | Unhide Project
        private void menuTasksUnhideProject_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                unhideItem(wProjects);
                _setHideProjectMenuVisibility(true);
            }
        }

        // Tasks | Delete Project
        private void menuTasksDeleteProject_Click(object sender, EventArgs e)
        {
            if (wProjects.SelectedNode != null) {
                deleteItem(wProjects);
            }
        }

        //---------------------------------------------------------------------

        // Report | Grid
        private void menuReportsGrid_Click(object sender, EventArgs e)
        {
            fGrid grid = new fGrid(data);
            grid.lastGridView = lastGridView;
            grid.Show(this);
            openForms.Add(grid);
            lastGridView = grid.lastGridView;
        }

        // Report | Quick List
        private void menuReportsQuick_Click(object sender, EventArgs e)
        {
            fReport rpt = new fReport(data, 
                options.wFontList.SelectedItem.ToString(), 
                Convert.ToInt32(options.wFontSize.Value),
                reportHeight, reportWidth);
            rpt.Show(this);
            openForms.Add(rpt);
            reportHeight = rpt.Height;
            reportWidth = rpt.Width;
        }

        // Report | Punch Card
        private void menuReportsPunch_Click(object sender, EventArgs e)
        {
            fPunch punch = new fPunch(data);
            punch.Show(this);
            openForms.Add(punch);
        }

        //---------------------------------------------------------------------

/*
        // Tools | Browse Entries
        private void menuToolBrowse_Click(object sender, EventArgs e)
        {
            if (menuToolBrowse.Checked) {
                CloseBrowser();
            } else {
                OpenLogForBrowsing();
            }
        }

        // Tools | Control | Start
        private void menuToolControlStart_Click(object sender, EventArgs e)
        {
            StartTimer();
        }

        // Tools | Control | Stop
        private void menuToolControlStop_Click(object sender, EventArgs e)
        {
            StopTimer();
            //CloseBrowser(); // FIXME: I'm now thinking this should be optional, I may just leave it open all the time, now that I can
        }

        private void menuToolControlClose_Click(object sender, EventArgs e)
        {
            CloseBrowser();
        }
*/

        // Tools | Control | First Entry
        private void menuToolControlFirst_Click(object sender, EventArgs e)
        {
            try {
                SaveRow(false);
                browserEntry.LoadFirst();
                priorLoadedBrowserEntry = browserEntry.Copy();
                if (browserEntry.EntryId > 0) {
                    DisplayRow();
                    EnableLast(true);
                    EnableNext(true);
                    EnableFirst(false);
                    EnablePrev(false);
                    isBrowsing = true;
                }
            }
            catch {
                // FIXME: watch this kind of "error handling"
            }
        }

        // Tools | Control | Previous Entry
        private void menuToolControlPrev_Click(object sender, EventArgs e)
        {
            try {
                if (!isBrowsing) {
                    // If we're not browsing, this is a new row. If it's a new
                    // row, save it so we don't lose it later.
                    FormToEntry(ref newBrowserEntry, 0);
                }

                SaveRow(false);
                browserEntry.LoadPrevious();
                priorLoadedBrowserEntry = browserEntry.Copy();
                if (browserEntry.EntryId > 0) {
                    DisplayRow();
                    EnableLast(true);
                    EnableNext(true);
                    if (browserEntry.AtBeginning()) {
                        EnableFirst(false);
                        EnablePrev(false);
                    }
                    if (browserEntry.AtEnd()) {
                        EnableNext(false);
                        EnableLast(false);
                    }
                    isBrowsing = true;
                } else {
                    EnableFirst(false);
                    EnablePrev(false);
                }
            }
            catch {
            }
        }

        // Tools | Control | Next Entry
        private void menuToolControlNext_Click(object sender, EventArgs e)
        {
            try {
                SaveRow(false);
                browserEntry.LoadNext();
                priorLoadedBrowserEntry = browserEntry.Copy();
                if (browserEntry.EntryId > 0) {
                    DisplayRow();
                    EnableFirst(true);
                    EnablePrev(true);
                    if (browserEntry.AtEnd()) {
                        EnableLast(false);
                        EnableNext(false);
                        if (timerRunning) {
                            //Common.Info("special handling here");
                            ResetBrowserForStopping(false);
                        }
                    }
                    isBrowsing = true;
                } else {
                    EnableLast(false);
                    EnableNext(false);
                }
            }
            catch {
            }
        }

        // Tools | Control | Last Entry
        private void menuToolControlLast_Click(object sender, EventArgs e)
        {
            try {
                SaveRow(false);
                browserEntry.LoadLast();
                priorLoadedBrowserEntry = browserEntry.Copy();
                if (browserEntry.EntryId > 0) {
                    DisplayRow();
                    EnableFirst(true);
                    EnablePrev(true);
                    EnableLast(false);
                    EnableNext(false);
                    isBrowsing = true;
                }
                if (timerRunning) {
                    ResetBrowserForStopping(false);
                }
            }
            catch {
            }
        }

        private void menuToolControlNew_Click(object sender, EventArgs e)
        {
            ResetBrowserForStarting(true);
        }

        private void menuToolControlCloseStartGap_Click(object sender, EventArgs e)
        {
            try {
                // Update the control with previous end time
                DateTime PreviousEndTime = GetPreviousEndTime();
                if (PreviousEndTime == DateTime.MinValue) {
                    // something went wrong, do nothing
                } else {
                    wStartTime.Value = PreviousEndTime;
                }

                // Recalculate duration
                wDuration.Text = _calculateDuration();

                // Disable button (already done)
                EnableCloseStartGap(false);

                // Enable revert
                EnableRevert(true);
            }
            catch {
                Common.Info("Could not get previous row.");
            }
        }

        private void menuToolControlCloseEndGap_Click(object sender, EventArgs e)
        {
            try {
                // Set next start date
                DateTime NextStartTime = GetNextStartTime();
                if (NextStartTime == DateTime.MinValue) {
                    // something went wrong, set it to now
                    wStopTime.Value = DateTime.Now;
                } else {
                    wStopTime.Value = NextStartTime;
                }

                // And recalculate duration
                wDuration.Text = _calculateDuration();

                // Enable revert
                EnableRevert(true);
            }
            catch {
                Common.Info("Could not find next row.");
            }
        }

        private void menuToolControlRevert_Click(object sender, EventArgs e)
        {
            // FIXME: maybe prompt for confirmation?

            // Copy the prior entry to the form
            EntryToForm(priorLoadedBrowserEntry);

            // Copy the prior entry to our internal representation
            browserEntry = priorLoadedBrowserEntry.Copy();

            // Now display the row (which also handles toolbar button states)
            DisplayRow();
        }

        private void menuToolControlUnlock_Click(object sender, EventArgs e)
        {
            browserEntry.IsLocked = false;
            browserEntry.Save();
            DisplayRow();
        }

        // Tools | Log/Tweak
        private void menuToolsTweak_Click(object sender, EventArgs e)
        {
            var log = new fLog(data);
            log.isTimerRunning = timerRunning;
            log.ShowDialog(this);
        }

        // Tools | Calendar
        private void menuToolsCalendar_Click(object sender, EventArgs e)
        {
            calendar = new fToolCalendar();
            calendar.Show(this);
            openForms.Add(calendar);
        }

        // Tools | Journal
        private void menuToolsJournal_Click(object sender, EventArgs e)
        {
            fToolJournal dlg = new fToolJournal(data);
            dlg.ActiveControl = dlg.wEntry;
            if (dlg.ShowDialog(this) == DialogResult.OK && dlg.is_dirty)
            {
                Row row = new Row();

                row["description"] = dlg.wEntry.Text;
                row["timestamp_m"] = Common.Now();

                if (dlg.wJumpBox.SelectedIndex == -1) {
                    row["timestamp_entry"] = dlg.wEntryDate.Value.ToString(Common.DATE_FORMAT);
                    row["timestamp_c"] = Common.Now();
                    data.Insert("journal", row);
                    Common.Info("Journal entry created.");
                } else {
                    string timestamp_c = dlg.wJumpBox.Items[dlg.wJumpBox.SelectedIndex].ToString();
                    data.Update("journal", row, "timestamp_c", timestamp_c);
                    Common.Info("Journal entry updated.");
                }
            }
        }

        // Tools | Stopwatch
        private void menuToolsStopwatch_Click(object sender, EventArgs e)
        {
            fToolStopwatch dlg = new fToolStopwatch();
            dlg.Show(this);
            openForms.Add(dlg);
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
            openForms.Add(dlg);
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
            bool prevViewHiddenTasks = options.wViewHiddenTasks.Checked;
            bool prevViewHiddenProjects = options.wViewHiddenProjects.Checked;

            options.ShowDialog(this);
            if (options.saved) {
                try {
                    // view or hide projects pane
                    _toggleProjects();

                    // view or hide status bar items
                    statusMain.Visible = options.wViewStatusBar.Checked;
                    statusCurrentTask.Visible = options.wViewCurrentTask.Checked;
                    statusTimeCurrent.Visible = options.wViewElapsedCurrent.Checked;
                    statusTimeToday.Visible = options.wViewElapsedOne.Checked;
                    statusTimeAll.Visible = options.wViewElapsedAll.Checked;
                    statusFile.Visible = options.wViewOpenedFile.Checked;

                    // window metrics
                    switch (options.wProfile.Text)
                    {
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
                            if (Width < 365)
                            {
                                Width = 365;
                            }
                            if (Height < 127)
                            {
                                Height = 127;
                            }
                            //splitContainer1.SplitterDistance = 450;
                            break;
                        default:
                            break;
                    }

                    // system try icon?
                    if (options.wShowInTray.Checked)
                    {
                        wNotifyIcon.Visible = true;
                    }
                    else
                    {
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
                        foreach (ToolStripMenuItem item in menuMain.Items.Find(function.Text, true)) {
                            item.ShortcutKeys = (Keys)function.ImageIndex;
                        }
                    }
                }
                catch {
                    Common.Warn("There was a problem applying options.");
                }
            }
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
            Database db = new Database(data);
            Row dbinfo = db.info();
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
                Task item = (Task)wTasks.SelectedNode.Tag;
                ShowProperties((Item)item);
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
                ShowProperties((Item)item);
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
                deleteItem(wTasks);
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
                deleteItem(wProjects);
            }
            else if ((e.KeyCode == Keys.Enter) && (e.Modifiers == Keys.Alt)) {
                pmenuProjectsProperties_Click(sender, e);
            }
        }

        // Memo keys
        private void wMemo_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control && e.KeyCode == Keys.I) {
                Common.Info("You pressed Ctrl+I");
                e.SuppressKeyPress = true;
                e.Handled = true;
            }
            */

            // No matter what, whether the timer is running or not, Escape
            // is what closes the browser pane. So it's "unconditionally"
            // handled here, rather than through menu item or toolbar 
            // button shortcuts.

            if (e.KeyCode == Keys.Escape) {
                menuActionStopAdvanced_Click(sender, e);
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
            StartTimer();
        }

        //---------------------------------------------------------------------
        // Timer Events
        //---------------------------------------------------------------------

        // FIXME: where should this live?
        private long ConvertToSeconds(string time)
        {
            string[] parts = time.Split(':');
            // todo: support partial parts (one part => ss, two => mm:ss ...)
            // error handling would be nice too (e.g., four parts!?)
            long h = Convert.ToInt32(parts[0]) * 3600;
            long m = Convert.ToInt32(parts[1]) * 60;
            long s = Convert.ToInt32(parts[2]);
            return h + m + s;
        }

        private void timer_Tick(object sender, EventArgs e)
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

                statusTimeCurrent.Text = Timekeeper.FormatSeconds(elapsed);
                statusTimeToday.Text = Timekeeper.FormatSeconds(elapsedToday);
                statusTimeAll.Text = Timekeeper.FormatSeconds(elapsedTodayAll);

                if (!isBrowsing) {
                    wDuration.Text = statusTimeCurrent.Text;
                    wStopTime.Value = DateTime.Now;
                }

                string timeToShow;
                if (options.wShowCurrent.Checked) {
                    timeToShow = statusTimeCurrent.Text;
                } else if (options.wShowToday.Checked) {
                    timeToShow = statusTimeToday.Text;
                } else {
                    timeToShow = statusTimeAll.Text;
                }

                // Text = currentTaskNode.Text + " (Timer Running)";
                // Text = currentTaskNode.Text + " (" + currentProjectNode.Text + ") - " + timeToShow;
                string tmp = options.wTitleBarTemplate.Text;
                tmp = tmp.Replace("%task", "{0}");
                tmp = tmp.Replace("%project", "{1}");
                tmp = tmp.Replace("%time", "{2}");
                Text = String.Format(tmp, currentTaskNode.Text, currentProjectNode.Text, timeToShow);
                //wNotifyIcon.Text = Text;
                wNotifyIcon.Text = Timekeeper.Abbreviate(Text, 63);
            }

            // Animate the task icon
            if (timerRunning == true) {
                int currentIndex = currentTaskNode.SelectedImageIndex;
                if (currentIndex > IMG_TASK_TIMER_END - 1) {
                    currentTaskNode.ImageIndex = IMG_TASK_TIMER_START;
                    currentTaskNode.SelectedImageIndex = IMG_TASK_TIMER_START;
                } else {
                    currentTaskNode.ImageIndex++;
                    currentTaskNode.SelectedImageIndex++;
                }
            }
        }

        //---------------------------------------------------------------------
        private void timerLong_Tick(object sender, EventArgs e)
        {
            if (timerRunning) {
                // Refresh actual time values from database to correct for drift
                elapsed = Convert.ToInt32(currentTask.elapsed().TotalSeconds);
                elapsedToday = Convert.ToInt32(currentTask.elapsedToday().TotalSeconds);
                elapsedTodayAll = Convert.ToInt32(currentTask.elapsedTodayAll(tasks.getSeconds()).TotalSeconds);
            }

            // Annoyance support: if so desired, bug the user that the timer isn't running
            DateTime now = DateTime.Now;
            TimeSpan ts = new TimeSpan(now.Ticks - timerLastRun.Ticks);
            if (options.wPromptNoTimer.Checked)
            {
                if (ts.TotalMinutes > (double)options.wPromptInterval.Value)
                {
                    if (timerRunning == false)
                    {
                        if (wNotifyIcon.Visible) {
                            wNotifyIcon.ShowBalloonTip(30000,
                                "Timekeeper", 
                                "No timer is currently running.\n\nYou can change the frequency of this notification, or disable it completly, in the Options dialog box.",
                                ToolTipIcon.Info);
                        }
                    }
                }
            }
        }

        //---------------------------------------------------------------------
        // Editing
        //---------------------------------------------------------------------

        private void wStartTime_Leave(object sender, EventArgs e)
        {
            if (isBrowsing) {
                if (wStartTime.Value != priorLoadedBrowserEntry.StartTime) {
                    EnableRevert(true);
                }
            }
        }

        //---------------------------------------------------------------------

        private void wStopTime_Leave(object sender, EventArgs e)
        {
            if (isBrowsing) {
                if (wStopTime.Value != priorLoadedBrowserEntry.StopTime) {
                    EnableRevert(true);
                }
            }
        }

        //---------------------------------------------------------------------

        private void wDuration_Leave(object sender, EventArgs e)
        {
            if (isBrowsing) {
                long duration = ConvertToSeconds(wDuration.Text);
                if (duration != priorLoadedBrowserEntry.Seconds) {
                    EnableRevert(true);
                }
            }
        }

        //---------------------------------------------------------------------

        private void wMemo_TextChanged(object sender, EventArgs e)
        {
            if (isBrowsing) {
                if (wMemo.Text != priorLoadedBrowserEntry.Memo) {
                    EnableRevert(true);
                }
            }
        }

        //---------------------------------------------------------------------
        // Editing Labels
        //---------------------------------------------------------------------

        private void wTasks_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = wTasks.SelectedNode;
            string oldName = wTasks.SelectedNode.Text;
            string newName = e.Label;
            e.CancelEdit = AfterLabelEdit(node, oldName, newName);
        }

        //---------------------------------------------------------------------
        private void wProjects_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = wProjects.SelectedNode;
            string oldName = wProjects.SelectedNode.Text;
            string newName = e.Label;
            e.CancelEdit = AfterLabelEdit(node, oldName, newName);
        }

        //---------------------------------------------------------------------
        private bool AfterLabelEdit(TreeNode node, string oldName, string newName)
        {
            if (newName == null) {
                return true;
            }

            if (newName.Length == 0) {
                Common.Warn("Name cannot be blank.");
                return true;
            }

            Item item = (Item)node.Tag;
            int result = item.rename(newName, false);

            if (result == -1) {
                Common.Warn("Project name already exists.");
                return true;
            } else if (result == 0) {
                Common.Warn("There was a problem renaming the project.");
                return true;
            }

            return false;
        }
        
        //---------------------------------------------------------------------
        // On Task Change
        //---------------------------------------------------------------------

        private void wTasks_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get current task
            Task task = (Task)wTasks.SelectedNode.Tag;

            // Update status bar
            if (timerRunning == false) {
                statusTimeCurrent.Text = "0:00:00";
                statusTimeCurrent.ForeColor = Color.Gray;
                statusTimeToday.Text = task.elapsedTodayStatic();
                statusTimeAll.Text = task.elapsedTodayAllStatic(tasks.getSeconds());
            }

            // Project auto-follow
            if (options.wProjectFollow.Checked) {
                if (task.project_id__last > 0) {
                    TreeNode node = _findNode(wProjects.Nodes, task.project_id__last);
                    if (node != null) {
                        wProjects.SelectedNode = node;
                    }
                }
            }

            // change context menu to reflect rules
            if (calendar != null)
            {
                // select date the task was last used
                Task currentTask = (Task)wTasks.SelectedNode.Tag;
                DateTime lastUsed = currentTask.dateLastUsed();

                calendar.wCalendar.TodayDate = lastUsed;
                //calendar.wCalendar.SelectionStart = calendar.wCalendar.TodayDate;
                //calendar.wCalendar.SelectionEnd = calendar.wCalendar.TodayDate;

                // now bold all dates where task has been used
                int count = currentTask.countDaysUsed();
                DateTime[] a = new DateTime[count];

                List<DateTime> list = currentTask.daysUsed();
                a = list.ToArray();

                calendar.wCalendar.BoldedDates = a;
            }

            // Set hide mode based on task's is_hidden property
            _setHideTaskMenuVisibility(!task.is_hidden);
        }

        //---------------------------------------------------------------------
        private void wProjects_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Get current project
            Project project = (Project)wProjects.SelectedNode.Tag;

            // change context menu to reflect rules
            if (calendar != null)
            {
                // select date the project was last used
                Project currentProject = (Project)wProjects.SelectedNode.Tag;

                // now bold all dates where project has been used
                int count = currentProject.countDaysUsed();
                DateTime[] a = new DateTime[count];

                List<DateTime> list = currentProject.daysUsed();
                a = list.ToArray();

                calendar.wCalendar.BoldedDates = a;
            }

            // Set hide mode based on projects's is_hidden property
            _setHideProjectMenuVisibility(!project.is_hidden);
        }

        //---------------------------------------------------------------------
        // Random bits
        //---------------------------------------------------------------------

        private void statusFile_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Strip instructions
                string rawText = statusFile.ToolTipText;
                string subText = rawText.Substring(0, rawText.IndexOf("\n"));
                // Put remainder on clipboard and notify user
                Clipboard.SetData(DataFormats.StringFormat, subText);
                Common.Info("File name copied to the clipboard.");
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
        // Drag and Drop events
        //---------------------------------------------------------------------

        private void wTasks_ItemDrag(object sender, ItemDragEventArgs e)
        {
            draggingNode = wTasks.SelectedNode;
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void wTasks_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void wTasks_DragDrop(object sender, DragEventArgs e)
        {
            /*
            if (timerRunning) {
                Common.Warn("Cannot drag and drop tasks while the timer is running.");
                return;
            }
             */

            try {
                Point pt = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                TreeNode DestinationNode = ((TreeView)sender).GetNodeAt(pt);
                TreeNode NewNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                Task to = (Task)DestinationNode.Tag;

                if (to.is_folder == true) {
                    // if it's a folder, then reparent
                    Task from = (Task)draggingNode.Tag;
                    if (from.isDescendentOf(to.id)) {
                        Common.Warn("Cannot reparent to a descendent node.");
                        return;
                    } else if (from.id == to.id) {
                        Common.Warn("Cannot move task to self.");
                        return;
                    }
                    from.reparent(to);
                    reloadTasks();
                } else {
                    // if it's a task, then swap
                    if (DestinationNode.Parent == null) {
                        int index = DestinationNode.Index;
                        wTasks.Nodes.Insert(index, (TreeNode)NewNode.Clone());
                        NewNode.Remove();
                    } else {
                        int index = DestinationNode.Parent.Nodes.Add((TreeNode)NewNode.Clone());
                        NewNode.Remove();
                    }
                }
            }
            catch {
                Common.Warn("An error was encountered dragging the item.");
            }
        }

        //---------------------------------------------------------------------
        // Application Actions
        //---------------------------------------------------------------------

        private void closeFile()
        {
            wTasks.Nodes.Clear();
            wProjects.Nodes.Clear();
            statusFile.Text = "No File Loaded";
            statusFile.ToolTipText = statusFile.Text;
            statusFile.ForeColor = Color.Gray;

            menuAction.Enabled = false;
            menuReport.Enabled = false;
            menuTool.Enabled = false;

            statusTimeCurrent.Text = "0:00:00";
            statusTimeToday.Text = "0:00:00";
            statusTimeAll.Text = "0:00:00";
            statusTimeCurrent.ForeColor = Color.Gray;
            statusTimeToday.ForeColor = Color.Gray;
            statusTimeAll.ForeColor = Color.Gray;

            this.data = null;

            foreach (Form form in openForms) {
                form.Close();
            }
        }

        //---------------------------------------------------------------------
        private bool loadFile(bool createIfMissing)
        {
            data = new DBI(dataFile, options.wSQLtracing.Checked);
            Database db = new Database(data); // FIXME: bad file/class name

            if (!data.DataFileExists) {
                if (createIfMissing) {
                    db.create();
                } else {
                    Common.Warn("The file " + dataFile + " could not be found.");
                    return false;
                }
            }

            int status = db.check();
            switch (status)
            {
                case -1: Common.Warn("An error occurred during the database check. Cannot open file."); return false;
                case -2: Common.Warn("This database is from a newer version of Timekeeper. Cannot open file."); return false;
                case -3: Common.Warn("This is not a Timekeeper database. File not opened."); return false;
                case -4: Common.Warn("This appears to be an empty database. A future version of Timekeeper will allow you to claim it."); return false;
            }

            db.info();

            loadTasks(null, 0);
            loadProjects(null, 0);

            FileInfo fileinfo = new FileInfo(dataFile);
            statusFile.Text = fileinfo.Name;
            statusFile.ToolTipText = dataFile + "\n(Right-click to copy to clipboard)";
            statusFile.ForeColor = Color.Black;

            wTasks.ExpandAll();
            wProjects.ExpandAll();

            menuAction.Enabled = true;
            menuReport.Enabled = true;
            menuTool.Enabled = true;

            statusTimeCurrent.Text = "0:00:00";
            statusTimeToday.Text = "0:00:00";
            statusTimeAll.Text = "0:00:00";
            statusTimeToday.ForeColor = Color.Black;
            statusTimeAll.ForeColor = Color.Black;

            // general FIXME: clean up this handling, it's a bit sloppy.

            // MRU handling (search list and add file if not already on the list)
            int i = 0;
            int pos = -1;
            foreach (ToolStripMenuItem item in menuFileRecent.DropDownItems) {
                if (item.Text == dataFile) {
                    pos = i;
                }
                i++;
            }

            // if found, remove from current position
            if (pos > -1) {
                menuFileRecent.DropDownItems.RemoveAt(pos);
            }

            // insert (either the new one or reinserting the one we just deleted, at the top)
            ToolStripMenuItem newItem = new ToolStripMenuItem();
            newItem.Click += new EventHandler(menuFileRecentFile_Click);
            newItem.Text = dataFile;
            menuFileRecent.DropDownItems.Insert(0, newItem);

            return true;
        }

        //---------------------------------------------------------------------
        private void loadTasks(TreeNode parent_node, long parent_id)
        {
            // Get sort order
            int nOrderBy = options.wOrderBy.SelectedIndex;
            string sOrderBy;
            switch (nOrderBy) {
                case 0: sOrderBy = "name asc"; break;
                case 1: sOrderBy = "name desc"; break;
                case 2: sOrderBy = "timestamp_c asc"; break;
                case 3: sOrderBy = "timestamp_c desc"; break;
                case 4: sOrderBy = "timestamp_m asc"; break;
                case 5: sOrderBy = "timestamp_m desc"; break;
                default: sOrderBy = "timestamp_c asc"; break;
            }

            // Begin a transaction
            data.Begin();

            // Instantiate Tasks object
            this.tasks = new Tasks(data, sOrderBy);

            foreach (Task task in tasks.get(parent_id, options.wViewHiddenTasks.Checked))
            {
                // create the new node
                TreeNode node = insertItem(wTasks, parent_node, task, IMG_TASK);

                // then recurse
                if (task.id != parent_id) {
                    loadTasks(node, task.id);
                }
            }

            // End transaction
            data.Commit();
        }

        //---------------------------------------------------------------------
        public void loadProjects(TreeNode parent_node, long parent_id)
        {
            // Get sort order (FIXME: copy/poasted from loadTasks; please fix that)
            int nOrderBy = options.wOrderBy.SelectedIndex;
            string sOrderBy;
            switch (nOrderBy)
            {
                case 0: sOrderBy = "name asc"; break;
                case 1: sOrderBy = "name desc"; break;
                case 2: sOrderBy = "timestamp_c asc"; break;
                case 3: sOrderBy = "timestamp_c desc"; break;
                case 4: sOrderBy = "timestamp_m asc"; break;
                case 5: sOrderBy = "timestamp_m desc"; break;
                default: sOrderBy = "timestamp_c asc"; break;
            }

            // Begin a transaction
            data.Begin();

            this.projects = new Projects(data, sOrderBy);

            foreach (Project project in projects.get(parent_id, options.wViewHiddenProjects.Checked))
            {
                // create the new node
                TreeNode node = insertItem(wProjects, parent_node, project, IMG_PROJECT);

                // then recurse
                if (project.id != parent_id) {
                    loadProjects(node, project.id);
                }
            }

            // End transaction
            data.Commit();
        }

        //---------------------------------------------------------------------
        private void dlgItemNew(TreeView tree, string title, bool is_folder, Item item, int imageIndex)
        {
            string tableName = (string)tree.Tag;
            fItem dlg = new fItem(data, tableName);

            dlg.Text = title;
            if (tree.SelectedNode == null) {
                dlg.wParent.SelectedIndex = 0;
            } else {
                int i = dlg.wParent.FindString(tree.SelectedNode.Text);
                if (i < 0) { i = 0; }
                dlg.wParent.SelectedIndex = i;
            }

            if (dlg.ShowDialog(this) == DialogResult.OK) {
                item.name = dlg.wNodeName.Text;
                item.description = dlg.wNodeDescription.Text;
                item.is_folder = is_folder;
                createItem(tree, item, dlg.wParent.Text, imageIndex);
            }
        }

        //---------------------------------------------------------------------
        private void dlgItemEdit(TreeView tree, string title, Item item)
        {
            string tableName = (string)tree.Tag;
            fItem dlg = new fItem(data, tableName);

            dlg.Text = title;
            if (tree.SelectedNode == null) {
                dlg.wParent.SelectedIndex = 0;
            } else if (tree.SelectedNode.Parent == null) {
                dlg.wParent.SelectedIndex = 0;
            } else {
                int i = dlg.wParent.FindString(tree.SelectedNode.Parent.Text);
                if (i < 0) { i = 0; }
                dlg.wParent.SelectedIndex = i;
            }

            dlg.wNodeName.Text = tree.SelectedNode.Text;
            dlg.wNodeDescription.Text = tree.SelectedNode.ToolTipText;

            string oldName = tree.SelectedNode.Text;

            if (dlg.ShowDialog(this) == DialogResult.OK) {

                // first rename
                item.description = dlg.wNodeDescription.Text;
                int result = item.rename(dlg.wNodeName.Text, oldName == dlg.wNodeName.Text);
                if (result == 0) {
                    Common.Warn("Error renaming task.");
                    return;
                } else if (result == -1) {
                    Common.Warn("An item with that name already exists.");
                    return;
                } else {
                    tree.SelectedNode.Text = item.name;
                    tree.SelectedNode.ToolTipText = item.description;
                }
                
                // then reparent
                TreeNode parentNode = _findNode(tree.Nodes, dlg.wParent.Text);

                if (parentNode == null) {
                    item.reparent(0);
                } else {
                    Item parentItem = (Item)parentNode.Tag;
                    if (item.isDescendentOf(parentItem.id)) {
                        Common.Warn("Item renamed, but not reparented. Cannot reparent to a descendent.");
                        return;
                    }
                    item.reparent((Item)parentNode.Tag);
                }

                // and reload
                tree.Nodes.Clear();
                // FIXME: bit of a hack, here
                if (tableName == "tasks") {
                    loadTasks(null, 0);
                } else {
                    loadProjects(null, 0);
                }
                tree.ExpandAll();
            }
        }

        //---------------------------------------------------------------------
        private void createItem(TreeView tree, Item item, string parentName, int imageIndex)
        {
            TreeNode parentNode = null;
            item.parent_id = 0;

            if (parentName != "(Top Level)") {
                parentNode = _findNode(tree.Nodes, parentName);
                if (parentNode != null) {
                    Item parentItem = (Item)parentNode.Tag;
                    item.parent_id = parentItem.id;
                } else {
                    Common.Warn("There was an error creating the item.");
                    return;
                }
            }

            int result = item.create();
            if (result == 1) {
                TreeNode foo = insertItem(tree, parentNode, item, imageIndex);
            } else if (result == 0) {
                Common.Warn("There was an error creating the item.");
            } else if (result == -1) {
                Common.Warn("An item with that name already exists.");
            }

        }

        //---------------------------------------------------------------------
        private TreeNode insertItem(TreeView tree, TreeNode parent_node, Item item, int imageIndex)
        {
            TreeNode node = new TreeNode();
            node.Tag = item;
            node.Text = item.name;
            node.ToolTipText = item.description;
            if (item.is_hidden == true) {
                node.ForeColor = Color.Gray;
                //node.ImageIndex = IMG_TASK_HIDDEN;
            }
            /*
            if (parent_node != null) {
                if (parent_node.ForeColor == Color.Gray) {
                    node.ForeColor = Color.Gray;
                    //node.ImageIndex = IMG_TASK_HIDDEN;
                }
            }
            */
            if (item.is_folder == true) {
                node.ImageIndex = IMG_FOLDER_CLOSED;
                node.SelectedImageIndex = IMG_FOLDER_OPEN;
            } else {
                node.ImageIndex = imageIndex;
                node.SelectedImageIndex = imageIndex;
            }

            // new tree or existing?
            if (parent_node == null) {
                tree.Nodes.Add(node);
            } else {
                parent_node.Nodes.Add(node);
            }

            // display root lines?
            _togglePlusMinus();

            return node;
        }

        //---------------------------------------------------------------------
        public void hideItem(TreeView tree, bool bViewItem)
        {
            // confirm
            if (options.wPromptHide.Checked) {
                fPrompt dlg = new fPrompt();
                if (dlg.ShowDialog(this) != DialogResult.OK) {
                    return;
                } else {
                    if (dlg.wDontShowAgain.Checked) {
                        options.wPromptHide.Checked = false;
                    }
                }
            }

            // hide in the database
            Item item = (Item)tree.SelectedNode.Tag;
            int result = item.hide();

            if (result == 0) {
                Common.Warn("There was a problem hiding the item.");
                return;
            }

            // now handle the UI
            if (bViewItem == false) {
                // Physically remove it from the tree if 
                // we're not showing hidden items
                tree.SelectedNode.Remove();
            } else {
                // Otherwise, just change its color
                // Todo: let the user select this color
                tree.SelectedNode.ForeColor = Color.Gray;
                //tree.SelectedNode.ImageIndex = IMG_TASK_HIDDEN;
            }

            // display root lines?
            _togglePlusMinus();
        }

        //---------------------------------------------------------------------
        public void unhideItem(TreeView tree)
        {
            // unhide in the database
            Item item = (Item)tree.SelectedNode.Tag;
            int result = item.unhide();

            if (result == 0) {
                Common.Warn("There was a problem unhiding the item.");
                return;
            }

            // Update the UI
            tree.SelectedNode.ForeColor = Color.Black;

            // display root lines?
            _togglePlusMinus();
        }

        //---------------------------------------------------------------------
        public void deleteItem(TreeView tree)
        {
            // confirm
            if (Common.Prompt("Delete this item?") != DialogResult.Yes) {
                return;
            }

            // remove in the database
            Item item = (Item)tree.SelectedNode.Tag;
            int result = item.delete();

            if (result == 0) {
                Common.Warn("There was a problem deleting the item.");
                return;
            }

            // now remove from the UI
            // FIXME: make sure you set is_deleted to all descendents
            tree.SelectedNode.Remove();

            // display root lines?
            _togglePlusMinus();
        }

        //---------------------------------------------------------------------
        private void StartTimer()
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
            currentTask = (Task)currentTaskNode.Tag;
            currentProject = (Project)currentProjectNode.Tag;

            if ((currentTask.is_folder == true) || (currentProject.is_folder)) {
                Common.Warn("Folders cannot be timed. Please select a task before starting the timer.");
                return;
            }

            // Prompt for annotation
            if (suppressAnnotationDialogs) {
            } else {
                fAnnotate dlg = new fAnnotate(data);
                dlg.panelTop.Visible = false;
                dlg.ActiveControl = dlg.wLog;
                dlg.AcceptButton = dlg.btnOK;
                if (dlg.ShowDialog(this) != DialogResult.OK) {
                    return;
                }
            }
            this.annotateStartTime = DateTime.Now;

            // Now start timing
            currentTask.beginTiming();
            currentTask.project_id__last = currentProject.id;

            currentEntry = new Entry(data);
            currentEntry.TaskId = currentTask.id;
            currentEntry.ProjectId = currentProject.id;
            currentEntry.StartTime = wStartTime.Value;
            currentEntry.StopTime = wStartTime.Value; // defaults to start time.
            currentEntry.Seconds = 0; // default to zero
            currentEntry.Memo = wMemo.Text;
            currentEntry.PreLog = ""; // THIS IS GOING AWAY, PostLog is on its way to being Memo
            currentEntry.PostLog = wMemo.Text; // FIXME (this is going away anyway)
            currentEntry.IsLocked = true;
            currentEntry.Create();

            //currentEntry.Begin(wMemo.Text, currentTask.id, currentProject.id);

            timerRunning = true;
            timerLastRun = DateTime.Now;

            // Grab times (this is a database hit)
            elapsed = (long)currentTask.elapsed().TotalSeconds;
            elapsedToday = (long)currentTask.elapsedToday().TotalSeconds;
            elapsedTodayAll = (long)currentTask.elapsedTodayAll(tasks.getSeconds()).TotalSeconds;

            // Make any UI changes based on the timer starting
            menuActionStart.Visible = false;
            //menuActionStartAdvanced.Visible = false;
            menuActionStop.Visible = true;
            //menuActionStopAdvanced.Visible = true;

            // swap start/stop keystrokes
            // FIXME: this is a mess
            Keys saveKeys = new Keys();
            Keys saveKeysAdvanced = new Keys();
            saveKeys = menuActionStart.ShortcutKeys;
            saveKeysAdvanced = menuActionStartAdvanced.ShortcutKeys;
            menuActionStart.ShortcutKeys = Keys.None;
            menuActionStartAdvanced.ShortcutKeys = Keys.None;
            menuActionStop.ShortcutKeys = saveKeys;
            menuActionStopAdvanced.ShortcutKeys = saveKeysAdvanced;
            /*
            saveKeys = menuToolControlStart.ShortcutKeys;
            menuToolControlStart.ShortcutKeys = Keys.None;
            menuToolControlStop.ShortcutKeys = saveKeys;
            */

            statusCurrentTask.Text = wTasks.SelectedNode.Text;
            statusCurrentTask.ForeColor = Color.Black;
            statusTimeCurrent.ForeColor = Color.Black;

            Text = wTasks.SelectedNode.Text;
            menuTasksDeleteTask.Enabled = false;
            pmenuTasksDelete.Enabled = false;
            wNotifyIcon.Text = Timekeeper.Abbreviate(Text, 63);

            menuFile.Enabled = false;
            menuFileNew.Enabled = false;
            menuFileOpen.Enabled = false;
            menuFileSaveAs.Enabled = false;
            menuFileClose.Enabled = false;
            menuFileRecent.Enabled = false;
            menuFileUtilities.Enabled = false;
            menuFileExit.Enabled = false;

            if (options.wMinimizeOnUse.Checked) {
                if ((ModifierKeys & Keys.Shift) == Keys.Shift) {
                    // Shift key temporarily overrides the minimize-on-use setting
                } else {
                    WindowState = FormWindowState.Minimized;
                }
            }

            // Don't display while the timer is running (FIXME: make this an option)
            //CloseBrowser();
            
            // As soon as the timer has started, we have to paint "stop" mode.
            ResetBrowserForStopping(false); 
        }

        // FIXME: MOVE THIS
        private void ResetBrowserForStarting(bool openLog)
        {
            // Set UI accordingly
            SetCreateState();

            // Create browser objects
            browserEntry = new Entry(data);
            priorLoadedBrowserEntry = new Entry(data);
            if (newBrowserEntry == null) {
                newBrowserEntry = new Entry(data);
            }
            isBrowsing = false;

            // Load empty form
            EntryToForm(newBrowserEntry);

            // Ensure proper display
            //splitMain.Panel2Collapsed = suppressBrowserDisplay ? true : false;
            //splitMain.Panel2Collapsed = !openLog;

            wMemo.Focus();
        }

        // FIXME: MOVE THIS
        // FIXME: ALSO RENAME THIS -- NOT A FAN OF "OPEN LOG" ANY MORE
        // FIXME: And now that I just added showBrowser support, that puts the last nail in the coffin
        private void ResetBrowserForStopping(bool showBrowser)
        {
            // Set UI accordingly 
            SetStopState();

            // Reset browser entry
            isBrowsing = false;

            if (showBrowser) {
                // not now: this is now totally under explicit user-control
                // and not determined by any special "mode" we might be in.
                //splitMain.Panel2Collapsed = false;
            }

            //wStopTime.Value = DateTime.Now;

            // Menu Mucking
            /*
            menuActionStartAdvanced.Visible = true;
            menuActionStopAdvanced.Visible = false;
            */

            // Ensure proper display
            wMemo.Focus();
        }

        // FIXME: MOVE THIS
        private void CloseBrowser()
        {
            // Clean up Tool menus
            menuToolBrowse.Checked = false;

            // Save row, just in case
            SaveRow(false);

            // Kill any existing "new" entry
            newBrowserEntry = null;

            /*
            menuToolFormat.Visible = false;
            menuToolControl.Visible = false;
            */

            // Close control pane
            // Note, this isn't an option. If we're here, it means CLOSE IT.
            // If you find yourself here and don't want it closed, then go
            // fix the caller.
            ShowBrowser(false);
        }

        //---------------------------------------------------------------------
        private void StopTimer()
        {
            // Get annotation
            string postLog = wMemo.Text; // FIXME: postLog is my unified log until the db migration happens.
                                         // double FIXME: this isn't even being used anymore

            if (options.wPostLog.Checked && suppressAnnotationDialogs == false) {
                // instantiate dialog box
                fAnnotate dlg = new fAnnotate(data);

                // a few settings
                dlg.panelTop.Visible = true;
                dlg.ActiveControl = dlg.wLog;

                DateTime endTime = DateTime.Now;
                TimeSpan ts = new TimeSpan(endTime.Ticks - this.annotateStartTime.Ticks);

                // default fields
                dlg.wStartTime.Text = this.annotateStartTime.ToString(Common.TIME_FORMAT);
                dlg.ttStartTime.SetToolTip(dlg.wStartTime, this.annotateStartTime.ToString(Common.DATETIME_FORMAT));
                dlg.wElapsedTime.Text = ts.ToString().Substring(0, 8);
                //dlg.wPreLog.Text = preLog;
                if (dlg.ShowDialog(this) != DialogResult.OK) {
                    return;
                }
                postLog = dlg.wLog.Text;
                //preLog = dlg.wPreLog.Text;
            }

            // Close off timer
            currentEntry.TaskId = currentTask.id;
            currentEntry.ProjectId = currentProject.id;
            currentEntry.StartTime = wStartTime.Value;
            currentEntry.StopTime = wStopTime.Value;
            currentEntry.Seconds = currentTask.endTiming();
            currentEntry.Memo = wMemo.Text;
            currentEntry.PreLog = ""; // FIXME: but it's going away
            currentEntry.PostLog = wMemo.Text;
            currentEntry.IsLocked = false;
            currentEntry.Save();
            timerRunning = false;
            //timerLastRunNotified = false;

            // Clear instances of current object
            currentTask = null;
            currentProject = null;
            currentEntry = null;

            // Make any UI changes 
            Text = "Timekeeper";

            menuActionStart.Visible = true;
            //menuActionStartAdvanced.Visible = true;
            menuActionStop.Visible = false;
            //menuActionStopAdvanced.Visible = false;
            statusCurrentTask.Text = "Timer Not Running";
            statusCurrentTask.ForeColor = Color.Gray;
            statusTimeCurrent.ForeColor = Color.Gray;

            // swap start/stop keystrokes
            // FIXME: this is a mess
            Keys saveKeys = new Keys();
            Keys saveKeysAdvanced = new Keys();
            saveKeys = menuActionStop.ShortcutKeys;
            saveKeysAdvanced = menuActionStopAdvanced.ShortcutKeys;
            menuActionStop.ShortcutKeys = Keys.None;
            menuActionStopAdvanced.ShortcutKeys = Keys.None;
            menuActionStart.ShortcutKeys = saveKeys;
            menuActionStartAdvanced.ShortcutKeys = saveKeysAdvanced;
            /*
            saveKeys = menuToolControlStop.ShortcutKeys;
            menuToolControlStop.ShortcutKeys = Keys.None;
            menuToolControlStart.ShortcutKeys = saveKeys;
            */
            currentTaskNode.ImageIndex = IMG_TASK;
            currentTaskNode.SelectedImageIndex = IMG_TASK;

            menuTasksDeleteTask.Enabled = true;
            pmenuTasksDelete.Enabled = true;

            menuFile.Enabled = true;
            menuFileNew.Enabled = true;
            menuFileOpen.Enabled = true;
            menuFileSaveAs.Enabled = true;
            menuFileClose.Enabled = true;
            menuFileRecent.Enabled = true;
            menuFileUtilities.Enabled = true;
            menuFileExit.Enabled = true;

            // As soon as the timer has stopped, we have to paint "start" mode.
            newBrowserEntry = null;

            // FIXME: stopping the timer != opening the browser
            ResetBrowserForStarting(false);
        }

        //---------------------------------------------------------------------
        private void ShowProperties(Item item)
        {
            string start = DateTime.Now.ToString(Common.DATE_FORMAT + " 00:00:00");
            string end =   DateTime.Now.ToString(Common.DATE_FORMAT + " 23:59:59");

            properties.Text = "Properties for " + item.name;

            properties.wID.Text = item.id.ToString();
            properties.wType.Text = item.is_folder ? "Folder" : "Item"; ;
            properties.wDescription.Text = item.description.Length > 0 ? item.description : "(none)";
            properties.wTotalTime.Text = Timekeeper.FormatSeconds(item.countTreeTime(item.id, "1900-01-01", "2999-01-01"));
            properties.wTimeToday.Text = Timekeeper.FormatSeconds(item.countTreeTime(item.id, start, end));
            properties.wCreated.Text = item.timestamp_c.ToString();

            properties.ShowDialog(this);
        }

        //---------------------------------------------------------------------
        // Form Events
        //---------------------------------------------------------------------

        // Load settings
        private void fMain_Load(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;

            // Registry relocation
            /* Maybe come back to this later
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "State");
            string version = (string)key.GetValue("version", "0");
            string regkey;
            if (version == "0") {
                // read from the old area
                regkey = REGKEY_OLD;
            } else {
                // read from the new
                regkey = REGKEY;
            }
            */

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
            options = new fOptions(data);
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
                item.Click += new EventHandler(menuFileRecentFile_Click);
                item.Text = mru;
                menuFileRecent.DropDownItems.Add(item);
            }
            key.Close();

            // Remove the old key
            /* or not
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(REGKEY_OLD);
            if (key != null) {
                key.DeleteSubKey("MRU");
                key.DeleteSubKey("Options");
                key.DeleteSubKey("State");
                key.DeleteSubKey("WindowMetrics");
            }
            */

            // Initialize property sheet
            properties = new fProperties();

            // Initialize timer
            timerLastRun = DateTime.Now;

            // Create tray icon if requested
            if (options.wShowInTray.Checked) {
                wNotifyIcon.Visible = true;
            } else {
                wNotifyIcon.Visible = false;
            }

            // Re-open last loaded file
            /*
            // NOTE: as of 2.2 this is redundant with the new MRU list, consider dropping
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "State");
            if (TestMode == 1) {
                dataFile = (string)key.GetValue("LastFileTest", "");
            } else {
                dataFile = (string)key.GetValue("LastFile", "");
            }
            key.Close();
            */

            // Load keyboard shortcuts
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "Keyboard");
            foreach (string name in key.GetValueNames()) {
                foreach (ToolStripMenuItem item in menuMain.Items.Find(name, true)) {
                    item.ShortcutKeys = (Keys)key.GetValue(name);
                    options.wFunctionList.Items.Add(name, (int)item.ShortcutKeys);
                }
            }
            key.Close();

            // Re-open last loaded file, if dataFile not already set
            if (dataFile == null) {
                if (menuFileRecent.DropDownItems.Count > 0) {
                    dataFile = menuFileRecent.DropDownItems[0].Text;
                }
            }

            // View or hide the project pane
            _toggleProjects();

            if (dataFile != null)
            {
                if (!loadFile(false)) {
                    // bail if we failed loading the file
                    return;
                }

                // and save name for next Ctrl+O
                dlgOpen.FileName = dataFile;

                // File-dependent settings
                key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "State");
                // fixme: these should come from the db as they're not OS-wide settings
                string lastTask = (string)key.GetValue("LastTask");
                string lastProject = (string)key.GetValue("LastProject");
                lastGridView = (string)key.GetValue("LastGridView", "Last View");
                key.Close();

                // Re-select last selected task
                TreeNode lastNode = _findNode(wTasks.Nodes, lastTask);
                if (lastNode != null) {
                    wTasks.SelectedNode = lastNode;
                    wTasks.SelectedNode.Expand();
                }

                // Re-select last selected project
                lastNode = _findNode(wProjects.Nodes, lastProject);
                if (lastNode != null) {
                    wProjects.SelectedNode = lastNode;
                    wProjects.SelectedNode.Expand();
                }

                // View root lines?
                _togglePlusMinus();
            }

            // NEW:

            LoadBrowser();
            ResetBrowserForStarting(false);

            // FIXME: This should be controlled by an option.
            // Until I have that option, I'm going to proceed as if the option
            // is set to "Don't Show Browser by Default" (or whatever I call it).
            splitMain.Panel2Collapsed = true;

            // experimental: swapping Tasks/Projects
            //this.splitTrees.Panel1.Controls.Add(this.wTasks);

            /*
            splitTrees.Panel1.Controls.Remove(this.wTasks);
            splitTrees.Panel1.Controls.Remove(this.wProjects);

            splitTrees.Panel1.Controls.Add(this.wProjects);
            splitTrees.Panel2.Controls.Add(this.wTasks);
            */
        }

        // FIXME/MOVEME

        private void ShowBrowser(bool show) {
            menuActionStartAdvanced.Visible = !show;
            menuActionStopAdvanced.Visible = show;
            splitMain.Panel2Collapsed = !show;
        }

        private void ShowStart(bool show)
        {
            toolControlStart.Visible = show;
            //menuToolControlStart.Visible = show;
        }

        private void ShowStop(bool show)
        {
            toolControlStop.Visible = show;
            //menuToolControlStop.Visible = show;
        }

        private void ShowClose(bool show)
        {
            toolControlClose.Visible = show;
            //menuToolControlClose.Visible = show;
        }

        private void ShowUnlock(bool show)
        {
            toolControlUnlock.Visible = show;
            menuToolControlUnlock.Visible = show;
        }

        private void EnableStart(bool enabled)
        {
            toolControlStart.Enabled = enabled;
            menuActionStart.Enabled = enabled;
            //menuToolControlStart.Enabled = enabled;
            if (enabled) {
                var kc = new KeysConverter();
                toolControlStart.ToolTipText = "Start the Timer (" + kc.ConvertToString(menuActionStart.ShortcutKeys) + ")";
            } else {
                toolControlStart.ToolTipText = "Timer cannot be started while browsing old entries. Click 'Go to New Entry' to begin timing.";
            }
        }

        private void EnableStop(bool enabled)
        {
            toolControlStop.Enabled = enabled;
            menuActionStop.Enabled = enabled;
            //menuToolControlStop.Enabled = enabled;
        }

        private void EnableClose(bool enabled)
        {
            toolControlClose.Enabled = enabled;
            //menuToolControlClose.Enabled = enabled;
        }

        private void EnableFirst(bool enabled)
        {
            toolControlFirstEntry.Enabled = enabled;
            menuToolControlFirst.Enabled = enabled;
        }

        private void EnablePrev(bool enabled)
        {
            toolControlPrevEntry.Enabled = enabled;
            menuToolControlPrev.Enabled = enabled;
        }

        private void EnableNext(bool enabled)
        {
            toolControlNextEntry.Enabled = enabled;
            menuToolControlNext.Enabled = enabled;
        }

        private void EnableLast(bool enabled)
        {
            toolControlLastEntry.Enabled = enabled;
            menuToolControlLast.Enabled = enabled;
        }

        private void EnableNew(bool enabled)
        {
            toolControlNewEntry.Enabled = enabled;
            menuToolControlNew.Enabled = enabled;
        }

        private void EnableCloseStartGap(bool enabled)
        {
            toolControlCloseStartGap.Enabled = enabled;
            menuToolControlCloseStartGap.Enabled = enabled;
        }

        private void EnableCloseEndGap(bool enabled)
        {
            toolControlCloseEndGap.Enabled = enabled;
            menuToolControlCloseEndGap.Enabled = enabled;
        }

        private void EnableRevert(bool enabled)
        {
            toolControlRevert.Enabled = enabled;
            menuToolControlRevert.Enabled = enabled;
        }

        private void EnableStartEntry(bool enabled)
        {
            wStartTime.Enabled = enabled;
            labelStartTime.Enabled = enabled;
        }

        private void EnableStopEntry(bool enabled)
        {
            wStopTime.Enabled = enabled;
            labelEndTime.Enabled = enabled;
        }

        private void EnableDurationEntry(bool enabled)
        {
            wDuration.Enabled = enabled;
            labelDuration.Enabled = enabled;
        }

        private void EnableMemoEntry(bool enabled)
        {
            wMemo.Enabled = enabled;
        }

        private void SetCreateState()
        {
            ShowStart(true);
            ShowStop(false);
            ShowClose(true);

            EnableStart(true);
            EnableStop(false);
            EnableClose(true);

            EnableFirst(true);
            EnablePrev(true);
            EnableNext(false);
            EnableLast(false);
            EnableNew(false);

            EnableCloseStartGap(true);
            EnableCloseEndGap(false);

            EnableStartEntry(true);
            EnableStopEntry(false);
            EnableDurationEntry(false);
        }

        private void SetBrowseState() {

            if (timerRunning) {
                ShowStart(false);
                ShowStop(true);
                ShowClose(true);

                EnableStart(false);
                EnableStop(false);
                EnableClose(true);

                EnableNew(false);

                EnableCloseStartGap(true);
                EnableCloseEndGap(true);

                EnableStartEntry(true);
                EnableStopEntry(true);
                EnableDurationEntry(true);
            } else {
                ShowStart(true);
                ShowStop(false);
                ShowClose(true);

                EnableStart(false);
                EnableStop(false);
                EnableClose(true);

                EnableNew(true);

                EnableCloseStartGap(true);
                EnableCloseEndGap(true);

                EnableStartEntry(true);
                EnableStopEntry(true);
                EnableDurationEntry(true);
            }
        }

        private void SetStopState()
        {
            ShowStart(false);
            ShowStop(true);
            ShowClose(true);

            EnableStart(false);
            EnableStop(true);
            EnableClose(true);

            EnableFirst(true);
            EnablePrev(true);
            EnableNext(false);
            EnableLast(false);
            EnableNew(false);

            EnableCloseStartGap(false);
            EnableCloseEndGap(false);

            EnableStartEntry(false);
            EnableStopEntry(false);
            EnableDurationEntry(false);
        }

        private void LoadBrowser()
        {
            try {
                // Initialize id with latest row

                // um, actually, don't
                /*
                browserEntry.SetLastId();
                if (browserEntry.EntryId == 0) {
                    //EnableButtons(false);
                    return;
                }

                // Show row
                DisplayRow();
                */

                // Add keyboard shortcuts to tooltips
                var kc = new KeysConverter();
                toolControlFirstEntry.ToolTipText += " (" + kc.ConvertToString(menuToolControlFirst.ShortcutKeys) + ")";
                toolControlLastEntry.ToolTipText += " (" + kc.ConvertToString(menuToolControlLast.ShortcutKeys) + ")";
                toolControlNextEntry.ToolTipText += " (" + kc.ConvertToString(menuToolControlNext.ShortcutKeys) + ")";
                toolControlPrevEntry.ToolTipText += " (" + kc.ConvertToString(menuToolControlPrev.ShortcutKeys) + ")";

                toolControlStart.ToolTipText += " (" + kc.ConvertToString(menuActionStart.ShortcutKeys) + ")";
                toolControlStop.ToolTipText += " (" + kc.ConvertToString(menuActionStop.ShortcutKeys) + ")";
                toolControlClose.ToolTipText += " (Esc)";
            }
            catch (Exception exception) {
                Common.Info("No file loaded.\n\n" + exception.ToString());
            }
        }

        //---------------------------------------------------------------------

        private void DisplayRow()
        {
            try {
                // browserEntry.Load();

                /*
                if (browserEntry.Empty()) {
                    Common.Info("You thought you couldn't hit this, did you?");
                    return;
                }
                */

                try {
                    SetBrowseState();

                    EnableRevert(false);

                    EntryToForm(browserEntry);

                    if (browserEntry.IsLocked) {
                        EnableCloseStartGap(false);
                        EnableCloseEndGap(false);
                        EnableStartEntry(false);
                        EnableStopEntry(false);
                        EnableDurationEntry(false);
                        if (timerRunning) {
                            EnableMemoEntry(true);
                            ShowUnlock(false);
                        } else {
                            EnableMemoEntry(false);
                            ShowUnlock(true);
                        }
                    } else {
                        EnableCloseStartGap(true);
                        EnableCloseEndGap(true);
                        EnableStartEntry(true);
                        EnableStopEntry(true);
                        EnableDurationEntry(true);
                        EnableMemoEntry(true);
                        ShowUnlock(false);
                    }

                    // Enable/disable start gap button
                    if (browserEntry.AtBeginning()) {
                        EnableCloseStartGap(false);
                    } else {
                        DateTime PreviousEndTime = GetPreviousEndTime();
                        if (PreviousEndTime == wStartTime.Value) {
                            EnableCloseStartGap(false);
                        } else {
                            EnableCloseStartGap(true);
                        }
                    }

                    // Enable/disable stop gap button
                    if (browserEntry.AtEnd()) {
                        EnableCloseEndGap(true);
                    } else {
                        DateTime NextStartTime = GetNextStartTime();
                        if (NextStartTime == wStopTime.Value) {
                            EnableCloseEndGap(false);
                        } else {
                            EnableCloseEndGap(true);
                        }
                    }

                }
                catch (Exception ee) {
                    Common.Warn(ee.ToString());
                }
            }
            catch {
            }
        }

        //---------------------------------------------------------------------

        private void FormToEntry(ref Entry entry, long entryId)
        {
            // First translate some necessary data from the form 
            Task task = (Task)wTasks.SelectedNode.Tag;
            Project project = (Project)wProjects.SelectedNode.Tag;
            TimeSpan ts = wStopTime.Value.Subtract(wStartTime.Value);

            // Update browserEntry with current form data
            entry.EntryId = entryId;
            entry.TaskId = task.id;
            entry.ProjectId = project.id;
            entry.StartTime = wStartTime.Value;
            entry.StopTime = wStopTime.Value;
            entry.Seconds = (long)ts.TotalSeconds;
            entry.Memo = wMemo.Text;
            entry.PostLog = wMemo.Text;
            entry.TaskName = wTasks.SelectedNode.Text;
            entry.ProjectName = wProjects.SelectedNode.Text;
        }

        private void EntryToForm(Entry entry)
        {
            // Now select tasks and projects while browsing.
            TreeNode node = _findNode(wTasks.Nodes, entry.TaskName);
            if (node != null) {
                wTasks.SelectedNode = node;
                wTasks.SelectedNode.Expand();
            }

            node = _findNode(wProjects.Nodes, entry.ProjectName);
            if (node != null) {
                wProjects.SelectedNode = node;
                wProjects.SelectedNode.Expand();
            }

            // Display entry
            wStartTime.Value = entry.StartTime;
            wStopTime.Value = entry.StopTime;
            wDuration.Text = entry.Seconds > 0 ? Timekeeper.FormatSeconds(entry.Seconds) : "";
            wMemo.Text = entry.PostLog; // FIXME: this will be changed to just "memo"

            // And any other relevant values
            toolControlEntryId.Text = entry.EntryId > 0 ? entry.EntryId.ToString() : "";
        }

        //---------------------------------------------------------------------

        public void SaveRow(bool forceSave)
        {
            // Bail if we have no entry
            if (browserEntry.EntryId == 0) {
                return;
            }

            // Copy form values to browser entry
            FormToEntry(ref browserEntry, browserEntry.EntryId);

            // Now bail if nothing's changed
            if (!forceSave) {
                if (browserEntry.Equals(priorLoadedBrowserEntry)) {
                    return;
                }
            }

            // FIXME: is this still needed?
            /*
            if ((wStartTime.Text == "") && (wStopTime.Text == "")) {
                // Bail if there's obviously no work to do
                return;
            }
            */

            // If we've made it this far, save the row
            browserEntry.Save();

            // And disable reverting, just in case
            EnableRevert(false);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private string _calculateDuration()
        {
            try {
                browserEntry.StartTime = wStartTime.Value;
                browserEntry.StopTime = wStopTime.Value;
                //timestamp_s = Convert.ToDateTime(wStartTime.Text);
                //timestamp_e = Convert.ToDateTime(wStopTime.Text);
                TimeSpan ts = browserEntry.StopTime.Subtract(browserEntry.StartTime);
                browserEntry.Seconds = (long)ts.TotalSeconds;
                return Timekeeper.FormatSeconds(browserEntry.Seconds);
            }
            catch {
                Common.Warn("Unrecognized date/time format.");
                return "00:00:00";
            }
        }

        private DateTime GetPreviousEndTime()
        {
            try {
                Entry copy = browserEntry.Copy();
                copy.LoadPrevious();
                return copy.StopTime;
            }
            catch {
                return DateTime.MinValue;
            }
        }

        private DateTime GetNextStartTime()
        {
            try {
                Entry copy = browserEntry.Copy();
                copy.LoadNext();
                return copy.StartTime;
            }
            catch {
                return DateTime.MinValue;
            }
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
                e.Cancel = false;
            }
        }

        //---------------------------------------------------------------------
        // Save settings on exit
        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
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

            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "State");
            if (wTasks.SelectedNode != null) {
                key.SetValue("LastTask", wTasks.SelectedNode.Text);
            }
            if (wProjects.SelectedNode != null) {
                key.SetValue("LastProject", wProjects.SelectedNode.Text);
            }
            if (lastGridView != null) {
                key.SetValue("LastGridView", lastGridView);
            }
            key.SetValue("Version", Timekeeper.VERSION);
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
            foreach (ToolStripMenuItem item in menuFileRecent.DropDownItems) {
                if (i < 10) { // arbitrary maximum
                    key.SetValue(i.ToString(), item.Text);
                    i++;
                }
            }
            key.SetValue("count", i, Microsoft.Win32.RegistryValueKind.DWord);
            key.Close();

            // Save Keyboard customizations
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "Keyboard");
            foreach (ToolStripMenuItem mainItem in menuMain.Items) {
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

            closeFile();
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private void _toggleProjects()
        {
            bool show = options.wViewProjectPane.Checked;
            bool hide = !show;

            splitTrees.Panel2Collapsed = hide;
            pmenuTasksSep3.Visible = hide;
            pmenuTasksShowProjects.Visible = hide;

            menuTasksSep2.Visible = show;
            menuTasksNewProject.Visible = show;
            menuTasksNewProjectFolder.Visible = show;
            menuTasksEditProject.Visible = show;
            menuTasksHideProject.Visible = show;
            menuTasksDeleteProject.Visible = show;
        }

        private void _setHideTaskMenuVisibility(bool visible)
        {
            if (options.wViewHiddenTasks.Checked) {
                // set main menu items
                menuTasksHideTask.Visible = visible;
                menuTasksUnhideTask.Visible = !visible;

                // mirror popup menu items
                pmenuTasksHide.Visible = visible;
                pmenuTasksUnhide.Visible = !visible;
            }
        }

        private void _setHideProjectMenuVisibility(bool visible)
        {
            if (options.wViewHiddenProjects.Checked) {
                // set main menu items
                menuTasksHideProject.Visible = visible;
                menuTasksUnhideProject.Visible = !visible;

                // mirror popup menu items
                pmenuProjectsHide.Visible = visible;
                pmenuProjectsUnhide.Visible = !visible;
            }
        }

        //---------------------------------------------------------------------
        public TreeNode _findNode(TreeNodeCollection nodes, string name)
        {
            TreeNode result = null;

            foreach (TreeNode n in nodes) {
                if (n.Text == name) {
                    result = n;
                } else {
                    result = _findNode(n.Nodes, name);
                }
                if (result != null) {
                    break;
                }
            }

            return result;
        }

        //---------------------------------------------------------------------
        public TreeNode _findNode(TreeNodeCollection nodes, long id)
        {
            TreeNode result = null;

            foreach (TreeNode n in nodes)
            {
                Item item = (Item)n.Tag;

                if (item.id == id) {
                    result = n;
                } else {
                    result = _findNode(n.Nodes, id);
                }
                if (result != null) {
                    break;
                }
            }

            return result;
        }

        private void _togglePlusMinus()
        {
            string query = "select count(*) as count from tasks where is_deleted = 0 and is_hidden = 0 and parent_id > 0";
            Row row = data.SelectRow(query);
            long count = row["count"];
            if (count > 0) {
                wTasks.ShowRootLines = (count > 0);
            }

            query = "select count(*) as count from projects where is_deleted = 0 and is_hidden = 0 and parent_id > 0";
            row = data.SelectRow(query);
            count = row["count"];
            if (count > 0) {
                wProjects.ShowRootLines = (count > 0);
            }
        }

        private void reloadTasks()
        {
            wTasks.Nodes.Clear();
            loadTasks(null, 0);
            wTasks.ExpandAll();
        }

        private void reloadProjects()
        {
            wProjects.Nodes.Clear();
            loadProjects(null, 0);
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

        /*
        private void menuToolsfRecord_Click(object sender, EventArgs e)
        {
            record = new fRecordOriginal(data, this);
            record.isTimerRunning = timerRunning;
            record.ShowDialog(this);
        }

        private void form3ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog(this);
        }
        */

    }
}