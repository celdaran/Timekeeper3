using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Runtime.InteropServices;
using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    public partial class ImportWizard : Form
    {
        private DBI Database;

        public ImportWizard()
        {
            InitializeComponent();
            this.Database = Timekeeper.Database;
        }

        private void ImportWizard_FormClosed(object sender, FormClosedEventArgs e)
        {
            // quick escape
            //Environment.Exit(0);
            Close();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            try {
                FileStream ADLfile = new FileStream(ImportFileName.Text + ".adl", FileMode.Open);

                /*
                var ActivityId = new byte[9];
                var ActivityLength = new byte[1];
                var Activity = new byte[50];
                var Active = new byte[1];
                var Official = new byte[1];
                var Eoln = new byte[3];

                ImportFile.Read(ActivityId, 0, 8);
                ImportFile.Read(ActivityLength, 0, 1);
                ImportFile.Read(Activity, 0, 50);
                ImportFile.Read(Active, 0, 1);
                ImportFile.Read(Official, 0, 1);
                ImportFile.Read(Eoln, 0, 3);

                string ActivityString = System.Text.Encoding.ASCII.GetString(Activity);
                ActivityString = ActivityString.Substring(0, Convert.ToInt32(ActivityLength[0]));
                bool IsOfficial = Active[0] == 255 ? true : false;

                Common.Info("You just found '" + ActivityString + "'. Is it official? " + IsOfficial.ToString());

                ImportFile.Read(ActivityId, 0, 8);
                ImportFile.Read(ActivityLength, 0, 1);
                ImportFile.Read(Activity, 0, 50);
                ImportFile.Read(Active, 0, 1);
                ImportFile.Read(Official, 0, 1);
                ImportFile.Read(Eoln, 0, 3);

                ActivityString = System.Text.Encoding.ASCII.GetString(Activity);
                ActivityString = ActivityString.Substring(0, Convert.ToInt32(ActivityLength[0]));
                IsOfficial = Active[0] == 255 ? true : false;

                Common.Info("You just found '" + ActivityString + "'. Is it official? " + IsOfficial.ToString());
                */

                if (ImportProjects.Checked) {
                    while (ADLfile.Position < ADLfile.Length) {
                        Timekeeper1Task Task = ReadTask(ADLfile);
                        string Message = String.Format("{0}\tCreateTime = {1}\tOfficial? {2}\n\n",
                            Task.TaskName, Task.CreateTime.ToString(), Task.IsOfficial.ToString());
                        //Common.Info(Message);
                        Console.AppendText(Message);

                        Classes.Project Project = new Classes.Project(Database);

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


                /*
                TimekeeperAdl Adl = ImportFile.ReadStruct<TimekeeperAdl>();

                string result = System.Text.Encoding.UTF8.GetString(Adl.Activity);

                Common.Info(Adl.ToString());
                */


                /*

                ImportFile.Position = 0;
                var Row = new byte[64];
                */

                //fs.Read(data, actualRead, 10 - actualRead);

                FileStream ADTFile = new FileStream(ImportFileName.Text + ".adt", FileMode.Open);

                while (ADTFile.Position < ADTFile.Length) {
                    Timekeeper1Bucket Bucket = ReadBucket(ADTFile);
                    string Message = String.Format("TaskDate = {0}\nTaskId = {1}\nTotalTime = {2}",
                        Bucket.TaskDate.ToString(), Bucket.TaskId.ToString(), Bucket.TotalTime.ToString());
                    //Common.Info(Message);
                }

                if (ImportEntries.Checked) {
                    String ADBFileName = ImportFileName.Text + ".adb";
                    Timekeeper.Info("Attempting to open " + ADBFileName);

                    var TotalLines = System.IO.File.ReadLines(ADBFileName).Count();

                    StreamReader ADBFile = new StreamReader(ADBFileName);
                    String Line;
                    int LineNo = 1;
                    while ((Line = ADBFile.ReadLine()) != null) {
                        ImportProgress.Value = (LineNo / TotalLines) * 100;
                        Application.DoEvents();
                        Timekeeper1Entry Entry = ReadEntry(Line);
                        if (Entry.Succeeded) {
                            Console.AppendText(Entry.StartTime + "\t'" + Entry.TaskName + "'\t" + Entry.Memo + "\n");

                            // A couple data conversions
                            TimeSpan ts = Entry.EndTime.Subtract(Entry.StartTime);
                            Classes.Project Project = new Classes.Project(Database, Entry.TaskName);

                            // Now create the Journal Entry
                            Classes.JournalEntry JournalEntry = new Classes.JournalEntry(Database);
                            JournalEntry.ProjectId = Project.ItemId;
                            JournalEntry.ActivityId = 1; // Default Activity
                            JournalEntry.StartTime = Entry.StartTime;
                            JournalEntry.StopTime = Entry.EndTime;
                            JournalEntry.Seconds = (long)ts.TotalSeconds;
                            JournalEntry.Memo = Entry.Memo;
                            JournalEntry.IsLocked = true;
                            // TODO: prompt for an Activity, Location, and/or Category to
                            // assign the new journal entry to.
                            JournalEntry.LocationId = 1; // Default Location
                            JournalEntry.CategoryId = 1; // Default Category
                            if (!JournalEntry.Create()) {
                                Common.Warn("There was an error starting the timer.");
                                return;
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
            }
        }

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

    public unsafe struct TimekeeperAdl
    {
        /*
        public DateTime ActivityId;
        public fixed char Activity[50];
        public bool Official;
        public bool Active;
        */
        public fixed byte ActivityId[9];
        public fixed byte Activity[51];
        public fixed byte Official[2];
        public fixed byte Active[2];
    }

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

    public struct Timekeeper1Task
    {
        public long TaskId;
        public string TaskName;
        public bool IsOfficial;
        public bool isActive;
        public DateTime CreateTime;
    }

    public struct Timekeeper1Bucket
    {
        public DateTime TaskDate;
        public long TaskId;
        public TimeSpan TotalTime;
    }

    public struct Timekeeper1Entry
    {
        public DateTime StartTime;
        public DateTime EndTime;
        public string TaskName;
        public string Memo;
        public bool Succeeded;
    }

    public static class StreamExtensions
    {
        public static T ReadStruct<T>(this Stream stream) where T : struct
        {
            var sz = Marshal.SizeOf(typeof(T));
            var buffer = new byte[sz];
            stream.Read(buffer, 0, sz);
            var pinnedBuffer = GCHandle.Alloc(buffer, GCHandleType.Pinned);
            var structure = (T)Marshal.PtrToStructure(
                pinnedBuffer.AddrOfPinnedObject(), typeof(T));
            pinnedBuffer.Free();
            return structure;
        }
    }

}
