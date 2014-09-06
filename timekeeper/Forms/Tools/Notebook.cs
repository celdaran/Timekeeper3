using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Tools
{
    public partial class Notebook : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private Classes.Options Options;

        private Classes.NotebookEntry CurrentEntry;
        private Classes.NotebookEntry PreviousEntry;
        private Classes.NotebookEntryCollection AllEntries;

        private bool IsBrowsing;

        private bool IgnoreTextChanges = false;

        // MemoEditor control
        private Forms.Shared.MemoEditor MemoEditor;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Notebook()
        {
            InitializeComponent();
            this.Options = Timekeeper.Options;
        }

        //----------------------------------------------------------------------
        // Form Events
        //----------------------------------------------------------------------

        private void Notebook_Load(object sender, EventArgs e)
        {
            try {
                IgnoreTextChanges = true;

                // Instantiate any run-time only controls
                this.MemoEditor = new Forms.Shared.MemoEditor();
                this.MemoEditor.Parent = this.MainPanel;
                this.MemoEditor.BringToFront();
                this.MemoEditor.Dock = DockStyle.Fill;
                this.MemoEditor.TabIndex = 1;
                this.MemoEditor.RightMargin = Options.View_MemoEditor_RightMargin_Notebook;
                this.MemoEditor.MemoEntry.TextChanged += new System.EventHandler(this.MemoEditor_TextChanged);

                /*
                this.MemoEditor.MemoEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wMemo_KeyDown);
                */

                // Set up UI bits
                //LocationPanel.Visible = Options.Layout_UseLocations;
                //CategoryPanel.Visible = Options.Layout_UseCategories;
                EntryDateTime.CustomFormat = Options.Advanced_DateTimeFormat;

                //ControlPanel.Height = LocationPanel.Visible && CategoryPanel.Visible ? 64 : (64 - 27);

                this.Height = Options.Notebook_Height;
                this.Width = Options.Notebook_Width;
                this.Top = Options.Notebook_Top;
                this.Left = Options.Notebook_Left;

                // Create in-memory entries
                CurrentEntry = new Classes.NotebookEntry();
                PreviousEntry = new Classes.NotebookEntry();
                AllEntries = new Classes.NotebookEntryCollection();

                IsBrowsing = false;

                // Clear this out for starters
                ToolbarNotebookEntryId.Text = "";

                // Set up keyboard shortcuts.
                Action_SetShortcuts();

                // Now set toolbar state
                PaintToolbar();

                IgnoreTextChanges = false;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void Action_SetShortcuts()
        {
            try {
                foreach (NameObjectPair Pair in Options.Keyboard_FunctionList) {
                    ToolStripItem[] Items = NotebookMenu.Items.Find("Notebook" + Pair.Name, true);
                    if (Items.Length > 0) {
                        ToolStripMenuItem Item = (ToolStripMenuItem)Items[0];
                        Item.ShortcutKeys = (Keys)Pair.Object;
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

        private void Notebook_Shown(object sender, EventArgs e)
        {
            this.MemoEditor.Focus();
        }

        //----------------------------------------------------------------------

        private void Notebook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.ToolbarSave.Enabled == true) && (DialogResult != DialogResult.OK)) {
                if (Common.WarnPrompt("Notebook Entry has changed. Continue closing?") != DialogResult.Yes) {
                    e.Cancel = true;
                }
            }

            // Consider moving to new spot
            Options.Notebook_Height = this.Height;
            Options.Notebook_Width = this.Width;
            Options.Notebook_Top = this.Top;
            Options.Notebook_Left = this.Left;
            Options.View_MemoEditor_RightMargin_Notebook = this.MemoEditor.RightMargin;
        }

        //----------------------------------------------------------------------

        private void MemoEditor_TextChanged(object sender, EventArgs e)
        {
            //int i = 0;
            if (!IgnoreTextChanges) {
                EnableSaveButton(true);
            }
        }

        //----------------------------------------------------------------------

        private void EntryDateTime_ValueChanged(object sender, EventArgs e)
        {
            if (!IgnoreTextChanges) {
                EnableSaveButton(true);
            }
        }

        //----------------------------------------------------------------------
        // Menu (and Toolbar) Events
        //----------------------------------------------------------------------

        // MenuToolbarBrowserLast_Click

        private void MenuToolbarBrowserFirst_Click(object sender, EventArgs e)
        {
            IsBrowsing = true;

            SaveEntry();

            Row FirstEntryRow = AllEntries.FirstEntry();
            CurrentEntry = new Classes.NotebookEntry(FirstEntryRow["NotebookId"]);

            EntryToForm(CurrentEntry);

            PaintToolbar();
        }

        //----------------------------------------------------------------------

        private void MenuToolbarBrowserPrev_Click(object sender, EventArgs e)
        {
            IsBrowsing = true;

            SaveEntry();

            Row PreviousEntryRow = AllEntries.PreviousEntry(CurrentEntry);
            if (PreviousEntryRow["NotebookId"] != null) {
                CurrentEntry = new Classes.NotebookEntry(PreviousEntryRow["NotebookId"]);
                EntryToForm(CurrentEntry);
            }

            PaintToolbar();
        }

        //----------------------------------------------------------------------

        private void MenuToolbarBrowserNext_Click(object sender, EventArgs e)
        {
            IsBrowsing = true;

            SaveEntry();

            Row NextEntryRow = AllEntries.NextEntry(CurrentEntry);
            if (NextEntryRow["NotebookId"] != null) {
                CurrentEntry = new Classes.NotebookEntry(NextEntryRow["NotebookId"]);
                EntryToForm(CurrentEntry);
            }

            PaintToolbar();
        }

        //----------------------------------------------------------------------

        private void MenuToolbarBrowserLast_Click(object sender, EventArgs e)
        {
            IsBrowsing = true;

            SaveEntry();

            Row LastEntryRow = AllEntries.LastEntry();
            CurrentEntry = new Classes.NotebookEntry(LastEntryRow["NotebookId"]);

            EntryToForm(CurrentEntry);

            PaintToolbar();
        }

        //----------------------------------------------------------------------

        private void MenuToolbarBrowserNew_Click(object sender, EventArgs e)
        {
            IsBrowsing = false;

            SaveEntry();

            CurrentEntry = new Classes.NotebookEntry();
            EntryToForm(CurrentEntry);

            PaintToolbar();
        }

        //----------------------------------------------------------------------

        private void MenuToolbarBrowserFind_Click(object sender, EventArgs e)
        {
            Forms.Find FindDialog = new Forms.Find(Browser_GotoEntry, Find.FindDataSources.Notebook);
            FindDialog.Show();
        }

        //----------------------------------------------------------------------

        private void MenuToolbarBrowserSave_Click(object sender, EventArgs e)
        {
            SaveEntry();
            PaintToolbar();
        }

        //----------------------------------------------------------------------

        private void MenuToolbarBrowserRevert_Click(object sender, EventArgs e)
        {
            if (this.ToolbarSave.Enabled) {
                if (Common.WarnPrompt("Notebook Entry has changed. Continue reverting?") != DialogResult.Yes) {
                    return;
                }
            }
            CurrentEntry.Copy(PreviousEntry);
            SaveEntry();
            EntryToForm(CurrentEntry);
            EnableSaveButton(false);
        }

        //----------------------------------------------------------------------

        private void SaveEntry()
        {
            PreviousEntry.Copy(CurrentEntry);
            FormToEntry();

            if ((!ToolbarSave.Enabled) || (!IsBrowsing))
                return;

            if (CurrentEntry.Save()) {
                /*
                string Message = String.Format("Notebook entry saved.\n\nid={0}\ncreated={1}\nmodified={2}\nguid={3}",
                    CurrentEntry.NotebookId,
                    CurrentEntry.CreateTime,
                    CurrentEntry.ModifyTime,
                    CurrentEntry.NotebookGuid);
                Common.Info(Message);
                */
            } else {
                Common.Warn("Problem saving Notebook entry");
            }

            EnableSaveButton(false);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatBold_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatBoldButton_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatItalic_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatItalicButton_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatUnderline_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatUnderlineButton_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatStrikethrough_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatStrikethroughButton_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatBulletedList_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatBulletedListButton_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatNumberedList_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatNumberedListButton_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatHeading1_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatHeading1Button_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatHeading2_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatHeading2Button_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatHeading3_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatHeading3Button_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatCode_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatCodeButton_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatBlockquote_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatBlockquoteButton_Click(sender, e);
        }

        //----------------------------------------------------------------------

        private void MenuToolbarFormatHorizontalRule_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatHorizontalRuleButton_Click(sender, e);
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private void EntryToForm()
        {
            EntryToForm(CurrentEntry);
        }

        //----------------------------------------------------------------------

        private void EntryToForm(Classes.NotebookEntry entry)
        {
            IgnoreTextChanges = true;

            try {
                this.MemoEditor.Text = entry.Memo;
                this.EntryDateTime.Value = entry.EntryTime ==
                    DateTimeOffset.MinValue ? Timekeeper.LocalNow.DateTime : entry.EntryTime.DateTime;
                this.ToolbarNotebookEntryId.Text = entry.NotebookId.ToString();

                // FIXME: Serious copy/paste problems here.
                // You really need to fix that. This was
                // lifted directly from Main.Browser.cs.
                // Let's move this to the Widgets class

                /*
                if (entry.LocationId > 0) {
                    Classes.Location Location = new Classes.Location(entry.LocationId);
                    if (Location.Name != null) {
                        int LocationIndex = wLocation.FindString(Location.Name);
                        wLocation.SelectedIndex = LocationIndex;
                    } else {
                        wLocation.SelectedIndex = -1;
                    }
                } else {
                    wLocation.SelectedIndex = -1;
                }

                if (entry.CategoryId > 0) {
                    Classes.Category Category = new Classes.Category(entry.CategoryId);
                    if (Category.Name != null) {
                        int CategoryIndex = wCategory.FindString(Category.Name);
                        wCategory.SelectedIndex = CategoryIndex;
                    } else {
                        wCategory.SelectedIndex = -1;
                    }
                } else {
                    wCategory.SelectedIndex = -1;
                }
                */

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            IgnoreTextChanges = false;
        }

        //---------------------------------------------------------------------

        private void FormToEntry()
        {
            try {
                CurrentEntry.Memo = this.MemoEditor.Text;
                CurrentEntry.EntryTime = this.EntryDateTime.Value;

                // Location & Category support
                /*
                if (wLocation.SelectedIndex > -1) {
                    Classes.Location Location = (Classes.Location)((IdObjectPair)wLocation.SelectedItem).Object;
                    CurrentEntry.LocationId = Location.ItemId;
                }
                if (wCategory.SelectedIndex > -1) {
                    Classes.Category Category = (Classes.Category)((IdObjectPair)wCategory.SelectedItem).Object;
                    CurrentEntry.CategoryId = Category.ItemId;
                }
                */

                CurrentEntry.ProjectId = 1;
                CurrentEntry.ActivityId = 1;
                CurrentEntry.LocationId = 1;
                CurrentEntry.CategoryId = 1;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void PaintToolbar()
        {
            // The idea here is to paint the state of the toolbar at any 
            // given point: just opening the form, navigating, clicking
            // buttons that otherwise change button states, and so on.
            // I've already done this for the main Journal Entry browser,
            // but I'll take this opportunity to take another crack at it.
            // Wisdom lies in the journey.

            long Count = AllEntries.Count();

            //Count = 0; // <--- FOR TESTING

            if (Count == 0)
                return;

            if (IsBrowsing) 
            {
                ToolbarFirstEntry.Enabled = true;
                ToolbarPreviousEntry.Enabled = true;
                ToolbarNextEntry.Enabled = true;
                ToolbarLastEntry.Enabled = true;

                ToolbarNewEntry.Enabled = true;

                if (CurrentEntry.AtBeginning()) 
                {
                    ToolbarFirstEntry.Enabled = false;
                    ToolbarPreviousEntry.Enabled = false;
                }

                if (CurrentEntry.AtEnd()) 
                {
                    ToolbarNextEntry.Enabled = false;
                    ToolbarLastEntry.Enabled = false;
                }
            }
            else
            {
                // Then we haven't loaded up an entry
                // and therefore we're at a new entry
                // and therefore, we can navigate back
                ToolbarFirstEntry.Enabled = true;
                ToolbarPreviousEntry.Enabled = true;
                ToolbarFind.Enabled = true;

                ToolbarNewEntry.Enabled = false;
                ToolbarNotebookEntryId.Text = "";
            }

        }

        //---------------------------------------------------------------------

        private void EnableSaveButton(bool enabled)
            // FIXME: WRONG NAME, just not sure where this one is heading yet
        {
            ToolbarSave.Enabled = enabled;
            ToolbarRevert.Enabled = enabled;
        }

        //---------------------------------------------------------------------

        public void Browser_GotoEntry(long notebookId)
        {
            IsBrowsing = true;

            SaveEntry();

            CurrentEntry = new Classes.NotebookEntry(notebookId);
            EntryToForm(CurrentEntry);

            PaintToolbar();
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fToolJournal\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

        //---------------------------------------------------------------------

    }
}
