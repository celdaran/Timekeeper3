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
            this.FormatHeadingDropdown = new System.Windows.Forms.ToolStripDropDownButton();
            this.FormatHeading1Button = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatHeading2Button = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatHeading3Button = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatCodeButton = new System.Windows.Forms.ToolStripButton();
            this.FormatBlockquoteButton = new System.Windows.Forms.ToolStripButton();
            this.FormatHorizontalRuleButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.MemoPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.hideFormattingToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showFormattingToolbarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MemoToolbar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.MemoPopup.SuspendLayout();
            this.SuspendLayout();
            // 
            // MemoEntry
            // 
            this.MemoEntry.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MemoEntry.ContextMenuStrip = this.MemoPopup;
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
            this.FormatHeadingDropdown,
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
            this.FormatBoldButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.FormatItalicButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.FormatUnderlineButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
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
            this.FormatStrikethroughButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FormatStrikethroughButton.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Strikeout, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormatStrikethroughButton.Image = global::Timekeeper.Properties.Resources.ImageButtonStrikethrough;
            this.FormatStrikethroughButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatStrikethroughButton.Name = "FormatStrikethroughButton";
            this.FormatStrikethroughButton.Size = new System.Drawing.Size(23, 22);
            this.FormatStrikethroughButton.Text = "S";
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
            // 
            // FormatNumberedListButton
            // 
            this.FormatNumberedListButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FormatNumberedListButton.Image = global::Timekeeper.Properties.Resources.ImageButtonListNumbered;
            this.FormatNumberedListButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatNumberedListButton.Name = "FormatNumberedListButton";
            this.FormatNumberedListButton.Size = new System.Drawing.Size(23, 22);
            this.FormatNumberedListButton.Text = "toolStripButton1";
            // 
            // FormatSeparator2
            // 
            this.FormatSeparator2.Name = "FormatSeparator2";
            this.FormatSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // FormatHeadingDropdown
            // 
            this.FormatHeadingDropdown.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FormatHeadingDropdown.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FormatHeading1Button,
            this.FormatHeading2Button,
            this.FormatHeading3Button});
            this.FormatHeadingDropdown.Image = ((System.Drawing.Image)(resources.GetObject("FormatHeadingDropdown.Image")));
            this.FormatHeadingDropdown.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatHeadingDropdown.Name = "FormatHeadingDropdown";
            this.FormatHeadingDropdown.Size = new System.Drawing.Size(64, 22);
            this.FormatHeadingDropdown.Text = "Headings";
            // 
            // FormatHeading1Button
            // 
            this.FormatHeading1Button.Name = "FormatHeading1Button";
            this.FormatHeading1Button.Size = new System.Drawing.Size(152, 22);
            this.FormatHeading1Button.Text = "Heading 1";
            // 
            // FormatHeading2Button
            // 
            this.FormatHeading2Button.Name = "FormatHeading2Button";
            this.FormatHeading2Button.Size = new System.Drawing.Size(152, 22);
            this.FormatHeading2Button.Text = "Heading 2";
            // 
            // FormatHeading3Button
            // 
            this.FormatHeading3Button.Name = "FormatHeading3Button";
            this.FormatHeading3Button.Size = new System.Drawing.Size(152, 22);
            this.FormatHeading3Button.Text = "Heading 3";
            // 
            // FormatCodeButton
            // 
            this.FormatCodeButton.Image = ((System.Drawing.Image)(resources.GetObject("FormatCodeButton.Image")));
            this.FormatCodeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatCodeButton.Name = "FormatCodeButton";
            this.FormatCodeButton.Size = new System.Drawing.Size(52, 22);
            this.FormatCodeButton.Text = "Code";
            // 
            // FormatBlockquoteButton
            // 
            this.FormatBlockquoteButton.Image = ((System.Drawing.Image)(resources.GetObject("FormatBlockquoteButton.Image")));
            this.FormatBlockquoteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatBlockquoteButton.Name = "FormatBlockquoteButton";
            this.FormatBlockquoteButton.Size = new System.Drawing.Size(79, 22);
            this.FormatBlockquoteButton.Text = "Blockquote";
            // 
            // FormatHorizontalRuleButton
            // 
            this.FormatHorizontalRuleButton.Image = ((System.Drawing.Image)(resources.GetObject("FormatHorizontalRuleButton.Image")));
            this.FormatHorizontalRuleButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FormatHorizontalRuleButton.Name = "FormatHorizontalRuleButton";
            this.FormatHorizontalRuleButton.Size = new System.Drawing.Size(41, 22);
            this.FormatHorizontalRuleButton.Text = "HR";
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
            // MemoPopup
            // 
            this.MemoPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem1,
            this.hideFormattingToolbarToolStripMenuItem,
            this.showFormattingToolbarToolStripMenuItem});
            this.MemoPopup.Name = "MemoPopup";
            this.MemoPopup.Size = new System.Drawing.Size(195, 120);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(191, 6);
            // 
            // hideFormattingToolbarToolStripMenuItem
            // 
            this.hideFormattingToolbarToolStripMenuItem.Name = "hideFormattingToolbarToolStripMenuItem";
            this.hideFormattingToolbarToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.hideFormattingToolbarToolStripMenuItem.Text = "Hide Formatting Toolbar";
            // 
            // showFormattingToolbarToolStripMenuItem
            // 
            this.showFormattingToolbarToolStripMenuItem.Name = "showFormattingToolbarToolStripMenuItem";
            this.showFormattingToolbarToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.showFormattingToolbarToolStripMenuItem.Text = "Show Formatting Toolbar";
            // 
            // MemoEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "MemoEditor";
            this.Size = new System.Drawing.Size(519, 232);
            this.MemoToolbar.ResumeLayout(false);
            this.MemoToolbar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MemoPopup.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripDropDownButton FormatHeadingDropdown;
        private System.Windows.Forms.ToolStripMenuItem FormatHeading1Button;
        private System.Windows.Forms.ToolStripMenuItem FormatHeading2Button;
        private System.Windows.Forms.ToolStripMenuItem FormatHeading3Button;
        private System.Windows.Forms.ToolStripButton FormatCodeButton;
        private System.Windows.Forms.ToolStripButton FormatBlockquoteButton;
        private System.Windows.Forms.ToolStripButton FormatHorizontalRuleButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip MemoPopup;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hideFormattingToolbarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showFormattingToolbarToolStripMenuItem;
        internal System.Windows.Forms.RichTextBox MemoEntry;
    }
}
