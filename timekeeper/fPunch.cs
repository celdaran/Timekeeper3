using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace Timekeeper
{
    public partial class fPunch : Form
    {
        DBI data;

        public fPunch(DBI data)
        {
            InitializeComponent();
            this.data = data;
            wDatePreset.SelectedIndex = 2;
        }


        private void fPunch_Load(object sender, EventArgs e)
        {
            _load_grid(sender, e);
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (wStartDate.Text.CompareTo(wEndDate.Text) > 0)
            {
                Common.Info("Start date is set past end date.");
                return;
            }

            _load_grid(sender, e);
        }


        private void wDatePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            _set_start_date();
        }


        private void _load_grid(object sender, EventArgs e)
        {
            // Clear rows
            wGrid.Rows.Clear();

            // Handle date ranges
            string sStartDate = wStartDate.Text + " 00:00:00";
            string sEndDate = wEndDate.Text + " 29:59:59";

            // Grab punch in/out times by day
            string query = String.Format(@"
                select strftime('%Y/%m/%d', timestamp_s) as day, min(timestamp_s) as punch_in, max(timestamp_e) as punch_out
                from timekeeper
                where timestamp_s >= '{0}'
                    and timestamp_s <= '{1}'
                group by day
                order by day",
                sStartDate, sEndDate);

            RowSet rows = data.select(query);
            foreach (Row row in rows)
            {
                DateTime punch_in = DateTime.Parse(row["punch_in"]);
                DateTime punch_out = DateTime.Parse(row["punch_out"]);
                TimeSpan ts = punch_out.Subtract(punch_in);
                string[] result = { row["day"], punch_in.ToString("HH:mm:ss"), punch_out.ToString("HH:mm:ss"), Common.FormatTimeSpan(ts) };
                wGrid.Rows.Add(result);
            }
        }


        // Move this to Common: a standard 
        // FIXME: copy/pasted from fGrid.cs -- ugh
        private void _set_start_date()
        {
            DateTime now = DateTime.Now;
            switch (wDatePreset.Text)
            {
                case "Today": wStartDate.Value = now; break;
                case "Last Five Days": wStartDate.Value = now.Subtract(new TimeSpan(24 * 5, 0, 0)); break;
                case "Last Seven Days": wStartDate.Value = now.Subtract(new TimeSpan(24 * 7, 0, 0)); break;
                case "This Month": wStartDate.Value = DateTime.Parse(now.Year.ToString() + "/" + now.Month.ToString() + "/1"); break;
                case "Year to Date": wStartDate.Value = DateTime.Parse(now.Year.ToString() + "/01/01"); break;
                case "All":
                    String query = @"select min(timestamp_s) as min from timekeeper";
                    Row row = data.selectRow(query);
                    wStartDate.Value = DateTime.Parse(row["min"]); break;
            }
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fPunch\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

    }
}
