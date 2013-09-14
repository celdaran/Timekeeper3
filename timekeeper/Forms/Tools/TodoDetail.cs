using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

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
                Widgets.BuildProjectTree(ProjectTree.Nodes);

                this.StartDate.CustomFormat = Options.Advanced_DateTimeFormat;
                this.DueDate.CustomFormat = Options.Advanced_DateTimeFormat;

                if (this.TodoId > 0) {
                    this.TodoItem = new Classes.TodoItem(this.TodoId);

                    // TODO: This should be in the Widgets class (e.g., a simple, all in one "SelectNode")
                    TreeNode ProjectNode = Widgets.FindTreeNode(ProjectTree.Nodes, TodoItem.ProjectId);
                    if (ProjectNode != null) {
                        ProjectTree.SelectedNode = ProjectNode;
                        ProjectTree.SelectedNode.Expand();
                    }

                    this.RefTodoStatus.SelectedIndex = 0;
                    this.RefTodoStatus.SelectedIndex = (int)TodoItem.RefTodoStatusId - 1;

                    if ((TodoItem.StartDate != null) && (TodoItem.StartDate != DateTime.MinValue))
                        this.StartDate.Value = TodoItem.StartDate;
                    if ((TodoItem.DueDate != null) && (TodoItem.DueDate != DateTime.MinValue))
                        this.DueDate.Value = TodoItem.DueDate;
                    if (TodoItem.Memo != null)
                        this.Memo.Text = TodoItem.Memo;
                } else {

                    // TODO: This should be in the Widgets class (e.g., a simple, all in one "SelectNode")
                    TreeNode ProjectNode = Widgets.FindTreeNode(ProjectTree.Nodes, this.ProjectId);
                    if (ProjectNode != null) {
                        ProjectTree.SelectedNode = ProjectNode;
                        ProjectTree.SelectedNode.Expand();
                    }

                    this.TodoItem = new Classes.TodoItem();
                    this.RefTodoStatus.SelectedIndex = 0;
                    this.StartDate.Value = DateTime.Now;
                    this.DueDate.Value = DateTime.Now;
                    this.Memo.Text = "";
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // Experimental
        //----------------------------------------------------------------------

        private void ProjectTree_DragDrop(object sender, DragEventArgs e)
        {
            Common.Info("You just dropped something. Want me to pick it up?" + "\n\n" + e.ToString());
        }

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            Timekeeper.Info("Accept Button Clicked");

            if (ProjectTree.SelectedNode == null) {
                Common.Warn("You must select a Project.");
                return;
            }

            Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;

            this.TodoItem.ProjectId = Project.ItemId;
            this.TodoItem.RefTodoStatusId = this.RefTodoStatus.SelectedIndex + 1;
            this.TodoItem.StartDate = this.StartDate.Value;
            this.TodoItem.DueDate = this.DueDate.Value;
            this.TodoItem.Memo = this.Memo.Text;

            DialogResult = DialogResult.OK;
        }

        private void TodoItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Timekeeper.Info("Form closing");

            if (DialogResult == DialogResult.OK) {

                // Check that a folder isn't selected
                Classes.Project Project = (Classes.Project)ProjectTree.SelectedNode.Tag;
                if (Project.IsFolder) {
                    Common.Warn("You must select a Project and not a Project Folder.");
                    e.Cancel = true;
                }

                // Check that this project isn't already on the todo list
                if (TodoId == 0) {
                    Classes.TodoItemCollection TodoItems = new Classes.TodoItemCollection();
                    if (TodoItems.Exists(Project.ItemId)) {
                        Common.Warn("A Todo Item for this Project already exists.");
                        e.Cancel = true;
                    }
                }
            }
        }

        //----------------------------------------------------------------------

    }
}
