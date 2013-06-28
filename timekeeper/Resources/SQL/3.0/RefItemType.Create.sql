------------------------------------------------------------------------
-- Table..: RefItemType
-- Purpose: Assigns identifiers to "Activity" and "Project".
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE RefItemType
(
    RefItemTypeId       INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL
);
