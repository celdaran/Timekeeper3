using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Database
    {
        private DBI Data;

        private const string SCHEMA_VERSION = "3.0.0.0";

        public const int ERROR_UNSPECIFIED = -1;
        public const int ERROR_NEWER_VERSION_DETECTED = -2;
        public const int ERROR_NOT_TKDB = -3;
        public const int ERROR_EMPTY_DB = -4;
        public const int ERROR_REQUIRES_UPGRADE = -5;
        public const int ERROR_INVALID_METADATA = -6;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Database(DBI data)
        {
            this.Data = data;
        }

        //---------------------------------------------------------------------
        // Creation & Compliance
        //---------------------------------------------------------------------

        public bool Create(Version version, bool populate)
        {
            try {
                CreateMeta(version, populate);
                CreateActivity(version, populate);
                CreateProject(version, populate);
                CreateTimekeeper(version);
                CreateJournal(version);
                CreateUserGridView(version);
                CreateUserLocation(version);
                CreateUserTag(version);
                CreateSystemDatePreset(version, populate);
                CreateSystemGridGroupBy(version, populate);
                CreateSystemGridTimeDisplay(version, populate);
            }
            catch {
                return false;
            }

            return true;
        }

        //---------------------------------------------------------------------

        public int Check()
        {
            try {
                // Quick sanity check on currently-opened database. If these
                // two functions work, we have a valid SQLite file.
                // FIXME: this should be DBI's responsibility, I'm not sure
                // how we're getting this far opening, say, a Word document.
                Data.Begin();
                Data.Rollback();

                // Declarations
                Version CurrentSchemaVersion = new Version(SCHEMA_VERSION);
                Version FoundSchemaVersion;
                Row row;

                // are there any tables at all?
                if (!Data.TablesExist()) {
                    // If we've opened the database and successfully queried the master table
                    // but have not found any rows, then it's a valid, empty SQLite file and
                    // we should allow the user to opt for converting it to a TK database.
                    return ERROR_EMPTY_DB;
                }

                // does the timekeeper table exist?
                if (!Data.TableExists("timekeeper")) {
                    // If no timekeeeper table, we have a valid SQLite file, but not a TK database.
                    // Let's bail before we destroy someone else's database.
                    return ERROR_NOT_TKDB;
                }

                // does the meta table exist?
                if (!Data.TableExists("meta")) {
                    // If no meta table, this is probably an old 2.0.x beta version.
                    return ERROR_REQUIRES_UPGRADE;
                } else {
                    // If there is a meta table, do an integrity check.
                    // We should have three rows.
                    /* --- not sold on this idea just yet
                    Table rows = Data.Select("select * from meta");
                    if (rows.Count != 3) {
                        return ERROR_INVALID_METADATA;
                    }
                    */

                    // If the table exists, attempt to read the schema version.
                    row = Data.SelectRow("select * from meta where key = 'version'");
                    if (row["value"] == null) {
                        // If version not found, we're in trouble. The user
                        // might have to upgrade or repair the database.
                        return ERROR_INVALID_METADATA;
                    }

                    // If we found a schema version, check it against the
                    // expected schema version and disallow opening databases 
                    // with higher schema versions.
                    FoundSchemaVersion = new Version(row["value"]);
                    if (FoundSchemaVersion > CurrentSchemaVersion) {
                        return ERROR_NEWER_VERSION_DETECTED;
                    }

                    // Also disallow opening lower versions, but return an error
                    // allowing the application to prompt for and convert. It's
                    // a quite different case from above, but does illustrate the
                    // point that from TK3 forward, you cannot leave Check()
                    // with anything but a valid, current schema found.
                    if (CurrentSchemaVersion > FoundSchemaVersion) {
                        return ERROR_REQUIRES_UPGRADE;
                    }
                }
            }
            catch { //(Exception e) {
                //Common.Warn(e.Message);
                return ERROR_UNSPECIFIED;
            }

            // Success
            return 0;
        }

        //---------------------------------------------------------------------

        public Row Info()
        {
            // stub in row to return
            Row row = new Row();

            try
            {
                // grab all meta rows
                Table rows = Data.Select("select key, value from meta order by key");

                // grab a few handy objects
                Tasks tasks = new Tasks(Data, "");
                Projects projects = new Projects(Data, "");
                Journal journal = new Journal(Data);
                Entry log = new Entry(Data);

                // convert meta rows to rows (note order by above)
                row.Add("created", rows[0]["value"]);
                row.Add("id", rows[1]["value"]);
                row.Add("version", rows[2]["value"]);

                // now grab individual attributes
                row.Add("filename", Data.DataFile);
                row.Add("filesize", Data.DataFileSize);
                row.Add("taskcount", tasks.count());
                row.Add("projectcount", projects.count());
                row.Add("journalcount", journal.count());
                row.Add("logcount", log.Count());
                row.Add("totalseconds", Timekeeper.FormatSeconds(log.TotalSeconds()));
            }
            catch
            {
                // Return empty Data
                
                // wipe out any partially created row from above
                row = new Row();

                // convert meta rows to rows
                row.Add("created", "");
                row.Add("version", "");
                row.Add("id", "");

                // now grab individual attributes
                row.Add("filename", "No file opened");
                row.Add("filesize", 0);
                row.Add("taskcount", 0);
                row.Add("projectcount", 0);
                row.Add("journalcount", 0);
                row.Add("logcount", 0);
                row.Add("totalseconds", 0);
            }

            return row;
        }

        //---------------------------------------------------------------------
        // Table Create Methods
        //---------------------------------------------------------------------

        private void CreateMeta(Version version, bool populate)
        {
            string Query = null;
            Row Row;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2) {
                    Query = @"
                        CREATE TABLE meta (
                            key string,
                            value string,
                            timestamp_c datetime)";
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE Meta (
                            MetaId      INTEGER PRIMARY KEY,
                            CreateTime  DATETIME,
                            ModifyTime  DATETIME,
                            Key         TEXT,
                            Value       TEXT)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            if (!populate) {
                return;
            }

            //----------------------------------------
            // Insert rows
            //----------------------------------------

            string VersionString = 
                version.Major.ToString() + "." + 
                version.Minor.ToString() + "." + 
                version.Build.ToString() + "." +
                version.Revision.ToString();

            // note: released versions:
            // tk2.0 = 2.0.0.0 = Apr 2008
            // tk2.1 = 2.1.0.0 = Jun 2010
            // tk2.2 = 2.2.0.4 = May 2011
            // tk2.3 = 2.2.0.4 = Oct 2012
            // tk3.0 = 3.0.0.0 = ??? 2013

            try {
                if (version.Major == 2 && version.Minor == 0) {
                    // Only one row in 2.0
                    Row = new Row() {
                        {"key", "version"},
                        {"value", VersionString},
                        {"timestamp_c", Common.Now()}
                    };
                    Data.Insert("meta", Row);
                }

                if (version.Major == 2 && version.Minor > 0) {
                    // Three rows for 2.x
                    Row = new Row() {
                        {"key", "created"},
                        {"value", Common.Now()},
                        {"timestamp_c", Common.Now()}
                    };
                    Data.Insert("meta", Row);

                    Row = new Row() {
                        {"key", "version"},
                        {"value", VersionString},
                        {"timestamp_c", Common.Now()}
                    };
                    Data.Insert("meta", Row);

                    Row = new Row() {
                        {"key", "id"},
                        {"value", UUID.Get()},
                        {"timestamp_c", Common.Now()}
                    };
                    Data.Insert("meta", Row);
                }

                if (version.Major == 3 && version.Minor == 0) {
                    // Still three rows
                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", null},
                        {"Key", "created"},
                        {"Value", Common.Now()}
                    };
                    Data.Insert("Meta", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Key", "version"},
                        {"Value", SCHEMA_VERSION},
                    };
                    Data.Insert("Meta", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", null},
                        {"Key", "id"},
                        {"Value", UUID.Get()}
                    };
                    Data.Insert("Meta", Row);
                }

            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            return;
        }

        //---------------------------------------------------------------------

        private void CreateActivity(Version version, bool populate)
        {
            string Query = null;
            Row Row;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE tasks (
                            id integer primary key,
                            name string,
                            descr string,
                            parent_id integer,
                            is_folder bool,
                            is_deleted bool,
                            timestamp_c datetime)";
                }

                if (version.Major == 2 && version.Minor == 1) {
                    Query = @"
                        CREATE TABLE tasks (
                            id integer primary key,
                            name string,
                            descr string,
                            parent_id integer,
                            is_folder bool,
                            is_deleted bool,
                            project_id__last int,
                            timestamp_c datetime,
                            timestamp_m datetime)";
                }

                if (version.Major == 2 && version.Minor >= 2) {
                    // basically same as above, but is_hidden moved
                    Query = @"
                        CREATE TABLE tasks (
                            id integer primary key,
                            name string,
                            descr string,
                            parent_id integer,
                            is_folder boolean,
                            is_hidden boolean,
                            is_deleted boolean,
                            project_id__last int,
                            timestamp_c datetime,
                            timestamp_m datetime)";
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE Activity (
                            ActivityId      INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime      DATETIME,
                            ModifyTime      DATETIME,
                            ActivityGuid    TEXT,
                            Name            TEXT,
                            Description     TEXT,
                            ParentId        INTEGER,
                            SortOrderNo     INTEGER,
                            LastProjectId   INTEGER,
                            IsFolder        BOOLEAN,
                            IsHidden        BOOLEAN,
                            IsDeleted       BOOLEAN,
                            HiddenTime      DATETIME,
                            DeleteTime      DATETIME)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            if (!populate) {
                return;
            }

            //----------------------------------------
            // Insert rows
            //----------------------------------------

            try {
                if (version.Major == 2 && version.Minor == 0) {
                    Row = new Row() {
                        {"name", "Default Task"},
                        {"descr", "Right click this task and select Edit to change the name or this description"},
                        {"parent_id", 0},
                        {"is_folder", 0},
                        {"is_deleted", 0},
                        {"timestamp_c", Common.Now()}
                    };
                    Data.Insert("tasks", Row);
                }

                if (version.Major == 2 && version.Minor == 1) {
                    Row = new Row() {
                        {"name", "Default Task"},
                        {"descr", "Right click this task and select Edit to change the name or this description"},
                        {"parent_id", 0},
                        {"is_folder", 0},
                        {"is_deleted", 0},
                        {"project_id__last", 0},
                        {"timestamp_c", Common.Now()},
                        {"timestamp_m", Common.Now()}
                    };
                    Data.Insert("tasks", Row);
                }

                if (version.Major == 2 && version.Minor >= 2) {
                    Row = new Row() {
                        {"name", "Default Task"},
                        {"descr", "Right click this task and select Edit to change the name or this description"},
                        {"parent_id", 0},
                        {"is_folder", 0},
                        {"is_hidden", 0},
                        {"is_deleted", 0},
                        {"project_id__last", 0},
                        {"timestamp_c", Common.Now()},
                        {"timestamp_m", Common.Now()}
                    };
                    Data.Insert("tasks", Row);
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"ActivityGuid", UUID.Get()},
                        {"Name", "Default Activity"},
                        {"Description", "Right click and select Edit to change the name or this description"},
                        {"ParentId", 0},
                        {"SortOrderNo", 0},
                        {"LastProjectId", 0},
                        {"IsFolder", 0},
                        {"IsHidden", 0},
                        {"IsDeleted", 0},
                        {"HiddenTime", null},
                        {"DeleteTime", null}
                    };
                    Data.Insert("Activity", Row);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            return;
        }

        //---------------------------------------------------------------------

        private void CreateProject(Version version, bool populate)
        {
            string Query = null;
            Row Row;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE projects (
                            id integer primary key,
                            name string,
                            descr string,
                            parent_id integer,
                            is_folder bool,
                            is_deleted bool,
                            timestamp_c datetime)";
                }

                if (version.Major == 2 && version.Minor == 1) {
                    Query = @"
                        CREATE TABLE projects (
                            id integer primary key,
                            name string,
                            descr string,
                            parent_id integer,
                            is_folder bool,
                            is_deleted bool,
                            timestamp_c datetime,
                            timestamp_m datetime)";
                }

                if (version.Major == 2 && version.Minor >= 2) {
                    Query = @"
                        CREATE TABLE projects (
                            id integer primary key,
                            name string,
                            descr string,
                            parent_id integer,
                            is_folder boolean,
                            is_hidden boolean,
                            is_deleted boolean,
                            timestamp_c datetime,
                            timestamp_m datetime)";
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE Project (
                            ProjectId       INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime      DATETIME,
                            ModifyTime      DATETIME,
                            ProjectGuid     TEXT,
                            Name            TEXT,
                            Description     TEXT,
                            ParentId        INTEGER,
                            SortOrderNo     INTEGER,
                            LastActivityId  INTEGER,
                            IsFolder        BOOLEAN,
                            IsHidden        BOOLEAN,
                            IsDeleted       BOOLEAN,
                            HiddenTime      DATETIME,
                            DeleteTime      DATETIME)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            if (!populate) {
                return;
            }

            //----------------------------------------
            // Insert rows
            //----------------------------------------

            try {
                if (version.Major == 2 && version.Minor == 0) {
                    Row = new Row() {
                        {"name", "Default Project"},
                        {"descr", "Right click this project and select Edit to change the name or this description"},
                        {"parent_id", 0},
                        {"is_folder", 0},
                        {"is_deleted", 0},
                        {"timestamp_c", Common.Now()}
                    };
                    Data.Insert("projects", Row);
                }

                if (version.Major == 2 && version.Minor == 1) {
                    Row = new Row() {
                        {"name", "Default Project"},
                        {"descr", "Right click this project and select Edit to change the name or this description"},
                        {"parent_id", 0},
                        {"is_folder", 0},
                        {"is_deleted", 0},
                        {"timestamp_c", Common.Now()},
                        {"timestamp_m", Common.Now()}
                    };
                    Data.Insert("projects", Row);
                }

                if (version.Major == 2 && version.Minor >= 2) {
                    Row = new Row() {
                        {"name", "Default Project"},
                        {"descr", "Right click this project and select Edit to change the name or this description"},
                        {"parent_id", 0},
                        {"is_folder", 0},
                        {"is_hidden", 0},
                        {"is_deleted", 0},
                        {"timestamp_c", Common.Now()},
                        {"timestamp_m", Common.Now()}
                    };
                    Data.Insert("projects", Row);
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"ProjectGuid", UUID.Get()},
                        {"Name", "Default Project"},
                        {"Description", "Right click and select Edit to change the name or this description"},
                        {"ParentId", 0},
                        {"SortOrderNo", 0},
                        {"LastActivityId", 0},
                        {"IsFolder", 0},
                        {"IsHidden", 0},
                        {"IsDeleted", 0},
                        {"HiddenTime", null},
                        {"DeleteTime", null}
                    };
                    Data.Insert("Project", Row);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            return;
        }

        //---------------------------------------------------------------------

        private void CreateTimekeeper(Version version)
        {
            string Query = null;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2) {
                    Query = @"
                        CREATE TABLE timekeeper (
                            id integer primary key,
                            task_id integer,
                            project_id integer,
                            timestamp_s datetime,
                            timestamp_e datetime,
                            seconds integer,
                            pre_log varchar,
                            post_log varchar,
                            is_locked bool)";
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE Timekeeper (
                            TimekeeperId    INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime      DATETIME,
                            ModifyTime      DATETIME,
                            TimekeeperGuid  TEXT,
                            ActivityId      INTEGER,
                            ProjectId       INTEGER,
                            StartTime       DATETIME,
                            StopTime        DATETIME,
                            Seconds         INTEGER,
                            Memo            TEXT,
                            IsLocked        BOOLEAN,
                            LocationId      INTEGER,
                            TagId           INTEGER)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            return;
        }

        //---------------------------------------------------------------------

        private void CreateJournal(Version version)
        {
            string Query = null;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2 && version.Minor == 0) {
                    // Not present in 2.0
                    Query = null;
                }

                if (version.Major == 2 && version.Minor > 0) {
                    Query = @"
                        CREATE TABLE journal (
                            id integer primary key,
                            timestamp_entry datetime,
                            description varchar,
                            timestamp_c datetime,
                            timestamp_m datetime)";
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE Journal (
                            JournalId       INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime      DATETIME,
                            ModifyTime      DATETIME,
                            JournalGuid     TEXT,
                            EntryTime       DATETIME,
                            Memo            TEXT)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }
            return;
        }

        //---------------------------------------------------------------------

        private void CreateUserGridView(Version version)
        {
            string Query = null;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2 && version.Minor == 0) {
                    // Not present in 2.0
                    Query = null;
                }

                if (version.Major == 2 && version.Minor > 0) {
                    Query = @"
                        CREATE TABLE grid_views (
                            id integer primary key,
                            name varchar,
                            description varchar,
                            sort_index int,
                            task_list varchar,
                            project_list varchar,
                            date_preset int,
                            start_date varchar,
                            end_date varchar,
                            group_by int,
                            data_from int,
                            hide_empty_rows int,
                            timestamp_c datetime,
                            timestamp_m datetime,
                            end_date_type int)";
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE UserGridView (
                            UserGridViewId              INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime                  DATETIME,
                            ModifyTime                  DATETIME,
                            Name                        TEXT,
                            Description                 TEXT,
                            SortOrderNo                 INTEGER,
                            ActivityFilter              TEXT,
                            ProjectFilter               TEXT,
                            SystemDatePresetId          INTEGER,
                            FromDate                    DATETIME,
                            ToDate                      DATETIME,
                            EndDateType                 INTEGER,
                            ItemTypeId                  INTEGER,
                            SystemGridGroupById         INTEGER,
                            SystemGridTimeDisplayId     INTEGER)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }
            return;
        }

        //---------------------------------------------------------------------

        private void CreateUserLocation(Version version)
        {
            string Query = null;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2) {
                    // Not present in 2.x
                    Query = null;
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE UserLocation (
                            UserLocationId              INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime                  DATETIME,
                            ModifyTime                  DATETIME,
                            Name                        TEXT,
                            Description                 TEXT
                        )";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }
            return;
        }

        //---------------------------------------------------------------------

        private void CreateUserTag(Version version)
        {
            string Query = null;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2) {
                    // Not present in 2.x
                    Query = null;
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE UserTag (
                            UserTagId               INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime              DATETIME,
                            ModifyTime              DATETIME,
                            Name                    TEXT,
                            Description             TEXT
                        )";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }
            return;
        }

        //---------------------------------------------------------------------

        private void CreateSystemDatePreset(Version version, bool populate)
        {
            string Query = null;
            Row Row;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2) {
                    // Not present in 2.x
                    Query = null;
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE SystemDatePreset (
                            SystemDatePresetId          INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime                  DATETIME,
                            ModifyTime                  DATETIME,
                            Name                        TEXT,
                            Description                 TEXT)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            //----------------------------------------
            // Insert rows
            //----------------------------------------

            try {
                if (version.Major == 3 && version.Minor == 0) {
                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Today"},
                        {"Description", "Entries matching today's date."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Yesterday"},
                        {"Description", "Entries (if any) matching yesterday's date."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Previous Day"},
                        {"Description", "Most recent entries prior to today's date. For example, on a Monday this is most likely entries for Friday."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "This Week"},
                        {"Description", "Entries between the prior Monday and today."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Last Week"},
                        {"Description", "Entries between the week before last Monday and last Sunday."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "This Month"},
                        {"Description", "Entries since the first of this month."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Last Month"},
                        {"Description", "Entries for last month."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "This Year"},
                        {"Description", "Entries since January first."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Last Year"},
                        {"Description", "Entries for last year."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "All"},
                        {"Description", "All entries ever logged."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Custom"},
                        {"Description", "User-specified date range."}
                    };
                    Data.Insert("SystemDatePreset", Row);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            } 
            
            return;
        }

        //---------------------------------------------------------------------

        private void CreateSystemGridGroupBy(Version version, bool populate)
        {
            string Query = null;
            Row Row;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2) {
                    // Not present in 2.x
                    Query = null;
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE SystemGridGroupBy (
                            SystemGridGroupById         INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime                  DATETIME,
                            ModifyTime                  DATETIME,
                            Name                        TEXT,
                            Description                 TEXT)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            //----------------------------------------
            // Insert rows
            //----------------------------------------

            try {
                if (version.Major == 3 && version.Minor == 0) {
                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Day"},
                        {"Description", "Group entries by day."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Week"},
                        {"Description", "Group entries by week."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Month"},
                        {"Description", "Group entries by month."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Year"},
                        {"Description", "Group entries by year."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "No Grouping"},
                        {"Description", "Do not group entries. Show results as a single sum."}
                    };
                    Data.Insert("SystemDatePreset", Row);


                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            return;
        }

        //---------------------------------------------------------------------

        private void CreateSystemGridTimeDisplay(Version version, bool populate)
        {
            string Query = null;
            Row Row;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            try {
                if (version.Major == 2) {
                    // Not present in 2.x
                    Query = null;
                }

                if (version.Major == 3 && version.Minor == 0) {
                    Query = @"
                        CREATE TABLE SystemGridTimeDisplay (
                            SystemGridTimeDisplayId     INTEGER PRIMARY KEY AUTOINCREMENT,
                            CreateTime                  DATETIME,
                            ModifyTime                  DATETIME,
                            Name                        TEXT,
                            Description                 TEXT)";
                }

                if (Query != null) {
                    Data.Exec(Query);
                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            //----------------------------------------
            // Insert rows
            //----------------------------------------

            try {
                if (version.Major == 3 && version.Minor == 0) {
                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "hh:mm:ss"},
                        {"Description", "Display times in hh:mm:ss format."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Hours"},
                        {"Description", "Display times as fractional number of hours."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Minutes"},
                        {"Description", "Display times as whole minutes."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                    Row = new Row() {
                        {"CreateTime", Common.Now()},
                        {"ModifyTime", Common.Now()},
                        {"Name", "Seconds"},
                        {"Description", "Display times as whole seconds."}
                    };
                    Data.Insert("SystemDatePreset", Row);

                }
            }
            catch {
                // FIXME: log something, then re-throw the error to the caller
                throw;
            }

            return;
        }

        //---------------------------------------------------------------------

    }

}