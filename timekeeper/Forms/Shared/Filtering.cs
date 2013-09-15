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
        }

        //---------------------------------------------------------------------
        // Event Handlers
        //---------------------------------------------------------------------

        private void Filtering_Load(object sender, EventArgs e)
        {
            Timekeeper.Info("Filtering_Load called");

            this.Widgets = new Classes.Widgets();

            //----------------------------------------
            // Populate Location & Category filters
            //----------------------------------------

            PopulateStuff();

            //----------------------------------------
            // Set Visibility
            //----------------------------------------

            if (!Options.Layout_UseProjects) {
                // TODO: I'm not sure I'm done with this
                FilterOptionsTabControl.TabPages.RemoveByKey("ProjectTab");
            }

            if (!Options.Layout_UseActivities) {
                FilterOptionsTabControl.TabPages.RemoveByKey("ActivityTab");
            }

            if (!Options.Layout_UseLocations) {
                FilterOptionsTabControl.TabPages.RemoveByKey("LocationTab");
            }

            if (!Options.Layout_UseCategories) {
                FilterOptionsTabControl.TabPages.RemoveByKey("CategoryTab");
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

            if (FilterOptions.MemoContains != null) {
                MemoFilter.Text = FilterOptions.MemoContains;
            }

            if (FilterOptions.Projects != null) {
                SetSelectedValues(ProjectTree.Nodes, FilterOptions.Projects);
            }

            if (FilterOptions.Activities != null) {
                SetSelectedValues(ActivityTree.Nodes, FilterOptions.Activities);
            }

            if (FilterOptions.Locations != null) {
                SetSelectedValues(LocationFilter, FilterOptions.Locations);
            }

            if (FilterOptions.Categories != null) {
                SetSelectedValues(CategoryFilter, FilterOptions.Categories);
            }

            if (FilterOptions.DurationOperator != -1) {
                DurationOperator.SelectedIndex = FilterOptions.DurationOperator;
                DurationOperator_SelectedIndexChanged(sender, e);
            }

            if (FilterOptions.DurationAmount != 0) {
                DurationAmount.Value = FilterOptions.DurationAmount;
            }

            if (FilterOptions.DurationUnit != -1) {
                DurationUnit.SelectedIndex = FilterOptions.DurationUnit;
            }
        }

        //----------------------------------------------------------------------

        private void PopulateStuff()
        {
            ProjectTree.Nodes.Clear();
            ActivityTree.Nodes.Clear();
            LocationFilter.Items.Clear();
            CategoryFilter.Items.Clear();

            Widgets.BuildProjectTree(ProjectTree.Nodes);
            Widgets.BuildActivityTree(ActivityTree.Nodes);

            Classes.LocationCollection Locations = new Classes.LocationCollection();
            List<IdObjectPair> FetchedLocations = Locations.Fetch();
            foreach (IdObjectPair Location in FetchedLocations) {
                LocationFilter.Items.Add(Location);
            }

            Classes.CategoryCollection Categories = new Classes.CategoryCollection();
            List<IdObjectPair> FetchedCategories = Categories.Fetch();
            foreach (IdObjectPair Category in FetchedCategories) {
                CategoryFilter.Items.Add(Category);
            }
        }

        //----------------------------------------------------------------------

        private void Filtering_FormClosing(object sender, FormClosingEventArgs e)
        {
            // FIXME
            if (ToDate.Value < FromDate.Value) {
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

        private void CheckedListBoxMenuSelectAll_Click(object sender, EventArgs e)
        {
            CheckedListBox Box = GetCheckedListBox(sender);
            Select(Box, 1);
        }

        //---------------------------------------------------------------------

        private void CheckedListBoxMenuSelectNone_Click(object sender, EventArgs e)
        {
            CheckedListBox Box = GetCheckedListBox(sender);
            Select(Box, 0);
        }

        //---------------------------------------------------------------------

        private void CheckedListBoxMenuInvertSelection_Click(object sender, EventArgs e)
        {
            CheckedListBox Box = GetCheckedListBox(sender);
            Select(Box, -1);
        }

        //---------------------------------------------------------------------

        private void DurationOperator_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Splitter_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // FIXME: move this to fMain too. I like it.
            //Splitter.SplitterDistance = Splitter.Width / 2;
        }

        //---------------------------------------------------------------------

        private void OkayButton_Click(object sender, EventArgs e)
        {
            FilterOptions.DateRangePreset = Presets.SelectedIndex + 1;
            FilterOptions.FromDate = FromDate.Value;
            FilterOptions.ToDate = ToDate.Value;
            FilterOptions.MemoContains = MemoFilter.Text;
            FilterOptions.Activities = GetActuallySelectedValues(ActivityTree.Nodes);
            FilterOptions.Projects = GetActuallySelectedValues(ProjectTree.Nodes);
            FilterOptions.DurationOperator = DurationOperator.SelectedIndex;
            FilterOptions.DurationAmount = (int)DurationAmount.Value;
            FilterOptions.DurationUnit = DurationUnit.SelectedIndex;
            FilterOptions.Locations = GetActuallySelectedValues(LocationFilter);
            FilterOptions.Categories = GetActuallySelectedValues(CategoryFilter);
            FilterOptions.ImpliedActivities = GetImpliedSelectedValues(ActivityTree.Nodes, false);
            FilterOptions.ImpliedProjects = GetImpliedSelectedValues(ProjectTree.Nodes, false);

            DialogResult = DialogResult.OK;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // TODO: need a better way to convert constants to combobox values
            Presets.SelectedIndex = Classes.FilterOptions.DATE_PRESET_ALL - 1;
            MemoFilter.Text = "";

            PopulateStuff();

            DurationOperator.SelectedIndex = 0;
            DurationAmount.Value = 0;
            DurationUnit.SelectedIndex = -1;

            CreateTimePresets.SelectedIndex = -1;
            ModifyTimePresets.SelectedIndex = -1;
        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        private List<long> GetImpliedSelectedValues(TreeNodeCollection nodes, bool ancestorChecked)
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

        private List<long> GetActuallySelectedValues(CheckedListBox list)
        {
            List<long> CheckedItems = new List<long>();

            for (int i = 0; i < list.Items.Count; i++) {
                if (list.GetItemChecked(i)) {
                    CheckedItems.Add(i);
                }
            }

            return CheckedItems;
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

        private void SetSelectedValues(CheckedListBox list, List<long> checkedItems)
        {
            for (int i = 0; i < list.Items.Count; i++) {
                if (checkedItems.IndexOf(i) >= 0) {
                    list.SetItemChecked(i, true);
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

        private void Select(CheckedListBox checkedListBox, int state)
        {

            for (int i = 0; i < checkedListBox.Items.Count; i++) {

                if (state == 0) {
                    checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
                } else if (state == 1) {
                    checkedListBox.SetItemCheckState(i, CheckState.Checked);
                } else if (state == -1) {
                    CheckState CurrentState = checkedListBox.GetItemCheckState(i);
                    if (CurrentState == CheckState.Checked) {
                        checkedListBox.SetItemCheckState(i, CheckState.Unchecked);
                    } else {
                        checkedListBox.SetItemCheckState(i, CheckState.Checked);
                    }
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

        //---------------------------------------------------------------------

        private CheckedListBox GetCheckedListBox(object sender)
        {
            CheckedListBox Result = null;

            ToolStripItem MenuItem = sender as ToolStripItem;
            if (MenuItem != null) {
                ContextMenuStrip Owner = MenuItem.Owner as ContextMenuStrip;
                if (Owner != null) {
                    Result = Owner.SourceControl as CheckedListBox;
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
                FromDate.Value = FilterOptions.FromDate;
                ToDate.Value = FilterOptions.ToDate;
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
            PreviousFromDate = FromDate.Value;
        }

        private void FromDate_Leave(object sender, EventArgs e)
        {
            if (PreviousFromDate != FromDate.Value) {
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

        //----------------------------------------------------------------------

    }
}
