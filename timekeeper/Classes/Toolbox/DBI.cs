//-----------------------------------------------------------------------------
// DBI.cs
// Database Interface for SQLite
// Copyright © 2013 by Technitivity, a division of Lockshire Media, LLC.
//-----------------------------------------------------------------------------
// DESCRIPTION
//
// This class provides a generally SQL-free interface to the SQLite embedded
// database system. It is a wrapper for System.Data.SQLite, simplifying data
// tasks with an intuitive object-oriented interface.
//
// For more information on SQLite: http://sqlite.org/
// For more information System.Data.SQLite: http://system.data.sqlite.org/
//-----------------------------------------------------------------------------
// LICENCE
//
// This file is part of Technitivity's Toolbox Project. This is free software:
// You can you can redistribute it and/or modify it under the terms of the GNU 
// General Public License as published by the Free Software Foundation, either 
// version 3 of the License, or (at your option) any later version.
//
// Technitivity Toolbox is distributed in the hope that it will be useful, but 
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY 
// or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for 
// more details: http://www.gnu.org/licenses/
//-----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Data.SQLite;
using System.Linq;

using System.Windows.Forms;

namespace Timekeeper.Classes.Toolbox
{
    public class DBI
    {
        //---------------------------------------------------------------------
        // Properties
        //---------------------------------------------------------------------

        // Public Properties
        private string _FileName;
        private bool _FileExists;
        private long _FileSize;

        // Private Properties
        private SQLiteConnection Connection;
        private SQLiteTransaction Transaction;
        private int TransactionDepth;

        private bool IsOpened;
        private int UnitOfWorkDepth;

        private Toolbox.Log Log;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public DBI(string dataFile) : this(dataFile, Log.NONE) {}
        // Potentially unuseful: consider using at least some level of logging.

        //---------------------------------------------------------------------

        public DBI(string dataFile, bool isLogging) : this(dataFile, Log.ERROR) {}
        // Deprecated: use DBI(string, int) or DBI(string, int, string) instead.
        // This is retained for backward compatability only.

        //---------------------------------------------------------------------

        public DBI(string dataFile, int logLevel) : this(dataFile, logLevel, dataFile + ".dbilog") {}
        // Gives you logging but with the default log file name. For full control
        // call the constructor below.

        //---------------------------------------------------------------------

        public DBI(string dataFile, int logLevel, string logFile)
        {
            // Set defaults
            this.FileName = dataFile;
            this.FileExists = false;

            // Open Log object with new file name
            this.Log = new Log(logFile);
            this.Log.Tag = "DBI";
            this.Log.Level = logLevel;

            this.Log.Debug("Init()");

            // Does the file exist?
            if (System.IO.File.Exists(this.FileName))
            {
                FileInfo fileinfo = new FileInfo(this.FileName);
                this.FileExists = fileinfo.Exists;
                this.FileSize = fileinfo.Length;
            }

            // Initialize UnitOfWorkDepth
            this.UnitOfWorkDepth = 0;
        }

        //---------------------------------------------------------------------
        // Public properties
        //---------------------------------------------------------------------

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value; }
        }

        //---------------------------------------------------------------------

        public bool FileExists
        {
            get { return _FileExists; }
            set { _FileExists = value; }
        }

        //---------------------------------------------------------------------

        public long FileSize
        {
            get { return _FileSize; }
            set { _FileSize = value; }
        }

        //---------------------------------------------------------------------
        // Private properties
        //---------------------------------------------------------------------

        private bool InUnitOfWork
        {
            get { return UnitOfWorkDepth > 0; }
        }

        //---------------------------------------------------------------------
        // Open / Close
        //---------------------------------------------------------------------

        private void Open()
        {
            if (this.InUnitOfWork)
                return;

            this.Log.Debug("Open(): called, IsOpened = " + this.IsOpened.ToString());

            if (this.IsOpened)
                return;

            string DataSource = "Data Source=" + this.FileName;
            Connection = new SQLiteConnection(DataSource);
            Connection.Open();

            this.Log.Debug("Open(): database " + FileName + " opened");

            this.Pragma("foreign_keys = ON");

            this.IsOpened = true;
            this.TransactionDepth = 0;
        }

        //---------------------------------------------------------------------

        private void Close()
        {
            if (this.InUnitOfWork)
                return;

            this.Log.Debug("Close(): called");

            if ((this.Transaction == null) && this.Connection != null)
            {
                this.Connection.Close();
                this.IsOpened = false;
                this.Connection = null;

                this.Log.Debug("Close(): database " + FileName + " closed");
            }
        }

        //---------------------------------------------------------------------

        private void Pragma(string pragma)
        {
            SQLiteCommand Command = Connection.CreateCommand();
            Command.CommandText = "PRAGMA " + pragma;
            Command.ExecuteNonQuery();
            Command.Dispose();
        }

        //---------------------------------------------------------------------
        // Transactions
        //---------------------------------------------------------------------

        public void Begin()
        {
            this.Open();

            if (this.TransactionDepth == 0) {
                this.Transaction = this.Connection.BeginTransaction();
                this.Log.Debug("Begin(): transaction started");
            }

            this.TransactionDepth++;
        }

        //---------------------------------------------------------------------

        public void Commit()
        {
            this.TransactionDepth--;

            if (this.TransactionDepth > 0)
                return;

            this.Transaction.Commit();
            this.Transaction = null;

            this.Log.Debug("Commit(): transaction committed");

            this.Close();
        }

        //---------------------------------------------------------------------

        public void Rollback()
        {
            this.Transaction.Rollback();
            this.Transaction = null;
            this.TransactionDepth = 0;

            this.Log.Debug("Rollback(): transaction rolled back");

            this.Close();
        }

        //---------------------------------------------------------------------

        public bool WithinTransaction()
        {
            return this.Transaction != null;
        }

        //---------------------------------------------------------------------
        // Units of Work
        //---------------------------------------------------------------------

        public void BeginWork()
        {
            Open();
            UnitOfWorkDepth++;
            this.Log.Debug("BeginWork(): UnitOfWorkDepth is " + UnitOfWorkDepth.ToString());
        }

        //---------------------------------------------------------------------

        public void EndWork()
        {
            UnitOfWorkDepth--;
            if (UnitOfWorkDepth < 0)
                this.Log.Warn("EndWork(): UnitOfWorkDepth is " + UnitOfWorkDepth.ToString());
            else
                this.Log.Debug("EndWork(): UnitOfWorkDepth is " + UnitOfWorkDepth.ToString());
            Close();
        }

        //---------------------------------------------------------------------
        // Select
        //---------------------------------------------------------------------

        public Table Select(string query)
        {
            Table Table = new Table();

            try {
                this.Log.Debug("Select(): " + query);

                Open();

                SQLiteCommand Command = Connection.CreateCommand();
                Command.CommandText = query;

                SQLiteDataReader Reader = Command.ExecuteReader();

                while (Reader.Read()) {
                    Row row = PopulateRow(Reader);
                    Table.Add(row);
                }

                Reader.Dispose();
                Command.Dispose();
            }
            catch (Exception e) {
                this.Log.Error(Common.Exception(e));
            }
            finally {
                Close();
            }

            return Table;
        }

        //---------------------------------------------------------------------

        public Row SelectRow(string query)
        {
            Row Row = new Row();

            try {
                this.Log.Debug("SelectRow(): " + query);

                Open();

                SQLiteCommand Command = Connection.CreateCommand();
                Command.CommandText = query;
                SQLiteDataReader Reader = Command.ExecuteReader();

                Reader.Read();

                Row = PopulateRow(Reader);

                Reader.Dispose();
                Command.Dispose();
            }
            catch (Exception e) {
                this.Log.Error(Common.Exception(e));
            }
            finally {
                Close();
            }

            return Row;
        }

        //---------------------------------------------------------------------

        private Row PopulateRow(SQLiteDataReader reader)
        {
            Row Row = new Row();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string Name;
                dynamic Value;

                Name = reader.GetName(i);
                if (reader.IsDBNull(i)) {
                    Value = null;
                } else {
                    try {
                        Value = reader.GetValue(i); //.ToString();
                    }
                    catch (Exception e) {
                        // if anything went wrong, just log
                        // the error, set the value to null
                        // and move on
                        this.Log.Error(Common.Exception(e) + " Column: " + Name);
                        Value = null;
                    }
                }

                Row.Add(Name, Value);
            }

            return Row;
        }

        //---------------------------------------------------------------------
        // Insert
        //---------------------------------------------------------------------

        public long Insert(string tableName, Row columns)
        {
            string Query = "";
            long Count = 0;
            long LastId = 0;

            try {
                Open();

                var ParameterizedColumns = new Row();

                // parameterize values
                foreach (string Key in columns.Keys) {
                    ParameterizedColumns["@" + Key] = columns[Key];
                }

                // build Insert statement
                Query = String.Format("INSERT INTO {0} (", tableName);
                Query += String.Join(",", columns.Keys.ToArray());
                Query += ") VALUES (";
                Query += String.Join(",", ParameterizedColumns.Keys.ToArray());
                Query += ")";

                SQLiteCommand Command = Connection.CreateCommand();
                Command.CommandText = Query;

                // now do the substituion
                foreach (string ColumnName in ParameterizedColumns.Keys) {
                    Command.Parameters.Add(ColumnName, DbType.String).Value =
                        ParameterizedColumns[ColumnName];
                }

                Count = (long)Command.ExecuteNonQuery();

                if (Count > 0) {
                    Command.CommandText = "SELECT last_insert_rowid()";
                    SQLiteDataReader Reader = Command.ExecuteReader();
                    Reader.Read();
                    LastId = Reader.GetInt64(0);
                    Reader.Dispose();
                }

                Command.Dispose();

                this.Log.Debug("Insert(): " + String.Format("row ({0}) inserted: {1}", LastId, Query));
            }
            catch (Exception e) {
                this.Log.Error(Common.Exception(e));
                this.Log.Debug("SQL: " + Query + "; Count = " + Count.ToString());
            }
            finally {
                Close();
            }

            return LastId;
        }

        //---------------------------------------------------------------------
        // Update
        //---------------------------------------------------------------------

        public long Update(string tableName, Row columns, string where)
        {
            string Query = "";
            string Pairs = "";
            long Count = 0;
            Row ParameterizedColumns = new Row();

            try {
                Open();

                // parameterize values
                foreach (string ColumnName in columns.Keys) {
                    ParameterizedColumns["@" + ColumnName] = columns[ColumnName];
                }

                // build pairs
                foreach (string ColumnName in columns.Keys) {
                    Pairs += String.Format("{0} = @{0},", ColumnName);
                }

                // strip trailing comma
                Pairs = Pairs.Substring(0, Pairs.Length - 1);

                // build Update statement
                Query = String.Format("UPDATE {0} SET ", tableName);
                Query += Pairs;
                Query += String.Format(" WHERE {0}", where);

                SQLiteCommand Command = Connection.CreateCommand();
                Command.CommandText = Query;

                this.Log.Debug("Update(): " + Query);

                // now do the substituion
                foreach (string ColumnName in ParameterizedColumns.Keys) {
                    Command.Parameters.Add(ColumnName, DbType.String).Value = 
                        ParameterizedColumns[ColumnName];
                }

                Count = Command.ExecuteNonQuery();

                Command.Dispose();
            }
            catch (Exception e) {
                this.Log.Error(Common.Exception(e));
                this.Log.Debug("SQL: " + Query + "; Count = " + Count.ToString());
            }
            finally {
                Close();
            }

            return Count;
        }

        //---------------------------------------------------------------------

        public long Update(string tableName, Row columns, string whereColumn, object whereValue)
        {
            whereValue = whereValue.ToString().Replace("'", "''");
            string where = String.Format("{0} = '{1}'", whereColumn, whereValue);
            return this.Update(tableName, columns, where);
        }

        //---------------------------------------------------------------------

        public long Update(string query)
        {
            return this.Exec("UPDATE " + query);
        }

        //---------------------------------------------------------------------
        // Delete
        //---------------------------------------------------------------------

        public long Delete(string tableName, string where)
        {
            string Query = "";
            long Count = 0;

            try {
                Open();

                // build Delete statement
                Query = String.Format("DELETE FROM {0} ", tableName);
                Query += String.Format("WHERE {0}", where);

                this.Log.Debug("Delete(): " + Query);

                SQLiteCommand Command = Connection.CreateCommand();
                Command.CommandText = Query;
                Count = Command.ExecuteNonQuery();
                Command.Dispose();
            }
            catch (Exception e) {
                this.Log.Error(Common.Exception(e));
                this.Log.Debug("SQL: " + Query + "; Count = " + Count.ToString());
            }
            finally {
                Close();
            }

            return Count;
        }

        //---------------------------------------------------------------------

        public long Delete(string tableName, string whereColumn, object whereValue)
        {
            whereValue = whereValue.ToString().Replace("'", "''");
            string where = String.Format("{0} = '{1}'", whereColumn, whereValue);
            return this.Delete(tableName, where);
        }

        //---------------------------------------------------------------------

        public long Delete(string query)
        {
            return this.Exec("DELETE FROM " + query);
        }

        //---------------------------------------------------------------------
        // Exec
        //---------------------------------------------------------------------

        public long Exec(string query)
        {
            int Count = 0;

            try {
                Open();

                this.Log.Debug("Exec(): " + query);

                SQLiteCommand Command = Connection.CreateCommand();
                Command.CommandText = query;
                Count = Command.ExecuteNonQuery();
                Command.Dispose();
            }
            catch (Exception e) {
                this.Log.Error(Common.Exception(e) + " Count: " + Count.ToString());
            }
            finally {
                Close();
            }

            return Count;
        }

        //---------------------------------------------------------------------
        // TablesExist
        //---------------------------------------------------------------------

        public bool TablesExist()
        {
            this.Log.Debug("TablesExist called");

            string query = "select count(*) as count from sqlite_master where type = 'table'";

            Row row = this.SelectRow(query);

            return row["count"] == 0 ? false : true;
        }

        //---------------------------------------------------------------------
        // TableExists
        //---------------------------------------------------------------------

        public bool TableExists(string tableName)
        {
            this.Log.Debug("TableExists called");

            // if the table name is in [this format] then remove the brackets
            tableName = tableName.Replace("[", "");
            tableName = tableName.Replace("]", "");

            string query = String.Format(
                "select count(*) from sqlite_master where type = 'table' and name = '{0}'",
                tableName);

            Row row = this.SelectRow(query);

            if (row["count(*)"] == 0) {
                return false;
            } else if (row["count(*)"] == 1) {
                return true;
            } else {
                this.Log.Debug("TableExists: row count was neither 0 nor 1");
                return false;
            }
        }

        //---------------------------------------------------------------------

    }

    //---------------------------------------------------------------------
    // Helper classes
    //---------------------------------------------------------------------

    public class Row : Dictionary<string, dynamic>
    {
    }

    //---------------------------------------------------------------------

    public class Table : List<Row>
    {
    }

    //---------------------------------------------------------------------
    // End of Class
    //---------------------------------------------------------------------

}