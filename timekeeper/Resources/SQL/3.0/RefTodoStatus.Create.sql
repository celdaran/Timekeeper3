------------------------------------------------------------------------
-- Table..: RefTodoStatus
-- Purpose: 
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE RefTodoStatus
(
    RefTodoStatusId     INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL
);
