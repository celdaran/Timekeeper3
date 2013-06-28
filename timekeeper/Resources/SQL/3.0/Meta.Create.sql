------------------------------------------------------------------------
-- Table..: AA9FFC4E_5CEB_4E3F_83FE_7EC5D1A33300
-- Purpose: This is the table containing meta information about the
--          database. It also serves as a unique identifier to help
--          immediately distinguish a Timekeeper database from any
--          other SQLite database. It contains the database's create
--          date, update date, UUID, and schema version.
-- Added..: Timekeeper 2.0
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'meta' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE AA9FFC4E_5CEB_4E3F_83FE_7EC5D1A33300
(
    MetaId	            INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Key                 TEXT    NOT NULL,
    Value               TEXT    NOT NULL
);
