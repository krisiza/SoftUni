namespace _02.KnightsofHonor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string> print = s => Console.WriteLine($"Sir {s}");

            foreach (string word in words)
            {
                print(word);
            }
        }
    }
}