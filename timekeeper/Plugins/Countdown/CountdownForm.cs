using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using Technitivity.Toolbox;

//------------------------------------------------------------------------------
/*

This is my prototype for creating Timekeeper plugins. The idea is that all items
currently (as of 3.0.511.0) on the Tools menu (apart from Options) are plugins
(and that "Tool" is simply what Timekeeper calls a plugin, at least to the end
user). There are official Technitivity-provided plugins and the projects for
those are in the Timekeeper solution itself. There is also a spec and interface
so third-party developers can create their own.

I have a lot to work out and I won't have time for this for Timekeeper 3.0, but
I did want to get my thoughts and ideas out there in preparation for this move.

I've tried a simple plugin in 3.0.511.0 and it worked. I created a completely
separate Timekeeper.Plugins solution (where the instantiation and run commands
were implemented and functional). However, I stopped at the point where I needed
integration points that were beyond my means to create on the current timeline.
In short:

1. Plugins need to be able to register events/callbacks that Timekeeper can
   trigger at the appropriate moments.
2. Access to the database is needed. Without having to pass the raw DBI object
   to the plugin for complete and unfettered access to the TKDB file. I need
   to design an interface that allows read access to TK-owned tables (or with
   appropriate write-access via an API) as well as write access to plugin-owned
   tables.

Upon subsequent thinking, I'm adding the following as I come across them.

3. Plugins need to be aware of other plugins. This one is an example: the 
   Countdown plugin should be able to see if the Scheduler plugin is available,
   and, if so, query it for information.
4. Plugins should be able to share standard TK widgets, like building uniform
   treeviews with. So I need to find a way to expose these functions.
5. Plugins required configuration attributes such as: can run multiple instances,
   or only one at a time, or are modal, and so on.

*/
//------------------------------------------------------------------------------

namespace Timekeeper.Plugins
{
    public partial class CountdownForm : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DateTime TargetTime;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public CountdownForm()
        {
            InitializeComponent();
        }

        //----------------------------------------------------------------------
        // Toolbar Events
        //----------------------------------------------------------------------

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
            if ((e.KeyCode >= Keys.A) && (e.KeyCode <= Keys.Z)) {
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Enter) {
                try {
                    BeginCountdown();
                }
                catch {
                    Common.Warn("Invalid input. Enter something better.");
                }
            }
        }

        private void BeginCountdown()
        {
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

        private void Display_Enter(object sender, EventArgs e)
        {
            //Display.Font = new Font(Display.Font.FontFamily, 8.25f, Display.Font.Style);
            SecondTimer.Enabled = false;
            Display.BackColor = SystemColors.Window;
        }

        private void SmallSizeButton_Click(object sender, EventArgs e)
        {
            Display.Font = new Font(Display.Font.FontFamily, 20.25f, Display.Font.Style);

            this.Width = 300;
            this.Height = 85;

            SmallSizeButton.Checked = true;
            MediumSizeButton.Checked = false;
            LargeSizeButton.Checked = false;
            DynamicSizeButton.Checked = false;
        }

        private void MediumSizeButton_Click(object sender, EventArgs e)
        {
            Display.Font = new Font(Display.Font.FontFamily, 40.0f, Display.Font.Style);

            this.Width = 415;
            this.Height = 110;

            SmallSizeButton.Checked = false;
            MediumSizeButton.Checked = true;
            LargeSizeButton.Checked = false;
            DynamicSizeButton.Checked = false;
        }

        private void LargeSizeButton_Click(object sender, EventArgs e)
        {
            Display.Font = new Font(Display.Font.FontFamily, 72.0f, Display.Font.Style);

            this.Width = 720;
            this.Height = 160;

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

    }
}
