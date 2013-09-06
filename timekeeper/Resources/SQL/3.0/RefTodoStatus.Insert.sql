------------------------------------------------------------------------
-- Table..: RefTodoStatus
-- Purpose: Populate a reference table to define Todo list statuses
------------------------------------------------------------------------

-- Not Started
-- In Progress
-- Completed
-- Blocked
-- On Hold

INSERT INTO RefTodoStatus
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Not Started',
    'The project has not been started.'
);

INSERT INTO RefTodoStatus
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'In Progress',
    'The project has been started and is not yet complete.'
);

INSERT INTO RefTodoStatus
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'On Hold',
    'Work on the project is currently suspended.'
);

INSERT INTO RefTodoStatus
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Blocked',
    'Progress on the project is blocked.'
);

INSERT INTO RefTodoStatus
(
    CreateTime,
    ModifyTime,
    Name,
    Description

) VALUES (
    '{0}',
    '{0}',
    'Completed',
    'The project has been completed.'
);
