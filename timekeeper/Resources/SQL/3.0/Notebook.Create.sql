------------------------------------------------------------------------
-- Table..: Notebook
-- Purpose: A Notebook entry is a special Timekeeper journal entry, one
--          not tied to particular time period or range but to a single
--          point in time (a specific day, hour, or minute, but most
--          typically a day).
-- Added..: Timekeeper 2.1
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'journal' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Notebook
(
    NotebookId          INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    NotebookGuid        TEXT        NOT NULL,

    EntryTime           DATETIME    NOT NULL,
    Memo                TEXT        NOT NULL,

    ProjectId           INTEGER         NULL,
    ActivityId          INTEGER         NULL,
    LocationId          INTEGER         NULL,
    CategoryId          INTEGER         NULL,

    FOREIGN KEY(LocationId)         REFERENCES Location(LocationId)
    FOREIGN KEY(CategoryId)         REFERENCES Category(CategoryId)
);

CREATE UNIQUE INDEX idx_Notebook_NotebookId ON Notebook(NotebookId);
CREATE UNIQUE INDEX idx_Notebook_NotebookGuid ON Notebook(NotebookGuid);
CREATE UNIQUE INDEX idx_Notebook_EntryTime ON Notebook(EntryTime);
