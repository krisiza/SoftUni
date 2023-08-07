using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.StudentAcademy
{
    /*
5
John
5,5
John
4,5
Alice
6
Alice
3
George
5
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string,List<double>> studens = new Dictionary<string, List<double>>();

            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++) 
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if(!studens.ContainsKey(name)) 
                {
                    studens[name] = new List<double>();
                    studens[name].Add(grade);
                }
                else
                {
                    studens[name].Add(grade);
                }
            }

            var topStudents = new Dictionary<string, double>();

            foreach (var s in studens)
            {
                double average = s.Value.Average();

                if(average >= 4.5) 
                {
                    topStudents[s.Key] = average;
                }
            }

            foreach(var s in topStudents) 
            {
                Console.WriteLine($"{s.Key} -> {s.Value:f2}");
            }
        }
    }
}
