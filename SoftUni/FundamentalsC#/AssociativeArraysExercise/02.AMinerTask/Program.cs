using System;
using System.Collections.Generic;

namespace _02.AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            List<string> arr = new List<string>();
            while (input != "stop")
            {
                arr.Add(input);
                input = Console.ReadLine();
            }

            Dictionary<string, int> dic = new Dictionary<string, int>();

            int index = 1;
            for (int i = 0; i < arr.Count; i++)
            {
                if (dic.ContainsKey(arr[i]))
                    dic[arr[i]] += int.Parse(arr[++i]);
                else
                    dic.Add(arr[i], int.Parse(arr[++i]));

            }

            foreach (var d in dic)
            {
                Console.WriteLine($"{d.Key} -> {d.Value}");
            }
        }

    }
}
