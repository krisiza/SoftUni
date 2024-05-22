-- 1
SELECT FirstName, LastName
FROM Employees
WHERE SUBSTRING([FirstName],1,2) = 'Sa'

-- 2
SELECT FirstName, LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 3
SELECT FirstName 
From Employees
WHERE DepartmentID IN (3,10)
AND YEAR(HireDate) BETWEEN 1995 AND 2005

-- 4
SELECT FirstName, LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- 5
SELECT [Name]
FROM Towns
WHERE LEN([Name]) BETWEEN 5 AND 6
ORDER BY [Name]

-- 6
SELECT TownID, [Name]
FROM Towns
WHERE LEFT([Name],1) IN ('M','K','B' ,'E')
ORDER BY [Name]

-- 7
SELECT TownID, [Name]
FROM Towns
WHERE LEFT([Name],1) <> 'R' AND LEFT([Name],1)  <> 'B' AND LEFT([Name],1) != 'D'
ORDER BY [Name]

-- 8
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName
FROM Employees
WHERE  YEAR(HireDate) > 2000

-- 9
SELECT FirstName, LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 10
SELECT EmployeeID, 
	   FirstName,
	   LastName, 
	   Salary, 
	   DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
   WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- 11
WITH RankedEmployees AS (
    SELECT EmployeeID, 
		   FirstName, 
		   LastName, 
		   Salary,
           DENSE_RANK() OVER (PARTITION BY Salary 
                              ORDER BY EmployeeID) AS [Rank]
    FROM Employees
    WHERE Salary BETWEEN 10000 AND 50000
)
SELECT EmployeeID, 
	   FirstName, 
	   LastName, 
	   Salary, [Rank]
FROM RankedEmployees
WHERE [Rank] = 2
ORDER BY Salary DESC;

-- 12
SELECT CountryName, ISOCode
FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY ISOCode;

-- 13 
SELECT p.PeakName, 
	   r.RiverName,
	   LOWER(CONCAT(SUBSTRING(p.PeakName,1,LEN(p.PeakName)-1), r.RiverName)) AS Mix
	FROM Peaks AS p,
	Rivers AS r
WHERE RIGHT(LOWER(p.PeakName),1) = LEFT(LOWER(r.RiverName), 1)
ORDER BY Mix

---- Method 2
SELECT Peaks.PeakName, 
	   Rivers.RiverName,  
	   LOWER(CONCAT(SUBSTRING(Peaks.PeakName,1,LEN(Peaks.PeakName)-1), Rivers.RiverName)) AS Mix
	FROM Peaks
LEFT JOIN Rivers ON RIGHT(Peaks.PeakName, 1) = LEFT(LOWER(Rivers.RiverName),1)
WHERE RiverName IS NOT NULL
ORDER BY Mix


-- 14
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE YEAR([Start]) BETWEEN 2011 AND 2012
ORDER BY [Start], [Name]

-- 15
WITH IntigersTable AS 
	(SELECT Username, Email, CHARINDEX('@', Email) AS [StartingIndex]
	FROM Users)
SELECT Username, SUBSTRING(Email, [StartingIndex]+1, LEN(Email)) AS [Email Provider]
FROM IntigersTable
ORDER BY [Email Provider], Username

-- 16
SELECT Username, IpAddress
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- 17
WITH FirstTable5 AS
	(SELECT [Name], 
		DATEPART(HOUR, [Start]) AS [DatePart], 
		Duration
	FROM Games)
SELECT [Name],

	CASE
		WHEN [DatePart] >= 0 AND [DatePart] < 12 THEN 'Morning'
		WHEN [DatePart] >= 12 AND [DatePart] < 18 THEN 'Afternoon'
		WHEN [DatePart] >= 18 AND [DatePart] < 24 THEN 'Evening'
	END AS [Part of the Day],

	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END AS Duration
FROM FirstTable5
ORDER BY [Name], [Duration], [Part of the Day]

-- 18
SELECT 
	ProductName, 
	OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders

-- 19
CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	Birthdate DATETIME2
)

INSERT INTO People
VALUES
('Victor', '2000-12-07 00:00:00.000'),
('Steven', '1992-09-10 00:00:00.000'),
('Stephen', '1910-09-19 00:00:00.000'),
('John', '2010-01-06 00:00:00.000')

SELECT [Name], 
	DATEDIFF(year, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(day, Birthdate, GETDATE()) AS [Age in Days],
	DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People

