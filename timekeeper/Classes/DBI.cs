using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SQLite;

namespace Timekeeper
{
    public class DBI
    {
        public string dataFile;
        public bool dataFileExists;
        public long dataFileSize;

        private SQLiteConnection db;
        private SQLiteTransaction trx;
        private int trx_depth;

        private bool opened;
        private bool tracing;
        
        private Logger log;

        //---------------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------------

        public DBI(string dataFile)
        {
            this.tracing = false;
            _init(dataFile);
        }

        //---------------------------------------------------------------------

        public DBI(string dataFile, bool tracing)
        {
            this.tracing = tracing;
            _init(dataFile);
        }

        //---------------------------------------------------------------------

        public void _init(string dataFile)
        {
            // set defaults
            this.dataFile = dataFile;
            this.dataFileExists = false;

            // open Logger object with new file name
            this.log = new Logger(dataFile + ".tklog");

            // does the file exist?
            if (File.Exists(this.dataFile))
            {
                FileInfo fileinfo = new FileInfo(this.dataFile);
                this.dataFileExists = fileinfo.Exists;
                this.dataFileSize = fileinfo.Length;
            }
        }

        //---------------------------------------------------------------------
        // Open / Close
        //---------------------------------------------------------------------

        public void open()
        {
            if (opened) {
                return;
            }

            string dsn = "Data Source=" + dataFile;
            db = new SQLiteConnection(dsn);
            db.Open();

            if (tracing) {
                log.write("database " + dataFile + " opened");
            }

            opened = true;
            trx_depth = 0;
        }

        //---------------------------------------------------------------------

        public void close()
        {
            if (trx == null) {
                db.Close();
                opened = false;

                if (tracing) {
                    log.write("database " + dataFile + " closed");
                }
            }
        }

        //---------------------------------------------------------------------
        // Transactions
        //---------------------------------------------------------------------

        public void begin()
        {
            open();
            if (trx_depth == 0) {
                trx = db.BeginTransaction();
                if (tracing) {
                    log.write("transaction started");
                }
            }
            trx_depth++;
        }

        //---------------------------------------------------------------------

        public void commit()
        {
            trx_depth--;
            if (trx_depth > 0) {
                return;
            }
            trx.Commit();
            trx = null;
            if (tracing) {
                log.write("transaction committed");
            }
            close();
        }

        //---------------------------------------------------------------------

        public void rollback()
        {
            trx.Rollback();
            trx = null;
            trx_depth = 0;
            if (tracing) {
                log.write("transaction rollback");
            }
            close();
        }

        //---------------------------------------------------------------------

        public bool in_transaction()
        {
            return trx != null;
        }

        //---------------------------------------------------------------------
        // Select
        //---------------------------------------------------------------------

        public RowSet select(string query)
        {
            open();

            RowSet rows = new RowSet();

            try
            {
                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = query;

                SQLiteDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Row row = _populate_row(reader);
                    rows.Add(row);
                }

                reader.Dispose();
                cmd.Dispose();

                if (tracing) {
                    log.write(query);
                }
            }
            catch (Exception ee)
            {
                log.write(ee.ToString());
                log.write(query);
            }

            close();

            return rows;
        }

        //---------------------------------------------------------------------

        public Row selectRow(string query)
        {
            try
            {
                open();

                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = query;
                SQLiteDataReader reader = cmd.ExecuteReader();

                reader.Read();

                Row row = _populate_row(reader);

                reader.Dispose();
                cmd.Dispose();

                if (tracing) {
                    log.write(query);
                }

                close();

                return row;
            }
            catch (Exception ee)
            {
                log.write(ee.ToString());
                log.write(query);
                return new Row();
            }
        }

        //---------------------------------------------------------------------

        private Row _populate_row(SQLiteDataReader reader)
        {
            Row row = new Row();

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string name;
                string value;

                name = reader.GetName(i);
                if (reader.IsDBNull(i)) {
                    value = "";
                } else {
                    value = reader.GetValue(i).ToString();
                }

                row.Add(name, value);
            }

            return row;
        }

        //---------------------------------------------------------------------
        // Insert
        //---------------------------------------------------------------------

        public int insert(string table, Row columns)
        {
            string query = "";
            Row newColumns = new Row();
            int count = 0;

            try
            {
                open();

                // parameterize values
                foreach (string key in columns.Keys) {
                    newColumns["@" + key] = columns[key];
                }

                // build insert statement
                query = String.Format("insert into {0} (", table);
                query += Join(",", columns.Keys);
                query += ") values (";
                query += Join(",", newColumns.Keys);
                query += ")";

                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = query;

                // now do the substituion
                foreach (string key in newColumns.Keys) {
                    cmd.Parameters.Add(key, DbType.String).Value = newColumns[key];
                }

                count = cmd.ExecuteNonQuery();

                if (count > 0) {
                    cmd.CommandText = "select last_insert_rowid()";
                    SQLiteDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    // actually last id
                    count = reader.GetInt32(0);
                    reader.Dispose();
                }

                cmd.Dispose();

                if (tracing) {
                    log.write(String.Format("row ({0}) inserted: {1}", count, query));
                }

                close();
            }
            catch (Exception ee)
            {
                log.write(String.Format("row NOT inserted: {0}", query));
                log.write(ee.ToString());
            }

            return count;
        }

        //---------------------------------------------------------------------
        // Update
        //---------------------------------------------------------------------

        public int update(string table, Row columns, string whereColumn, string whereValue)
        {
            string query = "";
            string pairs = "";
            Row newColumns = new Row();
            int count = 0;

            try
            {
                open();

                // parameterize values
                foreach (string key in columns.Keys)
                {
                    newColumns["@" + key] = columns[key];
                }

                // build pairs
                foreach (string s in columns.Keys)
                {
                    pairs += s + " = @" + s + ",";
                }

                // strip trailing comma
                pairs = pairs.Substring(0, pairs.Length - 1);

                // build update statement
                query = String.Format("update {0} set ", table);
                query += pairs;
                query += String.Format(" where {0} = '{1}'", whereColumn, whereValue.Replace("'", "''"));

                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = query;

                // now do the substituion
                foreach (string key in newColumns.Keys)
                {
                    cmd.Parameters.Add(key, DbType.String).Value = newColumns[key];
                }

                count = cmd.ExecuteNonQuery();

                cmd.Dispose();

                if (tracing) {
                    log.write(String.Format("row updated: {0}", query));
                }

                close();
            }
            catch (Exception ee)
            {
                log.write(String.Format("row NOT updated: {0}", query));
                log.write(ee.ToString());
            }

            return count;
        }

        //---------------------------------------------------------------------
        // Delete
        //---------------------------------------------------------------------

        public int delete(string table, string whereColumn, string whereValue)
        {
            string query = "";
            int count = 0;

            try
            {
                open();

                // build delete statement
                query = String.Format("delete from {0} ", table);
                query += String.Format(" where {0} = '{1}'", whereColumn, whereValue.Replace("'", "''"));

                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = query;
                count = cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (tracing) {
                    log.write(String.Format("row deleted: {0}", query));
                }

                close();
            }
            catch (Exception ee)
            {
                log.write(String.Format("row NOT deleted: {0}", query));
                log.write(ee.ToString());
            }

            return count;
        }

        //---------------------------------------------------------------------

        public int exec(string query)
        {
            try
            {
                open();

                SQLiteCommand cmd = db.CreateCommand();
                cmd.CommandText = query;
                int count = cmd.ExecuteNonQuery();
                cmd.Dispose();

                if (tracing) {
                    log.write(String.Format("command executed: {0}", query));
                }

                close();

                return count;
            }
            catch (Exception ee)
            {
                log.write(ee.ToString());
                return 0;
            }
        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private string Join(string sep, Dictionary<string, string>.KeyCollection list)
        {
            string join = "";
            foreach (string s in list)
            {
                join += s + ",";
            }
            return join.Substring(0, join.Length - 1);
        }

        private string Join(string sep, Dictionary<string, string>.ValueCollection list)
        {
            string join = "";
            foreach (string s in list)
            {
                join += s + ",";
            }
            return join.Substring(0, join.Length - 1);
        }
    }
        
    //---------------------------------------------------------------------
    // Helper classes
    //---------------------------------------------------------------------

    public class RowSet : List<Dictionary<string, string>>
    {
    }

    //---------------------------------------------------------------------

    public class Row : Dictionary<string, string>
    {
    }

    //---------------------------------------------------------------------
    // Pair class
    //   Somewhat experimental. Need to look at this again and see if it's
    //   really necessary (and what I want). Definitely a FIXME spot to
    //   come back to and clean up.
    //---------------------------------------------------------------------

    public class Pair
    {
        public string name;
        public int    value;

        public Pair(string sName, string sValue)
        {
            this.name = sName;
            this.value = Convert.ToInt32(sValue);
        }

        public override string ToString()
        {
            return this.name;
        }
    }

    //---------------------------------------------------------------------
    // Logger class
    //   Also somewhat experimental. I'd like to make something a bit 
    //   more robust and reusable. This is just a stab at it.
    //---------------------------------------------------------------------

    public class Logger
    {
        private string sFileName;

        public Logger(string sFileName)
        {
            this.sFileName = sFileName;
        }

        public void write(string sMsg)
        {
            StreamWriter writer = new StreamWriter(this.sFileName, true);
            writer.WriteLine(Common.Now() + ": " + sMsg);
            writer.Close();
        }

    }

}
