DROP DATABASE IF EXISTS MVCRestaurante;
CREATE DATABASE MVCRestaurante;
USE MVCRestaurante;

CREATE TABLE Restaurante(
			idRestaurante INT NOT NULL AUTO_INCREMENT,
            nombre VARCHAR(45) NOT NULL,
            direccion VARCHAR(45) NOT NULL,
            mail VARCHAR(45) NOT NULL,
            telefono INT NOT NULL,
            contrasenia CHAR(64),
            CONSTRAINT PK_Restaurante PRIMARY KEY (idRestaurante)
          
);

CREATE TABLE Categoria(
           idCategoria INT NOT NULL AUTO_INCREMENT,
           nombre VARCHAR(45) NOT NULL,
           CONSTRAINT PK_Categoria PRIMARY KEY (idCategoria)
);

CREATE TABLE Plato(
           idPlato INT NOT NULL AUTO_INCREMENT,
           idRestaurante INT NOT NULL,
           idCategoria INT NOT NULL,
           nombre VARCHAR(45) NOT NULL,
           precio DECIMAL(7,5) NOT NULL,
           CONSTRAINT PK_PLato PRIMARY KEY (idPlato),
           CONSTRAINT FK_PLATO_Restaurante FOREIGN KEY (idRestaurante) REFERENCES Restaurante (idRestaurante), 
           CONSTRAINT FK_PLATO_Categoria FOREIGN KEY (idCategoria) REFERENCES Categoria (idCategoria) 
);

