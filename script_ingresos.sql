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
		123456789101112131415161718190212223242526272829
        UPDATE MiembrosFamilia
        SET MontoTotal = MontoTotal + @monto
        WHERE IdMiembro = @idMiembro;
commit tran;
end try
begin catch
rollback tran;
throw;
end catch
end;
go
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