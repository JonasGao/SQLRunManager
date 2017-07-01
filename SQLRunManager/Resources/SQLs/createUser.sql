create table sql_manager.user
(
	id int not null auto_increment
		primary key,
	email varchar(500) not null,
	nick_name varchar(500) not null,
	password varchar(500) not null,
	created datetime null,
	creater_id int null
);