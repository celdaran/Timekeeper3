using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    partial class Main
    {
        //----------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        // FIXME/TODO: Apart from whatever individual visibility options have
        // been set, the overall "Use Projects" and "Use Activities" options
        // will ultimately dictate what appears on the status bar.
        //----------------------------------------------------------------------

        private void StatusBar_Inactive()
        {
            StatusBarCurrentProject.ForeColor = Color.Gray;
            StatusBarCurrentActivity.ForeColor = Color.Gray;

            StatusBarElapsedSinceStart.ForeColor = Color.Gray;
            StatusBarElapsedProjectToday.ForeColor = Color.Gray;
            StatusBarElapsedActivityToday.ForeColor = Color.Gray;
            StatusBarElapsedAllToday.ForeColor = Color.Gray;
        }

        //----------------------------------------------------------------------

        private void StatusBar_NullValues(bool includeTimers)
        {
            StatusBarCurrentProject.Text = "Project";
            StatusBarCurrentActivity.Text = "Activity";

            if (includeTimers) {
                StatusBarElapsedSinceStart.Text = "0:00:00";
                StatusBarElapsedProjectToday.Text = "0:00:00";
                StatusBarElapsedActivityToday.Text = "0:00:00";
                StatusBarElapsedAllToday.Text = "0:00:00";
            }
        }

        //----------------------------------------------------------------------

        private void StatusBar_FileClosed()
        {
            StatusBar_Inactive();
            StatusBar_NullValues(true);

            StatusBarFileName.Text = "No File Open";
            StatusBarFileName.ToolTipText = "No Timekeeper file has been opened. Use File|New or File|Open to begin.";
            StatusBarFileName.ForeColor = Color.Gray;
        }

        //---------------------------------------------------------------------

        private void StatusBar_FileOpened()
        {
            StatusBar_Inactive();
            StatusBar_NullValues(true);

            StatusBarFileName.Text = new File().Name;
            StatusBarFileName.ToolTipText = DatabaseFileName + "\n(Right-click to copy to clipboard)";
            StatusBarFileName.ForeColor = Color.Black;
        }

        //---------------------------------------------------------------------

        private void StatusBar_SetVisibility()
        {
            StatusBar.Visible = Options.View_StatusBar;
            StatusBarCurrentProject.Visible = Options.View_StatusBar_ProjectName;
            StatusBarCurrentActivity.Visible = Options.View_StatusBar_ActivityName;
            StatusBarElapsedSinceStart.Visible = Options.View_StatusBar_ElapsedSinceStart;
            StatusBarElapsedProjectToday.Visible = Options.View_StatusBar_ElapsedProjectToday;
            StatusBarElapsedActivityToday.Visible = Options.View_StatusBar_ElapsedActivityToday;
            StatusBarElapsedAllToday.Visible = Options.View_StatusBar_ElapsedAllToday;
            StatusBarFileName.Visible = Options.View_StatusBar_FileName;
        }

        //---------------------------------------------------------------------

        private void StatusBar_TimerStarted(string projectName, string activityName)
        {
            StatusBarCurrentProject.Text = projectName;
            StatusBarCurrentProject.ForeColor = Color.Black;

            StatusBarCurrentActivity.Text = activityName;
            StatusBarCurrentActivity.ForeColor = Color.Black;

            StatusBarElapsedSinceStart.ForeColor = Color.Black;
            StatusBarElapsedProjectToday.ForeColor = Color.Black;
            StatusBarElapsedActivityToday.ForeColor = Color.Black;
            StatusBarElapsedAllToday.ForeColor = Color.Black;
        }

        //---------------------------------------------------------------------

        private void StatusBar_TimerStopped()
        {
            StatusBar_Inactive();
            StatusBar_NullValues(false);
        }

        //---------------------------------------------------------------------

        private void StatusBar_Update()
        {
            // Called when the timer is running
            StatusBarElapsedSinceStart.Text = Timekeeper.FormatSeconds(ElapsedSinceStart);
            StatusBarElapsedProjectToday.Text = Timekeeper.FormatSeconds(ElapsedProjectToday);
            StatusBarElapsedActivityToday.Text = Timekeeper.FormatSeconds(ElapsedActivityToday);
            StatusBarElapsedAllToday.Text = Timekeeper.FormatSeconds(ElapsedAllToday);
        }

        //---------------------------------------------------------------------

        private void StatusBar_Update(Classes.Project project, Classes.Activity activity)
        {
            // Called when the timer isn't running
            StatusBarElapsedSinceStart.Text = "0:00:00";
            StatusBarElapsedProjectToday.Text = project.ElapsedTodayFormatted();
            StatusBarElapsedActivityToday.Text = activity.ElapsedTodayFormatted();
            StatusBarElapsedAllToday.Text = Entries.ElapsedTodayFormatted();
        }

        //---------------------------------------------------------------------
    }
}
