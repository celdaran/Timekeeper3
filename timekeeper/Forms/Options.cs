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
            Values = optionValues;
            MainMenu = mainMenu;
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

        private void PopulateForm()
        {
            //----------------------------------------------
            // Populate various dropdowns
            //----------------------------------------------

            string[] SortKeys = new string[5] { 
                "Alphabetically",
                "as Placed",
                "by Created Date",
                "by Modified Date",
                "by External Project Number" };
            AddItems(Layout_SortProjectsBy, SortKeys);

            SortKeys = new string[4] { 
                "Alphabetically",
                "as Placed",
                "by Created Date",
                "by Modified Date"};
            AddItems(Layout_SortItemsBy, SortKeys);

            SortKeys = new string[5] { 
                "Today",
                "The Last Week",
                "The Last Month",
                "The Last Year",
                "Ever"};
            AddItems(View_HiddenProjectsSince, SortKeys);
            AddItems(View_HiddenActivitiesSince, SortKeys);
            AddItems(View_HiddenLocationsSince, SortKeys);
            AddItems(View_HiddenCategoriesSince, SortKeys);

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

            // Give it an image (FIXME: base this on type: menu item vs toolbar item)
            NewItem.ImageIndex = 0;

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

    }
}
