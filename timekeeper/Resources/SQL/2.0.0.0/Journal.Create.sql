CREATE TABLE timekeeper (
    id integer primary key,
    task_id integer,
    project_id integer,
    timestamp_s datetime,
    timestamp_e datetime,
    seconds integer,
    pre_log varchar,
    post_log varchar,
    is_locked bool
)
