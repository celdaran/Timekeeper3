------------------------------------------------------------------------
-- Table..: GridOptions
-- Purpose: This table stores user options for saving a particular view
--          of the Grid display.
-- Added..: Timekeeper 2.1
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'grid_views' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE GridOptions
(
    GridOptionsId       INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,
    SortOrderNo         INTEGER         NULL,

    FilterOptionsId     INTEGER     NOT NULL,

    RefItemTypeId       INTEGER         NULL,
    RefGroupById        INTEGER         NULL,
    RefTimeDisplayId    INTEGER         NULL,

    FOREIGN KEY(FilterOptionsId)    REFERENCES FilterOptions(FilterOptionsId)
    FOREIGN KEY(RefItemTypeId)      REFERENCES RefItemType(RefItemTypeId)
    FOREIGN KEY(RefGroupById)       REFERENCES RefGroupBy(RefGroupById)
    FOREIGN KEY(RefTimeDisplayId)   REFERENCES RefTimeDisplay(RefTimeDisplayId)
);


CREATE UNIQUE INDEX idx_GridOptions_GridOptionsId ON GridOptions(GridOptionsId);
CREATE UNIQUE INDEX idx_GridOptions_Name ON GridOptions(Name);
