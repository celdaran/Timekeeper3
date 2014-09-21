using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    partial class Widgets
    {

        private long ViewCount;

        //----------------------------------------------------------------------
        // Notes
        //----------------------------------------------------------------------

        public bool ClearViewCancelled(bool changed)
        {
            if (changed) {
                if (Common.WarnPrompt("Current view has not been saved. Continue clearing?") == DialogResult.No) {
                    return true;
                }
            }
            return false;
        }

        //----------------------------------------------------------------------

        public Classes.FilterOptions FilteringDialog(Form window, Forms.Shared.Filtering filterDialog, long filterOptionsId)
        {
            Classes.FilterOptions BeforeFilterOptions = new Classes.FilterOptions(filterOptionsId);
            Classes.FilterOptions ReturnFilterOptions = new Classes.FilterOptions();

            if (filterDialog.ShowDialog(window) == DialogResult.OK) 
            {
                if (BeforeFilterOptions.Equals(filterDialog.FilterOptions)) {
                    Timekeeper.Debug("You didn't make no changes!");
                    ReturnFilterOptions.Copy(BeforeFilterOptions);
                    ReturnFilterOptions.Changed = false;
                } else {
                    Timekeeper.Debug("You made some changes!");
                    ReturnFilterOptions.Copy(filterDialog.FilterOptions);
                    ReturnFilterOptions.Changed = true;
                }
            } else {
                ReturnFilterOptions.Copy(BeforeFilterOptions);
                ReturnFilterOptions.Changed = false;
            }

            return ReturnFilterOptions;
        }

        //----------------------------------------------------------------------

        public long PopulateLoadMenu(string tableName, ToolStrip toolbar)
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

            this.ViewCount = BaseViews.Count;

            return this.ViewCount;
        }

        //----------------------------------------------------------------------

        public Classes.BaseView SaveViewDialog(Form window, string viewType, Classes.BaseView view)
        {
            Classes.BaseView View = view;

            Forms.Shared.SaveView DialogBox = new Forms.Shared.SaveView(viewType + "View", view.Changed);

            if (!view.IsAutoSaved) {
                // Prepopulate the box with the current name and description
                // as long as it isn't an AutoSaved view
                DialogBox.ViewName.Text = View.Name;
                DialogBox.ViewDescription.Text = View.Description;
            }

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
                //window.Text = String.Format("{0} {1}", Timekeeper.TITLE, windowTitle);
                window.Text = String.Format("{0}", windowTitle);
            } else {
                //window.Text = String.Format("{0} {1} - {2}", Timekeeper.TITLE, windowTitle, viewName);
                window.Text = String.Format("{0} - {1}", windowTitle, viewName);
            }
        }

        //----------------------------------------------------------------------

        public bool UpdateToolbar(ToolStrip toolbar, Classes.BaseView view)
        {
            Classes.JournalEntryCollection JournalEntries = new Classes.JournalEntryCollection();

            bool HasEntries = (JournalEntries.Count() > 0);

            // Get our buttons
            ToolStripButton FilterButton = (ToolStripButton)toolbar.Items["FilterButton"];
            ToolStripButton RefreshButton = (ToolStripButton)toolbar.Items["RefreshButton"];

            ToolStripButton ClearViewButton = (ToolStripButton)toolbar.Items["ClearViewButton"];
            ToolStripDropDownButton LoadViewMenuButton = (ToolStripDropDownButton)toolbar.Items["LoadViewMenuButton"];
            ToolStripButton SaveViewButton = (ToolStripButton)toolbar.Items["SaveViewButton"];
            ToolStripButton SaveViewAsButton = (ToolStripButton)toolbar.Items["SaveViewAsButton"];
            ToolStripButton ManageViewsButton = (ToolStripButton)toolbar.Items["ManageViewsButton"];

            // FIXME: handle conditionally present buttons
            //ToolStripButton PrintMenuButton = (ToolStripButton)toolbar.Items["PrintMenuButton"];

            FilterButton.Enabled = HasEntries;
            RefreshButton.Enabled = HasEntries;

            ClearViewButton.Enabled = (view.Id > 0);
            LoadViewMenuButton.Enabled = (this.ViewCount > 0);
            SaveViewButton.Enabled = (view.Changed && !view.IsAutoSaved);
            SaveViewAsButton.Enabled = HasEntries;
            ManageViewsButton.Enabled = (this.ViewCount > 0);

            //PrintMenuButton.Enabled = HasEntries;

            // Special handling
            if (view.Id == 0) {
                SaveViewButton.Enabled = false;
                SaveViewAsButton.Enabled = false;
            }

            // In case the caller needs this info
            return HasEntries;
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
