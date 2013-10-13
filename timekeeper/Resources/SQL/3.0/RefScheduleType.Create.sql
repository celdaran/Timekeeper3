------------------------------------------------------------------------
-- Table..: RefScheduleType
-- Purpose: Type of recurring schedule
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE RefScheduleType
(
    RefScheduleTypeId   INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL
);
