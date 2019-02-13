------------------------------------------------------------------------
-- Table..: Audit
-- Purpose: Database activity audit trail.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Audit
(
    AuditId             INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    EventTime           DATETIME    NOT NULL,
    Action              TEXT        NOT NULL,
    Memo                TEXT        NOT NULL
);
