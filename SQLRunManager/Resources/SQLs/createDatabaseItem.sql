create table sql_manager.database_item
(
	id int not null auto_increment
		primary key,
	title varchar(100) not null,
	server varchar(100) null,
	port int null,
	uid varchar(100) null,
	pwd varchar(100) null,
	removed bool not null default false,
	type varchar(100) not null,
	created datetime null,
	creater_id int null
);