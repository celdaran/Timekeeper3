------------------------------------------------------------------------
-- Table..: Category
-- Purpose: Provide a method for categorizing, tagging, or otherwise
--          flagging a row with a piece of additional, user-defined
--          information. For example, "follow up", "important", etc.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Category
(
    CategoryId          INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    CategoryGuid        TEXT        NOT NULL,

    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,

    ParentId            INTEGER         NULL,
    SortOrderNo         INTEGER     NOT NULL,
    IsHidden            BOOLEAN     NOT NULL,
    IsDeleted           BOOLEAN     NOT NULL,
    HiddenTime          DATETIME        NULL,
    DeletedTime         DATETIME        NULL
);

CREATE UNIQUE INDEX idx_Category_CategoryId ON Category(CategoryId);
CREATE UNIQUE INDEX idx_Category_CategoryGuid ON Category(CategoryGuid);
CREATE UNIQUE INDEX idx_Category_Name ON Category(Name);
