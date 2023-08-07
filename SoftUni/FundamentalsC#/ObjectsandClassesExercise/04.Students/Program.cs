using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Student student = new Student();
                string[] arr = Console.ReadLine().Split();
                student.FirstName = arr[0];
                student.LastName = arr[1];
                student.Grade = double.Parse(arr[2]);

                students.Add(student);
            }

            List<Student> sortedList = students.OrderByDescending(s => s.Grade).ToList();
            foreach (Student student in sortedList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName}: {student.Grade:f2}");
            }
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public static implicit operator List<object>(Student v)
        {
            throw new NotImplementedException();
        }
    }
}
