using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Resources;

using System.Collections.ObjectModel;
using System.Xml;

using Technitivity.Toolbox;

namespace Timekeeper
{
    partial class File
    {
        public DBI Database;

        public readonly string Name;
        public readonly string FullPath;

        //----------------------------------------------------------------------
        // A note on SCHEMA_VERSION:
        //
        //   MAJOR: Matches the major version of TK which created this schema.
        //   MINOR: Matches the minor version of TK which created this schema.
        //   BUILD: Increments whenever the schema changes in a way that 
        //          would case code incompatabilities. This would mean a new 
        //          table, a new column, or an object rename.
        //   REV'N: Increments whenever the schema changes in a way that
        //          does NOT cause any code incompatabilities. This would be
        //          things like new FK constraints, indeces, or (in some cases)
        //          new default rows.
        //
        // If the schema version changes, then the SQL file resources must also
        // be updated. Note that prior to 3.0, this convention was not followed 
        // (nor were the DDL statements stored as resources or tracked in p4).
        //----------------------------------------------------------------------
        public const string SCHEMA_VERSION = "3.0.6.0";
        //----------------------------------------------------------------------

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
            if ((Database != null) && (Database.FileName != null)) {
                FileInfo = new FileInfo(this.Database.FileName);
                this.Name = FileInfo.Name;
                this.FullPath = FileInfo.DirectoryName + "\\" + FileInfo.Name;
                this.Resources = new ResourceManager("Timekeeper.Properties.Resources", typeof(File).Assembly);
                this.CreateOptions = new FileCreateOptions();
            }
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

                // System Reference tables
                // FIXME: not FALSE for populate. wtf?
                CreateTable("RefDimension", version, populate);
                CreateTable("RefDatePreset", version, populate);
                CreateTable("RefGroupBy", version, populate);
                CreateTable("RefTimeDisplay", version, populate);
                CreateTable("RefTimeZone", version, false);
                CreateTable("RefTodoStatus", version, populate);
                PopulateRefTimeZone();

                // User Reference Tables
                CreateTable("Location", version, false);
                PopulateLocation((FileBaseOptions)this.CreateOptions);
                CreateTable("Category", version, populate);

                CreateTable("Activity", version, false);
                CreateTable("Project",  version, false);
                PopulateItems();

                // User Tables
                CreateTable("Journal", version, false);
                CreateTable("Notebook", version, false);
                CreateTable("Todo", version, false);

                // User Options
                CreateTable("Options", version, populate);
                CreateTable("FilterOptions", version, false);

                // User Views
                CreateTable("FindView", version, false);
                CreateTable("GridView", version, false);
                CreateTable("ReportView", version, false);

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
            //
            // TODO: There is currently no support for
            // updating this list after its initial 
            // generation.
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

        public void PopulateLocation(FileBaseOptions options)
        {
            Row Location = new Row();

            Location["CreateTime"] = Common.Now();
            Location["ModifyTime"] = Common.Now();
            Location["LocationGuid"] = UUID.Get();
            Location["Name"] = options.LocationName;
            Location["Description"] = options.LocationDescription;
            Location["RefTimeZoneId"] = options.LocationTimeZoneId;
            Location["SortOrderNo"] = 0;
            Location["IsHidden"] = 0;
            Location["IsDeleted"] = 0;
            Location["HiddenTime"] = null;
            Location["DeletedTime"] = null;

            this.InsertedRowId = Database.Insert("Location", Location);
            if (InsertedRowId == 0) throw new Exception("Insert failed");
        }

        //----------------------------------------------------------------------

        public void PopulateItems()
        {
            int PresetId = CreateOptions.ItemPreset;

            if (PresetId == 0) {
                PopulateDefaultItems();
            } else {
                PopulatePresetItems(PresetId);
            }
        }

        //----------------------------------------------------------------------

        private void PopulateDefaultItems()
        {
            CreateItem("Default Project", new Classes.Project(Database));
            CreateItem("Default Activity", new Classes.Activity(Database));
        }

        //----------------------------------------------------------------------

        private void PopulatePresetItems(int presetId)
        {
            try {
                // Open XML and get requested preset.
                XmlDocument Presets = new XmlDocument();
                Presets.LoadXml(Properties.Resources.Item_Presets);
                string XmlPath = String.Format("/presets/preset[@id='{0}']", presetId.ToString());

                // Find the Projects and Activities
                XmlNode Preset = Presets.SelectSingleNode(XmlPath);
                XmlNode Projects = Preset.ChildNodes[0];
                XmlNode Activities = Preset.ChildNodes[1];

                // Create Projects (new method)
                foreach (XmlNode ProjectNode in Projects.ChildNodes) {

                    Classes.Project Project = new Classes.Project(Database);
                    Classes.Project ParentProject = new Classes.Project(Database, ProjectNode["parent"].InnerText);

                    CreateItem(ProjectNode, (Classes.TreeAttribute)Project, (Classes.TreeAttribute)ParentProject);
                }

                // Create Activities (new method)
                foreach (XmlNode ActivityNode in Activities.ChildNodes) {

                    Classes.Activity Activity = new Classes.Activity(Database);
                    Classes.Activity ParentActivity = new Classes.Activity(Database, ActivityNode["parent"].InnerText);

                    CreateItem(ActivityNode, (Classes.TreeAttribute)Activity, (Classes.TreeAttribute)ParentActivity);
                }
            }
            catch (Exception x) {
                Timekeeper.Warn("Failure in PopulateItems(). Database schema likely corrupt.");
                Timekeeper.Exception(x);
                throw;
            }

            /*
            // Create Projects
            foreach (XmlNode ProjectNode in Projects.ChildNodes) {

                Project Project = new Project(Database);

                Project.Name = ProjectNode["name"].InnerText;
                Project.Description = ProjectNode["description"].InnerText;
                Project.IsFolder = ProjectNode["isfolder"].InnerText == "true";

                if (ProjectNode["parent"].InnerText != "") {
                    Project ParentProject = new Project(Database, ProjectNode["parent"].InnerText);
                    if (ParentProject.ItemId == 0) {
                        Timekeeper.Warn("Could not find parent item: '" + ProjectNode["parent"].InnerText + "'");
                    } else {
                        Project.ParentId = ParentProject.ItemId;
                    }
                }

                Project.Create();
            }

            // Create Activities
            foreach (XmlNode ActivityNode in Activities.ChildNodes) {

                Activity Activity = new Activity(Database);

                Activity.Name = ActivityNode["name"].InnerText;
                Activity.Description = ActivityNode["description"].InnerText;
                Activity.IsFolder = ActivityNode["isfolder"].InnerText == "true";

                if (ActivityNode["parent"].InnerText != "") {
                    Activity ParentActivity = new Activity(Database, ActivityNode["parent"].InnerText);
                    if (ParentActivity.ItemId == 0) {
                        Timekeeper.Warn("Could not find parent item: '" + ActivityNode["parent"].InnerText + "'");
                    } else {
                        Activity.ParentId = ParentActivity.ItemId;
                    }
                }

                Activity.Create();
            }
            */
        }

        //----------------------------------------------------------------------

        private void CreateItem(string itemName, Classes.TreeAttribute item)
        {
            item.Name = itemName;
            item.Description = "Default item";
            item.IsFolder = false;
            item.Create();
        }

        //----------------------------------------------------------------------

        private void CreateItem(XmlNode itemNode, Classes.TreeAttribute item, Classes.TreeAttribute parentItem)
        {
            item.Name = itemNode["name"].InnerText;
            item.Description = itemNode["description"].InnerText;
            item.IsFolder = itemNode["isfolder"].InnerText == "true";

            if (itemNode["parent"].InnerText != "") {
                if (parentItem.ItemId == 0) {
                    Timekeeper.Warn("Could not find parent item: '" + itemNode["parent"].InnerText + "'");
                } else {
                    item.ParentId = parentItem.ItemId;
                }
            }

            item.Create();
        }

        //---------------------------------------------------------------------
        // Return Database Metadata and Information
        //---------------------------------------------------------------------

        public Row Info()
        {
            if (Database == null) {
                return EmptyInfo();
            }

            // stub in row to return
            Row Info = new Row();

            try {
                // Grab a few handy objects
                Classes.ProjectCollection Projects = new Classes.ProjectCollection(Database);
                Classes.ActivityCollection Activities = new Classes.ActivityCollection(Database);
                Classes.Notebook Notebook = new Classes.Notebook();
                Classes.JournalEntryCollection Entries = new Classes.JournalEntryCollection();

                // convert meta rows to rows (note order by above)
                Classes.Meta Meta = new Classes.Meta();
                Info.Add("Created", Meta.Created);
                Info.Add("Upgraded", Meta.Upgraded);
                Info.Add("Id", Meta.Id);
                Info.Add("Version", Meta.Version);

                // now grab individual attributes
                Info.Add("FileName", Database.FileName);
                Info.Add("FileSize", Database.FileSize);
                Info.Add("EntryCount", Entries.Count());
                Info.Add("NotebookCount", Notebook.Count());
                Info.Add("ProjectCount", Projects.Count());
                Info.Add("ActivityCount", Activities.Count());
                Info.Add("TotalTime", Timekeeper.FormatSeconds(Entries.TotalSeconds()));

                // Flag that we're good
                Info.Add("FileOpened", true);
            }
            catch (Exception x)
            {
                Timekeeper.Exception(x);
                return EmptyInfo();
            }

            return Info;
        }

        //----------------------------------------------------------------------

        public Row EmptyInfo()
        {
            Row Info = new Row();

            // convert meta rows to rows
            Info.Add("Created", "");
            Info.Add("Upgraded", "");
            Info.Add("Id", "");
            Info.Add("Version", "");

            // now grab individual attributes
            Info.Add("FileName", "No file opened");
            Info.Add("FileSize", 0);
            Info.Add("EntryCount", 0);
            Info.Add("NotebookCount", 0);
            Info.Add("ActivityCount", 0);
            Info.Add("ProjectCount", 0);
            Info.Add("TotalSeconds", 0);

            // Flag that we're not good
            Info.Add("FileOpened", false);

            return Info;
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
