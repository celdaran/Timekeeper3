using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper
{
    class Database
    {
        DBI data;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Database(DBI data)
        {
            this.data = data;
        }

        //---------------------------------------------------------------------
        // Creation & Compliance
        //---------------------------------------------------------------------

        public void create()
        {
            _createMeta();
            _createTasks();
            _createProjects();
            _createTimekeeper();
            _createViews();
            _createJournal();
        }

        //---------------------------------------------------------------------

        public int check()
        {
            try {
                // Begin a transaction
                data.Begin();

                // Declarations
                Version app_version = new Version(Timekeeper.VERSION);
                Version db_version;
                Row row;

                // are there any tables at all?
                if (!data.TablesExist()) {
                    // If we've opened the database and successfully queried the master table
                    // but have not found any rows, then it's a valid, empty SQLite file and
                    // we should allow the user to opt for converting it to a TK database.
                    return -4;
                }

                // does the timekeeper table exist?
                if (!data.TableExists("timekeeper")) {
                    // if no timekeeeper table, we have a valid SQLite file, but not a TK database.
                    // bail before we destroy this database
                    return -3;
                    // if we do have a timekeeper table, proceed with caution
                }

                // does the meta table exist?
                if (!data.TableExists("meta")) {
                    // if no meta table, this is probably an old 2.0.x beta version.
                    // so create the meta table and continue
                    _createMeta();
                } else {
                    // if there is a meta table, check the version and disallow opening higher version dbs
                    row = data.SelectRow("select * from meta where key = 'version'");
                    db_version = new Version(row["value"]);
                    if (db_version > app_version) {
                        return -2;
                    }

                    // And do an integrity check. We should have three rows.
                    Table rows = data.Select("select * from meta");
                    if (rows.Count == 3) {
                        // Everything is okay.
                    } else {
                        // die a horrible death
                    }
                }

                // does the tk table have a locked column?
                row = data.SelectRow("select * from timekeeper where id = 1");
                if (!row.ContainsKey("is_locked")) {
                    // Also from an old TK 2.0.x version
                    string alterTable = @"alter table timekeeper add column is_locked bool";
                    data.Exec(alterTable);
                }

                // does the tasks table have a timestamp_m column?
                row = data.SelectRow("select * from tasks");
                if (!row.ContainsKey("timestamp_m")) {
                    // File is pre TK 2.1
                    string alterTable = @"alter table tasks add column timestamp_m datetime";
                    data.Exec(alterTable);
                    string updateTable = @"update tasks set timestamp_m = timestamp_c";
                    data.Exec(updateTable);
                }

                // does the tasks table have a project_id__last column?
                row = data.SelectRow("select * from tasks");
                if (!row.ContainsKey("project_id__last")) {
                    // File is pre TK 2.1
                    string alterTable = @"alter table tasks add column project_id__last int";
                    data.Exec(alterTable);
                }

                // does the projects table have a timestamp_m column?
                row = data.SelectRow("select * from projects");
                if (!row.ContainsKey("timestamp_m")) {
                    // File is pre TK 2.1
                    string alterTable = @"alter table projects add column timestamp_m datetime";
                    data.Exec(alterTable);
                    string updateTable = @"update projects set timestamp_m = timestamp_c";
                    data.Exec(updateTable);
                }

                // does the grid_views table exist
                row = data.SelectRow("select * from sqlite_master where type='table' and name = 'grid_views'");
                if (row["name"] == null) {
                    // Added in 2.1
                    _createViews();
                }

                // does the grid_views.end_date_type column exist?
                row = data.SelectRow("select * from grid_views");
                if (!row.ContainsKey("end_date_type")) {
                    // Added in 2.1
                    string alterTable = "alter table grid_views add column end_date_type int";
                    data.Exec(alterTable);
                }

                // does the journal table exist
                row = data.SelectRow("select * from sqlite_master where type='table' and name = 'journal'");
                if (row["name"] == null) {
                    // Added in 2.1
                    _createJournal();
                }

                // update version number, if necessary
                row = data.SelectRow("select value from meta where key = 'version'");
                /*
                 * FIXME: do NOT do this unless there's a reason to.
                 * Don't blindly update the version number if nothing has changed.
                db_version = new Version(row["value"]);
                if (db_version < app_version) {
                    row["value"] = Timekeeper.VERSION;
                    data.Update("meta", row, "key", "version");
                }
                */

                // do we have a UUID for this database?
                row = data.SelectRow("select value from meta where key = 'id'");
                if (row["value"] == null) {
                    // Create unique identifier for this database
                    row = new Row();
                    row["key"] = "id";
                    row["value"] = UUID.Get();
                    row["timestamp_c"] = Common.Now();
                    data.Insert("meta", row);
                }

                // does the tasks table have an is_hidden column?
                row = data.SelectRow("select * from tasks");
                if (!row.ContainsKey("is_hidden"))
                {
                    // File is pre TK 2.2
                    string alterTable = @"alter table tasks add column is_hidden bool";
                    data.Exec(alterTable);
                    string updateTable = @"update tasks set is_hidden = 0";
                    data.Exec(updateTable);
                }

                // does the projects table have an is_hidden column?
                row = data.SelectRow("select * from projects");
                if (!row.ContainsKey("is_hidden"))
                {
                    // File is pre TK 2.2
                    string alterTable = @"alter table projects add column is_hidden bool";
                    data.Exec(alterTable);
                    string updateTable = @"update projects set is_hidden = 0";
                    data.Exec(updateTable);
                }

                // make sure timekeeper.is_locked is not null (TKT #1227)
                row = new Row();
                row["is_locked"] = 0;
                int count = data.Update("timekeeper", row, "is_locked is null");

                // Commit
                data.Commit();
            }
            catch { //(Exception e) {
                // Rollback
                data.Rollback();
                return -1;
            }


            // Success
            return 0;
        }

        //---------------------------------------------------------------------

        public Row info()
        {
            // stub in row to return
            Row row = new Row();

            try
            {
                // grab all meta rows
                Table rows = data.Select("select key, value from meta order by key");

                // grab a few handy objects
                Tasks tasks = new Tasks(data, "");
                Projects projects = new Projects(data, "");
                Journal journal = new Journal(data);
                Log log = new Log(data);

                // convert meta rows to rows (note order by above)
                row.Add("created", rows[0]["value"]);
                row.Add("id", rows[1]["value"]);
                row.Add("version", rows[2]["value"]);

                // now grab individual attributes
                row.Add("filename", data.DataFile);
                row.Add("filesize", data.DataFileSize);
                row.Add("taskcount", tasks.count());
                row.Add("projectcount", projects.count());
                row.Add("journalcount", journal.count());
                row.Add("logcount", log.count());
                row.Add("totalseconds", Timekeeper.FormatSeconds(log.seconds()));
            }
            catch
            {
                // Return empty data
                
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
        // Actual creation functions
        //---------------------------------------------------------------------

        private void _createMeta()
        {
            string createMeta = @"
                create table meta (
                    key string,
                    value string,
                    timestamp_c datetime
                )";

            data.Exec(createMeta);

            Row row;

            // Stub in database creation date
            row = new Row() {
                {"key", "created"},
                {"value", Common.Now()},
                {"timestamp_c", Common.Now()}
            };
            data.Insert("meta", row);

            // Stub in (schema) version
            row = new Row() {
                {"key", "version"},
                {"value", Timekeeper.VERSION},
                {"timestamp_c", Common.Now()}
            };
            data.Insert("meta", row);

            // Create unique identifier for this database
            row = new Row() {
                {"key", "id"},
                {"value", UUID.Get()},
                {"timestamp_c", Common.Now()}
            };
            data.Insert("meta", row);
        }

        private void _createTasks()
        {
            string createTasks = @"
                create table tasks (
                    id integer primary key,
                    name string,
                    descr string,
                    parent_id integer,
                    is_folder bool,
                    is_hidden bool,
                    is_deleted bool,
                    project_id__last int,
                    timestamp_c datetime,
                    timestamp_m datetime
                )";

            data.Exec(createTasks);

            // Stub in one task 
            Row row = new Row();
            row["name"] = "Default Task";
            row["descr"] = "Right click this task and select Edit to change the name or this description";
            row["parent_id"] = 0;
            row["is_folder"] = 0;
            row["is_hidden"] = 0;
            row["is_deleted"] = 0;
            row["timestamp_c"] = Common.Now();
            row["timestamp_m"] = Common.Now();
            data.Insert("tasks", row);

        }

        private void _createProjects()
        {
            string createProjects = @"
                create table projects (
                    id integer primary key,
                    name string,
                    descr string,
                    parent_id integer,
                    is_folder bool,
                    is_hidden bool,
                    is_deleted bool,
                    timestamp_c datetime,
                    timestamp_m datetime
                )";

            data.Exec(createProjects);

            // Stub in one project
            Row row = new Row();
            row["name"] = "Default Project";
            row["descr"] = "Right click this project and select Edit to change the name or this description";
            row["parent_id"] = 0;
            row["is_folder"] = 0;
            row["is_hidden"] = 0;
            row["is_deleted"] = 0;
            row["timestamp_c"] = Common.Now();
            row["timestamp_m"] = Common.Now();
            data.Insert("projects", row);
        }

        private void _createTimekeeper()
        {
            string createTimekeeper = @"
                create table timekeeper (
                    id integer primary key,
                    task_id integer,
                    project_id integer,
                    timestamp_s datetime,
                    timestamp_e datetime,
                    seconds integer,
                    pre_log varchar,
                    post_log varchar,
                    is_locked bool
                )";

            data.Exec(createTimekeeper);
        }

        private void _createViews()
        {
            string createViews = @"
                create table grid_views (
                    id integer primary key,
                    name varchar,
                    description varchar,
                    sort_index int,
                    task_list varchar,
                    project_list varchar,
                    date_preset int,
                    start_date varchar,
                    end_date varchar,
                    end_date_type int,
                    group_by int,
                    data_from int,
                    hide_empty_rows int,
                    timestamp_c datetime,
                    timestamp_m datetime
                )";

            data.Exec(createViews);

            // FIXME: stub in a default???
        }

        private void _createJournal()
        {
            string createJournal = @"
                create table journal (
                    id integer primary key,
                    timestamp_entry datetime,
                    description varchar,
                    timestamp_c datetime,
                    timestamp_m datetime
                )";
            data.Exec(createJournal);
        }

    }


}
