use db_gastos
select * from MiembrosFamilia
select * from Ingreso
select * from Gastos
create or alter procedure sp_info_monto_miembros
as
begin
select * from MiembrosFamilia
end;
go
select * from Ingreso
select * from MiembrosFamilia