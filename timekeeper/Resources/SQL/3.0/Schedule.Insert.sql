------------------------------------------------------------------------
-- Table..: Schedule
-- Purpose: Create the fallback schedule
------------------------------------------------------------------------

INSERT INTO Schedule
(
    ScheduleId,

    CreateTime,
    ModifyTime,

    DurationTypeId,
    
    TriggerCount,
    
    RefScheduleTypeId

) VALUES (
    0,

    '{0}',
    '{0}',

    1,

    0,
    
    1
);
