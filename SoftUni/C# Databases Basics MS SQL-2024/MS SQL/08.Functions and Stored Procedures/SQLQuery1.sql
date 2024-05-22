-- 1
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
			AS
		 BEGIN
				SELECT 
						FirstName AS [First Name]
						,LastName AS [Last Name]
				  FROM	Employees
			     WHERE	Salary > 35000
		   END

-- 2
CREATE OR ALTER PROC usp_GetEmployeesSalaryAboveNumber(@number DECIMAL(18,4))
AS
BEGIN
SELECT 
	FirstName
	,LastName
FROM Employees
WHERE Salary >= @number
END

EXEC usp_GetEmployeesSalaryAboveNumber 10000.234

-- 3
CREATE PROC usp_GetTownsStartingWith (@input NVARCHAR(30))
AS
BEGIN
SELECT 
	[Name]
FROM Towns
WHERE LEFT([Name],LEN( @input)) = @input
END

EXEC usp_GetTownsStartingWith be

-- 4
CREATE PROC usp_GetEmployeesFromTown(@townName NVARCHAR(50))
AS
BEGIN
SELECT 
	e.FirstName
	,e.LastName
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
WHERE t.[Name] = @townName
END

EXEC usp_GetEmployeesFromTown Sofia

-- 5
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(30) 
AS
BEGIN
DECLARE @result NVARCHAR(20)
	IF @salary < 30000
	BEGIN
		SET @result = 'Low'
	END;
	ELSE IF @salary BETWEEN 30000 AND 50000
	BEGIN
		SET @result = 'Average'
	END;
	ELSE
	BEGIN
		SET @result = 'High'
	END;

	RETURN @result
END;

SELECT FirstName, LastName, Salary, dbo.ufn_GetSalaryLevel(Salary) FROM Employees

-- 6
CREATE PROC usp_EmployeesBySalaryLevel(@input VARCHAR(8))
AS
BEGIN
SELECT
	FirstName
	,LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary) = @input
END

EXEC usp_EmployeesBySalaryLevel 'high'

-- 7
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(100), @word NVARCHAR(100))
RETURNS BIT
AS
BEGIN
    DECLARE @isComprised BIT = 1;
    DECLARE @index INT = 1;

    WHILE @index <= LEN(@word)
    BEGIN
        DECLARE @currentChar NVARCHAR(1) = SUBSTRING(@word, @index, 1);

        IF CHARINDEX(@currentChar, @setOfLetters) = 0
        BEGIN
            SET @isComprised = 0;
            BREAK;
        END

        SET @index += 1;
    END

    RETURN @isComprised;
END

SELECT
	dbo.ufn_IsWordComprised('oistmiahf', 'halves')

-- 8
CREATE OR ALTER PROC usp_DeleteEmployeesFromDepartment (@departmentId INT) 
AS
BEGIN
	DECLARE @employeesToDelete TABLE(Id INT);

	INSERT INTO @employeesToDelete
	SELECT EmployeeID 
	FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE
	FROM EmployeesProjects
	WHERE EmployeeID IN (
							SELECT * 
							FROM @employeesToDelete
						)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT * 
							FROM @employeesToDelete
						)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT * 
							FROM @employeesToDelete
						)

	DELETE 
	FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE 
	FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 7


-- 9
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
SELECT 
	CONCAT_WS(' ', FirstName, LastName)
FROM AccountHolders
END

-- 10 
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number MONEY)
AS
BEGIN
SELECT 
	ah.FirstName AS [First Name]
	,ah.LastName AS [Last Name]
FROM Accounts AS a
JOIN AccountHolders AS ah ON a.AccountHolderId= ah.Id
GROUP BY ah.FirstName, ah.LastName
HAVING SUM(a.Balance) > @number
ORDER BY ah.FirstName,ah.LastName
END


-- 11
CREATE FUNCTION ufn_CalculateFutureValue(@sum DECIMAL(12,4), @yearlyinterestrate FLOAT, @numberofyears INT)
RETURNS DECIMAL(12,4)
AS
BEGIN
	DECLARE @result DECIMAL(12,4)

	BEGIN
		SET @result = @sum * (POWER((1 + @yearlyinterestrate), @numberofyears))
	END
RETURN @result
END;

SELECT dbo.ufn_CalculateFutureValue(123.12, 0.1, 5)

-- 12 
CREATE PROC usp_CalculateFutureValueForAccount( @accountId INT,  @yearlyinterestrate FLOAT)
AS
BEGIN
SELECT TOP 1
	ah.Id AS [Account Id]
	,ah.FirstName AS [First Name]
	,ah.LastName AS [Last Name]
	,a.Balance AS [Current Balance]
	, dbo.ufn_CalculateFutureValue(a.Balance, @yearlyinterestrate , 5) AS [Balance in 5 years]
FROM AccountHolders AS ah
JOIN Accounts AS a ON ah.Id = a.AccountHolderId
WHERE ah.Id = @accountId
END

EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1

-- 13
CREATE FUNCTION ufn_CashInUsersGames( @gameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN	
SELECT 
		SUM([Cash]) AS SumCash
FROM
	(
		SELECT
			ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS [Row]
			,ug.Cash AS Cash
		FROM Games AS g 
		JOIN UsersGames AS ug ON g.Id = ug.GameId
		WHERE @gameName  = g.[Name]
	) dt
WHERE [Row] % 2 = 1
