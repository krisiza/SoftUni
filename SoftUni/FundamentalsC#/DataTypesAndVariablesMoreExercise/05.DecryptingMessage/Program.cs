using System;

namespace _05.DecryptingMessage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int key = int.Parse(Console.ReadLine());
            int numberLines = int.Parse(Console.ReadLine());
            string message = "";
            for(int i = 0; i < numberLines; i++) 
            {
                int index = 0;
                char letter = char.Parse(Console.ReadLine());
                index = letter + key;

                char ch = Convert.ToChar(index);
                message += ch;
            }

            Console.WriteLine(message);
        }
    }
}
