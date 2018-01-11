 DELIMITER $$
-- EMPLOYESS
delete from employee;
insert into employee (irs_number, firstname,lastname, Street, StreetNumber, PostalCode, City)
values
(1,"John","Stavrou", 'Karlovasi', '1', '83200', 'Samos'),
(2,'Aris','Von','Pratinou','86','11634','Athens'),
(3,"Alex","Kourtis",'Galatsi','15','11002','Athens'),
(4,'Harry','Potter','Gryffindor','4','00123','Hogwarts'),
(5,'Ron','Weasley','','','',''),
(6,'Hermione','Granger','','','',''),
(7,'Albus','Dumbledore','','','',''),
(8,'Nevil','Longbottom','','','',''),
(9,'Tom','Riddle','','','',''),
(10,'Draco','Malfoy','','','',''),
(11,'Fred','Weasley','','','',''),
(12,'James','Potter','','','',''),
(13,'Lily','Potter','','','','');


-- STORES --
delete from store;
insert into store (storeid,street,streetnumber,postalcode,city)
values
(1,'Airport','','','Athens'),
(2,'Port','','','Piraeus'),
(3,'Stadiou','112','11630', 'Athina'),
(4,'Mesaio','4','83200','Karlovasi');

-- PHONES --
delete from phonenumber;
insert into phonenumber(storeid,num)
values
(1,2107231412),
(1,24511354),
(1,24512354),
(1,24513354),
(1,24513454),
(2,56546545);

-- WORKS --
delete from works;
insert into works(irs_number, storeid,startdate,position)
values
(7, 1, '2010-01-01','Headmaster'),
(1,1,'2010-01-01','Waiter'),
(2,2,'2015-01-01','Programmer'),
(3,3,'2012-01-01','ProPUBG'),
(4,4,'2010-01-01','Wizard'),
(5,1,'2009-01-01','Useless'),
(4,2,'2012-01-01','DoesAllTheWork'),
(4,3,'2014-01-01','Seeker'),
(2,1,'2015-01-01','SomeJob');


-- vehicle --
delete from vehicle;
insert into vehicle(LicensePlate,Model,Make,Storeid, kilometers, horsepower)
values
('MOA0001','Aygo','Toyota',2,40000,100),
('MOA0002','T5','Audi',3,20000,210),
('MOA0003','i3','Hyundai',2,120000,90),
('MOA0004','i3','Hyundai',2,110000,90),
('MOA0005','Yaris','Toyota',1,30000,130),
('MOA0006','Fiesta','Ford',1,50000,110),
('MOA0007','Fiesta','Ford',1,50000,110),
('MOV0002','Seat','Ibiza',4,35000,140),
('MOV0003','Lamborghini','Murcielago',3,6000,180),
('MOV0004','Volkswagen','Golf',2,80000,120),
('MOV0005','Renault','Clio',2,40000,90),
('MOV0006','Renault','Clio',2,45000,90),
('MOV0007','Kia','Sportage',3,140000,140),
('MOV0008','Duster','Ducia',3,90000,150);

-- CUSTOMERS --
delete from customers;
insert into customer(customerID, firstname, lastname)
values
(1,'pelatis','germanou');
$$
	DELIMITER ;
	