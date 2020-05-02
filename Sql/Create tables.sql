if not exists (select 1 from sys.databases where name = N'Projekat_Baze_2')
begin
	create database Projekat_Baze_2;
end;

use Projekat_Baze_2;

create table Kormilar (
	JMBG varchar(13) primary key,
	Ime nvarchar(150) not null,
	Prezime nvarchar(150) not null,
	Pol varchar(50)
);

create table Brodska_Linija (
	BrLin uniqueIdentifier primary key,
	Naziv nvarchar(150) not null,
	Tip nvarchar(50) not null,
	Polazna_tacka nvarchar(150) not null,
	Krajnja_tacka nvarchar(150) not null
);

create table Brodogradiliste (
	IDBrodog uniqueidentifier primary key,
	Naziv nvarchar(150) not null,
	Lokacija nvarchar(150) not null,
	BrNaprBrod int default 0,
	BrPrist int default 0,
	PosedSuvDok bit default 0,
);

create table Brod (
	IDBroda uniqueidentifier primary key,
	Ime nvarchar(150) not null,
	GodGrad date not null,
	MaxBrzina int,
	Duzina int,
	Sirina int,
	IDBrodog uniqueidentifier not null,
	foreign key (IDBrodog) references Brodogradiliste(IDBrodog)
);

create table Teretni_Brod (
	IDBroda uniqueidentifier primary key,
	KapacTeret int default 0,
	StatUtov nvarchar(50),
	foreign key (IDBroda) references Brod(IDBroda)
);

create table Tanker (
	IDBroda uniqueidentifier primary key,
	Nosivost int default 0,
	TipTeret nvarchar(50),
	foreign key (IDBroda) references Brod(IDBroda)
);

create table Kruzer (
	IDBroda uniqueidentifier primary key,
	BrPutnika int default 0,
	BrOsoblja int default 0,
	foreign key (IDBroda) references Brod(IDBroda)
);

create table Kapetan (
	JMBG varchar(13) primary key,
	Ime nvarchar(150) not null,
	Prezime nvarchar(150) not null,
	Pol varchar(50),
	GodRodj date,
	BrLin uniqueidentifier not null,
	IDBroda uniqueidentifier not null,
	foreign key (BrLin) references Brodska_Linija(BrLin),
	foreign key (IDBroda) references Brod(IDBroda)
);

create table Posada (
	ID uniqueidentifier primary key,
	Ime nvarchar(15) not null,
	Kapacitet int default 0,
	JMBG_Kormilar varchar(13) not null,
	JMBG_Kapetan varchar(13) not null,
	IDBroda uniqueidentifier not null,
	foreign key (JMBG_Kormilar) references Kormilar(JMBG),
	foreign key (JMBG_Kapetan) references Kapetan(JMBG),
	foreign key (IDBroda) references Brod(IDBroda)
);

create table Mornar (
	JMBG varchar(13) primary key,
	Ime nvarchar(150) not null,
	Prezime nvarchar(150) not null,
	Pol varchar(50),
	Rank nvarchar(150) not null,
	ID uniqueidentifier,
	IDBroda uniqueidentifier,
	foreign key (ID) references Posada(ID),
	foreign key (IDBroda) references Teretni_Brod(IDBroda)
);

create table Poseduje (
	IDBroda uniqueidentifier,
	BrLin uniqueidentifier,
	foreign key (IDBroda) references Brod(IDBroda),
	foreign key (BrLin) references Brodska_Linija(BrLin),
	primary key (IDBroda, BrLin)
);

create table Popravlja (
	IDBroda uniqueidentifier,
	BrLin uniqueidentifier,
	IDBrodog uniqueidentifier,
	foreign key (IDBrodog) references Brodogradiliste(IDBrodog),
	foreign key (IDBroda, BrLin) references Poseduje(IDBroda, BrLin),
	primary key (IDBroda, BrLin, IDBrodog)
);