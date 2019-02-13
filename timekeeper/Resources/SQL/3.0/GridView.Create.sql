------------------------------------------------------------------------
-- Table..: GridView
-- Purpose: This table stores the settings and options for saving a 
--          particular view of the Grid window.
-- Added..: Timekeeper 2.1
-- Updated: Timekeeper 3.0
-- AKA....: This table was known as 'grid_views' prior to Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE GridView
(
    GridViewId          INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime          DATETIME    NOT NULL,
    ModifyTime          DATETIME    NOT NULL,
    
    Name                TEXT        NOT NULL,
    Description         TEXT            NULL,
    SortOrderNo         INTEGER         NULL,

    FilterOptionsId     INTEGER         NULL,

    RefDimensionId      INTEGER         NULL,
    RefGroupById        INTEGER         NULL,
    RefTimeDisplayId    INTEGER         NULL,

    FOREIGN KEY(FilterOptionsId)    REFERENCES FilterOptions(FilterOptionsId)
    FOREIGN KEY(RefDimensionId)     REFERENCES RefDimension(RefDimensionId)
    FOREIGN KEY(RefGroupById)       REFERENCES RefGroupBy(RefGroupById)
    FOREIGN KEY(RefTimeDisplayId)   REFERENCES RefTimeDisplay(RefTimeDisplayId)
);

CREATE UNIQUE INDEX idx_GridView_GridViewId ON GridView(GridViewId);
CREATE UNIQUE INDEX idx_GridView_Name ON GridView(Name);
