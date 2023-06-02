using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double neededMoney = double.Parse(Console.ReadLine());
            double ownedMoney = double.Parse(Console.ReadLine());

            int daysCounter = 0;
            int spendingCounter = 0;

            while (ownedMoney < neededMoney && spendingCounter < 5)
            {
                string command = Console.ReadLine();
                double money = double.Parse(Console.ReadLine());

                if (command == "spend")
                {
                    daysCounter++;
                    spendingCounter++;
                    ownedMoney -= money;
                    if (ownedMoney < 0)
                        ownedMoney = 0;
                    if (spendingCounter == 5)
                    {
                        break;
                    }
                }
                if (command == "save")
                {
                    daysCounter++;
                    ownedMoney += money;
                    spendingCounter = 0;
                    if (ownedMoney >= neededMoney)
                    {
                        break;
                    }
                }
            }

            if (spendingCounter == 5)
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(daysCounter);
            }
            if (ownedMoney >= neededMoney)
            {
                Console.WriteLine($"You saved the money for {daysCounter} days.");
            }
        }
    }
}
