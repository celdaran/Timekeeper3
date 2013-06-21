CREATE TABLE SystemGridTimeDisplay
(
    SystemGridTimeDisplayId     INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime                  DATETIME NOT NULL,
    ModifyTime                  DATETIME NOT NULL,
    Name                        TEXT NOT NULL,
    Description                 TEXT
);
