select * from gastos
select * from Ingreso
select * from PagosServicios
select * from servicios
go
create or alter procedure sp_pago_servicio
@IdServicio int,
@IdMiembro int,
@Monto decimal(10,2),
@FechaPago datetime,
@PeriodoMes int,
@PeriodoAnio int,
@EstadoPago varchar(100)
as
begin
insert into PagosServicios (IdServicio,IdMiembro,Monto,FechaPago,PeriodoMes,PeriodoAnio,EstadoPago)
values (@IdServicio,@IdMiembro,@Monto,@FechaPago,@PeriodoMes,@PeriodoAnio,@EstadoPago)
end
go
create or alter procedure sp_get_servicios
as
begin
select * from Servicios
end
go
exec sp_get_servicios
select * from PagosServicios
go
create or alter procedure sp_get_all_pagos_servicios
as
begin
select * from PagosServicios;
end
go
exec sp_get_all_pagos_servicios
exec sp_total_servicio_categoria_mes 1, 2