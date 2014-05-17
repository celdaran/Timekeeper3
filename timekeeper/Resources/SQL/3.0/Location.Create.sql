------------------------------------------------------------------------
-- Table..: Location
-- Purpose: Provide a method for tagging Timekeeper data with a specific
--          geographic location as well as a time zone. The time zone
--          data, combined with row timestamps can be used to determine
--          whether a particular entry was recorded with DST or not.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Location
(
    LocationId          INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    LocationGuid        TEXT        NOT NULL,

    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,

    ParentId            INTEGER         NULL,
    SortOrderNo         INTEGER         NULL,
    IsFolder            BOOLEAN     NOT NULL,
    IsFolderOpened      BOOLEAN     NOT NULL,
    IsHidden            BOOLEAN     NOT NULL,
    IsDeleted           BOOLEAN     NOT NULL,
    HiddenTime          DATETIME        NULL,
    DeletedTime         DATETIME        NULL,

    RefTimeZoneId       INTEGER     NOT NULL,

    FOREIGN KEY(RefTimeZoneId)      REFERENCES RefTimeZone(RefTimeZoneId)
);

CREATE UNIQUE INDEX idx_Location_LocationId ON Location(LocationId);
CREATE UNIQUE INDEX idx_Location_LocationGuid ON Location(LocationGuid);
CREATE UNIQUE INDEX idx_Location_Name ON Location(Name);
