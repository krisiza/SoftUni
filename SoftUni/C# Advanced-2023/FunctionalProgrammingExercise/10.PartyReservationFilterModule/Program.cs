namespace _10.PartyReservationFilterModule
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> people = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            Dictionary<string, int> removedPeople = new Dictionary<string, int>();

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] tokens = command.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var predicate = GetPredicate(tokens[1], tokens[2]);
                Func<string, bool> filter = x => predicate(x);

                switch (tokens[0])
                {
                    case "Add filter":
                        var matches = people.FindAll(predicate);

                        foreach (var match in matches)
                        {
                            if (!removedPeople.ContainsKey(match))
                                removedPeople.Add(match, 0);

                            var index = people.FindIndex(predicate);

                            if (index != -1)
                                removedPeople[match] = index;
                        }
                        people.RemoveAll(predicate);
                        break;

                    case "Remove filter":

                        foreach (var pair in removedPeople)
                        {
                            if (filter(pair.Key))
                            {
                                if (pair.Value > people.Count - 1)
                                    people.Insert(people.Count, pair.Key);
                                else
                                    people.Insert(pair.Value, pair.Key);
                            }
                        }

                        break;
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", people));
        }

        private static Predicate<string> GetPredicate(string command, string parameter)
        {
            switch (command)
            {
                case "Ends with":
                    return name => name.EndsWith(parameter);

                case "Starts with":
                    return name => name.StartsWith(parameter);

                case "Length":
                    return name => name.Length == int.Parse(parameter);

                case "Contains":
                    return name => name.Contains(parameter);

                default:
                    return null;
            }
        }
    }
}