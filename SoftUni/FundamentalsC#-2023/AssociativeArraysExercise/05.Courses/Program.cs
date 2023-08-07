using System;
using System.Collections.Generic;

namespace _05.Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input = Console.ReadLine();

            while(input != "end") 
            {
                string[] arr = input.Split(':');

                string cours = arr[0];
                string student = arr[1];

                if(!courses.ContainsKey(cours)) 
                {
                    courses[cours] = new List<string>();
                    courses[cours].Add(student);
                }
                else
                {
                    courses[cours].Add(student);
                }
                
                input = Console.ReadLine();
            }

            foreach(var c in courses) 
            {
                Console.WriteLine($"{c.Key.Trim()}: {c.Value.Count}");
                Console.Write("--");
                Console.WriteLine(String.Join("\n--",c.Value));
            }
        }
    }
}
