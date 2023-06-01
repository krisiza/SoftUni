using System;

namespace SpiceMustFlow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int sumSpice = 0;
            int days = 0;

            while (startingYield >= 100)
            {
                sumSpice += startingYield;
                startingYield -= 10;

                sumSpice -= 26;

                if (sumSpice < 0)
                    break;
                days++;
            }

                sumSpice -= 26;

            if(sumSpice < 0)
                sumSpice = 0;

            Console.WriteLine(days);
            Console.WriteLine(sumSpice);

        }
    }
}
