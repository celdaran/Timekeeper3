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
        private long UpdatedRowCount;

        private FileUpgradeOptions UpgradeWizardOptions;

        private DateTimeOffset FileCreateDate;

        //---------------------------------------------------------------------
        // Upgrading Functions
        //---------------------------------------------------------------------

        public bool Upgrade(Label step, ProgressBar progressBar, FileUpgradeOptions options)
        {
            this.Step = step;
            this.Progress = progressBar;
            this.UpgradeWizardOptions = options;

            bool Populate = true;

            Version FoundSchemaVersion;

            try {
                FoundSchemaVersion = this.GetSchemaVersion();
                CurrentSchemaVersion = new Version(SCHEMA_VERSION);

                // Begin a unit of work (this is NOT a transaction)
                this.Database.BeginWork();
                this.Database.Exec("PRAGMA foreign_keys = OFF");

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor == 0))
                {
                    Version PriorVersion = new System.Version(2, 0);
                    Progress.Maximum = Count20();

                    // Create 3.0 reference tables
                    CreateRefTables(CurrentSchemaVersion);

                    // Create new 3.0 dimensions
                    CreateNewTable("Location", CurrentSchemaVersion, false);
                    PopulateLocation(CurrentSchemaVersion, (FileBaseOptions)this.UpgradeWizardOptions);
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);

                    // Upgrade 2.0 tables
                    UpgradeMeta(PriorVersion);
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeJournal(PriorVersion);

                    // Create remaining 3.0 tables
                    CreateNewTable("Notebook", CurrentSchemaVersion, false);
                    CreateNewTable("Todo", CurrentSchemaVersion, false);
                    CreateNewTable("Reminder", CurrentSchemaVersion, false);
                    CreateNewTable("Schedule", CurrentSchemaVersion, Populate);
                    CreateNewTable("EventGroup", CurrentSchemaVersion, Populate);
                    CreateNewTable("Event", CurrentSchemaVersion, false);

                    CreateNewTable("Options", CurrentSchemaVersion, Populate);
                    CreateNewTable("FilterOptions", CurrentSchemaVersion, false);

                    CreateNewTable("GridView", CurrentSchemaVersion, false);
                    CreateNewTable("FindView", CurrentSchemaVersion, false);
                    CreateNewTable("ReportView", CurrentSchemaVersion, false);
                    CreateNewTable("CalendarView", CurrentSchemaVersion, false);
                    CreateNewTable("PunchCardView", CurrentSchemaVersion, false);

                    CreateNewTable("Audit", CurrentSchemaVersion, false);
                }

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor == 1))
                {
                    Version PriorVersion = new System.Version(2, 1);
                    Progress.Maximum = Count21();

                    // Create 3.0 reference tables
                    CreateRefTables(CurrentSchemaVersion);

                    // Create new 3.0 dimensions
                    CreateNewTable("Location", CurrentSchemaVersion, false);
                    PopulateLocation(CurrentSchemaVersion, (FileBaseOptions)this.UpgradeWizardOptions);
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);

                    // Upgrade 2.1 tables
                    UpgradeMeta(PriorVersion);
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeNotebook(PriorVersion);
                    UpgradeGridView(PriorVersion);
                    UpgradeJournal(PriorVersion);

                    // Create 3.0 tables
                    CreateNewTable("Todo", CurrentSchemaVersion, false);
                    CreateNewTable("Reminder", CurrentSchemaVersion, false);
                    CreateNewTable("Schedule", CurrentSchemaVersion, Populate);
                    CreateNewTable("EventGroup", CurrentSchemaVersion, Populate);
                    CreateNewTable("Event", CurrentSchemaVersion, false);

                    CreateNewTable("Options", CurrentSchemaVersion, Populate);

                    CreateNewTable("FindView", CurrentSchemaVersion, false);
                    CreateNewTable("ReportView", CurrentSchemaVersion, false);
                    CreateNewTable("CalendarView", CurrentSchemaVersion, false);
                    CreateNewTable("PunchCardView", CurrentSchemaVersion, false);

                    CreateNewTable("Audit", CurrentSchemaVersion, false);
                }

                if ((FoundSchemaVersion.Major == 2) && (FoundSchemaVersion.Minor >= 2))
                {
                    Version PriorVersion = new System.Version(2, 2);
                    Progress.Maximum = Count22();

                    // Create 3.0 reference tables
                    CreateRefTables(CurrentSchemaVersion);

                    // Create new 3.0 dimensions
                    CreateNewTable("Location", CurrentSchemaVersion, false);
                    PopulateLocation(CurrentSchemaVersion, (FileBaseOptions)this.UpgradeWizardOptions);
                    CreateNewTable("Category", CurrentSchemaVersion, Populate);

                    // Upgrade 2.2 tables
                    UpgradeMeta(PriorVersion);
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeNotebook(PriorVersion);
                    UpgradeGridView(PriorVersion);
                    //UpgradeJournal(PriorVersion); <-- WARNING WARNING DO NOT SUBMIT LIKE THIS WARNING WARNING

                    // Create 3.0 tables
                    CreateNewTable("Todo", CurrentSchemaVersion, false);
                    CreateNewTable("Reminder", CurrentSchemaVersion, false);
                    CreateNewTable("Schedule", CurrentSchemaVersion, Populate);
                    CreateNewTable("EventGroup", CurrentSchemaVersion, Populate);
                    CreateNewTable("Event", CurrentSchemaVersion, false);

                    CreateNewTable("Options", CurrentSchemaVersion, Populate);

                    CreateNewTable("FindView", CurrentSchemaVersion, false);
                    CreateNewTable("ReportView", CurrentSchemaVersion, false);
                    CreateNewTable("CalendarView", CurrentSchemaVersion, false);
                    CreateNewTable("PunchCardView", CurrentSchemaVersion, false);

                    CreateNewTable("Audit", CurrentSchemaVersion, false);
                }

                // Highly specialized upgrade case to help me make the ginormous
                // leap from Schema 3.0.7.2 to Schema 3.0.9.3. This contains the
                // massive paradigm shift related to Issue #1345 and everything
                // that that implies. Yes it will only be used once, but I'm all
                // out of options.
                if (FoundSchemaVersion.CompareTo(new Version(3, 0, 7, 2)) == 0)
                {
                    Version PriorVersion = new System.Version(3, 0, 7, 2);
                    Progress.Maximum = 9999; // DON'T CARE

                    // Don't (re-)create 3.0 reference tables
                    this.Database.Exec("drop table RefDatePreset");
                    this.Database.Exec("drop table RefDimension");
                    this.Database.Exec("drop table RefGroupBy");
                    this.Database.Exec("drop table RefScheduleType");
                    this.Database.Exec("drop table RefTimeDisplay");
                    this.Database.Exec("drop table RefTimeZone");
                    this.Database.Exec("drop table RefTodoStatus");
                    CreateRefTables(CurrentSchemaVersion);

                    // Upgrade 3.0.7.2 tables
                    UpgradeMeta(PriorVersion);
                    UpgradeCategory(PriorVersion);
                    UpgradeLocation(PriorVersion);
                    UpgradeActivity(PriorVersion);
                    UpgradeProject(PriorVersion);
                    UpgradeNotebook(PriorVersion);
                    UpgradeJournal(PriorVersion);
                    UpgradeTodo();
                    UpgradeReminder();
                    UpgradeSchedule();
                    UpgradeEventGroup();
                    UpgradeEvent();
                    UpgradeOptions();
                    UpgradeFilterOptions();
                    UpgradeGridView(PriorVersion);
                    UpgradeFindView();
                    UpgradeReportView();
                }

            }
            catch (Exception x) {
                Timekeeper.Warn("Database upgrade failed on Step '" + this.Step.Text + "' on Row Id " + RowId.ToString());
                Timekeeper.Exception(x);
                this.Database.EndWork();
                return false;
            }

            this.Audit.DatabaseUpgraded(FoundSchemaVersion, CurrentSchemaVersion);

            this.Database.EndWork();

            return true;
        }

        //---------------------------------------------------------------------
        // Create (and populate) Ref tables
        //---------------------------------------------------------------------

        private void CreateRefTables(Version version)
        {
            CreateNewTable("RefDimension", version, true);
            CreateNewTable("RefDatePreset", version, true);
            CreateNewTable("RefGroupBy", version, true);
            CreateNewTable("RefScheduleType", version, true);
            CreateNewTable("RefTimeDisplay", version, true);
            CreateNewTable("RefTimeZone", version, false);
            CreateNewTable("RefTodoStatus", version, true);
            PopulateRefTimeZone(version);
        }

        //---------------------------------------------------------------------
        // Upgrade Meta Table
        //---------------------------------------------------------------------

        private void UpgradeMeta(Version priorVersion)
        {
            // Notify user
            SetStep("Meta Data");

            Table Meta = new Table();
            switch (priorVersion.Major) {
                case 2:
                    // Save old table in memory
                    Meta = this.Database.Select("select * from meta order by rowid");
                    // Drop old table
                    this.Database.Exec("drop table meta");
                    // Create new table
                    this.CreateTable("Meta", CurrentSchemaVersion, false);
                    break;
                case 3:
                    Meta = this.Database.Select("select * from " + Timekeeper.MetaTableName() + " where MetaId = 1");
                    break;
            }

            // Migrate rows
            if (priorVersion.Major == 3)
                MigrateMeta3072(Meta);
            else
                MigrateMeta2x(Meta);
        }

        //---------------------------------------------------------------------

        private void MigrateMeta2x(Table Meta)
        {
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
                    {"Value", Timekeeper.DateForDatabase()}
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

            RowId++;
            Row = new Row() {
                    {"Key", "ProcessId"},
                    {"Value", "0"}
                };
            InsertedRowId = Database.Insert(Timekeeper.MetaTableName(), Row);
            if (InsertedRowId == 0) throw new Exception("Insert failed");
            this.Progress.Value++;
        }

        //---------------------------------------------------------------------

        private void MigrateMeta3072(Table Meta)
        {
            Row Row;

            RowId++;
            Row = new Row() {
                    {"Value", SCHEMA_VERSION},
                };
            UpdatedRowCount = Database.Update(Timekeeper.MetaTableName(), Row, "Key", "Version");
            if (UpdatedRowCount == 0) throw new Exception("Update failed");
            this.Progress.Value++;

            RowId++;
            DateTimeOffset MetaCreateTime = DateTimeOffset.Parse(Meta[0]["Value"]);
            Row = new Row() {
                    {"Value", Timekeeper.DateForDatabase(MetaCreateTime)}
                };
            UpdatedRowCount = Database.Update(Timekeeper.MetaTableName(), Row, "Key", "Created");
            if (UpdatedRowCount == 0) throw new Exception("Update failed");
            this.Progress.Value++;

            RowId++;
            Row = new Row() {
                    {"Value", Timekeeper.DateForDatabase()}
                };
            UpdatedRowCount = Database.Update(Timekeeper.MetaTableName(), Row, "Key", "Upgraded");
            if (UpdatedRowCount == 0) throw new Exception("Update failed");
            this.Progress.Value++;

        }

        //---------------------------------------------------------------------
        // Upgrade Activity Table
        //---------------------------------------------------------------------

        private void UpgradeActivity(Version priorVersion)
        {
            // Notify user
            SetStep("Activities");

            // Save old table in memory
            Table Activity = new Table();
            switch (priorVersion.Major) {
                case 2: 
                    Activity = this.Database.Select("select * from tasks order by id");
                    this.Database.Exec("drop table tasks");
                    break;
                case 3: Activity = this.Database.Select("select * from Activity order by ActivityId");
                    this.Database.Exec("drop table Activity");
                    break;
            }

            // Create new table
            this.CreateTable("Activity", CurrentSchemaVersion, false);

            // Migrate rows
            if (priorVersion.Major == 3)
                MigrateActivity3072(Activity);
            else if (priorVersion.Minor == 0)
                MigrateActivity20(Activity);
            else if (priorVersion.Minor == 1)
                MigrateActivity21(Activity);
            else
                MigrateActivity22(Activity);
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
                    {"ParentId", OldRow["parent_id"] == 0 ? null : OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
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
                    {"ParentId", OldRow["parent_id"] == 0 ? null : OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
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
                    {"ParentId", OldRow["parent_id"] == 0 ? null : OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
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

        private void MigrateActivity3072(Table activity)
        {
            foreach (Row OldRow in activity) {
                RowId = OldRow["ActivityId"];
                Row NewRow = new Row() {
                    {"ActivityId", OldRow["ActivityId"]},
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"ActivityGuid", OldRow["ActivityGuid"]},
                    {"Name", OldRow["Name"]},
                    {"Description", OldRow["Description"]},
                    {"ParentId", OldRow["ParentId"] == 0 ? null : OldRow["ParentId"]},
                    {"SortOrderNo", OldRow["SortOrderNo"]},
                    {"IsFolder", OldRow["IsFolder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["IsFolderOpened"] ? 1 : 0},
                    {"IsHidden", OldRow["IsHidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["IsDeleted"] ? 1 : 0},
                    {"HiddenTime", ConvertTime(OldRow["HiddenTime"])},
                    {"DeletedTime", ConvertTime(OldRow["DeletedTime"])}
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
        // Upgrade Category Table
        //---------------------------------------------------------------------

        private void UpgradeCategory(Version priorVersion)
        {
            // Notify user
            SetStep("Categories");

            // Save old table in memory
            Table Category = new Table();
            switch (priorVersion.Major) {
                case 3: Category = this.Database.Select("select * from Category order by CategoryId");
                    this.Database.Exec("drop table Category");
                    break;
            }

            // Create new table
            this.CreateTable("Category", CurrentSchemaVersion, false);

            // Migrate rows
            if (priorVersion.Major == 3)
                MigrateCategory3072(Category);
        }

        //---------------------------------------------------------------------

        private void MigrateCategory3072(Table category)
        {
            foreach (Row OldRow in category) {
                RowId = OldRow["CategoryId"];
                Row NewRow = new Row() {
                    {"CategoryId", OldRow["CategoryId"]},
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"CategoryGuid", OldRow["CategoryGuid"]},
                    {"Name", OldRow["Name"]},
                    {"Description", OldRow["Description"]},
                    {"ParentId", null},
                    {"SortOrderNo", OldRow["SortOrderNo"]},
                    {"IsFolder", 0},
                    {"IsFolderOpened", 0},
                    {"IsHidden", OldRow["IsHidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["IsDeleted"] ? 1 : 0},
                    {"HiddenTime", ConvertTime(OldRow["HiddenTime"])},
                    {"DeletedTime", ConvertTime(OldRow["DeletedTime"])}
                };
                InsertedRowId = this.Database.Insert("Category", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade Location Table
        //---------------------------------------------------------------------

        private void UpgradeLocation(Version priorVersion)
        {
            // Notify user
            SetStep("Categories");

            // Save old table in memory
            Table Location = new Table();
            switch (priorVersion.Major) {
                case 3: Location = this.Database.Select("select * from Location order by LocationId");
                    this.Database.Exec("drop table Location");
                    break;
            }

            // Create new table
            this.CreateTable("Location", CurrentSchemaVersion, false);

            // Migrate rows
            if (priorVersion.Major == 3)
                MigrateLocation3072(Location);
        }

        //---------------------------------------------------------------------

        private void MigrateLocation3072(Table location)
        {
            foreach (Row OldRow in location) {
                RowId = OldRow["LocationId"];
                Row NewRow = new Row() {
                    {"LocationId", OldRow["LocationId"]},
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"LocationGuid", OldRow["LocationGuid"]},
                    {"Name", OldRow["Name"]},
                    {"Description", OldRow["Description"]},
                    {"ParentId", null},
                    {"SortOrderNo", OldRow["SortOrderNo"]},
                    {"IsFolder", 0},
                    {"IsFolderOpened", 0},
                    {"IsHidden", OldRow["IsHidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["IsDeleted"] ? 1 : 0},
                    {"HiddenTime", ConvertTime(OldRow["HiddenTime"])},
                    {"DeletedTime", ConvertTime(OldRow["DeletedTime"])},
                    {"RefTimeZoneId", OldRow["RefTimeZoneId"]},
                };
                InsertedRowId = this.Database.Insert("Location", NewRow);
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
            Table Project = new Table();
            switch (priorVersion.Major) {
                case 2:
                    Project = this.Database.Select("select * from projects order by id");
                    this.Database.Exec("drop table projects");
                    break;
                case 3: Project = this.Database.Select("select * from Project order by ProjectId");
                    this.Database.Exec("drop table Project");
                    break;
            }

            // Create new table
            this.CreateTable("Project", CurrentSchemaVersion, false);

            // Migrate rows
            if (priorVersion.Major == 3)
                MigrateProject3072(Project);
            else if (priorVersion.Minor == 0)
                MigrateProject20(Project);
            else if (priorVersion.Minor == 1)
                MigrateProject21(Project);
            else
                MigrateProject22(Project);
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
                    {"ParentId", OldRow["parent_id"] == 0 ? null : OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null},
                    {"LastActivityId", null},
                    {"LastLocationId", null},
                    {"LastCategoryId", null},
                    {"ExternalProjectNo", null},
                    {"StartTime", null},
                    {"DueTime", null},
                    {"Estimate", null},
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
                    {"ParentId", OldRow["parent_id"] == 0 ? null : OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null},
                    {"LastActivityId", null},
                    {"LastLocationId", null},
                    {"LastCategoryId", null},
                    {"ExternalProjectNo", null},
                    {"StartTime", null},
                    {"DueTime", null},
                    {"Estimate", null},
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
                    {"ParentId", OldRow["parent_id"] == 0 ? null : OldRow["parent_id"]},
                    {"SortOrderNo", SortOrderNo++},
                    {"IsFolder", OldRow["is_folder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["is_folder"] ? 1 : 0},
                    {"IsHidden", OldRow["is_hidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["is_deleted"] ? 1 : 0},
                    {"HiddenTime", null},
                    {"DeletedTime", null},
                    {"LastActivityId", null},
                    {"LastLocationId", null},
                    {"LastCategoryId", null},
                    {"ExternalProjectNo", null},
                    {"StartTime", null},
                    {"DueTime", null},
                    {"Estimate", null},
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

        private void MigrateProject3072(Table project)
        {
            foreach (Row OldRow in project) {
                RowId = OldRow["ProjectId"];
                Row NewRow = new Row() {
                    {"ProjectId", OldRow["ProjectId"]},
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"ProjectGuid", OldRow["ProjectGuid"]},
                    {"Name", OldRow["Name"]},
                    {"Description", OldRow["Description"]},
                    {"ParentId", OldRow["ParentId"] == 0 ? null : OldRow["ParentId"]},
                    {"SortOrderNo", OldRow["SortOrderNo"]},
                    {"IsFolder", OldRow["IsFolder"] ? 1 : 0},
                    {"IsFolderOpened", OldRow["IsFolderOpened"] ? 1 : 0},
                    {"IsHidden", OldRow["IsHidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["IsDeleted"] ? 1 : 0},
                    {"HiddenTime", ConvertTime(OldRow["HiddenTime"])},
                    {"DeletedTime", ConvertTime(OldRow["DeletedTime"])},
                    {"LastActivityId", OldRow["LastActivityId"]},
                    {"LastLocationId", null},
                    {"LastCategoryId", null},
                    {"ExternalProjectNo", OldRow["ExternalProjectNo"]},
                    {"StartTime", null},
                    {"DueTime", null},
                    {"Estimate", null},
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

        private void UpgradeJournal(Version priorVersion)
        {
            // Notify user
            SetStep("Journal Entries");

            // Save old table in memory
            Table Journal = new Table();
            switch (priorVersion.Major) {
                case 2:
                    Journal = this.Database.Select("select * from timekeeper order by timestamp_s");
                    this.Database.Exec("drop table timekeeper");
                    break;
                case 3: Journal = this.Database.Select("select * from Journal order by JournalId");
                    this.Database.Exec("drop table Journal");
                    break;
            }

            // Create new table
            this.CreateTable("Journal", CurrentSchemaVersion, false);

            // Migrate rows
            if (priorVersion.Major == 3)
                MigrateJournal3072(Journal);
            else
                MigrateJournal2x(Journal);
        }

        //---------------------------------------------------------------------

        private void MigrateJournal3072(Table journal)
        {
            // Delta Bucket
            int CumulativeDrift = 0;

            // Migrate rows
            foreach (Row OldRow in journal) {
                RowId = OldRow["JournalId"];

                if (OldRow["IsLocked"] == null) {
                    OldRow["IsLocked"] = false;
                    Timekeeper.Info(String.Format("Conversion Note: row {0} had a null is_locked value. Assumed false and processing continued.", RowId));
                }

                if (OldRow["IsLocked"] == true) {
                    // Automatically unlock any locked rows
                    OldRow["StopTime"] = OldRow["StartTime"];
                    OldRow["Seconds"] = 0;
                    OldRow["IsLocked"] = false;
                    Timekeeper.Info(String.Format("Conversion Note: row {0} was locked. The row was safely unlocked and processing continued.", RowId));
                }

                if (OldRow["StopTime"] == null) {
                    if (OldRow["Seconds"] == null) {
                        OldRow["StopTime"] = OldRow["StartTime"];
                    } else {
                        int Seconds = (int)OldRow["Seconds"];
                        TimeSpan Elapsed = new System.TimeSpan(0, 0, Seconds);
                        OldRow["StopTime"] = OldRow["StartTime"].Add(Elapsed);
                    }
                    Timekeeper.Info(String.Format("Conversion Note: row {0} had no StopTime value. A value based on StartTime was calculated and used.", RowId));
                }

                // Due to various reasons, the value of timekeeper.seconds isn't always the
                // exact delta between timestamp_s and timestamp_e. For that reason, the file
                // upgrade path recalculates seconds, thus ensuring this value matches the
                // visible start/end times of the journal entry.
                DateTimeOffset StartTime = OldRow["StartTime"];
                DateTimeOffset StopTime = OldRow["StopTime"];
                TimeSpan Delta = StopTime.Subtract(StartTime);
                int DeltaSeconds = Convert.ToInt32(Delta.TotalSeconds);

                if (OldRow["Seconds"] != DeltaSeconds) {
                    CumulativeDrift += DeltaSeconds - OldRow["Seconds"];
                    string Message = String.Format("Row {0}: saved 'seconds' ({1}) does not equal recalculated value ({2})",
                            OldRow["JournalId"],
                            OldRow["Seconds"],
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
                    {"JournalId", OldRow["JournalId"]},
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"JournalGuid", OldRow["JournalGuid"]},
                    {"StartTime", ConvertTime(OldRow["StartTime"])},
                    {"StopTime", ConvertTime(OldRow["StopTime"])},
                    {"Seconds", DeltaSeconds},
                    {"Memo", OldRow["Memo"]},
                    {"ProjectId", OldRow["ProjectId"]},
                    {"ActivityId", OldRow["ActivityId"]},
                    {"LocationId", OldRow["LocationId"]},
                    {"CategoryId", OldRow["CategoryId"]},
                    {"IsLocked", OldRow["IsLocked"] ? 1 : 0},
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

            // How'd we do?
            Timekeeper.Info(String.Format("Total time drift: {0}", CumulativeDrift));
        }

        //---------------------------------------------------------------------

        private void MigrateJournal2x(Table journal)
        {
            // Delta Bucket
            int CumulativeDrift = 0;

            // Migrate rows
            foreach (Row OldRow in journal) {
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
                DateTimeOffset StartTime = OldRow["timestamp_s"];
                DateTimeOffset StopTime = OldRow["timestamp_e"];
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
                    {"StartTime", ConvertTime(OldRow["timestamp_s"])},
                    {"StopTime", ConvertTime(OldRow["timestamp_e"])},
                    {"Seconds", DeltaSeconds},
                    {"ProjectId", OldRow["project_id"]},
                    {"ActivityId", OldRow["task_id"]},
                    {"LocationId", 1},
                    {"CategoryId", 1},
                    {"IsLocked", OldRow["is_locked"] ? 1 : 0},
                };

                switch (UpgradeWizardOptions.MemoMergeTypeId) {
                    case 1: NewRow["Memo"] = OldRow["pre_log"] + "\n\n<hr class=\"memo-break-upgrade\" />\n\n" + OldRow["post_log"]; break;
                    case 2: NewRow["Memo"] = OldRow["pre_log"] + "\n\n" + OldRow["post_log"]; break;
                    case 3: NewRow["Memo"] = OldRow["post_log"]; break;
                    case 4: NewRow["Memo"] = OldRow["pre_log"]; break;
                    default: throw new Exception("Invalid MemoMergeTypeId Found: " + UpgradeWizardOptions.MemoMergeTypeId.ToString());
                }

                InsertedRowId = this.Database.Insert("Journal", NewRow);
                if (InsertedRowId == 0) {
                    throw new Exception("Insert failed");
                }

                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }

            // How'd we do?
            Timekeeper.Info(String.Format("Total time drift: {0}", CumulativeDrift));
        }

        //---------------------------------------------------------------------
        // Upgrade Todo Table
        //---------------------------------------------------------------------

        private void UpgradeTodo()
        {
            // Notify user
            SetStep("Todo");

            // Save old table in memory
            Table Todo = new Table();
            Todo = this.Database.Select("select * from Todo order by TodoId");
            this.Database.Exec("drop table Todo");

            // Create new table
            this.CreateTable("Todo", CurrentSchemaVersion, false);

            // Migrate rows
            foreach (Row OldRow in Todo) {
                RowId = OldRow["TodoId"];
                Row NewRow = new Row() {
                    {"TodoId", OldRow["TodoId"]},
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"Memo", OldRow["Memo"]},
                    {"ProjectId", OldRow["ProjectId"]},
                    {"RefTodoStatusId", OldRow["RefTodoStatusId"]},
                    {"IsHidden", OldRow["IsHidden"] ? 1 : 0},
                    {"IsDeleted", OldRow["IsDeleted"] ? 1 : 0},
                    {"HiddenTime", ConvertTime(OldRow["HiddenTime"])},
                    {"DeletedTime", ConvertTime(OldRow["DeletedTime"])},
                };
                InsertedRowId = this.Database.Insert("Todo", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade Reminder Table
        //---------------------------------------------------------------------

        private void UpgradeReminder()
        {
            // Notify user
            SetStep("Reminder");

            // Load old table
            Table Reminder = new Table();
            Reminder = this.Database.Select("select * from Reminder order by ReminderId");

            // Migrate rows
            foreach (Row OldRow in Reminder) {
                RowId = OldRow["ReminderId"];
                Row UpdatedRow = new Row() {
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                };
                UpdatedRowCount = this.Database.Update("Reminder", UpdatedRow, "ReminderId", RowId);
                if (UpdatedRowCount == 0) throw new Exception("Update failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade Schedule Table
        //---------------------------------------------------------------------

        private void UpgradeSchedule()
        {
            // Notify user
            SetStep("Schedule");

            // Load old table
            Table Schedule = new Table();
            Schedule = this.Database.Select("select * from Schedule order by ScheduleId");

            // Migrate rows
            foreach (Row OldRow in Schedule) {
                RowId = OldRow["ScheduleId"];
                Row UpdatedRow = new Row() {
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"StopAfterTime", ConvertTime(OldRow["StopAfterTime"])},
                };
                UpdatedRowCount = this.Database.Update("Schedule", UpdatedRow, "ScheduleId", RowId);
                if (UpdatedRowCount == 0) throw new Exception("Update failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade EventGroup Table
        //---------------------------------------------------------------------

        private void UpgradeEventGroup()
        {
            // Notify user
            SetStep("Event Group");

            // Load old table
            Table EventGroup = new Table();
            EventGroup = this.Database.Select("select * from EventGroup order by EventGroupId");

            // Migrate rows
            foreach (Row OldRow in EventGroup) {
                RowId = OldRow["EventGroupId"];
                Row UpdatedRow = new Row() {
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                };
                UpdatedRowCount = this.Database.Update("EventGroup", UpdatedRow, "EventGroupId", RowId);
                if (UpdatedRowCount == 0) throw new Exception("Update failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade Event Table
        //---------------------------------------------------------------------

        private void UpgradeEvent()
        {
            // Notify user
            SetStep("Events");

            // Load old table
            Table Event = new Table();
            Event = this.Database.Select("select * from Event order by EventId");

            // Migrate rows
            foreach (Row OldRow in Event) {
                RowId = OldRow["EventId"];
                Row UpdatedRow = new Row() {
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"NextOccurrenceTime", ConvertTime(OldRow["NextOccurrenceTime"])},
                    {"HiddenTime", ConvertTime(OldRow["HiddenTime"])},
                    {"DeletedTime", ConvertTime(OldRow["DeletedTime"])},
                };
                UpdatedRowCount = this.Database.Update("Event", UpdatedRow, "EventId", RowId);
                if (UpdatedRowCount == 0) throw new Exception("Update failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade Options Table
        //---------------------------------------------------------------------

        private void UpgradeOptions()
        {
            // Notify user
            SetStep("Options");

            // Just do a clean rebuild
            // NOTE: Used only by the 3072 special upgrade.
            // FIXME: not suitable for a true upgrade process

            // Drop old table
            this.Database.Exec("drop table Options");

            // Create new table
            CreateTable("Options", CurrentSchemaVersion, true);
        }

        //---------------------------------------------------------------------
        // Upgrade FilterOptions Table
        //---------------------------------------------------------------------

        private void UpgradeFilterOptions()
        {
            // Notify user
            SetStep("Filter Options");

            // Load old table
            Table FilterOptions = new Table();
            FilterOptions = this.Database.Select("select * from FilterOptions order by FilterOptionsId");

            // Migrate rows
            foreach (Row OldRow in FilterOptions) {
                RowId = OldRow["FilterOptionsId"];
                Row UpdatedRow = new Row() {
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"FromTime", ConvertTime(OldRow["FromTime"])},
                    {"ToTime", ConvertTime(OldRow["ToTime"])},
                };
                UpdatedRowCount = this.Database.Update("FilterOptions", UpdatedRow, "FilterOptionsId", RowId);
                if (UpdatedRowCount == 0) throw new Exception("Update failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade Notebook Table
        //---------------------------------------------------------------------

        private void UpgradeNotebook(Version priorVersion)
        {
            // Notify user
            SetStep("Notebook Entries");

            Table Notebook = new Table();
            switch (priorVersion.Major) {
                case 2:
                    // Save old table in memory
                    Notebook = this.Database.Select("select * from journal order by id");
                    // Drop old table
                    this.Database.Exec("drop table journal");
                    break;
                case 3:
                    // Save old table in memory
                    Notebook = this.Database.Select("select * from Notebook order by NotebookId");
                    // Drop old table
                    this.Database.Exec("drop table Notebook");
                    break;
            }

            // Create new table
            this.CreateTable("Notebook", CurrentSchemaVersion, false);

            // Migrate rows
            if (priorVersion.Major == 3)
                MigrateNotebook3072(Notebook);
            else
                MigrateNotebook2x(Notebook);
        }

        //---------------------------------------------------------------------

        private void MigrateNotebook2x(Table Notebook)
        {
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
                    {"ProjectId", null},
                    {"ActivityId", null},
                    {"LocationId", null},
                    {"CategoryId", null},
                };
                InsertedRowId = this.Database.Insert("Notebook", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------

        private void MigrateNotebook3072(Table Notebook)
        {
            // Migrate rows
            foreach (Row OldRow in Notebook) {
                RowId = OldRow["NotebookId"];
                Row NewRow = new Row() {
                    {"NotebookId", OldRow["NotebookId"]},
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                    {"NotebookGuid", OldRow["NotebookGuid"]},
                    {"EntryTime", ConvertTime(OldRow["EntryTime"])},
                    {"Memo", OldRow["Memo"]},
                    {"ProjectId", null},
                    {"ActivityId", null},
                    {"LocationId", OldRow["LocationId"]},
                    {"CategoryId", OldRow["CategoryId"]},
                };
                InsertedRowId = this.Database.Insert("Notebook", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade GridView Table
        //---------------------------------------------------------------------

        private void UpgradeGridView(Version priorVersion)
        {
            // Notify user
            SetStep("Grid Options");

            Table GridView = new Table();
            switch (priorVersion.Major) {
                case 2:
                    // Save old table in memory
                    GridView = this.Database.Select("select * from grid_views order by id");

                    // Create new tables
                    this.CreateTable("FilterOptions", CurrentSchemaVersion, false);
                    this.CreateTable("GridView", CurrentSchemaVersion, false);

                    // Drop old table
                    this.Database.Exec("drop table grid_views");
                    break;
                case 3:
                    // Save old table in memory
                    GridView = this.Database.Select("select * from GridView order by GridViewId");
                    break;
            }

            // Migrate rows
            if (priorVersion.Major == 3)
                MigrateGridView3072(GridView);
            else
                MigrateGridView2x(GridView);
        }

        //---------------------------------------------------------------------

        private void MigrateGridView2x(Table GridView)
        {
            // Migrate rows
            foreach (Row OldRow in GridView) {
                RowId = OldRow["id"];

                Row NewFilterOptionsRow = new Row() {
                    {"CreateTime", Timekeeper.DateForDatabase()},
                    {"ModifyTime", Timekeeper.DateForDatabase()},
                    {"FilterOptionsType", 1},
                    {"RefDatePresetId", OldRow["date_preset"]},
                    {"FromTime", OldRow["start_date"]},
                    {"ToTime", OldRow["end_date"]},
                    {"MemoOperator", null},
                    {"MemoValue", null},
                    {"ProjectList", OldRow["project_list"]},
                    {"ActivityList", OldRow["task_list"]},
                    {"LocationList", null},
                    {"CategoryList", null},
                    {"DurationOperator", null},
                    {"DurationAmount", null},
                    {"DurationUnit", null},
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
                    {"RefDimensionId", OldRow["data_from"] == 0 ? 1 : OldRow["data_from"]},
                    {"RefGroupById", OldRow["group_by"] == 0 ? 1 : OldRow["group_by"]},
                    {"RefTimeDisplayId", null},
                };
                InsertedRowId = this.Database.Insert("GridView", NewRow);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
                this.Progress.Value++;
            }
        }

        //---------------------------------------------------------------------

        private void MigrateGridView3072(Table GridView)
        {
            // Migrate rows
            foreach (Row OldRow in GridView) {
                RowId = OldRow["GridViewId"];
                Row UpdatedRow = new Row() {
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                };
                UpdatedRowCount = this.Database.Update("GridView", UpdatedRow, "GridViewId", RowId);
                if (UpdatedRowCount == 0) throw new Exception("Update failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade FindView Table
        //---------------------------------------------------------------------

        private void UpgradeFindView()
        {
            // Notify user
            SetStep("Find View");

            // Load old table
            Table FindView = new Table();
            FindView = this.Database.Select("select * from FindView order by FindViewId");

            // Migrate rows
            foreach (Row OldRow in FindView) {
                RowId = OldRow["FindViewId"];
                Row UpdatedRow = new Row() {
                    {"CreateTime", ConvertTime(OldRow["CreateTime"])},
                    {"ModifyTime", ConvertTime(OldRow["ModifyTime"])},
                };
                UpdatedRowCount = this.Database.Update("FindView", UpdatedRow, "FindViewId", RowId);
                if (UpdatedRowCount == 0) throw new Exception("Update failed");
                this.Progress.Value++;

                if (RowId % 10 == 0) {
                    Application.DoEvents();
                }
            }
        }

        //---------------------------------------------------------------------
        // Upgrade ReportView Table
        //---------------------------------------------------------------------

        private void UpgradeReportView()
        {
            // Notify user
            SetStep("Report View");

            // Just do a clean rebuild
            // FIXME: not suitable for a true upgrade process

            // Drop old table
            this.Database.Exec("drop table ReportView");

            // Create new table
            CreateTable("ReportView", CurrentSchemaVersion, false);
        }

        //---------------------------------------------------------------------
        // General Helpers
        //---------------------------------------------------------------------

        private string ConvertTime(object time)
        {
            if (time == null)
                return Timekeeper.NullableDateForDatabase(null);
            else
                return "UNEXPECTED CONDITION";
        }

        //---------------------------------------------------------------------

        private string ConvertTime(DateTimeOffset time)
        {
            return Timekeeper.DateForDatabase(time);
        }

        //---------------------------------------------------------------------

        // The following was a bit of work. Leaving it around for the time (if
        // ever) that I come back to the UTC thing. For now, it's all staying
        // local time so the above replacement will work.

        private string ConvertTime_FOR_UTC_CURRENTLY_NOT_USED(DateTimeOffset time)
        {
            /*
            Given a current time zone of US Central Time:

            Convert:  2013-01-01 20:00:00
            To.....:  2013-01-02 02:00:00-06:00

            Convert:  2013-07-01 20:00:00
            To.....:  2013-07-02 01:00:00-05:00

            Keep in mind, this takes the user-specified time zone
            into account, and not the time zone of the current
            running process.
            */

            // Get time into standard string format
            string ConvertedTime = Timekeeper.DateForDatabase(time);

            // Calculate the timezone & dst (if any) offset
            TimeSpan Offset = UpgradeWizardOptions.LocationTimeZoneInfo.BaseUtcOffset;
            int OffsetHours = Offset.Hours;
            TimeZoneInfo TimeZoneInfo = UpgradeWizardOptions.LocationTimeZoneInfo;

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

            // Start with the number of rows in a 3.0.x meta table.
            Count = 5; 

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
