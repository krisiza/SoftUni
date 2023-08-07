using System;

namespace _02.ReportSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double expectedSum = double.Parse(Console.ReadLine());

            string objPrice = Console.ReadLine();
            int counter = 0;
            double input = 0;
            bool sold = false;
            int cashCounter = 0;
            double cashSum = 0;
            int cardCounter = 0;
            double cardSum = 0;
            double sum = 0;
            while (objPrice != "End")
            {
                input = double.Parse(objPrice);
                if (counter % 2 == 0)
                {
                    if (input > 100)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        sold = true;
                        cashCounter++;
                        cashSum += input;
                    }

                }
                else
                {
                    if (input < 10)
                    {
                        Console.WriteLine("Error in transaction!");
                    }
                    else
                    {
                        Console.WriteLine("Product sold!");
                        sold = true;
                        cardCounter++;
                        cardSum += input;
                    }

                }

                sum = cashSum + cardSum;

                if (sum >= expectedSum)
                    break;

                counter++;
                objPrice = Console.ReadLine();
            }

            if (sum >= expectedSum)
            {
                Console.WriteLine($"Average CS: {(cashSum / cashCounter):F2}");
                Console.WriteLine($"Average CC: {(cardSum / cashCounter):F2}");
            }
            if (objPrice == "End")
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
