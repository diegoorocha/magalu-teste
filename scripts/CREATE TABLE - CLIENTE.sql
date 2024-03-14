CREATE TABLE `magalu`.`cliente` (
  `id` VARCHAR(36) NOT NULL,
  `nome_razao_social` VARCHAR(150) NOT NULL,
  `email` VARCHAR(150) NOT NULL,
  `telefone` VARCHAR(11) NOT NULL,
  `data_cadastro` DATETIME NOT NULL,
  `tipo_pessoa` INT(1) NOT NULL,
  `documento` VARCHAR(14) NOT NULL,
  `inscricao_estadual` VARCHAR(12) NULL,
  `isento` TINYINT NOT NULL,
  `genero` INT(1) NOT NULL,
  `data_nascimento` DATE NOT NULL,
  `bloqueado` TINYINT NOT NULL,
  `senha` VARCHAR(250) NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC) VISIBLE);