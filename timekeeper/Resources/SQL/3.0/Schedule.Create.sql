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

    DurationTypeId                  INTEGER     NOT NULL,
    StopAfterCount                  INTEGER         NULL,
    StopAfterTime                   DATETIME        NULL,
    
    TriggerCount                    INTEGER     NOT NULL,
    
    RefScheduleTypeId               INTEGER     NOT NULL,
    
    -- Type 1: One Time
    -- No attributes for this: fire at Event.NextOccurrenceTime --

    -- Type 2: Fixed Period (FIXME: um, is "Once" the right term here?)
    OnceAmount                      INTEGER         NULL,
    OnceUnit                        INTEGER         NULL,

    -- Type 3: Daily
    DailyTypeId                     INTEGER         NULL,
    DailyIntervalCount              INTEGER         NULL,
    
    -- Type 4: Weekly
    WeeklyIntervalCount             INTEGER         NULL,
    WeeklyMonday                    BOOLEAN         NULL,
    WeeklyTueday                    BOOLEAN         NULL,
    WeeklyWednesday                 BOOLEAN         NULL,
    WeeklyThursday                  BOOLEAN         NULL,
    WeeklyFriday                    BOOLEAN         NULL,
    WeeklySaturday                  BOOLEAN         NULL,
    WeeklySunday                    BOOLEAN         NULL,

    -- Type 5: Monthly
    MonthlyTypeId                   INTEGER         NULL,
    MonthlyIntervalCount            INTEGER         NULL,
    MonthlyDate                     INTEGER         NULL,
    MonthlyOrdinalDay               INTEGER         NULL,
    MonthlyDayOfWeek                INTEGER         NULL,
    
    -- Type 6: Yearly
    YearlyTypeId                    INTEGER         NULL,
    YearlyEveryDate                 INTEGER         NULL,
    YearlyOrdinalDay                INTEGER         NULL,
    YearlyDayOfWeek                 INTEGER         NULL,
    YearlyMonth                     INTEGER         NULL,
    
    -- Type 7: Advanced
    CrontabExpression               TEXT            NULL,
    
    FOREIGN KEY(RefScheduleTypeId)  REFERENCES RefScheduleType(RefScheduleTypeId)

);

CREATE UNIQUE INDEX idx_Schedule_ScheduleId ON Schedule(ScheduleId);
