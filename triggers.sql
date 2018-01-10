
 DROP TRIGGER IF EXISTS upd_employee;  
 DELIMITER $$
 CREATE TRIGGER upd_employee BEFORE UPDATE ON employee
	FOR EACH ROW
	BEGIN
		IF (NEW.street='') THEN
			SET NEW.street='Unknown';
		ELSE
			SET NEW.street = NEW.street;
		END IF;
		IF (NEW.streetnumber="") THEN
			SET NEW.streetnumber="Unknown";
		ELSE
			SET NEW.streetnumber = NEW.streetnumber;
		END IF;
		IF (NEW.postalcode="") THEN
			SET NEW.postalcode="Unknown";
		ELSE
			SET NEW.postalcode = NEW.postalcode;
		END IF;
		IF (NEW.city='') THEN
			SET NEW.city='Unknown';
		ELSE
			SET NEW.city = NEW.city;
		END IF;
		IF (NEW.SocialSecurityNumber='') THEN
			SET NEW.SocialSecurityNumber='Unknown';
		ELSE
			SET NEW.SocialSecurityNumber=New.SocialSecurityNumber;
		END IF;
	END$$
	DELIMITER ;

DROP TRIGGER IF EXISTS creat_employee;
 DELIMITER $$
 CREATE TRIGGER creat_employee BEFORE INSERT ON employee
	FOR EACH ROW
	BEGIN
		IF (NEW.street='' OR new.street=null) THEN
			SET NEW.street='Unknown';
		ELSE
			SET NEW.street = NEW.street;
		END IF;
		IF (NEW.streetnumber="") THEN
			SET NEW.streetnumber="Unknown";
		ELSE
			SET NEW.streetnumber = NEW.streetnumber;
		END IF;
		IF (NEW.postalcode="") THEN
			SET NEW.postalcode="Unknown";
		ELSE
			SET NEW.postalcode = NEW.postalcode;
		END IF;
		IF (NEW.city='') THEN
			SET NEW.city='Unknown';
		ELSE
			SET NEW.city = NEW.city;
		END IF;
		IF (NEW.SocialSecurityNumber='') THEN
			SET NEW.SocialSecurityNumber='Unknown';
		ELSE
			SET NEW.SocialSecurityNumber=New.SocialSecurityNumber;
		END IF;
	END$$
	DELIMITER ;
	

