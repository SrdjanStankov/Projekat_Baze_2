use Projekat_Baze_2;
go
create trigger Add1NapravljenBrod
on Brod
after insert
as
declare @idBrodogradiliste uniqueidentifier;
select @idBrodogradiliste = i.IDBrodog from inserted i;
update Brodogradiliste set BrNaprBrod = BrNaprBrod + 1 where IDBrodog = @idBrodogradiliste;
go
create trigger Remove1NapravljenBrod
on Brod
for delete
as
declare @idBrodogradiliste uniqueidentifier;
select @idBrodogradiliste = i.IDBrodog from deleted i;
update Brodogradiliste set BrNaprBrod = BrNaprBrod - 1 where IDBrodog = @idBrodogradiliste;
go