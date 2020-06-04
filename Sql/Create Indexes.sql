use Projekat_Baze_2;

create nonclustered index KapetanPrezimeIme
on Kapetan(prezime asc, ime asc);
go
create nonclustered index KormilarPrezimeIme
on Kormilar(prezime asc, ime asc);
go
create nonclustered index MornarPrezimeIme
on Mornar(prezime asc, ime asc);