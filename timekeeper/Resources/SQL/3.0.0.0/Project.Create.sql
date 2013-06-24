CREATE TABLE Project (
    ProjectId       INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime      DATETIME    NOT NULL,
    ModifyTime      DATETIME    NOT NULL,
    ProjectGuid     TEXT        NOT NULL,
    Name            TEXT        NOT NULL,
    Description     TEXT            NULL,
    ParentId        INTEGER         NULL,
    SortOrderNo     INTEGER         NULL,
    LastActivityId  INTEGER         NULL,
    IsFolder        BOOLEAN     NOT NULL,
    IsOpened        BOOLEAN     NOT NULL,
    IsHidden        BOOLEAN     NOT NULL,
    IsDeleted       BOOLEAN     NOT NULL,
    HiddenTime      DATETIME        NULL,
    DeletedTime     DATETIME        NULL,

    FOREIGN KEY(LastActivityId) REFERENCES Activity(ActivityId)
);

CREATE UNIQUE INDEX idx_Project_ProjectId ON Project (ProjectId);
CREATE UNIQUE INDEX idx_Project_ProjectGuid ON Project (ProjectGuid);
CREATE UNIQUE INDEX idx_Project_ProjectName ON Project (Name);
