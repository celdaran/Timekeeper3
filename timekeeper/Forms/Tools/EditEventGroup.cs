using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Timekeeper.Classes.Toolbox;

namespace Timekeeper.Forms.Tools
{
    public partial class EditEventGroup : Form
    {
        private long EventGroupId;

        public EditEventGroup()
        {
            InitializeComponent();
            EventGroupId = 0;
        }

        public EditEventGroup(long eventGroupId)
        {
            InitializeComponent();
            EventGroupId = eventGroupId;
            Classes.EventGroup EventGroup = new Classes.EventGroup(eventGroupId);
            EventGroupName.Text = EventGroup.Name;
            EventGroupDescription.Text = EventGroup.Description;
        }

        private void AcceptDialogButton_Click(object sender, EventArgs e)
        {
            Classes.EventGroup EventGroup = new Classes.EventGroup(this.EventGroupId);
            EventGroup.Name = EventGroupName.Text;
            EventGroup.Description = EventGroupDescription.Text;
            if (EventGroup.Save()) {
                DialogResult = DialogResult.OK;
            } else {
                Common.Warn("There was a problem creating the new Group");
            }

        }
    }
}
