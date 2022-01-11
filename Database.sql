create table PDFFile(
ID int not null identity(1,1),
Name NVarchar(60) not null,
Location NVarchar(200) not null,
Filesize int default 0
primary key (ID)
)
go

