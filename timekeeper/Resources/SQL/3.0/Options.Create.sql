------------------------------------------------------------------------
-- Table..: Options
-- Purpose: Most user options are stored in the Windows Registry.
--          However, some options do not apply system-wide and are
--          specific to the opened database. Those options go here.
--          Items like tracking the last-timed Activity or the last
--          used Report view.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Options
(
    OptionsId           INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,

    Key                 TEXT        NOT NULL,
    Value               TEXT            NULL
);
