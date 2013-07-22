using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms.Controls
{
    public partial class DateRangePicker : UserControl
    {
        public DateRangePicker()
        {
            InitializeComponent();
        }

        private void Presets_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDateRange();
        }

        public void SetDateRange()
        {
            DateTime Now = DateTime.Now;
            Classes.Journal Entry;

            switch (Presets.Text) {
                case "Today":
                    FromDate.Value = Now;
                    ToDate.Value = Now;
                    break;

                case "Yesterday":
                    FromDate.Value = Now.Subtract(new TimeSpan(24, 0, 0));
                    ToDate.Value = FromDate.Value;
                    break;

                case "Previous Day":
                    Entry = new Classes.Journal(Timekeeper.Database);
                    FromDate.Value = Entry.PreviousDay();
                    ToDate.Value = FromDate.Value;
                    break;

                case "This Week":
                    int diff = Now.DayOfWeek - DayOfWeek.Monday;
                    FromDate.Value = Now.Subtract(new TimeSpan(diff * 24, 0, 0));
                    ToDate.Value = Now;
                    break;

                case "This Month":
                    FromDate.Value = DateTime.Parse(Now.Year.ToString() + "/" + Now.Month.ToString() + "/1");
                    ToDate.Value = Now;
                    break;

                case "Last Month":
                    int year = Now.Year;
                    int month = Now.Month;
                    if (Now.Month == 1) {
                        year--;
                        month = 12;
                    } else {
                        month--;
                    }
                    FromDate.Value = DateTime.Parse(year.ToString() + "/" + month.ToString() + "/1");
                    ToDate.Value = DateTime.Parse(year.ToString() + "/" + month.ToString() + "/" + DateTime.DaysInMonth(year, month).ToString());
                    break;

                case "This Year":
                    FromDate.Value = DateTime.Parse(Now.Year.ToString() + "/01/01");
                    ToDate.Value = Now;
                    break;

                case "Last Year":
                    year = Now.Year;
                    year--;
                    FromDate.Value = DateTime.Parse(year.ToString() + "/01/01");
                    ToDate.Value = DateTime.Parse(year.ToString() + "/12/31");
                    break;

                case "All":
                    Entry = new Classes.Journal(Timekeeper.Database);
                    FromDate.Value = Entry.FirstDay();
                    ToDate.Value = Entry.LastDay();
                    break;

                case "Custom":
                    // do nothing
                    break;
            }
        }

        private void DateRangePicker_Load(object sender, EventArgs e)
        {
            Classes.SystemData SystemData = new Classes.SystemData();
            List<IdValuePair> PresetValues = SystemData.DatePreset();
            foreach (IdValuePair Preset in PresetValues) {
                Presets.Items.Add(Preset);
            }
        }

    }
}
