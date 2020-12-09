use master
go
-- Drop the database if it already exists
IF EXISTS (
SELECT name
FROM sys.databases
WHERE name = N'bd_ventas'
)
DROP DATABASE bd_ventas
GO
CREATE DATABASE bd_ventas
GO
USE bd_ventas
GO
CREATE TABLE Catalogo
(
Codigo int PRIMARY KEY,
Nombre varchar(100) NOT NULL,
Precio float NOT NULL,
);
GO
CREATE TABLE Factura
(
Codigo int PRIMARY KEY,
Cliente varchar(100) NOT NULL,
Fecha varchar(100) NOT NULL,
);
GO
CREATE TABLE Producto
(
Id int identity PRIMARY KEY,
Codigo int NOT NULL,
Nombre varchar(100) NOT NULL,
Precio float NOT NULL,
Cantidad int NOT NULL,
Fk_Codigo int FOREIGN KEY REFERENCES Factura(Codigo)
);
GO
INSERT INTO Catalogo VALUES(10,'Televisor',9000);
INSERT INTO Catalogo VALUES(11,'Laptop DELL',15000);
INSERT INTO Catalogo VALUES(12,'Refrigeradora',20000);
INSERT INTO Catalogo VALUES(13,'Abanico',900);
INSERT INTO Catalogo VALUES(14,'Plancha',2000);
INSERT INTO Catalogo VALUES(15,'Cocina',10000);
GO
INSERT INTO Factura VALUES (1, 'Carmen Salinas', '10-Octubre-2015');
INSERT INTO Factura VALUES (2, 'Luis Martinez','15-Mayo-2017');
INSERT INTO Factura VALUES (3, 'Roger Perez','20-Enero-2016');
GO
INSERT INTO Producto (Codigo, Nombre, Precio, Cantidad, Fk_Codigo) VALUES(10,'Televisor',9000,2,1);
INSERT INTO Producto (Codigo, Nombre, Precio, Cantidad, Fk_Codigo) VALUES(11,'Laptop DELL',15000,3,1);
INSERT INTO Producto (Codigo, Nombre, Precio, Cantidad, Fk_Codigo) VALUES(12,'Refrigeradora',20000,4,1);
INSERT INTO Producto (Codigo, Nombre, Precio, Cantidad, Fk_Codigo) VALUES(13,'Abanico',900,5,2);
INSERT INTO Producto (Codigo, Nombre, Precio, Cantidad, Fk_Codigo) VALUES(14,'Plancha',2000,6,2);
INSERT INTO Producto (Codigo, Nombre, Precio, Cantidad, Fk_Codigo) VALUES(10,'Televisor',9000,5,3);
INSERT INTO Producto (Codigo, Nombre, Precio, Cantidad, Fk_Codigo) VALUES(14,'Plancha',2000,2,3);
GO
select * from Factura;
select * from Producto;