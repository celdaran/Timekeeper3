CREATE TABLE SystemGridGroupBy
(
    SystemGridGroupById         INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime                  DATETIME    NOT NULL,
    ModifyTime                  DATETIME    NOT NULL,
    Name                        TEXT        NOT NULL,
    Description                 TEXT            NULL
);
