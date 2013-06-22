CREATE TABLE GridOptions
(
    GridOptionsId               INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime                  DATETIME    NOT NULL,
    ModifyTime                  DATETIME    NOT NULL,

    Name                        TEXT        NOT NULL,
    Description                 TEXT            NULL,
    SortOrderNo                 INTEGER         NULL,

    FilterOptionsId             INTEGER     NOT NULL,

    ItemTypeId                  INTEGER         NULL,
    SystemGridGroupById         INTEGER         NULL,
    SystemGridTimeDisplayId     INTEGER         NULL,

    FOREIGN KEY(FilterOptionsId) REFERENCES FilterOptions(FilterOptionsId)
    FOREIGN KEY(SystemGridGroupById) REFERENCES SystemGridGroupBy(SystemGridGroupById)
    FOREIGN KEY(SystemGridTimeDisplayId) REFERENCES SystemGridTimeDisplay(SystemGridTimeDisplayId)
);
