using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

//using System.Timers;
using System.Diagnostics;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Forms
{
    partial class Main
    {
        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        // Browser Objects
        private Classes.JournalEntry browserEntry;
        private Classes.JournalEntry priorLoadedBrowserEntry;
        private Classes.JournalEntry newBrowserEntry;
        private bool isBrowsing = false;

        private Classes.JournalEntry.BrowseByMode PrevBrowseBy;
        private Classes.JournalEntry.BrowseByMode NextBrowseBy;

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        private void Browser_CloseStartGap()
        {
            try {
                // Update the control with previous end time
                DateTimeOffset? PreviousEndTime = Browser_GetPreviousEndTime();
                if (PreviousEndTime == null) {
                    // something went wrong, do nothing
                } else {
                    StartTimeSelector.Value = PreviousEndTime.Value.DateTime;
                }

                // Recalculate duration
                Browser_UpdateDurationBox();

                // Disable button (already done)
                Browser_EnableCloseStartGap(false);

                // Enable revert
                if (isBrowsing) {
                    Browser_EnableRevert(true);
                }

                // Disable walking start
                if (!isBrowsing) {
                    StartTimeManuallySet = true;
                }

                // Remove alert
                Browser_AlertCloseStartGap(false);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Browser_CloseStopGap()
        {
            try {
                // Set next start date
                DateTimeOffset? NextStartTime = Browser_GetNextStartTime();
                if (NextStartTime == null) {
                    StopTimeSelector.Value = Timekeeper.LocalNow.DateTime;
                } else {
                    StopTimeSelector.Value = NextStartTime.Value.DateTime;
                }

                // And recalculate duration
                Browser_UpdateDurationBox();

                // But don't disable the button.
                // Time continues to move forward and the CloseStopGap
                // button can be clicked multiple times.

                // Enable revert
                Browser_EnableRevert(true);

                // Remove alert
                Browser_AlertCloseStopGap(false);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Browser_Disable()
        {
            Action_SetMenuAvailability(MenuToolbar, false);
            browserEntry = null;
            priorLoadedBrowserEntry = null;
            newBrowserEntry = null;
            isBrowsing = false;
        }

        //---------------------------------------------------------------------

        private void Browser_DisableNavigation()
        {
            Browser_EnableFirst(false);
            Browser_EnablePrev(false);
            Browser_EnableLast(false);
            Browser_EnableNext(false);
            Browser_EnableCloseStartGap(false);
            Browser_EnableCloseStopGap(false);
            Browser_EnableSplit(false);
        }

        //---------------------------------------------------------------------

        private void Browser_DisplayRow()
        {
            try {
                Browser_SetBrowseState();

                Browser_EnableRevert(false);

                Browser_EntryToForm(browserEntry);

                if (browserEntry.IsLocked) {
                    Browser_EnableStartEntry(false);
                    Browser_EnableStopEntry(false);
                    Browser_EnableDurationEntry(false);
                    if (timerRunning) {
                        Browser_EnableMemoEntry(true);
                        Browser_ShowUnlock(false);
                    } else {
                        ProjectTreeDropdown.Enabled = false;
                        ActivityTreeDropdown.Enabled = false;
                        LocationTreeDropdown.Enabled = false;
                        CategoryTreeDropdown.Enabled = false;
                        Browser_EnableMemoEntry(false);
                        Browser_ShowUnlock(true);
                    }
                    Browser_EnableSplit(false);
                } else {
                    ProjectTreeDropdown.Enabled = true;
                    ActivityTreeDropdown.Enabled = true;
                    LocationTreeDropdown.Enabled = true;
                    CategoryTreeDropdown.Enabled = true;
                    Browser_EnableStartEntry(true);
                    Browser_EnableStopEntry(true);
                    Browser_EnableDurationEntry(true);
                    Browser_EnableMemoEntry(true);
                    Browser_ShowUnlock(false);
                    Browser_EnableSplit(true);
                }

                Browser_DetermineStartGapState();
                Browser_DetermineStopGapState();

                // Set focus
                MemoEditor.Focus();
            }
            catch (Exception x) {
                //Common.Warn(x.ToString());
                Timekeeper.Exception(x);
            }
        }

        private void Browser_DetermineStartGapState()
        {
            // Enable/disable start gap button
            if (browserEntry.AtBeginning()) {
                Browser_EnableCloseStartGap(false);
            } else {
                DateTimeOffset? PreviousEndTime = Browser_GetPreviousEndTime();
                if (PreviousEndTime == null) {
                    Browser_EnableCloseStartGap(false);
                } else {
                    if (PreviousEndTime.Value.DateTime.CompareTo(StartTimeSelector.Value) == 0) {
                        Browser_EnableCloseStartGap(false);
                    } else {
                        Browser_EnableCloseStartGap(true);

                        if (isBrowsing) { // && (InlineEditing != TimeBox.StopTime)) {
                            if (PreviousEndTime.Value.DateTime.CompareTo(StartTimeSelector.Value) < 0) {
                                Browser_AlertCloseStartGap(false);
                            } else {
                                Browser_AlertCloseStartGap(true);
                            }
                        }
                    }
                }
            }

            // Oh, one last shot at disabling
            if (browserEntry.IsLocked)
                Browser_EnableCloseStartGap(false);
        }

        private void Browser_DetermineStopGapState()
        {
            // Enable/disable stop gap button
            if (browserEntry.AtEnd()) {
                Browser_EnableCloseStopGap(true);
            } else {
                DateTimeOffset? NextStartTime = Browser_GetNextStartTime();
                if (NextStartTime == null) {
                    Browser_EnableCloseStopGap(true);
                } else {
                    if (NextStartTime.Value.DateTime.CompareTo(StopTimeSelector.Value) == 0) {
                        Browser_EnableCloseStopGap(false);
                    } else {
                        Browser_EnableCloseStopGap(true);

                        if (isBrowsing) { // && (InlineEditing != TimeBox.StartTime)) {
                            if (NextStartTime.Value.DateTime.CompareTo(StopTimeSelector.Value) > 0) {
                                Browser_AlertCloseStopGap(false);
                            } else {
                                Browser_AlertCloseStopGap(true);
                            }
                        }
                    }
                }
            }

            // Oh, one last shot at disabling
            if (browserEntry.IsLocked)
                Browser_EnableCloseStopGap(false);
        }

        //---------------------------------------------------------------------

        private void Browser_Enable()
        {
            // Do not show or hide the browser. Use this
            // method in conjunction with Browser_Show()
            Action_SetMenuAvailability(MenuToolbar, true);
        }

        //---------------------------------------------------------------------

        private void Browser_EnableStart(bool enabled)
        {
            ToolbarStartButton.Enabled = enabled;
            MenuActionStartTimer.Enabled = enabled;
            //menuToolControlStart.Enabled = enabled;
            if (enabled) {
                var kc = new KeysConverter();
                ToolbarStartButton.ToolTipText = "Start the Timer (" + kc.ConvertToString(MenuActionStartTimer.ShortcutKeys) + ")";
            } else {
                ToolbarStartButton.ToolTipText = "Timer cannot be started while browsing old entries. Click 'Go to New Entry' to begin timing.";
            }
        }

        /*
                            if (InlineEditing) {
                                DateTimeOffset? PreviousEndTime = Browser_GetPreviousEndTime();
                                if (PreviousEndTime.Value.DateTime.CompareTo(StartTimeSelector.Value) > 0) {
                                    Browser_AlertCloseStartGap(false);
                                } else {
                                    Browser_AlertCloseStartGap(true);
                                }
                            } else {
        */

        private void Browser_EnableStop(bool enabled)
        {
            ToolbarStopButton.Enabled = enabled;
            MenuActionStopTimer.Enabled = enabled;
            //menuToolControlStop.Enabled = enabled;
        }

        private void Browser_EnableFirst(bool enabled)
        {
            ToolbarFirstEntry.Enabled = enabled;
            MenuToolbarBrowserFirst.Enabled = enabled;
        }

        private void Browser_EnablePrev(bool enabled)
        {
            ToolbarPrevEntry.Enabled = enabled;
            MenuToolbarBrowserPrev.Enabled = enabled;
        }

        private void Browser_EnableNext(bool enabled)
        {
            ToolbarNextEntry.Enabled = enabled;
            MenuToolbarBrowserNext.Enabled = enabled;
        }

        private void Browser_EnableLast(bool enabled)
        {
            ToolbarLastEntry.Enabled = enabled;
            MenuToolbarBrowserLast.Enabled = enabled;
        }

        private void Browser_EnableNew(bool enabled)
        {
            ToolbarNewEntry.Enabled = enabled;
            MenuToolbarBrowserNew.Enabled = enabled;
        }

        private void Browser_EnableCloseStartGap(bool enabled)
        {
            MenuToolbarBrowserCloseStartGap.Enabled = enabled;
            CloseStartGapButton.Enabled = enabled;
        }

        private void Browser_EnableCloseStopGap(bool enabled)
        {
            MenuToolbarBrowserCloseEndGap.Enabled = enabled;
            CloseStopGapButton.Enabled = enabled;
        }

        private void Browser_EnableRevert(bool enabled)
        {
            ToolbarRevert.Enabled = enabled;
            MenuToolbarBrowserRevert.Enabled = enabled;
            // Revert is locked to Save
            Browser_EnableSave(enabled);
        }

        private void Browser_EnableSave(bool enabled)
        {
            // Save is not locked to Revert
            ToolbarSave.Enabled = enabled;
            MenuToolbarBrowserSave.Enabled = enabled;
        }

        private void Browser_EnableSplit(bool enabled)
        {
            ToolbarSplitEntry.Enabled = enabled;
            MenuToolbarBrowserSplitEntry.Enabled = enabled;
        }

        private void Browser_EnableStartEntry(bool enabled)
        {
            StartTimeSelector.Enabled = enabled;
            StartLabel.Enabled = enabled;
            //CloseStartGapButton.Enabled = enabled;
        }

        private void Browser_EnableStopEntry(bool enabled)
        {
            StopTimeSelector.Enabled = enabled;
            StopLabel.Enabled = enabled;
            //CloseStopGapButton.Enabled = enabled;
        }

        private void Browser_EnableDurationEntry(bool enabled)
        {
            DurationBox.Enabled = enabled;
            DurationLabel.Enabled = enabled;
        }

        private void Browser_EnableMemoEntry(bool enabled)
        {
            if (enabled) {
                MemoEditor.Enable();
            } else {
                MemoEditor.Disable();
            }
        }

        private void Browser_EnableProperties(bool enabled)
        {
            ToolbarEntryProperties.Enabled = enabled;
        }

        //----------------------------------------------------------------------

        private void Browser_AlertCloseStartGap(bool alert)
        {
            if (alert) {
                CloseStartGapButton.ForeColor = Color.Red;
            } else {
                CloseStartGapButton.ForeColor = SystemColors.ControlText;
            }
        }

        private void Browser_AlertCloseStopGap(bool alert)
        {
            if (alert) {
                CloseStopGapButton.ForeColor = Color.Red;
            } else {
                CloseStopGapButton.ForeColor = SystemColors.ControlText;
            }
        }

        //----------------------------------------------------------------------

        private void Browser_FormToEntry(ref Classes.JournalEntry entry, long entryId)
        {
            // Don't update the browser entry if nothing is selected
            if ((ProjectTreeDropdown.SelectedNode == null) ||
                (ActivityTreeDropdown.SelectedNode == null) ||
                (LocationTreeDropdown.SelectedNode == null) ||
                (CategoryTreeDropdown.SelectedNode == null)) {
                return;
            }

            // First translate some necessary data from the form
            Classes.TreeAttribute Project = (Classes.TreeAttribute)ProjectTreeDropdown.SelectedNode.Tag;
            Classes.TreeAttribute Activity = (Classes.TreeAttribute)ActivityTreeDropdown.SelectedNode.Tag;
            Classes.TreeAttribute Location = (Classes.TreeAttribute)LocationTreeDropdown.SelectedNode.Tag;
            Classes.TreeAttribute Category = (Classes.TreeAttribute)CategoryTreeDropdown.SelectedNode.Tag;

            TimeSpan Delta = StopTimeSelector.Value.Subtract(StartTimeSelector.Value);

            // Update browserEntry with current form data
            entry.JournalId = entryId;
            entry.ProjectId = Project.ItemId;
            entry.ActivityId = Activity.ItemId;
            entry.LocationId = Location.ItemId;
            entry.CategoryId = Category.ItemId;
            entry.StartTime = StartTimeSelector.Value;
            entry.StopTime = StopTimeSelector.Value;
            entry.Seconds = (long)Delta.TotalSeconds;
            //entry.Memo = wMemo.Text;
            entry.Memo = MemoEditor.Text;
            entry.ProjectName = Project.Name;
            entry.ActivityName = Activity.Name;
        }

        private void Foo(ComboTreeBox treebox, long itemId, string itemName, string tableName)
        {
            if (itemId == 0)
                return;

            ComboTreeNode Node = Widgets.FindTreeNode(treebox.Nodes, itemId);
            if (Node != null) {
                treebox.SelectedNode = Node;
            } else {
                Classes.TreeAttribute HiddenItem = new Classes.TreeAttribute(itemName, tableName, tableName + "Id");
                ComboTreeNode HiddenNode = Widgets.AddHiddenItemToTree(treebox.Nodes, HiddenItem);
                treebox.SelectedNode = HiddenNode;
            }
        }

        private void Browser_EntryToForm(Classes.JournalEntry entry)
        {
            Foo(ProjectTreeDropdown, entry.ProjectId, entry.ProjectName, "Project");
            Foo(ActivityTreeDropdown, entry.ActivityId, entry.ActivityName, "Activity");
            Foo(LocationTreeDropdown, entry.LocationId, entry.LocationName, "Location");
            Foo(CategoryTreeDropdown, entry.CategoryId, entry.CategoryName, "Category");

            // Display entry
            StartTimeSelector.Value = entry.StartTime.DateTime;
            StopTimeSelector.Value = entry.StopTime.DateTime;
            Browser_UpdateDurationBox(Timekeeper.FormatSeconds(entry.Seconds));
            MemoEditor.Text = entry.Memo;

            // And any other relevant values
            ToolbarJournalId.Text = entry.JournalId > 0 ? entry.JournalId.ToString() : "";
        }

        //----------------------------------------------------------------------

        public void Browser_GotoEntry(long journalId)
        {
            try {
                if (journalId == 0) {
                    // Degenerate case
                    Browser_DisableNavigation();
                    return;
                }

                if (!isBrowsing)
                    Browser_FormToEntry(ref newBrowserEntry, 0);

                Browser_LockAndLoad(journalId);

                if (browserEntry.JournalId > 0) {

                    Browser_DisplayRow();

                    isBrowsing = true;

                    if (browserEntry.AtBeginning() && browserEntry.AtEnd()) {
                        Browser_EnableFirst(false);
                        Browser_EnablePrev(false);
                        Browser_EnableLast(false);
                        Browser_EnableNext(false);
                    } else if (browserEntry.AtBeginning()) {
                        Browser_EnableFirst(false);
                        Browser_EnablePrev(false);
                        Browser_EnableLast(true);
                        Browser_EnableNext(true);
                    } else if (browserEntry.AtEnd()) {
                        Browser_EnableFirst(true);
                        Browser_EnablePrev(true);
                        Browser_EnableNext(false);
                        Browser_EnableLast(false);
                        if (timerRunning) {
                            Browser_SetupForStopping();
                        }
                        MemoEditor.MemoEntry.BackColor = Color.White;
                    }
                    else {
                        Browser_EnableFirst(true);
                        Browser_EnablePrev(true);
                        Browser_EnableNext(true);
                        Browser_EnableLast(true);
                        if (timerRunning) {
                            MemoEditor.MemoEntry.BackColor = SystemColors.ControlLight;
                        } else {
                            MemoEditor.MemoEntry.BackColor = Color.White;
                        }
                    }
                } else {
                    Common.Warn("browserEntry.JournalId <= 0");

                    /* wait, what is this code? When is the JournalId
                       or JournalIndex ever going to be zero?
                    if (LastJournalIndex < browserEntry.JournalIndex) {
                        Browser_EnableLast(false);
                        Browser_EnableNext(false);
                    } else {
                        Browser_EnableFirst(false);
                        Browser_EnablePrev(false);
                    }
                    */
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Browser_GotoFirstEntry()
        {
            Browser_GotoEntry(browserEntry.GetFirstId());
        }

        //---------------------------------------------------------------------

        private void Browser_GotoLastEntry()
        {
            Browser_GotoEntry(browserEntry.GetLastId());
        }

        //---------------------------------------------------------------------

        private void Browser_GotoNextEntry()
        {
            Application.DoEvents();
            Browser_GotoEntry(browserEntry.GetNextId(this.NextBrowseBy));
        }

        //---------------------------------------------------------------------

        private void Browser_GotoPreviousEntry()
        {
            Application.DoEvents();
            Browser_GotoEntry(browserEntry.GetPreviousId(this.PrevBrowseBy));
        }

        //---------------------------------------------------------------------

        private void Browser_Load()
        {
            try {
                Browser_SetShortcuts();
            }
            catch (Exception x) {
                Common.Info("Error loading Browser.\n\n" + x.ToString());
            }
        }

        //----------------------------------------------------------------------

        public void Browser_LockAndLoad(long journalId)
        {
            Browser_SaveRow();
            browserEntry.Load(journalId);
            long LastJournalId = priorLoadedBrowserEntry.JournalId;
            priorLoadedBrowserEntry = browserEntry.Copy();
        }

        //---------------------------------------------------------------------

        private void Browser_SetShortcuts()
        {
            var kc = new KeysConverter();

            ToolbarStartButton.ToolTipText = "Start Timer (" + kc.ConvertToString(MenuActionStartTimer.ShortcutKeys) + ")";
            ToolbarStopButton.ToolTipText = "Stop Timer (" + kc.ConvertToString(MenuActionStopTimer.ShortcutKeys) + ")";

            ToolbarFirstEntry.ToolTipText = "Go to First Entry (" + kc.ConvertToString(MenuToolbarBrowserFirst.ShortcutKeys) + ")";
            ToolbarLastEntry.ToolTipText = "Go to Last Entry (" + kc.ConvertToString(MenuToolbarBrowserLast.ShortcutKeys) + ")";
            ToolbarNextEntry.ToolTipText = "Go to Next Entry (" + kc.ConvertToString(MenuToolbarBrowserNext.ShortcutKeys) + ")";
            ToolbarPrevEntry.ToolTipText = "Go to Previous Entry (" + kc.ConvertToString(MenuToolbarBrowserPrev.ShortcutKeys) + ")";

            ToolbarNewEntry.ToolTipText = "Go to New Entry (" + kc.ConvertToString(MenuToolbarBrowserNew.ShortcutKeys) + ")";

            ToolbarSave.ToolTipText = "Save Changes to Database (" + kc.ConvertToString(MenuToolbarBrowserSave.ShortcutKeys) + ")";
            ToolbarRevert.ToolTipText = "Revert Changes to Last Saved State (" + kc.ConvertToString(MenuToolbarBrowserRevert.ShortcutKeys) + ")";
        }

        //---------------------------------------------------------------------

        private void Browser_RevertEntry()
        {
            // First confirm (FIXME: is this the right spot for this? Feels like a layer violation)
            if (Common.Prompt("Revert entry to last saved state? You will lose all changes.") != DialogResult.Yes) {
                return;
            }

            // Copy the prior entry to the form
            Browser_EntryToForm(priorLoadedBrowserEntry);

            // Copy the prior entry to our internal representation
            browserEntry = priorLoadedBrowserEntry.Copy();

            // Update gap buttons
            Browser_DetermineStartGapState();
            Browser_DetermineStopGapState();

            // Turn off button
            Browser_EnableRevert(false);

            // Revert inline editing
            InlineEditing = TimeBox.None;
        }

        //---------------------------------------------------------------------

        public void Browser_SaveRow()
        {
            Timekeeper.Debug("Browser_SaveRow: Checkpoint Alpha");
            // Bail if we have no entry
            if ((browserEntry == null) || (browserEntry.JournalId == 0)) {
                Timekeeper.Debug("Browser_SaveRow: Checkpoint Bravo");
                return;
            }

            // Copy form values to browser entry
            Timekeeper.Debug("Browser_SaveRow: Checkpoint Charlie (1)");
            Timekeeper.Debug("  StartTime: " + browserEntry.StartTime);
            Timekeeper.Debug("  StopTime.: " + browserEntry.StopTime);
            Timekeeper.Debug("  Seconds..: " + browserEntry.Seconds);
            Timekeeper.Debug("  Memo.....: " + browserEntry.Memo);
            Browser_FormToEntry(ref browserEntry, browserEntry.JournalId);
            Timekeeper.Debug("Browser_SaveRow: Checkpoint Charlie (2)");
            Timekeeper.Debug("  StartTime: " + browserEntry.StartTime);
            Timekeeper.Debug("  StopTime.: " + browserEntry.StopTime);
            Timekeeper.Debug("  Seconds..: " + browserEntry.Seconds);
            Timekeeper.Debug("  Memo.....: " + browserEntry.Memo);

            // Bail if nothing changed
            if (ToolbarRevert.Enabled == false) {
                Timekeeper.Debug("Browser_SaveRow: Checkpoint Delta");

                if (timerRunning) {
                    if (browserEntry.Memo == priorLoadedBrowserEntry.Memo) {
                        Timekeeper.Debug("Browser_SaveRow: Checkpoint Echo");
                        return;
                    } else {
                        Timekeeper.Debug("Browser_SaveRow: Checkpoint Foxtrot");
                        // The timer is running and the memo has changed, so
                        // please proceed to the save code below
                    }
                } else {
                    Timekeeper.Debug("Browser_SaveRow: Checkpoint Golf");
                    return;
                }

            }

            // If we made it this far, save
            Timekeeper.Debug("Browser_SaveRow: Checkpoint Hotel");
            Timekeeper.Debug("  StartTime: " + browserEntry.StartTime);
            Timekeeper.Debug("  StopTime.: " + browserEntry.StopTime);
            Timekeeper.Debug("  Seconds..: " + browserEntry.Seconds);
            Timekeeper.Debug("  Memo.....: " + browserEntry.Memo);
            if (browserEntry.Save()) {
                Browser_EnableRevert(false);
            } else {
                Common.Warn("There was a problem saving this journal entry. A duplicate start time is possible.");
            }
            Timekeeper.Debug("Browser_SaveRow: Checkpoint India");

            // If we've saved, we're no longer inline editing:
            InlineEditing = TimeBox.None;

            // Lastly, update the status bar with any potential time changes
            GetDimensions();
            TimedProject.ChangedTime();
            TimedActivity.ChangedTime();
            TimedLocation.ChangedTime();
            TimedCategory.ChangedTime();
            StatusBar_Update(TimedProject, TimedActivity, TimedLocation, TimedCategory);
            ReleaseDimensions();
        }

        //---------------------------------------------------------------------

        private void Browser_SetBrowseModePrev(ToolStripMenuItem item)
        {
            // Uncheck all
            ToolbarPrevEntryBrowseByEntry.Checked = false;
            ToolbarPrevEntryBrowseByDay.Checked = false;
            ToolbarPrevEntryBrowseByWeek.Checked = false;
            ToolbarPrevEntryBrowseByMonth.Checked = false;
            ToolbarPrevEntryBrowseByYear.Checked = false;

            // Set mode
            int EnumValue = Convert.ToInt32(item.Tag);
            PrevBrowseBy = (Classes.JournalEntry.BrowseByMode)EnumValue;

            if (item.Name.Substring(0, 4) == "Menu") {
                // HACK -- need to sync toolbar with menubar
                // This means we got here due to a keyboard shortcut
                // (which is tied to the invisible menu items and not
                // the visible toolbar dropdown). In this case, we
                // need to check the corresponding visible item and
                // not the invisible one that got us here
                switch (PrevBrowseBy) {
                    case Classes.JournalEntry.BrowseByMode.Entry: item = ToolbarPrevEntryBrowseByEntry; break;
                    case Classes.JournalEntry.BrowseByMode.Day: item = ToolbarPrevEntryBrowseByDay; break;
                    case Classes.JournalEntry.BrowseByMode.Week: item = ToolbarPrevEntryBrowseByWeek; break;
                    case Classes.JournalEntry.BrowseByMode.Month: item = ToolbarPrevEntryBrowseByMonth; break;
                    case Classes.JournalEntry.BrowseByMode.Year: item = ToolbarPrevEntryBrowseByYear; break;
                }
            }

            // Check currently selected item
            item.Checked = true;

            // Set parent's tooltip
            var kc = new KeysConverter();
            ToolbarPrevEntry.ToolTipText =
                "Go to Previous " + PrevBrowseBy.ToString() +
                " (" + kc.ConvertToString(MenuToolbarBrowserPrev.ShortcutKeys) + ")";

            // Update options
            Options.Behavior_BrowsePrevBy = EnumValue;
        }

        //---------------------------------------------------------------------

        private void Browser_SetBrowseModeNext(ToolStripMenuItem item)
        {
            // Uncheck all
            ToolbarNextEntryBrowseByEntry.Checked = false;
            ToolbarNextEntryBrowseByDay.Checked = false;
            ToolbarNextEntryBrowseByWeek.Checked = false;
            ToolbarNextEntryBrowseByMonth.Checked = false;
            ToolbarNextEntryBrowseByYear.Checked = false;

            // Set mode
            int EnumValue = Convert.ToInt32(item.Tag);
            NextBrowseBy = (Classes.JournalEntry.BrowseByMode)EnumValue;

            // HACK -- need to sync toolbar with menubar
            if (item.Name.Substring(0, 4) == "Menu") {
                // This means we got hear due to a keyboard shortcut
                // (which is tied to the invisible menu items and not
                // the visible toolbar dropdown). In this case, we
                // need to check the corresponding visible item and
                // not the invisible one that got us here
                switch (NextBrowseBy) {
                    case Classes.JournalEntry.BrowseByMode.Entry: item = ToolbarNextEntryBrowseByEntry; break;
                    case Classes.JournalEntry.BrowseByMode.Day: item = ToolbarNextEntryBrowseByDay; break;
                    case Classes.JournalEntry.BrowseByMode.Week: item = ToolbarNextEntryBrowseByWeek; break;
                    case Classes.JournalEntry.BrowseByMode.Month: item = ToolbarNextEntryBrowseByMonth; break;
                    case Classes.JournalEntry.BrowseByMode.Year: item = ToolbarNextEntryBrowseByYear; break;
                }
            }

            // Check currently selected item
            item.Checked = true;

            // Set tooltip
            var kc = new KeysConverter();
            ToolbarNextEntry.ToolTipText =
                "Go to Next " + NextBrowseBy.ToString() +
                " (" + kc.ConvertToString(MenuToolbarBrowserNext.ShortcutKeys) + ")";

            // Update options
            Options.Behavior_BrowseNextBy = EnumValue;
        }

        //---------------------------------------------------------------------

        private void Browser_SetCreateState()
        {
            Browser_ShowStart(true);
            Browser_ShowStop(false);

            Browser_EnableStart(true);
            Browser_EnableStop(false);

            Browser_EnableFirst(true);
            Browser_EnablePrev(true);
            Browser_EnableNext(false);
            Browser_EnableLast(false);
            Browser_EnableNew(false);

            Browser_EnableCloseStartGap(true);
            Browser_EnableCloseStopGap(false);
            Browser_EnableSplit(false);

            Browser_EnableStartEntry(true);
            Browser_EnableStopEntry(false);
            Browser_EnableDurationEntry(false);

            Browser_EnableProperties(false);
        }

        private void Browser_SetBrowseState()
        {

            if (timerRunning) {
                Browser_ShowStart(false);
                Browser_ShowStop(true);

                Browser_EnableStart(false);
                Browser_EnableStop(false);

                Browser_EnableNew(false);

                Browser_EnableStartEntry(true);
                Browser_EnableStopEntry(true);
                Browser_EnableDurationEntry(true);

                Browser_EnableProperties(false);
            }
            else {
                Browser_ShowStart(true);
                Browser_ShowStop(false);

                Browser_EnableStart(false);
                Browser_EnableStop(false);

                Browser_EnableNew(true);

                Browser_EnableStartEntry(true);
                Browser_EnableStopEntry(true);
                Browser_EnableDurationEntry(true);

                Browser_EnableProperties(true);
            }
        }

        private void Browser_SetStopState()
        {
            Browser_ShowStart(false);
            Browser_ShowStop(true);

            Browser_EnableStart(false);
            Browser_EnableStop(true);

            Browser_EnableFirst(true);
            Browser_EnablePrev(true);
            Browser_EnableNext(false);
            Browser_EnableLast(false);
            Browser_EnableNew(false);

            Browser_EnableCloseStartGap(false);
            Browser_EnableCloseStopGap(false);

            Browser_EnableStartEntry(false);
            Browser_EnableStopEntry(false);
            Browser_EnableDurationEntry(false);

            Browser_EnableProperties(false);
        }

        //---------------------------------------------------------------------

        private void Browser_SetupForStarting(bool saveRow)
        {
            try {
                // Just in case
                if (saveRow)
                    Browser_SaveRow();

                // Set UI accordingly
                Browser_SetCreateState();

                // Disable navigation if the database
                // is empty of journal entries.
                if (Entries.Count() == 0) {
                    Browser_DisableNavigation();
                }

                // Create browser objects
                browserEntry = TimedEntry.Copy();

                priorLoadedBrowserEntry = new Classes.JournalEntry();
                if (newBrowserEntry == null) {
                    newBrowserEntry = new Classes.JournalEntry();
                }
                isBrowsing = false;
                StartTimeManuallySet = false;

                // Load empty form
                Browser_EntryToForm(newBrowserEntry);

                MemoEditor.Focus();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Browser_SetupForStopping()
        {
            // Set UI accordingly 
            Browser_SetStopState();

            // Disable navigation if there's
            // only a single entry at this point.
            if (Entries.Count() == 1) {
                Browser_DisableNavigation();
            }

            // Reset browser entry
            isBrowsing = false;

            // Ensure proper display
            MemoEditor.Focus();
        }

        //---------------------------------------------------------------------
        // Are these types of things candidates for fMain.MenuBar?
        //---------------------------------------------------------------------

        private void Browser_ShowStart(bool show)
        {
            ToolbarStartButton.Visible = show;
            //menuToolControlStart.Visible = show;
        }

        private void Browser_ShowStop(bool show)
        {
            ToolbarStopButton.Visible = show;
            //menuToolControlStop.Visible = show;
        }

        private void Browser_ShowUnlock(bool show)
        {
            ToolbarUnlock.Visible = show;
            MenuToolbarBrowserUnlock.Visible = show;
        }

        //---------------------------------------------------------------------

        private void Browser_UnlockEntry()
        {
            browserEntry.IsLocked = false;
            browserEntry.Save();
            Browser_DisplayRow();
        }

        //---------------------------------------------------------------------

        private void Browser_UpdateDurationBox()
        {
            string DurationText = Browser_CalculateDuration();
            Browser_UpdateDurationBox(DurationText);
        }

        //---------------------------------------------------------------------

        private void Browser_UpdateDurationBox(string value)
        {
            DurationBox.Text = value;
            DurationBox.ForeColor = 
                browserEntry.Seconds == 0 ? Color.Red : SystemColors.ControlText;
        }

        //---------------------------------------------------------------------

        private void Browser_UpdateTimes()
        {
            if (isBrowsing) {
                long seconds = Timekeeper.UnformatSeconds(DurationBox.Text);

                if (seconds != priorLoadedBrowserEntry.Seconds) {
                    if (seconds < 0) {
                        // either set the start time backwards
                        browserEntry.Seconds = -seconds;
                        browserEntry.StartTime = browserEntry.StopTime.AddSeconds(Convert.ToDouble(seconds));
                        StartTimeSelector.Value = browserEntry.StartTime.DateTime;
                        Browser_EnableRevert(true);
                    } else {
                        // or the end time forward (or not at all: zero is fine)
                        browserEntry.Seconds = seconds;
                        browserEntry.StopTime = browserEntry.StartTime.AddSeconds(Convert.ToDouble(seconds));
                        StopTimeSelector.Value = browserEntry.StopTime.DateTime;
                        Browser_EnableRevert(true);
                    }

                    // Set close gap buttons
                    if (isBrowsing) {
                        Browser_DetermineStartGapState();
                        Browser_DetermineStopGapState();
                    }

                    // reformat duration before leaving
                    Browser_UpdateDurationBox();
                }
            }
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private string Browser_CalculateDuration()
        {
            try {
                browserEntry.StartTime = StartTimeSelector.Value;
                browserEntry.StopTime = StopTimeSelector.Value;
                TimeSpan ts = browserEntry.StopTime.Subtract(browserEntry.StartTime);
                browserEntry.Seconds = (long)ts.TotalSeconds;
                return Timekeeper.FormatSeconds(browserEntry.Seconds);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return "00:00:00";
            }
        }



        //---------------------------------------------------------------------

        private DateTimeOffset? Browser_GetPreviousEndTime()
        {
            try {
                if (browserEntry.AtBeginning()) {
                    return null;
                } else {
                    Classes.JournalEntry copy;
                    if (InlineEditing == TimeBox.StartTime) {
                        copy = priorLoadedBrowserEntry.Copy();
                    } else {
                        copy = browserEntry.Copy();
                    }
                    copy.LoadPrevious();
                    return copy.StopTime;
                }
            }
            catch {
                return null;
            }
        }

        //---------------------------------------------------------------------

        private DateTimeOffset? Browser_GetNextStartTime()
        {
            try {
                if (browserEntry.AtEnd()) {
                    return null;
                } else {
                    Classes.JournalEntry copy;
                    if (InlineEditing == TimeBox.StopTime) {
                        copy = priorLoadedBrowserEntry.Copy();
                    } else {
                        copy = browserEntry.Copy();
                    }
                    copy.LoadNext();
                    return copy.StartTime;
                }
            }
            catch {
                return null;
            }
        }

        //---------------------------------------------------------------------

    }
}
