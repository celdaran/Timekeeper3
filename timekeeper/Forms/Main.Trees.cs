using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    partial class Main
    {
        //---------------------------------------------------------------------
        // Helper class to break up fMain.cs into manageable pieces
        //---------------------------------------------------------------------

        public const int TREES_ITEM_CREATED = 0;
        public const int TREES_ERROR_CREATING_ITEM = -1;
        public const int TREES_DUPLICATE_ITEM = -2;

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------

        private void Trees_ShowRootLines()
        {
            Activities Activities = new Activities(Database);
            ActivityTree.ShowRootLines = Activities.HasParents();

            Projects Projects = new Projects(Database);
            ProjectTree.ShowRootLines = Projects.HasParents();
        }

        //---------------------------------------------------------------------

    }
}
