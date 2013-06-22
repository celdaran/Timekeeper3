CREATE TABLE projects (
    id integer primary key,
    name string,
    descr string,
    parent_id integer,
    is_folder bool,
    is_deleted bool,
    timestamp_c datetime
)
