 DELIMITER $$
-- EMPLOYESS
insert into employee (irs_number, lastname,firstname)
values
(1,"stavrou","john");

insert into employee (irs_number, lastname,firstname)
values
(3,"von","geo");


insert into employee (irs_number,firstname,lastname)
values
(2,'aris','von');

insert into employee (irs_number,firstname,lastname)
values
(4,'pan','athan');
-- STORES --
insert into store (storeid,street,city)
values
(01,"germanos",'karlovasi');

insert into store(storeid,street,city)
values
(2,'central','karlovasi');

insert into store(storeid,street,city)
values
(3,'ton kosmo', 'patra');

-- WORKS --
insert into works(storeid, irs_number,startdate,position)
values
(1, 1, '2010-01-01','dieuthintis');

insert into works(storeid, irs_number,startdate,position)
values
(2,2,'2010-01-01','servitoraios');

insert into works(storeid, irs_number,startdate,position)
values
(1,3,'2010-01-01','pwlitis');

insert into works(storeid, irs_number,startdate,position)
values
(3,3,'2015-01-01','foititis');

-- vehicle --
insert into vehicle(LicensePlate,Model,Make,Storeid)
values
('MOA0000','Fiesta','Ford',1);

insert into vehicle(LicensePlate,Model,Make,Storeid)
values
('MOA0001','Fiesta','Ford',1);

insert into vehicle(LicensePlate,Model,Make,Storeid)
values
('MOV0002','Duster','Ducia',2);

-- CUSTOMERS --
insert into customer(customerID, firstname, lastname)
values
(1,'pelatis','germanou');
$$
	DELIMITER ;
	