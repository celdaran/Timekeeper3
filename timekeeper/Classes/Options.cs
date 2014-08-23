using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

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

        //private readonly string REGKEY = String.Format(@"Software\Technitivity\Timekeeper\{0}\", Timekeeper.VERSION);
        private readonly string REGKEY = String.Format(@"Software\Technitivity\Timekeeper\{0}\", Timekeeper.SHORT_VERSION);

        //----------------------------------------------------------------------
        // Public Properties (Registry/Options)
        //----------------------------------------------------------------------

        public int LastOptionTab { get; set; }

        public int Layout_InterfacePreset { get; set; }
        public bool Layout_UseProjects { get; set; }
        public bool Layout_UseActivities { get; set; }
        public bool Layout_UseLocations { get; set; }
        public bool Layout_UseCategories { get; set; }

        public bool View_BrowserToolbar { get; set; }
        public bool View_MemoEditor { get; set; }
        public bool View_ControlPanel { get; set; }
        public bool View_StatusBar { get; set; }

        public bool View_StatusBar_ProjectName { get; set; }
        public bool View_StatusBar_ActivityName { get; set; }
        public bool View_StatusBar_LocationName { get; set; }
        public bool View_StatusBar_CategoryName { get; set; }
        public bool View_StatusBar_ElapsedSinceStart { get; set; }
        public bool View_StatusBar_ElapsedProjectToday { get; set; }
        public bool View_StatusBar_ElapsedActivityToday { get; set; }
        public bool View_StatusBar_ElapsedLocationToday { get; set; }
        public bool View_StatusBar_ElapsedCategoryToday { get; set; }
        public bool View_StatusBar_ElapsedAllToday { get; set; }
        public bool View_StatusBar_FileName { get; set; }

        public bool View_HiddenProjects { get; set; }
        public bool View_HiddenActivities { get; set; }
        public bool View_HiddenLocations { get; set; }
        public bool View_HiddenCategories { get; set; }
        public bool View_HiddenTodoItems { get; set; }
        public bool View_HiddenEvents { get; set; }
        public int View_HiddenProjectsSince { get; set; }
        public int View_HiddenActivitiesSince { get; set; }
        public int View_HiddenLocationsSince { get; set; }
        public int View_HiddenCategoriesSince { get; set; }
        public int View_HiddenTodoItemsSince { get; set; }
        public int View_HiddenEventsSince { get; set; }
        public bool View_MemoEditor_ShowToolbar { get; set; }
        public bool View_MemoEditor_ShowGutter { get; set; }
        public string View_MemoEditor_Font { get; set; }
        public int View_MemoEditor_RightMargin_Journal { get; set; }
        public int View_MemoEditor_RightMargin_Notebook { get; set; }
        public int View_MemoEditor_RightMargin_Todo { get; set; }

        public string Behavior_TitleBar_Template { get; set; }
        public int Behavior_TitleBar_Time { get; set; }

        public bool Behavior_Window_ShowInTray { get; set; }
        public bool Behavior_Window_MinimizeToTray { get; set; }
        public bool Behavior_Window_MinimizeOnUse { get; set; }

        public bool Behavior_Annoy_ActivityFollowsProject { get; set; }
        public bool Behavior_Annoy_LocationFollowsProject { get; set; }
        public bool Behavior_Annoy_CategoryFollowsProject { get; set; }
        public bool Behavior_Annoy_PromptBeforeHiding { get; set; }
        public bool Behavior_Annoy_NoRunningPrompt { get; set; }
        public int Behavior_Annoy_NoRunningPromptAmount { get; set; }
        public bool Behavior_Annoy_UseNewDatabaseWizard { get; set; }

        public int Behavior_SortProjectsBy { get; set; }
        public int Behavior_SortProjectsByDirection { get; set; }
        public int Behavior_SortProjectsThenBy { get; set; }
        public int Behavior_SortProjectsThenByDirection { get; set; }
        public int Behavior_SortItemsBy { get; set; }
        public int Behavior_SortItemsByDirection { get; set; }
        public int Behavior_BrowsePrevBy { get; set; }
        public int Behavior_BrowseNextBy { get; set; }

        public string Report_Font { get; set; }
        public string Report_StyleSheetFile { get; set; }
        public string Report_LayoutFile { get; set; }

        public List<NameObjectPair> Keyboard_FunctionList { get; set; }

        public string Mail_FromAddress { get; set; }
        public string Mail_FromDisplayAddress { get; set; }
        public string Mail_SmtpServer { get; set; }
        public int Mail_SmtpPort { get; set; }
        public bool Mail_SmtpServerRequiresSSL { get; set; }
        public int Mail_SmtpTimeout { get; set; }
        public string Mail_SmtpServerUsername { get; set; }
        public string Mail_SmtpServerPassword { get; set; }

        public int Advanced_Logging_Application { get; set; }
        public int Advanced_Logging_Database { get; set; }
        public string Advanced_DateTimeFormat { get; set; }
        public string Advanced_BreakTemplate { get; set; }
        public int Advanced_Other_MarkupLanguage { get; set; }
        public bool Advanced_Other_DisableScheduler { get; set; }
        public bool Advanced_Other_EnableStackTracing { get; set; }
        public int Advanced_Other_DimensionWidth { get; set; }
        public int Advanced_Other_MidnightOffset { get; set; }
        public bool Advanced_Other_WarnOpeningLockedDatabase { get; set; }
        public bool Advanced_Other_SortExProjectAsNumber { get; set; }

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
        //public int Main_BrowserHeight { get; set; }

        public int Report_Height { get; set; }
        public int Report_Width { get; set; }
        public int Report_Top { get; set; }
        public int Report_Left { get; set; }

        public int Grid_Height { get; set; }
        public int Grid_Width { get; set; }
        public int Grid_Top { get; set; }
        public int Grid_Left { get; set; }

        public int PunchCard_Height { get; set; }
        public int PunchCard_Width { get; set; }
        public int PunchCard_Top { get; set; }
        public int PunchCard_Left { get; set; }

        public int Find_Height { get; set; }
        public int Find_Width { get; set; }
        public int Find_Top { get; set; }
        public int Find_Left { get; set; }
        public int Find_JournalGrid_StartTimeWidth { get; set; }
        public int Find_JournalGrid_StopTimeWidth { get; set; }
        public int Find_JournalGrid_SecondsWidth { get; set; }
        public int Find_JournalGrid_MemoWidth { get; set; }
        public int Find_JournalGrid_ProjectNameWidth { get; set; }
        public int Find_JournalGrid_ActivityNameWidth { get; set; }
        public int Find_JournalGrid_LocationNameWidth { get; set; }
        public int Find_JournalGrid_CategoryNameWidth { get; set; }
        public int Find_JournalGrid_IsLockedWidth { get; set; }
        public int Find_JournalGrid_JournalIdWidth { get; set; }
        public int Find_NotebookGrid_EntryTimeWidth { get; set; }
        public int Find_NotebookGrid_MemoWidth { get; set; }
        public int Find_NotebookGrid_ProjectNameWidth { get; set; }
        public int Find_NotebookGrid_ActivityNameWidth { get; set; }
        public int Find_NotebookGrid_LocationNameWidth { get; set; }
        public int Find_NotebookGrid_CategoryNameWidth { get; set; }
        public int Find_NotebookGrid_NotebookIdWidth { get; set; }

        public int Calendar_Height { get; set; }
        public int Calendar_Width { get; set; }
        public int Calendar_Top { get; set; }
        public int Calendar_Left { get; set; }
        public bool Calendar_ShowEntries { get; set; }
        public int Calendar_Grid_StartTimeWidth { get; set; }
        public int Calendar_Grid_StopTimeWidth { get; set; }
        public int Calendar_Grid_SecondsWidth { get; set; }
        public int Calendar_Grid_MemoWidth { get; set; }
        public int Calendar_Grid_ProjectNameWidth { get; set; }
        public int Calendar_Grid_ActivityNameWidth { get; set; }
        public int Calendar_Grid_LocationNameWidth { get; set; }
        public int Calendar_Grid_CategoryNameWidth { get; set; }
        public int Calendar_Grid_IsLockedWidth { get; set; }
        public int Calendar_Grid_JournalIdWidth { get; set; }

        public int Todo_Height { get; set; }
        public int Todo_Width { get; set; }
        public int Todo_Top { get; set; }
        public int Todo_Left { get; set; }
        public bool Todo_ShowGroups { get; set; }
        public bool Todo_ShowCompletedItems { get; set; }
        public int Todo_IconView { get; set; }
        public int Todo_ProjectNameWidth { get; set; }
        public int Todo_StartDateWidth { get; set; }
        public int Todo_DueDateWidth { get; set; }
        public int Todo_StatusWidth { get; set; }
        public int Todo_ProjectNameDisplayIndex { get; set; }
        public int Todo_StartDateDisplayIndex { get; set; }
        public int Todo_DueDateDisplayIndex { get; set; }
        public int Todo_StatusDisplayIndex { get; set; }

        public int Event_Height { get; set; }
        public int Event_Width { get; set; }
        public int Event_Top { get; set; }
        public int Event_Left { get; set; }
        public bool Event_ShowGroups { get; set; }
        public bool Event_ShowPastEvents { get; set; }
        public bool Event_ShowHiddenEvents{ get; set; }
        public int Event_IconView { get; set; }
        public int Event_NameWidth { get; set; }
        public int Event_DescriptionWidth { get; set; }
        public int Event_NextOccurrenceTimeWidth { get; set; }
        public int Event_TriggerCountWidth { get; set; }
        public int Event_ReminderWidth { get; set; }
        public int Event_ScheduleWidth { get; set; }
        public int Event_NameDisplayIndex { get; set; }
        public int Event_DescriptionDisplayIndex { get; set; }
        public int Event_NextOccurrenceTimeDisplayIndex { get; set; }
        public int Event_TriggerCountDisplayIndex { get; set; }
        public int Event_ReminderDisplayIndex { get; set; }
        public int Event_ScheduleDisplayIndex { get; set; }

        public int Notebook_Height { get; set; }
        public int Notebook_Width { get; set; }
        public int Notebook_Top { get; set; }
        public int Notebook_Left { get; set; }

        public int Merge_Height { get; set; }
        public int Merge_Width { get; set; }
        public int Merge_Top { get; set; }
        public int Merge_Left { get; set; }

        public int TreeManager_Height { get; set; }
        public int TreeManager_Width { get; set; }
        public int TreeManager_Top { get; set; }
        public int TreeManager_Left { get; set; }

        //----------------------------------------------------------------------
        // Public Properties (Registry/MRU)
        //----------------------------------------------------------------------

        public List<string> MRU_List { get; set; }

        //----------------------------------------------------------------------
        // Public Properties (Database)
        //----------------------------------------------------------------------

        public long State_LastProjectId { get; set; }
        public long State_LastActivityId { get; set; }
        public long State_LastLocationId { get; set; }
        public long State_LastCategoryId { get; set; }
        public long State_LastFindViewId { get; set; }
        public long State_LastGridViewId { get; set; }
        public long State_LastReportViewId { get; set; }
        public long State_LastCalendarViewId { get; set; }
        public long State_LastPunchCardViewId { get; set; }

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
            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Layout");

            Layout_InterfacePreset = (int)Key.GetValue("InterfacePreset", 0);
            Layout_UseProjects = ((int)Key.GetValue("UseProjects", 1) == 1);
            Layout_UseActivities = ((int)Key.GetValue("UseActivities", 0) == 1);
            Layout_UseLocations = ((int)Key.GetValue("UseLocations", 0) == 1);
            Layout_UseCategories = ((int)Key.GetValue("UseCategories", 0) == 1);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\View");

            View_BrowserToolbar = ((int)Key.GetValue("BrowserToolbar", 1) == 1);
            View_MemoEditor = ((int)Key.GetValue("MemoEditor", 1) == 1);
            View_ControlPanel = ((int)Key.GetValue("ControlPanel", 0) == 1);
            View_StatusBar = ((int)Key.GetValue("StatusBar", 0) == 1);

            View_StatusBar_ProjectName = ((int)Key.GetValue("StatusBar_ProjectName", 0) == 1);
            View_StatusBar_ActivityName = ((int)Key.GetValue("StatusBar_ActivityName", 0) == 1);
            View_StatusBar_LocationName = ((int)Key.GetValue("StatusBar_LocationName", 0) == 1);
            View_StatusBar_CategoryName = ((int)Key.GetValue("StatusBar_CategoryName", 0) == 1);
            View_StatusBar_ElapsedSinceStart = ((int)Key.GetValue("StatusBar_ElapsedSinceStart", 0) == 1);
            View_StatusBar_ElapsedProjectToday = ((int)Key.GetValue("StatusBar_ElapsedProjectToday", 0) == 1);
            View_StatusBar_ElapsedActivityToday = ((int)Key.GetValue("StatusBar_ElapsedActivityToday", 0) == 1);
            View_StatusBar_ElapsedLocationToday = ((int)Key.GetValue("StatusBar_ElapsedLocationToday", 0) == 1);
            View_StatusBar_ElapsedCategoryToday = ((int)Key.GetValue("StatusBar_ElapsedCategoryToday", 0) == 1);
            View_StatusBar_ElapsedAllToday = ((int)Key.GetValue("StatusBar_ElapsedAllToday", 0) == 1);
            View_StatusBar_FileName = ((int)Key.GetValue("StatusBar_FileName", 1) == 1);

            View_HiddenProjects = ((int)Key.GetValue("HiddenProjects", 0) == 1);
            View_HiddenActivities = ((int)Key.GetValue("HiddenActivities", 0) == 1);
            View_HiddenLocations = ((int)Key.GetValue("HiddenLocations", 0) == 1);
            View_HiddenCategories = ((int)Key.GetValue("HiddenCategories", 0) == 1);
            View_HiddenTodoItems = ((int)Key.GetValue("HiddenTodoItems", 0) == 1);
            View_HiddenEvents = ((int)Key.GetValue("HiddenEvents", 0) == 1);

            View_HiddenProjectsSince = (int)Key.GetValue("HiddenProjectsSince", 4);
            View_HiddenActivitiesSince = (int)Key.GetValue("HiddenActivitiesSince", 4);
            View_HiddenLocationsSince = (int)Key.GetValue("HiddenLocationsSince", 4);
            View_HiddenCategoriesSince = (int)Key.GetValue("HiddenCategoriesSince", 4);
            View_HiddenTodoItemsSince = (int)Key.GetValue("HiddenTodoItemsSince", 4);
            View_HiddenEventsSince = (int)Key.GetValue("HiddenEventsSince", 4);

            View_MemoEditor_ShowToolbar = ((int)Key.GetValue("MemoEditor_ShowToolbar", 0) == 1);
            View_MemoEditor_ShowGutter = ((int)Key.GetValue("MemoEditor_ShowGutter", 1) == 1);
            View_MemoEditor_RightMargin_Journal = (int)Key.GetValue("MemoEditor_RightMargin_Journal", 550);
            View_MemoEditor_RightMargin_Notebook = (int)Key.GetValue("MemoEditor_RightMargin_Notebook", 410);
            View_MemoEditor_RightMargin_Todo = (int)Key.GetValue("MemoEditor_RightMargin_Todo", 333);
            View_MemoEditor_Font = (string)Key.GetValue("MemoEditor_Font", "Microsoft Sans Serif, 8.25pt");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Behavior");

            Behavior_TitleBar_Template = (string)Key.GetValue("TitleBar_Template", "%time - %activity for %project");
            Behavior_TitleBar_Time = (int)Key.GetValue("TitleBar_Time", 0);

            Behavior_Window_ShowInTray = ((int)Key.GetValue("Window_ShowInTray", 0) == 1);
            Behavior_Window_MinimizeToTray = ((int)Key.GetValue("Window_MinimizeToTray", 0) == 1);
            Behavior_Window_MinimizeOnUse = ((int)Key.GetValue("Window_MinimizeOnUse", 0) == 1);

            Behavior_Annoy_ActivityFollowsProject = ((int)Key.GetValue("Annoy_ActivityFollowsProject", 1) == 1);
            Behavior_Annoy_LocationFollowsProject = ((int)Key.GetValue("Annoy_LocationFollowsProject", 1) == 1);
            Behavior_Annoy_CategoryFollowsProject = ((int)Key.GetValue("Annoy_CategoryFollowsProject", 0) == 1);
            Behavior_Annoy_PromptBeforeHiding = ((int)Key.GetValue("Annoy_PromptBeforeHiding", 1) == 1);
            Behavior_Annoy_NoRunningPrompt = ((int)Key.GetValue("Annoy_NoRunningPrompt", 1) == 1);
            Behavior_Annoy_NoRunningPromptAmount = (int)Key.GetValue("Annoy_NoRunningPromptAmount", 10);
            Behavior_Annoy_UseNewDatabaseWizard = ((int)Key.GetValue("Annoy_UseNewDatabaseWizard", 1) == 1);

            Behavior_SortProjectsBy = (int)Key.GetValue("SortProjectsBy", 0);
            Behavior_SortProjectsByDirection = (int)Key.GetValue("SortProjectsByDirection", 0);
            Behavior_SortProjectsThenBy = (int)Key.GetValue("SortProjectsThenBy", 0);
            Behavior_SortProjectsThenByDirection = (int)Key.GetValue("SortProjectsThenByDirection", 0);
            Behavior_SortItemsBy = (int)Key.GetValue("SortItemsBy", 0);
            Behavior_SortItemsByDirection = (int)Key.GetValue("SortItemsByDirection", 0);
            Behavior_BrowsePrevBy = (int)Key.GetValue("BrowsePrevBy", 0);
            Behavior_BrowseNextBy = (int)Key.GetValue("BrowseNextBy", 0);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Report");

            Report_Font = (string)Key.GetValue("Font", "Tahoma, 10pt");
            Report_StyleSheetFile = (string)Key.GetValue("StyleSheetFile", @"Files\JournalEntryReport.css");
            Report_LayoutFile = (string)Key.GetValue("LayoutFile", @"Files\JournalEntryReport.html");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Keyboard");

            Keyboard_FunctionList = new List<NameObjectPair>();

            foreach (string KeyName in Key.GetValueNames()) {
                int KeyValue = (int)Key.GetValue(KeyName, 0);
                NameObjectPair Pair = new NameObjectPair(KeyName, KeyValue);
                Keyboard_FunctionList.Add(Pair);
            }

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Mail");

            Mail_FromAddress = (string)Key.GetValue("FromAddress", "from@example.com");
            Mail_FromDisplayAddress = (string)Key.GetValue("FromDisplayAddress", "Timekeeper Notification");
            Mail_SmtpServer = (string)Key.GetValue("SmtpServer", "smtp.example.com");
            Mail_SmtpPort = (int)Key.GetValue("SmtpPort", 25);
            Mail_SmtpServerRequiresSSL = ((int)Key.GetValue("SmtpServerRequiresSSL", 0) == 1);
            Mail_SmtpTimeout = (int)Key.GetValue("SmtpTimeout", 10);
            Mail_SmtpServerUsername = (string)Key.GetValue("SmtpServerUsername", "username");
            Mail_SmtpServerPassword = (string)Key.GetValue("SmtpServerPassword", "");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Advanced");

            Advanced_Logging_Application = (int)Key.GetValue("Logging_Application", 2);
            Advanced_Logging_Database = (int)Key.GetValue("Logging_Database", 2);
            Advanced_DateTimeFormat = (string)Key.GetValue("DateTimeFormat", 
                CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " +
                CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern);
            Advanced_BreakTemplate = (string)Key.GetValue("BreakTemplate", "\\n<hr class=\"memo-break-manual\" title=\"%timestamp\" />\\n");
            Advanced_Other_MarkupLanguage = (int)Key.GetValue("Other_MarkupLanguage", 1);
            Advanced_Other_DisableScheduler = ((int)Key.GetValue("Other_DisableScheduler", 0)) == 1;
            Advanced_Other_EnableStackTracing = ((int)Key.GetValue("Other_EnableStackTracing", 0)) == 1;
            Advanced_Other_DimensionWidth = (int)Key.GetValue("Other_DimensionWidth", 250);
            Advanced_Other_MidnightOffset = (int)Key.GetValue("Other_MidnightOffset", 0);
            Advanced_Other_WarnOpeningLockedDatabase = ((int)Key.GetValue("Other_WarnOpeningLockedDatabase", 1)) == 1;
            Advanced_Other_SortExProjectAsNumber = ((int)Key.GetValue("Other_SortExProjectAsNumber", 1)) == 1;

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options");

            LastOptionTab = (int)Key.GetValue("LastOptionTab", 0);

            //----------------------------------------------------------------------

            Key.Close();

            //----------------------------------------------------------------------

            Timekeeper.Debug("Options Loaded from Registry");
        }

        //----------------------------------------------------------------------

        private void LoadMetricsFromRegistry()
        {
            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Main");

            Main_Height = (int)Key.GetValue("Height", 200);
            Main_Width = (int)Key.GetValue("Width", 400);
            Main_Top = (int)Key.GetValue("Top", 64);
            Main_Left = (int)Key.GetValue("Left", 64);
            Main_MainSplitterDistance = (int)Key.GetValue("MainSplitterDistance", 100);
            Main_TreeSplitterDistance = (int)Key.GetValue("TreeSplitterDistance", 218);
            Main_BrowserOpen = ((int)Key.GetValue("BrowserOpen", 0) == 1);
            // TODO: add window state as an option (minimized, maximized, etc.)

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Report");

            Report_Height = (int)Key.GetValue("Height", 380);
            Report_Width = (int)Key.GetValue("Width", 580);
            Report_Top = (int)Key.GetValue("Top", 92);
            Report_Left = (int)Key.GetValue("Left", 92);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Grid");

            Grid_Height = (int)Key.GetValue("Height", 310);
            Grid_Width = (int)Key.GetValue("Width", 480);
            Grid_Top = (int)Key.GetValue("Top", 100);
            Grid_Left = (int)Key.GetValue("Left", 100);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\PunchCard");

            PunchCard_Height = (int)Key.GetValue("Height", 400);
            PunchCard_Width = (int)Key.GetValue("Width", 275);
            PunchCard_Top = (int)Key.GetValue("Top", 100);
            PunchCard_Left = (int)Key.GetValue("Left", 100);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Find");

            // TODO: come up with better defaults
            Find_Height = (int)Key.GetValue("Height", 320);
            Find_Width = (int)Key.GetValue("Width", 530);
            Find_Top = (int)Key.GetValue("Top", 100);
            Find_Left = (int)Key.GetValue("Left", 100);
            Find_JournalGrid_StartTimeWidth = (int)Key.GetValue("JournalGrid_StartTimeWidth", 80);
            Find_JournalGrid_StopTimeWidth = (int)Key.GetValue("JournalGrid_StopTimeWidth", 80);
            Find_JournalGrid_SecondsWidth = (int)Key.GetValue("JournalGrid_SecondsWidth", 72);
            Find_JournalGrid_MemoWidth = (int)Key.GetValue("JournalGrid_MemoWidth", 100);
            Find_JournalGrid_ProjectNameWidth = (int)Key.GetValue("JournalGrid_ProjectNameWidth", 65);
            Find_JournalGrid_ActivityNameWidth = (int)Key.GetValue("JournalGrid_ActivityNameWidth", 65);
            Find_JournalGrid_LocationNameWidth = (int)Key.GetValue("JournalGrid_LocationNameWidth", 65);
            Find_JournalGrid_CategoryNameWidth = (int)Key.GetValue("JournalGrid_CategoryNameWidth", 65);
            Find_JournalGrid_IsLockedWidth = (int)Key.GetValue("JournalGrid_IsLockedWidth", 50);
            Find_JournalGrid_JournalIdWidth = (int)Key.GetValue("JournalGrid_JournalIdWidth", 50);
            Find_NotebookGrid_EntryTimeWidth = (int)Key.GetValue("NotebookGrid_EntryTimeWidth", 72);
            Find_NotebookGrid_MemoWidth = (int)Key.GetValue("NotebookGrid_MemoWidth", 100);
            Find_NotebookGrid_ProjectNameWidth = (int)Key.GetValue("NotebookGrid_ProjectNameWidth", 65);
            Find_NotebookGrid_ActivityNameWidth = (int)Key.GetValue("NotebookGrid_ActivityNameWidth", 65);
            Find_NotebookGrid_LocationNameWidth = (int)Key.GetValue("NotebookGrid_LocationNameWidth", 65);
            Find_NotebookGrid_CategoryNameWidth = (int)Key.GetValue("NotebookGrid_CategoryNameWidth", 65);
            Find_NotebookGrid_NotebookIdWidth = (int)Key.GetValue("NotebookGrid_NotebookIdWidth", 50);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Calendar");

            Calendar_Height = (int)Key.GetValue("Height", 235);
            Calendar_Width = (int)Key.GetValue("Width", 719);
            Calendar_Top = (int)Key.GetValue("Top", 100);
            Calendar_Left = (int)Key.GetValue("Left", 100);
            Calendar_ShowEntries = ((int)Key.GetValue("ShowEntries", 1) == 1);
            Calendar_Grid_StartTimeWidth = (int)Key.GetValue("Grid_StartTimeWidth", 80);
            Calendar_Grid_StopTimeWidth = (int)Key.GetValue("Grid_StopTimeWidth", 80);
            Calendar_Grid_SecondsWidth = (int)Key.GetValue("Grid_SecondsWidth", 72);
            Calendar_Grid_MemoWidth = (int)Key.GetValue("Grid_MemoWidth", 100);
            Calendar_Grid_ProjectNameWidth = (int)Key.GetValue("Grid_ProjectNameWidth", 65);
            Calendar_Grid_ActivityNameWidth = (int)Key.GetValue("Grid_ActivityNameWidth", 65);
            Calendar_Grid_LocationNameWidth = (int)Key.GetValue("Grid_LocationNameWidth", 65);
            Calendar_Grid_CategoryNameWidth = (int)Key.GetValue("Grid_CategoryNameWidth", 65);
            Calendar_Grid_IsLockedWidth = (int)Key.GetValue("Grid_IsLockedWidth", 50);
            Calendar_Grid_JournalIdWidth = (int)Key.GetValue("Grid_JournalIdWidth", 50);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Todo");

            Todo_Height = (int)Key.GetValue("Height", 360);
            Todo_Width = (int)Key.GetValue("Width", 655);
            Todo_Top = (int)Key.GetValue("Top", 100);
            Todo_Left = (int)Key.GetValue("Left", 100);
            Todo_ShowGroups = ((int)Key.GetValue("ShowGroups", 1) == 1);
            Todo_ShowCompletedItems = ((int)Key.GetValue("ShowCompletedItems", 0) == 1);
            Todo_IconView = (int)Key.GetValue("IconView", 5);
            Todo_ProjectNameWidth = (int)Key.GetValue("ProjectNameWidth", 300);
            Todo_StartDateWidth = (int)Key.GetValue("StartDateWidth", 120);
            Todo_DueDateWidth = (int)Key.GetValue("DueDateWidth", 120);
            Todo_StatusWidth = (int)Key.GetValue("StatusWidth", 80);
            Todo_ProjectNameDisplayIndex = (int)Key.GetValue("ProjectNameDisplayIndex", 0);
            Todo_StartDateDisplayIndex = (int)Key.GetValue("StartDateDisplayIndex", 1);
            Todo_DueDateDisplayIndex = (int)Key.GetValue("DueDateDisplayIndex", 2);
            Todo_StatusDisplayIndex = (int)Key.GetValue("StatusDisplayIndex", 3);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Event");

            Event_Height = (int)Key.GetValue("Height", 360);
            Event_Width = (int)Key.GetValue("Width", 655);
            Event_Top = (int)Key.GetValue("Top", 100);
            Event_Left = (int)Key.GetValue("Left", 100);
            Event_ShowGroups = ((int)Key.GetValue("ShowGroups", 1) == 1);
            Event_ShowPastEvents = ((int)Key.GetValue("ShowPastEvents", 1) == 1);
            Event_ShowHiddenEvents = ((int)Key.GetValue("ShowHiddenEvents", 1) == 1);
            Event_IconView = (int)Key.GetValue("IconView", 5);
            Event_NameWidth = (int)Key.GetValue("NameWidth", 200);
            Event_DescriptionWidth = (int)Key.GetValue("DescriptionWidth", 200);
            Event_NextOccurrenceTimeWidth = (int)Key.GetValue("NextOccurrenceTimeWidth", 100);
            Event_TriggerCountWidth = (int)Key.GetValue("TriggerCountWidth", 60);
            Event_ReminderWidth = (int)Key.GetValue("ReminderWidth", 100);
            Event_ScheduleWidth = (int)Key.GetValue("ScheduleWidth", 100);
            Event_NameDisplayIndex = (int)Key.GetValue("NameDisplayIndex", 0);
            Event_DescriptionDisplayIndex = (int)Key.GetValue("DescriptionDisplayIndex", 1);
            Event_NextOccurrenceTimeDisplayIndex = (int)Key.GetValue("NextOccurrenceTimeDisplayIndex", 2);
            Event_TriggerCountDisplayIndex = (int)Key.GetValue("TriggerCountDisplayIndex", 3);
            Event_ReminderDisplayIndex = (int)Key.GetValue("ReminderDisplayIndex", 4);
            Event_ScheduleDisplayIndex = (int)Key.GetValue("ScheduleDisplayIndex", 5);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Notebook");

            Notebook_Height = (int)Key.GetValue("Height", 275);
            Notebook_Width = (int)Key.GetValue("Width", 420);
            Notebook_Top = (int)Key.GetValue("Top", 100);
            Notebook_Left = (int)Key.GetValue("Left", 100);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Merge");

            // Defaulting to zero to allow a default "center parent" starter position
            Merge_Height = (int)Key.GetValue("Height", 0);
            Merge_Width = (int)Key.GetValue("Width", 0);
            Merge_Top = (int)Key.GetValue("Top", 0);
            Merge_Left = (int)Key.GetValue("Left", 0);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\TreeManager");

            TreeManager_Height = (int)Key.GetValue("Height", 269);
            TreeManager_Width = (int)Key.GetValue("Width", 359);
            TreeManager_Top = (int)Key.GetValue("Top", 100);
            TreeManager_Left = (int)Key.GetValue("Left", 100);

            Key.Close();

            //----------------------------------------------------------------------

            Timekeeper.Debug("Metrics Loaded from Registry");
        }

        //----------------------------------------------------------------------

        private void LoadMRUFromRegistry()
        {
            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"MRU");

            int Count = (int)Key.GetValue("Count", 0);

            MRU_List = new List<string>();

            for (int i = 0; i < Count; i++) {
                string FileName = (string)Key.GetValue(i.ToString());
                MRU_List.Add(FileName);
            }

            Key.Close();

            //----------------------------------------------------------------------

            Timekeeper.Debug("MRU Loaded from Registry");
        }

        //-----------------------------------------------------------------------

        private void LoadFromDatabase()
        {
            this.Database = Timekeeper.Database;

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

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastLocationId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastLocationId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastCategoryId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastCategoryId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastFindViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastFindViewId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastGridViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastGridViewId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastReportViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastReportViewId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastCalendarViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastCalendarViewId = Convert.ToInt64(Option["Value"]);
                }

                Query = String.Format(@"select Value from Options where Key = '{0}'", "LastPunchCardViewId");
                Option = this.Database.SelectRow(Query);
                if (Option.Count > 0) {
                    State_LastPunchCardViewId = Convert.ToInt64(Option["Value"]);
                }

                Timekeeper.Debug("Options Loaded from Database");
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
            Timekeeper.Debug("Saving Options to Registry");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Layout");

            Key.SetValue("InterfacePreset", Layout_InterfacePreset, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("UseProjects", Layout_UseProjects, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("UseActivities", Layout_UseActivities, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("UseLocations", Layout_UseLocations, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("UseCategories", Layout_UseCategories, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\View");

            Key.SetValue("BrowserToolbar", View_BrowserToolbar, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("MemoEditor", View_MemoEditor, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ControlPanel", View_ControlPanel, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar", View_StatusBar, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("StatusBar_ProjectName", View_StatusBar_ProjectName, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ActivityName", View_StatusBar_ActivityName, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_LocationName", View_StatusBar_LocationName, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_CategoryName", View_StatusBar_CategoryName, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedSinceStart", View_StatusBar_ElapsedSinceStart, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedProjectToday", View_StatusBar_ElapsedProjectToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedActivityToday", View_StatusBar_ElapsedActivityToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedLocationToday", View_StatusBar_ElapsedLocationToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedCategoryToday", View_StatusBar_ElapsedCategoryToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_ElapsedAllToday", View_StatusBar_ElapsedAllToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusBar_FileName", View_StatusBar_FileName, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("HiddenProjects", View_HiddenProjects, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenActivities", View_HiddenActivities, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenLocations", View_HiddenLocations, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenCategories", View_HiddenCategories, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenTodoItems", View_HiddenTodoItems, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenEvents", View_HiddenEvents, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("HiddenProjectsSince", View_HiddenProjectsSince, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenActivitiesSince", View_HiddenActivitiesSince, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenLocationsSince", View_HiddenLocationsSince, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenCategoriesSince", View_HiddenCategoriesSince, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenTodoItemsSince", View_HiddenTodoItemsSince, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("HiddenEventsSince", View_HiddenEventsSince, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("MemoEditor_ShowToolbar", View_MemoEditor_ShowToolbar, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("MemoEditor_ShowGutter", View_MemoEditor_ShowGutter, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("MemoEditor_RightMargin_Journal", View_MemoEditor_RightMargin_Journal, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("MemoEditor_RightMargin_Notebook", View_MemoEditor_RightMargin_Notebook, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("MemoEditor_RightMargin_Todo", View_MemoEditor_RightMargin_Todo, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("MemoEditor_Font", View_MemoEditor_Font, Microsoft.Win32.RegistryValueKind.String);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Behavior");

            Key.SetValue("TitleBar_Template", Behavior_TitleBar_Template, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("TitleBar_Time", Behavior_TitleBar_Time, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("Window_ShowInTray", Behavior_Window_ShowInTray, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Window_MinimizeToTray", Behavior_Window_MinimizeToTray, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Window_MinimizeOnUse", Behavior_Window_MinimizeOnUse, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("Annoy_ActivityFollowsProject", Behavior_Annoy_ActivityFollowsProject, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_LocationFollowsProject", Behavior_Annoy_LocationFollowsProject, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_CategoryFollowsProject", Behavior_Annoy_CategoryFollowsProject, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_PromptBeforeHiding", Behavior_Annoy_PromptBeforeHiding, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_NoRunningPrompt", Behavior_Annoy_NoRunningPrompt, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_NoRunningPromptAmount", Behavior_Annoy_NoRunningPromptAmount, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Annoy_UseNewDatabaseWizard", Behavior_Annoy_UseNewDatabaseWizard, Microsoft.Win32.RegistryValueKind.DWord);

            Key.SetValue("SortProjectsBy", Behavior_SortProjectsBy, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SortProjectsByDirection", Behavior_SortProjectsByDirection, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SortProjectsThenBy", Behavior_SortProjectsThenBy, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SortProjectsThenByDirection", Behavior_SortProjectsThenByDirection, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SortItemsBy", Behavior_SortItemsBy, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SortItemsByDirection", Behavior_SortItemsByDirection, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("BrowsePrevBy", Behavior_BrowsePrevBy, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("BrowseNextBy", Behavior_BrowseNextBy, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Report");

            Key.SetValue("Font", Report_Font, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("StyleSheetFile", Report_StyleSheetFile, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("LayoutFile", Report_LayoutFile, Microsoft.Win32.RegistryValueKind.String);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Keyboard");

            foreach (NameObjectPair Pair in Keyboard_FunctionList) {
                Key.SetValue(Pair.Name, (int)Pair.Object, Microsoft.Win32.RegistryValueKind.DWord);
            }

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Mail");

            Key.SetValue("FromAddress", Mail_FromAddress, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("FromDisplayAddress", Mail_FromDisplayAddress, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("SmtpServer", Mail_SmtpServer, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("SmtpPort", Mail_SmtpPort, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SmtpServerRequiresSSL", Mail_SmtpServerRequiresSSL, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SmtpTimeout", Mail_SmtpTimeout, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("SmtpServerUsername", Mail_SmtpServerUsername, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("SmtpServerPassword", Mail_SmtpServerPassword, Microsoft.Win32.RegistryValueKind.String);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options\Advanced");

            Key.SetValue("Logging_Application", Advanced_Logging_Application, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Logging_Database", Advanced_Logging_Database, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("DateTimeFormat", Advanced_DateTimeFormat, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("BreakTemplate", Advanced_BreakTemplate, Microsoft.Win32.RegistryValueKind.String);
            Key.SetValue("Other_MarkupLanguage", Advanced_Other_MarkupLanguage, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Other_DisableScheduler", Advanced_Other_DisableScheduler, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Other_EnableStackTracing", Advanced_Other_EnableStackTracing, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Other_DimensionWidth", Advanced_Other_DimensionWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Other_MidnightOffset", unchecked((int)Advanced_Other_MidnightOffset), Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Other_WarnOpeningLockedDatabase", Advanced_Other_WarnOpeningLockedDatabase, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Other_SortExProjectAsNumber", Advanced_Other_SortExProjectAsNumber, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Options");

            Key.SetValue("LastOptionTab", LastOptionTab, Microsoft.Win32.RegistryValueKind.DWord);

            //----------------------------------------------------------------------

            Key.Close();
        }

        //----------------------------------------------------------------------

        private void SaveMetricsToRegistry()
        {
            Timekeeper.Debug("Saving Metrics to Registry");

            //----------------------------------------------------------------------

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Main");

            Key.SetValue("Height", Main_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Main_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Main_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Main_Left, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("MainSplitterDistance", Main_MainSplitterDistance, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("TreeSplitterDistance", Main_TreeSplitterDistance, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("BrowserOpen", Main_BrowserOpen, Microsoft.Win32.RegistryValueKind.DWord);
            //Key.SetValue("BrowserHeight", Main_BrowserHeight, Microsoft.Win32.RegistryValueKind.DWord);

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

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\PunchCard");

            Key.SetValue("Height", PunchCard_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", PunchCard_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", PunchCard_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", PunchCard_Left, Microsoft.Win32.RegistryValueKind.DWord);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Find");

            Key.SetValue("Height", Find_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Find_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Find_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Find_Left, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_StartTimeWidth", Find_JournalGrid_StartTimeWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_StopTimeWidth", Find_JournalGrid_StopTimeWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_SecondsWidth", Find_JournalGrid_SecondsWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_MemoWidth", Find_JournalGrid_MemoWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_ProjectNameWidth", Find_JournalGrid_ProjectNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_ActivityNameWidth", Find_JournalGrid_ActivityNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_LocationNameWidth", Find_JournalGrid_LocationNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_CategoryNameWidth", Find_JournalGrid_CategoryNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("JournalGrid_IsLockedWidth", Find_JournalGrid_IsLockedWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NotebookGrid_EntryTimeWidth", Find_NotebookGrid_EntryTimeWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NotebookGrid_MemoWidth", Find_NotebookGrid_MemoWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NotebookGrid_ProjectNameWidth", Find_NotebookGrid_ProjectNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NotebookGrid_ActivityNameWidth", Find_NotebookGrid_ActivityNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NotebookGrid_LocationNameWidth", Find_NotebookGrid_LocationNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NotebookGrid_CategoryNameWidth", Find_NotebookGrid_CategoryNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NotebookGrid_NotebookIdWidth", Find_NotebookGrid_NotebookIdWidth, Microsoft.Win32.RegistryValueKind.DWord);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Calendar");

            Key.SetValue("Height", Calendar_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Calendar_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Calendar_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Calendar_Left, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ShowEntries", Calendar_ShowEntries, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_StartTimeWidth", Calendar_Grid_StartTimeWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_StopTimeWidth", Calendar_Grid_StopTimeWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_SecondsWidth", Calendar_Grid_SecondsWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_MemoWidth", Calendar_Grid_MemoWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_ProjectNameWidth", Calendar_Grid_ProjectNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_ActivityNameWidth", Calendar_Grid_ActivityNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_LocationNameWidth", Calendar_Grid_LocationNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_CategoryNameWidth", Calendar_Grid_CategoryNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_IsLockedWidth", Calendar_Grid_IsLockedWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Grid_JournalIdWidth", Calendar_Grid_JournalIdWidth, Microsoft.Win32.RegistryValueKind.DWord);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Todo");

            Key.SetValue("Height", Todo_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Todo_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Todo_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Todo_Left, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ShowGroups", Todo_ShowGroups, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ShowCompletedItems", Todo_ShowCompletedItems, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("IconView", Todo_IconView, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ProjectNameWidth", Todo_ProjectNameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StartDateWidth", Todo_StartDateWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("DueDateWidth", Todo_DueDateWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusWidth", Todo_StatusWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ProjectNameDisplayIndex", Todo_ProjectNameDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StartDateDisplayIndex", Todo_StartDateDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("DueDateDisplayIndex", Todo_DueDateDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("StatusDisplayIndex", Todo_StatusDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Event");

            Key.SetValue("Height", Event_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Event_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Event_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Event_Left, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ShowGroups", Event_ShowGroups, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ShowPastEvents", Event_ShowPastEvents, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ShowHiddenEvents", Event_ShowHiddenEvents, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("IconView", Event_IconView, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NameWidth", Event_NameWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("DescriptionWidth", Event_DescriptionWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NextOccurrenceTimeWidth", Event_NextOccurrenceTimeWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("TriggerCountWidth", Event_TriggerCountWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ReminderWidth", Event_ReminderWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ScheduleWidth", Event_ScheduleWidth, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NameDisplayIndex", Event_NameDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("DescriptionDisplayIndex", Event_DescriptionDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("NextOccurrenceTimeDisplayIndex", Event_NextOccurrenceTimeDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("TriggerCountDisplayIndex", Event_TriggerCountDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ReminderDisplayIndex", Event_ReminderDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("ScheduleDisplayIndex", Event_ScheduleDisplayIndex, Microsoft.Win32.RegistryValueKind.DWord);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Notebook");

            Key.SetValue("Height", Notebook_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Notebook_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Notebook_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Notebook_Left, Microsoft.Win32.RegistryValueKind.DWord);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\Merge");

            Key.SetValue("Height", Merge_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", Merge_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", Merge_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", Merge_Left, Microsoft.Win32.RegistryValueKind.DWord);

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + @"Metrics\TreeManager");

            Key.SetValue("Height", TreeManager_Height, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Width", TreeManager_Width, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Top", TreeManager_Top, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("Left", TreeManager_Left, Microsoft.Win32.RegistryValueKind.DWord);

            Key.Close();
        }

        //----------------------------------------------------------------------

        private void SaveMRUToRegistry(ToolStripItemCollection items)
        {
            Timekeeper.Debug("Saving MRU to Registry");

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
            if (this.Database != null) {
                Timekeeper.Debug("Saving Options to Database");
                SaveRow("LastProjectId", State_LastProjectId.ToString());
                SaveRow("LastActivityId", State_LastActivityId.ToString());
                SaveRow("LastLocationId", State_LastLocationId.ToString());
                SaveRow("LastCategoryId", State_LastCategoryId.ToString());
                SaveRow("LastFindViewId", State_LastFindViewId.ToString());
                SaveRow("LastGridViewId", State_LastGridViewId.ToString());
                SaveRow("LastReportViewId", State_LastReportViewId.ToString());
            }
        }

        //----------------------------------------------------------------------

        private void SaveRow(string columnName, string columnValue)
        {
            try {
                Row Options = new Row();

                Options["Value"] = columnValue;
                Options["ModifyTime"] = Timekeeper.DateForDatabase();

                this.Database.Update("Options", Options, "Key", columnName);
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //----------------------------------------------------------------------

    }
}
