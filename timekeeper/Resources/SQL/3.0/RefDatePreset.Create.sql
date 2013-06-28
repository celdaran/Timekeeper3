------------------------------------------------------------------------
-- Table..: RefDatePreset
-- Purpose: The data filtering interface uses a drop-down selection of
--          date presets for quick date-range selection. For example,
--          Today, Last Week, This Month, Last Year, and so on. Those
--          values are stored here.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE RefDatePreset
(
    RefDatePresetId     INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,
    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL
);
