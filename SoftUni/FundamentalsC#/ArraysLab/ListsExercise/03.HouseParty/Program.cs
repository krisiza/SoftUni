using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;

namespace _03.HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());

            List<string> names = new List<string>();

            for (int i = 0; i < numOfCommands; i++)
            {
                bool thesameName = false;
                bool removed = false;
                List<string> commands = Console.ReadLine().Split().ToList();

                if (commands[2] == "not")
                {
                    for (int j = 0; j < names.Count; j++)
                    {
                        if (commands[0] == names[j])
                        {
                            names.Remove(names[j]);
                            removed = true;
                        }
                    }

                    if (!removed)
                        Console.WriteLine($"{commands[0]} is not in the list!");
                }
                else
                {
                    foreach (string name in names)
                    {
                        if (name == commands[0])
                            thesameName = true;
                    }
                    if (!thesameName)
                        names.Add(commands[0]);
                    else
                        Console.WriteLine($"{commands[0]} is already in the list!");
                }
            }

            Console.WriteLine(String.Join("\n", names));
        }
    }
}
