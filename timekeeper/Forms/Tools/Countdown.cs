using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Tools
{
    public partial class Countdown : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private string EventName;
        private DateTime TargetTime;
        private Classes.Widgets Widgets;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Countdown()
        {
            InitializeComponent();
            this.Widgets = new Classes.Widgets();
            this.EventName = "";
        }

        //----------------------------------------------------------------------
        // Toolbar Events
        //----------------------------------------------------------------------

        private void CreateEventButton_Click(object sender, EventArgs e)
        {
            /*
            Forms.Tools.CountdownEvent DialogBox = new Forms.Tools.CountdownEvent(true);
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                TargetTime = DateTime.Now; // DialogBox.EventDateTime.Value;
                SecondTimer.Enabled = true;
            }
            */
        }

        //----------------------------------------------------------------------

        private void LoadEventButton_Click(object sender, EventArgs e)
        {
            ToolStripItem Item = (ToolStripItem)sender;
            Classes.BaseView View = (Classes.BaseView)Item.Tag;
            //LoadAndRunGrid(View.Id);
        }

        //----------------------------------------------------------------------

        private void ManageCountdowns_Click(object sender, EventArgs e)
        {
            Forms.Shared.ManageViews DialogBox = new Forms.Shared.ManageViews("Event");
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                //PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------
        // Other Events
        //----------------------------------------------------------------------

        private void SecondTimer_Tick(object sender, EventArgs e)
        {
            DateTime Now = DateTime.Now;
            TimeSpan Delta;

            if (TargetTime.CompareTo(Now) > 0) {
                Delta = TargetTime.Subtract(Now);
                Display.ForeColor = Color.Black;
            } else {
                Delta = Now.Subtract(TargetTime);
                Display.ForeColor = Color.Red;
                SecondTimer.Enabled = false;
                TrayIcon.ShowBalloonTip(10000, "Timekeeper", "Your time is up!", ToolTipIcon.Info);
            }

            Display.Text = "";

            if (Delta.Days > 0) {
                Display.Text = Delta.Days.ToString() + " ";
            }

            Display.Text += String.Format("{0:00}:{1:00}:{2:00}", Delta.Hours, Delta.Minutes, Delta.Seconds);
            this.Text = Display.Text + " - Countdown";
            if (this.EventName != "") {
                this.Text += " (" + this.EventName + ")";
            }
        }

        //----------------------------------------------------------------------

        private void Countdown_ResizeEnd(object sender, EventArgs e)
        {
            if (!DynamicSizeButton.Checked) {
                return;
            }

            int LoopLimit = 1000;
            int Counter = 0;

            while (Display.Width < TextRenderer.MeasureText(Display.Text, new Font(Display.Font.FontFamily, Display.Font.Size, Display.Font.Style)).Width) {
                Display.Font = new Font(Display.Font.FontFamily, Display.Font.Size - 0.5f, Display.Font.Style);
                Counter++;
                if (Counter > LoopLimit)
                    return;
            }

            Counter = 0;
            while (Display.Width > TextRenderer.MeasureText(Display.Text, new Font(Display.Font.FontFamily, Display.Font.Size, Display.Font.Style)).Width) {
                Display.Font = new Font(Display.Font.FontFamily, Display.Font.Size + 0.5f, Display.Font.Style);
                Counter++;
                if (Counter > LoopLimit)
                    return;
            }
        }

        private void Display_KeyDown(object sender, KeyEventArgs e)
        {
            /*
            if (
                ((e.KeyCode >= Keys.D0) && (e.KeyCode <= Keys.D9)) || 
                 (e.KeyCode == Keys.Space) ||
                ((e.KeyCode == Keys.OemSemicolon) && (Control.ModifierKeys == Keys.Shift))
               )
            {
                //Common.Info("Valid keystroke");
            } else {
                e.SuppressKeyPress = true;
                return;
            }
            */

            if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z)) {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Enter) {
                try {
                    // Compress multiple spaces down to single spaces
                    RegexOptions options = RegexOptions.None;
                    Regex regex = new Regex(@"[ ]{2,}", options);
                    Display.Text = regex.Replace(Display.Text, @" ");

                    // Split into day & time components
                    string[] MainParts = Display.Text.Split(' ');

                    TimeSpan Delta;

                    // Set days (if any)
                    if (MainParts.Length > 1) {
                        // Set days
                        int Days = Convert.ToInt32(MainParts[0]);

                        // Set time
                        string[] Parts = MainParts[1].Split(':');
                        int Hours = Convert.ToInt32(Parts[0]);
                        int Minutes = Convert.ToInt32(Parts[1]);
                        int Seconds = Convert.ToInt32(Parts[2]);

                        // Set span
                        Seconds++;
                        Delta = new TimeSpan(Days, Hours, Minutes, Seconds);
                    } else {
                        // Set time
                        string[] Parts = MainParts[0].Split(':');
                        int Hours = Convert.ToInt32(Parts[0]);
                        int Minutes = Convert.ToInt32(Parts[1]);
                        int Seconds = Convert.ToInt32(Parts[2]);

                        // Set span
                        Seconds++;
                        Delta = new TimeSpan(Hours, Minutes, Seconds);
                    }

                    TargetTime = DateTime.Now.Add(Delta);

                    Display.BackColor = SystemColors.Control;
                    ToolStrip.Focus();
                    SecondTimer.Enabled = true;
                }
                catch {
                    Common.Warn("Invalid input. Enter something better.");
                }
            }
        }

        private void Display_Enter(object sender, EventArgs e)
        {
            //Display.Font = new Font(Display.Font.FontFamily, 8.25f, Display.Font.Style);
            SecondTimer.Enabled = false;
            Display.BackColor = SystemColors.Window;
        }

        private void SmallSizeButton_Click(object sender, EventArgs e)
        {
            Display.Font = new Font(Display.Font.FontFamily, 20.25f, Display.Font.Style);

            this.Width = 415;
            this.Height = 90;

            SmallSizeButton.Checked = true;
            MediumSizeButton.Checked = false;
            LargeSizeButton.Checked = false;
            DynamicSizeButton.Checked = false;
        }

        private void MediumSizeButton_Click(object sender, EventArgs e)
        {
            Display.Font = new Font(Display.Font.FontFamily, 40.0f, Display.Font.Style);

            this.Width = 415;
            this.Height = 120;

            SmallSizeButton.Checked = false;
            MediumSizeButton.Checked = true;
            LargeSizeButton.Checked = false;
            DynamicSizeButton.Checked = false;
        }

        private void LargeSizeButton_Click(object sender, EventArgs e)
        {
            Display.Font = new Font(Display.Font.FontFamily, 72.0f, Display.Font.Style);

            this.Width = 500;
            this.Height = 300;

            SmallSizeButton.Checked = false;
            MediumSizeButton.Checked = false;
            LargeSizeButton.Checked = true;
            DynamicSizeButton.Checked = false;
        }

        private void DynamicSizeButton_Click(object sender, EventArgs e)
        {
            SmallSizeButton.Checked = false;
            MediumSizeButton.Checked = false;
            LargeSizeButton.Checked = false;
            DynamicSizeButton.Checked = true;
        }

        private void AlwaysOnTopButton_Click(object sender, EventArgs e)
        {
            AlwaysOnTopButton.Checked = !AlwaysOnTopButton.Checked;
            this.TopMost = AlwaysOnTopButton.Checked;
        }

        //----------------------------------------------------------------------
        // TODO: Rearrange all this, of course
        //----------------------------------------------------------------------

        private void PopulateLoadMenu()
        {
            // Common functions
            this.Widgets.PopulateLoadMenu("GridView", ToolStrip);

            // Grid-specific function
            foreach (ToolStripItem Item in LoadEventMenu.DropDownItems) {
                Item.Click += new System.EventHandler(this.LoadEventButton_Click);
            }
        }

        //----------------------------------------------------------------------

    }
}
