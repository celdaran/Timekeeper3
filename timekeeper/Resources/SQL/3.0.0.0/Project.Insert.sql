INSERT INTO Project
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
    IsOpened,
    IsHidden,
    IsDeleted,
    HiddenTime,
    DeletedTime

) VALUES (
    datetime('now'),
    datetime('now'),
    {0},

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
