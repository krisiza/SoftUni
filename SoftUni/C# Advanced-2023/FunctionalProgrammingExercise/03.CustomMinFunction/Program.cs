namespace _03.CustomMinFunction
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] intigers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> smallestInt = numbers => numbers.Min();

            Console.WriteLine(smallestInt(intigers));
        }
    }
}