CREATE VIEW numberofcars AS (
	SELECT 	store.storeid as 'Store ID',
			store.street as 'Street',
			store.City as 'City',
			COUNT(vehicle.storeid) as 'Number of Vehicles'
	FROM Store
	LEFT JOIN vehicle ON store.storeid=vehicle.storeid
	GROUP BY store.storeid
	
);	

CREATE VIEW properemployee AS (
	SELECT
	firstname as "Name",
	lastname as "Surname",
	IRS_NUMBER AS "IRS Number",
	driverlicense as "Driver's License",
	socialsecuritynumber as "Social Security Number",
	STREET AS "Street",
	streetnumber as "Number",
	City as "City",
	Postalcode as "ZIP"
	FROM EMPLOYEE);