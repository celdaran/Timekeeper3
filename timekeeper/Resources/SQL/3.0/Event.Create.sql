------------------------------------------------------------------------
-- Table..: Event
-- Purpose: This table stores events. An Event is any date/time-based,
--          user-defined, groupable object that has meaning to the user.
--          Events can be anything from "Halloween" to "Get Out of Your
--          Chair Once in a While." Events can be Scheduled to repeat
--          and/or have Reminders attached.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Event
(
    EventId                         INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime                      DATETIME    NOT NULL,
    ModifyTime                      DATETIME    NOT NULL,

    Name                            TEXT        NOT NULL,
    Description                     TEXT            NULL,

    EventGroupId                    INTEGER     NOT NULL,
    NextOccurrenceTime              DATETIME    NOT NULL,
    ReminderId                      INTEGER     NOT NULL,
    ScheduleId                      INTEGER     NOT NULL,

    IsHidden                        BOOLEAN     NOT NULL,
    IsDeleted                       BOOLEAN     NOT NULL,
    HiddenTime                      DATETIME        NULL,
    DeletedTime                     DATETIME        NULL,

    FOREIGN KEY(EventGroupId)       REFERENCES EventGroup(EventGroupId)
    FOREIGN KEY(ReminderId)         REFERENCES Reminder(ReminderId)
    FOREIGN KEY(ScheduleId)         REFERENCES Schedule(ScheduleId)
);

CREATE UNIQUE INDEX idx_Event_EventId ON Event(EventId);
CREATE UNIQUE INDEX idx_Event_Name    ON Event(Name);
