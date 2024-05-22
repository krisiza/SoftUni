-- 7
CREATE DATABASE [People]

USE People;

CREATE TABLE People (
	Id int UNIQUE IDENTITY,
	Name nvarchar(200) NOT NULL,
	Picture varbinary(MAX),
	Height numeric(3, 2), -- Judge also accepts float(2)
	Weight numeric(5, 2), -- Judge also accepts float(2)
	Gender char(1) NOT NULL,
	Birthdate date NOT NULL,
	Biography nvarchar(MAX),
	CONSTRAINT PK_People PRIMARY KEY(Id),
	CONSTRAINT CK_People_Gender CHECK (Gender='m' OR Gender='f')
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
	('Maria', 011010101, 1.64, 65.77, 'f', '1985/01/17', 'Marias Bio'),
	('Peter', 01111101, 1.88, 87.00, 'm', '1980/06/11', 'Peters Bio'),
	('Ida', 100000001, 1.64, 65.77, 'f', '1985/05/03', 'Idas Bio'),
	('Nia', 000011010, 1.70, 60.52, 'f', '1975/06/06', 'Nias Bio'),
	('Tom', 101010101, 1.90, 85.7, 'm', '1995/08/08', 'Toms Bio')


-- 8
CREATE TABLE Users (
	Id int UNIQUE IDENTITY,
	Username varchar(30) UNIQUE NOT NULL,
	Password varchar(26) NOT NULL,
	ProfilePicture varbinary(900),
	LastLoginTime datetime,
	IsDeleted bit DEFAULT 0,
	CONSTRAINT PK_Users PRIMARY KEY(Id)
)

INSERT INTO Users(Username, Password, ProfilePicture, LastLoginTime, IsDeleted)
VALUES
	('tom', 'asdasdasdasd', 01010, '2016/01/18 00:01:50', 0),
	('maria', 'password', 0000, '2016/02/17 16:50:50', 0),
	('nia', 'asdasdasdasd', 1111, '2016/03/17 08:45:45', 1),
	('peter', 'password', 111, '2016/04/17 15:01:50', 0),
	('eva', 'password', 011110, '2016/05/17 22:23:50', 1)


-- 9
ALTER TABLE Users
DROP CONSTRAINT PK__Users;

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id, Username);

-- 10
ALTER TABLE Users
ADD CHECK (LEN([Password]) >= 5); 

-- 11
ALTER TABLE Users
ADD CONSTRAINT DF_Users_LastLogin DEFAULT getdate() FOR LastLoginTime


-- 12
ALTER TABLE Users
DROP CONSTRAINT PK_Users

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CK_Users_Username CHECK (len(Username) >= 3)