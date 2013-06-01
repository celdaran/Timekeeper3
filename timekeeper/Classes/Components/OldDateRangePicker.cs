using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Classes.Components
{
    //---------------------------------------------------------------------
    // Component Test
    //---------------------------------------------------------------------

    class OldDateRangePicker : GroupBox
    {
        public Label PresetLabel;
        public Label FromDateLabel;
        public Label ToDateLabel;


        public ComboBox Presets;
        public DateTimePicker FromDate;
        public DateTimePicker ToDate;

        public OldDateRangePicker()
        {
            CreateWidgets();

            Classes.SystemData SystemData = new Classes.SystemData();
            List<IdValuePair> PresetValues = SystemData.DatePresets();
            foreach (IdValuePair Preset in PresetValues) {
                Presets.Items.Add(Preset);
            }

            this.Text = "Date Range";
            this.Name = "DatePickerGroupBox";
            this.Size = new System.Drawing.Size(226, 100);

            this.Controls.Add(PresetLabel);
            this.Controls.Add(FromDateLabel);
            this.Controls.Add(ToDateLabel);
            this.Controls.Add(Presets);
            this.Controls.Add(FromDate);
            this.Controls.Add(ToDate);
        }

        private void CreateWidgets()
        {
            // Create Widgets
            this.PresetLabel = new System.Windows.Forms.Label();
            this.FromDateLabel = new System.Windows.Forms.Label();
            this.ToDateLabel = new System.Windows.Forms.Label();
            this.Presets = new System.Windows.Forms.ComboBox();
            this.FromDate = new System.Windows.Forms.DateTimePicker();
            this.ToDate = new System.Windows.Forms.DateTimePicker();
            // 
            // PresetLabel
            // 
            this.PresetLabel.AutoSize = true;
            this.PresetLabel.Location = new System.Drawing.Point(18, 22);
            this.PresetLabel.Name = "PresetLabel";
            this.PresetLabel.Size = new System.Drawing.Size(40, 13);
            this.PresetLabel.TabIndex = 1;
            this.PresetLabel.Text = "Preset:";
            // 
            // FromDateLabel
            // 
            this.FromDateLabel.AutoSize = true;
            this.FromDateLabel.Location = new System.Drawing.Point(18, 46);
            this.FromDateLabel.Name = "FromDateLabel";
            this.FromDateLabel.Size = new System.Drawing.Size(59, 13);
            this.FromDateLabel.TabIndex = 2;
            this.FromDateLabel.Text = "From Date:";
            // 
            // ToDateLabel
            // 
            this.ToDateLabel.AutoSize = true;
            this.ToDateLabel.Location = new System.Drawing.Point(18, 72);
            this.ToDateLabel.Name = "ToDateLabel";
            this.ToDateLabel.Size = new System.Drawing.Size(49, 13);
            this.ToDateLabel.TabIndex = 3;
            this.ToDateLabel.Text = "To Date:";
            // 
            // Presets
            // 
            this.Presets.FormattingEnabled = true;
            this.Presets.Location = new System.Drawing.Point(88, 19);
            this.Presets.Name = "Presets";
            this.Presets.Size = new System.Drawing.Size(121, 21);
            this.Presets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Presets.SelectedIndexChanged += new System.EventHandler(this.Presets_SelectedIndexChanged);
            this.Presets.TabIndex = 4;
            // 
            // ToDate
            // 
            this.ToDate.CustomFormat = "yyyy-MM-dd";
            this.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.ToDate.Location = new System.Drawing.Point(88, 72);
            this.ToDate.Name = "ToDate";
            this.ToDate.Size = new System.Drawing.Size(121, 20);
            this.ToDate.TabIndex = 5;
            // 
            // FromDate
            // 
            this.FromDate.CustomFormat = "yyyy-MM-dd";
            this.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.FromDate.Location = new System.Drawing.Point(88, 46);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(121, 20);
            this.FromDate.TabIndex = 6;
        }

        private void Presets_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDateRange();
        }

        private void SetDateRange()
        {
            DateTime Now = DateTime.Now;
            Entry Entry;

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
                    Entry = new Entry(Timekeeper.Database);
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
                    Entry = new Entry(Timekeeper.Database);
                    FromDate.Value = Entry.FirstDay();
                    ToDate.Value = Entry.LastDay();
                    break;

                case "Custom":
                    // do nothing
                    break;
            }
        }

    }
}
