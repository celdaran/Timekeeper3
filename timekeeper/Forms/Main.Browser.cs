using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

//using System.Timers;
using System.Diagnostics;


using Technitivity.Toolbox;

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

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        private void Browser_CloseStartGap()
        {
            try {
                // Update the control with previous end time
                DateTime PreviousEndTime = Browser_GetPreviousEndTime();
                if (PreviousEndTime == DateTime.MinValue) {
                    // something went wrong, do nothing
                } else {
                    wStartTime.Value = PreviousEndTime;
                }

                // Recalculate duration
                wDuration.Text = Browser_CalculateDuration();

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
                DateTime NextStartTime = Browser_GetNextStartTime();
                if (NextStartTime == DateTime.MaxValue) {
                    wStopTime.Value = DateTime.Now;
                } else {
                    wStopTime.Value = NextStartTime;
                }

                // And recalculate duration
                wDuration.Text = Browser_CalculateDuration();

                // Enable revert
                Browser_EnableRevert(true);
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
            Browser_EnableCloseEndGap(false);
            Browser_EnableSplit(false);
        }

        //---------------------------------------------------------------------

        private void Browser_DisplayRow()
        {
            /*
             * Run just this part for performance testing purposes.
            Browser_EntryToForm(browserEntry);
            return;
            */

            try {
                Browser_SetBrowseState();

                Browser_EnableRevert(false);

                Browser_EntryToForm(browserEntry);

                if (browserEntry.IsLocked) {
                    Browser_EnableCloseStartGap(false);
                    Browser_EnableCloseEndGap(false);
                    Browser_EnableStartEntry(false);
                    Browser_EnableStopEntry(false);
                    Browser_EnableDurationEntry(false);
                    Browser_EnableLocationEntry(false);
                    Browser_EnableCategoryEntry(false);
                    if (timerRunning) {
                        Browser_EnableMemoEntry(true);
                        Browser_ShowUnlock(false);
                    } else {
                        ProjectTreeDropdown.Enabled = false;
                        ActivityTreeDropdown.Enabled = false;
                        Browser_EnableMemoEntry(false);
                        Browser_ShowUnlock(true);
                    }
                    Browser_EnableSplit(false);
                } else {
                    ProjectTreeDropdown.Enabled = true;
                    ActivityTreeDropdown.Enabled = true;
                    Browser_EnableCloseStartGap(true);
                    Browser_EnableCloseEndGap(true);
                    Browser_EnableStartEntry(true);
                    Browser_EnableStopEntry(true);
                    Browser_EnableDurationEntry(true);
                    Browser_EnableLocationEntry(true);
                    Browser_EnableCategoryEntry(true);
                    Browser_EnableMemoEntry(true);
                    Browser_ShowUnlock(false);
                    Browser_EnableSplit(true);
                }

                // Enable/disable start gap button
                if (browserEntry.AtBeginning()) {
                    Browser_EnableCloseStartGap(false);
                } else {
                    DateTime PreviousEndTime = Browser_GetPreviousEndTime();
                    if (PreviousEndTime == wStartTime.Value) {
                        Browser_EnableCloseStartGap(false);
                    } else {
                        Browser_EnableCloseStartGap(true);
                    }
                }

                // Enable/disable stop gap button
                if (browserEntry.AtEnd()) {
                    Browser_EnableCloseEndGap(true);
                } else {
                    DateTime NextStartTime = Browser_GetNextStartTime();
                    if (NextStartTime == wStopTime.Value) {
                        Browser_EnableCloseEndGap(false);
                    } else {
                        Browser_EnableCloseEndGap(true);
                    }
                }

                // Set focus
                MemoEditor.Focus();
            }
            catch (Exception x) {
                //Common.Warn(x.ToString());
                Timekeeper.Exception(x);
            }
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
            toolControlStart.Enabled = enabled;
            MenuActionStartTimer.Enabled = enabled;
            //menuToolControlStart.Enabled = enabled;
            if (enabled) {
                var kc = new KeysConverter();
                toolControlStart.ToolTipText = "Start the Timer (" + kc.ConvertToString(MenuActionStartTimer.ShortcutKeys) + ")";
            } else {
                toolControlStart.ToolTipText = "Timer cannot be started while browsing old entries. Click 'Go to New Entry' to begin timing.";
            }
        }

        private void Browser_EnableStop(bool enabled)
        {
            toolControlStop.Enabled = enabled;
            MenuActionStopTimer.Enabled = enabled;
            //menuToolControlStop.Enabled = enabled;
        }

        private void Browser_EnableFirst(bool enabled)
        {
            toolControlFirstEntry.Enabled = enabled;
            MenuToolbarBrowserFirst.Enabled = enabled;
        }

        private void Browser_EnablePrev(bool enabled)
        {
            toolControlPrevEntry.Enabled = enabled;
            MenuToolbarBrowserPrev.Enabled = enabled;
        }

        private void Browser_EnableNext(bool enabled)
        {
            toolControlNextEntry.Enabled = enabled;
            MenuToolbarBrowserNext.Enabled = enabled;
        }

        private void Browser_EnableLast(bool enabled)
        {
            toolControlLastEntry.Enabled = enabled;
            MenuToolbarBrowserLast.Enabled = enabled;
        }

        private void Browser_EnableNew(bool enabled)
        {
            toolControlNewEntry.Enabled = enabled;
            MenuToolbarBrowserNew.Enabled = enabled;
        }

        private void Browser_EnableCloseStartGap(bool enabled)
        {
            toolControlCloseStartGap.Enabled = enabled;
            MenuToolbarBrowserCloseStartGap.Enabled = enabled;
        }

        private void Browser_EnableCloseEndGap(bool enabled)
        {
            toolControlCloseEndGap.Enabled = enabled;
            MenuToolbarBrowserCloseEndGap.Enabled = enabled;
        }

        private void Browser_EnableRevert(bool enabled)
        {
            toolControlRevert.Enabled = enabled;
            MenuToolbarBrowserRevert.Enabled = enabled;
            toolControlSave.Enabled = enabled;
            MenuToolbarBrowserSave.Enabled = enabled;
        }

        private void Browser_EnableSplit(bool enabled)
        {
            toolControlSplitEntry.Enabled = enabled;
            MenuToolbarBrowserSplitEntry.Enabled = enabled;
        }

        private void Browser_EnableStartEntry(bool enabled)
        {
            wStartTime.Enabled = enabled;
            labelStartTime.Enabled = enabled;
        }

        private void Browser_EnableStopEntry(bool enabled)
        {
            wStopTime.Enabled = enabled;
            labelStopTime.Enabled = enabled;
        }

        private void Browser_EnableDurationEntry(bool enabled)
        {
            wDuration.Enabled = enabled;
            labelDuration.Enabled = enabled;
        }

        private void Browser_EnableLocationEntry(bool enabled)
        {
            wLocation.Enabled = enabled;
            labelLocation.Enabled = enabled;
        }

        private void Browser_EnableCategoryEntry(bool enabled)
        {
            wCategory.Enabled = enabled;
            labelCategory.Enabled = enabled;
        }

        private void Browser_EnableMemoEntry(bool enabled)
        {
            // FIXME: Make "MemoEntry" private again then add
            // appropriate methods for all this direct access
            // that we're doing.
            if (enabled) {
            	MemoEditor.Enable();
            } else {
                MemoEditor.Disable();
            }
        }

        //----------------------------------------------------------------------

        private void Browser_FormToEntry(ref Classes.JournalEntry entry, long entryId)
        {
            // Don't update the browser entry if nothing is selected
            if ((ProjectTreeDropdown.SelectedNode == null) || (ActivityTreeDropdown.SelectedNode == null)) {
                return;
            }

            // First translate some necessary data from the form 
            Classes.Project Project = (Classes.Project)ProjectTreeDropdown.SelectedNode.Tag;
            Classes.Activity Activity = (Classes.Activity)ActivityTreeDropdown.SelectedNode.Tag;
            TimeSpan Delta = wStopTime.Value.Subtract(wStartTime.Value);

            // Update browserEntry with current form data
            entry.JournalId = entryId;
            entry.ProjectId = Project.ItemId;
            entry.ActivityId = Activity.ItemId;
            entry.StartTime = wStartTime.Value;
            entry.StopTime = wStopTime.Value;
            entry.Seconds = (long)Delta.TotalSeconds;
            //entry.Memo = wMemo.Text;
            entry.Memo = MemoEditor.Text;
            entry.ProjectName = Project.Name;
            entry.ActivityName = Activity.Name;

            // Location & Category support
            if (wLocation.SelectedIndex > -1) {
                Classes.Location Location = (Classes.Location)((IdObjectPair)wLocation.SelectedItem).Object;
                entry.LocationId = Location.Id;
            }
            if (wCategory.SelectedIndex > -1) {
                Classes.Category Category = (Classes.Category)((IdObjectPair)wCategory.SelectedItem).Object;
                entry.CategoryId = Category.Id;
            }
        }

        private void Browser_EntryToForm(Classes.JournalEntry entry)
        {
            // Now select projects and activities while browsing.
            ComboTreeNode ProjectNode = Widgets.FindTreeNode(ProjectTreeDropdown.Nodes, entry.ProjectId);
            if (ProjectNode != null) {
                ProjectTreeDropdown.SelectedNode = ProjectNode;
                ProjectTreeDropdown.SelectedNode.Expand();
            }
            if ((ProjectNode == null) && (entry.JournalId != 0)) {

                Classes.Project HiddenProject = new Classes.Project(entry.ProjectName);
                ComboTreeNode HiddenNode = Widgets.AddHiddenProjectToTree(ProjectTreeDropdown.Nodes, HiddenProject);

                ProjectTreeDropdown.SelectedNode = HiddenNode;
                //ProjectTree.SelectedNode.Expand();
            }

            // Yes, this is a nice copy/paste job from above.
            ComboTreeNode ActivityNode = Widgets.FindTreeNode(ActivityTreeDropdown.Nodes, entry.ActivityId);
            if (ActivityNode != null) {
                ActivityTreeDropdown.SelectedNode = ActivityNode;
                //ActivityTree.SelectedNode.Expand();
            }
            if ((ActivityNode == null) && (entry.JournalId != 0)) {
                // If we didn't find the node, it's been hidden. So
                // load it from the database and display it as hidden.

                Classes.Activity HiddenActivity = new Classes.Activity(entry.ActivityName);
                ComboTreeNode HiddenNode = Widgets.AddHiddenActivityToTree(ActivityTreeDropdown.Nodes, HiddenActivity);

                ActivityTreeDropdown.SelectedNode = HiddenNode;
                //ActivityTree.SelectedNode.Expand();
            }

            // And now again, for the new ComboTreeView
            ComboTreeNode ProjectNode2 = Widgets.FindTreeNode(ProjectTreeDropdown.Nodes, entry.ProjectId);
            if (ProjectNode2 != null) {
                ProjectTreeDropdown.SelectedNode = ProjectNode2;
            }

            ComboTreeNode ActivityNode2 = Widgets.FindTreeNode(ActivityTreeDropdown.Nodes, entry.ActivityId);
            if (ActivityNode2 != null) {
                ActivityTreeDropdown.SelectedNode = ActivityNode2;
            }

            // Display entry
            wStartTime.Value = entry.StartTime.LocalDateTime;
            wStopTime.Value = entry.StopTime.LocalDateTime;
            wDuration.Text = entry.Seconds > 0 ? Timekeeper.FormatSeconds(entry.Seconds) : "";
            //wMemo.Text = entry.Memo;
            MemoEditor.Text = entry.Memo;

            // Handle Location
            if (entry.LocationId > 0) {
                Classes.Location Location = new Classes.Location(entry.LocationId);
                if (Location.Name != null) {
                    int LocationIndex = wLocation.FindString(Location.Name);
                    wLocation.SelectedIndex = LocationIndex;
                } else {
                    wLocation.SelectedIndex = 0;
                }
            } else {
                wLocation.SelectedIndex = 0;
            }

            // FIXME: MORE COPY/PASTE CODE.  :(
            if (entry.CategoryId > 0) {
                Classes.Category Category = new Classes.Category(entry.CategoryId);
                if (Category.Name != null) {
                    int CategoryIndex = wCategory.FindString(Category.Name);
                    wCategory.SelectedIndex = CategoryIndex;
                } else {
                    wCategory.SelectedIndex = 0;
                }
            } else {
                wCategory.SelectedIndex = 0;
            }

            // And any other relevant values
            toolControlEntryId.Text = entry.JournalId > 0 ? entry.JournalId.ToString() : "";
            toolControlEntryIndex.Text = entry.JournalIndex > 0 ? entry.JournalIndex.ToString() : "";
        }

        //----------------------------------------------------------------------

        public void Browser_GotoEntry(long journalIndex)
        {
            try {
                if (journalIndex == 0) {
                    // Degenerate case
                    Browser_DisableNavigation();
                    return;
                }

                if (!isBrowsing)
                    Browser_FormToEntry(ref newBrowserEntry, 0);

                Browser_SaveRow(false);
                browserEntry.LoadByNewIndex(journalIndex);
                long LastJournalIndex = priorLoadedBrowserEntry.JournalIndex;
                priorLoadedBrowserEntry = browserEntry.Copy();

                if (browserEntry.JournalIndex > 0) {

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
                    } else {
                        Browser_EnableFirst(true);
                        Browser_EnablePrev(true);
                        Browser_EnableNext(true);
                        Browser_EnableLast(true);
                    }
                } else {
                    Common.Warn("browserEntry.JournalIndex <= 0");

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
            browserEntry.SetFirstIndex();
            Browser_GotoEntry(browserEntry.JournalIndex);
        }

        //---------------------------------------------------------------------

        private void Browser_GotoLastEntry()
        {
            browserEntry.SetLastIndex();
            Browser_GotoEntry(browserEntry.JournalIndex);
        }

        //---------------------------------------------------------------------

        private void Browser_GotoNextEntry()
        {
            browserEntry.SetNextIndex();
            Browser_GotoEntry(browserEntry.JournalIndex);
        }

        //---------------------------------------------------------------------

        private void Browser_GotoPreviousEntry()
        {
            browserEntry.SetPreviousIndex();
            Browser_GotoEntry(browserEntry.JournalIndex);
        }

        //---------------------------------------------------------------------

        private void Browser_Load()
        {
            try {
                Browser_SetShortcuts();
                Browser_ViewOtherAttributes();
            }
            catch (Exception x) {
                Common.Info("Error loading Browser.\n\n" + x.ToString());
            }
        }

        //---------------------------------------------------------------------

        private void Browser_SetShortcuts()
        {
            var kc = new KeysConverter();

            toolControlStart.ToolTipText = "Start Timer (" + kc.ConvertToString(MenuActionStartTimer.ShortcutKeys) + ")";
            toolControlStop.ToolTipText = "Stop Timer (" + kc.ConvertToString(MenuActionStopTimer.ShortcutKeys) + ")";

            toolControlFirstEntry.ToolTipText = "Go to First Entry (" + kc.ConvertToString(MenuToolbarBrowserFirst.ShortcutKeys) + ")";
            toolControlLastEntry.ToolTipText = "Go to Last Entry (" + kc.ConvertToString(MenuToolbarBrowserLast.ShortcutKeys) + ")";
            toolControlNextEntry.ToolTipText = "Go to Next Entry (" + kc.ConvertToString(MenuToolbarBrowserNext.ShortcutKeys) + ")";
            toolControlPrevEntry.ToolTipText = "Go to Previous Entry (" + kc.ConvertToString(MenuToolbarBrowserPrev.ShortcutKeys) + ")";

            toolControlNewEntry.ToolTipText = "Go to New Entry (" + kc.ConvertToString(MenuToolbarBrowserNew.ShortcutKeys) + ")";
            toolControlCloseStartGap.ToolTipText = "Close Start Gap (" + kc.ConvertToString(MenuToolbarBrowserCloseStartGap.ShortcutKeys) + ")";
            toolControlCloseEndGap.ToolTipText = "Close End Gap (" + kc.ConvertToString(MenuToolbarBrowserCloseEndGap.ShortcutKeys) + ")";

            toolControlSave.ToolTipText = "Save Changes to Database (" + kc.ConvertToString(MenuToolbarBrowserSave.ShortcutKeys) + ")";
            toolControlRevert.ToolTipText = "Revert Changes to Last Saved State (" + kc.ConvertToString(MenuToolbarBrowserRevert.ShortcutKeys) + ")";
        }

        //---------------------------------------------------------------------

        private void Browser_ViewOtherAttributes()
        {
            LocationPanel.Height = Options.Layout_UseLocations ? 27 : 0;
            CategoryPanel.Height = Options.Layout_UseCategories ? 27 : 0;
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

            // Turn off button
            Browser_EnableRevert(false);
        }

        //---------------------------------------------------------------------

        public void Browser_SaveRow(bool forceSave)
        {
            // Bail if we have no entry
            if ((browserEntry == null) || (browserEntry.JournalId == 0)) {
                return;
            }

            // Copy form values to browser entry
            Browser_FormToEntry(ref browserEntry, browserEntry.JournalId);

            // Now bail if nothing's changed
            if (!forceSave) {
                /*
                if (browserEntry.Equals(priorLoadedBrowserEntry)) {
                    return;
                }
                */

                if (toolControlRevert.Enabled == false) {
                    // Instead of comparing the current to previous browser
                    // entry, let's just check the revert button, which
                    // is a user-facing visual indication that something
                    // has changed. This should prevent the problem where
                    // setting a hidden Project or Activity automatically
                    // resets the value. (Still not sure what to do about
                    // that in general: it's still an issue.)
                    //return;

                    // wait, one more test: special handling for the memo
                    // block while the timer is running.
                    if (timerRunning) {
                        if (browserEntry.Memo == priorLoadedBrowserEntry.Memo) {
                            return;
                        } else {
                            // The timer is running and the memo has changed, so
                            // please proceed to the save code below
                        }
                    } else {
                        return;
                    }
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
            /*
            string Message = String.Format("Entry.Save(). Id = {0}, Memo = \"{1}\", Prior Memo = \"{2}\"",
                browserEntry.JournalId, 
                Common.Abbreviate(browserEntry.Memo, 30), 
                Common.Abbreviate(priorLoadedBrowserEntry.Memo, 30)
                );
            Timekeeper.Warn(Message);
            */
            browserEntry.Save();

            // Once the entry has been saved, we may need to reindex
            if (browserEntry.StartTime != priorLoadedBrowserEntry.StartTime) {
                Entries.Reindex(browserEntry.StartTime);
                browserEntry.RefreshIndex();
                Timekeeper.Info("Reindexed Journal table starting at " + browserEntry.StartTime.ToString(Common.DATETIME_FORMAT));
            }

            // And disable reverting, just in case
            Browser_EnableRevert(false);
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
            Browser_EnableCloseEndGap(false);
            Browser_EnableSplit(false);

            Browser_EnableStartEntry(true);
            Browser_EnableStopEntry(false);
            Browser_EnableDurationEntry(false);
            Browser_EnableLocationEntry(true);
            Browser_EnableCategoryEntry(true);
        }

        private void Browser_SetBrowseState()
        {

            if (timerRunning) {
                Browser_ShowStart(false);
                Browser_ShowStop(true);

                Browser_EnableStart(false);
                Browser_EnableStop(false);

                Browser_EnableNew(false);

                Browser_EnableCloseStartGap(true);
                Browser_EnableCloseEndGap(true);

                Browser_EnableStartEntry(true);
                Browser_EnableStopEntry(true);
                Browser_EnableDurationEntry(true);
                Browser_EnableLocationEntry(true);
                Browser_EnableCategoryEntry(true);
            } else {
                Browser_ShowStart(true);
                Browser_ShowStop(false);

                Browser_EnableStart(false);
                Browser_EnableStop(false);

                Browser_EnableNew(true);

                Browser_EnableCloseStartGap(true);
                Browser_EnableCloseEndGap(true);

                Browser_EnableStartEntry(true);
                Browser_EnableStopEntry(true);
                Browser_EnableDurationEntry(true);
                Browser_EnableLocationEntry(true);
                Browser_EnableCategoryEntry(true);
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
            Browser_EnableCloseEndGap(false);

            Browser_EnableStartEntry(false);
            Browser_EnableStopEntry(false);
            Browser_EnableDurationEntry(false);
            Browser_EnableLocationEntry(false);
            Browser_EnableCategoryEntry(false);
        }

        //---------------------------------------------------------------------

        private void Browser_SetupForStarting()
        {
            try {
                // Just in case
                Browser_SaveRow(false);

                // Set UI accordingly
                Browser_SetCreateState();

                // Disable navigation if the database
                // is empty of journal entries.
                if (Entries.Count() == 0) {
                    Browser_DisableNavigation();
                }

                // Create browser objects
                //browserEntry = new Classes.Journal(Database);
                //browserEntry = new Classes.JournalEntry();
                //browserEntry = TimedEntry;
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
            toolControlStart.Visible = show;
            //menuToolControlStart.Visible = show;
        }

        private void Browser_ShowStop(bool show)
        {
            toolControlStop.Visible = show;
            //menuToolControlStop.Visible = show;
        }

        private void Browser_ShowUnlock(bool show)
        {
            toolControlUnlock.Visible = show;
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

        private void Browser_UpdateTimes()
        {
            if (isBrowsing) {
                long seconds = ConvertToSeconds(wDuration.Text);

                if (seconds != priorLoadedBrowserEntry.Seconds) {
                    if (seconds < 0) {
                        // either set the start time backwards
                        browserEntry.Seconds = -seconds;
                        browserEntry.StartTime = browserEntry.StopTime.AddSeconds(Convert.ToDouble(seconds));
                        wStartTime.Value = browserEntry.StartTime.LocalDateTime;
                        Browser_EnableRevert(true);
                    } else if (seconds > 0) {
                        // or the end time forward
                        browserEntry.Seconds = seconds;
                        browserEntry.StopTime = browserEntry.StartTime.AddSeconds(Convert.ToDouble(seconds));
                        wStopTime.Value = browserEntry.StopTime.LocalDateTime;
                        Browser_EnableRevert(true);
                    } else {
                        // duration is zero, do nothing
                    }

                    // reformat duration before leaving
                    wDuration.Text = Timekeeper.FormatSeconds(browserEntry.Seconds);
                }
            }
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private string Browser_CalculateDuration()
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
            catch (Exception x) {
                Timekeeper.Exception(x);
                return "00:00:00";
            }
        }

        // FIXME: where should this live?
        private long ConvertToSeconds(string time)
        {
            long seconds = 0;
            long h = 0;
            long m = 0;
            long s = 0;
            bool negative = false;

            try {
                if (time.Substring(0, 1) == "-") {
                    // user going back in time
                    negative = true;
                    // strip minus sign from text
                    time = time.Substring(1);
                }

                string[] parts = time.Split(':');

                switch (parts.Length) {
                    case 1:
                        // one part => minutes
                        h = 0;
                        m = Convert.ToInt32(parts[0]) * 60;
                        s = 0;
                        break;
                    case 2:
                        // two parts => hours minutes
                        h = Convert.ToInt32(parts[0]) * 3600;
                        m = Convert.ToInt32(parts[1]) * 60;
                        s = 0;
                        if ((m < 0) || (m > 3599)) {
                            throw new System.ApplicationException("invalid minutes");
                        }
                        break;
                    case 3:
                        // three parts => hours minutes seconds
                        h = Convert.ToInt32(parts[0]) * 3600;
                        m = Convert.ToInt32(parts[1]) * 60;
                        s = Convert.ToInt32(parts[2]);
                        if ((m < 0) || (m > 3599)) {
                            throw new System.ApplicationException("invalid minutes");
                        }
                        if ((s < 0) || (s > 59)) {
                            throw new System.ApplicationException("invalid seconds");
                        }
                        break;
                    default:
                        // if it's not 1, 2, or three, do nothing
                        break;
                }

                seconds = h + m + s;
            }
            catch {
                // do anything? -- probably not, just ignore it and 
                // return the default value of 0
            }

            return negative ? -seconds : seconds;
        }

        //---------------------------------------------------------------------

        private DateTime Browser_GetPreviousEndTime()
        {
            try {
                if (browserEntry.AtBeginning()) {
                    return DateTime.MinValue;
                } else {
                    Classes.JournalEntry copy = browserEntry.Copy();
                    copy.LoadPrevious();
                    return copy.StopTime.LocalDateTime;
                }
            }
            catch {
                return DateTime.MinValue;
            }
        }

        //---------------------------------------------------------------------

        private DateTime Browser_GetNextStartTime()
        {
            try {
                if (browserEntry.AtEnd()) {
                    return DateTime.MaxValue;
                } else {
                    Classes.JournalEntry copy = browserEntry.Copy();
                    copy.LoadNext();
                    return copy.StartTime.LocalDateTime;
                }
            }
            catch {
                return DateTime.MinValue;
            }
        }

        //---------------------------------------------------------------------

    }
}
