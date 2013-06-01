using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;

using Technitivity.Toolbox;

namespace Timekeeper.Forms
{
    public partial class Report : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Database;

        private Classes.FilterOptions FilterOptions = new Classes.FilterOptions();

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Report()
        {
            InitializeComponent();
        }

        //---------------------------------------------------------------------
        // Events
        //---------------------------------------------------------------------

        private void Report_Load(object sender, EventArgs e)
        {
            this.Database = Timekeeper.Database;

            // I'm having trouble getting the default report to paint, this
            // hack fixes that by sending the paint work to a different code path.
            //TimerHack.Start();

            RunReport();

            // TODO: set window metrics
        }

        //---------------------------------------------------------------------

        private void FilterButton_Click(object sender, EventArgs e)
        {
            Forms.Filtering Dialog = new Forms.Filtering(FilterOptions);

            if (Dialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
                FilterOptions = Dialog.FilterOptions;
                RunReport();
            } else {
                // Uh, why?
                //FilterOptions.Clear();
            }
            Dialog.Dispose();
        }

        //---------------------------------------------------------------------

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunReport();
        }

        //---------------------------------------------------------------------

        private void PrintReportButton_Click(object sender, EventArgs e)
        {
            ReportWindow.Print();
        }

        //---------------------------------------------------------------------

        private void PrintSetupButton_Click(object sender, EventArgs e)
        {
            ReportWindow.ShowPageSetupDialog();
        }

        //---------------------------------------------------------------------

        private void PrintPreviewButton_Click(object sender, EventArgs e)
        {
            ReportWindow.ShowPrintPreviewDialog();
        }

        //---------------------------------------------------------------------

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        //---------------------------------------------------------------------

        private void TimerHack_Tick(object sender, EventArgs e)
        {
            //TimerHack.Stop();
            Common.Warn("TimerHack still going off");
            RunReport();
        }

        //---------------------------------------------------------------------
        // Main Report Generator
        //---------------------------------------------------------------------

        private void RunReport()
        {
            string WhereClause = GetWhereClause();
            string OrderBy = GetOrderBy();

            string Query = String.Format(@"
                select
                    log.StartTime, log.StopTime, log.Seconds, 
                    a.Name as task_name, p.Name as project_name,
                    log.Memo
                from Journal log
                join Activity a on a.ActivityId = log.ActivityId
                join Project p on p.ProjectId = log.ProjectId
                left join Location l on l.LocationId = log.LocationId
                left join Tag t on t.TagId = log.TagId
                where {0}
                order by {1}",
                WhereClause, OrderBy);

            //Common.Info(Query);

            Table Rows = Database.Select(Query);

            int nPrevDay = 0;
            long nTotalSeconds = 0;
            long nDailySeconds = 0;

            String Body = "";

            foreach (Row row in Rows) {
                long seconds = row["Seconds"];
                DateTime start = row["StartTime"];
                DateTime end = row["StopTime"];
                string post = row["Memo"].Replace("\n", "<br/>");
                post = post.Replace("<br/>*", "<br/><li>");
                string hr = "";

                string[] MemoParts = post.Split(new string[] { "<br/><br/><!--SEPARATOR--><br/><br/>" }, StringSplitOptions.RemoveEmptyEntries);
                string MemoArea = "";
                int index = 1;
                if (MemoParts.Count() > 1) {
                    foreach (string MemoPart in MemoParts) {
                        MemoArea += String.Format(@"<p class=""memo""><b>Part {0}</b>: {1}</p>", index++, MemoPart);
                    }
                } else if (MemoParts.Count() > 0) {
                    MemoArea = String.Format(@"<p class=""memo"">{0}</p>", MemoParts[0]);
                } else {
                    MemoArea = String.Format(@"<p class=""memo"">{0}</p>", MemoArea);
                }

                /*
                string Pre = post.Substring(0, post.IndexOf("<br/><br/><!--SEPARATOR--><br/><br/>"));
                string Post = post.Substring(post.IndexOf("<br/><br/><!--SEPARATOR--><br/><br/>") + 36);
                Common.Info(MemoParts[0]);
                if (MemoParts.Count() > 1) {
                    Common.Info(MemoParts[1]);
                }
                */

                if (nPrevDay == start.DayOfYear) {
                    // no header if this entry is the same day as the previous
                } else {
                    if (nPrevDay != 0) {
                        hr += "<p><b>Daily Total</b>: " + Timekeeper.FormatSeconds(nDailySeconds) + "</p>";
                    }
                    hr += "<hr /> <b>";
                    hr += start.ToString("dddd, MMMM dd, yyyy") + "</b>";
                    nDailySeconds = 0;
                }

                nPrevDay = start.DayOfYear;

                string rpt = String.Format(@"
                    {5}
                    <p>{0} - {1} (<b>{2}</b>): {3}</p>
                    <p>{4}</p>",
                    start.ToString("HH:mm:ss"), end.ToString("HH:mm:ss"),
                    Timekeeper.FormatSeconds(seconds), row["task_name"] + " / " + row["project_name"],
                    MemoArea, hr);
                Body += rpt;

                nTotalSeconds += seconds;
                nDailySeconds += seconds;
            }

            if (Rows.Count > 0) {
                Body += "<hr/><b>Total Time</b>: " + Timekeeper.FormatSeconds(nTotalSeconds);
            } else {
                Body += "<p>No data matches reporting criteria.</p>";
            }

            try {
                //ResourceManager Resources = new ResourceManager(typeof(string));
                //ResourceManager Resources = new ResourceManager(typeof(Timekeeper));
                ResourceManager Resources = new ResourceManager("Timekeeper.Properties.Resources", typeof(Report).Assembly);

                //var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                //var farewell = loader.GetString("Farewell");

                string Styles = Resources.GetString("ReportCssTemplate");
                string Document = Resources.GetString("ReportTemplate");
                string TextFileTest = Resources.GetString("TextFileTest");
                string MetaTableName = Resources.GetString("AA9FFC4E_5CEB_4E3F_83FE_7EC5D1A33300");

                //Common.Info(Styles);
                //Common.Info(Document);
                //Common.Info(TextFileTest);
                //Common.Info(MetaTableName);

                Styles = String.Format(Styles, "Tahoma", "10");
                Document = String.Format(Document, "Timekeeper Report", Styles, Body);

                string filename = System.IO.Path.GetTempPath() + Timekeeper.IDENTIFIER + @".html";

                StreamWriter writer = new StreamWriter(filename);
                writer.Write(Document);
                writer.Close();

                ReportWindow.Navigate("file://" + filename);
                //ReportWindow.DocumentText = "<html><body>Hello</body></html>";
                //ReportWindow.DocumentText = doc;

                //ReportWindow.Document.OpenNew(true);
                //ReportWindow.Document.Write(doc);
                /*
                HtmlElement Html = ReportWindow.Document.CreateElement("html");
                HtmlElement Body = ReportWindow.Document.CreateElement("body");
                Html.AppendChild(Body);

                HtmlDocument Document = ReportWindow.Document;
                foreach (HtmlElement Element in Document.All) {
                    Common.Info(Element.InnerHtml);
                }
                */

                /*
                ReportWindow.Document.OpenNew(true);
                ReportWindow.DocumentText = "<html><body>Hello</body></html>";
                ReportWindow.Document.Write(doc);
                */
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }

        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        private string GetWhereClause()
        {
            string WhereClause = "";

            WhereClause += String.Format("log.StartTime >= '{0}'",
                FilterOptions.StartTimeToString()) + System.Environment.NewLine;

            WhereClause += String.Format("and log.StopTime <= '{0}'",
                FilterOptions.StopTimeToString()) + System.Environment.NewLine;

            if ((FilterOptions.ImpliedActivities != null) && (FilterOptions.ImpliedActivities.Count > 0)) {
                WhereClause += String.Format("and log.ActivityId in ({0})",
                    FilterOptions.List(FilterOptions.ImpliedActivities)) + System.Environment.NewLine;
            }
            if ((FilterOptions.ImpliedProjects != null) && (FilterOptions.ImpliedProjects.Count > 0)) {
                WhereClause += String.Format("and log.ProjectId in ({0})",
                    FilterOptions.List(FilterOptions.ImpliedProjects)) + System.Environment.NewLine;
            }
            if ((FilterOptions.Memo != null) && (FilterOptions.Memo != "")) {
                WhereClause += String.Format("and log.Memo like '%{0}%'", FilterOptions.Memo) + System.Environment.NewLine;
            }

            if (FilterOptions.DurationOperator > 0) {
                // Meaning, if anything but "Any" was selected

                WhereClause += "and log.Seconds ";

                switch (FilterOptions.DurationOperator) {
                    case 1: WhereClause += " > "; break;
                    case 2: WhereClause += " < "; break;
                    case 3: WhereClause += " = "; break;
                }

                WhereClause += FilterOptions.Seconds().ToString() + System.Environment.NewLine;
            }

            if ((FilterOptions.Locations != null) && (FilterOptions.Locations.Count > 0)) {
                WhereClause += String.Format("and log.LocationId in ({0})",
                    FilterOptions.List(FilterOptions.Locations)) + System.Environment.NewLine;
            }

            if ((FilterOptions.Tags != null) && (FilterOptions.Tags.Count > 0)) {
                WhereClause += String.Format("and log.TagId in ({0})",
                    FilterOptions.List(FilterOptions.Tags)) + System.Environment.NewLine;
            }

            return WhereClause;
        }

        //---------------------------------------------------------------------

        private string GetOrderBy()
        {
            string OrderBy = GetOrderByInternal(FilterOptions.SortBy1);

            if (FilterOptions.SortBy2 > -1)
                OrderBy += ", " + GetOrderByInternal(FilterOptions.SortBy2);

            if (FilterOptions.SortBy3 > -1)
                OrderBy += ", " + GetOrderByInternal(FilterOptions.SortBy3);

            return OrderBy;
        }

        //---------------------------------------------------------------------

        private string GetOrderByInternal(int selection)
        {
            string OrderBy = "";

            if (selection <= 1) {
                // If option isn't checked, or it's (none) or it's Date/Time
                // Yes, even "(none)" gets you a sort order . . .
                OrderBy = "log.StartTime";
            } else {
                // Otherwise, set the value accordingly
                switch (selection) {
                    case 2: OrderBy = "a.Name"; break;
                    case 3: OrderBy = "p.Name"; break;
                    case 4: OrderBy = "log.Seconds"; break;
                    case 5: OrderBy = "l.Name"; break;
                    case 6: OrderBy = "t.Name"; break;
                    case 7: OrderBy = "log.ExternalEntryId"; break;
                    case 8: OrderBy = "log.JournalEntryId"; break;
                }
            }

            return OrderBy;
        }

        //---------------------------------------------------------------------

    }
}
