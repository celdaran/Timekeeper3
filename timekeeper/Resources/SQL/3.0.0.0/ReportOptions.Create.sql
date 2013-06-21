CREATE TABLE ReportOptions
(
    ReportOptionsId     INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME NOT NULL,
    ModifyTime          DATETIME NOT NULL,
    Name                TEXT NOT NULL,
    Description         TEXT,
    FilterOptionsId     INTEGER,
    SortBy1             INTEGER,
    SortBy2             INTEGER,
    SortBy3             INTEGER
);
