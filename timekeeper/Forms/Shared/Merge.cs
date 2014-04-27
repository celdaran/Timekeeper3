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

            if (this.SourceItem.Type == Classes.TreeAttribute.ItemType.Project) {
                Widgets.BuildProjectTree(ItemTree.Nodes);
            } else {
                Widgets.BuildActivityTree(ItemTree.Nodes);
            }

        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            this.FilterDialog = new Forms.Shared.Filtering(FindView.FilterOptions);

            FindView.FilterOptions = this.Widgets.FilteringDialog(this,
                FilterDialog, FindView.FilterOptions.FilterOptionsId);

            if (FindView.FilterOptions.Changed) {
                FindView.Changed = true;
                Common.Info(this.FindView.FilterOptions.WhereClause);
                //RunFind();
            }
        }

    }
}
