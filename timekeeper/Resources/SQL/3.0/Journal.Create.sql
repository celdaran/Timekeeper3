------------------------------------------------------------------------
-- Table..: Journal
-- Purpose: This is the primary Timekeeper Journal Entry table and the
--          entire reason this whole project exists. As the user starts
--          and stops the timer, rows are created and updated here.
-- Added..: Timekeeper 2.0
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'timekeeper' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Journal
(
    JournalEntryId          INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime              DATETIME    NOT NULL,
    ModifyTime              DATETIME    NOT NULL,
    LocationId              INTEGER         NULL,

    JournalEntryGuid        TEXT        NOT NULL,

    ActivityId              INTEGER     NOT NULL,
    ProjectId               INTEGER     NOT NULL,
    StartTime               DATETIME    NOT NULL,
    StopTime                DATETIME        NULL,
    Seconds                 INTEGER     NOT NULL,
    Memo                    TEXT            NULL,
    CategoryId              INTEGER         NULL,
    IsLocked                BOOLEAN     NOT NULL,

    -- NOT PERMANENT COLUMNS, ONLY HERE DURING UTC TRANSITION DEVELOPMENT
    OriginalStartTime       DATETIME        NULL,
    OriginalStopTime        DATETIME        NULL,

    FOREIGN KEY(LocationId)             REFERENCES Location(LocationId)
    FOREIGN KEY(ActivityId)             REFERENCES Activity(ActivityId)
    FOREIGN KEY(ProjectId)              REFERENCES Project(ProjectId)
    FOREIGN KEY(CategoryId)             REFERENCES Category(CategoryId)
);

CREATE UNIQUE INDEX idx_Journal_JournalEntryId      ON Journal(JournalEntryId);
CREATE UNIQUE INDEX idx_Journal_JournalEntryGuid    ON Journal(JournalEntryGuid);
CREATE UNIQUE INDEX idx_Journal_StartTime           ON Journal(StartTime);
CREATE        INDEX idx_Journal_ActivityId          ON Journal(ActivityId);
CREATE        INDEX idx_Journal_ProjectId           ON Journal(ProjectId);
