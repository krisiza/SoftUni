CREATE DATABASE RailwaysDb;


-- 1
CREATE TABLE Passengers (
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY(TownId) REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Trains(
	Id INT PRIMARY KEY IDENTITY,
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT FOREIGN KEY(DepartureTownId) REFERENCES Towns(Id) NOT NULL,
	ArrivalTownId INT FOREIGN KEY(ArrivalTownId) REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE TrainsRailwayStations (
	TrainId INT FOREIGN KEY(TrainId) REFERENCES Trains(Id) NOT NULL,
	RailwayStationId INT FOREIGN KEY(RailwayStationId) REFERENCES RailwayStations(Id) NOT NULL
	PRIMARY KEY (TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords (
	Id INT PRIMARY KEY IDENTITY,
	DateOfMaintenance DATE NOT NULL,
	Details VARCHAR(2000) NOT NULL,
	TrainId INT FOREIGN KEY(TrainId) REFERENCES Trains(Id) NOT NULL
)

CREATE TABLE Tickets (
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL NOT NULL,
	DateOfDeparture DATE NOT NULL,
	DateOfArrival DATE NOT NULL,
	TrainId INT FOREIGN KEY(TrainId) REFERENCES Trains(Id) NOT NULL,
	PassengerId INT FOREIGN KEY(PassengerId) REFERENCES Passengers(Id) NOT NULL,
)

-- 2
INSERT INTO Trains
	VALUES  ('07:00', '19:00', 1, 3),
			('08:30', '20:30', 5, 6),
			('09:00', '21:00', 4, 8),
			('06:45', '03:55', 27, 7),
			('10:15', '12:15', 15, 5)

INSERT INTO TrainsRailwayStations
	VALUES  (36, 1),
			(36, 4),
			(36, 31),
			(36, 57),
			(36, 7),
			(37, 13),
			(37, 54),
			(37, 60),
			(37, 16),
			(38, 10),
			(38, 50),
			(38, 52),
			(38, 22),
			(39, 68),
			(39, 3),
			(39, 31),
			(39, 19),
			(40, 41),
			(40, 7),
			(40, 52),
			(40, 13)

INSERT INTO Tickets
	VALUES  (90.00, '2023-12-01', '2023-12-01', 36, 1),
			(115.00, '2023-08-02', '2023-08-02', 37, 2),
			(160.00, '2023-08-03', '2023-08-03', 38, 3),
			(255.00, '2023-09-01', '2023-09-02', 39, 21),
			(95.00, '2023-09-02', '2023-09-03', 40, 22)


-- 3
UPDATE Tickets
SET DateOfDeparture = DATEADD(day, 7, DateOfDeparture), DateOfArrival = DATEADD(day, 7, DateOfDeparture)
WHERE MONTH(DateOfDeparture) > 10  

-- 4
DELETE FROM MaintenanceRecords
WHERE TrainId =	(SELECT Id
		FROM Trains
		WHERE DepartureTownId = 3)

DELETE FROM TrainsRailwayStations
WHERE TrainId =	(SELECT Id
		FROM Trains
		WHERE DepartureTownId = 3)

DELETE FROM Tickets
WHERE TrainId =	(SELECT Id
		FROM Trains
		WHERE DepartureTownId = 3)

DELETE FROM Trains
WHERE DepartureTownId = 3

-- 5
SELECT DateOfDeparture,
		CAST(Price AS DECIMAL(10,2)) AS TicketPrice
FROM Tickets
ORDER BY Price, DateOfDeparture DESC

-- 6
SELECT 
		p.[Name] AS PassengerName,
		t.Price AS TicketPrice,
		t.DateOfDeparture AS DateOfDeparture,
		t.TrainId AS TrainID
FROM Tickets AS t
JOIN Passengers AS p ON t.PassengerId = p.Id
ORDER BY t.Price DESC, p.Name

-- 7
SELECT t.[Name],	
		rs.Name
FROM RailwayStations AS rs
LEFT JOIN Towns AS t ON rs.TownId = t.Id
LEFT JOIN TrainsRailwayStations AS trs ON rs.Id = trs.RailwayStationId
LEFT JOIN Trains AS tr ON trs.TrainId = tr.Id
WHERE tr.Id IS NULL
ORDER BY t.Name, rs.Name

-- 8
SELECT TOP 3
				t.Id AS TraindId,
				t.HourOfDeparture AS HourOfDeparture,
				CAST(ti.Price AS DECIMAL(10,2)) AS TicketPrice,
				tw.[Name] AS Destination
FROM Trains AS t
JOIN Tickets AS ti ON ti.TrainId = t.Id
JOIN Towns AS tw ON t.ArrivalTownId = tw.Id
WHERE DATEPART(HOUR, t.HourOfDeparture) = '8'  AND ti.Price > 50
ORDER BY t.HourOfDeparture, ti.Price

-- 9
SELECT 
		tw.Name AS TownName,
		Count(p.[Name]) AS PassengersCount
FROM Tickets AS ti
JOIN Passengers AS p ON p.Id = ti.PassengerId
JOIN Trains AS tr ON tr.Id = ti.TrainId
JOIN Towns As tw On tw.Id = tr.ArrivalTownId
WHERE ti.Price > 76.99
GROUP BY tw.[Name]
ORDER BY TownName

-- 10
SELECT	
		tr.Id AS TrainID,
		tw.[Name] AS DepartureTown,
		mr.Details AS Details
FROM Trains AS tr
JOIN Towns AS tw ON tr.DepartureTownId = tw.Id
JOIN MaintenanceRecords AS mr On mr.TrainId = tr.Id
WHERE LOWER(mr.Details) LIKE '%inspection%'
ORDER BY TrainId

-- 11
CREATE FUNCTION udf_TownsWithTrains(@name NVARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @result INT
	DECLARE @depCount INT
	DECLARE @arCount INT

	SELECT @depCount = COUNT(*)
		FROM Towns AS tw
		JOIN Trains AS trD ON tw.Id = trD.DepartureTownId
		WHERE Name = @name

	SELECT @arCount = COUNT(*)
		FROM Towns AS tw
		JOIN Trains AS trD ON tw.Id = trD.ArrivalTownId
		WHERE tw.[Name] = @name

	SET @result = @depCount +  @arCount

	RETURN @result
END;

SELECT dbo.udf_TownsWithTrains('Paris')

-- 12
SELECT 
		p.[Name] AS PassengerName,
		tic.DateOfDeparture AS DateOfDeparture,
		tr.HourOfDeparture AS HourOfDeparture
FROM Towns AS tw
JOIN Trains AS tr ON tr.ArrivalTownId = tw.Id
JOIN Tickets AS tic ON tic.TrainId = tr.Id
JOIN Passengers AS p ON p.Id = tic.PassengerId 
WHERE tw.[Name] = 'Berlin'
ORDER BY DateOfDeparture DESC, PassengerName

SELECT *
FROM Trains
WHERE A

CREATE PROC usp_SearchByTown(@townName NVARCHAR(50))
AS
BEGIN
SELECT 
		p.[Name] AS PassengerName,
		tic.DateOfDeparture AS DateOfDeparture,
		tr.HourOfDeparture AS HourOfDeparture
FROM Towns AS tw
JOIN Trains AS tr ON tr.ArrivalTownId = tw.Id
JOIN Tickets AS tic ON tic.TrainId = tr.Id
JOIN Passengers AS p ON p.Id = tic.PassengerId 
WHERE tw.[Name] = @townName
ORDER BY DateOfDeparture DESC, PassengerName
END

EXEC usp_SearchByTown 'Berlin'





