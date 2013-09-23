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

        public Classes.FilterOptions FilteringDialog(Form window, Forms.Shared.Filtering filterDialog, long filterOptionsId)
        {
            Classes.FilterOptions BeforeFilterOptions = new Classes.FilterOptions(filterOptionsId);
            Classes.FilterOptions ReturnFilterOptions = new Classes.FilterOptions();

            if (filterDialog.ShowDialog(window) == DialogResult.OK) {
                if (BeforeFilterOptions.Equals(filterDialog.FilterOptions)) {
                    Common.Info("You didn't make no changes!");
                    ReturnFilterOptions.Copy(BeforeFilterOptions);
                    ReturnFilterOptions.Changed = false;
                } else {
                    Common.Info("You made some changes!");
                    ReturnFilterOptions.Copy(filterDialog.FilterOptions);
                    ReturnFilterOptions.Changed = true;
                }
            }

            return ReturnFilterOptions;
        }

        //----------------------------------------------------------------------

        public int PopulateLoadMenu(string tableName, ToolStrip toolbar)
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

            return BaseViews.Count;
        }

        //----------------------------------------------------------------------

        public Classes.BaseView SaveViewDialog(Form window, string viewType, Classes.BaseView view)
        {
            Classes.BaseView View = view;

            Forms.Shared.SaveView DialogBox = new Forms.Shared.SaveView(viewType + "View", view.Changed);
            DialogBox.ViewName.Text = View.Name;
            DialogBox.ViewDescription.Text = View.Description;

            if (DialogBox.ShowDialog(window) == DialogResult.OK) {
                View.Name = DialogBox.ViewName.Text;
                View.Description = DialogBox.ViewDescription.Text;
                SetViewTitleBar(window, viewType, View.Name);
                View.Changed = true;
            } else {
                View.Changed = false;
            }
            return View;
        }

        //----------------------------------------------------------------------

        public void SetViewTitleBar(System.Windows.Forms.Form window, string windowTitle)
        {
            SetViewTitleBar(window, windowTitle, null);
        }

        //----------------------------------------------------------------------

        public void SetViewTitleBar(System.Windows.Forms.Form window, string windowTitle, string viewName)
        {
            // TODO: Make this format user-definable (like the app title bar)
            if (viewName == null) {
                window.Text = String.Format("{0} {1}", Timekeeper.TITLE, windowTitle);
            } else {
                window.Text = String.Format("{0} {1} - {2}", Timekeeper.TITLE, windowTitle, viewName);
            }
        }

        //----------------------------------------------------------------------

        public bool ViewExists(string tableName, string viewName, bool isDirty)
        {
            Classes.BaseViewCollection Views = new Classes.BaseViewCollection(tableName);
            if (Views.ViewExists(viewName)) {
                if (isDirty) {
                    return false;
                } else {
                    Common.Warn("A view with that name already exists.");
                    return true;
                }
            } else {
                return false;
            }
        }

        //----------------------------------------------------------------------

    }
}
