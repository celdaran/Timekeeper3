using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper
{
    public partial class fReport : Form
    {
        private DBI data;
        private string fontName;
        private int fontSize;

        public fReport(DBI data, string fontName, int fontSize, int reportHeight, int reportWidth)
        {
            InitializeComponent();
            this.data = data;
            this.fontName = fontName;
            this.fontSize = fontSize;
            this.Height = reportHeight;
            this.Width = reportWidth;
        }

        private void fReport_Load(object sender, EventArgs e)
        {
            wPreset.Text = "Previous Day";

            string query = @"select distinct strftime('%Y-%m-%d', timestamp_s) as date from timekeeper order by date desc";
            Table rows = data.Select(query);

            if (rows.Count > 1) {
                wStartDate.Text = rows[1]["date"];
                wEndDate.Text = rows[1]["date"];
            }

            ActiveControl = wPreset;

            runReport();
        }

        private void wPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query;
            string today;
            string monday;

            switch (wPreset.Text) {
                case "Today":
                    today = Common.Today();
                    wStartDate.Text = today;
                    wEndDate.Text = today;
                    break;

                case "Previous Day":
                    query = @"select distinct strftime('%Y-%m-%d', timestamp_s) as date from timekeeper order by date desc";
                    Table rows = data.Select(query);
                    if (rows.Count > 1) {
                        wStartDate.Text = rows[1]["date"];
                        wEndDate.Text = rows[1]["date"];
                    }
                    break;

                case "Past Five Days":
                    TimeSpan ts = new TimeSpan(5, 0, 0, 0);
                    monday = DateTime.Now.Subtract(ts).ToString(Common.DATE_FORMAT);
                    today = Common.Today();
                    wStartDate.Text = monday;
                    wEndDate.Text = today;
                    break;
            }

            runReport();
        }

        private void runReport()
        {
            if (wStartDate.Text.CompareTo(wEndDate.Text) > 0) {
                Common.Info("Start date is set past end date.");
                return;
            }

            string startDate = wStartDate.Text + " 00:00:00";
            string endDate = wEndDate.Text + " 23:59:59";

            string query = String.Format(@"
                select
                    log.timestamp_s, log.timestamp_e, log.seconds, 
                    t.name as task_name, p.name as project_name,
                    log.pre_log, log.post_log
                from timekeeper log
                join tasks t on t.id = log.task_id
                join projects p on p.id = log.project_id
                where log.timestamp_s >= '{0}'
                  and log.timestamp_e <= '{1}'",
                startDate, endDate);

            Table rows = data.Select(query);

            wReport.Navigate("about:blank");

            string styles = String.Format(@"
                body, table {{
                    margin: 8px;
                    font-family: {0}, verdana, arial, helv, sans-serif;
                    font-size: {1}pt;
                    border-collapse: collapse;
                    empty-cells: show;}}", fontName, fontSize);

            string doc = String.Format(@"
                <html>
                  <head>
                    <title>Timekeeper Report</title>
                    <style>{0}</style>
                  </head>
                <body>", styles);

            int nPrevDay = 0;
            int nTotalSeconds = 0;
            int nDailySeconds = 0;

            foreach (Row row in rows)
            {
                int seconds = Convert.ToInt32(row["seconds"]);
                DateTime start = Convert.ToDateTime(row["timestamp_s"]);
                DateTime end = Convert.ToDateTime(row["timestamp_e"]);
                string pre = row["pre_log"].Replace("\n", "<br/>");
                string post = row["post_log"].Replace("\n", "<br/>");
                pre = pre.Replace("<br/>*", "<br/><li>");
                post = post.Replace("<br/>*", "<br/><li>");
                string hr = "";

                if (nPrevDay == start.DayOfYear)
                {
                    // no header if this entry is the same day as the previous
                }
                else
                {
                    if (nPrevDay != 0)
                    {
                        hr += "<p><b>Daily Total</b>: " + Common.FormatSeconds(nDailySeconds) + "</p>";
                    }
                    hr += "<hr /> <b>";
                    hr += start.ToString("dddd, MMMM dd, yyyy") + "</b>";
                    nDailySeconds = 0;
                }

                nPrevDay = start.DayOfYear;

                string rpt = String.Format(@"
                    {6}
                    <p>{0} - {1} (<b>{2}</b>): {3}</p>
                    <p>
                    <table cellpadding=""4"">
                        <tr height=""20"" valign=""top""><td><b>Pre:</b></td><td>{4}</td></tr>
                        <tr height=""20"" valign=""top""><td><b>Post:</b></td><td>{5}</td></tr>
                    </table>
                    </p>",
                    start.ToString("HH:mm:ss"), end.ToString("HH:mm:ss"),
                    Common.FormatSeconds(seconds), row["task_name"] + " / " + row["project_name"],
                    pre, post, hr);
                doc += rpt;

                nTotalSeconds += seconds;
                nDailySeconds += seconds;
            }
            doc += "<hr/><b>Total Time</b>: " + Common.FormatSeconds(nTotalSeconds);

            doc += "</body></html>";
            wReport.DocumentText = doc;
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            runReport();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            wReport.Print();
        }

        private void btnPrintSetup_Click(object sender, EventArgs e)
        {
            wReport.ShowPrintDialog();
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            wReport.ShowPrintPreviewDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Hide();
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fReport\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }


    }
}