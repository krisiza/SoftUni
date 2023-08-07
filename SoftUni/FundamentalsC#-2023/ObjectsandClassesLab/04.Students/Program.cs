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

            string input = Console.ReadLine();  

            while (input != "end") 
            {
                var arr = input.Split().ToArray();

                Student student = new Student();
                student.FirstName = arr[0];
                student.LastName = arr[1];
                student.Age = int.Parse(arr[2]);
                student.HomeTown= arr[3];

                students.Add(student);

                input= Console.ReadLine();  
            }
            string town = Console.ReadLine();

            foreach (var student in students) 
            {
                if(student.HomeTown == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
            
        }
    }
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}
