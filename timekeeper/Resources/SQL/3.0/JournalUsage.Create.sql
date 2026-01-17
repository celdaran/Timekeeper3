------------------------------------------------------------------------
-- Table..: Journal
-- Purpose: This is an aggregate table used to keep track of how many
--          and how much each dimension is used. It has as many rows
--          as there are dimensions in use, and keeps track of counts
--          and sums of each in the Journal table. It's populated by
--          a process that runs in Timekeeper's idle item
-- Added..: Timekeeper 3.3
-- Updated: Timekeeper 3.3
------------------------------------------------------------------------

CREATE TABLE JournalUsage (
    RefDimensionId INTEGER NOT NULL,
    DimensionId INTEGER NOT NULL,
    TotalCount INTEGER DEFAULT 0,
    TotalSeconds INTEGER DEFAULT 0,
    LastMonthCount INTEGER DEFAULT 0,
    LastMonthSeconds INTEGER DEFAULT 0,
    PRIMARY KEY (RefDimensionId, DimensionId),
    FOREIGN KEY (RefDimensionId) REFERENCES RefDimension(RefDimensionId)
) WITHOUT ROWID;
