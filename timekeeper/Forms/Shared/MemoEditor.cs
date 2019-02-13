using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Resources;

using Timekeeper.Classes.Toolbox;

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

        //---------------------------------------------------------------------

        public int RightMargin
        {
            get { return MemoEntry.RightMargin; }
            set {
                if (value > 0) {
                    MemoEntry.RightMargin = value;
                    RightMarginMarker.Location = new Point(value, 0);
                }
            }
        }

        //---------------------------------------------------------------------

        public bool ShowGutter
        {
            get { return MemoEntry.ShowSelectionMargin; }
            set {
                // First off, set the actual memo margin visibility
                MemoEntry.ShowSelectionMargin = value;

                // UI feedback
                GutterPanel.Visible = value;
                ShowLeftMargin.Visible = !value;
                PopupMenuShowGutter.Visible = !value;
                PopupMenuHideGutter.Visible = value;

                /*
                if (value)
                    this.RightMargin -= 10;
                else
                    this.RightMargin += 10;
                */

                // Lastly, remember this option
                Options.View_MemoEditor_ShowGutter = value;
            }
        }

        //---------------------------------------------------------------------

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
            // Are the toolbar components visible?
            FormatToolbarVisible(Timekeeper.Options.View_MemoEditor_ShowToolbar);
            FormatRulerVisible(Timekeeper.Options.View_MemoEditor_ShowRuler);

            // Adjust interface based on markup language
            SwitchMarkdown(Timekeeper.Options.Advanced_MarkupLanguage);
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

        private void PopupMenuToggleCheckbox_Click(object sender, EventArgs e)
        {
            FormatCheckboxButton_Click(sender, e);
        }

        //---------------------------------------------------------------------

        private void PopupMenuHideToolbar_Click(object sender, EventArgs e)
        {
            FormatToolbarVisible(false);
        }

        //---------------------------------------------------------------------

        private void PopupMenuShowToolbar_Click(object sender, EventArgs e)
        {
            FormatToolbarVisible(true);
        }

        //---------------------------------------------------------------------

        private void PopupMenuHideRuler_Click(object sender, EventArgs e)
        {
            FormatRulerVisible(false);
        }

        //---------------------------------------------------------------------

        private void PopupMenuShowRuler_Click(object sender, EventArgs e)
        {
            FormatRulerVisible(true);
        }

        //---------------------------------------------------------------------

        private void PopupMenuHideGutter_Click(object sender, EventArgs e)
        {
            this.ShowGutter = false;
        }

        //---------------------------------------------------------------------

        private void PopupMenuShowGutter_Click(object sender, EventArgs e)
        {
            this.ShowGutter = true;
        }

        //---------------------------------------------------------------------

        internal void FormatToolbarVisible(bool visible)
        {
            PopupMenuShowToolbar.Visible = !visible;
            PopupMenuHideToolbar.Visible = visible;
            MemoToolbar.Visible = visible;
            Timekeeper.Options.View_MemoEditor_ShowToolbar = visible;
        }

        //---------------------------------------------------------------------

        internal void FormatRulerVisible(bool visible)
        {
            PopupMenuShowRuler.Visible = !visible;
            PopupMenuHideRuler.Visible = visible;
            RulerContainer.Visible = visible;
            Timekeeper.Options.View_MemoEditor_ShowRuler = visible;
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
            Timekeeper.Options.Advanced_MarkupLanguage = language;
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
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatBoldButton, "b");
            } else {
                FormatBasicMarkup(FormatBoldButton, "**");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatItalicButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatItalicButton, "i");
            } else {
                FormatBasicMarkup(FormatItalicButton, "*");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatUnderlineButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatUnderlineButton, "u");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatStrikethroughButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatStrikethroughButton, "s");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatBulletedListButton_Click(object sender, EventArgs e)
        {
            if (MemoEntry.SelectedText.Length > 0) {
                if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
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
                if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                    FormatListHTML("ol");
                } else {
                    FormatListMarkdown(1);
                }
            }
        }

        //---------------------------------------------------------------------

        internal void FormatCheckboxListButton_Click(object sender, EventArgs e)
        {
            if (MemoEntry.SelectedText.Length > 0) {
                FormatCheckboxList();
            }
        }

        //---------------------------------------------------------------------

        internal void FormatHeading1Button_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatHeading1Button, "h1");
            } else {
                FormatLeadTag("#");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatHeading2Button_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatHeading2Button, "h2");
            } else {
                FormatLeadTag("##");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatHeading3Button_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatHeading3Button, "h3");
            } else {
                FormatLeadTag("###");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatCheckboxButton_Click(object sender, EventArgs e)
        {
            FormatCheckboxListLine();
        }

        //---------------------------------------------------------------------

        internal void FormatCodeButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatCodeButton, "pre");
            } else {
                FormatBasicMarkup(FormatCodeButton, "```");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatBlockquoteButton_Click(object sender, EventArgs e)
        {
            if (Timekeeper.Options.Advanced_MarkupLanguage == 0) {
                FormatBasicHTML(FormatBlockquoteButton, "blockquote");
            } else {
                FormatLeadTag(">");
            }
        }

        //---------------------------------------------------------------------

        internal void FormatHorizontalRuleButton_Click(object sender, EventArgs e)
        {
            // Get our template and current timestamp
            string Template = Options.Advanced_BreakTemplate;
            string Timestamp = Timekeeper.DateForDisplay();

            // Substitute timestamp, if present
            Template = Template.Replace("%timestamp", "{0}");
            Template = Template.Replace("\\n", "\n");
            string BreakText = String.Format(Template, Timestamp);

            // Send output to the memo box
            FormatSimpleTextInsert(BreakText);
        }

        //---------------------------------------------------------------------
        /*

        private void FormatBallotBoxButton_Click(object sender, EventArgs e)
        {
            // Save selection
            int SelectionStart = MemoEntry.SelectionStart;
            int SelectionLength = MemoEntry.SelectionLength;

            SelectionStart = Something(SelectionStart);

            // Restore selection
            MemoEntry.SelectionStart = SelectionStart;
            MemoEntry.SelectionLength = SelectionLength;
        }

        //---------------------------------------------------------------------

        private int Something(int selectionStart)
        {
            int LineNumber = MemoEntry.GetLineFromCharIndex(selectionStart);
            string[] AllLines = MemoEntry.Lines;

            // If no lines, we have an empty box
            if (AllLines.Length == 0) {
                string[] NewLine = new string[1];
                NewLine[0] = ToggleCheckbox(" ", ref selectionStart);
                MemoEntry.Lines = NewLine;
            } else {
                // Otherwise we have data
                string CurrentLine = MemoEntry.Lines[LineNumber];

                // If the current *line* is empty, we'll just be
                // adding a box to an empty line, but let's bump
                // the selection start
                if (CurrentLine.Length == 0)
                    selectionStart += 2;

                AllLines[LineNumber] = ToggleCheckbox(CurrentLine, ref selectionStart);
                MemoEntry.Lines = AllLines;
            }

            return selectionStart;
        }
        */

        //---------------------------------------------------------------------

        private string ToggleCheckbox(string currentLine, ref int selectionStart)
        {
            if (currentLine.Length > 0) {
                if (currentLine.Substring(0, 1) == Timekeeper.Uncheckedbox) {
                    currentLine = Timekeeper.Checkedbox + currentLine.Substring(1);
                } else if (currentLine.Substring(0, 1) == Timekeeper.Checkedbox) {
                    currentLine = Timekeeper.Uncheckedbox + currentLine.Substring(1);
                } else {
                    // No checkbox, so let's add one
                    currentLine = Timekeeper.Uncheckedbox + " " + currentLine;
                    selectionStart += 2;
                }
            } else {
                currentLine = Timekeeper.Uncheckedbox + " ";
            }
            return currentLine;
        }

        //---------------------------------------------------------------------

        private void FormatInsertBreakButton_Click(object sender, EventArgs e)
        {
            /* 
            Saving this hacked up image-insertion code for later

            object SaveClipboard = Clipboard.GetDataObject();

            ResourceManager Resources = new ResourceManager("Timekeeper.Properties.Resources", typeof(File).Assembly);
            Image TestImage = (Image)Resources.GetObject("ImageIconToolbar");

            Clipboard.SetImage(TestImage);
            MemoEntry.Paste();

            Clipboard.SetDataObject(SaveClipboard);
            */

            /*
            Note! No longer used... I've merged the "Break" and "HorizonalRule" functions.
            */
        }

        //---------------------------------------------------------------------
        // Formatting helpers
        //---------------------------------------------------------------------

        private void FormatSimpleTextInsert(string value)
        {
            MemoEntry.SelectedText = value;
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

            int SavedSelectionStart = MemoEntry.SelectionStart;

            foreach (string Line in Lines) {
                NewHtml += "<li>" + Line + "</li>" + "\n";
            }

            MemoEntry.SelectedText = "<" + tag + ">\n" + NewHtml + "</"+ tag +">\n";
            MemoEntry.SelectionStart = SavedSelectionStart;
        }

        //---------------------------------------------------------------------

        private void FormatListMarkdown(string tag)
        {
            string NewMarkdown = "";
            string[] Lines = GetLines();

            int SavedSelectionStart = MemoEntry.SelectionStart;

            foreach (string Line in Lines) {
                string NewLine = StripOrdering(Line);
                NewMarkdown += tag + " " + NewLine + "\n";
            }

            MemoEntry.SelectedText = NewMarkdown;
            MemoEntry.SelectionStart = SavedSelectionStart;
        }

        //---------------------------------------------------------------------

        private void FormatListMarkdown(int tag)
        {
            string NewMarkdown = "";
            string[] Lines = GetLines();

            int SavedSelectionStart = MemoEntry.SelectionStart;

            foreach (string Line in Lines) {
                string NewLine = StripOrdering(Line);
                NewMarkdown += tag.ToString() + ". " + NewLine + "\n";
                tag++;
            }

            MemoEntry.SelectedText = NewMarkdown;
            MemoEntry.SelectionStart = SavedSelectionStart;
        }

        //---------------------------------------------------------------------

        private void FormatCheckboxList()
        {
            FormatCheckboxList(MemoEntry.SelectionStart);
        }

        private void FormatCheckboxList(int savedSelectionStart)
        {
            string NewText = "";
            string[] Lines = GetLines();

            //int SavedSelectionStart = MemoEntry.SelectionStart;

            // Handle each line
            foreach (string Line in Lines) {
                NewText += GetCheckboxListLine(Line) + "\n";
            }

            // Update selection
            if (MemoEntry.SelectedText.EndsWith("\n")) {
                MemoEntry.SelectedText = NewText;
            } else {
                MemoEntry.SelectedText = NewText.Substring(0, NewText.Length - 1);
            }

            MemoEntry.SelectionStart = savedSelectionStart + 2;
        }

        //---------------------------------------------------------------------

        private void FormatTestButton_Click(object sender, EventArgs e)
        {
            MemoEntry.SelectionBackColor = Color.Black;
            MemoEntry.SelectionColor = Color.Green;
            MemoEntry.SelectionFont = new Font("Arial", 12, FontStyle.Bold);
        }

        private void FormatCheckboxListLine()
        {

            /*
            // Clear all text from the RichTextBox;
            MemoEntry.Clear();
            // Set the font for the opening text to a larger Arial font;
            MemoEntry.SelectionFont = new Font("Arial", 16);
            // Assign the introduction text to the RichTextBox control.
            MemoEntry.SelectedText = "The following is a list of bulleted items:" + "\n";
            // Set the Font for the first item to a smaller size Arial font.
            MemoEntry.SelectionFont = new Font("Arial", 12);
            // Specify that the following items are to be added to a bulleted list.
            MemoEntry.SelectionBullet = true;
            // Set the color of the item text.
            MemoEntry.SelectionColor = Color.Red;
            // Assign the text to the bulleted item.
            MemoEntry.SelectedText = "Apples" + "\n";
            // Apply same font since font settings do not carry to next line.
            MemoEntry.SelectionFont = new Font("Arial", 12);
            MemoEntry.SelectionColor = Color.Orange;
            MemoEntry.SelectedText = "Oranges" + "\n";
            MemoEntry.SelectionFont = new Font("Arial", 12);
            MemoEntry.SelectionColor = Color.Purple;
            MemoEntry.SelectedText = "Grapes" + "\n";
            // End the bulleted list.
            MemoEntry.SelectionBullet = false;
            // Specify the font size and string for text displayed below bulleted list.
            MemoEntry.SelectionFont = new Font("Arial", 16);
            MemoEntry.SelectedText = "Bulleted Text Complete!";

            return;
            */

            //int Foo = MemoEntry.GetLineFromCharIndex(MemoEntry.SelectionStart);

            /*
            string[] AllLines = MemoEntry.Lines;
            List<string> AllLines2 = new List<string>();

            foreach (string TempLine in AllLines) {
                AllLines2.Add(TempLine);
            }

            AllLines2[AllLines2.Count - 1] = "This replaces the last line";

            //MemoEntry.Text = String.Join("\n", AllLines2);
            MemoEntry.SelectedText = String.Join("\n", AllLines2);

            return;
            */

            /*
              Line 1\n
              Line 2\n
              Line 3 could be very long
              and wrap a bit meaning, my
              physical line numbers and
              the number of hard newlines
              will be different.\n
              Line 4\n
              Line 5 could be just as long
              if not longer than Line 3.
              And is a good test of this.\n
              Line 6\n.
            */

            // Break box into pieces
            // An array of structs
            // [0].Start
            // [0].Contents
            // [1].Start
            // [1].Contents
            // [2].Start
            // [2].Contents
            // But . . . this should be calculatable.
            // I know how long the lines are.

            int SavedSelectionStart = SelectCurrentLine();
            if (MemoEntry.SelectionLength == 0) {
                MemoEntry.SelectedText = Timekeeper.Uncheckedbox + " ";
                MemoEntry.SelectionStart += 2;
            }
            else {
                FormatCheckboxList(SavedSelectionStart);
            }

            return;

            /*

            Wow, this did NOT turn out . . . leaving it for one commit, but
            then will likely kill it.

            string Line = "";
            int StartOffset = 0;

            if (MemoEntry.Text.Length == 0) {
                // If there's no text at all, do nothing just yet
            } else {
                string[] AllLines = MemoEntry.Lines;
                string LeftText = MemoEntry.Text.Substring(0, MemoEntry.SelectionStart);
                string[] Lines = LeftText.Split('\n');
                int LineNumber = Lines.Length;
                Line = AllLines[LineNumber - 1];
            }

            if (Line == "") {
                // If the line is empty, just drop in a new unchecked box
                MemoEntry.SelectedText = Timekeeper.Uncheckedbox + " ";
            } else {
                // Otherwise, figure out what kind of line
                CheckboxLineType LineType = DetermineCheckboxLineType(Line);

                // Get the altered line
                string NewLine = GetCheckboxListLine(Line);

                // The type of line matters
                if (LineType == CheckboxLineType.None) {
                    StartOffset = 2;
                    NewLine += "\n";
                }

                // Figure out the start and length of the current line
                // Which is NOT as easy as you'd think, primarily due
                // to wordwrapping in the control.
                int SaveSelectionStart = MemoEntry.SelectionStart;
                MemoEntry.SelectionStart = this.GetFirstCharIndexFromLine(1); // MemoEntry.GetFirstCharIndexFromLine(0); // MemoEntry.GetFirstCharIndexOfCurrentLine();
                MemoEntry.SelectionLength = NewLine.Length - StartOffset;

                // Replace the text
                MemoEntry.SelectedText = NewLine;

                // Attempt to restore prior state
                MemoEntry.SelectionLength = 0;
                MemoEntry.SelectionStart = SaveSelectionStart + StartOffset;
            }

            */

        }

        private int SelectCurrentLine()
        {
            int SavedStartPosition = MemoEntry.SelectionStart;

            string[] AllLines = MemoEntry.Lines;
            int RunningLength = 0;
            int RunningStartPos = 0;
            string CurrentLine = "";

            foreach (string Line in AllLines) {
                CurrentLine = Line;
                RunningLength += Line.Length + 1;
                if (RunningLength > MemoEntry.SelectionStart) {
                    break;
                }
                RunningStartPos = RunningLength;
            }

            MemoEntry.SelectionStart = RunningStartPos;
            MemoEntry.SelectionLength = CurrentLine.Length;

            return SavedStartPosition;
        }

        private int GetFirstCharIndexFromLine(int lineNo)
        {
            int Position = 0;

            for (int i = 0; i < lineNo; i++) {
                Position += (MemoEntry.Lines[i].Length + 1);
            }

            return Position;
        }


        private string GetCheckboxListLine(string line)
        {
            string NewText = "";
            string NewLine;

            if (line == "") {
                NewText = Timekeeper.Uncheckedbox + " ";
            } else {
                switch (DetermineCheckboxType(line)) {
                    case CheckboxType.None:
                        NewText = Timekeeper.Uncheckedbox + " " + line;
                        break;
                    case CheckboxType.Checked:
                        NewLine = StripCheckbox(line);
                        NewText = Timekeeper.Uncheckedbox + " " + NewLine;
                        break;
                    case CheckboxType.Unchecked:
                        NewLine = StripCheckbox(line);
                        NewText = Timekeeper.Checkedbox + " " + NewLine;
                        break;
                }
            }

            return NewText;
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
            return GetLines(StringSplitOptions.RemoveEmptyEntries);
        }

        //---------------------------------------------------------------------

        private string[] GetLines(StringSplitOptions options)
        {
            string[] Lines = MemoEntry.SelectedText.Split(
                new string[] { "\n" }, options);
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

        private string StripCheckbox(string line)
        {
            return line.Substring(2);
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
            this.RightMargin = 
                (MemoEntry.Size.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth - 10) - 
                (RightMarginMarker.Width / 2);
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

        private void GutterPanel_Click(object sender, EventArgs e)
        {
            this.ShowGutter = false;
        }

        private void MemoEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*
            By moving focus away from the RichTextBox and then back
            again, I'm able to avoid the "random unicode character swap"
            problem tracked in Issue #1364 and also posed to the Stack
            Overflow community in a vain effort to solve this mystery.
            */
            Hacktastic.Focus();
            Hacktastic.Text = e.KeyChar.ToString();
            MemoEntry.Focus();
        }

        private enum CheckboxLineType { None, Populated, Empty }
        private enum CheckboxType { None, Checked, Unchecked }

        private void MemoEntry_KeyDown(object sender, KeyEventArgs e)
        {
            try {
                if (e.KeyCode == Keys.Enter) {
                    switch (GetCheckboxLineType()) {
                        case CheckboxLineType.None:
                            // Do nothing
                            break;
                        case CheckboxLineType.Populated:
                            // Add an empty row
                            this.MemoEntry.SelectedText += Timekeeper.Uncheckedbox + " ";
                            break;
                        case CheckboxLineType.Empty:
                            // Lop off previous row, but preserve everything before (and after) that point.
                            int SaveSelectionPoint = MemoEntry.SelectionStart;
                            this.MemoEntry.Text =
                                this.MemoEntry.Text.Substring(0, SaveSelectionPoint - 4) +
                                this.MemoEntry.Text.Substring(SaveSelectionPoint) + Environment.NewLine;
                            MemoEntry.SelectionStart = SaveSelectionPoint - 3;
                            break;
                    }
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        private CheckboxLineType GetCheckboxLineType()
        {
            // FIXME: make these three lines of text a "GetLineNumber" method
            string LeftText = MemoEntry.Text.Substring(0, MemoEntry.SelectionStart);
            string[] Lines = LeftText.Split('\n');
            int LineNumber = Lines.Length - 1;

            if (LineNumber > 0)
                return DetermineCheckboxLineType(MemoEntry.Lines[LineNumber - 1]);
            else 
                return CheckboxLineType.None;
        }

        private CheckboxLineType DetermineCheckboxLineType(string line)
        {
            if (line == (Timekeeper.Uncheckedbox + " "))
                return CheckboxLineType.Empty;
            else if (line.StartsWith(Timekeeper.Uncheckedbox) || line.StartsWith(Timekeeper.Checkedbox))
                return CheckboxLineType.Populated;
            else
                return CheckboxLineType.None;
        }

        private CheckboxType DetermineCheckboxType(string line)
        {
            if (line.StartsWith(Timekeeper.Checkedbox))
                return CheckboxType.Checked;
            else if (line.StartsWith(Timekeeper.Uncheckedbox))
                return CheckboxType.Unchecked;
            else
                return CheckboxType.None;
        }

        //---------------------------------------------------------------------

    }
}
