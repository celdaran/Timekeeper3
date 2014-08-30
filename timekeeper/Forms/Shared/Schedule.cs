using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Media;
using System.Text.RegularExpressions;

using Technitivity.Toolbox;
using Quartz;

namespace Timekeeper.Forms.Shared
{
    public partial class Schedule : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private long ScheduleId;

        private Classes.Options Options;
        private Classes.Widgets Widgets;

        public DateTime ExternalEventNextOccurrence { get; set; }
        public Classes.Schedule CurrentSchedule { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Schedule(long? scheduleId, DateTime eventNextOccurrence)
        {
            InitializeComponent();
            this.ScheduleId = scheduleId == null ? 0 : (long)scheduleId;
            this.ExternalEventNextOccurrence = eventNextOccurrence;
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Event_Load(object sender, EventArgs e)
        {
            this.Widgets = new Classes.Widgets();
            this.Options = Timekeeper.Options;
            this.CurrentSchedule = new Classes.Schedule(this.ScheduleId);

            ScheduleTabControl.TabPages.RemoveByKey("HiddenTab");
            ThenLabel.Visible = false;
            TargetPanel.Visible = false;

            PopulateForm(sender, e);
        }

        //----------------------------------------------------------------------

        private void Event_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
            return;
            /*
            if (Common.WarnPrompt("Are you sure?") == DialogResult.Yes) {
                e.Cancel = false;
            } else {
                e.Cancel = true;
            }
            */
        }

        //----------------------------------------------------------------------

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            // Set Schedule Type
            if (RecurNoneRadioButton.Checked)
                CurrentSchedule.RefScheduleTypeId = 1;
            else if (RecurFixedRadioButton.Checked)
                CurrentSchedule.RefScheduleTypeId = 2;
            else if (RecurDailyRadioButton.Checked)
                CurrentSchedule.RefScheduleTypeId = 3;
            else if (RecurWeeklyRadioButton.Checked)
                CurrentSchedule.RefScheduleTypeId = 4;
            else if (RecurMonthlyRadioButton.Checked)
                CurrentSchedule.RefScheduleTypeId = 5;
            else if (RecurYearlyRadioButton.Checked)
                CurrentSchedule.RefScheduleTypeId = 6;
            else
                CurrentSchedule.RefScheduleTypeId = 7;

            // Type 1
            //CurrentSchedule.  FIXME: need to link the start time back to the event

            // Type 2: Fixed
            CurrentSchedule.OnceAmount = (long)OnceAmountValue.Value;
            CurrentSchedule.OnceUnit = OnceUnitList.SelectedIndex + 1;

            // Type 3: Daily
            if (DailyEveryDayRadioButton.Checked)
                CurrentSchedule.DailyTypeId = 1;
            else if (DailyEveryWeekdayRadioButton.Checked)
                CurrentSchedule.DailyTypeId = 2;
            else if (DailyIntervalRadioButton.Checked)
                CurrentSchedule.DailyTypeId = 3;
            CurrentSchedule.DailyIntervalCount = (long)DailyIntervalCountValue.Value;

            // Type 4: Weekly
            CurrentSchedule.WeeklyIntervalCount = (long)WeeklyIntervalCountValue.Value;
            CurrentSchedule.WeeklyMonday = WeeklyMondayCheckbox.Checked;
            CurrentSchedule.WeeklyTuesday = WeeklyTuesdayCheckbox.Checked;
            CurrentSchedule.WeeklyWednesday = WeeklyWednesdayCheckbox.Checked;
            CurrentSchedule.WeeklyThursday = WeeklyThursdayCheckbox.Checked;
            CurrentSchedule.WeeklyFriday = WeeklyFridayCheckbox.Checked;
            CurrentSchedule.WeeklySaturday = WeeklySaturdayCheckbox.Checked;
            CurrentSchedule.WeeklySunday = WeeklySundayCheckbox.Checked;

            // Type 5: Monthly
            if (MonthlyDateRadioButton.Checked) 
                CurrentSchedule.MonthlyTypeId = 1;
            else if (MonthlyDayRadioButton.Checked)
                CurrentSchedule.MonthlyTypeId = 2;

            CurrentSchedule.MonthlyDate = (long)MonthlyDateValue.Value;
            // FIXME: WTF's with these name mismatches? What's on the form should match what's in the database wherever possible
            CurrentSchedule.MonthlyOrdinalDay = MonthlyOrdinalWeekList.SelectedIndex + 1;
            CurrentSchedule.MonthlyDayOfWeek = MonthlyDayOfWeekList.SelectedIndex + 1;
            CurrentSchedule.MonthlyIntervalCount = (long)MonthlyIntervalCountValue.Value;

            // Type 6: Yearly
            if (YearlyDateRadioButton.Checked)
                CurrentSchedule.YearlyTypeId = 1;
            else if (YearlyDayRadioButton.Checked)
                CurrentSchedule.YearlyTypeId = 2;

            CurrentSchedule.YearlyEveryDate = (long)YearlyDateValue.Value;
            CurrentSchedule.YearlyOrdinalDay = YearlyOrdinalWeekList.SelectedIndex + 1;
            CurrentSchedule.YearlyDayOfWeek = YearlyDayOfWeekList.SelectedIndex + 1;
            CurrentSchedule.YearlyMonth = YearlyMonthList.SelectedIndex + 1;

            // Type 7: Cronly
            CurrentSchedule.CrontabExpression = CrontabExpressionValue.Text;

            // Duration tab
            if (RunIndefinitelyButton.Checked)
                CurrentSchedule.DurationTypeId = 1;
            else if (StopAfterCountRadioButton.Checked) {
                CurrentSchedule.DurationTypeId = 2;
                CurrentSchedule.StopAfterCount = (long)StopAfterCountValue.Value;
            } else if (StopAfterTimeRadioButton.Checked) {
                CurrentSchedule.DurationTypeId = 3;
                CurrentSchedule.StopAfterTime = StopAfterTimeValue.Value;
            }

            // Now save
            CurrentSchedule.Save();

            // And get out of here
            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------

        private void CancelDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //----------------------------------------------------------------------
        // Form Event Helpers
        //----------------------------------------------------------------------

        private int GetValue(object value, object defaultValue)
        {
            // Very thin wrapper/helper
            return Convert.ToInt32(Timekeeper.GetValue(value, defaultValue));
        }

        private void PopulateForm(object sender, EventArgs e)
        {
            try {
                //------------------------------------------
                // Set the current event time
                //------------------------------------------

                EventNextOccurrence.CustomFormat = Options.Advanced_DateTimeFormat;
                EventNextOccurrence.Value = this.ExternalEventNextOccurrence;

                //------------------------------------------
                // Set defaults, if no schedule loaded
                //------------------------------------------

                if (this.ScheduleId == 0) {
                    OnceUnitList.SelectedIndex = 2;
                    DailyEveryDayRadioButton.Checked = true;
                    MonthlyDateRadioButton.Checked = true;
                    MonthlyOrdinalWeekList.SelectedIndex = 0;
                    MonthlyDayOfWeekList.SelectedIndex = 0;
                    YearlyDateRadioButton.Checked = true;
                    YearlyOrdinalWeekList.SelectedIndex = 0;
                    YearlyDayOfWeekList.SelectedIndex = 0;
                    YearlyMonthList.SelectedIndex = 0;
                    return;
                }

                //------------------------------------------
                // Prepopulate all panels
                //------------------------------------------

                // FIXME: I don't know why casting this as an (int) isn't working; it works everywhere else!
                OnceUnitList.SelectedIndex = GetValue(CurrentSchedule.OnceUnit, 1) - 1;
                OnceAmountValue.Value = GetValue(CurrentSchedule.OnceAmount, 1);

                //------------------------------------------

                switch (CurrentSchedule.DailyTypeId) {
                    case 1: DailyEveryDayRadioButton.Checked = true; break;
                    case 2: DailyEveryWeekdayRadioButton.Checked = true; break;
                    case 3: DailyIntervalRadioButton.Checked = true; break;
                }
                DailyIntervalCountValue.Value = GetValue(CurrentSchedule.DailyIntervalCount, 1);

                //------------------------------------------

                WeeklyIntervalCountValue.Value = GetValue(CurrentSchedule.WeeklyIntervalCount, 1);
                WeeklyMondayCheckbox.Checked = CurrentSchedule.WeeklyMonday;
                WeeklyTuesdayCheckbox.Checked = CurrentSchedule.WeeklyTuesday;
                WeeklyWednesdayCheckbox.Checked = CurrentSchedule.WeeklyWednesday;
                WeeklyThursdayCheckbox.Checked = CurrentSchedule.WeeklyThursday;
                WeeklyFridayCheckbox.Checked = CurrentSchedule.WeeklyFriday;
                WeeklySaturdayCheckbox.Checked = CurrentSchedule.WeeklySaturday;
                WeeklySundayCheckbox.Checked = CurrentSchedule.WeeklySunday;

                //------------------------------------------

                switch (CurrentSchedule.MonthlyTypeId) {
                    case 1: MonthlyDateRadioButton.Checked = true; break;
                    case 2: MonthlyDayRadioButton.Checked = true; break;
                }

                MonthlyDateValue.Value = GetValue(CurrentSchedule.MonthlyDate, 1);
                // FIXME: WTF's with these name mismatches? What's on the form should match what's in the database wherever possible
                MonthlyOrdinalWeekList.SelectedIndex = GetValue(CurrentSchedule.MonthlyOrdinalDay, 1) - 1; 
                MonthlyDayOfWeekList.SelectedIndex = GetValue(CurrentSchedule.MonthlyDayOfWeek, 1) - 1;
                MonthlyIntervalCountValue.Value = GetValue(CurrentSchedule.MonthlyIntervalCount, 1);

                //------------------------------------------

                switch (CurrentSchedule.YearlyTypeId) {
                    case 1: YearlyDateRadioButton.Checked = true; break;
                    case 2: YearlyDayRadioButton.Checked = true; break;
                }

                YearlyDateValue.Value = GetValue(CurrentSchedule.YearlyEveryDate, 1);
                YearlyOrdinalWeekList.SelectedIndex = GetValue(CurrentSchedule.YearlyOrdinalDay, 1) - 1;
                YearlyDayOfWeekList.SelectedIndex = GetValue(CurrentSchedule.YearlyDayOfWeek, 1) - 1;
                YearlyMonthList.SelectedIndex = GetValue(CurrentSchedule.YearlyMonth, 1) - 1;

                //------------------------------------------

                CrontabExpressionValue.Text = CurrentSchedule.CrontabExpression;

                //------------------------------------------
                // Lastly, select the broad schedule type
                //------------------------------------------

                switch (CurrentSchedule.RefScheduleTypeId) {
                    case 1: RecurNoneRadioButton.Checked = true; break;
                    case 2: RecurFixedRadioButton.Checked = true; break;
                    case 3: RecurDailyRadioButton.Checked = true; break;
                    case 4: RecurWeeklyRadioButton.Checked = true; break;
                    case 5: RecurMonthlyRadioButton.Checked = true; break;
                    case 6: RecurYearlyRadioButton.Checked = true; break;
                    case 7: RecurCronRadioButton.Checked = true; break;
                }

                //------------------------------------------
                // Duration Tab
                //------------------------------------------

                StopAfterTimeValue.CustomFormat = Options.Advanced_DateTimeFormat;

                switch (CurrentSchedule.DurationTypeId) {
                    case 1: 
                        RunIndefinitelyButton.Checked = true;
                        break;
                    case 2:
                        StopAfterCountRadioButton.Checked = true;
                        StopAfterCountValue.Value = (int)CurrentSchedule.StopAfterCount;
                        break;
                    case 3:
                        StopAfterTimeRadioButton.Checked = true;
                        StopAfterTimeValue.Value = CurrentSchedule.StopAfterTime.Value.DateTime;
                        break;
                }

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //======================================================================
        // SCHEDULE TAB
        //======================================================================

        //----------------------------------------------------------------------
        // Radio Events
        //----------------------------------------------------------------------

        private void RecurNoneRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurNoneRadioButton.Checked) {
                HideAllPanels();
                EnableDurationTab(false);
                ThenLabel.Visible = false;
                TargetPanel.Visible = false;
            }
        }

        private void RecurFixedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurFixedRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurFixedPanel);
            }
        }

        private void RecurDailyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurDailyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurDailyPanel);
            }
        }

        private void RecurWeeklyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurWeeklyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurWeeklyPanel);
            }
        }

        private void RecurMonthlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurMonthlyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurMonthlyPanel);
            }
        }

        private void RecurYearlyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurYearlyRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurYearlyPanel);
            }
        }

        private void RecurCronRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RecurCronRadioButton.Checked) {
                HideAllPanels();
                RelocatePanel(RecurCronPanel);
            }
        }

        private void DailyEveryDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DailyEveryDayRadioButton.Checked) {
                DailyIntervalCountValue.Enabled = false;
            }
        }

        private void DailyEveryWeekdayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DailyEveryWeekdayRadioButton.Checked) {
                DailyIntervalCountValue.Enabled = false;
            }
        }

        private void DailyIntervalRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (DailyIntervalRadioButton.Checked) {
                DailyIntervalCountValue.Enabled = true;
            }
        }

        private void MonthlyDateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MonthlyDateRadioButton.Checked) {
                MonthlyDateValue.Enabled = true;
                MonthlyOrdinalWeekList.Enabled = false;
                MonthlyDayOfWeekList.Enabled = false;
            }
        }

        private void MonthlyDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MonthlyDayRadioButton.Checked) {
                MonthlyDateValue.Enabled = false;
                MonthlyOrdinalWeekList.Enabled = true;
                MonthlyDayOfWeekList.Enabled = true;
            }
        }

        private void YearlyDateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (YearlyDateRadioButton.Checked) {
                YearlyDateValue.Enabled = true;
                YearlyOrdinalWeekList.Enabled = false;
                YearlyDayOfWeekList.Enabled = false;
            }
        }

        private void YearlyDayRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (YearlyDayRadioButton.Checked) {
                YearlyDateValue.Enabled = false;
                YearlyOrdinalWeekList.Enabled = true;
                YearlyDayOfWeekList.Enabled = true;
            }
        }

        //----------------------------------------------------------------------
        // Sub-form Event Handlers
        //----------------------------------------------------------------------

        private void CrontabSeconds_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Regex.IsMatch(e.KeyChar.ToString(), @"^[0-9\*\/\?\-]")) {
                e.Handled = false;
            } else if (e.KeyChar == 8) {
                e.Handled = false;
            } else {
                e.Handled = true;
            }
        }

        //----------------------------------------------------------------------

        private void CrontabElement_TextChanged(object sender, EventArgs e)
        {
            this.CrontabExpressionValue.TextChanged -= this.CrontabExpression_TextChanged;

            // Build up full expression
            CrontabExpressionValue.Text =
                CrontabSeconds.Text + " " +
                CrontabMinutes.Text + " " +
                CrontabHours.Text + " " +
                CrontabDayOfMonth.Text + " " +
                CrontabMonth.Text + " " +
                CrontabDayOfWeek.Text;

            // Special handling
            /*
            if ((CrontabDayOfMonth.Text == "?") && (CrontabDayOfWeek.Text == "?")) {
                Common.Warn("Day of Month and Day of Week cannot both be ?");
            }

            if ((CrontabDayOfMonth.Text == "*") && (CrontabDayOfWeek.Text == "*")) {
                Common.Warn("Day of Month and Day of Week cannot both be *");
            }
            */

            this.CrontabExpressionValue.TextChanged += new System.EventHandler(this.CrontabExpression_TextChanged);
        }

        //----------------------------------------------------------------------

        private void CrontabExpression_TextChanged(object sender, EventArgs e)
        {
            // Bit of a hack, but disable cross-updating
            this.CrontabSeconds.TextChanged -= this.CrontabElement_TextChanged;
            this.CrontabMinutes.TextChanged -= this.CrontabElement_TextChanged;
            this.CrontabHours.TextChanged -= this.CrontabElement_TextChanged;
            this.CrontabDayOfMonth.TextChanged -= this.CrontabElement_TextChanged;
            this.CrontabMonth.TextChanged -= this.CrontabElement_TextChanged;
            this.CrontabDayOfWeek.TextChanged -= this.CrontabElement_TextChanged;

            // Clear existing values
            CrontabSeconds.Text = "";
            CrontabMinutes.Text = "";
            CrontabHours.Text = "";
            CrontabDayOfMonth.Text = "";
            CrontabMonth.Text = "";
            CrontabDayOfWeek.Text = "";

            // Repopulate
            string[] Parts = CrontabExpressionValue.Text.Split(' ');
            if (Parts.Length > 0)
                CrontabSeconds.Text = Parts[0];
            if (Parts.Length > 1)
                CrontabMinutes.Text = Parts[1];
            if (Parts.Length > 2)
                CrontabHours.Text = Parts[2];
            if (Parts.Length > 3)
                CrontabDayOfMonth.Text = Parts[3];
            if (Parts.Length > 4)
                CrontabMonth.Text = Parts[4];
            if (Parts.Length > 5)
                CrontabDayOfWeek.Text = Parts[5];
            if (Parts.Length > 6)
                Alert("Invalid expression");

            // And reenable when done
            this.CrontabSeconds.TextChanged += new System.EventHandler(this.CrontabElement_TextChanged);
            this.CrontabMinutes.TextChanged += new System.EventHandler(this.CrontabElement_TextChanged);
            this.CrontabHours.TextChanged += new System.EventHandler(this.CrontabElement_TextChanged);
            this.CrontabDayOfMonth.TextChanged += new System.EventHandler(this.CrontabElement_TextChanged);
            this.CrontabMonth.TextChanged += new System.EventHandler(this.CrontabElement_TextChanged);
            this.CrontabDayOfWeek.TextChanged += new System.EventHandler(this.CrontabElement_TextChanged);
        }

        //----------------------------------------------------------------------
        // Radio Event Helpers
        //----------------------------------------------------------------------

        private void EnableDurationTab(bool enabled)
        {
            RunIndefinitelyButton.Enabled = enabled;
            StopAfterCountRadioButton.Enabled = enabled;
            StopAfterTimeRadioButton.Enabled = enabled;
            StopAfterCountValue.Enabled = StopAfterCountRadioButton.Checked && StopAfterCountRadioButton.Enabled;
            StopAfterTimeValue.Enabled = StopAfterTimeRadioButton.Checked && StopAfterTimeRadioButton.Enabled;
        }

        //----------------------------------------------------------------------

        private void RelocatePanel(Panel panel)
        {
            panel.Top = TargetPanel.Top; // +6;
            panel.Left = TargetPanel.Left; // +6;
            panel.Parent = ScheduleTab; // PatternGroupBox;
            panel.BringToFront();
            EnableDurationTab(true);
            ThenLabel.Visible = true;
            TargetPanel.Visible = true;
        }

        //----------------------------------------------------------------------

        private void HideAllPanels()
        {
            RecurFixedPanel.Parent = PanelCorral;
            RecurDailyPanel.Parent = PanelCorral;
            RecurWeeklyPanel.Parent = PanelCorral;
            RecurMonthlyPanel.Parent = PanelCorral;
            RecurYearlyPanel.Parent = PanelCorral;
            RecurCronPanel.Parent = PanelCorral;
        }

        //======================================================================
        // DURATION TAB
        //======================================================================

        //----------------------------------------------------------------------
        // Radio Button Events
        //----------------------------------------------------------------------

        private void RunIndefinitelyButton_CheckedChanged(object sender, EventArgs e)
        {
            if (RunIndefinitelyButton.Checked) {
                StopAfterCountValue.Enabled = !RunIndefinitelyButton.Checked;
                StopAfterTimeValue.Enabled = !RunIndefinitelyButton.Checked;
            }
        }

        private void StopAfterCountRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (StopAfterCountRadioButton.Checked) {
                StopAfterCountValue.Enabled = !RunIndefinitelyButton.Checked;
                StopAfterTimeValue.Enabled = RunIndefinitelyButton.Checked;
            }
        }

        private void StopAfterTimeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (StopAfterTimeRadioButton.Checked) {
                StopAfterCountValue.Enabled = RunIndefinitelyButton.Checked;
                StopAfterTimeValue.Enabled = !RunIndefinitelyButton.Checked;
            }
        }

        //----------------------------------------------------------------------
        // TEMPORARY AND/OR EXPERIMENTAL
        //----------------------------------------------------------------------

        private void CrontabTesterButton_Click(object sender, EventArgs e)
        {
            try {
                UpdatePreview();
            }
            catch (Exception x) {
                UpdatePreviewWindow(x.Message);
                //Common.Warn(x.ToString());
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void UpdatePreview()
        {
            if (RecurNoneRadioButton.Checked) {
                UpdatePreviewWindow(EventNextOccurrence.Value);
            }

            if (RecurFixedRadioButton.Checked) {

                ITrigger FixedTrigger = CurrentSchedule.FixedTrigger(
                    "Preview Trigger",
                    EventNextOccurrence.Value,
                    OnceUnitList.SelectedIndex + 1,
                    (int)OnceAmountValue.Value);

                UpdatePreviewWindow(FixedTrigger);
            }

            if (RecurDailyRadioButton.Checked) {

                int DailyTypeId = 0;

                if (DailyEveryDayRadioButton.Checked)
                    DailyTypeId = 1;
                if (DailyEveryWeekdayRadioButton.Checked)
                    DailyTypeId = 2;
                if (DailyIntervalRadioButton.Checked)
                    DailyTypeId = 3;

                ITrigger DailyTrigger = CurrentSchedule.DailyTrigger(
                    "Preview Trigger",
                    EventNextOccurrence.Value,
                    DailyTypeId,
                    (int)DailyIntervalCountValue.Value);

                UpdatePreviewWindow(DailyTrigger);
            }

            if (RecurWeeklyRadioButton.Checked) {

                List<string> Weekdays = new List<string>();

                if (WeeklyMondayCheckbox.Checked)
                    Weekdays.Add("MON");
                if (WeeklyTuesdayCheckbox.Checked)
                    Weekdays.Add("TUE");
                if (WeeklyWednesdayCheckbox.Checked)
                    Weekdays.Add("WED");
                if (WeeklyThursdayCheckbox.Checked)
                    Weekdays.Add("THU");
                if (WeeklyFridayCheckbox.Checked)
                    Weekdays.Add("FRI");
                if (WeeklySaturdayCheckbox.Checked)
                    Weekdays.Add("SAT");
                if (WeeklySundayCheckbox.Checked)
                    Weekdays.Add("SUN");

                ITrigger WeeklyTrigger = CurrentSchedule.WeeklyTrigger(
                    "Preview Trigger",
                    EventNextOccurrence.Value,
                    Weekdays);
                UpdatePreviewWindow(WeeklyTrigger);
            }

            if (RecurMonthlyRadioButton.Checked) {

                ITrigger MonthlyTrigger;

                if (MonthlyDateRadioButton.Checked) {
                    MonthlyTrigger = CurrentSchedule.MonthlyTrigger(
                        "Preview Trigger",
                        EventNextOccurrence.Value,
                        (int)MonthlyDateValue.Value,
                        (int)MonthlyIntervalCountValue.Value);
                } else {
                    MonthlyTrigger = CurrentSchedule.MonthlyTrigger(
                        "Preview Trigger",
                        EventNextOccurrence.Value,
                        MonthlyDayOfWeekList.SelectedIndex + 1,
                        MonthlyOrdinalWeekList.SelectedIndex + 1,
                        (int)MonthlyIntervalCountValue.Value);
                }

                UpdatePreviewWindow(MonthlyTrigger);
            }

            if (RecurYearlyRadioButton.Checked) {

                ITrigger YearlyTrigger;

                if (YearlyDateRadioButton.Checked) {
                    YearlyTrigger = CurrentSchedule.YearlyTrigger(
                        "Preview Trigger",
                        EventNextOccurrence.Value,
                        (int)YearlyDateValue.Value,
                        YearlyMonthList.SelectedIndex + 1);
                } else {
                    YearlyTrigger = CurrentSchedule.YearlyTrigger(
                        "Preview Trigger",
                        EventNextOccurrence.Value,
                        YearlyDayOfWeekList.SelectedIndex + 1,
                        YearlyOrdinalWeekList.SelectedIndex + 1,
                        YearlyMonthList.SelectedIndex + 1);
                }

                UpdatePreviewWindow(YearlyTrigger);
            }

            if (RecurCronRadioButton.Checked) {
                ITrigger CronTrigger = CurrentSchedule.CronTrigger(
                    "Preview Trigger",
                    EventNextOccurrence.Value,
                    CrontabExpressionValue.Text,
                    "Cronly");
                UpdatePreviewWindow(CronTrigger);
            }
        }

        //----------------------------------------------------------------------

        private void UpdatePreviewCron(string cronExpression)
        {
            ITrigger PreviewTrigger = TriggerBuilder.Create()
                .WithIdentity("Preview Trigger")
                .WithCronSchedule(cronExpression)
                .StartAt(EventNextOccurrence.Value)
                .Build();
            UpdatePreviewWindow(PreviewTrigger);
        }

        //----------------------------------------------------------------------

        private void UpdatePreviewWindow(ITrigger trigger)
        {
            string DateTimeFormat = Options.Advanced_DateTimeFormat + " (ddd)";

            // Find first one
            DateTimeOffset? EventStartTime = trigger.StartTimeUtc;
            SchedulePreview.Text = EventStartTime.Value.ToString(DateTimeFormat) + "\n";

            // Determine loop count
            int CountTo = StopAfterCountRadioButton.Checked ?
                Convert.ToInt32(Math.Min(StopAfterCountValue.Value, PreviewCount.Value)) :
                Convert.ToInt32(PreviewCount.Value);

            // Then loop through more (perhaps all) subsequently scheduled timers
            DateTimeOffset CurrentEvent = (DateTimeOffset)EventStartTime;
            for (int i = 0; i < CountTo - 1; i++) {

                DateTimeOffset? NextEvent = trigger.GetFireTimeAfter(CurrentEvent);

                // Bail point?
                if (StopAfterTimeRadioButton.Checked) {
                    /*
                    string Debug = String.Format(@"Event: {0}, Limit: {1}", NextEvent.Value.LocalDateTime, StopAfterTimeValue.Value);
                    Common.Info(Debug);
                    */
                    if (NextEvent.Value.LocalDateTime > StopAfterTimeValue.Value) {
                        break;
                    }
                }

                SchedulePreview.Text += NextEvent.Value.LocalDateTime.ToString(DateTimeFormat) + "\n";
                CurrentEvent = (DateTimeOffset)NextEvent;
            }
        }

        //----------------------------------------------------------------------

        private void UpdatePreviewWindow(DateTime dateTime)
        {
            string DateTimeFormat = Options.Advanced_DateTimeFormat + " (ddd)";
            SchedulePreview.Text = dateTime.ToString(DateTimeFormat);
        }

        //----------------------------------------------------------------------

        private void UpdatePreviewWindow(string message)
        {
            SchedulePreview.Text += message + "\n";
        }

        //----------------------------------------------------------------------

        private void ReallyUpdatePreview(string cronExpression)
        {
            Quartz.CronExpression CronExpression = new Quartz.CronExpression(cronExpression);

            DateTime StartTime = EventNextOccurrence.Value;

            // Stub in the starting value
            SchedulePreview.Text = Timekeeper.DateForDisplay(EventNextOccurrence.Value) + "\n";

            // Then loop through more (perhaps all) subsequently scheduled timers
            DateTimeOffset CurrentEvent = new DateTimeOffset(StartTime);
            for (int i = 0; i < PreviewCount.Value; i++) {
                DateTimeOffset? NextEvent = CronExpression.GetNextValidTimeAfter(CurrentEvent);
                SchedulePreview.Text += Timekeeper.NullableDateForDisplay(NextEvent) + "\n";
                CurrentEvent = (DateTimeOffset)NextEvent;
            }

            // Note: this is just for display purposes. We still have to ensure that this
            // will actually happen. Nothing in here reflects the reality of the schedule
            // once created and instantiated. (It should, of course, but it isn't guaranteed.
            // Other parts of the code are responsible for that.)
        }

        private void Alert(string message)
        {
            WarningIcon.Visible = true;
            WarningLabel.Visible = true;
            WarningLabel.Text = message;
        }

        private void Alert()
        {
            WarningIcon.Visible = false;
            WarningLabel.Visible = false;
            WarningLabel.Text = "";
        }

        private void ScheduleTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ScheduleTabControl.SelectedIndex == 2) {
                // Automatically update schedule when PreviewTab gets focus
                // FIXME: right event for this? Maybe zero in on the PreviewTab itself...?
                CrontabTesterButton_Click(sender, e);
            }
        }

        private void CrontabExpressionValue_Leave(object sender, EventArgs e)
        {
            try {
                ITrigger CronTrigger = CurrentSchedule.CronTrigger(
                    "Preview Trigger",
                    EventNextOccurrence.Value,
                    CrontabExpressionValue.Text,
                    "Cronly");
                Alert();
            }
            catch (Exception x) {
                Alert(x.Message);
            }
        }

        private void EventNextOccurrence_ValueChanged(object sender, EventArgs e)
        {
            // Keep these in sync
            this.ExternalEventNextOccurrence = EventNextOccurrence.Value;
        }

        //----------------------------------------------------------------------
    }

}
