using System;

namespace _07.VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine(); ;
            double sumMoney = 0;

            while(command != "Start")
            {
                double coins = Convert.ToDouble(command);

                if (coins == 0.1 || coins == 0.2 || coins == 0.5 || coins == 1 || coins == 2)
                    sumMoney += coins;
                else
                    Console.WriteLine($"Cannot accept {coins}");

                command = Console.ReadLine();
            }

            string secodCommand = Console.ReadLine();

            while (secodCommand != "End")
            {
                if (secodCommand == "Nuts" && sumMoney >= 2)
                {
                    Console.WriteLine("Purchased nuts");
                    sumMoney -= 2;
                }
                else if (secodCommand == "Water" && sumMoney >= 0.7)
                {
                    Console.WriteLine("Purchased water");
                    sumMoney -= 0.7;
                }
                else if (secodCommand == "Crisps" && sumMoney >= 1.5)
                {
                    Console.WriteLine("Purchased crisps");
                    sumMoney -= 1.5;
                }
                else if (secodCommand == "Soda" && sumMoney >= 0.8)
                {
                    Console.WriteLine("Purchased soda");
                    sumMoney -= 0.8;
                }
                else if (secodCommand == "Coke" && sumMoney >= 1)
                {
                    Console.WriteLine("Purchased coke");
                    sumMoney -= 1;
                }
                else if (secodCommand != "Nuts" && secodCommand != "Water" && secodCommand != "Crisps" && secodCommand != "Soda" && secodCommand != "Coke")
                    Console.WriteLine("Invalid product");
                else
                    Console.WriteLine("Sorry, not enough money");

                secodCommand = Console.ReadLine();
            }

            Console.WriteLine($"Change: {sumMoney:f2}");
        }
    }
}
