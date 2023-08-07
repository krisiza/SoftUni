using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04.ListOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<string> commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            while (commands[0] != "End")
            {
                string act = commands[0];

                if (commands[0] == "Add")
                {
                    int numAct = int.Parse(commands[1]);
                    numbers.Add(numAct);
                }
                else if (act == "Insert")
                {
                    int numAct = int.Parse(commands[1]);
                    int indexInsert = int.Parse(commands[2]);

                    if (indexInsert < numbers.Count && indexInsert >= 0)
                        numbers.Insert(indexInsert, numAct);
                    else
                        Console.WriteLine("Invalid index");
                }
                else if (act == "Remove")
                {
                    int numAct = int.Parse(commands[1]);
                    if (numAct < numbers.Count && numAct >= 0)
                        numbers.RemoveAt(numAct);              
                    else
                        Console.WriteLine("Invalid index");
                }
                else if (act == "Shift" && commands[1] == "left")
                {
                    int times = int.Parse(commands[2]);
                    for (int i = 0; i < times; i++)
                    {
                        int temp = numbers[0];
                        for (int j = 0; j < numbers.Count - 1; j++)
                        {
                            numbers[j] = numbers[j + 1];
                        }
                        numbers[numbers.Count - 1] = temp;
                    }
                }
                else if (commands[0] == "Shift" && commands[1] == "right")
                {
                    int times = int.Parse(commands[2]);
                    for (int i = 0; i < times; i++)
                    {
                        int temp = numbers[numbers.Count - 1];
                        for (int j = numbers.Count - 1; j > 0; j--)
                        {
                            numbers[j] = numbers[j - 1];
                        }
                        numbers[0] = temp;
                    }
                }

                commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
