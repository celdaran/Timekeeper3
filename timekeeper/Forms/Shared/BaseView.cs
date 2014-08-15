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
    public partial class BaseView : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        internal Classes.FilterOptions.OptionsType FilterOptionsType;
        internal string ViewName { get; set; }
        internal string TableName { get; set; }
        internal long LastViewId { get; set; }

        public delegate void BrowserCallback(long entryId);
        internal BrowserCallback Browser_GotoEntry;

        internal dynamic CurrentView { get; set; }
        internal dynamic AutoSavedView { get; set; }
        internal dynamic CurrentViewEmpty { get; set; }
        internal dynamic AutoSavedViewEmpty { get; set; }

        internal Classes.Options Options;
        internal Classes.Widgets Widgets;

        //---------------------------------------------------------------------

        private Forms.Shared.Filtering FilterDialog;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public BaseView()
        {
            // NEVER add anything to this.
            // That includes constructor arguments.
            // You'll be sorry.
            InitializeComponent();
        }

        //---------------------------------------------------------------------

        public void Initialize()
        {
            // internal attributes
            this.Options = Timekeeper.Options;
            this.Widgets = new Classes.Widgets();

            // this used to be the OnLoad event handler, except
            // that was throwing Visual Studio designer on the
            // child forms into a tizzy.
            try {
                // Load up saved view and paint
                switch (this.FilterOptionsType) {
                    case Classes.FilterOptions.OptionsType.Calendar:
                        this.LastViewId = Options.State_LastCalendarViewId;
                        break;
                    case Classes.FilterOptions.OptionsType.PunchCard:
                        this.LastViewId = Options.State_LastPunchCardViewId;
                        break;
                }
                LoadAndRunView(this.LastViewId);

                if (CurrentView.IsAutoSaved) {
                    CurrentView.Changed = true;
                }

                // Populate the list of Saved Views
                PopulateLoadMenu();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------
        // Form Events
        //---------------------------------------------------------------------

        private void BaseView_Load(object sender, EventArgs e)
        {
            // Use Initialize() instead
        }

        //---------------------------------------------------------------------

        private void BaseView_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CurrentView.Changed) {
                string Warning = String.Format("{0} view has not been saved. Continue closing?", this.ViewName);
                if (Common.WarnPrompt(Warning) == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
            }
        }

        //---------------------------------------------------------------------
        // Toolbar Events
        //---------------------------------------------------------------------

        private void FilterButton_Click(object sender, EventArgs e)
        {
            CurrentView.FilterOptions.FilterOptionsType = this.FilterOptionsType;
            CurrentView.FilterOptions.FilterMergeType = null;

            this.FilterDialog = new Forms.Shared.Filtering(CurrentView.FilterOptions);

            CurrentView.FilterOptions = this.Widgets.FilteringDialog(this,
                FilterDialog, CurrentView.FilterOptions.FilterOptionsId);

            if (CurrentView.FilterOptions.Changed) {
                CurrentView.Changed = true;
                RunView();
            }
        }

        //---------------------------------------------------------------------

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunView(false);
        }

        //---------------------------------------------------------------------

        private void LoadViewButton_Click(object sender, EventArgs e)
        {
            ToolStripItem Item = (ToolStripItem)sender;
            Classes.BaseView View = (Classes.BaseView)Item.Tag;
            LoadAndRunView(View.Id);
        }

        //----------------------------------------------------------------------

        private void SaveViewButton_Click(object sender, EventArgs e)
        {
            // Save view
            CurrentView.Save(CurrentView.FilterOptions.Changed, CurrentView.FilterOptions.FilterOptionsId);

            // Post-save steps
            CurrentView.Changed = false;
            this.Widgets.SetViewTitleBar(this, this.ViewName, CurrentView.Name);
        }

        //----------------------------------------------------------------------

        private void SaveViewAsButton_Click(object sender, EventArgs e)
        {
            CurrentView = (Classes.BaseView)this.Widgets.SaveViewDialog(this, this.ViewName, CurrentView);
            if (CurrentView.Changed) {
                CurrentView.Save(true);
                CurrentView.Changed = false;
                PopulateLoadMenu();
                UpdateToolbar();
                this.LastViewId = CurrentView.Id;
            }
        }

        //----------------------------------------------------------------------

        private void ClearViewButton_Click(object sender, EventArgs e)
        {
            if (this.Widgets.ClearViewCancelled(CurrentView.Changed)) {
                return;
            }

            CurrentView = this.CurrentViewEmpty;

            this.Widgets.SetViewTitleBar(this, this.ViewName);

            LoadAndRunView(0);
        }

        //----------------------------------------------------------------------

        private void ManageViewsButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.ManageViews DialogBox = new Forms.Shared.ManageViews(this.TableName);
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------
        // Internal Helpers
        //----------------------------------------------------------------------

        private void UpdateViewState(bool autoSaveView)
        {
            if ((CurrentView.Id == 0) || CurrentView.IsAutoSaved) {
                if (autoSaveView) {
                    AutoSaveView();
                }
            } else {
                if (CurrentView.Changed) {
                    this.Widgets.SetViewTitleBar(this, this.ViewName, CurrentView.Name + "*");
                }
            }
            UpdateToolbar();
        }

        //----------------------------------------------------------------------

        private void AutoSaveView()
        {
            AutoSavedView = this.AutoSavedViewEmpty;

            bool NewView = false;

            if (AutoSavedView.Id == 0) {
                // This is the first time; so seed the new view
                AutoSavedView.Name = "Unsaved View";
                AutoSavedView.Description = "Unnamed, last-applied view";
                NewView = true;
            }

            // Overwrite FilterOptions with current FilterOptions
            long SavedFilterOptionsId = AutoSavedView.FilterOptions.FilterOptionsId;
            AutoSavedView.FilterOptions = CurrentView.FilterOptions;
            if (CurrentView.FilterOptions.FilterOptionsId > 0) {
                AutoSavedView.FilterOptions.FilterOptionsId = CurrentView.FilterOptions.FilterOptionsId;
            } else {
                AutoSavedView.FilterOptions.FilterOptionsId = SavedFilterOptionsId;
            }

            // Overwrite Find-specific settings with current UI values
            // (none (yet))

            // Now attempt to save (this is an upsert)
            if (AutoSavedView.Save(CurrentView.FilterOptions.Changed, AutoSavedView.FilterOptions.FilterOptionsId)) {
                // Make sure the Last Saved ID is the current value
                this.LastViewId = AutoSavedView.Id;

                // And copy it back into the current grid options
                CurrentView = AutoSavedView;

                // Although this has technically been saved to the DB, treat it as though it hasn't
                CurrentView.Changed = true;

                // Update title bar
                this.Widgets.SetViewTitleBar(this, this.ViewName, CurrentView.Name);
            } else {
                Timekeeper.Debug("Options not saved in AutoSaveView()");
            }

            if (NewView) {
                PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------

        private void UpdateToolbar()
        {
            bool HasEntries = this.Widgets.UpdateToolbar(ToolStrip, (Classes.BaseView)CurrentView);
        }

        //----------------------------------------------------------------------

        private void PopulateLoadMenu()
        {
            this.Widgets.PopulateLoadMenu(this.TableName, ToolStrip);

            foreach (ToolStripItem Item in LoadViewMenuButton.DropDownItems) {
                Item.Click += new System.EventHandler(this.LoadViewButton_Click);
            }
        }

        //----------------------------------------------------------------------
        // Wrapper for the gridfind loading logic, followed by the actual 
        // running of the Find code.
        //----------------------------------------------------------------------

        private void LoadAndRunView(long calenderViewId)
        {
            if (calenderViewId > 0) {
                // Load Last Saved Options
                CurrentView.Load(calenderViewId);

                CurrentView.FilterOptions.FilterMergeType = null;

                // This requires some explanation. It's definitely a hack but something
                // for which I don't currently have the time or energy to handle otherwise.
                // In short, the tree handling logic lies within the Filtering dialog box,
                // including the ImpliedProjects and ImpliedActivities. These structures
                // are the result of looking at the actually-checked values in the treeview
                // controls and returning the list of ProjectId and ActivityId values that
                // are implied by the checkboxes. This information is required to properly
                // paint a just-loaded grid and it only lives in Forms.Shared.Filtering.
                // If we instantiate this form here, right after loading up a saved grid
                // view, then everything Just Works.

                this.FilterDialog = new Forms.Shared.Filtering(CurrentView.FilterOptions);

                // Reflect loaded view in Title Bar
                this.Widgets.SetViewTitleBar(this, this.ViewName, CurrentView.Name);

                // Set this as the last run ID
                this.LastViewId = calenderViewId;

                RunView(false);
            } else {
                UpdateToolbar();
                RunView(false);
            }
        }

        //----------------------------------------------------------------------

        private void RunView()
        {
            RunView(true);
        }

        //---------------------------------------------------------------------

        private void RunView(bool autoSaveView)
        {
            PopulateData();
            UpdateViewState(autoSaveView);
        }

        //---------------------------------------------------------------------

        internal virtual void PopulateData()
        {
            Timekeeper.DoubleWarn("You must override PopulateData()");
        }

        //---------------------------------------------------------------------
        // Leftovers
        //---------------------------------------------------------------------

        private void GoToEntry(long entryId)
        {
            this.Browser_GotoEntry(entryId);
        }

        //---------------------------------------------------------------------
        // End of Class
        //---------------------------------------------------------------------

    }
}
