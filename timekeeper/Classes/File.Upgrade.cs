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
        private Version CurrentSchemaVersion;

        private ProgressBar Progress;
        private Label Step;
        private long RowId;
        private long InsertedRowId;

        private FileUpgradeOptions UpgradeOptions;

        private DateTime FileCreateDate;

        //---------------------------------------------------------------------
        // Upgrading Functions
        //---------------------------------------------------------------------

        public bool Upgrade(Label step, ProgressBar progressBar, FileUpgradeOptions options)
        {
            this.Step = step;
            this.Progress = progressBar;
            this.UpgradeOptions = options;

            bool Populate = true;

            try {
                Version FoundSchemaVersion = this.GetSchemaVersion();
                CurrentSchemaVersion = new Version(SCHEMA_VERSION);

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor == 0))
                {
                    Version PriorVersion = new System.Version(2, 0);
                    Progress.Maximum = Count20();

                    // Create 3.0 reference tables
                    CreateRefTables(CurrentSchemaVersion);

                    // Upgrade 2.0 tables
                    UpgradeMeta();
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeJournal();

                    // Create remaining 3.0 tables
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);
                    CreateNewTable("Notebook", CurrentSchemaVersion, false);
                    CreateNewTable("Options", CurrentSchemaVersion, Populate);
                    CreateNewTable("FilterOptions", CurrentSchemaVersion, false);
                    CreateNewTable("FindView", CurrentSchemaVersion, false);
                    CreateNewTable("GridView", CurrentSchemaVersion, false);
                    CreateNewTable("ReportView", CurrentSchemaVersion, false);

                    return true;
                }

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor == 1))
                {
                    Version PriorVersion = new System.Version(2, 1);
                    Progress.Maximum = Count21();

                    // Create 3.0 reference tables
                    CreateRefTables(CurrentSchemaVersion);

                    // Upgrade 2.1 tables
                    UpgradeMeta();
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeNotebook();
                    UpgradeGridView();
                    UpgradeJournal();

                    // Create 3.0 tables
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);
                    CreateNewTable("Options", CurrentSchemaVersion, Populate);
                    CreateNewTable("ReportView", CurrentSchemaVersion, false);

                    return true;
                }

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor >= 2))
                {
                    Version PriorVersion = new System.Version(2, 2);
                    Progress.Maximum = Count22();

                    // Create 3.0 reference tables
                    CreateRefTables(CurrentSchemaVersion);

                    // Upgrade 2.2 tables
                    UpgradeMeta();
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeNotebook();
                    UpgradeGridView();
                    UpgradeJournal();

                    // Create 3.0 tables
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);
                    CreateNewTable("Options", CurrentSchemaVersion, Populate);
                    CreateNewTable("ReportView", CurrentSchemaVersion, false);

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
        // Create (and populate) Ref tables
        //---------------------------------------------------------------------

        private void CreateRefTables(Version version)
        {
            // Create prerequisite 3.0 tables
            CreateNewTable("RefDimension", version, true);
            CreateNewTable("RefDatePreset", version, true);
            CreateNewTable("RefGroupBy", version, true);
            CreateNewTable("RefTimeDisplay", version, true);

            CreateNewTable("RefTimeZone", version, false);
            PopulateRefTimeZone();

            CreateNewTable("Location", version, false);
            PopulateLocation((FileBaseOptions)this.UpgradeOptions);
        }

        //---------------------------------------------------------------------
        // Upgrade Meta Table
        //---------------------------------------------------------------------

        private void UpgradeMeta()
        {
            // Notify user
            SetStep("Meta Data");

            // Save old table in memory
            Table Meta = this.Database.Select("select * from meta order by rowid");

            // Old table did not have an identity column, so we have to 
            // convert our positional array to actual key names to avoid 
            // any odd positionally-related issues (which would be highly
            // likely otherwise.)

            string Created = "";
            string Id = "";

            foreach (Row Item in Meta) {
                if (Item["key"] == "version") {
                    // A bug prior to TK3 sometimes had the create
                    // date on the timestamp of the version row and 
                    // not (ironically) on the create row. For safety
                    // always use version.timestamp_c to get the actual
                    // create date of a database.
                    // Actually: not always a bug: TK 2.0 *only* had
                    // a verion key and nothing else.
                    Created = ConvertTime(Item["timestamp_c"]);
                    this.FileCreateDate = Item["timestamp_c"];
                }
                if (Item["key"] == "id")
                    Id = Item["value"];
            }

            // Older versions may not have had a GUID. Fill one in now
            // if an existing one could not be found
            if (Id == "") {
                Id = UUID.Get();
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
                    {"CreateTime", ConvertTime(OldRow["timestamp_c"])},
                    {"ModifyTime", ConvertTime(OldRow["timestamp_c"])}, // didn't exist in this schema, set to 'c'
                    {"ActivityGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastProjectId", 0},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
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
                    {"CreateTime", ConvertTime(OldRow["timestamp_c"])},
                    {"ModifyTime", ConvertTime(OldRow["timestamp_m"])},
                    {"ActivityGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastProjectId", OldRow["project_id__last"] ?? 0},
                    {"IsFolder", OldRow["is_folder"] ? 1: 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
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
                    {"CreateTime", ConvertTime(OldRow["timestamp_c"])},
                    {"ModifyTime", ConvertTime(OldRow["timestamp_m"])},
                    {"ActivityGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastProjectId", OldRow["project_id__last"] ?? 0},
                    {"IsFolder", OldRow["is_folder"] ? 1: 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
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
                    OldRow["timestamp_c"] = this.FileCreateDate;
                }

                Row NewRow = new Row() {
                    {"ProjectId", OldRow["id"]},
                    {"CreateTime", ConvertTime(OldRow["timestamp_c"])},
                    {"ModifyTime", ConvertTime(OldRow["timestamp_c"])}, // didn't exist in this schema, set to 'c'
                    {"ProjectGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastActivityId", 0},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null},
                    {"ExternalProjectNo", null}
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
                    {"CreateTime", ConvertTime(OldRow["timestamp_c"])},
                    {"ModifyTime", ConvertTime(OldRow["timestamp_m"])},
                    {"ProjectGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastActivityId", 0},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null},
                    {"ExternalProjectNo", null}
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
                    {"CreateTime", ConvertTime(OldRow["timestamp_c"])},
                    {"ModifyTime", ConvertTime(OldRow["timestamp_m"])},
                    {"ProjectGuid", UUID.Get()},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["descr"]},
                    {"ParentId", OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"LastActivityId", 0},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", OldRow["is_hidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null},
                    {"ExternalProjectNo", null}
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
            SetStep("Journal Entries");

            // Save old table in memory
            // FIXME: Really? In memory?
            Table Journal = this.Database.Select("select * from timekeeper order by timestamp_s");

            // Create new table
            this.CreateTable("Journal", CurrentSchemaVersion, false);

            // Journal Index
            // This value is used primarily for navigational purposes. We don't use the
            // JournalId identity column, because this does not indicate chronology (and
            // is also immutable). We don't use StartTime, because it's unpredictable.
            // Therefore, JournalIndex acts like a JournalId value that can be updated
            // as StartTime is updated: it's both chronologically correct and predictable,
            // which makes for lightning-fast navigation when browsing Journal entries.
            int JournalIndex = 1;

            // Delta Bucket
            int CumulativeDrift = 0;

            // Migrate rows
            foreach (Row OldRow in Journal) {
                RowId = OldRow["id"];

                if (OldRow["is_locked"] == null) {
                    OldRow["is_locked"] = false;
                    Timekeeper.Info(String.Format("Conversion Note: row {0} had a null is_locked value. Assumed false and processing continued.", RowId));
                }

                if (OldRow["is_locked"] == true) {
                    // Automatically unlock any locked rows
                    OldRow["timestamp_e"] = OldRow["timestamp_s"];
                    OldRow["seconds"] = 0;
                    OldRow["is_locked"] = false;
                    Timekeeper.Info(String.Format("Conversion Note: row {0} was locked. The row was safely unlocked and processing continued.", RowId));
                }

                if (OldRow["timestamp_e"] == null) {
                    if (OldRow["seconds"] == null) {
                        OldRow["timestamp_e"] = OldRow["timestamp_s"];
                    } else {
                        int Seconds = (int)OldRow["seconds"];
                        TimeSpan Elapsed = new System.TimeSpan(0, 0, Seconds);
                        OldRow["timestamp_e"] = OldRow["timestamp_s"].Add(Elapsed);
                    }
                    Timekeeper.Info(String.Format("Conversion Note: row {0} had no StopTime value. A value based on StartTime was calculated and used.", RowId));
                }

                // Due to various reasons, the value of timekeeper.seconds isn't always the
                // exact delta between timestamp_s and timestamp_e. For that reason, the file
                // upgrade path recalculates seconds, thus ensuring this value matches the
                // visible start/end times of the journal entry.
                DateTime StartTime = OldRow["timestamp_s"];
                DateTime StopTime = OldRow["timestamp_e"];
                TimeSpan Delta = StopTime.Subtract(StartTime);
                int DeltaSeconds = Convert.ToInt32(Delta.TotalSeconds);

                if (OldRow["seconds"] != DeltaSeconds) {
                    CumulativeDrift += DeltaSeconds - OldRow["seconds"];
                    string Message = String.Format("Row {0}: saved 'seconds' ({1}) does not equal recalculated value ({2})",
                            OldRow["id"],
                            OldRow["seconds"],
                            DeltaSeconds);
                    if (Math.Abs(DeltaSeconds) > 5) {
                        // Report the large ones
                        Timekeeper.Info(Message);
                    } else {
                        // "Ignore" the small ones: it can get very noisy
                        Timekeeper.Debug(Message);
                    }
                }

                Row NewRow = new Row() {
                    {"JournalId", OldRow["id"]},
                    {"CreateTime", ConvertTime(OldRow["timestamp_s"])}, // column didn't exist until TK3
                    {"ModifyTime", ConvertTime(OldRow["timestamp_e"])}, // column didn't exist until TK3
                    {"JournalGuid", UUID.Get()},
                    {"ActivityId", OldRow["task_id"]},
                    {"ProjectId", OldRow["project_id"]},
                    {"StartTime", ConvertTime(OldRow["timestamp_s"])},
                    {"StopTime", ConvertTime(OldRow["timestamp_e"])},
                    {"Seconds", DeltaSeconds},
                    {"LocationId", 1},
                    {"CategoryId", null},
                    {"IsLocked", OldRow["is_locked"] ? 1 : 0},
                    {"JournalIndex", JournalIndex},
                    {"OriginalStartTime", OldRow["timestamp_s"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                    {"OriginalStopTime", OldRow["timestamp_e"].ToString(Common.LOCAL_DATETIME_FORMAT)},
                };

                switch (UpgradeOptions.MemoMergeTypeId) {
                    case 1: NewRow["Memo"] = OldRow["pre_log"] + "\n\n<!--SEPARATOR-->\n\n" + OldRow["post_log"]; break;
                    case 2: NewRow["Memo"] = OldRow["pre_log"] + "\n\n<!--CUSTOM SEP-->\n\n" + OldRow["post_log"]; break;
                    case 3: NewRow["Memo"] = OldRow["post_log"]; break;
                    case 4: NewRow["Memo"] = OldRow["pre_log"]; break;
                    default: throw new Exception("Invalid MemoMergeTypeId Found: " + UpgradeOptions.MemoMergeTypeId.ToString());
                }

                InsertedRowId = this.Database.Insert("Journal", NewRow);
                if (InsertedRowId == 0) {
                    throw new Exception("Insert failed");
                }

                JournalIndex++;
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }

            // How'd we do?
            Timekeeper.Info(String.Format("Total time drift: {0}", CumulativeDrift));

            // Drop old table
            this.Database.Exec("drop table timekeeper");
        }

        //---------------------------------------------------------------------
        // Upgrade Notebook Table
        //---------------------------------------------------------------------

        private void UpgradeNotebook()
        {
            // Notify user
            SetStep("Notebook Entries");

            // Save old table in memory
            Table Notebook = this.Database.Select("select * from journal order by id");

            // Create new table
            this.CreateTable("Notebook", CurrentSchemaVersion, false);

            // Migrate rows
            foreach (Row OldRow in Notebook) {
                RowId = OldRow["id"];
                Row NewRow = new Row() {
                    {"NotebookId", OldRow["id"]},
                    {"CreateTime", ConvertTime(OldRow["timestamp_c"])},
                    {"ModifyTime", ConvertTime(OldRow["timestamp_m"])},
                    {"NotebookGuid", UUID.Get()},
                    {"EntryTime", ConvertTime(OldRow["timestamp_entry"])},
                    {"Memo", OldRow["description"]},
                    {"LocationId", 1},
                    {"CategoryId", null},
                };
                InsertedRowId = this.Database.Insert("Notebook", NewRow);
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
        // Upgrade GridView Table
        //---------------------------------------------------------------------

        private void UpgradeGridView()
        {
            // Notify user
            SetStep("Grid Options");

            // Save old table in memory
            Table GridView = this.Database.Select("select * from grid_views order by id");

            // Create new tables
            this.CreateTable("FilterOptions", CurrentSchemaVersion, false);
            this.CreateTable("GridView", CurrentSchemaVersion, false);

            // Migrate rows
            foreach (Row OldRow in GridView) {
                RowId = OldRow["id"];

                // FIXME: we're still missing the "end date type' concept (previously known as grid_views.end_date_type)
                Row NewFilterOptionsRow = new Row() {
                    {"CreateTime", Common.Now()},
                    {"ModifyTime", Common.Now()},
                    {"ActivityList", OldRow["task_list"]},
                    {"ProjectList", OldRow["project_list"]},
                    {"RefDatePresetId", OldRow["date_preset"]},
                    {"FromDate", OldRow["start_date"]},
                    {"ToDate", OldRow["end_date"]},
                    {"MemoContains", null},
                    {"DurationOperator", null},
                    {"DurationAmount", null},
                    {"DurationUnit", null},
                    {"LocationList", null},
                    {"CategoryList", null}
                };
                InsertedRowId = this.Database.Insert("FilterOptions", NewFilterOptionsRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");

                Row NewRow = new Row() {
                    {"GridViewId", OldRow["id"]},
                    {"CreateTime", ConvertTime(OldRow["timestamp_c"])},
                    {"ModifyTime", ConvertTime(OldRow["timestamp_m"])},
                    {"Name", OldRow["name"]},
                    {"Description", OldRow["description"]},
                    {"SortOrderNo", OldRow["sort_index"]},
                    {"FilterOptionsId", InsertedRowId},
                    {"RefDimensionId", OldRow["data_from"]},
                    {"RefGroupById", OldRow["group_by"]},
                    {"RefTimeDisplayId", null},
                };
                InsertedRowId = this.Database.Insert("GridView", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;
            }

            // Drop old table
            this.Database.Exec("drop table grid_views");
        }

        //---------------------------------------------------------------------
        // General Helpers
        //---------------------------------------------------------------------

        private string ConvertTime(DateTime time)
        {
            /*
            Given a current time zone of US Central Time:

            Convert:  2013-01-01 20:00:00
            To.....:  2013-01-02 02:00:00-06:00

            Convert:  2013-07-01 20:00:00
            To.....:  2013-07-02 01:00:00-05:00
            */

            // Get time into standard string format
            string ConvertedTime = time.ToString(Common.LOCAL_DATETIME_FORMAT);

            // Make sure we have the right date/time delimeter
            ConvertedTime = ConvertedTime.Replace(' ', 'T');

            // Calculate the timezone & dst (if any) offset
            TimeSpan Offset = UpgradeOptions.LocationTimeZoneInfo.BaseUtcOffset;
            int OffsetHours = Offset.Hours;
            TimeZoneInfo TimeZoneInfo = UpgradeOptions.LocationTimeZoneInfo;

            if (TimeZoneInfo.SupportsDaylightSavingTime) {
                if (TimeZoneInfo.IsDaylightSavingTime(time)) {
                    OffsetHours++;
                }
            }

            string TimeZoneOffset = String.Format("{0:00}:{1:00}", OffsetHours, Offset.Minutes);

            // Now tack on the timezone (utc offset, with dst factored in)
            ConvertedTime += TimeZoneOffset;

            // Done
            return ConvertedTime;
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
            Count = 4; // Hardcoding for the four rows that the meta table gets in schema 3.0.x

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
