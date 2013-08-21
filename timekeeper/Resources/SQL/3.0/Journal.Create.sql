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
    JournalId               INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime              DATETIME    NOT NULL,
    ModifyTime              DATETIME    NOT NULL,
    JournalGuid             TEXT        NOT NULL,

    ProjectId               INTEGER     NOT NULL,
    ActivityId              INTEGER     NOT NULL,
    StartTime               DATETIME    NOT NULL,
    StopTime                DATETIME        NULL,
    Seconds                 INTEGER     NOT NULL,
    Memo                    TEXT            NULL,
    LocationId              INTEGER         NULL,
    CategoryId              INTEGER         NULL,

    IsLocked                BOOLEAN     NOT NULL,
    JournalIndex            INTEGER     NOT NULL,

    -- Thinking about a 'natural' flag: was this entry timed naturally? or otherwise subject to human intervention?
    
    -- NOT PERMANENT COLUMNS, ONLY HERE DURING UTC TRANSITION DEVELOPMENT
    OriginalStartTime       DATETIME        NULL,
    OriginalStopTime        DATETIME        NULL,

    FOREIGN KEY(ProjectId)              REFERENCES Project(ProjectId)
    FOREIGN KEY(ActivityId)             REFERENCES Activity(ActivityId)
    FOREIGN KEY(LocationId)             REFERENCES Location(LocationId)
    FOREIGN KEY(CategoryId)             REFERENCES Category(CategoryId)
);

CREATE UNIQUE INDEX idx_Journal_JournalId           ON Journal(JournalId);
CREATE UNIQUE INDEX idx_Journal_JournalGuid         ON Journal(JournalGuid);
CREATE UNIQUE INDEX idx_Journal_StartTime           ON Journal(StartTime);
CREATE UNIQUE INDEX idx_Journal_JournalIndex        ON Journal(JournalIndex);
CREATE        INDEX idx_Journal_ProjectId           ON Journal(ProjectId);
CREATE        INDEX idx_Journal_ActivityId          ON Journal(ActivityId);
