drop procedure SelectPosadaAndMornar;
go
create procedure SelectPosadaAndMornar as
begin
	--declare
	--	@ID uniqueidentifier,
	--	@Ime nvarchar(15),
	--	@Kapacitet int,
	--	@JMBG_Kormilar varchar(13),
	--	@JMBG_Kapetan varchar(13),
	--	@IDBroda uniqueidentifier;

	--declare curName cursor
	--for select Posada.ID, Posada.Ime, Posada.Kapacitet, Posada.JMBG_Kormilar, Posada.JMBG_Kapetan, Posada.IDBroda from Posada left outer join Mornar on Posada.ID = Mornar.ID;

	--open curName;

	--fetch next from curName into
	--	@ID,
	--	@Ime,
	--	@Kapacitet,
	--	@JMBG_Kormilar,
	--	@JMBG_Kapetan,
	--	@IDBroda;

	--while @@FETCH_STATUS = 0
	--	begin
	--		fetch next from curName into
	--			@ID,
	--			@Ime,
	--			@Kapacitet,
	--			@JMBG_Kormilar,
	--			@JMBG_Kapetan,
	--			@IDBroda;
	--	end

	--close curName;
	--deallocate curName;
	select * from Posada left outer join Mornar on Posada.ID = Mornar.ID order by Posada.ID;
	return;
end