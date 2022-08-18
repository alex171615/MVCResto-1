-- Active: 1632321143175@@127.0.0.1@3306@mvcrestaurante
USE MVCRestaurante;

call altaCategoria(@idPollo, 'Pollo');
call altaCategoria(@idHamburguesa, 'Hambuerguesa');
call altaRestaurante(@idRestaurante,'el loro burger', 'av.libertador270','loroburger@gmail.com', 1123456789,'1234');
call altaplato(@idplato, @idCategoria, @idRestaurante,'Hamburguesa triple con salsa chedar',12000.99);