using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Diagnostics;

using Technitivity.Toolbox;

// Big FIXME: forms shouldn't be doing any direct database access
// These should only operate on the underlying objects. That is,
// fLog should only access methods in the Log object. The Log object
// is then allowed to access the database.

namespace Timekeeper
{
    public partial class fLog : Form
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        public bool isTimerRunning;
        private bool isLocked;

        private DBI data;
        //private Log log; ==> fixme

        private long id;
        private long task_id;
        private long project_id;
        private long seconds;
        private DateTime timestamp_s;
        private DateTime timestamp_e;
        private string pre_log;
        private string post_log;
        private DateTime timestamp_s_current;

        private int oldWidth = 775;

        private bool isDirty;
        private string oldValue;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public fLog(DBI data)
        {
            InitializeComponent();
            this.data = data;
        }

        //---------------------------------------------------------------------
        // Form events
        //---------------------------------------------------------------------

        private void fLog_Load(object sender, EventArgs e)
        {
            try {
                string query;

                // hide the search panel
                this.Width = 500;
                splitContainer1.Panel2Collapsed = true;

                // Create tool tips
                ToolTip toolTip1 = new ToolTip();
                toolTip1.InitialDelay = 1000;
                toolTip1.ReshowDelay = 500;
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(this.btnCloseStartGap, "Set the start time to the end time of the previous entry");

                ToolTip toolTip2 = new ToolTip();
                toolTip2.InitialDelay = 1000;
                toolTip2.ReshowDelay = 500;
                toolTip2.ShowAlways = true;
                toolTip2.SetToolTip(this.btnCloseEndGap, "Set the end time to the start time of the next entry");

                // Begin unit of work
                data.Begin();

                // populate the comboboxes
                query = "select name from tasks where is_deleted = 0 and is_hidden = 0 and is_folder = 0 order by name";
                Table rows = data.Select(query);
                foreach (Row taskRow in rows)
                {
                    wTask.Items.Add(taskRow["name"]);
                }

                query = "select name from projects where is_deleted = 0 and is_hidden = 0 and is_folder = 0 order by name";
                rows = data.Select(query);
                foreach (Row projectRow in rows)
                {
                    wProject.Items.Add(projectRow["name"]);
                }

                // Initialize id with latest row
                SetLastId();
                if (id == 0) {
                    //Common.Info("There are no rows in the log.");
                    btnPrev.Enabled = false;
                    btnNext.Enabled = false;
                    btnFirst.Enabled = false;
                    btnLast.Enabled = false;
                    btnCloseStartGap.Enabled = false;
                    btnCloseEndGap.Enabled = false;
                    btnOK.Enabled = false;
                    return;
                }

                // Default search date pickers
                query = "select min(timestamp_s) from timekeeper";
                Row row = data.SelectRow(query);
                if (row["min(timestamp_s)"] != null) {
                    // Need to parse because the min() aggregater appears
                    // to be converting my value to a string.
                    DateTime dt = DateTime.Parse(row["min(timestamp_s)"]);
                    wFromDatePicker.Value = dt;
                }

                query = "select max(timestamp_s) as timestamp_s from timekeeper";
                row = data.SelectRow(query);
                if (row["timestamp_s"] != null) {
                    DateTime dt = DateTime.Parse(row["timestamp_s"]);
                    wToDatePicker.Value = dt;
                }

                // Disable Next/Last buttons
                btnLast.Enabled = false;
                btnNext.Enabled = false;

                // Show row
                DisplayRow();

                // Complete unit of work
                data.Commit();

                this.isDirty = false;
            }
            catch (Exception exception) {
                Common.Info("No file loaded.\n\n" + exception.ToString());
            }
        }

        //---------------------------------------------------------------------

        private void fLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true; // wait . . . is this necessary?
        }

        //---------------------------------------------------------------------
        // Control events
        //---------------------------------------------------------------------

        private void btnOK_Click(object sender, EventArgs e)
        {
            try {
                if (isLocked && isTimerRunning) {
                    SaveRow(false);
                } else {
                    SaveRow(true);
                }
                Hide();
            }
            catch {
            }
        }

        //---------------------------------------------------------------------

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Hide();
        }

        //---------------------------------------------------------------------

        private void btnPrev_Click(object sender, EventArgs e)
        {
            try {
                SaveRow(false);
                SetPrevId();
                if (id > 0) {
                    DisplayRow();
                    btnLast.Enabled = true;
                    btnNext.Enabled = true;
                    if (AtBeginning()) {
                        btnFirst.Enabled = false;
                        btnPrev.Enabled = false;
                    }
                } else {
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                }
            }
            catch {
            }
        }

        //---------------------------------------------------------------------

        private void btnNext_Click(object sender, EventArgs e)
        {
            try {
                SaveRow(false);
                SetNextId();
                if (id > 0) {
                    DisplayRow();
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                    if (AtEnd()) {
                        btnLast.Enabled = false;
                        btnNext.Enabled = false;
                    }
                } else {
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            catch {
            }
        }

        //---------------------------------------------------------------------

        private void btnLast_Click(object sender, EventArgs e)
        {
            try {
                SaveRow(false);
                SetLastId();
                if (id > 0) {
                    DisplayRow();
                    btnFirst.Enabled = true;
                    btnPrev.Enabled = true;
                    btnLast.Enabled = false;
                    btnNext.Enabled = false;
                }
            }
            catch {
            }
        }

        //---------------------------------------------------------------------

        private void btnFirst_Click(object sender, EventArgs e)
        {
            try {
                SaveRow(false);
                SetFirstId();
                if (id > 0) {
                    DisplayRow();
                    btnLast.Enabled = true;
                    btnNext.Enabled = true;
                    btnFirst.Enabled = false;
                    btnPrev.Enabled = false;
                }
            }
            catch {
            }
        }

        //---------------------------------------------------------------------

        private void btnCloseStartGap_Click(object sender, EventArgs e)
        {
            try
            {
                // Update the control with previous end time
                wPrevStart.Text = _getPreviousEndTime();

                // Recalculate duration
                wDuration.Text = _calculateDuration();

                // Disable button (already done)
                btnCloseStartGap.Enabled = false;

                // And set dirty bit
                isDirty = true;
            }
            catch
            {
                Common.Info("Could not get previous row.");
            }
        }

        //---------------------------------------------------------------------

        private void btnCloseEndGap_Click(object sender, EventArgs e)
        {
            try
            {
                // Set next start date
                wPrevEnd.Text = _getNextStartTime(); 

                // And recalculate duration
                wDuration.Text = _calculateDuration();

                // Set dirty bit
                isDirty = true;
            }
            catch
            {
                Common.Info("Could not find next row.");
            }
        }

        //---------------------------------------------------------------------

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            Row row = new Row();
            row["is_locked"] = 0;

            data.Begin();
            data.Update("timekeeper", row, "id", id);
            DisplayRow();
            data.Commit();
        }

        //---------------------------------------------------------------------

        private void btnExpand_Click(object sender, EventArgs e)
        {
            try {
                if (splitContainer1.Panel2Collapsed) {
                    Width = oldWidth;
                    splitContainer1.Panel2Collapsed = false;
                    btnExpand.Text = "<< &Hide";
                } else {
                    splitContainer1.Panel2Collapsed = true;
                    oldWidth = Width;
                    Width = 500;
                    btnExpand.Text = "Searc&h >>";
                }
            }
            catch (Exception ee)
            {
                Common.Warn(ee.ToString());
            }
        }

        //---------------------------------------------------------------------

        private void btnGo_Click(object sender, EventArgs e)
        {
            try {
                wResults.Rows.Clear();

                string fromDate = wFromDatePicker.Value.ToString(Common.DATE_FORMAT) + " 00:00:00";
                string toDate = wToDatePicker.Value.ToString(Common.DATE_FORMAT) + " 23:59:59";

                if (fromDate.Length == 0) {
                    fromDate = "1900-01";
                }
                if (toDate.Length == 0) {
                    toDate = "2999-12";
                }

                // Begin unit of work
                data.Begin();

                string query = String.Format(@"
                    select
                        log.id, t.name as task_name, p.name as project_name,
                        log.timestamp_s, log.timestamp_e
                    from timekeeper log
                    join tasks t on t.id = log.task_id
                    join projects p on p.id = log.project_id
                    where log.timestamp_s >= '{0}'
                      and log.timestamp_e < '{1}'
                      and (log.pre_log like '%{2}%' or log.post_log like '%{2}%')",
                    fromDate, toDate, wSearchText.Text);
                Table rows = data.Select(query);

                if (rows.Count > 0) {
                    foreach (Row row in rows) {
                        string[] result = { row["id"].ToString(), row["timestamp_s"].ToString(), row["timestamp_e"].ToString(), row["task_name"], row["project_name"] };
                        wResults.Rows.Add(result);
                    }
                } else {
                    Common.Info("No log entries found matching criteria.");
                }

                // Complete unit of work
                data.Commit();
            }
            catch {
            }
        }

        //---------------------------------------------------------------------

        private void wResults_DoubleClick(object sender, EventArgs e)
        {
            try {
                DataGridViewRow row = wResults.SelectedRows[0];
                DataGridViewCell cell = row.Cells["log_id"];
                id = Convert.ToInt32(cell.Value);
                DisplayRow();
            }
            catch {
            }
        }

        //---------------------------------------------------------------------
        // Dirt handling
        //---------------------------------------------------------------------

        private void wEnterControl(object sender, EventArgs e)
        {
            this.oldValue = _getText(sender);
        }

        //---------------------------------------------------------------------

        private void wPrevEnd_TextChanged(object sender, EventArgs e)
        {
            if (!_controlChanged(sender)) {
                return;
            }
            wDuration.Text = _calculateDuration();
        }

        //---------------------------------------------------------------------

        private void wDuration_TextChanged(object sender, EventArgs e)
        {
            if (!_controlChanged(sender))
            {
                return;
            }
            // convert hh:mm:ss to datetime and add to start
            string[] parts = wDuration.Text.Split(':');
            // todo: support partial parts (one part => ss, two => mm:ss ...)
            // error handling would be nice too (e.g., four parts!?)
            int h = Convert.ToInt32(parts[0]) * 3600;
            int m = Convert.ToInt32(parts[1]) * 60;
            int s = Convert.ToInt32(parts[2]);
            seconds = h + m + s;
            timestamp_e = timestamp_s.AddSeconds(Convert.ToDouble(seconds));

            // display to user
            wPrevEnd.Text = timestamp_e.ToString(Common.DATETIME_FORMAT);
        }

        //---------------------------------------------------------------------

        private void wLeaveControl(object sender, EventArgs e)
        {
            _controlChanged(sender);
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private void DisplayRow()
        {
            // FIXME: in general, if I haven't said it already, let's get rid
            // of direct SQL access inside forms. This kind of stuff should
            // be done at a business objects level or otherwise segregated 
            // from the presentation layer. (Added as Bug Number #1218.)

            try {
                // Now get some real log data
                string query = @"
                select
                    log.task_id, t.name as task_name,
                    log.project_id, p.name as project_name,
                    log.timestamp_s, log.timestamp_e, 
                    log.seconds, log.pre_log, log.post_log,
                    log.is_locked
                from timekeeper log
                join tasks t on t.id = log.task_id
                join projects p on p.id = log.project_id
                where log.id = " + id;
                Row row = data.SelectRow(query);

                if (row["task_id"] == null) {
                    // all out of rows
                    return;
                }

                try {
                    // Save values in object members
                    task_id = row["task_id"];
                    project_id = row["project_id"];
                    seconds = row["seconds"];
                    timestamp_s = row["timestamp_s"];
                    if (row["timestamp_e"] != null)
                        timestamp_e = row["timestamp_e"];
                    pre_log = row["pre_log"];
                    post_log = row["post_log"];

                    wPrevStart.Text = timestamp_s.ToString(Common.DATETIME_FORMAT);
                    if (row["timestamp_e"] != null)
                        wPrevEnd.Text = timestamp_e.ToString(Common.DATETIME_FORMAT);

                    wDuration.Text = Timekeeper.FormatSeconds(seconds);
                    wPrevLog.Text = pre_log;
                    wPostLog.Text = post_log;
                    wTask.Text = row["task_name"];
                    wProject.Text = row["project_name"];

                    wID.Text = id.ToString();

                    if (row["is_locked"]) {
                        isLocked = true;
                        wPrevStart.Enabled = false;
                        wPrevEnd.Enabled = false;
                        wDuration.Enabled = false;
                        wPrevLog.Enabled = false;
                        wPostLog.Enabled = false;
                        wTask.Enabled = false;
                        wProject.Enabled = false;
                        btnUnlock.Visible = isTimerRunning ? false : true;
                    } else {
                        isLocked = false;
                        wPrevStart.Enabled = true;
                        wPrevEnd.Enabled = true;
                        wDuration.Enabled = true;
                        wPrevLog.Enabled = true;
                        wPostLog.Enabled = true;
                        wTask.Enabled = true;
                        wProject.Enabled = true;
                        btnUnlock.Visible = false;
                    }

                    // Disable close gap buttons if no gap to close
                    string prevEndTime = _getPreviousEndTime();
                    if (prevEndTime == wPrevStart.Text) {
                        btnCloseStartGap.Enabled = false;
                    } else {
                        if (prevEndTime == "") {
                            btnCloseStartGap.Enabled = false;
                        } else {
                            btnCloseStartGap.Enabled = true;
                        }
                    }

                    string nextStartTime = _getNextStartTime();
                    if (nextStartTime == wPrevEnd.Text) {
                        btnCloseEndGap.Enabled = false;
                    } else {
                        btnCloseEndGap.Enabled = true;
                    }

                }
                catch (Exception ee) {
                    Common.Warn(ee.ToString());
                }
            }
            catch {
            }
        }

        //---------------------------------------------------------------------

        private void SaveRow(bool forceSave)
        {
            if (!forceSave) {
                if (!this.isDirty) {
                    return;
                }
            }

            if ((wPrevStart.Text == "") && (wPrevEnd.Text == "")) {
                // Bail if there's obviously no work to do
                return;
            }

            String query;

            // Begin unit of work
            data.Begin();

            // convert form data
            try {
                // set fixed fields
                timestamp_s = Convert.ToDateTime(wPrevStart.Text);
                timestamp_e = Convert.ToDateTime(wPrevEnd.Text);
                TimeSpan ts = timestamp_e.Subtract(timestamp_s);
                seconds = (long)ts.TotalSeconds;

                // set lookup fields
                string tmp = wTask.Text;
                tmp = tmp.Replace("'", "''");
                query = String.Format(@"select id from tasks where name = '{0}'", tmp);
                Row lookup = data.SelectRow(query);
                task_id = Convert.ToInt32(lookup["id"]);

                tmp = wProject.Text;
                tmp = tmp.Replace("'", "''");
                query = String.Format(@"select id from projects where name = '{0}'", tmp);
                lookup = data.SelectRow(query);
                project_id = Convert.ToInt32(lookup["id"]);
            }
            catch (Exception ee) {
                // Um, don't do this . . .
                Common.Warn(ee.ToString());
            }

            // now do the update
            Row row = new Row();

            row["timestamp_s"] = timestamp_s.ToString(Common.DATETIME_FORMAT);
            row["timestamp_e"] = timestamp_e.ToString(Common.DATETIME_FORMAT);
            row["seconds"] = seconds;
            row["pre_log"] = wPrevLog.Text;
            row["post_log"] = wPostLog.Text;
            row["task_id"] = task_id;
            row["project_id"] = project_id;

            data.Update("timekeeper", row, "id", wID.Text);

            // Commit unit of work
            data.Commit();

            // Cleanup
            this.isDirty = false;
        }

        //---------------------------------------------------------------------
        // Row location testers
        //---------------------------------------------------------------------

        private bool AtEnd()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper 
                order by timestamp_s desc 
                limit 1");
            Row row = data.SelectRow(query);
            if ((row["id"] != null) && (row["id"] == this.id)) {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------

        private bool AtBeginning()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper 
                order by timestamp_s asc 
                limit 1");
            Row row = data.SelectRow(query);
            if ((row["id"] != null) && (row["id"] == this.id)) {
                return true;
            } else {
                return false;
            }
        }

        //---------------------------------------------------------------------
        // ID values
        // Remember that the id does not imply chronology. Backfills, data 
        // migrations, and other data changes can create "out of order" id 
        // values. The value of timestamp_s is authoritative.
        //---------------------------------------------------------------------

        private void SetLastId()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper 
                order by timestamp_s desc 
                limit 1");
            _SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetFirstId()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper 
                order by timestamp_s asc 
                limit 1");
            _SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetPrevId()
        {
            string query = String.Format(@"
                select id, timestamp_s from timekeeper
                where timestamp_s < '{0}'
                order by timestamp_s desc
                limit 1",
            this.timestamp_s_current.ToString(Common.DATETIME_FORMAT));
            _SetId(query);
        }

        //---------------------------------------------------------------------

        private void SetNextId()
        {
            if (this.timestamp_s_current == DateTime.MinValue)
                return;
            string query = String.Format(@"
                select id, timestamp_s from timekeeper
                where timestamp_s > '{0}'
                order by timestamp_s asc
                limit 1",
            this.timestamp_s_current.ToString(Common.DATETIME_FORMAT));
            _SetId(query);
        }

        //---------------------------------------------------------------------

        private void _SetId(string query)
        {
            var s = new Stopwatch();
            s.Start();

            try {
                Row row = data.SelectRow(query);
                this.id = row["id"];
                this.timestamp_s_current = row["timestamp_s"];
            }
            catch {
                this.id = 0;
                this.timestamp_s_current = DateTime.MinValue;
            }

            s.Stop();
            // Helpful debugging step
            // this.Text = "Elapsed time " + s.ElapsedMilliseconds.ToString();
        }

        //---------------------------------------------------------------------

        private string _getText(object sender)
        {
            if (sender.GetType().Name == "TextBox") {
                TextBox tb = (TextBox)sender;
                return tb.Text;
            }
            else if (sender.GetType().Name == "RichTextBox") {
                RichTextBox tb = (RichTextBox)sender;
                return tb.Text;
            }
            else if (sender.GetType().Name == "ComboBox") {
                ComboBox cb = (ComboBox)sender;
                return cb.Text;
            } 
            else {
                return "Unsupported Control Found";
            }
        }

        private bool _controlChanged(object sender)
        {
            string newValue = _getText(sender);

            if (this.oldValue != newValue) {
                this.isDirty = true;
                return true;
            }
            else {
                return false;
            }
        }

        private string _calculateDuration()
        {
            try
            {
                timestamp_s = Convert.ToDateTime(wPrevStart.Text);
                timestamp_e = Convert.ToDateTime(wPrevEnd.Text);
                TimeSpan ts = timestamp_e.Subtract(timestamp_s);
                seconds = (long)ts.TotalSeconds;
                return Timekeeper.FormatSeconds(seconds);
            }
            catch
            {
                Common.Warn("Unrecognized date/time format.");
                return "00:00:00";
            }
        }

        private string _getPreviousEndTime()
        {
            try {
                // Get the previous row
                string query = "select max(id) as prev_id from timekeeper where id < " + id;
                Row row = data.SelectRow(query);

                query = "select timestamp_e from timekeeper where id = " + row["prev_id"];
                row = data.SelectRow(query);

                // Return standard-formatted string
                DateTime prevEnd;
                prevEnd = row["timestamp_e"];
                return prevEnd.ToString(Common.DATETIME_FORMAT);
            }
            catch {
                // something went wrong, let's just ignore it
                return "";
            }
        }

        private string _getNextStartTime()
        {
            try
            {
                // Get the next row
                string query = "select min(id) as next_id from timekeeper where id > " + id;
                Row row = data.SelectRow(query);

                // Did we get one?
                DateTime nextBegin;
                if (row["next_id"] == null) {
                    // If not, use current date time
                    nextBegin = DateTime.Now;
                } else {
                    query = "select timestamp_s from timekeeper where id = " + row["next_id"];
                    row = data.SelectRow(query);
                    nextBegin = row["timestamp_s"];
                }

                // Return standard-formatted string
                return nextBegin.ToString(Common.DATETIME_FORMAT);
            }
            catch
            {
                // something went wrong, let's just ignore it
                return "";
            }
        }

        //---------------------------------------------------------------------
        // Context-sensitive help
        //---------------------------------------------------------------------

        private void widget_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            Control c = (Control)sender;
            string topic = String.Format("html\\context\\fLog\\{0}.html", c.Name);
            Help.ShowHelp(this, "timekeeper.chm", HelpNavigator.Topic, topic);
        }

        //---------------------------------------------------------------------
        // End of fLog
        //---------------------------------------------------------------------

    }
}