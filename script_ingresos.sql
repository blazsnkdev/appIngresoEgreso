select * from MiembrosFamilia
create table Ingreso(
IdIngreso int primary key identity(1,1),
Monto decimal(10,2)not null default 0,
IdMiembroFamilia int constraint fk_ingreso_miembro foreign key(IdMiembroFamilia) references MiembrosFamilia(IdMiembro)
)
select * from Ingreso
select * from MiembrosFamilia
go
create or alter procedure sp_nuevo_ingreso
@monto decimal(10,2),
@idMiembro int
as
begin
set nocount on;
begin tran;
begin try
        INSERT INTO Ingreso (Monto, FechaIngreso, IdMiembroFamilia)
        VALUES (@monto, GETDATE(), @idMiembro);
        UPDATE MiembrosFamilia
        set MontoTotal = isnull(MontoTotal,0) +@monto
        WHERE IdMiembro = @idMiembro;
commit tran;
end try
begin catch
rollback tran;
throw;
end catch
end;
go

alter table MiembrosFamilia add MontoTotal decimal(10,2)
alter table Ingreso add FechaIngreso datetime
select * from ingreso
select * from miembrosFamilia
exec sp_nuevo_ingreso 200,1
go
create or alter procedure sp_get_idMiembros
as
begin
select idMiembro,Nombre from MiembrosFamilia;
end
go