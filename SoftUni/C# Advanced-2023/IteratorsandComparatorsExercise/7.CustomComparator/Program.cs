namespace _7.CustomComperator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, int> compare = (x, y) =>
            {
                if (x % 2 == 0 && y % 2 == 1)
                {
                    return 1;
                }

                if (x % 2 == 1 && y % 2 == 0)
                {
                    return 0;
                }

                return x.CompareTo(y);
            };

            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Array.Sort(numbers, (x, y) => compare(x,y));

            Console.WriteLine(string.Join(" ", numbers));
        }
    }  
}