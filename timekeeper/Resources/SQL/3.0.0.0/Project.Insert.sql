INSERT INTO Project
(
    CreateTime,
    ModifyTime,
    ProjectGuid,

    Name,
    Description,
    ParentId,

    SortOrderNo,
    LastActivityId,

    IsFolder,
    IsOpened,
    IsHidden,
    IsDeleted,
    HiddenTime,
    DeletedTime

) VALUES (
    '{0}',
    '{0}',
    '{1}',

    'Default Project',
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
