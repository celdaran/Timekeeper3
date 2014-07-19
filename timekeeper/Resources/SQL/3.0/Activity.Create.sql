------------------------------------------------------------------------
-- Table..: Activity
-- Purpose: An Activity is one of the two primary dimensions to time-
--          tracking. The other is Project. Activity can be generally
--          thought of as the verbs: as in what are you DOING and not
--          what are you DELIVERING.
-- Added..: Timekeeper 2.0
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'tasks' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Activity
(
    ActivityId          INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    ActivityGuid        TEXT        NOT NULL,

    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,

    ParentId            INTEGER         NULL,
    SortOrderNo         INTEGER     NOT NULL,
    IsFolder            BOOLEAN     NOT NULL,
    IsFolderOpened      BOOLEAN     NOT NULL,
    IsHidden            BOOLEAN     NOT NULL,
    IsDeleted           BOOLEAN     NOT NULL,
    HiddenTime          DATETIME        NULL,
    DeletedTime         DATETIME        NULL,

    LastLocationId      INTEGER         NULL,

    FOREIGN KEY(ParentId)           REFERENCES Activity(ActivityId)
    FOREIGN KEY(LastLocationId)     REFERENCES Location(LocationId)
);

CREATE UNIQUE INDEX idx_Activity_ActivityId ON Activity(ActivityId);
CREATE UNIQUE INDEX idx_Activity_ActivityGuid ON Activity(ActivityGuid);
CREATE UNIQUE INDEX idx_Activity_Name ON Activity(Name);
