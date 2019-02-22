using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.Resources;
using System.Xml;

using Timekeeper.Classes.Toolbox;

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

        // Misc
        private bool StartTimeManuallySet = false;

        // Persistent objects
        private Classes.JournalEntryCollection Entries;
        private Classes.Meta Meta;
        private Classes.Widgets Widgets;

        // Objects currently being timed
        private Classes.JournalEntry TimedEntry;
        private Classes.TreeAttribute TimedProject;
        private Classes.TreeAttribute TimedActivity;
        private Classes.TreeAttribute TimedLocation;
        private Classes.TreeAttribute TimedCategory;

        // MemoEditor control
        private Forms.Shared.MemoEditor MemoEditor;

        // Timer properties
        private bool timerRunning = false;
        private DateTimeOffset timerLastRun;
        private long ElapsedSinceStart;
        private long ElapsedProjectToday;
        private long ElapsedActivityToday;
        private long ElapsedLocationToday;
        private long ElapsedCategoryToday;
        private long ElapsedAllToday;

        // Hack? Set when editing start/end time
        public enum TimeBox { None, StartTime, StopTime, Duration };
        private TimeBox InlineEditing = TimeBox.None;

        // Open form tracking
        public List<Form> OpenForms = new List<Form>();

        // Plugin tracking
        public Dictionary<Type, object> LoadedPlugins = new Dictionary<Type, object>();

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

        // File | Exit
        private void MenuFileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //---------------------------------------------------------------------

        // Adjust menu upon opening
        private void MenuAction_DropDownOpened(object sender, EventArgs e)
        {
            Action_SetActionSepVisibility();
        }

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

        // Action | Find
        private void MenuActionFind_Click(object sender, EventArgs e)
        {
            Forms.Find FindDialog = new Forms.Find(Browser_GotoEntry, Find.FindDataSources.Journal);
            FindDialog.Show();
            OpenForms.Add(FindDialog);
        }

        // Action | Manage Projects
        private void MenuActionManageProjects_Click(object sender, EventArgs e)
        {
            Action_ManageTree(Timekeeper.Dimension.Project, ProjectTreeDropdown);

            /*
            if (Action_ManageTree(Timekeeper.Dimension.Project)) {
                IgnoreDimensionChanges = true;
                ComboTreeNode SavedNode = ProjectTreeDropdown.SelectedNode;
                Classes.TreeAttribute Item = (Classes.TreeAttribute)SavedNode.Tag;
                ProjectTreeDropdown.Nodes.Clear();
                Widgets.BuildProjectTree(ProjectTreeDropdown.Nodes);
                ComboTreeNode RestoredNode = Widgets.FindTreeNode(ProjectTreeDropdown.Nodes, Item.ItemId);
                if (RestoredNode == null)
                    SetDefaultNode(ProjectTreeDropdown);
                else
                    ProjectTreeDropdown.SelectedNode = RestoredNode;
                IgnoreDimensionChanges = false;
            }
            */
        }

        // Action | Manage Activities
        private void MenuActionManageActivities_Click(object sender, EventArgs e)
        {
            Action_ManageTree(Timekeeper.Dimension.Activity, ActivityTreeDropdown);
        }

        // Action | Manage Locations
        private void MenuActionManageLocations_Click(object sender, EventArgs e)
        {
            Action_ManageTree(Timekeeper.Dimension.Location, LocationTreeDropdown);
        }

        // Action | Manage Categories
        private void MenuActionManageCategories_Click(object sender, EventArgs e)
        {
            Action_ManageTree(Timekeeper.Dimension.Category, CategoryTreeDropdown);
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
            try {
                Forms.Tools.Calendar Calendar = new Forms.Tools.Calendar(Browser_GotoEntry);
                Calendar.Show();
                OpenForms.Add(Calendar);
            } catch (Exception x) {
                Timekeeper.Exception(x);
            }
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
        private void MenuHelpContents_Click(object sender, EventArgs e)
        {
            Help.ShowHelpIndex(this, "timekeeper.chm");
        }

        // Help | Web Support
        private void MenuHelpDocumentation_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "http://www.technitivity.com/timekeeper/documentation/" + Timekeeper.SHORT_VERSION + "/");
        }

        // Help | Web Site
        private void MenuHelpWebSite_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "http://www.technitivity.com/timekeeper/");
        }

        // Help | Check for Updates
        private void MenuHelpCheckForUpdates_Click(object sender, EventArgs e)
        {
            Action_CheckForUpdates();
        }

        // Help | About
        private void MenuHelpAbout_Click(object sender, EventArgs e)
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

        // Toolbar Functions | Browser | Previous Entry | Browse by UNIT
        private void ToolbarPrevEntryBrowseByUnit_Click(object sender, EventArgs e)
        {
            Browser_SetBrowseModePrev((ToolStripMenuItem)sender);
        }

        // Toolbar Functions | Browser | Next Entry
        private void MenuToolbarBrowserNext_Click(object sender, EventArgs e)
        {
            Browser_GotoNextEntry();
        }

        // Toolbar Functions | Browser | Previous Entry | Browse by UNIT
        private void ToolbarNextEntryBrowseByUnit_Click(object sender, EventArgs e)
        {
            Browser_SetBrowseModeNext((ToolStripMenuItem)sender);
        }

        // Toolbar Functions | Browser | Last Entry
        private void MenuToolbarBrowserLast_Click(object sender, EventArgs e)
        {
            Browser_GotoLastEntry();
        }

        // Toolbar Functions | Browser | New Entry
        private void MenuToolbarBrowserNew_Click(object sender, EventArgs e)
        {
            Browser_SetupForStarting(true);
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

        // Toolbar Functions | Browser | Split | in Halves
        private void MenuToolbarBrowserSplitEntry2_Click(object sender, EventArgs e)
        {
            Action_SplitEntry(2);
        }

        // Toolbar Functions | Browser | Split | in Thirds
        private void MenuToolbarBrowserSplitEntry3_Click(object sender, EventArgs e)
        {
            Action_SplitEntry(3);
        }

        // Toolbar Functions | Browser | Split | in Fourths
        private void MenuToolbarBrowserSplitEntry4_Click(object sender, EventArgs e)
        {
            Action_SplitEntry(4);
        }

        // Toolbar Functions | Browser | Split | Join Entries
        private void MenuToolbarBrowserJoinEntries_Click(object sender, EventArgs e)
        {
            Action_JoinEntries();
        }

        // Toolbar Functions | Browser | Revert
        private void MenuToolbarBrowserSave_Click(object sender, EventArgs e)
        {
            Browser_LockAndLoad(browserEntry.JournalId);
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

        // Toolbar Functions | Format | Checkbox List
        private void MenuToolbarFormatCheckboxList_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatCheckboxListButton_Click(sender, e);
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

        // Toolbar Functions | Format | Checkbox
        private void MenuToolbarFormatCheckbox_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatCheckboxButton_Click(sender, e);
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

        private Timekeeper.Dimension GetPopupDimension()
        {
            int Control = Convert.ToInt32((string)PopupMenuDimension.SourceControl.Tag);
            Timekeeper.Dimension Dim = (Timekeeper.Dimension)Control;
            return Dim;
        }

        private void PopupMenuDimension_Opening(object sender, CancelEventArgs e)
        {
            // Alter menu item text
            Timekeeper.Dimension Dim = GetPopupDimension();
            switch (Dim) {
                case Timekeeper.Dimension.Project:
                    PopupMenuDimensionNewItem.Text = "New Project";
                    PopupMenuDimensionManageItems.Text = "Manage Projects";
                    break;
                case Timekeeper.Dimension.Activity:
                    PopupMenuDimensionNewItem.Text = "New Activity";
                    PopupMenuDimensionManageItems.Text = "Manage Activities";
                    break;
                case Timekeeper.Dimension.Location:
                    PopupMenuDimensionNewItem.Text = "New Location";
                    PopupMenuDimensionManageItems.Text = "Manage Locations";
                    break;
                case Timekeeper.Dimension.Category:
                    PopupMenuDimensionNewItem.Text = "New Category";
                    PopupMenuDimensionManageItems.Text = "Manage Categories";
                    break;
            }

            // Check dimensional usage
            PopupMenuDimensionUseProjects.Checked = Options.Layout_UseProjects;
            PopupMenuDimensionUseActivities.Checked = Options.Layout_UseActivities;
            PopupMenuDimensionUseLocations.Checked = Options.Layout_UseLocations;
            PopupMenuDimensionUseCategories.Checked = Options.Layout_UseCategories;
        }

        private void PopupMenuDimensionNewItem_Click(object sender, EventArgs e)
        {
            ComboTreeBox Box = (ComboTreeBox)PopupMenuDimension.SourceControl;
            Timekeeper.Dimension Dim = GetPopupDimension();
            Classes.TreeAttribute Item = this.Widgets.CreateTreeItemDialog(Box, Dim, false);

            if (Item != null) {
                ComboTreeNode NodeToSelect = Widgets.FindTreeNode(Box.Nodes, Item.ItemId);
                if (NodeToSelect == null)
                    this.Widgets.SetDefaultNode(Box);
                else
                    Box.SelectedNode = NodeToSelect;
            }
        }

        private void PopupMenuDimensionManageItems_Click(object sender, EventArgs e)
        {
            Timekeeper.Dimension Dim = GetPopupDimension();

            ToolStripDropDownItem PopupItem = (ToolStripDropDownItem)sender;
            ComboTreeBox Tree = (ComboTreeBox)((ContextMenuStrip)PopupItem.Owner).SourceControl;
            Action_ManageTree(Dim, Tree);

            // This isn't working. I'd like it to work.
            /*
            ComboTreeBox Box = (ComboTreeBox)PopupMenuDimension.SourceControl;
            Rectangle Rect = Box.Bounds;
            Point StartPoint = PanelControls.PointToScreen(new Point(Rect.X, Rect.Y));
            Form.StartPosition = FormStartPosition.Manual;
            Form.Location = StartPoint;
            */
        }

        private void PopupMenuDimensionUseProjects_Click(object sender, EventArgs e)
        {
            Action_UseProjects(!PopupMenuDimensionUseProjects.Checked);
            Action_AdjustControlPanel();
        }

        private void PopupMenuDimensionUseActivities_Click(object sender, EventArgs e)
        {
            Action_UseActivities(!PopupMenuDimensionUseActivities.Checked);
            Action_AdjustControlPanel();
        }

        private void PopupMenuDimensionUseLocations_Click(object sender, EventArgs e)
        {
            Action_UseLocations(!PopupMenuDimensionUseLocations.Checked);
            Action_AdjustControlPanel();
        }

        private void PopupMenuDimensionUseCategories_Click(object sender, EventArgs e)
        {
            Action_UseCategories(!PopupMenuDimensionUseCategories.Checked);
            Action_AdjustControlPanel();
        }

        private void PopupMenuDimensionProperties_Click(object sender, EventArgs e)
        {
            Timekeeper.Dimension Dim = GetPopupDimension();
            ComboTreeBox Box = null;

            switch (Dim) {
                case Timekeeper.Dimension.Project:
                    Box = ProjectTreeDropdown;
                    break;
                case Timekeeper.Dimension.Activity:
                    Box = ActivityTreeDropdown;
                    break;
                case Timekeeper.Dimension.Location:
                    Box = LocationTreeDropdown;
                    break;
                case Timekeeper.Dimension.Category:
                    Box = CategoryTreeDropdown;
                    break;
            }

            if ((Box != null) && (Box.SelectedNode != null)) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)Box.SelectedNode.Tag;
                Forms.Properties Dialog = Widgets.GetPropertiesDialog(Item);
                Dialog.ShowDialog(this);
            }
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

        private void IdleTimer_Tick(object sender, EventArgs e)
        {
            Action_IdleTick();
        }

        //---------------------------------------------------------------------
        // Editing events
        //---------------------------------------------------------------------

        private void wStartTime_Leave(object sender, EventArgs e)
        {
            InlineEditing = TimeBox.StartTime;
            Action_UpdateDuration(StartTimeSelector.Value, priorLoadedBrowserEntry.StartTime);
            Action_CheckStartTime();
        }

        //---------------------------------------------------------------------

        private void wStopTime_Leave(object sender, EventArgs e)
        {
            InlineEditing = TimeBox.StopTime;
            Action_UpdateDuration(StopTimeSelector.Value, priorLoadedBrowserEntry.StopTime);
        }

        //---------------------------------------------------------------------

        private void wDuration_Leave(object sender, EventArgs e)
        {
            InlineEditing = TimeBox.Duration;
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

        private void ProjectTreeDropdown_SelectedNodeChanged(object sender, EventArgs e)
        {
            Action_ChangedProject();
        }

        //---------------------------------------------------------------------

        private void ActivityTreeDropdown_SelectedNodeChanged(object sender, EventArgs e)
        {
            Action_ChangedActivity();
        }

        //---------------------------------------------------------------------

        private void LocationTreeDropdown_SelectedNodeChanged(object sender, EventArgs e)
        {
            Action_ChangedLocation();
        }

        //---------------------------------------------------------------------

        private void CategoryTreeDropdown_SelectedNodeChanged(object sender, EventArgs e)
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
        // Message Handler
        //---------------------------------------------------------------------

        /// <summary>
        /// Called when [handle message].
        /// This is called whenever a new message has been added to the "central" list.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="args">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void OnHandleMessage(object sender, EventArgs args)
        {
            var MailboxEvent = args as Classes.MessageEventArgs;

            if (MailboxEvent != null) {
                string Message = MailboxEvent.Message;

                Timekeeper.Debug("Received MailboxEvent.Message: " + Message);

                if (Message == "ReloadProjectTreeDropdown") {
                    this.IgnoreDimensionChanges = true;
                    ComboTreeNode SelectedNode = ProjectTreeDropdown.SelectedNode;
                    Classes.TreeAttribute Project = (Classes.TreeAttribute)SelectedNode.Tag;
                    this.Widgets.BuildTree(Timekeeper.Dimension.Project, ProjectTreeDropdown);
                    this.Widgets.ReselectNode(ProjectTreeDropdown, Project);
                    this.IgnoreDimensionChanges = false;
                } else {
                    Timekeeper.Warn("Unsupported MailboxEvent.Message received: " + Message);
                }

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

        //---------------------------------------------------------------------
        // Testing Area
        //---------------------------------------------------------------------

        private void wStartTime_Enter(object sender, EventArgs e)
        {
            // This is in anticipation that the value will change
            StartTimeManuallySet = true;
        }

        private void wStartTime_KeyDown(object sender, KeyEventArgs e)
        {
            Action_DateTimeClipboard(StartTimeSelector, e);
        }

        private void wStopTime_KeyDown(object sender, KeyEventArgs e)
        {
            Action_DateTimeClipboard(StopTimeSelector, e);
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

        private void PopupMenuDatesCloseGap_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem PopupItem = (ToolStripDropDownItem)sender;
            DateTimePicker Picker = (DateTimePicker)((ContextMenuStrip)PopupItem.Owner).SourceControl;
            if (Picker.Name == "StartTimeSelector") {
                Browser_CloseStartGap();
            } else {
                Browser_CloseStopGap();
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string LocalTime = Common.LocalNow();
            string UtcTime = Common.Now();
            //string UtcTime2 = DateTime.Now.ToString(Common.UTC_DATETIME_FORMAT);
            string UtcTime2 = DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssK");
            string UtcTime3 = DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssK");

            string Message = String.Format("TBX LocalTime = {0}\nTBX UtcTime = {1}\nUtcTime2 = {2}\nUtcTime3 = {3}",
                LocalTime,
                UtcTime,
                UtcTime2,
                UtcTime3);

            string UtcTimeDST    = DateTime.Parse("2014-11-01T12:00:00-05:00").ToUniversalTime().ToString(Common.UTC_DATETIME_FORMAT);
            string UtcTimeNotDST = DateTime.Parse("2014-11-03T12:00:00-06:00").ToUniversalTime().ToString(Common.UTC_DATETIME_FORMAT);

            string Message2 = String.Format("UtcTimeDST = {0}\nUtcTimeNotDST = {1}",
                UtcTimeDST,
                UtcTimeNotDST);

            this.MemoEditor.Text += Message2;

            string LocalTimeDST = DateTime.Parse(UtcTimeDST).ToLocalTime().ToString(Common.LOCAL_DATETIME_FORMAT);
            string LocalTimeNotDST = DateTime.Parse(UtcTimeNotDST).ToLocalTime().ToString(Common.LOCAL_DATETIME_FORMAT);

            string Message3 = String.Format("LocalTimeDST = {0}\nLocalTimeNotDST = {1}",
                LocalTimeDST,
                LocalTimeNotDST);

            this.MemoEditor.Text += "\n\n" + Message3;

            /*

            This seems to be working...

            UtcTimeDST      = 2014-11-01T17:00:00Z
            UtcTimeNotDST   = 2014-11-03T18:00:00Z

            LocalTimeDST    = 2014-11-01T12:00:00
            LocalTimeNotDST = 2014-11-03T12:00:00

            */

            // Now trying out a standard way of going back and forth between the
            // C# DateTimeOffset datatypes and the strings required by SQLite

            string Message4;

            string Convert1 = Timekeeper.DateForDatabase();
            string Convert2 = Timekeeper.DateForDatabase(DateTime.Now.AddMonths(2));
            string Convert3 = Timekeeper.DateForDatabase(DateTime.Now.AddMonths(5));

            Message4 = String.Format("Timekeeper.DateForDatabase()    = {0}", Convert1);
            this.MemoEditor.Text += "\n\n" + Message4;
            Message4 = String.Format("Timekeeper.DateForDatabase(+2M) = {0}", Convert2);
            this.MemoEditor.Text += "\n" + Message4;
            Message4 = String.Format("Timekeeper.DateForDatabase(+5M) = {0}", Convert3);
            this.MemoEditor.Text += "\n" + Message4;

            DateTimeOffset Revert1 = Timekeeper.StringToDate(Convert1);
            DateTimeOffset Revert2 = Timekeeper.StringToDate(Convert2);
            DateTimeOffset Revert3 = Timekeeper.StringToDate(Convert3);

            Message4 = String.Format("Timekeeper.StringToDate(Convert1) = {0}", Timekeeper.DateForDisplay(Revert1));
            this.MemoEditor.Text += "\n\n" + Message4;
            Message4 = String.Format("Timekeeper.StringToDate(Convert2) = {0}", Timekeeper.DateForDisplay(Revert2));
            this.MemoEditor.Text += "\n" + Message4;
            Message4 = String.Format("Timekeeper.StringToDate(Convert3) = {0}", Timekeeper.DateForDisplay(Revert3));
            this.MemoEditor.Text += "\n" + Message4;

            Convert1 = Timekeeper.DateForDisplay();
            Convert2 = Timekeeper.DateForDisplay(DateTime.Now.AddMonths(2));
            Convert3 = Timekeeper.DateForDisplay(DateTime.Now.AddMonths(5));

            Message4 = String.Format("Timekeeper.DateForDisplay()    = {0}", Convert1);
            this.MemoEditor.Text += "\n\n" + Message4;
            Message4 = String.Format("Timekeeper.DateForDisplay(+2M) = {0}", Convert2);
            this.MemoEditor.Text += "\n" + Message4;
            Message4 = String.Format("Timekeeper.DateForDisplay(+5M) = {0}", Convert3);
            this.MemoEditor.Text += "\n" + Message4;

            Revert1 = Timekeeper.StringToDate(Convert1);
            Revert2 = Timekeeper.StringToDate(Convert2);
            Revert3 = Timekeeper.StringToDate(Convert3);

            Message4 = String.Format("Timekeeper.StringToDate(Convert1) = {0}", Timekeeper.DateForDisplay(Revert1));
            this.MemoEditor.Text += "\n\n" + Message4;
            Message4 = String.Format("Timekeeper.StringToDate(Convert2) = {0}", Timekeeper.DateForDisplay(Revert2));
            this.MemoEditor.Text += "\n" + Message4;
            Message4 = String.Format("Timekeeper.StringToDate(Convert3) = {0}", Timekeeper.DateForDisplay(Revert3));
            this.MemoEditor.Text += "\n" + Message4;

            DateTimeOffset SpringDstTest = Timekeeper.StringToDate("2014-03-08 17:00:00");
            this.MemoEditor.Text += "\n";
            for (int i = 0; i < 24; i++) {
                Message4 = String.Format("Timekeeper.DateForDatabase() = {0}", Timekeeper.DateForDatabase(SpringDstTest));
                this.MemoEditor.Text += "\n" + Message4;
                SpringDstTest = SpringDstTest.AddHours(1);
            }

            DateTimeOffset FallDstTest = Timekeeper.StringToDate("2014-11-02 17:00:00");
            this.MemoEditor.Text += "\n";
            for (int i = 0; i < 24; i++) {
                Message4 = String.Format("Timekeeper.DateForDatabase() = {0}", Timekeeper.DateForDatabase(FallDstTest));
                this.MemoEditor.Text += "\n" + Message4;
                FallDstTest = FallDstTest.AddHours(1);
            }

            this.MemoEditor.Text += "\n";
        }

        private void ToolbarEntryProperties_Click(object sender, EventArgs e)
        {
            var Dialog = new Shared.EntryProperties(browserEntry, Options);
            Dialog.ShowDialog(this);
        }

        //---------------------------------------------------------------------
        // FIXME - EXPERIMENTAL - NOT READY FOR PRIME TIME
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

    }
}