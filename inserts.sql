 DELIMITER $$
-- EMPLOYESS
insert into employee (irs_number, firstname,lastname, Street, StreetNumber, PostalCode, City)
values
(1,"John","Stavrou", 'Karlovasi', '1', '83200', 'Samos'),
(2,'Aris','Von','','','',''),
(3,"Alex","Kourtis",'','','',''),
(4,'Harry','Potter','','','',''),
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
insert into store (storeid,street,streetnumber,postalcode,city)
values
(1,'Airport','','','Athens'),
(2,'Port','','','Piraeus'),
(3,'Stadiou','112','11630', 'Athina'),
(4,'Mesaio','4','83200','Karlovasi');

-- PHONES --
insert into phonenumber(storeid,num)
values
(1,2107231412),
(1,24511354),
(1,24512354),
(1,24513354),
(1,24513454),
(2,56546545);

-- WORKS --
insert into works(storeid, irs_number,startdate,position)
values
(1, 1, '2010-01-01','dieuthintis'),
(2,2,'2010-01-01','servitoraios'),
(1,3,'2010-01-01','pwlitis'),
(3,3,'2015-01-01','foititis');


-- vehicle --
insert into vehicle(LicensePlate,Model,Make,Storeid, kilometers, horsepower)
values
('MOA0001','Aygo','Toyota',2,40000,100),
('MOA0002','T5','Audi',3,20000,210),
('MOA0003','i3','Hyundai',2,120000,90),
('MOA0004','i3','Hyundai',2,110000,90),
('MOA0005','Yaris','Toyota',1,30000,130),
('MOA0006','Fiesta','Ford',1,50000,110),
('MOA0007','Fiesta','Ford',1,50000,110),
('MOV0002','Duster','Ducia',3,90000,150);


-- CUSTOMERS --
insert into customer(customerID, firstname, lastname)
values
(1,'pelatis','germanou');
$$
	DELIMITER ;
	