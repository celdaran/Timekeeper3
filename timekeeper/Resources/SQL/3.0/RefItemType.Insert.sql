------------------------------------------------------------------------
-- Table..: RefItemType
-- Purpose: Populate a reference table to define Timekeeper item types.
------------------------------------------------------------------------

INSERT INTO RefItemType
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Activity',
    'An Activity is a verb or action being timed.'
);

INSERT INTO RefItemType
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Project',
    'A Project is a noun or deliverable being timed.'
);

