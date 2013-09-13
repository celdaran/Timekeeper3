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

        // Options
        private Classes.Options Options;

        // Persistent dialog boxes
        // FIXME: why? Why these?
        //private Forms.OptionsLegacy options;
        private fToolCalendar calendar;
        private Forms.Properties properties;

        // Misc
        private bool StartTimeManuallySet = false;

        // Open form tracking
        private List<Form> OpenForms = new List<Form>();

        // Persistent objects
        private Classes.JournalEntryCollection Entries;
        private Classes.Meta Meta;
        private Classes.Widgets Widgets;

        // current objects
        private Classes.JournalEntry Entry;
        private Classes.Project currentProject;
        private Classes.Activity currentActivity;
        private Classes.Location currentLocation;
        private Classes.Category currentCategory;

        // FIXME: class-wide values?
        private TreeNode currentProjectNode;
        private TreeNode currentActivityNode;

        // Timer properties
        private bool timerRunning = false;
        private DateTime timerLastRun;
        private long ElapsedSinceStart;
        private long ElapsedProjectToday;
        private long ElapsedActivityToday;
        private long ElapsedAllToday;

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
            if (Action_CheckRecentFile(menuItem)) {
                Action_OpenFile(menuItem.Text);
            }
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
            Browser_Size(true);
        }

        // Action | Close Browser
        private void MenuActionCloseBrowser_Click(object sender, EventArgs e)
        {
            Browser_Close();
            Browser_Size(false);
        }

        // Action | New Project
        private void MenuActionNewProject_Click(object sender, EventArgs e)
        {
            Classes.Project project = new Classes.Project(Database);
            Dialog_NewItem(ProjectTree, "New Project", false, (Classes.TreeAttribute)project, Timekeeper.IMG_PROJECT);
        }

        // Action | New Project Folder
        private void MenuActionNewProjectFolder_Click(object sender, EventArgs e)
        {
            Classes.Project project = new Classes.Project(Database);
            Dialog_NewItem(ProjectTree, "New Project Folder", true, (Classes.TreeAttribute)project, Timekeeper.IMG_PROJECT);
        }

        // Action | Edit Project
        private void MenuActionEditProject_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
                Dialog_EditItem(ProjectTree, "Edit Project", (Classes.TreeAttribute)Project);
            }
        }

        // Action | Hide Project
        private void MenuActionHideProject_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Dialog_HideItem(ProjectTree, Options.View_HiddenProjects);
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
            if (ProjectTree.SelectedNode == null) {
                return;
            }

            if (ProjectTree.SelectedNode.Text == currentProject.DisplayName()) {
                Common.Warn("Cannot delete the item being timed.");
                return;
            }

            Action_DeleteItem(ProjectTree);
        }

        // Action | New Activity
        private void MenuActionNewActivity_Click(object sender, EventArgs e)
        {
            Classes.Activity Activity = new Classes.Activity(Database);
            Dialog_NewItem(ActivityTree, "New Activity", false, (Classes.TreeAttribute)Activity, Timekeeper.IMG_ACTIVITY);
        }

        // Action | New Activity Folder
        private void MenuActionNewActivityFolder_Click(object sender, EventArgs e)
        {
            Classes.Activity Activity = new Classes.Activity(Database);
            Dialog_NewItem(ActivityTree, "New Activity Folder", true, (Classes.TreeAttribute)Activity, Timekeeper.IMG_ACTIVITY);
        }

        // Action | Edit Activity
        private void MenuActionEdit_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Classes.Activity Activity = (Classes.Activity)ActivityTree.SelectedNode.Tag;
                Dialog_EditItem(ActivityTree, "Edit Activity", (Classes.TreeAttribute)Activity);
            }
        }

        // Action | Hide Activity
        private void MenuActionHideActivity_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Dialog_HideItem(ActivityTree, Options.View_HiddenActivities);
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
            if (ActivityTree.SelectedNode == null) {
                return;
            }

            if (ActivityTree.SelectedNode.Text == currentActivity.DisplayName()) {
                Common.Warn("Cannot delete the item being timed.");
                return;
            }

            Action_DeleteItem(ActivityTree);
        }

        //---------------------------------------------------------------------

        // Report | Grid
        private void menuReportsGrid_Click(object sender, EventArgs e)
        {
            // FIXME: should this logic be in Main.Dialog.cs?

            /*
            Classes.GridOptions GridOptions = new Classes.GridOptions();
            Forms.Reports.Grid GridDialog = new Forms.Reports.Grid(GridOptions);
            GridDialog.Show(this);
            */
            Forms.Reports.Grid GridDialog = new Forms.Reports.Grid();
            GridDialog.Show();

            /*
            Forms.Reports.Grid grid = new Forms.Reports.Grid(Database);
            grid.lastGridViewId = Options.State_LastGridOptionsId;
            grid.Show(this);
            */
            OpenForms.Add(GridDialog);

            // FIXME: needed?
            //Options.State_LastGridOptionsId = GridDialog.lastGridViewId;
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

        // Tools | Find
        private void MenuToolFind_Click(object sender, EventArgs e)
        {
            Classes.FindOptions FindOptions = new Classes.FindOptions();
            Forms.Find FindDialog = new Forms.Find(FindOptions, Browser_GotoEntry);
            FindDialog.Show(this); // FIXME: why does this get flaky when "this" isn't specified?
        }

        // Tools | Notebook
        private void MenuToolNotebook_Click(object sender, EventArgs e)
        {
            fToolJournal dlg = new fToolJournal(Database);
            dlg.ActiveControl = dlg.wEntry;
            if (dlg.ShowDialog(this) == DialogResult.OK && dlg.is_dirty) {
                Action_UpdateNotebook(dlg.wEntry.Text, dlg.wEntryDate.Value, dlg.wJumpBox.SelectedIndex == -1);
            }
        }

        // Tools | Calendar
        private void MenuToolCalendar_Click(object sender, EventArgs e)
        {
            calendar = new fToolCalendar();
            calendar.Show(this);
            OpenForms.Add(calendar);
        }

        // Tools | Stopwatch
        private void MenuToolStopwatch_Click(object sender, EventArgs e)
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
        private void MenuToolCountdown_Click(object sender, EventArgs e)
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
        private void MenuToolReminders_Click(object sender, EventArgs e)
        {
            fToolReminders dlg = new fToolReminders();
            dlg.ShowDialog(this);
        }

        // Tools | Options
        private void MenuToolOptions_Click(object sender, EventArgs e)
        {
            Dialog_Options();
        }

        private void MenuToolOptionsLegacy_Click(object sender, EventArgs e)
        {
            Dialog_Options_Legacy();
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
            Help.ShowHelp(this, "http://www.technitivity.com/timekeeper/help/" + Timekeeper.SHORT_VERSION + "/");
        }

        // Help | About
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            File db = new File(Database);
            Row dbinfo = db.Info();
            About dlg = new About(dbinfo);
            dlg.ShowDialog(this);
        }

        //---------------------------------------------------------------------

        // Toolbar Functions | Browser | First Entry
        private void MenuToolbarBrowserFirst_Click(object sender, EventArgs e)
        {
            Browser_GotoFirstEntry();
        }

        // Toolbar Functions | Browser | Previous Entry
        private void MenuToolbarBrowserPrev_Click(object sender, EventArgs e)
        {
            Browser_GotoPreviousEntry();
        }

        // Toolbar Functions | Browser | Next Entry
        private void MenuToolbarBrowserNext_Click(object sender, EventArgs e)
        {
            Browser_GotoNextEntry();
        }

        // Toolbar Functions | Browser | Last Entry
        private void MenuToolbarBrowserLast_Click(object sender, EventArgs e)
        {
            Browser_GotoLastEntry();
        }

        // Toolbar Functions | Browser | New Entry
        private void MenuToolbarBrowserNew_Click(object sender, EventArgs e)
        {
            Browser_SetupForStarting();
            Entry.AdvanceIndex();
        }

        // Toolbar Functions | Browser | Close Start Gap
        private void MenuToolbarBrowserCloseStartGap_Click(object sender, EventArgs e)
        {
            Browser_CloseStartGap();
        }

        // Toolbar Functions | Browser | Close End Gap
        private void MenuToolbarBrowserCloseEndGap_Click(object sender, EventArgs e)
        {
            Browser_CloseStopGap();
        }

        // Toolbar Functions | Browser | Revert
        private void MenuToolbarBrowserRevert_Click(object sender, EventArgs e)
        {
            Browser_RevertEntry();
        }

        // Toolbar Functions | Browser | Unlock
        private void MenuToolbarBrowserUnlock_Click(object sender, EventArgs e)
        {
            Browser_UnlockEntry();
        }

        //---------------------------------------------------------------------
        // Context Menu Events
        //---------------------------------------------------------------------

        // Popup Project | Rename
        private void PopupMenuProjectRename_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
                ProjectTree.SelectedNode.Text = Project.Name;
                ProjectTree.SelectedNode.BeginEdit();
            }
        }

        // Popup Project | Use Projects
        private void PopupMenuProjectUseProjects_Click(object sender, EventArgs e)
        {
            Action_UseProjects(!PopupMenuProjectUseProjects.Checked);
        }

        // Popup Project | Use Activities
        private void PopupMenuProjectUseActivities_Click(object sender, EventArgs e)
        {
            Action_UseActivities(!PopupMenuProjectUseActivities.Checked);
        }

        // Poup Project | Swap Panes
        private void PopupMenuProjectSwapPanes_Click(object sender, EventArgs e)
        {
            Action_SwapPanes();
        }

        // Popup Projects | Properties
        private void PopupMenuProjectProperties_Click(object sender, EventArgs e)
        {
            if (ProjectTree.SelectedNode != null) {
                Classes.Project item = (Classes.Project)ProjectTree.SelectedNode.Tag;
                Dialog_Properties((Classes.TreeAttribute)item);
            }
        }

        // Popup Activity | Rename
        private void PopupMenuActivityRename_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                ActivityTree.SelectedNode.BeginEdit();
            }
        }

        // Popup Activity | Use Projects
        private void PopupMenuActivityUseProjects_Click(object sender, EventArgs e)
        {
            Action_UseProjects(!PopupMenuActivityUseProjects.Checked);
        }

        // Popup Activity | Use Activities
        private void PopupMenuActivityUseActivities_Click(object sender, EventArgs e)
        {
            Action_UseActivities(!PopupMenuActivityUseActivities.Checked);
        }

        // Poup Activity | Swap Panes
        private void PopupMenuActivitySwapPanes_Click(object sender, EventArgs e)
        {
            Action_SwapPanes();
        }

        // Poup Activity | Properties
        private void PopupMenuActivityProperties_Click(object sender, EventArgs e)
        {
            if (ActivityTree.SelectedNode != null) {
                Classes.Activity item = (Classes.Activity)ActivityTree.SelectedNode.Tag;
                Dialog_Properties((Classes.TreeAttribute)item);
            }
        }

        //---------------------------------------------------------------------
        // Keyboard events
        //---------------------------------------------------------------------

        // Project window keys
        private void ProjectTree_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2) {
                Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
                ProjectTree.SelectedNode.Text = Project.Name;
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
            TreeNode Node  = ProjectTree.SelectedNode;
            Classes.Project Project = (Classes.Project)Node.Tag;

            if (e.Label == null) {
                // This means they hit escape, so just reset the
                // node's text to what it was before this started.
                Node.Text = Project.DisplayName();
            } else {
                if (Action_RenameItem(Node, Project, e.Label)) {
                    Node.Text = Project.DisplayName();
                }
            }

            // Edit's never cancelled: we're manually handling all cases,
            // so don't give control back to the framework.
            e.CancelEdit = true;
        }

        //---------------------------------------------------------------------

        private void ActivityTree_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            TreeNode node  = ActivityTree.SelectedNode;
            Classes.TreeAttribute item = (Classes.TreeAttribute)node.Tag;
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

        private void wLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Action_ChangedLocation();
        }

        //---------------------------------------------------------------------

        private void wCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            Action_ChangedCategory();
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
                if (TrayIcon.Visible && (Options.Behavior_Window_MinimizeToTray)) {
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
            if(!Action_FormLoad()) {
                Environment.Exit(1);
            }

            // Jump right to the new thing.
            //MenuFileUtilitiesImport_Click(sender, e);
        }

        //---------------------------------------------------------------------

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Action_FormClose();
        }

        //---------------------------------------------------------------------

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (timerRunning == true) {
                Common.Warn("You must stop the timer before exiting.");
                e.Cancel = true;
            } else {
                // override settings in persistent dialogs
                // TODO: no more "persistent dialog boxes" -- that should have been a red flag.

                // Save row, just in case
                Browser_SaveRow(false);

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
                Classes.Project Project = (Classes.Project)SelectedNode.Tag;
                if (!Project.IsFolderOpened) {
                    Project.OpenFolder();
                }
            }
        }

        private void ProjectTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Classes.Project Project = (Classes.Project)SelectedNode.Tag;
                if (Project.IsFolderOpened) {
                    Project.CloseFolder();
                }
            }
        }

        private void ActivityTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Classes.Activity Activity = (Classes.Activity)SelectedNode.Tag;
                if (!Activity.IsFolderOpened) {
                    Activity.OpenFolder();
                }
            }
        }

        private void ActivityTree_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            TreeNode SelectedNode = e.Node;
            if (SelectedNode != null) {
                Classes.Activity Activity = (Classes.Activity)SelectedNode.Tag;
                if (Activity.IsFolderOpened) {
                    Activity.CloseFolder();
                }
            }
        }

        private void wStartTime_Enter(object sender, EventArgs e)
        {
            // This is in anticipation that the value will change
            StartTimeManuallySet = true;
        }

        //---------------------------------------------------------------------
        // Testing Area
        //---------------------------------------------------------------------

        private void wStartTime_KeyDown(object sender, KeyEventArgs e)
        {
            Action_DateTimeClipboard(wStartTime, e);
        }

        private void wStopTime_KeyDown(object sender, KeyEventArgs e)
        {
            Action_DateTimeClipboard(wStopTime, e);
        }

        private void Action_DateTimeClipboard(DateTimePicker picker, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.C) && (e.Modifiers == Keys.Control)) {
                Action_CopyDate(picker);
            }

            if ((e.KeyCode == Keys.V) && (e.Modifiers == Keys.Control)) {
                Action_PasteDate(picker);
            }
        }

        private void Action_CopyDate(DateTimePicker picker)
        {
            Clipboard.SetData(DataFormats.StringFormat, picker.Value.ToString(Options.Advanced_DateTimeFormat));
        }

        private void Action_PasteDate(DateTimePicker picker)
        {
            string ClipboardTime = (string)Clipboard.GetData(DataFormats.StringFormat);
            try {
                picker.Value = Convert.ToDateTime(ClipboardTime);
            }
            catch {
                Timekeeper.Debug("Invalid date/time format: " + ClipboardTime);
            }
        }

        private void PopupMenuDatesCopy_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem PopupItem = (ToolStripDropDownItem)sender;
            DateTimePicker Picker = (DateTimePicker)((ContextMenuStrip)PopupItem.Owner).SourceControl;
            Action_CopyDate((DateTimePicker)Picker);
        }

        private void PopupMenuDatesPaste_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem PopupItem = (ToolStripDropDownItem)sender;
            DateTimePicker Picker = (DateTimePicker)((ContextMenuStrip)PopupItem.Owner).SourceControl;
            Action_PasteDate((DateTimePicker)Picker);
        }

        private void wStopTime_ValueChanged(object sender, EventArgs e)
        {
            if (!isBrowsing) {
                return;
            }

            // Remember! This event gets fired while loading, browsing, etc.
            // It's not just in response to the user typing a new value in.

            // prototype for Date/Time sanity checks.
            // basic rules: Stop Time has to be after start time.
            // No part of the Start to Stop time range can overlap other entries.
            // i.e., Stop Time <= Start Time next entry
            //   and Start Time >= Stop Time of previous entry

            // August 20, 2013 note. In a word, FIXME.
            // More elaborately, the logic below is too
            // simplistic. Here's the amended rule:
            // 1. User can enter any start/stop time.
            // 2. Once completed, the new Start and End time
            //    together need to not overlap with any other
            //    entries.
            // 3. This is trickier than it sounds.
            // Go!

            if (wStopTime.Value < wStartTime.Value) {
                Common.Warn("Stop time cannot be before Start time");
                wStopTime.Value = priorLoadedBrowserEntry.StopTime;
                return;
            }

            DateTime NextStartTime = Browser_GetNextStartTime();
            if (wStopTime.Value > NextStartTime) {
                Common.Warn("Stop time cannot be after Start time of next entry");
                wStopTime.Value = priorLoadedBrowserEntry.StopTime;
                return;
            }

            DateTime PreviousEndTime = Browser_GetPreviousEndTime();
            if (wStartTime.Value < PreviousEndTime) {
                Common.Warn("Start time cannot be before Stop time of previous entry");
                wStartTime.Value = priorLoadedBrowserEntry.StartTime;
                return;
            }

            // TODO: Lastly, move this logic to Main.Action.cs
        }

        private void wStartTime_ValueChanged(object sender, EventArgs e)
        {
        }

        private void MenuToolbarBrowserSplitEntry_Click(object sender, EventArgs e)
        {
            /*
             * 
             * Already deprecated! But save this code for later. It took me a good
             * little while to figure out (placing a window over top a toolstrip
             * button as if it were a drop-down box.)
             * 
             */

            /*
            Forms.SplitEntry DialogBox = new SplitEntry();

            Rectangle Rect = toolControlSplitEntry.Bounds;
            Point StartPoint = BrowserToolbar.PointToScreen(new Point(Rect.X, Rect.Y));
            StartPoint.Y += 23;

            DialogBox.Location = StartPoint;

            DialogBox.ShowDialog(this);
            */
        }

        private void MenuToolbarBrowserSplitEntry2_Click(object sender, EventArgs e)
        {
            Action_SplitEntry(2);
        }

        private void toolControlSplitEntry3_Click(object sender, EventArgs e)
        {
            Action_SplitEntry(3);
        }

        private void toolControlSplitEntry4_Click(object sender, EventArgs e)
        {
            Action_SplitEntry(4);
        }

        private void MenuActionManageLocations_Click(object sender, EventArgs e)
        {
            int SavedSelection = wLocation.SelectedIndex;
            Dialog_LocationManager();
            wLocation.SelectedIndex = SavedSelection;
        }

        private void MenuActionManageCategories_Click(object sender, EventArgs e)
        {
            Action_ChangedCategory();
        }

        private void MenuFileUtilitiesImport_Click(object sender, EventArgs e)
        {
            Forms.ImportWizard DialogBox = new Forms.ImportWizard();
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                reloadProjects();
            }
        }

        private void MenuToolTodo_Click(object sender, EventArgs e)
        {
            // Only allow one open Todo list at a time
            foreach (Form Form in OpenForms) {
                if (Form.Name == "Todo") {
                    if (Form.IsDisposed) {
                        // Ignore
                    } else {
                        Form.Show();
                        Form.Focus();
                        return;
                    }
                }
            }

            // If we've made it this far, instantiate a new one.
            Forms.Todo DialogBox = new Forms.Todo();
            DialogBox.Show();
            OpenForms.Add(DialogBox);
        }

        private void PopupMenuProjectAddtoTodoList_Click(object sender, EventArgs e)
        {
            Forms.TodoDetail DialogBox = new Forms.TodoDetail();

            Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
            DialogBox.ProjectId = Project.ItemId;

            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                Classes.TodoItem TodoItem = DialogBox.TodoItem;
                TodoItem.Create();

                // If a Todo form is open, add it to its list
                foreach (Form Form in OpenForms) {
                    if (Form.Name == "Todo") {
                        Forms.Todo Todo = (Forms.Todo)Form;
                        Todo.AddItem(Project.DisplayName(), TodoItem, Todo.TodoList.Groups[TodoItem.StatusName]);
                    }
                }
            }
        }

        private void PopupMenuProject_Opening(object sender, CancelEventArgs e)
        {
            // Enable/disable todo list
            Classes.TodoItemCollection TodoItems = new Classes.TodoItemCollection();
            Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;

            if (Project.IsFolder) {
                PopupMenuProjectAddtoTodoList.Enabled = false;
            } else {
                PopupMenuProjectAddtoTodoList.Enabled = !TodoItems.Exists(Project.ItemId);
            }
        }

        //---------------------------------------------------------------------

    }
}