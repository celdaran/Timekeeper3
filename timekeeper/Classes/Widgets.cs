using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Technitivity.Toolbox;

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
                Description = Common.Abbreviate(item.Description, 42);
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

            Timekeeper.Warn("FIXME: Last Dimension Id issue in Properties dialog not properly handled");

            if (item.Dimension == Timekeeper.Dimension.Project) {
                if (item.LastActivityId > 0) {
                    Classes.Activity Activity = new Classes.Activity(item.LastActivityId);
                    Dialog.wLastItemName.Enabled = true;
                    Dialog.wLastItemName.Text = Activity.Name;
                    Dialog.wLastItemLabel.Text = "Last Activity:";
                } else {
                    Dialog.wLastItemName.Enabled = false;
                    Dialog.wLastItemName.Text = "None";
                }
                Dialog.wExternalProjectNo.Text = item.ExternalProjectNo;
                Dialog.wExternalProjectNoLabel.Visible = true;
                Dialog.wExternalProjectNo.Visible = true;
            } else {
                if (item.LastLocationId > 0) {
                    Classes.Project Project = new Classes.Project(item.LastLocationId);
                    Dialog.wLastItemLabel.Text = "Last Project:";
                    Dialog.wLastItemName.Enabled = true;
                    Dialog.wLastItemName.Text = Project.Name;
                } else {
                    Dialog.wLastItemName.Enabled = false;
                    Dialog.wLastItemName.Text = "None";
                }
                Dialog.wExternalProjectNoLabel.Visible = false;
                Dialog.wExternalProjectNo.Visible = false;
            }

            return Dialog;
        }

        //----------------------------------------------------------------------

    }
}
