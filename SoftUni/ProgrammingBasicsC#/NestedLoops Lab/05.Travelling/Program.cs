using System;

namespace _05.Travelling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string dest = "";
            while (true)
            {
                dest = Console.ReadLine();
                if (dest == "End")
                    break;
                double neededBudget = double.Parse(Console.ReadLine());

                double money = 0;
                double salary = 0;
                while (neededBudget > money)
                {
                    salary = double.Parse(Console.ReadLine());
                    money += salary;

                    if (money >= neededBudget)
                    {
                        Console.WriteLine("Going to " + dest + "!");
                    }
                }

            }
        }
    }
}
