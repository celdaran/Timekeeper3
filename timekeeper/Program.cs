using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;

namespace Timekeeper
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (RequiredLibrariesFound()) {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Forms.Main(args));
            } else {
                MessageBox.Show("One or more required DLLs are missing. Cannot start application.", Timekeeper.TITLE);
            }
        }

        //-----------------------------------------------------------------------------

        static bool RequiredLibrariesFound()
        {
            bool found = true;

            try {
                // TODO: For TBX, support Semantic Versioning (http://semver.org/)
                // This would mean only checking the major version at this point.
                CheckAssembly("Technitivity.Toolbox", new Version(3, 0, 17));
                CheckAssembly("System.Data.SQLite", new Version(1, 0, 92));
            }
            catch {
                found = false;
            }

            return found;
        }

        //-----------------------------------------------------------------------------

        static void CheckAssembly(string name, Version version)
        {
            try {
                Assembly Assembly = Assembly.ReflectionOnlyLoadFrom(name + ".dll");
                string LoadedName = Assembly.GetName().Name;
                Version LoadedVersion = Assembly.GetName().Version;
                if (LoadedName == name &&
                    LoadedVersion.Major == version.Major &&
                    LoadedVersion.Minor == version.Minor &&
                    LoadedVersion.Build == version.Build) {
                } else {
                    throw new Exception("Name or version mismatch");
                }
            }
            catch {
                MessageBox.Show(name + ".dll (Version " + version + ") not found", Timekeeper.TITLE);
                throw;
            }
        }

        //-----------------------------------------------------------------------------

    }
}