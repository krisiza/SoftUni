namespace _3.CountUppercaseWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string[] upperCaseWords = words.Where(word =>  char.IsUpper(word[0])).ToArray();

            Console.WriteLine(string.Join("\n", upperCaseWords));
        }


    }
}