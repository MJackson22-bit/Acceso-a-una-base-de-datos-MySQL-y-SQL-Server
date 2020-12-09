CREATE SCHEMA IF NOT EXISTS `bd_login` DEFAULT CHARACTER SET utf8 COLLATE utf8_unicode_ci ;
USE `bd_login` ;
-- -----------------------------------------------------
-- Table `bd_login`.`tb_login`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `bd_login`.`tb_login` ;
CREATE TABLE IF NOT EXISTS `bd_login`.`tb_login` (
`nombre` VARCHAR(50) NULL ,
`usuario` VARCHAR(20) ,
`clave` VARCHAR(12) NULL ,
PRIMARY KEY (`usuario`) )
ENGINE = InnoDB;
INSERT INTO `bd_login`.`tb_login` VALUES('Alvaro Altamirano','admin','admin123');
INSERT INTO `bd_login`.`tb_login` VALUES('Maria Gonzalez','mgonzalez','maria123');
INSERT INTO `bd_login`.`tb_login` VALUES('Carlos Perez','cperez','carlos123');
SELECT * FROM tb_login;