-- 1
SELECT TOP 5
	e.EmployeeID
	,e.JobTitle
	,e.AddressID
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
ORDER BY a.AddressID

-- 2
SELECT TOP 50
	e.FirstName
	,e.LastName
	,t.Name AS Town
	,a.AddressText
FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON a.TownID = t.TownID
ORDER BY e.FirstName, e.LastName

-- 3
SELECT
	e.EmployeeID
	,e.FirstName
	,e.LastName
	,d.Name
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY e.EmployeeID

-- 4
SELECT TOP 5
	e.EmployeeID
	,e.FirstName
	,e.Salary
	,d.[Name]
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

-- 5
SELECT TOP 3
	 e.EmployeeID
	,e.FirstName
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

-- 6
SELECT 
	e.FirstName
	,e.LastName
	,e.HireDate
	,d.[Name] AS DeptName
FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID 
AND e.HireDate > '1.1.1999' 
AND d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate

-- 7 
SELECT TOP 5
			e.EmployeeID
			,e.FirstName
			,p.[Name] AS ProjectName
		FROM Employees AS e
		JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects AS p ON ep.ProjectID = p.ProjectID
		WHERE p.StartDate > {d'2002-08-13'} AND p.EndDate IS NULL
		ORDER BY EmployeeID

-- 8
SELECT 
	EmployeeID	
	,FirstName
	,ProjectName =
	CASE
		WHEN YEAR(StartDate) >= 2005 THEN NULL
		ELSE ProjectName
END
FROM
		(SELECT 
			e.EmployeeID
			,e.FirstName
			,p.[Name] AS ProjectName
			,p.StartDate AS StartDate
		FROM Employees AS e
		JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
		JOIN Projects AS p ON ep.ProjectID = p.ProjectID
		WHERE e.EmployeeID = 24) AS dt

-- 9 
SELECT
	e.EmployeeID
	,e.FirstName
	,e.ManagerID
	,m.[FirstName]
FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

-- 10
SELECT TOP 50
	e.EmployeeID
	,CONCAT_WS(' ', e.FirstName, e.LastName) AS EmployeeName
	,CONCAT_WS(' ', m.FirstName, m.LastName) AS ManagerName
	,d.[Name] AS DepartmentName
FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- 11
SELECT
	MIN(AvgSalary) AS MinAverageSalary
FROM
		(SELECT
			DepartmentID,
			AVG(Salary) AS AvgSalary
		FROM Employees
		GROUP BY DepartmentID) AS dt

-- 12
SELECT 
	mc.CountryCode
	,m.MountainRange
	,p.PeakName
	,p.Elevation
FROM MountainsCountries AS mc
JOIN Mountains AS m ON mc.MountainId = m.Id
JOIN Peaks AS p ON m.Id = p.MountainId
WHERE mc.CountryCode = 'BG' 
AND p.Elevation > 2835
ORDER BY p.Elevation DESC

-- 13
SELECT 
	CountryCode
	,COUNT(MountainId) AS	MountainRanges
FROM MountainsCountries 
WHERE CountryCode IN ('BG', 'RU', 'US')
GROUP BY CountryCode

-- 14
SELECT TOP 5
	c.CountryName
	,r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

-- 15 *
SELECT 
		ContinentCode
		,CurrencyCode
		,CurrencyUsage
FROM
		(
			SELECT 
					*
					,DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyUsage DESC) AS UsageRank
			FROM
				(
					SELECT
							ContinentCode
							,CurrencyCode 
							,COUNT(*) AS CurrencyUsage
					FROM Countries
					GROUP BY ContinentCode, CurrencyCode
					HAVING COUNT(*) > 1
				) AS dt
		) AS dt2
WHERE UsageRank = 1
ORDER BY ContinentCode

-- 16
SELECT
	COUNT(*)
FROM
		(SELECT 
			c.CountryCode AS Country
			,mc.MountainId AS MID
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		WHERE mc.MountainId IS NULL) AS dt

-- 17
SELECT TOP 5
	c.CountryName
	,MAX(p.Elevation) AS HighestPeakElevation
	,MAX(r.[Length]) AS LongestRiverLength
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
LEFT JOIN Peaks AS p ON m.Id = p.MountainId
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, c.CountryName

-- 18 *
SELECT TOP 5
	dt.CountryName AS Country
	, ISNULL(PeakName,'(no highest peak)') AS [Highest Peak Name]
	, ISNULL(dt.PeakHight,0) AS [Highest Peak Elevation]
	,ISNULL(MountainRange,'(no mountain)') AS Mountain
FROM
		(SELECT
			c.CountryName AS CountryName
			,p.Elevation AS PeakHight
			,p.PeakName AS PeakName
			,m.MountainRange AS MountainRange
			,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS RankElevation
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON m.Id = p.MountainId) AS dt
WHERE RankElevation = 1
ORDER BY CountryName, [Highest Peak Name]
