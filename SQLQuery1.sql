Create database PasteleriaRM;
use PasteleriaRM;

Create table tblClientes(
   idCliente  int IDENTITY(1,1) NOT NULL ,
   nit int not null,
   nombre varchar(20) not null,
   telf varchar(20) ,
   primary key (idCliente)
);

Create table tblTrabajador (
   idTrabajador  int IDENTITY(1,1) NOT NULL ,
   ciTrabajador int not null,
   nombre varchar(20) not null,
   telf varchar(20) not null,
   nick varchar(20) not null,
   estado int not null,
   primary key (idTrabajador),
   dateIn date not null,
   dateMod date
);


Create table tblPedido(
   idPedido  int IDENTITY(1,1) NOT NULL ,
   numPedido int not null,
   fechaInicio datetime not null,
   fechaEntrega datetime,
   costo money not null,
   estado int not null,
   idCliente int not null,
   idTrabajador int not null,
   direccion varchar(50),
   descripcionMap varchar(50),
   lat float, 
   lng float,

   primary key (idPedido),
   foreign key (idCliente) references tblClientes(idCliente),
   foreign key (idTrabajador) references tblTrabajador(idTrabajador)
);


Create table tblProducto (
   idProducto  int IDENTITY(1,1) NOT NULL,
   nombre varchar(20) not null,
   precio money not null,
   stock int not null,
   categoria varchar(10) not null,
   tama�o varchar(20) not null,
   produccion int not null,
   estatus int not null,
   foto image

   primary key (idProducto)
);

Create table tblIngredientes(
   idIngrediente  int IDENTITY(1,1) NOT NULL ,
   nombre varchar(20) not null,
   precio money not null,
   stock int not null,
   estado int not null,
   primary key (idIngrediente)
);
									
Create table tblProduccion(
   idProduccion  int IDENTITY(1,1) NOT NULL ,
   idProducto int not null,
   idIngredinte int not null,   
   primary key (idProduccion),
   foreign key (idProducto) references tblProducto(idProducto),   
   foreign key (idIngredinte) references tblIngredientes(idIngrediente)
);

Create table tblDetallePedido(
   idElaboracion  int IDENTITY(1,1) NOT NULL,
   idProducto int not null,
   idPedido int not null,
   cantidad int not null,
   primary key (idElaboracion),
   foreign key (idProducto) references tblProducto(idProducto),
   foreign key (idPedido) references tblPedido(idPedido)
);
select * from tblProducto
DELETE FROM tblProducto where idProducto = 3;

INSERT INTO tblProducto (precio, stock, categoria, tama�o, relleno, nombre) 
       VALUES	(20.5,5,'masitas', 'personal' , 'chocolate', 'Brownies');


INSERT INTO tblProducto (nombre, precio, stock, categoria, tama�o, produccion, estatus) 
       VALUES	('Tamales',20.8 ,0,'masitas', 'personal' , 1,1 ) SELECT SCOPE_IDENTITY();

INSERT INTO tblClientes (nombre, nit, telf) values ('Nicolas', 123456, '60019879');

INSERT INTO tblClientes (nombre, nit, telf) values ('Yerson', 555555, '6845987');

INSERT INTO tblClientes (nombre, nit, telf) values ('Juan', 654321, '258964');

INSERT INTO tblTrabajador(ciTrabajador, nombre,telf) values (9999999, 'Pedro',  '70977597');


alter table tblTrabajador add nick varchar(20)

update tblTrabajador set nick='Juan'
select * from tblTrabajador

alter table tblTrabajador alter column nick varchar(20) not null

SELECT * FROM tblTrabajador

Select P.idProducto, p.precio, p.stock, p.categoria, p.tama�o, p.saborMasa, p.saborRelleno, p.relleno, p.nombre
FROM tblProducto p, tblDetallePedido DP
WHERE p.idProducto = DP.idProducto and DP.idPedido = 1

SELECT precio FROM tblProducto WHERE idProducto = 1

SELECT * FROM tblproducto WHERE idProducto = 2

SELECT * FROM tblPedido

SELECT * FROM tblClientes

SELECT * FROM tblDetallePedido

SELECT Count(*)  FROM tblPedido    
SELECT * FROM tblTrabajador

INSERT into tblPedido (numPedido, fechaInicio, fechaEntrega, costo,  estado, idCliente, idTrabajador)              
values ( 18 , '12/03/2021' , '12/03/2021' , 20 , 1 , @idcliente , @idTrabajador ) SELECT SCOPE_IDENTITY()

SELECT * FROM tblPedido WHERE idCliente = 1 and lat is not null 