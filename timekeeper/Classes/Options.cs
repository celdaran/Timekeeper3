using System;
using System.Collections.Generic;
using System.Text;

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

        const string REGKEY = "Software\\Technitivity\\Timekeeper\\3.X\\";

        //----------------------------------------------------------------------
        // Public Properties (Registry)
        //----------------------------------------------------------------------

        public bool View_StatusBar { get; set; }
        public bool View_StatusBar_ProjectName { get; set; }
        public bool View_StatusBar_ActivityName { get; set; }
        public bool View_StatusBar_ElapsedSinceStart { get; set; }
        public bool View_StatusBar_ElapsedProjectToday { get; set; }
        public bool View_StatusBar_ElapsedActivityToday { get; set; }
        public bool View_StatusBar_ElapsedAllToday { get; set; }

        //----------------------------------------------------------------------
        // Public Properties (Database)
        //----------------------------------------------------------------------

        private long _Database_LastProjectId;
        private long _Database_LastActivityId;
        private long _Database_LastGridViewId;
        private long _Database_LastReportViewId;

        //----------------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------------

        public Options()
        {
            this.Database = Timekeeper.Database;
            this.LoadFromRegistry();
            this.LoadFromDatabase();
        }

        //----------------------------------------------------------------------

        public void Save()
        {
            this.SaveToRegistry();
            //this.SaveToDatabase();  FIXME/TBD
        }

        //----------------------------------------------------------------------

        private void LoadFromRegistry()
        {

            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "Options");

            View_StatusBar = ((int)Key.GetValue("View_StatusBar", 1) == 1);
            View_StatusBar_ProjectName = ((int)Key.GetValue("View_StatusBar_ProjectName", 1) == 1);
            View_StatusBar_ActivityName = ((int)Key.GetValue("View_StatusBar_ActivityName", 1) == 1);
            View_StatusBar_ElapsedSinceStart = ((int)Key.GetValue("View_StatusBar_ElapsedSinceStart", 1) == 1);
            View_StatusBar_ElapsedProjectToday = ((int)Key.GetValue("View_StatusBar_ElapsedProjectToday", 1) == 1);
            View_StatusBar_ElapsedActivityToday = ((int)Key.GetValue("View_StatusBar_ElapsedActivityToday", 1) == 1);
            View_StatusBar_ElapsedAllToday = ((int)Key.GetValue("View_StatusBar_ElapsedAllToday", 1) == 1);
        }

        //----------------------------------------------------------------------

        private void SaveToRegistry()
        {
            Key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(REGKEY + "Options");

            Key.SetValue("View_StatusBar", View_StatusBar, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("View_StatusBar_ProjectName", View_StatusBar_ProjectName, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("View_StatusBar_ActivityName", View_StatusBar_ActivityName, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("View_StatusBar_ElapsedSinceStart", View_StatusBar_ElapsedSinceStart, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("View_StatusBar_ElapsedProjectToday", View_StatusBar_ElapsedProjectToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("View_StatusBar_ElapsedActivityToday", View_StatusBar_ElapsedActivityToday, Microsoft.Win32.RegistryValueKind.DWord);
            Key.SetValue("View_StatusBar_ElapsedAllToday", View_StatusBar_ElapsedAllToday, Microsoft.Win32.RegistryValueKind.DWord);
        }

        //----------------------------------------------------------------------

    }
}
