CREATE TABLE Activity
(
    ActivityId      INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime      DATETIME NOT NULL,
    ModifyTime      DATETIME NOT NULL,
    ActivityGuid    TEXT NOT NULL,
    Name            TEXT NOT NULL,
    Description     TEXT,
    ParentId        INTEGER,
    SortOrderNo     INTEGER,
    LastProjectId   INTEGER,
    IsFolder        BOOLEAN NOT NULL,
    IsOpened        BOOLEAN NOT NULL,
    IsHidden        BOOLEAN NOT NULL,
    IsDeleted       BOOLEAN NOT NULL,
    HiddenTime      DATETIME,
    DeletedTime     DATETIME
);

CREATE UNIQUE INDEX idx_Project_ProjectId ON Project (ProjectId);
