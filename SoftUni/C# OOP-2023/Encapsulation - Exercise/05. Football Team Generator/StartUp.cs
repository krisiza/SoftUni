using System.Xml.Linq;

namespace EncapsulationExercise
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            string command;
            List<Team> teams = new List<Team>();

            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    switch (tokens[0])
                    {
                        case "Team":
                            Team team = new(tokens[1]);
                            teams.Add(team);
                            break;

                        case "Add":
                            var foundTeam = teams.FirstOrDefault(team => team.Name == tokens[1]);

                            if (foundTeam == null)
                            {
                                throw new Exception($"Team {tokens[1]} does not exist.");
                            }

                            Stats stats = new(int.Parse(tokens[3]), int.Parse(tokens[4]), int.Parse(tokens[5]), int.Parse(tokens[6]), int.Parse(tokens[7]));
                            Player player = new(tokens[2], stats);

                            foundTeam.AddPlayer(player);

                            break;

                        case "Remove":

                            foundTeam = teams.FirstOrDefault(team => team.Name == tokens[1]);

                            if (foundTeam == null)
                            {
                                throw new Exception($"Team {tokens[1]} does not exist.");
                            }

                            var foundPlayer = foundTeam.Players.FirstOrDefault(p => p.Name == tokens[2]);

                            if (foundPlayer == null)
                            {
                                throw new Exception($"Player {tokens[2]} is not in {foundTeam.Name} team.");
                            }

                            foundTeam.RemovePlayer(foundPlayer);


                            break;

                        case "Rating":
                            foundTeam = teams.FirstOrDefault(team => team.Name == tokens[1]);

                            if (foundTeam == null)
                            {
                                throw new Exception($"Team {tokens[1]} does not exist.");
                            }

                            if (foundTeam.Players.Count == 0)
                                Console.WriteLine($"{foundTeam.Name} - 0");
                            else
                                Console.WriteLine($"{foundTeam.Name} - {foundTeam.Rating}");

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }
    }
}