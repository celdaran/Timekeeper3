using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class Datafile
    {
        private Version CurrentSchemaVersion;

        private ProgressBar Progress;
        private Label Step;
        private long RowId;
        private long InsertedRowId;

        //---------------------------------------------------------------------
        // Upgrading Functions
        //---------------------------------------------------------------------

        public bool Upgrade(Label step, ProgressBar progressBar)
        {
            this.Step = step;
            this.Progress = progressBar;

            bool Populate = true;

            try {
                Version FoundSchemaVersion = this.GetSchemaVersion();
                CurrentSchemaVersion = new Version(SCHEMA_VERSION);

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor == 0))
                {
                    Version PriorVersion = new System.Version(2, 0);
                    Progress.Maximum = Count20();

                    // Upgrade 2.0 tables
                    UpgradeMeta();
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeJournal();

                    // Create 3.0 tables
                    CreateNewTable("Location", CurrentSchemaVersion, Populate);
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);
                    CreateNewTable("Diary", CurrentSchemaVersion, false);
                    CreateNewTable("Options", CurrentSchemaVersion, Populate);
                    CreateNewTable("FilterOptions", CurrentSchemaVersion, Populate);
                    CreateNewTable("GridOptions", CurrentSchemaVersion, false);
                    CreateNewTable("ReportOptions", CurrentSchemaVersion, false);
                    CreateNewTable("SystemDatePreset", CurrentSchemaVersion, Populate);
                    CreateNewTable("SystemGridGroupBy", CurrentSchemaVersion, Populate);
                    CreateNewTable("SystemGridTimeDisplay", CurrentSchemaVersion, Populate);

                    return true;
                }

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor == 1))
                {
                    Version PriorVersion = new System.Version(2, 1);
                    Progress.Maximum = Count21();

                    // Upgrade 2.1 tables
                    UpgradeMeta();
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeDiary();
                    UpgradeGridOptions();
                    UpgradeJournal();

                    // Create 3.0 tables
                    CreateNewTable("Location", CurrentSchemaVersion, Populate);
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);
                    CreateNewTable("Options", CurrentSchemaVersion, Populate);
                    CreateNewTable("ReportOptions", CurrentSchemaVersion, false);
                    CreateNewTable("SystemDatePreset", CurrentSchemaVersion, Populate);
                    CreateNewTable("SystemGridGroupBy", CurrentSchemaVersion, Populate);
                    CreateNewTable("SystemGridTimeDisplay", CurrentSchemaVersion, Populate);

                    return true;
                }

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor >= 2))
                {
                    Version PriorVersion = new System.Version(2, 2);
                    Progress.Maximum = Count22();

                    // Upgrade 2.2 tables
                    UpgradeMeta();
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeDiary();
                    UpgradeGridOptions();
                    UpgradeJournal();

                    // Create 3.0 tables
                    CreateNewTable("Location", CurrentSchemaVersion, Populate);
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);
                    CreateNewTable("Options", CurrentSchemaVersion, Populate);
                    CreateNewTable("ReportOptions", CurrentSchemaVersion, false);
                    CreateNewTable("SystemDatePreset", CurrentSchemaVersion, Populate);
                    CreateNewTable("SystemGridGroupBy", CurrentSchemaVersion, Populate);
                    CreateNewTable("SystemGridTimeDisplay", CurrentSchemaVersion, Populate);

                    return true;
                }

            }
            catch (Exception x) {
                Timekeeper.Warn("Database upgrade failed on Step '" + this.Step.Text + "' on Row Id " + RowId.ToString());
                Timekeeper.Exception(x);
            }

            return false;
        }

        //---------------------------------------------------------------------
        // Upgrade Meta Table
        //---------------------------------------------------------------------

        private void UpgradeMeta()
        {
            // Notify user
            SetStep("Metadata");

            // Save old table in memory
            Table Meta = this.Database.Select("select * from meta order by rowid");

            // Old table did not have an identity column, so we have to 
            // convert our positional array to actual key names to avoid 
            // any odd positionally-related issues (which would be highly
            // likely otherwise.)

            string Created = "";
            string Id = "";

            foreach (Row Item in Meta) {
                if (Item["key"] == "created")
                    Created = Item["value"];
                if (Item["key"] == "id")
                    Id = Item["value"];
            }

            // Create new table
            this.CreateTable("Meta", CurrentSchemaVersion, false);

            // Migrate data
            RowId = 1;
            Row Row = new Row() {
                    {"Key", "Created"},
                    {"Value", Created}
                };
            InsertedRowId = Database.Insert(Timekeeper.MetaTableName(), Row);
            if (InsertedRowId == 0) throw new Exception("Insert failed");
            this.Progress.Value++;

            RowId++;
            Row = new Row() {
                    {"Key", "Upgraded"},
                    {"Value", Common.Now()}
                };
            InsertedRowId = Database.Insert(Timekeeper.MetaTableName(), Row);
            if (InsertedRowId == 0) throw new Exception("Insert failed");
            this.Progress.Value++;

            RowId++;
            Row = new Row() {
                    {"Key", "Version"},
                    {"Value", SCHEMA_VERSION},
                };
            InsertedRowId = Database.Insert(Timekeeper.MetaTableName(), Row);
            if (InsertedRowId == 0) throw new Exception("Insert failed");
            this.Progress.Value++;

            RowId++;
            Row = new Row() {
                    {"Key", "Id"},
                    {"Value", Id}
                };
            InsertedRowId = Database.Insert(Timekeeper.MetaTableName(), Row);
            if (InsertedRowId == 0) throw new Exception("Insert failed");
            this.Progress.Value++;

            // Drop old table
            this.Database.Exec("drop table meta");
        }

        //---------------------------------------------------------------------
        // Upgrade Activity Table
        //---------------------------------------------------------------------

        private void UpgradeActivity(Version priorVersion)
        {
            // Notify user
            SetStep("Activities");

            // Save old table in memory
            Table Activity = this.Database.Select("select * from tasks order by id");

            // Create new table
            this.CreateTable("Activity", CurrentSchemaVersion, false);

            // Migrate rows
            if (priorVersion.Minor == 0) {
                MigrateActivity20(Activity);
            } else if (priorVersion.Minor == 1) {
                MigrateActivity21(Activity);
            } else {
                MigrateActivity22(Activity);
            }

            // Drop old table
            this.Database.Exec("drop table tasks");
        }

        //---------------------------------------------------------------------

        private void MigrateActivity20(Table activity)
        {
            // Migrate data
            int SortOrderNo = 1;
            foreach (Row OldRow in activity) {
                RowId = OldRow["id"];
                Row NewRow = new Row() {
                    {"ActivityId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_c"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", Common.Now()},
                    {"ActivityGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastProjectId", 0},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null}
                };
                InsertedRowId = this.Database.Insert("Activity", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------

        private void MigrateActivity21(Table activity)
        {
            // Migrate data
            int SortOrderNo = 1;
            foreach (Row OldRow in activity) {
                RowId = OldRow["id"];
                Row NewRow = new Row() {
                    {"ActivityId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_c"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", Common.Now()},
                    {"ActivityGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastProjectId", OldRow["project_id__last"] ?? 0},
                    {"IsFolder", OldRow["is_folder"] ? 1: 0},
                    {"IsOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null}
                };
                InsertedRowId = this.Database.Insert("Activity", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------

        private void MigrateActivity22(Table activity)
        {
            // Migrate data
            int SortOrderNo = 1;
            foreach (Row OldRow in activity) {
                RowId = OldRow["id"];
                Row NewRow = new Row() {
                    {"ActivityId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_c"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", Common.Now()},
                    {"ActivityGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastProjectId", OldRow["project_id__last"] ?? 0},
                    {"IsFolder", OldRow["is_folder"] ? 1: 0},
                    {"IsOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", OldRow["is_hidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null}
                };
                InsertedRowId = this.Database.Insert("Activity", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade Project Table
        //---------------------------------------------------------------------

        private void UpgradeProject(Version priorVersion)
        {
            // Notify user
            SetStep("Projects");

            // Save old table in memory
            Table Project = this.Database.Select("select * from projects order by id");

            // Create new table
            this.CreateTable("Project", CurrentSchemaVersion, false);

            // Migrate rows
            if (priorVersion.Minor == 0) {
                MigrateProject20(Project);
            } else if (priorVersion.Minor == 1) {
                MigrateProject21(Project);
            } else {
                MigrateProject22(Project);
            }

            // Drop old table
            this.Database.Exec("drop table projects");
        }

        //---------------------------------------------------------------------

        private void MigrateProject20(Table project)
        {
            int SortOrderNo = 1;
            foreach (Row OldRow in project) {
                RowId = OldRow["id"];

                if (OldRow["timestamp_c"] == null) {
                    OldRow["timestamp_c"] = OldRow["timestamp_m"];
                }

                Row NewRow = new Row() {
                    {"ProjectId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_c"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", Common.Now()},
                    {"ProjectGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastActivityId", 0},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null}
                };
                InsertedRowId = this.Database.Insert("Project", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------

        private void MigrateProject21(Table project)
        {
            int SortOrderNo = 1;
            foreach (Row OldRow in project) {
                RowId = OldRow["id"];

                if (OldRow["timestamp_c"] == null) {
                    OldRow["timestamp_c"] = OldRow["timestamp_m"];
                }

                Row NewRow = new Row() {
                    {"ProjectId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_c"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", OldRow["timestamp_m"].ToString(Common.DATETIME_FORMAT)},
                    {"ProjectGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastActivityId", 0},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null}
                };
                InsertedRowId = this.Database.Insert("Project", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------

        private void MigrateProject22(Table project)
        {
            long SortOrderNo = 1;

            foreach (Row OldRow in project) {
                RowId = OldRow["id"];

                if (OldRow["timestamp_c"] == null) {
                    OldRow["timestamp_c"] = OldRow["timestamp_m"];
                }

                Row NewRow = new Row() {
                    {"ProjectId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_c"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", OldRow["timestamp_m"].ToString(Common.DATETIME_FORMAT)},
                    {"ProjectGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastActivityId", 0},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", OldRow["is_hidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null}
                };
                InsertedRowId = this.Database.Insert("Project", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade Journal Table
        //---------------------------------------------------------------------

        private void UpgradeJournal()
        {
            // Notify user
            SetStep("Timekeeper Journal Entries");

            // Save old table in memory
            // FIXME: Really? In memory?
            Table Journal = this.Database.Select("select * from timekeeper order by id");

            // Create new table
            this.CreateTable("Journal", CurrentSchemaVersion, false);

            // Migrate rows
            foreach (Row OldRow in Journal) {
                RowId = OldRow["id"];

                if (OldRow["is_locked"] == true) {
                    // Automatically unlock any locked rows
                    OldRow["timestamp_e"] = OldRow["timestamp_s"];
                    OldRow["seconds"] = 0;
                    OldRow["is_locked"] = false;
                    Timekeeper.Info(String.Format("Conversion Note: row {0} was locked. The row was safely unlocked and processing continued.", RowId));
                }

                Row NewRow = new Row() {
                    {"JournalEntryId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_s"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", Common.Now()},
                    {"JournalEntryGuid", UUID.Get()},
                    {"ExternalEntryId", null},
                    {"ActivityId", OldRow["task_id"]},
                    {"ProjectId", OldRow["project_id"]},
                    {"StartTime", OldRow["timestamp_s"].ToString(Common.DATETIME_FORMAT)},
                    {"StopTime", OldRow["timestamp_e"].ToString(Common.DATETIME_FORMAT)},
                    {"Seconds", OldRow["seconds"]},
                    {"Memo", OldRow["pre_log"] + "\n\n<!--SEPARATOR-->\n\n" + OldRow["post_log"]},
                    {"LocationId", null},
                    {"CategoryId", null},
                    {"IsLocked", OldRow["is_locked"] ? 1 : 0},
                };
                InsertedRowId = this.Database.Insert("Journal", NewRow);
                if (InsertedRowId == 0) {
                    throw new Exception("Insert failed");
                }
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }

            // Drop old table
            this.Database.Exec("drop table timekeeper");
        }

        //---------------------------------------------------------------------
        // Upgrade Diary Table
        //---------------------------------------------------------------------

        private void UpgradeDiary()
        {
            // Notify user
            SetStep("Diary Entries");

            // Save old table in memory
            Table Diary = this.Database.Select("select * from journal order by id");

            // Create new table
            this.CreateTable("Diary", CurrentSchemaVersion, false);

            // Migrate rows
            foreach (Row OldRow in Diary) {
                RowId = OldRow["id"];
                Row NewRow = new Row() {
                    {"DiaryEntryId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_c"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", OldRow["timestamp_m"].ToString(Common.DATETIME_FORMAT)},
                    {"DiaryEntryGuid", UUID.Get()},
                    {"EntryTime", OldRow["timestamp_entry"].ToString(Common.DATETIME_FORMAT)},
                    {"Memo", OldRow["description"]},
                    {"LocationId", null},
                    {"CategoryId", null},
                };
                InsertedRowId = this.Database.Insert("Diary", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }

            // Drop old table
            this.Database.Exec("drop table journal");
        }

        //---------------------------------------------------------------------
        // Upgrade GridOptions Table
        //---------------------------------------------------------------------

        private void UpgradeGridOptions()
        {
            // Notify user
            SetStep("Grid Options");

            // Save old table in memory
            Table GridOptions = this.Database.Select("select * from grid_views order by id");

            // Create new tables
            this.CreateTable("FilterOptions", CurrentSchemaVersion, false);
            this.CreateTable("GridOptions", CurrentSchemaVersion, false);

            // Migrate rows
            foreach (Row OldRow in GridOptions) {
                RowId = OldRow["id"];

                // FIXME: we're still missing the "end date type' concept (previously known as grid_views.end_date_type)
                Row NewFilterOptionsRow = new Row() {
                    {"CreateTime", Common.Now()},
                    {"ModifyTime", Common.Now()},
                    {"ActivityList", OldRow["task_list"]},
                    {"ProjectList", OldRow["project_list"]},
                    {"SystemDatePresetId", OldRow["date_preset"]},
                    {"FromDate", OldRow["start_date"]},
                    {"ToDate", OldRow["end_date"]},
                    {"Memo", null},
                    {"DurationOperator", null},
                    {"DurationAmount", null},
                    {"DurationUnit", null},
                    {"LocationList", null},
                    {"CategoryList", null}
                };
                InsertedRowId = this.Database.Insert("FilterOptions", NewFilterOptionsRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");

                Row NewRow = new Row() {
                    {"GridOptionsId", OldRow["id"]},
                    {"CreateTime", OldRow["timestamp_c"].ToString(Common.DATETIME_FORMAT)},
                    {"ModifyTime", OldRow["timestamp_m"].ToString(Common.DATETIME_FORMAT)},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["description"]},
                    {"SortOrderNo", OldRow["sort_index"]},
                    {"FilterOptionsId", InsertedRowId},
                    {"ItemTypeId", OldRow["data_from"]},
                    {"SystemGridGroupById", OldRow["group_by"]},
                    {"SystemGridTimeDisplayId", null},
                };
                InsertedRowId = this.Database.Insert("GridOptions", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;
            }

            // Drop old table
            this.Database.Exec("drop table grid_views");
        }

        //---------------------------------------------------------------------
        // Progress bar helpers
        //---------------------------------------------------------------------

        private int Count20()
        {
            int Count = 0;
            Row Row;

            /* No. Don't count how many there were. Count how many there will be
            Row = this.Database.SelectRow("select count(*) as Count from meta");
            Count += Row["Count"];
            */
            Count = 4; // Hardcoding for the four rows that the meta table gets in schema 3.0.0.0

            Row = this.Database.SelectRow("select count(*) as Count from tasks");
            Count += Row["Count"];

            Row = this.Database.SelectRow("select count(*) as Count from projects");
            Count += Row["Count"];

            Row = this.Database.SelectRow("select count(*) as Count from timekeeper");
            Count += Row["Count"];

            return Count;
        }

        //---------------------------------------------------------------------

        private int Count21()
        {
            int Count = Count20();
            Row Row;

            Row = this.Database.SelectRow("select count(*) as Count from journal");
            Count += Row["Count"];

            Row = this.Database.SelectRow("select count(*) as Count from grid_views");
            Count += Row["Count"];

            return Count;
        }

        //---------------------------------------------------------------------

        private int Count22()
        {
            // No change in the number of tables
            return Count21();
        }

        //---------------------------------------------------------------------
        // Step Helpers
        //---------------------------------------------------------------------

        private void SetStep(string stepText, long rowId)
        {
            SetStep(stepText);
            this.RowId = rowId;
        }

        //---------------------------------------------------------------------

        private void SetStep(string stepText)
        {
            this.Step.Text = stepText;
            Application.DoEvents();
        }

        //---------------------------------------------------------------------
        // Create Table Helper
        //---------------------------------------------------------------------

        private void CreateNewTable(string tableName, Version currentSchemaVersion, bool populate)
        {
            SetStep("Creating " + tableName + " Table", -1);
            CreateTable(tableName, currentSchemaVersion, populate);
        }

        //---------------------------------------------------------------------

    }
}
