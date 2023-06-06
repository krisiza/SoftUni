using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> command = Console.ReadLine().Split().ToList();
            bool listChanged = false;

            while (command[0] != "end")
            {
                if (command[0] == "Add")
                {
                    numbers.Add(int.Parse(command[1]));
                    listChanged = true;
                }
                if (command[0] == "Remove")
                {
                    numbers.Remove(int.Parse(command[1]));
                    listChanged = true;
                }
                if (command[0] == "RemoveAt")
                {
                    numbers.RemoveAt(int.Parse(command[1]));
                    listChanged = true;
                }
                if (command[0] == "Insert")
                {
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));
                    listChanged = true;
                }

                if (command[0] == "Contains")
                {
                    if (numbers.Contains(int.Parse(command[1])))
                        Console.WriteLine("Yes");
                    else
                        Console.WriteLine("No such number");
                }
                if (command[0] == "PrintEven")
                    PrintEven(numbers);
                if (command[0] == "PrintOdd")
                    PrintOdd(numbers);
                if (command[0] == "GetSum")
                    Console.WriteLine(numbers.Sum());
                if (command[0] == "Filter")
                    Filter(numbers, command[1], command[2]);
  
                command = Console.ReadLine().Split().ToList();
            }

            if (listChanged)
                Console.WriteLine(String.Join(" ", numbers));
        }
        static void PrintEven(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] % 2 == 0)
                    Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
        static void PrintOdd(List<int> numbers)
        {
            for(int i = 0; i < numbers.Count; i++) 
            {
                if (numbers[i] % 2 == 1)
                    Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
        }
        static void Filter(List<int> numbers, string command1, string command2)
        {
            if (command1 == ">=")
                Console.WriteLine(String.Join(" ",numbers.FindAll(n => n >= int.Parse(command2))));
            if (command1 == "<=")
                Console.WriteLine(String.Join(" ", numbers.FindAll(n => n <= int.Parse(command2))));
            if (command1 == ">")
                Console.WriteLine(String.Join(" ", numbers.FindAll(n => n > int.Parse(command2))));
            if (command1 == "<")
                Console.WriteLine(String.Join(" ", numbers.FindAll(n => n < int.Parse(command2))));
        }
    }
}
