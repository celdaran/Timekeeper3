------------------------------------------------------------------------
-- Table..: RefDimension
-- Purpose: Assigns identifiers to the four time-tracking dimensions:
--          Projects, Activities, Locations, and Categories.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE RefDimension
(
    RefDimensionId      INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL
);
