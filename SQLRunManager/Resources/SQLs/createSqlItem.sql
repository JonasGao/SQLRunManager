CREATE TABLE sql_manager.sql_item
(
	id INT NOT NULL AUTO_INCREMENT
		PRIMARY KEY,
	DatabaseId INT NOT NULL ,
	Content VARCHAR(1000) NOT NULL ,
	RecordsAffected INT NULL ,
	Ran DATETIME NULL ,
	Runner INT NULL,
	created DATETIME NULL,
	creater_id INT NULL
) CHARSET 'utf8';