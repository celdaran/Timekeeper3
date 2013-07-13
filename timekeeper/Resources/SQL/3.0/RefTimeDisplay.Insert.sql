------------------------------------------------------------------------
-- Table..: RefTimeDisplay
-- Purpose: Populate a reference table to define time display formats.
------------------------------------------------------------------------

INSERT INTO RefTimeDisplay
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'hh:mm:ss',
    'Display time in Hours:Minutes:Seconds.'
);

INSERT INTO RefTimeDisplay
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Hours',
    'Display time in fractional hours.'
);

INSERT INTO RefTimeDisplay
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Minutes',
    'Display time in minutes.'
);

INSERT INTO RefTimeDisplay
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Seconds',
    'Display time in seconds.'
);
