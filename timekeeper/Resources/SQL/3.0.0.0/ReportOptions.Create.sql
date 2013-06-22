CREATE TABLE ReportOptions
(
    ReportOptionsId             INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime                  DATETIME    NOT NULL,
    ModifyTime                  DATETIME    NOT NULL,

    Name                        TEXT        NOT NULL,
    Description                 TEXT            NULL,
    SortOrderNo                 INTEGER         NULL,

    FilterOptionsId             INTEGER     NOT NULL,

    SortBy1                     INTEGER         NULL,
    SortBy2                     INTEGER         NULL,
    SortBy3                     INTEGER         NULL,

    FOREIGN KEY(FilterOptionsId) REFERENCES FilterOptions(FilterOptionsId)
);
