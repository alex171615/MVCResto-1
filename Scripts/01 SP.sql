-- Active: 1632321143175@@127.0.0.1@3306@mvcrestaurante

USE MVCRestaurante;
DELIMITER $$
DROP PROCEDURE IF EXISTS altaRestaurante $$
CREATE PROCEDURE altaRestaurante (out unidRestaurante SMALLINT, unNombre VARCHAR(45), unaDireccion VARCHAR(45), unMail VARCHAR(45), unTelefono INT, unaContrasenia VARCHAR(64))
BEGIN
      INSERT INTO Restaurante (nombre, direccion, mail, telefono, contrasenia)
                   VALUES (unNombre, unaDireccion, unMail, unTelefono, sha2(unaContrasenia, 256));
      SET unidRestaurante =  LAST_INSERT_ID();
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS altaCategoria $$
CREATE PROCEDURE altaCategoria(out unidCategoria SMALLINT, unNombre VARCHAR(45))
BEGIN
      INSERT INTO Categoria (nombre)
                  VALUES (unNombre);
      SET unidCategoria =  LAST_INSERT_ID();
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS altaPlato $$
CREATE PROCEDURE altaPlato(out unidPlato SMALLINT, unidRestaurante SMALLINT, unidCategoria SMALLINT, unNombre VARCHAR(45), unPrecio DECIMAL (7,2))
BEGIN
	 INSERT INTO Plato (idRestaurante, idCategoria, nombre, precio)
                 VALUES (unidRestaurante, unidCategoria, unNombre, unPrecio);
       SET unidPlato =  LAST_INSERT_ID();
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS restoPorPass $$
CREATE PROCEDURE restoPorPass (unMail VARCHAR(45), unaContrasenia VARCHAR(64))
BEGIN
      SELECT *
      FROM Restaurante
      WHERE unMail = mail
      AND sha2(unaContrasenia, 256) = contrasenia; 
END $$

DELIMITER $$

DROP PROCEDURE IF EXISTS llamarEstudio $$
CREATE PROCEDURE llamarEstudio(unIdEstudio int)
BEGIN
    SELECT *
    FROM Estudio
    WHERE idEstudio = unIdEstudio;
END $$

DELIMITER $$
DROP PROCEDURE IF EXISTS eliminarEstudio $$
CREATE PROCEDURE eliminarEstudio(unIdEstudio int)
BEGIN
    DELETE FROM Estudio
    WHERE idEstudio = unIdEstudio;
END $$


DELIMITER $$
DROP PROCEDURE IF EXISTS ActualizarRestaurante $$
CREATE PROCEDURE ActualizarRestaurante(out unidRestaurante SMALLINT, unNombre VARCHAR(45), unaDireccion VARCHAR(45), unMail VARCHAR(45), unTelefono INT, unaContrasenia VARCHAR(64))
BEGIN
    UPDATE RestaurantePorId
    SET idRestaurante = unidRestaurante,
        Nombre = unNombre
        Direccion = unaDireccion
        Mail = unMail
        Telefono = unTelefono
        Contrasenia = unaContrasenia
    WHERE idRestaurante =idRestaurante
END $$


