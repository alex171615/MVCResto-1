-- Active: 1632321143175@@127.0.0.1@3306@mvcrestaurante

USE MVCRestaurante;
DELIMITER $$
DROP PROCEDURE IF EXISTS altaRestaurante $$
CREATE PROCEDURE altaRestaurante (out unidRestaurante INT, unNombre VARCHAR(45), unaDireccion VARCHAR(45), unMail VARCHAR(45), unTelefono INT, unaContrasenia CHAR(64))
BEGIN
      INSERT INTO Restaurante (nombre, direccion, mail, telefono, contrasenia)
                   VALUES (unNombre, unaDireccion, unMail, unTelefono, sha2(unaContrasenia, 256));
      SET unidRestaurante =  LAST_INSERT_ID();
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaCategoria $$
CREATE PROCEDURE altaCategoria(out unidCategoria INT, unNombre VARCHAR(45))
BEGIN
      INSERT INTO Categoria (nombre)
                  VALUES (unNombre);
      SET unidCategoria =  LAST_INSERT_ID();
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS altaPlato $$
CREATE PROCEDURE altaPlato(out unidPlato INT, unidRestaurante INT, unidCategoria INT, unNombre VARCHAR(45), unPrecio DECIMAL (7,2))
BEGIN
	 INSERT INTO Plato (idRestaurante, idCatergoria, nombre, precio)
                 VALUES (unidRestaurante, unidCategoria,unNombre, unPrecio);
       SET unidPlato =  LAST_INSERT_ID();
END $$