using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    partial class Widgets
    {
        //----------------------------------------------------------------------
        // Notes
        //----------------------------------------------------------------------

        public void PopulateLoadMenu(string tableName, ToolStrip toolbar)
        {
            // Get our buttons
            ToolStripDropDownButton LoadViewMenuButton = (ToolStripDropDownButton)toolbar.Items["LoadViewMenuButton"];
            ToolStripButton ManageViewsButton = (ToolStripButton)toolbar.Items["ManageViewsButton"];

            // Reset UI
            LoadViewMenuButton.DropDownItems.Clear();
            LoadViewMenuButton.Enabled = false;
            ManageViewsButton.Enabled = false;

            // Now grab new entries
            List<Classes.BaseView> BaseViews = new Classes.BaseViewCollection(tableName).Fetch();
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
