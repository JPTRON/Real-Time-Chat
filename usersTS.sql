CREATE DATABASE IF NOT EXISTS usersTS;
USE usersTS;

CREATE TABLE IF NOT EXISTS users(
	username VARCHAR(20) PRIMARY KEY NOT NULL,
    password VARCHAR(100) NOT NULL)
    ENGINE = INNODB;
    
INSERT IGNORE INTO users VALUES ("JoãoFerreira", SHA2("Arroz123+", 256)), ("RodrigoCarreira", SHA2("qwerty123", 256)), ("FernandoVideira", SHA2("ElFernaldo1", 256));
-- INSERT IGNORE INTO users VALUES ("JoãoFerreira", AES_ENCRYPT("Arroz123+", "Eu Gosto De Pão POGGERS")), ("RodrigoCarreira", AES_ENCRYPT("qwerty123", "Eu Gosto De Pão POGGERS")), ("FernandoVideira", AES_ENCRYPT("ElFernaldo1", "Eu Gosto De Pão POGGERS"));

SELECT * FROM users;
-- SELECT username, CAST(AES_DECRYPT(password, "Eu Gosto De Pão POGGERS") AS CHAR) as "password" FROM users;