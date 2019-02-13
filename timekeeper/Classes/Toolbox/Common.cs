//-----------------------------------------------------------------------------
// Common.cs
// Static Class for Common Functionality
// Copyright © 2013 by Technitivity, a division of Lockshire Media, LLC.
//-----------------------------------------------------------------------------
// DESCRIPTION
//
// This class provides a small library of static methods to handle common
// functions such as error handling, consistent MessageBox display, and 
// date/time formatting.
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
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Configuration;

namespace Timekeeper.Classes.Toolbox
{
    public class Common
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        public const string DATE_FORMAT = "yyyy-MM-dd";
        public const string TIME_FORMAT = "HH:mm:ss";
        public const string LOCAL_DATETIME_FORMAT = "yyyy'-'MM'-'dd'T'HH':'mm':'ss";
        public const string UTC_DATETIME_FORMAT = LOCAL_DATETIME_FORMAT + "K";

        private static string _AssemblyName;

        //---------------------------------------------------------------------
        // Static Methods
        //---------------------------------------------------------------------

        public static string Abbreviate(string text, int length)
        {
            if (text.Length < length) {
                return text;
            } else {
                return text.Substring(0, length - 3) + "...";
            }
        }

        //---------------------------------------------------------------------

        public static string AssemblyName()
        {
            if (_AssemblyName == null) {
                _AssemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            }
            return _AssemblyName;

            /*
            string sectionName = "applicationSettings/" + executingAssembly + ".Properties.Settings";
            ClientSettingsSection section = (ClientSettingsSection)ConfigurationManager.GetSection(sectionName);

            // add null checking etc
            SettingElement setting = section.Settings.Get("Foo");
            AppName = setting.Value.ValueXml.InnerText;

            return AppName;

            NameValueCollection appSettings = ConfigurationManager.AppSettings;

            for (int i = 0; i < appSettings.Count; i++) {
                AppName += String.Format("#{0} Key: {1} Value: {2}",
                  i, appSettings.GetKey(i), appSettings[i]);
            }
            return AppName;

            ConnectionStringSettingsCollection connections = ConfigurationManager.ConnectionStrings;
            foreach (ConnectionStringSettings connection in connections) {
                AppName += connection.Name + ":";
            }
            return AppName;
            */

            //return Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetEntryAssembly().Location);
            /*
            System.Reflection.AssemblyName name = System.Reflection.Assembly.GetExecutingAssembly().GetName();
            return "AppName(): " + name.Name + " " + name.Version;
            */
        }

        //---------------------------------------------------------------------

        public static string Exception(Exception x)
        {
            return Exception(x, 2);
        }

        //---------------------------------------------------------------------

        public static string Exception(Exception x, int frameNo)
        {
            StackTrace StackTrace = new StackTrace();
            StackFrame StackFrame = StackTrace.GetFrame(frameNo);
            string msg = String.Format(@"Exception in {0}.{1}: {2}",
                StackFrame.GetMethod().DeclaringType, StackFrame.GetMethod().Name, x.Message);
            return msg;
        }

        //---------------------------------------------------------------------

        public static void Info(string msg)
        {
            MessageBox.Show(msg, AssemblyName(), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //---------------------------------------------------------------------

        public static void Warn(string msg)
        {
            MessageBox.Show(msg, AssemblyName(), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        //---------------------------------------------------------------------

        public static DialogResult Prompt(string msg)
        {
            return MessageBox.Show(msg, AssemblyName(), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        //---------------------------------------------------------------------

        public static DialogResult WarnPrompt(string msg)
        {
            return MessageBox.Show(msg, AssemblyName(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
        }

        //---------------------------------------------------------------------

        public static string Today()
        {
            return DateTime.Now.ToString(Common.DATE_FORMAT);
        }

        //---------------------------------------------------------------------

        public static string Now()
        {
            return UtcNow();
        }

        //---------------------------------------------------------------------

        public static string LocalNow()
        {
            return DateTime.Now.ToString(Common.LOCAL_DATETIME_FORMAT);
        }

        //---------------------------------------------------------------------

        public static string UtcNow()
        {
            return DateTime.UtcNow.ToString(Common.UTC_DATETIME_FORMAT);
        }

        //---------------------------------------------------------------------

        public static bool IsUpper(string input)
        {
            for (int i = 0; i < input.Length; i++) {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }

        //---------------------------------------------------------------------

        public static bool IsLower(string input)
        {
            for (int i = 0; i < input.Length; i++) {
                if (Char.IsLetter(input[i]) && !Char.IsLower(input[i]))
                    return false;
            }
            return true;
        }

        //---------------------------------------------------------------------

    }
}
