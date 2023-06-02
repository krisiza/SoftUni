using System;

namespace _06.MaxNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            int num = 0;
            int num2 = int.MinValue;

            input = Console.ReadLine();

            while (input != "Stop")
            {
                num = int.Parse(input);
                if (num2 < num)
                {
                    num2 = num;
                }

                input = Console.ReadLine();
            }
            Console.WriteLine(num2);
        }
    }
}
