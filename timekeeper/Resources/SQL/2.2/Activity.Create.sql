CREATE TABLE tasks (
    id integer primary key,
    name string,
    descr string,
    parent_id integer,
    is_folder boolean,
    is_hidden boolean,
    is_deleted boolean,
    project_id__last int,
    timestamp_c datetime,
    timestamp_m datetime
)
