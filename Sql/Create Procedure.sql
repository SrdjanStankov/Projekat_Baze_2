use Projekat_Baze_2;
go
create procedure SelectPosadaAndMornar as
begin
	select Posada.ID, Posada.Ime, Posada.Kapacitet, Posada.JMBG_Kormilar, Posada.JMBG_Kapetan, Posada.IDBroda  from Posada left outer join Mornar on Posada.ID = Mornar.ID order by Posada.ID;
	return;
end