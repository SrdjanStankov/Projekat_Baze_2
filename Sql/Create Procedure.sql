create procedure SelectPosadaAndMornar as
begin
	select * from Posada left outer join Mornar on Posada.ID = Mornar.ID order by Posada.ID;
	return;
end