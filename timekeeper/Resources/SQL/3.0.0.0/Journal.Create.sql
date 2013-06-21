CREATE TABLE Journal
(
    JournalEntryId      INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME NOT NULL,
    ModifyTime          DATETIME NOT NULL,
    JournalEntryGuid    TEXT NOT NULL,
    ExternalEntryId     INTEGER,
    ActivityId          INTEGER NOT NULL,
    ProjectId           INTEGER NOT NULL,
    StartTime           DATETIME,
    StopTime            DATETIME,
    Seconds             INTEGER NOT NULL,
    Memo                TEXT,
    LocationId          INTEGER,
    CategoryId          INTEGER,
    IsLocked            BOOLEAN NOT NULL
);

CREATE UNIQUE INDEX idx_Journal_JournalEntryId  ON Journal (JournalEntryId);
CREATE UNIQUE INDEX idx_Journal_StartTime       ON Journal (StartTime);
CREATE        INDEX idx_Journal_ActivityId      ON Journal (ActivityId);
CREATE        INDEX idx_Journal_ProjectId       ON Journal (ProjectId);
