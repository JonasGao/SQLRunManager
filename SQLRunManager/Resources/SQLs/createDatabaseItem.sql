create table sql_manager.database_item
(
	id int not null auto_increment
		primary key,
	title varchar(100) not null,
	server varchar(100) not null,
	port int not null,
	uid varchar(100) not null,
	pwd varchar(100) not null,
	database_name varchar(100) not null,
	removed bool not null default false,
	type varchar(100) not null,
	created datetime not null,
	creater_id int not null
);