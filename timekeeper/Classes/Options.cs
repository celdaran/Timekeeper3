using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    public partial class Options
    {
        //----------------------------------------------------------------------
        // Private Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private Microsoft.Win32.RegistryKey Key;

        //----------------------------------------------------------------------
        // Constants
        //----------------------------------------------------------------------

        const string REGKEY = @"Software\Technitivity\Timekeeper\3.X\";

        //----------------------------------------------------------------------
        // Public Properties (Registry/Options)
        //----------------------------------------------------------------------

        public bool Layout_UseProjects { get; set; }
        public bool Layout_UseActivities { get; set; }
        public bool Layout_UseLocations { get; set; }
        public bool Layout_UseCategories { get; set; }

        public int Layout_SortProjectsBy { get; set; }
        public int Layout_SortProjectsByDirection { get; set; }
        public int Layout_SortItemsBy { get; set; }
        public int Layout_SortItemsByDirection { get; set; }

        public bool View_StatusBar { get; set; }
        public bool View_StatusBar_ProjectName { get; set; }
        public bool View_StatusBar_ActivityName { get; set; }
        public bool View_StatusBar_ElapsedSinceStart { get; set; }
        public bool View_StatusBar_ElapsedProjectToday { get; set; }
        public bool View_StatusBar_ElapsedActivityToday { get; set; }
        public bool View_StatusBar_ElapsedAllToday { get; set; }
        public bool View_StatusBar_FileName { get; set; }

        public bool View_HiddenProjects { get; set; }
        public bool View_HiddenActivities { get; set; }
        public bool View_HiddenLocations { get; set; }
        public bool View_HiddenCategories { get; set; }
        public int View_HiddenProjectsSince { get; set; }
        public int View_HiddenActivitiesSince { get; set; }
        public int View_HiddenLocationsSince { get; set; }
        public int View_HiddenCategoriesSince { get; set; }

        public string Behavior_TitleBar_Template { get; set; }
        public int Behavior_TitleBar_Time { get; set; }

        public bool Behavior_Window_ShowInTray { get; set; }
        public bool Behavior_Window_MinimizeToTray { get; set; }
        public bool Behavior_Window_MinimizeOnUse { get; set; }

        public bool Behavior_Annoy_ActivityFollowsProject { get; set; }
        public bool Behavior_Annoy_ProjectFollowsActivity { get; set; }
        public bool Behavior_Annoy_PromptBeforeHiding { get; set; }
        public bool Behavior_Annoy_NoRunningPrompt { get; set; }
        public int Behavior_Annoy_NoRunningPromptAmount { get; set; }

        public string Report_FontName { get; set; }
        public int Report_FontSize { get; set; }
        public string Report_StyleSheet { get; set; }

        public List<NameObjectPair> Keyboard_FunctionList { get; set; }

        public int Advanced_Logging_Application { get; set; }
        public int Advanced_Logging_Database { get; set; }

        public int LastOptionTab { get; set; }
        public int InterfacePreset { get; set; }

        //----------------------------------------------------------------------
        // Public Properties (Registry/Metrics)
        //----------------------------------------------------------------------

        public int Main_Height { get; set; }
        public int Main_Width { get; set; }
        public int Main_Top { get; set; }
        public int Main_Left { get; set; }
        public int Main_MainSplitterDistance { get; set; }
        public int Main_TreeSplitterDistance { get; set; }
        public bool Main_BrowserOpen { get; set; }

        public int Report_Height { get; set; }
        public int Report_Width { get; set; }
        public int Report_Top { get; set; }
        public int Report_Left { get; set; }

        public int Grid_Height { get; set; }
        public int Grid_Width { get; set; }
        public int Grid_Top { get; set; }
        public int Grid_Left { get; set; }

        //----------------------------------------------------------------------
        // Public Properties (Registry/MRU)
        //----------------------------------------------------------------------

        public List<string> MRU_List { get; set; }

        //----------------------------------------------------------------------
        // Public Properties (Database)
        //----------------------------------------------------------------------

        // deprecated
        /*
        private long _Database_LastProjectId;
        private long _Database_LastActivityId;
        private long _Database_LastGridViewId;
        private long _Database_LastReportViewId;
        */

        // replaced by
        public long State_LastProjectId { get; set; }
        public long State_LastActivityId { get; set; }
        public long State_LastGridViewId { get; set; }
        public long State_LastReportViewId { get; set; }

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Options()
        {
        }

        //----------------------------------------------------------------------
        // Load Methods
        //----------------------------------------------------------------------

        public void LoadOptions()
        {
            this.LoadOptionsFromRegistry();
        }

        //----------------------------------------------------------------------

        public void LoadMetrics()
        {
            this.LoadMetricsFromRegistry();
        }

        //----------------------------------------------------------------------

        public void LoadMRU()
        {
            this.LoadMRUFromRegistry();
        }

        //----------------------------------------------------------------------

        public void LoadLocal()
        {
            this.LoadFromDatabase();
        }

        //----------------------------------------------------------------------
        // Save Methods
        //----------------------------------------------------------------------

        public void SaveOptions()
        {
            this.SaveOptionsToRegistry();
        }

        //----------------------------------------------------------------------

        public void SaveMetrics()
        {
            this.SaveMetricsToRegistry();
        }

        //----------------------------------------------------------------------

        public void SaveMRU(ToolStripItemCollection items)
        {
            this.SaveMRUToRegistry(items);
        }

        //----------------------------------------------------------------------

        public void SaveLocal()
        {
            this.SaveToDatabase();
        }

        //----------------------------------------------------------------------
        // Private Load Methods
        //----------------------------------------------------------------------

        private void LoadOptionsFromRegistry()
        {
            Timekeeper.Info("Loading Options from Registry");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Layout");

            Layout_UseProjects = ((int)Key.GetValue("UseProjects", 1) == 1);
            Layout_UseActivities = ((int)Key.GetValue("UseActivities", 0) == 1);
            Layout_UseLocations = ((int)Key.GetValue("UseLocations", 0) == 1);
            Layout_UseCategories = ((int)Key.GetValue("UseCategories", 0) == 1);

            Layout_SortProjectsBy = (int)Key.GetValue("SortProjectsBy", 0);
            Layout_SortProjectsByDirection = (int)Key.GetValue("SortProjectsByDirection", 0);
            Layout_SortItemsBy = (int)Key.GetValue("SortItemsBy", 0);
            Layout_SortItemsByDirection = (int)Key.GetValue("SortItemsByDirection", 0);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\View");

            View_StatusBar = ((int)Key.GetValue("StatusBar", 1) == 1);
            View_StatusBar_ProjectName = ((int)Key.GetValue("StatusBar_ProjectName", 1) == 1);
            View_StatusBar_ActivityName = ((int)Key.GetValue("StatusBar_ActivityName", 1) == 1);
            View_StatusBar_ElapsedSinceStart = ((int)Key.GetValue("StatusBar_ElapsedSinceStart", 1) == 1);
            View_StatusBar_ElapsedProjectToday = ((int)Key.GetValue("StatusBar_ElapsedProjectToday", 1) == 1);
            View_StatusBar_ElapsedActivityToday = ((int)Key.GetValue("StatusBar_ElapsedActivityToday", 1) == 1);
            View_StatusBar_ElapsedAllToday = ((int)Key.GetValue("StatusBar_ElapsedAllToday", 1) == 1);
            View_StatusBar_FileName = ((int)Key.GetValue("StatusBar_FileName", 1) == 1);

            View_HiddenProjects = ((int)Key.GetValue("HiddenProjects", 0) == 1);
            View_HiddenActivities = ((int)Key.GetValue("HiddenActivities", 0) == 1);
            View_HiddenLocations = ((int)Key.GetValue("HiddenLocations", 0) == 1);
            View_HiddenCategories = ((int)Key.GetValue("HiddenCategories", 0) == 1);

            View_HiddenProjectsSince = (int)Key.GetValue("HiddenProjectsSince", 4);
            View_HiddenActivitiesSince = (int)Key.GetValue("HiddenActivitiesSince", 4);
            View_HiddenLocationsSince = (int)Key.GetValue("HiddenLocationsSince", 4);
            View_HiddenCategoriesSince = (int)Key.GetValue("HiddenCategoriesSince", 4);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Behavior");

            Behavior_TitleBar_Template = (string)Key.GetValue("TitleBar_Template", "%time - %activity for %project");
            Behavior_TitleBar_Time = (int)Key.GetValue("TitleBar_Time", 0);

            Behavior_Window_ShowInTray = ((int)Key.GetValue("Window_ShowInTray", 0) == 1);
            Behavior_Window_MinimizeToTray = ((int)Key.GetValue("Window_MinimizeToTray", 0) == 1);
            Behavior_Window_MinimizeOnUse = ((int)Key.GetValue("Window_MinimizeOnUse", 0) == 1);

            Behavior_Annoy_ActivityFollowsProject = ((int)Key.GetValue("Annoy_ActivityFollowsProject", 0) == 1);
            Behavior_Annoy_ProjectFollowsActivity = ((int)Key.GetValue("Annoy_ProjectFollowsActivity", 0) == 1);
            Behavior_Annoy_PromptBeforeHiding = ((int)Key.GetValue("Annoy_PromptBeforeHiding", 1) == 1);
            Behavior_Annoy_NoRunningPrompt = ((int)Key.GetValue("Annoy_NoRunningPrompt", 1) == 1);
            Behavior_Annoy_NoRunningPromptAmount = (int)Key.GetValue("Annoy_NoRunningPromptAmount", 10);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Report");

            Report_FontName = (string)Key.GetValue("FontName", "Verdana");
            Report_FontSize = (int)Key.GetValue("FontSize", 10);
            Report_StyleSheet = (string)Key.GetValue("StyleSheet", "not implemented");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Keyboard");

            Keyboard_FunctionList = new List<NameObjectPair>();

            foreach (string KeyName in Key.GetValueNames()) {
                int KeyValue = (int)Key.GetValue(KeyName, 0);
                NameObjectPair Pair = new NameObjectPair(KeyName, KeyValue);
                Keyboard_FunctionList.Add(Pair);
            }

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Advanced");

            Advanced_Logging_Application = (int)Key.GetValue("Logging_Application", 0);
            Advanced_Logging_Database = (int)Key.GetValue("Logging_Database", 0);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options");

            LastOptionTab = (int)Key.GetValue("LastOptionTab", 0);
            InterfacePreset = (int)Key.GetValue("InterfacePreset", 0);

            //----------------------------------------------------------------------

            Key.Close();
        }

        //----------------------------------------------------------------------

        private void LoadMetricsFromRegistry()
        {
            Timekeeper.Info("Loading Metrics from Registry");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Main");

            Main_Height = (int)Key.GetValue("Height", 436);
            Main_Width = (int)Key.GetValue("Width", 200);
            Main_Top = (int)Key.GetValue("Top", 64);
            Main_Left = (int)Key.GetValue("Left", 64);
            Main_MainSplitterDistance = (int)Key.GetValue("MainSplitterDistance", 100);
            Main_TreeSplitterDistance = (int)Key.GetValue("TreeSplitterDistance", 218);
            Main_BrowserOpen = ((int)Key.GetValue("BrowserOpen", 0) == 1);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Report");

            Report_Height = (int)Key.GetValue("Height", 380);
            Report_Width = (int)Key.GetValue("Width", 580);
            Report_Top = (int)Key.GetValue("Top", 92);
            Report_Left = (int)Key.GetValue("Left", 92);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Grid");

            Grid_Height = (int)Key.GetValue("Height", 100);
            Grid_Width = (int)Key.GetValue("Width", 100);
            Grid_Top = (int)Key.GetValue("Top", 100);
            Grid_Left = (int)Key.GetValue("Left", 100);

            Key.Close();
        }

        //----------------------------------------------------------------------

        private void LoadMRUFromRegistry()
        {
            Timekeeper.Info("Loading MRU from Registry");

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"MRU");

            int Count = (int)Key.GetValue("Count", 0);

            MRU_List = new List<string>();

            for (int i = 0; i < Count; i++) {
                string FileName = (string)Key.GetValue(i.ToString());
                MRU_List.Add(FileName);
            }

            Key.Close();
        }

        //-----------------------------------------------------------------------

        private void LoadFromDatabase()
        {
            this.Database = Timekeeper.Database;

            Timekeeper.Info("Loading Options from Database");

            try {
                Row Option;
                string Query;

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastProjectId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastProjectId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastActivityId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastActivityId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastReportViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastReportViewId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastGridViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastGridViewId = Convert.ToInt64(Option["Value"]);
                }
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------
        // Private Save Methods
        //----------------------------------------------------------------------

        private void SaveOptionsToRegistry()
        {
            Timekeeper.Info("Saving Options to Registry");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Layout");

            Key.SetValue("UseProjects", Layout_UseProjects, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("UseActivities", Layout_UseActivities, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("UseLocations", Layout_UseLocations, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("UseCategories", Layout_UseCategories, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("SortProjectsBy", Layout_SortProjectsBy, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SortProjectsByDirection", Layout_SortProjectsByDirection, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SortItemsBy", Layout_SortItemsBy, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SortItemsByDirection", Layout_SortItemsByDirection, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\View");

            Key.SetValue("StatusBar", View_StatusBar, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ProjectName", View_StatusBar_ProjectName, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ActivityName", View_StatusBar_ActivityName, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedSinceStart", View_StatusBar_ElapsedSinceStart, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedProjectToday", View_StatusBar_ElapsedProjectToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedActivityToday", View_StatusBar_ElapsedActivityToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedAllToday", View_StatusBar_ElapsedAllToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_FileName", View_StatusBar_FileName, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("HiddenProjects", View_HiddenProjects, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenActivities", View_HiddenActivities, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenLocations", View_HiddenLocations, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenCategories", View_HiddenCategories, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("HiddenProjectsSince", View_HiddenProjectsSince, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenActivitiesSince", View_HiddenActivitiesSince, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenLocationsSince", View_HiddenLocationsSince, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenCategoriesSince", View_HiddenCategoriesSince, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Behavior");

            Key.SetValue("TitleBar_Template", Behavior_TitleBar_Template, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("TitleBar_Time", Behavior_TitleBar_Time, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("Window_ShowInTray", Behavior_Window_ShowInTray, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Window_MinimizeToTray", Behavior_Window_MinimizeToTray, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Window_MinimizeOnUse", Behavior_Window_MinimizeOnUse, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("Annoy_ActivityFollowsProject", Behavior_Annoy_ActivityFollowsProject, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_ProjectFollowsActivity", Behavior_Annoy_ProjectFollowsActivity, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_PromptBeforeHiding", Behavior_Annoy_PromptBeforeHiding, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_NoRunningPrompt", Behavior_Annoy_NoRunningPrompt, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_NoRunningPromptAmount", Behavior_Annoy_NoRunningPromptAmount, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Keyboard");

            foreach (NameObjectPair Pair in Keyboard_FunctionList) {
                Key.SetValue(Pair.Name, (int)Pair.Object, Microsoft.Win32.RegistryValueKind.DWord);
            }

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Advanced");

            Key.SetValue("Logging_Application", Advanced_Logging_Application, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Logging_Database", Advanced_Logging_Database, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options");

            Key.SetValue("LastOptionTab", LastOptionTab, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("InterfacePreset", InterfacePreset, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key.Close();
        }

        //----------------------------------------------------------------------

        private void SaveMetricsToRegistry()
        {
            Timekeeper.Info("Saving Metrics to Registry");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Main");

            Key.SetValue("Height", Main_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Main_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Main_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Main_Left, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("MainSplitterDistance", Main_MainSplitterDistance, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("TreeSplitterDistance", Main_TreeSplitterDistance, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("BrowserOpen", Main_BrowserOpen, Microsoft.Win32.RegistryValueKind.DWord); 

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Report");

            Key.SetValue("Height", Report_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Report_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Report_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Report_Left, Microsoft.Win32.RegistryValueKind.DWord);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Grid");

            Key.SetValue("Height", Grid_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Grid_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Grid_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Grid_Left, Microsoft.Win32.RegistryValueKind.DWord);

            Key.Close();
        }

        //----------------------------------------------------------------------

        private void SaveMRUToRegistry(ToolStripItemCollection items)
        {
            Timekeeper.Info("Saving MRU to Registry");

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"MRU");

            int i = 0;
            foreach (ToolStripMenuItem Item in items) {
                if (i < 10) { // arbitrary maximum (FIXME: Make this a user-settable option)
                    Key.SetValue(i.ToString(), Item.Text);
                    i++;
                }
            }

            // FIXME: this leaves stray entries above "i". We should probably
            // clean those up along the way.
            Key.SetValue("Count", i, Microsoft.Win32.RegistryValueKind.DWord);

            Key.Close();
        }

        //----------------------------------------------------------------------

        private void SaveToDatabase()
        {
            SaveRow("LastProjectId", State_LastProjectId.ToString());
            SaveRow("LastActivityId", State_LastActivityId.ToString());
            SaveRow("LastReportViewId", State_LastReportViewId.ToString());
            SaveRow("LastGridViewId", State_LastGridViewId.ToString());
        }

        //----------------------------------------------------------------------

        private void SaveRow(string columnName, string columnValue)
        {
            try {
                Row Options = new Row();

                Options["Value"] = columnValue;
                Options["ModifyTime"] = Common.Now();

                this.Database.Update("Options", Options, "Key", columnName);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

    }
}
