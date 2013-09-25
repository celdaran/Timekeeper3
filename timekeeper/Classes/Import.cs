using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

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
                        Row["CreateTime"] = Task.CreateTime.ToString(Common.DATETIME_FORMAT);
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

                    while ((Line = ADBFile.ReadLine()) != null) {

                        ImportProgress.Value = LineNo;
                        Application.DoEvents();

                        Timekeeper1Entry Entry = ReadEntry(Line);
                        if (Entry.Succeeded) {
                            Console.AppendText(Entry.StartTime + "\t'" + Entry.TaskName + "'\t" + Entry.Memo + "\n");

                            // A couple data conversions
                            TimeSpan ts = Entry.EndTime.Subtract(Entry.StartTime);
                            Classes.Project Project = new Classes.Project(Entry.TaskName);

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
                                throw new Exception("There was an error starting the timer.");
                            }
                        } else {
                            Console.AppendText("Could not parse line " + LineNo.ToString() + "\n");
                        }
                        LineNo++;
                    }
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
