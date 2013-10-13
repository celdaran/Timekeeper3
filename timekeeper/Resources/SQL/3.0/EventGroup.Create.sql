------------------------------------------------------------------------
-- Table..: EventGroup
-- Purpose: This table stores user-defined groups for events.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE EventGroup
(
    EventGroupId        INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,

    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,
    SortOrderNo         INTEGER     NOT NULL
);

CREATE UNIQUE INDEX idx_EventGroup_EventGroupId ON EventGroup(EventGroupId);
CREATE UNIQUE INDEX idx_EventGroup_Name ON EventGroup(Name);
