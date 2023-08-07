using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CompanyRoster
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Employee> employees = new List<Employee>();
            List<string> departaments = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string[] arr = Console.ReadLine().Split();

                string emName = arr[0];
                decimal emSalary = decimal.Parse(arr[1]);
                string emDepartament = arr[2];

                departaments.Add(emDepartament);

                Employee employee = new Employee(emName, emSalary, emDepartament);
                employees.Add(employee);

            }

            decimal bestAverage = 0;
            string bestDepartament = null;
            foreach (string dep in departaments)
            {
                decimal agerage = employees
                    .Where(emp => emp.Departament == dep)
                    .Select(emp => emp.Salary)
                    .DefaultIfEmpty()
                    .Average();

                if (bestAverage < agerage)
                {
                    bestAverage = agerage;
                    bestDepartament = dep;
                }
            }

            Console.WriteLine($"Highest Average Salary: {bestDepartament}");

            List<Employee> bestEmp = employees
                .Where(x => x.Departament == bestDepartament)
                .OrderByDescending(x => x.Salary).ToList();
            bestEmp.ForEach(x => Console.WriteLine(x));
        }
    }
    class Employee
    {
        public Employee(string name, decimal salary, string departament)
        {
            Name = name;
            Salary = salary;
            Departament = departament;
        }

        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Departament { get; set; }

        public override string ToString()
        {
            return $"{Name} {Salary:f2}";
        }
    }
}
