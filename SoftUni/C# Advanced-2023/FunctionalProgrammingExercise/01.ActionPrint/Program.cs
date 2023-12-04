namespace _01.ActionPrint
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Action<string[]> print = s => Console.WriteLine(string.Join(Environment.NewLine, s));

            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            print(words);
        }
    }
}