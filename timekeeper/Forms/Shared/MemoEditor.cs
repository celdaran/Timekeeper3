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
        public MemoEditor()
        {
            InitializeComponent();
        }

        override public string Text
        {
            get { return MemoEntry.Text; }
            set { MemoEntry.Text = value; }
        }

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

        internal void FormatBoldButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatBoldButton, "b");
        }

        internal void FormatItalicButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatItalicButton, "i");
        }

        internal void FormatUnderlineButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatUnderlineButton, "u");
        }

        internal void FormatStrikethroughButton_Click(object sender, EventArgs e)
        {
            FormatBasic(FormatStrikethroughButton, "s");
        }

    }
}
