CREATE DATABASE [Hotel]

USE [Hotel]

CREATE TABLE [Employees]
(Id INT PRIMARY KEY IDENTITY,
FirstName NVARCHAR(70) NOT NULL,
LastName NVARCHAR(70) NOT NULL,
Tirle VARCHAR(70),
Notes DECIMAL)

CREATE TABLE [Customers]
(AccountNumber INT PRIMARY KEY NOT NULL,
FirstName NVARCHAR(70) NOT NULL,
LastName NVARCHAR(70) NOT NULL,
PhoneNumber VARCHAR(20),
EmergencyName NVARCHAR(70),
EmergencyNumber VARCHAR(20),
Notes DECIMAL)

CREATE TABLE [RoomStatus]
(RoomStatus NVARCHAR(50) PRIMARY KEY,
Notes DECIMAL)

CREATE TABLE [RoomTypes]
(RoomType NVARCHAR(50) PRIMARY KEY,
Notes DECIMAL)

CREATE TABLE [BedTypes]
(BedType NVARCHAR(50) PRIMARY KEY,
Notes DECIMAL)

CREATE TABLE [Rooms]
(RoomNumber INT PRIMARY KEY,
RoomType NVARCHAR(50) FOREIGN KEY (RoomType) REFERENCES RoomTypes(RoomType),
BedType NVARCHAR(50) FOREIGN KEY (BedType) REFERENCES BedTypes(BedType),
Rate DECIMAL,
RoomStatus NVARCHAR(50) FOREIGN KEY (RoomStatus) REFERENCES RoomStatus(RoomStatus),
Notes DECIMAL)

CREATE TABLE [Payments]
(Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY (EmployeeId) REFERENCES Employees([Id]),
PaymentDate DATE,
AccountNumber INT FOREIGN KEY (AccountNumber) REFERENCES Customers([AccountNumber]),
FirstDateOccupied DATE,
LastDateOccupied DATE,
TotalDays INT,
AmountCharged DECIMAL,
TaxRate DECIMAL,
PaymentTotal DECIMAL,
Notes DECIMAL)

CREATE TABLE [Occupancies](
Id INT PRIMARY KEY IDENTITY,
EmployeeId INT FOREIGN KEY (EmployeeId) REFERENCES Employees([Id]),
DateOccupied DATE,
AccountNumber INT FOREIGN KEY (AccountNumber) REFERENCES Customers([AccountNumber]),
RoomNumber INT FOREIGN KEY (RoomNumber) REFERENCES Rooms([RoomNumber]),
RateApplied DECIMAL,
PhoneCharge INT,
NOTES DECIMAL
)

INSERT INTO [Employees]
VALUES
('FirstName1', 'LastName1', NULL, NULL),
('FirstName2', 'LastName2', NULL, NULL),
('FirstName3', 'LastName3', NULL, NULL)

INSERT INTO [Customers]
VALUES
(123, 'FirstName1', 'LastName1', NULL, NULL, NULL, NULL),
(124, 'FirstName2', 'LastName2', NULL, NULL, NULL, NULL),
(125, 'FirstName3', 'LastName3', NULL, NULL, NULL, NULL)

INSERT INTO [RoomStatus]
VALUES
('Status1', NULL),
('Status2', NULL),
('Status3', NULL)

INSERT INTO [RoomTypes]
VALUES
('Type1', NULL),
('Type2', NULL),
('Type3', NULL)

INSERT INTO [BedTypes]
VALUES
('Type1', NULL),
('Type2', NULL),
('Type3', NULL)

INSERT INTO [Rooms]
VALUES
(1, 'Type1', 'Type1', NULL, 'Status1', NULL),
(2, 'Type2', 'Type2', NULL, 'Status2', NULL),
(3, 'Type3', 'Type3', NULL, 'Status3', NULL)

INSERT INTO [Payments]
VALUES
(1, NULL, 123, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(2, NULL, 124, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
(3, NULL, 125, NULL, NULL, NULL, NULL, NULL, NULL, NULL)

INSERT INTO [Occupancies]
VALUES
(1, NULL, 123, 1, NULL, NULL, NULL),
(2, NULL, 124, 2, NULL, NULL, NULL),
(3, NULL, 125, 3, NULL, NULL, NULL)
