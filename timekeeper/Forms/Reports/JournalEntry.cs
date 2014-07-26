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

using MarkdownSharp;
using Technitivity.Toolbox;

namespace Timekeeper.Forms.Reports
{
    public partial class JournalEntry : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private Classes.Options Options;
        private Classes.Widgets Widgets;

        private Classes.JournalEntryView ReportView;
        private Classes.JournalEntryView AutoSavedReportView;

        private Forms.Shared.Filtering FilterDialog;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public JournalEntry()
        {
            InitializeComponent();

            this.Options = Timekeeper.Options;
            this.ReportView = new Classes.JournalEntryView();
            this.AutoSavedReportView = new Classes.JournalEntryView();
            this.Widgets = new Classes.Widgets();
        }

        //---------------------------------------------------------------------
        // Events
        //---------------------------------------------------------------------

        private void Report_Load(object sender, EventArgs e)
        {
            // Restore window metrics
            Height = Options.Report_Height;
            Width = Options.Report_Width;
            Top = Options.Report_Top;
            Left = Options.Report_Left;

            // Load up saved Find and paint
            LoadAndRunReport(Options.State_LastReportViewId);

            if (ReportView.IsAutoSaved) {
                ReportView.Changed = true;
            }

            // Populate the list of Saved Views
            PopulateLoadMenu();
        }

        //----------------------------------------------------------------------

        private void Report_Activated(object sender, EventArgs e)
        {
            UpdateToolbar();
        }

        //----------------------------------------------------------------------

        private void Report_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ReportView.Changed) {
                if (Common.WarnPrompt("View has not been saved. Continue closing?") == DialogResult.No) {
                    e.Cancel = true;
                    return;
                }
            }
            // Save window metrics
            Options.Report_Height = Height;
            Options.Report_Width = Width;
            Options.Report_Top = Top;
            Options.Report_Left = Left;
        }

        //----------------------------------------------------------------------
        // Toolbar Commands
        //----------------------------------------------------------------------

        private void FilterButton_Click(object sender, EventArgs e)
        {
            // Re-instantiate just before opening. See comment surrounding the
            // only other instantiation of this object
            this.FilterDialog = new Forms.Shared.Filtering(ReportView.FilterOptions);

            ReportView.FilterOptions = this.Widgets.FilteringDialog(this,
                FilterDialog, ReportView.FilterOptions.FilterOptionsId);

            if (ReportView.FilterOptions.Changed) {
                ReportView.Changed = true;
                RunReport();
            }
        }

        //---------------------------------------------------------------------

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            RunReport(false);
        }

        //----------------------------------------------------------------------

        private void ClearViewButton_Click(object sender, EventArgs e)
        {
            if (this.Widgets.ClearViewCancelled(ReportView.Changed)) {
                return;
            }

            ReportView = new Classes.JournalEntryView();

            this.Widgets.SetViewTitleBar(this, "Report");
            ClearViewButton.Enabled = false;

            LoadAndRunReport(0);
        }

        //---------------------------------------------------------------------

        private void LoadViewButton_Click(object sender, EventArgs e)
        {
            ToolStripItem Item = (ToolStripItem)sender;
            Classes.BaseView View = (Classes.BaseView)Item.Tag;
            LoadAndRunReport(View.Id);
        }

        //----------------------------------------------------------------------

        private void SaveViewButton_Click(object sender, EventArgs e)
        {
            // Set Report-specific view options
            // (none)

            // Save view
            ReportView.Save(ReportView.FilterOptions.Changed, ReportView.FilterOptions.FilterOptionsId);

            // Post-save steps
            ReportView.Changed = false;
            this.Widgets.SetViewTitleBar(this, "Report", ReportView.Name);
        }

        //----------------------------------------------------------------------

        private void SaveViewAsButton_Click(object sender, EventArgs e)
        {
            ReportView = (Classes.JournalEntryView)this.Widgets.SaveViewDialog(this, "Report", ReportView);
            if (ReportView.Changed) {
                ReportView.Save(true); // When Saving As, always create a new FilterRow
                ReportView.Changed = false;
                PopulateLoadMenu();
                UpdateToolbar();
                Options.State_LastReportViewId = ReportView.Id;
            }
        }

        //----------------------------------------------------------------------

        private void ManageViewsButton_Click(object sender, EventArgs e)
        {
            Forms.Shared.ManageViews DialogBox = new Forms.Shared.ManageViews("ReportView");
            if (DialogBox.ShowDialog(this) == DialogResult.OK) {
                PopulateLoadMenu();
            }
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

        //----------------------------------------------------------------------
        // Internal Helpers
        //----------------------------------------------------------------------

        private void UpdateViewState(bool autoSaveView)
        {
            if ((ReportView.Id == 0) || ReportView.IsAutoSaved) {
                if (autoSaveView) {
                    AutoSaveView();
                }
            } else {
                if (ReportView.Changed) {
                    this.Widgets.SetViewTitleBar(this, "Report", ReportView.Name + "*");
                }
            }
            UpdateToolbar();
        }

        //----------------------------------------------------------------------

        private void AutoSaveView()
        {
            /*
                Yes, there's a high degree of copy/paste between Grid's AutoSaveView and
                here. I'm leaving that for a rainy day project. [CH, 2013-09-24]
            */
            AutoSavedReportView = new Classes.JournalEntryView("Unsaved View");

            bool NewView = false;

            if (AutoSavedReportView.Id == 0) {
                // This is the first time; so seed the new view
                AutoSavedReportView.Name = "Unsaved View";
                AutoSavedReportView.Description = "Unnamed, last-applied view";
                NewView = true;
            }

            // Overwrite FilterOptions with current FilterOptions
            long SavedFilterOptionsId = AutoSavedReportView.FilterOptions.FilterOptionsId;
            AutoSavedReportView.FilterOptions = ReportView.FilterOptions;
            if (ReportView.FilterOptions.FilterOptionsId > 0) {
                AutoSavedReportView.FilterOptions.FilterOptionsId = ReportView.FilterOptions.FilterOptionsId;
            } else {
                AutoSavedReportView.FilterOptions.FilterOptionsId = SavedFilterOptionsId;
            }

            // Now attempt to save (this is an upsert)
            if (AutoSavedReportView.Save(ReportView.FilterOptions.Changed, AutoSavedReportView.FilterOptions.FilterOptionsId)) {
                // Make sure the Last Saved ID is the current value
                Options.State_LastReportViewId = AutoSavedReportView.Id;

                // And copy it back into the current grid options
                ReportView = AutoSavedReportView;

                // Although this has technically been saved to the DB, treat it as though it hasn't
                ReportView.Changed = true;

                // Update title bar
                this.Widgets.SetViewTitleBar(this, "Report", ReportView.Name);
            } else {
                Timekeeper.Debug("Options not saved in AutoSaveView()");
            }

            if (NewView) {
                PopulateLoadMenu();
            }
        }

        //----------------------------------------------------------------------

        private void UpdateToolbar()
        {
            bool HasEntries = this.Widgets.UpdateToolbar(ToolStrip, (Classes.BaseView)ReportView);
        }

        //----------------------------------------------------------------------

        private void PopulateLoadMenu()
        {
            // Common functions
            this.Widgets.PopulateLoadMenu("ReportView", ToolStrip);

            // Report-specific function
            foreach (ToolStripItem Item in LoadViewMenuButton.DropDownItems) {
                Item.Click += new System.EventHandler(this.LoadViewButton_Click);
            }
        }

        //----------------------------------------------------------------------
        // Wrapper for the gridfind loading logic, followed by the actual 
        // running of the Report code.
        //----------------------------------------------------------------------

        private void LoadAndRunReport(long findViewId)
        {
            if (findViewId > 0) {
                // Load Last Saved Options
                ReportView.Load(findViewId);

                // This requires some explanation. It's definitely a hack but something
                // for which I don't currently have the time or energy to handle otherwise.
                // In short, the tree handling logic lies within the Filtering dialog box,
                // including the ImpliedProjects and ImpliedActivities. These structures
                // are the result of looking at the actually-checked values in the treeview
                // controls and returning the  list of ProjectId and ActivityId values that
                // are implied by the checkboxes. This information is required to properly
                // paint a just-loaded grid and it only lives in Forms.Shared.Filtering.
                // If we instantiate this form here, right after loading up a saved grid
                // view, then everything Just Works.

                this.FilterDialog = new Forms.Shared.Filtering(ReportView.FilterOptions);

                // Reflect loaded view in Title Bar
                this.Widgets.SetViewTitleBar(this, "Report", ReportView.Name);

                // Set this as the last run ID
                Options.State_LastReportViewId = findViewId;

                RunReport(false);
            } else {
                UpdateToolbar();
                RunReport(false);
            }
        }

        //---------------------------------------------------------------------
        // Main Report Generator
        //---------------------------------------------------------------------

        private void RunReport()
        {
            RunReport(true);
        }

        //---------------------------------------------------------------------

        private void RunReport(bool autoSaveView)
        {
            // TODO: reimplement this: GetOrderBy();
            string OrderBy = "j.StartTime"; 

            Table FindResults = ReportView.Results(OrderBy);

            int nPrevDay = 0;
            long nTotalSeconds = 0;
            long nDailySeconds = 0;

            String Body = "";

            foreach (Row row in FindResults) {
                long seconds = row["Seconds"];
                DateTime start = DateTime.Parse(row["StartTime"]);
                DateTime end = DateTime.Parse(row["StopTime"]);

                // Markup support
                /*
                string post = row["Memo"].Replace("\n", "<br/>");
                post = post.Replace("<br/>*", "<br/><li>");
                */

                Markdown MarkdownEngine = new Markdown();
                string post = MarkdownEngine.Transform(row["Memo"]);

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

                string hr = "";

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
                    start.AddHours(Options.Advanced_Other_MidnightOffset).ToString("HH:mm:ss"),
                    end.AddHours(Options.Advanced_Other_MidnightOffset).ToString("HH:mm:ss"),
                    Timekeeper.FormatSeconds(seconds), row["ActivityName"] + " / " + row["ProjectName"],
                    MemoArea, hr);
                Body += rpt;

                nTotalSeconds += seconds;
                nDailySeconds += seconds;
            }

            if (FindResults.Count > 0) {
                Body += "<hr/><b>Total Time</b>: " + Timekeeper.FormatSeconds(nTotalSeconds);
            } else {
                Body += "<p>No data matches reporting criteria.</p>";
            }

            try {
                //ResourceManager Resources = new ResourceManager(typeof(string));
                //ResourceManager Resources = new ResourceManager(typeof(Timekeeper));
                ResourceManager Resources = new ResourceManager("Timekeeper.Properties.Resources", typeof(JournalEntry).Assembly);

                //var loader = new Windows.ApplicationModel.Resources.ResourceLoader();
                //var farewell = loader.GetString("Farewell");

                string Styles = Resources.GetString("ReportCssTemplate");
                string Document = Resources.GetString("ReportTemplate");
                string TextFileTest = Resources.GetString("TextFileTest");
                string MetaTableName = Resources.GetString(Timekeeper.MetaTableName());

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

            //----------------------------------------------
            // UI Updates
            //----------------------------------------------

            //ResultCount.Text = FindResultsGrid.Rows.Count.ToString() + " entries found.";
            UpdateViewState(autoSaveView);

        }

        //---------------------------------------------------------------------
        // Private Helpers
        //---------------------------------------------------------------------

        /*
        private string GetOrderBy()
        {
            string OrderBy = GetOrderByInternal(FilterOptions.SortBy1);

            if (FilterOptions.SortBy2 > -1)
                OrderBy += ", " + GetOrderByInternal(FilterOptions.SortBy2);

            if (FilterOptions.SortBy3 > -1)
                OrderBy += ", " + GetOrderByInternal(FilterOptions.SortBy3);

            return OrderBy;
        }
        */

        //---------------------------------------------------------------------

        private string GetOrderByInternal(int selection)
        {
            string OrderBy = "";

            if (selection <= 1) {
                // If option isn't checked, or it's (none) or it's Date/Time
                // Yes, even "(none)" gets you a sort order . . .
                OrderBy = "j.StartTime";
            } else {
                // Otherwise, set the value accordingly
                switch (selection) {
                    case 2: OrderBy = "a.Name"; break;
                    case 3: OrderBy = "p.Name"; break;
                    case 4: OrderBy = "log.Seconds"; break;
                    case 5: OrderBy = "l.Name"; break;
                    case 6: OrderBy = "t.Name"; break;
                    case 7: OrderBy = "p.ExternalProjectNo"; break;
                    case 8: OrderBy = "log.JournalId"; break;
                }
            }

            return OrderBy;
        }


        //---------------------------------------------------------------------

    }
}
