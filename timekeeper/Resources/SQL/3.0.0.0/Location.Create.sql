CREATE TABLE Location
(
    LocationId      INTEGER PRIMARY KEY AUTOINCREMENT,
    CreateTime      DATETIME NOT NULL,
    ModifyTime      DATETIME NOT NULL,
    Name            TEXT NOT NULL,
    Description     TEXT,
    SortOrderNo     INTEGER NOT NULL,
    IsHidden        BOOLEAN NOT NULL,
    IsDeleted       BOOLEAN NOT NULL
);

CREATE UNIQUE INDEX idx_Location_LocationId ON Location (LocationId);
