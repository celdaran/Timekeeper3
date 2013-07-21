------------------------------------------------------------------------
-- Table..: [7EFF6E35-2448-4AA8-BBB0-441536BE592F]
-- Purpose: This is the table containing meta information about the
--          database. It also serves as a unique identifier to help
--          immediately distinguish a Timekeeper database from any
--          other SQLite database. It contains the database's create
--          date, update date, UUID, and schema version.
-- Added..: Timekeeper 2.0
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'meta' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE [7EFF6E35-2448-4AA8-BBB0-441536BE592F]
(
    MetaId	            INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Key                 TEXT    NOT NULL,
    Value               TEXT    NOT NULL
);
