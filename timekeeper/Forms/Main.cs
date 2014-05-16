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
        private string DatabaseFileName;

        // Options
        private Classes.Options Options;

        // Persistent dialog boxes
        // FIXME: why? Why these?
        //private Forms.OptionsLegacy options;
        private Forms.Tools.Calendar calendar;

        // Misc
        private bool StartTimeManuallySet = false;

        // Persistent objects
        private Classes.JournalEntryCollection Entries;
        private Classes.Meta Meta;
        private Classes.Widgets Widgets;

        // Objects currently being timed
        private Classes.JournalEntry TimedEntry;
        private Classes.Project TimedProject;
        private Classes.Activity TimedActivity;
        private Classes.Location TimedLocation;
        private Classes.Category TimedCategory;

        // MemoEditor control
        private Forms.Shared.MemoEditor MemoEditor;

        // FIXME: class-wide values?
        private ComboTreeNode currentProjectNode;
        private ComboTreeNode currentActivityNode;

        // Timer properties
        private bool timerRunning = false;
        private DateTime timerLastRun;
        private long ElapsedSinceStart;
        private long ElapsedProjectToday;
        private long ElapsedActivityToday;
        private long ElapsedAllToday;

        // Open form tracking
        public List<Form> OpenForms = new List<Form>();

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

        // File | Utilities | Import
        private void MenuFileUtilitiesImport_Click(object sender, EventArgs e)
        {
            Forms.Wizards.Import DialogBox = new Forms.Wizards.Import();
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                reloadProjects();
            }
        }

        // File | Utilities | Check
        private void MenuFileUtilitiesCheck_Click(object sender, EventArgs e)
        {
            var DialogBox = new Reports.DatabaseCheck(Browser_GotoEntry);
            DialogBox.Show(this);
            OpenForms.Add(DialogBox);
        }

        // File | Utilities | Reindex
        private void MenuFileUtilitiesReindex_Click(object sender, EventArgs e)
        {
            Action_Reindex();
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

        // Action | Manage Projects
        private void MenuActionManageProjects_Click(object sender, EventArgs e)
        {
            Forms.Shared.TreeAttributeManager Form = new Shared.TreeAttributeManager(Timekeeper.Dimension.Project);
            Form.ShowDialog(this);
        }

        // Action | Manage Activities
        private void MenuActionManageActivities_Click(object sender, EventArgs e)
        {
            Forms.Shared.TreeAttributeManager Form = new Shared.TreeAttributeManager(Timekeeper.Dimension.Activity);
            Form.ShowDialog(this);
        }

        // Action | Manage Locations
        private void MenuActionManageLocations_Click(object sender, EventArgs e)
        {
            int SavedSelection = wLocation.SelectedIndex;
            Dialog_LocationManager();
            wLocation.SelectedIndex = SavedSelection;
        }

        // Action | Manage Categories
        private void MenuActionManageCategories_Click(object sender, EventArgs e)
        {
            Action_ChangedCategory();
        }

        //---------------------------------------------------------------------

        // Report | Grid
        private void menuReportsGrid_Click(object sender, EventArgs e)
        {
            Forms.Reports.Grid GridDialog = new Forms.Reports.Grid();
            GridDialog.Show();
            OpenForms.Add(GridDialog);
        }

        // Report | Quick List
        private void menuReportsQuick_Click(object sender, EventArgs e)
        {
            Forms.Reports.JournalEntry Report = new Forms.Reports.JournalEntry();
            Report.Show();
        }

        // Report | Punch Card
        private void menuReportsPunch_Click(object sender, EventArgs e)
        {
            Forms.Reports.PunchCard punch = new Forms.Reports.PunchCard();
            punch.Show(this);
            OpenForms.Add(punch);
        }

        //---------------------------------------------------------------------

        // Tools | Find
        private void MenuToolFind_Click(object sender, EventArgs e)
        {
            Forms.Find FindDialog = new Forms.Find(Browser_GotoEntry, Find.FindDataSources.Journal);
            FindDialog.Show(this); // FIXME: why does this get flaky when "this" isn't specified?
            OpenForms.Add(FindDialog);
        }

        // Tools | To Do List
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
            Forms.Tools.Todo DialogBox = new Forms.Tools.Todo();
            DialogBox.Show();
            OpenForms.Add(DialogBox);
        }

        // Tools | Events & Reminders
        private void MenuToolReminders_Click(object sender, EventArgs e)
        {
            Forms.Tools.Event DialogBox = new Forms.Tools.Event(this);
            DialogBox.Show();
            OpenForms.Add(DialogBox);
        }

        // Tools | Notebook
        private void MenuToolNotebook_Click(object sender, EventArgs e)
        {
            // TODO: Don't call some of the new-style windows "Dialog" any more
            // This is the first to just call them windows. (cf. FindDialog above)

            Forms.Tools.Notebook NotebookWindow = new Forms.Tools.Notebook();
            NotebookWindow.Show();
            OpenForms.Add(NotebookWindow);

            /* this stuff belongs in the window itself ... not here, not as an "Action_"
            NotebookWindow.ActiveControl = NotebookWindow.wEntry;
            if (NotebookWindow.ShowDialog(this) == DialogResult.OK && NotebookWindow.is_dirty) {
                Action_UpdateNotebook(NotebookWindow.wEntry.Text, NotebookWindow.wEntryDate.Value, NotebookWindow.wJumpBox.SelectedIndex == -1);
            }
            */
        }

        // Tools | Calendar
        private void MenuToolCalendar_Click(object sender, EventArgs e)
        {
            calendar = new Forms.Tools.Calendar();
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

            Forms.Tools.Stopwatch dlg = new Forms.Tools.Stopwatch();
            dlg.Show(this);
            OpenForms.Add(dlg);
        }

        // Tools | Countdown
        private void MenuToolCountdown_Click(object sender, EventArgs e)
        {
            Forms.Tools.Countdown DialogBox = new Forms.Tools.Countdown(this);
            DialogBox.Show();
            OpenForms.Add(DialogBox);
        }

        // Tools | Date Calculator
        private void menuToolsDatecalc_Click(object sender, EventArgs e)
        {
            Forms.Tools.DateCalculator dlg = new Forms.Tools.DateCalculator();
            dlg.Show(this);
            OpenForms.Add(dlg);
        }

        // Tools | Options
        private void MenuToolOptions_Click(object sender, EventArgs e)
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
            Help.ShowHelp(this, "http://www.technitivity.com/timekeeper/help/" + Timekeeper.SHORT_VERSION + "/");
        }

        // Help | About
        private void menuHelpAbout_Click(object sender, EventArgs e)
        {
            File db = new File();
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
            TimedEntry.AdvanceIndex();
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
        private void MenuToolbarBrowserSave_Click(object sender, EventArgs e)
        {
            Browser_SaveRow(true);
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

        // Toolbar Functions | Format | Bold
        private void MenuToolbarFormatBold_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatBoldButton_Click(sender, e);
        }

        // Toolbar Functions | Format | Italic
        private void MenuToolbarFormatItalic_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatItalicButton_Click(sender, e);
        }

        // Toolbar Functions | Format | Underline
        private void MenuToolbarFormatUnderline_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatUnderlineButton_Click(sender, e);
        }

        // Toolbar Functions | Format | Strikethrough
        private void MenuToolbarFormatStrikethrough_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatStrikethroughButton_Click(sender, e);
        }

        // Toolbar Functions | Format | Bulleted List
        private void MenuToolbarFormatBulletedList_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatBulletedListButton_Click(sender, e);
        }

        // Toolbar Functions | Format | Numbered List
        private void MenuToolbarFormatNumberedList_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatNumberedListButton_Click(sender, e);
        }

        // Toolbar Functions | Format | Heading 1
        private void MenuToolbarFormatHeading1_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatHeading1Button_Click(sender, e);
        }

        // Toolbar Functions | Format | Heading 2
        private void MenuToolbarFormatHeading2_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatHeading2Button_Click(sender, e);
        }

        // Toolbar Functions | Format | Heading 3
        private void MenuToolbarFormatHeading3_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatHeading3Button_Click(sender, e);
        }

        // Toolbar Functions | Format | Code
        private void MenuToolbarFormatCode_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatCodeButton_Click(sender, e);
        }

        // Toolbar Functions | Format | Blockquote
        private void MenuToolbarFormatBlockquote_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatBlockquoteButton_Click(sender, e);
        }

        // Toolbar Functions | Format | Horizontal Rule
        private void MenuToolbarFormatHorizontalRule_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatHorizontalRuleButton_Click(sender, e);
        }

        //---------------------------------------------------------------------
        // Context Menu Events
        //---------------------------------------------------------------------

        // Popup Project | Use Projects
        /*
        private void PopupMenuProjectUseProjects_Click(object sender, EventArgs e)
        {
            Action_UseProjects(!PopupMenuProjectUseProjects.Checked);
        }

        // Popup Project | Use Activities
        private void PopupMenuProjectUseActivities_Click(object sender, EventArgs e)
        {
            Action_UseActivities(!PopupMenuProjectUseActivities.Checked);
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
        */

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
            Action_EnableRevert(MemoEditor.Text, priorLoadedBrowserEntry.Memo);
        }

        //---------------------------------------------------------------------
        // On Item Change
        //---------------------------------------------------------------------

        private void ProjectTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Action_ChangedProject();
        }

        //---------------------------------------------------------------------

        private void ActivityTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Action_ChangedActivity();
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

        //---------------------------------------------------------------------

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
                e.Cancel = false;
            }
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private void reloadProjects()
        {
            ProjectTreeDropdown.Nodes.Clear();
            Widgets.BuildProjectTree(ProjectTreeDropdown.Nodes);
        }

        private void reloadActivities()
        {
            ActivityTreeDropdown.Nodes.Clear();
            Widgets.BuildActivityTree(ActivityTreeDropdown.Nodes);
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


            /*
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
            */

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

        //---------------------------------------------------------------------
        // FIXME - EXPERIMENTAL - NOT READY FOR PRIME TIME
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

    }
}