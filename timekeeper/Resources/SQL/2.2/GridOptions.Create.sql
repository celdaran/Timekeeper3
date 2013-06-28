CREATE TABLE grid_views (
    id integer primary key,
    name varchar,
    description varchar,
    sort_index int,
    task_list varchar,
    project_list varchar,
    date_preset int,
    start_date varchar,
    end_date varchar,
    end_date_type int,
    group_by int,
    data_from int,
    hide_empty_rows int,
    timestamp_c datetime,
    timestamp_m datetime
)
