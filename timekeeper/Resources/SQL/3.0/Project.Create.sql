------------------------------------------------------------------------
-- Table..: Project
-- Purpose: A Project is one of the two primary dimensions to time-
--          tracking. The other is Activity. Project can be generally
--          thought of as the nouns: as in what are you DELIVERING and
--          not what are you DOING.
-- Added..: Timekeeper 2.0
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'projects' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Project
(
    ProjectId           INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    ProjectGuid         TEXT        NOT NULL,

    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,

    ParentId            INTEGER         NULL,
    SortOrderNo         INTEGER     NOT NULL,
    IsFolder            BOOLEAN     NOT NULL,
    IsFolderOpened      BOOLEAN     NOT NULL,
    IsHidden            BOOLEAN     NOT NULL,
    IsDeleted           BOOLEAN     NOT NULL,
    HiddenTime          DATETIME        NULL,
    DeletedTime         DATETIME        NULL,

    LastActivityId      INTEGER         NULL,
    LastLocationId      INTEGER         NULL,
    LastCategoryId      INTEGER         NULL,

    ExternalProjectNo   TEXT            NULL,
    StartTime           DATETIME        NULL,
    DueTime             DATETIME        NULL,
    Estimate            INTEGER         NULL,

    FOREIGN KEY(ParentId)           REFERENCES Project(ProjectId)
    FOREIGN KEY(LastActivityId)     REFERENCES Activity(ActivityId)
    FOREIGN KEY(LastLocationId)     REFERENCES Location(LocationId)
    FOREIGN KEY(LastCategoryId)     REFERENCES Category(CategoryId)
);

CREATE UNIQUE INDEX idx_Project_ProjectId ON Project(ProjectId);
CREATE UNIQUE INDEX idx_Project_ProjectGuid ON Project(ProjectGuid);
CREATE UNIQUE INDEX idx_Project_Name ON Project(Name);
