using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Notebook
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Data;

        //---------------------------------------------------------------------

        public int NotebookId;
        public DateTime CreateTime;
        public DateTime ModifyTime;
        public string NotebookGuid;

        private DateTime _EntryTime;
        private string _Memo;
        private int _LocationId;
        private int _CategoryId;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Notebook()
        {
            this.Data = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        public int Count()
        {
            string Query = "select count(*) as Count from Notebook";
            Row Row = Data.SelectRow(Query);
            return (int)Row["Count"];
        }

        //---------------------------------------------------------------------

        public void Load(int notebookId)
        {
            NotebookId = notebookId;

            try {
                Row Row = new Row();
                Row = this.Data.SelectRow("select * from Notebook where NotebookId = " + notebookId);

                this.CreateTime = Row["CreateTime"];
                this.ModifyTime = Row["ModifyTime"];
                this.NotebookGuid = Row["NotebookGuid"];

                this._EntryTime = Row["EntryTime"];
                this._Memo = Row["Memo"];
                this._LocationId = Row["LocationId"];
                this._CategoryId = Row["CategoryId"];
            }
            catch (Exception x) {
                Timekeeper.Exception(x);
            }
        }

        //---------------------------------------------------------------------

        public Table Entries()
        {
            string Query = "select NotebookId, EntryTime from Notebook order by EntryTime";
            return Data.Select(Query);
        }

        //---------------------------------------------------------------------
        // Setter/Getters
        //---------------------------------------------------------------------

        public DateTime EntryTime
        {
            get { return _EntryTime; }
            set { _EntryTime = value; }
        }

        //---------------------------------------------------------------------

        public string Memo
        {
            get { return _Memo; }
            set { _Memo = value; }
        }

        //---------------------------------------------------------------------

        public int LocationId
        {
            get { return _LocationId; }
            set { _LocationId = value; }
        }

        //---------------------------------------------------------------------

        public int CategoryId
        {
            get { return _CategoryId; }
            set { _CategoryId = value; }
        }

        //---------------------------------------------------------------------
        // These are still in an experimental stage. I'm toying with different
        // ideas for less-generic database access. I'm not making any attempt
        // to genericize this approach yet until I have a better idea of what
        // I want to do with this long term.
        //---------------------------------------------------------------------

        public void Create()
        {
            Row Row = new Row();

            Row["CreateTime"] = Common.Now();
            Row["ModifyTime"] = Common.Now();
            Row["NotebookGuid"] = UUID.Get();

            Row["EntryTime"] = this.EntryTime.ToString(Common.DATETIME_FORMAT);
            Row["Memo"] = this.Memo;
            Row["LocationId"] = this.LocationId;
            Row["CategoryId"] = this.CategoryId;

            Data.Insert("Notebook", Row);
        }

        //---------------------------------------------------------------------

        public void Update()
        {
            Row Row = new Row();

            Row["ModifyTime"] = Common.Now();

            Row["EntryTime"] = this.EntryTime;
            Row["Memo"] = this.Memo;
            Row["LocationId"] = this.LocationId;
            Row["CategoryId"] = this.CategoryId;

            Data.Update("Notebook", Row, "NotebookId", this.NotebookId);
        }

        //---------------------------------------------------------------------

    }
}
