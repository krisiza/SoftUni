using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _02.OldestFamilyMember
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Family family = new Family();

            for(int i = 0; i < n; i++) 
            {
                string[] arr = Console.ReadLine().Split();

                string name = arr[0];
                int age = int.Parse(arr[1]);

                Person person = new Person(name, age);

                family.AddMember(person);
            }

           var oldestMember = family.GetOldestMember();
            Console.WriteLine($"{oldestMember.Name} {oldestMember.Age}");
        }
    }
    class Family
    {
        public Family() 
        {
            People= new List<Person>();
        }
        public void AddMember(Person member)
        {
            People.Add(member);
        }
        public Person GetOldestMember()
        {
            var oldestPerson = People.OrderByDescending(x => x.Age).FirstOrDefault();

            return oldestPerson;
        }
        public List<Person> People { get; set; }
        public Person perosn { get; set; }

    }
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }    
    }
}
