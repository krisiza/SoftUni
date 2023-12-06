CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE [Towns](
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(70) NOT NULL)

CREATE TABLE [Addresses](
Id INT PRIMARY KEY IDENTITY,
AddressText NVARCHAR(200) NOT NULL,
TownId INT FOREIGN KEY (TownId) REFERENCES Towns(Id))

CREATE TABLE [Departments](
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(70) NOT NULL)

CREATE TABLE [Employees](
[Id] INT PRIMARY KEY IDENTITY,
[FirstName] NVARCHAR(70) NOT NULL,
[MiddleName] NVARCHAR(70),
[LastName] NVARCHAR(70) NOT NULL,
[JobTitle] NVARCHAR(70) NOT NULL,
[DepartmentId] INT FOREIGN KEY (DepartmentId) REFERENCES Departments(Id),
HireDate DATE,
Salary DECIMAL,
AddressId INT FOREIGN KEY (AddressId) REFERENCES Addresses (Id))

INSERT INTO [Towns]
VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO [Departments]
VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO [Employees]
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4,	'01/02/2013', 3500.00, NULL),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1,	'02/03/2004', 4000.00, NULL),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5,	'28/08/2016', 525.25, NULL),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2,	'09/12/2007', 3000.00, NULL),
('Peter', 'Pan', 'Pan', 'Intern', 3,	'28/08/2016', 599.88, NULL)

-- 20
SELECT * FROM Towns ORDER BY [Name]
SELECT * FROM Departments ORDER BY [Name]
SELECT * FROM Employees ORDER BY Salary DESC

-- 21
SELECT [Name] FROM Towns ORDER BY [Name]
SELECT [Name] FROM Departments ORDER BY [Name]
SELECT FirstName, LastName, JobTitle, Salary FROM Employees ORDER BY Salary DESC

-- 22
UPDATE Employees
SET Salary = Salary + (Salary * 0.1)

SELECT Salary FROM Employees

-- 23
UPDATE Payments
SET TaxRate = TaxRate - (TaxRate * 0.03)

SELECT TaxRate FROM Payments

-- 24
TRUNCATE TABLE Occupancies 