------------------------------------------------------------------------
-- Table..: Todo
-- Purpose: This table keeps track of the user's todo list, as defined
--          by the Timekeeper projects in the same file. If UseProjects
--          isn't enabled, Todo lists are also disabled.
-- Added..: Timekeeper 3.0
-- Updated: Timekeeper 3.0
------------------------------------------------------------------------

CREATE TABLE Todo
(
    TodoId                  INTEGER     NOT NULL PRIMARY KEY AUTOINCREMENT,

    CreateTime              DATETIME    NOT NULL,
    ModifyTime              DATETIME    NOT NULL,

    ProjectId               INTEGER     NOT NULL,

    RefTodoStatusId         INTEGER     NOT NULL,
    StartTime               DATETIME        NULL,
    DueTime                 DATETIME        NULL,
    Memo                    TEXT            NULL,

    IsHidden                BOOLEAN     NOT NULL,
    IsDeleted               BOOLEAN     NOT NULL,
    HiddenTime              DATETIME        NULL,
    DeletedTime             DATETIME        NULL,

    FOREIGN KEY(ProjectId)              REFERENCES Project(ProjectId)
    FOREIGN KEY(RefTodoStatusId)        REFERENCES RefTodoStatus(RefTodoStatusId)
);

CREATE UNIQUE INDEX idx_Todo_TodoId ON Todo(TodoId);
