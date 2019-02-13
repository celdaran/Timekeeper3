using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper.Forms.Shared
{
    public partial class EntryProperties : Form
    {
        private Classes.JournalEntry journalEntry;
        private Classes.Options options;

        public EntryProperties(Classes.JournalEntry journalEntry, Classes.Options options)
        {
            InitializeComponent();
            this.journalEntry = journalEntry;
            this.options = options;
        }

        private void EntryProperties_Load(object sender, EventArgs e)
        {
            wID.Text = this.journalEntry.JournalId.ToString();
            wStartTime.Text = this.journalEntry.StartTime.ToString(options.Advanced_DateTimeFormat);
            wStopTime.Text = this.journalEntry.StopTime.ToString(options.Advanced_DateTimeFormat);
            wCreatedOn.Text = this.journalEntry.CreateTime.ToString(options.Advanced_DateTimeFormat);
            wModifiedOn.Text = this.journalEntry.ModifyTime.ToString(options.Advanced_DateTimeFormat);
            wGUID.Text = this.journalEntry.JournalGuid.ToLower();
            wLockedFlag.Text = this.journalEntry.IsLocked ? "Yes" : "No";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
