using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class Datafile
    {
        //---------------------------------------------------------------------
        // Downgrading Functions
        //---------------------------------------------------------------------

        public void SaveAs23(Datafile newDatafile)
        {
            // TK2.3's schema was identical to TK2.2
            SaveAs22(newDatafile);
        }

        //---------------------------------------------------------------------

        public void SaveAs22(Datafile newDatafile)
        {

            //--------------------------------------------------------
            // Define database
            //--------------------------------------------------------

            // Create the new database
            Version Version = new System.Version(2, 2, 0, 4);
            newDatafile.Create(Version, false);

            // Drop and recreate Meta table
            newDatafile.Database.Exec("drop table meta");
            newDatafile.CreateTable("Meta", Version, true);

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
                    {"timestamp_c", Row["CreateTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.DATETIME_FORMAT)},
                };

                newDatafile.Database.Insert("tasks", NewRow);
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
                    {"timestamp_c", Row["CreateTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.DATETIME_FORMAT)},
                };

                newDatafile.Database.Insert("projects", NewRow);
            }

            // Journal table
            Table Journal = this.Database.Select("select * from Journal");
            foreach (Row Row in Journal) {

                Row NewRow = new Row() {
                    {"id", Row["JournalEntryId"]},
                    {"task_id", Row["ActivityId"]},
                    {"project_id", Row["ProjectId"]},
                    {"timestamp_s", Row["StartTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_e", Row["StopTime"].ToString(Common.DATETIME_FORMAT)},
                    {"seconds", Row["Seconds"]},
                    {"pre_log", ""},
                    {"post_log", Row["Memo"]},
                    {"is_locked", Row["IsLocked"] ? 1 : 0},
                };

                newDatafile.Database.Insert("timekeeper", NewRow);
            }

            // Diary table
            Table Diary = this.Database.Select("select * from Diary");
            foreach (Row Row in Diary) {

                Row NewRow = new Row() {
                    {"id", Row["DiaryEntryId"]},
                    {"timestamp_entry", Row["EntryTime"].ToString(Common.DATETIME_FORMAT)},
                    {"description", Row["Memo"]},
                    {"timestamp_c", Row["CreateTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.DATETIME_FORMAT)},
                };

                newDatafile.Database.Insert("journal", NewRow);
            }

            // GridOptions table
            Table GridOptions = this.Database.Select("select * from GridOptions");
            foreach (Row Row in GridOptions) {

                Row NewRow = new Row() {
                    {"id", Row["GridOptionsId"]},
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
                    {"timestamp_c", Row["StartTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_m", Row["StopTime"].ToString(Common.DATETIME_FORMAT)},
                };

                newDatafile.Database.Insert("grid_views", NewRow);
            }
        }

        //---------------------------------------------------------------------

        public void SaveAs21(Datafile newDatafile)
        {

            //--------------------------------------------------------
            // Define database
            //--------------------------------------------------------

            // Create the new database
            Version Version = new System.Version(2, 1, 0, 0);
            newDatafile.Create(Version, false);

            // Drop and recreate Meta table
            newDatafile.Database.Exec("drop table meta");
            newDatafile.CreateTable("Meta", Version, true);

            //--------------------------------------------------------
            // Data copy - FIXME: THIS IS NOT FINISHED
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
                    {"timestamp_c", Row["CreateTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.DATETIME_FORMAT)},
                };

                newDatafile.Database.Insert("tasks", NewRow);
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
                    {"timestamp_c", Row["CreateTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.DATETIME_FORMAT)},
                };

                newDatafile.Database.Insert("projects", NewRow);
            }

            // Journal table
            Table Journal = this.Database.Select("select * from Journal");
            foreach (Row Row in Journal) {

                Row NewRow = new Row() {
                    {"id", Row["JournalEntryId"]},
                    {"task_id", Row["ActivityId"]},
                    {"project_id", Row["ProjectId"]},
                    {"timestamp_s", Row["StartTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_e", Row["StopTime"].ToString(Common.DATETIME_FORMAT)},
                    {"seconds", Row["Seconds"]},
                    {"pre_log", ""},
                    {"post_log", Row["Memo"]},
                    {"is_locked", Row["IsLocked"] ? 1 : 0},
                };

                newDatafile.Database.Insert("timekeeper", NewRow);
            }

            // Diary table
            Table Diary = this.Database.Select("select * from Diary");
            foreach (Row Row in Diary) {

                Row NewRow = new Row() {
                    {"id", Row["DiaryEntryId"]},
                    {"timestamp_entry", Row["EntryTime"].ToString(Common.DATETIME_FORMAT)},
                    {"description", Row["Memo"]},
                    {"timestamp_c", Row["CreateTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_m", Row["ModifyTime"].ToString(Common.DATETIME_FORMAT)},
                };

                newDatafile.Database.Insert("journal", NewRow);
            }

            // GridOptions table
            Table GridOptions = this.Database.Select("select * from GridOptions");
            foreach (Row Row in GridOptions) {

                Row NewRow = new Row() {
                    {"id", Row["GridOptionsId"]},
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
                    {"timestamp_c", Row["StartTime"].ToString(Common.DATETIME_FORMAT)},
                    {"timestamp_m", Row["StopTime"].ToString(Common.DATETIME_FORMAT)},
                };

                newDatafile.Database.Insert("grid_views", NewRow);
            }
        }

        //---------------------------------------------------------------------

    }
}
