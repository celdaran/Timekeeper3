using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class File
    {
        //---------------------------------------------------------------------
        // Downgrading Functions
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
                    {"timestamp_c", Row["CreateTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("tasks", NewRow);
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
                    {"timestamp_c", Row["CreateTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("projects", NewRow);
            }

            // Journal table
            Table Journal = this.Database.Select("select * from Journal");
            foreach (Row Row in Journal) {

                Row NewRow = new Row() {
                    {"id", Row["JournalId"]},
                    {"task_id", Row["ActivityId"]},
                    {"project_id", Row["ProjectId"]},
                    {"timestamp_s", Row["StartTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_e", Row["StopTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"seconds", Row["Seconds"]},
                    {"pre_log", ""},
                    {"post_log", Row["Memo"]},
                    {"is_locked", Row["IsLocked"] ? 1 : 0},
                };

                newFile.Database.Insert("timekeeper", NewRow);
            }

            // Notebook table
            Table Notebook = this.Database.Select("select * from Notebook");
            foreach (Row Row in Notebook) {

                Row NewRow = new Row() {
                    {"id", Row["NotebookId"]},
                    {"timestamp_entry", Row["EntryTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"description", Row["Memo"]},
                    {"timestamp_c", Row["CreateTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("journal", NewRow);
            }

            // GridView table
            Table GridView = this.Database.Select("select * from GridView");
            foreach (Row Row in GridView) {

                Row NewRow = new Row() {
                    {"id", Row["GridViewId"]},
                    {"name", Row["Name"]},
                    {"description", Row["Description"]},
                    {"sort_index", Row["SortOrderNo"]},
                    {"task_list", Row["ActivityFilter"]},
                    {"project_list", Row["ProjectFilter"]},
                    {"date_preset", Row["SystemDatePresetId"]},
                    {"start_date", Row["FromDate"]},
                    {"end_date", Row["ToDate"]},
                    {"end_date_type", Row["EndDateType"]},
                    {"group_by", Row["SystemGridGroupById"]},
                    {"data_from", Row["SystemGridTimeDisplayId"]},
                    {"hide_empty_rows", Row[""]},
                    {"timestamp_c", Row["StartTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_m", Row["StopTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("grid_views", NewRow);
            }
        }

        //---------------------------------------------------------------------

        public void SaveAs21(File newFile)
        {

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
                    {"timestamp_c", Row["CreateTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("tasks", NewRow);
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
                    {"timestamp_c", Row["CreateTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("projects", NewRow);
            }

            // Journal table
            Table Journal = this.Database.Select("select * from Journal");
            foreach (Row Row in Journal) {

                Row NewRow = new Row() {
                    {"id", Row["JournalId"]},
                    {"task_id", Row["ActivityId"]},
                    {"project_id", Row["ProjectId"]},
                    {"timestamp_s", Row["StartTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_e", Row["StopTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"seconds", Row["Seconds"]},
                    {"pre_log", ""},
                    {"post_log", Row["Memo"]},
                    {"is_locked", Row["IsLocked"] ? 1 : 0},
                };

                newFile.Database.Insert("timekeeper", NewRow);
            }

            // Notebook table
            Table Notebook = this.Database.Select("select * from Notebook");
            foreach (Row Row in Notebook) {

                Row NewRow = new Row() {
                    {"id", Row["NotebookId"]},
                    {"timestamp_entry", Row["EntryTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"description", Row["Memo"]},
                    {"timestamp_c", Row["CreateTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("journal", NewRow);
            }

            // GridView table
            Table GridView = this.Database.Select("select * from GridView");
            foreach (Row Row in GridView) {

                Row NewRow = new Row() {
                    {"id", Row["GridViewId"]},
                    {"name", Row["Name"]},
                    {"description", Row["Description"]},
                    {"sort_index", Row["SortOrderNo"]},
                    {"task_list", Row["ActivityFilter"]},
                    {"project_list", Row["ProjectFilter"]},
                    {"date_preset", Row["SystemDatePresetId"]},
                    {"start_date", Row["FromDate"]},
                    {"end_date", Row["ToDate"]},
                    {"end_date_type", Row["EndDateType"]},
                    {"group_by", Row["SystemGridGroupById"]},
                    {"data_from", Row["SystemGridTimeDisplayId"]},
                    {"hide_empty_rows", Row[""]},
                    {"timestamp_c", Row["StartTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"timestamp_m", Row["StopTime"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                newFile.Database.Insert("grid_views", NewRow);
            }
        }

        //---------------------------------------------------------------------

    }
}
