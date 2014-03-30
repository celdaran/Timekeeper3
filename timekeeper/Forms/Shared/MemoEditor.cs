using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms.Shared
{
    public partial class MemoEditor : UserControl
    {
        //---------------------------------------------------------------------
        // Reusable Memo editor control with text entry box and formatting
        // toolbar. To be used for the main Journal Browser, as well as for
        // the notebook editor and todo list.
        //---------------------------------------------------------------------

        public MemoEditor()
        {
            InitializeComponent();
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
        // Popup Menu Events
        //---------------------------------------------------------------------

        private void PopupMenu_Opening(object sender, CancelEventArgs e)
        {
            PopupMenuPaste.Enabled = MemoEntry.CanPaste(DataFormats.GetFormat(DataFormats.Text));
            PopupMenuCut.Enabled = MemoEntry.SelectedText.Length > 0;
            PopupMenuCopy.Enabled = PopupMenuCut.Enabled;
        }

        //---------------------------------------------------------------------

        private void PopupMenuHideToolbar_Click(object sender, EventArgs e)
        {
            PopupMenuShowToolbar.Visible = true;
            PopupMenuHideToolbar.Visible = false;
            MemoToolbar.Visible = false;
        }

        //---------------------------------------------------------------------

        private void PopupMenuShowToolbar_Click(object sender, EventArgs e)
        {
            PopupMenuShowToolbar.Visible = false;
            PopupMenuHideToolbar.Visible = true;
            MemoToolbar.Visible = true;
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
            MemoEntry.Paste();
        }

        //---------------------------------------------------------------------
        // Toolbar
        //---------------------------------------------------------------------

        internal void FormatBoldButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatBoldButton, "b");
        }

        //---------------------------------------------------------------------

        internal void FormatItalicButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatItalicButton, "i");
        }

        //---------------------------------------------------------------------

        internal void FormatUnderlineButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatUnderlineButton, "u");
        }

        //---------------------------------------------------------------------

        internal void FormatStrikethroughButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatStrikethroughButton, "s");
        }

        //---------------------------------------------------------------------

        internal void FormatBulletedListButton_Click(object sender, EventArgs e)
        {
            FormatList(FormatBulletedListButton, "ul");
        }

        //---------------------------------------------------------------------

        internal void FormatNumberedListButton_Click(object sender, EventArgs e)
        {
            FormatList(FormatNumberedListButton, "ol");
        }

        //---------------------------------------------------------------------

        internal void FormatHeading1Button_Click(object sender, EventArgs e)
        {
            FormatLeadTag("#");
        }

        //---------------------------------------------------------------------

        internal void FormatHeading2Button_Click(object sender, EventArgs e)
        {
            FormatLeadTag("##");
        }

        //---------------------------------------------------------------------

        internal void FormatHeading3Button_Click(object sender, EventArgs e)
        {
            FormatLeadTag("###");
        }

        //---------------------------------------------------------------------

        internal void FormatCodeButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatCodeButton, "pre");
        }

        //---------------------------------------------------------------------

        internal void FormatBlockquoteButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatCodeButton, "blockquote");
        }

        //---------------------------------------------------------------------

        internal void FormatHorizontalRuleButton_Click(object sender, EventArgs e)
        {
            FormatLeadTag("---");
        }

        //---------------------------------------------------------------------

        private void FormatBasic(ToolStripButton button, string tag)
        {
            string OpenTag = "<" + tag + ">";
            string CloseTag = "</" + tag + ">";

            if (MemoEntry.SelectedText.Length > 0) {
                MemoEntry.SelectedText = OpenTag + MemoEntry.SelectedText + CloseTag;
            } else {
                if (button.Checked) {
                    MemoEntry.SelectedText = CloseTag;
                    button.Checked = false;
                } else {
                    MemoEntry.SelectedText = OpenTag;
                    button.Checked = true;
                }
            }
        }

        //---------------------------------------------------------------------

        private void FormatList(ToolStripButton button, string tag)
        {
            /*
              Convert this:

              Hello
              There
              How
              Are
              You?

              To this:

              <ul>
              <li>Hello</li>
              <li>There</li>
              <li>How</li>
              <li>Are</li>
              <li>You?</li>
              </ul>

              Or this:

              * Hello
              * There
              * How
              * Are
              * You?

            Or both? Do I support both HTML and MD engines?
            I'm starting to think: no
            */

            if (MemoEntry.SelectedText.Length > 0) {

                string NewMarkdown = "";
                string NewHtml = "";

                string[] Lines = MemoEntry.SelectedText.Split(
                    new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (string Line in Lines) {
                    NewMarkdown += "* " + Line + "\n";
                    NewHtml += "<li>" + Line + "</li>" + "\n";
                }

                //MemoEntry.SelectedText = NewMarkdown;
                MemoEntry.SelectedText = "<" + tag + ">\n" + NewHtml + "</"+ tag +">\n";
            }
        }

        //---------------------------------------------------------------------

        private void FormatLeadTag(string tag)
        {
            if (MemoEntry.SelectedText.Length == 0) {
                MemoEntry.SelectedText = tag + " " + MemoEntry.SelectedText;
            }
        }

        //---------------------------------------------------------------------

    }
}
