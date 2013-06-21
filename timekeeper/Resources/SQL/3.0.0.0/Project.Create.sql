CREATE TABLE Project (
    ProjectId       INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime      DATETIME NOT NULL,
    ModifyTime      DATETIME NOT NULL,
    ProjectGuid     TEXT NOT NULL,
    Name            TEXT NOT NULL,
    Description     TEXT,
    ParentId        INTEGER,
    SortOrderNo     INTEGER,
    LastActivityId  INTEGER,
    IsFolder        BOOLEAN NOT NULL,
    IsOpened        BOOLEAN NOT NULL,
    IsHidden        BOOLEAN NOT NULL,
    IsDeleted       BOOLEAN NOT NULL,
    HiddenTime      DATETIME,
    DeletedTime     DATETIME
);
