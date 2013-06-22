CREATE TABLE Options
(
    OptionsId       INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime      DATETIME    NOT NULL,
    ModifyTime      DATETIME    NOT NULL,
    Key             TEXT        NOT NULL,
    Value           TEXT            NULL
);
