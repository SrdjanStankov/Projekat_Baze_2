create procedure selectPosadaAndMornar as

declare
	@ID uniqueidentifier,
	@Ime nvarchar(15),
	@Kapacitet int,
	@JMBG_Kormilar varchar(13),
	@JMBG_Kapetan varchar(13),
	@IDBroda uniqueidentifier,
	@JMBG varchar(13),
	@ImeMornar nvarchar(150),
	@Prezime nvarchar(150),
	@Pol varchar(50),
	@Rank nvarchar(150),
	@IDMornar uniqueidentifier,
	@IDBrodaMornar uniqueidentifier;

declare curName cursor
for select * from Posada left outer join Mornar on Posada.ID = Mornar.ID;

open curName;

fetch next from curName into
	@ID,
	@Ime,
	@Kapacitet,
	@JMBG_Kormilar,
	@JMBG_Kapetan,
	@IDBroda,
	@JMBG,
	@ImeMornar,
	@Prezime,
	@Pol,
	@Rank,
	@IDMornar,
	@IDBrodaMornar;

while @@FETCH_STATUS = 0
	begin
		fetch next from curName into
			@ID,
			@Ime,
			@Kapacitet,
			@JMBG_Kormilar,
			@JMBG_Kapetan,
			@IDBroda,
			@JMBG,
			@ImeMornar,
			@Prezime,
			@Pol,
			@Rank,
			@IDMornar,
			@IDBrodaMornar;
	end

close curName;
deallocate curName;