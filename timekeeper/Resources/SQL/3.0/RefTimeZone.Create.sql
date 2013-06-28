------------------------------------------------------------------------
-- Table..: RefTimeZone
-- Purpose: Map Windows' time zones to a unique, interinal identifier
--          better suited for use as foreign key constraints.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE RefTimeZone
(
    RefTimeZoneId       INTEGER     NOT NULL PRIMARY KEY,
    OSTimeZone          TEXT        NOT NULL
);

CREATE UNIQUE INDEX idx_RefTimeZone_RefTimeZoneId ON RefTimeZone(RefTimeZoneId);
