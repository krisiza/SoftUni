namespace _09.SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> submissions = new();
            Dictionary<string, int> users = new();

            string input = Console.ReadLine();

            while (input != "exam finished")
            {
                string[] arr = input.Split("-", StringSplitOptions.RemoveEmptyEntries);

                string name = arr[0];
                string language = arr[1];

                if (language == "banned")
                {
                    users.Remove(name);
                }
                else
                {
                    int points = int.Parse(arr[2]);

                    if (!users.ContainsKey(name))
                        users.Add(name, points);
                    else
                    {
                        if (points > users[name])
                            users[name] = points;
                    }

                    if (!submissions.ContainsKey(language))
                        submissions.Add(language, 0);

                    submissions[language]++;
                }

                input = Console.ReadLine();
            }

            users = users.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            submissions = submissions.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Results:");

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key} | {user.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var sub in submissions)
            {
                Console.WriteLine($"{sub.Key} - {sub.Value}");
            }
        }
    }
}