using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.TeamworkProjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {

                string[] arr = Console.ReadLine().Split('-');               

                string user = arr[0];
                string team = arr[1];

                Team teamN = new Team(team, user);

                 teamN.Members.FirstOrDefault(x => x.Contains(team));

                foreach (Collection col in collections)
                {
                    if (arr[0] == col.User.Name)
                    {
                        Console.WriteLine($"{col.User.Name} cannot create another team!");
                        addToCollection = false;
                        break;
                    }
                }
                if (addToCollection)
                {
                    collection.Team.Name = arr[1];
                    collection.User.Name = arr[0];
                    collections.Add(collection);
                }

                Console.WriteLine($"Team {collection.Team.Name} has been created by {collection.User.Name}!");
            }
            string input = Console.ReadLine();

            while (input != "end of assignment")
            {
                bool teamFound = false;
                bool nameFound = false;
                Collection collection = new Collection();
                Member participant = new Member();

                string[] arr = input.Split("->");

                participant.Name = arr[0];

                foreach (Collection col in collections)
                {
                    if (arr[1] == col.Team.Name)
                        teamFound = true;
                }
                if (!teamFound)
                    Console.WriteLine($"Team {arr[1]} does not exist!");
                else
                {

                    for (int i = 0; i < collections.Count; i++)
                    {
                        foreach (Member m in collections[i].Team.Members)
                        {
                            if (m.Name == participant.Name)
                            {
                                nameFound = true;
                                Console.WriteLine($"Member {arr[0]} cannot join team {arr[1]}!");
                                break;
                            }
                        }

                        if (collections[i].User.Name == participant.Name)
                        {
                            nameFound = true;
                            Console.WriteLine($"Member {arr[0]} cannot join team {arr[1]}!");
                            break;
                        }

                        if (nameFound)
                            break;
                    }

                    if (!nameFound && teamFound)
                    {
                        foreach (Collection c in collections)
                        {
                            if (arr[1] == c.Team.Name)
                            {
                                c.Team.Members.Add(participant);
                                break;
                            }
                        }
                    }
                }
                input = Console.ReadLine();
            }

            List<Collection> sortedList = new List<Collection>();




            for (int i = 0; i < collections.Count; i++)
            {
                if (collections[i].Team.Members.Count > 0)
                {
                    Console.WriteLine(collections[i].Team.Name);
                    Console.WriteLine($"-{collections[i].User.Name}");
                    foreach (Member m in collections[i].Team.Members)
                    {
                        Console.WriteLine($"--{m.Name}");
                    }
                }
            }
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
    }
}
