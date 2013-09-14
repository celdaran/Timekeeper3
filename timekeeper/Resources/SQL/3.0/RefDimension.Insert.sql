------------------------------------------------------------------------
-- Table..: RefDimension
-- Purpose: Populate a reference table to define Timekeeper item types.
------------------------------------------------------------------------

INSERT INTO RefDimension
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

INSERT INTO RefDimension
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

INSERT INTO RefDimension
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Location',
    'A Location helps you geographically tag journal entries.'
);

INSERT INTO RefDimension
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Category',
    'A Category lets you further track entries.'
);
