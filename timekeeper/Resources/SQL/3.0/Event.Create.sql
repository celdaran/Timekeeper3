------------------------------------------------------------------------
-- Table..: Event
-- Purpose: This table stores events for Reminders and Countdowns.
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
    SortOrderNo                     INTEGER     NOT NULL,

    -- Event
    EventGroupId                    INTEGER     NOT NULL,
    NextOccurrenceTime              DATETIME    NOT NULL,

    -- Reminder
    Reminder_TimeAmount             INTEGER     NOT NULL,
    Reminder_TimeUnit               INTEGER     NOT NULL,
    Reminder_NotifyViaTray          BOOLEAN     NOT NULL,
    Reminder_NotifyViaAudio         BOOLEAN     NOT NULL,
    Reminder_NotifyViaEmail         BOOLEAN     NOT NULL,
    Reminder_NotifyViaSMS           BOOLEAN     NOT NULL,
    Reminder_NotifyTrayMessage      TEXT            NULL,
    Reminder_NotifyAudioFile        TEXT            NULL,
    Reminder_NotifyEmailAddress     TEXT            NULL,
    Reminder_NotifyPhoneNumber      TEXT            NULL,
    Reminder_NotifyCarrierListId    INTEGER         NULL,

    -- Schedule
    RefScheduleTypeId               INTEGER     NOT NULL,

    Schedule_OnceAmount             INTEGER         NULL,
    Schedule_OnceUnit               INTEGER         NULL,

    Schedule_DailyTypeId            INTEGER         NULL,
    Schedule_DailyIntervalCount     INTEGER         NULL,
    
    Schedule_WeeklyIntervalCount    INTEGER         NULL,
    Schedule_WeeklyMonday           BOOLEAN         NULL,
    Schedule_WeeklyTueday           BOOLEAN         NULL,
    Schedule_WeeklyWednesday        BOOLEAN         NULL,
    Schedule_WeeklyThursday         BOOLEAN         NULL,
    Schedule_WeeklyFriday           BOOLEAN         NULL,
    Schedule_WeeklySaturday         BOOLEAN         NULL,
    Schedule_WeeklySunday           BOOLEAN         NULL,

    Schedule_MonthlyTypeId          INTEGER         NULL,
    Schedule_MonthlyIntervalCount   INTEGER         NULL,
    Schedule_MonthlyDate            INTEGER         NULL,
    Schedule_MonthlyOrdinalDay      INTEGER         NULL,
    Schedule_MonthlyDayOfWeek       INTEGER         NULL,
    
    Schedule_YearlyTypeId           INTEGER         NULL,
    Schedule_YearlyEveryDate        INTEGER         NULL,
    Schedule_YearlyOrdinalDay       INTEGER         NULL,
    Schedule_YearlyDayOfWeek        INTEGER         NULL,
    Schedule_YearlyMonth            INTEGER         NULL,
    
    CrontabExpression               TEXT            NULL,
    
    -- Duration
    Duration_TypeId                 INTEGER     NOT NULL,
    Duration_StopAfterCount         INTEGER         NULL,
    Duration_StopAfterTime          DATETIME        NULL,
    
    -- Event Metadata
    TriggerCount                    INTEGER     NOT NULL,
    
    -- System Metadata
    IsHidden                        BOOLEAN     NOT NULL,
    IsDeleted                       BOOLEAN     NOT NULL,
    HiddenTime                      DATETIME        NULL,
    DeletedTime                     DATETIME        NULL,

    FOREIGN KEY(EventGroupId)       REFERENCES EventGroup(EventGroupId)
    FOREIGN KEY(RefScheduleTypeId)  REFERENCES RefScheduleType(RefScheduleTypeId)

);

CREATE UNIQUE INDEX idx_Event_EventId ON Event(EventId);
CREATE UNIQUE INDEX idx_Event_Name    ON Event(Name);
