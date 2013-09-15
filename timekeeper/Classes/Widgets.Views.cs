using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    partial class Widgets
    {
        //----------------------------------------------------------------------
        // Consider making this a partial class and breaking it up by area. For
        // example TreeView functions in one file, what I'm about to do next in
        // another file and so on.
        //
        // . . . done!
        //----------------------------------------------------------------------

        /* 

        I don't think this one is worth the trouble

        public bool SaveView(System.Windows.Forms.Form parent, ToolStrip toolbar)
        {
            Forms.Shared.SaveView DialogBox = new Forms.Shared.SaveView();
            if (DialogBox.ShowDialog(parent) == DialogResult.OK) {
                GridView.Name = DialogBox.wName.Text;
                GridView.Description = DialogBox.wDescription.Text;
                GridView.Save();
                PopulateLoadMenu(toolbar);
                SetViewTitleBar(parent, "Grid", GridView.Name);
            }
        }
        */

        //----------------------------------------------------------------------

        public void PopulateLoadMenu(ToolStrip toolbar)
        {
            // Get our buttons
            ToolStripDropDownButton LoadViewMenuButton = (ToolStripDropDownButton)toolbar.Items["LoadViewMenuButton"];
            ToolStripButton ManageViewsButton = (ToolStripButton)toolbar.Items["ManageViewsButton"];

            // Reset UI
            LoadViewMenuButton.DropDownItems.Clear();
            LoadViewMenuButton.Enabled = false;
            ManageViewsButton.Enabled = false;

            // Now grab new entries
            List<Classes.BaseView> BaseViews = new Classes.BaseViewCollection("GridView").Fetch();
            foreach (Classes.BaseView BaseView in BaseViews) {
                ToolStripItem Item = LoadViewMenuButton.DropDownItems.Add(BaseView.Name);
                Item.Tag = BaseView;
                Item.ToolTipText = BaseView.Description;
            }

            // Update UI
            if (BaseViews.Count > 0) {
                LoadViewMenuButton.Enabled = true;
                ManageViewsButton.Enabled = true;
            }
        }

        //----------------------------------------------------------------------

        public void SetViewTitleBar(System.Windows.Forms.Form window, string windowTitle, string viewName)
        {
            window.Text = String.Format("Timekeeper {0} ({1})", windowTitle, viewName);
        }

        //----------------------------------------------------------------------

        public bool ViewExists(string tableName, string viewName)
        {
            Classes.BaseViewCollection Views = new Classes.BaseViewCollection(tableName);
            if (Views.ViewExists(viewName)) {
                Common.Warn("A view with that name already exists.");
                return true;
            } else {
                return false;
            }
        }

        //----------------------------------------------------------------------

    }
}
