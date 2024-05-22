using Microsoft.Data.SqlClient;
using System.Reflection.Metadata;
using System.Text;

namespace _02.VillainNames
{
    internal class Program
    {
        static async Task Main()

        {
            const string sqlConnectionString = @"Server=NBKRISTIYANAZA;Database=MinionsDB;Integrated Security=true;TrustServerCertificate=true;";

            await using SqlConnection sqlConnection = new(sqlConnectionString);
            await sqlConnection.OpenAsync();

            string result = await IncreaseAgeStoredProcedure(sqlConnection);
            Console.WriteLine(result);
        }

        static async Task<string> GetAllVillainsWithTheirMinions(SqlConnection sqlConnection)
        {
            StringBuilder stringBuilder = new();

            SqlCommand sqlCommand = new(SqlQueries.GetAllVillainsAndCountOfTheirMeinions, sqlConnection);
            SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                string villlainName = reader["Name"].ToString();
                int minionsCount = (int)reader["MinionsCount"];

                stringBuilder.AppendLine($"{villlainName} - {minionsCount}");
            }

            return stringBuilder.ToString().TrimEnd();
        }

        static async Task<string> GetVillainAndHisMinions(SqlConnection sqlConnection)
        {
            StringBuilder stringBuilder = new();

            int villainId = int.Parse(Console.ReadLine());

            using SqlCommand getVillainCommand = new(SqlQueries.GetVillainById, sqlConnection);
            getVillainCommand.Parameters.AddWithValue("@Id", villainId);

            object? villainnameObj = await getVillainCommand.ExecuteScalarAsync();

            if (villainnameObj == null)
            {
                stringBuilder.AppendLine($"No villain with ID {villainId} exists in the database.");
                return stringBuilder.ToString().TrimEnd();
            }

            string villainname = (string)villainnameObj;

            using SqlCommand minionsCommand = new(SqlQueries.GetVillainsMinions, sqlConnection);
            minionsCommand.Parameters.AddWithValue("@Id", villainId);
            SqlDataReader readerMinions = await minionsCommand.ExecuteReaderAsync();
            stringBuilder.AppendLine($"Villain: {villainname}");

            if (!readerMinions.HasRows)
            {
                stringBuilder.AppendLine("(no minions)");
            }
            else
            {
                while (readerMinions.Read())
                {
                    long rowNumber = (long)readerMinions[0];
                    string minionName = (string)readerMinions[1];
                    int age = (int)readerMinions[2];

                    stringBuilder.AppendLine($"{rowNumber}. {minionName} {age}");
                }
            }


            return stringBuilder.ToString().TrimEnd();
        }

        static async Task<string> AddMinion(SqlConnection sqlConnection)
        {
            StringBuilder stringBuilder = new();

            string[] minionInfo = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();
            string villainName = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray()[0];

            string minionName = minionInfo[0];
            int minionAge = int.Parse(minionInfo[1]);
            string townName = minionInfo[2];

            SqlTransaction transaction = sqlConnection.BeginTransaction();

            try
            {
                int townId = await GetTownByIdOrAddAsync(sqlConnection, stringBuilder, townName, transaction);
                int villainid = await GetVillainIdOrAddAsync(sqlConnection, stringBuilder, villainName, transaction);
                int minionid = await AddNewMinionAndReturnIdAsync(sqlConnection, minionName, minionAge, townId, transaction);

                await AddNewMinionAndReturnIdAsync(sqlConnection, minionName, minionAge, townId, transaction);
                stringBuilder.AppendLine($"Successfully added {minionName} to be minion of {villainName}");

                await transaction.CommitAsync();
            }
            catch
            {
                transaction.Rollback();
            }


            return stringBuilder.ToString().TrimEnd();
        }

        private static async Task<int> GetTownByIdOrAddAsync(SqlConnection sqlConnection, StringBuilder stringBuilder, string townName, SqlTransaction transaction)
        {
            SqlCommand searchTown = new(SqlQueries.GetTownIdByName, sqlConnection, transaction);
            searchTown.Parameters.AddWithValue("@townName", townName);
            Object townIdObj = await searchTown.ExecuteScalarAsync();

            if (townIdObj == null)
            {
                SqlCommand insertTown = new(SqlQueries.InsertTown, sqlConnection, transaction);
                insertTown.Parameters.AddWithValue("@townName", townName);

                await insertTown.ExecuteNonQueryAsync();
                townIdObj = await searchTown.ExecuteScalarAsync();
                stringBuilder.AppendLine($"Town {townName} was added to the database.");
            }

            return (int)townIdObj;
        }

        private static async Task<int> GetVillainIdOrAddAsync(SqlConnection sqlConnection, StringBuilder stringBuilder, string villainName, SqlTransaction transaction)
        {
            SqlCommand getvillain = new(SqlQueries.GetVillainIdByName, sqlConnection, transaction);
            getvillain.Parameters.AddWithValue("@Name", villainName);
            int? villainId = (int?)await getvillain.ExecuteScalarAsync();

            if (!villainId.HasValue)
            {
                SqlCommand insertVillain = new(SqlQueries.InsertVallian, sqlConnection, transaction);
                insertVillain.Parameters.AddWithValue("@villainName", villainName);

                await insertVillain.ExecuteNonQueryAsync();

                villainId = (int?)await getvillain.ExecuteScalarAsync();
                stringBuilder.AppendLine($"Villain {villainName} was added to the database.");
            }

            return villainId.Value;
        }

        private static async Task<int> AddNewMinionAndReturnIdAsync(SqlConnection sqlConnection, string minionName, int minionAge, int townId, SqlTransaction transaction)
        {
            SqlCommand addMinion = new(SqlQueries.InsertMinion, sqlConnection, transaction);
            addMinion.Parameters.AddWithValue("@name", minionName);
            addMinion.Parameters.AddWithValue("@age", minionAge);
            addMinion.Parameters.AddWithValue("@townId", townId);

            await addMinion.ExecuteNonQueryAsync();

            SqlCommand getMinionId = new(SqlQueries.GetMinionIdByName, sqlConnection, transaction);
            getMinionId.Parameters.AddWithValue("@Name", minionName);

            int minionId = (int)await getMinionId.ExecuteScalarAsync();
            return minionId;

        }

        private static async Task SetMinionToBeServantOfVillainAsynic(SqlConnection sqlConnection, int minionId, int villainId, SqlTransaction transaction)
        {
            SqlCommand addMinionVillainCmd = new(SqlQueries.InsertMinionsVallainsRelations, sqlConnection, transaction);
            addMinionVillainCmd.Parameters.AddWithValue("@minionId", minionId);
            addMinionVillainCmd.Parameters.AddWithValue("@villainId", villainId);

            await addMinionVillainCmd.ExecuteNonQueryAsync();
        }

        static async Task<string> ChangeTownNamesCasing(SqlConnection sqlConnection)
        {
            StringBuilder sb = new StringBuilder();

            string country = Console.ReadLine();

            SqlCommand updateTownName = new(SqlQueries.UpdateTownNameToUpper, sqlConnection);
            updateTownName.Parameters.AddWithValue("@countryName", country);
            int affectedRows = await updateTownName.ExecuteNonQueryAsync();

            if (affectedRows == 0)
            {
                sb.AppendLine("No town names were affected.");
                return sb.ToString().TrimEnd();
            }

            sb.AppendLine($"{affectedRows} town names were affected.");

            SqlCommand selectTowns = new(SqlQueries.SelectAllTownsFromCountry, sqlConnection);
            selectTowns.Parameters.AddWithValue("@countryName", country);
            SqlDataReader reader = await selectTowns.ExecuteReaderAsync();

            List<string> cities= new List<string>();
            while (reader.Read()) 
            {
                cities.Add((string)reader["Name"]);
            }


            sb.AppendLine($"[{string.Join(", ", cities)}]");

            return sb.ToString().TrimEnd();

        }

        static async Task<string> RemoveVillain(SqlConnection sqlConnection)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int villainId = int.Parse(Console.ReadLine());

            SqlTransaction transaction = sqlConnection.BeginTransaction();

            try
            {
                SqlCommand selectVillain = new(SqlQueries.SelectVillainById, sqlConnection, transaction);
                selectVillain.Parameters.AddWithValue("@villainId", villainId);
                string? villainName = (string?)await selectVillain.ExecuteScalarAsync();

                if (villainName == null)
                {
                    stringBuilder.AppendLine("No such villain was found.");
                    return stringBuilder.ToString().TrimEnd();
                }

                SqlCommand deleteVillainMinionsRelation = new(SqlQueries.DeleteRelationMinionsVillainsByVillainId, sqlConnection, transaction);
                deleteVillainMinionsRelation.Parameters.AddWithValue("@villainId", villainId);
                int relesedMinions = await deleteVillainMinionsRelation.ExecuteNonQueryAsync();

                SqlCommand deleteVillain = new(SqlQueries.DeleteVillainById, sqlConnection, transaction);
                deleteVillain.Parameters.AddWithValue("@villainId", villainId);
                await deleteVillain.ExecuteNonQueryAsync();

                stringBuilder.AppendLine($"{villainName} was deleted.");
                stringBuilder.AppendLine($"{relesedMinions} minions were released");

                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
            }
           

            return stringBuilder.ToString().TrimEnd();
        }

        static async Task<string> PrintAllMinionNames(SqlConnection sqlConnection)
        {
            var stringBuilder = new StringBuilder();

            SqlCommand selectMinions = new(SqlQueries.SelectAllMinions, sqlConnection);
            SqlDataReader reader = selectMinions.ExecuteReader();

            List<string> minions = new List<string>();
            while (reader.Read()) 
            {
                minions.Add((string)reader["Name"]);
            }

            while(minions.Count > 0) 
            {
                string firstMinion = minions[0];
                minions.RemoveAt(0);
                stringBuilder.AppendLine(firstMinion);

                if(minions.Count > 0)
                {
                    string lastMinion = minions[^1];
                    minions.RemoveAt(minions.Count-1);
                    stringBuilder.AppendLine(lastMinion);
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }

        static async Task<string> IncreaseMinionAge(SqlConnection sqlConnection)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int[]minionsId = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            SqlTransaction transaction = sqlConnection.BeginTransaction();

            try 
            {
                for(int i = 0; i < minionsId.Length; i++)
                {
                    SqlCommand incrementAge = new(SqlQueries.IncrementMinionAgeByOne, sqlConnection, transaction);
                    incrementAge.Parameters.AddWithValue("@Id", minionsId[i]);
                    await incrementAge.ExecuteNonQueryAsync();
                }

                SqlCommand getMinions = new(SqlQueries.SelectAllMinionsNameAndAge, sqlConnection, transaction);
                SqlDataReader reader = await getMinions.ExecuteReaderAsync();


                while (reader.Read()) 
                {
                    stringBuilder.AppendLine($"{(string)reader[0]} {(int)reader[1]}");
                }

            }
            catch
            {
                await transaction.RollbackAsync();
            }

            return stringBuilder.ToString().TrimEnd();
        }

        static async Task<string> IncreaseAgeStoredProcedure(SqlConnection sqlConnection)
        {
            StringBuilder stringBuilder = new StringBuilder();

            int minionId = int.Parse(Console.ReadLine());

            using (SqlCommand createProcedureCmd = new SqlCommand(SqlQueries.StoredProcedure, sqlConnection))
            {
                await createProcedureCmd.ExecuteNonQueryAsync();
            }

            using (SqlCommand storeProcedureCmd = new SqlCommand("usp_GetOlder", sqlConnection))
            {
                storeProcedureCmd.CommandType = System.Data.CommandType.StoredProcedure;
                storeProcedureCmd.Parameters.AddWithValue("@id", minionId);
                await storeProcedureCmd.ExecuteNonQueryAsync();
            }

            SqlCommand getMinion = new(SqlQueries.SelectMinionNameAndAgeById, sqlConnection);
            getMinion.Parameters.Add(new SqlParameter("@Id", minionId));
            SqlDataReader reader = await getMinion.ExecuteReaderAsync();

            while (reader.Read()) 
            {
                stringBuilder.AppendLine($"{(string)reader[0]} – {(int)reader[1]} years old");
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }

}
