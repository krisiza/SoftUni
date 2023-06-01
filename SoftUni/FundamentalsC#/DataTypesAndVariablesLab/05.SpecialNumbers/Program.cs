using System;

namespace _05.SpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            int number = 0;
            for(int i = 1; i <= num; i++) 
            {
                int sum = 0;
                number = i;

                sum += (number % 10);
                sum += number / 10;
                if (number == 5 || number == 7 || sum == 5 || sum == 7 || sum == 11)
                    Console.WriteLine($"{number} -> True");
                else
                    Console.WriteLine($"{number} -> False");     
            }
        }
    }
}
