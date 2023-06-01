using System;

namespace _12.RefactorSpecialNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            bool specialNumber = false;
            for (int i = 1; i <= number; i++)
            {
                int sum = 0;
                int index = i;
                while (i > 0)
                {
                    sum += i % 10;
                    i = i / 10;
                }
                specialNumber = (sum == 5) || (sum == 7) || (sum == 11);
                Console.WriteLine("{0} -> {1}", index, specialNumber);
                sum = 0;
                i = index;
            }

        }
    }
}
