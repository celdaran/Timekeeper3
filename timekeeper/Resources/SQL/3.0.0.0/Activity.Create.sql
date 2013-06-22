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
    DeletedTime     DATETIME,

    FOREIGN KEY(LastProjectId) REFERENCES Project(ProjectId)
);

CREATE UNIQUE INDEX idx_Activity_ActivityId ON Activity (ActivityId);
CREATE UNIQUE INDEX idx_Activity_ActivityGuid ON Activity (ActivityGuid);
CREATE UNIQUE INDEX idx_Activity_ActivityName ON Activity (ActivityName);
