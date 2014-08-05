using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms.Tools
{
    public partial class CalendarMonth : UserControl
    {
        public DateTimeOffset CurrentDate { get; set; }

        public CalendarMonth()
        {
            InitializeComponent();

            foreach (DataGridViewColumn Column in MonthGrid.Columns) {
                Column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            MonthGrid.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            MonthGrid.Rows.Add("29", "30", "31", "1", "2", "3", "4");
            MonthGrid.Rows.Add("5", "6", "7", "8", "9", "10", "11");
            MonthGrid.Rows.Add("12", "13", "14", "15", "16", "17", "18");
            MonthGrid.Rows.Add("19", "20", "21", "22", "23", "24", "25");
            MonthGrid.Rows.Add("26", "27", "28", "29", "30", "31", "1");
            MonthGrid.Rows.Add("27", "", "", "", "", "", "", "");

            DataGridViewCellStyle Style = new DataGridViewCellStyle();
            Style.ForeColor = SystemColors.InactiveCaptionText;

            MonthGrid.Rows[0].Cells[0].Style = Style;
            MonthGrid.Rows[0].Cells[1].Style = Style;
            MonthGrid.Rows[0].Cells[2].Style = Style;
            MonthGrid.Rows[4].Cells[6].Style = Style;

            foreach (DataGridViewRow Row in MonthGrid.Rows) {
                //DataGridViewAdvancedCellBorderStyle Border = new DataGridViewAdvancedCellBorderStyle();
                //Row.Cells[0].AdjustCellBorderStyle = 

                DataGridViewAdvancedBorderStyle newStyle =
                    new DataGridViewAdvancedBorderStyle();
                newStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                newStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
                newStyle.Bottom = DataGridViewAdvancedCellBorderStyle.Outset;
                newStyle.Right = DataGridViewAdvancedCellBorderStyle.OutsetDouble;

                //Row.Cells[0].AdjustCellBorderStyle = newStyle;
            }

            for (int i = 0; i < MonthGrid.Rows.Count; i++) {
                MonthGrid.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }

        private void MonthGrid_KeyDown(object sender, KeyEventArgs e)
        {
            int selectedCellRow = MonthGrid.SelectedCells[0].RowIndex;
            int selectedCellColumn = MonthGrid.SelectedCells[0].ColumnIndex;

            if (e.KeyCode == Keys.Right) {
                if ((selectedCellColumn == 6) && (selectedCellRow < 5)) {
                    selectedCellColumn = 0;
                    selectedCellRow++;
                    MonthGrid.Rows[selectedCellRow].Cells[selectedCellColumn].Selected = true;
                    e.Handled = true;
                }
            }

            if (e.KeyCode == Keys.Left) {
                if ((selectedCellColumn == 0) && (selectedCellRow > 0)) {
                    selectedCellColumn = 6;
                    selectedCellRow--;
                    MonthGrid.Rows[selectedCellRow].Cells[selectedCellColumn].Selected = true;
                    e.Handled = true;
                }
            }
        }
    }

}
