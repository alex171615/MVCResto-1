-- Active: 1632321143175@@127.0.0.1@3306@mvcrestaurante
USE MVCRestaurante;

call altaCategoria(@idPollo, 'Pollo');
call altaCategoria(@idHamburguesa, 'Hamburguesa');
call altaCategoria(@idSandwich, 'SandWich');
call altaRestaurante(@idLoroburguer,'el loro burger', 'av.libertador270','loroburger@gmail.com', 1123456789,'1234');
call altaRestaurante(@idLoroSandWich,'el loro Sandwich', 'av.libertador270','loroSandwich@gmail.com', 1123456789,'1234');
call altaPlato(@idPlato,1,1,'Hamburguesa triple con salsa chedar', 92.9);


call restoPorPass('loroburger@gmail.com', '1234');