use Projekat_Baze_2;
go
create procedure SelectPosadaAndMornar as
begin
	select Posada.ID, Posada.Ime, Posada.Kapacitet, Posada.JMBG_Kormilar, Posada.JMBG_Kapetan, Posada.IDBroda  from Posada left outer join Mornar on Posada.ID = Mornar.ID order by Posada.ID;
	return;
end
go
create procedure SelectTeretniBrodAndMornar as
begin
	select Teretni_Brod.IDBroda, Teretni_Brod.KapacTeret, Teretni_Brod.StatUtov from Teretni_Brod left outer join Mornar on Mornar.IDBroda = Teretni_Brod.IDBroda order by Teretni_Brod.IDBroda;
	return;
end
go
