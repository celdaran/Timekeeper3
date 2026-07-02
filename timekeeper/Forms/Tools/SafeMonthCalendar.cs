using System;
using System.Windows.Forms;

namespace Timekeeper.Forms.Tools
{
    public class SafeMonthCalendar : MonthCalendar
    {
        private bool isParentResizing = false;

        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);

            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.ResizeBegin -= ParentForm_ResizeBegin;
                parentForm.ResizeEnd -= ParentForm_ResizeEnd;

                parentForm.ResizeBegin += ParentForm_ResizeBegin;
                parentForm.ResizeEnd += ParentForm_ResizeEnd;
            }
        }

        private void ParentForm_ResizeBegin(object sender, EventArgs e)
        {
            isParentResizing = true;
        }

        private void ParentForm_ResizeEnd(object sender, EventArgs e)
        {
            isParentResizing = false;
            this.Invalidate();
        }

        // --- ADDED SNIPPET HERE ---
        protected override void OnLayout(LayoutEventArgs levent)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                try
                {
                    base.OnLayout(levent);
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Silently swallow the un-representable date math calculation 
                    // when it happens during layout recalculations under Wine
                }
            }
            else
            {
                base.OnLayout(levent);
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                if (isParentResizing)
                {
                    if (m.Msg == 0x000F || m.Msg == 0x0047 || m.Msg == 0x004E || m.Msg == 0x204E)
                    {
                        m.Result = IntPtr.Zero;
                        return;
                    }
                }

                if (m.Msg == 0x1150)
                {
                    m.Result = IntPtr.Zero;
                    return;
                }
            }

            try
            {
                base.WndProc(ref m);
            }
            catch (ArgumentOutOfRangeException) when (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                m.Result = IntPtr.Zero;
            }
        }
    }
}