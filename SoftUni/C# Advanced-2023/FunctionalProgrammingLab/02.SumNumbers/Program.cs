namespace _02.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] intigers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(intigers.Count());
            Console.WriteLine(intigers.Sum());
        }
    }
}