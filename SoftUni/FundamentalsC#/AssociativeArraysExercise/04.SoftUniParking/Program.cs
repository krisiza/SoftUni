using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _04.SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, string> dic = new Dictionary<string, string>();
            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                string command = arr[0];
                string name = arr[1];

                if (command == "register")
                {
                    string num = arr[2];

                    if (dic.ContainsKey(name))
                    {
                        Console.WriteLine("ERROR: already registered with plate number " + dic[name]);
                    }

                    else
                    {
                        dic[name] = num;
                        Console.WriteLine($"{name} registered {num} successfully");
                    }
                }
                else
                {
                    if (!dic.Keys.Contains(name))
                    {
                        Console.WriteLine($"ERROR: user {name} not found");
                    }
                    else
                    {
                        Console.WriteLine($"{name} unregistered successfully");
                        dic.Remove(name);
                    }
                }
            }
            foreach (var d in dic)
            {
                Console.WriteLine($"{d.Key} => {d.Value}");
            }

        }
    }
}
