using System;

namespace _07.MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int num = 0;
            int num2 = int.MaxValue;

            input = Console.ReadLine();

            while (input != "Stop")
            {
                num = int.Parse(input);
                if (num < num2)
                {
                    num2 = num;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(num2);
        }
    }
}
