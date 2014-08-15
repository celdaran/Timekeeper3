using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Technitivity.Toolbox;

namespace Timekeeper.Forms.Reports
{
    public partial class PunchCard : Forms.Shared.BaseView
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private Table PunchCardResults;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public PunchCard()
            : base()
        {
            InitializeComponent();
            InitializeComponentExtensions();

            // Define the things that make this form *this* form
            this.FilterOptionsType = Classes.FilterOptions.OptionsType.PunchCard;
            this.ViewName = "PunchCard";
            this.TableName = "PunchCardView";
            this.CurrentView = new Classes.PunchCardView();
            this.AutoSavedView = new Classes.PunchCardView();
            this.CurrentViewEmpty = new Classes.PunchCardView();
            this.AutoSavedViewEmpty = new Classes.PunchCardView("Unsaved View");

            // Then initialize the base class
            this.Initialize();
        }

        //---------------------------------------------------------------------

        private void InitializeComponentExtensions()
        {
        }

        //---------------------------------------------------------------------
        // Form Events
        //---------------------------------------------------------------------

        private void PunchCard_Load(object sender, EventArgs e)
        {
            // Restore window metrics
            Height = Options.PunchCard_Height;
            Width = Options.PunchCard_Width;
            Top = Options.PunchCard_Top;
            Left = Options.PunchCard_Left;
        }

        //---------------------------------------------------------------------

        private void PunchCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save window metrics
            Options.PunchCard_Height = Height;
            Options.PunchCard_Width = Width;
            Options.PunchCard_Top = Top;
            Options.PunchCard_Left = Left;

            // Save last view
            Options.State_LastPunchCardViewId = this.LastViewId;
        }

        //---------------------------------------------------------------------
        // Toolbar events
        //---------------------------------------------------------------------

        //---------------------------------------------------------------------
        // Private helpers
        //---------------------------------------------------------------------

        override internal void PopulateData()
        {
            PunchCardGrid.Rows.Clear();

            // At this point, this.CurrentView *should* be enough to get us
            // by, but it's not. So we need to instantiate a new, specific,
            // child-class. Then copy the FilterOptions into it.
            Classes.PunchCardView PunchCardView = new Classes.PunchCardView(this.CurrentView.Id);
            PunchCardView.FilterOptions.Copy(this.CurrentView.FilterOptions);

            // Now get the results
            this.PunchCardResults = PunchCardView.FilterResults();

            long TotalSeconds = 0;

            foreach (Row Result in PunchCardResults) {

                DateTime PunchIn = DateTime.Parse(Result["PunchIn"].ToString());
                DateTime PunchOut = DateTime.Parse(Result["PunchOut"].ToString());
                TimeSpan ts = PunchOut.Subtract(PunchIn);

                string[] GridRow = { 
                            Result["Day"].ToString(),
                            PunchIn.ToString("HH:mm:ss"), 
                            PunchOut.ToString("HH:mm:ss"), 
                            Timekeeper.FormatTimeSpan(ts) 
                        };
                PunchCardGrid.Rows.Add(GridRow);

                TotalSeconds += (long)ts.TotalSeconds;
            }

            string[] TotalRow = {
                        "Total",
                        "",
                        "",
                        Timekeeper.FormatSeconds(TotalSeconds)
                        };
            PunchCardGrid.Rows.Add(TotalRow);
        }

        //---------------------------------------------------------------------
    }
}
