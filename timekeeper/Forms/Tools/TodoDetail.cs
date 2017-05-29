using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Forms.Tools
{
    public partial class TodoDetail : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;
        private long TodoId;

        public Classes.TodoItem TodoItem { get; set; }
        public long ProjectId { get; set; }

        // MemoEditor control
        private Forms.Shared.MemoEditor MemoEditor;

        //----------------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------------

        public TodoDetail() : this(0)
        {
        }

        public TodoDetail(long todoId)
        {
            InitializeComponent();
            this.Options = Timekeeper.Options;
            this.TodoId = todoId;
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void TodoItem_Load(object sender, EventArgs e)
        {
            try {
                Classes.Widgets Widgets = new Classes.Widgets();
                Widgets.BuildProjectTree(ProjectTreeDropdown.Nodes);

                this.StartTime.CustomFormat = Options.Advanced_DateTimeFormat;
                this.DueTime.CustomFormat = Options.Advanced_DateTimeFormat;

                this.MemoEditor = new Forms.Shared.MemoEditor();
                this.MemoEditor.Parent = MemoPanel;
                this.MemoEditor.BringToFront();
                this.MemoEditor.Dock = DockStyle.Fill;
                this.MemoEditor.MemoEntry.TextChanged += new System.EventHandler(this.wMemo_TextChanged);
                this.MemoEditor.RightMargin = Options.View_MemoEditor_RightMargin_Todo;
                this.MemoEditor.Enabled = true;

                if (this.TodoId > 0) {
                    this.TodoItem = new Classes.TodoItem(this.TodoId);

                    // TODO: This should be in the Widgets class (e.g., a simple, all in one "SelectNode")
                    ComboTreeNode ProjectNode = Widgets.FindTreeNode(ProjectTreeDropdown.Nodes, TodoItem.ProjectId);
                    if (ProjectNode != null) {
                        ProjectTreeDropdown.SelectedNode = ProjectNode;
                        ProjectTreeDropdown.SelectedNode.Expand();
                    }

                    if (TodoItem.Memo != null)
                        this.MemoEditor.Text = TodoItem.Memo;

                    this.RefTodoStatus.SelectedIndex = 0;
                    this.RefTodoStatus.SelectedIndex = (int)TodoItem.RefTodoStatusId - 1;

                    if (DateSpecified(TodoItem.StartTime))
                        this.StartTime.Value = TodoItem.StartTime.Value.DateTime;
                    if (DateSpecified(TodoItem.DueTime))
                        this.DueTime.Value = TodoItem.DueTime.Value.DateTime;
                    if (TodoItem.Estimate > 0)
                        this.EstimateBox.Text = Timekeeper.FormatSeconds(TodoItem.Estimate.HasValue ? TodoItem.Estimate.Value : 0);

                } else {

                    // TODO: This should be in the Widgets class (e.g., a simple, all in one "SelectNode")
                    ComboTreeNode ProjectNode = Widgets.FindTreeNode(ProjectTreeDropdown.Nodes, this.ProjectId);
                    if (ProjectNode != null) {
                        ProjectTreeDropdown.SelectedNode = ProjectNode;
                        ProjectTreeDropdown.SelectedNode.Expand();
                    }

                    this.MemoEditor.Text = "Describe task here.";

                    this.TodoItem = new Classes.TodoItem();
                    this.RefTodoStatus.SelectedIndex = 0;
                    this.StartTime.Value = Timekeeper.LocalNow.DateTime;
                    this.DueTime.Value = Timekeeper.LocalNow.DateTime;
                }

                this.UseStartDate.Checked = DateSpecified(this.TodoItem.StartTime);
                this.UseDueDate.Checked = DateSpecified(this.TodoItem.DueTime);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private bool DateSpecified(DateTimeOffset? datetime)
        {
            if ((datetime == null) || (datetime == DateTimeOffset.MinValue)) {
                return false;
            } else {
                return true;
            }
        }

        //---------------------------------------------------------------------

        private void wMemo_TextChanged(object sender, EventArgs e)
        {
            // FIXME: need to implement revert
            //Action_EnableRevert(MemoEditor.Text, priorLoadedBrowserEntry.Memo);
        }

        //----------------------------------------------------------------------
        // Experimental
        //----------------------------------------------------------------------

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            Timekeeper.Info("Accept Button Clicked");

            if (ProjectTreeDropdown.SelectedNode == null) {
                Common.Warn("You must select a Project.");
                return;
            }

            Classes.TreeAttribute Project = (Classes.TreeAttribute)ProjectTreeDropdown.SelectedNode.Tag;

            this.TodoItem.Memo = this.MemoEditor.Text;
            this.TodoItem.ProjectId = Project.ItemId;
            this.TodoItem.RefTodoStatusId = this.RefTodoStatus.SelectedIndex + 1;
            this.TodoItem.StartTime = this.UseStartDate.Checked ? this.StartTime.Value : DateTimeOffset.MinValue;
            this.TodoItem.DueTime = this.UseDueDate.Checked ? this.DueTime.Value : DateTimeOffset.MinValue;
            this.TodoItem.Estimate = Timekeeper.UnformatSeconds(this.EstimateBox.Text);

            DialogResult = DialogResult.OK;
        }

        private void TodoItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Timekeeper.Info("Form closing");

            if (DialogResult == DialogResult.OK) {

                // Check that a folder isn't selected
                Classes.TreeAttribute Project = (Classes.TreeAttribute)ProjectTreeDropdown.SelectedNode.Tag;
                if (Project.IsFolder) {
                    Common.Warn("You must select a Project and not a Project Folder.");
                    e.Cancel = true;
                }

                // Check that this project isn't already on the todo list
                // There's a database constraint for this, but it's nicer
                // if we can catch it here before it gets that far...
                if (TodoId == 0) {
                    Classes.TodoItemCollection TodoItems = new Classes.TodoItemCollection();
                    if (TodoItems.Exists(Project.ItemId)) {
                        Common.Warn("A Todo Item for this Project already exists.");
                        e.Cancel = true;
                    }
                }
            }

            Options.View_MemoEditor_RightMargin_Todo = this.MemoEditor.RightMargin;
        }

        private void UseStartDate_CheckedChanged(object sender, EventArgs e)
        {
            StartTime.Enabled = UseStartDate.Checked;
        }

        private void UseDueDate_CheckedChanged(object sender, EventArgs e)
        {
            DueTime.Enabled = UseDueDate.Checked;
        }

        private void ProjectTreeDropdown_SelectedNodeChanged(object sender, EventArgs e)
        {
        }

        private void ProjectTreeDropdown_DropDownClosed(object sender, EventArgs e)
        {
        }

        private ComboTreeNode LastSelectedNode;

        private void ProjectTreeDropdown_Enter(object sender, EventArgs e)
        {
            LastSelectedNode = ProjectTreeDropdown.SelectedNode;
        }

        private void ProjectTreeDropdown_Leave(object sender, EventArgs e)
        {
            if (ProjectTreeDropdown.SelectedNode == null)
                return;

            Classes.TreeAttribute Project = (Classes.TreeAttribute)ProjectTreeDropdown.SelectedNode.Tag;
            if (Project.IsFolder) {
                Common.Warn("NO FOLDERS!!!");
                ProjectTreeDropdown.SelectedNode = LastSelectedNode;
            }
        }

        private void EstimateBox_Leave(object sender, EventArgs e)
        {
            this.EstimateBox.Text = Timekeeper.ReformatSeconds(this.EstimateBox.Text);
        }

        private void PopupMenuDimensionNewItem_Click(object sender, EventArgs e)
        {
            // FIXME: most of this lifted as-is from Main.Action.cs
            // Sorry...

            Classes.Widgets Widgets = new Classes.Widgets();

            Classes.TreeAttribute Item = Widgets.CreateTreeItemDialog(
                ProjectTreeDropdown, Timekeeper.Dimension.Project, false);

            if (Item != null)
            {
                ComboTreeNode NodeToSelect = Widgets.FindTreeNode(ProjectTreeDropdown.Nodes, Item.ItemId);

                if (NodeToSelect == null)
                    Widgets.SetDefaultNode(ProjectTreeDropdown);
                else
                    ProjectTreeDropdown.SelectedNode = NodeToSelect;

                Timekeeper.Mailbox.AddMessage("ReloadProjectTreeDropdown");
            }
        }

        private void PopupMenuDimensionManageItems_Click(object sender, EventArgs e)
        {
            Classes.Widgets Widgets = new Classes.Widgets();
            Widgets.ManageTreeDialog(Timekeeper.Dimension.Project, ProjectTreeDropdown, this);
            Timekeeper.Mailbox.AddMessage("ReloadProjectTreeDropdown");
        }

        //----------------------------------------------------------------------

    }
}
