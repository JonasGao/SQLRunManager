CREATE TABLE sql_manager.sql_item
(
	id INT NOT NULL AUTO_INCREMENT
		PRIMARY KEY,
	database_id INT NOT NULL ,
	content VARCHAR(1000) NOT NULL ,
	records_affected INT NULL ,
	ran DATETIME NULL ,
	runner INT NULL,
	exception VARCHAR(500) NULL,
	message VARCHAR(1000) NULL,
	stack_trace VARCHAR(5000) NULL,
	created DATETIME NOT NULL,
	creater_id INT NOT NULL
) CHARSET 'utf8';