-- 13
CREATE DATABASE [Movies]

USE[Movies]

CREATE TABLE [Directors](
[Id] INT PRIMARY KEY IDENTITY,
[DirectorName] NVARCHAR(70) NOT NULL,
[Notes] DECIMAL)

CREATE TABLE [Genres](
[Id] INT PRIMARY KEY IDENTITY,
[GenreName] NVARCHAR(70) NOT NULL,
[Notes] DECIMAL)

CREATE TABLE [Categories](
[Id] INT PRIMARY KEY IDENTITY,
[CategoriesName] NVARCHAR(70) NOT NULL,
[Notes] DECIMAL)

CREATE TABLE [Movies](
[Id] INT PRIMARY KEY IDENTITY,
[Title] NVARCHAR(70) NOT NULL,
[DirectorId] INT FOREIGN KEY (DirectorId) REFERENCES Directors([Id]),
[CopyrightYear] DATE,
[Lenght] DECIMAL,
[GenreId] INT FOREIGN KEY (GenreId) REFERENCES Genres([Id]),
[CategoryId] INT FOREIGN KEY (CategoryId) REFERENCES Categories([Id]),
[Rating] DECIMAL,
[Notes] DECIMAL)

INSERT INTO [Directors]
VALUES
('firstName1', NULL),
('firstName2', NULL),
('firstName3', NULL),
('firstName4', NULL),
('firstName5', NULL)

INSERT INTO [Genres]
VALUES
('GenresName1', NULL),
('GenresName2', NULL),
('GenresName3', NULL),
('GenresName4', NULL),
('GenresName5', NULL)

INSERT INTO [Categories]
VALUES
('CategoriesName1', NULL),
('CategoriesName2', NULL),
('CategoriesName3', NULL),
('CategoriesName4', NULL),
('CategoriesName5', NULL)

INSERT INTO [Movies]
VALUES
('Movie1', 1, NULL, NULL, 3, 1, NULL, NULL),
('Movie2', 2, NULL, NULL, 1, 2, NULL, NULL),
('Movie3', 3, NULL, NULL, 2, 3, NULL, NULL),
('Movie4', 4, NULL, NULL, 3, 4, NULL, NULL),
('Movie5', 1, NULL, NULL, 5, 5, NULL, NULL)