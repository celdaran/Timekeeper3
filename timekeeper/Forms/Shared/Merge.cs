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
    public partial class Merge : Form
    {
        private Classes.TreeAttribute SourceItem;

        private Classes.FindView FindView;
        private Forms.Shared.Filtering FilterDialog;
        private Classes.Widgets Widgets;

        private TreeNode LastSelectedNode;

        private Classes.JournalEntryCollection Entries;
        private string WhereClause;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Merge(Classes.TreeAttribute item)
        {
            InitializeComponent();

            this.SourceItem = item;
            this.FindView = new Classes.FindView();
            this.Entries = new Classes.JournalEntryCollection();
        }

        //----------------------------------------------------------------------
        // Form events
        //----------------------------------------------------------------------

        private void Merge_Load(object sender, EventArgs e)
        {
            // Reset window metrics

            if (Timekeeper.Options.Merge_Height > 0) {
                this.Height = Timekeeper.Options.Merge_Height;
                this.Width = Timekeeper.Options.Merge_Width;
                this.Top = Timekeeper.Options.Merge_Top;
                this.Left = Timekeeper.Options.Merge_Left;
            }

            // Set window title

            this.Text = String.Format(@"Merge {0} ""{1}"" into...",
                this.SourceItem.Dimension.ToString(),
                this.SourceItem.Name);

            // Prepare the tree
            ItemTree.Nodes.Clear();

            this.Widgets = new Classes.Widgets();

            Widgets.BuildTree(this.SourceItem.Dimension, ItemTree);

            // Remove the preselected node, since merging into 
            // ourself isn't allowed.
            TreeNode PreSelectedNode = Widgets.FindTreeNode(ItemTree.Nodes, this.SourceItem.ItemId);
            PreSelectedNode.Remove();

            // And repurpose the preselected node as the first
            // non-folder node in the tree.
            PreSelectedNode = GetFirstNonFolder(ItemTree.Nodes);
            ItemTree.SelectedNode = PreSelectedNode;

        }

        //----------------------------------------------------------------------

        private void Merge_FormClosing(object sender, FormClosingEventArgs e)
        {
            Timekeeper.Options.Merge_Height = this.Height;
            Timekeeper.Options.Merge_Width = this.Width;
            Timekeeper.Options.Merge_Top = this.Top;
            Timekeeper.Options.Merge_Left = this.Left;
        }

        //----------------------------------------------------------------------

        private TreeNode GetFirstNonFolder(TreeNodeCollection nodes)
        {
            // STOLEN FROM Main.Action.cs
            // FIXME: THIS BELONGS IN Classes.Widgets

            TreeNode ReturnValue = null;

            foreach (TreeNode Node in nodes) {
                Classes.TreeAttribute Temp = (Classes.TreeAttribute)Node.Tag;
                if (Temp.IsFolder) {
                    ReturnValue = GetFirstNonFolder(Node.Nodes);
                    break;
                } else {
                    ReturnValue = Node;
                    break;
                }
            }

            return ReturnValue;
        }

        //----------------------------------------------------------------------
        // Tree events
        //----------------------------------------------------------------------

        private void ItemTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            LastSelectedNode = ItemTree.SelectedNode;
        }

        //----------------------------------------------------------------------

        private void ItemTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Classes.TreeAttribute Item = (Classes.TreeAttribute)ItemTree.SelectedNode.Tag;
            if (Item.IsFolder) {
                Common.Warn("Cannot select a folder as the merge target.");
                ItemTree.SelectedNode = LastSelectedNode;
            }
        }

        //----------------------------------------------------------------------

        private void ItemTree_DoubleClick(object sender, EventArgs e)
        {
            MergeButton_Click(sender, e);
        }

        //----------------------------------------------------------------------
        // Button events
        //----------------------------------------------------------------------

        private void MergeButton_Click(object sender, EventArgs e)
        {
            if (ItemTree.SelectedNode == null) {
                Common.Warn("No item selected");
                return;
            }

            Classes.TreeAttribute TargetItem = (Classes.TreeAttribute)ItemTree.SelectedNode.Tag;

            FindView.FilterOptions.SuppressTableAlias = true;

            this.WhereClause = String.Format(@"{0} AND {1}Id = {2}",
                this.FindView.FilterOptions.WhereClause,
                this.SourceItem.Dimension.ToString(),
                this.SourceItem.ItemId);

            int EntriesAffected = Entries.Count(WhereClause);

            if (EntriesAffected == 0) {
                Common.Info("No entries would be affected by this merge.");
                return;
            }

            string Prompt = String.Format(@"This would merge {0} entries from {3} ""{1}"" into {3} ""{2}"". Continue?",
                EntriesAffected,
                this.SourceItem.Name,
                TargetItem.Name,
                this.SourceItem.Dimension.ToString());

            if (Common.Prompt(Prompt) == DialogResult.Yes)
            {
                bool Result = Entries.Merge(
                    this.WhereClause,
                    this.SourceItem.Dimension.ToString() + "Id",
                    TargetItem.ItemId);
                if (Result) {
                    string Message = String.Format("Merge was successful.");
                    Common.Info(Message);
                } else {
                    Timekeeper.DoubleWarn("Error encountered during merge operation.");
                    return;
                }

            }
            else {
                // Merge cancelled...
                // So leave return to the dialog box and give them a second try
                return;
            }

            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        //----------------------------------------------------------------------

        private void FilterButton_Click(object sender, EventArgs e)
        {
            FindView.FilterOptions.FilterOptionsType = Classes.FilterOptions.OptionsType.Merge;
            FindView.FilterOptions.FilterMergeType = this.SourceItem.Dimension;
            this.FilterDialog = new Forms.Shared.Filtering(FindView.FilterOptions);

            FindView.FilterOptions = this.Widgets.FilteringDialog(this,
                FilterDialog, FindView.FilterOptions.FilterOptionsId);

            if (FindView.FilterOptions.Changed) {
                FindView.Changed = true;
            }
        }

        //----------------------------------------------------------------------

    }
}
