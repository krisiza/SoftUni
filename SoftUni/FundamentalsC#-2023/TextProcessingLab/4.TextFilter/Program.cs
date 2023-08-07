using System;
using System.Text;

namespace _4.TextFilter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder resultText = new StringBuilder();

            string[] bannedWords = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            string text = Console.ReadLine();

            for (int i = 0; i < bannedWords.Length; i++)
            {
                string result = new String('*', bannedWords[i].Length);
                text = text.Replace(bannedWords[i], result);
            }
            Console.WriteLine(text);

        }
    }
}
