namespace _07.PredicateForNames
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int nameLength = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Predicate<int> filterLength = length => length <= nameLength;
            Func<int, bool> filter = x => filterLength(x);
            List<string> filteredNames = new List<string>();

            foreach (string name in names)
            {
                if (filter(name.Length))
                    filteredNames.Add(name);
            }

            Console.WriteLine(string.Join("\n", filteredNames));
        }
    }
}