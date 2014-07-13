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
        public bool InterfaceChanged { get; set; }

        const int CTRL = (int)Keys.Control;
        const int SHIFT = (int)Keys.Shift;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Options(Classes.Options optionValues, MenuStrip mainMenu)
        {
            InitializeComponent();

            OptionsPanelCollection.DrawItem += new DrawItemEventHandler(OptionsPanelCollection_DrawItem);

            this.Values = optionValues;
            this.MainMenu = mainMenu;
        }

        //----------------------------------------------------------------------
        // Event Handlers
        //----------------------------------------------------------------------

        private void Options_Load(object sender, EventArgs e)
        {
            PopulateForm();
            OptionsToForm();

            // Last pass: dynamic interface changes
            Layout_UseProjects_CheckedChanged(sender, e);
            Layout_UseActivities_CheckedChanged(sender, e);
            Layout_UseLocations_CheckedChanged(sender, e);
            Layout_UseCategories_CheckedChanged(sender, e);

            View_MemoEditor_CheckedChanged(sender, e);
            View_StatusBar_CheckedChanged(sender, e);
            View_MemoEditor_ShowToolbar_CheckedChanged(sender, e);
        }

        //----------------------------------------------------------------------

        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK) {
                FormToOptions();
            } else {
                /*
                if (Common.WarnPrompt("Are you sure?") != DialogResult.Yes) {
                    e.Cancel = true;
                }
                */
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

        private void AddItems(ComboBox box, List<IdValuePair> list)
        {
            foreach (IdValuePair Pair in list) {
                box.Items.Add(Pair);
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
            AddItems(Behavior_SortProjectsBy, Entries);

            Entries = new string[4] { 
                "Alphabetically",
                "as Placed",
                "by Created Date",
                "by Modified Date"};
            AddItems(Behavior_SortItemsBy, Entries);

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

            try {
                PopulateFontList();
                PopulateFunctionList(MainMenu.Items, "");
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

        }

        private void PopulateFontList()
        {
            InstalledFontCollection fonts = new InstalledFontCollection();
            FontFamily[] fontFamilies = fonts.Families;

            foreach (FontFamily font in fonts.Families) {
                Report_FontList.Items.Add(font.Name);
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

        private void PopulateTitleBarTimeList()
        {
            Behavior_TitleBar_Time.Items.Clear();
            List<IdValuePair> TitleBarTimes = new List<IdValuePair>();
            TitleBarTimes.Add(new IdValuePair(0, "Elapsed time since timer last started"));
            TitleBarTimes.Add(new IdValuePair(1, "Elapsed time today for current project"));
            TitleBarTimes.Add(new IdValuePair(2, "Elapsed time today for current activity"));
            TitleBarTimes.Add(new IdValuePair(3, "Total elapsed time today"));
            AddItems(Behavior_TitleBar_Time, TitleBarTimes);

            Behavior_TitleBar_Time.SelectedIndex = Values.Behavior_TitleBar_Time;
        }

        private void AddKeyboardMapping(ToolStripMenuItem MenuItem, string MenuItemName)
        {
            // Add this menu item to the function list
            ListViewItem NewItem = FunctionList.Items.Add(MenuItemName);

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

                if (Pair.Object == null) {
                    // If we get this far, clearly a new menu item has
                    // appeared and we need to add it to the list.
                    Pair.Name = MenuItem.Name;
                    Pair.Object = MenuItem.ShortcutKeys;
                    Values.Keyboard_FunctionList.Add(Pair);
                }
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
            OptionsPanelCollection.SelectedIndex = Values.LastOptionTab;

            //----------------------------------------------------------------------

            Layout_UseProjects.Checked = Values.Layout_UseProjects;
            Layout_UseActivities.Checked = Values.Layout_UseActivities;
            Layout_UseLocations.Checked = Values.Layout_UseLocations;
            Layout_UseCategories.Checked = Values.Layout_UseCategories;

            //----------------------------------------------------------------------

            View_BrowserToolbar.Checked = Values.View_BrowserToolbar;
            View_MemoEditor.Checked = Values.View_MemoEditor;
            View_ControlPanel.Checked = Values.View_ControlPanel;
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

            View_MemoEditor_ShowToolbar.Checked = Values.View_MemoEditor_ShowToolbar;
            View_MemoEditor_RightMargin.Value = Values.View_MemoEditor_RightMargin;
            View_MemoEditor_ShowGutter.Checked = Values.View_MemoEditor_ShowGutter;
            View_MemoEditor_Font.Text = Values.View_MemoEditor_Font;

            //----------------------------------------------------------------------

            Behavior_TitleBar_Template.Text = Values.Behavior_TitleBar_Template;
            Behavior_TitleBar_Time.SelectedIndex = Values.Behavior_TitleBar_Time;

            Behavior_Window_ShowInTray.Checked = Values.Behavior_Window_ShowInTray;
            Behavior_Window_MinimizeToTray.Checked = Values.Behavior_Window_MinimizeToTray;
            Behavior_Window_MinimizeOnUse.Checked = Values.Behavior_Window_MinimizeOnUse;

            Behavior_Annoy_ActivityFollowsProject.Checked = Values.Behavior_Annoy_ActivityFollowsProject;
            Behavior_Annoy_LocationFollowsProject.Checked = Values.Behavior_Annoy_LocationFollowsProject;
            Behavior_Annoy_CategoryFollowsProject.Checked = Values.Behavior_Annoy_CategoryFollowsProject;
            Behavior_Annoy_PromptBeforeHiding.Checked = Values.Behavior_Annoy_PromptBeforeHiding;
            Behavior_Annoy_NoRunningPrompt.Checked = Values.Behavior_Annoy_NoRunningPrompt;
            Behavior_Annoy_NoRunningPromptAmount.Value = Values.Behavior_Annoy_NoRunningPromptAmount;
            Behavior_Annoy_UseNewDatabaseWizard.Checked = Values.Behavior_Annoy_UseNewDatabaseWizard;

            Behavior_SortProjectsBy.SelectedIndex = Values.Behavior_SortProjectsBy;
            Behavior_SortProjectsByDirection.SelectedIndex = Values.Behavior_SortProjectsByDirection;
            Behavior_SortItemsBy.SelectedIndex = Values.Behavior_SortItemsBy;
            Behavior_SortItemsByDirection.SelectedIndex = Values.Behavior_SortItemsByDirection;
            Behavior_BrowsePrevBy.SelectedIndex = Values.Behavior_BrowsePrevBy;
            Behavior_BrowseNextBy.SelectedIndex = Values.Behavior_BrowseNextBy;

            //----------------------------------------------------------------------

            Report_FontList.SelectedIndex = Report_FontList.FindString(Values.Report_FontName);
            Report_FontSize.Value = Values.Report_FontSize;
            // TODO: Report_StyleSheet.Text = // probably read from a file, unless it's small enough for the registry?

            //----------------------------------------------------------------------

            Mail_FromAddress.Text = Values.Mail_FromAddress;
            Mail_FromDisplayAddress.Text = Values.Mail_FromDisplayAddress;
            Mail_SmtpServer.Text = Values.Mail_SmtpServer;
            Mail_SmtpPort.Text = Values.Mail_SmtpPort.ToString();
            Mail_SmtpServerRequiresSSL.Checked = Values.Mail_SmtpServerRequiresSSL;
            Mail_SmtpTimeout.Value = Values.Mail_SmtpTimeout;
            Mail_SmtpServerUsername.Text = Values.Mail_SmtpServerUsername;
            Mail_SmtpServerPassword.Text = Values.Mail_SmtpServerPassword;

            //----------------------------------------------------------------------

            Advanced_Logging_Application.SelectedIndex = Values.Advanced_Logging_Application;
            Advanced_Logging_Database.SelectedIndex = Values.Advanced_Logging_Database;
            Advanced_Other_MarkupLanguage.SelectedIndex = Values.Advanced_Other_MarkupLanguage;
            Advanced_Other_DimensionWidth.Value = Values.Advanced_Other_DimensionWidth;
        }

        //----------------------------------------------------------------------

        private void FormToOptions()
        {
            Values.LastOptionTab = OptionsPanelCollection.SelectedIndex;

            //----------------------------------------------------------------------

            Values.Layout_UseProjects = Layout_UseProjects.Checked;
            Values.Layout_UseActivities = Layout_UseActivities.Checked;
            Values.Layout_UseLocations = Layout_UseLocations.Checked;
            Values.Layout_UseCategories = Layout_UseCategories.Checked;

            //----------------------------------------------------------------------

            Values.View_BrowserToolbar = View_BrowserToolbar.Checked;
            Values.View_MemoEditor = View_MemoEditor.Checked;
            Values.View_ControlPanel = View_ControlPanel.Checked;
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

            Values.View_MemoEditor_ShowToolbar = View_MemoEditor_ShowToolbar.Checked;
            Values.View_MemoEditor_RightMargin = (int)View_MemoEditor_RightMargin.Value;
            Values.View_MemoEditor_ShowGutter = View_MemoEditor_ShowGutter.Checked;
            Values.View_MemoEditor_Font = View_MemoEditor_Font.Text;

            //----------------------------------------------------------------------

            Values.Behavior_TitleBar_Time = Behavior_TitleBar_Time.SelectedIndex;
            Values.Behavior_TitleBar_Template = Behavior_TitleBar_Template.Text;

            Values.Behavior_Window_ShowInTray = Behavior_Window_ShowInTray.Checked;
            Values.Behavior_Window_MinimizeToTray = Behavior_Window_MinimizeToTray.Checked;
            Values.Behavior_Window_MinimizeOnUse = Behavior_Window_MinimizeOnUse.Checked;

            Values.Behavior_Annoy_ActivityFollowsProject = Behavior_Annoy_ActivityFollowsProject.Checked;
            Values.Behavior_Annoy_LocationFollowsProject = Behavior_Annoy_LocationFollowsProject.Checked;
            Values.Behavior_Annoy_CategoryFollowsProject = Behavior_Annoy_CategoryFollowsProject.Checked;
            Values.Behavior_Annoy_PromptBeforeHiding = Behavior_Annoy_PromptBeforeHiding.Checked;
            Values.Behavior_Annoy_NoRunningPrompt = Behavior_Annoy_NoRunningPrompt.Checked;
            Values.Behavior_Annoy_NoRunningPromptAmount = (int)Behavior_Annoy_NoRunningPromptAmount.Value;
            Values.Behavior_Annoy_UseNewDatabaseWizard = Behavior_Annoy_UseNewDatabaseWizard.Checked;

            Values.Behavior_SortProjectsBy = Behavior_SortProjectsBy.SelectedIndex;
            Values.Behavior_SortProjectsByDirection = Behavior_SortProjectsByDirection.SelectedIndex;
            Values.Behavior_SortItemsBy = Behavior_SortItemsBy.SelectedIndex;
            Values.Behavior_SortItemsByDirection = Behavior_SortItemsByDirection.SelectedIndex;
            Values.Behavior_BrowsePrevBy = Behavior_BrowsePrevBy.SelectedIndex;
            Values.Behavior_BrowseNextBy = Behavior_BrowseNextBy.SelectedIndex;

            //----------------------------------------------------------------------

            Values.Keyboard_FunctionList = GetKeyboardMappings();

            //----------------------------------------------------------------------

            Values.Mail_FromAddress = Mail_FromAddress.Text;
            Values.Mail_FromDisplayAddress = Mail_FromDisplayAddress.Text;
            Values.Mail_SmtpServer = Mail_SmtpServer.Text;
            Values.Mail_SmtpPort = Convert.ToInt32(Mail_SmtpPort.Text);
            Values.Mail_SmtpServerRequiresSSL = Mail_SmtpServerRequiresSSL.Checked;
            Values.Mail_SmtpTimeout = Convert.ToInt32(Mail_SmtpTimeout.Value);
            Values.Mail_SmtpServerUsername = Mail_SmtpServerUsername.Text;
            Values.Mail_SmtpServerPassword = Mail_SmtpServerPassword.Text;

            //----------------------------------------------------------------------

            Values.Advanced_Logging_Application = Advanced_Logging_Application.SelectedIndex;
            Values.Advanced_Logging_Database = Advanced_Logging_Database.SelectedIndex;
            Values.Advanced_Other_MarkupLanguage = Advanced_Other_MarkupLanguage.SelectedIndex;
            Values.Advanced_Other_DimensionWidth = (int)Advanced_Other_DimensionWidth.Value;
        }

        //----------------------------------------------------------------------

        private List<NameObjectPair> GetKeyboardMappings()
        {
            List<NameObjectPair> Mappings = new List<NameObjectPair>();

            foreach (ListViewItem Item in FunctionList.Items) {
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
            ControlKey.Checked = ((Keys & Keys.Control) == Keys.Control);
            AltKey.Checked = ((Keys & Keys.Alt) == Keys.Alt);
            ShiftKey.Checked = ((Keys & Keys.Shift) == Keys.Shift);

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

            KeyCode.SelectedIndex = KeyCode.FindStringExact(Keys.ToString());
        }

        private void RemoveKey_Click(object sender, EventArgs e)
        {
            ListViewItem Item = SelectedItem();

            // Clear out keystroke
            Item.Tag = 0;

            // Reset visible attribute
            Item.SubItems[1].Text = ""; // was "None"

            // Clear out controls
            ControlKey.Checked = false;
            AltKey.Checked = false;
            ShiftKey.Checked = false;
            KeyCode.SelectedIndex = -1;

            // And disable button
            RemoveKey.Enabled = false;
        }

        private void AssignKey_Click(object sender, EventArgs e)
        {
            ListViewItem Item = SelectedItem();

            Keys Keys = 0;

            if (ControlKey.Checked)
                Keys += (int)Keys.Control;
            if (AltKey.Checked)
                Keys += (int)Keys.Alt;
            if (ShiftKey.Checked)
                Keys += (int)Keys.Shift;

            KeysConverter Converter = new KeysConverter();
            Keys += (int)Converter.ConvertFromString((string)KeyCode.SelectedItem);

            // Assign new keystroke
            Item.Tag = Keys;

            // Reset visible attribute
            Item.SubItems[1].Text = Converter.ConvertToString(Keys);

        }

        private ListViewItem SelectedItem()
        {
            if (FunctionList.SelectedItems.Count > 0) {
                return FunctionList.SelectedItems[0];
            } else {
                return null;
            }
        }

        private void View_MemoEditor_ShowToolbar_CheckedChanged(object sender, EventArgs e)
        {
            View_MemoEditor_RightMarginLabel.Enabled = View_MemoEditor_ShowToolbar.Checked;
            View_MemoEditor_RightMargin.Enabled = View_MemoEditor_ShowToolbar.Checked;
            View_MemoEditor_ShowGutter.Enabled = View_MemoEditor_ShowToolbar.Checked;
            /*
            View_MemoEditor_FontButton.Enabled = View_MemoEditor_ShowToolbar.Checked;
            View_MemoEditor_Font.Enabled = View_MemoEditor_ShowToolbar.Checked;
            */
        }

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
            if (!Layout_UseProjects.Checked && !Layout_UseActivities.Checked) {
                if (!LeaveItAlone) {
                    LeaveItAlone = true;
                    Layout_UseActivities.Checked = true;
                    LeaveItAlone = false;
                }
            }
            _SetProjectVisibility();
        }

        private void Layout_UseActivities_CheckedChanged(object sender, EventArgs e)
        {
            if (!Layout_UseProjects.Checked && !Layout_UseActivities.Checked) {
                if (!LeaveItAlone) {
                    LeaveItAlone = true;
                    Layout_UseProjects.Checked = true;
                    LeaveItAlone = false;
                }
            }
            _DisableSortOther();
            _SetActivityVisibility();
        }

        private void Layout_UseLocations_CheckedChanged(object sender, EventArgs e)
        {
            int TallHeight = Layout_UseLocations.Checked ? 27 : 0;
            HiddenGroup_LocationPanel.Height = TallHeight;
            _DisableSortOther();
            _SetLocationVisibility();
        }

        private void Layout_UseCategories_CheckedChanged(object sender, EventArgs e)
        {
            int TallHeight = Layout_UseCategories.Checked ? 27 : 0;
            HiddenGroup_CategoryPanel.Height = TallHeight;
            _DisableSortOther();
            _SetCategoryVisibility();
        }

        private void _DisableSortOther()
        {
            if (Layout_UseActivities.Checked || Layout_UseLocations.Checked || Layout_UseCategories.Checked) {
                SortingGroup_BottomPanel.Height = 27;
            } else {
                SortingGroup_BottomPanel.Height = 0;
            }
        }

        private void _SetProjectVisibility()
        {
            // Define Standard Heights
            int TallHeight = Layout_UseProjects.Checked ? 27 : 0;
            int ShortHeight = Layout_UseProjects.Checked ? 23 : 0;
            int SpecialHeight = (Layout_UseActivities.Checked && Layout_UseProjects.Checked) ? 23 : 0;

            // Set Heights
            SortingGroup_ProjectPanel.Height = TallHeight;
            StatusBarGroup_ProjectNamePanel.Height = ShortHeight;
            StatusBarGroup_ProjectElapsedPanel.Height = ShortHeight;
            HiddenGroup_ProjectPanel.Height = TallHeight;
            AnnoyGroup_ActivityFollowPanel.Height = SpecialHeight;

            if (Layout_UseProjects.Checked) {
                PopulateTitleBarTimeList();
            } else {
                Behavior_TitleBar_Time.Items.RemoveAt(1);
            }

            _Pizza();
        }

        private void _SetActivityVisibility()
        {
            int TallHeight = Layout_UseActivities.Checked ? 27 : 0;
            int ShortHeight = Layout_UseActivities.Checked ? 23 : 0;
            int SpecialHeight = (Layout_UseActivities.Checked && Layout_UseProjects.Checked) ? 23 : 0;

            StatusBarGroup_ActivityNamePanel.Height = ShortHeight;
            StatusBarGroup_ActivityElapsedPanel.Height = ShortHeight;
            HiddenGroup_ActivityPanel.Height = TallHeight;
            AnnoyGroup_ActivityFollowPanel.Height = SpecialHeight;

            if (Layout_UseActivities.Checked) {
                PopulateTitleBarTimeList();
            } else {
                Behavior_TitleBar_Time.Items.RemoveAt(2);
            }


            _Pizza();
        }

        private void _SetLocationVisibility()
        {
            int ShortHeight = Layout_UseLocations.Checked ? 23 : 0;
            AnnoyGroup_LocationFollowPanel.Height = ShortHeight;
            _Pizza();
        }

        private void _SetCategoryVisibility()
        {
            int ShortHeight = Layout_UseCategories.Checked ? 23 : 0;
            AnnoyGroup_CategoryFollowPanel.Height = ShortHeight;
            _Pizza();
        }

        private void _Pizza()
        {
            // Adjust GroupBox Heights
            SortingGroup.Height = GetGroupHeight(SortingGroup);
            StatusBarGroup.Height = GetGroupHeight(StatusBarGroup);
            HiddenGroup.Height = GetGroupHeight(HiddenGroup);
            AnnoyGroup.Height = GetGroupHeight(AnnoyGroup);

            // This one's a bit of a bitch
            /*
            AnnoyGroup.Height = 90 +
                (AnnoyGroup_ActivityFollowPanel.Visible ? AnnoyGroup_ActivityFollowPanel.Height : 0) +
                (AnnoyGroup_LocationFollowPanel.Visible ? AnnoyGroup_LocationFollowPanel.Height : 0) +
                (AnnoyGroup_CategoryFollowPanel.Visible ? AnnoyGroup_CategoryFollowPanel.Height : 0);
            */

            // One-off Adjustments
            //HiddenGroup.Top = StatusBarGroup.Height + 23;
            HiddenGroup.Top = StatusBarGroup.Bottom + 7;
            //MemoEditorGroup.Top = HiddenGroup.Bottom + 7;
            SortingGroup.Top = AnnoyGroup.Bottom + 7;
            BrowsingGroup.Top = SortingGroup.Bottom + 7;
            ViewSpacerBox.Top = HiddenGroup.Bottom + 7;
            BehaviorSpacingBox.Top = BrowsingGroup.Bottom + 7;
        }

        private int GetGroupHeight(GroupBox box)
        {
            int GroupHeight = 23;
            foreach (Control Control in box.Controls) {
                GroupHeight += Control.Height;
            }
            return GroupHeight;
        }

        private void View_StatusBar_CheckedChanged(object sender, EventArgs e)
        {
            StatusBarGroup.Enabled = View_StatusBar.Checked;
            /*
            View_StatusBar_ProjectName.Enabled = View_StatusBar.Checked;
            View_StatusBar_ActivityName.Enabled = View_StatusBar.Checked;
            View_StatusBar_ElapsedSinceStart.Enabled = View_StatusBar.Checked;
            View_StatusBar_ElapsedProjectToday.Enabled = View_StatusBar.Checked;
            View_StatusBar_ElapsedActivityToday.Enabled = View_StatusBar.Checked;
            View_StatusBar_ElapsedAllToday.Enabled = View_StatusBar.Checked;
            View_StatusBar_FileName.Enabled = View_StatusBar.Checked;
            //View_StatusBar_AddLabels.Enabled = View_StatusBar.Checked;
            */
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

        private void Behavior_Annoy_NoRunningPrompt_CheckedChanged(object sender, EventArgs e)
        {
            Behavior_Annoy_NoRunningPromptAmount.Enabled = Behavior_Annoy_NoRunningPrompt.Checked;
        }

        private void Layout_Preset_Simple_Click(object sender, EventArgs e)
        {
            Layout_UseProjects.Checked = true;
            Layout_UseActivities.Checked = false;
            Layout_UseLocations.Checked = false;
            Layout_UseCategories.Checked = false;

            View_BrowserToolbar.Checked = true;
            View_MemoEditor.Checked = true;
            View_ControlPanel.Checked = false;
            View_StatusBar.Checked = false;
            View_MemoEditor_RightMargin.Value = 250;
            // FIXME: System.Windows.Forms.SystemInformation.VerticalScrollBarWidth <--- USE THIS

            View_StatusBar_ProjectName.Checked = false;
            View_StatusBar_ActivityName.Checked = false;
            View_StatusBar_ElapsedSinceStart.Checked = false;
            View_StatusBar_ElapsedProjectToday.Checked = false;
            View_StatusBar_ElapsedActivityToday.Checked = false;
            View_StatusBar_ElapsedAllToday.Checked = false;
            View_StatusBar_FileName.Checked = false;

            View_HiddenProjects.Checked = false;
            View_HiddenActivities.Checked = false;
            View_HiddenLocations.Checked = false;
            View_HiddenCategories.Checked = false;

            View_MemoEditor_ShowToolbar.Checked = false;

            Behavior_TitleBar_Template.Text = "%time - %project";
            Behavior_TitleBar_Time.SelectedIndex = 0;

            Advanced_Other_DimensionWidth.Value = 150;

            Values.Layout_InterfacePreset = 0;
            InterfaceChanged = true;
        }

        private void Layout_Preset_Typical_Click(object sender, EventArgs e)
        {
            Layout_UseProjects.Checked = true;
            Layout_UseActivities.Checked = true;
            Layout_UseLocations.Checked = false;
            Layout_UseCategories.Checked = false;

            View_BrowserToolbar.Checked = true;
            View_MemoEditor.Checked = true;
            View_ControlPanel.Checked = true;
            View_StatusBar.Checked = true;
            View_MemoEditor_RightMargin.Value = 420;

            View_StatusBar_ProjectName.Checked = true;
            View_StatusBar_ActivityName.Checked = false;
            View_StatusBar_ElapsedSinceStart.Checked = true;
            View_StatusBar_ElapsedProjectToday.Checked = true;
            View_StatusBar_ElapsedActivityToday.Checked = false;
            View_StatusBar_ElapsedAllToday.Checked = true;
            View_StatusBar_FileName.Checked = true;

            View_HiddenProjects.Checked = false;
            View_HiddenActivities.Checked = false;
            View_HiddenLocations.Checked = false;
            View_HiddenCategories.Checked = false;

            View_MemoEditor_ShowToolbar.Checked = false;

            Behavior_TitleBar_Template.Text = "%time - %activity for %project";
            Behavior_TitleBar_Time.SelectedIndex = 0;

            Advanced_Other_DimensionWidth.Value = 150;

            Values.Layout_InterfacePreset = 1;
            InterfaceChanged = true;
        }

        private void Layout_Preset_TheWorks_Click(object sender, EventArgs e)
        {
            Layout_UseProjects.Checked = true;
            Layout_UseActivities.Checked = true;
            Layout_UseLocations.Checked = true;
            Layout_UseCategories.Checked = true;

            View_BrowserToolbar.Checked = true;
            View_MemoEditor.Checked = true;
            View_ControlPanel.Checked = true;
            View_StatusBar.Checked = true;
            View_MemoEditor_RightMargin.Value = 520;

            View_StatusBar_ProjectName.Checked = true;
            View_StatusBar_ActivityName.Checked = true;
            View_StatusBar_ElapsedSinceStart.Checked = true;
            View_StatusBar_ElapsedProjectToday.Checked = true;
            View_StatusBar_ElapsedActivityToday.Checked = true;
            View_StatusBar_ElapsedAllToday.Checked = true;
            View_StatusBar_FileName.Checked = true;

            View_HiddenProjects.Checked = true;
            View_HiddenActivities.Checked = true;
            View_HiddenLocations.Checked = true;
            View_HiddenCategories.Checked = true;

            View_MemoEditor_ShowToolbar.Checked = true;

            Behavior_TitleBar_Template.Text = "%time - %activity for %project";
            Behavior_TitleBar_Time.SelectedIndex = 0;

            Advanced_Other_DimensionWidth.Value = 250;

            Values.Layout_InterfacePreset = 2;
            InterfaceChanged = true;
        }

        private void View_MemoEditor_FontButton_Click(object sender, EventArgs e)
        {
            FontConverter fc = new FontConverter();
            FontDialog.Font = (Font)fc.ConvertFromString(View_MemoEditor_Font.Text);
            if (FontDialog.ShowDialog(this) == DialogResult.OK) {
                View_MemoEditor_Font.Text = (string)fc.ConvertToString(FontDialog.Font);
            }
        }

        private void View_MemoEditor_CheckedChanged(object sender, EventArgs e)
        {
            MemoEditorGroup.Enabled = View_MemoEditor.Checked;
        }

        //----------------------------------------------------------------------

    }
}
