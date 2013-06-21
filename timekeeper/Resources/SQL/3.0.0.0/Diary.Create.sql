CREATE TABLE Diary
(
    DiaryEntryId        INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME NOT NULL,
    ModifyTime          DATETIME NOT NULL,
    DiaryEntryGuid      TEXT NOT NULL,
    EntryTime           DATETIME NOT NULL,
    Memo                TEXT NOT NULL,
    LocationId          INTEGER,
    CategoryId          INTEGER
);

CREATE UNIQUE INDEX idx_Diary_DiaryEntryId  ON Diary (DiaryEntryId);
CREATE UNIQUE INDEX idx_Diary_EntryTime     ON Diary (EntryTime);
