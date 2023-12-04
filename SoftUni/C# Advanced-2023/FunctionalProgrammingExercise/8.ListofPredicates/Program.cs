namespace _8.ListofPredicates
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] dividers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> divisibleNumbers = new List<int>();

            for (int i = 1; i <= n; i++)
            {
                bool add = true;

                foreach (int divider in dividers)
                {
                    Predicate<int> divisible = number => number % divider != 0;
                    Func<int, bool> filter = x => divisible(x);

                    if (filter(i))
                    {
                        add = false;
                        break;
                    }
                }

                if (add)
                    divisibleNumbers.Add(i);
            }

            Console.WriteLine(string.Join(" ", divisibleNumbers));
        }
    }
}