-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema origin
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema origin
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `origin` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `origin` ;

-- -----------------------------------------------------
-- Table `origin`.`tarjeta`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `origin`.`tarjeta` (
  `numero` BIGINT NOT NULL AUTO_INCREMENT,
  `bloqueada` BIT(1) NOT NULL,
  `pin` INT NOT NULL,
  `balance` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`numero`))
ENGINE = InnoDB
AUTO_INCREMENT = 1111444488890000
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `origin`.`balance`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `origin`.`balance` (
  `id_operacion` INT NOT NULL AUTO_INCREMENT,
  `id_tarjeta` BIGINT NOT NULL,
  `hora` DATETIME NOT NULL,
  PRIMARY KEY (`id_operacion`),
  INDEX `id_id_tarjeta_idx` (`id_tarjeta` ASC) VISIBLE,
  CONSTRAINT `id_id_tarjeta`
    FOREIGN KEY (`id_tarjeta`)
    REFERENCES `origin`.`tarjeta` (`numero`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `origin`.`retiro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `origin`.`retiro` (
  `id_operacion` INT NOT NULL AUTO_INCREMENT,
  `id_tarjeta` BIGINT NOT NULL,
  `hora` DATETIME NOT NULL,
  `cantidad` DECIMAL(10,2) NOT NULL,
  PRIMARY KEY (`id_operacion`),
  INDEX `id_tarjeta_id_idx` (`id_tarjeta` ASC) VISIBLE,
  CONSTRAINT `id_tarjeta_id`
    FOREIGN KEY (`id_tarjeta`)
    REFERENCES `origin`.`tarjeta` (`numero`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
