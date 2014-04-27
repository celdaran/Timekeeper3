------------------------------------------------------------------------
-- Table..: FindView
-- Purpose: This table stores the settings and options for saving a 
--          particular view of the Find window.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE FindView
(
    FindViewId          INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,
    SortOrderNo         INTEGER         NULL,

    FilterOptionsId     INTEGER         NULL,

    FOREIGN KEY(FilterOptionsId)    REFERENCES FilterOptions(FilterOptionsId)
);

CREATE UNIQUE INDEX idx_FindView_FindViewId ON FindView(FindViewId);
CREATE UNIQUE INDEX idx_FindView_Name ON FindView(Name);
