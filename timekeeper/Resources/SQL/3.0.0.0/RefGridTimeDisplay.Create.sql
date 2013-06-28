------------------------------------------------------------------------
-- Table..: RefTimeDisplay
-- Purpose: The interface uses a drop-down selection of time display
--          formats to control how sum(Journal.Seconds) is displayed.
--          For example, hh:mm:ss, Hours, Minutes, Seconds.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE RefTimeDisplay
(
    RefTimeDisplayId    INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL
);
