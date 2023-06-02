using System;

namespace _05.Salary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool noMoreMoney = false;
            int windows = int.Parse(Console.ReadLine());
            double salary = double.Parse(Console.ReadLine());

            for (int i = 1; i <= windows; i++)
            {
                string site = Console.ReadLine();

                switch (site)
                {
                    case "Facebook":
                        salary -= 150;
                        break;
                    case "Instagram":
                        salary -= 100;
                        break;
                    case "Reddit":
                        salary -= 50;
                        break;
                }

                if (salary <= 0)
                {
                    noMoreMoney = true;
                    break;
                }
            }

            if (noMoreMoney)
                Console.WriteLine("You have lost your salary.");
            else
                Console.WriteLine(salary);
        }
    }
}
