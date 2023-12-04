namespace _9.PredicateParty_
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> peopleComing = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] commands = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var predicate = GetPredicate(commands[1], commands[2]);

                switch (commands[0])
                {
                    case "Double":

                        var matches = peopleComing.FindAll(predicate);
                        if (matches.Count > 0)
                        {
                            var index = peopleComing.FindIndex(predicate);
                            peopleComing.InsertRange(index, matches);
                        }

                        break;

                    case "Remove":

                        peopleComing.RemoveAll(predicate);

                        break;
                }

                command = Console.ReadLine();
            }

            if (peopleComing.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", peopleComing)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static Predicate<string> GetPredicate(string commandType, string arg)
        {
            switch (commandType)
            {
                case "StartsWith":
                    return name => name.StartsWith(arg);

                case "EndsWith":
                    return name => name.EndsWith(arg);

                case "Length":
                    return name => name.Length == int.Parse(arg);

                default:
                    return default;
            }
        }
    }
}