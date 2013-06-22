CREATE TABLE Diary
(
    DiaryEntryId        INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    DiaryEntryGuid      TEXT        NOT NULL,
    EntryTime           DATETIME    NOT NULL,
    Memo                TEXT        NOT NULL,
    LocationId          INTEGER         NULL,
    CategoryId          INTEGER         NULL,

    FOREIGN KEY(LocationId) REFERENCES Location(LocationId)
    FOREIGN KEY(CategoryId) REFERENCES Category(CategoryId)
);

CREATE UNIQUE INDEX idx_Diary_DiaryEntryId      ON Diary (DiaryEntryId);
CREATE UNIQUE INDEX idx_Diary_DiaryEntryGuid    ON Diary (DiaryEntryGuid);
CREATE UNIQUE INDEX idx_Diary_EntryTime         ON Diary (EntryTime);
