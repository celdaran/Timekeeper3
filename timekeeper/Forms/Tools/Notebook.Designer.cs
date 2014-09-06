namespace Timekeeper.Forms.Tools
{
    partial class Notebook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Notebook));
            this.EntryDateTime = new System.Windows.Forms.DateTimePicker();
            this.DateLabel = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ToolbarFirstEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarPreviousEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarNextEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarLastEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarNewEntry = new System.Windows.Forms.ToolStripButton();
            this.ToolbarNotebookEntryId = new System.Windows.Forms.ToolStripLabel();
            this.ToolbarSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolbarFind = new System.Windows.Forms.ToolStripButton();
            this.ToolbarSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolbarSave = new System.Windows.Forms.ToolStripButton();
            this.ToolbarRevert = new System.Windows.Forms.ToolStripButton();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.NotebookMenu = new System.Windows.Forms.MenuStrip();
            this.NotebookMenuToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarBrowser = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarBrowserFirst = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarBrowserPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarBrowserNext = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarBrowserLast = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarBrowserNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.NotebookMenuToolbarBrowserSave = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarBrowserRevert = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatBold = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatItalic = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatUnderline = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatStrikethrough = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.NotebookMenuToolbarFormatBulletedList = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatNumberedList = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatSep2 = new System.Windows.Forms.ToolStripSeparator();
            this.NotebookMenuToolbarFormatHeading1 = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatHeading2 = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatHeading3 = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatSep3 = new System.Windows.Forms.ToolStripSeparator();
            this.NotebookMenuToolbarFormatCode = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatBlockQuote = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuToolbarFormatHorizontalRule = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuAction = new System.Windows.Forms.ToolStripMenuItem();
            this.NotebookMenuActionFind = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1.SuspendLayout();
            this.ControlPanel.SuspendLayout();
            this.NotebookMenu.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // EntryDateTime
            // 
            this.EntryDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EntryDateTime.Location = new System.Drawing.Point(41, 6);
            this.EntryDateTime.Name = "EntryDateTime";
            this.EntryDateTime.Size = new System.Drawing.Size(148, 20);
            this.EntryDateTime.TabIndex = 2;
            this.EntryDateTime.ValueChanged += new System.EventHandler(this.EntryDateTime_ValueChanged);
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(5, 8);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(33, 13);
            this.DateLabel.TabIndex = 0;
            this.DateLabel.Text = "Date:";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolbarFirstEntry,
            this.ToolbarPreviousEntry,
            this.ToolbarNextEntry,
            this.ToolbarLastEntry,
            this.ToolbarNewEntry,
            this.ToolbarNotebookEntryId,
            this.ToolbarSep1,
            this.ToolbarFind,
            this.ToolbarSep2,
            this.ToolbarSave,
            this.ToolbarRevert});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(423, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "Notebook";
            // 
            // ToolbarFirstEntry
            // 
            this.ToolbarFirstEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarFirstEntry.Enabled = false;
            this.ToolbarFirstEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonFirst;
            this.ToolbarFirstEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarFirstEntry.Name = "ToolbarFirstEntry";
            this.ToolbarFirstEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarFirstEntry.Text = "|<";
            this.ToolbarFirstEntry.ToolTipText = "Go to First Entry";
            this.ToolbarFirstEntry.Click += new System.EventHandler(this.MenuToolbarBrowserFirst_Click);
            // 
            // ToolbarPreviousEntry
            // 
            this.ToolbarPreviousEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarPreviousEntry.Enabled = false;
            this.ToolbarPreviousEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonPrev;
            this.ToolbarPreviousEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarPreviousEntry.Name = "ToolbarPreviousEntry";
            this.ToolbarPreviousEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarPreviousEntry.Text = "<<";
            this.ToolbarPreviousEntry.ToolTipText = "Go to Previous Entry";
            this.ToolbarPreviousEntry.Click += new System.EventHandler(this.MenuToolbarBrowserPrev_Click);
            // 
            // ToolbarNextEntry
            // 
            this.ToolbarNextEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarNextEntry.Enabled = false;
            this.ToolbarNextEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonNext;
            this.ToolbarNextEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarNextEntry.Name = "ToolbarNextEntry";
            this.ToolbarNextEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarNextEntry.Text = ">>";
            this.ToolbarNextEntry.ToolTipText = "Go to Next Entry";
            this.ToolbarNextEntry.Click += new System.EventHandler(this.MenuToolbarBrowserNext_Click);
            // 
            // ToolbarLastEntry
            // 
            this.ToolbarLastEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarLastEntry.Enabled = false;
            this.ToolbarLastEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonLast;
            this.ToolbarLastEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarLastEntry.Name = "ToolbarLastEntry";
            this.ToolbarLastEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarLastEntry.Text = ">|";
            this.ToolbarLastEntry.ToolTipText = "Go to Last Entry";
            this.ToolbarLastEntry.Click += new System.EventHandler(this.MenuToolbarBrowserLast_Click);
            // 
            // ToolbarNewEntry
            // 
            this.ToolbarNewEntry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarNewEntry.Enabled = false;
            this.ToolbarNewEntry.Image = global::Timekeeper.Properties.Resources.ImageButtonNew;
            this.ToolbarNewEntry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarNewEntry.Name = "ToolbarNewEntry";
            this.ToolbarNewEntry.Size = new System.Drawing.Size(23, 22);
            this.ToolbarNewEntry.Text = "New Entry";
            this.ToolbarNewEntry.ToolTipText = "Go to New Entry";
            this.ToolbarNewEntry.Click += new System.EventHandler(this.MenuToolbarBrowserNew_Click);
            // 
            // ToolbarNotebookEntryId
            // 
            this.ToolbarNotebookEntryId.Enabled = false;
            this.ToolbarNotebookEntryId.Name = "ToolbarNotebookEntryId";
            this.ToolbarNotebookEntryId.Size = new System.Drawing.Size(37, 22);
            this.ToolbarNotebookEntryId.Text = "12345";
            // 
            // ToolbarSep1
            // 
            this.ToolbarSep1.Name = "ToolbarSep1";
            this.ToolbarSep1.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolbarFind
            // 
            this.ToolbarFind.Enabled = false;
            this.ToolbarFind.Image = global::Timekeeper.Properties.Resources.ImageButtonFilter;
            this.ToolbarFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarFind.Name = "ToolbarFind";
            this.ToolbarFind.Size = new System.Drawing.Size(47, 22);
            this.ToolbarFind.Text = "Find";
            this.ToolbarFind.ToolTipText = "Find Entries";
            this.ToolbarFind.Click += new System.EventHandler(this.MenuToolbarBrowserFind_Click);
            // 
            // ToolbarSep2
            // 
            this.ToolbarSep2.Name = "ToolbarSep2";
            this.ToolbarSep2.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolbarSave
            // 
            this.ToolbarSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarSave.Enabled = false;
            this.ToolbarSave.Image = global::Timekeeper.Properties.Resources.ImageButtonSave;
            this.ToolbarSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarSave.Name = "ToolbarSave";
            this.ToolbarSave.Size = new System.Drawing.Size(23, 22);
            this.ToolbarSave.Text = "Save";
            this.ToolbarSave.Click += new System.EventHandler(this.MenuToolbarBrowserSave_Click);
            // 
            // ToolbarRevert
            // 
            this.ToolbarRevert.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ToolbarRevert.Enabled = false;
            this.ToolbarRevert.Image = global::Timekeeper.Properties.Resources.ImageButtonRevert;
            this.ToolbarRevert.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ToolbarRevert.Name = "ToolbarRevert";
            this.ToolbarRevert.Size = new System.Drawing.Size(23, 22);
            this.ToolbarRevert.Text = "Revert";
            this.ToolbarRevert.Click += new System.EventHandler(this.MenuToolbarBrowserRevert_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ControlPanel.Controls.Add(this.EntryDateTime);
            this.ControlPanel.Controls.Add(this.DateLabel);
            this.ControlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ControlPanel.Location = new System.Drawing.Point(0, 187);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(423, 35);
            this.ControlPanel.TabIndex = 7;
            // 
            // NotebookMenu
            // 
            this.NotebookMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotebookMenuToolbar});
            this.NotebookMenu.Location = new System.Drawing.Point(0, 0);
            this.NotebookMenu.Name = "NotebookMenu";
            this.NotebookMenu.Size = new System.Drawing.Size(423, 24);
            this.NotebookMenu.TabIndex = 9;
            this.NotebookMenu.Text = "menuStrip1";
            this.NotebookMenu.Visible = false;
            // 
            // NotebookMenuToolbar
            // 
            this.NotebookMenuToolbar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotebookMenuToolbarBrowser,
            this.NotebookMenuToolbarFormat,
            this.NotebookMenuAction});
            this.NotebookMenuToolbar.Name = "NotebookMenuToolbar";
            this.NotebookMenuToolbar.Size = new System.Drawing.Size(104, 20);
            this.NotebookMenuToolbar.Text = "Toolbar Functions";
            // 
            // NotebookMenuToolbarBrowser
            // 
            this.NotebookMenuToolbarBrowser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotebookMenuToolbarBrowserFirst,
            this.NotebookMenuToolbarBrowserPrev,
            this.NotebookMenuToolbarBrowserNext,
            this.NotebookMenuToolbarBrowserLast,
            this.NotebookMenuToolbarBrowserNew,
            this.toolStripSeparator1,
            this.NotebookMenuToolbarBrowserSave,
            this.NotebookMenuToolbarBrowserRevert});
            this.NotebookMenuToolbarBrowser.Name = "NotebookMenuToolbarBrowser";
            this.NotebookMenuToolbarBrowser.Size = new System.Drawing.Size(113, 22);
            this.NotebookMenuToolbarBrowser.Text = "&Browser";
            // 
            // NotebookMenuToolbarBrowserFirst
            // 
            this.NotebookMenuToolbarBrowserFirst.Name = "NotebookMenuToolbarBrowserFirst";
            this.NotebookMenuToolbarBrowserFirst.Size = new System.Drawing.Size(144, 22);
            this.NotebookMenuToolbarBrowserFirst.Text = "&First Entry";
            this.NotebookMenuToolbarBrowserFirst.Click += new System.EventHandler(this.MenuToolbarBrowserFirst_Click);
            // 
            // NotebookMenuToolbarBrowserPrev
            // 
            this.NotebookMenuToolbarBrowserPrev.Name = "NotebookMenuToolbarBrowserPrev";
            this.NotebookMenuToolbarBrowserPrev.Size = new System.Drawing.Size(144, 22);
            this.NotebookMenuToolbarBrowserPrev.Text = "&Previous Entry";
            this.NotebookMenuToolbarBrowserPrev.Click += new System.EventHandler(this.MenuToolbarBrowserPrev_Click);
            // 
            // NotebookMenuToolbarBrowserNext
            // 
            this.NotebookMenuToolbarBrowserNext.Name = "NotebookMenuToolbarBrowserNext";
            this.NotebookMenuToolbarBrowserNext.Size = new System.Drawing.Size(144, 22);
            this.NotebookMenuToolbarBrowserNext.Text = "&Next Entry";
            this.NotebookMenuToolbarBrowserNext.Click += new System.EventHandler(this.MenuToolbarBrowserNext_Click);
            // 
            // NotebookMenuToolbarBrowserLast
            // 
            this.NotebookMenuToolbarBrowserLast.Name = "NotebookMenuToolbarBrowserLast";
            this.NotebookMenuToolbarBrowserLast.Size = new System.Drawing.Size(144, 22);
            this.NotebookMenuToolbarBrowserLast.Text = "&Last Entry";
            this.NotebookMenuToolbarBrowserLast.Click += new System.EventHandler(this.MenuToolbarBrowserLast_Click);
            // 
            // NotebookMenuToolbarBrowserNew
            // 
            this.NotebookMenuToolbarBrowserNew.Name = "NotebookMenuToolbarBrowserNew";
            this.NotebookMenuToolbarBrowserNew.Size = new System.Drawing.Size(144, 22);
            this.NotebookMenuToolbarBrowserNew.Text = "&New Entry";
            this.NotebookMenuToolbarBrowserNew.Click += new System.EventHandler(this.MenuToolbarBrowserNew_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(141, 6);
            // 
            // NotebookMenuToolbarBrowserSave
            // 
            this.NotebookMenuToolbarBrowserSave.Name = "NotebookMenuToolbarBrowserSave";
            this.NotebookMenuToolbarBrowserSave.Size = new System.Drawing.Size(144, 22);
            this.NotebookMenuToolbarBrowserSave.Text = "Save";
            this.NotebookMenuToolbarBrowserSave.Click += new System.EventHandler(this.MenuToolbarBrowserSave_Click);
            // 
            // NotebookMenuToolbarBrowserRevert
            // 
            this.NotebookMenuToolbarBrowserRevert.Name = "NotebookMenuToolbarBrowserRevert";
            this.NotebookMenuToolbarBrowserRevert.Size = new System.Drawing.Size(144, 22);
            this.NotebookMenuToolbarBrowserRevert.Text = "&Revert";
            this.NotebookMenuToolbarBrowserRevert.Click += new System.EventHandler(this.MenuToolbarBrowserRevert_Click);
            // 
            // NotebookMenuToolbarFormat
            // 
            this.NotebookMenuToolbarFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotebookMenuToolbarFormatBold,
            this.NotebookMenuToolbarFormatItalic,
            this.NotebookMenuToolbarFormatUnderline,
            this.NotebookMenuToolbarFormatStrikethrough,
            this.NotebookMenuToolbarFormatSep1,
            this.NotebookMenuToolbarFormatBulletedList,
            this.NotebookMenuToolbarFormatNumberedList,
            this.NotebookMenuToolbarFormatSep2,
            this.NotebookMenuToolbarFormatHeading1,
            this.NotebookMenuToolbarFormatHeading2,
            this.NotebookMenuToolbarFormatHeading3,
            this.NotebookMenuToolbarFormatSep3,
            this.NotebookMenuToolbarFormatCode,
            this.NotebookMenuToolbarFormatBlockQuote,
            this.NotebookMenuToolbarFormatHorizontalRule});
            this.NotebookMenuToolbarFormat.Name = "NotebookMenuToolbarFormat";
            this.NotebookMenuToolbarFormat.Size = new System.Drawing.Size(113, 22);
            this.NotebookMenuToolbarFormat.Text = "&Format";
            // 
            // NotebookMenuToolbarFormatBold
            // 
            this.NotebookMenuToolbarFormatBold.Name = "NotebookMenuToolbarFormatBold";
            this.NotebookMenuToolbarFormatBold.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatBold.Text = "&Bold";
            this.NotebookMenuToolbarFormatBold.Click += new System.EventHandler(this.MenuToolbarFormatBold_Click);
            // 
            // NotebookMenuToolbarFormatItalic
            // 
            this.NotebookMenuToolbarFormatItalic.Name = "NotebookMenuToolbarFormatItalic";
            this.NotebookMenuToolbarFormatItalic.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatItalic.Text = "&Italic";
            this.NotebookMenuToolbarFormatItalic.Click += new System.EventHandler(this.MenuToolbarFormatItalic_Click);
            // 
            // NotebookMenuToolbarFormatUnderline
            // 
            this.NotebookMenuToolbarFormatUnderline.Name = "NotebookMenuToolbarFormatUnderline";
            this.NotebookMenuToolbarFormatUnderline.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatUnderline.Text = "&Underline";
            this.NotebookMenuToolbarFormatUnderline.Click += new System.EventHandler(this.MenuToolbarFormatUnderline_Click);
            // 
            // NotebookMenuToolbarFormatStrikethrough
            // 
            this.NotebookMenuToolbarFormatStrikethrough.Name = "NotebookMenuToolbarFormatStrikethrough";
            this.NotebookMenuToolbarFormatStrikethrough.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatStrikethrough.Text = "&Strikethrough";
            this.NotebookMenuToolbarFormatStrikethrough.Click += new System.EventHandler(this.MenuToolbarFormatStrikethrough_Click);
            // 
            // NotebookMenuToolbarFormatSep1
            // 
            this.NotebookMenuToolbarFormatSep1.Name = "NotebookMenuToolbarFormatSep1";
            this.NotebookMenuToolbarFormatSep1.Size = new System.Drawing.Size(143, 6);
            // 
            // NotebookMenuToolbarFormatBulletedList
            // 
            this.NotebookMenuToolbarFormatBulletedList.Name = "NotebookMenuToolbarFormatBulletedList";
            this.NotebookMenuToolbarFormatBulletedList.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatBulletedList.Text = "Bulleted List";
            this.NotebookMenuToolbarFormatBulletedList.Click += new System.EventHandler(this.MenuToolbarFormatBulletedList_Click);
            // 
            // NotebookMenuToolbarFormatNumberedList
            // 
            this.NotebookMenuToolbarFormatNumberedList.Name = "NotebookMenuToolbarFormatNumberedList";
            this.NotebookMenuToolbarFormatNumberedList.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatNumberedList.Text = "Numbered List";
            this.NotebookMenuToolbarFormatNumberedList.Click += new System.EventHandler(this.MenuToolbarFormatNumberedList_Click);
            // 
            // NotebookMenuToolbarFormatSep2
            // 
            this.NotebookMenuToolbarFormatSep2.Name = "NotebookMenuToolbarFormatSep2";
            this.NotebookMenuToolbarFormatSep2.Size = new System.Drawing.Size(143, 6);
            // 
            // NotebookMenuToolbarFormatHeading1
            // 
            this.NotebookMenuToolbarFormatHeading1.Name = "NotebookMenuToolbarFormatHeading1";
            this.NotebookMenuToolbarFormatHeading1.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatHeading1.Text = "Heading 1";
            this.NotebookMenuToolbarFormatHeading1.Click += new System.EventHandler(this.MenuToolbarFormatHeading1_Click);
            // 
            // NotebookMenuToolbarFormatHeading2
            // 
            this.NotebookMenuToolbarFormatHeading2.Name = "NotebookMenuToolbarFormatHeading2";
            this.NotebookMenuToolbarFormatHeading2.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatHeading2.Text = "Heading 2";
            this.NotebookMenuToolbarFormatHeading2.Click += new System.EventHandler(this.MenuToolbarFormatHeading2_Click);
            // 
            // NotebookMenuToolbarFormatHeading3
            // 
            this.NotebookMenuToolbarFormatHeading3.Name = "NotebookMenuToolbarFormatHeading3";
            this.NotebookMenuToolbarFormatHeading3.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatHeading3.Text = "Heading 3";
            this.NotebookMenuToolbarFormatHeading3.Click += new System.EventHandler(this.MenuToolbarFormatHeading3_Click);
            // 
            // NotebookMenuToolbarFormatSep3
            // 
            this.NotebookMenuToolbarFormatSep3.Name = "NotebookMenuToolbarFormatSep3";
            this.NotebookMenuToolbarFormatSep3.Size = new System.Drawing.Size(143, 6);
            // 
            // NotebookMenuToolbarFormatCode
            // 
            this.NotebookMenuToolbarFormatCode.Name = "NotebookMenuToolbarFormatCode";
            this.NotebookMenuToolbarFormatCode.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatCode.Text = "Code";
            this.NotebookMenuToolbarFormatCode.Click += new System.EventHandler(this.MenuToolbarFormatCode_Click);
            // 
            // NotebookMenuToolbarFormatBlockQuote
            // 
            this.NotebookMenuToolbarFormatBlockQuote.Name = "NotebookMenuToolbarFormatBlockQuote";
            this.NotebookMenuToolbarFormatBlockQuote.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatBlockQuote.Text = "Blockquote";
            this.NotebookMenuToolbarFormatBlockQuote.Click += new System.EventHandler(this.MenuToolbarFormatBlockquote_Click);
            // 
            // NotebookMenuToolbarFormatHorizontalRule
            // 
            this.NotebookMenuToolbarFormatHorizontalRule.Name = "NotebookMenuToolbarFormatHorizontalRule";
            this.NotebookMenuToolbarFormatHorizontalRule.Size = new System.Drawing.Size(146, 22);
            this.NotebookMenuToolbarFormatHorizontalRule.Text = "Horizontal Rule";
            this.NotebookMenuToolbarFormatHorizontalRule.Click += new System.EventHandler(this.MenuToolbarFormatHorizontalRule_Click);
            // 
            // NotebookMenuAction
            // 
            this.NotebookMenuAction.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NotebookMenuActionFind});
            this.NotebookMenuAction.Name = "NotebookMenuAction";
            this.NotebookMenuAction.Size = new System.Drawing.Size(113, 22);
            this.NotebookMenuAction.Text = "Action";
            // 
            // NotebookMenuActionFind
            // 
            this.NotebookMenuActionFind.Name = "NotebookMenuActionFind";
            this.NotebookMenuActionFind.Size = new System.Drawing.Size(94, 22);
            this.NotebookMenuActionFind.Text = "Find";
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ControlPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 25);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(423, 222);
            this.MainPanel.TabIndex = 10;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 276);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(454, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            this.statusStrip1.Visible = false;
            // 
            // Notebook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 247);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.NotebookMenu);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.NotebookMenu;
            this.Name = "Notebook";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Notebook";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notebook_FormClosing);
            this.Load += new System.EventHandler(this.Notebook_Load);
            this.Shown += new System.EventHandler(this.Notebook_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ControlPanel.ResumeLayout(false);
            this.ControlPanel.PerformLayout();
            this.NotebookMenu.ResumeLayout(false);
            this.NotebookMenu.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DateLabel;
        internal System.Windows.Forms.DateTimePicker EntryDateTime;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ToolbarFirstEntry;
        private System.Windows.Forms.ToolStripButton ToolbarPreviousEntry;
        private System.Windows.Forms.ToolStripButton ToolbarNextEntry;
        private System.Windows.Forms.ToolStripButton ToolbarLastEntry;
        private System.Windows.Forms.ToolStripButton ToolbarNewEntry;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.ToolStripSeparator ToolbarSep2;
        private System.Windows.Forms.ToolStripButton ToolbarSave;
        private System.Windows.Forms.ToolStripButton ToolbarRevert;
        private System.Windows.Forms.MenuStrip NotebookMenu;
        private System.Windows.Forms.ToolStripSeparator ToolbarSep1;
        private System.Windows.Forms.ToolStripButton ToolbarFind;
        private System.Windows.Forms.ToolStripLabel ToolbarNotebookEntryId;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarBrowser;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarBrowserFirst;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarBrowserPrev;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarBrowserNext;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarBrowserLast;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarBrowserNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarBrowserSave;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarBrowserRevert;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormat;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatBold;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatItalic;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatUnderline;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatStrikethrough;
        private System.Windows.Forms.ToolStripSeparator NotebookMenuToolbarFormatSep1;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatBulletedList;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatNumberedList;
        private System.Windows.Forms.ToolStripSeparator NotebookMenuToolbarFormatSep2;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatHeading1;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatHeading2;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatHeading3;
        private System.Windows.Forms.ToolStripSeparator NotebookMenuToolbarFormatSep3;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatCode;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatBlockQuote;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbarFormatHorizontalRule;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuToolbar;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuAction;
        private System.Windows.Forms.ToolStripMenuItem NotebookMenuActionFind;
    }
}