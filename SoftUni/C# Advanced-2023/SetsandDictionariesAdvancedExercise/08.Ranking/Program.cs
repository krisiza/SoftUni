using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace _08.Ranking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> contests = new Dictionary<string, string>();

            while (input != "end of contests")
            {
                string[] arr = input
                    .Split(":");

                if (!contests.ContainsKey(arr[0]))
                {
                    contests.Add(arr[0], arr[1]);
                }

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            List<User> users = new List<User>();

            while (input != "end of submissions")
            {
                string[] arr = input
                    .Split("=>");

                string contest = arr[0];
                string password = arr[1];
                string username = arr[2];
                int points = int.Parse(arr[3]);

                if (contests.ContainsKey(contest) && contests[contest] == password)
                {
                    User user = new User(username);
                    Contest cont = new Contest(contest, points);

                    var currentUser = users.FirstOrDefault(x => x.Name == username);

                    if (currentUser == null)
                    {
                        users.Add(user);
                        user.Contests.Add(cont);
                    }
                    else
                    {
                        var currentContent = currentUser.Contests.FirstOrDefault(x => x.Name == contest);

                        if (currentContent == null)
                        {
                            currentUser.Contests.Add(cont);
                        }
                        else
                        {
                            //!!
                            if (currentUser.Contests.Find(x => x.Name == contest).Points < points)
                                currentUser.Contests.Find(x => x.Name == contest).Points = points;
                        }
                    }
                }

                input = Console.ReadLine();
            }
            int maxPoints = int.MinValue;

            User bestCandidate = null;

            foreach (var user in users)
            {
                int sum = user.Contests.Sum(x => x.Points);

                if (sum > maxPoints)
                {
                    maxPoints = sum;
                    bestCandidate = user;
                }
            }

            Console.WriteLine($"Best candidate is {bestCandidate.Name} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");

            users = users.OrderBy(x => x.Name).ToList();

            foreach(var user in users) 
            {
                Console.WriteLine(user.Name);

                user.Contests = user.Contests.OrderByDescending(x => x.Points).ToList();

                foreach(var cont in user.Contests) 
                {
                    Console.WriteLine($"#  {cont.Name} -> {cont.Points}");
                }
            }
        }
    }

    public class User
    {
        public User(string name)
        {
            Name = name;
            Contests = new List<Contest>();
        }

        public string Name { get; set; }

        public List<Contest> Contests { get; set; }
    }
    public class Contest
    {
        public string Name { get; set; }

        public int Points { get; set; }


        public Contest(string name, int points)
        {
            Name = name;
            Points = points;
        }
    }
}