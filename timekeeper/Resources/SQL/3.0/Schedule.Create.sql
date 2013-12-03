------------------------------------------------------------------------
-- Table..: Schedule
-- Purpose: This table stores schedules. Schedules can be attached to
--          events and used with Reminders to create recurring events.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Schedule
(
    ScheduleId                      INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime                      DATETIME    NOT NULL,
    ModifyTime                      DATETIME    NOT NULL,

    RefScheduleTypeId               INTEGER     NOT NULL,

    OnceAmount                      INTEGER         NULL,
    OnceUnit                        INTEGER         NULL,

    DailyTypeId                     INTEGER         NULL,
    DailyIntervalCount              INTEGER         NULL,
    
    WeeklyIntervalCount             INTEGER         NULL,
    WeeklyMonday                    BOOLEAN         NULL,
    WeeklyTueday                    BOOLEAN         NULL,
    WeeklyWednesday                 BOOLEAN         NULL,
    WeeklyThursday                  BOOLEAN         NULL,
    WeeklyFriday                    BOOLEAN         NULL,
    WeeklySaturday                  BOOLEAN         NULL,
    WeeklySunday                    BOOLEAN         NULL,

    MonthlyTypeId                   INTEGER         NULL,
    MonthlyIntervalCount            INTEGER         NULL,
    MonthlyDate                     INTEGER         NULL,
    MonthlyOrdinalDay               INTEGER         NULL,
    MonthlyDayOfWeek                INTEGER         NULL,
    
    YearlyTypeId                    INTEGER         NULL,
    YearlyEveryDate                 INTEGER         NULL,
    YearlyOrdinalDay                INTEGER         NULL,
    YearlyDayOfWeek                 INTEGER         NULL,
    YearlyMonth                     INTEGER         NULL,
    
    CrontabExpression               TEXT            NULL,
    
    DurationTypeId                  INTEGER     NOT NULL,
    StopAfterCount                  INTEGER         NULL,
    StopAfterTime                   DATETIME        NULL,
    
    TriggerCount                    INTEGER     NOT NULL,
    
    FOREIGN KEY(RefScheduleTypeId)  REFERENCES RefScheduleType(RefScheduleTypeId)

);

CREATE UNIQUE INDEX idx_Schedule_ScheduleId ON Schedule(ScheduleId);
