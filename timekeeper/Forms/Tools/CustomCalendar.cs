using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms.Tools
{
    public partial class CustomCalendar : Form
    {
        public CustomCalendar()
        {
            InitializeComponent();
        }

        private void CustomCalendar_Load(object sender, EventArgs e)
        {
            Forms.Tools.CalendarMonth January = new Forms.Tools.CalendarMonth();
            January.Top = 100;
            January.Left = 100;
            this.Controls.Add(January);

            Forms.Tools.CalendarMonth February = new Forms.Tools.CalendarMonth();
            February.Top = 100;
            February.Left = January.Left + January.Width - 2;
            this.Controls.Add(February);

            /*
            Forms.Tools.CustomDataGridView CustomGrid = new Forms.Tools.CustomDataGridView();
            CustomGrid.Top = 100;
            CustomGrid.Left = 400;
            this.Controls.Add(CustomGrid);
            */
        }
    }
}
