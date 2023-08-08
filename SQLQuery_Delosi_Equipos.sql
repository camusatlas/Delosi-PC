use master
go
--
Create database DB_Equipos_Tienda
go
--
Use DB_Equipos_Tienda
go
--Crear las tablas de Servidores, Punto de ventas(WS6,WS6A y WS5A) y KDS
--Tabla Servidores - Tienda
Create table Servidores
(
Nom_Emp varchar(100),
Comp_Tienda varchar(100),
Num varchar(300),
Departamento varchar(100),
Provincia varchar(100),
Distrito varchar(100),
Region varchar(100),
Servidor_IP varchar(25),
HostName varchar(100),
Estado_Tienda varchar(100),
Vers_Micros varchar(100),
Tamaño_BD varchar(100),
S_O  varchar(100),
Ram varchar(100),
Model_Equipo varchar(100),
Serial_Equipo varchar(100),
Nom_Tienda varchar(100),
Tecnico_Asigando varchar(100),
Fecha_Instalacion varchar(10),
Observaciones varchar(100),
Nom_Tienda_DWH varchar(100),
Email VARCHAR(255),
Telefono_Tienda char(9),
Direccion_Tienda varchar(500),
Latitud varchar(300),
Longitud varchar(300),
Categoria varchar(150),
Join_Tienda varchar(150)
)
go
select * from Servidores
go
drop table Servidores
go
--Tabla Punto de Venta - Tienda
Create table Punto_Venta
(
Nom_Empresa varchar(100),
Comp_tienda varchar(100),
Num_Tienda varchar(300),
Nomb_Teinda varchar(300),
IP_WS varchar(25),
Estado_Tienda varchar(100),
Modelo varchar(100),
Status_WS varchar(100),
Join_Tienda varchar(100)
)
go
select * from Punto_Venta
go
--Tabla KDS - Tienda
Create Table KDS
(
Nom_Empresa varchar(100),
Comp_tienda varchar(100),
Num_Tienda varchar(300),
Nomb_Teinda varchar(300),
IP_KDS varchar(25),
HostName varchar(80),
Estado_Tienda varchar(100),
Modelo varchar(100),
Status_WS varchar(100),
Join_Tienda varchar(100)
)
go
select * from KDS
go
--Listado de Servidores
Create Proc List_Servidores
as
Begin
	select * from Servidores
End
go
--Listado de Punto de Venta
Create Proc List_Punto_Venta
as
Begin
	select * from Punto_Venta
End
go
--Listado de KDS
Create Proc List_KDS
as
Begin
	select * from KDS
End
go
--Inser Datos en Servidores
Create Proc Ing_Servidores
@Nom_Emp varchar(100),
@Comp_Tienda varchar(100),
@Num varchar(300),
@Departamento varchar(100),
@Provincia varchar(100),
@Distrito varchar(100),
@Region varchar(100),
@Servidor_IP varchar(25),
@HostName varchar(100),
@Estado_Tienda varchar(100),
@Vers_Micros varchar(100),
@Tamaño_BD varchar(100),
@S_O  varchar(100),
@Ram varchar(100),
@Model_Equipo varchar(100),
@Serial_Equipo varchar(100),
@Nom_Tienda varchar(100),
@Tecnico_Asigando varchar(100),
@Fecha_Instalacion varchar(10),
@Observaciones varchar(100),
@Nom_Tienda_DWH varchar(100),
@Email VARCHAR(255),
@Telefono_Tienda char(9),
@Direccion_Tienda varchar(500),
@Latitud varchar(300),
@Longitud varchar(300),
@Categoria varchar(150),
@Join_Tienda varchar(150)
as
Begin
	Insert Servidores
	values(@Nom_Emp,@Comp_Tienda,@Num,@Departamento,@Provincia,@Distrito,@Region,@Servidor_IP,@HostName,@Estado_Tienda,@Vers_Micros,@Tamaño_BD,@S_O,@Ram,@Model_Equipo,
@Serial_Equipo,@Nom_Tienda,@Tecnico_Asigando,@Fecha_Instalacion,@Observaciones,@Nom_Tienda_DWH,@Email,@Telefono_Tienda,@Direccion_Tienda,@Latitud,
@Longitud,@Categoria,@Join_Tienda)
End
go
drop Proc Update_Servidores
go
--Insertar Punto de Venta
Create Proc Ing_Punto_Ventas
@Nom_Empresa varchar(100),
@Comp_tienda varchar(100),
@Num_Tienda varchar(300),
@Nomb_Teinda varchar(300),
@IP_WS varchar(25),
@Estado_Tienda varchar(100),
@Modelo varchar(100),
@Status_WS varchar(100),
@Join_Tienda varchar(100)
as
Begin
 Insert Punto_Venta
 Values(@Nom_Empresa,@Comp_tienda,@Num_Tienda,@Nomb_Teinda,@IP_WS,@Estado_Tienda,@Modelo,@Status_WS,@Join_Tienda)
End
go
--Insertar KDS
Create Proc Ing_KDS
@Nom_Empresa varchar(100),
@Comp_tienda varchar(100),
@Num_Tienda varchar(300),
@Nomb_Teinda varchar(300),
@IP_KDS varchar(25),
@HostName varchar(80),
@Estado_Tienda varchar(100),
@Modelo varchar(100),
@Status_WS varchar(100),
@Join_Tienda varchar(100)
as
Begin
	Insert KDS
values(@Nom_Empresa,@Comp_tienda,@Num_Tienda,@Nomb_Teinda,@IP_KDS,@HostName,@Estado_Tienda,@Modelo,@Status_WS,@Join_Tienda)
End
go
--Actualizar la Table Servidores
Create Proc Upd_Servidores
@Nom_Emp varchar(100),
@Comp_Tienda varchar(100),
@Num varchar(300),
@Departamento varchar(100),
@Provincia varchar(100),
@Distrito varchar(100),
@Region varchar(100),
@Servidor_IP varchar(25),
@HostName varchar(100),
@Estado_Tienda varchar(100),
@Vers_Micros varchar(100),
@Tamaño_BD varchar(100),
@S_O  varchar(100),
@Ram varchar(100),
@Model_Equipo varchar(100),
@Serial_Equipo varchar(100),
@Nom_Tienda varchar(100),
@Tecnico_Asigando varchar(100),
@Fecha_Instalacion varchar(10),
@Observaciones varchar(100),
@Nom_Tienda_DWH varchar(100),
@Email VARCHAR(255),
@Telefono_Tienda char(9),
@Direccion_Tienda varchar(500),
@Latitud varchar(300),
@Longitud varchar(300),
@Categoria varchar(150),
@Join_Tienda varchar(150)
as
Begin
	update Servidores
	set Nom_Emp=@Nom_Emp,
		Comp_Tienda=@Comp_Tienda,
		Num=@Num,
		Departamento=@Departamento,
		Provincia=@Provincia,
		Distrito=@Distrito,
		Region=@Region,
		Servidor_IP=@Servidor_IP,
		HostName=@HostName,
		Estado_Tienda=@Estado_Tienda,
		Vers_Micros=@Vers_Micros,
		Tamaño_BD=@Tamaño_BD,
		S_O=@S_O,
		Ram=@Ram,
		Model_Equipo=@Model_Equipo,
		Serial_Equipo=@Serial_Equipo,
		Tecnico_Asigando=@Tecnico_Asigando,
		Fecha_Instalacion=@Fecha_Instalacion,
		Observaciones=@Observaciones,
		Nom_Tienda_DWH=@Nom_Tienda_DWH,
		Email=@Email,
		Telefono_Tienda=@Telefono_Tienda,
		Direccion_Tienda=@Direccion_Tienda,
		Latitud=@Latitud,
		Longitud=@Longitud,
		Categoria=@Categoria,
		Join_Tienda=@Join_Tienda
		where Nom_Tienda=@Nom_Tienda
End
go
--Actualizar Punto de Ventas
drop proc Upd_Punto_Venta
go
Create Proc Upd_Punto_Venta
@Nom_Empresa varchar(100),
@Comp_tienda varchar(100),
@Num_Tienda varchar(300),
@Nomb_Teinda varchar(300),
@IP_WS varchar(25),
@Estado_Tienda varchar(100),
@Modelo varchar(100),
@Status_WS varchar(100),
@Join_Tienda varchar(100)
as
Begin
	Update Punto_Venta
	set Nom_Empresa=@Nom_Empresa,
		Comp_tienda=@Comp_tienda,
		Num_Tienda=@Num_Tienda,
		Nomb_Teinda=@Nomb_Teinda,
		IP_WS=@IP_WS,
		Estado_Tienda=@Estado_Tienda,
		Modelo=@Modelo,
		Status_WS=@Status_WS,
		Join_Tienda=@Join_Tienda
		where IP_WS=@IP_WS
End
go
--Actualizar KDS
Create Proc Upd_KDS
@Nom_Empresa varchar(100),
@Comp_tienda varchar(100),
@Num_Tienda varchar(300),
@Nomb_Teinda varchar(300),
@IP_KDS varchar(25),
@HostName varchar(80),
@Estado_Tienda varchar(100),
@Modelo varchar(100),
@Status_WS varchar(100),
@Join_Tienda varchar(100)
as
Begin
	Update KDS
	set Nom_Empresa=@Nom_Empresa,
		Comp_tienda=@Comp_tienda,
		Num_Tienda=@Num_Tienda,
		Nomb_Teinda=@Nomb_Teinda,
		IP_KDS=@IP_KDS,
		HostName=@HostName,
		Estado_Tienda=@Estado_Tienda,
		Modelo=@Modelo,
		Status_WS=@Status_WS,
		Join_Tienda=@Join_Tienda
		where IP_KDS=@IP_KDS
End
go
--Buscar Servidor
Create Proc BuscServidor
@Nom_Tienda varchar(100)
as
Begin
	select * from Servidores
	where Nom_Tienda LIKE @Nom_Tienda + '%'
End
go
--Elminar datos de Servidor
Create Proc DeleteServidor
@Nom_Tienda varchar(100)
as
Begin
    delete FROM Servidores
    where Nom_Tienda = @Nom_Tienda
end
go
--Buscar Punto Venta
Create Proc BuscPuntoVenta
@Join_Tienda varchar(100)
as
Begin
	select * from Punto_Venta
	where Join_Tienda LIKE @Join_Tienda + '%'
End
go
select * from Punto_Venta
go
--Buscar KDS
Create Proc BuscKDS
@Join_Tienda varchar(100)
as
Begin
	select * from Punto_Venta
	where Join_Tienda LIKE @Join_Tienda + '%'
End
go
select * from KDS
go

drop proc BuscPuntoVenta
go