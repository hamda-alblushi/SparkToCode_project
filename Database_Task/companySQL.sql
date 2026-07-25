create database CompanyDB;

use CompanyDB;

create table Employee 
(
	Fname varchar(20) not null,
	Minit varchar(20),
	Lname varchar(20) not null,
	Ssn int primary key identity(1, 1),
	Bdate date,
	EAddress varchar(100), 
	Gender bit default 0,
	Salary int constraint CK_Employee_Salary check(Salary between 500 and 3500),
	Supervise_ssn int,
	foreign key (Supervise_ssn) references Employee(Ssn),
	Dno int,
	foreign key (Dno) references Department(Dnumber),
);

create table Department 
(
	Dname varchar(20),
	Dnumber int primary key identity(1, 1),
	Mgr_ssn int,
	foreign key (Mgr_ssn) references Employee(Ssn),
	Mgr_start_date date,
);

create table dept_locations
(
	Dnumber int,
	foreign key (Dnumber) references Department(Dnumber),
	Dlocation varchar(100),
	Primary key (Dnumber, Dlocation),
);

create table Project
(
	Pname varchar(20),
	Pnumber int primary key identity(1, 1),
	Plocation varchar(100),
	Dnum int,
	foreign key (Dnum) references Department(Dnumber),
);

create table works_on
(
	Essn int,
	foreign key (Essn) references Employee(Ssn),
	Pno int,
	foreign key (Pno) references Project(pnumber),
	Hrs int not null,
	Primary key (Essn, Pno),
);

create table EDependent
(
	Essn int,
	foreign key (Essn) references Employee(Ssn),
	Dependent_name varchar(20) not null,
	Primary key (Essn, Dependent_name),
);

select * from Employee;

insert into Employee(Fname, Lname, Bdate, Gender, Salary)
values ('Hamda', 'Essa', '2005-6-20', 1, 2100),
	   ('Fatma', 'Saleh', '2001-11-22', 1, 1100),
	   ('Noora', 'Ibrahim', '2009-1-1', 0, 1500),
	   ('Maitha', 'Nasser', '2011-11-11', 1, 900),
	   ('Meera', 'Yousef', '2007-3-4', 1, 760);

update Employee set Salary += 25;
update Employee set Salary += 25 where Ssn = 6;
update Employee set EAddress = 'Nizwa' where Salary > 1000;
update Employee set Dno = 2 where Bdate >= '2009-1-1';
update Employee set Gender = 0 where Fname = 'Sarah';

delete from Employee where Ssn = 7;
delete from Employee where Salary < 1000;