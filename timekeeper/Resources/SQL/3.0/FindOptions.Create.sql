------------------------------------------------------------------------
-- Table..: FindOptions
-- Purpose: This table stores user options for saving a particular view
--          of the Find dialog box results.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE FindOptions
(
    FindOptionsId       INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,
    SortOrderNo         INTEGER         NULL,

    FilterOptionsId     INTEGER     NOT NULL,

    FOREIGN KEY(FilterOptionsId)    REFERENCES FilterOptions(FilterOptionsId)
);

CREATE UNIQUE INDEX idx_FindOptions_FindOptionsId ON FindOptions(FindOptionsId);
CREATE UNIQUE INDEX idx_FindOptions_Name ON FindOptions(Name);
