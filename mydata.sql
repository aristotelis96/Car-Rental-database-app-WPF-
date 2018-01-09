CREATE DATABASE Company;
USE Company

CREATE TABLE Employee (
    IRS_number int UNIQUE NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255) NOT NULL,
	DriverLicense varchar(255),
	SocialSecurityNumber varchar(255),
	Street varchar(255),
	StreetNumber varchar(255),
	PostalCode varchar(255),
	City varchar(255),
	PRIMARY KEY (IRS_number)	
);
		
CREATE TABLE Store (
	StoreID int UNIQUE NOT NULL,
	Street varchar(255),
	StreetNumber varchar(255),
	PostalCode varchar(255),
	City varchar(255),
	PRIMARY KEY (StoreID)
);

CREATE TABLE PhoneNumber (
	StoreID int,
	Num long,
	FOREIGN KEY (StoreID) REFERENCES Store(StoreID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Email (
	StoreID int,
	EmailAddress varchar(255),
	FOREIGN KEY (StoreID) REFERENCES Store(StoreID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Works (
	StartDate date NOT NULL,
	FinishDate date,
	Position varchar(255),
	IRS_number int,
	StoreID int,
	FOREIGN KEY (IRS_number) REFERENCES Employee(IRS_number) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (StoreID) REFERENCES Store(StoreID) ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (IRS_number, StoreID, StartDate)
);

CREATE TABLE Customer (
	CustomerID int UNIQUE NOT NULL,
	FirstRegistration date,
	SocialSecutiryNumber  varchar(255),
	DriverLicense  varchar(255),
	IRS_number  varchar(255),
	LastName varchar(255) NOT NULL,
	FirstName varchar(255) NOT NULL,
	Street varchar(255), 
	StreetNumber  varchar(255),
	PostalCode  varchar(255),
	City varchar(255),
	PRIMARY KEY (CustomerID)
);


CREATE TABLE Vehicle (
	LicensePlate varchar(255) UNIQUE NOT NULL,
	Model varchar(255),
	CarType varchar(255),
	Make varchar(255),
	YearMade YEAR,
	Kilometers int,
	CylinderCapacity int,
	HorsePower int,
	Damages varchar(255),
	Malfunctions varchar(255),
	NextService date,
	LastService date,
	InsuranceExpirationDate date,
	StoreID int,
	PRIMARY KEY (LicensePlate),
	FOREIGN KEY (StoreID) REFERENCES Store(StoreID) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Fuel (
	LicensePlate varchar(255),
	FuelType varchar(255),
	FOREIGN KEY (LicensePlate) REFERENCES Vehicle(LicensePlate) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Reserves (
	StartLocation varchar(255),
	FinishLocation varchar(255),
	StartDate date UNIQUE NOT NULL,
	FinishDate date,
	Paid BOOLEAN,
	
	CustomerID int,
	LicensePlate varchar(255),
	FOREIGN KEY (LicensePlate) REFERENCES Vehicle(LicensePlate) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (LicensePlate, StartDate)
);

CREATE TABLE Rents (
	StartDate date UNIQUE NOT NULL,
	StartLocation varchar(255),
	FinishLocation varchar(255),
	FinishDate date,
	ReturnState varchar(255),
	
	LicensePlate varchar(255),
	CustomerID int,
	IRS_number int,
	FOREIGN KEY (CustomerID) REFERENCES Customer(CustomerID) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (LicensePlate) REFERENCES Vehicle(LicensePlate) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (IRS_number) REFERENCES Employee(IRS_number) ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (LicensePlate, StartDate)
);

	
CREATE TABLE PaymentTransaction (
	StartDate date,
	LicensePlate varchar(255),
	PaymentAmount int,
	PaymentMethod varchar(255),
	FOREIGN KEY (StartDate) REFERENCES Rents(StartDate) ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (LicensePlate) REFERENCES Vehicle(LicensePlate) ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (LicensePlate, StartDate)
);

	
	
	
	
	
	
	
	
	
	
	
	
