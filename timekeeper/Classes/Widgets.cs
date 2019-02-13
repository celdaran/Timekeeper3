using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Classes
{
    partial class Widgets
    {
        //----------------------------------------------------------------------
        // UI Helper Class
        //----------------------------------------------------------------------

        private DBI Database;
        private Classes.Options Options;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Widgets() {
            this.Database = Timekeeper.Database;
            this.Options = Timekeeper.Options;
        }

        //----------------------------------------------------------------------

        public void PopulateGenericComboBox(ComboBox box, List<IdObjectPair> items)
        {
            foreach (IdObjectPair Pair in items) {
                box.Items.Add(Pair);
            }
        }

        //----------------------------------------------------------------------
        // Experimental

        public void PopulateGenericComboBox(ComboBox box, Table table)
        {
            try {
                foreach (Row Row in table) {
                    IdObjectPair Pair = new IdObjectPair((int)Row["Id"], Row["Name"]);
                    box.Items.Add(Pair);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void PopulateTimeZoneComboBox(ComboBox box)
        {
            try {
                ReadOnlyCollection<TimeZoneInfo> TimeZones = TimeZoneInfo.GetSystemTimeZones();

                TimeZone CurrentTimeZone = TimeZone.CurrentTimeZone;
                int CurrentIndex = 0;

                foreach (TimeZoneInfo timeZone in TimeZones) {

                    IdObjectPair Pair = new IdObjectPair(CurrentIndex + 1, timeZone);

                    box.Items.Add(Pair);
                    if (CurrentTimeZone.StandardName == timeZone.StandardName) {
                        box.SelectedIndex = CurrentIndex;
                    }
                    CurrentIndex++;
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        public void SelectCurrentTimeZone(ComboBox box)
        {
            TimeZone CurrentTimeZone = TimeZone.CurrentTimeZone;
            TimeZoneInfo CurrentTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById(CurrentTimeZone.StandardName);
            int Index = box.FindString(CurrentTimeZoneInfo.DisplayName);
            box.SelectedIndex = Index;
        }


        //----------------------------------------------------------------------

        public Forms.Properties GetPropertiesDialog(Classes.TreeAttribute item)
        {
            Forms.Properties Dialog = new Forms.Properties();

            // Set date range for time calculations
            string From = Timekeeper.LocalNow.ToString(Common.DATE_FORMAT + " 00:00:00");
            string To = Timekeeper.LocalNow.AddDays(1).ToString(Common.DATE_FORMAT + " 00:00:00");

            // Determine the item type
            string ItemType = item.Dimension.ToString();
            if (item.IsFolder) ItemType += " Folder";

            // Set dialog box title
            Dialog.Text = ItemType + " Properties";

            // Set description
            string Description;
            if (item.Description.Length > 0) {
                Description = item.Description.Replace("\n", Environment.NewLine);
                Dialog.wDescription.Enabled = true;
            } else {
                Description = "None";
                Dialog.wDescription.Enabled = false;
            }

            // Now fill in all the values
            Dialog.wName.Text = Common.Abbreviate(item.Name, 42);
            Dialog.wDescription.Text = Description;
            Dialog.wType.Text = ItemType;
            Dialog.wID.Text = item.ItemId.ToString();
            Dialog.wGUID.Text = item.ItemGuid;

            Dialog.wCreated.Text = Timekeeper.DateForDisplay(item.CreateTime);
            Dialog.wModified.Text = Timekeeper.DateForDisplay(item.ModifyTime);
            Dialog.wTotalTime.Text = Timekeeper.FormatSeconds(item.RecursiveSecondsElapsed(item.ItemId, "1900-01-01", "2999-01-01"));
            Dialog.wTimeToday.Text = Timekeeper.FormatSeconds(item.RecursiveSecondsElapsed(item.ItemId, From, To));

            Dialog.wIsHidden.Checked = item.IsHidden;
            Dialog.wIsDeleted.Checked = item.IsDeleted;
            if (item.IsHidden)
                Dialog.wHiddenTime.Text = Timekeeper.NullableDateForDisplay(item.HiddenTime);
            if (item.IsDeleted)
                Dialog.wDeletedTime.Text = Timekeeper.NullableDateForDisplay(item.DeletedTime);
            Dialog.wExternalProjectNo.Text = item.ExternalProjectNo != null ? item.ExternalProjectNo : "n/a";

            return Dialog;
        }

        //----------------------------------------------------------------------

        public void SetMainFormDatePickerFormats(Forms.Main mainForm)
        {
            SetDatePickerFormat(mainForm.StartTimeSelector);
            SetDatePickerFormat(mainForm.StopTimeSelector);

            /*
            mainForm.StartTimeSelector.CustomFormat = Options.Advanced_DateTimeFormat;
            mainForm.StopTimeSelector.CustomFormat = Options.Advanced_DateTimeFormat;

            // Adjust Start/Stop time widths and LocationAndCategoryPanel location
            mainForm.StartTimeSelector.Value = Timekeeper.LocalNow.DateTime;
            Size DateSize = TextRenderer.MeasureText(
                mainForm.StartTimeSelector.Value.ToString(Options.Advanced_DateTimeFormat),
                mainForm.StartTimeSelector.Font);
            int DateTimeWidth = DateSize.Width;
            int DropDownButtonWidth = 33;

            mainForm.StartTimeSelector.Width = DateTimeWidth + DropDownButtonWidth;
            mainForm.StopTimeSelector.Width = DateTimeWidth + DropDownButtonWidth;
            */

            mainForm.CloseStartGapButton.Left = Math.Max(mainForm.StartTimeSelector.Width + 73, 142);
            mainForm.CloseStopGapButton.Left = Math.Max(mainForm.StartTimeSelector.Width + 73, 142);

            // mainForm.DimensionPanel.Left = mainForm.CloseStartGapButton.Left + (SystemInformation.VerticalScrollBarWidth * 2 + 1);
        }

        //----------------------------------------------------------------------

        public void SetDatePickerFormat(DateTimePicker picker)
        {
            // First set the format
            picker.CustomFormat = Options.Advanced_DateTimeFormat;

            // Give it a dummy value: the control requires text to be measured
            picker.Value = Timekeeper.LocalNow.DateTime;

            // Now measure the text and the button width
            Size DateSize = TextRenderer.MeasureText(
                picker.Value.ToString(Options.Advanced_DateTimeFormat),
                picker.Font);
            int DateTimeWidth = DateSize.Width;
            int DropDownButtonWidth = (SystemInformation.VerticalScrollBarWidth * 2 + 1);

            // Set width
            picker.Width = DateTimeWidth + DropDownButtonWidth;
        }

        //----------------------------------------------------------------------

    }
}
