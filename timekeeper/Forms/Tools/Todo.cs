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
    public partial class Todo : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;
        private ListViewColumnSorter ColumnSorter;
        private int GroupBy = 1;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Todo()
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;

            ColumnSorter = new ListViewColumnSorter();
            this.TodoList.ListViewItemSorter = ColumnSorter;
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void TodoList_DoubleClick(object sender, EventArgs e)
        {
            EditItem();
        }

        //----------------------------------------------------------------------

        private void Todo_Load(object sender, EventArgs e)
        {
            try {
                PopulateTodoList();
                RestoreWindowMetrics();
                ShowGroups(Options.Todo_ShowGroups);
                ShowCompletedItems(Options.Todo_ShowCompletedItems);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        private void PopulateTodoList()
        {
            System.Diagnostics.Stopwatch t = new System.Diagnostics.Stopwatch();
            Timekeeper.Bench(t);

            Timekeeper.Database.BeginWork();

            // Populate Groups
            CreateGroups();

            // Clear list
            TodoList.Items.Clear();
            ColumnSorter.SortColumn = 0;

            // Populate items
            Classes.TodoItemCollection Collection = new Classes.TodoItemCollection();
            List<Classes.TodoItem> Items = Collection.Fetch(!MenuTodoShowCompletedItems.Checked);

            foreach (Classes.TodoItem TodoItem in Items) {
                Classes.Project Project = new Classes.Project(TodoItem.ProjectId);
                string GroupName = GetGroupName(TodoItem);
                this.AddItem(Project.DisplayName(), TodoItem, TodoList.Groups[GroupName]);
            }

            Timekeeper.Database.EndWork();

            Timekeeper.Bench(t, "PopulateTodoList (" + this.GroupBy.ToString() + ")");

            StatusBarItemCount.Text = TodoList.Items.Count + " item(s)";
        }

        private string GetTodoItemText(string text, int id)
        {
            int NewlineLocation = text.IndexOf("\n");
            bool NewlineExistsWithinReason = (NewlineLocation > -1) && (NewlineLocation < 50);

            string Display = ""; // id.ToString() + ". ";

            if (NewlineExistsWithinReason) {
                Display += text.Substring(0, NewlineLocation);
            } else {
                Display += Common.Abbreviate(text, 50);
            }

            return Display;
        }

        private string GetGroupName(Classes.TodoItem TodoItem)
        {
            string GroupName = "Default";
            switch (this.GroupBy) {
                case 1:
                    GroupName = TodoItem.StatusName;
                    break;
                case 2:
                    GroupName = GetProjectFolder(TodoItem.ProjectId);
                    break;
                case 3:
                    GroupName = GetDueDateTimeframe(TodoItem.DueTime);
                    break;
            }
            return GroupName;
        }

        private string GetProjectFolder(long projectId)
        {
            Classes.Project Project = new Classes.Project(projectId);
            return Project.Parent.Name;
        }

        private string GetDueDateTimeframe(DateTimeOffset? duedate)
        {
            if (duedate == null)
                return "None";

            DateTime DueDate = duedate.Value.LocalDateTime;
            DateTime TimeframeEndDate;

            DateTimeOffset Today = DateTimeOffset.Now;
            TimeframeEndDate = DateTime.Parse(Today.ToString(Timekeeper.DATE_FORMAT) + " 23:59:59");
            //Timekeeper.Info(String.Format("Alpha: Comparing {0} to {1}", DueDate, TimeframeEndDate));
            if (DueDate.CompareTo(TimeframeEndDate) < 1)
                return "Today";

            int SundayDelta = DayOfWeek.Sunday - Today.DayOfWeek;
            DateTimeOffset EndOfWeek = Today.Add(new TimeSpan((SundayDelta + 7) * 24, 0, 0));
            TimeframeEndDate = DateTime.Parse(EndOfWeek.Date.ToString(Timekeeper.DATE_FORMAT) + " 23:59:59");
            if (DueDate.CompareTo(TimeframeEndDate) < 1)
                return "This Week";

            string EndOfMonthString = String.Format("{0}-{1}-{2}", 
                Today.Year, Today.Month, DateTime.DaysInMonth(Today.Year, Today.Month));
            DateTimeOffset EndOfMonth = Timekeeper.StringToDate(EndOfMonthString);
            TimeframeEndDate = DateTime.Parse(EndOfWeek.Date.ToString(Timekeeper.DATE_FORMAT) + " 23:59:59");
            if (DueDate.CompareTo(TimeframeEndDate) < 1)
                return "This Month";

            TimeframeEndDate = DateTime.Parse(Today.Year.ToString() + "-12-31 23:59:59");
            if (DueDate.CompareTo(TimeframeEndDate) < 1)
                return "This Year";

            return "Beyond";
        }

        private void RestoreWindowMetrics()
        {
            this.Height = Options.Todo_Height;
            this.Width = Options.Todo_Width;
            this.Left = Options.Todo_Left;
            this.Top = Options.Todo_Top;

            switch (Options.Todo_IconView) {
                case 1: ViewLargeIcons(); break;
                case 2: ViewSmallIcons(); break;
                case 3: ViewTiles(); break;
                case 4: ViewList(); break;
                default: ViewDetails(); break;
            }

            TodoList.Columns[0].Width = Options.Todo_ProjectNameWidth;
            TodoList.Columns[1].Width = Options.Todo_StartDateWidth;
            TodoList.Columns[2].Width = Options.Todo_DueDateWidth;
            TodoList.Columns[3].Width = Options.Todo_StatusWidth;

            TodoList.Columns[0].DisplayIndex = Options.Todo_ProjectNameDisplayIndex;
            TodoList.Columns[1].DisplayIndex = Options.Todo_StartDateDisplayIndex;
            TodoList.Columns[2].DisplayIndex = Options.Todo_DueDateDisplayIndex;
            TodoList.Columns[3].DisplayIndex = Options.Todo_StatusDisplayIndex;
        }

        private void CreateGroups()
        {
            ListViewGroup Group;
            TodoList.Groups.Clear();

            switch (this.GroupBy) {
                // Hardcoding Status for now
                case 1:
                    // Get status values
                    Classes.ReferenceData ReferenceData = new Classes.ReferenceData();
                    List<IdValuePair> TodoStatusCollection = ReferenceData.TodoStatus();

                    // Now create a group for each one
                    foreach (IdValuePair TodoStatus in TodoStatusCollection) {
                        Group = new ListViewGroup(TodoStatus.Description, TodoStatus.Description);
                        TodoList.Groups.Add(Group);
                    }
                    break;
                case 2 :
                    // Get project folders
                    Classes.ProjectCollection ProjectCollection = new Classes.ProjectCollection();
                    List<Classes.Project> Projects = ProjectCollection.FetchAll();
                    foreach (Classes.Project Project in Projects) {
                        Group = new ListViewGroup(Project.Parent.Name ?? "None", Project.Parent.Name ?? "None");
                        TodoList.Groups.Add(Group);
                    }
                    break;
                case 3:
                    // Get timeframes
                    Group = new ListViewGroup("Today", "Today");
                    TodoList.Groups.Add(Group);
                    Group = new ListViewGroup("This Week", "This Week");
                    TodoList.Groups.Add(Group);
                    Group = new ListViewGroup("This Month", "This Month");
                    TodoList.Groups.Add(Group);
                    Group = new ListViewGroup("This Year", "This Year");
                    TodoList.Groups.Add(Group);
                    Group = new ListViewGroup("Beyond", "Beyond");
                    TodoList.Groups.Add(Group);
                    Group = new ListViewGroup("None", "None");
                    TodoList.Groups.Add(Group);
                    break;
            }

        }

        public void AddItem(string displayName, Classes.TodoItem todoItem, ListViewGroup group)
        {
            try {
                if (todoItem.IsHidden && !Options.View_HiddenProjects) {
                    // Don't add hidden items if we're hiding hidden items
                    return;
                }

                ListViewItem NewItem = new ListViewItem(displayName, group);
                TodoList.Items.Add(NewItem);

                NewItem.Tag = todoItem;
                NewItem.ImageIndex = 0;
                NewItem.ToolTipText = todoItem.Memo;

                if (todoItem.IsHidden) {
                    NewItem.ForeColor = Color.Gray;
                    NewItem.ImageIndex = 1;
                }

                string StartDate = Timekeeper.NullableDateForDisplay(todoItem.StartTime);
                string DueDate = Timekeeper.NullableDateForDisplay(todoItem.DueTime);

                if (DueDate != "None") {
                    DateTimeOffset Converted = (DateTimeOffset)todoItem.DueTime;
                    if (Converted.CompareTo(DateTime.UtcNow) < 0) {
                        NewItem.ForeColor = Color.Red;
                    }
                }

                NewItem.SubItems.Add(GetTodoItemText(todoItem.Memo, (int)todoItem.TodoId));
                NewItem.SubItems.Add(todoItem.ProjectFolderName ?? "None");
                NewItem.SubItems.Add(StartDate);
                NewItem.SubItems.Add(DueDate);
                NewItem.SubItems.Add(todoItem.StatusName);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // Menu and Toolbar Events
        //----------------------------------------------------------------------

        private void MenuTodoAdd_Click(object sender, EventArgs e)
        {
            Forms.Tools.TodoDetail DialogBox = new Forms.Tools.TodoDetail();
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                Classes.TodoItem TodoItem = DialogBox.TodoItem;
                if (TodoItem.Create()) {
                    string GroupName = GetGroupName(TodoItem);
                    this.AddItem(TodoItem.ProjectName, TodoItem, TodoList.Groups[GroupName]);
                }
            }
        }

        private void MenuTodoEdit_Click(object sender, EventArgs e)
        {
            if (TodoList.SelectedItems.Count > 1) {
                Common.Warn("Cannot edit multiple items");
            } else {
                EditItem();
            }
        }

        private void MenuTodoHide_Click(object sender, EventArgs e)
        {
            if (TodoList.SelectedItems.Count > 1) {
                string Message = String.Format("Are you sure you want to hide these {0} items?", TodoList.SelectedItems.Count);
                if (Common.WarnPrompt(Message) == DialogResult.No) {
                    return;
                }
            }

            foreach (ListViewItem Item in TodoList.SelectedItems) {
                Classes.TodoItem TodoItem = (Classes.TodoItem)Item.Tag;
                TodoItem.Hide();
                if (Options.View_HiddenProjects) {
                    Item.ImageIndex = 1;
                    Item.ForeColor = Color.Gray;
                } else {
                    TodoList.Items.Remove(Item);
                }
            }
        }

        private void MenuTodoUnhide_Click(object sender, EventArgs e)
        {
            if (TodoList.SelectedItems.Count > 1) {
                string Message = String.Format("Are you sure you want to unhide these {0} items?", TodoList.SelectedItems.Count);
                if (Common.WarnPrompt(Message) == DialogResult.No) {
                    return;
                }
            }

            foreach (ListViewItem Item in TodoList.SelectedItems) {
                Classes.TodoItem TodoItem = (Classes.TodoItem)Item.Tag;
                TodoItem.Unhide();
                Item.ImageIndex = 0;
                Item.ForeColor = SystemColors.ControlText;
            }
        }

        private void MenuTodoDelete_Click(object sender, EventArgs e)
        {
            if (TodoList.SelectedItems.Count > 0) {
                string Message = TodoList.SelectedItems.Count == 1 ?
                    String.Format("Are you sure you want to delete this item?") :
                    String.Format("Are you sure you want to delete these {0} items?", TodoList.SelectedItems.Count);
                if (Common.WarnPrompt(Message) == DialogResult.No) {
                    return;
                }
            }

            foreach (ListViewItem Item in TodoList.SelectedItems) {
                Classes.TodoItem TodoItem = (Classes.TodoItem)Item.Tag;
                TodoItem.Delete();
                TodoList.Items.Remove(Item);
            }
        }

        private void MenuTodoMarkAsNotStarted_Click(object sender, EventArgs e)
        {
            // TODO: come up with constants for this
            SetTodoItemStatus(1);
        }

        private void MenuTodoMarkAsInProgress_Click(object sender, EventArgs e)
        {
            SetTodoItemStatus(2);
        }

        private void MenuTodoMarkAsOnHold_Click(object sender, EventArgs e)
        {
            SetTodoItemStatus(3);
        }

        private void MenuTodoMarkAsBlocked_Click(object sender, EventArgs e)
        {
            SetTodoItemStatus(4);
        }

        private void MenuTodoMarkAsComplete_Click(object sender, EventArgs e)
        {
            SetTodoItemStatus(5);
        }

        private void MenuTodoViewLargeIcons_Click(object sender, EventArgs e)
        {
            ViewLargeIcons();
        }

        private void MenuTodoViewSmallIcons_Click(object sender, EventArgs e)
        {
            ViewSmallIcons();
        }

        private void MenuTodoViewTiles_Click(object sender, EventArgs e)
        {
            ViewTiles();
        }

        private void MenuTodoViewList_Click(object sender, EventArgs e)
        {
            ViewList();
        }

        private void MenuTodoViewDetails_Click(object sender, EventArgs e)
        {
            ViewDetails();
        }

        private void MenuTodoViewShowGroups_Click(object sender, EventArgs e)
        {
            ToggleGroups();
            /*
            PopupMenuTodoViewShowGroups.Checked = !PopupMenuTodoViewShowGroups.Checked;
            TodoList.ShowGroups = PopupMenuTodoViewShowGroups.Checked;
            MenuTodoShowGroups.Checked = PopupMenuTodoViewShowGroups.Checked;
            */
        }

        private void ShowGroups(bool showGroups)
        {
            TodoList.ShowGroups = showGroups;
            MenuTodoShowGroups.Checked = TodoList.ShowGroups;
            PopupMenuTodoViewShowGroups.Checked = TodoList.ShowGroups;
        }

        private void ToggleGroups()
        {
            ShowGroups(!TodoList.ShowGroups);
            Options.Todo_ShowGroups = TodoList.ShowGroups;
        }

        private void MirrorViewChecks()
        {
            MenuTodoViewLargeIcons.Checked = PopupMenuTodoViewLargeIcons.Checked;
            MenuTodoViewSmallIcons.Checked = PopupMenuTodoViewSmallIcons.Checked;
            MenuTodoViewTiles.Checked = PopupMenuTodoViewTiles.Checked;
            MenuTodoViewList.Checked = PopupMenuTodoViewList.Checked;
            MenuTodoViewDetails.Checked = PopupMenuTodoViewDetails.Checked;
        }

        private void MenuTodoGroupByStatus_Click(object sender, EventArgs e)
        {
            this.GroupBy = 1;

            MenuTodoGroupByStatus.Checked = true;
            MenuTodoGroupByProject.Checked = false;
            MenuTodoGroupByDueDate.Checked = false;

            PopupMenuTodoGroupByStatus.Checked = true;
            PopupMenuTodoGroupByProject.Checked = false;
            PopupMenuTodoGroupByDueDate.Checked = false;

            PopulateTodoList();
        }

        private void MenuTodoGroupByProject_Click(object sender, EventArgs e)
        {
            this.GroupBy = 2;

            MenuTodoGroupByStatus.Checked = false;
            MenuTodoGroupByProject.Checked = true;
            MenuTodoGroupByDueDate.Checked = false;

            PopupMenuTodoGroupByStatus.Checked = false;
            PopupMenuTodoGroupByProject.Checked = true;
            PopupMenuTodoGroupByDueDate.Checked = false;

            PopulateTodoList();
        }

        private void MenuTodoGroupByDueDate_Click(object sender, EventArgs e)
        {
            this.GroupBy = 3;

            MenuTodoGroupByStatus.Checked = false;
            MenuTodoGroupByProject.Checked = false;
            MenuTodoGroupByDueDate.Checked = true;

            PopupMenuTodoGroupByStatus.Checked = false;
            PopupMenuTodoGroupByProject.Checked = false;
            PopupMenuTodoGroupByDueDate.Checked = true;

            PopulateTodoList();
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private void EditItem()
        {
            long TodoId = GetSelectedId();

            if (TodoId == 0) {
                return;
            }

            ListViewItem SelectedItem = TodoList.SelectedItems[0];

            Forms.Tools.TodoDetail DialogBox = new Forms.Tools.TodoDetail(TodoId);
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                Classes.TodoItem TodoItem = DialogBox.TodoItem;
                TodoItem.Save();

                SelectedItem.SubItems[0].Text = TodoItem.ProjectName;
                SelectedItem.SubItems[1].Text = GetTodoItemText(TodoItem.Memo, (int)TodoItem.TodoId);
                SelectedItem.SubItems[2].Text = TodoItem.ProjectFolderName ?? "None";
                SelectedItem.SubItems[3].Text = Timekeeper.NullableDateForDisplay(TodoItem.StartTime);
                SelectedItem.SubItems[4].Text = Timekeeper.NullableDateForDisplay(TodoItem.DueTime);
                SelectedItem.SubItems[5].Text = TodoItem.StatusName;
                SelectedItem.Group = TodoList.Groups[GetGroupName(TodoItem)];
            }
        }

        //----------------------------------------------------------------------

        private long GetSelectedId()
        {
            if (TodoList.SelectedItems.Count > 0) {
                Classes.TodoItem TodoItem = (Classes.TodoItem)TodoList.SelectedItems[0].Tag;
                return TodoItem.TodoId;
            } else {
                return 0;
            }
        }

        //----------------------------------------------------------------------

        private void ViewLargeIcons()
        {
            TodoList.View = View.LargeIcon;

            PopupMenuTodoViewLargeIcons.Checked = true;
            PopupMenuTodoViewSmallIcons.Checked = false;
            PopupMenuTodoViewTiles.Checked = false;
            PopupMenuTodoViewList.Checked = false;
            PopupMenuTodoViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewSmallIcons()
        {
            TodoList.View = View.SmallIcon;

            PopupMenuTodoViewLargeIcons.Checked = false;
            PopupMenuTodoViewSmallIcons.Checked = true;
            PopupMenuTodoViewTiles.Checked = false;
            PopupMenuTodoViewList.Checked = false;
            PopupMenuTodoViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewTiles()
        {
            TodoList.View = View.Tile;

            PopupMenuTodoViewLargeIcons.Checked = false;
            PopupMenuTodoViewSmallIcons.Checked = false;
            PopupMenuTodoViewTiles.Checked = true;
            PopupMenuTodoViewList.Checked = false;
            PopupMenuTodoViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewList()
        {
            TodoList.View = View.List;

            PopupMenuTodoViewLargeIcons.Checked = false;
            PopupMenuTodoViewSmallIcons.Checked = false;
            PopupMenuTodoViewTiles.Checked = false;
            PopupMenuTodoViewList.Checked = true;
            PopupMenuTodoViewDetails.Checked = false;

            MirrorViewChecks();
        }

        private void ViewDetails()
        {
            TodoList.View = View.Details;

            PopupMenuTodoViewLargeIcons.Checked = false;
            PopupMenuTodoViewSmallIcons.Checked = false;
            PopupMenuTodoViewTiles.Checked = false;
            PopupMenuTodoViewList.Checked = false;
            PopupMenuTodoViewDetails.Checked = true;

            MirrorViewChecks();
        }

        //----------------------------------------------------------------------

        private void SetTodoItemStatus(long refTodoStatusId)
        {
            foreach (ListViewItem Item in TodoList.SelectedItems) {
                Classes.TodoItem TodoItem = (Classes.TodoItem)Item.Tag;
                TodoItem.UpdateStatus(refTodoStatusId);
                // Brute-force remove/re-add
                TodoList.Items.Remove(Item);
                string GroupName = GetGroupName(TodoItem);
                this.AddItem(TodoItem.ProjectName, TodoItem, TodoList.Groups[GroupName]);
            }
        }

        private void PopupMenuTodo_Opening(object sender, CancelEventArgs e)
        {
            ToggleHideMenuItem();
        }

        private void MenuTodoAction_DropDownOpening(object sender, EventArgs e)
        {
            ToggleHideMenuItem();
        }

        private void ToggleHideMenuItem()
        {
            if (TodoList.SelectedItems.Count > 0) {
                Classes.TodoItem SelectedItem = (Classes.TodoItem)(TodoList.SelectedItems[0]).Tag;
                MenuTodoActionHide.Visible = !SelectedItem.IsHidden;
                MenuTodoActionUnhide.Visible = SelectedItem.IsHidden;
                PopupMenuTodoHide.Visible = !SelectedItem.IsHidden;
                PopupMenuTodoUnhide.Visible = SelectedItem.IsHidden;
            }
        }

        private void TodoList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Translate date columns for proper date/time sorting

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == ColumnSorter.SortColumn) {
                // Reverse the current sort direction for this column.
                if (ColumnSorter.Order == SortOrder.Ascending) {
                    ColumnSorter.Order = SortOrder.Descending;
                } else {
                    ColumnSorter.Order = SortOrder.Ascending;
                }
            } else {
                // Set the column number that is to be sorted; default to ascending.
                ColumnSorter.SortColumn = e.Column;
                ColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.TodoList.Sort();
        }

        private void MenuTodoShowCompletedItems_Click(object sender, EventArgs e)
        {
            ShowCompletedItems(!MenuTodoShowCompletedItems.Checked);
        }

        private void ShowCompletedItems(bool show)
        {
            MenuTodoShowCompletedItems.Checked = show;
            PopupMenuTodoViewShowCompletedItems.Checked = MenuTodoShowCompletedItems.Checked;
            PopulateTodoList();
        }

        private void Todo_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {
                Options.Todo_Height = Height;
                Options.Todo_Width = Width;
                Options.Todo_Top = Top;
                Options.Todo_Left = Left;

                Options.Todo_ShowGroups = TodoList.ShowGroups;
                Options.Todo_ShowCompletedItems = MenuTodoShowCompletedItems.Checked;

                Options.Todo_IconView =
                    PopupMenuTodoViewLargeIcons.Checked ? 1 :
                    PopupMenuTodoViewSmallIcons.Checked ? 2 :
                    PopupMenuTodoViewTiles.Checked ? 3 :
                    PopupMenuTodoViewList.Checked ? 4 : 5;

                Options.Todo_ProjectNameWidth = TodoList.Columns[0].Width;
                Options.Todo_StartDateWidth = TodoList.Columns[1].Width;
                Options.Todo_DueDateWidth = TodoList.Columns[2].Width;
                Options.Todo_StatusWidth = TodoList.Columns[3].Width;

                Options.Todo_ProjectNameDisplayIndex = TodoList.Columns[0].DisplayIndex;
                Options.Todo_StartDateDisplayIndex = TodoList.Columns[1].DisplayIndex;
                Options.Todo_DueDateDisplayIndex = TodoList.Columns[2].DisplayIndex;
                Options.Todo_StatusDisplayIndex = TodoList.Columns[3].DisplayIndex;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        private void MenuTodoRefresh_Click(object sender, EventArgs e)
        {
            PopulateTodoList();
        }

        //----------------------------------------------------------------------

    }
}
