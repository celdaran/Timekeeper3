//-----------------------------------------------------------------------------
// Log.cs
// Simple Logging Facility
// Copyright © 2013 by Technitivity, a division of Lockshire Media, LLC.
//-----------------------------------------------------------------------------
// DESCRIPTION
//
// This class provides a simple, lightweight interface for writing log messages
// to files in a consistent manner.
//-----------------------------------------------------------------------------
// LICENCE
//
// This file is part of Technitivity's Toolbox Project. This is free software:
// You can you can redistribute it and/or modify it under the terms of the GNU 
// General Public License as published by the Free Software Foundation, either 
// version 3 of the License, or (at your option) any later version.
//
// Technitivity Toolbox is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for 
// more details: http://www.gnu.org/licenses/
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Threading;

namespace Timekeeper.Classes.Toolbox
{
    public class Log
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        // Public Constants
        public const int DEBUG = 7;
        public const int INFO = 6;
        public const int WARN = 4;
        public const int ERROR = 3;
        public const int NONE = -1;

        // Public Properties
        public string Tag { get; set; }
        public string LastLine { get; private set; }
        public int Level { get; set; }

        // Private Properties
        private string FileName;
        private string FallbackFileName;
        private string DateTimeFormat;
        private bool UseUtc;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Log(string fileName)
            : this(fileName, Common.UTC_DATETIME_FORMAT, false)
        {
        }

        //---------------------------------------------------------------------

        public Log(string fileName, string dateTimeFormat)
            : this(fileName, dateTimeFormat, false)
        {
        }

        //---------------------------------------------------------------------

        public Log(string fileName, string dateTimeFormat, bool useUtc)
        {
            this.FileName = fileName;
            this.DateTimeFormat = dateTimeFormat;
            this.UseUtc = useUtc;
        }

        //---------------------------------------------------------------------
        // Write methods
        //---------------------------------------------------------------------

        public void Debug(string message)
        {
            Write(message, DEBUG);
        }

        //---------------------------------------------------------------------

        public void Error(string message)
        {
            Write(message, ERROR);
        }

        //---------------------------------------------------------------------

        public void Info(string message)
        {
            Write(message, INFO);
        }

        //---------------------------------------------------------------------

        public void Warn(string message)
        {
            Write(message, WARN);
        }

        //---------------------------------------------------------------------
        // File IO
        //---------------------------------------------------------------------

        private void Write(string message, int requestedLevel)
        {
            if (requestedLevel <= Level) {
                try {
                    string levelText;
                    switch (requestedLevel) {
                        case DEBUG: levelText = "DEBUG"; break;
                        case INFO: levelText = "INFO"; break;
                        case WARN: levelText = "WARN"; break;
                        case ERROR: levelText = "ERROR"; break;
                        default: levelText = "UNKNOWN"; break;
                    }

                    string Timestamp = this.UseUtc ?
                        DateTime.UtcNow.ToString(this.DateTimeFormat) :
                        DateTime.Now.ToString(this.DateTimeFormat);

                    if (this.Tag == null) {
                        message = String.Format("{0} [{1}]: {2}", Timestamp, levelText, message);
                    } else {
                        message = String.Format("{0} [{1}]: [{2}] {3}", Timestamp, levelText, this.Tag, message);
                    }

                    int ThreadId = Thread.CurrentThread.ManagedThreadId;
                    message = String.Format("{0} (ThreadId: {1})", message, ThreadId);

                    StreamWriter writer = new StreamWriter(this.FileName, true);
                    writer.WriteLine(message);
                    writer.Close();

                    this.LastLine = message;
                }
                catch (Exception x) {
                    // In an emergency, write out our message *somewhere*
                    if (this.FallbackFileName == null) {
                        string RandomFile = Path.GetTempFileName();
                        FileInfo Info = new FileInfo(RandomFile);
                        string TempFileName = "Timekeeper.ExceptionLog." + Info.Name;
                        RandomFile = Info.Directory + "/" + TempFileName;
                        this.FallbackFileName = RandomFile;
                    }

                    StreamWriter writer = new StreamWriter(this.FallbackFileName, true);
                    writer.WriteLine(message + " [EXCEPTION: " + x.Message + "]");
                    writer.Close();
                }

            }
        }

        //---------------------------------------------------------------------

    }
}
