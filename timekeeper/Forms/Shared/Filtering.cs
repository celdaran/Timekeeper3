using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Shared
{

    // TODO: This (class/file) is still a bit of a mess. Please come back and clean up.

    public partial class Filtering : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private Classes.Options Options;
        private Classes.Widgets Widgets;

        //---------------------------------------------------------------------
        // Auto-Implemented Properties
        //---------------------------------------------------------------------

        public Classes.FilterOptions FilterOptions { get; set; }

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Filtering() : this(null) {}

        //---------------------------------------------------------------------

        public Filtering(Classes.FilterOptions filterOptions)
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;

            if (filterOptions == null) {
                FilterOptions = new Classes.FilterOptions();
            } else {
                FilterOptions = filterOptions;
            }

            // FIXME: load window metrics

            // FIXME: find a place for this
            Classes.ReferenceData Ref = new Classes.ReferenceData();
            List<IdValuePair> PresetValues = Ref.DatePreset();
            foreach (IdValuePair Preset in PresetValues) {
                Presets.Items.Add(Preset);
                if (Preset.Id != Classes.FilterOptions.DATE_PRESET_CUSTOM) {
                    CreateTimePresets.Items.Add(Preset);
                    ModifyTimePresets.Items.Add(Preset);
                }
            }

            // Hack?
            LoadForm();
        }

        //---------------------------------------------------------------------
        // Event Handlers
        //---------------------------------------------------------------------

        private void Filtering_Load(object sender, EventArgs e)
        {
            ProjectTree.ExpandAll();
            ActivityTree.ExpandAll();
        }

        //----------------------------------------------------------------------

        private void LoadForm()
        {
            this.Widgets = new Classes.Widgets();

            //----------------------------------------
            // Populate Location & Category filters
            //----------------------------------------

            PopulateStuff();

            //----------------------------------------
            // Set Visibility
            //----------------------------------------

            // FIXME: Options should have both a DATE and a DATETIME format
            /*
            FromDate.CustomFormat = this.Options.Advanced_DateTimeFormat;
            ToDate.CustomFormat = this.Options.Advanced_DateTimeFormat;
            */

            DurationLabel.Visible = (this.FilterOptions.FilterOptionsType != Classes.FilterOptions.OptionsType.Notebook);
            DurationAmount.Visible = (this.FilterOptions.FilterOptionsType != Classes.FilterOptions.OptionsType.Notebook);
            DurationOperator.Visible = (this.FilterOptions.FilterOptionsType != Classes.FilterOptions.OptionsType.Notebook);
            DurationUnit.Visible = (this.FilterOptions.FilterOptionsType != Classes.FilterOptions.OptionsType.Notebook);

            if ((!Options.Layout_UseProjects) || 
                (this.FilterOptions.FilterOptionsType == Classes.FilterOptions.OptionsType.Notebook) ||
                (this.FilterOptions.FilterMergeType == Timekeeper.Dimension.Project)) {
                FilterOptionsTabControl.TabPages.RemoveByKey("ProjectTab");
            }

            if ((!Options.Layout_UseActivities) || 
                (this.FilterOptions.FilterOptionsType == Classes.FilterOptions.OptionsType.Notebook) ||
                (this.FilterOptions.FilterMergeType == Timekeeper.Dimension.Activity)) {
                FilterOptionsTabControl.TabPages.RemoveByKey("ActivityTab");
            }

            if ((!Options.Layout_UseLocations) ||
                (this.FilterOptions.FilterMergeType == Timekeeper.Dimension.Location)) {
                FilterOptionsTabControl.TabPages.RemoveByKey("LocationTab");
            }

            if ((!Options.Layout_UseCategories) ||
                (this.FilterOptions.FilterMergeType == Timekeeper.Dimension.Category)) {
                FilterOptionsTabControl.TabPages.RemoveByKey("CategoryTab");
            }

            if (this.FilterOptions.FilterOptionsType != Classes.FilterOptions.OptionsType.Journal) {
                // problem: this isn't 'Advanced'
                // I probably should have OptionsType-specific tabs and move 
                // 'not advanced' (e.g., duration checks) to the main tab
                FilterOptionsTabControl.TabPages.RemoveByKey("AdvancedTab");
            }

            //----------------------------------------
            // Load up existing options
            //----------------------------------------

            if (FilterOptions.DateRangePreset != Classes.FilterOptions.DATE_PRESET_NONE) {
                Presets.SelectedIndex = FilterOptions.DateRangePreset - 1;
                SetDateRange();
            } else {
                Timekeeper.Warn("DateRangePreset = DATE_PRESET_NONE");
            }

            if (FilterOptions.MemoOperator != -1) {
                MemoOperator.SelectedIndex = FilterOptions.MemoOperator;
                ChangeMemoValue();
            }

            if (FilterOptions.MemoValue != null) {
                MemoValue.Text = FilterOptions.MemoValue;
            }

            if (FilterOptions.DurationOperator != -1) {
                DurationOperator.SelectedIndex = FilterOptions.DurationOperator;
                ChangeDuration();
            }

            if (FilterOptions.DurationAmount != 0) {
                DurationAmount.Value = FilterOptions.DurationAmount;
            }

            if (FilterOptions.DurationUnit != -1) {
                DurationUnit.SelectedIndex = FilterOptions.DurationUnit;
            }

            if (FilterOptions.Projects != null) {
                SetSelectedValues(ProjectTree.Nodes, FilterOptions.Projects);
            }

            if (FilterOptions.Activities != null) {
                SetSelectedValues(ActivityTree.Nodes, FilterOptions.Activities);
            }

            if (FilterOptions.Locations != null) {
                SetSelectedValues(LocationTree.Nodes, FilterOptions.Locations);
            }

            if (FilterOptions.Categories != null) {
                SetSelectedValues(CategoryTree.Nodes, FilterOptions.Categories);
            }

            // With the above four set, populate self with selections
            FilterOptions.Activities = GetActuallySelectedValues(ActivityTree.Nodes);
            FilterOptions.Projects = GetActuallySelectedValues(ProjectTree.Nodes);
            FilterOptions.Locations = GetActuallySelectedValues(LocationTree.Nodes);
            FilterOptions.Categories = GetActuallySelectedValues(CategoryTree.Nodes);
            FilterOptions.ImpliedActivities = GetImpliedSelectedValues(ActivityTree.Nodes, false);
            FilterOptions.ImpliedProjects = GetImpliedSelectedValues(ProjectTree.Nodes, false);
            // End populate self

        }

        //----------------------------------------------------------------------

        private void PopulateStuff()
        {
            ProjectTree.Nodes.Clear();
            ActivityTree.Nodes.Clear();
            LocationTree.Nodes.Clear();
            CategoryTree.Nodes.Clear();

            Widgets.BuildProjectTree(ProjectTree.Nodes);
            Widgets.BuildActivityTree(ActivityTree.Nodes);
            Widgets.BuildLocationTree(LocationTree.Nodes);
            Widgets.BuildCategoryTree(CategoryTree.Nodes);
        }

        //----------------------------------------------------------------------

        private void Filtering_FormClosing(object sender, FormClosingEventArgs e)
        {
            // FIXME
            if (ToDate.Value.Date < FromDate.Value.Date) {
                //Common.Warn("Invalid date selection");
                //e.Cancel = true;
            }
        }

        //---------------------------------------------------------------------

        private void MenuSelectAll_Click(object sender, EventArgs e)
        {
            TreeView Tree = GetTreeView(sender);
            Select(Tree.Nodes, 1);
        }

        //---------------------------------------------------------------------

        private void MenuSelectNone_Click(object sender, EventArgs e)
        {
            TreeView Tree = GetTreeView(sender);
            Select(Tree.Nodes, 0);
        }

        //---------------------------------------------------------------------

        private void MenuInvertSelection_Click(object sender, EventArgs e)
        {
            TreeView Tree = GetTreeView(sender);
            Select(Tree.Nodes, -1);
        }

        //---------------------------------------------------------------------

        private void MemoOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeMemoValue();
        }

        //---------------------------------------------------------------------

        private void DurationOperator_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeDuration();
        }

        //---------------------------------------------------------------------
        // TODO: Are these next two necessary?
        //---------------------------------------------------------------------

        private void ChangeMemoValue()
        {
            // -1 : not selected
            //  0 : any
            //  1 : contains
            //  2 : does not contain
            //  3 : begins with
            //  4 : ends with
            //  5 : empty
            //  6 : not empty
            if ((MemoOperator.SelectedIndex >= 1) && (MemoOperator.SelectedIndex <= 4)) {
                MemoValue.Enabled = true;
            } else {
                MemoValue.Enabled = false;
            }
        }

        //---------------------------------------------------------------------

        private void ChangeDuration()
        {
            if (DurationOperator.SelectedIndex == 0) {
                DurationAmount.Enabled = false;
                DurationUnit.Enabled = false;
            } else {
                DurationAmount.Enabled = true;
                DurationUnit.Enabled = true;
            }
        }

        //---------------------------------------------------------------------
        /*

        private void SortBy1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SortBy1.SelectedIndex == 0) {
                SortBy2.Enabled = false;
                SortBy3.Enabled = false;
            } else {
                SortBy2.Enabled = true;
                if (SortBy2.SelectedIndex == -1)
                    SortBy2.SelectedIndex = 0;
            }
        }

        //---------------------------------------------------------------------

        private void SortBy2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SortBy2.SelectedIndex == 0) {
                SortBy3.Enabled = false;
            } else {
                SortBy3.Enabled = true;
                if (SortBy3.SelectedIndex == -1)
                    SortBy3.SelectedIndex = 0;
            }
        }
        */

        //---------------------------------------------------------------------

        private void OkayButton_Click(object sender, EventArgs e)
        {
            FilterOptions.DateRangePreset = Presets.SelectedIndex + 1;
            FilterOptions.FromTime = FromDate.Value.Date;
            FilterOptions.ToTime = ToDate.Value.Date;
            FilterOptions.MemoOperator = MemoOperator.SelectedIndex;
            FilterOptions.MemoValue = MemoValue.Text;
            FilterOptions.DurationOperator = DurationOperator.SelectedIndex;
            FilterOptions.DurationAmount = (int)DurationAmount.Value;
            FilterOptions.DurationUnit = DurationUnit.SelectedIndex;
            FilterOptions.Activities = GetActuallySelectedValues(ActivityTree.Nodes);
            FilterOptions.Projects = GetActuallySelectedValues(ProjectTree.Nodes);
            FilterOptions.Locations = GetActuallySelectedValues(LocationTree.Nodes);
            FilterOptions.Categories = GetActuallySelectedValues(CategoryTree.Nodes);
            FilterOptions.ImpliedActivities = GetImpliedSelectedValues(ActivityTree.Nodes, false);
            FilterOptions.ImpliedProjects = GetImpliedSelectedValues(ProjectTree.Nodes, false);

            DialogResult = DialogResult.OK;
        }

        //---------------------------------------------------------------------

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //---------------------------------------------------------------------

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // TODO: need a better way to convert constants to combobox values
            Presets.SelectedIndex = Classes.FilterOptions.DATE_PRESET_ALL - 1;
            MemoOperator.SelectedIndex = -1;
            MemoValue.Text = "";

            PopulateStuff();

            DurationOperator.SelectedIndex = -1;
            DurationAmount.Value = 0;
            DurationUnit.SelectedIndex = 0;

            CreateTimePresets.SelectedIndex = -1;
            ModifyTimePresets.SelectedIndex = -1;
        }

        //---------------------------------------------------------------------
        // Private Helpers
        //----------------------------------------------------------------------

        public List<long> GetImpliedSelectedValues(TreeNodeCollection nodes, bool ancestorChecked)
        {
            List<long> CheckedNodes = new List<long>();

            foreach (TreeNode Node in nodes) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)Node.Tag;
                if (!Item.IsFolder && (Node.Checked || ancestorChecked)) {
                    CheckedNodes.Add(Item.ItemId);
                }

                if (Node.Nodes.Count > 0) {
                    // If this node has children, get the checked kids
                    List<long> CheckedChildren = new List<long>();

                    bool AncestorChecked = false;

                    if ((Node.Checked) || (Item.IsFolder && ancestorChecked)) {
                        AncestorChecked = true;
                    }

                    CheckedChildren = GetImpliedSelectedValues(Node.Nodes, AncestorChecked);
                    // And add to the main list
                    CheckedNodes.AddRange(CheckedChildren);
                }
            }

            return CheckedNodes;
        }

        //---------------------------------------------------------------------

        private List<long> GetActuallySelectedValues(TreeNodeCollection nodes)
        {
            List<long> CheckedNodes = new List<long>();

            foreach (TreeNode Node in nodes) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)Node.Tag;
                if (Node.Checked) {
                    CheckedNodes.Add(Item.ItemId);
                }

                if (Node.Nodes.Count > 0) {
                    // If this node has children, get the checked kids
                    List<long> CheckedChildren = new List<long>();
                    CheckedChildren = GetActuallySelectedValues(Node.Nodes);
                    // And add to the main list
                    CheckedNodes.AddRange(CheckedChildren);
                }
            }

            return CheckedNodes;
        }

        //---------------------------------------------------------------------

        private void SetSelectedValues(TreeNodeCollection nodes, List<long> checkedNodes)
        {
            foreach (TreeNode Node in nodes) {
                Classes.TreeAttribute Item = (Classes.TreeAttribute)Node.Tag;

                if (checkedNodes.IndexOf(Item.ItemId) >= 0) {
                    Node.Checked = true;
                }

                if (Node.Nodes.Count > 0) {
                    SetSelectedValues(Node.Nodes, checkedNodes);
                }
            }
        }

        //---------------------------------------------------------------------

        private void Select(TreeNodeCollection Nodes, int state)
        {
            foreach (TreeNode Node in Nodes) {
                if (state == 0) {
                    Node.Checked = false;
                } else if (state == 1) {
                    Node.Checked = true;
                } else if (state == -1) {
                    Node.Checked = !Node.Checked;
                }

                if (Node.Nodes.Count > 0) {
                    Select(Node.Nodes, state);
                }
            }
        }

        //---------------------------------------------------------------------

        private TreeView GetTreeView(object sender)
        {
            TreeView Result = null;

            ToolStripItem MenuItem = sender as ToolStripItem;
            if (MenuItem != null) {
                ContextMenuStrip Owner = MenuItem.Owner as ContextMenuStrip;
                if (Owner != null) {
                    Result = Owner.SourceControl as TreeView;
                }
            }

            return Result;
        }

        //----------------------------------------------------------------------

        public void SetDateRange()
        {
            FilterOptions.DateRangePreset = Presets.SelectedIndex + 1;
            if (FilterOptions.DateRangePreset != Classes.FilterOptions.DATE_PRESET_CUSTOM) {
                // If custom, don't whomp our From/To dates based on Preset
                FilterOptions.SetDateRange();
            }
            if (ChangeDateRange) {
                FromDate.Value = FilterOptions.FromTime.Value.Date;
                ToDate.Value = FilterOptions.ToTime.Value.Date;
            }
        }

        private void Presets_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDateRange();
        }

        private void FilterOptionsTabControl_Selected(object sender, TabControlEventArgs e)
        {
            // Let's do the Project & Activity loading here (more "on demand");

            if (e.TabPage.Name == "ProjectTab") {
                // If we switched to this tab and the current number
                // of nodes is zero, populate it.
                if (ProjectTree.Nodes.Count == 0) {
                }
            } else if (e.TabPage.Name == "ActivityTab") {
                if (ActivityTree.Nodes.Count == 0) {
                }
            }

        }

        private DateTime PreviousFromDate;
        private DateTime PreviousToDate;
        private Boolean ChangeDateRange = true;

        private void FromDate_Enter(object sender, EventArgs e)
        {
            PreviousFromDate = FromDate.Value.Date;
        }

        private void FromDate_Leave(object sender, EventArgs e)
        {
            if (PreviousFromDate != FromDate.Value.Date) {
                ChangeDateRange = false;
                Presets.SelectedIndex = Classes.FilterOptions.DATE_PRESET_CUSTOM - 1;
                ChangeDateRange = true;
            }
        }

        private void ToDate_Enter(object sender, EventArgs e)
        {
            PreviousToDate = ToDate.Value;
        }

        private void ToDate_Leave(object sender, EventArgs e)
        {
            if (PreviousToDate != ToDate.Value) {
                ChangeDateRange = false;
                Presets.SelectedIndex = Classes.FilterOptions.DATE_PRESET_CUSTOM - 1;
                ChangeDateRange = true;
            }
        }

        // Date Picker Popup Menus
        // FIXME: Code stolen from Main.cs
        // Also, SetTimeToMidnight not needed here. Look to Events and Todo items.

        private void Action_CopyDate(DateTimePicker picker)
        {
            Clipboard.SetData(DataFormats.StringFormat, picker.Value.ToString(Options.Advanced_DateTimeFormat));
        }

        private void Action_PasteDate(DateTimePicker picker)
        {
            string ClipboardTime = (string)Clipboard.GetData(DataFormats.StringFormat);
            try {
                picker.Value = Convert.ToDateTime(ClipboardTime);
            }
            catch {
                Timekeeper.Debug("Invalid date/time format: " + ClipboardTime);
            }
        }

        private void Action_SetTimeToMidnight(DateTimePicker picker)
        {
            DateTime CurrentValue = picker.Value;
            CurrentValue = DateTime.Parse(CurrentValue.Date.ToString(Timekeeper.DATE_FORMAT) + " 00:00:00");
            CurrentValue = CurrentValue.AddHours(Timekeeper.Options.Advanced_Other_MidnightOffset);
            picker.Value = CurrentValue;
        }

        private void PopupMenuDatesCopy_Click(object sender, EventArgs e)
        {
            // Maybe have next two lines be some sort of Classes.Widget thing? GetSourceDatePicker() or something?
            ToolStripDropDownItem PopupItem = (ToolStripDropDownItem)sender;
            DateTimePicker Picker = (DateTimePicker)((ContextMenuStrip)PopupItem.Owner).SourceControl;
            Action_CopyDate((DateTimePicker)Picker);
        }

        private void PopupMenuDatesPaste_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem PopupItem = (ToolStripDropDownItem)sender;
            DateTimePicker Picker = (DateTimePicker)((ContextMenuStrip)PopupItem.Owner).SourceControl;
            Action_PasteDate((DateTimePicker)Picker);
        }

        private void PopupMenuDatesSetTimeToMidnight_Click(object sender, EventArgs e)
        {
            ToolStripDropDownItem PopupItem = (ToolStripDropDownItem)sender;
            DateTimePicker Picker = (DateTimePicker)((ContextMenuStrip)PopupItem.Owner).SourceControl;
            Action_SetTimeToMidnight((DateTimePicker)Picker);
        }

        //----------------------------------------------------------------------

    }
}
