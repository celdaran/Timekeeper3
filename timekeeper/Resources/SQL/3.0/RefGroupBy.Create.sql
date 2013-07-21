------------------------------------------------------------------------
-- Table..: RefGroupBy
-- Purpose: The data filtering interface uses a drop-down selection of
--          date "Group By" values. For example, Week, Month, Year.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE RefGroupBy
(
    RefGroupById        INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL
);
