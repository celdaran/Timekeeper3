------------------------------------------------------------------------
-- Table..: FilterOptions
-- Purpose: This table stores standard filtering options for various
--          user reporting and querying tasks. If a particular form or
--          feature of Timekeeper requires filtering, this row is first
--          populated, then attached to the specific instance of user
--          filtering. For example, both the Report and Grid forms
--          support filtering, but each of these also has its own
--          unique set of attributes. The unique attributes are stored
--          in their own tables, but then a common FilterOptions row
--          is pointed to from there.
--          Much of this concept came from the old grid_views table.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE FilterOptions
(
    FilterOptionsId     INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    LocationId          INTEGER         NULL,

    ActivityList        TEXT            NULL,
    ProjectList         TEXT            NULL,
    RefDatePresetId     INTEGER         NULL,
    FromDate            DATETIME        NULL,
    ToDate              DATETIME        NULL,
    Memo                TEXT            NULL,
    DurationOperator    INTEGER         NULL,
    DurationAmount      INTEGER         NULL,
    DurationUnit        INTEGER         NULL,
    LocationList        TEXT            NULL,
    CategoryList        TEXT            NULL,

    FOREIGN KEY(LocationId)         REFERENCES Location(LocationId)
    FOREIGN KEY(RefDatePresetId)    REFERENCES RefDatePreset(RefDatePresetId)
);
