using System;

namespace _06.NumberinRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            if (num <= 100 && num >= -100 && num != 0)
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
    }
}
