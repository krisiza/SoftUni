using System;

namespace _09.CharstoString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char a = char.Parse(Console.ReadLine());
            char b = char.Parse(Console.ReadLine());
            char c = char.Parse(Console.ReadLine());

            string message = "";

            message += a.ToString() + b.ToString() + c.ToString();

            Console.WriteLine(message);


        }
    }
}
