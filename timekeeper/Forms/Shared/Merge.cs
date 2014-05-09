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
        //----------------------------------------------------------------------
        // TODO: this thing is more or less hard wired to just allow for project
        // and activity merging. But it should be made available for use by 
        // locations and categories too. *Parts* of this are ready for these
        // other two dimensions, but other parts are very much not.
        //----------------------------------------------------------------------

        private Classes.TreeAttribute SourceItem;

        public Classes.TreeAttribute TargetItem;

        private Classes.FindView FindView;
        private Forms.Shared.Filtering FilterDialog;
        private Classes.Widgets Widgets;

        public Merge(Classes.TreeAttribute item)
        {
            InitializeComponent();
            this.SourceItem = item;
            this.FindView = new Classes.FindView();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            if (ItemTree.SelectedNode == null) {
                Common.Warn("No item selected");
                return;
            }

            this.TargetItem = (Classes.TreeAttribute)ItemTree.SelectedNode.Tag;
            DialogResult = DialogResult.OK;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Merge_Load(object sender, EventArgs e)
        {
            ItemTree.Nodes.Clear();
            this.Widgets = new Classes.Widgets();

            if (this.SourceItem.Type == Timekeeper.Dimension.Project) {
                Widgets.BuildProjectTree(ItemTree.Nodes);
            } else {
                Widgets.BuildActivityTree(ItemTree.Nodes);
            }

        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            FindView.FilterOptions.FilterOptionsType = Classes.FilterOptions.OptionsType.Merge;
            FindView.FilterOptions.FilterMergeType = this.SourceItem.Type;
            this.FilterDialog = new Forms.Shared.Filtering(FindView.FilterOptions);

            FindView.FilterOptions = this.Widgets.FilteringDialog(this,
                FilterDialog, FindView.FilterOptions.FilterOptionsId);

            if (FindView.FilterOptions.Changed) {
                FindView.Changed = true;
                List<long> ImpliedProjects = new List<long>();
                ImpliedProjects.Add(this.SourceItem.ItemId);
                FindView.FilterOptions.ImpliedProjects = ImpliedProjects;
                FindView.FilterOptions.SuppressTableAlias = true;
                Common.Info(this.FindView.FilterOptions.WhereClause);
                //RunMerge();
            }
        }

        private void RunMerge()
        {
            Classes.JournalEntryCollection Entries = new Classes.JournalEntryCollection();
            bool Result = Entries.Merge(
                this.FindView.FilterOptions.WhereClause, 
                this.SourceItem.Type.ToString() + "Id", 
                this.SourceItem.ItemId);
            if (!Result) {
                Timekeeper.DoubleWarn("Error encountered during merge operation.");
            }
        }

    }
}
