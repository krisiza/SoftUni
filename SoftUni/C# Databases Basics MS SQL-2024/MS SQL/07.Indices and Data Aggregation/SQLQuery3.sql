-- 1
SELECT
	COUNT(*)
FROM WizzardDeposits

-- 2
SELECT
	MAX(MagicWandSize)
FROM WizzardDeposits

-- 3
SELECT
	DepositGroup
	,MAX(MagicWandSize) AS LongestMagicWand
FROM WizzardDeposits
GROUP BY DepositGroup

-- 4
SELECT TOP 2
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- 5
SELECT 
	DepositGroup
	,SUM(DepositAmount)
FROM WizzardDeposits
GROUP BY DepositGroup

-- 6
SELECT 
	DepositGroup
	,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- 7
SELECT 
	DepositGroup
	,SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

-- 8 
SELECT 
	DepositGroup
	,MagicWandCreator
	,MIN(DepositCharge)
FROM WizzardDeposits
GROUP BY DepositGroup,MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup 

-- 9
SELECT 
    CASE 
        WHEN age BETWEEN 0 AND 10 THEN '[0-10]'
        WHEN age BETWEEN 11 AND 20 THEN '[11-20]'
        WHEN age BETWEEN 21 AND 30 THEN '[21-30]'
        WHEN age BETWEEN 31 AND 40 THEN '[31-40]'
        WHEN age BETWEEN 41 AND 50 THEN '[41-50]'
        WHEN age BETWEEN 51 AND 60 THEN '[51-60]'
        ELSE '[61+]'
    END AS AgeGroup,
    COUNT(*) AS WizardCount
FROM
    WizzardDeposits
GROUP BY
    CASE 
        WHEN age BETWEEN 0 AND 10 THEN '[0-10]'
        WHEN age BETWEEN 11 AND 20 THEN '[11-20]'
        WHEN age BETWEEN 21 AND 30 THEN '[21-30]'
        WHEN age BETWEEN 31 AND 40 THEN '[31-40]'
        WHEN age BETWEEN 41 AND 50 THEN '[41-50]'
        WHEN age BETWEEN 51 AND 60 THEN '[51-60]'
        ELSE '[61+]'
    END

-- 10
SELECT
DISTINCT	LEFT(FirstName,1) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY FirstName
ORDER BY FirstLetter

-- 11
SELECT
	DepositGroup
	,IsDepositExpired 
	,AVG(DepositInterest) AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > {d'1985-01-01'}
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired

-- 12 *
SELECT SUM([Difference]) AS SumDifference
FROM
	(
		SELECT 
			FirstName AS [Host Wizard]
			, DepositAmount AS [Host Wizard Deposit]
			,LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard]
			,LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit]
			,DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
		FROM WizzardDeposits
	) AS dt

-- 13
SELECT
	DepartmentID
	,SUM(Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 14
SELECT
	DepartmentID
	,MIN(Salary)
FROM Employees
WHERE DepartmentID IN (2,5,7)
AND HireDate > {d'2000-01-01'}
GROUP BY DepartmentID
ORDER BY DepartmentID

-- 15
SELECT *
INTO #tempTableEmploye
FROM Employees
WHERE Salary > 30000

DELETE 
FROM #tempTableEmploye 
WHERE ManagerID = 42

UPDATE #tempTableEmploye
SET Salary += 5000
WHERE DepartmentID = 1

SELECT
	DepartmentID
	,AVG(Salary) AS AverageSalary
FROM #tempTableEmploye
GROUP BY DepartmentID

-- 16
SELECT
	DepartmentID
	,MAX(Salary)
FROM Employees
GROUP BY DepartmentID
HAVING NOT MAX(Salary) BETWEEN 30000 AND  70000

-- 17
SELECT
	COUNT(*) AS [Count]
FROM Employees
GROUP BY ManagerID
HAVING ManagerID IS NULL

-- 18 *
SELECT 
DISTINCT	DepartmentID
			,Salary
FROM
	(
		SELECT
			DepartmentID
			,Salary
			,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS SalaryRank
		FROM Employees
	) AS dt
WHERE SalaryRank = 3

-- 19 **
SELECT TOP 10
	e.FirstName
	,e.LastName
	,e.DepartmentID
FROM Employees AS e
	JOIN
		(
			SELECT
				DepartmentID
				,AVG(Salary) AS AverageSalary
			FROM Employees
			GROUP BY DepartmentID
		) AS dt
ON e.DepartmentID = dt.DepartmentID
WHERE Salary > AverageSalary
ORDER BY e.DepartmentID