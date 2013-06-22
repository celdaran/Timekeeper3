CREATE TABLE Location
(
    LocationId      INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime      DATETIME    NOT NULL,
    ModifyTime      DATETIME    NOT NULL,
    LocationGuid    TEXT        NOT NULL,
    Name            TEXT        NOT NULL,
    Description     TEXT            NULL,
    SortOrderNo     INTEGER     NOT NULL,
    IsHidden        BOOLEAN     NOT NULL,
    IsDeleted       BOOLEAN     NOT NULL,
    HiddenTime      DATETIME        NULL,
    DeletedTime     DATETIME        NULL
);

CREATE UNIQUE INDEX idx_Location_LocationId ON Location (LocationId);
CREATE UNIQUE INDEX idx_Location_LocationGuid ON Location (LocationGuid);
