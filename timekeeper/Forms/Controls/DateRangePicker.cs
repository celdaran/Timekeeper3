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
            Timekeeper.Warn("This version of SetDateRange should no longer be used");
        }

        private void DateRangePicker_Load(object sender, EventArgs e)
        {
            Classes.ReferenceData SystemData = new Classes.ReferenceData();
            List<IdValuePair> PresetValues = SystemData.DatePreset();
            foreach (IdValuePair Preset in PresetValues) {
                Presets.Items.Add(Preset);
            }
        }

    }
}
