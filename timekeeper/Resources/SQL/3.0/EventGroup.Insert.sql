------------------------------------------------------------------------
-- Table..: EventGroup
-- Purpose: Create a default event group.
------------------------------------------------------------------------

INSERT INTO EventGroup
(
    CreateTime,
    ModifyTime,
    Name,
    Description,
    SortOrderNo

) VALUES (
    '{0}',
    '{0}',
    'Default',
    'This is the default event group. Rename this or create your own.',
    1
);
