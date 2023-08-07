using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamWorkProject
{
    internal class Program
    {
        /*
4      
John-PowerPuffsCoders
Tony-Tony is the best
John-PowerPuffsCoders
Tony-Hi
Peter->PowerPuffsCoders
Tony->Tony is the best
        */
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Team> teams = new List<Team>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split('-');

                
                string user = arr[0];
                string teamName = arr[1];

                Team team = new Team(teamName, user);

                var result = teams.FirstOrDefault(team => team.Name == teamName);
                var resultCreator = teams.Find(team => team.Creator == user);

                if (result != null)
                {
                    Console.WriteLine($"Team {team.Name} was already created!");
                    continue;
                }

                if (resultCreator != null)
                {
                    Console.WriteLine($"{team.Creator} cannot create another team!");
                    continue;
                }

                teams.Add(team);
                Console.WriteLine($"Team {team.Name} has been created by {team.Creator}!");

            }

            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                string[] arr = input.Split("->");

                string member = arr[0];
                string teamName = arr[1];


                var result = teams.Find(teams => teams.Name == teamName);
                if (result != null)
                {
                    if(teams.Any(teams => teams.Creator == member) 
                        || teams.Any(team => team.Members.Contains(member)))
                    {
                        Console.WriteLine($"Member {member} cannot join team {teamName}!");
                    }
                    else
                        result.Members.Add(member);
                }
                else
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }

                input = Console.ReadLine();
            }

            List<Team> leftTeams = teams.Where(teams => teams.Members.Count > 0).ToList();
            List<Team> disbandTeams = teams.Where(teams => teams.Members.Count <= 0).ToList();

            List<Team> orderedTeams = leftTeams
            .OrderByDescending(team => team.Members.Count)
            .ThenBy(team => team.Name)
            .ToList();

            orderedTeams.ForEach(team => Console.WriteLine(team));

            Console.WriteLine("Teams to disband:");
            orderedTeams = disbandTeams.OrderBy(x => x.Name).ToList();
            orderedTeams.ForEach(team => Console.WriteLine(team.Name));
        }
    }
    class Team
    {
        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public Team(string name, string creator)
        {
            Members = new List<string>();

            Name = name;
            Creator = creator;
        }

        public override string ToString()
        {
            string result = string.Empty;
            result += $"{Name}\n";
            result += $"- {Creator}\n";
            result += $"-- {String.Join("\n-- ", Members.OrderBy(name => name).ToList())}";
            return result;
        }
    }
}
