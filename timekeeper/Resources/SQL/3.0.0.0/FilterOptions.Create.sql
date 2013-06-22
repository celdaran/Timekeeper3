CREATE TABLE FilterOptions
(
    FilterOptionsId             INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime                  DATETIME    NOT NULL,
    ModifyTime                  DATETIME    NOT NULL,

    ActivityList                TEXT            NULL,
    ProjectList                 TEXT            NULL,
    SystemDatePresetId          INTEGER         NULL,
    FromDate                    DATETIME        NULL,
    -- need an "end date type" concept here: i.e., literal dates vs variable dates
    ToDate                      DATETIME        NULL,
    Memo                        TEXT            NULL,
    DurationOperator            INT             NULL,
    DurationAmount              INT             NULL,
    DurationUnit                INT             NULL,
    LocationList                TEXT            NULL,
    CategoryList                TEXT            NULL,

    FOREIGN KEY(SystemDatePresetId) REFERENCES SystemDatePreset(SystemDatePresetId)
);
