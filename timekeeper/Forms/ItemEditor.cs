using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper
{
    public partial class ItemEditor : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private string TableName;

        private bool ClickedCancel = false;
        private string PreviousItemName = "";
        private string PreviousExternalProjectNo = null;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ItemEditor(string tableName)
        {
            InitializeComponent();

            this.TableName = tableName;
            this.PopulateParents();

            if (tableName == "Project") {
                //this.Project = new Project(database);
            } else {
                //this.Activity = new Activity(database);
                ExternalProjectNoLabel.Visible = false;
                ItemExternalProjectNo.Visible = false;
                this.Height -= 30;
            }
        }

        //---------------------------------------------------------------------
        // Event Handlers
        //---------------------------------------------------------------------

        private void ItemEditor_Load(object sender, EventArgs e)
        {
            PreviousItemName = ItemName.Text;
            PreviousExternalProjectNo = ItemExternalProjectNo.Text;
        }

        //----------------------------------------------------------------------

        private void ItemEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ClickedCancel) {
                return;
            }

            if (ItemName.Text == "") {
                Common.Warn("Name cannot be blank.");
                e.Cancel = true;
                return;
            }

            string Messages = "";

            if (this.TableName == "Project") {
                if (PreviousItemName != ItemName.Text) {
                    Classes.Project Project = new Classes.Project(ItemName.Text);
                    if (ItemName.Text == Project.Name) {
                        Messages += this.TableName + " '" + ItemName.Text + "' already exists." + Environment.NewLine;
                    }
                }

                if (PreviousExternalProjectNo != ItemExternalProjectNo.Text) {
                    Classes.ProjectCollection Projects = new Classes.ProjectCollection();
                    if (Projects.ExternalProjectNoExists(ItemExternalProjectNo.Text)) {
                        Messages += "External ID '" + ItemExternalProjectNo.Text + "' already exists." + Environment.NewLine;
                    }
                }

                if (ItemExternalProjectNo.Text == "") {
                    ItemExternalProjectNo.Text = null;
                }
            }

            if (this.TableName == "Activity") {
                if (PreviousItemName != ItemName.Text) {
                    Classes.Activity Activity = new Classes.Activity(ItemName.Text);
                    if (ItemName.Text == Activity.Name) {
                        Messages += this.TableName + " already exists." + Environment.NewLine;
                    }
                }
            }

            if (Messages != "") {
                Common.Warn(Messages);
                e.Cancel = true;
            }

        }

        //----------------------------------------------------------------------

        private void AcceptDialog_Click(object sender, EventArgs e)
        {
            ClickedCancel = false;
        }

        //----------------------------------------------------------------------

        private void CancelDialog_Click(object sender, EventArgs e)
        {
            ClickedCancel = true;
        }

        //----------------------------------------------------------------------
        // Private Helpers
        //----------------------------------------------------------------------

        private void PopulateParents()
        {
            Table ParentList = new Classes.TreeAttributeCollection(this.TableName, "CreateTime").GetFolders();
            IdValuePair Pair = new IdValuePair(-1, "(Top Level)");

            ItemParent.Items.Add(Pair);
            foreach (Row Row in ParentList) {
                Pair = new IdValuePair((int)Row["Id"], Row["Name"]);
                ItemParent.Items.Add(Pair);
            }
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string Topic = String.Format("html\\context\\ItemEditor\\{0}.html", c.Name);
            Timekeeper.Info("Calling help topic: " + Topic);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, Topic);
        }

    }
}