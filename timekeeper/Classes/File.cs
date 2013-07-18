using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Resources;
using System.Collections.ObjectModel;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class File
    {
        public DBI Database;

        public readonly string Name;
        public readonly string FullPath;

        public const string SCHEMA_VERSION = "3.0.0.1";

        public const int ERROR_UNEXPECTED = -1;
        public const int ERROR_NEWER_VERSION_DETECTED = -2;
        public const int ERROR_NOT_TKDB = -3;
        public const int ERROR_EMPTY_DB = -4;
        public const int ERROR_REQUIRES_UPGRADE = -5;

        private FileInfo FileInfo;
        private ResourceManager Resources;

        private FileCreateOptions _CreateOptions;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        // Deprecated constructor
        public File(DBI data)
        {
            this.Database = data;
            FileInfo = new FileInfo(this.Database.FileName);
            this.Name = FileInfo.Name;
            this.FullPath = FileInfo.DirectoryName + "\\" + FileInfo.Name;
            this.Resources = new ResourceManager("Timekeeper.Properties.Resources", typeof(File).Assembly);
            this.CreateOptions = new FileCreateOptions();
        }

        // New/future constructor
        // Calling the old for compatability purposes
        public File() : this(Timekeeper.Database)
        {
        }

        //---------------------------------------------------------------------
        // Accessors
        //---------------------------------------------------------------------

        public FileCreateOptions CreateOptions
        {
            get { return _CreateOptions; }
            set { _CreateOptions = value; }
        }

        //---------------------------------------------------------------------
        // Check Database Integrity
        //---------------------------------------------------------------------

        public int Check()
        {
            try {
                Version CurrentSchemaVersion = new Version(SCHEMA_VERSION);
                Version FoundSchemaVersion = this.GetSchemaVersion();

                // Quick sanity check on currently-opened database. If these
                // two functions work, we have a valid SQLite file.
                // FIXME: this should be DBI's responsibility, I'm not sure
                // how we're getting this far opening, say, a Word document.
                Database.Begin();
                Database.Rollback();

                // Are there any tables at all?
                if (!Database.TablesExist()) {
                    // If we've opened the database and successfully queried the master table
                    // but have not found any rows, then it's a valid, empty SQLite file and
                    // we should allow the user to opt for converting it to a TK database.
                    return ERROR_EMPTY_DB;
                }

                // Can we extract the schema version from the meta table?
                if (FoundSchemaVersion != null) {
                    if (FoundSchemaVersion > CurrentSchemaVersion) {
                        return ERROR_NEWER_VERSION_DETECTED;
                    }

                    if (CurrentSchemaVersion > FoundSchemaVersion) {
                        return ERROR_REQUIRES_UPGRADE;
                    }
                } else {
                    return ERROR_NOT_TKDB;
                }

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return ERROR_UNEXPECTED;
            }

            // Success
            return 0;
        }

        //---------------------------------------------------------------------
        // Database Creation & Population
        //---------------------------------------------------------------------

        /*
        public bool Create(Version version)
        {
            return Create(VersionToString(version), true);
        }

        //---------------------------------------------------------------------

        public bool Create(Version version, bool populate)
        {
            return Create(VersionToString(version), populate);
        }
        */

        //---------------------------------------------------------------------

        // TRANSITIONAL

        /*
        public bool Create(Version desiredVersion, bool populate)
        {
            FileCreateOptions Options = new FileCreateOptions();
            return Create(desiredVersion, Options, populate);
        }
        */

        //---------------------------------------------------------------------

        public bool Create(Version desiredVersion) //string version)
        {
            return Create(desiredVersion, true);
        }

        //---------------------------------------------------------------------

        public bool Create(Version desiredVersion, bool populate) //string version, bool populate)
        {
            try {
                string version = VersionToString(desiredVersion);

                // Note: due to FK constraints, the order
                // of table creation below matters.

                // Schema Metadata
                CreateTable("Meta", version, populate);

                // System Reference tables | FIXME: not FALSE for populate. wtf?
                CreateTable("RefItemType", version, populate);
                CreateTable("RefDatePreset", version, populate);
                CreateTable("RefGroupBy", version, populate);
                CreateTable("RefTimeDisplay", version, populate);
                CreateTable("RefTimeZone", version, false);
                PopulateRefTimeZone();

                // User Reference Tables
                CreateTable("Location", version, false);
                CreateTable("Activity", version, populate);
                CreateTable("Project",  version, populate);
                CreateTable("Category", version, populate);

                // Journal Tables
                CreateTable("Journal", version, false);
                CreateTable("Diary", version, false);

                // User Options
                CreateTable("Options", version, populate);
                CreateTable("FilterOptions", version, false);
                CreateTable("GridOptions", version, false);
                CreateTable("ReportOptions", version, false);

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //---------------------------------------------------------------------

        private void CreateTable(string tableName, Version version, bool populate)
        {
            CreateTable(tableName, VersionToString(version), populate);
        }

        //---------------------------------------------------------------------

        private void CreateTable(string tableName, string version, bool populate)
        {
            string Query = null;
            string ResourceName = null;

            //----------------------------------------
            // Create the table
            //----------------------------------------

            ResourceName = String.Format("SQL_{0}_{1}_Create", version, tableName);
            Query = Resources.GetString(ResourceName);

            if (Query != null) {
                long status = Database.Exec(Query);
                Timekeeper.Debug(ResourceName + " status was " + status.ToString());
            } else {
                // Actually, this isn't necessarily bad: this will get
                // tripped up when I try to create tables in older 
                // versions that don't exist in the current version.
                Timekeeper.Warn("Could not find resource: " + ResourceName);
                return;
            }

            //----------------------------------------
            // Populate the table
            //----------------------------------------

            if (!populate) {
                return;
            }

            ResourceName = String.Format("SQL_{0}_{1}_Insert", version, tableName);
            Query = Resources.GetString(ResourceName);

            if (Query != null) {
                // FIXME: Consider removing positional arguments with named arguments
                // The below implementation gets us by, but doesn't feel right at all.
                Query = String.Format(Query, Common.Now(), UUID.Get(), UUID.Get(), SCHEMA_VERSION);
                long status = Database.Exec(Query);
                Timekeeper.Debug(ResourceName + " status was " + status.ToString());
            } else {
                Timekeeper.Warn("Could not find resource: " + ResourceName);
                return;
            }
        }

        //---------------------------------------------------------------------

        private void PopulateRefTimeZone()
        {
            //----------------------------------------------
            // The Time Zone reference table is populated
            // at database creation by copying the OS list
            // of time zones and assigning an identity value
            // to each (for use as FKs inside the tkdb).
            // Note: there is currently no support for
            // updating this list after its initial 
            // generation. Future FIXME.
            //----------------------------------------------

            ReadOnlyCollection<TimeZoneInfo> TimeZones = TimeZoneInfo.GetSystemTimeZones();
            foreach (TimeZoneInfo TimeZone in TimeZones) {
                Row RefTimeZone = new Row();
                RefTimeZone["OSTimeZone"] = TimeZone.Id;
                this.InsertedRowId = Database.Insert("RefTimeZone", RefTimeZone);
                if (InsertedRowId == 0) throw new Exception("Insert failed");
            }
        }

        //---------------------------------------------------------------------

        public void PopulateLocation()
        {
            Row Location = new Row();

            Location["CreateTime"] = Common.Now();
            Location["ModifyTime"] = Common.Now();
            Location["LocationGuid"] = UUID.Get();
            Location["Name"] = Options.LocationName;
            Location["Description"] = Options.LocationDescription;
            Location["RefTimeZoneId"] = Options.LocationTimeZoneId;
            Location["SortOrderNo"] = 0;
            Location["IsHidden"] = 0;
            Location["IsDeleted"] = 0;
            Location["HiddenTime"] = null;
            Location["DeletedTime"] = null;

            this.InsertedRowId = Database.Insert("Location", Location);
            if (InsertedRowId == 0) throw new Exception("Insert failed");
        }

        //---------------------------------------------------------------------
        // Return Database Metadata and Information
        //---------------------------------------------------------------------

        public Row Info()
        {
            // stub in row to return
            Row row = new Row();

            try
            {
                // Grab a few handy objects
                Activities Tasks = new Activities(Database, "");
                Projects Projects = new Projects(Database, "");
                Classes.Diary Diary = new Classes.Diary();
                Entries Entries = new Entries(Database);

                // convert meta rows to rows (note order by above)
                Classes.Meta Meta = new Classes.Meta();
                row.Add("created", Meta.Created);
                row.Add("id", Meta.Id);
                row.Add("version", Meta.Version);

                // now grab individual attributes
                row.Add("filename", Database.FileName);
                row.Add("filesize", Database.FileSize);
                row.Add("taskcount", Tasks.Count());
                row.Add("projectcount", Projects.Count());
                row.Add("journalcount", Diary.Count());
                row.Add("logcount", Entries.Count());
                row.Add("totalseconds", Timekeeper.FormatSeconds(Entries.TotalSeconds()));
            }
            catch (Exception x)
            {
                // Log the problem
                Timekeeper.Exception(x);

                // Return empty Data on any sort of error

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
        // Extract the Schema Version from the Database itself
        //---------------------------------------------------------------------

        public Version GetSchemaVersion()
        {
            Version FoundSchemaVersion = null;

            try {
                // Universal (i.e., all TK 2.x and above) meta table detection.
                if (Database.TableExists(Timekeeper.MetaTableName()) || Database.TableExists("meta"))
                {
                    // Determine table name and column names
                    string TableName;
                    string ValueColumnName;
                    string KeyColumnName;
                    string KeyColumnValue;

                    if (Database.TableExists(Timekeeper.MetaTableName())) {
                        TableName = Timekeeper.MetaTableName();
                        ValueColumnName = "Value";
                        KeyColumnName = "Key";
                        KeyColumnValue = "Version";
                    } else {
                        TableName = "meta";
                        ValueColumnName = "value";
                        KeyColumnName = "key";
                        KeyColumnValue = "version";
                    }

                    string Query = String.Format("select {0} as Value from {1} where {2} = '{3}'",
                        ValueColumnName, TableName, KeyColumnName, KeyColumnValue);

                    // If the table exists, attempt to read the schema version.
                    Row Row = Database.SelectRow(Query);
                    if (Row["Value"] == null) {
                        // If version not found, we're in trouble. The user
                        // might have to upgrade or repair the database.
                        throw new System.ApplicationException("Version not found");
                    } else {
                        FoundSchemaVersion = new Version(Row["Value"]);
                    }

                } else {
                    throw new System.ApplicationException("Meta data not found");
                }

            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

            return FoundSchemaVersion;
        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        private string VersionToString(Version version)
        {
            string StringVersion = String.Format("{0}{1}{2}{3}",
                version.Major, version.Minor, version.Build, version.Revision);
            return StringVersion;
        }

        //---------------------------------------------------------------------

    }

}
