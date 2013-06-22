CREATE TABLE Journal
(
    JournalEntryId      INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    JournalEntryGuid    TEXT        NOT NULL,
    ExternalEntryId     INTEGER         NULL,
    ActivityId          INTEGER     NOT NULL,
    ProjectId           INTEGER     NOT NULL,
    StartTime           DATETIME    NOT NULL,
    StopTime            DATETIME        NULL,
    Seconds             INTEGER     NOT NULL,
    Memo                TEXT            NULL,
    LocationId          INTEGER         NULL,
    CategoryId          INTEGER         NULL,
    IsLocked            BOOLEAN     NOT NULL,

    FOREIGN KEY(ActivityId) REFERENCES Activity(ActivityId)
    FOREIGN KEY(ProjectId)  REFERENCES Project(ProjectId)
    FOREIGN KEY(LocationId) REFERENCES Location(LocationId)
    FOREIGN KEY(CategoryId) REFERENCES Category(CategoryId)
);

CREATE UNIQUE INDEX idx_Journal_JournalEntryId      ON Journal (JournalEntryId);
CREATE UNIQUE INDEX idx_Journal_JournalEntryGuid    ON Journal (JournalEntryGuid);
CREATE UNIQUE INDEX idx_Journal_StartTime           ON Journal (StartTime);
CREATE        INDEX idx_Journal_ActivityId          ON Journal (ActivityId);
CREATE        INDEX idx_Journal_ProjectId           ON Journal (ProjectId);
