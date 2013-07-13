------------------------------------------------------------------------
-- Table..: Activity
-- Purpose: Create a default Activity.
------------------------------------------------------------------------

INSERT INTO Activity
(
    CreateTime,
    ModifyTime,
    ActivityGuid,

    Name,
    Description,
    ParentId,

    SortOrderNo,
    LastProjectId,

    IsFolder,
    IsFolderOpened,
    IsHidden,
    IsDeleted,
    HiddenTime,
    DeletedTime

) VALUES (
    '{0}',
    '{0}',
    '{1}',

    'Default Activity',
    'Right click and select Edit to change the name or this description',
    0,
    
    0,
    0,
    
    0,
    0,
    0,
    0,
    
    null,
    null
)
