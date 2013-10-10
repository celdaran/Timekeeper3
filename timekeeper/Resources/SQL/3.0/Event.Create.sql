------------------------------------------------------------------------
-- Table..: Event
-- Purpose: This table stores countdown events.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Event
(
    EventId             INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,

    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,
    SortOrderNo         INTEGER     NOT NULL,
    
    /*
    Type? Like, one-time, or recurring
    Can this table be used for both the Countdown & Reminders tool?
    Wait, where's the target time?
   
    
    IsHidden                BOOLEAN     NOT NULL,
    IsDeleted               BOOLEAN     NOT NULL,
    HiddenTime              DATETIME        NULL,
    DeletedTime             DATETIME        NULL,
    */
);

CREATE UNIQUE INDEX idx_Event_EventId ON Event(EventId);
CREATE UNIQUE INDEX idx_Event_Name    ON Event(Name);
