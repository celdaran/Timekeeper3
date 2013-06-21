CREATE TABLE FilterOptions
(
    FilterOptionsId             INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime                  DATETIME NOT NULL,
    ModifyTime                  DATETIME NOT NULL,

    Name                        TEXT,
    Description                 TEXT,
    SortOrderNo                 INTEGER,
    ActivityList                TEXT,
    ProjectList                 TEXT,
    SystemDatePresetId          INTEGER,
    FromDate                    DATETIME,
    ToDate                      DATETIME,
    -- need an "end date type" concept here: i.e., literal dates vs variable dates
    Memo                        TEXT,
    DurationOperator            INT,
    DurationAmount              INT,
    DurationUnit                INT,
    LocationList                TEXT,
    TagList                     TEXT,
);
