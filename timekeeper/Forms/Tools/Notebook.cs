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

        private bool IgnoreTextChanges = false;
        private bool IsDirty = false;
        private Classes.NotebookEntry NotebookEntry;

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
            IgnoreTextChanges = true;

            // Instantiate any run-time only controls
            this.MemoEditor = new Forms.Shared.MemoEditor();
            this.MemoEditor.Parent = EditPanel;
            this.MemoEditor.BringToFront();
            this.MemoEditor.Dock = DockStyle.Fill;
            this.MemoEditor.TabIndex = 1;
            this.MemoEditor.MemoEntry.TextChanged += new System.EventHandler(this.MemoEditor_TextChanged);

            /*
            this.MemoEditor.MemoEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.wMemo_KeyDown);
            */

            // Set up UI bits
            LocationPanel.Visible = Options.Layout_UseLocations;
            CategoryPanel.Visible = Options.Layout_UseCategories;
            EntryDateTime.CustomFormat = Options.Advanced_DateTimeFormat;

            this.Height = Options.Notebook_Height;
            this.Width = Options.Notebook_Width;
            this.Top = Options.Notebook_Top;
            this.Left = Options.Notebook_Left;

            // Populate form (wait, no. open up with a blank form)
            NotebookEntry = new Classes.NotebookEntry();
            //NotebookEntry.Load();
            //EntryToForm();

            IgnoreTextChanges = false;
        }

        //----------------------------------------------------------------------

        private void Notebook_Shown(object sender, EventArgs e)
        {
            this.MemoEditor.Focus();
        }

        //----------------------------------------------------------------------

        private void Notebook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((this.IsDirty == true) && (DialogResult != DialogResult.OK)) {
                if (Common.WarnPrompt("Notebook Entry has changed. Continue closing?") != DialogResult.Yes) {
                    e.Cancel = true;
                }
            }
            Options.Notebook_Height = this.Height;
            Options.Notebook_Width = this.Width;
            Options.Notebook_Top = this.Top;
            Options.Notebook_Left = this.Left;
        }

        //----------------------------------------------------------------------

        private void MemoEditor_TextChanged(object sender, EventArgs e)
        {
            if (!IgnoreTextChanges) {
                EnableToolbar(true);
            }
        }

        //----------------------------------------------------------------------
        // Menu (and Toolbar) Events
        //----------------------------------------------------------------------

        private void MenuToolbarSave_Click(object sender, EventArgs e)
        {
            FormToEntry();

            if (NotebookEntry.Save()) {
                string Message = String.Format("Notebook entry saved.\n\nid={0}\ncreated={1}\nmodified={2}\nguid={3}",
                    NotebookEntry.NotebookId,
                    NotebookEntry.CreateTime,
                    NotebookEntry.ModifyTime,
                    NotebookEntry.NotebookGuid);
                Common.Info(Message);
            } else {
                Common.Warn("Problem saving Notebook entry");
            }

            EnableToolbar(false);
        }

        //----------------------------------------------------------------------

        private void MenuFormatBold_Click(object sender, EventArgs e)
        {
            this.MemoEditor.FormatBoldButton_Click(sender, e);
        }

        //----------------------------------------------------------------------
        // Helpers
        //----------------------------------------------------------------------

        private void EntryToForm()
        {
            try {
                this.MemoEditor.Text = NotebookEntry.Memo;
                this.EntryDateTime.Value = NotebookEntry.EntryTime;
                this.ToolbarNotebookEntryId.Text = NotebookEntry.NotebookId.ToString();
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void FormToEntry()
        {
            try {
                NotebookEntry.Memo = this.MemoEditor.Text;
                NotebookEntry.EntryTime = this.EntryDateTime.Value;
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        private void EnableToolbar(bool enabled)
            // FIXME: WRONG NAME, just not sure where this one is heading yet
        {
            ToolbarSave.Enabled = enabled;
            ToolbarRevert.Enabled = enabled;
            IsDirty = enabled;
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
