--Create table
create table Studentinformation
(
Studentid int not null primary key identity (1,1),
StudentName nvarchar (100) not null,
FatherName nvarchar(100)not null,
Phonenumber bigint not null,
Gender nvarchar(100)not null
)

drop table Studentinformation
select * from Studentinformation
--insertsp
create or alter procedure insertStudentinformation (@StudentName  nvarchar (100),@FatherName nvarchar(100),@Phonenumber bigint,@Gender nvarchar(100))
as
begin
insert into Studentinformation(StudentName,FatherName,Phonenumber,Gender)values(@StudentName,@FatherName,@Phonenumber,@Gender)
end
exec insertStudentinformation    'sibi','s',99455656656262,'male'
--updatesp with id
create or alter procedure updateStudentinformation(@Studentid int,@StudentName  nvarchar (100),@FatherName nvarchar(100),@Phonenumber bigint,@Gender nvarchar(100))
as
begin
update Studentinformation set StudentName=@StudentName,FatherName=@FatherName,Phonenumber=@Phonenumber,Gender=@Gender where Studentid=@Studentid
end
exec updateStudentinformation 3, 'Sibi','Raja',9876564532,'male'
--deletesp with id
create or alter procedure deleteStudentinformation (@Studentid int)
as
begin
delete from Studentinformation where Studentid=@Studentid
end
exec deleteStudentinformation 3