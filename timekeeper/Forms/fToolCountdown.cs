using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Timekeeper
{
    public partial class fToolCountdown : Form
    {
        public fToolCountdown()
        {
            InitializeComponent();
        }

        private void wSeconds_ValueChanged(object sender, EventArgs e)
        {
            if (wSeconds.Value == 60) {
                wMinutes.Value++;
                wSeconds.Value = 0;
            }

            if (wSeconds.Value < 0) {
                if ((wHours.Value == 0) && (wMinutes.Value == 0)) {
                    wSeconds.Value = 0;
                } else {
                    wMinutes.Value--;
                    wSeconds.Value = 59;
                }
            }
        }

        private void wMinutes_ValueChanged(object sender, EventArgs e)
        {
            if (wMinutes.Value == 60)
            {
                wHours.Value++;
                wMinutes.Value = 0;
            }

            if (wMinutes.Value < 0) {
                if (wHours.Value > 0) {
                    wHours.Value--;
                    wMinutes.Value = 59;
                } else {
                    wMinutes.Value = 0;
                }
            }
        }
    }
}
