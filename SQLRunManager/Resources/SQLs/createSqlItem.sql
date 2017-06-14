CREATE TABLE sql_manager.sql_item
(
	id INT NOT NULL AUTO_INCREMENT
		PRIMARY KEY,
	database_id INT NOT NULL ,
	content VARCHAR(1000) NOT NULL ,
	records_affected INT NULL ,
	ran DATETIME NULL ,
	runner INT NULL,
	created DATETIME NULL,
	creater_id INT NULL
) CHARSET 'utf8';