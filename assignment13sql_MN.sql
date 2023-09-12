-- --------------------------------------------------------------------------------
-- Name: Megan Noel
 
-- Abstract: FlyMe2theMoon
-- --------------------------------------------------------------------------------

-- --------------------------------------------------------------------------------
-- Options
-- --------------------------------------------------------------------------------
USE dbFlyMe2theMoon;     
SET NOCOUNT ON;  

-- --------------------------------------------------------------------------------
--						Problem #10
-- --------------------------------------------------------------------------------

-- Drop Table Statements
IF OBJECT_ID ('TEmployees')				IS NOT NULL DROP TABLE TEmployees
IF OBJECT_ID ('TPilotFlights')			IS NOT NULL DROP TABLE TPilotFlights
IF OBJECT_ID ('TAttendantFlights')		IS NOT NULL DROP TABLE TAttendantFlights
IF OBJECT_ID ('TFlightPassengers')		IS NOT NULL DROP TABLE TFlightPassengers
IF OBJECT_ID ('TMaintenanceMaintenanceWorkers')			IS NOT NULL DROP TABLE TMaintenanceMaintenanceWorkers

IF OBJECT_ID ('TPassengers')			IS NOT NULL DROP TABLE TPassengers
IF OBJECT_ID ('TPilots')				IS NOT NULL DROP TABLE TPilots
IF OBJECT_ID ('TAttendants')			IS NOT NULL DROP TABLE TAttendants
IF OBJECT_ID ('TMaintenanceWorkers')	IS NOT NULL DROP TABLE TMaintenanceWorkers

IF OBJECT_ID ('TFlights')				IS NOT NULL DROP TABLE TFlights
IF OBJECT_ID ('TMaintenances')			IS NOT NULL DROP TABLE TMaintenances
IF OBJECT_ID ('TPlanes')				IS NOT NULL DROP TABLE TPlanes
IF OBJECT_ID ('TPlaneTypes')			IS NOT NULL DROP TABLE TPlaneTypes
IF OBJECT_ID ('TPilotRoles')			IS NOT NULL DROP TABLE TPilotRoles
IF OBJECT_ID ('TAirports')				IS NOT NULL DROP TABLE TAirports
IF OBJECT_ID ('TStates')				IS NOT NULL DROP TABLE TStates

-- --------------------------------------------------------------------------------
--	Step #1 : Create table 
-- --------------------------------------------------------------------------------

CREATE TABLE TPassengers
(
	 intPassengerID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strAddress				VARCHAR(255)	NOT NULL
	,strCity				VARCHAR(255)	NOT NULL
	,intStateID				INTEGER			NOT NULL
	,strZip					VARCHAR(255)	NOT NULL
	,strPhoneNumber			VARCHAR(255)	NOT NULL
	,strEmail				VARCHAR(255)	NOT NULL
	,dtmDateOfBirth			DATETIME		NOT NULL
	,strLoginID				VARCHAR(255)	NOT NULL
	,strPassword			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPassengers_PK PRIMARY KEY ( intPassengerID )
)


CREATE TABLE TPilots
(
	 intPilotID				INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfLicense		DATETIME		NOT NULL
	,intPilotRoleID			INTEGER			NOT NULL

	,CONSTRAINT TPilots_PK PRIMARY KEY ( intPilotID )
)


CREATE TABLE TAttendants
(
	 intAttendantID			INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,CONSTRAINT TAttendants_PK PRIMARY KEY ( intAttendantID )
)

Create table TEmployees
(
		intEmpPrimaryKeyId			INTEGER			NOT NULL
		,strEmployeeLoginID		VARCHAR(255)	NOT NULL
		,strEmployeePassword	VARCHAR(255)	NOT NULL
		,strEmployeeRole		VARCHAR(255)	NOT NULL
		,intEmployeeID			INTEGER			NOT NULL
		,CONSTRAINT TEmployees_PK	PRIMARY KEY ( intEmpPrimaryKeyID )
)

CREATE TABLE TMaintenanceWorkers
(
	 intMaintenanceWorkerID	INTEGER			NOT NULL
	,strFirstName			VARCHAR(255)	NOT NULL
	,strLastName			VARCHAR(255)	NOT NULL
	,strEmployeeID			VARCHAR(255)	NOT NULL
	,dtmDateOfHire			DATETIME		NOT NULL
	,dtmDateOfTermination	DATETIME		NOT NULL
	,dtmDateOfCertification	DATETIME		NOT NULL
	,CONSTRAINT TMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceWorkerID )
)


CREATE TABLE TStates
(
	 intStateID			INTEGER			NOT NULL
	,strState			VARCHAR(255)	NOT NULL
	,CONSTRAINT TStates_PK PRIMARY KEY ( intStateID )
)


CREATE TABLE TFlights
(
	 intFlightID			INTEGER			NOT NULL
	,strFlightNumber		VARCHAR(255)	NOT NULL
	,dtmFlightDate			DATETIME		NOT NULL
	,dtmTimeofDeparture		TIME			NOT NULL
	,dtmTimeOfLanding		TIME			NOT NULL
	,intFromAirportID		INTEGER			NOT NULL
	,intToAirportID			INTEGER			NOT NULL
	,intMilesFlown			INTEGER			NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TFlights_PK PRIMARY KEY ( intFlightID )
)


CREATE TABLE TMaintenances
(
	 intMaintenanceID		INTEGER			NOT NULL
	,strWorkCompleted		VARCHAR(8000)	NOT NULL
	,dtmMaintenanceDate		DATETIME		NOT NULL
	,intPlaneID				INTEGER			NOT NULL
	,CONSTRAINT TMaintenances_PK PRIMARY KEY ( intMaintenanceID )
)


CREATE TABLE TPlanes
(
	 intPlaneID				INTEGER			NOT NULL
	,strPlaneNumber			VARCHAR(255)	NOT NULL
	,intPlaneTypeID			INTEGER			NOT NULL
	,CONSTRAINT TPlanes_PK PRIMARY KEY ( intPlaneID )
)


CREATE TABLE TPlaneTypes	
(
	 intPlaneTypeID			INTEGER			NOT NULL
	,strPlaneType			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPlaneTypes_PK PRIMARY KEY ( intPlaneTypeID )
)


CREATE TABLE TPilotRoles	
(
	 intPilotRoleID			INTEGER			NOT NULL
	,strPilotRole			VARCHAR(255)	NOT NULL
	,CONSTRAINT TPilotRoles_PK PRIMARY KEY ( intPilotRoleID )
)


CREATE TABLE TAirports
(
	 intAirportID			INTEGER			NOT NULL
	,strAirportCity			VARCHAR(255)	NOT NULL
	,strAirportCode			VARCHAR(255)	NOT NULL
	,CONSTRAINT TAirports_PK PRIMARY KEY ( intAirportID )
)


CREATE TABLE TPilotFlights
(
	 intPilotFlightID		INTEGER			NOT NULL
	,intPilotID				INTEGER			NOT NULL
	,intFlightID			INTEGER			NOT NULL
	,CONSTRAINT TPilotFlights_PK PRIMARY KEY ( intPilotFlightID )
)


CREATE TABLE TAttendantFlights
(
	 intAttendantFlightID		INTEGER			NOT NULL
	,intAttendantID				INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,CONSTRAINT TAttendantFlights_PK PRIMARY KEY ( intAttendantFlightID )
)


CREATE TABLE TFlightPassengers
(
	 intFlightPassengerID		INTEGER			NOT NULL
	,intFlightID				INTEGER			NOT NULL
	,intPassengerID				INTEGER			NOT NULL
	,strSeat					VARCHAR(255)	NOT NULL
	,decFlightCost				decimal(5,2)			NOT NULL
	,CONSTRAINT TFlightPassengers_PK PRIMARY KEY ( intFlightPassengerID )
)


CREATE TABLE TMaintenanceMaintenanceWorkers
(
	 intMaintenanceMaintenanceWorkerID		INTEGER			NOT NULL
	,intMaintenanceID						INTEGER			NOT NULL
	,intMaintenanceWorkerID					INTEGER			NOT NULL
	,intHours								INTEGER			NOT NULL
	,CONSTRAINT TMaintenanceMaintenanceWorkers_PK PRIMARY KEY ( intMaintenanceMaintenanceWorkerID )
)

-- --------------------------------------------------------------------------------
--	Step #2 : Establish Referential Integrity 
-- --------------------------------------------------------------------------------
--
-- #	Child							Parent						Column
-- -	-----							------						---------
-- 1	TPassengers						TStates						intStateID	
-- 2	TFlightPassenger				TPassengers					intPassengerID
-- 3	TFlights						TPlanes						intPlaneID
-- 4	TFlights						TAirports					intFromAiportID
-- 5	TFlights						TAirports					intToAiportID
-- 6	TPilotFlights					TFlights					intFlightID
-- 7	TAttendantFlights				TFlights					intFlightID
-- 8	TPilotFlights					TPilots						intPilotID
-- 9	TAttendantFlights				TAttendants					intAttendantID
-- 10	TPilots							TPilotRoles					intPilotRoleID
-- 11	TPlanes							TPlaneTypes					intPlaneTypeID
-- 12	TMaintenances					TPlanes						intPlaneID
-- 13	TMaintenanceMaintenanceWorkers	TMaintenance				intMaintenanceID
-- 14	TMaintenanceMaintenanceWorkers	TMaintenanceWorker			intMaintenanceWorkerID
-- 15	TFlightPassenger				TFlights					intFlightID

--1
ALTER TABLE TPassengers ADD CONSTRAINT TPassengers_TStates_FK 
FOREIGN KEY ( intStateID ) REFERENCES TStates ( intStateID ) 

--2
ALTER TABLE TFlightPassengers ADD CONSTRAINT TPFlightPassengers_TPassengers_FK 
FOREIGN KEY ( intPassengerID ) REFERENCES TPassengers ( intPassengerID ) On delete cascade

--3
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes ( intPlaneID ) 

--4
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TFromAirports_FK 
FOREIGN KEY ( intFromAirportID ) REFERENCES TAirports ( intAirportID ) 

--5
ALTER TABLE TFlights	 ADD CONSTRAINT TFlights_TToAirports_FK 
FOREIGN KEY ( intToAirportID ) REFERENCES TAirports ( intAirportID ) 

--6
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID )  on delete cascade

--7
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) on delete cascade

--8
ALTER TABLE TPilotFlights	 ADD CONSTRAINT TPilotFlights_TPilots_FK 
FOREIGN KEY ( intPilotID ) REFERENCES TPilots (intPilotID ) on delete cascade

--9
ALTER TABLE TAttendantFlights	 ADD CONSTRAINT TAttendantFlights_TAttendants_FK 
FOREIGN KEY ( intAttendantID ) REFERENCES TAttendants (intAttendantID ) on delete cascade

--10
ALTER TABLE TPilots	 ADD CONSTRAINT TPilots_TPilotRoles_FK 
FOREIGN KEY ( intPilotRoleID ) REFERENCES TPilotRoles (intPilotRoleID )  

--11
ALTER TABLE TPlanes	 ADD CONSTRAINT TPlanes_TPlaneTypes_FK 
FOREIGN KEY ( intPlaneTypeID ) REFERENCES TPlaneTypes (intPlaneTypeID )  

--12
ALTER TABLE TMaintenances	 ADD CONSTRAINT TMaintenances_TPlanes_FK 
FOREIGN KEY ( intPlaneID ) REFERENCES TPlanes (intPlaneID )  

--13
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenances_FK 
FOREIGN KEY ( intMaintenanceID ) REFERENCES TMaintenances (intMaintenanceID ) 

--14
ALTER TABLE TMaintenanceMaintenanceWorkers	 ADD CONSTRAINT TMaintenanceMaintenanceWorkers_TMaintenanceWorkers_FK 
FOREIGN KEY ( intMaintenanceWorkerID ) REFERENCES TMaintenanceWorkers (intMaintenanceWorkerID ) 

--15
ALTER TABLE TFlightPassengers	 ADD CONSTRAINT TFlightPassengers_TFlights_FK 
FOREIGN KEY ( intFlightID ) REFERENCES TFlights (intFlightID ) On delete cascade


-- --------------------------------------------------------------------------------
--	Step #3 : Add Data - INSERTS
-- --------------------------------------------------------------------------------
INSERT INTO TStates( intStateID, strState)
VALUES				(1, 'Ohio')
				   ,(2, 'Kentucky')
				   ,(3, 'Indiana')


INSERT INTO TPilotRoles( intPilotRoleID, strPilotRole)
VALUES				(1, 'Co-Pilot')
				   ,(2, 'Captain')

				
INSERT INTO TPlaneTypes( intPlaneTypeID, strPlaneType)
VALUES				(1, 'Airbus A350')
				   ,(2, 'Boeing 747-8')
				   ,(3, 'Boeing 767-300F')


INSERT INTO TPlanes( intPlaneID, strPlaneNumber, intPlaneTypeID)
VALUES				(1, '4X887G', 1)
				   ,(2, '5HT78F', 2)
				   ,(3, '5TYY65', 2)
				   ,(4, '4UR522', 1)
				   ,(5, '6OP3PK', 3)
				   ,(6, '67TYHH', 3)


INSERT INTO TAirports( intAirportID, strAirportCity, strAirportCode)
VALUES				(1, 'Cincinnati', 'CVG')
				   ,(2, 'Miami', 'MIA')
				   ,(3, 'Ft. Meyer', 'RSW')
				   ,(4, 'Louisville',  'SDF')
				   ,(5, 'Denver', 'DEN')
				   ,(6, 'Orlando', 'MCO' )


INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail,dtmDateOfBirth, strLoginID, strPassword)
VALUES				  (1, 'Knelly', 'Nervious', '321 Elm St.', 'Cincinnati', 1, '45201', '5135553333', 'nnelly@gmail.com','10/10/2020','KNervious','RealNervous')
					 ,(2, 'Orville', 'Waite', '987 Oak St.', 'Cleveland', 1, '45218', '5135556333', 'owright@gmail.com','04/05/1945','OWaite','Waite4Me')
					 ,(3, 'Eileen', 'Awnewe', '1569 Windisch Rd.', 'Dayton', 1, '45069', '5135555333', 'eonewe1@yahoo.com','03/08/1980','EAwnewe','Awnewe80')
					 ,(4, 'Bob', 'Eninocean', '44561 Oak Ave.', 'Florence', 2, '45246', '8596663333', 'bobenocean@gmail.com','11/02/1997','BEniocean','BobInTheOcean')
					 ,(5, 'Ware', 'Hyjeked', '44881 Pine Ave.', 'Aurora', 3, '45546', '2825553333', 'Hyjekedohmy@gmail.com','06/20/1978','WHyjeked','WareAmI')
					 ,(6, 'Kay', 'Oss', '4484 Bushfield Ave.', 'Lawrenceburg', 3, '45546', '2825553333', 'wehavekayoss@gmail.com','02/02/1989','KOss','Kay89')


INSERT INTO TPilots (intPilotID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateofLicense, intPilotRoleID)
VALUES				  (1, 'Tip', 'Seenow', '12121', '1/1/2015', '1/1/2099', '12/1/2014', 1)
					 ,(2, 'Ima', 'Soring', '13322', '1/1/2016', '1/1/2099', '12/1/2015', 1)
					 ,(3, 'Hugh', 'Encharge', '16666', '1/1/2017', '1/1/2099', '12/1/2016', 2)
					 ,(4, 'Iwanna', 'Knapp', '17676', '1/1/2014', '1/1/2015', '12/1/2013', 1)
					 ,(5, 'Rose', 'Ennair', '19909', '1/1/2012', '1/1/2099', '12/1/2011', 2)


INSERT INTO TAttendants (intAttendantID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination)
VALUES				  (1, 'Miller', 'Tyme', '22121', '1/1/2015', '1/1/2099')
					 ,(2, 'Sherley', 'Ujest', '23322', '1/1/2016', '1/1/2099')
					 ,(3, 'Buhh', 'Biy', '26666', '1/1/2017', '1/1/2099')
					 ,(4, 'Myles', 'Amanie', '27676', '1/1/2014', '1/1/2015')
					 ,(5, 'Walker', 'Toexet', '29909', '1/1/2012', '1/1/2099')

INSERT INTO TEmployees (intEmpPrimaryKeyId, strEmployeeLoginID, strEmployeePassword, strEmployeeRole, intEmployeeID )
VALUES					(1, 'TSeenow', 'ICanSeeNow', 'Pilot', 1)
						,(2, 'ISoring' , 'ILovePlanes', 'Pilot' ,2)
						,(3, 'HEncharge', 'ImInCharge', 'Pilot', 3)
						,(4, 'IKnapp', 'LetMeSleep', 'Pilot' , 4)
						,(5, 'REnnair' , 'InDaAir', 'Pilot', 5)
						,(6, 'MTyme', 'NeedADrink', 'Attendant', 1)
						,(7, 'SUjest', 'Shirley123', 'Attendant' , 2)
						,(8, 'BBiy' , 'SeeYaLater', 'Attendant' , 3)
						,(9, 'MAmanie', 'MylesNMyles' , 'Attendant' , 4)
						,(10, 'WToexet' , 'Walker88', 'Attendant' , 5)
						,(11, 'TJoy', 'Trinity4', 'Admin', 8)
						,(12, 'LOdell', 'Lyndsey3' , 'Admin', 9)


INSERT INTO TMaintenanceWorkers (intMaintenanceWorkerID, strFirstName, strLastName, strEmployeeID, dtmDateofHire, dtmDateofTermination, dtmDateOfCertification)
VALUES				  (1, 'Gressy', 'Nuckles', '32121', '1/1/2015', '1/1/2099', '12/1/2014')
					 ,(2, 'Bolt', 'Izamiss', '33322', '1/1/2016', '1/1/2099', '12/1/2015')
					 ,(3, 'Sharon', 'Urphood', '36666', '1/1/2017', '1/1/2099','12/1/2016')
					 ,(4, 'Ides', 'Racrozed', '37676', '1/1/2014', '1/1/2015','12/1/2013')
					

INSERT INTO TMaintenances (intMaintenanceID, strWorkCompleted, dtmMaintenanceDate, intPlaneID)
VALUES				  (1, 'Fixed Wing', '1/1/2022', 1)
					 ,(2, 'Repaired Flat Tire', '3/1/2022', 2)
					 ,(3, 'Added Wiper Fluid', '4/1/2022', 3)
					 ,(4, 'Tightened Engine to Wing', '5/1/2022', 2)
					 ,(5, '100,000 mile checkup', '3/10/2022', 4)
					 ,(6, 'Replaced Loose Door', '4/10/2022', 6)
					 ,(7, 'Trapped Raccoon in Cargo Hold', '5/1/2022', 6)


INSERT INTO TFlights (intFlightID, dtmFlightDate, strFlightNumber,  dtmTimeofDeparture, dtmTimeOfLanding, intFromAirportID, intToAirportID, intMilesFlown, intPlaneID)
VALUES				  (1, '4/1/2022', '111', '10:00:00', '12:00:00', 1, 2, 1200, 2)
					 ,(2, '4/4/2022', '222','13:00:00', '15:00:00', 1, 3, 1000, 2)
					 ,(3, '4/5/2022', '333','15:00:00', '17:00:00', 1, 5, 1200, 3)
					 ,(4, '4/16/2022','444', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					 ,(5, '3/14/2022','555', '18:00:00', '20:00:00', 2, 1, 1200, 3)
					 ,(6, '3/21/2022','666', '19:00:00', '21:00:00', 3, 1, 1000, 1)
					 ,(7, '3/11/2022', '777','20:00:00', '22:00:00', 3, 6, 1400, 4)
					 ,(8, '3/17/2022', '888','09:00:00', '11:00:00', 6, 4, 1100, 5)
					 ,(9, '4/19/2022', '999','08:00:00', '10:00:00', 4, 2, 1000, 6)
					 ,(10, '4/22/2022', '091','10:00:00', '12:00:00', 2, 1, 1200, 6)
					 ,(11, '8/22/2023', '303', '08:00:00', '10:00:00', 1, 2, 1200, 2)
					 ,(12, '9/15/2023', '404', '13:00:00', '15:00:00', 1, 3, 1000, 2)
					 ,(13, '10/08/2023', '505', '15:00:00', '17:00:00', 1, 5, 1200, 3)
					 ,(14, '11/02/2024', '606', '10:00:00', '12:00:00', 4, 6, 1100, 3)
					 ,(15, '11/14/2024', '707', '18:00:00', '20:00:00', 2, 1, 1200, 3);

INSERT INTO TPilotFlights ( intPilotFlightID, intPilotID, intFlightID)
VALUES				 ( 1, 1, 2 )
					,( 2, 1, 3 )
					,( 3, 3, 3 )
					,( 4, 3, 2 )
					,( 5, 5, 1 )
					,( 6, 2, 1 )
					,( 7, 3, 4 )
					,( 8, 2, 4 )
					,( 9, 2, 5 )
					,( 10, 3, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )
					,(13, 1, 15)


INSERT INTO TAttendantFlights ( intAttendantFlightID, intAttendantID, intFlightID)
VALUES				( 1, 1, 2 )
					,( 2, 2, 3 )
					,( 3, 3, 3 )
					,( 4, 4, 2 )
					,( 5, 5, 1 )
					,( 6, 1, 1 )
					,( 7, 2, 4 )
					,( 8, 3, 4 )
					,( 9, 4, 5 )
					,( 10, 5, 5 )
					,( 11, 5, 6 )
					,( 12, 1, 6 )
					,(13, 1, 15)
					

INSERT INTO TFlightPassengers ( intFlightPassengerID, intFlightID, intPassengerID, strSeat, decFlightCost)
VALUES				 ( 1, 1, 1, '1A', 400.00)
					,( 2, 1, 2, '2A', 500.00 )
					,( 3, 1, 3, '1B', 450.00 )
					,( 4, 1, 4, '1C', 300.00 )
					,( 5, 1, 5, '1D', 320.00 )
					,( 6, 2, 5, '1A', 800.00 )
					,( 7, 2, 4, '2A', 480.00 )
					,( 8, 2, 3, '1B', 340.00 )
					,( 9, 3, 1, '1B', 200.00 )
					,( 10, 3, 2, '2A', 760.00 )
					,( 11, 3, 3, '1B', 400.00 )
					,( 12, 3, 4, '1C', 300.00 )
					,( 13, 3, 5, '1D', 500.00 )
					,( 14, 4, 2, '1A', 600.00 )
					,( 15, 4, 3, '1B', 300.00 )
					,( 16, 4, 4, '1C', 400.00 )
					,( 17, 4, 5, '1D', 500.00 )
					,( 18, 5, 1, '1A', 690.00 )
					,( 19, 5, 2, '2A', 150.00 )
					,( 20, 5, 3, '1B', 570.00 )
					,( 21, 5, 4, '2B', 300.00 )
					,( 22, 6, 1, '1A', 400.00 )
					,( 23, 6, 2, '2A', 600.00 )
					,( 24, 6, 3, '3A' , 700.00 )
					,(25, 11, 1, '5C', 540.00)
					, (26, 12, 1, 'W1', 720.00)
					, (27, 12, 4, 'A5', 800.00)
					, (28, 12, 3, 'C4', 500.00)
					
					
					

INSERT INTO TMaintenanceMaintenanceWorkers ( intMaintenanceMaintenanceWorkerID, intMaintenanceID, intMaintenanceWorkerID, intHours)
VALUES				 ( 1, 2, 1, 2 )
					,( 2, 4, 1, 3 )
					,( 3, 2, 3, 4 )
					,( 4, 1, 4, 2 )
					,( 5, 3, 4, 2 )
					,( 6, 4, 3, 5 )
					,( 7, 5, 1, 7 )
					,( 8, 6, 1, 2 )
					,( 9, 7, 3, 4 )
					,( 10, 4, 4, 1 )
					,( 11, 3, 3, 4 )
					,( 12, 7, 3, 8 )

--- This returns all future flights for customer based on customerid (passenger pk)
Create Procedure uspCustomerFutureFlights(@customer_id as integer)
As
Begin
SELECT TFlights.intFlightID, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeOfLanding, 
           DepartureAirport.strAirportCity AS DepartureCity, ArrivalAirport.strAirportCity AS ArrivalCity, 
            TFlights.intPlaneID, TFlights.strFlightNumber, TFlightPassengers.strSeat, TFlights.intMilesFlown , TFlightPassengers.decFlightCost
            FROM TPassengers 
            INNER JOIN TFlightPassengers ON TPassengers.intPassengerID = TFlightPassengers.intPassengerID 
            INNER JOIN TFlights ON TFlightPassengers.intFlightID = TFlights.intFlightID 
            JOIN TAirports AS DepartureAirport ON TFlights.intFromAirportID = DepartureAirport.intAirportID 
            JOIN TAirports AS ArrivalAirport ON TFlights.intToAirportID = ArrivalAirport.intAirportID 
            WHERE TPassengers.intPassengerID = @customer_id
            AND TFlights.dtmFlightDate > GETDATE()

End





--- This returns all future flight miles for customer based on customerid(passenger pk)
Create Procedure uspCustomerFutureFlightMiles(@customer_id as integer)
As 
Begin
SELECT COALESCE(SUM(TFlights.intMilesFlown), 0) AS TotalMilesFlown
            FROM TFlights
            LEFT JOIN TFlightPassengers ON TFlights.intFlightID = TFlightPassengers.intFlightID
            LEFT JOIN TPassengers ON TFlightPassengers.intPassengerID = TPassengers.intPassengerID
            WHERE TPassengers.intPassengerID = @customer_id
            AND TFlights.dtmFlightDate > GETDATE()

End




--- This returns all past flights for customer based on customerid (passenger pk)
Create Procedure uspCustomerPastFlights(@customer_id as integer)
As
Begin
SELECT TFlights.intFlightID, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeOfLanding, 
            DepartureAirport.strAirportCity AS DepartureCity, ArrivalAirport.strAirportCity AS ArrivalCity, 
            TFlights.intPlaneID, TFlights.strFlightNumber, TFlightPassengers.strSeat, TFlights.intMilesFlown 
            FROM TPassengers 
            INNER JOIN TFlightPassengers ON TPassengers.intPassengerID = TFlightPassengers.intPassengerID 
            INNER JOIN TFlights ON TFlightPassengers.intFlightID = TFlights.intFlightID 
            JOIN TAirports AS DepartureAirport ON TFlights.intFromAirportID = DepartureAirport.intAirportID 
            JOIN TAirports AS ArrivalAirport ON TFlights.intToAirportID = ArrivalAirport.intAirportID 
            WHERE TPassengers.intPassengerID = @customer_id
             AND TFlights.dtmFlightDate < GETDATE()

End






---  This returns all past flight miles for customer based on customerid(passenger pk)
Create Procedure uspCustomerPastFlightMiles(@customer_id as integer)
As
Begin
SELECT COALESCE(SUM(TFlights.intMilesFlown), 0) AS TotalMilesFlown
           FROM TFlights
             LEFT JOIN TFlightPassengers ON TFlights.intFlightID = TFlightPassengers.intFlightID
             LEFT JOIN TPassengers ON TFlightPassengers.intPassengerID = TPassengers.intPassengerID
             WHERE TPassengers.intPassengerID = @customer_id
             AND TFlights.dtmFlightDate < GETDATE()
End






--- This returns all future flights for pilot based on pilotid

Create Procedure uspPilotFutureFlights(@pilot_id as integer)
as
begin
SELECT TFlights.intFlightID, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeOfLanding, DepartureAirport.strAirportCity AS DepartureCity, ArrivalAirport.strAirportCity AS ArrivalCity,TPlaneTypes.strPlaneType, TFlights.strFlightNumber, TFlights.intMilesFlown
                        From TFlights Join TAirports As DepartureAirport On TFlights.intFromAirportID = DepartureAirport.intAirportID
                       Join TAirports As ArrivalAirport On TFlights.intToAirportID = ArrivalAirport.intAirportID
                       Join TPilotFlights On TFlights.intFlightID = TPilotFlights.intFlightID
                       Join TPilots On TPilots.intPilotID = TPilotFlights.intPilotID
                        Join TPlanes On TPlanes.intPlaneID = TFlights.intPlaneID
                        Join TPlaneTypes On TPlaneTypes.intPlaneTypeID = TPlanes.intPlaneTypeID
                        Where TPilots.intPilotID = @pilot_id
                       And TFlights.dtmFlightDate > GetDate()
end







--- This returns all future flights for attendant based on attendantid
Create Procedure uspAttendantFutureFlights(@attendant_id as integer)
as
begin
SELECT TFlights.intFlightID, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeOfLanding, DepartureAirport.strAirportCity AS DepartureCity, ArrivalAirport.strAirportCity AS ArrivalCity,TPlaneTypes.strPlaneType, TFlights.strFlightNumber, TFlights.intMilesFlown
                        From TFlights Join TAirports As DepartureAirport On TFlights.intFromAirportID = DepartureAirport.intAirportID
                        Join TAirports As ArrivalAirport On TFlights.intToAirportID = ArrivalAirport.intAirportID
                        Join TAttendantFlights On TFlights.intFlightID = TAttendantFlights.intFlightID
                        Join TAttendants On TAttendants.intAttendantID = TAttendantFlights.intAttendantID
                         Join TPlanes On TPlanes.intPlaneID = TFlights.intPlaneID
                         Join TPlaneTypes On TPlaneTypes.intPlaneTypeID = TPlanes.intPlaneTypeID
                         Where TAttendants.intAttendantID = @attendant_id
                        And TFlights.dtmFlightDate > GetDate()
end



--- This returns all past flights for attendant based on attendantid
Create Procedure uspAttendantPastFlights(@attendant_id as integer)
As 
Begin
SELECT TFlights.intFlightID, TFlights.dtmFlightDate, TFlights.dtmTimeofDeparture, TFlights.dtmTimeOfLanding, DepartureAirport.strAirportCity AS DepartureCity, ArrivalAirport.strAirportCity AS ArrivalCity,TPlaneTypes.strPlaneType, TFlights.strFlightNumber, TFlights.intMilesFlown
                         From TFlights Join TAirports As DepartureAirport On TFlights.intFromAirportID = DepartureAirport.intAirportID
                        Join TAirports As ArrivalAirport On TFlights.intToAirportID = ArrivalAirport.intAirportID
                        Join TAttendantFlights On TFlights.intFlightID = TAttendantFlights.intFlightID
                        Join TAttendants On TAttendants.intAttendantID = TAttendantFlights.intAttendantID
                         Join TPlanes On TPlanes.intPlaneID = TFlights.intPlaneID
                         Join TPlaneTypes On TPlaneTypes.intPlaneTypeID = TPlanes.intPlaneTypeID
                         Where TAttendants.intAttendantID = @attendant_id
                        And TFlights.dtmFlightDate < GetDate()
End




---This returns all past flight miles for attendant based on attendantid
Create Procedure uspAttendantPastFlightMiles(@attendant_id as integer)
AS
Begin
SELECT COALESCE(SUM(TFlights.intMilesFlown), 0) AS TotalMilesFlown
            FROM TFlights
            LEFT JOIN TAttendantFlights ON TFlights.intFlightID = TAttendantFlights.intFlightID
            LEFT JOIN TAttendants ON TAttendantFlights.intAttendantID = TAttendants.intAttendantID
            WHERE TAttendants.intAttendantID = 1
            AND TFlights.dtmFlightDate < GETDATE()

End


---This creates a record for a new passenger
CREATE PROCEDURE uspAddCustomer
     @intPassengerID			AS INTEGER OUTPUT
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strAddress				AS VARCHAR(255)
    ,@strCity					AS VARCHAR(255)
    ,@intState					AS INTEGER 
    ,@strZip					AS VARCHAR(255)
    ,@strPhone					AS VARCHAR(255)
    ,@strEmail					AS VARCHAR(255)
	,@dtmDateOfBirth			AS DATETIME
	,@strLoginID				AS VARCHAR(255)
	,@strPassword				AS VARCHAR(255)
      
AS
SET XACT_ABORT ON 
BEGIN TRANSACTION
    SELECT @intPassengerID = MAX(intPassengerID) + 1 
    FROM TPassengers (TABLOCKX)   
    SELECT @intPassengerID = COALESCE(@intPassengerID, 1)
    INSERT INTO TPassengers (intPassengerID, strFirstName, strLastName, strAddress, strCity, intStateID, strZip, strPhoneNumber, strEmail, dtmDateOfBirth, strLoginID, strPassword)
    VALUES (@intPassengerID, @strFirstName, @strLastName, @strAddress, @strCity, @intState, @strZip, @strPhone, @strEmail, @dtmDateOfBirth, @strLoginID, @strPassword)


COMMIT TRANSACTION
GO


---This updates information for passenger based on pk
Create Procedure uspUpdateCustomer
     @intPassengerID			AS INTEGER
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strAddress				AS VARCHAR(255)
    ,@strCity					AS VARCHAR(255)
    ,@intState					AS INTEGER 
    ,@strZip					AS VARCHAR(255)
    ,@strPhone					AS VARCHAR(255)
    ,@strEmail					AS VARCHAR(255)
	,@strLoginID				AS VARCHAR(255)
	,@strPassword				AS VARCHAR(255)

       
AS
SET XACT_ABORT ON 
BEGIN TRANSACTION
  Update  TPassengers 
			SET strFirstName =	@strFirstName, 
			    strLastName =	@strLastName,
				strAddress =	@strAddress, 
				strCity =		@strCity, 
				intStateID =	@intState,
				strZip =		@strZip,
				strPhoneNumber = @strPhone,
				strEmail = @strEmail,
				strLoginId = @strLoginID,
				strPassword = @strPassword
			
	WHERE  intPassengerID = @intPassengerID 


COMMIT TRANSACTION
GO


---This deletes pilot based on pk
Create Procedure uspDeletePilot
     @intPilotID				AS INTEGER  
    
       
AS
SET XACT_ABORT ON 
BEGIN TRANSACTION
  
    Delete  FROM TPilots
	WHERE  intPilotID = @intPilotID

COMMIT TRANSACTION
GO


-- This deletes attendant based on pk 
Create Procedure uspDeleteAttendant
     @intAttendantID				AS INTEGER  
    
       
AS
SET XACT_ABORT ON 
BEGIN TRANSACTION
  
    Delete  FROM TAttendants
	WHERE  intAttendantID = @intAttendantID

COMMIT TRANSACTION
GO

---This updates information for attendant in ATTENDANTS table based on pk
Create Procedure uspUpdateAttendant
     @intAttendantID			AS INTEGER
    ,@strFirstName				AS VARCHAR(255)
    ,@strLastName				AS VARCHAR(255)
    ,@strEmployeeID				AS VARCHAR(255)
    ,@dtmDateHire				as datetime
    ,@dtmDateTerminated		as datetime
       
AS
SET XACT_ABORT ON 
BEGIN TRANSACTION
  Update  TAttendants 
			SET strFirstName =	@strFirstName, 
			    strLastName =	@strLastName,
				strEmployeeID =	@strEmployeeID, 
				dtmDateofHire =	@dtmDateHire, 
				dtmDateofTermination = @dtmDateTerminated
			
	WHERE  intAttendantID = @intAttendantID 


COMMIT TRANSACTION
GO




---This updates information for attendant in EMPLOYEES table based on pk
Create Procedure uspUpdateAttendantEmployee
     
    @strLoginId			AS VARCHAR(255)
    ,@strPassword			AS VARCHAR(255)
	,@intAttendantID				as integer
   
AS
SET XACT_ABORT ON 
BEGIN TRANSACTION
  Update  TEmployees 
			SET strEmployeeLoginID =	@strLoginId, 
			    strEmployeePassword =	@strPassword
				
			
	WHERE  intEmployeeID = @intAttendantID 
	and strEmployeeRole = 'Attendant'


COMMIT TRANSACTION
GO