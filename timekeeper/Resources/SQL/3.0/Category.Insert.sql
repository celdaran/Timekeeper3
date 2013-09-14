------------------------------------------------------------------------
-- Table..: Category
-- Purpose: Create the default Category.
------------------------------------------------------------------------

INSERT INTO Category
(
    CreateTime,
    ModifyTime,
    CategoryGuid,

    Name,
    Description,

    SortOrderNo,

    IsHidden,
    IsDeleted,
    HiddenTime,
    DeletedTime

) VALUES (
    '{0}',
    '{0}',
    '{1}',

    'Default Category',
    'This is the default category. Rename this or create your own.',
    
    0,
    
    0,
    0,
    
    null,
    null
);
