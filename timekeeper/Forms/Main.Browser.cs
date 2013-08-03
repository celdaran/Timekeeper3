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
        private Classes.Journal browserEntry;
        private Classes.Journal priorLoadedBrowserEntry;
        private Classes.Journal newBrowserEntry;
        private bool isBrowsing = false;

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        private void Browser_Close()
        {
            // Save row, just in case
            Browser_SaveRow(false);

            // Kill any existing "new" entry
            newBrowserEntry = null;

            Browser_Show(false);
        }

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
                if (NextStartTime == DateTime.MinValue) {
                    // something went wrong, set it to now
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
                    ProjectTree.Enabled = false;
                    ActivityTree.Enabled = false;
                    Browser_EnableCloseStartGap(false);
                    Browser_EnableCloseEndGap(false);
                    Browser_EnableStartEntry(false);
                    Browser_EnableStopEntry(false);
                    Browser_EnableDurationEntry(false);
                    Browser_EnableLocationEntry(false);
                    Browser_EnableCategoryEntry(false);
                    Browser_EnableMemoEntry(false);
                    Browser_ShowUnlock(true);
                } else {
                    ProjectTree.Enabled = true;
                    ActivityTree.Enabled = true;
                    Browser_EnableCloseStartGap(true);
                    Browser_EnableCloseEndGap(true);
                    Browser_EnableStartEntry(true);
                    Browser_EnableStopEntry(true);
                    Browser_EnableDurationEntry(true);
                    Browser_EnableLocationEntry(true);
                    Browser_EnableCategoryEntry(true);
                    Browser_EnableMemoEntry(true);
                    Browser_ShowUnlock(false);
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
                wMemo.Focus();
            }
            catch (Exception x) {
                Common.Warn(x.ToString());
                Timekeeper.Exception(x);
            }
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

        private void Browser_EnableClose(bool enabled)
        {
            toolControlClose.Enabled = enabled;
            //menuToolControlClose.Enabled = enabled;
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
        }

        private void Browser_EnableStartEntry(bool enabled)
        {
            wStartTime.Enabled = enabled;
            labelStartTime.Enabled = enabled;
        }

        private void Browser_EnableStopEntry(bool enabled)
        {
            wStopTime.Enabled = enabled;
            labelEndTime.Enabled = enabled;
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
            wMemo.Enabled = enabled;
        }

        //---------------------------------------------------------------------

        private void Browser_FormToEntry(ref Classes.Journal entry, long entryId)
        {
            // Don't update the browser entry if nothing is selected
            if ((ProjectTree.SelectedNode == null) || (ActivityTree.SelectedNode == null)) {
                return;
            }

            // First translate some necessary data from the form 
            Project Project = (Project)ProjectTree.SelectedNode.Tag;
            Activity Activity = (Activity)ActivityTree.SelectedNode.Tag;
            TimeSpan Delta = wStopTime.Value.Subtract(wStartTime.Value);

            // Update browserEntry with current form data
            entry.JournalId = entryId;
            entry.ProjectId = Project.ItemId;
            entry.ActivityId = Activity.ItemId;
            entry.StartTime = wStartTime.Value;
            entry.StopTime = wStopTime.Value;
            entry.Seconds = (long)Delta.TotalSeconds;
            entry.Memo = wMemo.Text;
            entry.ProjectName = ProjectTree.SelectedNode.Text;
            entry.ActivityName = ActivityTree.SelectedNode.Text;
        }

        private void Browser_EntryToForm(Classes.Journal entry)
        {
            // Now select projects and activities while browsing.
            TreeNode ProjectNode = Widgets.FindTreeNode(ProjectTree.Nodes, entry.ProjectName);
            if (ProjectNode != null) {
                ProjectTree.SelectedNode = ProjectNode;
                ProjectTree.SelectedNode.Expand();
            }
            if ((ProjectNode == null) && (entry.JournalId != 0)) {

                Project HiddenProject = new Project(Database, entry.ProjectName);
                TreeNode HiddenNode = Widgets.AddHiddenProjectToTree(ProjectTree.Nodes, HiddenProject);

                ProjectTree.SelectedNode = HiddenNode;
                ProjectTree.SelectedNode.Expand();
            }

            // Yes, this is a nice copy/paste job from above.
            TreeNode ActivityNode = Widgets.FindTreeNode(ActivityTree.Nodes, entry.ActivityName);
            if (ActivityNode != null) {
                ActivityTree.SelectedNode = ActivityNode;
                ActivityTree.SelectedNode.Expand();
            }
            if ((ActivityNode == null) && (entry.JournalId != 0)) {
                // If we didn't find the node, it's been hidden. So
                // load it from the database and display it as hidden.

                Activity HiddenActivity = new Activity(Database, entry.ActivityName);
                TreeNode HiddenNode = Widgets.AddHiddenActivityToTree(ActivityTree.Nodes, HiddenActivity);

                ActivityTree.SelectedNode = HiddenNode;
                ActivityTree.SelectedNode.Expand();
            }

            // Display entry
            wStartTime.Value = entry.StartTime;
            wStopTime.Value = entry.StopTime;
            wDuration.Text = entry.Seconds > 0 ? Timekeeper.FormatSeconds(entry.Seconds) : "";
            wMemo.Text = entry.Memo;

            // And any other relevant values
            toolControlEntryId.Text = entry.JournalId > 0 ? entry.JournalId.ToString() : "";
        }

        //---------------------------------------------------------------------

        private void Browser_GotoFirstEntry()
        {
            try {
                Browser_SaveRow(false);
                browserEntry.LoadFirst();
                priorLoadedBrowserEntry = browserEntry.Copy();
                if (browserEntry.JournalId > 0) {
                    Browser_DisplayRow();
                    Browser_EnableLast(true);
                    Browser_EnableNext(true);
                    Browser_EnableFirst(false);
                    Browser_EnablePrev(false);
                    isBrowsing = true;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }


        //---------------------------------------------------------------------

        private void Browser_GotoLastEntry()
        {
            try {
                Browser_SaveRow(false);
                browserEntry.LoadLast();
                priorLoadedBrowserEntry = browserEntry.Copy();
                if (browserEntry.JournalId > 0) {
                    Browser_DisplayRow();
                    Browser_EnableFirst(true);
                    Browser_EnablePrev(true);
                    Browser_EnableLast(false);
                    Browser_EnableNext(false);
                    isBrowsing = true;
                }
                if (timerRunning) {
                    Browser_SetupForStopping();
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Browser_GotoNextEntry()
        {
            try {
                Browser_SaveRow(false);
                browserEntry.LoadNext();
                priorLoadedBrowserEntry = browserEntry.Copy();
                if (browserEntry.JournalId > 0) {
                    Browser_DisplayRow();
                    Browser_EnableFirst(true);
                    Browser_EnablePrev(true);
                    if (browserEntry.AtEnd()) {
                        Browser_EnableLast(false);
                        Browser_EnableNext(false);
                        if (timerRunning) {
                            //Common.Info("special handling here");
                            Browser_SetupForStopping();
                        }
                    }
                    isBrowsing = true;
                } else {
                    Browser_EnableLast(false);
                    Browser_EnableNext(false);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Browser_GotoPreviousEntry()
        {
            var t = new Stopwatch();

            try {
                if (!isBrowsing) {
                    // If we're not browsing, this is a new row. If it's a new
                    // row, save it so we don't lose it later.
                    Browser_FormToEntry(ref newBrowserEntry, 0);
                }

                /* Bench(t); */
                Browser_SaveRow(false);
                //Bench(t, "Browser_SaveRow");

                //Bench(t);
                // This is the second most expensive step (~150 ms)
                browserEntry.LoadPrevious();
                //Bench(t, "browserEntry.LoadPrevious");

                //Bench(t);
                priorLoadedBrowserEntry = browserEntry.Copy();
                //Bench(t, "browserEntry.Copy");

                if (browserEntry.JournalId > 0) {
                    //Bench(t);
                    // This is the most expensive step (~250 ms)
                    Browser_DisplayRow();
                    //Bench(t, "Browser_DisplayRow");

                    //Bench(t);
                    Browser_EnableLast(true);
                    Browser_EnableNext(true);
                    if (browserEntry.AtBeginning()) {
                        Browser_EnableFirst(false);
                        Browser_EnablePrev(false);
                    }
                    if (browserEntry.AtEnd()) {
                        Browser_EnableNext(false);
                        Browser_EnableLast(false);
                    }
                    isBrowsing = true;
                    //Bench(t, "Updating Toolbar Buttons");
                } else {
                    Browser_EnableFirst(false);
                    Browser_EnablePrev(false);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            //t.Stop();
            //StatusBarDebugging.Text = t.ElapsedMilliseconds.ToString();
            /* Bench(t, "Previous row displayed"); */
        }

        private void Bench(Stopwatch t)
        {
            t.Start();
        }

        private void Bench(Stopwatch t, string message)
        {
            t.Stop();
            Timekeeper.Info(message + ": " + t.ElapsedMilliseconds.ToString()); 
            t.Reset();
        }

        //---------------------------------------------------------------------

        private bool IsBrowserOpen()
        {
            return !splitMain.Panel2Collapsed;
        }

        //---------------------------------------------------------------------

        private void Browser_Load()
        {
            try {
                // Add keyboard shortcuts to tooltips
                var kc = new KeysConverter();
                toolControlFirstEntry.ToolTipText += " (" + kc.ConvertToString(MenuToolbarBrowserFirst.ShortcutKeys) + ")";
                toolControlLastEntry.ToolTipText += " (" + kc.ConvertToString(MenuToolbarBrowserLast.ShortcutKeys) + ")";
                toolControlNextEntry.ToolTipText += " (" + kc.ConvertToString(MenuToolbarBrowserNext.ShortcutKeys) + ")";
                toolControlPrevEntry.ToolTipText += " (" + kc.ConvertToString(MenuToolbarBrowserPrev.ShortcutKeys) + ")";

                toolControlStart.ToolTipText += " (" + kc.ConvertToString(MenuActionStartTimer.ShortcutKeys) + ")";
                toolControlStop.ToolTipText += " (" + kc.ConvertToString(MenuActionStopTimer.ShortcutKeys) + ")";
                toolControlClose.ToolTipText += " (Esc)";
            }
            catch (Exception x) {
                Common.Info("No file loaded.\n\n" + x.ToString());
            }
        }

        //---------------------------------------------------------------------

        private void Browser_Open()
        {
            Browser_Show(true);

            if (timerRunning) {
                Browser_SetupForStopping();
            }
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

            // Now display the row (which also handles toolbar button states)
            Browser_DisplayRow();
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
            string Message = String.Format("Entry.Save(). Id = {0}, Entry Seconds = {1}, Prior Entry Seconds = {2}",
                browserEntry.JournalId, browserEntry.Seconds, priorLoadedBrowserEntry.Seconds);
            Timekeeper.Warn(Message);
            browserEntry.Save();

            // And disable reverting, just in case
            Browser_EnableRevert(false);
        }

        //---------------------------------------------------------------------

        private void Browser_SetCreateState()
        {
            Browser_ShowStart(true);
            Browser_ShowStop(false);
            Browser_ShowClose(true);

            Browser_EnableStart(true);
            Browser_EnableStop(false);
            Browser_EnableClose(true);

            Browser_EnableFirst(true);
            Browser_EnablePrev(true);
            Browser_EnableNext(false);
            Browser_EnableLast(false);
            Browser_EnableNew(false);

            Browser_EnableCloseStartGap(true);
            Browser_EnableCloseEndGap(false);

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
                Browser_ShowClose(true);

                Browser_EnableStart(false);
                Browser_EnableStop(false);
                Browser_EnableClose(true);

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
                Browser_ShowClose(true);

                Browser_EnableStart(false);
                Browser_EnableStop(false);
                Browser_EnableClose(true);

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
            Browser_ShowClose(true);

            Browser_EnableStart(false);
            Browser_EnableStop(true);
            Browser_EnableClose(true);

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

                // Create browser objects
                browserEntry = new Classes.Journal(Database);
                //browserEntry.JournalId = 5000;
                priorLoadedBrowserEntry = new Classes.Journal(Database);
                if (newBrowserEntry == null) {
                    newBrowserEntry = new Classes.Journal(Database);
                }
                isBrowsing = false;
                StartTimeManuallySet = false;

                // Load empty form
                Browser_EntryToForm(newBrowserEntry);

                wMemo.Focus();
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

            // Reset browser entry
            isBrowsing = false;

            // Ensure proper display
            wMemo.Focus();
        }

        //---------------------------------------------------------------------

        private void Browser_Show(bool show)
        {
            MenuActionOpenBrowser.Visible = !show;
            MenuActionCloseBrowser.Visible = show;
            splitMain.Panel2Collapsed = !show;
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

        private void Browser_ShowClose(bool show)
        {
            toolControlClose.Visible = show;
            //menuToolControlClose.Visible = show;
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
                        wStartTime.Value = browserEntry.StartTime;
                        Browser_EnableRevert(true);
                    } else if (seconds > 0) {
                        // or the end time forward
                        browserEntry.Seconds = seconds;
                        browserEntry.StopTime = browserEntry.StartTime.AddSeconds(Convert.ToDouble(seconds));
                        wStopTime.Value = browserEntry.StopTime;
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
                Classes.Journal copy = browserEntry.Copy();
                copy.LoadPrevious();
                return copy.StopTime;
            }
            catch {
                return DateTime.MinValue;
            }
        }

        //---------------------------------------------------------------------

        private DateTime Browser_GetNextStartTime()
        {
            try {
                Classes.Journal copy = browserEntry.Copy();
                copy.LoadNext();
                return copy.StartTime;
            }
            catch {
                return DateTime.MinValue;
            }
        }

        //---------------------------------------------------------------------

    }
}
