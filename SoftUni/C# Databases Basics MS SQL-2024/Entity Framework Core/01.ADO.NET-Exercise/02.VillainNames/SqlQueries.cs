using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.VillainNames
{
    internal static class SqlQueries
    {
        public static string GetAllVillainsAndCountOfTheirMeinions = 
            @"SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
              FROM Villains AS v 
              JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
              GROUP BY v.Id, v.Name 
              HAVING COUNT(mv.VillainId) > 3 
              ORDER BY COUNT(mv.VillainId)";

        public static string GetVillainById =
            @"SELECT Name FROM Villains WHERE Id = @Id";

        public static string GetVillainsMinions =
            @"SELECT ROW_NUMBER() OVER (ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

        public static string GetVillainIdByName =
            @"SELECT Id FROM Villains WHERE Name = @Name";

        public static string GetMinionIdByName =
            @"SELECT Id FROM Minions WHERE Name = @Name";

        public static string GetTownIdByName =
            @"SELECT Id FROM Towns WHERE Name = @townName";

        public static string InsertMinion =
            @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public static string InsertTown =
            @"INSERT INTO Towns (Name) VALUES (@townName)";

        public static string InsertMinionsVallainsRelations =
            @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";

        public static string InsertVallian =
            @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public static string UpdateTownNameToUpper =
            @"UPDATE Towns
                SET Name = UPPER(Name)
                WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";

        public static string SelectAllTownsFromCountry =
            @"SELECT t.Name 
                FROM Towns as t
                JOIN Countries AS c ON c.Id = t.CountryCode
               WHERE c.Name = @countryName";

        public static string SelectVillainById =
            @"SELECT Name FROM Villains WHERE Id = @villainId";

        public static string DeleteRelationMinionsVillainsByVillainId =
            @"DELETE FROM MinionsVillains 
                WHERE VillainId = @villainId";

        public static string DeleteVillainById =
            @"DELETE FROM Villains
                WHERE Id = @villainId";

        public static string SelectAllMinions =
            @"SELECT Name FROM Minions";

        public static string IncrementMinionAgeByOne =
            @"UPDATE Minions
                SET Name = UPPER(LEFT(Name, 1)) + SUBSTRING(Name, 2, LEN(Name)), Age += 1
                WHERE Id = @Id";

        public static string SelectAllMinionsNameAndAge =
            @"SELECT Name, Age FROM Minions";

        public static string StoredProcedure =
              @"CREATE PROC usp_GetOlder @id INT
          AS
          BEGIN
            UPDATE Minions
            SET Age += 1
            WHERE Id = @id
          END";

        public static string SelectMinionNameAndAgeById =
            @"SELECT Name, Age FROM Minions WHERE Id = @Id";
    }
}
