 DELIMITER $$
-- EMPLOYESS
delete from employee;
insert into employee (irs_number, firstname,lastname, Street, StreetNumber, PostalCode, City)
values
(1,"John","Stavrou", 'Karlovasi', '1', '83200', 'Samos'),
(2,'Aris','Von','Pratinou','86','11634','Athens'),
(3,"Alex","Kourtis",'Galatsi','15','11002','Athens'),
(4,'Harry','Potter','Gryffindor','4','00123','Hogwarts'),
(5,'Ron','Weasley','Gryffindor','6','00123','Hogwarts'),
(6,'Hermione','Granger','Gryffindor','5','00123','Hogwarts'),
(7,'Albus','Dumbledore','BigTower','1','00123','Hogwarts'),
(8,'Nevil','Longbottom','Gryffindor','7','00123','Hogwarts'),
(9,'Tom','Riddle','Forbidden','0','12300','Forest'),
(10,'Draco','Malfoy','Slytherin','10','00123','Hogwarts'),
(11,'Fred','Weasley','WeasleyHouse','1','123','Weasley'),
(12,'James','Potter','Godricks','1','72000','Hollow'),
(13,'Lily','Potter','Godricks','1','72000','Hollow'),
(14,'Lord','Voldemord','Forbidden','0','12300','Forest'),
(15,'Vrasidas','Xlempouras','KwnKaiElenhs','15','12321','Athens');

-- STORES --
delete from store;
insert into store (storeid,street,streetnumber,postalcode,city)
values
(1,'Airport','','','Athens'),
(2,'Port','','','Piraeus'),
(3,'Stadiou','112','11630', 'Athina'),
(4,'Mesaio','4','83200','Karlovasi'),
(5,'Panormou','78','11231', 'Athina'),
(6,'Kourtiou','15','11146', 'Athina'),
(7,'Akadimias','74','11630', 'Athina'),
(8,'Kufisias','142','11630', 'Athina');

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
(5,5,'2009-01-01','Useless'),
(6,2,'2012-01-01','DoesAllTheWork'),
(4,3,'2014-01-01','Seeker'),
(8,5,'2014-01-01','ERROR VALUE NOT FOUND'),
(9,6,'2013-01-01','Riddler'),
(10,7,'2015-01-01','WorstGuyInSeries'),
(11,8,'2012-01-01','NothingSpecial'),
(12,6,'2014-01-01','HeDead'),
(13,6,'2014-01-01','DeadAsWell'),
(15,7,'2013-01-01','TiKaneisTwraMwre?'),
(14,2,'2015-01-01','MainBadGuy'),
(2,1,'2015-01-01','SomeJob'),
(14,1,'2015-01-01','AnotherJob');


-- vehicle --
delete from vehicle;
insert into vehicle(LicensePlate,Model,Make,Storeid, kilometers, horsepower)
values
('MOA0001','Aygo','Toyota',2,40000,100),
('MOA0002','A1','Audi',3,20000,210),
('MOA0003','i3','BMW',2,120000,90),
('MOA0004','i3','BMW',2,110000,90),
('MOA0005','Yaris','Toyota',1,30000,105),
('MOA0006','Fiesta','Ford',1,50000,110),
('MOA0007','Fiesta','Ford',1,50000,110),
('MOV0002','Seat','Ibiza',4,35000,140),
('MOV0003','Lamborghini','Murcielago',3,6000,180),
('MOV0004','Volkswagen','Golf',2,80000,120),
('MOV0005','Renault','Clio',2,40000,90),
('MOV0006','Renault','Clio',2,45000,90),
('MOV0007','Kia','Sportage',3,140000,140),
('MOA8080','MX5','Mazda',4,180000,115),
('MOV0008','Duster','Ducia',3,90000,150);

-- CUSTOMERS --
delete from customer;
insert into customer(customerID, firstname, lastname,firstregistration,irs_number)
values
(1,'Marios','Giannaros','2011-12-21',5123),
(2,'Niovi','Athanasopoulou','2012-02-29',3241),
(3,'Aspasia','Valsamidou','2012-05-19',1232),
(4,'Nikos','Vogiatzoglou','2013-02-20',4451),
(6,'Stauros','Vasileiou','2013-10-02',4139),
(7,'Kwstas','Vasileiou','2014-04-21',0341),
(8,'Giannis','Lamprinidis','2015-03-12',5120),
(9,'Sofia','Eugenikou','2016-05-23',1123);

$$
	DELIMITER ;
	