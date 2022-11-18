DROP DATABASE
    IF EXISTS MVCRestaurante;


CREATE DATABASE
    MVCRestaurante;


USE MVCRestaurante;


CREATE TABLE
    Restaurante(
        idRestaurante SMALLINT NOT NULL AUTO_INCREMENT,
        nombre VARCHAR(45) NOT NULL,
        direccion VARCHAR(45) NOT NULL,
        mail VARCHAR(45) NOT NULL,
        telefono INT NOT NULL,
        contrasenia CHAR(64),
        CONSTRAINT PK_Restaurante PRIMARY KEY (idRestaurante),
        CONSTRAINT UQ_Restaurante_mail UNIQUE (mail)
    );



CREATE TABLE
    Categoria(
        idCategoria SMALLINT NOT NULL AUTO_INCREMENT,
        nombre VARCHAR(45) NOT NULL,
        CONSTRAINT PK_Categoria PRIMARY KEY (idCategoria)
    );



CREATE TABLE
    Plato(
        idPlato SMALLINT NOT NULL AUTO_INCREMENT,
        idRestaurante SMALLINT NOT NULL,
        idCategoria SMALLINT NOT NULL,
        nombre VARCHAR(45) NOT NULL,
        precio DECIMAL(7, 5) NOT NULL,
        CONSTRAINT PK_Plato PRIMARY KEY (idPlato),
        CONSTRAINT FK_Plato_Restaurante FOREIGN KEY (idRestaurante) REFERENCES Restaurante (idRestaurante),
        CONSTRAINT FK_Plato_Categoria FOREIGN KEY (idCategoria) REFERENCES Categoria (idCategoria)
    );