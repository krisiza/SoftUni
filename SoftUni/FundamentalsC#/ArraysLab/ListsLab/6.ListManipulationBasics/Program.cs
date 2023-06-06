using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.ListManipulationBasics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<string> command = Console.ReadLine().Split().ToList();

            while(command[0] != "end")
            {
                if (command[0] == "Add")
                    numbers.Add(int.Parse(command[1]));
                if (command[0] == "Remove")
                    numbers.Remove(int.Parse(command[1]));               
                if (command[0] == "RemoveAt")
                    numbers.RemoveAt(int.Parse(command[1]));
                if (command[0] == "Insert")
                    numbers.Insert(int.Parse(command[2]), int.Parse(command[1]));

                command = Console.ReadLine().Split().ToList();
            }

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
