using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ChangeList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> command = Console.ReadLine().Split().ToList();

            while (command[0] != "end")
            {
                if (command[0] == "Delete")
                    ints.RemoveAll(i => i == int.Parse(command[1]));
                if (command[0] == "Insert")
                    ints.Insert(int.Parse(command[2]), int.Parse(command[1]));

                command = Console.ReadLine().Split().ToList();
            }
            Console.WriteLine(String.Join(" ", ints));
        }
    }
}
