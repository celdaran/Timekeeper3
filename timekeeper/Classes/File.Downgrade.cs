using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class File
    {
        // Make sure we're not using any current version date/time formatting
        // when saving in historical data formats
        private const string DOWNGRADE_DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        // Used for nothing except calling DoEvents()
        // In other words: its value doesn't matter
        private long DowngradeRowCount = 0;

        //---------------------------------------------------------------------
        // Downgrading Functions
        //---------------------------------------------------------------------

        public void SaveAs30(File newFile)
        {
            //--------------------------------------------------------
            // Define database
            //--------------------------------------------------------

            // For performance
            newFile.Database.BeginWork();

            // Create the new database
            Version Version = new System.Version(SCHEMA_VERSION);
            newFile.Create(Version, false);

            // Drop and recreate Meta table
            newFile.Database.Exec("drop table meta");
            newFile.CreateTable("Meta", Version, true);

            // FIXME: 3.1 issue, when downgrading to a schema version
            // that actually supports Auditing is introduced.
            this.Audit.DatabaseDowngraded(
                new System.Version(SCHEMA_VERSION), 
                new System.Version("3.0.something"));

            // For performance
            newFile.Database.EndWork();
        }

        //---------------------------------------------------------------------

        public void SaveAs23(File newFile)
        {
            // TK2.3's schema was identical to TK2.2
            SaveAs22(newFile);
        }

        //---------------------------------------------------------------------

        public void SaveAs22(File newFile)
        {
            //--------------------------------------------------------
            // Define database
            //--------------------------------------------------------

            // For performance
            newFile.Database.BeginWork();

            // Create the new database
            Version Version = new System.Version(2, 2, 0, 4);
            newFile.Create(Version, false);

            // Drop and recreate Meta table
            newFile.Database.Exec("drop table meta");
            newFile.CreateTable("Meta", Version, true);

            //--------------------------------------------------------
            // Data copy
            //--------------------------------------------------------

            // Activity table
            Table Activity = this.Database.Select("select * from Activity");
            foreach (Row Row in Activity) {

                Row NewRow = new Row() {
                    {"id", Row["ActivityId"]},
                    {"name", Row["Name"]},
                    {"descr", Row["Description"]},
                    {"parent_id", Row["ParentId"]},
                    {"is_folder", Row["IsFolder"] ? 1 : 0},
                    {"is_hidden", Row["IsHidden"] ? 1 : 0},
                    {"is_deleted", Row["IsDeleted"] ? 1 : 0},
                    {"project_id__last", Row["LastProjectId"]},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("tasks", NewRow);

                ProcessEvents();
            }

            // Project table
            Table Project = this.Database.Select("select * from Project");
            foreach (Row Row in Project) {

                Row NewRow = new Row() {
                    {"id", Row["ProjectId"]},
                    {"name", Row["Name"]},
                    {"descr", Row["Description"]},
                    {"parent_id", Row["ParentId"]},
                    {"is_folder", Row["IsFolder"] ? 1 : 0},
                    {"is_hidden", Row["IsHidden"] ? 1 : 0},
                    {"is_deleted", Row["IsDeleted"] ? 1 : 0},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("projects", NewRow);

                ProcessEvents();
            }

            // Journal table
            Table Journal = this.Database.Select("select * from Journal");
            foreach (Row Row in Journal) {

                Row NewRow = new Row() {
                    {"id", Row["JournalId"]},
                    {"task_id", Row["ActivityId"]},
                    {"project_id", Row["ProjectId"]},
                    {"timestamp_s", Row["StartTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_e", Row["StopTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"seconds", Row["Seconds"]},
                    {"pre_log", ""},
                    {"post_log", Row["Memo"]},
                    {"is_locked", Row["IsLocked"] ? 1 : 0},
                };

                newFile.Database.Insert("timekeeper", NewRow);

                ProcessEvents();
            }

            // Notebook table
            Table Notebook = this.Database.Select("select * from Notebook");
            foreach (Row Row in Notebook) {

                Row NewRow = new Row() {
                    {"id", Row["NotebookId"]},
                    {"timestamp_entry", Row["EntryTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"description", Row["Memo"]},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("journal", NewRow);

                ProcessEvents();
            }

            // GridView table
            Table GridView = this.Database.Select(@"
                select 
                    g.GridViewId, g.Name, g.Description, g.SortOrderNo,
                    f.ActivityList, f.ProjectList, f.RefDatePresetId,
                    f.FromTime, f.ToTime,
                    g.RefGroupById, g.RefDimensionId,
                    g.CreateTime, g.ModifyTime
                from GridView g
                join FilterOptions f on f.FilterOptionsId = g.FilterOptionsId");

            foreach (Row Row in GridView) {

                Row NewRow = new Row() {
                    {"id", Row["GridViewId"]},
                    {"name", Row["Name"]},
                    {"description", Row["Description"]},
                    {"sort_index", Row["SortOrderNo"]},
                    {"task_list", Row["ActivityList"]},
                    {"project_list", Row["ProjectList"]},
                    {"date_preset", Row["RefDatePresetId"]},
                    {"start_date", Row["FromTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"end_date", Row["ToTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"end_date_type", 1},
                    {"group_by", Row["RefGroupById"]},
                    {"data_from", Row["RefDimensionId"]},
                    {"hide_empty_rows", 1},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("grid_views", NewRow);

                ProcessEvents();
            }

            // For performance
            newFile.Database.EndWork();
        }

        //---------------------------------------------------------------------

        public void SaveAs21(File newFile)
        {
            // For performance
            newFile.Database.BeginWork();

            //--------------------------------------------------------
            // Define database
            //--------------------------------------------------------

            // Create the new database
            Version Version = new System.Version(2, 1, 0, 0);
            newFile.Create(Version, false);

            // Drop and recreate Meta table
            newFile.Database.Exec("drop table meta");
            newFile.CreateTable("Meta", Version, true);

            //--------------------------------------------------------
            // Data copy
            //--------------------------------------------------------

            // Activity table
            Table Activity = this.Database.Select("select * from Activity");
            foreach (Row Row in Activity) {

                Row NewRow = new Row() {
                    {"id", Row["ActivityId"]},
                    {"name", Row["Name"]},
                    {"descr", Row["Description"]},
                    {"parent_id", Row["ParentId"]},
                    {"is_folder", Row["IsFolder"] ? 1 : 0},
                    {"is_deleted", Row["IsDeleted"] ? 1 : 0},
                    {"project_id__last", Row["LastProjectId"]},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("tasks", NewRow);

                ProcessEvents();
            }

            // Project table
            Table Project = this.Database.Select("select * from Project");
            foreach (Row Row in Project) {

                Row NewRow = new Row() {
                    {"id", Row["ProjectId"]},
                    {"name", Row["Name"]},
                    {"descr", Row["Description"]},
                    {"parent_id", Row["ParentId"]},
                    {"is_folder", Row["IsFolder"] ? 1 : 0},
                    {"is_deleted", Row["IsDeleted"] ? 1 : 0},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("projects", NewRow);

                ProcessEvents();
            }

            // Journal table
            Table Journal = this.Database.Select("select * from Journal");
            foreach (Row Row in Journal) {

                Row NewRow = new Row() {
                    {"id", Row["JournalId"]},
                    {"task_id", Row["ActivityId"]},
                    {"project_id", Row["ProjectId"]},
                    {"timestamp_s", Row["StartTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_e", Row["StopTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"seconds", Row["Seconds"]},
                    {"pre_log", ""},
                    {"post_log", Row["Memo"]},
                    {"is_locked", Row["IsLocked"] ? 1 : 0},
                };

                newFile.Database.Insert("timekeeper", NewRow);

                ProcessEvents();
            }

            // Notebook table
            Table Notebook = this.Database.Select("select * from Notebook");
            foreach (Row Row in Notebook) {

                Row NewRow = new Row() {
                    {"id", Row["NotebookId"]},
                    {"timestamp_entry", Row["EntryTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"description", Row["Memo"]},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("journal", NewRow);

                ProcessEvents();
            }

            // GridView table
            Table GridView = this.Database.Select(@"
                select 
                    g.GridViewId, g.Name, g.Description, g.SortOrderNo,
                    f.ActivityList, f.ProjectList, f.RefDatePresetId,
                    f.FromTime, f.ToTime,
                    g.RefGroupById, g.RefDimensionId,
                    g.CreateTime, g.ModifyTime
                from GridView g
                join FilterOptions f on f.FilterOptionsId = g.FilterOptionId");

            foreach (Row Row in GridView) {

                Row NewRow = new Row() {
                    {"id", Row["GridViewId"]},
                    {"name", Row["Name"]},
                    {"description", Row["Description"]},
                    {"sort_index", Row["SortOrderNo"]},
                    {"task_list", Row["ActivityList"]},
                    {"project_list", Row["ProjectList"]},
                    {"date_preset", Row["RefDatePresetId"]},
                    {"start_date", Row["FromTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"end_date", Row["ToTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"end_date_type", 1},
                    {"group_by", Row["RefGroupById"]},
                    {"data_from", Row["RefDimensionId"]},
                    {"hide_empty_rows", 1},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("grid_views", NewRow);

                ProcessEvents();
            }

            // For performance
            newFile.Database.EndWork();
        }

        //---------------------------------------------------------------------

        public void SaveAs20(File newFile)
        {
            // For performance
            newFile.Database.BeginWork();

            //--------------------------------------------------------
            // Define database
            //--------------------------------------------------------

            // Create the new database
            Version Version = new System.Version(2, 0, 0, 0);
            newFile.Create(Version, false);

            // Drop and recreate Meta table
            newFile.Database.Exec("drop table meta");
            newFile.CreateTable("Meta", Version, true);

            //--------------------------------------------------------
            // Data copy
            //--------------------------------------------------------

            // Activity table
            Table Activity = this.Database.Select("select * from Activity");
            foreach (Row Row in Activity) {

                Row NewRow = new Row() {
                    {"id", Row["ActivityId"]},
                    {"name", Row["Name"]},
                    {"descr", Row["Description"]},
                    {"parent_id", Row["ParentId"]},
                    {"is_folder", Row["IsFolder"] ? 1 : 0},
                    {"is_deleted", Row["IsDeleted"] ? 1 : 0},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)}
                };

                newFile.Database.Insert("tasks", NewRow);

                ProcessEvents();
            }

            // Project table
            Table Project = this.Database.Select("select * from Project");
            foreach (Row Row in Project) {

                Row NewRow = new Row() {
                    {"id", Row["ProjectId"]},
                    {"name", Row["Name"]},
                    {"descr", Row["Description"]},
                    {"parent_id", Row["ParentId"]},
                    {"is_folder", Row["IsFolder"] ? 1 : 0},
                    {"is_deleted", Row["IsDeleted"] ? 1 : 0},
                    {"timestamp_c", Row["CreateTime"].ToString(DOWNGRADE_DATETIME_FORMAT)}
                };

                newFile.Database.Insert("projects", NewRow);

                ProcessEvents();
            }

            // Journal table
            Table Journal = this.Database.Select("select * from Journal");
            foreach (Row Row in Journal) {

                Row NewRow = new Row() {
                    {"id", Row["JournalId"]},
                    {"task_id", Row["ActivityId"]},
                    {"project_id", Row["ProjectId"]},
                    {"timestamp_s", Row["StartTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"timestamp_e", Row["StopTime"].ToString(DOWNGRADE_DATETIME_FORMAT)},
                    {"seconds", Row["Seconds"]},
                    {"pre_log", ""},
                    {"post_log", Row["Memo"]},
                    {"is_locked", Row["IsLocked"] ? 1 : 0},
                };

                newFile.Database.Insert("timekeeper", NewRow);

                ProcessEvents();
            }

            // For performance
            newFile.Database.EndWork();
        }

        //---------------------------------------------------------------------

        private void ProcessEvents()
        {
            DowngradeRowCount++;
            if (DowngradeRowCount % 10 == 0) {
                Application.DoEvents();
                Cursor.Current = Cursors.WaitCursor;
            }
        }

        //---------------------------------------------------------------------

    }
}
