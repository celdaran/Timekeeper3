CREATE TABLE projects (
    id integer primary key,
    name string,
    descr string,
    parent_id integer,
    is_folder boolean,
    is_hidden boolean,
    is_deleted boolean,
    timestamp_c datetime,
    timestamp_m datetime
)
