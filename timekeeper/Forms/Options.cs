using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    public partial class Options : Form
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private MenuStrip MainMenu;

        public Classes.Options Values { get; set; }

        const int CTRL = (int)Keys.Control;
        const int SHIFT = (int)Keys.Shift;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Options(Classes.Options optionValues, MenuStrip mainMenu)
        {
            InitializeComponent();

            OptionsPanelCollection.DrawItem += new DrawItemEventHandler(OptionsPanelCollection_DrawItem);

            Values = optionValues;
            MainMenu = mainMenu;

            panel2.Height = 0;
        }

        //----------------------------------------------------------------------
        // Event Handlers
        //----------------------------------------------------------------------

        private void Options_Load(object sender, EventArgs e)
        {
            PopulateForm();
            OptionsToForm();
        }

        //----------------------------------------------------------------------

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) {
                FormToOptions();
            } else {
                if (Common.WarnPrompt("Are you sure?") != DialogResult.Yes) {
                    e.Cancel = true;
                }
            }
        }

        private void AddItems(ComboBox box, string[] strings)
        {
            int Index = 0;
            foreach (string Item in strings) {
                IdValuePair Pair = new IdValuePair(Index, Item);
                box.Items.Add(Pair);
                Index++;
            }
        }

        private void AddItems(CheckedListBox box, string[] strings)
        {
            int Index = 0;
            foreach (string Item in strings) {
                IdValuePair Pair = new IdValuePair(Index, Item);
                box.Items.Add(Pair);
                //box.Items[Index];
                Index++;
            }
        }

        private void PopulateForm()
        {
            //----------------------------------------------
            // Populate various dropdowns
            //----------------------------------------------

            string[] Entries = new string[5] { 
                "Alphabetically",
                "as Placed",
                "by Created Date",
                "by Modified Date",
                "by External Project Number" };
            AddItems(Layout_SortProjectsBy, Entries);

            Entries = new string[4] { 
                "Alphabetically",
                "as Placed",
                "by Created Date",
                "by Modified Date"};
            AddItems(Layout_SortItemsBy, Entries);

            Entries = new string[5] { 
                "Today",
                "The Last Week",
                "The Last Month",
                "The Last Year",
                "Ever"};
            AddItems(View_HiddenProjectsSince, Entries);
            AddItems(View_HiddenActivitiesSince, Entries);
            AddItems(View_HiddenLocationsSince, Entries);
            AddItems(View_HiddenCategoriesSince, Entries);

            // Populate View Status Bar Collection

            Entries = new string[7] { 
                "Project Name",
                "Activity Name",
                "Elapsed Since Start",
                "Elapsed Time Today for Current Project",
                "Elapsed Time Today for Current Activity",
                "Total Elapsed Time Today",
                "Currently Opened File Name"};
            //AddItems(View_StatusBar_Collection, Entries);

            //----------------------------------------------
            // Populate Font List
            //----------------------------------------------

            InstalledFontCollection fonts = new InstalledFontCollection();
            FontFamily[] fontFamilies = fonts.Families;

            foreach (FontFamily font in fonts.Families) {
                Report_FontList.Items.Add(font.Name);
            }

            //----------------------------------------------
            // Populate Keyboard Function List
            //----------------------------------------------

            try {
                PopulateFunctionList(MainMenu.Items, "");
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

        }

        private void PopulateFunctionList(ToolStripItemCollection items, string parentText)
        {
            foreach (ToolStripItem Item in items) {
                if (Item.GetType().ToString() == "System.Windows.Forms.ToolStripMenuItem") {
                    ToolStripMenuItem MenuItem = (ToolStripMenuItem)Item;
                    if (MenuItem.Name != "MenuFileRecent") {
                        string MenuItemName = GetMenuItemName(parentText, MenuItem.Text);
                        if (MenuItem.HasDropDownItems) {
                            PopulateFunctionList(MenuItem.DropDownItems, MenuItemName);
                        } else {
                            AddKeyboardMapping(MenuItem, MenuItemName);
                        }
                    }
                }
            }
        }

        private void AddKeyboardMapping(ToolStripMenuItem MenuItem, string MenuItemName)
        {
            // Add this menu item to the function list
            ListViewItem NewItem = wFunctionList.Items.Add(MenuItemName);

            if (Values.Keyboard_FunctionList.Count == 0) {
                // If no items on function list, this is our first time through
                // this process and we (indirectly) seed the list with the
                // current shortcut definitions for each menu item
                NewItem.Tag = MenuItem.ShortcutKeys;
            } else {
                // At this point we have, e.g., MenuItem.Name = "MenuFileNew"
                // So we need to find "MenuFileNew" on our list of items
                // fetched from the registry and use it's (int)Object value.
                NameObjectPair Pair = FindKeyboardMapping(MenuItem.Name);
                NewItem.Tag = (Keys)Pair.Object;
            }

            // Give it an image
            string Temp = MenuItem.Name.Substring(0, 11);
            if (Temp == "MenuToolbar") {
                NewItem.ImageIndex = 1;
            } else {
                NewItem.ImageIndex = 0;
            }

            // Add a friendly string representing the keys
            if ((int)NewItem.Tag > 0) {
                KeysConverter Converter = new KeysConverter();
                string ShortCut = Converter.ConvertToString((Keys)NewItem.Tag);

                // Throw the second column on there
                NewItem.SubItems.Add(ShortCut);
            } else {
                NewItem.SubItems.Add(""); // Necessary?
            }

            // Hidden column holds our key
            NewItem.SubItems.Add(MenuItem.Name);
        }

        private NameObjectPair FindKeyboardMapping(string match)
        {
            foreach (NameObjectPair Pair in Values.Keyboard_FunctionList) {
                if (Pair.Name == match) {
                    return Pair;
                }
            }
            return new NameObjectPair();
        }

        private string GetMenuItemName(string parentText, string itemText)
        {
            string returnText = "";
            if (parentText == "") {
                returnText = itemText;
            } else {
                returnText = parentText + " | " + itemText;
            }
            return returnText.Replace("&", "").Replace("...", "");
        }

        //----------------------------------------------------------------------
        // Options Setter/Getters
        //----------------------------------------------------------------------

        private void OptionsToForm()
        {
            //----------------------------------------------------------------------

            Layout_UseProjects.Checked = Values.Layout_UseProjects;
            Layout_UseActivities.Checked = Values.Layout_UseActivities;
            Layout_UseLocations.Checked = Values.Layout_UseLocations;
            Layout_UseCategories.Checked = Values.Layout_UseCategories;

            Layout_SortProjectsBy.SelectedIndex = Values.Layout_SortProjectsBy;
            Layout_SortProjectsByDirection.SelectedIndex = Values.Layout_SortProjectsByDirection;
            Layout_SortItemsBy.SelectedIndex = Values.Layout_SortItemsBy;
            Layout_SortItemsByDirection.SelectedIndex = Values.Layout_SortItemsByDirection;

            //----------------------------------------------------------------------

            View_StatusBar.Checked = Values.View_StatusBar;
            View_StatusBar_ProjectName.Checked = Values.View_StatusBar_ProjectName;
            View_StatusBar_ActivityName.Checked = Values.View_StatusBar_ActivityName;
            View_StatusBar_ElapsedSinceStart.Checked = Values.View_StatusBar_ElapsedSinceStart;
            View_StatusBar_ElapsedProjectToday.Checked = Values.View_StatusBar_ElapsedProjectToday;
            View_StatusBar_ElapsedActivityToday.Checked = Values.View_StatusBar_ElapsedActivityToday;
            View_StatusBar_ElapsedAllToday.Checked = Values.View_StatusBar_ElapsedAllToday;
            View_StatusBar_FileName.Checked = Values.View_StatusBar_FileName;

            View_HiddenProjects.Checked = Values.View_HiddenProjects;
            View_HiddenActivities.Checked = Values.View_HiddenActivities;
            View_HiddenLocations.Checked = Values.View_HiddenLocations;
            View_HiddenCategories.Checked = Values.View_HiddenCategories;

            View_HiddenProjectsSince.SelectedIndex = Values.View_HiddenProjectsSince;
            View_HiddenActivitiesSince.SelectedIndex = Values.View_HiddenActivitiesSince;
            View_HiddenLocationsSince.SelectedIndex = Values.View_HiddenLocationsSince;
            View_HiddenCategoriesSince.SelectedIndex = Values.View_HiddenCategoriesSince;

            //----------------------------------------------------------------------

            switch (Values.Behavior_TitleBar) {
                case 0: Behavior_TitleBar_ElapsedSinceStart.Checked = true; break;
                case 1: Behavior_TitleBar_ElapsedProjectToday.Checked = true; break;
                case 2: Behavior_TitleBar_ElapsedActivityToday.Checked = true; break;
                case 3: Behavior_TitleBar_ElapsedAllToday.Checked = true; break;
            }
            Behavior_TitleBar_Template.Text = Values.Behavior_TitleBar_Template;

            Behavior_Window_ShowInTray.Checked = Values.Behavior_Window_ShowInTray;
            Behavior_Window_MinimizeToTray.Checked = Values.Behavior_Window_MinimizeToTray;
            Behavior_Window_MinimizeOnUse.Checked = Values.Behavior_Window_MinimizeOnUse;

            Behavior_Annoy_ActivityFollowsProject.Checked = Values.Behavior_Annoy_ActivityFollowsProject;
            Behavior_Annoy_ProjectFollowsActivity.Checked = Values.Behavior_Annoy_ProjectFollowsActivity;
            Behavior_Annoy_PromptBeforeHiding.Checked = Values.Behavior_Annoy_PromptBeforeHiding;
            Behavior_Annoy_NoRunningPrompt.Checked = Values.Behavior_Annoy_NoRunningPrompt;
            Behavior_Annoy_NoRunningPromptAmount.Value = Values.Behavior_Annoy_NoRunningPromptAmount;

            //----------------------------------------------------------------------

            Report_FontList.SelectedIndex = Report_FontList.FindString(Values.Report_FontName);
            Report_FontSize.Value = Values.Report_FontSize;
            // TODO: Report_StyleSheet.Text = // probably read from a file, unless it's small enough for the registry?

            //----------------------------------------------------------------------

            Advanced_Logging_Application.SelectedIndex = Values.Advanced_Logging_Application;
            Advanced_Logging_Database.SelectedIndex = Values.Advanced_Logging_Database;

            //----------------------------------------------------------------------

            OptionsPanelCollection.SelectedIndex = Values.LastOptionTab;

        }

        //----------------------------------------------------------------------

        private void FormToOptions()
        {
            //----------------------------------------------------------------------

            Values.Layout_UseProjects = Layout_UseProjects.Checked;
            Values.Layout_UseActivities = Layout_UseActivities.Checked;
            Values.Layout_UseLocations = Layout_UseLocations.Checked;
            Values.Layout_UseCategories = Layout_UseCategories.Checked;

            Values.Layout_SortProjectsBy = Layout_SortProjectsBy.SelectedIndex;
            Values.Layout_SortProjectsByDirection = Layout_SortProjectsByDirection.SelectedIndex;
            Values.Layout_SortItemsBy = Layout_SortItemsBy.SelectedIndex;
            Values.Layout_SortItemsByDirection = Layout_SortItemsByDirection.SelectedIndex;

            //----------------------------------------------------------------------

            Values.View_StatusBar = View_StatusBar.Checked;
            Values.View_StatusBar_ProjectName = View_StatusBar_ProjectName.Checked;
            Values.View_StatusBar_ActivityName = View_StatusBar_ActivityName.Checked;
            Values.View_StatusBar_ElapsedSinceStart = View_StatusBar_ElapsedSinceStart.Checked;
            Values.View_StatusBar_ElapsedProjectToday = View_StatusBar_ElapsedProjectToday.Checked;
            Values.View_StatusBar_ElapsedActivityToday = View_StatusBar_ElapsedActivityToday.Checked;
            Values.View_StatusBar_ElapsedAllToday = View_StatusBar_ElapsedAllToday.Checked;
            Values.View_StatusBar_FileName = View_StatusBar_FileName.Checked;

            Values.View_HiddenProjects = View_HiddenProjects.Checked;
            Values.View_HiddenActivities = View_HiddenActivities.Checked;
            Values.View_HiddenLocations = View_HiddenLocations.Checked;
            Values.View_HiddenCategories = View_HiddenCategories.Checked;

            Values.View_HiddenProjectsSince = View_HiddenProjectsSince.SelectedIndex;
            Values.View_HiddenActivitiesSince = View_HiddenActivitiesSince.SelectedIndex;
            Values.View_HiddenLocationsSince = View_HiddenLocationsSince.SelectedIndex;
            Values.View_HiddenCategoriesSince = View_HiddenCategoriesSince.SelectedIndex;

            //----------------------------------------------------------------------

            RadioButton Selected = TitleBarGroup.Controls.OfType<RadioButton>().Where(r => r.Checked == true).FirstOrDefault();
            Values.Behavior_TitleBar = Convert.ToInt32(Selected.Tag);
            Values.Behavior_TitleBar_Template = Behavior_TitleBar_Template.Text;

            Values.Behavior_Window_ShowInTray = Behavior_Window_ShowInTray.Checked;
            Values.Behavior_Window_MinimizeToTray = Behavior_Window_MinimizeToTray.Checked;
            Values.Behavior_Window_MinimizeOnUse = Behavior_Window_MinimizeOnUse.Checked;

            Values.Behavior_Annoy_ActivityFollowsProject = Behavior_Annoy_ActivityFollowsProject.Checked;
            Values.Behavior_Annoy_ProjectFollowsActivity = Behavior_Annoy_ProjectFollowsActivity.Checked;
            Values.Behavior_Annoy_PromptBeforeHiding = Behavior_Annoy_PromptBeforeHiding.Checked;
            Values.Behavior_Annoy_NoRunningPrompt = Behavior_Annoy_NoRunningPrompt.Checked;
            Values.Behavior_Annoy_NoRunningPromptAmount = (int)Behavior_Annoy_NoRunningPromptAmount.Value;

            //----------------------------------------------------------------------

            Values.Keyboard_FunctionList = GetKeyboardMappings();

            //----------------------------------------------------------------------

            Values.Advanced_Logging_Application = Advanced_Logging_Application.SelectedIndex;
            Values.Advanced_Logging_Database = Advanced_Logging_Database.SelectedIndex;

            //----------------------------------------------------------------------

            Values.LastOptionTab = OptionsPanelCollection.SelectedIndex;
        }

        //----------------------------------------------------------------------

        private List<NameObjectPair> GetKeyboardMappings()
        {
            List<NameObjectPair> Mappings = new List<NameObjectPair>();

            foreach (ListViewItem Item in wFunctionList.Items) {
                NameObjectPair Pair = new NameObjectPair(Item.SubItems[2].Text, Item.Tag);
                Mappings.Add(Pair);
            }

            return Mappings;
        }

        //----------------------------------------------------------------------

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        //----------------------------------------------------------------------
        // Uncategorized. Clean this up before submitting final revision.
        //----------------------------------------------------------------------

        private void wFunctionList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem Item = SelectedItem();

            if (Item == null)
                return;

            // Get the Keys value we saved in Tag
            Keys Keys = (Keys)Item.Tag;

            // Update the UI
            wCtrl.Checked = ((Keys & Keys.Control) == Keys.Control);
            wAlt.Checked = ((Keys & Keys.Alt) == Keys.Alt);
            wShift.Checked = ((Keys & Keys.Shift) == Keys.Shift);

            // Seriously? There's gotta be a better way to do this!
            if ((Keys & Keys.Control) == Keys.Control)
                Keys = Keys - (int)Keys.Control;
            if ((Keys & Keys.Alt) == Keys.Alt)
                Keys = Keys - (int)Keys.Alt;
            if ((Keys & Keys.Shift) == Keys.Shift)
                Keys = Keys - (int)Keys.Shift;

            //Common.Info("Key value is now just " + Keys.ToString());

            // Disable the 'Remove' button if no key is assigned
            RemoveKey.Enabled = (Keys != 0);

            wKey.SelectedIndex = wKey.FindStringExact(Keys.ToString());
        }

        private void RemoveKey_Click(object sender, EventArgs e)
        {
            ListViewItem Item = SelectedItem();

            // Clear out keystroke
            Item.Tag = 0;

            // Reset visible attribute
            Item.SubItems[1].Text = ""; // was "None"

            // Clear out controls
            wCtrl.Checked = false;
            wAlt.Checked = false;
            wShift.Checked = false;
            wKey.SelectedIndex = -1;

            // And disable button
            RemoveKey.Enabled = false;
        }

        private void AssignKey_Click(object sender, EventArgs e)
        {
            ListViewItem Item = SelectedItem();

            Keys Keys = 0;

            if (wCtrl.Checked)
                Keys += (int)Keys.Control;
            if (wAlt.Checked)
                Keys += (int)Keys.Alt;
            if (wShift.Checked)
                Keys += (int)Keys.Shift;

            KeysConverter Converter = new KeysConverter();
            Keys += (int)Converter.ConvertFromString((string)wKey.SelectedItem);

            // Assign new keystroke
            Item.Tag = Keys;

            // Reset visible attribute
            Item.SubItems[1].Text = Converter.ConvertToString(Keys);

        }

        private ListViewItem SelectedItem()
        {
            if (wFunctionList.SelectedItems.Count > 0) {
                return wFunctionList.SelectedItems[0];
            } else {
                return null;
            }
        }

        /*
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //Timekeeper.Info("Called OnPaintBackground");
            if (TabRenderer.IsSupported && Application.RenderWithVisualStyles) {
                TabRenderer.DrawTabPage(e.Graphics, this.ClientRectangle);
            } else {
                base.OnPaintBackground(e);
                ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Raised);
            }
        }
        */

        //----------------------------------------------------------------------

        private void OptionsPanelCollection_DrawItem(Object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            Graphics Graphics = e.Graphics;

            Brush TextBrush;
            Brush ButtonBrush;
            Font TabFont;

            // Get the real bounds for the tab rectangle.
            Rectangle TabBounds = OptionsPanelCollection.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected) {
                // Draw a different background color, and don't paint a focus rectangle.
                TextBrush = new SolidBrush(Color.Black); // Ends up white if not set
                ButtonBrush = new System.Drawing.SolidBrush(SystemColors.Control);
                Graphics.FillRectangle(ButtonBrush, e.Bounds);

                // Made active tab text Bold
                TabFont = new Font("Microsoft Sans Serif", e.Font.Size, FontStyle.Bold);
            } else {
                TextBrush = new System.Drawing.SolidBrush(e.ForeColor);
                ButtonBrush = new System.Drawing.SolidBrush(SystemColors.Control);
                Graphics.FillRectangle(ButtonBrush, e.Bounds);

                //e.DrawBackground();

                // Don't change font.
                TabFont = e.Font;
            }

            //_textBrush = new System.Drawing.SolidBrush(e.ForeColor);
            //TextBrush = new System.Drawing.SolidBrush(e.ForeColor);

            //TextBrush = new System.Drawing.SolidBrush(e.ForeColor);

            // Draw string. Center the text.
            StringFormat TextFormat = new StringFormat();
            TextFormat.Alignment = StringAlignment.Center;
            TextFormat.LineAlignment = StringAlignment.Center;

            // Get the item from the collection.
            TabPage Page = OptionsPanelCollection.TabPages[e.Index];

            Graphics.DrawString(Page.Text, TabFont, TextBrush, TabBounds, TextFormat);
        }

        private bool LeaveItAlone;

        private void Layout_UseProjects_CheckedChanged(object sender, EventArgs e)
        {
            if (!Layout_UseProjects.Checked && !Layout_UseProjects.Checked) {
                if (!LeaveItAlone) {
                    LeaveItAlone = true;
                    Layout_UseActivities.Checked = true;
                    LeaveItAlone = false;
                }
            }
            _SetProjectVisibility();
        }

        private void _SetProjectVisibility()
        {
            // Change Visibility
            Label_SortProjects.Visible = Layout_UseProjects.Checked;
            Layout_SortProjectsBy.Visible = Layout_UseProjects.Checked;
            Layout_SortProjectsByDirection.Visible = Layout_UseProjects.Checked;
            View_StatusBar_ProjectName.Visible = Layout_UseProjects.Checked;
            View_StatusBar_ElapsedProjectToday.Visible = Layout_UseProjects.Checked;

            /*
            View_HiddenProjects.Visible = Layout_UseProjects.Checked;
            View_HiddenProjectsSince.Visible = Layout_UseProjects.Checked;
            */
            // Replacement for Above
            HiddenGroupPanelProject.Height = Layout_UseProjects.Checked ? 27 : 0;

            Behavior_TitleBar_ElapsedProjectToday.Visible = Layout_UseProjects.Checked;
            Behavior_Annoy_ActivityFollowsProject.Visible = Layout_UseProjects.Checked;
            Behavior_Annoy_ProjectFollowsActivity.Visible = Layout_UseProjects.Checked;

            // Change Location
            int Offset = 23;
            int Base = 42;

            /* BOO!!! This won't work (even though visibility is set to true, .Visible is false)
            // Array of checkboxes
            List<CheckBox> View_StatusBar_Checkboxes = new List<CheckBox>();
            View_StatusBar_Checkboxes.Add(View_StatusBar_ProjectName);
            View_StatusBar_Checkboxes.Add(View_StatusBar_ActivityName);
            View_StatusBar_Checkboxes.Add(View_StatusBar_ElapsedSinceStart);
            View_StatusBar_Checkboxes.Add(View_StatusBar_ElapsedProjectToday);
            View_StatusBar_Checkboxes.Add(View_StatusBar_ElapsedActivityToday);
            View_StatusBar_Checkboxes.Add(View_StatusBar_ElapsedAllToday);
            View_StatusBar_Checkboxes.Add(View_StatusBar_FileName);

            int Index = 0;
            foreach (CheckBox Box in View_StatusBar_Checkboxes) {
                if (Box.Visible) {
                    Box.Top = Base + (Offset * Index);
                    Index++;
                }
            }
            */

            if (Layout_UseProjects.Checked) {
                View_StatusBar_ProjectName.Top = Base;
                View_StatusBar_ActivityName.Top = Base + (Offset * 1);
                View_StatusBar_ElapsedSinceStart.Top = Base + (Offset * 2);
                View_StatusBar_ElapsedProjectToday.Top = Base + (Offset * 3);
                View_StatusBar_ElapsedActivityToday.Top = Base + (Offset * 4);
                View_StatusBar_ElapsedAllToday.Top = Base + (Offset * 5);
                View_StatusBar_FileName.Top = Base + (Offset * 6);
                StatusBarGroup.Height = 215;
                HiddenGroup.Top = 237;
                SortingGroup.Height = 81;
            } else {
                View_StatusBar_ActivityName.Top = Base;
                View_StatusBar_ElapsedSinceStart.Top = Base + (Offset * 1);
                View_StatusBar_ElapsedActivityToday.Top = Base + (Offset * 2);
                View_StatusBar_ElapsedAllToday.Top = Base + (Offset * 3);
                View_StatusBar_FileName.Top = Base + (Offset * 4);
                StatusBarGroup.Height = 215 - (Offset * 2);
                HiddenGroup.Top = 237 - (Offset * 2);
                SortingGroup.Height = 81 - Offset;
            }

            /*
            Offset = 27;
            Base = 19;

            if (Layout_UseProjects.Checked) {
                View_HiddenProjects.Top = Base;
                View_HiddenProjectsSince.Top = Base;
                View_HiddenActivities.Top = Base + (Offset * 1);
                View_HiddenActivitiesSince.Top = Base + (Offset * 1);
                View_HiddenLocations.Top = Base + (Offset * 2);
                View_HiddenLocationsSince.Top = Base + (Offset * 2);
                View_HiddenCategories.Top = Base + (Offset * 3);
                View_HiddenCategoriesSince.Top = Base + (Offset * 3);
                HiddenGroup.Height = 140;
            } else {
                View_HiddenActivities.Top = Base;
                View_HiddenActivitiesSince.Top = Base;
                View_HiddenLocations.Top = Base + (Offset * 1);
                View_HiddenLocationsSince.Top = Base + (Offset * 1);
                View_HiddenCategories.Top = Base + (Offset * 2);
                View_HiddenCategoriesSince.Top = Base + (Offset * 2);
                HiddenGroup.Height = 140 - Offset;
            }
            */

            Offset = 23;
            Base = 71;

            if (Layout_UseProjects.Checked) {
                Behavior_TitleBar_ElapsedProjectToday.Top = Base;
                Behavior_TitleBar_ElapsedActivityToday.Top = Base + (Offset * 1);
                Behavior_TitleBar_ElapsedAllToday.Top = Base + (Offset * 2);
                TitleBarGroup.Height = 147;
                AnnoyGroup.Height = 116;
                WindowControlGroup.Top = 169;
                AnnoyGroup.Top = 275;
            } else {
                Behavior_TitleBar_ElapsedActivityToday.Top = Base;
                Behavior_TitleBar_ElapsedAllToday.Top = Base + (Offset * 1);
                TitleBarGroup.Height = 147 - Offset;
                AnnoyGroup.Height = 116 - (Offset * 2);
                WindowControlGroup.Top = 169 - Offset;
                AnnoyGroup.Top = 275 - Offset;
            }
        }

        private void Layout_UseActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (!Layout_UseProjects.Checked && !Layout_UseProjects.Checked) {
                if (!LeaveItAlone) {
                    LeaveItAlone = true;
                    Layout_UseProjects.Checked = true;
                    LeaveItAlone = false;
                }
            }

            /*
            View_StatusBar_ActivityName.Enabled = Layout_UseActivities.Checked;
            View_StatusBar_ElapsedActivityToday.Enabled = Layout_UseActivities.Checked;
            View_HiddenActivities.Enabled = Layout_UseActivities.Checked;
            View_HiddenActivitiesSince.Enabled = Layout_UseActivities.Checked;
            */

            _SetActivityVisibility();
        }

        private void _SetActivityVisibility()
        {
            // Change Visibility
            View_StatusBar_ActivityName.Visible = Layout_UseActivities.Checked;
            View_StatusBar_ElapsedActivityToday.Visible = Layout_UseActivities.Checked;

            /*
            View_HiddenActivities.Visible = Layout_UseActivities.Checked;
            View_HiddenActivitiesSince.Visible = Layout_UseActivities.Checked;
            */
            // Replacement for above
            HiddenGroupPanelActivity.Height = Layout_UseActivities.Checked ? 27 : 0;

            Behavior_TitleBar_ElapsedActivityToday.Visible = Layout_UseActivities.Checked;
            Behavior_Annoy_ActivityFollowsProject.Visible = Layout_UseActivities.Checked;
            Behavior_Annoy_ProjectFollowsActivity.Visible = Layout_UseActivities.Checked;

            // Change Location
            int Offset = 23;
            int Base = 42;

            if (Layout_UseActivities.Checked) {
                View_StatusBar_ProjectName.Top = Base;
                View_StatusBar_ActivityName.Top = Base + (Offset * 1);
                View_StatusBar_ElapsedSinceStart.Top = Base + (Offset * 2);
                View_StatusBar_ElapsedProjectToday.Top = Base + (Offset * 3);
                View_StatusBar_ElapsedActivityToday.Top = Base + (Offset * 4);
                View_StatusBar_ElapsedAllToday.Top = Base + (Offset * 5);
                View_StatusBar_FileName.Top = Base + (Offset * 6);
                StatusBarGroup.Height = 215;
                HiddenGroup.Top = 237;
            } else {
                View_StatusBar_ProjectName.Top = Base;
                View_StatusBar_ElapsedSinceStart.Top = Base + (Offset * 1);
                View_StatusBar_ElapsedProjectToday.Top = Base + (Offset * 2);
                View_StatusBar_ElapsedAllToday.Top = Base + (Offset * 3);
                View_StatusBar_FileName.Top = Base + (Offset * 4);
                StatusBarGroup.Height = 215 - (Offset * 2);
                HiddenGroup.Top = 237 - (Offset * 2);
            }

            /*
            Offset = 27;
            Base = 19;

            if (Layout_UseActivities.Checked) {
                View_HiddenProjects.Top = Base;
                View_HiddenProjectsSince.Top = Base;
                View_HiddenActivities.Top = Base + (Offset * 1);
                View_HiddenActivitiesSince.Top = Base + (Offset * 1);
                View_HiddenLocations.Top = Base + (Offset * 2);
                View_HiddenLocationsSince.Top = Base + (Offset * 2);
                View_HiddenCategories.Top = Base + (Offset * 3);
                View_HiddenCategoriesSince.Top = Base + (Offset * 3);
                HiddenGroup.Height = 140;
            } else {
                View_HiddenProjects.Top = Base;
                View_HiddenProjectsSince.Top = Base;
                View_HiddenLocations.Top = Base + (Offset * 1);
                View_HiddenLocationsSince.Top = Base + (Offset * 1);
                View_HiddenCategories.Top = Base + (Offset * 2);
                View_HiddenCategoriesSince.Top = Base + (Offset * 2);
                HiddenGroup.Height = 140 - Offset;
            }
            */

            Offset = 23;
            Base = 71;

            if (Layout_UseActivities.Checked) {
                Behavior_TitleBar_ElapsedProjectToday.Top = Base;
                Behavior_TitleBar_ElapsedActivityToday.Top = Base + (Offset * 1);
                Behavior_TitleBar_ElapsedAllToday.Top = Base + (Offset * 2);
                TitleBarGroup.Height = 147;
                AnnoyGroup.Height = 116;
                WindowControlGroup.Top = 169;
                AnnoyGroup.Top = 275;
            } else {
                Behavior_TitleBar_ElapsedProjectToday.Top = Base;
                Behavior_TitleBar_ElapsedAllToday.Top = Base + (Offset * 1);
                TitleBarGroup.Height = 147 - Offset;
                AnnoyGroup.Height = 116 - (Offset * 2);
                WindowControlGroup.Top = 169 - Offset;
                AnnoyGroup.Top = 275 - Offset;
            }

        }

        private void View_StatusBar_CheckedChanged(object sender, EventArgs e)
        {
            View_StatusBar_ProjectName.Enabled = View_StatusBar.Checked;
            View_StatusBar_ActivityName.Enabled = View_StatusBar.Checked;
            View_StatusBar_ElapsedSinceStart.Enabled = View_StatusBar.Checked;
            View_StatusBar_ElapsedProjectToday.Enabled = View_StatusBar.Checked;
            View_StatusBar_ElapsedActivityToday.Enabled = View_StatusBar.Checked;
            View_StatusBar_ElapsedAllToday.Enabled = View_StatusBar.Checked;
            View_StatusBar_FileName.Enabled = View_StatusBar.Checked;
            View_StatusBar_AddLabels.Enabled = View_StatusBar.Checked;
        }

        private void View_HiddenProjects_CheckedChanged(object sender, EventArgs e)
        {
            View_HiddenProjectsSince.Enabled = View_HiddenProjects.Checked;
        }

        private void View_HiddenActivities_CheckedChanged(object sender, EventArgs e)
        {
            View_HiddenActivitiesSince.Enabled = View_HiddenActivities.Checked;

        }

        private void View_HiddenLocations_CheckedChanged(object sender, EventArgs e)
        {
            View_HiddenLocationsSince.Enabled = View_HiddenLocations.Checked;
        }

        private void View_HiddenCategories_CheckedChanged(object sender, EventArgs e)
        {
            View_HiddenCategoriesSince.Enabled = View_HiddenCategories.Checked;
        }

        private void Behavior_Window_ShowInTray_CheckedChanged(object sender, EventArgs e)
        {
            Behavior_Window_MinimizeToTray.Enabled = Behavior_Window_ShowInTray.Checked;
        }

        private void Layout_UseLocations_CheckedChanged(object sender, EventArgs e)
        {
            View_HiddenLocations.Visible = Layout_UseLocations.Checked;
            View_HiddenLocationsSince.Visible = Layout_UseLocations.Checked;
        }

        private void Layout_UseCategories_CheckedChanged(object sender, EventArgs e)
        {
            View_HiddenCategories.Visible = Layout_UseCategories.Checked;
            View_HiddenCategoriesSince.Visible = Layout_UseCategories.Checked;
        }

        //----------------------------------------------------------------------

    }
}
