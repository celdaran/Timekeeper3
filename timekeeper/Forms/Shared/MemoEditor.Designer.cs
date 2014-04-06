namespace Timekeeper.Forms.Shared
{
    partial class MemoEditor
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoEditor));
            this.MemoEntry = new System.Windows.Forms.RichTextBox();
            this.MemoToolbar = new System.Windows.Forms.ToolStrip();
            this.FormatBoldButton = new System.Windows.Forms.ToolStripButton();
            this.FormatItalicButton = new System.Windows.Forms.ToolStripButton();
            this.FormatUnderlineButton = new System.Windows.Forms.ToolStripButton();
            this.FormatStrikethroughButton = new System.Windows.Forms.ToolStripButton();
            this.FormatSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FormatBulletedListButton = new System.Windows.Forms.ToolStripButton();
            this.FormatNumberedListButton = new System.Windows.Forms.ToolStripButton();
            this.FormatSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.FormatCodeButton = new System.Windows.Forms.ToolStripButton();
            this.FormatBlockquoteButton = new System.Windows.Forms.ToolStripButton();
            this.FormatHorizontalRuleButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PopupMenuCut = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuPaste = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuSep1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuHideToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuShowToolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.PopupMenuMarkupLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuHTML = new System.Windows.Forms.ToolStripMenuItem();
            this.PopupMenuMarkdown = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatHeading1Button = new System.Windows.Forms.ToolStripButton();
            this.FormatHeading2Button = new System.Windows.Forms.ToolStripButton();
            this.FormatHeading3Button = new System.Windows.Forms.ToolStripButton();
            this.FormatSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MemoToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PopupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemoEntry
            // 
            this.MemoEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemoEntry.ContextMenuStrip = this.PopupMenu;
            this.MemoEntry.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MemoEntry.Location = new System.Drawing.Point(0, 25);
            this.MemoEntry.Name = "MemoEntry";
            this.MemoEntry.Size = new System.Drawing.Size(515, 203);
            this.MemoEntry.TabIndex = 0;
            this.MemoEntry.Text = "";
            // 
            // MemoToolbar
            // 
            this.MemoToolbar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.MemoToolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.MemoToolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormatBoldButton,
            this.FormatItalicButton,
            this.FormatUnderlineButton,
            this.FormatStrikethroughButton,
            this.FormatSeparator1,
            this.FormatBulletedListButton,
            this.FormatNumberedListButton,
            this.FormatSeparator2,
            this.FormatHeading1Button,
            this.FormatHeading2Button,
            this.FormatHeading3Button,
            this.FormatSeparator3,
            this.FormatCodeButton,
            this.FormatBlockquoteButton,
            this.FormatHorizontalRuleButton});
            this.MemoToolbar.Location = new System.Drawing.Point(0, 0);
            this.MemoToolbar.Name = "MemoToolbar";
            this.MemoToolbar.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.MemoToolbar.Size = new System.Drawing.Size(515, 25);
            this.MemoToolbar.TabIndex = 1;
            this.MemoToolbar.Text = "toolStrip1";
            // 
            // FormatBoldButton
            // 
            this.FormatBoldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatBoldButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatBoldButton.Image = global::Timekeeper.Properties.Resources.ImageButtonBold;
            this.FormatBoldButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatBoldButton.Name = "FormatBoldButton";
            this.FormatBoldButton.Size = new System.Drawing.Size(23, 22);
            this.FormatBoldButton.Text = "B";
            this.FormatBoldButton.ToolTipText = "Bold";
            this.FormatBoldButton.Click += new System.EventHandler(this.FormatBoldButton_Click);
            // 
            // FormatItalicButton
            // 
            this.FormatItalicButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatItalicButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatItalicButton.Image = global::Timekeeper.Properties.Resources.ImageButtonItalics;
            this.FormatItalicButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatItalicButton.Name = "FormatItalicButton";
            this.FormatItalicButton.Size = new System.Drawing.Size(23, 22);
            this.FormatItalicButton.Text = "I";
            this.FormatItalicButton.ToolTipText = "Italics";
            this.FormatItalicButton.Click += new System.EventHandler(this.FormatItalicButton_Click);
            // 
            // FormatUnderlineButton
            // 
            this.FormatUnderlineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatUnderlineButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatUnderlineButton.Image = global::Timekeeper.Properties.Resources.ImageButtonUnderlined;
            this.FormatUnderlineButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatUnderlineButton.Name = "FormatUnderlineButton";
            this.FormatUnderlineButton.Size = new System.Drawing.Size(23, 22);
            this.FormatUnderlineButton.Text = "U";
            this.FormatUnderlineButton.ToolTipText = "Underline";
            this.FormatUnderlineButton.Click += new System.EventHandler(this.FormatUnderlineButton_Click);
            // 
            // FormatStrikethroughButton
            // 
            this.FormatStrikethroughButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatStrikethroughButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatStrikethroughButton.Image = global::Timekeeper.Properties.Resources.ImageButtonStrikethrough;
            this.FormatStrikethroughButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatStrikethroughButton.Name = "FormatStrikethroughButton";
            this.FormatStrikethroughButton.Size = new System.Drawing.Size(28, 22);
            this.FormatStrikethroughButton.Text = "abc";
            this.FormatStrikethroughButton.ToolTipText = "Strikethrough";
            this.FormatStrikethroughButton.Click += new System.EventHandler(this.FormatStrikethroughButton_Click);
            // 
            // FormatSeparator1
            // 
            this.FormatSeparator1.Name = "FormatSeparator1";
            this.FormatSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // FormatBulletedListButton
            // 
            this.FormatBulletedListButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FormatBulletedListButton.Image = global::Timekeeper.Properties.Resources.ImageButtonListBulleted;
            this.FormatBulletedListButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatBulletedListButton.Name = "FormatBulletedListButton";
            this.FormatBulletedListButton.Size = new System.Drawing.Size(23, 22);
            this.FormatBulletedListButton.Text = "toolStripButton5";
            this.FormatBulletedListButton.ToolTipText = "Bulleted List";
            this.FormatBulletedListButton.Click += new System.EventHandler(this.FormatBulletedListButton_Click);
            // 
            // FormatNumberedListButton
            // 
            this.FormatNumberedListButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FormatNumberedListButton.Image = global::Timekeeper.Properties.Resources.ImageButtonListNumbered;
            this.FormatNumberedListButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatNumberedListButton.Name = "FormatNumberedListButton";
            this.FormatNumberedListButton.Size = new System.Drawing.Size(23, 22);
            this.FormatNumberedListButton.Text = "toolStripButton1";
            this.FormatNumberedListButton.ToolTipText = "Numbered List";
            this.FormatNumberedListButton.Click += new System.EventHandler(this.FormatNumberedListButton_Click);
            // 
            // FormatSeparator2
            // 
            this.FormatSeparator2.Name = "FormatSeparator2";
            this.FormatSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // FormatCodeButton
            // 
            this.FormatCodeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatCodeButton.Image = ((System.Drawing.Image)(resources.GetObject("FormatCodeButton.Image")));
            this.FormatCodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatCodeButton.Name = "FormatCodeButton";
            this.FormatCodeButton.Size = new System.Drawing.Size(27, 22);
            this.FormatCodeButton.Text = "<>";
            this.FormatCodeButton.ToolTipText = "Code or Preformatted Text";
            this.FormatCodeButton.Click += new System.EventHandler(this.FormatCodeButton_Click);
            // 
            // FormatBlockquoteButton
            // 
            this.FormatBlockquoteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatBlockquoteButton.Image = ((System.Drawing.Image)(resources.GetObject("FormatBlockquoteButton.Image")));
            this.FormatBlockquoteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatBlockquoteButton.Name = "FormatBlockquoteButton";
            this.FormatBlockquoteButton.Size = new System.Drawing.Size(23, 22);
            this.FormatBlockquoteButton.Text = "\" \"";
            this.FormatBlockquoteButton.ToolTipText = "Blockquote";
            this.FormatBlockquoteButton.Click += new System.EventHandler(this.FormatBlockquoteButton_Click);
            // 
            // FormatHorizontalRuleButton
            // 
            this.FormatHorizontalRuleButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatHorizontalRuleButton.Image = ((System.Drawing.Image)(resources.GetObject("FormatHorizontalRuleButton.Image")));
            this.FormatHorizontalRuleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatHorizontalRuleButton.Name = "FormatHorizontalRuleButton";
            this.FormatHorizontalRuleButton.Size = new System.Drawing.Size(23, 22);
            this.FormatHorizontalRuleButton.Text = "—";
            this.FormatHorizontalRuleButton.ToolTipText = "Separator";
            this.FormatHorizontalRuleButton.Click += new System.EventHandler(this.FormatHorizontalRuleButton_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.MemoEntry);
            this.panel1.Controls.Add(this.MemoToolbar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(519, 232);
            this.panel1.TabIndex = 2;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuCut,
            this.PopupMenuCopy,
            this.PopupMenuPaste,
            this.PopupMenuSep1,
            this.PopupMenuHideToolbar,
            this.PopupMenuShowToolbar,
            this.toolStripMenuItem1,
            this.PopupMenuMarkupLanguage});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(195, 148);
            this.PopupMenu.Opening += new System.ComponentModel.CancelEventHandler(this.PopupMenu_Opening);
            // 
            // PopupMenuCut
            // 
            this.PopupMenuCut.Name = "PopupMenuCut";
            this.PopupMenuCut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.PopupMenuCut.Size = new System.Drawing.Size(194, 22);
            this.PopupMenuCut.Text = "Cut";
            this.PopupMenuCut.Click += new System.EventHandler(this.PopupMenuCut_Click);
            // 
            // PopupMenuCopy
            // 
            this.PopupMenuCopy.Name = "PopupMenuCopy";
            this.PopupMenuCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.PopupMenuCopy.Size = new System.Drawing.Size(194, 22);
            this.PopupMenuCopy.Text = "Copy";
            this.PopupMenuCopy.Click += new System.EventHandler(this.PopupMenuCopy_Click);
            // 
            // PopupMenuPaste
            // 
            this.PopupMenuPaste.Name = "PopupMenuPaste";
            this.PopupMenuPaste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.PopupMenuPaste.Size = new System.Drawing.Size(194, 22);
            this.PopupMenuPaste.Text = "Paste";
            this.PopupMenuPaste.Click += new System.EventHandler(this.PopupMenuPaste_Click);
            // 
            // PopupMenuSep1
            // 
            this.PopupMenuSep1.Name = "PopupMenuSep1";
            this.PopupMenuSep1.Size = new System.Drawing.Size(191, 6);
            // 
            // PopupMenuHideToolbar
            // 
            this.PopupMenuHideToolbar.Name = "PopupMenuHideToolbar";
            this.PopupMenuHideToolbar.Size = new System.Drawing.Size(194, 22);
            this.PopupMenuHideToolbar.Text = "Hide Formatting Toolbar";
            this.PopupMenuHideToolbar.Click += new System.EventHandler(this.PopupMenuHideToolbar_Click);
            // 
            // PopupMenuShowToolbar
            // 
            this.PopupMenuShowToolbar.Name = "PopupMenuShowToolbar";
            this.PopupMenuShowToolbar.Size = new System.Drawing.Size(194, 22);
            this.PopupMenuShowToolbar.Text = "Show Formatting Toolbar";
            this.PopupMenuShowToolbar.Visible = false;
            this.PopupMenuShowToolbar.Click += new System.EventHandler(this.PopupMenuShowToolbar_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // PopupMenuMarkupLanguage
            // 
            this.PopupMenuMarkupLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PopupMenuHTML,
            this.PopupMenuMarkdown});
            this.PopupMenuMarkupLanguage.Name = "PopupMenuMarkupLanguage";
            this.PopupMenuMarkupLanguage.Size = new System.Drawing.Size(194, 22);
            this.PopupMenuMarkupLanguage.Text = "Markup Language";
            // 
            // PopupMenuHTML
            // 
            this.PopupMenuHTML.Name = "PopupMenuHTML";
            this.PopupMenuHTML.Size = new System.Drawing.Size(152, 22);
            this.PopupMenuHTML.Text = "HTML";
            this.PopupMenuHTML.Click += new System.EventHandler(this.PopupMenuHTML_Click);
            // 
            // PopupMenuMarkdown
            // 
            this.PopupMenuMarkdown.Name = "PopupMenuMarkdown";
            this.PopupMenuMarkdown.Size = new System.Drawing.Size(152, 22);
            this.PopupMenuMarkdown.Text = "Markdown";
            this.PopupMenuMarkdown.Click += new System.EventHandler(this.PopupMenuMarkdown_Click);
            // 
            // FormatHeading1Button
            // 
            this.FormatHeading1Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatHeading1Button.Image = ((System.Drawing.Image)(resources.GetObject("FormatHeading1Button.Image")));
            this.FormatHeading1Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatHeading1Button.Name = "FormatHeading1Button";
            this.FormatHeading1Button.Size = new System.Drawing.Size(24, 22);
            this.FormatHeading1Button.Text = "H1";
            this.FormatHeading1Button.ToolTipText = "Heading 1";
            this.FormatHeading1Button.Click += new System.EventHandler(this.FormatHeading1Button_Click);
            // 
            // FormatHeading2Button
            // 
            this.FormatHeading2Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatHeading2Button.Image = ((System.Drawing.Image)(resources.GetObject("FormatHeading2Button.Image")));
            this.FormatHeading2Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatHeading2Button.Name = "FormatHeading2Button";
            this.FormatHeading2Button.Size = new System.Drawing.Size(24, 22);
            this.FormatHeading2Button.Text = "H2";
            this.FormatHeading2Button.ToolTipText = "Heading 2";
            this.FormatHeading2Button.Click += new System.EventHandler(this.FormatHeading2Button_Click);
            // 
            // FormatHeading3Button
            // 
            this.FormatHeading3Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatHeading3Button.Image = ((System.Drawing.Image)(resources.GetObject("FormatHeading3Button.Image")));
            this.FormatHeading3Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatHeading3Button.Name = "FormatHeading3Button";
            this.FormatHeading3Button.Size = new System.Drawing.Size(24, 22);
            this.FormatHeading3Button.Text = "H3";
            this.FormatHeading3Button.ToolTipText = "Heading 3";
            this.FormatHeading3Button.Click += new System.EventHandler(this.FormatHeading3Button_Click);
            // 
            // FormatSeparator3
            // 
            this.FormatSeparator3.Name = "FormatSeparator3";
            this.FormatSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // MemoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MemoEditor";
            this.Size = new System.Drawing.Size(519, 232);
            this.Load += new System.EventHandler(this.MemoEditor_Load);
            this.MemoToolbar.ResumeLayout(false);
            this.MemoToolbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.PopupMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip MemoToolbar;
        private System.Windows.Forms.ToolStripButton FormatBoldButton;
        private System.Windows.Forms.ToolStripButton FormatItalicButton;
        private System.Windows.Forms.ToolStripButton FormatUnderlineButton;
        private System.Windows.Forms.ToolStripButton FormatStrikethroughButton;
        private System.Windows.Forms.ToolStripSeparator FormatSeparator1;
        private System.Windows.Forms.ToolStripButton FormatBulletedListButton;
        private System.Windows.Forms.ToolStripButton FormatNumberedListButton;
        private System.Windows.Forms.ToolStripSeparator FormatSeparator2;
        private System.Windows.Forms.ToolStripButton FormatCodeButton;
        private System.Windows.Forms.ToolStripButton FormatBlockquoteButton;
        private System.Windows.Forms.ToolStripButton FormatHorizontalRuleButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuCut;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuCopy;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuPaste;
        private System.Windows.Forms.ToolStripSeparator PopupMenuSep1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuHideToolbar;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuShowToolbar;
        internal System.Windows.Forms.RichTextBox MemoEntry;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuMarkupLanguage;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuHTML;
        private System.Windows.Forms.ToolStripMenuItem PopupMenuMarkdown;
        private System.Windows.Forms.ToolStripButton FormatHeading1Button;
        private System.Windows.Forms.ToolStripButton FormatHeading2Button;
        private System.Windows.Forms.ToolStripButton FormatHeading3Button;
        private System.Windows.Forms.ToolStripSeparator FormatSeparator3;
    }
}
