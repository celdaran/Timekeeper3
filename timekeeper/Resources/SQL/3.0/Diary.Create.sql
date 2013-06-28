------------------------------------------------------------------------
-- Table..: Diary
-- Purpose: A Diary entry is a special Timekeeper journal entry, one
--          not tied to particular time period or range but to a single
--          point in time (a specific day, hour, or minute, but most
--          typically a day).
-- Added..: Timekeeper 2.1
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'journal' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Diary
(
    DiaryEntryId        INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    LocationId          INTEGER         NULL,

    DiaryEntryGuid      TEXT        NOT NULL,

    EntryTime           DATETIME    NOT NULL,
    Memo                TEXT        NOT NULL,
    CategoryId          INTEGER         NULL,

    FOREIGN KEY(LocationId)         REFERENCES Location(LocationId)
    FOREIGN KEY(CategoryId)         REFERENCES Category(CategoryId)
);

CREATE UNIQUE INDEX idx_Diary_DiaryEntryId ON Diary(DiaryEntryId);
CREATE UNIQUE INDEX idx_Diary_DiaryEntryGuid ON Diary(DiaryEntryGuid);
CREATE UNIQUE INDEX idx_Diary_EntryTime ON Diary(EntryTime);
