create database db_gastos
use db_gastos
CREATE TABLE MiembrosFamilia (
    IdMiembro INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Rol VARCHAR(50) NULL 
);

CREATE TABLE Categorias (
    IdCategoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL,     
    Descripcion VARCHAR(200) NULL,
    Estado VARCHAR(20) DEFAULT 'ACTIVO'
);
CREATE TABLE Gastos (
    IdGasto INT PRIMARY KEY IDENTITY(1,1),
    IdMiembro INT NOT NULL,
    IdCategoria INT NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Descripcion VARCHAR(200) NULL,
    FechaGasto DATE NOT NULL,
    MetodoPago VARCHAR(50) NULL,   -- Ej: Efectivo, Yape, Tarjeta
    FOREIGN KEY (IdMiembro) REFERENCES MiembrosFamilia(IdMiembro),
    FOREIGN KEY (IdCategoria) REFERENCES Categorias(IdCategoria)
);
CREATE TABLE Servicios (
    IdServicio INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,       -- Ej: Luz, Agua, Internet
    Empresa VARCHAR(100) NULL,
    FechaRegistro DATE DEFAULT GETDATE(),
    Estado VARCHAR(20) DEFAULT 'ACTIVO'
);
CREATE TABLE PagosServicios (
    IdPagoServicio INT PRIMARY KEY IDENTITY(1,1),
    IdServicio INT NOT NULL,
    IdMiembro INT NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    FechaPago DATE NOT NULL,
    PeriodoMes INT NOT NULL,
    PeriodoAnio INT NOT NULL,
    EstadoPago VARCHAR(20) DEFAULT 'PAGADO',
    FOREIGN KEY (IdServicio) REFERENCES Servicios(IdServicio),
    FOREIGN KEY (IdMiembro) REFERENCES MiembrosFamilia(IdMiembro)
);
CREATE TABLE PresupuestoMensual (
    IdPresupuesto INT PRIMARY KEY IDENTITY(1,1),
    MontoTotal DECIMAL(10,2) NOT NULL,
    Mes INT NOT NULL,
    Anio INT NOT NULL
);

INSERT INTO MiembrosFamilia (Nombre, Rol)
VALUES ('Juan', 'Papá'), ('María', 'Mamá');

INSERT INTO Categorias (Nombre) 
VALUES ('Mercado'), ('Servicios'), ('Transporte'), ('Compras grandes');

INSERT INTO Servicios (Nombre, Empresa) 
VALUES ('Luz', 'Enel'), ('Agua', 'Sedapal'), ('Internet', 'Movistar');

INSERT INTO Gastos (IdMiembro, IdCategoria, Monto, Descripcion, FechaGasto, MetodoPago)
VALUES (1, 1, 120.50, 'Compra en el mercado', '2025-10-05', 'Efectivo');

INSERT INTO PagosServicios (IdServicio, IdMiembro, Monto, FechaPago, PeriodoMes, PeriodoAnio)
VALUES (1, 1, 150.00, '2025-10-02', 10, 2025);
go

create procedure sp_listar_categorias_activas
as
begin
set nocount on;
select IdCategoria, Nombre
from Categorias where Estado = 'ACTIVO'
end;
exec sp_listar_categorias_activas
go
create procedure sp_agregar_categoria
@Nombre varchar(20),
@Descripcion varchar(200)
as
begin
insert into Categorias (Nombre,Descripcion) values(@Nombre,@Descripcion);
end;
exec sp_agregar_categoria 'test','test'
go
create procedure sp_actualizar_categoria
@IdCategoria int,
@Nombre varchar(20),
@Descripcion varchar(200)
as
begin
update Categorias set 
Nombre = @Nombre,
Descripcion = @Descripcion
where IdCategoria = @IdCategoria;
end;
exec sp_actualizar_categoria 1,'test modificado','test modificado'
go
create procedure sp_dar_baja_categoria
@IdCategoria int
as
begin
update Categorias set
Estado = 'DESACTIVO'
where IdCategoria = @IdCategoria;
end;
exec sp_dar_baja_categoria 1
go
create procedure sp_eliminar_categoria
@IdCategoria int
as
begin
delete from Categorias where IdCategoria = @IdCategoria;
end;
exec sp_eliminar_categoria 1
go
create procedure sp_listar_categorias
as
begin
set nocount on;
select * from Categorias;
end;
go
exec sp_listar_categorias
go
create procedure sp_obtener_categoria_id
@IdCategoria int
as
begin
set nocount on;
select * from Categorias where IdCategoria = @IdCategoria;
end;
exec sp_obtener_categoria_id 5
go
--11/10/2025
create procedure sp_total_gastos_mes
as
begin
select sum(Monto) as totalGastoMes
from gastos where month(FechaGasto) =month(getdate());
end;
exec sp_total_gastos_mes
go
create procedure sp_total_servicios_mes
as
begin
select sum(Monto) as totalServicioMes
from PagosServicios where month(FechaPago) = month(getdate());
end;
exec sp_total_servicios_mes
go
select * from Gastos
go
create procedure sp_total_gasto_categoria_mes
@IdCategoria int,
@Mes int
as
begin
select sum(Monto) as total
from Gastos where IdCategoria = @IdCategoria and month(FechaGasto) = @Mes;
end;
exec sp_total_gasto_categoria_mes 1,3
go
create procedure sp_total_servicio_categoria_mes
@IdServicio int,
@Mes int
as
begin
select sum(Monto) as total
from PagosServicios where IdServicio = @IdServicio and month(FechaPago) = @Mes;
end;
exec sp_total_servicio_categoria_mes 1,3
go

select * from PagosServicios
exec sp_total_gastos_mes
exec sp_total_servicios_mes

select * from Gastos
go

-- MODULO GASTOS --
create procedure sp_registrar_gasto
@IdMiembro int,
@IdCategoria int,
@Monto decimal(10,2),
@Descripcion varchar(200),
@fechaGasto date,
@MetodoPago varchar(50)
as
begin
insert into Gastos (IdMiembro,IdCategoria,Monto,Descripcion,FechaGasto,MetodoPago)
values (@IdMiembro, @IdCategoria, @Monto,@Descripcion,@fechaGasto,@MetodoPago);
end;
select * from Gastos
exec sp_registrar_gasto 1,1,1200,'pago de la vaina esa che mal','Yape'
go
create procedure sp_editar_gasto
@IdGasto int,
@IdMiembro int,
@IdCategoria int,
@Monto decimal(10,2),
@Descripcion varchar(200),
@fechaGasto date,
@MetodoPago varchar(50)
as
begin
update Gastos set
IdMiembro = @IdMiembro,
IdCategoria = @IdCategoria,
Monto = @Monto,
Descripcion = @Descripcion,
FechaGasto = @fechaGasto,
MetodoPago = @MetodoPago
where IdGasto = IdGasto;
end;
exec sp_editar_gasto 3,1,2,200,'che la verdad me equivoque mal','Yape'
go
create procedure sp_eliminar_gasto
@IdGasto int
as
begin
delete from Gastos where IdGasto = @IdGasto;
end;
exec sp_eliminar_gasto 3
go
create procedure sp_filtrar_rango_fechas
@fechaInicio date,
@fechaFin date
as
begin
select * from Gastos where fechaGasto between @fechaInicio and @fechaFin;
end;
exec sp_filtrar_rango_fechas '2025-09-12','2025-10-03'
select * from gastos
go
create procedure sp_filtrar_gastos_categoria
@IdCategoria int
as
begin
select * from gastos where IdCategoria = @IdCategoria;
end;
exec sp_filtrar_gastos_categoria 2
go
create procedure sp_filtrar_gastos_miembro
@IdMiembro int
as
begin
select * from gastos where IdMiembro = @IdMiembro;
end;
exec sp_filtrar_gastos_miembro 1
go

create procedure sp_listar_miembros
as
begin
set nocount on;
select * from MiembrosFamilia;
end
go




exec sp_listar_miembros
use db_gastos
select * from gastos