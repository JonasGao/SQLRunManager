create table sql_manager.user
(
	id int not null auto_increment
		primary key,
	email varchar(500) not null,
	nick_name varchar(500) not null,
	password varchar(500) not null,
	group_id SMALLINT NOT NULL DEFAULT 30,
	created datetime null,
	creater_id int null
);

INSERT INTO sql_manager.user VALUES (-1, 'root', 'root', '123456', -1, now(), -1);