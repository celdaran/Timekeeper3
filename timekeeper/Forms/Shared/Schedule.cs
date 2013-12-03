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

        private Classes.Options Options;
        private Classes.Widgets Widgets;
        private Classes.Schedule CurrentSchedule;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Schedule()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Event_Load(object sender, EventArgs e)
        {
            this.Widgets = new Classes.Widgets();
            this.Options = Timekeeper.Options;
            this.CurrentSchedule = new Classes.Schedule(1);

            ScheduleTabControl.TabPages.RemoveByKey("HiddenTab");
            ThenLabel.Visible = false;
            TargetPanel.Visible = false;

            PopulateForm(sender, e);

            // FIXME: FOR TESTING
            RecurCronRadioButton.Checked = true;
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

        private void PopulateForm(object sender, EventArgs e)
        {
            try {
                // Schedule Tab
                if (CurrentSchedule.RefScheduleTypeId == 1)
                    RecurNoneRadioButton.Checked = true;
                if (CurrentSchedule.RefScheduleTypeId == 2)
                    RecurFixedRadioButton.Checked = true;
                if (CurrentSchedule.RefScheduleTypeId == 3)
                    RecurDailyRadioButton.Checked = true;
                if (CurrentSchedule.RefScheduleTypeId == 4)
                    RecurWeeklyRadioButton.Checked = true;
                if (CurrentSchedule.RefScheduleTypeId == 5)
                    RecurMonthlyRadioButton.Checked = true;
                if (CurrentSchedule.RefScheduleTypeId == 6)
                    RecurYearlyRadioButton.Checked = true;
                if (CurrentSchedule.RefScheduleTypeId == 7)
                    RecurCronRadioButton.Checked = true;

                EventNextOccurrence.CustomFormat = Options.Advanced_DateTimeFormat;
                OnceUnitList.SelectedIndex = 2;
                DailyEveryDayRadioButton_CheckedChanged(sender, e);
                MonthlyDateRadioButton_CheckedChanged(sender, e);
                MonthlyOrdinalWeekList.SelectedIndex = 0;
                MonthlyDayOfWeekList.SelectedIndex = 0;
                YearlyOrdinalWeekList.SelectedIndex = 0;
                YearlyDayOfWeekList.SelectedIndex = 0;
                YearlyMonthList.SelectedIndex = 0;
                MonthlyDateRadioButton_CheckedChanged(sender, e);
                YearlyDateRadioButton_CheckedChanged(sender, e);

                // Duration Tab
                StopAfterTimeValue.CustomFormat = Options.Advanced_DateTimeFormat;
                EnableDurationTab(false);
                RunIndefinitelyButton.Checked = true;
                RunIndefinitelyButton_CheckedChanged(sender, e);
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
            if ((CrontabDayOfMonth.Text == "?") && (CrontabDayOfWeek.Text == "?")) {
                Common.Warn("Day of Month and Day of Week cannot both be ?");
            }

            if ((CrontabDayOfMonth.Text == "*") && (CrontabDayOfWeek.Text == "*")) {
                Common.Warn("Day of Month and Day of Week cannot both be *");
            }

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
                Common.Warn(x.ToString());
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void UpdatePreview()
        {
            if (RecurNoneRadioButton.Checked)
                Common.Info("No schedule needed");

            if (RecurFixedRadioButton.Checked) {

                int Interval = (int)OnceAmountValue.Value;

                switch (OnceUnitList.SelectedIndex) {
                    case 0: // Seconds
                        UpdatePreviewFixed(Interval);
                        break;
                    case 1: // Minutes
                        UpdatePreviewFixed(Interval * 60);
                        break;
                    case 2: // Hours
                        UpdatePreviewFixed(Interval * 60 * 60);
                        break;
                    case 3: // Days
                        UpdatePreviewFixed(Interval * 60 * 60 * 24);
                        break;
                    case 4: // Weeks
                        UpdatePreviewFixed(Interval * 60 * 60 * 24 * 7);
                        break;
                    case 5: // Months
                        UpdatePreviewFixedMonthly(Interval);
                        break;
                    case 6: // Quarters
                        UpdatePreviewFixedMonthly(Interval * 3);
                        break;
                    case 7: // Years
                        UpdatePreviewFixedMonthly(Interval * 12);
                        break;
                }
            }

            if (RecurDailyRadioButton.Checked) {

                if (DailyEveryDayRadioButton.Checked) {
                    UpdatePreviewFixed(60 * 60 * 24);
                }

                if (DailyEveryWeekdayRadioButton.Checked) {
                    DateTime StartTime = EventNextOccurrence.Value;
                    string CronExpressionString =
                        String.Format("{0} {1} {2} ? * MON,TUE,WED,THU,FRI *", StartTime.Second, StartTime.Minute, StartTime.Hour);
                    UpdatePreviewCron(CronExpressionString);
                }

                if (DailyIntervalRadioButton.Checked) {
                    int Interval = (int)DailyIntervalCountValue.Value;
                    UpdatePreviewFixed(Interval * 60 * 60 * 24);
                }
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

                DateTime StartTime = EventNextOccurrence.Value;
                string CronExpressionString =
                    String.Format("{0} {1} {2} ? * {3} *", 
                        StartTime.Second, 
                        StartTime.Minute, 
                        StartTime.Hour, 
                        string.Join(",", Weekdays.ToArray()));
                UpdatePreviewCron(CronExpressionString);

                // FIXME: Currently no support for WeeklyIntervalCountValue.
                // I think we'll have to just let it fire once a week, but
                // then silently drop triggers according to the interval
                // schedule. That, or we drop support for it completely.

            }

            if (RecurMonthlyRadioButton.Checked) {

                if (MonthlyDateRadioButton.Checked) {
                    // 0 0 12 7 1/3 ? *
                    DateTime StartTime = EventNextOccurrence.Value;
                    string CronExpressionString =
                        String.Format("{0} {1} {2} {3} 1/{4} ? *",
                            StartTime.Second,
                            StartTime.Minute,
                            StartTime.Hour,
                            MonthlyDateValue.Value,
                            MonthlyIntervalCountValue.Value);
                    UpdatePreviewCron(CronExpressionString);
                }

                if (MonthlyDayRadioButton.Checked) {

                    // Day of week
                    string DayOfWeek = "";
                    switch (MonthlyDayOfWeekList.SelectedIndex) {
                        case 0: DayOfWeek = "MON"; break;
                        case 1: DayOfWeek = "TUE"; break;
                        case 2: DayOfWeek = "WED"; break;
                        case 3: DayOfWeek = "THU"; break;
                        case 4: DayOfWeek = "FRI"; break;
                        case 5: DayOfWeek = "SAT"; break;
                        case 6: DayOfWeek = "SUN"; break;
                    }

                    // Ordinal week
                    string WeekOfMonth = "";
                    switch (MonthlyOrdinalWeekList.SelectedIndex) {
                        case 0: WeekOfMonth = "#1"; break;
                        case 1: WeekOfMonth = "#2"; break;
                        case 2: WeekOfMonth = "#3"; break;
                        case 3: WeekOfMonth = "#4"; break;
                        case 4: WeekOfMonth = "L"; break;
                    }

                    // 0 0 12 ? 1/1 TUE#2 *

                    DateTime StartTime = EventNextOccurrence.Value;
                    string CronExpressionString =
                        String.Format("{0} {1} {2} ? 1/{3} {4}{5} *",
                            StartTime.Second,
                            StartTime.Minute,
                            StartTime.Hour,
                            MonthlyIntervalCountValue.Value,
                            DayOfWeek,
                            WeekOfMonth);
                    UpdatePreviewCron(CronExpressionString);
                }
            }

            if (RecurYearlyRadioButton.Checked) {

                // YearlyDateValue

                if (YearlyDateRadioButton.Checked) {
                    // 0 0 12 14 3 ? *
                    DateTime StartTime = EventNextOccurrence.Value;
                    string CronExpressionString =
                        String.Format("{0} {1} {2} {3} {4} ? *",
                            StartTime.Second,
                            StartTime.Minute,
                            StartTime.Hour,
                            YearlyDateValue.Value,
                            YearlyMonthList.SelectedIndex + 1);
                    UpdatePreviewCron(CronExpressionString);
                }

                if (YearlyDayRadioButton.Checked) {

                    // Day of week
                    string DayOfWeek = "";
                    switch (YearlyDayOfWeekList.SelectedIndex) {
                        case 0: DayOfWeek = "MON"; break;
                        case 1: DayOfWeek = "TUE"; break;
                        case 2: DayOfWeek = "WED"; break;
                        case 3: DayOfWeek = "THU"; break;
                        case 4: DayOfWeek = "FRI"; break;
                        case 5: DayOfWeek = "SAT"; break;
                        case 6: DayOfWeek = "SUN"; break;
                    }

                    // Ordinal week
                    string WeekOfMonth = "";
                    switch (YearlyOrdinalWeekList.SelectedIndex) {
                        case 0: WeekOfMonth = "#1"; break;
                        case 1: WeekOfMonth = "#2"; break;
                        case 2: WeekOfMonth = "#3"; break;
                        case 3: WeekOfMonth = "#4"; break;
                        case 4: WeekOfMonth = "L"; break;
                    }

                    // 0 0 12 ? 5 WED#2 *

                    DateTime StartTime = EventNextOccurrence.Value;
                    string CronExpressionString =
                        String.Format("{0} {1} {2} ? {3} {4}{5} *",
                            StartTime.Second,
                            StartTime.Minute,
                            StartTime.Hour,
                            YearlyMonthList.SelectedIndex + 1,
                            DayOfWeek,
                            WeekOfMonth);
                    UpdatePreviewCron(CronExpressionString);
                }

            }

            if (RecurCronRadioButton.Checked)
                ReallyUpdatePreview(CrontabExpressionValue.Text);
        }

        //----------------------------------------------------------------------

        private void UpdatePreviewFixed(int count)
        {
            ITrigger PreviewTrigger = TriggerBuilder.Create()
                .WithIdentity("Preview Trigger")
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(count).RepeatForever())
                .StartAt(EventNextOccurrence.Value)
                .Build();
            UpdatePreviewWindow(PreviewTrigger);
        }

        //----------------------------------------------------------------------

        private void UpdatePreviewFixedMonthly(int count)
        {
            ITrigger PreviewTrigger = TriggerBuilder.Create()
                .WithIdentity("Preview Trigger")
                .WithCalendarIntervalSchedule(x => x.WithIntervalInMonths(count))
                .StartAt(EventNextOccurrence.Value)
                .Build();
            UpdatePreviewWindow(PreviewTrigger);
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
            // Find first one
            DateTimeOffset? EventStartTime = trigger.StartTimeUtc;
            SchedulePreview.Text = EventStartTime.Value.ToString(Common.LOCAL_DATETIME_FORMAT) + "\n";

            // Then loop through more (perhaps all) subsequently scheduled timers
            DateTimeOffset CurrentEvent = (DateTimeOffset)EventStartTime;
            for (int i = 0; i < PreviewCount.Value; i++) {
                DateTimeOffset? NextEvent = trigger.GetFireTimeAfter(CurrentEvent);
                SchedulePreview.Text += NextEvent.Value.LocalDateTime.ToString(Common.LOCAL_DATETIME_FORMAT) + "\n";
                CurrentEvent = (DateTimeOffset)NextEvent;
            }
        }

        //----------------------------------------------------------------------

        private void ReallyUpdatePreview(string cronExpression)
        {
            Quartz.CronExpression CronExpression = new Quartz.CronExpression(cronExpression);

            DateTime StartTime = EventNextOccurrence.Value;

            // Stub in the starting value
            SchedulePreview.Text = EventNextOccurrence.Value.ToString(Common.LOCAL_DATETIME_FORMAT) + "\n";

            // Then loop through more (perhaps all) subsequently scheduled timers
            DateTimeOffset CurrentEvent = new DateTimeOffset(StartTime);
            for (int i = 0; i < PreviewCount.Value; i++) {
                DateTimeOffset? NextEvent = CronExpression.GetNextValidTimeAfter(CurrentEvent);
                SchedulePreview.Text += NextEvent.Value.LocalDateTime.ToString(Common.LOCAL_DATETIME_FORMAT) + "\n";
                CurrentEvent = (DateTimeOffset)NextEvent;
            }

            // Note: this is just for display purposes. We still have to ensure that this
            // will actually happen. Nothing in here reflects the reality of the schedule
            // once created and instantiated. (It should, of course, but it isn't guaranteed.
            // Other parts of the code are responsible for that.)
        }

        //----------------------------------------------------------------------
    }

}
