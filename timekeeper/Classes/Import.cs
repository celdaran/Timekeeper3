using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Microsoft.VisualBasic.FileIO;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Import
    {
        //----------------------------------------------------------------------
        // Properties
        //----------------------------------------------------------------------

        private DBI Database;
        private string ImportFileName;

        private Dictionary<long, long> FoundProjects = new Dictionary<long,long>();
        private Dictionary<long, long> FoundActivities = new Dictionary<long,long>();
        private Dictionary<long, long> FoundLocations = new Dictionary<long,long>();
        private Dictionary<long, long> FoundCategories = new Dictionary<long,long>();

        public RichTextBox Console { get; set; }
        public ProgressBar ImportProgress { get; set; }

        //----------------------------------------------------------------------

        public Import(string importFieleName)
        {
            this.Database = Timekeeper.Database;
            this.ImportFileName = importFieleName;
        }

        //----------------------------------------------------------------------

        public bool Timekeeper1x(bool importProjects, bool importEntries)
        {
            try {
                FileStream ADLfile = new FileStream(ImportFileName + ".adl", FileMode.Open);

                if (importProjects) {
                    while (ADLfile.Position < ADLfile.Length) {
                        Timekeeper1Task Task = ReadTask(ADLfile);
                        string Message = String.Format("{0}\tCreateTime = {1}\tOfficial? {2}\n\n",
                            Task.TaskName, Task.CreateTime.ToString(), Task.IsOfficial.ToString());
                        //Common.Info(Message);
                        Console.AppendText(Message);

                        Classes.Project Project = new Classes.Project();

                        Project.Name = Task.TaskName;
                        Project.Description = "Project Imported from a Timekeeper 1.x file";
                        Project.IsFolder = false;
                        long ProjectId = Project.Create();

                        // Now go back and hack in a new create
                        // date that reflects the time this project
                        // was actually created.
                        Row Row = new Row();
                        Row["CreateTime"] = Task.CreateTime.ToString(Common.UTC_DATETIME_FORMAT);
                        Database.Update("Project", Row, "ProjectId", ProjectId);
                    }
                }

                FileStream ADTFile = new FileStream(ImportFileName + ".adt", FileMode.Open);

                while (ADTFile.Position < ADTFile.Length) {
                    Timekeeper1Bucket Bucket = ReadBucket(ADTFile);
                    string Message = String.Format("TaskDate = {0}\nTaskId = {1}\nTotalTime = {2}",
                        Bucket.TaskDate.ToString(), Bucket.TaskId.ToString(), Bucket.TotalTime.ToString());
                    //Common.Info(Message);
                }

                if (importEntries) {
                    String ADBFileName = ImportFileName + ".adb";
                    Timekeeper.Info("Attempting to open " + ADBFileName);

                    var TotalLines = System.IO.File.ReadLines(ADBFileName).Count();
                    ImportProgress.Maximum = TotalLines;

                    StreamReader ADBFile = new StreamReader(ADBFileName);
                    String Line;
                    int LineNo = 1;

                    DateTimeOffset EarliestImportedEntryDate = DateTimeOffset.MaxValue;

                    while ((Line = ADBFile.ReadLine()) != null) {

                        ImportProgress.Value = LineNo;
                        Application.DoEvents();

                        Timekeeper1Entry Entry = ReadEntry(Line);
                        if (Entry.Succeeded) {
                            Console.AppendText(Entry.StartTime + "\t'" + Entry.TaskName + "'\t" + Entry.Memo + "\n");

                            // A couple data conversions
                            TimeSpan ts = Entry.EndTime.Subtract(Entry.StartTime);
                            Classes.Project Project = new Classes.Project(Entry.TaskName);

                            // Keep track of this value for reindexing purposes.
                            // We'll only want to reindex from the earliest imported
                            // entry forward, and not the entire file
                            if (Entry.StartTime.CompareTo(EarliestImportedEntryDate) < 0) {
                                EarliestImportedEntryDate = Entry.StartTime;
                            }

                            // Now create the Journal Entry
                            Classes.JournalEntry JournalEntry = new Classes.JournalEntry();
                            JournalEntry.StartTime = Entry.StartTime;
                            JournalEntry.StopTime = Entry.EndTime;
                            JournalEntry.Seconds = (long)ts.TotalSeconds;
                            JournalEntry.Memo = Entry.Memo;
                            JournalEntry.ProjectId = Project.ItemId;
                            JournalEntry.ActivityId = 1; // Default Activity
                            // TODO: prompt for an Activity, Location, and/or Category to
                            // assign the new journal entry to.
                            JournalEntry.LocationId = 1; // Default Location
                            JournalEntry.CategoryId = 1; // Default Category
                            JournalEntry.IsLocked = false;
                            if (!JournalEntry.Create()) {
                                throw new Exception("There was an error creating the journal entry.");
                            }
                        } else {
                            Console.AppendText("Could not parse line " + LineNo.ToString() + "\n");
                        }
                        LineNo++;
                    }

                    // Now reindex the Journal table
                    Classes.JournalEntryCollection Entries = new Classes.JournalEntryCollection();
                    Entries.Reindex(EarliestImportedEntryDate);
                }
            }
            catch (Exception x)
            {
                Timekeeper.Exception(x);
                return false;
            }

            return true;
        }

        //----------------------------------------------------------------------

        public bool CommaSeparatedValues()
        {
            bool Imported = false;
            int RowNo = 0;
            DateTimeOffset EarliestImportedEntryDate = DateTimeOffset.MaxValue;

            string Message;
            int ImportedRows = 0;
            int DuplicateRows = 0;
            int InvalidRows = 0;
            int ErrorRows = 0;
            int ExceptionsCaught = 0;
            int ProjectsCreated = 0;
            int ActivitiesCreated = 0;
            int LocationsCreated = 0;
            int CategoriesCreated = 0;

            try {
                // Initialize positions
                int StartTimePos = -1;
                int StopTimePos = -1;
                int MemoPos = -1;
                int ProjectIdPos = -1;
                int ActivityIdPos = -1;
                int LocationIdPos = -1;
                int CategoryIdPos = -1;
                int ProjectPos = -1;
                int ActivityPos = -1;
                int LocationPos = -1;
                int CategoryPos = -1;

                // Set progress bar
                var TotalLines = System.IO.File.ReadLines(this.ImportFileName).Count();
                ImportProgress.Maximum = TotalLines;

                Message = String.Format("Import started at {0}.\n\n", Common.Now());
                Console.AppendText(Message);

                using (TextFieldParser parser = new TextFieldParser(this.ImportFileName)) {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");

                    while (!parser.EndOfData) {
                        string[] Fields = parser.ReadFields();

                        if (RowNo == 0) {
                            // Read header
                            int ColNo = 0;

                            foreach (string Field in Fields) {
                                if (Field == "StartTime")
                                    StartTimePos = ColNo;
                                else if (Field == "StopTime")
                                    StopTimePos = ColNo;
                                else if (Field == "Memo")
                                    MemoPos = ColNo;

                                // ID values
                                else if (Field == "ProjectId")
                                    ProjectIdPos = ColNo;
                                else if (Field == "ActivityId")
                                    ActivityIdPos = ColNo;
                                else if (Field == "LocationId")
                                    LocationIdPos = ColNo;
                                else if (Field == "CategoryId")
                                    CategoryIdPos = ColNo;

                                // Name values
                                else if (Field == "Project")
                                    ProjectPos = ColNo;
                                else if (Field == "Activity")
                                    ActivityPos = ColNo;
                                else if (Field == "Location")
                                    LocationPos = ColNo;
                                else if (Field == "Category")
                                    CategoryPos = ColNo;

                                else {
                                    // Just ignore it...
                                }

                                ColNo++;
                            }

                            // Quick sanity check: did we get our required columns?
                            if ((StartTimePos == -1) || (StopTimePos == -1)) {
                                throw new Exception("Both StartTime and StopTime columns must exist.");
                            }
                        } else {
                            // Instantiate a new JournalEntry object
                            Classes.JournalEntry JournalEntry = new Classes.JournalEntry();

                            // StartTime is our key
                            DateTimeOffset StartTime = DateTimeOffset.Parse(Fields[StartTimePos]);

                            if (CsvRowExists(StartTime)) {
                                Message = String.Format("Row {0}. Journal entry already exists: {1}\n",
                                    RowNo, StartTime.ToString(Common.UTC_DATETIME_FORMAT));
                                Console.AppendText(Message);
                                DuplicateRows++;
                            }
                            else {
                                // If StartTime is okay, continue

                                DateTimeOffset StopTime = DateTimeOffset.Parse(Fields[StopTimePos]);
                                TimeSpan ts = StopTime.Subtract(StartTime);

                                // Keep track of this value for reindexing purposes.
                                // We'll only want to reindex from the earliest imported
                                // entry forward, and not the entire file
                                if (StartTime.CompareTo(EarliestImportedEntryDate) < 0) {
                                    EarliestImportedEntryDate = StartTime;
                                }

                                JournalEntry.StartTime = StartTime;
                                JournalEntry.StopTime = StopTime;
                                JournalEntry.Seconds = (long)ts.TotalSeconds;

                                JournalEntry.Memo = MemoPos == -1 ? "" : Fields[MemoPos];

                                JournalEntry.ProjectId = DetermineDimension(Timekeeper.Dimension.Project, ProjectIdPos, ProjectPos, Fields, ref ProjectsCreated);
                                JournalEntry.ActivityId = DetermineDimension(Timekeeper.Dimension.Activity, ActivityIdPos, ActivityPos, Fields, ref ActivitiesCreated);
                                JournalEntry.LocationId = DetermineDimension(Timekeeper.Dimension.Location, LocationIdPos, LocationPos, Fields, ref LocationsCreated);
                                JournalEntry.CategoryId = DetermineDimension(Timekeeper.Dimension.Category, CategoryIdPos, CategoryPos, Fields, ref CategoriesCreated);

                                JournalEntry.IsLocked = false;

                                string ValidMessage = CsvRowIsValid(JournalEntry);

                                if (ValidMessage.Length == 0) {
                                    if (JournalEntry.Create()) {
                                        Message = String.Format("Row {0}. Imported CSV entry as TKID {1}.\n",
                                            RowNo, JournalEntry.JournalId);
                                        Console.AppendText(Message);
                                        ImportedRows++;
                                    } else {
                                        Message = String.Format("Row {0}. Error creating CSV entry.\n",
                                            RowNo);
                                        Console.AppendText(Message);
                                        ErrorRows++;
                                    }
                                } else {
                                    Message = String.Format("Row {0}. Invalid CSV entry: {1}\n",
                                        RowNo, ValidMessage);
                                    Console.AppendText(Message);
                                    InvalidRows++;
                                }
                            }
                        }

                        RowNo++;
                        ImportProgress.Value = RowNo;
                    }
                }

                // Correct row number
                RowNo--;

                // Now reindex the Journal table
                Classes.JournalEntryCollection Entries = new Classes.JournalEntryCollection();
                Entries.Reindex(EarliestImportedEntryDate);

                // If we made it this far, we're good.
                Imported = true;
            }
            catch (Exception x) {
                Message = String.Format("Row {0}. Exception caught: {1}.\n",
                    RowNo, x.Message);
                Console.AppendText(Message);

                //Common.Warn(Message);
                Timekeeper.Exception(x);

                ExceptionsCaught++;
            }

            // Close up bar (in case of errors or whatever)
            ImportProgress.Value = ImportProgress.Maximum;

            // Write stats to console
            Console.AppendText("\nImport Stats:\n\n");
            Console.AppendText("CSV rows read.......: " + RowNo.ToString() + "\n");
            Console.AppendText("Duplicate rows......: " + DuplicateRows.ToString() + "\n");
            Console.AppendText("Invalid rows........: " + InvalidRows.ToString() + "\n");
            Console.AppendText("Error rows..........: " + ErrorRows.ToString() + "\n");
            Console.AppendText("Exceptions caught...: " + ExceptionsCaught.ToString() + "\n");
            Console.AppendText("Projects created....: " + ProjectsCreated.ToString() + "\n");
            Console.AppendText("Activities created..: " + ActivitiesCreated.ToString() + "\n");
            Console.AppendText("Locations created...: " + LocationsCreated.ToString() + "\n");
            Console.AppendText("Categories created..: " + CategoriesCreated.ToString() + "\n\n");
            Console.AppendText("Rows imported.......: " + ImportedRows.ToString() + "\n");

            Message = String.Format("\nImport completed at {0}.\n", Common.Now());
            Console.AppendText(Message);

            return Imported;
        }

        private bool CsvRowExists(DateTimeOffset StartTime)
        {
            Classes.JournalEntryCollection JournalEntryCollection = new Classes.JournalEntryCollection();
            if (JournalEntryCollection.Exists(StartTime)) {
                return true;
            } else {
                return false;
            }
        }

        private string CsvRowIsValid(Classes.JournalEntry JournalEntry)
        {
            string Message = "";

            if (JournalEntry.Seconds < 0) {
                Message += "Stop time cannot be before start time. ";
            }

            if (FoundProjects.ContainsKey(JournalEntry.ProjectId)) {
                FoundProjects[JournalEntry.ProjectId]++;
            } else {
                FoundProjects.Add(JournalEntry.ProjectId, 1);
                Classes.Project Project = new Classes.Project(JournalEntry.ProjectId);
                if (!Project.Exists()) {
                    Message += "ProjectId " + JournalEntry.ProjectId.ToString() + " could not be found. ";
                }
            }

            if (FoundActivities.ContainsKey(JournalEntry.ActivityId)) {
                FoundActivities[JournalEntry.ActivityId]++;
            } else {
                FoundActivities.Add(JournalEntry.ActivityId, 1);
                Classes.Activity Activity = new Classes.Activity(JournalEntry.ActivityId);
                if (!Activity.Exists()) {
                    Message += "ActivityId " + JournalEntry.ActivityId.ToString() + " could not be found. ";
                }
            }

            if (FoundLocations.ContainsKey(JournalEntry.LocationId)) {
                FoundLocations[JournalEntry.LocationId]++;
            } else {
                FoundLocations.Add(JournalEntry.LocationId, 1);
                Classes.Location Location = new Classes.Location(JournalEntry.LocationId);
                if (!Location.Exists(Location.Name)) {
                    Message += "LocationId " + JournalEntry.LocationId.ToString() + " could not be found. ";
                }
            }

            if (FoundCategories.ContainsKey(JournalEntry.CategoryId)) {
                FoundCategories[JournalEntry.CategoryId]++;
            } else {
                FoundCategories.Add(JournalEntry.CategoryId, 1);
                Classes.Category Category = new Classes.Category(JournalEntry.CategoryId);
                if (!Category.Exists(Category.Name)) {
                    Message += "CategoryId " + JournalEntry.CategoryId.ToString() + " could not be found. ";
                }
            }

            return Message;
        }

        private long DetermineDimension(Timekeeper.Dimension dimension, int idPos, int namePos, string[] fields, ref int createdCount)
        {
            long returnId = -1;

            try {
                if (idPos == -1)
                    if (namePos == -1)
                        returnId = 1;
                    else
                        if ((dimension == Timekeeper.Dimension.Project) || (dimension == Timekeeper.Dimension.Activity))
                            returnId = CheckName_Tree(dimension, namePos, fields, ref createdCount);
                        else
                            returnId = CheckName_List(dimension, namePos, fields, ref createdCount);
                else
                    returnId = Convert.ToInt32(fields[idPos]);
                    /*
                    if ((dimension == Timekeeper.Dimension.Project) || (dimension == Timekeeper.Dimension.Activity))
                        returnId = CheckId_Tree(dimension, fields[idPos]);
                    else
                        returnId = CheckId_List(dimension, fields[idPos]);
                    */
            }
            catch (Exception x) {
                throw new Exception("Could not read " + dimension.ToString() + ". " + x.Message);
            }

            return returnId;
        }

        private long CheckName_List(Timekeeper.Dimension dimension, int namePos, string[] fields, ref int createdCount)
        {
            long returnId = 0;

            Classes.ListAttribute Item = new Classes.ListAttribute(dimension.ToString(), fields[namePos]);
            if (Item.Id == 0) {
                Item.Name = fields[namePos];
                Item.Description = "Item created automatically during Import process.";
                Item.Create();
                if (Item.Id > 0) {
                    string Message = String.Format("  Created {0} \"{1}\"\n", dimension, Item.Name);
                    Console.AppendText(Message);
                    createdCount++;
                }
            }
            if (Item.Id == 0) {
                throw new Exception("The non-existent " + dimension.ToString() + " \"" + Item.Name + "\" could not be created.");
            } else {
                returnId = Item.Id;
            }

            return returnId;
        }

        private long CheckName_Tree(Timekeeper.Dimension dimension, int namePos, string[] fields, ref int createdCount)
        {
            long returnId = 0;

            Classes.TreeAttribute Item = new Classes.TreeAttribute(fields[namePos], dimension.ToString(), dimension.ToString() + "Id");
            if (Item.ItemId == 0) {
                Item.Name = fields[namePos];
                Item.Description = "Item created automatically during Import process.";
                //Item.Dimension = dimension;
                Item.IsFolder = false;
                Item.ParentId = 0;
                Item.Create();
                if (Item.ItemId > 0) {
                    string Message = String.Format("  Created {0} \"{1}\"\n", dimension, Item.Name);
                    Console.AppendText(Message);
                    createdCount++;
                }
            }
            if (Item.ItemId == 0) {
                throw new Exception("The non-existent " + dimension.ToString() + " \"" + Item.Name + "\" could not be created.");
            } else {
                returnId = Item.ItemId;
            }

            return returnId;
        }

        // Actually, not using the following two any more

        private long CheckId_List(Timekeeper.Dimension dimension, string idValue)
        {
            long returnId = Convert.ToInt32(idValue);

            Classes.ListAttribute Item = new Classes.ListAttribute(dimension.ToString(), returnId);
            if (Item.Id > 0) {
                // All is well
            } else {
                throw new Exception("The specified " + dimension.ToString() + " " + idValue + " does not exist.");
            }

            return returnId;
        }

        private long CheckId_Tree(Timekeeper.Dimension dimension, string idValue)
        {
            long returnId = Convert.ToInt32(idValue);

            Classes.TreeAttribute Item = new Classes.TreeAttribute(returnId, dimension.ToString(), dimension.ToString() + "Id");
            if (Item.Exists()) {
                // All is well
            } else {
                throw new Exception("The specified " + dimension.ToString() + " " + idValue + " does not exist.");
            }

            return returnId;
        }

        //----------------------------------------------------------------------

        //----------------------------------------------------------------------
        // File Readers
        //----------------------------------------------------------------------

        private Timekeeper1Task ReadTask(FileStream stream)
        {
            var Line = new Timekeeper1Task();

            var TaskId = new byte[8];
            var TaskLength = new byte[1];
            var Task = new byte[50];
            var Active = new byte[1];
            var Official = new byte[1];
            var Eoln = new byte[3];

            stream.Read(TaskId, 0, 8);
            stream.Read(TaskLength, 0, 1);
            stream.Read(Task, 0, 50);
            stream.Read(Official, 0, 1);
            stream.Read(Active, 0, 1);
            stream.Read(Eoln, 0, 3);

            Line.TaskId = BitConverter.ToInt64(TaskId, 0);
            Line.TaskName = System.Text.Encoding.ASCII.GetString(Task);
            Line.TaskName = Line.TaskName.Substring(0, Convert.ToInt32(TaskLength[0]));
            Line.IsOfficial = Official[0] == 255 ? true : false;
            Line.isActive = Active[0] == 255 ? true : false;

            /*
            It is stored as a Double variable, with the date as the 
            integral part, and time as fractional part. The date is 
            stored as the number of days since 30 Dec 1899. Quite why 
            it is not 31 Dec is not clear. 01 Jan 1900 has a days 
            value of 2. 
            */

            double Temp = BitConverter.ToDouble(TaskId, 0);
            Line.CreateTime = DateTime.FromOADate(Temp);

            return Line;
        }

        //----------------------------------------------------------------------

        private Timekeeper1Bucket ReadBucket(FileStream stream)
        {
            var Line = new Timekeeper1Bucket();

            var TaskDate = new byte[8];
            var TaskId = new byte[8];
            var TotalTime = new byte[8];

            stream.Read(TaskDate, 0, 8);
            stream.Read(TaskId, 0, 8);
            stream.Read(TotalTime, 0, 8);

            double RawTaskDate = BitConverter.ToDouble(TaskId, 0);
            Line.TaskDate = DateTime.FromOADate(RawTaskDate);

            Line.TaskId = BitConverter.ToInt64(TaskId, 0);

            double RawTotalTime = BitConverter.ToDouble(TotalTime, 0);
            DateTime ConvertedTotalTime = DateTime.FromOADate(RawTotalTime);
            DateTime ZeroDate = DateTime.Parse("1899-12-30 00:00:00");
            Line.TotalTime = ConvertedTotalTime.Subtract(ZeroDate);

            return Line;
        }

        //----------------------------------------------------------------------

        private Timekeeper1Entry ReadEntry(string line)
        {
            var Entry = new Timekeeper1Entry();

            Entry.Succeeded = false;

            try {
                //------------------------------------------
                // First, read in the raw text
                //------------------------------------------

                // Guaranteed data
                string EntryDate = line.Substring(0, 8);
                string EntryStartTime = line.Substring(9, 8);
                string EntryTimeDelimiter = line.Substring(17, 3);

                // Potentially missing data
                string EntryEndTime = "";
                if (line.Length > 20) {
                    EntryEndTime = line.Substring(20, 8);
                }
                string EntryTaskName = "";
                int ParenPosition = -1;
                if (line.Length > 40) {
                    ParenPosition = line.IndexOf("(", 40);
                    EntryTaskName = line.Substring(40, ParenPosition - 40 - 1);
                }
                string EntryMemo = "";
                if (line.Length > ParenPosition) {
                    EntryMemo = line.Substring(ParenPosition + 1, line.Length - ParenPosition - 2);
                }

                //------------------------------------------
                // Next, convert to native data types
                //------------------------------------------

                //DateTime Entry
                DateTime BaseDate = DateTime.Parse(EntryDate);
                Entry.StartTime = DateTime.Parse(EntryDate + " " + EntryStartTime);
                if (EntryEndTime != "") {
                    if (EntryEndTime.CompareTo(EntryStartTime) < 0) {
                        // Our end time went into the next day, 
                        // so bump the base date by one, then
                        // calculate end time from there...
                        BaseDate.AddDays(1);
                        Entry.EndTime = DateTime.Parse(BaseDate.ToShortDateString() + " " + EntryEndTime);
                    } else {
                        Entry.EndTime = DateTime.Parse(EntryDate + " " + EntryEndTime);
                    }
                } else {
                    Entry.EndTime = Entry.StartTime;
                }

                Entry.TaskName = EntryTaskName;
                Entry.Memo = EntryMemo;

                Entry.Succeeded = true;

            }
            catch (Exception x) {
                // TODO: add stats so we can report back
                Timekeeper.Exception(x);
            }

            return Entry;
        }

        //----------------------------------------------------------------------

    }

    //----------------------------------------------------------------------
    // Structs
    //----------------------------------------------------------------------

    /*
      From the Timekeeper 1.0 source code (fMain.pas)

      TActivityList = record
        ActivityId : TDateTime;
        Activity : string[50];
        Official : bytebool;
        Active : bytebool;
      end;

      TActivityTime = record
        ActivityDate : TDateTime;
        ActivityId : TDateTime;
        TotalTime : TDateTime;
      end;
    */

    //----------------------------------------------------------------------

    public struct Timekeeper1Task
    {
        public long TaskId;
        public string TaskName;
        public bool IsOfficial;
        public bool isActive;
        public DateTime CreateTime;
    }

    //----------------------------------------------------------------------

    public struct Timekeeper1Bucket
    {
        public DateTime TaskDate;
        public long TaskId;
        public TimeSpan TotalTime;
    }

    //----------------------------------------------------------------------

    public struct Timekeeper1Entry
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public string TaskName;
        public string Memo;
        public bool Succeeded;
    }

    //----------------------------------------------------------------------
    // End Structs
    //----------------------------------------------------------------------

}
