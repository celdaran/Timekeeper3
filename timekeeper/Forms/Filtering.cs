using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{

    public partial class Filtering : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private Forms.Controls.DateRangePicker DateRangePicker;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Filtering(Classes.FilterOptions filterOptions)
        {
            InitializeComponent();
            FilterOptions = filterOptions;
            // FIXME: load window metrics
        }

        //---------------------------------------------------------------------
        // Auto-Implemented Properties
        //---------------------------------------------------------------------

        public Classes.FilterOptions FilterOptions { get; set; }

        //---------------------------------------------------------------------
        // Event Handlers
        //---------------------------------------------------------------------

        private void Filtering_Load(object sender, EventArgs e)
        {
            //----------------------------------------
            // Custom controls
            //----------------------------------------

            // I'm having some design-time issues with this, loading up control at run time instead
            DateRangePicker = new Forms.Controls.DateRangePicker();
            DateRangePicker.Left = 17;
            DateRangePicker.Top = 26;
            DateGroupBox.Controls.Add(DateRangePicker);

            //----------------------------------------
            // Populate trees
            //----------------------------------------

            Classes.Widgets Widgets = new Classes.Widgets();

            ActivityTree.Nodes.Clear();
            Widgets.BuildActivityTree(ActivityTree.Nodes);

            ProjectTree.Nodes.Clear();
            Widgets.BuildProjectTree(ProjectTree.Nodes);

            //----------------------------------------
            // Populate duration boxes
            //----------------------------------------

            DurationOperator.SelectedIndex = 0;
            DurationAmount.Value = 0;
            DurationUnit.SelectedIndex = 0;

            //----------------------------------------
            // Populate Location & Category filters
            //----------------------------------------

            OtherAttributes OtherAttributes = new OtherAttributes();

            List<IdValuePair> Locations = OtherAttributes.Locations();
            foreach (IdValuePair Location in Locations) {
                LocationFilter.Items.Add(Location);
            }

            List<IdValuePair> Categories = OtherAttributes.Categories();
            foreach (IdValuePair Category in Categories) {
                CategoryFilter.Items.Add(Category);
            }

            //----------------------------------------
            // Load up existing options
            //----------------------------------------

            if (FilterOptions.DateRangePreset != -1) {
                DateRangePicker.Presets.SelectedIndex = FilterOptions.DateRangePreset;
                DateRangePicker.SetDateRange();
            }

            if (FilterOptions.Activities != null) {
                SetSelectedValues(ActivityTree.Nodes, FilterOptions.Activities);
            }

            if (FilterOptions.Projects != null) {
                SetSelectedValues(ProjectTree.Nodes, FilterOptions.Projects);
            }

            if (FilterOptions.Memo != null) {
                MemoFilter.Text = FilterOptions.Memo;
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

            if (FilterOptions.Locations != null) {
                SetSelectedValues(LocationFilter, FilterOptions.Locations);
            }

            if (FilterOptions.Categories != null) {
                SetSelectedValues(CategoryFilter, FilterOptions.Categories);
            }

            SortBy1.SelectedIndex = FilterOptions.SortBy1;
            SortBy2.SelectedIndex = FilterOptions.SortBy2;
            SortBy3.SelectedIndex = FilterOptions.SortBy3;
        }

        //---------------------------------------------------------------------

        private void Filtering_FormClosing(object sender, FormClosingEventArgs e)
        {
            // FIXME
            if (DateRangePicker.ToDate.Value < DateRangePicker.FromDate.Value) {
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

        //---------------------------------------------------------------------

        private void Splitter_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // FIXME: move this to fMain too. I like it.
            Splitter.SplitterDistance = Splitter.Width / 2;
        }

        //---------------------------------------------------------------------

        private void OkayButton_Click(object sender, EventArgs e)
        {
            FilterOptions.DateRangePreset = DateRangePicker.Presets.SelectedIndex;
            FilterOptions.StartTime = DateRangePicker.FromDate.Value;
            FilterOptions.StopTime = DateRangePicker.ToDate.Value;
            FilterOptions.Activities = GetActuallySelectedValues(ActivityTree.Nodes);
            FilterOptions.Projects = GetActuallySelectedValues(ProjectTree.Nodes);
            FilterOptions.Memo = MemoFilter.Text;
            FilterOptions.DurationOperator = DurationOperator.SelectedIndex;
            FilterOptions.DurationAmount = (int)DurationAmount.Value;
            FilterOptions.DurationUnit = DurationUnit.SelectedIndex;
            FilterOptions.Locations = GetActuallySelectedValues(LocationFilter);
            FilterOptions.Categories = GetActuallySelectedValues(CategoryFilter);
            FilterOptions.ImpliedActivities = GetImpliedSelectedValues(ActivityTree.Nodes, false);
            FilterOptions.ImpliedProjects = GetImpliedSelectedValues(ProjectTree.Nodes, false);
            FilterOptions.SortBy1 = SortBy1.SelectedIndex;
            FilterOptions.SortBy2 = SortBy2.SelectedIndex;
            FilterOptions.SortBy3 = SortBy3.SelectedIndex;

            DialogResult = DialogResult.OK;
        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        private List<long> GetImpliedSelectedValues(TreeNodeCollection nodes, bool ancestorChecked)
        {
            List<long> CheckedNodes = new List<long>();

            foreach (TreeNode Node in nodes) {
                Item Item = (Item)Node.Tag;
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
                Item Item = (Item)Node.Tag;
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
                Item Item = (Item)Node.Tag;

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


        //---------------------------------------------------------------------

    }
}
