CREATE TABLE tasks (
    id integer primary key,
    name string,
    descr string,
    parent_id integer,
    is_folder bool,
    is_deleted bool,
    project_id__last int,
    timestamp_c datetime,
    timestamp_m datetime
)