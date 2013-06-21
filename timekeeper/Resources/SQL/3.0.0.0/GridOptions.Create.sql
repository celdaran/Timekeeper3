CREATE TABLE GridOptions
(
    GridOptionsId               INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime                  DATETIME NOT NULL,
    ModifyTime                  DATETIME NOT NULL,
    Name                        TEXT NOT NULL,
    Description                 TEXT,
    SortOrderNo                 INTEGER,
    ActivityFilter              TEXT,
    ProjectFilter               TEXT,
    SystemDatePresetId          INTEGER,
    FromDate                    DATETIME,
    ToDate                      DATETIME,
    EndDateType                 INTEGER,
    ItemTypeId                  INTEGER,
    SystemGridGroupById         INTEGER,
    SystemGridTimeDisplayId     INTEGER
);
