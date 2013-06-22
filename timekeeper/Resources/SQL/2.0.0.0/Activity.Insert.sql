INSERT INTO tasks (
    name,
    descr,
    parent_id,
    is_folder,
    is_deleted,
    timestamp_c
) VALUES (
    'Default Task',
    'Right click this task and select Edit to change the name or this description',
    0,
    0,
    0,
    datetime('now')
)
