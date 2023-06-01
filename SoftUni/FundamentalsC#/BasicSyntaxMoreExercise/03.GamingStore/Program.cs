using System;

namespace _03.GamingStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());
            string command = Console.ReadLine();

            double totalSpent = 0;
            while (command != "Game Time")
            {
                if (command == "OutFall 4")
                {
                    if (balance < 39.99)
                        Console.WriteLine("Too Expensive");
                    else
                    { 
                        balance -= 39.99;
                        totalSpent += 39.99;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "CS: OG")
                {
                    if (balance < 15.99)
                        Console.WriteLine("Too Expensive");
                    else
                    { 
                        balance -= 15.99;
                        totalSpent += 15.99;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "Zplinter Zell")
                {
                    if (balance < 19.99)
                    Console.WriteLine("Too Expensive");
                    else
                    { 
                        balance -= 19.99;
                        totalSpent += 19.99;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "Honored 2")
                {
                    if (balance < 59.99)
                        Console.WriteLine("Too Expensive");
                    else
                    { 
                        balance -= 59.99;
                        totalSpent += 59.99;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "RoverWatch")
                {
                    if (balance < 29.99)
                        Console.WriteLine("Too Expensive");
                    else
                    { 
                        balance -= 29.99;
                        totalSpent += 29.99;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else if (command == "RoverWatch Origins Edition")
                {
                    if (balance < 39.99)
                        Console.WriteLine("Too Expensive");
                    else
                    {
                        balance -= 39.99;
                        totalSpent += 39.99;
                        Console.WriteLine($"Bought {command}");
                    }
                }
                else
                    Console.WriteLine("Not Found");

                if (balance <= 0)
                {
                    Console.WriteLine("Out of money!");
                    return;
                }

                command= Console.ReadLine();

            }

            Console.WriteLine($"Total spent: ${totalSpent:f2}. Remaining: ${balance:f2}");
        }
    }
}
