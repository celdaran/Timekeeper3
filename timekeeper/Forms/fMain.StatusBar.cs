using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class fMain
    {
        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        private void StatusBar_FileClosed()
        {
            StatusBarItemName.Text = "No Timer Running";
            StatusBarItemName.ForeColor = Color.Gray;

            StatusBarItemTime.Text = "0:00:00";
            StatusBarItemTimeToday.Text = "0:00:00";
            StatusBarItemsTimeToday.Text = "0:00:00";
            StatusBarItemTimeToday.ForeColor = Color.Gray;
            StatusBarItemsTimeToday.ForeColor = Color.Gray;
            StatusBarItemsTimeToday.ForeColor = Color.Gray;

            StatusBarFileName.Text = "No File Loaded";
            StatusBarFileName.ToolTipText = "No File Loaded";
            StatusBarFileName.ForeColor = Color.Gray;
        }

        //---------------------------------------------------------------------

        private void StatusBar_FileOpened()
        {
            StatusBarItemName.Text = "No Timer Running";
            StatusBarItemName.ForeColor = Color.Gray;

            StatusBarItemTime.Text = "0:00:00";
            StatusBarItemTimeToday.Text = "0:00:00";
            StatusBarItemsTimeToday.Text = "0:00:00";
            StatusBarItemTime.ForeColor = Color.Gray;
            StatusBarItemTimeToday.ForeColor = Color.Gray;
            StatusBarItemsTimeToday.ForeColor = Color.Gray;

            StatusBarFileName.Text = new Datafile().Name;
            StatusBarFileName.ToolTipText = DatabaseFileName + "\n(Right-click to copy to clipboard)";
            StatusBarFileName.ForeColor = Color.Black;
        }

        //---------------------------------------------------------------------

        private void StatusBar_SetVisibility()
        {
            // view or hide status bar items
            StatusBar.Visible = options.wViewStatusBar.Checked;
            StatusBarItemName.Visible = options.wViewCurrentTask.Checked;
            StatusBarItemTime.Visible = options.wViewElapsedCurrent.Checked;
            StatusBarItemTimeToday.Visible = options.wViewElapsedOne.Checked;
            StatusBarItemsTimeToday.Visible = options.wViewElapsedAll.Checked;
            StatusBarFileName.Visible = options.wViewOpenedFile.Checked;
        }

        //---------------------------------------------------------------------

        private void StatusBar_TimerStarted(string itemText)
        {
            StatusBarItemName.Text = itemText;
            StatusBarItemName.ForeColor = Color.Black;
            StatusBarItemTime.ForeColor = Color.Black;

            StatusBarItemTimeToday.ForeColor = Color.Black;
            StatusBarItemsTimeToday.ForeColor = Color.Black;
            StatusBarItemsTimeToday.ForeColor = Color.Black;
        }

        //---------------------------------------------------------------------

        private void StatusBar_TimerStopped()
        {
            StatusBarItemName.Text = "No Timer Running";
            StatusBarItemName.ForeColor = Color.Gray;
            StatusBarItemTime.ForeColor = Color.Gray;

            StatusBarItemTimeToday.ForeColor = Color.Gray;
            StatusBarItemsTimeToday.ForeColor = Color.Gray;
            StatusBarItemsTimeToday.ForeColor = Color.Gray;
        }

        //---------------------------------------------------------------------

        private void StatusBar_Update()
        {
            // Called when the timer is running
            StatusBarItemTime.Text = Timekeeper.FormatSeconds(elapsed);
            StatusBarItemTimeToday.Text = Timekeeper.FormatSeconds(elapsedToday);
            StatusBarItemsTimeToday.Text = Timekeeper.FormatSeconds(elapsedTodayAll);
        }

        //---------------------------------------------------------------------

        private void StatusBar_Update(Activity activity)
        {
            // Only called when the timer isn't running
            StatusBarItemTime.Text = "0:00:00";
            StatusBarItemTimeToday.Text = activity.ElapsedTodayFormatted();
            StatusBarItemsTimeToday.Text = Entries.ElapsedTodayFormatted();
        }

        //---------------------------------------------------------------------
    }
}
