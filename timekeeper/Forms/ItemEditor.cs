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

        private DBI Database;
        private string Table;

        private bool ClickedCancel = false;
        private string PreviousItemName = "";
        private string PreviousExternalProjectNo = "";

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public ItemEditor(DBI database, string table)
        {
            InitializeComponent();

            this.Database = database;
            this.Table = table;
            this.PopulateParents();

            if (table == "Project") {
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

            if (this.Table == "Project") {
                if (PreviousItemName != ItemName.Text) {
                    Classes.Project Project = new Classes.Project(this.Database, ItemName.Text);
                    if (ItemName.Text == Project.Name) {
                        Messages += this.Table + " '" + ItemName.Text + "' already exists." + Environment.NewLine;
                    }
                }

                if (PreviousExternalProjectNo != ItemExternalProjectNo.Text) {
                    Classes.ProjectCollection Projects = new Classes.ProjectCollection(this.Database);
                    if (Projects.ExternalProjectNoExists(ItemExternalProjectNo.Text)) {
                        Messages += "External ID '" + ItemExternalProjectNo.Text + "' already exists." + Environment.NewLine;
                    }
                }

                if (ItemExternalProjectNo.Text == "") {
                    ItemExternalProjectNo.Text = UUID.Get();
                }
            }

            if (this.Table == "Activity") {
                if (PreviousItemName != ItemName.Text) {
                    Classes.Activity Activity = new Classes.Activity(this.Database, ItemName.Text);
                    if (ItemName.Text == Activity.Name) {
                        Messages += this.Table + " already exists." + Environment.NewLine;
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
            // FIXME: This Order By clause should honor the Timekeeper.Options global "order" setting
            string Query = String.Format(
                @"select * from {0} where IsDeleted = 0 and IsHidden = 0 and IsFolder = 1 order by CreateTime", this.Table);
            Table Table = Database.Select(Query);
            ItemParent.Items.Add("(Top Level)");
            foreach (Row Row in Table) {
                ItemParent.Items.Add(Row["Name"]);
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