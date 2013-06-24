using System;
using System.Collections.Generic;
using System.Text;

using Technitivity.Toolbox;

namespace Timekeeper.Classes
{
    class Diary
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        private DBI Data;

        //---------------------------------------------------------------------

        public int DiaryEntryId;
        public DateTime CreateTime;
        public DateTime ModifyTime;
        public string DiaryEntryGuid;

        private DateTime _EntryTime;
        private string _Memo;
        private int _LocationId;
        private int _CategoryId;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public Diary()
        {
            this.Data = Timekeeper.Database;
        }

        //---------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------

        public int Count()
        {
            string Query = "select count(*) as Count from Diary";
            Row Row = Data.SelectRow(Query);
            return (int)Row["Count"];
        }

        //---------------------------------------------------------------------

        public void Load(int diaryEntryId)
        {
            DiaryEntryId = diaryEntryId;

            try {
                Row Row = new Row();
                Row = this.Data.SelectRow("select * from Diary where DiaryEntryId = " + diaryEntryId);

                this.CreateTime = Row["CreateTime"];
                this.ModifyTime = Row["ModifyTime"];
                this.DiaryEntryGuid = Row["DiaryEntryGuid"];

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
            string Query = "select DiaryEntryId, EntryTime from Diary order by EntryTime";
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
            Row["DiaryEntryGuid"] = UUID.Get();

            Row["EntryTime"] = this.EntryTime.ToString(Common.DATETIME_FORMAT);
            Row["Memo"] = this.Memo;
            Row["LocationId"] = this.LocationId;
            Row["CategoryId"] = this.CategoryId;

            Data.Insert("Diary", Row);
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

            Data.Update("Diary", Row, "DiaryEntryId", this.DiaryEntryId);
        }

        //---------------------------------------------------------------------

    }
}
