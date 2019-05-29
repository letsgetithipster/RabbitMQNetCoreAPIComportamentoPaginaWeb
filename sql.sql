Create Database LogComportamentoPagina
Go
Use LogComportamentoPagina

Create Table Comportamento(
[Id] int Identity (1,1) Primary Key,
[IP] varchar(15),
[NomePagina] varchar(50),
[Browser] varchar(50),
[Parametros] varchar(100)
);