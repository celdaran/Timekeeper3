using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Shared
{
    public partial class MemoEditor : UserControl
    {
        //---------------------------------------------------------------------
        // Reusable Memo editor control with text entry box and formatting
        // toolbar. To be used for the main Journal Browser, as well as for
        // the notebook editor and todo list.
        //---------------------------------------------------------------------

        private Classes.Options Options;

        public MemoEditor()
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;

            this.RightMargin = Options.View_MemoEditor_RightMargin;
            this.ShowGutter = Options.View_MemoEditor_ShowGutter;
            this.EditorFont = Options.View_MemoEditor_Font;
        }

        //---------------------------------------------------------------------
        // Public properties
        //---------------------------------------------------------------------

        override public string Text
        {
            get { return MemoEntry.Text; }
            set { MemoEntry.Text = value; }
        }

        public int RightMargin
        {
            get { return MemoEntry.RightMargin; }
            set {
                MemoEntry.RightMargin = value;
                RightMarginMarker.Location = new Point(value, 0);
                Options.View_MemoEditor_RightMargin = value;
            }
        }

        public bool ShowGutter
        {
            get { return MemoEntry.ShowSelectionMargin; }
            set {
                MemoEntry.ShowSelectionMargin = value;
                Options.View_MemoEditor_ShowGutter = value;
            }
        }

        public string EditorFont
        {
            get {
                FontConverter fc = new FontConverter();
                return (string) fc.ConvertToString(MemoEntry.Font);
            }

            set {
                FontConverter fc = new FontConverter();
                MemoEntry.Font = (Font)fc.ConvertFromString(value);
                Options.View_MemoEditor_Font = value;
            }
        }

        //---------------------------------------------------------------------
        // Public methods
        //---------------------------------------------------------------------

        public void Disable()
        {
            this.MemoEntry.Enabled = false;
        }

        //---------------------------------------------------------------------

        public void Enable()
        {
            this.MemoEntry.Enabled = true;
        }

        //---------------------------------------------------------------------

        new public void Focus()
        {
            this.MemoEntry.Focus();
        }

        //---------------------------------------------------------------------
        // Form Events
        //---------------------------------------------------------------------

        private void MemoEditor_Load(object sender, EventArgs e)
        {
            // Is the formatting toolbar visible?
            ToolbarVisible(Timekeeper.Options.View_MemoEditor_ShowToolbar);

            // Adjust interface based on markup language
            SwitchMarkdown(Timekeeper.Options.Advanced_Other_MarkupLanguage);
        }

        //---------------------------------------------------------------------
        // Popup Menu Events
        //---------------------------------------------------------------------

        private void PopupMenu_Opening(object sender, CancelEventArgs e)
        {
            PopupMenuPaste.Enabled = MemoEntry.CanPaste(DataFormats.GetFormat(DataFormats.Text));
            PopupMenuCut.Enabled = MemoEntry.SelectedText.Length > 0;
            PopupMenuCopy.Enabled = PopupMenuCut.Enabled;
        }

        //---------------------------------------------------------------------

        private void PopupMenuCut_Click(object sender, EventArgs e)
        {
            MemoEntry.Cut();
        }

        //---------------------------------------------------------------------

        private void PopupMenuCopy_Click(object sender, EventArgs e)
        {
            MemoEntry.Copy();
        }

        //---------------------------------------------------------------------

        private void PopupMenuPaste_Click(object sender, EventArgs e)
        {
            MemoEntry.Paste(DataFormats.GetFormat(DataFormats.Text));
        }

        //---------------------------------------------------------------------

        private void PopupMenuHideToolbar_Click(object sender, EventArgs e)
        {
            ToolbarVisible(false);
        }

        //---------------------------------------------------------------------

        private void PopupMenuShowToolbar_Click(object sender, EventArgs e)
        {
            ToolbarVisible(true);
        }

        //---------------------------------------------------------------------

        internal void ToolbarVisible(bool visible)
        {
            PopupMenuShowToolbar.Visible = !visible;
            PopupMenuHideToolbar.Visible = visible;
            MemoToolbar.Visible = visible;
            RulerPanel.Visible = visible;
            Timekeeper.Options.View_MemoEditor_ShowToolbar = visible;
        }

        //---------------------------------------------------------------------

        private void PopupMenuHTML_Click(object sender, EventArgs e)
        {
            SwitchMarkdown(0);
        }

        //---------------------------------------------------------------------

        private void PopupMenuMarkdown_Click(object sender, EventArgs e)
        {
            SwitchMarkdown(1);
        }

        //---------------------------------------------------------------------

        internal void SwitchMarkdown(int language)
        {
            FormatUnderlineButton.Visible = (language == 0);
            FormatStrikethroughButton.Visible = (language == 0);
            PopupMenuHTML.Checked = (language == 0);
            PopupMenuMarkdown.Checked = (language == 1);
            Timekeeper.Options.Advanced_Other_MarkupLanguage = language;
        }

        //---------------------------------------------------------------------
        // Toolbar
        //---------------------------------------------------------------------

        internal void FormatFontButton_Click(object sender, EventArgs e)
        {
            // Prepopulate Font dialog box with the currently selected font
            FontConverter fc = new FontConverter();
            FontDialog.Font = (Font)fc.ConvertFromString(Options.View_MemoEditor_Font);

            // Display dialog
            if (FontDialog.ShowDialog(this) == DialogResult.OK) {
                // If OK, save selected Font
                this.EditorFont = (string)fc.ConvertToString(FontDialog.Font);
            }
        }

        internal void FormatBoldButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatBoldButton, "b");
            } else {
                FormatBasicMarkup(FormatBoldButton, "**");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatItalicButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatItalicButton, "i");
            } else {
                FormatBasicMarkup(FormatItalicButton, "*");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatUnderlineButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatUnderlineButton, "u");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatStrikethroughButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatStrikethroughButton, "s");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatBulletedListButton_Click(object sender, EventArgs e)
        {
            if (MemoEntry.SelectedText.Length > 0) {
                if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                    FormatListHTML("ul");
                } else {
                    FormatListMarkdown("*");
                }
            }
        }

        //---------------------------------------------------------------------

        internal void FormatNumberedListButton_Click(object sender, EventArgs e)
        {
            if (MemoEntry.SelectedText.Length > 0) {
                if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                    FormatListHTML("ol");
                } else {
                    FormatListMarkdown(1);
                }
            }
        }

        //---------------------------------------------------------------------

        internal void FormatHeading1Button_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatHeading1Button, "h1");
            } else {
                FormatLeadTag("#");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatHeading2Button_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatHeading2Button, "h2");
            } else {
                FormatLeadTag("##");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatHeading3Button_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatHeading3Button, "h3");
            } else {
                FormatLeadTag("###");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatCodeButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatCodeButton, "pre");
            } else {
                FormatBasicMarkup(FormatCodeButton, "```");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatBlockquoteButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatBasicHTML(FormatBlockquoteButton, "blockquote");
            } else {
                FormatLeadTag(">");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatHorizontalRuleButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_Other_MarkupLanguage == 0) {
                FormatLeadTag("<hr>");
            } else {
                FormatLeadTag("---");
            }
        }

        //---------------------------------------------------------------------

        private void FormatBasicHTML(ToolStripButton button, string tag)
        {
            string OpenTag = "<" + tag + ">";
            string CloseTag = "</" + tag + ">";
            FormatBasic(button, OpenTag, CloseTag);
        }

        //---------------------------------------------------------------------

        private void FormatBasicMarkup(ToolStripButton button, string tag)
        {
            FormatBasic(button, tag, tag);
        }

        //---------------------------------------------------------------------

        private void FormatBasic(ToolStripButton button, string openTag, string closeTag)
        {
            if (MemoEntry.SelectedText.Length > 0) {
                MemoEntry.SelectedText = openTag + MemoEntry.SelectedText + closeTag;
            } else {
                if (button.Checked) {
                    MemoEntry.SelectedText = closeTag;
                    button.Checked = false;
                } else {
                    MemoEntry.SelectedText = openTag;
                    button.Checked = true;
                }
            }
        }

        //---------------------------------------------------------------------

        private void FormatListHTML(string tag)
        {
            string NewHtml = "";
            string[] Lines = GetLines();

            foreach (string Line in Lines) {
                NewHtml += "<li>" + Line + "</li>" + "\n";
            }

            MemoEntry.SelectedText = "<" + tag + ">\n" + NewHtml + "</"+ tag +">\n";
        }

        //---------------------------------------------------------------------

        private void FormatListMarkdown(string tag)
        {
            string NewMarkdown = "";
            string[] Lines = GetLines();

            foreach (string Line in Lines) {
                string NewLine = StripOrdering(Line);
                NewMarkdown += tag + " " + NewLine + "\n";
            }

            MemoEntry.SelectedText = NewMarkdown;
        }

        //---------------------------------------------------------------------

        private void FormatListMarkdown(int tag)
        {
            string NewMarkdown = "";
            string[] Lines = GetLines();

            foreach (string Line in Lines) {
                string NewLine = StripOrdering(Line);
                NewMarkdown += tag.ToString() + ". " + NewLine + "\n";
                tag++;
            }

            MemoEntry.SelectedText = NewMarkdown;
        }

        //---------------------------------------------------------------------

        private void FormatLeadTag(string tag)
        {
            if (MemoEntry.SelectedText.Length == 0) {
                MemoEntry.SelectedText = tag + " " + MemoEntry.SelectedText;
            }
        }

        //---------------------------------------------------------------------
        // Internal helpers
        //---------------------------------------------------------------------

        private string[] GetLines()
        {
            string[] Lines = MemoEntry.SelectedText.Split(
                new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            return Lines;
        }

        //---------------------------------------------------------------------

        private string StripOrdering(string line)
        {
            string NewLine;

            Match match = Regex.Match(line, @"(^[0-9]+\.) (.*)", RegexOptions.IgnoreCase);
            if (match.Success) {
                // Line begins with a number and a dot. Strip it.
                NewLine = match.Groups[2].Value;
            } else {
                // Line doesn't begin with a number and a dot. Look for a star instead.
                match = Regex.Match(line, @"(^\*) (.*)", RegexOptions.IgnoreCase);
                if (match.Success) {
                    // Line begins with a star. Strip it.
                    NewLine = match.Groups[2].Value;
                } else {
                    NewLine = line;
                }
            }

            return NewLine;
        }

        //---------------------------------------------------------------------

        bool isDragged = false;
        Point ptOffset;
        private void RightMarginMarker_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                isDragged = true;
                Point ptStartPosition = RightMarginMarker.PointToScreen(new Point(e.X, e.Y));

                ptOffset = new Point();
                ptOffset.X = RightMarginMarker.Location.X - ptStartPosition.X;
                //ptOffset.Y = RightMarginMarker.Location.Y - ptStartPosition.Y;
            } else {
                isDragged = false;
            }
        }

        private void RightMarginMarker_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragged) {
                Point newPoint = RightMarginMarker.PointToScreen(new Point(e.X, e.Y));
                newPoint.Offset(ptOffset);
                RightMarginMarker.Location = new Point(newPoint.X, 0);
                if (RightMarginMarker.Location.X >= 0) {
                    this.RightMargin = RightMarginMarker.Location.X;
                }
            }
        }

        private void RightMarginMarker_MouseUp(object sender, MouseEventArgs e)
        {
            isDragged = false;
        }

        private void RightMarginMarker_DoubleClick(object sender, EventArgs e)
        {
            this.RightMargin = MemoEntry.Size.Width - (RightMarginMarker.Width / 2);
        }

        //---------------------------------------------------------------------

        private void ShowLeftMargin_Click(object sender, EventArgs e)
        {
            this.ShowGutter = !this.ShowGutter;
        }

        private void RulerPanel_DoubleClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            this.RightMargin = me.X - (RightMarginMarker.Width / 2);
        }

        //---------------------------------------------------------------------

    }
}
