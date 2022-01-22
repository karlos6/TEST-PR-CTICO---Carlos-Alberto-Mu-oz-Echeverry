CREATE TABLE tb_bodega(
    id int identity not null primary key,
    nombre nvarchar(100) not null
)


CREATE TABLE tb_articulo(
    id int identity not null primary key,
    nombre  nvarchar(100) not null,
    descripcion nvarchar(300) not null,
    id_bodega int not null,
    foreign key (id_bodega) references tb_bodega
)


CREATE TABLE tb_log(
    id int identity not null primary key,
    fecha  nvarchar(100) not null,
    hora nvarchar(100) not null,
    id_bodega_origen int not null,
    id_bodega_destino int not null,
    id_articulo int not null,
    cantidadTranferidas int not null,
)